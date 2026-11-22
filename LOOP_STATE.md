# LOOP_STATE — Avatar World RE (uso pessoal, repo privado)

## T020: os 3 outliers também fechados — causa raiz 100% unificada e todas as 124 classes resolvidas/prontas — 2026-11-22
Continuando a sessão anterior: os 3 outliers (`GameExtraSettings`, `LocalizationManager`,
`WindowManager`) deixados abertos por não terem a string "SerializableDictionaryBase" no próprio
arquivo decompilado. Achado: eles referenciam **subclasses nomeadas** desse genérico
(`Name_Back_Scene`, `Country_SupportedLanguages`, `Name_Audio`, `Name_AudioEvent`) — mesmo mecanismo
de quebra, só que indireto (um grep ingênuo pela string literal não pega). Fechadas as 3 tarefas
restantes na fila como `blocked_external` (`out/recon/tasks/T020/close_nullref_final3_2026-11-22.py`).
- Fila: `blocked_external` de 48 para 51, `pending` de 844 para 841.
- **As 124 classes T020 agora têm causa raiz 100% identificada**: 65 `same_bug_likely_fixed`
  (precisam só de RAM pra confirmar), 30 `typetreegeneratorapi_nullref_*` (fechadas, limitação de
  ferramenta), 20 `type_stripped_*` (fechadas, binário shipado sem o tipo), 9
  `serialize_reference_*` (precisam só de RAM pra confirmar). Nenhuma categoria "causa desconhecida"
  restante. Detalhe: `docs/RECON_T020_NODE_TREE_TRIAGE_2026-11-22.md`.

## T020: mais 27 classes fechadas na fila; 3 outliers deixados em aberto por rigor — 2026-11-22
Continuação do fechamento das 20 `type_stripped_*`. Para as 30 `typetreegeneratorapi_nullref_*`,
verifiquei **individualmente** (não por amostra) cada uma contra `out/cpp2il` decompilado antes de
fechar qualquer uma — achei que 3 (`PazuCore.GameExtraSettings`, `PazuCore.LocalizationManager`,
`PazuCore.WindowManager`) têm a mesma mensagem nativa mas **não têm** o campo
`SerializableDictionaryBase<K,V>` confirmado nas outras 27 — causa real delas ainda desconhecida.
- Fechei só as 27 confirmadas (campo e tipo exatos lidos do fonte decompilado de cada uma) na fila
  formal como `blocked_external` (`out/recon/tasks/T020/close_nullref_confirmed_tasks_2026-11-22.py`).
  As 3 outliers ficam `pending`/`ready`, sem causa raiz registrada — não fechei sem prova.
- Fila: `blocked_external` de 21 para 48, `pending` de 871 para 844.
- Detalhe: `docs/RECON_T020_NODE_TREE_TRIAGE_2026-11-22.md`.

## T020: 20 classes PWC.EditorApp.* fechadas na fila como blocked_external — 2026-11-22
Confirmado sistematicamente (não amostra) que nenhuma das 20 classes `type_stripped_*` existe em
`out/cpp2il/DiffableCs` — nem a string "EditorApp" aparece em lugar nenhum da árvore decompilada.
Fechei as 20 tarefas `T020/CLASS/<hash>` correspondentes na fila formal via `claim`→`start`→
`checkpoint(blocked_external)` (script `out/recon/tasks/T020/close_type_stripped_tasks_2026-11-22.py`),
gerando `class-contract.json`/`recount.json`/`result.json` em `out/recon/tasks/T020/CLASS/<hash>/`
pra cada uma.
- **Por que `blocked_external` e não `evidence_ready`**: o critério de aceite exige "identificar
  cada objeto afetado" (path_id/arquivo exato) — isso só dá pra saber abrindo o `datapack.unity3d`,
  bloqueado por RAM. Só a contagem agregada (`out/mb/_stats.json`) é conhecida, não a identidade de
  cada objeto. Marcar como resolvido sem isso seria inventar evidência.
- Fila: `blocked_external` subiu de 1 para 21, `pending` caiu de 891 para 871.

## T020: as 124 classes 100% categorizadas por causa raiz — 2026-11-22
Fechando a triagem (`docs/RECON_T020_NODE_TREE_TRIAGE_2026-11-22.md`): as 18 classes que tinham
falha de geração de árvore sem correlação automática da mensagem nativa foram checadas uma a uma
(sem tocar no datapack). Resultado final das 124: **65** `same_bug_likely_fixed` (mesmo fix já
mergeado, falta só confirmar com dado real), **30** `typetreegeneratorapi_nullref_*` (limitação da
lib nativa em campo de dicionário genérico cru — inclui agora **todas as 14** classes
`AvatarMaker*ColorsConfig`/`*SubcategoriesConfig`, uma por espécie do editor de avatar), **20**
`type_stripped_*` (todas `PWC.EditorApp.*`, provável code stripping, provavelmente irresolúvel de
verdade), **9** `serialize_reference_ref_types_resolution` (já diagnosticadas antes).
Nenhuma classe restante sem causa raiz identificada.

## T020: as 9 classes de "causa desconhecida" diagnosticadas (SerializeReference) — 2026-11-22
Continuação da triagem (`docs/RECON_T020_NODE_TREE_TRIAGE_2026-11-22.md`). As 9 classes que tinham
árvore de tipos gerada com sucesso mas nenhum campo `List<String>` mal rotulado agora têm causa raiz
identificada: todas usam `[SerializeReference]` do Unity (confirmado: todas têm nós
`ManagedReferencesRegistry`/`ReferencedObject`). O tipo concreto de cada instância só resolve contra
`SerializedFile.ref_types`, que é metadado por arquivo serializado — precisa do datapack carregado pra
confirmar se está ausente ou se é mismatch de nome na comparação exata. Confirmado que `assetsfile` já
é passado certinho pro `read_typetree` (não é bug de parâmetro faltando).
- Inclui `BWYW.DailyTasksData` (`T020/CLASS/4cc86bcb4a623c07`, ready) e `BWYW.BWYWGiftData`
  (`T020/CLASS/d723b7b66951bef8`, `blocked_external` numa tentativa anterior que travou só carregando
  o IL2CPP, antes de gerar a árvore — confirmado agora que a geração funciona, o bloqueio foi memória).
- **Parado por decisão do usuário, após 1 tentativa adicional autorizada**: usuário pediu pra conferir
  a memória e tentar mesmo assim (2,6 GiB disponível, 1,6 GiB swap livre no momento do disparo — melhor
  que antes). `journalctl -k` confirma OOM de novo, **5ª vez seguida, sempre no mesmo ponto** (carregando
  `datapack.unity3d`, antes de processar qualquer objeto): desta vez matado com só **3,75 GB de RSS**
  (`anon-rss:3745384kB`), bem abaixo do pico de ~5,8 GB da tentativa anterior — confirma que não é um
  teto fixo do processo, é pressão do sistema todo variando em tempo real (provavelmente o Chrome,
  maior consumidor de RAM observado, crescendo durante os poucos segundos do carregamento). "RAM
  disponível" no instante do disparo não prediz o resultado de forma confiável nesta máquina. Decisão
  final do usuário: parar de tentar por conta própria aqui; diagnóstico (SerializeReference) documentado
  é considerado avanço suficiente por ora. Retomar no PC do trabalho (`tools/mb_retry_failed_classes.py`)
  ou depois de fechar o Chrome manualmente.

## T020: fila formal descoberta e usada; 124 classes restantes triadas sem RAM — 2026-11-22
- Descoberta: já existe uma fila formal de tarefas (`tools/recon_queue.py`, `reports/recon/tasks.json`,
  908 tarefas) coordenando o trabalho entre as sessões/worktrees — família `T020/CLASS/<hash>`, uma por
  classe de MonoBehaviour que falha na extração. Reconciliei `InventoryBuildData`/`InventorySkinsBuildData`
  nela (PR #65): `claim` → `start` → `checkpoint evidence_ready`, ambas em estado `review` aguardando
  revisor independente (não autoaceitei, a fila proíbe).
- Achado: `TypeTreeGenerator.get_nodes_as_json()` só precisa de `il2cpp_in/` + `data.unity3d` (não o
  `datapack.unity3d` de 1,3 GB que sempre dá OOM) — dá pra testar a hipótese "mesmo bug de
  `fix_mislabeled_vectors`" pras 124 classes restantes sem risco de travar a máquina. Resultado: 65
  provavelmente já resolvidas pelo fix existente (falta só confirmar com o datapack), ~19+ são limitação
  da própria biblioteca `TypeTreeGeneratorAPI` (null ref em campo de dicionário genérico cru, ex.
  `SerializableDictionaryBase<TKey,TValue>` — afeta 12 classes `AvatarMaker*ColorsConfig`/`*SubcategoriesConfig`,
  relevante pro trabalho paralelo do editor de avatar), ~13+ são tipos removidos do binário shipado
  (`PWC.EditorApp.*`, ferramental de editor/dev, confirmado ausente também no `out/cpp2il` decompilado),
  9 têm causa raiz ainda não diagnosticada. Detalhe completo: `docs/RECON_T020_NODE_TREE_TRIAGE_2026-11-22.md`.
- Nada disso foi marcado `done` na fila — é triagem/hipótese, não resolução (acceptance de cada tarefa
  exige ler objetos reais com `check_read=True`, que precisa do datapack).

## Loja: Mansão e mais temas de Casas confirmados irresolúveis; Modern House confirmado — 2026-11-22
Continuando os pendentes de `docs/RECON_STORE_HOUSE_BUNDLES_2026-11-07.md` (PR #64, aberta).
- `ModernHousePB9Box_Pack` passou de "incerto" pra **confirmado**: busca por "modern" em todo `store_catalog.json`
  (37230 itens) retorna exatamente a capa + os 2 cômodos já linkados, nenhum outro — não é mais inferência fraca.
- `MansionBundlePB2Box_Pack` confirmado **irresolúvel**, não só "não achei ainda": `store_catalog.json` tem 351
  prefabs `*Pack` em `resources.assets`, só 224 linkados em `InventoryBuildData.packToItems` (única instância do
  objeto no jogo). Os outros 127 "órfãos" não têm item-list em lugar nenhum do APK — inclui Mansão, mais um tema
  "Apartamento" (`ApartmentHMP82/89/95`, 3 variantes), mais 6 cômodos órfãos de Bubble Glam e uma 2ª variante de
  Kawaii House. Mesma ausência de dado já documentada pra Moda (`StoreData.Item`/`bundleItems` não estão no APK).
- Categorização dos 224 pacotes refinada separadamente: ver `docs/RECON_STORE_ALL_PACKS_OVERVIEW_2026-11-07.md`.
- Nada implementado no cliente ainda (não há editor de casas); decisão de produto pendente do autor sobre o que
  fazer com temas irresolúveis (excluir da loja offline ou inventar conteúdo próprio, deixando claro que não é
  dado original).

## Loja: reextração das ~124 classes de MonoBehaviour restantes — bloqueada por RAM, não por contenção — 2026-11-21
Continuação de `docs/RECON_STORE_HOUSE_BUNDLES_2026-11-07.md` (PR #42, já mergeada: fix do bug de type-tree
`List<String>` rotulado como `string`, 7 temas de Casas decodificados). Faltava reextrair as outras ~124
classes de MonoBehaviour que tinham o mesmo bug (`out/mb/_stats.json`), achando que era só falta de RAM
momentânea por sessões concorrentes.
- 4 tentativas seguidas (2 em 07/11, 2 em 21/11, já com swap livre e sem outras sessões Unity rodando)
  falharam idênticas, sempre no mesmo ponto (carregando `x/base/assets/bin/Data/datapack.unity3d`, 1,3 GB).
- **Causa real confirmada por `journalctl -k`**: `Out of memory: Killed process ... anon-rss:5778888kB` — o
  processo passa de **5,8 GB de RAM residente** só pra carregar o datapack (Unity comprime os blocos com
  LZMA/LZ4HC; descomprimido fica bem maior que o 1,3 GB no disco), e ainda estava crescendo. Não é contenção
  de outra sessão: é que esta máquina (7,1 GB RAM) não comporta essa carga de trabalho sozinha.
- Decisão do usuário (2026-11-21): rodar no PC do trabalho (mais RAM) em vez de insistir aqui.
- Script pronto e documentado, dentro do repo agora (antes só existia fora, em `/tmp` de um job que seria
  limpo): `tools/mb_retry_failed_classes.py` — docstring tem o passo a passo completo pra extrair
  `il2cpp_in/`+`x/` do APK (ambos gitignored) e instalar `TypeTreeGeneratorAPI` (faltava no ambiente, não vem
  com UnityPy). Só reprocessa as classes que ainda estão em `out/mb/_stats.json["erros"]`, mescla o resultado
  de volta no mesmo arquivo sem apagar o que já está ok.
- **Próximo passo:** rodar `python3 tools/mb_retry_failed_classes.py` numa máquina com mais RAM livre (o
  PC do trabalho). Se passar, dá pra reaproveitar `docs/RECON_STORE_ALL_PACKS_OVERVIEW_2026-11-07.md` como
  base pra refinar a categorização dos 224 pacotes com dados reais em vez de heurística.

## Hipótese revisada: sufixo `_st` em skins = sticker, não sombra/template — 2026-11-14
- Hipótese anterior ("camada auxiliar de sombra/template, não visível") era só inferência pelo
  nome; nunca tinha sido checada contra o atlas original nem contra o código. Escopo real é
  pequeno: só 2 skins em todo o catálogo capturado têm sufixo `_st` (`hat_3_st` em
  `hat_a_207_color`, `j_arm_r_2_st` em `jacket_91_color`; 4 `path_id` no total).
- Checado diretamente no `resources.assets` ORIGINAL (extraído de `apk/base.apk`, via
  UnityPy): as 4 entradas `_st` existem como Texture2D+Sprite reais, mesmo tamanho de canvas
  da versão sem `_st` — a extração do clone não pulou nenhuma página do atlas.
- Pixels decodificados mostram que `_st` NÃO é sombra/silhueta do item base: `Hat_3_ST` é um
  rosto de urso de pelúcia pequeno (3,9% opaco), `J_Arm_R_2_ST` é um emblema circular pequeno —
  ambos sem relação de forma com `Hat_3`/`J_Arm_R_2`. Uma sombra real replicaria a silhueta;
  aqui não replica.
- Strings do binário/metadata IL2CPP originais (`il2cpp_in/`) confirmam um sistema de
  "sticker" ativo e não trivial: `LevelCAStickerItemHandler`, `CarStickerDecal`/
  `CarStickerMapping`/`CarStickerSlotExclusion`, `TryGetStickerForTarget`, mensagens de
  validação de runtime ("sticker area has no size", "a part can only wear one [sticker]"),
  e dezenas de assets de sticker nomeados alhures no catálogo. `_st` muito provavelmente
  abrevia "sticker": um decalque pequeno associado à skin, não uma camada invisível.
- **Pendência não fechada (3 rodadas, 2 providers, mesma causa de fundo):** decompilação do
  call-path real (`LevelSkinCATargetHandler.TryAddCAHandlerFromSkinName`/`OnPutClothing`,
  `LevelCAStickerItemHandler.OnAddedToTarget`/`GetFolderName`,
  `LevelClothingItemHandler.GetSkinName`) via REA em `il2cpp_in/libil2cpp.so`: (1) Hopper
  morto por OOM com um teste Unity EditMode concorrente saturando a máquina; (2) Hopper, já
  com memória livre, travado 2x em `provider_timeout`/`QDialog::WaitDialog` (sem banco de
  análise `.hop` pré-existente); (3) depois de instalar Ghidra 12.1.4 e configurar
  `GHIDRA_INSTALL_DIR` (exigiu reiniciar o job para o MCP server `rea` pegar a env var nova),
  `open_binary` com Ghidra funcionou, mas `procedure_pseudo_code` matou o processo Java por
  **OOM de novo** (`journalctl -k` confirma `Killed process 97231 (java)
  anon-rss:1759520kB`) assim que o Ghidra headless entrou na análise completa do binário.
  Conclusão: é limitação estrutural da máquina (7,1 GiB RAM + 4 GiB swap insuficientes para
  analisar um IL2CPP de ~75MB com qualquer um dos dois providers enquanto as sessões/apps
  normais estão abertas), não do binário nem da abordagem. Retomar exige mais memória
  disponível no momento (fechar outras sessões/apps, aumentar swap — decisão do usuário) ou
  rodar numa máquina com mais RAM. Vaddrs exatos seguem anotados em
  `out/recon/tasks/T034/ST_SUFFIX_FINDINGS.md`. Classificação:
  `static_candidate_not_runtime_validated` até essa etapa fechar.
- Evidência completa: `out/recon/tasks/T034/ST_SUFFIX_FINDINGS.md`. Sem alteração do cliente,
  sem execução/emulação, sem aparelho.

## Loja "Criador de Avatar" vira atalho de navegacao — 2026-11-07
- Commit `87148a4f8` (branch `worktree-loja-criador-avatar`, pushado): `StoreScreen.SelectCategory` trata
  `StoreCatalog.CategoryAvatarMaker` como atalho (fecha a loja, abre `AvatarSlotsScreen` via
  `HomeBootstrap.OpenAvatarSlots`) em vez de listar cartoes - evidencia em
  `docs/STORE_ORIGINAL_REFERENCE_2026-11-07.md` e `docs/STORE_WORLD_UI_SPEC.md` (cena AvatarMakerLobby,
  separada da Store). Removida do `ComingSoon`; teste novo `AvatarMaker_IsNavigationShortcutNotProductCategory`
  em `StoreCatalogTests.cs`.
- **Validacao automatizada PENDENTE.** Tres tentativas de `unity test --mode EditMode` nesta sessao foram
  mortas pelo OOM killer do kernel (confirmado via `journalctl`, nao erro do codigo): a maquina (7,1 GB RAM)
  tem varios jobs Claude Code em background concorrentes consumindo memoria ao mesmo tempo; em uma das
  tentativas o OOM matou um processo Python de outro job, nao o Unity. Copiar `Library/` do checkout
  principal (45 GB) para o worktree eliminou a reimportacao completa, mas nao foi suficiente para evitar o
  OOM na ultima tentativa. Decisao do usuario: seguir sem validacao automatizada por ora.
- Revisao manual feita com cuidado: mudanca pequena (4 arquivos), navegacao nova espelha padrao ja existente
  no codigo (botao de carrinho de `AvatarSlotsScreen` ja abre a loja no sentido inverso). Um artefato do
  processo Unity morto no meio (zerou `m_RuntimeSettings.m_List` em
  `UniversalRenderPipelineGlobalSettings.asset`) foi descartado com `git checkout --`, nao commitado.
- **Proximo passo:** rodar `unity test client/AvatarWorldClient --mode EditMode` neste worktree (Library ja
  copiada, deve ser rapido) assim que a maquina tiver folga de memoria, e confirmar
  `AvatarMaker_IsNavigationShortcutNotProductCategory` + suite completa verde antes de dar como fechado.

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
- 2026-11-07: assinantes dos eventos Stage1-3 decodificados (`tools/recon_scene_subscribers.py`, `docs/RECON_SCENE_SUBSCRIBERS.md`): 5 ligações registro→handler verificadas (`BackgroundPlanetSoundHandler`/Stage1, `PersistentDataManager` e `LevelManager`/Stage2, `LevelManager`/Stage3, mais `GameSceneManager..cctor`→`activeSceneChanged`). 9 testes OK. Revalidado em T025/METHOD/8e708ca7d06e0b52 no mesmo dia.
- 2026-11-08: decodificado o próprio despacho `blr` dos 3 Stage1-3 dentro de `LoadScene` (`tools/recon_stage_dispatch.py`, `docs/RECON_STAGE_DELEGATE_INVOKE.md`), fechando o unknown `T025/complete_body_and_cfg` até o limite estático: os três `blr x9` (antes só marcados como alvo indireto opaco) carregam o alvo e os dois primeiros argumentos de offsets fixos (`+0x18`/`+0x40`/`+0x28`) do próprio objeto delegate em runtime, nunca de um branch fixo a handler — e essa sequência exata de 4 instruções recorre 467 vezes em classes não relacionadas no mesmo `.so` (idioma genérico do IL2CPP para invocar delegate direto, não algo específico destes 3 eventos). 8 testes OK. Rótulos `invoke_impl`/`m_target`/`method` para esses offsets são candidatos pela forma pública do ABI Il2CppDelegate, não confirmados contra esta build. Não fecha: quem de fato executa em runtime (propriedade do delegate construído pelos `add_*`, não do call site), nem o fade de `StartSceneTransition`. Nenhum alvo REA ativo, nenhuma execução do jogo, fila (`reports/recon/tasks.json`) não tocada nesta rodada.
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
- 2026-11-08 — T031 avançou: os dispatches indiretos de `DragDropItemBase.OnBeginDrag`/`OnEndDrag` (os "quatro dispatches indiretos" de cada, citados em 2026-11-04) estão totalmente identificados e provados por campo/slot re-derivado da metadata (não por cache): `TryOverridePreBeginDragAction`/`TryOverridePreEndDragAction` (campos `0xE8`/`0xF0`) cancelam o fluxo padrão quando retornam `true`; `this+0x39` (antes "significado não determinado") é `<IsDragging>k__BackingField`. Em `LevelItem.OnBeginDragInternal`/`OnEndDragInternal`, 4/5 e 2/3 dispatches resolvidos; achado principal: `OverrideOnDropBehaviorAction` (campo `0x328`) é o gancho que substitui todo o pipeline padrão de queda/pouso/escala/som ao soltar — ponto de extensão para itens de drop customizado (ex. pontuação). `SortDropAreas`/`GetMostRelevantDropAreaUnderPosition` não têm `blr` (confirmado por varredura negativa): prioridade entre hitboxes sobrepostas = ordem fixa de `SortDropAreas`, primeira área aceita pelo predicado (`IsDroppableUnderItem`) vence; o comparador e o predicado em si não foram abertos. Ferramenta `tools/recon_t031_dispatch.py`, relatório `out/recon/tasks/T031/dispatch-resolution.json`, 7 testes de mutação em `tools/test_recon_t031_dispatch.py` (7/7 OK), detalhes em `docs/RECON_INPUT_CONTRACT.md` (recorte 2026-11-08). Sem Hopper/Ghidra/IDA utilizável neste sandbox (Hopper expirou de novo por diálogo de licença/loader; `objdump` local não tem suporte AArch64) — leitura continua sendo ELF+metadata byte a byte. Em aberto: identidade dos dois delegates estáticos de `LevelItem`, comparador de `SortDropAreas`, critérios de `IsDroppableUnderItem`, e física/pontuação completa da quadra (`LevelBSBasketballItemHandler.ScoreInternal`/`MissInternal`/`Shoot`, `LevelBSHoop`) — não abertas nesta passagem por falta de disassembler AArch64 funcional. T031 continua parcial. Testes de aparelho adiados conforme combinado.
- 2026-11-04 — T032 avançou estaticamente: classificação hashada dos 896 presets (827 Character, 45 Toddler, 11 Baby, 7 Dog, 3 Cat, 3 Horse), 21 classes de cena relacionadas e 87 janelas ARM64 em `out/recon/tasks/T032/`. Contratos de spawn, drag/movimento, interfaces e lacunas em `docs/RECON_CHARACTER_CONTRACT.md`. T032 permanece parcial: dispatch de callbacks, posição/autonomia de NPC, movimento entre famílias e execução pendentes. `recon_queue.py prepare T032` confirma dependências canônicas T018, T025–T027 e T031 pendentes; não promover estado da fila.
- 2026-11-04 — T033: o catálogo do cliente foi ampliado de 400 para 2.174 opções nas quatro categorias principais. Foram integradas 1.774 peças adicionais, preservando as 400 IDs existentes e usando alocação proporcional provisória (564/525/634/451). `tools/recon_clothing_gates.py` recuperou `ExpansionPacksBuildData` (48 flags/1.763 associações) e `InventorySkinsBuildData` (3 flags premium/11 associações) dos objetos serializados em `resources.assets`. O cruzamento identificou 64 IDs do catálogo explicitamente associados a flags de expansão (2 camisas, 2 partes de baixo, 52 sapatos, 8 acessórios); os outros 2.110 não aparecem nesses mapas e não podem ser presumidos gratuitos. O cliente ainda não reproduz esses gates; distribuição original, variantes de cor e renderização seguem sem evidência. Relatório: `out/recon/tasks/T033/clothing-gates-crosswalk.json`; detalhes em `docs/RECON_CLOTHING_GAP.md`. T033 continua parcial.
- 2026-11-04 — T042: inventário automatizado de `ResourceManager` (154.446 referências/92.603 caminhos), 176 grupos de recursos de cena, World map level4 (59 edifícios, 770 renderers/484 sprites), acessórios SUT (263 IDs Character cruzam explicitamente com flags), veículos CarMaker (4 IDs de breed; peças com sufixos p232/p235/p246 coincidem com flags de produto) e pets (35 presets Dog/Cat/Horse, além dos caminhos de skins). Relatórios `out/recon/tasks/T042/world-vehicles-accessories-pets.json` + índice comprimido e resumo `docs/RECON_WORLD_ASSET_MAP.md`. Associação de veículos/pets por nome segue candidata; entitlement e fluxos runtime não estão fechados. T042 continua parcial e com dependências pendentes.
- 2026-11-04 — T035: inventário de todas as fontes locais de animação: 587/587 esqueletos Spine parseados, 7.206 entradas arquivo/animação e 5.067 nomes únicos; 23 AnimationClips, 5 AnimatorControllers, 10 Animator e 55 componentes Animation Unity; 821 classes `LevelCA*`, sendo 577 com 24.983 instâncias nos dumps por cena. Hashes, crosswalks e CSV em `out/recon/tasks/T035/`; resumo em `docs/RECON_ANIMATION_INVENTORY.md`. Nomes estáticos cobertos para fontes extraídas; handlers não revelam por si sós transições e efeitos completos. T035 continua parcial.
- 2026-11-05 — T035: `recon_contextual_links.py` varreu 878.040 registros e resolveu 5.704 referências por `(arquivo,path_id)` de 5.678 componentes. Ligou 894/974 assets de configuração e 66/71 de reação; 3.150 nomes-base presentes nos rigs correspondentes. Cache por hash reutiliza 239 tabelas externas sem descompressão; verificador reconstrói as identidades de todas as referências. Recuperadas 13 regras de sufixo (9 por PostureType, 3 `_Standing`, 1 `_Sitting` condicional) e comparação/seleção de nomes de reação em 33 janelas ARM64. Duas fontes de reação têm quatro entradas com diferenças de pasta/prefixo; alternativas registradas, dados originais preservados. Dossiê `docs/RECON_CONTEXTUAL_LINKS.md`, relatório completo em `out/recon/tasks/T035/contextual-links.json`. Próximo: ciclo add/remove/cancel/complete dos handlers básicos, nomes de reação e carregamentos indiretos. T035 permanece parcial; testes de aparelho continuam adiados.
- 2026-11-08 — T033: grafo de chamadas do pipeline de thumbs do editor recuperado por varredura determinística de `bl`/`b` em todo o binário (`tools/recon_callers.py`/`recon_call_targets.py`): a corrotina `AvatarMakerThumbsManager.AfterThumbsScaleDownAnimation` (`MoveNext`, `0x21ce8d4`) é a única chamadora de `AddItemSpritesOutsideAnyPack`, `FillSections`, `AddOwnedExpansionPacksThumbs`, `FilterByClaimedInventoryFlags` e `GetRelevantInventorySkins`. Duas descobertas novas: `AvatarSpineSkinsRestrictionsManager.IsSkinAllowed` (gate de compatibilidade por tamanho de avatar, não de compra) e `AvatarSpineDataManager`'s `MakerIncludedSkinsJson` (caminho confirmado no `global-metadata.dat`, mas sem `TextAsset`/JSON correspondente em `resources.assets` — 0 objetos `TextAsset` no arquivo —, `avatar-datapack.unity3d` nem nos JSONs de índice de recursos). A hipótese inicial de que `AddItemSpritesOutsideAnyPack` seria o mecanismo universal para itens "fora de pacote = grátis" **não se confirmou**: ela só roda num dos 4 ramos de um switch cujo valor despachado não foi determinado, e os valores 1/2/3 só coincidem com categorias de forma corporal específicas por `SpineType`, não com Camisa/Calça/Sapato/Acessório gerais. Onde a lista-base dessas categorias comuns é montada não foi localizado. `FilterByClaimedInventoryFlags` traçado parcialmente (confiança média): remove da lista exibida os itens premium (3 flags/11 skins) cuja flag não está reivindicada. Nenhum dos ~2.110 itens sem correspondência foi reclassificado. Evidências em `out/recon/tasks/T033/thumbs-pipeline-findings.json` e `pipeline-asm/`; dossiê atualizado em `docs/RECON_CLOTHING_GAP.md`. T033 continua parcial.
- 2026-11-08 — T035: ciclo adicionar/remover/cancelar/concluir recuperado via `CATargetExtensionMethods` (`AddCAHandlerAndUpdateGame`/`RemoveCAHandlerAndUpdateGame`/`PlayContextualAnimation`). Confirmado por chamadas de interface resolvidas + leitura manual das chamadas virtuais na vtable do próprio handler (identificações por posição/assinatura, não resolvidas por nome): adicionar faz gate de validade → `Contains` (evita duplicata) → `CAHandlers.Add` → setup de lock/animação → só então `OnAddedToTarget` (inferido, por último) → gate final que pode disparar uma corrotina `<MakeFishEatFood>d__16`. Remover é o inverso: `CAHandlers.Remove` (aborta se ausente) → `OnRemovedFromTarget` (inferido, chamado primeiro) → limpeza do lado do alvo. Cancelar (`OnInterruptOrEnd`) e concluir (`OnCompleteFullCycle`/`OnCompleteNotLooped`) são guardados por um contador de geração (`ContexualAnimationCounter`) que descarta callbacks obsoletos quando uma animação mais nova já começou; conclusão sem loop pode rechamar `PlayContextualAnimation` (repetição). Reconciliação das duas discrepâncias de reação: ambas são o mesmo padrão (dado de reação grava o nome já com prefixo `CA/` embutido; rig lista sem o prefixo), elevando a alternativa já encontrada de candidata para interpretação mais sustentada, sem alterar o verificador. Carregamento indireto: checagem negativa em `LevelCAItemHandlerWithData.GetData()` (referência serializada direta, sem busca por nome); os 85 assets órfãos continuam sem mecanismo identificado. Evidências em `out/recon/tasks/T035/ca-handler-lifecycle.json` e `lifecycle-asm/`; dossiê atualizado em `docs/RECON_CONTEXTUAL_LINKS.md`. T035 continua parcial; testes de aparelho continuam adiados.

## ETAPA "Avatar completo e funcional" — loop (iniciada 2026-11-04)

**Objetivo:** o avatar aparece e é editado de forma completa e funcional como no jogo original.
**Regras do loop:** um erro por ciclo; máximo 5 tentativas por erro (depois parar e escalar com: o que tentei, erro exato, 2 hipóteses); cada ciclo = Pensar → Agir → Observar (testes EditMode + build + aparelho/logcat) → Decidir. Instalação no aparelho exige o usuário tocar em "Instalar" (MIUI): só pedir quando houver algo novo a verificar.

**Estado verificado no aparelho (2026-11-04):** editor com layout do original (CharacterMenu), 400 itens reais (100 camisas/calças/sapatos/acessórios; `tools/avatar_catalog_build.py`), texturas carregadas sob demanda, miniaturas geradas do próprio avatar (~27 ms cada), atlas 2172/2172 sem avisos, 109 testes EditMode. Bug resolvido: texturas novas sem Read/Write (`ClothingTextureImporter`).

**Critério de conclusão (todos verificados no aparelho):**
- [~] C1 Cores: pele (62), olhos (33) e itens `_color` por tinta Multiply com a paleta General (115) + coluna de cores no menu — OK no aparelho para sobrancelhas (ciclos 1 e 3) e cabelo (ciclo 4). Camisa/calça/sapato/acessório já tinham itens `_color` de uma expansão por seleção explícita anterior (T033); ciclo 6 e sua continuação resolveram **todos** os demais itens `_color` dessas categorias (correção do `resolve()`, ver histórico). Falta validar no aparelho.
- [~] C2 Rosto/cabelo: olhos com cor, tom de pele (ciclo 1) e boca (100 opções, ciclo 2) OK no aparelho. Sobrancelhas (74, `_color` com tinta) OK no aparelho (ciclo 3). Cabelo frente (100 de 276 skins) + trás (99 de 188 itens) implementado no ciclo 4, AINDA NÃO verificado no aparelho.
- [~] C3 Categorias restantes: chapéu, jaqueta (outra sessão) + vestido, meias, acessório de costas, bochechas (ciclo 5) com save/renderização ligados. Falta validar no aparelho.
- [~] C4 Slots: vários avatares persistidos (adicionar/trocar/apagar). Adicionar/trocar já estavam prontos (`PlayerState.SwitchHumanSlot`, `AvatarSlotsScreen`, de sessão paralela); apagar era um botão central (lixeira, bate com o print `AvatarMakerLobby` 16.07.17/16.07.35) que só mostrava "nada para remover". Falta validar no aparelho.
- [~] C5 Menu: subcategorias (bug de duplicação corrigido, ver histórico) e miniaturas sem artefatos (não confirmado, sem aparelho). "Marcas" sem lastro encontrado para o editor de avatar (só achei "Brand" em handlers de loja/fotobooth de outras telas); não implementado por falta de evidência.
- [~] C6 Referência visual: `AvatarAppearance.CreateReferenceImagem13Preset()` reproduz chapéu de bombeiro, jaqueta vermelha e saia rosa com itens reais do catálogo; cabelo branco via tinta (índice 114 da paleta General). Falta validar visualmente no aparelho.
- [ ] C7 Qualidade: 0 erros no logcat, testes verdes, tempo de abertura medido. Licença do Unity conectou nesta sessão (diferente de tentativas anteriores) e achou um erro real de compilação (ver ciclo 10); processo de testes foi morto por pouca memória do sistema antes de rodar de verdade. Retomar quando pedido, não sozinho.
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
- (ciclo 5) Categorias restantes do CharacterCategoryType (C3): chapéu e jaqueta já tinham entrado por outra sessão em paralelo (upstream, 98 e 78 itens reais); este ciclo fecha o resto com Onepiece (vestido, 100 itens), Legs (meias, 100 itens) e, como bônus do mesmo enum original, BackA (acessório de costas, 28 itens — toda a pasta `back_c` do SUT) e FaceCheeks (bochechas, 100 itens). `tools/avatar_catalog_build.py` ganhou os 4 novos prefixos SUT; PNGs+.meta em Resources/AvatarSpine/Clothing, IDs em AvatarCatalogData.cs e manifesto por extração scoped local (fora do dump completo de 121k texturas da Fase 4a).
  - As categorias apareciam no menu (AvatarCatalog/AvatarEditorScreen) mas sem onde persistir ou renderizar: `AvatarAppearance` ganhou os 4 campos (Id, Clone, SameAs, Get/SetRaw, IsFullyValid, SanitizeInPlace) e `AvatarGpuRuntime` ganhou as 4 entradas em `CategoryLabels` (aplica anexo no esqueleto + botão de depuração) e na cópia bruta do snapshot de miniatura — mesmo padrão exato do chapéu/jaqueta. Criança/bebê recebem só o placeholder "sem peça" (`OnepieceNone`/`LegsNone`/`BackANone`/`FaceCheeksNone`) e a aba fica oculta, como chapéu/jaqueta.
  - Testes novos em `AvatarCatalogDataTests.cs` (contagem/unicidade das 4 categorias, placeholder oculto em criança/bebê); `EveryCatalogIdHasAManifestItemWhoseTexturesExist` já cobre as novas categorias por iterar `OptionsByCategory.Keys` genericamente. Testes não executados nesta sessão (backlog final combinado com o usuário). Sem aparelho: validação visual/tátil, preset do print (C6) e tempo de abertura/logcat (C7) continuam pendentes.
- (ciclo 6) Roupas `_color` com a mesma coluna: `COLOR_CATEGORIES` em `tools/avatar_catalog_build.py` ganhou Shirt/Bottom/Shoes/Accessory. Extração dedicada (`resources.assets`+`resources.assets.resS`, já presentes localmente, via UnityPy) de todos os itens `_color` dessas 4 categorias no SUT: 1.286 path_ids candidatos, 643 texturas realmente existentes no asset (a outra metade são path_ids "fantasma" do par duplo por template, já documentado). Dessas, só 5 itens tiveram TODAS as peças resolvidas com textura e dimensão corretas: `shirt_special_1177_color`, `bottom_special_1077/1078/1079_color` e `accessories_body_neck_515_color`; nenhum sapato resolveu. Adicionados manualmente ao catálogo/manifesto preservando byte a byte as outras categorias (a reexecução direta do gerador com cota alta inflava Chapéu/Jaqueta/Vestido/Meia/Boca/CabeloAtrás para além do já curado e commitado, e zerava Cabelo de novo pela mesma razão do ciclo 5 — descartado, não promovido).
  - A baixa taxa de resolução (5 de ~1.286 candidatos) sugere que a maioria dos itens `_color` dessas categorias tem peças faltando na extração atual ou dimensões de atlas incompatíveis; não investigado a fundo. Coluna de cores do editor já é genérica (decide só por `IsColorItem` do item selecionado), então os 5 itens já funcionam sem mudança de UI.
  - Testes novos em `AvatarColorTests.cs` (os 5 ids são itens de cor, aparecem nas categorias certas, tingem via `TrySelectItemColor`). Não executados nesta sessão (backlog final). Sem aparelho.
- (ciclo 6, continuação — investigação da baixa taxa de resolução) Causa raiz encontrada: toda peça com sufixo `_st` (788 ocorrências, só dentro de pastas `_color`, nunca fora) não tem página correspondente no `Avatar_Spine.atlas.txt` — **para item nenhum**, com ou sem cor. Não é falta de textura nem incompatibilidade de extração: é um tipo de peça auxiliar do jogo original (provável camada de sombra/template) que nunca foi assada no atlas deste cliente. `resolve()` tratava toda peça do item como obrigatória, então um único `_st` bastava para rejeitar o item inteiro.
  - Corrigido ignorando peças `_st` em `resolve()` (não bloqueiam, não entram no manifesto). Verificação isolada confirmou: dos 155 itens `_color` candidatos nas 4 categorias, **100% resolvem** sem a peça `_st` (antes: 77/155, dos quais 72 já existiam da expansão T033 e 5 vieram da primeira passada deste ciclo). Reexecução do gerador com a correção + mesma extração já feita adicionou os **78 itens `_color` restantes** (28 camisa, 21 calça, 21 sapato, 8 acessório), preservando as demais categorias byte a byte pelo mesmo motivo do ciclo 5/6 anterior (cota alta expõe itens já extraídos mas não curados em Chapéu/Jaqueta/Vestido/Meia/etc. e zera Cabelo).
  - Camisa/Calça/Sapato/Acessório agora têm, respectivamente, 1077/1000/1198/842 itens, todos os `_color` candidatos do SUT dessas 4 categorias resolvidos. Teste novo cobre a correção. Sem aparelho; sem investigar se as peças `_st` deveriam ser renderizadas de algum outro jeito (sombra?) — ficou documentado, não implementado.
- (ciclo 7) C4 (apagar slot): `AvatarMakerLobby` do original tem uma lixeira central (print 16.07.17/16.07.35, `docs/STORE_WORLD_UI_SPEC.md:40`), não uma por slot; `AvatarSlotsScreen.DeleteButton` já existia mas era um stub (só mostrava "Não há nada para remover."). Sem print/decompilação que prove a interação exata de seleção, escolhida uma regra própria autorizada pelo padrão já usado no próprio arquivo (`ShowKindPicker`): tocar na lixeira abre um seletor com os slots ocupados da aba atual (humano ou pet); tocar num remove na hora, cancelar fecha sem apagar.
  - `PlayerState.DeleteHumanSlot`/`HumanAvatarCount` novos: nunca deixa o jogador sem nenhum avatar (bloqueia apagar o último); apagar o slot ativo troca para outro restante antes (reaproveita `SwitchHumanSlot`). Pet não tem essa restrição (`RemovePet` já existia, só faltava UI). Aba de veículo mantém o aviso antigo (vaga comprada não é reembolsável aqui).
  - Teste novo cobre apagar slot não ativo, apagar o ativo (troca antes) e o bloqueio do último avatar. Não executado nesta sessão; sem aparelho.
- (ciclo 8) C5: `AvatarCatalog.CategoryHairBack` já era corretamente excluída de `AllMenuCategories` (ícone próprio da coluna) por ser só-aba de Cabelo (`TabGroups`); `CategoryHat`/`CategoryJacket` (adicionadas por outra sessão) não seguiram o mesmo padrão e ficavam **duplicadas**: ícone próprio na coluna (abrindo a categoria direto) + aba "Chapéu"/"Jaqueta" dentro de Acessório/Camisa (o mesmo item, dois caminhos). Removidas de `AllMenuCategories`, mesma correção que já valia para Cabelo-atrás; a coluna cai de 15 para 13 categorias.
  - Procurei por um sistema de "marcas" de roupa no código decompilado; só achei `Brand` em handlers de loja/fotobooth (`LevelCAKawaiiShopBrandPhotoBoothDropAreaHandler`, `...ShoeShopBrand...`), sem relação com o editor de avatar. Sem evidência de que o `CharacterMenu` original tenha algo assim; não implementado.
  - "Miniaturas sem artefatos": revisão estática de `Capture()`/`ThumbnailWorker()` não achou bug óbvio (restaura o item anterior em `finally`, limpa a RenderTexture); sem aparelho para confirmar visualmente. Fica aberto.
- (ciclo 9) C6: IDs do catálogo não têm metadado de cor/estilo, então a única forma de achar o chapéu/jaqueta/saia certos foi inspeção visual. Gerei folhas de contato (grade de miniaturas com rótulo do ID, `tools/venv` + Pillow, script descartável) para Chapéu (98), Jaqueta (78 primeiros) e Calça/Saia (80 primeiros) e comparei contra `assets/exemplo_jogo_original/imagem13.jpeg`: achei `hat_a_7` (capacete vermelho com emblema dourado) na primeira folha, `jacket_formal_6` (jaqueta vermelha sólida) conferido pela peça de torso, `bottom_formal_9` (saia rosa pregueada) na primeira folha.
  - Cabelo não tem essa inspeção: toda a categoria é um template cinza neutro tingido pela paleta General (mesmo mecanismo de sobrancelha). "Cabelo branco" = qualquer `Hair_Front/N_Color` + índice 114 da paleta (0.9647 RGB, mais próximo do branco puro; não há 1,1,1 exato nas 115 cores). Usei o estilo padrão (`Hair_Front/1_Color`) já que o chapéu cobre a maior parte da cabeça no print.
  - `AvatarAppearance.CreateReferenceImagem13Preset()` novo, `IsFullyValid()` confirmado. Teste cobre os 4 IDs e a cor. Não validado visualmente no aparelho (sem dispositivo nesta sessão) nem comparado lado a lado com o print renderizado de verdade — a inspeção foi por peça solta (textura recortada), não pelo boneco montado.
- (ciclo 10) C7, primeira tentativa real de testes: pela primeira vez nesta sessão a licença do Unity Editor (6000.6.6f1, Unity Personal) conectou com sucesso (`LicenseClient-c1c3ru`), diferente das falhas registradas em sessões/ciclos anteriores. `unity -batchmode -runTests -testPlatform EditMode` rodou de verdade (import completo da Library, ~2 min de compilação).
  - Achado real (não ambiente): `CharacterDragControllerTests.cs` falhava a compilação (CS0200) porque três testes atribuíam `_c.HasRunningAnimations = true/false`, mas o ciclo T032 (commit anterior desta mesma sessão) tornou a propriedade somente leitura (sempre `false`, pela evidência de que `LevelAnimal.HasRunningAnimations` nunca é `true` em nenhuma família recuperada). Erro meu: mudei a API sem atualizar o teste, e só agora consegui compilar de verdade para descobrir.
  - Corrigido: removidas as atribuições; `AnimalRunsOnlyWithRunningAnimations` (testava um comportamento que não existe mais via o componente público) foi substituído por `AnimalNeverRunsEvenAtHugeSpeed` — o ramo genérico de Run continua coberto direto em `LocomotionStateMachineTests.cs` (chamando `LocomotionStateMachine.Next` com `hasRunningAnimations=true` sem passar pelo componente), exatamente como o comentário do ciclo T032 já previa.
  - O processo de testes foi morto pelo próprio sistema (`CLAUDE_CODE_DISABLE_BG_SHELL_PRESSURE_REAP`) por pouca memória enquanto a sessão estava ociosa aguardando notificação — não é falha do Unity nem do projeto. Não tentei de novo sem pedir (instrução explícita do sistema). C7 segue aberto: não sabemos ainda se a suíte toda compila/passa, não há build nem aparelho nesta sessão.
**Próximos ciclos (backlog):** retomar os testes EditMode (C7), medir abertura e checar logcat quando houver aparelho.

### Retomada do ciclo 4 — 2026-11-07
- `adb devices -l` não retornou um dispositivo utilizável (consulta inicial vazia; nova tentativa bloqueada ao iniciar o daemon ADB por `Operation not permitted` no sandbox). A validação tátil e de renderização no Xiaomi não pôde ser feita nesta sessão.
- EditMode atualizado: XML `out/test-results-avatar-cycle4-resume.xml`, **313 total / 308 passed / 5 failed / 0 skipped**. As cinco falhas são de `AvatarSlotsTests`: quatro `KeyNotFoundException` para a categoria `Hat` ausente e uma expectativa de um slot, que recebeu zero. A suíte completa não está verde; não atribuo essas falhas ao cabelo sem investigação.
- O build Android foi tentado para `out/avatar-cycle4-resume.apk`, mas o Editor encerrou antes da compilação por falha de conexão com `LicenseClient-c1c3ru` (`out/unity-avatar-cycle4-resume-build.log`). O APK não foi produzido nesta tentativa.
- `git diff --check` passou. **Ciclo 4 continua aberto** até executar build e verificar no aparelho: grade Frente/Atrás, tintura, miniaturas traseiras e tempo de abertura.

### T025/T029 — efeitos dos cinco handlers já identificados (2026-11-08)
- Recuperados, por desassemblagem LLVM fixada por opcode e revalidação do índice metadata/codegen, os efeitos concretos dos cinco handlers de `RECON_SCENE_SUBSCRIBERS.md`: `BackgroundPlanetSoundHandler.OnBeforeSceneLoadStage1` cancela um LeanTween pendente (`_tweenId`, offset 0x58) e zera o campo; `PersistentDataManager.OnBeforeSceneLoadStage2` é um tail-jump de 4 bytes para `SaveProgressInAllScenes` (laço `SceneManager.GetSceneAt` + `SaveProgress(Scene)` por cena); `LevelManager.OnBeforeSceneLoadStage2` grava `IsAboutToLoadScene=true` (offset 0x3A); `LevelManager.OnBeforeSceneLoadStage3` zera o campo estático `GameSceneManager.CurrentSceneSuffix` (offset 0x18, via slot de uso de metadata/literal vazio); `GameSceneManager.OnActiveSceneChanged` zera `IsSceneChangingInProgress` (offset 0x30), `Multiplayer_LoadingSceneNameInProgress` (0x40) e `CurrentlyLoadingSceneName` (0x28).
- Fecha a pendência histórica "quem zera `IsSceneChangingInProgress`" de `RECON_NAVIGATION_CONTRACT.md` (2026-11-04): é `OnActiveSceneChanged`, confirmado por opcode e nome de campo do stub extraído.
- Evidência: `docs/RECON_STAGE_HANDLER_EFFECTS.md`, `reports/recon/stage_handler_effects_2026-11-08.json`, cinco filhos `out/recon/tasks/T025/HANDLER/<rid>/` (method-contract/control-flow/unknowns/result), produtor `tools/recon_stage_handler_effects.py`. Sete testes focados passaram (cinco mutações negativas + verificação dos cinco analisadores contra o par real + checagem dos arquivos de saída).
- Sem alteração do cliente, sem execução/emulação e sem aparelho. Os corpos dos callees nomeados (`LeanTween.cancel`, `PersistentDataManager.SaveProgress`, APIs Unity de cena) e os outros sete handlers do universo de doze MethodDefs únicos (do escaneamento de 13 registros Stage1-3) continuam sem efeitos recuperados. Tudo rotulado `static_candidate_not_runtime_validated`; nenhuma tarefa promovida a `done`.
- Trabalho feito em worktree isolado (`worktree-recon-stage-handler-effects`), a partir do commit `498a97809`. Não inclui/duplica alterações não commitadas que já existiam no checkout principal (ex.: `tools/recon_stage_handlers.py`/planejamento dos doze handlers, ou os pilotos `GetCurrentWorldSceneName`/`LoadSceneImplement`/`LoadPlayScene` em retomada) — essas permanecem como estavam, fora do escopo deste branch.
### Continuação RE — lifetime de eventos (2026-11-07)
- Quatro pares estáticos de inscrição/remoção confirmados em três OnDestroy: BackgroundPlanetSoundHandler Stage1, PersistentDataManager Stage2 e LevelManager Stage2/3. Mesmo MethodDef e alvo this; novo delegate construído na remoção.
- Evidência: docs/RECON_SCENE_LIFETIME_2026-11-07.md e reports/recon/scene_unsubscribers.json; reprodução com tools/recon_scene_unsubscribers.py.
- Sem alteração do cliente/fila e sem execução Android. Remoção efetiva, exceções, lifetime Unity estático e nove candidatos restantes seguem abertos. Próximo: efeitos dos handlers e semântica interna de remove/delegates.
- Verificação do recorte: 5 testes passaram em 16,317 s, sem falhas; produtor retornou zero (quatro pares / três janelas).

### T025 — auditoria e dois pilotos (2026-11-07)
- T025 permanece aberta: dependências T022–T024 pendentes, universo de 36.421 MethodDefs ainda não reconciliado em filhos (cinco existentes).
- Registros IL2CPP e joins genéricos recuperados: HashSet<string> ctor/Add/Contains, Dictionary.Clear de MPOwnership, campo MP estático 0 e cache 0x48. Evidência em reports/recon/t025_generic_bindings_investigation.json e revisão independente correspondente.
- GetCurrentWorldSceneName: 53 instruções no CFG normal local; errata fully_bounded=true corrigida para false no produtor. LoadSceneImplement: 47 instruções, guarda MP e overloads comprovados; efeitos transitivos e exceções abertos. Ambos com contratos reproduzíveis e checkpoint, sem done.
- 25 testes focados passaram em 10,588 s. Hopper falhou na bridge após 120 s, sessão fechada; sem decompilação/runtime. Próximo: recuperar corpos/erros/helpers dependentes, resolver pipeline de decompilação e expandir universo obrigatório sem reduzir aceite. Detalhes: docs/RECON_T025_COMPLETION_2026-11-07.md.
- Checkpoint final da rodada: fila revisão36; getter e implement ready, sem lease ativo; T025 pai pending. Auditoria final: reports/recon/t025_readiness.json. Revisões independentes finais em t025_getter_review.json e t025_implement_review.json; nenhuma semântica integral aprovada.

### T026 — máquina next-frame e sceneLoaded (2026-11-07)
- Filho T026/STATE_MACHINE/execute-next-frame importado e checkpoint ready (fila revisão43, próprio lease liberado). Pai T026 continua pending por T024/T025; nenhuma aprovação global.
- Oito métodos/offsets originais e oito entradas na tabela de transições: state0 yield null/1; state1 grava -1 antes de Action; outros retornam false. Dispose é no-op local, Reset constrói NotSupportedException e passa ao helper (throw inferido). Tempo/cancelamento Unity continuam externos.
- Hook LoadingScreenManager Awake/OnDestroy tem add/remove sceneLoaded por slot4 condicional, com ctor canônico registrado; sem provar runtime ou remoção efetiva.
- 16 testes passaram em19,580s, revisões estáticas independentes e git diff --check OK. Evidências/pendências em docs/RECON_T026_NEXT_FRAME.md e reports/recon/t026_checkpoint.json. Outra frente possui filho T025 em execução; seu lease foi preservado.
- Próximo recorte T026: contrato de StopCoroutine/host destruction ou outra máquina gameplay com wait/cancelamento, antes de fechar toda a tarefa.

### T026 — universo 449 e censo amplo (2026-11-08)
- Interfaces corrigem o histórico: 449 máquinas = 387 IEnumerator + 62 async; 12 tipos adicionais, 458 eventos e 1.147 candidatas a closure. Os 169 são apenas um subconjunto por prefixes; exclusões QA/lobby e demais escopos pendentes continuam explícitos.
- Fila: 449 filhos T026, com next-frame ready e 448 pending importados por coordenador concorrente na revisão 50. Reconciliação exata, sem duplicação ou remoção de dependências.
- Censo: 445 MoveNext, 411.168 bytes e 86.204 instruções. Quatro slots nulos preservados, com seis alternativas genéricas registradas em evidências separadas. Nenhum contrato semântico fabricado.
- Condition/timeout recuperado; oito wrappers do scheduler/11 icalls conferidos; docs Unity 2022.3 externas separadas. Passaram 43 testes novos em rodadas focadas. Evidências e revisões em reports/recon/t026_*.json.
- ADB confirmou versão instalada 1.228/code229; análise estática é 1.227/code228. Sem execução, reinstalação ou modificação de dados. A bridge Hopper não foi observada pronta após o último timeout; confirmação de licença/importação permanece pendente.
- T026 continua aberta: pai depende de T024/T025; novos filhos dependem de T022–T025. Faltam contratos completos, descoberta complementar e efeitos externos/exceções. Retomada: docs/RECON_T026_PROGRESS_2026-11-08.md e reports/recon/t026_acceptance.json. Atividade concorrente T025 preservada.

### T032 — dispatch, NPC e famílias (2026-11-08)
- Recuperados 21 virtuais, nove chamadas ILevelAvatar, duas IHasPersistentData e três closures de passo completas; Baby/Cat/Dog/Horse respeitam override de aterrissagem. Campo/assinatura dos callbacks Baby recuperados; atribuição CATargetEvents inferida por layout, com usage não canônico preservado.
- NPC caller reposiciona diretamente ou faz spawn. Managers de fundo animam sem navegação nos corpos examinados; walkway transporta itens por tween. Todos os 1.170 registros de 229 SceneAvatarMaps têm isOnPhone=true; position serve ownerPosition na restauração de roupas, não prova NPC já no mundo.
- Corrigidas inferências históricas: Animal HasRunningAnimations=false; Walk usa Forced_To_Walk na faixa0 sem lock e faixa1 com lock; cinco techs sem caminhada animada; Baby herda sync físico. Time.deltaTime confirmado para a velocidade animal.
- Evidências e revisões locais em out/recon/tasks/T032/{callbacks,npc,families}; contrato integrado em docs/RECON_T032_PROGRESS.md. tools/recon_t032_acceptance.py executa sete probes e revalida hashes/censos/estado, sem promover fila nem implementação.
- T032 permanece pending, dependências T018/T025/T026/T027/T031 pendentes. Runtime 1.227 não validado: Android instalado é 1.228/code229, apenas consultas de metadados. Sem alteração de cliente, instalação/downgrade ou dados. Integração T049 precisa reconciliar caminhada/overlay, capabilities e roteamento Baby/techs; ordem/cardinalidade/cancelamento de callbacks e receptores dinâmicos permanecem abertos.
