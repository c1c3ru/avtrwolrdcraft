# Testes que faltam — 2026-11-16

Estado medido nesta data. Itens marcados [feito] foram executados; os demais estão pendentes.

## 1. Python (`tools/test_*.py`)
- [feito] `python3 -m unittest discover -p 'test_*.py'` em `tools/`: 237 testes, 4 erros.
- Pendente (3 erros por arquivo de entrada ausente, não por bug de código):
  - `test_recon_loading_fade.LoadingFadeTests`: falta `out/recon/loading-fade/raw-binding.json`.
  - `test_recon_t026_flow_census.EntryGuardsTests`: falta `out/recon/t026-inventory/machines.jsonl`.
  - `test_recon_t031_dispatch.DispatchResolutionTests`: caminho fixo `/home/c1c3ru/avtrwolrdcraft/out/recon/il2cpp/libil2cpp.so` (de outro usuário); deveria usar a raiz do repositório.
- Pendente (1 erro de lógica a investigar): `test_recon_queue.QueueTests.test_independent_child_review_required_before_parent_can_close` (`evidence_ready requires every declared output, including the full report`).

## 2. Unity EditMode / PlayMode
- Existem 44 arquivos de teste C# (38 EditMode, 6 PlayMode) para 81 classes em `Assets/Scripts`.
- [feito] EditMode: 317/318 (a falha era `AvatarSlotsTests.SlotsSurviveJsonRoundTripAndSanitizeBadData`, linha 71; correção do teste commitada, ainda não re-executada). PlayMode: 24/24.
- Nota: as 4 primeiras execuções do EditMode (09:30–09:39) foram mortas por OOM do sistema com o swap cheio; passou depois de parar o Greenbone.
- Classes sem nenhum teste (nome sem arquivo `*Tests.cs` correspondente):
  - Dados e regras: `ItemPricing`, `PlayerState`, `ItemNames`, `ItemCatalogFile`, `ItemCatalogIndex`, `AvatarCatalog`, `AvatarKind`, `AvatarKindCatalogData`, `AvatarPaletteData`, `PetAppearance`, `PetCatalogData`, `PetLayerCatalogData`, `PetPaletteData`, `SkyData`, `SceneDescription`, `StoreItem`, `StorePackContent`, `ClaimResult`, `AnswerResult`, `ChallengeDifficulty`, `ChallengeSelector`, `LiteracyChallenge`, `LiteracyContent`, `CACatalogLoader`, `LocomotionAnimations`, `WorldMapMotion`.
  - Runtime e telas: `WorldMapRuntime`, `InteriorRuntime`, `SceneSliceRuntime`, `BasketballCourtRuntime`, `MapCarsLayer`, `MapSpineLayer`, `AvatarGpuRuntime`, `PetGpuRuntime`, `SkyBackground`, `HomeBootstrap`, `LoadingScreen`, `StoreScreen`, `ItemBrowserScreen`, `AvatarEditorScreen`, `AvatarSlotsScreen`, `PetEditorScreen`, `LiteracyChallengeScreen`, `CoinFx`, `UiSound`, `BackgroundMusic`.
- Prioridade sugerida: lógica pura primeiro (`ItemPricing`, `PlayerState`, `ChallengeSelector`, `ItemCatalogIndex`, `WorldMapMotion`), que dá EditMode barato.

## 3. Aparelho (Xiaomi M2101K7BI, adb)
- [feito] Smoke de abertura e Play (`tools/device_smoke.py`): 6/6 checagens passaram no build instalado de 2026-11-07 (processo vivo, sem crash, PSS 951 MB). Capturas em `out/device/tests/`.
- Pendente:
  - Reinstalar um APK do código atual (o instalado é de 07/11, o último commit é de 09/11) e repetir o smoke.
  - Smoke de cenas: abrir cada mapa e cada interior (58 exportados), conferindo ausência de crash e de erro no `logcat`.
  - Diff visual contra o original (`com.pazugames.avatarworld`), usando `out/device/avatar-original-survey-2026-11-09/` como referência.
  - Navegação por prédio: o hambúrguer estava interditado no mapa; confirmar se o original também fica interditado.
  - Persistência: fechar e reabrir o app e conferir moedas e aparência.
  - Aviso não fatal a tratar: `ClassNotFoundException: com.google.android.play.core.assetpacks.AssetPackManager` no logcat.
