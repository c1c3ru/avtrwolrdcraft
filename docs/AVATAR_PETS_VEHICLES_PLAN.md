# Pets e veículos no slot de avatar: levantamento e plano

Data: 2026-11-06. Estado: **não implementado**; só inventário (nenhum render foi possível neste ambiente).

## Pets
- Esqueletos `Pet_{Dog,Cat,Rabbit,Hamster,Bird,Chicken,Fish,Lizard,Snake,Turtle}_Spine` + `Pet_Horse`/`Cow_Pet` em `out/assets/TextAsset`. Cães e gatos têm roupas SUT (`sutsystem/skins/{dog,cat,horse}`: 844/782/368 refs); os demais não têm roupas.
- Cão (437 skins) e gato (268) são compostos por camadas: `Breed_A..R/{Body/Body_Base_Color, Body/Body_Outline, Eyebrows/*, Pattern/Pattern_N_Color}`, `Eyes_{Outline,Base,Gradient,Pupils}/*`, `Mouth/*`, `Templates/*` (roupas). Raça, padrão, sobrancelha e cor do corpo são skins independentes com cores próprias (ver `AvatarSpineSkinsColoringConfigs_*`).
- Espécies simples (coelho: `Rabbit_A_1`, `Rabbit_B_1`…) são só skins prontas = variantes.
- Reuso: `tools/avatar_kind_build.py` (resolução skin -> região -> página -> textura), `AvatarGpuRuntime` por tipo, `AvatarKind`. Falta: categorias de editor próprias (espécie, raça, padrão, cor do corpo/padrão, olhos, boca, roupa), tintas por camada (corpo = cor base, padrão = cor própria) e ícones de menu.

## Veículos
- Existem `CarMakerOneSlot`, `CarMakerFiveSlots`, `CarDefaultCategoryColors` e `AvatarSpineSkinsDefaultColors_Car_SeatsColors` (editor de carro por slots e cores), mas nenhum esqueleto de "carro do avatar" foi identificado ainda (os `Car_*.skel` são carros de cenário). Precisa de uma tarefa de descoberta (T0xx) antes de qualquer UI.

## Recomendação
1. Validar o render de criança/bebê (PR #13-#15) num Editor/aparelho antes de acrescentar mais tipos.
2. Pets em duas fases: (a) espécies simples + cão/gato com raça e cor de corpo; (b) padrões, olhos, boca e roupas.
3. Veículos: descoberta do CarMaker primeiro.
