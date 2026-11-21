# Loja: visão geral dos 224 pacotes de `InventoryBuildData` (2026-11-07)

Continuação de `docs/RECON_STORE_HOUSE_BUNDLES_2026-11-07.md`, que resolveu só os 7 temas de **Casas**. Usuário
pediu para também mapear as outras categorias. Esta é uma classificação de **todos** os 224 pacotes do único
objeto `PWC.Inventory.InventoryBuildData` do jogo, por heurística (nome do pacote + categoria majoritária dos
itens resolvidos em `store_catalog.json`) — **não é prova**, é uma primeira passada para orientar o que vale a
pena investigar a fundo depois, igual já foi feito para Casas.

Script: `tools/recon_store_packs_overview.py`. Saída: `out/recon/store_all_packs_overview.json`.

## Resumo por categoria (heurística, refinada em 2026-11-22)

| Categoria | Pacotes | Itens |
|---|---:|---:|
| Moda/avatar | 74 | 3435 |
| Casa/cômodo | 65 | 2958 |
| Celebração | 19 | 1598 |
| Bebê/criança | 18 | 739 |
| Pet | 17 | 385 |
| Esporte | 10 | 589 |
| Veículo | 10 | 185 |
| Indefinido | 11 | 137 |

224 pacotes, 10026 itens no total (contagem de guids, não deduplicada entre pacotes). Primeira passada (2026-11-07)
tinha 58 "Indefinido"; refinado adicionando os prefixos de família já confirmados em
`docs/RECON_STORE_HOUSE_BUNDLES_2026-11-07.md` (`BubbleGlam*`, `GalxeHM*`, `IslandHM*`, `NaturalChic*`, `SnowyHM*`
etc. sempre viram Casa/cômodo, independente do conteúdo), mais categorias de item que faltavam no mapeamento
(`sticky`, `garden`, `ornament`, `ugc`, etc.) e um nome-padrão pra Moda (`y2k`, `makeup`, `hiphop`, `swim`...).
Os 11 que sobraram são pacotes pequenos e genuinamente ambíguos (ex.: `PE42_MailBoxBox_Pack`,
`PE45_PiggyVault_Pack`, `StarStage_PE18Box_Pack`) — não valem mais tempo de heurística, só revisão manual caso
algum deles vire relevante depois.

## Limites desta passada
- É **classificação automática**, não confirmação. "Moda/avatar" aqui é qualquer pacote cujos itens resolvidos
  têm maioria de categoria `character` no catálogo (ou nome com padrão de moda) — inclui tanto combos de roupa
  (como os já documentados em `docs/STORE_BUNDLE_CONTENTS.md`, que vêm de `InventorySkinsBuildData`, objeto
  **diferente**) quanto pacotes temáticos que misturam roupa com cenário (ex.: fantasias, esportes).
- "Casa/cômodo" ficou mais abrangente do que "cômodo de casa" no sentido estrito: inclui parque/playground/dog
  park (categoria de item `ugc`) por falta de um bucket de "ambiente externo" dedicado — rotulagem aproximada,
  não uma categoria real da loja confirmada.
- Nenhum pacote teve o conteúdo real conferido contra print do original, exceto os 2 já confirmados em
  `docs/RECON_STORE_HOUSE_BUNDLES_2026-11-07.md` (Galxe Mansion, Natural Chic).
- Pacotes "Bundle-capa (0 itens diretos)": só 8 no total (os 7 de Casas + `CatamarnP36_Pack`, Veículo, sem
  cômodos/conteúdo associado encontrado, igual ao caso não resolvido de `MansionBundlePB2`) — confirma que o
  padrão "bundle-capa remete a sub-pacotes por prefixo de nome" é raro, não um mecanismo geral; os outros ~216
  pacotes já são listas de itens completas por si.

## Pendência: as outras ~124 classes com o mesmo bug de type-tree
Resolvido que **não é falta de RAM momentânea**: confirmado por `journalctl -k` (2026-11-21) que o processo
precisa de ~6 GB de RAM residente só pra carregar `datapack.unity3d`, mais do que esta máquina (7,1 GB) comporta
sozinha, mesmo sem contenção de outras sessões. Decisão do usuário: rodar no PC do trabalho. Script levado para
dentro do repo com instruções completas: `tools/mb_retry_failed_classes.py`. Detalhe em `LOOP_STATE.md`
(entrada "reextração das ~124 classes... — 2026-11-21").

## Próximo passo sugerido
1. Rodar `tools/mb_retry_failed_classes.py` numa máquina com mais RAM livre — pode revelar uma estrutura de
   categoria real da loja em vez de inferência por nome/conteúdo.
2. Revisar manualmente os 11 pacotes "Indefinido" restantes e `MansionBundlePB2`/`CatamarnP36_Pack` (bundles-capa
   sem conteúdo encontrado), achando os sub-pacotes reais do mesmo jeito que foi feito para os 7 temas de Casas.
3. Só depois disso faz sentido decidir o que "colocar no jogo" de fato — o cliente não tem editor de casas, loja
   de veículos/pets etc. implementados ainda.
