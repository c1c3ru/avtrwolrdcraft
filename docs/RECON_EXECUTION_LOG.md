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
