# Tipos de avatar: adulto, criança e bebê

Data: 2026-11-06. O original tem três famílias de avatar humano (`SpineType`: Character=1, Baby=2, Toddler=13). O cliente passou a suportar as três nos slots de avatar humano.

## O que existe
- `AvatarKind` (Adult/Toddler/Baby) em `AvatarAppearance.Kind`; saves antigos sem o campo continuam adultos.
- Cada tipo usa o próprio esqueleto e atlas (`Resources/AvatarSpine/Kinds/<Tipo>/Spine.{skel.bytes,atlas.txt}`) e um manifesto próprio (`manifest.json`), com o item fixo `__body` (corpo, orelha, olhos e a cor que cada peça recebe).
- Catálogo por tipo em `AvatarKindCatalogData` (gerado por `tools/avatar_kind_build.py`): criança 48 cabelos, 295 camisas (camisas + jaquetas + vestidos inteiros), 134 calças (+ fraldas), 190 sapatos, 38 acessórios (pescoço, bolsas, itens de costas, carregador), 38 bocas, 21 sobrancelhas; bebê 34 cabelos, 195 camisas (wrap + babador), 301 acessórios (óculos, chapéus, carregador), 42 bocas, 21 sobrancelhas. Categorias sem itens (calça/sapato do bebê, cabelo traseiro) ficam fora do menu.
- Tela de slots: tocar num slot vazio pergunta o tipo; slots já criados mostram o tipo embaixo do avatar.

## Como foi resolvido
- Itens de roupa: caminhos `sutsystem/skins/{toddler,baby}/...` do ResourceManager do APK base (o inventário antigo só lia `character`), com a mesma regra estrita do adulto (uma textura `<peça>_<path_id>.png` por peça, página de atlas com as mesmas dimensões, skin `Templates/<página>` no esqueleto).
- Rosto e corpo: skin do esqueleto -> `path` do attachment -> região do atlas -> página -> textura única por nome+dimensões. Skins cuja página tem textura ambígua foram descartadas (6 bocas de cada tipo).
- Entradas: `out/recon/tasks/T034/{other-skins,Toddler.skins,Baby.skins}.json`.

## Limitações
- Não validado em aparelho nem no Editor com render real: foram checados compilação, existência de skin/região/PNG de cada peça (`0` problemas) e testes EditMode escritos (`AvatarSlotsTests`). Recortes das miniaturas de criança/bebê são escalados pela altura da malha e podem precisar de ajuste fino.
- Itens de mão da criança (bicicleta, instrumentos, cavalinho) não entram. Peças `_color`/`_p` ficam de fora, como no adulto.
- Jaquetas e vestidos inteiros dividem a categoria Camisa (e fraldas a Calça): um vestido inteiro usa os mesmos slots da calça, então o último a ser aplicado cobre o outro.
- Cores: as paletas de pele/olhos/geral (`AWSpineColorsList`) são globais, então valem para os três tipos. Mas os `ColoringConfigs` de criança e bebê usam mistura **Overlay** e o cliente aplica **Multiply** (como no adulto); a cor de cabelo/sobrancelha de criança/bebê pode sair mais escura que a original até haver um shader Overlay.
- Pets e veículos continuam sem slot funcional: os esqueletos `Pet_*_Spine` existem, mas pedem a mesma extração por espécie (catálogo, atlas, roupas de cão/gato) e não há arte de veículo no slot.
