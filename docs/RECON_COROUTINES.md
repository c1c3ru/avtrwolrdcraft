# Corrotinas e máquinas de estado — inventário (T026, parcial)

Ferramenta: `tools/recon_coroutines.py` → `out/recon/tasks/T032/coroutines.jsonl` (uma linha por `MoveNext`). O dono vem de `Il2CppTypeDefinition.declaringTypeIndex` (offset `+12`, que é índice de `Il2CppType` e mapeia por `byvalTypeIndex`); isso desambigua nomes repetidos como `<SyncPosition>d__75` (a de `DragDropItemBase`) e `<SyncPosition>d__5` (outra classe).

## Provado
- **437** máquinas de estado em `Assembly-CSharp`, **268** classes donas. Todas são enumeradores (`IEnumerator`); nenhuma chama os builders `AsyncTaskMethodBuilder`/`AsyncVoidMethodBuilder` dentro da janela do `MoveNext`.
- Por área do dono: gameplay de nível (`Game.Level`/`PWC.Level`) 138; SDK/framework (`PazuCore`, Google, Firebase) 92; QA/automação (`PWC.QA.*`, que não faz parte do jogo para o jogador) 80; outros 72; mundo/home/loja 31; multiplayer 24.
- Maiores: `LobbyHelloWorld.ExecuteLobbyDemoAsync` e `RTAStoreTester.TestStorePackItemAsync_Internal` (12.288 bytes, ambos demo/QA), `AvatarMakerThumbsManager.AfterThumbsScaleDownAnimation` (7.788 bytes, gameplay) e `LevelQAManager.Init`.
- Corrotinas de gameplay ligadas a entidades já mapeadas: `DragDropItemBase.SyncPosition` (1.008 bytes, por quadro; chama `OnSyncPosition`, ver `RECON_INPUT_CONTRACT.md`), `LevelCharacterSummoningBellItemHandler.CallCharacterCoroutine` (272 bytes), `LevelItemsMenuShopPack.PlayAlternateIdleAnimations` (524 bytes), `LevelItemsChangerItemHandler.Changing` (628 bytes).

## Para o escopo do jogo
Dos 437, só as de gameplay (138) e mundo/home/loja (31), ou seja 169, interessam à reimplementação; QA (80), demos de lobby e SDK podem ser excluídas por decisão de escopo (T006).

## Limites
- Contagem de "chamadas de espera" no JSON (`wait_calls`) é **indício** por nome de chamada direta (`WaitFor*`, `Tween*`, `StartCoroutine`...), não prova de quando/quanto espera: valores como `WaitForSeconds(x)` não foram extraídos (ficam em constantes de `.rodata`, como nas constantes do animator).
- Não foram decodificados os estados (`<>1__state`) nem a ordem de `yield`: exige ler o `MoveNext` por método (como foi feito com `SyncPosition`, cujas chamadas de slot 25/26/27 foram provadas).
- Corrotinas iniciadas por reflexão, por delegate ou por `StartCoroutine` indireto não aparecem como chamadores.
