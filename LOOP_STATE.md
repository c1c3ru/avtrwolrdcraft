# LOOP_STATE — Avatar World RE (uso pessoal, repo privado)

## Retomada em 2026-11-03
- Checkout sincronizado com `origin/main` (`33d592e`); avanços de 02/11 estavam publicados.
- Cache IL2CPP restaurado dos APKs locais, com hashes confirmados; 73 testes existentes e 2 novos testes do callback passaram em rodadas separadas.
- Callback `<LoadScene>b__0` mapeado estaticamente, incluindo literal Home, caminho local e chamadas multiplayer. Sem promoção de tarefas ou alteração do cliente.
- Evidências, limites e próximo passo: `docs/RECON_CALLBACK_2026-11-03.md`.

## Entrega da loja gráfica offline — 2026-11-02
- Concluída a substituição dos menus de texto de loja/presentes/passe por UI com sprites originais da level237, painel branco original e prévias renderizadas pelo Spine com os itens entregues. Organização/catálogo são adaptações offline, sem alegação de paridade completa.
- Regras próprias autorizadas pelo usuário: composições 15/20/25 moedas, presente inicial +25, diário +10 por UTC, passe 60 e prêmios +25 em 4/8/12 desafios. Resgates únicos, compra persistida, rollback em falha de save. Detalhes em docs/OFFLINE_HOME_RULES.md.
- Corrigidos ComingSoon sobre Avatar ID, GiftBadge sem ação própria, hitbox invisível de presente sobre Starter Pack, textos extrapolando botões e sobreposição do terceiro prêmio do passe.
- EditMode **72/72 passou** (`out/test-results-store-visual.xml`). Build final e instalação no Xiaomi concluídas. APK 106.089.488 bytes, SHA256 `97fe877acf804a63dd709c7c012dd7f41265fbeabd71377892744cfb05ce31a7`.
- Android: loja/comprar, presentes, passe/ativar, recusa de prêmio sem requisitos, retorno, abrir editor com aparência comprada e persistência após reinstalar/reabrir validados. Sequência real do saldo 50→35→70→10. Captura final `out/store-visual-device-final-pass.png` mostra os três prêmios separados.
- Relatório: docs/STORE_VISUAL_VALIDATION_2026-11-02.md. Objetivo geral continua aberto: catálogo limitado a três composições, gameplay protótipo, serviços online ausentes e materiais Spine não resolvidos ainda geram Development Console no editor/quadra.
- Preservadas alterações de outras frentes em README/.gitignore/planos/ferramentas de reconstrução. Nenhum commit ou push desta rodada.

## Retomada e validação — 2026-11-01
- Retomadas mudanças locais da Home: loading, painel Settings original e acesso às atividades locais pelos painéis de perfil/progresso.
- Corrigido bug no backdrop de Settings: o loop de botões pendentes desabilitava o Button criado para fechar o painel. Agora permanece interativo; teste de regressão incluído.
- EditMode: **63/63 passaram**, zero falhas/ignorados (`out/test-results-home-reference-resume.xml`). `git diff --check` passou.
- Build Android concluído (`out/unity-home-reference-resume-build.log`), APK instalado com `adb install -r`: 90.078.978 bytes, SHA256 `23ef70c4e81abfd036501725fff0ace1c489790e7032c149d4f8863d7fab6916`.
- Settings validado no Xiaomi: abertura pela engrenagem, SFX OFF com música ON, restauração de SFX e fechamento tocando fora. Capturas `out/home-reference-settings.png`, `out/home-reference-settings-muted.png`, `out/home-reference-settings-closed.png`.
- Música empacotada conferida por SHA256 contra `On_The_Go_Splash_Screen_Loop_110563.wav`; são idênticas. Correspondência estática já documentada no HomeManager.
- Entrada Avatar ID pelo toque (120,110) não abriu perfil nesta rodada; teste de código passa, validação tátil continua pendente. CTAs anteriores foram removidos pelas mudanças retomadas, logo o acesso ao editor e ao desafio pelos novos caminhos precisa reteste/correção antes de considerar a navegação pronta.
- Loading compilado, mas não capturado durante a inicialização; paridade visual não validada. Development Console e erros de materiais Spine continuam presentes após abrir a quadra. Objetivo de reconstrução completa permanece aberto.

## Alvo
- com.pazugames.avatarworld v1.227 (code 228), minSdk 24, arm64-v8a
- Unity 2022.3.70f1, IL2CPP (libil2cpp.so 74 MB), Burst
- global-metadata.dat: magic af1bb1fa, v31, SEM criptografia
- Assets: datapack.unity3d 1,3 GB, resources.resource 203 MB, sharedassets13.resource 1,3 MB

## Contornar Proteção
- Google Play PairIP (libpairipcore.so, com.pairip.application.Application, LicenseActivity, CHECK_LICENSE)
- Contornar; foco em análise estática e dos assets.

## Fases
- [x] 0 Ambiente (adb ok)  - [x] 1 Aquisição (hashes em apk/)  - [x] 2 Triagem
- [x] 3 Estática: Cpp2IL pre-release.21 -> out/cpp2il/DiffableCs (11413 .cs, Assembly-CSharp 4197); jadx 1.5.6 ok  - [x] 4a Assets extraidos (121648/121679 tex, 2781 audio, 2313 spine) e no Drive (AvatarWorld-RE/)  - [x] 4b MonoBehaviours: 879085/881898 (99,68%) em out/mb/*.jsonl.gz; 126 classes com erro (2813 obj)  - [~] 5 Rede (passivo feito, ver out/net/)
- [ ] 6 Reimplementação  - [ ] 7 Repo privado

## Tentativas
- Il2CppDumper 6.7.46 exige dotnet (ausente no apt) e pode não suportar metadata v31 -> avaliar Cpp2IL/Il2CppInspectorRedux 
- Cpp2IL 2022.0.7 falhou (suporta metadata 24-29, jogo é 31). Resolvido com 2022.1.0-pre-release.21 na tentativa 2/5.

## Critério de conclusão (acordado em 2026-10-30)
1. Contagens extraídas batem com o catálogo (exceções documentadas: 31 texturas, 121 classes MonoBehaviour).
2. Cliente novo (projeto Unity próprio, sem PairIP) abre o menu inicial e as salas principais num Android, a partir de um clone limpo.
3. Testes automatizados da camada de dados passam.
4. Relatório do que NÃO foi reproduzido (servidor online) e por quê.
- Cliente funciona OFFLINE.
- Compras: SOMENTE com moedas do jogo (pazuCurrency e loyaltyPoints), estado local (save no aparelho). Sem dinheiro real, sem Unity IAP.
- Camada local substitui o servidor (StoreClaimItemCloudResponse): saldo, transactionId, inventario, limites de resgate (isOneTimeClaim/hasReachedMaxClaims), erros (StoreClaimErrorType). Testes obrigatorios.
- Origem das moedas: padrao = jogabilidade como no original + saldo inicial pequeno configuravel (decisao do usuario pendente; pode mudar).

- mb_dump: 2 falhas (exit 1 sem traceback, provavel pressao de memoria/ambiente) na tentativa 3/5 passou, 9 GB de RAM de pico; nao rodar em paralelo com upload.
- Upload Drive: arquivos soltos (82 KiB/s) -> trocado por 3 tar/zst; verificado por MD5.

## Loja e rede (2026-10-30)
- store_catalog.json: 37230 entradas PDPrefab, 25812 GUIDs unicos (deduplicar por guid). Precos = 0 (a definir); precos reais pertencem ao servidor.
- Rede (passivo, /proc/net/tcp do uid 10258, 15 amostras): tudo em 443/TLS.
  3.234.189.197 (AWS EC2 us-east-1, conexao persistente, 43/60 amostras) = provavel backend/websocket (o app tem unity-websocket-sharp);
  34.107.172.168 (Google Cloud), 172.217.115.4 (Google), 108.139.119.9 (CloudFront/CDN).
  Nomes de dominio/SNI NAO observados; conteudo NAO inspecionado (TLS). Interceptar HTTPS fica fora de escopo.

## Unity / Spine (2026-10-30)
- Projeto: client/AvatarWorldClient (Unity 6000.6.6f1, template universal-2d). Modulo Android instalado.
- spine-csharp 4.2 via git; spine-unity 4.2.121 embutido em Packages/ e PATCHADO (codigo de terceiros):
  1) Runtime/.../SkeletonMecanim.cs: GetInstanceID() -> comparacao direta (obsoleto como ERRO no Unity 6.6).
  2) pasta Editor/ REMOVIDA (60 erros CS0619 pelas mesmas APIs). Sem inspetores/importer do Spine no editor;
     SkeletonData e carregado em runtime a partir de .skel/.atlas (TextAsset). Reavaliar se precisar do importer.

## Descoberta importante: path_id NAO e unico (2026-10-30)
- datapack.unity3d tem 507 arquivos serializados: resources.assets (1,2M objs) + ~252 levelNN (cenas reais). path_id colide em ~1M objetos.
- Toda chave deve ser (assets_file.name, path_id). PPtr com m_FileID 0 = mesmo arquivo.
- PENDENTE (corrigir): (a) store_catalog.json usou so path_id -> nomes podem estar trocados; reconstruir.
  (b) out/mb/*.jsonl.gz sem campo de arquivo -> re-dump com "_file" (mb_dump.py).
- level3 = HOME (menu inicial): PlayButton, ShopButton, AccountButton, HomeManager; 708 objs (77 Image, 39 Button, 9 TMP). Primeira fatia do cliente.
- Cenas jogaveis: raiz "LevelCanvas" (342 transforms), ex.: level8, level99, level102, level200.

## Estado em 2026-10-30 (antes de desligamento)
- Codigo escrito (compila contra DLLs do Unity 6.6; testes NUnit AINDA NAO RODARAM no editor):
  Core/Economy (LocalStoreService + 11 checagens fora do Unity OK), Runtime (UiSceneBuilder, HomeBootstrap, SaveStore), 26 testes.
- tools/export_level.py escrito, NAO executado (depende de out/mb_v2 valido).
- BUG proprio (corrigido): comentario no meio da linha em mb_dump.py engoliu a gravacao -> primeira out/mb_v2 saiu vazia (46 bytes/arquivo).
  Licao: teste curto (limite 2) e conferir arquivos antes de rodar a extracao longa. Script agora aborta se gravados != ok.
- PENDENTE: out/mb_v2 valido -> trocar out/mb -> export_level.py level3 -> rodar testes no Unity -> refazer store_catalog.json (chave arquivo+path_id).
- store_catalog.json ATUAL e INVALIDO (nomes por path_id colidido).

## Resultado (2026-10-30, apos desligamento agendado)
- out/mb REFEITO e validado lendo do disco: 879085 linhas, todas com _file, 0 JSON invalido, contagens iguais as antigas.
- store_catalog.json REFEITO com chave (arquivo, path_id): 7892 de 37230 nomes do catalogo antigo estavam errados.
- level3 exportado: 149 nos, 57 sprites, 0 ausentes -> Assets/Resources/HomeSlice.
- Testes Unity EditMode (batch, JUnit em out/test-results.xml): 27 testes, 0 falhas, 0 erros.
- Ainda NAO verificado: a tela Home renderizada (Play Mode / build Android). Layout AFC*/PositionPerScreen nao reproduzido.

## Build Android (2026-10-30 16:55)
- BuildPipeline: Succeeded. APK dev em client/AvatarWorldClient/Builds/AvatarWorldOffline-dev.apk (43,7 MB, ignorado no git).
- Pacote com.c1c3ru.avatarworldoffline (IL2CPP, ARM64, minSdk 24). NAO instalado: celular sem conexao ADB no momento.
- Proximo: adb install -r + abrir; verificar a Home renderizada (nunca vista). Rebuild: unity run ... -executeMethod AvatarWorld.EditorTools.ProjectSetup.BuildAndroidDevelopment

## Sessao 2026-10-31 (ambiente novo, sem Unity Editor nem device)
- Ambiente de execucao atual NAO tem Unity Editor instalado (so achei o `unity` do desktop GNOME,
  irrelevante) e `adb devices` retorna lista vazia -> build/instalacao/verificacao visual (criterio 2)
  continuam BLOQUEADOS aqui; precisam rodar num ambiente com Unity Hub+Editor 6000.6.6f1 e/ou um
  Android conectado. O APK dev de 2026-10-30 nao esta neste checkout (Builds/ e gitignored).
- apk/ tem so base.apk (28,9 MB); sem lib/, sem libil2cpp.so/libpairipcore.so (vivem no split
  ABI-specific, nao baixado neste ambiente). assets/ so tem SHA256SUMS.txt (tars reais ficam no Drive).
- Verificado com REA (inspect_android_package/JADX) o manifest do base.apk original: confirma
  com.pairip.application.Application, LicenseActivity, CHECK_LICENSE, extractNativeLibs=true,
  requiredSplitTypes=base__abi, Play Billing 8.0.0 (dinheiro real, nao reproduzido por decisao).
  Evidence: ev_cfb37074585b813a2225b3cf70e4a94f8ba20ed1d98bc3ab04d7fbe180ae4e22.
- Conferido o StoreClaimItemCloudResponse.cs decompilado contra LocalStoreService/StoreItem da
  reimplementacao: achado MaxClaims (int) e o enum ClaimError sao INVENCOES (o binario so expoe o
  booleano hasReachedMaxClaims; o enum original so tem erros de guid/prefab, nao economicos).
- Criterio #4 (relatorio do que nao foi reproduzido) ESCRITO: ver NOT_REPRODUCED.md (backend online,
  precos/limites server-side, IAP real, PairIP, assets nao trazidos, Home nao vista).
- ACHADO (nao resolvido, usuario pediu para nao agir agora): repo GitHub c1c3ru/avtrwolrdcraft esta
  PUBLICO; README diz "privado". store_catalog.json e os PNGs extraidos em
  Assets/Resources/HomeSlice/sprites/ estao versionados e visiveis publicamente.
- PENDENTE real: (a) ambiente com Unity Editor para rebuild, (b) device ADB para instalar e ver a
  Home renderizada, (c) decidir visibilidade do repo.

## Sessao 2026-10-31 (continuacao) - Home verificada e funcional pela primeira vez
- Unity CLI + Editor 6000.6.6f1 + modulo Android instalados neste ambiente (~/.local/bin/unity,
  ~/Unity/Hub/Editor/6000.6.6f1). Licenca Personal ativada.
- Celular conectado via ADB (Xiaomi M2101K7BI) apos autorizar USB debugging (tela desbloqueada e
  necessaria para o prompt aparecer).
- Bugs encontrados e corrigidos, em ordem:
  1. Build batch falhava achando NDK: AndroidExternalToolsSettings apontado manualmente pro SDK/NDK/
     JDK do proprio Editor (deteccao "Installed with Unity" falha em modulos instalados depois do
     Editor via `unity install-modules`).
  2. TMP Essential Resources nunca foi importado -> NullReferenceException em todo TextMeshProUGUI.
     Corrigido extraindo o .unitypackage manualmente (ImportPackage async nao completa em batch).
  3. UI_BTTN_Logout (unico no com hasButton+hasText no mesmo objeto, sem imagem) gerava 2 Graphic
     conflitantes (Image + TMP) -> NullReferenceException que abortava o Build() inteiro, deixando
     dialogos active=false presos visiveis. Corrigido: so adiciona alvo de raycast invisivel quando
     o no NAO tem texto; Build() agora contem excecao por no em vez de abortar tudo.
  4. Clique nao registrava em NENHUM botao: causa real era AreaYouSureBubble/LeaveGameYesButton/
     LeaveGameNoButton (dialogo "sair do multiplayer?") ativos e centralizados por cima do PlayButton
     na hierarquia exportada - visibilidade de dialogos de multiplayer e controlada por script no
     original, nao pelo "active" estatico exportado. Corrigido desativando MultiplayerCanvas inteiro
     (fora de escopo deste cliente offline).
  5. Orientacao travada em paisagem (userLandscape, como o manifest original).
  6. Sem AudioListener na cena -> nenhum som tocava. Audios de UI (click/correct/wrong/coin) tinham
     preloadAudioData=0 e 3D=1 (herdado do import default) -> corrigido para preload=1, 3D=0, e
     AudioSource.spatialBlend=0 explicito no codigo (fallback se o import nao bastar).
- PARALELO: usuario tambem usou ChatGPT (GPT-6 Astra) no mesmo repo/GitHub pro mesmo sintoma (fundo
  atras dos controles). Resultado: branch `fix/home-background-layering` (HomeLayout.cs), baseada no
  commit b3bd9a33 (sem nenhum dos fixes acima). Mesclada manualmente por cima do meu estado: usa o
  CanvasBackground real (root canvas separado do Canvas principal, index 145 em level3.json, com
  GraphicRaycaster/CanvasScaler explicitamente omitidos no original - dado real, nao inventado) para
  por o fundo atras (sortingOrder -1) e desabilitar seu raycaster; AspectRatioFitter.EnvelopeParent
  pro fundo cobrir sem distorcer (diverge do _effectType=XY/keepAspectRatio=0 real que eu tinha achado
  em ScreenScripts.FitToScreen - EnvelopeParent preserva proporcao, o original nao preservava. Reavaliar
  qual comportamento manter). Scaler fixo em 2048x1024 + ScreenMatchMode.Expand, substitui minha curva
  dinamica baseada no AFCCanvasScalerRangeToScreen real.
- RESULTADO (testado no device, com os dois fixes juntos): fundo preenche a tela, TODOS os icones/
  botoes (Play, Shop, corações, conta, PAW PASS, Starter Pack, etc.) visiveis e no lugar certo pela
  primeira vez. PlayButton clicavel -> abre a tela de desafio de alfabetizacao (Core/Literacy, criada
  nesta sessao). Resposta certa paga moeda (saldo persiste entre sessoes via SaveStore), avanca fila,
  som toca sem aviso de "clipe nao encontrado". Zero excecoes no logcat.
- PENDENTE: reconciliar com a branch do ChatGPT no GitHub antes de decidir o que vai pra main (os dois
  fixes do fundo divergem em fidelidade ao original - ver acima); criterio de conclusao #2 (Home
  renderizada, nunca vista antes) agora atingido na pratica, falta formalizar.
- Usuario decidiu manter a abordagem do ChatGPT (AspectRatioFitter.EnvelopeParent) como definitiva;
  removida minha regra especial de FitToScreen em UiSceneBuilder.cs (agora redundante).
- Desafio pedagogico: usuario reportou loop sem fim (fila circular reiniciava sem avisar, sem saida).
  Corrigido: botao "X" sempre visivel em toda tela de desafio (fecha a qualquer momento), tela de
  conclusao ao terminar uma volta completa na fila ("Parabens! Voce respondeu tudo!" + moedas ganhas
  na sessao + "Jogar de novo"/"X"), em vez de reiniciar direto e silenciosamente.
- Animacao de moeda: usuario pediu reaproveitar a animacao propria do jogo. Nao achamos uma animacao
  Spine/sprite-sheet dedicada nos dados extraidos; usamos o icone estatico real (Currency_Coin,
  assets/textures_png/Texture2D/Currency_Coin_85317.png, 41x27) com uma animacao propria simples
  (pop de escala + voo ate o contador + fade, CoinFx.cs) - testada no device, visivel voando ate
  "Moedas: N" ao acertar.
- Som/musica: UiSound.PlayClick ja estava em TODO botao (Home inteira + desafios) desde antes.
  Adicionado BackgroundMusic.cs (loop, nao reinicia se ja tocando) com musica da Home. Sem confirmacao
  do clipe original exato (so o botao de mute foi achado no MonoBehaviour dump, nao o AudioClip
  referenciado); escolhida Vacation_Theme_Loop por tema (combina com o banner "ON THE ROAD" da Home),
  documentado como escolha por conteudo, nao mapeamento confirmado. Usuario confirmou ouvindo no
  aparelho: musica e efeitos tocando de verdade.
- PENDENTE: musica/som por tela alem da Home (so existem 2 "telas" ainda - Home e desafios - desafios
  herdam a musica da Home por enquanto, tocando por baixo); commit+push desta rodada ainda nao feito.

## Continuação da Home — 2026-10-31 (Codex)
- Revisado PR #1 do origin `c1c3ru/avtrwolrdcraft` (URL com `avtrworldcraft` retorna 404), head f1af061d; não aplicado integralmente porque sua base anterior perderia o Play/desafios atuais e manteria saldo separado no perfil.
- Inspecionados assets fora do Git (121647 texturas/arquivos, 2781 áudios, 2313 arquivos Spine) e cenas, inclusive worktree antiga ignorada. Não há salas jogáveis do cliente além de Home/SampleScene/template; ter assets brutos não equivale a ter uma sala implementada.
- HomeActions adaptado do PR: Play chama desafios existentes; conta salva o MESMO PlayerState dos desafios; configurações oferecem mute global persistente; conquistas consulta progresso local. Mantidos fundo, TMP, clique, sons, moedas e conclusão dos desafios locais.
- 35 dos 39 Button exportados continuam pendentes e desabilitados (incluem controles internos ocultos). Não contamos aviso de indisponibilidade como funcionalidade. Loja não está concluída: catálogo existe no disco, mas faltam interface, preços/configuração e integração dos resgates com os itens.
- Unity 6000.6.6f1 EditMode executado: 47/47 passaram, zero falhas/ignorados, incluindo 5 testes novos de integração e preservação do saldo. XML em out/test-results-home.xml; log em out/unity_home_tests.log (ignorados no Git).
- Relatório detalhado de revisão, limites e validação: docs/HOME_VALIDATION_2026-10-31.md.
- APK gerado: Builds/AvatarWorldOffline-dev.apk, 59.473.626 bytes, SHA256 a682e936fb4f59e0c68864feeaf952efa65047a896539a3495f5ba63e3b14b08; build/CLI concluídos com sucesso. Instalado com -r no Xiaomi M2101K7BI (API33), mantendo dados. Home, configurações/mute persistente, Voltar, conta/salvar (55 moedas preservadas), Play/X e progresso local validados com toques ADB + screenshots.
- Log do aparelho registra ClassNotFoundException de AssetPackManager na inicialização, sem impedir os fluxos verificados. Pendente investigar; não é execução sem exceções. Runtime reporta min API26 apesar da configuração solicitada API24.
- Alterações simultâneas posteriores em LiteracyChallengeScreen.cs e quiz_panel.png/.meta foram preservadas e não pertencem ao commit desta correção nem à validação do assembly compilado antes delas. Detalhes/timestamps no relatório.

## Novo objetivo — gameplay visual de avatares (2026-10-31)
- Solicitação do usuário: plano de ação e execução em loop para montar os visuais dos avatares e chegar ao jogo, além dos menus textuais.
- Plano persistente em docs/AVATAR_GAMEPLAY_PLAN.md: ciclos 0 inventário → 1 avatar renderizado → 2 personalização visual → 3 persistência → 4 Home → 5 primeira sala interativa → 6 APK e regressões.
- Critério do marco: Home → editor visual → troca real de cabelo/roupa/acessório → salvar → reabrir com mesma aparência → avatar numa sala com interação. Avisos, placeholders e testes só de dados não concluem o objetivo.
- Estado inicial observado: e837dd7b (já inclui a publicação paralela das mudanças de quiz); diretório de trabalho sem diferenças antes deste novo ciclo.
- Ciclo 0 EM INVESTIGAÇÃO: arquivos locais Avatar_Spine.skel_108595.txt (binário com versão 4.2.43), Avatar_Spine.atlas_109005.txt e PremadeCharactersJson_109356.txt (896 presets com CategoryType/SkinName/cores). São evidências estáticas, ainda não prova de um avatar renderizado.
- Hipótese: compor skins reais por categoria usando runtime Spine 4.2 existente, com seleção mínima de páginas para evitar carregar todas as texturas. Probe de leitura no Unity criado em Assets/Editor/AvatarAssetProbe.cs; resultado deve confirmar dependências reais antes do empacotamento.
- Ciclo 0: probe executado com Unity 6000.6.6f1, exit 0. Binário lido como Spine 4.2.43, 1419 bones, 429 slots, 2120 skins, 2172 páginas, 3479 animações. Inventário em out/avatar-spine-inventory.json, resumo em docs/AVATAR_ASSET_FINDINGS.md.
- Primeira tentativa do probe falhou em compilação porque Atlas não implementa IDisposable; removido o using do Atlas, mantido o dispose do FileStream. Segunda tentativa passou. Isso valida leitura/compatibilidade, não renderização.
- Hipótese de presets inteiros componíveis apenas por FindSkin REFUTADA: 7539/12770 referências de skins dos 827 presets Character não existem diretamente no SkeletonData. Evidências apontam para templates e sistema SUT/material externo. Próxima tentativa visual limitada ao conjunto com referências únicas; roupas exigem rastreio do bundle.
- Rastreio SUT, tentativa 1: UnityPy.load do bundle inteiro saiu 137 sob pressão de memória (não repetido). Mudança de hipótese operacional: extrair somente resources.assets por blocos UnityFS, sem juntar todo o conteúdo descomprimido em RAM. Parser limitado verificou UnityFS v8/2022.3.70f1, 737 entradas; resources.assets tem 327041532 bytes. Inventário do diretório em out/assets/avatar-bundle-directory.json.
- Solicitação adicional do usuário: automatizar o trabalho possível com scripts Python que ele possa executar. Pipeline em preparação: doctor → inventário SUT → probes opcionais Unity → auditoria → pacote mínimo → relatório/estado retomável. Não executa compras, não sobrescreve assets fonte e não declara gameplay pronto.
- Rastreio SUT corrigido: ResourceManager está em globalgamemanagers dentro de assets/base.apk/data.unity3d. Encontradas 48200 referências / 24100 paths únicos Character, todas apontando resources.assets. O inventário agora lê só esse bundle base pequeno por padrão; extrair o bundle pesado/resources.assets virou opção explícita.
- Auditoria Python real executada: 2172 páginas, 901 com candidato único e 1271 com múltiplos candidatos por nome/dimensões, zero páginas sem candidato. Esta contagem de candidatos inclui arquivos idênticos; não contradiz as 1269 páginas com pixels distintos do levantamento anterior. Ambiguidade não é resolvida escolhendo o primeiro arquivo.
- Probe de referência visual executado no Unity com exit0: corpo/rosto/short padrão e duas opções de cabelo, 40 slots, 1363 triângulos somados, zero páginas visíveis ausentes. Corrigidos FlipV (evidência no runtime local SpineAtlasAsset) e camada complementar Eyes/1_Color-p. Imagens em out/avatar-preview*.png. É rasterização CPU das geometrias Spine, não gameplay/GPU/Android nem roupas aplicadas.

## Automação e retomada — verificação 2026-10-31
- Usuário pediu reduzir repetição manual e automatizar as verificações possíveis. Conferi `tools/avatar_pipeline.py`, `avatar_audit.py`, `avatar_bundle_inventory.py`, `avatar_package.py` e `docs/AVATAR_AUTOMATION.md`.
- `doctor`/`report` verificados com `tools/venv/bin/python`: entradas completas, UnityPy disponível, probes prontos (licença/execução do Unity não verificada por esses comandos). Inventário SUT e resultados CPU/GPU existentes são reutilizáveis.
- Teste do empacotador com 7 itens reais achou incompatibilidade de path: o CLI tomava `Category/ID` como um único nível, mas SUT organiza `shirt/shirt_formal/shirt_formal_1` e `accessories/accessories_face/accessories_face_glasses/accessories_face_glasses_1`. Corrigido o prefixo hierárquico. Validação real: 7 itens, 22 PNGs, `resolved-static`, 0 dependências pendentes; manifesto em `out/avatar-package-check/manifest.json`. Isso valida só o pacote estático, não a imagem nem o gameplay.
- A instrução de automação agora documenta um comando de pacote com categorias reais. Resultados de verificação isolados ficam ignorados pelo Git.
- Confirmado `main` igual a `origin/main` no commit `71aa0122`; logo após o ciclo 2 começaram alterações locais não commitadas em PlayerState, SaveStore e `Core/Avatar/` para o ciclo 3 (persistência). Preservadas, ainda não auditadas nem validadas nesta verificação.

## Retomada após ciclos 1–3 — 2026-10-31
- Usuário confirmou prioridade do produto: o desafio de alfabetização serve para ganhar moedas e é secundário; o botão principal Play deve iniciar a experiência principal nos ambientes, nunca substituir o jogo pelo quiz.
- Causa da navegação atual: `HomeActions.Initialize` só liga Play, Settings, Account e Achievements; os demais 35 botões são desabilitados. `PlayButton` está ligado a `OpenLiteracyChallenges`, por isso entra no quiz.
- Limite encontrado: o projeto cliente tem Home, cena de validação do avatar e templates; os assets/dumps das salas originais ainda não viraram cenas de jogo. “Ligar” um botão a uma cena não implementada não fornece gameplay.
- Ciclo 4 em implementação: entrada “Meu avatar” adicionada à Home; injeta `SaveStore` e `PlayerState` existentes em `AvatarGpuRuntime`; botão de retorno restaura canvases. EditMode 62/62 passou.
- ADB confirmou dispositivo online. A captura da Home mostra a entrada. Várias tentativas de toque não mostraram o avatar nem o log `Home: abrindo editor visual do avatar`; o fallback de toque por posição e o sortingOrder 500 foram incluídos, mas a validação tátil continua pendente.
- APK rebuildado e instalado: `Builds/AvatarWorldOffline-dev.apk`, 62.132.105 bytes, SHA256 11265444b7054f16bba03066e043668023878e0e5d36f1c85c36784c924d0ade. Build Unity: `ProjectSetup: build Succeeded`.
- Próximo ciclo deve corrigir validação/recebimento do toque e expor o editor pela Home; em paralelo preparar a primeira sala com assets existentes, avatar persistido, movimento por toque/arraste e interação concreta. A atividade de moedas deve ter entrada própria. Não contar menu textual nem aviso como jogo.
- Rastreio da sala principal: `tools/unityfs_extract_entry.py level8` extraiu só o serialized file de 290028 bytes do datapack UnityFS v8, em vez de carregar o bundle de 1,33 GB. `scene_level_inspect.py` encontrou a quadra Basketball (2403 objetos, 58 SpriteRenderers, 18 PolygonCollider2D e componentes reais `LevelBouncyBall`, `LevelBSBasketballItemHandler`, `LevelBasketballScoreBoard`, `BasketBallGate`); `scene_level_export.py` decodificou 54 sprites via referências `(arquivo, path_id)` incluindo `resources.assets.resS` por symlink local. Relatório `out/scene-extract/level8-report.json`, imagens `out/scene-extract/level8-sprites/`. Isso prova que a fonte original contém os recursos e sistemas da sala; ainda não a torna uma cena carregável no cliente nem prova gameplay reimplementado.

## Ciclo 5 — fluxo Play e primeira interação de sala (2026-10-31)
- Ajustada a arquitetura do HomeBootstrap: callback principal passa a criar a quadra; callback separado preserva a alfabetização como atividade opcional para moedas. Botão visível “Desafio: ganhar moedas” dedicado; `PlayButton` não chama mais `OpenLiteracyChallenges`.
- Criado `BasketballCourtRuntime`: usa o fundo da quadra e sprites exatos da extração de level8; incorpora avatar Spine configurado com o mesmo save/estado; arrastar a bola para cima cria arremesso e atualiza placar local; retorno salva e volta à Home. O protótipo não remunera moedas.
- Assets usados e incluídos no cliente: `Assets/Resources/BasketballCourt/{BG_01,Hoop,Ball}.png` com metadados. Sem levar os 54 sprites exportados ou o bundle de origem inteiro para o APK.
- Fallback de entrada ampliado para `Touchscreen` e `Pointer` do Input System e API legada na Home; input direto também na quadra. A exportação level3 traz seu próprio `EventSystem`/`StandaloneInputModule`; o bootstrap agora consolida os EventSystems depois de materializar a Home e configura um único `InputSystemUIInputModule`. Capturas após a correção ainda mostram Home depois de `adb input tap` e swipe de 250 ms na posição de Play. Viewport lógica do Android conferida em 2400×1080; log filtrado não confirma toque recebido. Captura `out/home-validation.png` valida a renderização da Home e das duas entradas, não o funcionamento tátil.
- EditMode executado após alteração do fallback: **62 passed / 0 failed / 0 skipped**, `out/test-results-avatar-gameplay-slice.xml`, `out/unity-avatar-gameplay-slice-tests.log`.
- Build Unity Android final: `ProjectSetup: build Succeeded`; APK instalado com `adb install -r`: 90.070.255 bytes, SHA256 `3f38848911a6603ff82406a96237114704054d844fc4464aa8c2d177b50ef079`. O APK inclui a consolidação do EventSystem e o fallback `Pointer.current`. Ainda não há captura da quadra porque o botão não responde ao input ADB.
- Pendências do ciclo: reproduzir/diagnosticar o toque com input físico ou telemetria de `Touchscreen` no Android; observar a quadra, avatar, pontuação e retorno; validar editor visual no mesmo APK. Pendências do objetivo maior: movimento de avatar, mais ambientes e colisão/sensor de cesta; revalidar o ciclo completo e só depois finalizar `/goal`.

## Correção após novo teste no aparelho — 2026-11-01
- Reteste após relato de botões inativos apontou callbacks duplicados (EventSystem mais fallback manual InputSystem/legacy) e Canvas da Home mantidos sobre a quadra. Removido fallback manual, mantido um EventSystem e ocultados/restaurados os Canvas da Home para editor, desafio e gameplay.
- EditMode: 62/62 passed, 0 failed, 0 skipped (`out/test-results-avatar-gameplay-slice.xml`); `git diff --check` sem erros.
- APK regenerado e instalado no Xiaomi M2101K7BI/API 33: 90.070.438 bytes, SHA256 `d005e153f6ad4890b9cea7e89ce5b4b3a1069763ea5780765b2de5293833b1fb`; `unzip -t` sem erro.
- Play abriu quadra com avatar salvo, bola, cestas e placar; retorno restaurou Home (`out/avatar-final-play.png`, `out/avatar-final-return.png`). CTA de moedas abriu quiz sem Progress duplicado (`out/avatar-final-coins.png`); Configurações abriu (`out/avatar-final-settings.png`); Meu avatar abriu editor e toque alterou visualmente (`out/avatar-final-editor*.png`). Arraste da bola exibiu “Cesta!” (`out/avatar-final-shot.png`), mas placar apareceu 9 após uma tacada iniciada em 0; regra do contador precisa de investigação.
- Pendente: validar cada controle/categoria individualmente e persistência integrada após reabrir; remover Development Console da build de entrega; resolver avisos de materiais de guarda-chuva; implementar movimento e detecção física de cesta. Objetivo geral não concluído; sem commit/push.

## Correção da faixa da Home — 2026-11-01
- O usuário apontou que a música tocada na Home pertencia a outro cenário. Confirmado: o recurso `home_music.wav` era idêntico a `Vacation_Theme_Loop_111886.wav` (SHA256 `5d1022695bcede171a628076ea1da55d952bd467c5024f1ebc64646edc40ab26`; tamanho 5.292.046 bytes), seleção temática anterior sem vínculo de cena comprovado.
- Substituído por `assets/audio_wav/AudioClip/Main_Theme_Loop_112599.wav` (SHA256 `eb174afcbf7038e0efe1591f998c0c3d27bbd8119d26bcbd03db452ccf42dbb2`; 3.763.246 bytes), preservando o GUID/import settings de `Resources/Audio/home_music.wav`. É a faixa geral mais coerente com a tela principal; dump de MonoBehaviour não serializa o clip e portanto vínculo exato ainda precisa de audição/validação do usuário.
- Rebuild/instalação concluídos: APK `AvatarWorldOffline-dev.apk`, 90.070.438 bytes, SHA256 `95ce751d70b00f1bb44acda03fc184566f0391b4d1a0362b69c5c13c6fe31c87`; `unzip -t` sem erro; `adb install -r` e inicialização no Xiaomi concluídos. EditMode não foi repetido porque a mudança foi apenas o arquivo de áudio/import resource e a rodada 62/62 já estava verde.

## Ativação incremental dos botões Home — 2026-11-01
- Ações reais já conectadas: Play→quadra principal; CTA “Desafio: ganhar moedas”→alfabetização opcional; “Meu avatar”→editor Spine; Settings→preferências; Account→perfil/save local; Achievements→progresso local. Não são destinos equivalentes nem avisos.
- Ativado novo par de controles nas Configurações: efeitos UI e música independentes, cada um persistido em PlayerPrefs. Migração lê `home.sound.enabled` legado quando as novas chaves ainda não existem. `UiSound` muta seu AudioSource e `BackgroundMusic` muta apenas a fonte da música, sem pausar `AudioListener` inteiro.
- EditMode após mudança: 62/62 passou. Teste confirma muting independente dos dois AudioSources e estados persistidos. XML `out/test-results-home-button-audio.xml`, log `out/unity-home-button-audio-tests.log`.
- Device Xiaomi M2101K7BI/API33: controle de efeitos foi desligado mantendo música ligada; depois música desligada; ambos reativados. Capturas `out/home-settings-audio.png`, `out/home-settings-sfx-muted.png`, `out/home-settings-both-muted.png`, `out/home-settings-audio-restored.png`.
- APK atualizado instalado, 90.072.488 bytes, SHA256 `5a938da78bea68dfa235d7e4db2b208bcfa8aa669e4b4d5ac89a98ead369fbe2`; build Unity e `unzip -t` passaram.
- Próximos botões visíveis sem funcionalidade local correspondente: `ShopButton`, `HolidayButton`, `NewUserGiftCurrency`, `AvatarPassButton`/`AvatarPassButton_Small`, `AvatarPassChangeWidget`, `ComingSoonButton` e Multiplayer. Loja não recebe preço zero inventado (os preços reais dependem de servidor; catálogo local tem preços indefinidos); gift/pass precisam de regras/recompensas locais; multiplayer exige serviço ausente. Não os conectei a destinos de nome diferente. Parte dos 35 pendentes são controles internos ocultos de login, rede e diálogo.

## Reteste no aparelho e paridade com o jogo original — 2026-11-01
- ADB no Xiaomi M2101K7BI, resolução física 1080x2400 (jogo em paisagem); cold launch abre Home. Toque Play abriu a quadra e o desafio opcional abriu pergunta/alternativas; fechar desafio retornou à Home. Capturas `out/home-device-test-start.png`, `out/home-device-play.png`, `out/home-device-coins.png`, `out/home-device-after-coins.png`.
- Ressalva do usuário confirmada: responsividade tátil e equivalência com o jogo original são critérios distintos. A quadra de basquete e o quiz opcional são protótipos locais — a Home original `HomePlayButton.LoadPlayScene()` abre o fluxo principal original de cenários, não a nossa quadra de protótipo. `GameAchievementsButton` usa servidor/hunts do jogo original; o painel local de progresso não é equivalente. Perfil local também não replica a conta/cloud.
- Referência exata da música encontrada em `out/mb/Game.Home.HomeManager.jsonl.gz`: cena `level3` tem `_themeSoundName = On_The_Go_Splash_Screen_Loop`; `PazuCore.AudioClipPaths` mapeia nome para `Sound/Music/On_The_Go_Splash_Screen_Loop`, arquivo fonte `assets/audio_wav/AudioClip/On_The_Go_Splash_Screen_Loop_110563.wav`. Substituído `home_music.wav` pelo arquivo fonte, SHA256 `4a5ec3fa504efa92fc6afc19fff812009107b1a6d8cae4666a81003a8d093f9d`, 4.503.332 bytes. O APK atual no aparelho ainda não contém essa troca; rebuild pendente.

## Plano autônomo por agentes + checagem de raycast — 2026-11-01
- Documento novo `docs/AI_AGENT_REVERSE_ENGINEERING_WORKPLAN.md`: backlog detalhado, trilhas delegáveis, dependências, outputs estruturados, evidências/classes de confiança, gates de teste e proposta de orquestrador incremental com cache SHA256. Meta de 100% limitada à cobertura auditável dos artefatos/comportamentos observáveis; limites dinâmicos do backend viram regras offline explícitas ou divergências documentadas.
- Documento novo `docs/OFFLINE_RECONSTRUCTION_STATUS.md`: matriz controle a controle diferenciando resposta local de equivalência ao original, com evidências, limites e pendências do produto offline completo.
- Mudança de layout das entradas “Desafio” e “Meu avatar” para centro inferior: EditMode **62/62 passed** (`out/test-results-reconstruction-doc.xml`). APK de desenvolvimento anterior ao último ajuste de raycast foi gerada e instalada, 90.072.488 bytes, SHA256 `c18865278e18f8d5eb8c825314131020cd58baebca94c83bb08d66e044ca983e`, `unzip -t` passou.
- No aparelho, Home fria capturada (`out/home-doc-reopened.png`); a nova posição de “Meu avatar” abriu o editor Spine (`out/home-doc-avatar-hit-test.png`). Tap `(2360,800)` abriu painel de progresso local (`out/home-doc-progress-open.png`), mas tocar “Voltar à home” não fechou o painel em dois retestes (`out/home-doc-progress-close-retest.png`). Ajuste de ordem com `SetAsLastSibling()` foi aplicado e precisa rebuild/reteste.
- Development Console ainda exibe mensagens de materiais/atlas não carregados para peças de guarda-chuva. Clone offline e paridade do Play, loja, conta e conquistas continuam pendentes.
- Após aplicar o ajuste de raycast, EditMode passou novamente (**62/62**) e Unity gerou APK de 90.071.775 bytes, SHA256 `38654fd85ff5eecadad9246f86b2a995fc10874e5dbcbeebd36b2b175334f6ff`; `unzip -t` passou. O Xiaomi desconectou antes da instalação; `adb devices -l` lista zero dispositivos. O reteste do botão de retorno permanece pendente e não foi declarado concluído.

## Home → Play no original (observação em aparelho) — 2026-11-03
- Xiaomi M2101K7BI, original 1.227 (versionCode 228). Cold launch → Home; toque em Play (1872,528 em 2400×1080) → tela de carregamento (fundo amarelo, avatar com gato, relógio) → mapa do mundo (cidade com prédios em obras, voltar, clima, globo/viagem, adicionar avatar, editar casa, Pacote Inicial, loja). Capturas e SHA256 em `out/recon/tasks/T025/DEVICE/`.
- Compatível com o contrato estático de `tools/recon_home_play.py` para o ramo sem `pazucore_pending_deep_link`: `GetCurrentWorldSceneName` → `LoadScene(scene, true, null)` (fade = carregamento visto). O ramo com deep link pendente NÃO foi exercitado; chamada indireta em 0x2058174 segue sem alvo resolvido.
- Conclusão: o Play original abre o mapa do mundo, não a quadra de basquete; a quadra permanece protótipo sem equivalência. Contrato continua `static_candidate_not_runtime_validated`; T025 não vira done sem revisão independente. Log Unity filtrado só mostrou `LOW_MEMORY`, sem nome de cena — a cena concreta do mapa ainda não foi identificada.
- Próximos: identificar nome da cena do mapa (logcat/`GetCurrentWorldSceneName` no metadata), resolver o alvo de 0x2058174, e cobrir os cenários chave ausente/vazia/não vazia.
- Continuação 2026-11-03: alvo da chamada indireta em `0x2058174` resolvido como **inferido** (`DeepLinkManager.Instance._mapLinkToLevel[chave]`, campo +0x28); verificador ganhou anchors e teste (86 testes OK). Handoff completo em `docs/RECON_HOME_PLAY_HANDOFF.md` com desconhecidos ordenados. Nada commitado.
- 2026-11-03: `_mapLinkToLevel` extraído do datapack (149 entradas, `out/recon/tasks/T025/DEVICE/deeplink_map_link_to_level.json`), pareamento por ordem ainda não validado (lista de chaves duplicada). Evidências de `out/recon/` agora versionadas, exceto `out/recon/il2cpp/`.
- 2026-11-03: duplicata de chaves explicada (`_keyValues`+`_keys`+`_values`); mapa deep link→LevelType passa a candidato sólido. Próximo: LevelType→cena via `CoreExtensions.GetSceneName` (0x206a798).
- 2026-11-03: `GetSceneName` = "Level_"+enum; tabela deep link→cena gerada (146/149 no BuildSettings; faltam apthmf2, dock, conveniencestore). Cenas `Home` e `World` existem no BuildSettings.
- 2026-11-03: despacho em 0x2058174 decodificado como slot 0 de IDictionary`2 = get_Item (âncoras + teste). Celular não é necessário para os próximos passos estáticos; só para testes de runtime.
- 2026-11-03: 3 deep links sem cena explicados: 7 LevelTypes não distribuídos na 1.227 (inclui Burger/GasStation/CarWash, vistos em obras no mapa). Estáticos concluídos; resta runtime (celular) e revisão independente.
- 2026-11-03: contrato estático de `GameSceneManager.LoadScene`/`LoadSceneImplement` (T029) com verificador `tools/recon_load_scene.py`, 5 testes de mutação (91 OK) e `docs/RECON_LOAD_SCENE_CONTRACT.md`. LoadScene não chama IsSceneAvailable; ordem: guard in-progress → limpa caches → estáticos → Stage1-3 → StartSceneTransition. Próximo: quem zera IsSceneChangingInProgress (OnActiveSceneChanged 0x2072644), depois WorldBuilding.ClickOnLevel.
- 2026-11-03: OnActiveSceneChanged e CancelCurrentSceneChangingProgress decodificados (zeram in-progress, MP loading name e CurrentlyLoadingSceneName); 18 âncoras, 92 testes OK. Falta achar assinante/chamador. Próximo: WorldBuilding.ClickOnLevel.
- 2026-11-03: contrato estático do toque em prédio (`WorldBuilding.OnPointerClickInternal`/`ClickOnLevel`/`WorldEnterableEntity.LoadScene`/`SaveBuildingData`) com verificador `tools/recon_world_click.py` (17 chamadas, 20 âncoras, 6 testes de mutação) e `docs/RECON_WORLD_CLICK_CONTRACT.md`. Achado: `GAME_CURRENT_WORLD` é gravado em `WorldEnterableEntity.LoadScene` com a cena ativa; gate de entrada usa `ExtraSettings.useTimeLock`/IsCurrentlyFree/IsGameUnlocked, senão popup de preview. Próximo: gates de UGC/ponteiro, `IsCurrentlyFree`/`IsGameUnlocked`, `TryLoadBuildingData` parse.
- 2026-11-03: gate de acesso decodificado: `PWCConstants..cctor` seta `IsAllWorldFree=true` → `IsCurrentlyFree()` sempre verdadeiro na 1.227; 115 prédios `_isFree=0`; `useTimeLock=0` (parse manual). Verificador `tools/recon_access_gate.py` (10 chamadas, 17 âncoras, 5 testes). Próximo: parse de TryLoadBuildingData, gates de UGC/ponteiro, slot virtual 0x298.
- 2026-11-03: toque em prédio completo: OnPointerClick ignora drag/reset; OnPointerClickInternal ignora em UGC edit mode; TryLoadBuildingData = string vazia→false, senão Enum.TryParse. recon_world_click.py agora 20 chamadas/37 âncoras, 8 testes.
- 2026-11-03: virtual LoadScene fechado por unicidade do override (WorldEnterableEntity). Índice da cadeia e lista do que falta em `docs/RECON_HOME_PLAY_HANDOFF.md`. Estático concluído para a cadeia Home→Play→prédio→cena; faltam runtime e revisão independente.
- 2026-11-03: banco de 100 desafios + Pacote Inicial abre balão de desafios (dificuldade por preço, sorteio sem repetição, +moedas por acerto). Validado no aparelho em build lado a lado (assinatura do app principal difere). Mapa World: exportador tools/export_world_map.py pronto (composição confere com o original), integração Unity pendente (fatias 1-2 de docs/STORE_WORLD_UI_SPEC.md).
- 2026-11-03 (fim do dia): **Fatia 1 do mapa World implementada, NÃO verificada visualmente no aparelho** (celular desconectado no fim). Play → `WorldMapRuntime` (arte extraída de level4: 307 elementos/262 sprites em `Resources/WorldSlice`, câmera que rola ao arrastar, toque em prédios, botão voltar do original); toque no prédio `Basketball_T1S2` (LevelType 13) abre a quadra e voltar da quadra retorna ao mapa; prédios em obras/sem cena mostram aviso. EditMode 88/88; build lado a lado OK (`Builds/AvatarWorldOffline-sidebyside.apk`, id `.sbs`).
- **Amanhã:** (1) conectar o celular, `adb install -r` do build lado a lado, tocar Play e conferir: composição vs original (print 16.08.14), arrasto, posição inicial (startX 49,5 / startY −0,5 em `world.json`), clique no prédio de basquete (x ≈ −78…−73), aviso nos prédios em obras (x ≈ 44–56); (2) conferir ordenação/transparência, tinta de hora do dia (hoje sem tint) e fundo do céu; (3) fatia 2: refinar o prédio do basquete e a quadra como lugar do mapa; (4) fatia 3: barra do mapa (clima, globo, +avatar, editar casa) — UI já exportada em `out/scene-extract/level4_ui` (local, não versionado). Reexportar: `tools/export_world_map.py` (precisa de `out/scene-extract` extraído do datapack, ~1,6 GB; `unityfs_extract_entry.py` com `--bundle x/data/assets/bin/Data/datapack.unity3d`).
- 2026-11-04: **Verificado no aparelho (build `.sbs`)**: Home → Play mostra a tela de loading (avatar+gato, relógio, círculo; `LoadingScreen.cs`, arte em `Resources/Loading`, extraída de `sharedassets1.assets`) e abre o mapa; composição bate com o print original após restaurar a arte DayMode (lava-jato/posto/hamburgueria; filtro do exportador removido) e ajustar a câmera inicial (`startX 51.2 / startY −0.05`); arrasto OK; toque na quadra (vermelha com tela, ao lado do hospital, x ≈ −78…−73) → loading → quadra; voltar → mapa na mesma posição. Destaque ao tocar prédio (`PulseBuilding`). Pendente: círculo/ponteiros/escala do loading são aproximados; faixa rosa de poucos px ao fundo; tinta de hora do dia, céu, barra superior (fatia 3). O "Development Console" com avisos de atlas do avatar (`Material with texture name ... not found`) vem do build de desenvolvimento, anterior a esta fatia.
- 2026-11-04 — reconciliação save/progressão: cliente local salva moeda, pontos, claims, ledger, desafios e aparência em JSON; posição do avatar, objetos e progresso por cena ainda não integram `PlayerState`. Dump original mostra `PersistentDataManager`, `PDSceneObject`, `IHasPersistentData`, grupos `SceneObjects`/`Prefabs` e hooks de save/load, mas corpos relevantes estão vazios no Cpp2IL. Contrato parcial e próximo lote registrados em `docs/RECON_SAVE_CONTRACT.md`; T030 permanece aberto. O mapa World tem registro de verificação no aparelho nesta data; aparelho não é bloqueio para a próxima extração estática.
- 2026-11-04 — extração T030: `tools/recon_save_static.py` recuperou 58 janelas ARM64, sem métodos-alvo ausentes, com hashes e arestas de chamadas em `out/recon/tasks/T030/persistence-asm/report.json`. Evidência do fluxo: `SaveProgressInAllScenes` percorre cenas; `SaveDataInternal` cria `PDScene`, atualiza `LevelUserData`, serializa MiniJSON e chama `FileManager.SaveTextFile`; load lê arquivo ou default, desserializa, limpa/spawna objetos e aplica handlers. Janelas extensas agora chegam a 16 KiB quando necessário; limite e inícios de metadata não provam corpos completos. Despachos indiretos continuam pendentes.
- 2026-11-04 — pilotos T030: `tools/recon_save_scene.py level4` gerou `scene-pilot.json` (41 `PDSceneObject`, GUIDs únicos: 6 UUID e 35 nomes; 13 handlers persistentes). A quadra original `level8` foi extraída em bloco isolado do APK e reportada em `level8-inspect.json`/`level8-scene-pilot.json`: 81 `PDSceneObject` com UUIDs únicos, 22 `PDPrefab`, 34 handlers persistentes, incluindo placar, itens, orientação, bolsa e item preenchível. Cpp2IL + ARM64 confirmam os schemas de score, parent/posição/attachment/flip, orientação, aberto/fechado e cheio/vazio; valores dinâmicos de uma sessão salva não vieram na cena base. T030 segue aberto para CFG/indirect dispatch e comparação com um save real ou captura runtime equivalente.
- 2026-11-04 — T031 avançou por análise estática: 72 janelas ARM64 mapeadas sem alvos ausentes; relatórios com hashes e 2 cenas piloto em `out/recon/tasks/T031/`. `level4`: EventSystem padrão, 68 `LevelScrollCameraOnDrag`, 162 `CShape`, 107 polígonos; `level8`: EventSystem padrão, 14 `LevelItem`, handlers/aros da cesta e 18 polígonos. Contrato, cadeia pointer→drag→drop e limites em `docs/RECON_INPUT_CONTRACT.md`. Dispatches indiretos, competição de hitboxes, cancelamento, limiar de arraste, física/pontuação completa e execução dinâmica seguem pendentes; T031 continua parcial. Testes de aparelho adiados conforme combinado.
- 2026-11-04 — T032 avançou estaticamente: classificação hashada dos 896 presets (827 Character, 45 Toddler, 11 Baby, 7 Dog, 3 Cat, 3 Horse), 21 classes de cena relacionadas e 87 janelas ARM64 em `out/recon/tasks/T032/`. Contratos de spawn, drag/movimento, interfaces e lacunas em `docs/RECON_CHARACTER_CONTRACT.md`. T032 permanece parcial: dispatch de callbacks, posição/autonomia de NPC, movimento entre famílias e execução pendentes. `recon_queue.py prepare T032` confirma dependências canônicas T018, T025–T027 e T031 pendentes; não promover estado da fila.
- 2026-11-04 — T033: o catálogo do cliente foi ampliado de 400 para 2.174 opções nas quatro categorias principais. Foram integradas 1.774 peças adicionais, preservando as 400 IDs existentes e usando alocação proporcional provisória (564/525/634/451). `tools/recon_clothing_gates.py` recuperou `ExpansionPacksBuildData` (48 flags/1.763 associações) e `InventorySkinsBuildData` (3 flags premium/11 associações) dos objetos serializados em `resources.assets`. O cruzamento identificou 64 IDs do catálogo explicitamente associados a flags de expansão (2 camisas, 2 partes de baixo, 52 sapatos, 8 acessórios); os outros 2.110 não aparecem nesses mapas e não podem ser presumidos gratuitos. O cliente ainda não reproduz esses gates; distribuição original, variantes de cor e renderização seguem sem evidência. Relatório: `out/recon/tasks/T033/clothing-gates-crosswalk.json`; detalhes em `docs/RECON_CLOTHING_GAP.md`. T033 continua parcial.
- 2026-11-04 — T042: inventário automatizado de `ResourceManager` (154.446 referências/92.603 caminhos), 176 grupos de recursos de cena, World map level4 (59 edifícios, 770 renderers/484 sprites), acessórios SUT (263 IDs Character cruzam explicitamente com flags), veículos CarMaker (4 IDs de breed; peças com sufixos p232/p235/p246 coincidem com flags de produto) e pets (35 presets Dog/Cat/Horse, além dos caminhos de skins). Relatórios `out/recon/tasks/T042/world-vehicles-accessories-pets.json` + índice comprimido e resumo `docs/RECON_WORLD_ASSET_MAP.md`. Associação de veículos/pets por nome segue candidata; entitlement e fluxos runtime não estão fechados. T042 continua parcial e com dependências pendentes.
- 2026-11-04 — T035: inventário de todas as fontes locais de animação: 587/587 esqueletos Spine parseados, 7.206 entradas arquivo/animação e 5.067 nomes únicos; 23 AnimationClips, 5 AnimatorControllers, 10 Animator e 55 componentes Animation Unity; 821 classes `LevelCA*`, sendo 577 com 24.983 instâncias nos dumps por cena. Hashes, crosswalks e CSV em `out/recon/tasks/T035/`; resumo em `docs/RECON_ANIMATION_INVENTORY.md`. Nomes estáticos cobertos para fontes extraídas; handlers não revelam por si sós transições e efeitos completos. T035 continua parcial.
- 2026-11-05 — T035: `recon_contextual_links.py` varreu 878.040 registros e resolveu 5.704 referências por `(arquivo,path_id)` de 5.678 componentes. Ligou 894/974 assets de configuração e 66/71 de reação; 3.150 nomes-base presentes nos rigs correspondentes. Cache por hash reutiliza 239 tabelas externas sem descompressão; verificador reconstrói as identidades de todas as referências. Recuperadas 13 regras de sufixo (9 por PostureType, 3 `_Standing`, 1 `_Sitting` condicional) e comparação/seleção de nomes de reação em 33 janelas ARM64. Duas fontes de reação têm quatro entradas com diferenças de pasta/prefixo; alternativas registradas, dados originais preservados. Dossiê `docs/RECON_CONTEXTUAL_LINKS.md`, relatório completo em `out/recon/tasks/T035/contextual-links.json`. Próximo: ciclo add/remove/cancel/complete dos handlers básicos, nomes de reação e carregamentos indiretos. T035 permanece parcial; testes de aparelho continuam adiados.

## ETAPA "Avatar completo e funcional" — loop (iniciada 2026-11-04)

**Objetivo:** o avatar aparece e é editado de forma completa e funcional como no jogo original.
**Regras do loop:** um erro por ciclo; máximo 5 tentativas por erro (depois parar e escalar com: o que tentei, erro exato, 2 hipóteses); cada ciclo = Pensar → Agir → Observar (testes EditMode + build + aparelho/logcat) → Decidir. Instalação no aparelho exige o usuário tocar em "Instalar" (MIUI): só pedir quando houver algo novo a verificar.

**Estado verificado no aparelho (2026-11-04):** editor com layout do original (CharacterMenu), 400 itens reais (100 camisas/calças/sapatos/acessórios; `tools/avatar_catalog_build.py`), texturas carregadas sob demanda, miniaturas geradas do próprio avatar (~27 ms cada), atlas 2172/2172 sem avisos, 109 testes EditMode. Bug resolvido: texturas novas sem Read/Write (`ClothingTextureImporter`).

**Critério de conclusão (todos verificados no aparelho):**
- [~] C1 Cores: pele (62), olhos (33) e itens `_color` por tinta Multiply com a paleta General (115) + coluna de cores no menu — OK no aparelho para sobrancelhas (ciclos 1 e 3). Falta: roupas `_color` e cabelo usarem a mesma coluna (estender o catálogo para esses itens).
- [~] C2 Rosto/cabelo: olhos com cor, tom de pele (ciclo 1) e boca (100 opções, ciclo 2) OK no aparelho. Sobrancelhas (74, `_color` com tinta) OK no aparelho (ciclo 3). Cabelo frente (100 de 276 skins) + trás (99 de 188 itens) implementado no ciclo 4, AINDA NÃO verificado no aparelho.
- [ ] C3 Categorias restantes: chapéu, jaqueta, vestido, meias (modelo de save estendido, migração do save antigo).
- [ ] C4 Slots: vários avatares persistidos (adicionar/trocar/apagar).
- [ ] C5 Menu: subcategorias e marcas; miniaturas sem artefatos.
- [ ] C6 Referência visual: um preset reproduz o look do print do original (imagem13: chapéu de bombeiro, cabelo branco, jaqueta vermelha, saia rosa).
- [ ] C7 Qualidade: 0 erros no logcat, testes verdes, tempo de abertura medido.
**Fora desta etapa (documentado):** tipos criança/bebê/animais, CarMaker, avatar andando no mundo, persistência de cena (T030–T032).
**Decisão pendente do usuário:** como o jogador obtém cada roupa (grátis no editor ou comprada com moedas).

### Histórico de ciclos
- (ciclo 0) catálogo de 400 itens + carregamento sob demanda: OK no aparelho.
- (ciclo 1) paletas oficiais `AWSpineColorsList` → `palettes.json` (`tools/avatar_palette_export.py`); `AvatarAppearance.SkinIndex/EyesIndex` (save antigo mantém padrões; testado); categorias Pele/Olhos no menu com amostras. EditMode 113/113. Aparelho: grade de 62 e 33 amostras, troca ao vivo, desfazer ativo, concluir salva, reabrir mantém.
  - Óculos "duplos" NÃO é bug: o atlas `Glasses_5` tem uma região só com 2 pares desenhados (probe `AvatarAssetProbe`, inventário em `out/avatar-spine-inventory.json`).
- (ciclo 2) Boca: `AvatarAppearance.MouthId` (padrão `mouth_default` = anexo embutido), 99 bocas SUT via `tools/avatar_catalog_build.py` (suporta pastas de 3 níveis), skin `Templates/Mouth_N` + `SetAttachment("Mouths","Mouths")`. EditMode 113/113. Aparelho: 100 miniaturas (~26 ms cada), troca ao vivo, desfazer ativo.
  - Próximo (ciclo 3): sobrancelhas e cabelo (`_color`) → exige tint por item (config `AvatarSpineSkinsDefaultColors_*` + paleta General) e coluna de cores.
- (ciclo 3) Sobrancelhas + cor por item: `AvatarAppearance.EyebrowsId` e `ItemColors` (lista Categoria/Índice, padrão = marrom escuro da paleta General), tinta Multiply por item `_color`, coluna de cores (visível só quando o item aceita tinta). Tentativa 1 falhou no aparelho (avatar desbotado): `SetAttachment("Eyebrows_L",...)` lançava `Attachment not found` em itens de um só lado e abortava a tinta; tentativa 2: ligar só os anexos do skin do próprio item → OK (sobrancelhas vermelhas visíveis sem os óculos levantados, que as cobrem). Capture de miniatura agora restaura o item anterior em `finally` (a falha deixava o estado preso e salvo). EditMode 115/115.
- (ciclo 4) Cabelo: `Hair` vira categoria de itens (100 skins `Hair_Front/N_Color`, manifesto com campo `skin`) + categoria `HairBack` (99 itens `_color` + `hair_back_none`), cor única de cabelo (`AvatarCatalog.ColorKey`), abas Frente/Atrás no menu; `tools/avatar_catalog_build.py` lê `out/avatar-spine-inventory.json` (gerado por `AvatarAssetProbe.Inspect`). EditMode 116/116. **Pendente:** instalar e verificar no aparelho (grade de cabelos, aba Atrás, tinta pela coluna, miniaturas do cabelo traseiro, tempo de abertura). Sessão encerrada a pedido do usuário antes dessa verificação.
**Próximos ciclos (backlog):** roupas `_color` com a mesma coluna; chapéu/jaqueta/vestido/meias (save); slots múltiplos (C4); subcategorias e marcas do menu (C5); preset do print imagem13 (C6); medir abertura e 0 erros no logcat (C7).

## Loja de veículos — captura no aparelho (2026-11-07)
- Pergunta do usuário: a loja original tem 3 submenus de veículos com vários pacotes cada — já estava mapeado? Resposta: só parcialmente (sub-trilho "destaque/carro/van" dos prints de 16.03–16.07 e os 3 breeds candidatos do CarMaker em T042). Faltavam os pacotes reais (nomes/preços).
- Capturado ao vivo via ADB no Xiaomi M2101K7BI conectado, abrindo `com.pazugames.avatarworld` 1.228 (versionCode 229, instalado 2026-11-06 — build mais novo que o 1.227/228 usado em 2026-11-03). Bloqueio encontrado e resolvido: sem a permissão "Início automático" (MIUI), o app era morto pelo `AutoStartManagerService` ~20s depois de abrir a loja; usuário liberou manualmente na Central de Segurança e a captura funcionou.
- Achado: a categoria Veículos tem **4 abas** (Destaque/VIP/Carro/Van), não 3 como os prints antigos sugeriam — a aba "estrela" (VIP: Helicóptero 800, Iate 900, 2 limusines 300) não tinha sido registrada antes. Carro de Aventura (Jeep) confirmado em 700 moedas, batendo com o valor já documentado. Lista completa e cruzamento com os breeds do CarMaker (T042) em `docs/STORE_WORLD_UI_SPEC.md`.
- Nenhuma arte local (`Resources/Store/packs`) corresponde a esses pacotes ainda; implementação em `StoreCatalog.cs` requer decidir arte placeholder vs. nova tarefa de extração antes de tirar "Veículos" do `ComingSoon`. Nada implementado em código nesta sessão, só documentação.
