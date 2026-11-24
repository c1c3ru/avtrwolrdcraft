# T020 sem estourar memoria: 63 das 74 classes "que so precisavam de RAM" agora decodificam — 2026-11-24

Contexto: `RECON_T020_NODE_TREE_TRIAGE_2026-11-22.md` deixou 65 classes `same_bug_likely_fixed` e 9 `serialize_reference_*` esperando "RAM para confirmar" (o UnityPy passa de 5,8 GB so para abrir o
`datapack.unity3d`). Com o extrator em blocos (`RECON_DROPS_1.230_2026-11-24.md`) essa premissa de memoria caiu.

## Metodo
`tools/mb_stream_extract.py`: (1) descomprime em uma passada os **523 arquivos serializados** do `datapack.unity3d` (555 MB no total; o maior e `resources.assets`, 334 MB);
(2) abre **um arquivo por vez** no UnityPy e le, com `TypeTreeGenerator` do mesmo build + `fix_mislabeled_vectors` + `check_read=True`, as instancias das 74 classes alvo.
Filtro rapido: o `m_Script.m_PathID` do MonoBehaviour e lido direto dos bytes brutos, so as instancias alvo passam pelo typetree.
Build: o instalado, **1.230** (os numeros antigos vieram de um build anterior). **Tempo 46 s, pico de memoria 1,25 GB**, sem OOM. Saida: `out/recon/il2cpp_1.230/mb_t020/` (nao versionada).

## Resultado
| Grupo | Classes | 100% das instancias decodificam | Com erro |
|---|---:|---:|---:|
| `same_bug_likely_fixed` | 65 | **63** (4.037 instancias lidas) | 2 |
| `serialize_reference_*` | 9 | 0 (so 1 instancia solta leu) | 9 |
| Total | 74 | **63** | 11 |
As 74 tiveram arvore de tipos gerada (0 falhas de geracao) e instancias encontradas (0 "sem instancia").

### Reconciliacao com os totais antigos (`out/mb/_stats.json`, build anterior)
Das 63 classes que decodificam, **54 batem exatamente**: o total de instancias novo = `ok + err` antigo (o que antes falhava agora le). As outras **9 tem mais instancias no 1.230**
(por exemplo `Spine.Unity.SkeletonAnimation` 1.963 -> 2.005, `LevelPlant` 66 -> 70): conteudo novo do build, nao diferenca de leitura. Nao comparei contra o build antigo diretamente.

### As 11 que continuam falhando
| Classe | Erro | Instancias |
|---|---|---:|
| `Game.Level.LevelSecretAvatarAnimationSolvedListener` (grupo `same_bug`) | `ValueError: Failed to get ref type node` | 79 |
| `Game.Level.LevelOutfit` (grupo `same_bug`) | `EOFError: read_str out of bounds` | 8 |
| `BWYW.DailyTasksData`, `BWYW.BWYWGiftData`, `LevelSecretVehicleInWorldPositionListener` | `Failed to get ref type node` | 45, 4, 3 (+1 ok) |
| `LevelOnSpecificPairAnimationBetweenSpecificAvatars`, `LevelStaticConditionsResolver`, `...WithDropAreas`, `...WithParkedVehicles`, `LevelRecipeSecret`, `LevelItemConditionsResolver` | `EOFError: read_str out of bounds` | 14, 18, 14, 2, 6, 24 |
- `Failed to get ref type node`: o objeto usa `[SerializeReference]` e o UnityPy nao achou o no do tipo referenciado. `LevelSecretAvatarAnimationSolvedListener` estava classificada como "mesmo bug", mas tambem tem referencias polimorficas.
- `EOFError: read_str out of bounds` nas demais: o `fix_mislabeled_vectors` nao cobre o caso (provavel variante do mesmo rotulo errado do `TypeTreeGeneratorAPI`); nao diagnostiquei.

## O que isso NAO e
- Nao registrei nada na fila formal (`reports/recon/tasks.json`): as 63 tarefas `T020/CLASS/<hash>` seguem como estavam. Cada uma exige `class-contract.json`, `recount.json` e `result.json` com a reconciliacao exata; isso
  e um passo a parte e a revisao continua independente.
- A leitura confirma que os objetos **decodificam sem sobrar/faltar byte** (`check_read=True`); nao valida o significado dos campos.
- Os 30 `typetreegeneratorapi_nullref_*` e os 20 `type_stripped_*` nao foram tentados (causa e a ferramenta/binario, nao memoria).

## Proximo passo possivel
Diagnosticar as 11 restantes (no de tipos de referencia para as `SerializeReference`; o rotulo errado do `EOFError`) e, depois, montar as evidencias das 63 para a fila formal.
