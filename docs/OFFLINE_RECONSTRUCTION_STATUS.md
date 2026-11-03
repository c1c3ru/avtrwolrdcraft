# Reconstrução offline — escopo, evidências e pendências

Atualizado em 2026-10-31. Este documento descreve o que foi observado no APK original, o que o cliente local realmente implementa e o que ainda falta. “Responde ao toque” não significa “equivalente ao original”. O objetivo geral permanece aberto.

## Escopo acordado

- Reconstruir para uso offline as experiências e sistemas encontrados nos APKs do jogo original, começando por fatias pequenas que possam ser comparadas e validadas.
- Não integrar login obrigatório, backend, multiplayer online ou transações com dinheiro real. Qualquer conteúdo bloqueado que seja reconstruído deve usar uma economia local, documentada e persistente.
- Manter a atividade pedagógica aleatória como uma opção para obter moedas; ela não substitui o botão Play nem o jogo principal.
- O saldo local deve ser a única fonte da moeda fictícia. Resgates devem atualizar saldo e inventário juntos, validar duplicidade/limites quando definidos e sobreviver a reinício do app.
- Não declarar paridade com base em menus, avisos de indisponibilidade, telas sem interação ou botões que apenas abrem um substituto textual.

## Base de análise e limites

- APK original: `assets/base.apk`, `assets/split_config.arm64_v8a.apk` e `assets/split_UnityDataAssetPack.apk`; o datapack contém cenas, sprites, áudio e metadados extraídos localmente.
- Análise estática disponível: dump Cpp2IL em `out/cpp2il/DiffableCs`, MonoBehaviours em `out/mb` e exportações de cenas em `out/scene-extract`. Os nomes de métodos e componentes abaixo vêm desses dados e da cena `level3` quando indicado.
- Isso não equivale ao código-fonte original. Dumps IL2CPP podem perder relações/runtime; o backend e os dados entregues dinamicamente não estão disponíveis. A inspeção REA/JADX não foi executada porque o provedor pede um JAR JADX headless 0.7.1 fornecido pelo chamador (`REA_JADX_MCP_JAR`); não foi baixado nem instalado.
- Preços/limites server-side e respostas de loja não foram inferidos. O catálogo extraído tem 37.230 entradas e 25.812 GUIDs únicos; os preços no dump local são zero e não representam preço real.

## Mapa de telas e controles da Home

| Controle original / evidência | Implementação local atual | Classificação e lacuna |
| --- | --- | --- |
| `PlayButton` → `Game.Home.HomePlayButton.LoadPlayScene()` (`level3`) | Abre `BasketballCourtRuntime`, quadra montada com assets de `level8`, avatar Spine salvo, arremesso e placar local | Interação jogável inicial, mas **não é** a cena principal original. Falta reconstruir seleção de mundos, movimento livre, colisão/sensores, interações e sequência original. |
| `ShopButton` → `Game.Store.StoreButton` | Sem compra real; loja offline ainda sem catálogo e política de preço aprovados | Pendente. Não declarar concluído nem mostrar aviso como substituto. |
| `AccountButton` → `PazuCore.AF.ActionBar.OpenForParentsButton` | Abre perfil/save local | Responde, mas não reproduz conta/cloud nem ações para responsáveis. Paridade pendente. |
| `AchievementsAppWidget` → `Game.Home.GameAchievementsButton` | Painel local lê desafios, moedas e pontos do save | Responde, mas o original abre experiência de conquistas dependente de serviços. Sem equivalência ainda. |
| `SettingsButton` → `Game.Home.HomeSettingsButton` | Preferências locais independentes para efeitos e música, persistidas em `PlayerPrefs` | Som funcional; faltam painéis/idiomas e demais opções do original. |
| `PWC.GameSFXMuteButton` / `PWC.GameMusicMuteButton` | Mutam separadamente SFX e música | Comportamento básico implementado; validar persistência e experiência de navegação completa. |
| `HomeManager._themeSoundName` em `level3` | Usa `On_The_Go_Splash_Screen_Loop`, asset `assets/audio_wav/AudioClip/On_The_Go_Splash_Screen_Loop_110563.wav` | Mapeamento estático confirmado; build atual usa esse arquivo. |
| `Game.World.HolidayGameModeButton` | Ainda não ligado a evento local | Pendente; requer conteúdo/regras do evento, não apenas um botão. |
| `Game.Store.StoreNewUserGiftCurrencyButton` | Sem resgate implementado | Pendente. Regra original server-side desconhecida; definir recompensa fictícia explicitamente antes de implementar. |
| `Game.Store.StoreAvatarPassButton`, `PWC.AvatarPassChange.AvatarPassChangeWidget` | Sem passe local | Pendente; exige trilha de recompensas e desbloqueios offline. |
| Botões/serviços multiplayer e `HomeUserMenu` | Desativados ou ausentes por dependerem de rede/conta | Não são funcionais offline. Recriar apenas se o fluxo puder ser definido localmente; não simular conectividade. |
| Entrada local “Meu avatar” | Abre runtime `Spine` e altera cabelo, camisa, calça, sapato e acessório com save compartilhado | Editor visual real baseado em assets reconstruídos; ainda precisa ampliar catálogo/combinações e validar ciclo integrado por reinício. |
| Entrada local “Desafio: ganhar moedas” | Abre questões pedagógicas aleatórias e credita moeda local | Opção separada de Play. Validar variedade, correção, saldo/inventário e persistência em ciclos completos. |

O dump `level3` contém 39 componentes `Button`; 35 permanecem sem uma ação local equivalente, muitos em diálogos ocultos, widgets de rede ou controles que ainda não foram mapeados. A lista `HomeActions.PendingButtons` é um inventário de trabalho, não prova de que todos esses 35 sejam controles visíveis ao usuário.

## Gameplay e aparência já prototipados

- Editor: esqueleto Spine do jogo original, renderer spine-unity, templates SUT de roupas, seleção persistida no `PlayerState`. A composição do avatar foi validada em GPU no Editor e em Android. Dados de referência e ciclos estão em `docs/AVATAR_GAMEPLAY_PLAN.md` e `docs/AVATAR_ASSET_FINDINGS.md`.
- Sala: `level8` foi inspecionada: 2.403 objetos, 58 SpriteRenderers, 18 PolygonCollider2D, incluindo `LevelBouncyBall`, `LevelBSBasketballItemHandler`, `LevelBasketballScoreBoard` e `BasketBallGate`. O cliente recria só uma fatia da quadra; não carrega nem executa os scripts originais.
- O placar observado em um teste ADB exibiu 9 depois de um único arraste que mostrou “Cesta!”. A regra/contador não está validada. Não apresentar esse resultado como implementação correta de pontuação.
- O editor, quiz e quadra usam estado compartilhado nas entradas implementadas, mas falta a validação integrada: editar avatar → jogar → obter moedas pelo desafio → reiniciar processo → confirmar avatar, moeda e progresso.

## Critérios para avançar cada fatia

1. Rastrear cena, hierarquia, componentes, dados, assets e fluxo de runtime do original; registrar quais partes são estáticas e quais dependem do servidor.
2. Implementar uma fatia jogável local com entrada, regra, feedback visual/sonoro e estado persistido; não considerar telas informativas como gameplay.
3. Cobrir lógica de estado com EditMode e validar fluxo/tamanho/touch no aparelho; salvar APK, logs, XML de testes e capturas da rodada.
4. Comparar resultado e hitboxes com a referência original. Corrigir controles cobertos, contador incoerente e warnings que contaminem o teste.
5. Atualizar este mapa com evidência, limites e próximo bloqueio. Só marcar paridade quando comportamento observável, conteúdo e estado estiverem reproduzidos na fatia declarada.

## Evidência desta rodada

- EditMode: **62/62 passed, 0 failed, 0 skipped** em `out/test-results-reconstruction-doc.xml`; log `out/unity-reconstruction-doc-tests.log`. A execução ocorreu com Unity fora do sandbox após o sandbox retornar erro de banco local somente leitura.
- APK gerada após o ajuste de raycast: `client/AvatarWorldClient/Builds/AvatarWorldOffline-dev.apk`, 90.071.775 bytes, SHA256 `38654fd85ff5eecadad9246f86b2a995fc10874e5dbcbeebd36b2b175334f6ff`; Unity reportou `build Succeeded` e `unzip -t` passou. A tentativa de instalar esta build falhou porque o Xiaomi desconectou do ADB; esta revisão **não** foi validada no aparelho.
- Home fria: `out/home-doc-reopened.png`. A entrada “Meu avatar” no centro inferior abriu o editor Spine na captura `out/home-doc-avatar-hit-test.png`; as cinco categorias são visíveis e o avatar está renderizado. Isso valida a entrada visual, não cobertura de todo catálogo.
- Toque `(2360,800)` abre o painel Progresso local (`out/home-doc-progress-open.png`), com saldo 50 e progresso 0. Isso é funcionalidade local, sem equivalência com o app de conquistas dependente de serviços do original.
- **Defeito reaberto:** tocar “Voltar à home” no painel Progresso não o fechou em duas tentativas. Foi ajustado `SetAsLastSibling()` para priorizar o botão de retorno sobre o `ScrollRect`; a APK atual contém a correção, mas falta reteste físico. O ADB agora lista zero dispositivos. Até validar, o retorno do modal permanece pendente.
- A build ainda mostra Development Console e erros repetidos de material/atlas para texturas de guarda-chuva não carregadas. O avatar renderiza; o ruído deve ser removido para uma validação/entrega limpa.
- Home sem os CTAs: não há captura da referência original nesta rodada para demonstrar comparação visual completa. O APK atual continua um cliente parcial, não uma cópia funcional completa.

## Pendências prioritárias

1. Executar testes Unity e reinstalar a build atual; validar Play/retorno, editor, Settings, perfil, Conquistas, CTA de moedas e a área tocável original sem sobreposição.
2. Corrigir/validar o contador de cesta e transformar a quadra de protótipo em movimento livre/interações de jogo observáveis.
3. Reproduzir a navegação e gameplay principal original por ambiente, seguindo o rastreio dos níveis e seus scripts; não tratar a quadra única como cópia do jogo.
4. Definir catálogo local de itens bloqueados e preços em moeda fictícia, inventário, desbloqueio atômico e recuperação de save; nenhum valor de compra real.
5. Completar desafios pedagógicos com banco aleatório, validação de respostas e concessão persistente de moedas, sem substituir Play.
6. Mapear e classificar os controles restantes; documentar equivalência ou limitação individual. Nunca contar avisos de indisponibilidade como implementação.
