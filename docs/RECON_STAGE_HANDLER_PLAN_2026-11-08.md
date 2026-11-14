# T025 — plano de recuperação dos handlers Stage

Plano importado em 2026-11-08 para continuar a partir dos **13 edges estáticos diretos** já encontrados. Esses edges apontam para **12 MethodDefs únicos**: `LevelSpawnOnLevelPostInit.DestroyCurrentItems` é delegado por dois registradores e deve ser analisado uma vez, reaproveitando o contrato pelos dois edges.

## Lotes independentes

| Task | Handler | Token |
| --- | --- | --- |
| `T025/HANDLER/00002d72` | `Game.Level.LevelDigHoleArea.OnBeforeSceneLoadStage1` | `0x06002d73` |
| `T025/HANDLER/000032a8` | `Game.Level.LevelSpawnOnLevelPostInit.DestroyCurrentItems` | `0x060032a9` |
| `T025/HANDLER/00003cd1` | `Game.Level.WaterSlide.LevelSlideSwitcherHandler.OnBeforeSceneLoadStage1` | `0x06003cd2` |
| `T025/HANDLER/00005600` | `PWC.BackgroundPlanetSoundHandler.OnBeforeSceneLoadStage1` | `0x06005601` |
| `T025/HANDLER/00006999` | `PWC.AvatarSpeech.AvatarSpeechUIMenu.OnBeforeSceneLoadStage1` | `0x0600699a` |
| `T025/HANDLER/00006e43` | `PWC.PersistentData.PersistentDataManager.OnBeforeSceneLoadStage2` | `0x06006e44` |
| `T025/HANDLER/0000784d` | `PWC.Level.LevelKillArea.OnBeforeSceneLoadStage1` | `0x0600784e` |
| `T025/HANDLER/0000849b` | `PWC.Level.LevelManager.OnBeforeSceneLoadStage2` | `0x0600849c` |
| `T025/HANDLER/0000849c` | `PWC.Level.LevelManager.OnBeforeSceneLoadStage3` | `0x0600849d` |
| `T025/HANDLER/000084fe` | `PWC.Level.LevelScreenshotManager.OnBeforeSceneLoad` | `0x060084ff` |
| `T025/HANDLER/000085cf` | `PWC.Level.LevelNewAvatarManager.OnBeforeSceneLoadStage1` | `0x060085d0` |
| `T025/HANDLER/00008659` | `PWC.Level.LevelMakerSwitcher.OnBeforeSceneLoadStage3` | `0x0600865a` |

Os IDs de task usam o índice zero-based de MethodDef; a coluna Token usa o token managed, cujo RID começa em 1. Cada filho tem input hashes idênticos do ELF/metadata/index e hashes do relatório base de edges, diretório de saída próprio e lock de análise específico do MethodDef. Assim os produtores locais podem trabalhar em paralelo sem escrever no mesmo diretório. O manifest gerado é [t025_stage_handler_children_2026-11-08.json](../reports/recon/t025_stage_handler_children_2026-11-08.json), pelo [recon_stage_handlers.py](../tools/recon_stage_handlers.py).

## Loop obrigatório por agente

1. Rodar `python3 tools/recon_queue.py prepare <task-id>` e confirmar hash de todos os inputs; não começar por uma saída de cache sem essa conferência.
2. Fazer claim/start no próprio task ID. Trabalhar somente no diretório permitido do método. Usar LLVM/parsers locais já disponíveis, sem copiar database ou alterar shared reports durante a análise.
3. Reconfirmar MethodDef, metadata owner/token/arity e native pointer. Recuperar instruções, ramos condicionais, CFG, loads/stores, argumento/retorno, efeitos observáveis, handlers de erro e callbacks.
4. Tratar o próximo MethodDef apenas como limite da janela; investigar regiões não contíguas e exceções. Se faltar um helper, dispatch indireto ou contrato externo, registrar `unknown_id`, fonte/bytes e a menor tarefa filha que fecha a lacuna.
5. Produzir contrato, CFG, `unknowns.jsonl`, resultado parcial e testes de mutação. Testar alteração de opcode, alvo, MethodDef, owner/token e fluxo de argumentos para rejeitar evidência falsa.
6. Fazer checkpoint `ready` se restar qualquer desconhecido relevante. Só avançar a `evidence_ready/review` quando todos os outputs do child estiverem completos; revisão independente verifica binário/metadata raw, hash e cobertura. O autor não revisa a própria entrega.
7. Só reviewer pode aceitar `done`; edge de inscrição ou o relatório de nome do handler não certifica corpo/efeitos. Após uma correção reabrir o loop, revalidar hashes e repetir testes.

## Critério de conclusão individual

Um handler só pode ser aceito quando todas as regiões/caminhos relevantes, mutações de estado, efeitos e dependências necessários estiverem explicados e ligados ao par de artefatos exato, com exceções/dispatch resolvidos ou justificados como fora do comportamento observável. Janelas limitadas, nomes, contagens, localização de uma inscrição, resultado de `MoveNext` e testes de parser sozinhos não satisfazem o aceite.

Os 12 filhos foram importados como `pending`, dependentes somente dos pré-requisitos estreitos T001 e T022/PILOT_INDEX já aceitos. Eles não dependem do aceite do pai T025 (o que criaria ciclo: T025 exige os handlers); o fechamento implícito do pai continua condicionado a todos os filhos. **O importador da fila não inicia agentes:** é necessário um coordenador/runner externo para atribuir tarefas e observar checkpoints. Atualmente o processo é manual via CLI; nenhum scheduler autônomo foi implementado.
