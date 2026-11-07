# Especificação de UI: loja, mundo e quadra (a partir de prints do original), 2026-11-03

Fonte: 19 prints do original em `assets/exemplo_jogo_original/` (pasta ignorada pelo Git; tela 2400×1080 reduzida a 1600×720). Decisões de produto vêm do autor do projeto; o restante é observação dos prints + `docs/RECON_*`.

## Decisões de produto (do autor)
1. **Telas de compra mantêm o visual original.** A lógica **não** segue o original: nada de dinheiro real/IAP.
2. **Moedas AW** passam a ser obtidas por **atividades pedagógicas** (alfabetização etc.) — é aqui que o produto se diferencia. Gastar moedas desbloqueia itens localmente.
3. **A quadra de basquete é parte do mundo**, não destino do botão Play.

## Cenas originais correspondentes (BuildSettings, 254 cenas)
`Home`(3), `World`(4, serializado `level4`), `Store`(237), `StoreAvatarPass`(238), `StoreBundle`(239), `StarsPass`(253), `AvatarMakerLobby`(233, slots), `AvatarMaker`(234), `CarMaker`(235). Extraídos localmente (não versionados) em `out/scene-extract/level{4,233,237}`; `level237` = UGUI com 34 `Image`, 17 `TextMeshProUGUI`, 3 `ScrollRect`, `Game.Store.StoreViewManager`, `StorePazuCurrencyViewer`, `CoinAnimationManager`, `StarsPass.StarsPassBarManager`.

## Loja (prints 16.03.10 – 16.07.35)
Layout comum: botão voltar (topo-esquerda, roxo), **contador de moedas** (topo-direita, ícone estrela-moeda + valor), trilho vertical de categorias à esquerda, área de cartões com rolagem horizontal, `RESTORE PURCHASES` (rodapé-direita). Fundo roxo com padrão.
- **Categorias (trilho, pt-BR):** Moedas AW, Destaque, Veículos, Casas, Narrativa, Criador de Avatar, Combos, Moda, Casas de Férias, Pet, Celebrações, Profissões, Esportes, … (há mais abaixo). A categoria ativa abre um **sub-trilho** de ícones (ex.: Casas → 5 tipos; Veículos → destaque/carro/van; Moda → 6 subgrupos).
- **Sub-trilho de Moda (print `assets/exemplo_jogo_original/imagem8.jpeg`):** confirmado em 2026-11-07 — 6 ícones verticais, sem rótulo de texto (mesmo padrão de Casas/Veículos): pretzel/espiral, listras arco-íris na diagonal, flor rosa, cabeça de coelho branco, chapéu de bruxa roxo com rosto de raposa/gato, estrela dourada (selecionado nesse print, abrindo o cartão "MINI EU", 300 moedas, selo de 5 estrelas). **Não dá para recuperar os nomes reais:** não há texto nos ícones; `StoreData`/`StoreDataCloudResponse` (decompilado, `out/cpp2il/.../Game/Store/StoreData.cs`) prova que as chaves de categoria/subgrupo vêm de config remota, ausente do APK (`docs/STORE_BUNDLE_CONTENTS.md:3`); e uma tentativa de captura dinâmica em 2026-11-07 (app original `com.pazugames.avatarworld`, instalado no aparelho físico `AIBUR4JBNBLNQKKZ`) falhou — o app não permanece em foreground após `am start` (só o processo do nosso próprio build aparece em `ps -A` nas duas tentativas). Os 5 valores de `Sub` usados hoje em `StoreCatalog.cs` para `CategoryFashion` (Palco, Luxo, Infantil, Urbano, Casual) são **agrupamento nosso**, inferido do nome dos pacotes (`docs/STORE_BUNDLE_CONTENTS.md`), não os rótulos reais — mesma situação de Casas (5 confirmados no print vs. 4 grupos distintos implementados).
- **Cartões:** moldura colorida por tema, título, arte, **pílula de preço** (ícone de moeda + valor); promoções com selo "NN% OFF" e preço antigo riscado; fitas "BUNDLE"; selo de avatar nos itens de moda. Preços observados em moedas: 300–1400 (ex.: Carro de aventura 700, Casinha de brincar 770 [de 1100], Galxe Mansion 1200 [de 2400], Meu primeiro hamster 500, Festa de formatura 600, Show ao vivo 980 [de 1400], Mini Eu 300).
- **Moedas AW (print 16.03.37):** pacotes por dinheiro real (1250 "POPULAR" R$ 27,90; 8500 "MELHOR VALOR" R$ 166,90; +estrelas), **AW Pass** 2000/mês, **Cofrinho Gatinho** ("ganha moedas"), **Especial: presente de 150 moedas** com botão `RESGATAR`, e barra de progresso de estrelas 0/5.
- **Adaptação (nossa lógica):** manter layout, arte, categorias e pílulas; **trocar** pacotes em R$, AW Pass e `RESTORE PURCHASES` por **cartões de atividades pedagógicas** (mesmo estilo visual) que pagam moedas; `RESGATAR` pode virar resgate de recompensa de atividade concluída; cofrinho/barra de estrelas podem representar progresso de aprendizagem. Itens continuam com preço em moedas. **A decidir com o autor:** destino exato de AW Pass/Cofrinho/Pacote Inicial e se `RESTORE PURCHASES` some.

## Slots de avatar/veículo/pet (prints 16.07.17, 16.07.35)
Tela `AvatarMakerLobby`: botão voltar; três abas (carro com "NEW", pet, avatar); 3 slots com silhueta tracejada e botão `+`; lixeira central; aba de veículos mostra silhueta laranja com botão de carrinho (→ loja).

## Mundo (prints 16.08.14 – 16.08.47)
- **Mapa `World`:** barra superior: voltar; **clima** (expande: ensolarado/flor/chuva/neve); **globo/viagem** (expande miniaturas dos 5 mundos: cidade, praia/férias, cidade estelar, campo/fazenda…); à direita **adicionar avatar (+)** e **editar casa**. Canto inferior-esquerdo: bolha **Pacote Inicial** (→ loja); inferior-direito: widget de veículo (×1, carrinho).
- **Prédios em obras** (fita amarela/preta): lava-jato, posto de gasolina, hambúrguer (`CarWash`, `GasStation`, `BurgerRestaurant`) — coincidem com os `LevelType` sem cena no APK; **não interativos**.
- **Modo edição do mundo** (16.08.47): ícones voltar + livro/casa + lápis verde; prédios com contorno tracejado.
- **Cena de nível** (16.09.15/47): botão voltar, três ícones pendurados em cordas (música, varinha, barco), ícone de **celular** (inferior-direito); **barra de chat/emotes** (balão de fala + 7 emotes).

## Quadra de basquete no mundo
No original: mapa `World` → prédio **`MiniBasketball_Z1B3`** (em `level4`, `_defaultLevelType = MiniBasketball_L1`, valor 13) → cena `Level_MiniBasketball_L1` (BuildSettings 8, serializado `level8`, Sunrise Hills). Outras cenas de esporte existem (`Level_Gym_L164`, `Level_Basketball_LM1`, `Level_DogPark_L165`, `Level_Playground_LM201`) mas não são o prédio padrão do mapa. Contratos de toque/carga: `docs/RECON_WORLD_CLICK_CONTRACT.md`, `docs/RECON_LOAD_SCENE_CONTRACT.md`.

## Plano proposto (fatias verticais, cada uma validada no aparelho antes da próxima)
1. **Navegação do original**: Play → mapa `World` (exportar `level4`: fundo, prédios com `WorldBuilding`, colliders de toque, música `Main_Theme_Loop`); remover a quadra do Play; voltar → Home.
2. **Prédio de basquete**: toque em `MiniBasketball_Z1B3` abre a quadra (`BasketballCourtRuntime`, `level8`); voltar → mapa. Prédios em obras ficam inertes; demais prédios sem cena ainda ficam inertes com feedback neutro.
3. **Barra do mapa**: voltar, clima (efeito visual), globo (miniaturas; só `World` ativo no início), + avatar → slots, editar casa (depois).
4. **Loja com visual original** (`level237`): trilho de categorias, cartões, pílulas, contador de moedas ligado ao save; compra com moedas; sem R$/IAP.
5. **Atividades pedagógicas → moedas**: reaproveitar o desafio de alfabetização existente como fonte de moedas; cartões de atividade na categoria "Moedas AW".
6. **Slots/avatar/veículo** (`AvatarMakerLobby`) conforme prints.

Sem validação em runtime do original além do que está nos documentos RECON; telas aqui descritas são **observação de prints**, não decodificação de código.

## Estado da fatia 1 (2026-11-03)
Implementada em `Scripts/Runtime/{WorldMapRuntime,WorldMapData}.cs` + `Resources/WorldSlice/` (dados de `tools/export_world_map.py`). Play abre o mapa; o prédio `Basketball_T1S2` abre a quadra; prédios em obras (`*_UC_*`) e sem cena mostram aviso. EditMode 88/88 e build OK; **falta validar no aparelho** (ver `LOOP_STATE.md`).
Decisões de produto confirmadas: Pacote Inicial = 700 moedas (nível médio); faixas de preço até 500 / 501–899 / 900+.
