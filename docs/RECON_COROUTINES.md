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

---

# T025 (parcial): extensões de método validadas
Ferramenta: `tools/recon_method_extents.py` → `out/recon/method-extents.jsonl`. O mapa de métodos marcava a extensão como `UNKNOWN_not_inferred_from_next_pointer`. Teste: para cada método, a última instrução antes do início do próximo é um terminador (`ret`, `b`, `br`, `brk`) ou um `bl` para helper sem retorno (alvo que encerra ≥ 50 métodos: `0x1914dc0`, `0x1b8884c`, `0x1b88980`, `0x1b88988`, `0x1b88d1c`).
Resultado: **35.825 de 35.830** extensões (99,986%) são consistentes (ret 9.947, b 8.814, bl-noreturn 16.802, br 267). Os 5 restantes ficam sem validação.
Leitura correta: é **consistência forte**, não prova formal por método. Um corte errado raramente cairia logo após um terminador em 35 mil casos, então "início do próximo método = fim do atual" passa a ser a regra adotada, com janela máxima por método quando o próximo está longe. Isso sustenta `tools/recon_disasm.py`, `recon_method_literals.py` e `recon_coroutines.py`, que usam essa janela.
Não coberto: pools de literais embutidos entre métodos (não observados), blocos frios fora da janela e corpos de métodos genéricos compartilhados.

## Decisao de escopo (2026-11-05, usuario)
As 80 corrotinas de QA/automacao (`PWC.QA.*`, `RTA*`) e as demos de lobby (`LobbyHelloWorld`) ficam **excluidas da reimplementacao**. Escopo restante de corrotinas: gameplay (138) e mundo/home/loja (31), ou seja 169, mais as de multiplayer e SDK apenas se uma tarefa futura as exigir. Isso so afeta o inventario; os dados de `coroutines.jsonl` nao foram apagados.

---

# T026 (parcial): durações de `WaitForSeconds`
Ferramentas: `tools/recon_image_methods.py` (mapa método→VA de qualquer imagem; gerado `UnityEngine.CoreModule`: 2.903 métodos, 2.598 com código; `WaitForSeconds..ctor` em `0x3cd11cc`, `WaitForSecondsRealtime..ctor` em `0x3cd12c8`) e `tools/recon_waits.py` (capstone; para cada `bl` ao construtor recua até a instrução que define `s0`: `fmov` imediato, `adrp`+`ldr` do `.rodata`, `mov`/`movk`+`fmov`, ou segue cópias `fmov sA, sB`). Saída: `out/recon/tasks/T032/waits.jsonl`.

## Provado
- **146 corrotinas** criam `WaitForSeconds`/`WaitForSecondsRealtime`, num total de **230** esperas.
- **166 esperas têm duração constante** (72%): `fmov` imediato 109, `.rodata` 53, `mov`+`fmov` 2, zero 2. As outras **64 são dinâmicas** (valor vindo de campo ou cálculo; sem constante no código; para essas o valor está nos dados serializados ou em tempo de execução).
- Durações mais comuns: 1,0 s (43), 0,5 s (23), 0,3 s (21), 2,0 s (8), 0,1 s (7), 3,0 s (7), 0,25 s (7), 0,4 s (6), 1,5 s (5), 0,02 s (4), 5,0 s (4), 0,6 s (4).
- Amostra conferida à mão no disassembly (`LevelClawMachine.PlayLightsSequence`, `0x1f24e10`): `bl 0x1b88970` (alocação), `adrp`+`ldr s0` de `0xb2ff08` (0,02 s) e `bl 0x3cd11cc` (construtor); outro sítio com `fmov s0, #0.5`.

## Limites
- Só cobre `WaitForSeconds` e `WaitForSecondsRealtime`; não extrai `WaitUntil`, `WaitForEndOfFrame`, `yield return null`, tweens nem corrotinas aninhadas, nem a ordem dos `yield`.
- Exclui nada por escopo: as 80 corrotinas de QA/lobby (decisão do usuário) continuam no arquivo, filtre por dono ao usar.
- O valor é o da instrução mais próxima que define `s0`; esperas cujo `s0` foi calculado em outro bloco ficam como dinâmicas (subestima as constantes).
