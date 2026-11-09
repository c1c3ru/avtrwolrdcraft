# Loja: visão geral dos 224 pacotes de `InventoryBuildData` (2026-11-07)

Continuação de `docs/RECON_STORE_HOUSE_BUNDLES_2026-11-07.md`, que resolveu só os 7 temas de **Casas**. Usuário
pediu para também mapear as outras categorias. Esta é uma classificação de **todos** os 224 pacotes do único
objeto `PWC.Inventory.InventoryBuildData` do jogo, por heurística (nome do pacote + categoria majoritária dos
itens resolvidos em `store_catalog.json`) — **não é prova**, é uma primeira passada para orientar o que vale a
pena investigar a fundo depois, igual já foi feito para Casas.

Script: `tools/recon_store_packs_overview.py`. Saída: `out/recon/store_all_packs_overview.json`.

## Resumo por categoria (heurística)

| Categoria | Pacotes | Itens |
|---|---:|---:|
| Casa/cômodo | 50 | 2570 |
| Moda/avatar | 49 | 1772 |
| Indefinido | 58 | 2322 |
| Bebê/criança | 21 | 1063 |
| Celebração | 14 | 1291 |
| Pet | 14 | 260 |
| Esporte | 9 | 564 |
| Veículo | 9 | 184 |

224 pacotes, 10026 itens no total (contagem de guids, não deduplicada entre pacotes).

## Limites desta passada
- É **classificação automática**, não confirmação. "Moda/avatar" aqui é qualquer pacote cujos itens resolvidos
  têm maioria de categoria `character` no catálogo — inclui tanto combos de roupa (como os já documentados em
  `docs/STORE_BUNDLE_CONTENTS.md`, que vêm de `InventorySkinsBuildData`, objeto **diferente**) quanto pacotes
  temáticos que misturam roupa com cenário (ex.: fantasias, esportes).
- "Indefinido" (58 pacotes, maior grupo) é tudo que não teve sinal forte em nenhuma direção — merece uma segunda
  passada manual antes de qualquer implementação.
- Nenhum pacote teve o conteúdo real conferido contra print do original, exceto os 2 já confirmados em
  `docs/RECON_STORE_HOUSE_BUNDLES_2026-11-07.md` (Galxe Mansion, Natural Chic).
- Pacotes "Bundle-capa (0 itens diretos)" (ex.: a maioria dos `...PBnBox_Pack`) não entram nos buckets de
  conteúdo — são capas que remetem a outros pacotes por convenção de nome (ver `rooms` nos temas de Casas já
  resolvidos); esta passada não tentou resolver bundles-capa fora de Casas.

## Pendência: as outras ~124 classes com o mesmo bug de type-tree
Tentei reaproveitar o fix de `tools/mb_dump.py` para reextrair as ~124 classes que ainda falhavam em
`out/mb/_stats.json` (43 com o mesmo `EOFError: read_str out of bounds` das duas já corrigidas, 81 com
`ValueError` de contagem de bytes — possivelmente a mesma causa, não confirmado). **Não consegui rodar**: a
máquina tem só 7,1 GB de RAM e `datapack.unity3d` (1,3 GB, ~882k objetos) sozinho já não coube na memória
disponível com outra sessão do Claude rodando em paralelo no mesmo checkout (worktree `store-moda-submenus`) —
matado por falta de memória (`exit 137`) duas vezes seguidas, sempre no mesmo ponto (carregando o datapack, antes
de sequer começar a tentar as classes-alvo). Script pronto em
`/home/c1c3ru/.claude/jobs/57f8c0ba/tmp/retry_failed_classes.py` (fora do repo) para rodar depois, numa máquina
com mais RAM livre ou sem outra sessão pesada concorrente.

## Próximo passo sugerido
1. Rodar a reextração das ~124 classes (acima) quando houver RAM livre — pode revelar uma estrutura de categoria
   real da loja em vez de inferência por nome/conteúdo.
2. Revisar manualmente os 58 pacotes "Indefinido" e os pacotes-capa (`...PBnBox_Pack`) fora de Casas, achando os
   sub-pacotes reais do mesmo jeito que foi feito para os 7 temas de Casas (prefixo de nome compartilhado).
3. Só depois disso faz sentido decidir o que "colocar no jogo" de fato — o cliente não tem editor de casas, loja
   de veículos/pets etc. implementados ainda.
