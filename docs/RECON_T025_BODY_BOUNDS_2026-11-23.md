# T025 — limites de corpo dos 8 metodos abertos (estatico, Capstone) — 2026-11-23

`tools/recon_body_bounds.py` desmonta o trecho `[inicio, proximo_metodo)` de cada metodo e faz a busca de alcancabilidade a partir da
entrada. Pergunta: o corpo contiguo e **fechado** (sem ilhas escondidas, sem fluxo vazando para o metodo seguinte)? Saida bruta em
`out/recon/t025_body_bounds.json` (nao versionada). Dados: `out/recon/il2cpp` (`libil2cpp.so` sha256 `b63661fa60c2...`).

| Metodo (tarefa) | vaddr | bytes | instr. alcancaveis / total | Termina em | Saidas do intervalo |
|---|---|---|---|---|---|
| `HomePlayButton.LoadPlayScene` (T025/METHOD/5fe1bb4a) | `0x2057fa8` | 580 | 145 / 145 | thunk NullReference | tail call a `0x20728d4` (`GameSceneManager.LoadScene`) |
| `GameSceneManager.GetCurrentWorldSceneName` (d417091e) | `0x2073238` | 212 | 53 / 53 | `ret` | nenhuma |
| `GameSceneManager.LoadScene` (8e708ca7) | `0x20728d4` | 904 | 226 / 226 | thunk NullReference | tail calls a `0x20fe2d8`, `0x3ca5b88` |
| `GameSceneManager.LoadSceneImplement` (e579655b) | `0x2072cc8` | 188 | 47 / 47 | `b` (tail call) | `0x3cdc604` |
| `WorldBuilding.ClickOnLevel` (4a19cfec) | `0x2108e90` | 388 | 97 / 97 | thunk NullReference | nenhuma |
| `LevelDigHoleArea.OnBeforeSceneLoadStage1` (00002d72) | `0x1e29da8` | 4 | 1 / 1 | `b` (tail call) | `0x1e299b4` |
| `LevelSpawnOnLevelPostInit.DestroyCurrentItems` (000032a8) | `0x1e64abc` | 208 | 52 / 52 | thunk IndexOutOfRange | nenhuma |
| `WaterSlide.LevelSlideSwitcherHandler.OnBeforeSceneLoadStage1` (00003cd1) | `0x1f04f28` | 32 | 8 / 8 | `ret` | nenhuma |

## O que isso mostra
- Em todos os 8, **todos os bytes decodificam** e **toda instrucao e alcancavel** da entrada: nao ha bloco frio, pouso de excecao ou codigo
  morto dentro do intervalo. Nenhum fluxo cai no metodo seguinte.
- Todo desvio que sai do intervalo e **tail call para um inicio de metodo conhecido** (conferido na tabela de metodos), nao um bloco solto.
- Isso sustenta, para o trecho contiguo, o que o erratum de `d417091e` dizia faltar ("53 instrucoes numa janela nao provam o corpo inteiro").
  Para `GetCurrentWorldSceneName` o intervalo e exatamente os 212 bytes ja inspecionados e fecha em `ret`.

## O que isso NAO mostra
- **Thunks sem retorno por padrao, nao por prova.** `0x1b88980` (NullReference) e `0x1b88988` (IndexOutOfRange) sao `str x30; bl <helper>`;
  o helper monta a excecao (mensagem em .rodata) e chama o raise (`0x1b48ee0`). Tratei como terminais; nao executei.
- **Contiguidade assumida.** O proximo inicio vem das tabelas de metodos (Assembly-CSharp, CoreModule, metadata). Como todos os bytes ate la
  decodificam e sao alcancaveis, nao ha codigo extra no meio, mas regioes de excecao/frias **separadas** do intervalo continuam
  impossiveis de excluir so com isso.
- **Semantica continua nao certificada.** Bound de corpo nao e contrato de comportamento: efeitos, helpers de runtime, `PlayerPrefs`,
  inicializacao lazy e o despacho indireto de `HomePlayButton` (`0x2058174`) seguem como desconhecidos nos `unknowns.jsonl` de cada tarefa.
  Nao ha oraculo/original executavel (PairIP, sem aparelho), entao `semantic_completion` nao muda.

## Estado da fila
Nao alterei `reports/recon/tasks.json`: nenhuma tarefa foi reivindicada, checkpointada ou revisada. As evidencias em `out/recon/tasks/` tambem nao
foram reescritas. A tarefa `5fe1bb4a` (em `review`) continua com 3 de 4 hashes divergentes do registrado.
