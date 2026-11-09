# Corrotinas e máquinas de estado — inventário (T026, parcial)

Ferramenta: `tools/recon_coroutines.py` → `out/recon/tasks/T032/coroutines.jsonl` (uma linha por `MoveNext`). O dono vem de `Il2CppTypeDefinition.declaringTypeIndex` (offset `+12`, que é índice de `Il2CppType` e mapeia por `byvalTypeIndex`); isso desambigua nomes repetidos como `<SyncPosition>d__75` (a de `DragDropItemBase`) e `<SyncPosition>d__5` (outra classe).

## Provado
- **437 entradas do filtro histórico por nomes**, distribuídas por 268 donos. A reconciliação por interfaces identifica **380 enumeradores e 57 async** nesse conjunto. Mais 12 tipos levam o inventário direto a 449; ausência de chamadas nomeadas a builders no scan antigo não demonstrava ausência de async.
- Por área do dono: gameplay de nível (`Game.Level`/`PWC.Level`) 138; SDK/framework (`PazuCore`, Google, Firebase) 92; QA/automação (`PWC.QA.*`, que não faz parte do jogo para o jogador) 80; outros 72; mundo/home/loja 31; multiplayer 24.
- Maiores: `LobbyHelloWorld.ExecuteLobbyDemoAsync` e `RTAStoreTester.TestStorePackItemAsync_Internal` (12.288 bytes, ambos demo/QA), `AvatarMakerThumbsManager.AfterThumbsScaleDownAnimation` (7.788 bytes, gameplay) e `LevelQAManager.Init`.
- Corrotinas de gameplay ligadas a entidades já mapeadas: `DragDropItemBase.SyncPosition` (1.008 bytes, por quadro; chama `OnSyncPosition`, ver `RECON_INPUT_CONTRACT.md`), `LevelCharacterSummoningBellItemHandler.CallCharacterCoroutine` (272 bytes), `LevelItemsMenuShopPack.PlayAlternateIdleAnimations` (524 bytes), `LevelItemsChangerItemHandler.Changing` (628 bytes).

## Para o escopo do jogo
O agrupamento histórico de gameplay (138) e mundo/home/loja (31), total 169, é um subconjunto por prefixes. O inventário atualizado mantém outros candidatos Game/PWC e dependências necessárias. A exclusão autorizada de QA/lobby está preservada; SDK e multiplayer exigem disposição por dependência, sem exclusão automática.

## Limites
- Contagem de "chamadas de espera" no JSON (`wait_calls`) é **indício** por nome de chamada direta (`WaitFor*`, `Tween*`, `StartCoroutine`...), não prova de quando/quanto espera: valores como `WaitForSeconds(x)` não foram extraídos (ficam em constantes de `.rodata`, como nas constantes do animator).
- Não foram decodificados os estados (`<>1__state`) nem a ordem de `yield`: exige ler o `MoveNext` por método (como foi feito com `SyncPosition`, cujas chamadas de slot 25/26/27 foram provadas).
- Corrotinas iniciadas por reflexão, por delegate ou por `StartCoroutine` indireto não aparecem como chamadores.

---

# T025 (parcial): extensões de método validadas
Ferramenta: `tools/recon_method_extents.py` → `out/recon/method-extents.jsonl`. O mapa de métodos marcava a extensão como `UNKNOWN_not_inferred_from_next_pointer`. Teste: para cada método, a última instrução antes do início do próximo é um terminador (`ret`, `b`, `br`, `brk`) ou um `bl` para helper sem retorno (alvo que encerra ≥ 50 métodos: `0x1914dc0`, `0x1b8884c`, `0x1b88980`, `0x1b88988`, `0x1b88d1c`).
Resultado: **35.825 de 35.830** extensões (99,986%) são consistentes (ret 9.947, b 8.814, bl-noreturn 16.802, br 267). Os 5 restantes ficam sem validação.
Leitura correta: trata-se de **heurística de consistência**, não prova de extensão por método. A frequência de chamadas terminais também não prova que um helper seja noreturn. As ferramentas citadas usam o próximo início como janela de inspeção, que pode omitir blocos frios, regiões não contíguas e exceções; essa janela não autoriza marcar um corpo completo.
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

## Continuação T026 — ciclo e hook do loading (2026-11-07)

Recuperadas a tabela de estados e as entradas/saídas de ExecuteNextFrameCoroutine, incluindo Dispose/Current/Reset e callback nulo, e identificadas duas chamadas add/remove do hook sceneLoaded sob resolução virtual condicional. Contrato, limites e 16 testes focados: [RECON_T026_NEXT_FRAME.md](RECON_T026_NEXT_FRAME.md).

A palavra “Provado” nas contagens históricas não deve ser estendida à semântica de todas as máquinas. O scan usa nomes de tipos e chamadas diretas num índice limitado; ausência de AsyncTaskMethodBuilder nesse scan não comprova ausência de async. Terminador ao fim de uma janela é evidência de consistência local; não prova todos os corpos/CFGs ou que helpers sejam noreturn apenas pela frequência. Os limites de T025 continuam válidos.

## Continuação: inventário e censo delimitado T026

O inventário foi ampliado a 449 tipos de máquina no índice atual e reconciliado com os 437 registros históricos. O censo localizou 445 janelas de `MoveNext` com fluxo limitado e quatro MethodDefs sem ponteiro nativo; nenhum dos 449 foi aceito semanticamente. O contrato adicional de `ExecuteOnConditionCoroutine`, os wrappers `StartCoroutine`/`StopCoroutine` e os limites de scheduling estão em [RECON_T026_INVENTORY_AND_FLOW_2026-11-08.md](RECON_T026_INVENTORY_AND_FLOW_2026-11-08.md). Isso continua um censo estrutural/parcial; não conclui T026 nem prova cobertura semântica do jogo.

## Correção do universo por interfaces — 2026-11-08

A leitura de interfaces nos metadados originais identificou **449 tipos**: **387 IEnumerator** e **62 IAsyncStateMachine**. Entre as 437 entradas antigas, 380 são enumeradores e 57 são async; há mais 12 tipos fora do filtro antigo por nomes. Logo a afirmação histórica de que as 437 eram todas enumeradores estava incorreta. Os 169 continuam sendo apenas um agrupamento de prefixes, não o universo completo obrigatório.

O registro preserva 169 desse agrupamento, 38 candidatos adicionais Game/PWC e o helper next-frame já requerido; 115 dependências condicionais, 34 escopos a resolver e 92 exclusões QA/lobby ficam explícitos. As exclusões se aplicam à reimplementação e não autorizam ocultar uma dependência necessária. Foram também inventariadas 458 declarações de eventos e 1.147 candidatas a closure; nenhuma dessas contagens prova assinantes, efeitos ou cobertura global de callbacks.

O censo de MoveNext gerou janelas e grafos locais para 445 máquinas; quatro ponteiros nulos continuam sem bytes inventados. São 411.168 bytes inspecionados e 86.204 instruções alcançáveis sob hipóteses explícitas. Isso não constitui 445 contratos semânticos ou corpos completos. Fontes e limites: reports/recon/t026_inventory.json e reports/recon/t026_flow_census.json; produtores tools/recon_t026_inventory.py e tools/recon_t026_flow_census.py.
