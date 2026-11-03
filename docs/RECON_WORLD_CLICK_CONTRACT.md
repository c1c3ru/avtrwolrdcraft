# Contrato estático: toque num prédio do mapa → cena do nível (T029), 2026-11-03

Candidato estático, **não validado em runtime**. Verificador: `python3 tools/recon_world_click.py` (saída `out/recon/tasks/T029/WORLD_CLICK/`); testes: `python3 -m unittest discover -s tools -p test_recon_world_click.py`. Continua em `docs/RECON_LOAD_SCENE_CONTRACT.md` e `docs/RECON_HOME_PLAY_HANDOFF.md`.

Campos de `WorldBuilding` (dump Cpp2IL): `+0x48 _buildingType`, `+0x4c` nível padrão, `+0x50` lista de níveis válidos, `+0x88 OnClickBuildingAction`, `+0x90 OnClickAction`.

## Fluxo candidato
0. `WorldEnterableEntity.OnPointerClick(eventData)`: ignora o toque se `eventData.dragging` (`+0x145`) ou `WorldResetManager.IsGameInResetMode` (`+0x18`); senão chama o `OnPointerClickInternal` virtual.
1. `OnPointerClickInternal`: se `UGCManager.Instance` existe e `Instance.IsEditMode` (`+0x28`) → retorna sem entrar. Senão escolhe o nível:
   - `MPManager.IsMultiplayerGame` → nível padrão;
   - senão `TryLoadBuildingData(buildingType)`; o nível salvo só vale se for diferente do padrão **e** estiver na lista de válidos (`List<LevelType>.IndexOf != -1`); caso contrário, padrão.
2. `ClickOnLevel(level)`: dispara `OnClickBuildingAction(this, level)` se houver; `InteractionHistoryManager.MarkBuildingAsInteracted` e `SetFocusedBuildingType`.
3. Gate: `SettingsManager.Instance.ExtraSettings.useTimeLock` (`GameExtraSettings +0x73`) ≠ 0 → entra; senão entra só se `IsCurrentlyFree()` ou `Utils.IsGameUnlocked(null)`. Caso contrário: `TryGetRemoteConfigItem` + `WorldBuildingPreviewPopup.Show(buildingType, item)` e **não entra** (cena não muda).
4. Entrar: `OnClickAction.Invoke()` se houver; `SaveBuildingData(buildingType, level)`; `cena = GetSceneName(level)` (`"Level_"` + nome do enum); chamada virtual `LoadScene(cena)` (slot inferido = `WorldEnterableEntity.LoadScene`).
5. `SaveBuildingData`: fora de multiplayer, `PlayerPrefs.SetString("WorldBuildingData_" + buildingType, level.ToString())`. `TryLoadBuildingData` lê com padrão `""`; string vazia/nula → `false` (nível 0); caso contrário `Enum.TryParse<LevelType>` genérico (instância não resolvida por nome) — string inválida → `false`.
6. `WorldEnterableEntity.LoadScene(cena)`: `SoundManager.Stop(1001)` (se houver instância); **`SetCurrentWorldSceneName(GetActiveSceneName())` = `PlayerPrefs.SetString("GAME_CURRENT_WORLD", cenaAtiva)`**; depois `GameSceneManager.LoadScene(cena, true, null)` (ver contrato do LoadScene).

## Gate de acesso (decodificado depois)
Verificador: `python3 tools/recon_access_gate.py` (`out/recon/tasks/T029/WORLD_CLICK/access-gate-contract.json`), testes em `tools/test_recon_access_gate.py`.
- `IsCurrentlyFree() = _isFree(+0x58) || _isFreeFromRemoteConfig(+0x70) || PWCConstants.IsAllWorldFree`.
- **`PWCConstants..cctor` grava `IsAllWorldFree = true`** (`0x207cc38..0x207cc40`) → na 1.227 `IsCurrentlyFree()` é verdadeiro para todo prédio e o popup de preview não aparece (candidato estático). Os 115 `WorldBuilding` têm `_isFree = 0` (`out/mb`), então é o `IsAllWorldFree` que libera.
- `IsGameUnlocked() = !User.IsLocked()`; `IsLocked`: versão completa (`PlayerPrefs.GetInt(GetFullVersionKey(),0)==1`) → desbloqueado; assinatura (token + keychain `is_active_subscription == "1"` + dispositivo ativo); senão `useTimeLock` → `TimeLimitDataManager.IsTimerLimitReached`; senão `!GamesPackUtils.IsThisGameFullVersionExistInKeychain`.
- `GameExtraSettings` serializado (datapack `sharedassets1.assets` path 214, 544 bytes; parse manual, cada bool em 4 bytes, confiança moderada): `useNewEndSession=1, useAnalytics=1, useActionBarHomePlayButton=0, useTimeLock=0, useActionBarNextGameWidget=1, androidUseGoogleAnalytics=0, dontOfferSubscriptionPurchase=1`.

## Consequências para o clone
- `GAME_CURRENT_WORLD` é gravado ao **entrar num prédio**, com o nome da cena ativa naquele momento (ex.: `World`); até lá o Play usa o padrão `"World"`.
- O nível aberto por prédio é persistente e validado: último nível salvo se ainda válido, senão o padrão.
- Na 1.227 todos os prédios com cena abrem (`IsAllWorldFree`); o popup de preview existe no código mas não é alcançado. Nenhuma cena é inventada para `LevelType` não distribuídos. O clone offline não precisa de compra/assinatura para abrir prédios.

## Desconhecidos
- Slot virtual `0x298` continua sem vtable decodificada, mas o `override void LoadScene(string)` aparece **uma única vez em todo o `Assembly-CSharp`** (`WorldEnterableEntity`) e `WorldBuilding` não tem subclasses, então o alvo é `WorldEnterableEntity.LoadScene` (inferência forte, não verificada por vtable).
- Se algum outro escritor/remote config muda `IsAllWorldFree` em runtime (campo `readonly`, assumido constante); layout de `GameExtraSettings` a confirmar com typetree gerado.
- Slots virtuais de `OnPointerClickInternal` (em `OnPointerClick`) e de `LoadScene` (em `ClickOnLevel`) não decodificados por vtable (ver nota acima).
- Efeitos de `MarkBuildingAsInteracted`/`SetFocusedBuildingType` e UI do popup.
