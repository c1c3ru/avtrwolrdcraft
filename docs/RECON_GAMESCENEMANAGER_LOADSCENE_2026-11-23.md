# GameSceneManager.LoadScene / LoadSceneImplement e HomePlayButton.LoadPlayScene — 2026-11-23

T025/METHOD (`8e708ca7d06e0b52` LoadScene, `e579655ba8e57adf` LoadSceneImplement, `5fe1bb4a25183678` HomePlayButton.LoadPlayScene). Estatico: Capstone,
`libil2cpp.so` sha256 `b63661fa60c2...`, metadata v31; `tools/il2cpp_field_offsets.py`, `tools/il2cpp_method_usage.py`. Fecha o U "stage_dispatch_binding" de LoadScene.

## Campos estaticos de `PWC.GameSceneManager` (typeDef 3803, tabela de metadata)
`OnBeforeSceneLoadStage1Action` 0x0, `Stage2Action` 0x8, `Stage3Action` 0x10, `CurrentSceneSuffix` 0x18, `PreviousSceneName` 0x20, `CurrentlyLoadingSceneName` 0x28,
`<IsSceneChangingInProgress>` 0x30, `TryOverrideSceneNameAction` 0x38, `<Multiplayer_LoadingSceneNameInProgress>` 0x40, `_availableSceneNames` 0x48.
=> as tres chamadas indiretas com guarda de nulo (offsets 0/8/16) **sao** os eventos Stage1/2/3 (invocacao de `Action` inline: metodo `+0x18`, alvo `+0x40`, info `+0x28`).

## LoadScene(string sceneName, bool considerMultiplayer = true, string mp_nextSceneId = null)  — `0x20728d4`
```
closure = new <>c__DisplayClass28_0 { sceneName=+0x10, considerMultiplayer=+0x18, mp_nextSceneId=+0x20 };
if (IsSceneChangingInProgress) { Debug.LogError("Scene loading is already in progress!"); return; }
AvatarSpineTexturesManager.ClearAllTextureData();        // 0x217a958
SUTUtils.ClearTexturesCache();                           // 0x208bcc0
CarPartsLoader.ClearLoadedParts();                       // 0x2159d10
CarAppearance.ClearIconCache();                          // 0x21527a0
IsSceneChangingInProgress = true;
CurrentlyLoadingSceneName = sceneName;                   // +0x28
PreviousSceneName = GetActiveSceneName();                // +0x20, 0x2072c64
OnBeforeSceneLoadStage1Action?.Invoke();                 // +0x0  (ex.: LevelSlideSwitcherHandler, LevelDigHoleArea guardam itens)
OnBeforeSceneLoadStage2Action?.Invoke();                 // +0x8
OnBeforeSceneLoadStage3Action?.Invoke();                 // +0x10
LoadingScreenManager.Instance.StartSceneTransition(new Action(closure.<LoadScene>b__0));   // 0x20fe2d8; lambda roda quando a tela de carregamento cobre a cena
```
A trava `IsSceneChangingInProgress` so e limpa depois (fora destes metodos).

## `<LoadScene>b__0` (lambda, `0x2073488`)
```
bool single = !( sceneName != "Home" && considerMultiplayer && MPManager.IsMultiplayerGame /*static +0x0*/ && !MPManager.Instance.IsHostAndOnlyPlayer() );
if (single) { LoadSceneImplement(sceneName); return; }
// multiplayer com outros jogadores, cena != "Home":
guid = Guid.NewGuid().ToString();
target = mp_nextSceneId ?? sceneName;
if (MPManager.Instance.IsHost()) {
    req = new MPData_SceneChangeRequest{ requestGuid=guid(+0x28), fromSceneId=GetActiveSceneId()(+0x30), toSceneId=target(+0x38), <campo base +0x10 = 1> };
    MPManager.Instance.SendWaitForPlayerForSceneChangeRequest(req);          // 0x20d7058
} else {
    MPDataHelper_SceneChangeRequest.TrySendEvent(GetActiveSceneId(), target, guid);   // 0x20bece0
}
MPUtils.DestroyAllGameObjectsInLoadedScenes();                               // 0x20e1954
MPManager.Instance.ClearPlayerFromScenes(MPManager.Instance.GetPlayerUID());  // 0x20d36ac / 0x20cb73c
GameSceneManager.Multiplayer_LoadingSceneNameInProgress = sceneName;          // +0x40
```
Offline (nosso caso), `IsMultiplayerGame` e falso: o lambda sempre cai em `LoadSceneImplement(sceneName)`. A literal comparada e `"Home"` (string literal 7159).

## LoadSceneImplement(string sceneName) — `0x2072cc8`
```
if (<estatico bool em +0x0 da classe MPManager? GOT 0x41b5350>) MPOwnership.Clear();     // 0x20d7e78
SceneManager.LoadSceneAsync(sceneName);                                                   // 0x3cdc604 (1 arg)
```
(O booleano lido e o mesmo `IsMultiplayerGame` usado no lambda; classe pelo uso, o slot de GOT esta em `.bss` e nao decodificado.) O retorno do `LoadSceneAsync` e descartado.

## HomePlayButton.LoadPlayScene — fecha 3 dos 6 desconhecidos de T025/5fe1bb4a
```
InteractionHistoryManager.Instance.OnClickHomePlayButton();                // 0x21419ac
if (PlayerPrefs.HasKey("pazucore_pending_deep_link")) {                     // literal 20002
    SoundManager.Instance.Stop(1001);                                       // 0x1caf0e0
    key = PlayerPrefs.GetString("pazucore_pending_deep_link", "");
    level = string.IsNullOrEmpty(key) ? LevelType.GirlsRoom_Z1B1L2 /*2*/ : DeepLinkManager.Instance.MapLinkToLevel[key];   // get_Item (IDictionary), pode lancar se ausente
    PlayerPrefs.DeleteKey("pazucore_pending_deep_link"); PlayerPrefs.Save();
    WorldBuildingsDataManager.SaveBuildingData(0, level);                   // 0x2109220
    sceneName = CoreExtensions.GetSceneName(level);                         // 0x206a798
} else {
    sceneName = GameSceneManager.GetCurrentWorldSceneName();                // 0x2073238
}
GameSceneManager.LoadScene(sceneName, true, null);                          // tail call 0x20728d4, w1=1, x2=0
```
- "Close the callees of world lookup, scene load, fade and return": world lookup = `GetCurrentWorldSceneName`; scene load = `LoadScene`; fade/retorno = `LoadingScreenManager.StartSceneTransition(Action)`.
- Efeito dos callbacks: `OnClickHomePlayButton` (historico de interacao) e `SaveBuildingData(0, level)` (grava o predio de origem da cena com indice 0) so sao nomeados; corpos nao lidos.
- Default `2` = `GirlsRoom_Z1B1L2` (quarto da casa): inferido do enum; o jogo real usa isso quando a chave existe mas esta vazia.

## Confianca / aberto
Alta: fluxo, campos, nomes dos callees, strings. Media: o bool de `LoadSceneImplement` (slot de GOT em `.bss`), o campo base `+0x10 = 1` do `MPData_SceneChangeRequest`.
Aberto: quem zera `IsSceneChangingInProgress`; corpo de `StartSceneTransition`; conteudo de `_mapLinkToLevel` (149 entradas serializadas); validacao em aparelho; revisao independente. Fila nao alterada.
