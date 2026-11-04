# Inventário estático: mapas, veículos, acessórios e pets

Data: 2026-11-04. Relatório reproduzível: `tools/venv/bin/python tools/recon_world_assets.py`. Saídas completas em `out/recon/tasks/T042/world-vehicles-accessories-pets.json` e `out/recon/tasks/T042/resource-container-index.json.gz`.

## Mapa do mundo e cenas

- O `ResourceManager` do APK lista **154.446 referências** para **92.603 caminhos únicos**; o índice comprimido preserva path, arquivo de destino e `path_id`.
- Há **176 grupos** sob `level/sceneitems/`. São diretórios de recursos por cena, ainda não uma contagem de cenas jogáveis verificadas.
- O export de `level4` contém **59 registros de edifícios**, **770 renderers** e **484 nomes de sprite**. Os valores originais `isFree` e `underConstruction` estão registrados no relatório, sem inferir a semântica de acesso apenas pelo campo.
- A composição/entrada da World map já tem um piloto separado. Os outros grupos ainda precisam de reconciliação por cena: componentes, dependências, navegação, estado de acesso e comportamento.

## Veículos

- Recursos `carsmaker`: bases de carro, peças de carroceria, charms, espelhos/rodas, ornamentos, calotas, elementos de teto, assentos e adesivos; o relatório traz os IDs de recurso de cada categoria.
- O índice contém quatro IDs de breed do CarMaker (oito referências) e **241 referências** sob `carsmaker/parts`.
- Partes com sufixos `p232`, `p235` e `p246` coincidem com flags chamadas `JeepCarBreedP232`, `RvCarVehicleP235` e `FamilyCarP246`. Registrei como associação candidata pelo número do pacote; ainda falta confirmar no componente de entitlement do CarMaker.
- As configurações de produto Jeep/RV descrevem slots, modelo, cores, tonalidade de janelas e decorações. O contrato de criação, seleção, salvamento e uso dos veículos em cena permanece em aberto.

## Acessórios

- O SUT contém oito famílias de acessórios do avatar Character (bolsas, pulseiras, luvas, pescoço, anéis, óculos, máscaras e piercings), além de acessórios para pets. IDs, caminhos e quantidades estão no relatório.
- O cruzamento com `InventorySkinsBuildData` recupera **263 itens Character/accessories** associados explicitamente a flags de inventário. As flags e skins correspondentes estão em `avatar_inventory_flags_crosswalk.matches`.
- O catálogo `store_catalog.json` também lista 506 referências categorizadas como `accessories`, mas é um catálogo de itens de cena, não uma lista completa de entitlement do editor.

## Pets

- `PetMaker_BreedsData` contém **35 presets**: 19 Dog (18 marcados `Is_Default=Yes`), 14 Cat (8 default) e 2 Horse (ambos default). Nomes, breed, prefab, tamanho e cores foram preservados.
- O SUT tem 213 pastas de itens Dog, 161 Cat e 27 Horse; isso inclui skins e partes de personalização, não representa número de animais ou presets.
- Flags `Dog_C` a `Dog_R` e `Cat_C` a `Cat_H` coincidem lexicalmente com breeds da tabela; o relatório marca essa relação como candidata. `Is_Default` não prova que a variante é gratuita, e a flag correspondente ainda precisa ser ligada ao fluxo real do PetMaker.
- Itens de pets/animais no `store_catalog` são conteúdo colocável em cenas; não são contagem de raças vendidas.

## Limites e próximo recorte

Este é um inventário de recursos e referências estáticas. Ele localiza conteúdo e algumas associações explícitas/candidatas, mas não fecha gates de compra, controles, física, save ou uso em jogo. T042 continua parcial porque as cenas e prefabs precisam de contratos próprios e há dependências canônicas pendentes. Próximo recorte: resolver os componentes de CarMaker e PetMaker e confirmar os campos de entitlement que ligam flags a breeds/veículos; depois selecionar uma cena piloto por domínio para reconstruir o fluxo.
