# LOOP_STATE — Avatar World RE (uso pessoal, repo privado)

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
