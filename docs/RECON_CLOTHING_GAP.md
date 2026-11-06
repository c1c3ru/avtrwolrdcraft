# Lacuna de catálogo de roupas — T033

Data: 2026-11-04. A meta de 2.174 IDs foi informada pelo usuário; não foi encontrado neste checkout um arquivo/lista de referência que atribua esse total às categorias do editor.

## Contagem conferida

| Métrica | IDs | Significado |
|---|---:|---|
| Quatro categorias principais no catálogo usado pelo runtime | **400** | 100 camisas + 100 partes de baixo + 100 sapatos + 100 acessórios |
| Manifesto completo atual | 772 | IDs no `clothing-manifest.json`, incluindo cabelo e outras categorias |
| Arrays atuais em `AvatarCatalogData` | 775 | 8 arrays; não equivale a 775 roupas das quatro categorias principais |
| Candidatos estritamente resolvidos nas quatro categorias | **4.016** | 1.042 camisas, 970 partes de baixo, 1.171 sapatos, 833 acessórios |
| Meta comunicada | **2.174** | Distribuição por categoria ainda não documentada |

Os 400 são reproduzíveis: `tools/avatar_catalog_build.py` usa `--per-category 100` por padrão, e `AvatarCatalogData.cs` contém precisamente 100 opções nas quatro categorias principais. Portanto, esse limite vem da seleção do pipeline; não é um limite dos arquivos já extraídos. A diferença até a meta do usuário é 1.774 IDs. Os recursos extraídos apresentam candidatos suficientes para preenchê-la dentro das quatro categorias com as regras estritas atuais.

O inventário do SUT contém 48.200 referências e 8.979 pastas de item distintas em várias categorias. O auditor encontrou 4.016 IDs das quatro categorias que passam correspondência exata de textura única, página de atlas e dimensão. Isso não prova compatibilidade de attachments, cores ou renderização. A seleção atual pula sufixos `_color`/`_p` em várias categorias e cobre somente óculos e adornos de pescoço dentro de acessórios.

## Auditoria reproduzível

`python3 tools/recon_clothing_gap.py` grava `out/recon/tasks/T033/clothing-gap-audit.json`, com hashes de entradas, contagens por categoria e as limitações de resolução. SHA256 do inventário SUT: `f10a826783f6e189c6c3cb9135313d40627b869701659a5ca9f09ce478cc3be7`. O JSON também registra hashes do atlas, manifesto, catálogo e nomes das texturas.

O auditor preparou `out/recon/tasks/T033/clothing-candidate-2174.json`: exatamente 2.174 IDs únicos, preservando os IDs atuais e distribuindo os demais proporcionalmente aos candidatos resolvidos (**564 camisas, 525 partes de baixo, 634 sapatos e 451 acessórios**). Essa distribuição é uma proposta de capacidade derivada do SUT, não um dado recuperado do UI original. Ela foi integrada ao catálogo do cliente; 1.774 peças foram adicionadas. A integração estática não comprova ordem original, compatibilidade visual completa nem disponibilidade sem compra.

## Compra e disponibilidade

O original tem gates de expansão no editor: o assembly contém `FilterByClaimedInventoryFlags`, `GetOwnedPackFlagsInTabOrder`, `GetPremiumItemsNames`, `GetRelevantInventorySkins` e `InitAvailableExpansionPacks`; `InventorySkinsBuildData` associa flags de inventário aos nomes das skins. Isso confirma que certos itens do editor dependem de flags/pacotes.

## Cruzamento das flags com o catálogo

`tools/recon_clothing_gates.py` leu os dois objetos `InventorySkinsBuildData` serializados em `out/scene-extract/resources.assets`, usando o assembly para resolver os enums `InventoryFlagType` e `SpineType`. Os objetos consumiram integralmente os respectivos dados serializados: `ExpansionPacksBuildData` tem **48 flags e 1.763 associações flag/skin**; `InventorySkinsBuildData` tem **3 flags premium e 11 associações** (5 cabelos toddler e 3 para cada um dos outros dois flags). Isso corrige a contagem preliminar de seis nomes baseada apenas na leitura incompleta do CSV.

O cruzamento exato normaliza maiúsculas/minúsculas e remove apenas o sufixo terminal `_Color` ou `_P` do nome da skin. Das 2.174 opções atuais, **64 aparecem explicitamente no mapa de expansão**: 2 camisas, 2 partes de baixo, 52 sapatos e 8 acessórios. Nenhuma das opções das quatro categorias corresponde às 11 skins da tabela premium, que são cabelos. As outras **2.110** não aparecem nas duas tabelas recuperadas; isso significa “sem flag encontrada nessas tabelas”, não prova que sejam gratuitas.

O relatório detalhado com hashes, cada associação de skin, flag, tipo Spine e cruzamento por ID está em `out/recon/tasks/T033/clothing-gates-crosswalk.json`. Reproduzir: `tools/venv/bin/python tools/recon_clothing_gates.py`. O nome da família é inferido do prefixo da skin; as tabelas serializadas não guardam o inteiro da categoria visual do menu. A classificação também continua dependente da lista candidata e sua distribuição proporcional, que não foi recuperada do UI original.

O cliente ainda não aplica os gates de compra e expõe as 2.174 opções. Não converter os 2.110 itens sem correspondência em “grátis” até reconciliar o mapa integral com as categorias e as fontes de inventário do editor.

## Próximo recorte

1. Reconciliar o mapa recuperado com as listas de skins/categorias do editor para classificar os 2.110 itens restantes sem inferir gratuidade pela ausência na tabela.
2. Fixar a distribuição original dos 2.174 IDs entre categorias; a distribuição atual é apenas proporcional à disponibilidade de arquivos resolvidos.
3. Recuperar coloração e compatibilidade de variantes que terminam em `_color`/`_p`, sem tint uniforme presumido.
4. Validar thumbnails e renderização em runtime posteriormente.

T033 continua parcial. A fila canônica ainda lista T017–T019 e T025–T027 como dependências pendentes; este levantamento é uma reconciliação de evidências e não promove o estado da tarefa.
