# T020: 63 das 124 classes com erro resolvidas com leitura de baixa memoria — 2026-11-24

Confirma a hipotese de `docs/RECON_T020_NODE_TREE_TRIAGE_2026-11-22.md` ("same_bug_likely_fixed: so precisam de RAM") e mede o que sobra.

## Por que falhava e como contornei
`UnityPy.load(datapack.unity3d)` (1,3 GB) descomprime todos os blocos e faz `b"".join(...)` (pico ~2x) e ainda carrega os `.resS`/`.resource` (2,6 GB de texturas/audio, nao usados num dump de
MonoBehaviours). `tools/lowmem_unitypy.py` troca isso por: descompressao em **streaming para um arquivo temporario** (3,26 GB em disco, nao em RAM), leitura por `mmap`
(`memoryview`, mesma semantica do leitor em memoria do UnityPy) e `read_files` que **so instancia `SerializedFile`** (355 MB; pula `.resS`/`.resource`).
Pico medido: ~580 MB na sondagem do diretorio; ~2,5 GB de RSS no passe completo sobre 881.898 MonoBehaviours (antes: >6 GB e `MemoryError`).
Ao instalar o patch, o `BundleFile` do UnityPy 1.25.4 e substituido em `read_fs`/`read_files`; nao altera arquivos do jogo.

## Resultado (reprocessando so as 124 classes de `out/mb/_stats.json` -> `erros`, com o `nodes_for` corrigido de `tools/mb_dump.py`)
| Triagem (2026-11-22) | Classes | Agora |
|---|---|---|
| `same_bug_likely_fixed` | 65 | **63 decodificam 100%**, 2 ainda falham: `Game.Level.LevelSecretAvatarAnimationSolvedListener` (79 instancias) e `Game.Level.LevelOutfit` (8), ambas `EOFError: read_str out of bounds` com type tree gerado |
| `serialize_reference_ref_types_resolution` | 9 | 8 falham (`Failed to get ref type node`), 1 parcial (`LevelSecretVehicleInWorldPositionListener`, 1 ok / 2 err) — **nao e problema de RAM** |
| `type_stripped_from_release_il2cpp_metadata` | 20 | 20 falham (tipo ausente no binario; irrecuperavel) |
| `typetreegeneratorapi_nullref_confirmed_serializabledict_field` | 30 | 30 falham (gerador de type tree quebra em `SerializableDictionaryBase`) |

Total: **3.951 instancias novas/corrigidas** em 64 classes, 1.382 instancias ainda com erro. `out/mb/_stats.json`: erros de 124 para 61.

## Validacao dos dados novos
- Cada classe gravada: nº de linhas = `ok` do passe, `m_Script`+`_path_id`+`_file` presentes, sem `path_id` duplicado; o passe 2 reproduziu exatamente o resultado do passe 1 (ok/err por classe).
- **Teste de regressao nas 13 classes que ja tinham dump parcial** (2.523 linhas antigas): novo `ok` = antigo `ok` + antigo `err` em todas (ex. `Spine.Unity.SkeletonAnimation` 1737+226 = 1963),
  nenhuma linha antiga some e a **unica** diferenca de conteudo e `""` -> `[]` em campos `List<string>` vazios (3.162 campos): o dump antigo carregava o bug do vetor mal rotulado
  (`m_Type="string"` na raiz de `List<String>`) e o novo sai com o tipo certo.
- Nota: outros dumps antigos de `out/mb` feitos antes do `fix_mislabeled_vectors` podem ter `""` onde deveria haver `[]`; nao varri o resto do diretorio.

## O que continua sem solucao (61 classes)
- 30 `nullref` (incluem `DeepLinkManager`, `GameExtraSettings`, `LocalizationManager`, `WindowManager`, apps do `LevelPhone`): limitacao do `TypeTreeGeneratorAPI` com `SerializableDictionaryBase`;
  os bytes crus existem no bundle e podem ser decodificados a mao (tentativa para `DeepLinkManager`: ver abaixo, se registrada).
- 20 `type_stripped` (`PWC.EditorApp.*`): tipo removido do binario, sem solucao sem o assembly original.
- 9 `serialize_reference`: precisam de resolucao de `ManagedReferenceRegistry` (ref types), outra frente.
- As 2 `same_bug_likely_fixed` que ainda falham (`LevelSecretAvatarAnimationSolvedListener`, `LevelOutfit`) e as 8 `serialize_reference`: causa nao e memoria; nao investigadas alem do primeiro erro.

## Fila
As 74 tarefas `T020/CLASS/<hash>` correspondentes **nao** foram alteradas: submeter e aprovar cada uma exige claim/checkpoint/review (revisor distinto do autor); aguardam decisao.
