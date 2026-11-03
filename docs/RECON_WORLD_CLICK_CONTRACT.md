# Contrato estático: toque num prédio do mapa → cena do nível (T029), 2026-11-03

Candidato estático, **não validado em runtime**. Verificador: `python3 tools/recon_world_click.py` (saída `out/recon/tasks/T029/WORLD_CLICK/`); testes: `python3 -m unittest discover -s tools -p test_recon_world_click.py`. Continua em `docs/RECON_LOAD_SCENE_CONTRACT.md` e `docs/RECON_HOME_PLAY_HANDOFF.md`.

Campos de `WorldBuilding` (dump Cpp2IL): `+0x48 _buildingType`, `+0x4c` nível padrão, `+0x50` lista de níveis válidos, `+0x88 OnClickBuildingAction`, `+0x90 OnClickAction`.

## Fluxo candidato
1. `OnPointerClickInternal` (após gates de UGC/ponteiro **não decodificados**) escolhe o nível:
   - `MPManager.IsMultiplayerGame` → nível padrão;
   - senão `TryLoadBuildingData(buildingType)`; o nível salvo só vale se for diferente do padrão **e** estiver na lista de válidos (`List<LevelType>.IndexOf != -1`); caso contrário, padrão.
2. `ClickOnLevel(level)`: dispara `OnClickBuildingAction(this, level)` se houver; `InteractionHistoryManager.MarkBuildingAsInteracted` e `SetFocusedBuildingType`.
3. Gate: `SettingsManager.Instance.ExtraSettings.useTimeLock` (`GameExtraSettings +0x73`) ≠ 0 → entra; senão entra só se `IsCurrentlyFree()` ou `Utils.IsGameUnlocked(null)`. Caso contrário: `TryGetRemoteConfigItem` + `WorldBuildingPreviewPopup.Show(buildingType, item)` e **não entra** (cena não muda).
4. Entrar: `OnClickAction.Invoke()` se houver; `SaveBuildingData(buildingType, level)`; `cena = GetSceneName(level)` (`"Level_"` + nome do enum); chamada virtual `LoadScene(cena)` (slot inferido = `WorldEnterableEntity.LoadScene`).
5. `SaveBuildingData`: fora de multiplayer, `PlayerPrefs.SetString("WorldBuildingData_" + buildingType, level.ToString())`. `TryLoadBuildingData` lê com padrão `""`.
6. `WorldEnterableEntity.LoadScene(cena)`: `SoundManager.Stop(1001)` (se houver instância); **`SetCurrentWorldSceneName(GetActiveSceneName())` = `PlayerPrefs.SetString("GAME_CURRENT_WORLD", cenaAtiva)`**; depois `GameSceneManager.LoadScene(cena, true, null)` (ver contrato do LoadScene).

## Consequências para o clone
- `GAME_CURRENT_WORLD` é gravado ao **entrar num prédio**, com o nome da cena ativa naquele momento (ex.: `World`); até lá o Play usa o padrão `"World"`.
- O nível aberto por prédio é persistente e validado: último nível salvo se ainda válido, senão o padrão.
- Prédios bloqueados mostram o popup de preview e não carregam cena. Nenhuma cena é inventada para `LevelType` não distribuídos.

## Desconhecidos
- Slot virtual `0x298` é inferido (única `LoadScene(string)` virtual na cadeia; vtable não decodificada).
- Significado e valor distribuído de `useTimeLock`; semântica de `IsCurrentlyFree`/`IsGameUnlocked` e do `RemoteConfig`.
- Gates de UGC/ponteiro no início de `OnPointerClickInternal` e `OnPointerClick`.
- Parse do nível salvo em `TryLoadBuildingData` (cauda em `0x2109120`) e comportamento em falha.
- Efeitos de `MarkBuildingAsInteracted`/`SetFocusedBuildingType` e UI do popup.
