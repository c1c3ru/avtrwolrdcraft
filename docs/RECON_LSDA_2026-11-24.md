# Limites de corpo e regioes de excecao (LSDA) dos metodos de T025 — 2026-11-24

Fecha a reserva "tabela formal de excecao (LSDA) nao recuperada" das T025 aceitas em 2026-11-24. Estatico: `.eh_frame` (FDE) + `.gcc_except_table` do
`libil2cpp.so` (sha256 `b63661fa60c2...`), ferramenta nova `tools/il2cpp_lsda.py` (pyelftools). Nao altera a fila nem os arquivos de evidencia ja aceitos.

## Limites de corpo (FDE) — confirmam as extensoes antes inferidas por metadata
| Metodo | Inicio | Bytes (FDE) | LSDA |
|---|---|---|---|
| `LevelSpawnOnLevelPostInit.DestroyCurrentItems` | `0x1e64abc` | 208 | nao |
| `LevelUtils.DestroyLevelItem` | `0x232b9ac` | 1512 | nao |
| `LevelSlideSwitcherHandler.OnBeforeSceneLoadStage1` | `0x1f04f28` | 32 | nao |
| `LevelSlideSwitcherHandler.SaveItemInBulkData` | `0x1f04f48` | 464 | nao |
| `LevelSlideSwitcherHandler.SetInSildeData` | `0x1f05214` | 468 | nao |
| `GameSceneManager.LoadScene` | `0x20728d4` | 904 | nao |
| `<LoadScene>b__0` (lambda) | `0x2073488` | 772 | nao |
| `GameSceneManager.LoadSceneImplement` | `0x2072cc8` | 188 | nao |
| `HomePlayButton.LoadPlayScene` | `0x2057fa8` | 580 | nao |
| `GameSceneManager.GetCurrentWorldSceneName` | `0x2073238` | 212 | nao |
| `WorldBuilding.ClickOnLevel` | `0x2108e90` | 388 | nao |
| `LevelDigHoleArea.OnBeforeSceneLoadStage1` (thunk) | `0x1e29da8` | 4 | nao |
| `LevelDigHoleArea.DetachContainerAreaChildrenIfNeeded` | `0x1e299b4` | 596 | **sim** |

Cada FDE cobre o corpo inteiro numa unica faixa contigua (nenhum corpo parte em regioes nao contiguas), e os tamanhos batem com os limites usados nos docs
(ex. `DestroyLevelItem` 1512 bytes, `LoadScene` 904 bytes).

## Excecoes
- **Todos os metodos acima, exceto o helper do DigHole, nao tem LSDA**: nenhuma regiao de excecao tratada. Excecao nesses metodos (NRE em `0x1b88980`, IOORE em `0x1b88988`, ou vinda de callee)
  **propaga** sem limpeza local. Isso confirma, para as T025, o que os docs deduziram do fluxo.
- **`DetachContainerAreaChildrenIfNeeded` (`0x1e299b4`)**: LSDA em `0xf9bfc4`, 14 call-sites, encoding uleb128. Faixas protegidas -> landing pad:
  - `[0x1e29aac,0x1e29ab4)` -> `0x1e29b8c`; `[0x1e29afc,0x1e29b20)` -> `0x1e29b80`; `[0x1e29b24,0x1e29b40)` -> `0x1e29b94`; `[0x1e29b6c,0x1e29b70)` -> `0x1e29b88`;
    `[0x1e29b70,0x1e29b74)` -> `0x1e29b84`; `[0x1e29b74,0x1e29b7c)` -> `0x1e29b90` (acao 3): sao os pontos do laco sobre `List<LevelItem>.Enumerator` onde um NRE pode ocorrer;
    os landing pads `0x1e29b80..0x1e29b90` sao `b 0x1e29b94`, que executa o caminho de limpeza.
  - `[0x1e29bac,0x1e29bb0)` -> `0x1e29bd8` (acao 0, so cleanup) e `[0x1e29be8,0x1e29bf0)`/`[0x1e29bfc,0x1e29c04)` -> `0x1e29c04` (acao 5): o `Enumerator.Dispose()` e a continuacao
    (`_Unwind_Resume`/terminate) do `finally` do `foreach`.
  - Consequencia: o `foreach` tem `try/finally` real (Dispose do enumerador mesmo com excecao), como os docs ja descreviam por leitura de fluxo; agora com as faixas formais.

## Limites desta analise
- As acoes (indices 3 e 5 na tabela de acoes) nao foram interpretadas contra a tabela de tipos (`ttype`): so se sabe que sao clausulas de captura/limpeza, nao o tipo capturado.
- LSDA descreve excecoes C++ do codegen; o comportamento gerenciado de `try/catch` do C# original nao e inferido daqui.
- Nao ha validacao dinamica.
