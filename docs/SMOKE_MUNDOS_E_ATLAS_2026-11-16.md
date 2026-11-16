# Mundos, atlas do Spine e testes — 2026-11-16

Continuação de `fix-npc-spawn-and-sun` (PR #60). Medido no aparelho (Xiaomi M2101K7BI) e no Editor.

## 3) Erros "Material with texture name ... not found for atlas asset"
- **Causa:** `MapSpineLayer` criava **um** material por esqueleto, mas 4 atlases têm várias páginas: `C_Scissors` (20), `Pendolum` (3),
  `Scissors_Z1B5L1` (2) e `Skeleton_L11` (2). O Spine liga cada página ao material cujo `mainTexture` tem o nome da página; as páginas extras
  ficavam sem material e o painel de desenvolvimento mostrava um erro por página.
- **Dados:** a pasta `Resources/MapSpine/<nome>/` só guarda a primeira página; as demais estão em `Resources/Spine/<nome>/`.
  Conferido por arquivo: das 130 atlases de MapSpine, **0 páginas faltam** nos dois lugares.
- **Correção:** `MapSpineLayer.CreateMaterials` cria um material por página (textura de `MapSpine/`, com fallback em `Spine/`),
  com alfa direto. Página realmente ausente vira um pixel transparente com aviso, e não derruba a camada.
- **Testes:** `MapSpineAtlasPagesTests` (um material por página, com a textura real, nos 4 atlases; e todas as páginas dos 130 atlases existem).

## 4) Cobertura dos mundos no aparelho (`tools/device_worlds_smoke.py`)
Cada troca de mundo é validada pelo log do jogo `WorldMap: <elementos> elementos, <prédios> predios` contra os dados do mapa.

| Mundo | Esperado (elementos/prédios) | Log no aparelho | App vivo |
|---|---|---|---|
| Campus | 197/4 | 197/4 | sim |
| Bairro | 643/65 | 643/65 | sim |
| Cidade | 348/30 | 348/30 | sim |
| Fazenda | 220/4 | 220/4 | sim |
| Resort | 90/10 | 90/10 | sim |
| Montanha | 117/8 | 117/8 | sim |

Observações medidas: a faixa do seletor só rola ~220 px (para no limite); depois de rolar, Resort fica em x≈1000 e Montanha em x≈1132.
Só o Bairro tem interiores no `InteriorCatalog`; os outros 56 prédios mostram o aviso de "não disponível".

## 5) Testes
- **EditMode novos:** `ItemPricingTests`, `ItemCatalogIndexTests`, `ChallengeSelectorEdgeCaseTests` (nível com 1 desafio, nível vazio, histórico limitado,
  estado nulo). `ChallengeSelector` e `ChallengeDifficulty` já tinham testes em `ChallengeBankTests.cs` e não foram duplicados.
- **Python:** `test_recon_queue` estava errado (o filho declara `out/child/result.json` e o teste entregava `result.json`; a fila rejeita com razão):
  corrigido, 35/35. `recon_t031_dispatch.py` usava um caminho fixo de outro usuário (`/home/c1c3ru/...`): agora relativo ao repositório, 7/7.
- **Não alterado de propósito:** `test_recon_loading_fade` e `test_recon_t026_flow_census` falham quando faltam artefatos locais em `out/recon/`.
  O próprio projeto documenta que entrada em cache ausente deve falhar, não pular; para rodá-los é preciso regenerar esses artefatos.

## Resultado das suítes (Editor, com este branch e o PR #60)
- EditMode: 333 de 334 (a única falha, `AvatarSlotsTests.SlotsSurviveJsonRoundTripAndSanitizeBadData`, é anterior; a correção do teste está na branch `worktree-tests-faltantes`).
- PlayMode: 25 de 25.

## Pendente
- Conferência visual no aparelho com um APK que inclua o PR #60 e este branch (sol redondo, NPCs na tela, sem erros de atlas).
