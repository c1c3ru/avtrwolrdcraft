# Backlog: pacotes de moda individuais do original sem arte local, 2026-11-07

Fonte: `out/cpp2il/DiffableCs/Assembly-CSharp/Store/StorePackType.cs` (enum decompilado do APK, nomes
internos reais, não config remota). Além dos 22 combos (`PBnn`) já em `StoreCatalog.cs`, o enum lista
~31 pacotes individuais de moda com prefixo `PFnn`, agrupáveis por tema recorrente. Nenhum tem arte em
`client/AvatarWorldClient/Assets/Resources/Store/` hoje — não são itens prontos pra usar, só candidatos
pra quando houver arte (extraída do APK ou refeita).

Como o enum é nome de código (não necessariamente o título localizado exibido na tela), os nomes abaixo
são indicativos do tema, não a string final confirmada.

## Temas identificados (ids do enum entre parênteses)

| Tema | Pacotes | Qtde |
|---|---|---|
| Y2K Hip Hop | PF1–PF6 | 6 |
| Y2K Baller | PF7–PF10, PF12 | 5 |
| Y2K Edgy Star | PF13, PF14 | 2 |
| Kawaii | PF11, PF15, PF16, PF18, PF20 | 5 |
| Daizy (Daisy) | PF17, PF19 | 2 |
| Family Outdoors | PF21 | 1 |
| Fashion Road Trip | PF22 | 1 |
| Summer Waves | PF23 | 1 |
| Vintage Academia | PF24 | 1 |
| Mermaid | PF25 | 1 |
| Mini Me | PF27 | 1 |
| Rain Fashion | PF28 | 1 |
| Picnic Squad | PF30 | 1 |
| Pool Party | PF31 | 1 |
| Pilates Fashion | PF32 | 1 |
| Dreamy Baby | PF33 | 1 |

PF26 e PF29 não aparecem no enum (gap — provavelmente item descartado/renomeado no original).

## Uso sugerido

O cluster "Y2K" (13 entradas somando HipHop/Baller/EdgyStar) é o mais forte candidato a ter sido um
ícone próprio do sub-trilho de Moda no original — nenhum outro tema se repete tanto. Se a licença de
arte ou um substituto próprio aparecer, dá pra virar o 7º/8º subgrupo de `CategoryFashion` em
`StoreCatalog.cs`, mantendo os 6 já documentados em `docs/STORE_WORLD_UI_SPEC.md`.

Os demais temas (1–2 pacotes cada) servem mais como ideias de combo futuro do que como subgrupo novo.
