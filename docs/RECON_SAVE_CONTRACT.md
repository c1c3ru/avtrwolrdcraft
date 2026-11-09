# Persistência original — contrato parcial

## Atualização L03 (2026-11-09)

Gatilhos de gravação/leitura/reset, regra `CanSaveScene`, inventário parcial de chaves, fronteira com a nuvem e catálogo do esquema estão em [docs/loops/results/L03.md](loops/results/L03.md). Provas reproduzíveis: `tools/recon_save_triggers.py` e `tools/recon_pd_schema.py`. O contrato C# de `CanSaveScene` e dos dois gatilhos automáticos está em `Core/Persistence/SaveGate` com `SaveGateTests`.

Data da reconciliação: 2026-11-04  
Escopo: inventário estático de `Assembly-CSharp` e comparação com o estado local. Este documento não declara a persistência original totalmente recuperada.

## Evidência recuperada

- A análise nativa AArch64 recuperou janelas endereçadas dos métodos principais e handlers (índice/executável descritos em `out/recon/tasks/T030/persistence-asm/report.json`; assembly por método na mesma pasta). SHA256 de `libil2cpp.so`: `b63661fa60c23ebef1c2da4bb5288ad787eb3da36b22d4bdf285401f1643d728`. O limite de cada janela segue o próximo início de método do metadata ou 16 KiB; isso não prova que o corpo esteja completo.
- `SaveProgressInAllScenes` itera `SceneManager.sceneCount`/`GetSceneAt` e chama `SaveProgress`. `SaveProgress` chama `SaveDataForScene`, `SaveSceneObjectsToKeepOnLoad` e contém despacho indireto de callback; os eventos pre/post permanecem candidatos relevantes para confirmar por análise de fluxo.
- `SaveDataForScene` obtém raízes relevantes, caminho e chama `SaveDataInternal`. `SaveDataInternal` constrói `PDScene`, atualiza `LevelUserData`, serializa com `MiniJSON.Json.Serialize`, garante a pasta e chama `PazuCore.FileManager.SaveTextFile`. O caminho é composto por `GetFolder()` e scene ID, com `TryOverrideFileNameAction` como despacho indireto; portanto o nome final depende de override.
- `LoadProgress` é um wrapper de 8 bytes que transfere controle para `LoadData`. `LoadData` obtém raízes/caminho e chama `LoadDataInternal`. Esta tenta ler texto; quando o texto está vazio, consulta dados default da cena; desserializa com `MiniJSON.Json.Deserialize`; lê objetos mantidos/GUIDs novos ou sincronizados; e então chama, nessa ordem observada, limpeza de objetos ausentes, spawn de prefabs default/runtime, aplicação de dados persistentes, aplicação de defaults e atualização da ordenação. Há um despacho indireto e tratamento de exceção dentro da janela.
- `PDScene` divide o conteúdo em `SceneObjects` e `Prefabs` (constantes no manager). `GetDataFromRootGameObjects` agrega os dois grupos; `PDPrefab.GetSceneObjectsData` usa `UnityEngine.JsonUtility.ToJson` para serializar seu `SceneData.sceneObjects`; `GetSceneObjects` chama `PDSceneObject.EnsureSceneGuid`. Essa amostra confirma identidades de objetos e configuração de prefabs na composição, sem reconstruir todos os casos de merge/reset.
- `PDSceneObject` mantém um `sceneGuid`, registra objetos em `All` e expõe `EnsureSceneGuid`/`SetSceneGuid`. No piloto abaixo, todos os 41 valores são únicos dentro de `level4`; 6 têm formato UUID e 35 repetem nomes de GameObject. Isso prova o conteúdo desta cena, não a regra geral de criação nem unicidade entre cenas.
- O mesmo tipo declara o agrupamento `SceneObjects`/`Prefabs`, a pasta raiz `PersistantData/`, a pasta `Regular`, dados-base sob `Level/DefaultData/`, e a chave de PlayerPrefs `PazuWorld_PersistantData_KeepObjectsOnLoad`. Há controle de build (`BuildNumber`), objetos preservados durante load e GUIDs de objetos adicionados/sincronizados. A semântica exata de cada transição não está fechada.
- `PDSceneObject` mantém um `sceneGuid`, registra objetos em `All` e expõe `EnsureSceneGuid`/`SetSceneGuid`. Isso indica identidade estável por objeto de cena, necessária para reconciliar objetos salvos com a hierarquia carregada.
- `IHasPersistentData` define o par `GetPersistentData()`/`SetPersistentData(allData, sceneObjects)`. Foram encontrados 270 arquivos do dump que mencionam essa interface e 277 que mencionam `IRequirePDSceneObject`; são contagens de candidatos, não de implementações únicas confirmadas. O dump contém 63 tipos `Game.PersistentData` e 94 tipos `PWC.PersistentData`.
- Navegação tem persistência separada em PlayerPrefs: `WorldBuildingData_<buildingType>` guarda o nível selecionado e `GAME_CURRENT_WORLD` guarda o nome de cena do mundo. O contrato de escrita durante entrada em prédio está em [RECON_WORLD_CLICK_CONTRACT.md](RECON_WORLD_CLICK_CONTRACT.md). Isso não demonstra que progresso dos objetos internos do prédio use PlayerPrefs.

## Cena piloto: `level4`

Relatório extraído em `out/recon/tasks/T030/scene-pilot.json`; SHA256 da cena `d3e51b2e16a3319b3a0671973f2c1c12ca828040c7108148a3599a17a58e2e45`.

- O inspector conta 9.135 objetos Unity e 2.726 MonoBehaviours. A cena contém um `PersistentDataManager`, 41 `PDSceneObject` e 13 componentes com `IHasPersistentData`: 9 `UGCNewPresetGridFloorHandler`, 3 `UGCStorePackGridFloorHandler` e 1 `GameSoundPlayer`.
- Campos serializados dos handlers foram lidos da carga de cada MonoBehaviour e comparados à ordem/tipo declarados no Cpp2IL. Os nove handlers UGC New guardam referências `prefabGuid`; os três Store Pack guardam `StorePackType`, `InventoryFlagType` e `prefabGuid`. Exemplos decodificados incluem `ParkP149` e `DogParkP145`, confirmados nos enums locais.
- O `GameSoundPlayer` `AmbientLoop` tem `_ignoreDistance=true`, `_ignorePD=true` e `_distanceFactor=1.0`. Seu payload persistente (`GameSoundPlayerPD`) declara `isPlayingLoop`, `clipName`, `volume` e `pitch`; o código nativo de `GetPersistentData` consulta clip/pitch e o setter chama `Play`/`SetPitch`.
- `UGCNewPresetGridFloorHandlerPD` e `UGCStorePackGridFloorHandlerPD` declaram `didSpawnPreset` e `didCameraFocusOnGift`. A cena guarda configuração e GUIDs do prefab; esses dois booleans são estado persistente runtime, não campos de configuração da cena.
- O relatório conserva hashes, path IDs, nomes, GUIDs e os campos serializados, para que o piloto possa ser repetido sem reabrir o dump completo.

## Cena piloto jogável: `level8`

Cena original da quadra, inspecionada em `out/recon/tasks/T030/level8-inspect.json` e comparada em `out/recon/tasks/T030/level8-scene-pilot.json`. SHA256 da cena: `dff6d557630a579e05a48f65519b75c0aefb41c55623b4ad89078e9d290c38f5`.

- Contém 2.403 objetos Unity, 957 MonoBehaviours, um `PersistentDataManager`, 81 `PDSceneObject` com IDs únicos em formato UUID, 22 `PDPrefab` e 34 handlers que implementam `IHasPersistentData`.
- Classes de interação persistente presentes: 14 `LevelItem`, 7 `GameSoundPlayer`, 5 `LevelItemOrientationHandler`, 2 `LightSource`, 2 `LevelLight`, e um de cada `LevelBasketballScoreBoard`, `LevelBag`, `LevelFillableItemHandler` e `LevelRuntimeColoredSpriteHandler`.
- O `LevelBasketballScoreBoard.GetPersistentData` cria `IntArrayPD.values`; seu setter restaura a pontuação e sincroniza os textos. A configuração serializada da cena guarda referências aos textos/aros; os scores são estado runtime separado.
- `LevelItem` persiste parent, posição, movimento, attachment ao avatar/personagem e flip (`LevelItemPD`); `LevelItemOrientationHandler` persiste `orientationType`; `LevelBag` persiste um bool e sincroniza estado aberto/fechado; `LevelFillableItemHandler` persiste `isFull` e refaz o estado visual.
- O extrator guarda os payloads de configuração Unity por path ID em hexadecimal. Os valores dinâmicos salvos de uma sessão (por exemplo, score após cesta e posições alteradas) não estão serializados dentro da cena base; não havia arquivo `PersistantData` do aparelho nesta amostra. O schema estático e a aplicação por handler estão confirmados, mas os valores reais de um ciclo save→reload ainda precisam de uma captura do arquivo salvo ou de observação equivalente.

## Diferença no cliente offline

`PlayerState` serializa moeda, pontos, claims, ledger, desafios concluídos/ recentes e aparência. `SaveStore` grava JSON em `Application.persistentDataPath`, mantém cópia `.corrupt` quando o parse falha e sanitiza a aparência. Não há atualmente no modelo um mapa por cena de `sceneGuid` para dados de objetos, spawns de prefab, objetos a manter no load, build de origem ou posição persistida do avatar.

As posições e o placar da quadra protótipo são estado transitório de runtime. A aparência do avatar compartilha o `PlayerState`, mas isso não equivale ao mecanismo original de persistência de cenas. Nenhum formato original de arquivo foi inferido a partir dos nomes de chaves do dump.

## Próxima extração delimitada

1. ~~Refinar CFG e resolver despachos indiretos em `GetDataFromRootGameObjects`, `LoadDataInternal`, `GetFilePath` e handlers~~ — avançado em 2026-11-08, ver [RECON_SAVE_CFG_2026-11-08.md](RECON_SAVE_CFG_2026-11-08.md): CFG de blocos básicos (todos os tipos de desvio, não só `bl`/`b`) para 42/58 janelas com limite dentro da janela verificado, e cobertura de despacho indireto ampliada de 4 para 18 sites (12 com alvo de confiança alta/média, 6 documentados como indeterminados). Ainda restam 16 janelas sem limite comprovado e 6 sites sem alvo — ver esse documento para a lista exata; retornos/exceções/merge default-save ainda não têm evidência de ciclo completo.
2. Obter uma instância real de save de `level8` após mover/arremessar objetos, ou instrumentar execução offline permitida, e comparar valores com esses handlers antes de propor equivalência. Em 2026-11-08 um aparelho estava conectado via ADB mas com a tela bloqueada (PIN pessoal do usuário); sem desbloqueio físico não há como jogar até a quadra original nem confirmar o diálogo de `adb backup`. Continua pendente.
3. Só então propor adaptação offline versionada por cena e GUID. Preservar saves antigos e evitar converter campos sem equivalência demonstrada.

## Critério de fechamento

T030 continua aberto até haver CFG/dispatch fechado para os caminhos relevantes, evidência do ciclo load/save/reset/migração nos tipos cobertos, fixtures por revisão, e comparação com o modelo local. A cadeia principal e um piloto de cena já foram analisados; isso não cobre estados remotos, salas jogáveis nem todos os handlers.
