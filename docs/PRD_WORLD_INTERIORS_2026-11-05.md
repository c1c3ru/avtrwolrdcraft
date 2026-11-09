# PRD (fase 1 SDD): interiores dos prédios, toque no mapa, loja por item

Pesquisa apenas; nenhuma implementação nesta etapa. Base: `docs/SBS_BASELINE_2026-11-05.md`.

## 1. Clima no mapa
- O build do checkout (`.test`) **funciona**: botão abre sol/chuva/neve, o globo desliza para a direita, a neve troca os sprites do mapa (`WorldMapRuntime.ApplyWeather`).
- O problema visto no `.sbs` instalado é de versão antiga: o globo ficava por cima do ícone do sol.
- Resta de verdade: **chuva não tem efeito visual próprio** (o código diz "não reproduz scripts do original (clima, luz)"). Pendente de decisão de escopo.

## 2. Toque no mapa → cenas
- Hoje `WorldMapRuntime.OnTap` só abre a quadra (`defaultLevel == 13`); os demais mostram um aviso. A quadra é um protótipo à mão (`BasketballCourtRuntime`, 6 arquivos), não um leitor de cena.
- **Cadeia resolvida** (`tools/recon_building_scenes.py` → `out/recon/building_scenes.json`):
  `building.defaultLevel` → enum `PWC.Game.LevelType` (Cpp2IL) → `Level_<nome>.unity` na lista de cenas do BuildSettings (`base.apk/assets/bin/Data/data.unity3d`, 254 cenas) → arquivo serializado `level<índice>` do datapack. Conferido: `MiniBasketball_L1` = índice 8 = `level8`.
- **59 dos 65 prédios** do mapa têm cena. Os 6 sem cena (`*_UC_T1`, cinema) têm `defaultLevel 0`: são os "em obras" com fita amarela; o aviso atual está correto para eles.
- Contrato original do clique (`docs/RECON_WORLD_CLICK_CONTRACT.md`): salva `WorldBuildingData_<tipo>`, grava `GAME_CURRENT_WORLD`, carrega a cena; na 1.227 todos abrem (`IsAllWorldFree = true`).
- Pipeline de exportação existente: `tools/scene_level_inspect.py` + `tools/scene_level_export.py` (SpriteRenderers e sprites de um `levelN`, sem abrir o datapack de 1,3 GB) e `tools/export_world_map.py` (formato `world.json`).
- Candidatos a piloto, por menor número de objetos raiz: Dentista `level206` (8), Balé `level30` (12), Cabana `level15` (15), Estação de trem `level21` (15), Supermercado `level9` (17), Farmácia `level26` (17).

## 3. Loja por item
- `store_catalog.json`: 37.230 linhas, 25.812 GUIDs únicos, **preço 0 em todas**, 2.209 categorias, 130 arquivos de origem (29.180 em `resources.assets`). 6.412 GUIDs aparecem em mais de uma linha.
- Faixas de preço de produto já decididas (`docs/STORE_WORLD_UI_SPEC.md`): até 500 / 501–899 / 900+. Preços observados dos combos: 300–1400.
- O `LocalStoreService` já aplica preço > 0, uma resgate por GUID e saldo; falta só a fonte de preço e a UI por item.

## 4. Riscos
- Cena do original é grande (centenas de objetos, colisores, scripts); só os SpriteRenderers são exportáveis hoje. Um interior será **visual + navegação de saída**, sem a lógica do original.
- Tamanho do APK: o `.test` já tem 157 MB; cada interior acrescenta sprites.
- O `.sbs` do usuário não pode ser substituído; todo teste usa o `.test`.

## 5. Decisões pendentes (do autor)
1. Prédio piloto.
2. ~~Regra de preço por item~~ — decidida em 2026-11-05: por categoria em 3 faixas (`Core/Economy/ItemPricing.cs`,
   `Small`/`Medium`/`Large`), sem preço de dinheiro real. Já implementada e coberta por teste.
3. Se o efeito visual de chuva entra no escopo.
