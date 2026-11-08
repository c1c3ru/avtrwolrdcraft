# Contrato estático GameSceneManager.LoadScene / LoadSceneImplement (T029), 2026-11-03

Candidato estático, **não validado em runtime**. Verificador: `python3 tools/recon_load_scene.py` (saída em `out/recon/tasks/T029/LOAD_SCENE/`); testes: `python3 -m unittest discover -s tools -p test_recon_load_scene.py`.

Janelas: `LoadScene` VA `0x20728d4..0x2072c64`, `LoadSceneImplement` `0x2072cc8..0x2072d84` (fim = próximo método; não prova corpo/CFG completo). Complementa `docs/RECON_CALLBACK_2026-11-03.md` (`<LoadScene>b__0`) e `docs/RECON_HOME_PLAY_HANDOFF.md`.

## Offsets estáticos de `GameSceneManager` (conferidos com o dump Cpp2IL)
`0x0/0x8/0x10` eventos `OnBeforeSceneLoadStage1/2/3Action`; `0x20` `PreviousSceneName`; `0x28` `CurrentlyLoadingSceneName`; `0x30` `IsSceneChangingInProgress`. `MPManager` estático `0x0` = `IsMultiplayerGame`; `LoadingScreenManager` estático `0x0` = `Instance`. Closure `<>c__DisplayClass28_0`: `0x10 sceneName`, `0x18 considerMultiplayer`, `0x20 mp_nextSceneId`.

## Fluxo candidato
1. Aloca o closure com os três argumentos.
2. `IsSceneChangingInProgress` verdadeiro → `Debug.LogError("Scene loading is already in progress!")` e retorna (cena não muda).
3. Limpa caches: `AvatarSpineTexturesManager.ClearAllTextureData`, `SUTUtils.ClearTexturesCache`, `CarPartsLoader.ClearLoadedParts`, `CarAppearance.ClearIconCache`.
4. `IsSceneChangingInProgress = true`; `CurrentlyLoadingSceneName = sceneName`; `PreviousSceneName = GetActiveSceneName()`.
5. Invoca Stage1, Stage2, Stage3 (cada um se não nulo), nessa ordem.
6. `LoadingScreenManager.Instance.StartSceneTransition(new Action(closure.<LoadScene>b__0))`; `Instance` nulo → helper de falha.
7. Após o fade, `<LoadScene>b__0` segue para `LoadSceneImplement` (ou caminho multiplayer, ver doc do callback).
8. `CancelCurrentSceneChangingProgress()` (`0x207256c`) e `OnActiveSceneChanged(old,new)` (`0x2072644`) têm o mesmo efeito: `IsSceneChangingInProgress=false`, `Multiplayer_LoadingSceneNameInProgress=null`, `CurrentlyLoadingSceneName=null`; `PreviousSceneName` é mantido. (Verificado por 6 âncoras; 18 no total.)
9. `LoadSceneImplement(sceneName)`: se `MPManager.IsMultiplayerGame` → `MPOwnership.Clear()`; `SceneManager.LoadSceneAsync(sceneName)`.

## Para o clone
`LoadScene` **não** chama `IsSceneAvailable`; a checagem de cena ausente é de quem chama (ex.: `GetCurrentWorldSceneName`). Cena inexistente (ex.: os 7 `LevelType` não distribuídos) cairia no erro do `LoadSceneAsync` — não replicar nem inventar cena.

## Desconhecidos
- Quem assina `OnActiveSceneChanged` (provável `SceneManager.activeSceneChanged`) e quem chama `CancelCurrentSceneChangingProgress`; sem isso o ciclo do indicador não está fechado.
- ~~Assinantes dos eventos Stage1–3~~: resolvido em [RECON_SCENE_SUBSCRIBERS.md](RECON_SCENE_SUBSCRIBERS.md) (5 ligações registro→handler verificadas: `BackgroundPlanetSoundHandler`/Stage1, `PersistentDataManager` e `LevelManager`/Stage2, `LevelManager`/Stage3). O próprio despacho `blr` dentro de `LoadScene` (quem chama, com quais registradores/offsets) está decodificado em [RECON_STAGE_DELEGATE_INVOKE.md](RECON_STAGE_DELEGATE_INVOKE.md): é sempre indireto através de um campo do objeto delegate em runtime (offset `+0x18`, com args em `+0x40`/`+0x28`), nunca um branch fixo — o que ainda falta é o fade de `StartSceneTransition` (`0x20fe2d8`), que não invoca o delegate dentro da própria janela analisada.
- Exceções e corpos completos.
