# Pets e veículos no slot de avatar: levantamento e plano

Data: 2026-11-06. Estado: **pets simples, cão, gato, cavalo e vaca implementados** (sem validação de render); roupas de pet (cão, gato, cavalo) implementadas; **veículos não são implementáveis com os dados extraídos** (ver abaixo).

## Implementado: pets simples
- Espécies com variantes prontas (skin completo): coelho 4, hamster 4, pássaro 9, galinha 3, tartaruga 2, lagarto 4, cobra 2, peixe 4 (32 variantes; as `Party_Hat_Skin_*` ficaram de fora).
- Dados: `tools/avatar_pet_build.py` (skin -> região -> página -> textura única por nome+dimensões) gera `Resources/AvatarSpine/Pets/<Espécie>/{Spine.atlas.txt,Spine.skel.bytes,pet.json}` e `PetCatalogData.cs`; checagem cruzada: 0 problemas.
- Cliente: `PetAppearance`/`SavedPet` em `PlayerState.Pets` (3 slots), `PetGpuRuntime` (skin composto default + variante, animação `General/Chilling`), `PetEditorScreen` (espécie + variante), aba de pets da tela de slots.
- Não validado em aparelho/Editor; escala (1,3 no editor, 0,8 nos slots) e posição foram estimadas.

## Implementado: cão e gato (em camadas)
- `tools/avatar_pet_layers_build.py` monta `pet.json` em camadas: cão 18 raças / 72 padrões / 84 sobrancelhas / 9 conjuntos de olhos / 11 bocas; gato 8 raças / 32 padrões / 22 olhos / 10 bocas. Paletas próprias (`AWSpineColorsList` Dog_Body/Patterns/Eyes/Eyebrows, Cat_Body/Patterns/Eyes) em `pet-palettes.json`.
- Papéis de cor (hipótese, não conferida em tela): corpo/padrão/sobrancelha = cor de exibição multiplicada na textura; olhos: `Colors[0]` na base e `Colors[1]` no gradiente do cão; contornos e pupilas sem tinta.
- Editor: abas Raça, Padrão, Cor, Cor padrão, Sobrancelha, Cor sobr., Olhos, Cor olhos, Boca, com grade rolável (rótulos numéricos, sem miniaturas).
- Cavalo (mesmo builder): 2 raças, 10 padrões, 10 sobrancelhas, 13 conjuntos de olhos, 11 bocas, 20 crinas (cabelo da frente + de trás) e 20 caudas, com paletas `Horse_Body/Patterns/Eyes/Eyebrows/Hair/Tail`. Vaca: espécie simples (1 variante, `Cow_Pet`).
- Roupas (paths SUT `dog/*`, `cat/*`, `horse/*`, mesma regra estrita de textura): abas Chapéu, Roupa, Sapatos e Acessório. Cão 68 chapéus / 83 roupas / 14 sapatos / 48 acessórios; gato 59 / 67 / 4 / 31; cavalo: Chapéu = rédea (14) e Roupa = sela (13). Itens `_color`/`_p` ficam de fora. Sem tinta.
- Tamanho/posição: `PetGpuRuntime.Sizes` guarda a caixa da pose inicial medida de cada esqueleto (centro, base, largura, altura); cada animal é escalado a uma altura-alvo (editor 4,2; slots 2,3 unidades) e apoiado na base. A medida usa só a pose inicial (skin padrão + corpo), então é aproximada.

## Pets
- Esqueletos `Pet_{Dog,Cat,Rabbit,Hamster,Bird,Chicken,Fish,Lizard,Snake,Turtle}_Spine` + `Pet_Horse`/`Cow_Pet` em `out/assets/TextAsset`. Cães e gatos têm roupas SUT (`sutsystem/skins/{dog,cat,horse}`: 844/782/368 refs); os demais não têm roupas.
- Cão (437 skins) e gato (268) são compostos por camadas: `Breed_A..R/{Body/Body_Base_Color, Body/Body_Outline, Eyebrows/*, Pattern/Pattern_N_Color}`, `Eyes_{Outline,Base,Gradient,Pupils}/*`, `Mouth/*`, `Templates/*` (roupas). Raça, padrão, sobrancelha e cor do corpo são skins independentes com cores próprias (ver `AvatarSpineSkinsColoringConfigs_*`).
- Espécies simples (coelho: `Rabbit_A_1`, `Rabbit_B_1`…) são só skins prontas = variantes.
- Reuso: `tools/avatar_kind_build.py` (resolução skin -> região -> página -> textura), `AvatarGpuRuntime` por tipo, `AvatarKind`. Falta: categorias de editor próprias (espécie, raça, padrão, cor do corpo/padrão, olhos, boca, roupa), tintas por camada (corpo = cor base, padrão = cor própria) e ícones de menu.

## Veículos
- O carro do avatar é um `AvatarSpine` de `SpineType` 17 (Car) com categorias (`GarageL232_Cars`): corpo (`CM03`, 3 cores), vidro (`Window_Tint_*`), banco (`Seat_*`), calotas (`Hub_Caps_*`), amuleto (`Car_Charm_*`), elementos de teto (`Roof_Elements_*`) e adesivos (`Sticker_Full_*`), mais paletas `Car_Body/Car_Seat/Car_Window_Tint` e os itens de loja `CarMakerOneSlot/FiveSlots` (slots de carro: o slot bloqueado do cliente leva à loja por isso).
- **O esqueleto, o atlas e as texturas desse carro não estão no APK extraído**: nenhum TextAsset/Texture2D contém `Hub_Caps`/`CM03`; só existem 22 ícones de UI (`CM_Icon_*`) e as configurações. Os `Car_*.skel` encontrados são carros de cenário (outros esqueletos). O conteúdo do car maker provavelmente chega por download (pacotes P232/P235/P246/P240, build 228) e não faz parte do que foi extraído.
- Sem essa arte não dá para renderizar nem editar o veículo. Próximo passo possível: obter o pacote/asset bundle do carro (ou o dump do jogo com os downloads) e só então repetir o pipeline (esqueleto -> skins -> paletas).

## Recomendação
1. Validar o render de criança/bebê e de pets num Editor/aparelho.
2. Roupas e acessórios de pet (cão, gato, cavalo) via paths SUT.
3. Veículos: só com o esqueleto/arte do car maker (ver acima).
