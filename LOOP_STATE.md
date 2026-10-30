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
