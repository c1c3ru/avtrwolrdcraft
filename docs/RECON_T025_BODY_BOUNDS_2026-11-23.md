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

## Desconhecido atacado: regra de data de `ClothesDropDataMap.GetDropDataForTime` (lida, `0x22486f8`)
Corpo de 0x1ec bytes lido por inteiro (`tools/recon_disasm.py`); o que ele faz, em ordem:
1. Na primeira chamada, `GetAllUnixTimes` (`0x22488e0`) preenche `unixTime` de cada entrada e marca `_isUnixValuesCalculated` (`+0x28`).
2. Zera os dois `out long` e, se `_timeToClothesData` (`+0x18`) e nula, retorna null.
3. Percorre a lista em ordem. Entrada com `unixTime > time` e pulada. Para a primeira com `unixTime <= time`, olha a seguinte: se a seguinte ja
   e `> time` (ou nao existe), essa e a vigente; senao avanca. Ou seja, devolve a **ultima entrada com `unixTime <= time`** (lista em ordem crescente) e
   retorna null se todas sao futuras.
4. `out dropEndTime` (1o `out`) = `unixTime` da entrada seguinte, ou 0 se a vigente e a ultima; `out dropStartTime` (2o) = `unixTime` da vigente (no caso de
   igualdade exata com `time`, o proprio `time`, que e o mesmo valor). Retorna `entrada.data` (`PDTextBulkData`, `+0x28`).
5. Todo acesso a lista/elemento tem guarda de null que desvia para o thunk de NullReference.

`TimeToClothesDropData.GetUnixTimeFromDate` (`0x2248a30`) monta `new DateTime(year@+0x18, month@+0x14, day@+0x10, 14, 0, 0, DateTimeKind.Utc)` e converte para
segundos Unix: **todo drop comeca as 14:00 UTC da data**. O cliente adotou as duas regras (`ClothesDrop.StartHourUtc`, `ClothesDrops.Current`).

Ainda aberto: comparacao exata de "novo" em `CheckIsAnyNewDropExist` (usa o nome do ultimo drop visto por `LevelType`, `GetLastDropNameSeen`, nao a data), `EnsureData`
(313 linhas) e a escolha de qual `LevelType` mostrar quando varias lojas tem drop novo. O cliente compara por data e mostra todas as lojas.

## Desconhecido atacado: como o original decide "drop novo" (`ClothesDropUtils`, lido)
Corpos lidos: `CheckIsAnyNewDropExist` (`0x2248bf8`), `OnLevelEnter` (`0x22495cc`), `GetLastDropNameSeen` (`0x2249368`), `MarkLastSeen` (`0x22496dc`),
`CheckIsAnyLastChanceDropExist` (`0x2249ec0`). Constantes do cpp2il: `HOUR_OF_UPDATE = 14`, `LAST_CHANCE_DURATION_HOURS = 24`,
`SHOP_DROP_INTERACTION_DATA_KEY = "PWC_World_ShopDropInteractionHistory"`, mapas em `Level/ClothesDropSystemMap/ClothesDropMap_<loja>`.

`CheckIsAnyNewDropExist(long currentTime, out LevelType levelType)`:
1. `EnsureData()` carrega o dicionario `LevelType -> ClothesDropDataMap`; `*levelType = 0`; `melhor = 0`.
2. Para cada par do dicionario: `dados = mapa.GetDropDataForTime(currentTime, out fim, out inicio)`.
3. Pula se `dados` e nulo (`UnityEngine.Object ==`) ou se `dados.name` e nulo/vazio.
4. `igual = (dados.name == GetLastDropNameSeen(levelType))`. Se `inicio > melhor` e `!igual`: `melhor = inicio`, `*levelType = chave`.
5. Retorna `*levelType != 0`.

Ou seja: entre todas as lojas cujo drop vigente tem **nome diferente do ultimo visto**, devolve **uma so**, a de **inicio mais recente**. A comparacao e por
**nome do ScriptableObject** (`ClothesDrop_BulkData_<Tema>_LD<n>_L<nivel>`), nao por data, e conjuntos `Empty` tem nome nao vazio, entao contam como drop novo.

- **Quando vira "visto"**: `OnLevelEnter(type, time)` = `MarkLastSeen(type, GetCurrentDropName(type, time))`, ou seja ao **entrar no nivel da loja**, nao ao tocar no widget.
- **Onde guarda**: PlayerPrefs `PWC_World_ShopDropInteractionHistory`, JSON de `ShopDropInteractionTable { lastDropNameInteractionHistory: [ { levelType, lastDropName, isNotificationSeen } ] }`.
- `CheckIsAnyLastChanceDropExist()` e um stub que retorna `true` (`mov w0, #1; ret`); a regra de "ultima chance" (24 h antes do fim) nao esta nesse corpo.
- `GetWidgetIconByLevelType(levelType)` mostra o icone da loja escolhida: o widget do original aponta para **uma** loja.

### Diferencas do cliente (`ClothesDrops`, `HomeActions.ShowClothesDrops`)
| Original | Cliente |
|---|---|
| "Novo" = nome do drop vigente != nome visto (por loja) | "Novo" = data do drop vigente != data vista (equivalente, um drop por data) |
| Widget aponta para a UMA loja de inicio mais recente | Painel lista todas as lojas com drop vigente |
| Marca visto ao entrar no nivel da loja | Marca visto todas as lojas ao abrir o painel |
| Conjunto `Empty` conta como drop vigente | Conjuntos sem pecas sao pulados |
Nada disso foi mudado no cliente; so documentado.
