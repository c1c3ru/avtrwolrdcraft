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
| `ModernHousePB9Box_Pack` | Modern House | `ModernGarageP55`(36) `ModernLivingRoomAndBalconyP53`(36) | 72 | **incerto** — vínculo por substring "Modern", sem confirmação de print nem de prefixo comum (`GalxeHM`/`IslandHM`-style) |
| `MansionBundlePB2Box_Pack` | Mansão | — | 0 | **não resolvido** — nenhum sub-pacote de cômodo encontrado por nome; cartão "MANSÃO BUNDLE" apareceu cortado no print (imagem3.jpeg), preço não capturado |

Isso dá **6–7 temas de Casas confirmados/bem inferidos**, não os 8 relatados. Candidato a um 8º tema, não
confirmado: `FairyTreeDollhouseP224Box_Pack` (53 itens, sem bundle "capa" `PBxx` associado) — o nome bate em
espírito com o card "CASINHA DE BRINCAR BUNDLE" (770, de 1100, 30% OFF) visto nos prints
`assets/exemplo_jogo_original/imagem5.jpeg`/`imagem6.jpeg`, mas **não há prova de vínculo** (não achei guid do
cartão da loja em lugar nenhum do APK, exatamente como já documentado para Moda — `StoreData.Item`/`bundleItems`
não estão no APK). Mesma ressalva vale para `WelcomeBabyP223Box_Pack` (71 itens) vs. o card "ESSENCIAIS DE BEBÊ"
(800) do mesmo print.

## Limites / o que falta
1. **Ligação cartão-da-loja → pack é inferência por nome**, igual ao já documentado para Moda em
   `docs/STORE_BUNDLE_CONTENTS.md` — o servidor da loja (preço, nome exibido, bundleItems) não está no APK.
2. `MansionBundlePB2` segue sem cômodos encontrados; `ModernHousePB9` tem vínculo fraco. Precisa ou (a) mais prints
   do original mostrando esses dois bundles abertos, ou (b) buscar por outro padrão de nome nos 224 pacotes.
3. Não confirmei se **todos** os 224 pacotes de `InventoryBuildData` cobrem 100% do que a loja vende, nem se há mais
   pacotes de casa fora desse objeto único (existe só 1 instância de `InventoryBuildData` no jogo inteiro —
   `out/mb_survey.json` confirma contagem 1).
4. Reextrair as outras ~124 classes que falhavam com o mesmo bug (agora corrigido em `tools/mb_dump.py`) não foi
   feito nesta sessão — pode valer a pena rodar o dump completo de novo.
5. Itens resolvidos contra `store_catalog.json` só têm nome/categoria/arquivo — sem textura/posição/preço real
   (preço = 0 a definir, como já documentado).

## Próximo passo sugerido
Se o objetivo for implementar Casas no cliente (como foi feito para Moda com `StorePackContent.cs`/`PackGate`),
falta: (a) confirmar ou descartar `MansionBundlePB2`/`ModernHousePB9`/`FairyTreeDollhouse`/`WelcomeBaby` com mais
prints ou decisão do autor sobre aceitar a inferência por nome; (b) decidir que "pacote de casa" vira o quê no
cliente offline (desbloqueio de mobília no editor de casas, que ainda não existe — ver `docs/PRD_WORLD_INTERIORS_2026-11-05.md`);
(c) rodar em ambiente com Unity Editor (não disponível nesta sessão) para implementar e validar.
