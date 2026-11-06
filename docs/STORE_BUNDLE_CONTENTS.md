# Conteúdo dos combos da loja (moda)

**O servidor da loja do original não está no APK.** `StoreData.Item` só traz nome, preço e `bundleItems` (índices de outros itens do JSON do servidor); `entitlements` tem só `pazuCurrency` e `loyaltyPoints`. Os ids `PB2`–`PB27` são nomes de arte.

O que existe no APK: `InventorySkinsBuildData` (resources.assets) com 51 pacotes de moda (flag `...Pnnn` -> skins). A associação **cartão da loja -> pacote é inferida pelo nome** (inferência, não prova):

| Cartão | Pacote | Peças liberadas no editor |
|---|---|---|
| Show ao vivo (PB23) | `GalxeLiveShowP173` | 18 |
| Festa (PB27; "Festa de formatura 600" nos prints) | `GraduationPartyP214` | 34 |
| Pop Star (PB20) | `StarsFashionP228` | 25 |
| Moda Daisy (PB21) | `DaizyMiniCollectionP216` | 9 |

Só entram peças com textura utilizável (`tools/pack_texture_coverage.py`) e categoria no editor (camisa, calça, sapato, acessório pescoço/óculos, boca, sobrancelha, cabelo traseiro). Hat/Jacket/Hair-front etc. ficam de fora até o editor ter essas categorias. Nem toda peça foi confirmada no skeleton Spine.

Pipeline: `tools/pack_texture_coverage.py` -> `tools/build_pack_content.py` -> `tools/avatar_catalog_build.py --selection out/recon/pack_selection.json`.
Gate: `PackGate` (Core/Economy) bloqueia a peça no `AvatarEditorScreen` até comprar o combo.
