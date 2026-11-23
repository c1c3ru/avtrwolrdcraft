# Navegacao entre cenas: ciclo da trava, mundo atual, clique em predio e chamadores de LoadScene — 2026-11-23

T025/METHOD `d417091ede9f01e0` (GetCurrentWorldSceneName), `4a19cfec8f8e89ba` (WorldBuilding.ClickOnLevel) e complemento de `8e708ca7d06e0b52`.
Estatico (Capstone), `libil2cpp.so` sha256 `b63661fa60c2...`. Ferramentas: `tools/il2cpp_callers.py` (novo), `il2cpp_field_offsets.py`, `il2cpp_vtable.py`, `il2cpp_method_usage.py`.

## Ciclo da trava `GameSceneManager.IsSceneChangingInProgress` (+0x30)
- Liga em `LoadScene` (`strb 1,[statics+0x30]`).
- Desliga (e zera `CurrentlyLoadingSceneName` +0x28 e `Multiplayer_LoadingSceneNameInProgress` +0x40) em **`OnActiveSceneChanged`** (`0x2072644`, handler do evento de troca de cena ativa)
  e em **`CancelCurrentSceneChangingProgress`** (`0x207256c`). O setter `set_IsSceneChangingInProgress` (`0x20723b4`) nao tem chamadores diretos.
- Consequencia: um segundo `LoadScene` durante a transicao so loga "Scene loading is already in progress!" e sai; a trava solta quando a cena nova vira a ativa.

## GetCurrentWorldSceneName() — `0x2073238`
```
defaultName = ((PWC.Game.LevelWorldType)1).ToString();         // box + Enum.ToString (0x338d9a0)
saved = PlayerPrefs.GetString("GAME_CURRENT_WORLD", defaultName);   // 0x3cc5a70
return IsSceneAvailable(saved) ? saved : defaultName;                              // 0x207305c
```
(`LevelWorldType` valor 1 = `World` (o Bairro) e a chave `GAME_CURRENT_WORLD` decodificados pelo metadata.)

## WorldBuilding.ClickOnLevel(LevelType level) — `0x2108e90` (typeDef 4292)
Campos: `_buildingType` 0x48, `OnClickBuildingAction` 0x88 (delegate de 2 args), `OnClickAction` 0x90 (`UnityEvent`), `_isFree` 0x58, `_isFreeFromRemoteConfig` 0x70.
```
OnClickBuildingAction?.Invoke(this, level);
InteractionHistoryManager.Instance.MarkBuildingAsInteracted(_buildingType);    // 0x2141b50
InteractionHistoryManager.Instance.SetFocusedBuildingType(_buildingType);      // 0x2141d58
if (SettingsManager.instance._extraSettings.useTimeLock       // GameExtraSettings +0x73 (SettingsManager +0x28)
    || IsCurrentlyFree()                                       // 0x2109138
    || PazuCore.Utils.IsGameUnlocked()) {                      // 0x1cbb7a8
    OnClickAction?.Invoke();                                   // UnityEvent.Invoke 0x3cda874
    WorldBuildingsDataManager.SaveBuildingData(_buildingType, level);          // 0x2109220
    this.LoadScene(CoreExtensions.GetSceneName(level));        // virtual slot 22 = WorldEnterableEntity.LoadScene -> GameSceneManager.LoadScene
} else {
    WorldBuildingPreviewPopup.Show(_buildingType, TryGetRemoteConfigItem(out item));   // 0x21091b4 / 0x20feda8: previa/paywall
}
```
Offline: tratar `IsGameUnlocked()` como verdadeiro libera todos os predios (nosso cliente ja o faz). Chamadores diretos: `WorldBuilding.OnPointerClickInternal` e `WorldBuildingLevel.OnPointerClick`.

## Quem chama GameSceneManager.LoadScene (50 chamadores diretos, `tools/il2cpp_callers.py`)
- **Home/menus**: `HomePlayButton.LoadPlayScene`, `GameAchievementsButton.OnClick`, `SecretHomeWidget.WidgetButtomClick`, `OpenHomeSceneButton.OnClick`, `ChangeWorldButton.OnButtonClick`,
  `BackButton.OnButtonClick`, `WorldReset.WorldResetButton.OnClick` e `ExitResetGameModeButton.OnClick`.
- **Mundo/predios**: `WorldEnterableEntity.LoadScene`, `Street.StreetHouseLevel.OnPointerClick`, `WorldManager.AvatarMakerButtonPress`, `UGC.UGCLevelEntrance.PerformClick`.
- **Interiores/transicoes de fase**: `LevelLevelSwitcher`, `LevelSwitcherOnClick`, `LevelInstancedLevelSwitcher`, `LevelInstancedLevelExitSwitcher` (2 chamadas), `LevelLinkedSlide.MoveToScene`,
  `LevelCrossLevelSlide.MoveToScene`, `LevelAvatarEntry.OnPointerClick`, `WaterSlide.LevelSlideSwitcherHandler.LoadScene`, elevador (`OnElevatorButtonClick`).
- **Loja**: `Store.StoreViewManager.ShowImplement`/`OnBackButtonClickImplement`, `StoreBundleViewManager.ShowImplement`, `StoreAvatarPassViewManager.ShowImplement`, `StoreManager.OnClaimItemSuccess`, `LoadSceneOnClaim`.
- **Avatar**: `AvatarMakerManager.LeaveToLobby`/`DoneButton`, `AvatarMakerLobbyManager.OpenScene`/`BackButton`/`OnEmptySlotClick`/`OnFilledSlotClick`.
- **Celular/conquistas**: `LevelPhone.Phone.OnApplicationClick`, `PopupNotificationButton.OnPointerClick`, `AchievementDetailsPage.GoToHuntLevel`, `LevelInitAchievementDictionary.OnNewServerHuntRequiresReload`.
- **Outros**: `StarsPass`/`BWYW` (menus de passe/habilidades), `MultiplayerExample`/`MPUtils.TryGoToAvatarScene` (multiplayer), `GameSceneManager.ReloadCurrentScene` e `LoadSceneAndUpdateZoneScene`,
  `<LoadSceneAsync>d__7.MoveNext`. Todos entram por `LoadScene(sceneName, considerMultiplayer, mp_nextSceneId)` e portanto passam pelos 3 estagios (Stage1/2/3).
- `StartSceneTransition` tem um unico chamador direto: `LoadScene`.

## Aberto
Corpos de `IsSceneAvailable`, `OnActiveSceneChanged` alem do reset da trava, de `WorldBuildingPreviewPopup.Show` e de
`StartSceneTransition`; chamadores indiretos (delegate/vtable/UnityEvent serializado) nao aparecem na varredura. Revisao independente. Fila nao alterada.
