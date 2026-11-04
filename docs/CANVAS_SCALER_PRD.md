# CanvasScaler da Home — pesquisa

## Evidencia do original

- `out/mb/UnityEngine.UI.CanvasScaler.jsonl.gz`, arquivo `level3`, GameObjects 8 e 16:
  `ScaleWithScreenSize`, referencia `2048x1024`, `MatchWidthOrHeight`, match `1.0`,
  `referencePixelsPerUnit=100`.
- `out/mb/PazuCore.PazuCoreAddressables.AFC.AFCCanvasScalerRangeToScreen.jsonl.gz`,
  GameObject 8:
  - ratio `1.0..1.3333334`: match `0.7..1.0`;
  - ratio `1.6..1.777778`: match `0.5..1.0`;
  - ratio `2.0..2.164251`: altura de referencia `1106..1024`.

## Codigo afetado

- `Assets/Scripts/Runtime/UiSceneBuilder.cs`: cria o CanvasScaler e hoje implementa apenas
  a faixa de tela muito larga sobre uma referencia incorreta.
- `Assets/Scripts/Runtime/HomeLayout.cs`: sobrescreve o scaler com `Expand`, divergindo do original.
- `Assets/Tests/EditMode/HomeLayoutTests.cs`: valida atualmente o comportamento divergente.

## Restricoes

- Nao inferir valores visuais: usar somente os campos serializados.
- Aplicar as faixas AFC apenas ao Canvas principal, pois somente o GameObject 8 possui o componente.
- Preservar o Canvas do fundo com os valores-base do CanvasScaler original.
