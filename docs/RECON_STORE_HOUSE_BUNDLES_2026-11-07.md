# Loja: categoria "Casas" — bug de extração corrigido e pacotes decodificados (2026-11-07)

## Pedido
Usuário relatou, observando a loja do original ao vivo: a categoria **Casas** tem 8 submenus, cada um com vários
pacotes. `docs/STORE_WORLD_UI_SPEC.md` só tinha "Casas → 5 tipos", registrado por observação de prints (sem prova).
Pedido do usuário: se já estava mapeado por engenharia reversa, implementar; senão, investigar e achar os objetos.

## Diagnóstico: não estava mapeado
- `level237` (cena da loja) só tem os containers vazios `Categories`/`Subcategories`/`Items` — populados em runtime
  pelo servidor. Confirmado lendo `out/store-ui-export/level237.json` e `out/scene-extract/level237.inspect.json`.
- `docs/STORE_BUNDLE_CONTENTS.md` só cobre **Moda** (via `InventorySkinsBuildData.MAP_CSV_PATH`, um CSV em
  Resources, pipeline próprio em `tools/pack_texture_coverage.py`/`tools/recon_clothing_gates.py`) — nunca cobriu Casas.
- `docs/RECON_BASELINE_WAVE1.md` já citava `PWC.Inventory.InventoryBuildData` como uma das 126 classes com erro na
  extração de MonoBehaviours (`out/mb/_stats.json`). Essa classe é exatamente `packGuid -> lista de itens`, a fonte
  provável dos pacotes de Casas/Veículos/Pet/etc. (ver `PWC/Inventory/InventoryBuildData.cs` decompilado).

## Causa raiz do erro de extração
Erro original: `EOFError: read_str out of bounds` ao ler `PWC.Inventory.InventoryBuildData` e também
`PWC.Inventory.InventorySkinsBuildData` (2 instâncias) via `tools/mb_dump.py`.

`TypeTreeGeneratorAPI` (gerador de type-tree a partir do IL2CPP) rotula a **raiz** de campos `List<String>`
(ex.: `List<String> items`, `List<String> skins`) com `m_Type="string"`, mantendo corretamente os filhos
`Array/size/data` — mas com o nome errado. O leitor da UnityPy (`TypeTreeHelper.read_value`) despacha primeiro por
`FUNCTION_READ_MAP.get(node.m_Type)`; como `"string"` está nesse mapa, ele lê a lista inteira como se fosse uma
string escalar (`read_aligned_string`), ignorando os filhos reais — e corrompe a leitura de tudo que vem depois.

**Fix** (`tools/mb_dump.py`, função `fix_mislabeled_vectors`): para cada nó `m_Type=="string"`, se o primeiro filho
é `Array` e o `data` do `Array` não é `char` (ou seja, é lista de não-caracteres, não uma string de verdade),
renomeia o nó para `"vector"` — isso faz o leitor cair no branch genérico de vetor (`node.m_Children[0].m_Type ==
"Array"`), que já lida corretamente com listas aninhadas.

Validado: os 3 objetos (`InventoryBuildData` path_id 217 em `sharedassets1.assets`; `InventorySkinsBuildData`
path_id 721792 e 721793 em `resources.assets`) agora leem com `check_read=True` passando (contagem de bytes bate
exatamente com `byte_size` do objeto serializado). Esse fix vale para **as 126 classes** que falhavam antes, não só
estas duas — reextrair todas é trabalho futuro (não feito aqui; `tools/mb_dump.py` levaria um bom tempo rodando
sobre os ~882k objetos do `datapack.unity3d`).

Dependência que faltava no ambiente: pacote Python `TypeTreeGeneratorAPI` (instalado via pip; não estava no
`tools/venv` desta sessão).

## O que `InventoryBuildData` contém
224 pacotes (`packGuid -> [itemGuid, ...]`), cobrindo **todas** as categorias que usam o padrão "pack de prefab
guids" (não só Casas — tem Pet, Moda sazonal, acessórios, etc., misturados). Guids resolvidos contra
`store_catalog.json` (37230 entradas). Artefato completo: `out/recon/store_house_bundles.json`.
Dump bruto (mesmo formato de `out/mb/*.jsonl.gz`): `out/mb/PWC.Inventory.InventoryBuildData.jsonl.gz`,
`out/mb/PWC.Inventory.InventorySkinsBuildData.jsonl.gz`.

## Temas de Casas identificados (pacotes `...PB<n>Box_Pack` com 0 itens diretos = bundle "capa";
os itens reais vêm de sub-pacotes de cômodo, achados por prefixo de nome)

| Bundle (guid resolvido) | Nome provável | Cômodos (prefixo) | Itens totais | Status |
|---|---|---|---:|---|
| `GalxeHouseBundlePB22Box_Pack` | Galxe Mansion | `GalxeHM*`: Bathroom(28) DiningRoom(24) Kitchen(24) LivingRoom(28) Lounge(57) Lumi(113) Sky(75) Vega(83) | 432 | **confirmado** — bate com o print `assets/exemplo_jogo_original/imagem3.jpeg` ("GALXE MANSION BUNDLE", 1200 moedas, de 2400, 50% OFF) |
| `NaturalChicBundlePB7Box_Pack` | Natural Chic | `NaturalChic*`: BedRoom(30) DiningRoom(57) LivingRoom(33) ToddlerAndBaby(101) | 221 | **confirmado** — bate com o print imagem3.jpeg ("NATURAL CHIC BUNDLE", 1400, de 2000, 30% OFF) |
| `BeachHousePB11Box_Pack` | Beach House | `IslandHM*`: Balcony(24) Bathroom(33) Beach(28) Bedroom(30) Kitchen(26) Outdoors(31) | 172 | inferido — o pacote da loja chama "Beach" mas os cômodos reais usam o prefixo `IslandHM` (mesmo padrão de nomenclatura de `GalxeHM`/`SnowyHM`) |
| `BubbleGlamPB8Box_Pack` | Bubble Glam | `BubbleGlam*`: Bathroom(48) Bedroom(61) Parking(27) PoolArea(69) Teen(53) WalkingCloset×2(68+96) | 422 | inferido — não visto num print, mas o padrão de nome é idêntico aos confirmados |
| `KawaiiHousePB10Box_Pack` | Kawaii House | `KawaiiHouseP29`(79) `KawaiiHouseP30`(42) | 121 | inferido |
| `ModernHousePB9Box_Pack` | Modern House | `ModernGarageP55`(36) `ModernLivingRoomAndBalconyP53`(36) | 72 | **confirmado por exclusividade de nome (2026-11-22)** — busca por "modern" em todo `store_catalog.json` (37230 itens) retorna exatamente estes 3 nomes (capa + 2 cômodos), não é coincidência de substring |
| `MansionBundlePB2Box_Pack` | Mansão | — | 0 | **irresolúvel com os dados atuais (2026-11-22)** — ver nota abaixo |

Isso dá **6–7 temas de Casas confirmados/bem inferidos**, não os 8 relatados. Candidato a um 8º tema, não
confirmado: `FairyTreeDollhouseP224Box_Pack` (53 itens, sem bundle "capa" `PBxx` associado) — o nome bate em
espírito com o card "CASINHA DE BRINCAR BUNDLE" (770, de 1100, 30% OFF) visto nos prints
`assets/exemplo_jogo_original/imagem5.jpeg`/`imagem6.jpeg`, mas **não há prova de vínculo** (não achei guid do
cartão da loja em lugar nenhum do APK, exatamente como já documentado para Moda — `StoreData.Item`/`bundleItems`
não estão no APK). Mesma ressalva vale para `WelcomeBabyP223Box_Pack` (71 itens) vs. o card "ESSENCIAIS DE BEBÊ"
(800) do mesmo print.

## Addendum (mesma sessão): pacotes "casa" avulsos sem bundle-capa
`tools/recon_store_packs_overview.py` (ver `docs/RECON_STORE_ALL_PACKS_OVERVIEW_2026-11-07.md`) achou mais pacotes
com perfil de cômodo que **não** têm bundle-capa `...PBnBox_Pack` associado e não pertencem a nenhum dos 7 temas
acima: `HipHopAptP85Box_Pack`(170) + `HipHopStoreP98Box_Pack`(97) — "apartamento hip hop", tema plausível não
visto em print nenhum; `SummerBathRoomP35Box_Pack`(37) + `SummerKitchenP37Box_Pack`(36) — tema "verão"; e o par
`DiningRoomL43Box_Pack`(43) + `PoolL43Box_Pack`(52), que compartilham o sufixo `L43` (mesmo padrão usado por
`GalxeHM`/`SnowyHM` pra agrupar cômodos de um local) — **candidato mais forte a cômodos de `MansionBundlePB2`**,
mas sem nenhuma prova (não há bundle-capa `MansionBundlePB2` apontando pra eles, é só coincidência de sufixo).
Nenhum desses tem bundle-capa com guid resolvido — ou são temas vendidos sem "capa" (card único, sem sub-trilho),
ou a ligação real está em dados que não estão no APK (igual já vale para Moda). **Não dou isso como resolvido.**

## Mansão e outros temas irresolúveis (confirmado em 2026-11-22, não é só "não achei ainda")
`store_catalog.json` tem **351** prefabs com nome terminando em `*Pack` em `resources.assets`; só **224** estão
linkados em `InventoryBuildData.packToItems` (confirmado só 1 instância do objeto no jogo inteiro —
`out/mb_survey.json`). Os outros **127** (chamo de "órfãos") são capas/cômodos nomeados que existem como prefab
mas **não têm nenhuma lista de itens em lugar nenhum do APK** — não é falta de busca, é ausência de dado mesmo,
igual ao já documentado para `StoreData.Item`/`bundleItems` de Moda. `MansionBundlePB2Box_Pack` e
`CatamarnP36_Pack` estão nesse grupo (busca por "mansion" em todo o catálogo só retorna a própria capa). Outros
temas de Casas adicionais também caem aí, sem conteúdo extraível por nenhum método disponível:
- `ApartmentHMP82Box_Pack`/`P89`/`P95` — 3 variantes de um tema "Apartamento", mesmo padrão `*HM*` de
  Galxe/Island/Snowy, mas nenhuma das 3 tem cômodos linkados.
- Mais 6 prefabs de cômodo do tema Bubble Glam existem (`BubbleGlamDinningroomP64`, `KitchenP63`,
  `LivingroomP39`, `TilesP54`/`TilesPE3`, `CouponPC9`) além dos 7 já linkados — sem item-list.
- Uma segunda variante de Kawaii House (`KawaiiHouseBox_Bathroom_L33`, `KawaiiHouseBox_MasterBedroom_L33`),
  separada de `KawaiiHouseP29`/`P30`.

Artefato: `out/recon/store_house_bundles.json`, chave `orphan_pack_prefabs_sem_conteudo`.

## Limites / o que falta
1. **Ligação cartão-da-loja → pack é inferência por nome**, igual ao já documentado para Moda em
   `docs/STORE_BUNDLE_CONTENTS.md` — o servidor da loja (preço, nome exibido, bundleItems) não está no APK.
2. `MansionBundlePB2` confirmado irresolúvel com os dados atuais (ver seção acima); `ModernHousePB9` agora
   confirmado por exclusividade de nome.
3. Reextrair as outras ~124 classes que falhavam com o mesmo bug (agora corrigido em `tools/mb_dump.py`) não foi
   feito ainda — bloqueado por RAM nesta máquina (~6 GB de pico, ver `LOOP_STATE.md` e `tools/mb_retry_failed_classes.py`).
4. Itens resolvidos contra `store_catalog.json` só têm nome/categoria/arquivo — sem textura/posição/preço real
   (preço = 0 a definir, como já documentado).

## Próximo passo sugerido
Se o objetivo for implementar Casas no cliente (como foi feito para Moda com `StorePackContent.cs`/`PackGate`),
falta: (a) `MansionBundlePB2` ficou irresolúvel (ver seção acima) — decisão do autor: excluir esse tema da loja
offline, ou inventar conteúdo próprio pra ele (deixando claro que não é dado original); `FairyTreeDollhouse`/
`WelcomeBaby` continuam como inferência de nome sem prova, mesma decisão se aplica; (b) decidir que "pacote de
casa" vira o quê no cliente offline (desbloqueio de mobília no editor de casas, que ainda não existe — ver
`docs/PRD_WORLD_INTERIORS_2026-11-05.md`); (c) rodar em ambiente com Unity Editor (não disponível nesta sessão)
para implementar e validar.
