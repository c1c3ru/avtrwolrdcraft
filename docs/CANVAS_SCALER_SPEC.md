# Especificacao — CanvasScaler da Home

## `Assets/Scripts/Runtime/UiSceneBuilder.cs` — MODIFICAR

- Definir a referencia-base como `2048x1024`.
- Configurar Canvas raiz com `MatchWidthOrHeight` e match-base `1.0`.
- Para o Canvas principal da Home, reproduzir por interpolacao linear e limitada as tres faixas
  observadas no `AFCCanvasScalerRangeToScreen`.
- Nao aplicar as faixas AFC ao `CanvasBackground`.

## `Assets/Scripts/Runtime/HomeLayout.cs` — MODIFICAR

- Remover a sobrescrita para `Expand`.
- Preservar explicitamente os valores-base observados do scaler, sem apagar os valores dinamicos
  calculados pelo builder para o Canvas principal.

## `Assets/Tests/EditMode/HomeLayoutTests.cs` — MODIFICAR

- Validar referencia, modo e match-base observados.
- Validar as tres faixas adaptativas e seus limites por uma funcao pura, sem depender do tamanho
  da janela do editor.
