# Home comercial offline — interface visual

## Escopo

Substituição dos menus de texto de loja, presentes e passe por telas gráficas que reutilizam sprites originais extraídos localmente. A economia usa as regras offline autorizadas em `OFFLINE_HOME_RULES.md`. Isso conclui esta fatia de interface; não representa reprodução completa da loja, eventos, catálogo ou serviços online originais.

## Origem dos visuais

- Cena original da loja: `level237`, identificada por `Game.Store.StoreViewManager` no dump de MonoBehaviour; 83 nós exportados em `out/store-ui-export/level237.json`.
- Sprites de voltar, moeda, contador, botão verde e barra lateral: `resources.assets` e `sharedassets237.assets`, exportados sem abrir o bundle inteiro em RAM. `tools/export_level.py` aceita o diretório de arquivos serializados já extraídos como quarto argumento.
- Painéis: `UI_Panel_White_47597.png` original; artes de presentes/passe: `Gifts_Static_92702.png` e `AvatarPass_Static_67114.png`.
- Fundo: gradiente reconstruído com as cores serializadas no material `StoreBGGradient`, `sharedassets237.assets`, path_id 2.
- Produtos: três prévias geradas com o runtime Spine e as mesmas composições aplicadas pelas compras. Geração reproduzível: `AvatarWorld.EditorTools.StoreVisualAssets.RenderPreviews`. Não são imagens inventadas nem fotografias de outro produto.
- A organização dos três produtos e as categorias locais são uma adaptação offline. As imagens originais de pacotes indisponíveis não são anunciadas como itens entregáveis.

## Comportamento

- Loja compra/aplica composições reais; reaplicar item adquirido não cobra novamente.
- Presentes inicial e diário concedem moedas uma única vez por regra; botões de resgate ficam inativos após recebimento.
- Passe compra ativação local e valida marcos de 4/8/12 desafios diferentes antes de conceder cada prêmio.
- Todas as telas oferecem retorno e navegação entre categorias; loja abre editor e atividade de moedas.
- Removido o overlay Coming Soon que cobria Avatar ID e o hitbox de presente sem View que interceptava o Starter Pack. GiftBadge visível abre os presentes.

## Evidência no aparelho

Xiaomi M2101K7BI, ADB USB, orientação paisagem. Capturas:

- `out/store-visual-device-shop.png`: cartões gráficos com os três avatares, preços e contador.
- `out/store-visual-device-gifts.png`: presentes com saldo 35 após compra de 15 moedas.
- `out/store-visual-device-pass.png`: saldo 70 após presentes inicial (+25) e diário (+10).
- `out/store-visual-device-pass-active.png`: passe ativado por 60, saldo 10; prêmio recusado por falta de desafios.

O save foi lido após essas operações: uma compra de visual, um resgate inicial, um resgate diário e uma ativação de passe, cada qual registrado uma única vez. A aparência aplicada contém os mesmos IDs da prévia do produto. A primeira captura do passe ativado revelou sobreposição do terceiro prêmio pela ação de jogar; posições corrigidas e teste de regressão incluído. A captura final corrigida é registrada separadamente ao concluir a instalação.

## Entrega validada

- Unity EditMode: **72/72 passaram**, zero falhas/ignorados, em `out/test-results-store-visual.xml`.
- Build final: `out/unity-store-visual-delivery-build.log`, `ProjectSetup: build Succeeded`.
- APK: `client/AvatarWorldClient/Builds/AvatarWorldOffline-dev.apk`, 106.089.488 bytes, SHA256 `97fe877acf804a63dd709c7c012dd7f41265fbeabd71377892744cfb05ce31a7`.
- Instalação final com `adb install -r`: Success. Reabertura preservou saldo 10, propriedade do visual, presentes resgatados, passe ativo e aparência.
- `out/store-visual-device-final-pass.png`: os três prêmios e a ação de jogar estão separados e visíveis na build final.
- `out/store-visual-device-editor.png`: acesso ao editor pela loja mostra a mesma aparência da compra, com cabelo 2, camisa 1, calça 2, sapato 1 e acessório 2.
- `git diff --check`: sem erros.

## Limites mantidos

O catálogo contém apenas as três composições renderizáveis desta fatia. Multiplayer, conta/cloud e demais serviços online permanecem pendentes. Perfil/progresso são telas locais de apoio. Os avisos de materiais Spine não resolvidos ao abrir o editor/quadra já existiam e não foram solucionados nesta alteração.
