# T020: +3 classes com o construtor v3 (tipos aninhados) — 2026-11-24

Continuacao de `..._BUILDER_V2_2026-11-24.md`. v1/v2 e os docs anteriores ficam congelados (evidencia hasheada de tarefas `done`).

## Causas corrigidas na v3 (`tools/mb_typetree_builder_v3.py`)
1. **Tipos aninhados**: `SceneMap` (campo de `GameExtraSettings`) tem `List<Item>` onde `Item` e uma classe *aninhada* (`SceneName sceneName` + `List<string> gameSceneNames`). O indice so via tipos de topo e resolvia
   `Item` como outra classe qualquer (virava `PPtr`), desalinhando tudo (campos seguintes liam ASCII como `bool`). A v3 indexa os tipos aninhados de cada arquivo e os resolve no contexto da classe que os declara (pilha de contexto).
2. **Enums do Unity** que nao estao no Cpp2IL do `Assembly-CSharp` (ex. `SystemLanguage`, 4 bytes) caiam em `PPtr`; a v3 tem uma lista de enums comuns do Unity/TMP (int32).

## Resultado
- Regressao: as **27** classes ja aceitas saem **identicas** na v3 (27/27).
- Novas (cada uma reconcilia com `declared_counts`; leitura exata + sanidade + bool 0/1): `PazuCore.GameExtraSettings`, `PazuCore.LocalizationManager`, `Game.Level.LevelCatTunnel` (1 instancia cada).
- Dados em `out/mb/`; estatisticas em `out/mb/_stats_addendum_2026-11-24c.json`.

## O que os dados mostram
- **`GameExtraSettings`**: `sceneMap` liga cada `SceneName` (analytics) as cenas do jogo (`Home`; `World`, `AvatarMakerLobby`; `Level_Campsite_Z2B1L1`; ...); `dontDestroyOnLoad` com 17 referencias; flags
  `multiTouchEnabled=1`, `showFullGameButton=1`, `useCloudGameData=0`, `useNewEndSession=1`, `useAnalytics=1`, `useActionBarHomePlayButton=0`, **`useTimeLock=0`**, `useActionBarNextGameWidget=1`, `androidUseGoogleAnalytics=0`,
  `dontOfferSubscriptionPurchase=1`, `gameDataVersion=0`; `defaultCloseWindowSound="Library_ButtonClick"`; os tres dicionarios (`nameBackScene`, `backgroundMusics`, `audioEvents`) estao vazios neste asset.
  **Relacao com as T025**: `WorldBuilding.ClickOnLevel` entra se `useTimeLock || IsCurrentlyFree() || IsGameUnlocked()`; como `useTimeLock = 0`, o gate de entrada nos predios depende so de `IsCurrentlyFree`/`IsGameUnlocked` (nao do time lock).
- **`LocalizationManager`**: tabela de **26 paises** (titulo, `flagAssetName`, codigos de pais ISO/numericos) com seus idiomas suportados (`systemLanguage` do Unity, `textAssetName` `lang_en_text`/`lang_es_text`..., `languageKey`, `fontType`, `isRTL`),
  ex. Estados Unidos -> ingles (10) e espanhol (34). Util para o seletor de idiomas do cliente (hoje pt/en/es/id).
- **`LevelCatTunnel`**: `_dropAreas` por `Side` (2, 1, 0) apontando para 3 areas de queda.

## Restam 31 classes
20 `PWC.EditorApp.*` (tipo removido do binario, irrecuperaveis) e 11 com `[SerializeReference]`/`ConditionResolver` (9 `serialize_reference` + `LevelOutfit` + `LevelSecretAvatarAnimationSolvedListener`), que exigem decodificar o
`ManagedReferenceRegistry` (referencias polimorficas); a v3 nao cobre isso.

## Fila
As 3 tarefas `T020/CLASS` correspondentes continuam `blocked_external`; levar pela fila exige autorizacao explicita.
