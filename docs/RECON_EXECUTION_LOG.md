# Execução da reconstrução — checkpoints e passos importantes

Este registro acompanha o [plano mestre](AVATAR_WORLD_MASTER_PLAN.md). Inventário, recuperação de lógica e implementação validada são marcos distintos. Nenhuma entrada abaixo declara o jogo completo.

## 2026-11-01 — primeira onda executada

1. Preservadas as mudanças preexistentes do cliente e os documentos de regras offline. Nenhum script desta onda alterou o cliente Unity ou saves.
2. Identificado um conjunto coerente de três APKs: pacote `com.pazugames.avatarworld`, versionCode 228, base versionName 1.227. Verificação das assinaturas pelo SDK retornou sucesso e os certificados coincidem. Isso não demonstra origem oficial nem paridade do clone.
3. Recontados os dumps: 879.085 linhas, 2.418 classes, 2.813 erros declarados e 126 classes com erro. Zero divergências de contagem ou identidades duplicadas dentro da mesma classe; a correção dos layouts e proveniência continua pendente.
4. Reconciliados 30 XMLs históricos. O resultado 71/71 existe, mas não prova o código atual: há fontes posteriores e falta manifesto source→build→teste.
5. Pareados `libil2cpp.so` e `global-metadata.dat` por hash, ELF AArch64 e metadata v31. Indexados estruturalmente 120.743 métodos de 96 imagens. Assembly-CSharp possui 36.421 registros, 35.831 ponteiros executáveis e 590 ponteiros nulos. Endereço conhecido não é corpo recuperado.
6. Obtidos os endereços de Play, scene manager e ClickOnLevel; cinco janelas de assembly por LLVM identificaram chamadas e tail branches. `GetCurrentWorldSceneName` possui contrato estático candidato com `GAME_CURRENT_WORLD` e fallback `LevelWorldType.World`, ainda sem validação runtime integral.
7. O REA abriu o binário correto por hash, mas a consulta nativa no Hopper expirou aguardando a bridge (120 s; possível diálogo de loader/licença). Não houve decompilação REA bem-sucedida. A sessão foi fechada e a análise local de bytes/metadata prosseguiu, sem contorno de proteção.
8. Implementada e inicializada uma fila local com 60 pacotes, inicialmente todos `pending`. Claims exigem configuração de inputs, lease e dependências; revisão independente e hashes impedem promoção automática. A implementação inicial não executa agentes em background.
9. Revisão independente aceitou o baseline T001 no escopo de identidade e registrou T002/T003/T005 como parciais. A fila ainda não tinha importado esse veredito quando a conversa foi interrompida.

Fontes: [baseline](RECON_BASELINE_WAVE1.md), [bootstrap IL2CPP](RECON_IL2CPP_BOOTSTRAP.md), [operação da fila](RECON_QUEUE_USAGE.md), [revisão independente](../reports/recon/review_wave1.json).

## 2026-11-02 — retomada após interrupção

- Conferidos git status, histórico e fila antes de executar. HEAD continuava em `420b2ae6`; o commit/push solicitado anteriormente ainda não havia ocorrido. Não foi presumido que a interrupção tivesse concluído essas ações.
- A fila estava na revisão 0 com 60 tarefas pendentes e nenhum lease ativo. Os artefatos da primeira onda continuavam presentes.
- A instrução anterior de pausa era até 15h de 2026-11-01, Fortaleza. A retomada de 2026-11-02 foi explicitamente solicitada pelo usuário.
- Nova divisão: um agente prepara filhos por cena/classe com falha; outro estende a fila para importar filhos com segurança; outro valida e aprofunda o contrato nativo da navegação. O integrador confere evidência, documenta e publica apenas o lote revisado.
- Os índices/binários grandes e cenas extraídas ficam fora do Git. Ferramentas, testes, contratos e relatórios pequenos permanecem versionáveis. A implementação preexistente do cliente não será incluída incidentalmente no commit deste lote.

### Próximos gates

1. Executar testes atuais da fila, do gerador de filhos e do piloto de navegação; conferir os inputs reais sem repetir extração completa.
2. Importar o aceite T001 para a fila apenas depois de reconferir as evidências de revisão; preservar pendências maiores de build/lógica/dumps.
3. Importar filhos de descoberta sem marcar cenas/métodos como concluídos e sem criar ciclos entre filhos e pais.
4. Documentar o contrato de navegação recuperado, limites e próximos alvos; persistir a lista residual de desconhecidos.
5. Fazer commit seletivo e push; registrar resultado real e hash. Um push falho não pode ser relatado como publicado.

### Resultado integrado desta retomada

- **T001 importada e aceita:** baseline de identidade, com veredito independente existente revalidado por hash. Isso não conclui build, dumps, lógica ou paridade.
- **387 filhos importados:** 254 cenas, 126 classes com falha, dois pré-requisitos nativos estreitos e cinco métodos piloto. Somados aos 60 pais, são 447 tarefas. Nenhuma cena ou método foi concluído pela importação.
- **Dois filhos estreitos aceitos por revisão independente:** identidade do par native/metadata e cinco joins token/owner/endereço. Os pais T021/T022 e a recuperação semântica permanecem abertos. A fila ficou na revisão 16: **3 done, 444 pending**, sem lease ou pausa ativa. Essas contagens não são percentual de completude do jogo.
- **Navegação aprofundada:** recuperado contrato estático candidato do getter do mundo salvo; ampliadas as âncoras de disponibilidade, scene manager e loading. Genéricos da coleção, callbacks, dispatch virtual, exceções e efeitos Unity ainda exigem análise/validação.
- **73 testes passaram** na execução integrada: 17 do gerador, 25 de navegação e 31 da fila; duração observada 2,456 s. A revisão independente verificou adicionalmente 12 mutações negativas. Esses testes exercitam ferramentas/contratos estáticos; não são testes do jogo completo nem substituem Android.
- **Importação com leitura única de cada input:** o lote de 387 filhos verificou oito paths únicos por SHA-256 na operação. Antes do commit da fila, alterações de fingerprint/resolução de paths são rejeitadas. A importação efetiva levou 0,670 s; a verificação temporária anterior, com releituras por filho, havia levado 38,632 s. Não é um benchmark controlado, mas a redução de leituras foi verificada por teste.
- **ADB:** a primeira consulta no sandbox falhou por bloqueio de socket local; a repetição autorizada no host concluiu e listou zero dispositivos. Nenhuma instalação, captura, replay, build ou teste Unity foi executado nesta rodada.

Relatórios: [checkpoint integrado](../reports/recon/wave2_checkpoint.json), [revisão nativa independente](../reports/recon/review_navigation_wave2.json), [contrato de navegação](RECON_NAVIGATION_CONTRACT.md), [filhos de descoberta](RECON_DISCOVERY_CHILDREN.md).

Comandos principais executados:

```bash
python3 -m unittest discover -s tools -p 'test_recon_*.py' -v
python3 tools/recon_queue.py import-children --manifest reports/recon/discovery_children.json \
  --actor /root --note 'Expansão inicial delimitada e revisada'
python3 tools/recon_queue.py status
adb devices -l
```

Os vereditos foram registrados pela API da fila depois de conferir evidências reais; o histórico persistido guarda autores, revisão, hashes e escopo. Resultados aceitos não devem ser sobrescritos por uma nova coleta: versionar entradas/saídas antes de atualizá-las, ou os gates corretamente bloquearão dependências com hashes obsoletos.

Próxima investigação: fechar os callees genéricos de `IsSceneAvailable`, os delegates/closure de `LoadScene` e o destino virtual do loading; seguir os cinco filhos de método liberados sem marcar seus pais como completos.

### Publicação Git confirmada

- Commit de ferramentas, contratos e fila: `2aa88455ba02a4179d71c8f6216dc678a05e2508`.
- `git push origin main` concluiu com código zero, atualizando `420b2ae6 → 2aa88455`.
- O recibo estruturado está em `reports/recon/wave2_checkpoint.json`; esta entrada integra um commit documental posterior.
- Nenhum APK, binário IL2CPP, dump pesado ou alteração preexistente de código do cliente foi incluído nesse lote.

## 2026-11-02 — publicação das alterações preexistentes, autorizada depois

O usuário solicitou também publicar o trabalho preexistente e, em seguida, parar. A revisão incluiu loading, Home/Settings, loja gráfica, economia local, presentes/passe, testes, gerador de previews e exportação seletiva de UI. Scripts, assets runtime necessários e respectivos `.meta` entram no novo lote; o export intermediário `out/store-ui-export/` fica ignorado, assim como APKs e caches.

- Revisão independente não identificou bloqueio de correção ou PNG/meta obrigatório ausente. Continua pendente a seleção visual do subasset do loading importado como Multiple; os testes da Home não certificam sua paridade visual.
- A execução atual produziu `out/test-results-preexisting-review.xml`: **72 testes, 72 Passed, zero failed/skipped**, de 22:05:24Z a 22:05:25Z. O processo CLI foi interrompido posteriormente e retornou 130; o XML completo já estava gravado. O resultado dos testes é reportado pelo XML, sem afirmar término normal da CLI.
- A evidência Android/APK anterior está em `STORE_VISUAL_VALIDATION_2026-11-02.md`; esta publicação não executou uma nova instalação/reprodução em aparelho.
- `git diff --check` passou. O recibo de revisão em `reports/recon/client_publication_review.json` vincula os arquivos deste lote e o XML por hash.
- Após commit e push deste lote, a execução será encerrada por instrução explícita do usuário; nenhum novo lote de engenharia reversa será iniciado.

## 2026-11-07 — fechamento da pendência de publicação

- Conferido o histórico após a interrupção: as alterações preexistentes da loja, presentes/passe, loading e testes já foram publicadas no commit `277b07d4b328f167e3321e546f479d6196fa919b`.
- Uma alteração posterior, `87f72dc76`, reverteu o protótipo de loja gráfica/loading. Essa reversão faz parte do estado atual e não deve ser anulada por uma retomada baseada nas notas antigas.
- `git ls-remote origin refs/heads/main` confirmou `8fa788b4d45feed47818cafecf2bcc85b9bb40c3`, igual ao HEAD local antes desta anotação. A consulta precisou ser repetida no host porque a resolução DNS falhou no sandbox.
- Existem alterações posteriores de catálogo/avatares, assets de roupas e movimento do mapa no workspace. Não fazem parte da antiga pendência de publicação; foram preservadas sem inclusão incidental em commit.
- A tarefa anterior de publicar as alterações preexistentes está concluída. Esta retomada apenas registra o desfecho; não restaura funcionalidades revertidas, não executa novos testes do jogo e não inicia outro lote de implementação.

## 2026-11-07 — nova continuação: loading e assinantes de cena

Após nova instrução explícita para continuar, retomada a recuperação da lógica original de navegação. O workspace contém alterações de catálogo/roupas/editor/mapa em andamento; este lote de análise mantém esses arquivos fora de sua edição e de seu commit.

1. Conferidos fila, contratos e ferramentas já existentes, incluindo callback de `LoadScene`, deep links e save. O callback já analisado em 03/11 não foi refeito como se fosse uma descoberta nova.
2. `prepare` detectou que a fila ainda apontava para `/home/deppi/avatarworld-re`, ausente neste host. Usado `relocate --root /home/c1c3ru/avtrwolrdcraft`, que revalidou 17 referências aceitas e registrou revisão 21. Nenhum hash ou aceite foi alterado para ignorar o erro.
3. Preparado o filho `T025/METHOD/8e708ca7d06e0b52` (`GameSceneManager.LoadScene`), sem bloqueadores e com os inputs conferidos. Adquirido lease para a investigação limitada dos callees de loading e das inscrições em eventos; o corpo inteiro permanece sujeito ao aceite original.
4. Reutilizados o par IL2CPP/metadata e os índices existentes. O Hopper já tinha bloqueio de bridge registrado; não foi repetido o timeout sem mudança desse bloqueio. As novas evidências são de leitura estática local/LLVM, não de decompilação REA bem-sucedida nem execução Android.
5. Uma frente recupera o binding do método virtual de fade e os callbacks; outra identifica inscrições concretas nos estágios de troca de cena. A revisão independente usa os bytes e metadata originais, além dos relatórios finais. Outputs volumosos ficam em diretórios locais exclusivos.

### Resultado e checkpoint

- Resolvidos, para o prefab distribuído e sob as precondições documentadas, os slots de `LoadingScreenScreen.Fade` e `Graphic.set_raycastTarget`. Manager 259 → screen 242 e os scripts foram revalidados nos bytes serializados originais.
- Recuperado o fluxo estático de alpha 1/0 com argumento de duração 0,25, atualização do CanvasGroup, completion true com Action opcional e completion false com cancelamento do clock e destruição da tela. A coroutine posterior ao carregamento possui um `yield null` antes do fade de saída. Isso não mede tempo real nem prova toda a interação com Unity.
- Confirmadas cinco inscrições: som no Stage1, persistência no Stage2, LevelManager nos Stage2/3 e `OnActiveSceneChanged` no evento Unity. O scan contém 13 candidatos diretos dos estágios; quatro foram aprofundados e nove permanecem abertos. A quinta ligação positiva é a Unity e está fora desse conjunto.
- **30 testes focados passaram:** 21 de loading/fade (2,293 s) e nove de assinantes (9,667 s). A revisão independente rejeitou oito mutações adicionais e aceitou a evidência estática parcial sem bloqueios no recorte declarado.
- Salvo checkpoint retomável no filho de LoadScene, estado `ready`, com oito grupos de desconhecidos explícitos. A fila ficou na revisão **27**: 3 `done`, 442 `pending`, 1 `stale`, 1 `ready`; nenhum lease ativo. Nenhum método inteiro ou pai foi concluído por esse recorte.
- Próximas investigações: os nove candidatos de registro restantes, remoções/lifetime/efeitos dos handlers, hook de OnSceneLoaded, bibliotecas/helpers/exceções, comportamento temporal/input e comparação em runtime.

Fontes: [contrato loading/fade](RECON_LOADING_FADE_CONTRACT.md), [assinantes de cena](RECON_SCENE_SUBSCRIBERS.md), [revisão independente](../reports/recon/review_loading_subscribers.json) e [checkpoint estruturado](../reports/recon/loading_wave_checkpoint.json).

Comandos de verificação desta rodada:

```bash
python3 tools/recon_queue.py prepare T025/METHOD/8e708ca7d06e0b52
python3 tools/recon_loading_fade.py
python3 tools/recon_scene_subscribers.py
python3 -m unittest discover -s tools -p test_recon_loading_fade.py -v
python3 -m unittest discover -s tools -p test_recon_scene_subscribers.py -v
```

O produtor de loading verifica os hashes dos APKs e só materializa a entrada UnityFS selecionada, com 726.336 bytes; o bundle inteiro não foi redumpado. Os índices nativos e as evidências anteriores foram reutilizados. Nenhuma execução Android, build Unity ou alteração no cliente integra este lote. Commit e push deste recorte são feitos depois dessas verificações; resultados de publicação são confirmados pelo Git.
