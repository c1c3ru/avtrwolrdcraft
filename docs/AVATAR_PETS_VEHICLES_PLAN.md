# Pets e veículos no slot de avatar: levantamento e plano

Data: 2026-11-06. Estado: **pets simples e cão/gato implementados** (sem validação de render); cavalo, vaca, roupas de pet e veículos seguem só como inventário.

## Implementado: pets simples
- Espécies com variantes prontas (skin completo): coelho 4, hamster 4, pássaro 9, galinha 3, tartaruga 2, lagarto 4, cobra 2, peixe 4 (32 variantes; as `Party_Hat_Skin_*` ficaram de fora).
- Dados: `tools/avatar_pet_build.py` (skin -> região -> página -> textura única por nome+dimensões) gera `Resources/AvatarSpine/Pets/<Espécie>/{Spine.atlas.txt,Spine.skel.bytes,pet.json}` e `PetCatalogData.cs`; checagem cruzada: 0 problemas.
- Cliente: `PetAppearance`/`SavedPet` em `PlayerState.Pets` (3 slots), `PetGpuRuntime` (skin composto default + variante, animação `General/Chilling`), `PetEditorScreen` (espécie + variante), aba de pets da tela de slots.
- Não validado em aparelho/Editor; escala (1,3 no editor, 0,8 nos slots) e posição foram estimadas.

## Implementado: cão e gato (em camadas)
- `tools/avatar_pet_layers_build.py` monta `pet.json` em camadas: cão 18 raças / 72 padrões / 84 sobrancelhas / 9 conjuntos de olhos / 11 bocas; gato 8 raças / 32 padrões / 22 olhos / 10 bocas. Paletas próprias (`AWSpineColorsList` Dog_Body/Patterns/Eyes/Eyebrows, Cat_Body/Patterns/Eyes) em `pet-palettes.json`.
- Papéis de cor (hipótese, não conferida em tela): corpo/padrão/sobrancelha = cor de exibição multiplicada na textura; olhos: `Colors[0]` na base e `Colors[1]` no gradiente do cão; contornos e pupilas sem tinta.
- Editor: abas Raça, Padrão, Cor, Cor padrão, Sobrancelha, Cor sobr., Olhos, Cor olhos, Boca, com grade rolável (rótulos numéricos, sem miniaturas).
- Fora: roupas e acessórios de cão/gato (`Templates/*`, paths SUT `dog/*`, `cat/*`), cavalo e vaca.

## Pets
- Esqueletos `Pet_{Dog,Cat,Rabbit,Hamster,Bird,Chicken,Fish,Lizard,Snake,Turtle}_Spine` + `Pet_Horse`/`Cow_Pet` em `out/assets/TextAsset`. Cães e gatos têm roupas SUT (`sutsystem/skins/{dog,cat,horse}`: 844/782/368 refs); os demais não têm roupas.
- Cão (437 skins) e gato (268) são compostos por camadas: `Breed_A..R/{Body/Body_Base_Color, Body/Body_Outline, Eyebrows/*, Pattern/Pattern_N_Color}`, `Eyes_{Outline,Base,Gradient,Pupils}/*`, `Mouth/*`, `Templates/*` (roupas). Raça, padrão, sobrancelha e cor do corpo são skins independentes com cores próprias (ver `AvatarSpineSkinsColoringConfigs_*`).
- Espécies simples (coelho: `Rabbit_A_1`, `Rabbit_B_1`…) são só skins prontas = variantes.
- Reuso: `tools/avatar_kind_build.py` (resolução skin -> região -> página -> textura), `AvatarGpuRuntime` por tipo, `AvatarKind`. Falta: categorias de editor próprias (espécie, raça, padrão, cor do corpo/padrão, olhos, boca, roupa), tintas por camada (corpo = cor base, padrão = cor própria) e ícones de menu.

## Veículos
- Existem `CarMakerOneSlot`, `CarMakerFiveSlots`, `CarDefaultCategoryColors` e `AvatarSpineSkinsDefaultColors_Car_SeatsColors` (editor de carro por slots e cores), mas nenhum esqueleto de "carro do avatar" foi identificado ainda (os `Car_*.skel` são carros de cenário). Precisa de uma tarefa de descoberta (T0xx) antes de qualquer UI.

## Recomendação
1. Validar o render de criança/bebê e de pets num Editor/aparelho.
2. Pets fase 2: cão/gato com raça e cor de corpo; depois padrões, olhos, boca e roupas (e cavalo/vaca).
3. Veículos: descoberta do CarMaker primeiro.
