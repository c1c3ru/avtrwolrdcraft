# Avatar World — plano mestre de varredura, recuperação de lógica e reconstrução

Versão 1, 2026-11-01. Documento operacional principal. Complementa o [plano inicial](AI_AGENT_REVERSE_ENGINEERING_WORKPLAN.md), preserva seu escopo offline e incorpora o [mapeamento recente](REA_NAVIGATION_MAPPING_2026-11-01.md). Este documento especifica o trabalho; não significa que o orquestrador, os agentes ou a reconstrução completa já estejam executados.

## 1. Resultado esperado e significado de 100%

Construir uma cópia funcional offline do Avatar World v1.227 encontrado nos APKs locais: navegação, mundos, ambientes, avatares, objetos, interações, animações, áudio, menus, progresso e persistência. Preservar o visual e o comportamento observável do original dentro do escopo declarado. A atividade pedagógica continua opcional para ganhar moedas e nunca substitui Play.

Manter três marcos independentes:

| Marco | Condição necessária | O que não basta |
| --- | --- | --- |
| V — Varredura completa | Todos os artefatos, cenas, scripts, métodos, controles, formatos e integrações classificados, com desconhecidos identificados | Contar só símbolos exportados, classes ou cenas |
| L — Lógica recuperada | Todo comportamento local obrigatório especificado e sustentado por código/dados e validação adequada; métodos e dependências rastreados | C# vazio, nome de função, pseudocódigo sem contrato, microteste parcial |
| C — Cópia offline validada | Todas as funcionalidades locais obrigatórias implementadas, conteúdo integrado, cenários comparados e APK validado | Menus responsivos, única sala, painel textual ou aviso de indisponibilidade |

Não afirmar equivalência universal: testes finitos não a provam. “100%” sempre informa versão, hash, domínio, plataformas e divergências. Classificar tudo não equivale a recuperar tudo; recuperar não equivale a implementar; implementar não equivale a validar.

Backend, multiplayer online, login/cloud, pagamentos reais, flags remotas e conteúdo não presente nos artefatos não podem ser recuperados integralmente apenas do APK. Mapear o contrato cliente desses recursos e registrar a ausência. A cópia seguirá as regras offline já autorizadas em [OFFLINE_HOME_RULES.md](OFFLINE_HOME_RULES.md). Uma substituição local pode cumprir o requisito do produto, mas não aumenta o contador de paridade original daquele serviço. Manter todos esses itens visíveis no denominador do inventário completo e em uma categoria de divergências; não excluí-los silenciosamente para chegar a 100%.

Não contornar PairIP/licença, não sondar endpoints, não fazer compras/login reais e não publicar conteúdo automaticamente. Análise, implementação, testes e build locais podem prosseguir autonomamente no escopo autorizado. Configuração fora do workspace, ferramentas ausentes e permissões de sistema seguem as restrições reais do ambiente.

## 2. Ponto de partida: aproveitar antes de desenvolver

| Área | Já existe / evidência | Situação e trabalho restante |
| --- | --- | --- |
| Identidade da base | APK SHA-256 `c7edf76ff14254ecab9dc4162962f5d49d8e13be6e2e74e38f7d992f8c77ca07`; inventário REA exportado | Base identificada; reconciliar todos os splits, binário, metadata e dumps |
| Cenas | 254 paths em BuildSettings, lidos do APK | Lista concluída para a base; hierarquias/comportamentos completos ainda parciais |
| Navegação estática | 115 edifícios, 101 entradas, joins únicos com cenas; 115 vínculos de GameObject revalidados | Reutilizar `tools/map_world_navigation.py`; faltam corpos, condições, retornos e zonas |
| Mapas | Seis mapas candidatos e duas bases de editor com WorldManager | Componentes catalogados; nome ↔ arquivo serializado ainda precisa vínculo independente |
| MonoBehaviours | `_stats.json`: 2.418 classes e 126 classes com erro; README relata 879.085/881.898 objetos decodificados | Recalcular as contagens diretamente antes de usá-las; fechar erros por classe e objeto |
| IL2CPP | `out/cpp2il/DiffableCs` contém tipos, campos, enums e assinaturas | Corpos consultados de navegação estão vazios; falta recuperar código real e endereços |
| Assets/Spine/SUT | Extração, probes, pipeline, empacotador e editor parcial | Reusar tudo; resolver ambiguidades e completar catálogo, animações e comportamento |
| Cliente Unity | Home, avatar, quiz, quadra, som, save e testes já implementados em parte | Validar revisão atual; protótipo não equivale ao jogo inteiro |
| Economia offline | Regras autorizadas, serviço/testes e status com 71/71 testes e compra Android relatados | Reusar entregas; conferir logs/revisão sem refazer a economia existente |
| Testes Android/Unity | Relatórios históricos em LOOP_STATE e docs | Vincular ao commit/APK exatos; mudança de fonte invalida só evidência dependente |
| Automação | `avatar_pipeline.py` e ferramentas por cena | Pipeline de avatar existe; orquestrador global abaixo ainda é tarefa |

O cache atual do pipeline de avatar usa caminho/tamanho/mtime, conforme sua documentação. Não tratá-lo como cache criptográfico de toda a investigação. Não substituir a automação existente por outra sem primeiro avaliar extensão e compatibilidade.

Preservar as alterações locais existentes, inclusive HomeActions, HomeBootstrap, LoadingScreenView, OfflineHomeService, testes e documentos. Existência de arquivo não comprova funcionamento. Notas antigas, como NOT_REPRODUCED, contêm limites que podem ter sido superados; reconciliar datas e artefatos em vez de apagar o histórico.

A atualização de 2026-11-01 do status informa 27 controles exportados conectados, ação adicional ao GiftBadge (28 bindings), 12 controles pendentes, 71/71 testes EditMode e compra local de Passeio validada no Android. Esses resultados são relatos/evidências existentes, não testes reexecutados na preparação deste plano. T003 deve vincular seus logs/XML/APK à revisão correta; não usar as tabelas históricas posteriores de 35 pendentes para reiniciar trabalho já feito.

## 3. Organização de agentes e recursos

| Papel | Responsabilidade | Escrita permitida |
| --- | --- | --- |
| Coordenador | Inventário canônico, fila, prioridade, leases, integração e critérios | Manifestos e fila; nunca delegar a si mesmo uma aprovação fictícia |
| Agente de artefatos | APK/splits, UnityFS, cenas, referências e parsers | Relatório exclusivo da tarefa e ferramentas isoladas |
| Agente de lógica | IL2CPP, chamadas, contratos e pseudocódigo | Dossiês por método/componente, sem editar manifestos compartilhados |
| Agente de comportamento | Fluxos, estado, roteiro original e diferenças | Cenários/fixtures, com exclusividade de dispositivo |
| Agente de implementação | Código próprio para a fatia especificada | Branch/worktree isolada ou patch exclusivo |
| Agente de validação | Revisão independente de contratos, testes e paridade | Vereditos e bugs; não aprovar a própria implementação |

Usar tantos papéis quanto houver slots reais, não um processo por papel necessariamente. Com quatro slots, reservar o coordenador e até três workers; reduzir concorrência por RAM, não aumentar por pressa. Um worker pode assumir outro papel em tarefa diferente; a revisão da mesma evidência deve ser independente.

Compartilhar artefatos imutáveis por referência/hash. Um único dono por arquivo comum e por fila; cada worker grava `out/recon/tasks/<task-id>/<attempt-id>/`. Exclusividade também para dispositivo, Unity no mesmo projeto, banco de análise mutável e extração pesada. Não abrir várias instâncias Unity no mesmo checkout. Não lançar múltiplas análises que disputem o mesmo banco do REA.

## 4. Loop obrigatório de cada tarefa

Estados: `pending → ready → leased → running → evidence_ready → review → done`. Alternativas: `failed_retryable`, `blocked_external`, `needs_input`, `stale`, `rejected`. Estado atual da tarefa e maturidade herdada são campos diferentes.

1. **Selecionar:** dependências concluídas ou interfaces explicitamente disponíveis; escolher tarefa que desbloqueia mais funcionalidades ou fecha uma fatia, ponderando custo real e incerteza.
2. **Adquirir lease:** gravar dono, revisão/hash de entrada, paths permitidos, recurso exclusivo e prazo/heartbeat. Retomada de lease expirado verifica processo vivo e outputs antes de reassumir; não mata nem apaga trabalho alheio.
3. **Ler pacote mínimo:** objetivo, contrato, trechos relevantes, referências de evidência e última tentativa. Não enviar histórico inteiro nem o dump completo.
4. **Auditar existente:** identificar o que já satisfaz o aceite. Reusar evidência válida, marcando a porção restante. Invalidar só dependentes de inputs alterados.
5. **Planejar uma hipótese:** pergunta concreta, menor ferramenta que resolve, resultado esperado e condição de falha. Para REA usar ferramenta disponível e identidade correta; não repetir readiness/setup sem bloqueio observado.
6. **Executar lote limitado:** analisar, recuperar contrato ou implementar a menor unidade revisável. Registrar comandos, duração, ferramentas, retorno, hashes e arquivos.
7. **Validar:** verificação estrutural, diferencial, teste de estado ou runtime conforme o tipo. Separar passos que apenas compilaram dos que reproduziram comportamento.
8. **Revisar:** worker independente verifica evidência, caminhos desconhecidos e aceite. O coordenador integra só os resultados aceitos e atualiza o ledger atomicamente.
9. **Persistir checkpoint:** resumir descobertas, código, cobertura, bloqueio e próximo passo específico. Após interrupção, continuar desse ponto, sem reiniciar a tarefa.
10. **Avançar ou mudar hipótese:** sucesso fecha somente o escopo comprovado. Falha produz diferença mínima reproduzível e novo passo; não repetir comando idêntico sem mudança relevante.

Depois de três tentativas sem progresso sob a mesma hipótese/erro, estacionar a tarefa com diagnóstico e seguir tarefas independentes. Isso não encerra a meta nem aprova o item: o coordenador agenda outro método ou aguarda o recurso exato. Nunca usar um loop infinito de “tentar novamente” nem “até passar” alterando o teste para aceitar o defeito.

O loop global termina apenas quando todos os filhos obrigatórios descobertos estão aceitos, não há `unknown` obrigatório, filas de revisão/bugs estão vazias e o gate final passa. Se só restarem bloqueios externos, gerar checkpoint e estado `blocked_external`; não declarar concluído. Autonomia entre sessões exige executor persistente real: um documento ou prompt sozinho não mantém processos ativos.

## 5. Economia de tokens e tempo

- Fazer indexação mecânica uma vez: métodos, classes, strings, referências, assets e cenas ficam em SQLite/JSONL pesquisável; agentes pedem consultas pequenas.
- Chave do cache: hash do input + versão/configuração da ferramenta + schema/consulta. Hashes grandes por streaming uma vez por revisão; tamanho/mtime servem como filtro rápido, não como prova de identidade.
- Identidade do método: hash do binário + módulo + token/definição metadata + instanciação genérica quando aplicável + endereço/intervalo. Endereço sozinho não identifica método entre versões.
- Identidade do objeto: hash do bundle + arquivo serializado + path_id; resolver também fileID/GUID externos. Nome e path_id isolado são insuficientes.
- Agrupar por bloco comprimido, família de componentes e dependências. Implementar lógica compartilhada uma vez, mas verificar diferenças de dados/override em cada variante.
- Produzir resumos curtos para o coordenador, com ponteiros a arquivos; detalhes ficam no disco. Usar compactação de contexto por tarefa, sem eliminar desconhecidos.
- Decompilar sob demanda em lotes pequenos; conservar assembly/bytes e Evidence IDs. Pseudocódigo truncado não é evidência completa; paginar/exportar.
- Começar pelas dependências de Home→mapa→ambiente→retorno, não pelas funções mais fáceis para inflar porcentagem. Depois expandir todos os filhos do universo inventariado.
- Rodar testes diretamente afetados primeiro; gates de integração por fatia e regressão completa antes de fechar release. Repetir teste verde só com mudança ou dúvida nova.
- Registrar custo real por família (tempo, RAM, tokens quando disponíveis), estimar pacotes pelo histórico e dividir os que excederem uma janela operacional. Sem inventar estimativas de prazo.

## 6. Entregáveis e contratos de dados

`reports/recon/` guarda índices pequenos/versionáveis, fila e sínteses; `out/recon/` guarda evidência volumosa/derivada. O layout abaixo é **proposto**, não já implementado:

```text
reports/recon/baseline.json
reports/recon/scope.json
reports/recon/tasks.json
reports/recon/methods.jsonl
reports/recon/components.jsonl
reports/recon/scenes.jsonl
reports/recon/features.jsonl
reports/recon/unknowns.jsonl
reports/recon/divergences.jsonl
reports/recon/coverage.json
out/recon/tasks/<task-id>/<attempt-id>/
out/recon/evidence/<content-hash>/
```

Uma tarefa possui `id`, `parent_id`, `role`, `dependencies`, `baseline_maturity`, `state`, `input_refs`, `allowed_paths`, `resource_locks`, `questions`, `steps`, `outputs`, `acceptance`, `evidence_refs`, `unknown_ids`, `attempts`, `owner`, `lease`, `review` e `next_action`. Não colocar `done` no estado inicial apenas por haver um documento.

Cada afirmação recebe `STATIC`, `OBSERVED`, `INFERRED`, `UNKNOWN` ou `DESIGNED_OFFLINE`. Evidência registra ferramenta, comando, versão, data, hash, localização, escopo, resultado e limitações. REA Evidence é somente a retornada pelo REA; resultados de UnityPy/ADB/scripts recebem a proveniência real.

Contrato por método: assinatura/ABI, bytes/intervalos, CFG, argumentos/retorno, registradores relevantes, campos/offsets, memória, efeitos, callees/callbacks, exceções, coroutine/async, estado antes/depois, entradas inválidas e critérios de término. Incluir código reconstruído e testes quando exigidos pelo marco C.

Contrato por funcionalidade: cena/controle/gesto → handler → regra → dados/estado → efeitos visuais/áudio → persistência → saída/retorno; requisitos originais e divergências offline separados.

Os 60 pacotes abaixo são pais. A conclusão exige filhos gerados por inventário, sem limite artificial de “60 tarefas”. Exemplo: `T022/METHOD/<module-token-instantiation>`, `T042/SCENE/<scene-id>`, `T035/COMPONENT/<type-id>`, `T056/SCENARIO/<scenario-id>`. Cada filho herda o protocolo e tem IDs de evidência específicos. O pai só fecha depois de uma reconciliação completa do seu conjunto de filhos.

Catálogo inicial para leitura por agentes: [AVATAR_WORLD_TASKS.json](AVATAR_WORLD_TASKS.json). Ele contém os 60 pacotes, dependências, maturidade, passos, saídas e aceite. É uma semente de planejamento, não uma fila já conciliada ou um scheduler executável. T007–T012 devem importar a semente, gerar os filhos e preencher paths/locks/claims específicos antes da execução concorrente.

## 7. Backlog de execução

Maturidade: `partial` = existe trabalho aproveitável; `unverified` = existe indicação/implementação, aceite atual não comprovado; `planned` = proposta sem entrega demonstrada. Todos os estados operacionais iniciais são `pending`, aguardando reconciliação; isso não apaga a maturidade herdada.

### Fase A — Fixar o alvo e reconciliar o trabalho

#### T001 — Baseline de APKs, splits e revisão do cliente

- **Papel / dependências / maturidade:** artefatos; nenhuma; partial.
- **Entradas e execução:** `assets/*.apk`, `apk/`, git status e fontes Unity; calcular hashes/tamanhos por streaming, comparar cópias, identificar package/versionCode/versionName/ABI e registrar alterações preexistentes. Preservar originais e saves.
- **Saída:** `baseline.json`, mapa de cópias e manifesto de revisão do cliente, sem credenciais.
- **Aceite:** cada análise aponta para um conjunto APK/splits coerente; nenhuma mistura silenciosa de versão ou revisão.

#### T002 — Matriz de funcionalidades e escopo

- **Papel / dependências / maturidade:** coordenador; T001; partial.
- **Entradas e execução:** docs atuais, SceneType, catálogo e regras autorizadas; enumerar recursos locais, integrações online, conteúdo ausente e extensões pedagógicas. Registrar política por recurso: paridade, adaptação offline ou ausência externa.
- **Saída:** `scope.json`, `features.jsonl`, `divergences.jsonl` com domínio e plataformas.
- **Aceite:** nenhuma exclusão oculta; mudanças de preço/recompensa não são confundidas com regra recuperada.

#### T003 — Reconciliar evidências e implementação existentes

- **Papel / dependências / maturidade:** validação; T001–T002; partial.
- **Entradas e execução:** LOOP_STATE, status, probes, testes/XML/logs, builds e código atual; classificar cada entrega em válida, parcial, histórica, obsoleta ou não verificável; extrair o restante exato.
- **Saída:** matriz requisito→entrega→evidência→revisão, tarefas já satisfeitas e lacunas.
- **Aceite:** nenhuma tarefa manda refazer extração/build/probe válido; teste antigo não aprova fonte modificada.

#### T004 — Inventário de ferramentas e capacidade real

- **Papel / dependências / maturidade:** artefatos; T001; partial.
- **Entradas e execução:** REA, Cpp2IL, UnityPy, Unity/Android, decompilador nativo; consultar disponibilidade e versões. Identificar capacidade por operação, licença, host e entradas. Planejar reparo só do bloqueio observado.
- **Saída:** matriz capacidade→ferramenta→comando→limites e ambiente reproduzível.
- **Aceite:** rota suportada para inventário e recuperação nativa, ou bloqueio exato registrado; sem instalar/alterar configuração global silenciosamente.

#### T005 — Proveniência dos dumps e falhas de decodificação

- **Papel / dependências / maturidade:** artefatos; T001, T003; partial.
- **Entradas e execução:** `_stats.json`, gzip, metadata e scripts do dump; recalcular objetos/classes/sucessos/erros, conferir schema e campos alinhados, identificar as 126 classes com erro e inputs originais.
- **Saída:** cobertura por classe/objeto e fila de correção com exemplos mínimos.
- **Aceite:** toda linha reaproveitada tem identidade/proveniência ou rótulo de não verificada; totais reconciliados sem duplicar objetos.

#### T006 — Congelar decisões e contratos de compatibilidade

- **Papel / dependências / maturidade:** coordenador; T002–T005; partial.
- **Entradas e execução:** salvar regras existentes de economia, formato de save, versões Unity original/cliente e assets licenciados no workspace; documentar diferenças intencionais e restrições técnicas observadas.
- **Saída:** contratos versionados e lista de decisões ainda necessárias.
- **Aceite:** agentes podem implementar interfaces sem inventar políticas; perguntas ficam limitadas a decisões não autorizadas ou recursos externos necessários.

### Fase B — Preparar o loop autônomo e o ledger

#### T007 — Schemas e ledger de evidência

- **Papel / dependências / maturidade:** coordenador; T006; planned.
- **Entradas e execução:** contratos da seção 6 e formatos atuais; criar schemas e migração/importação, IDs estáveis, validação e escrita atômica; distinguir metadados, prova de comportamento e implementação.
- **Saída:** schemas, ledger inicial e validador.
- **Aceite:** rejeitar referências inexistentes, hashes incompatíveis, duplicidade e promoção sem aceite; preservar dados históricos.

#### T008 — Indexação incremental e cache por conteúdo

- **Papel / dependências / maturidade:** artefatos; T007; partial.
- **Entradas e execução:** pipeline de avatar, scripts existentes, catálogos e dumps; estender armazenamento pesquisável e cache com dependências transitivas, ferramenta/config/schema e invalidação seletiva.
- **Saída:** índices locais e subcomandos de consulta/extract/report compatíveis com ferramentas existentes.
- **Aceite:** segunda execução sem mudança reaproveita resultados; mudança de metadata invalida dossiês afetados; saída ausente/corrompida não dá cache hit.

#### T009 — Scheduler, leases e locks de recursos

- **Papel / dependências / maturidade:** coordenador; T007–T008; planned.
- **Entradas e execução:** DAG dos pacotes e recursos disponíveis; implementar fila pronta, leases, heartbeat, dono, limites de RAM/processos e exclusividade de Unity/dispositivo/banco REA.
- **Saída:** executor retomável e journal de transições.
- **Aceite:** dois workers não assumem a mesma tarefa; interrupção preserva outputs; recurso ocupado faz esperar/reagendar sem apagar lock ativo.

#### T010 — Gerador de filhos e prioridade

- **Papel / dependências / maturidade:** coordenador; T009; planned.
- **Entradas e execução:** inventários disponíveis e novos resultados; expandir filhos por método, componente, cena e cenário; priorizar desbloqueio, risco e fatia jogável; incorporar descobertas tardias.
- **Saída:** fila com IDs canônicos, vínculos pai/filho e estimativa baseada em custo medido.
- **Aceite:** nova função/handler cria pendência; pai não termina com filho obrigatório aberto; reexecução não duplica tarefas.

#### T011 — Runner, checkpointer e recuperação de falhas

- **Papel / dependências / maturidade:** coordenador; T009–T010; partial.
- **Entradas e execução:** padrões de `avatar_pipeline.py`; executar passos limitados com retorno/log/saída verificados, persistir tentativa e próximo passo, cancelar com checkpoint e retomar só etapas inválidas.
- **Saída:** loop da seção 4 implementado, comandos de status/resume/report e diagnóstico de bloqueio.
- **Aceite:** timeout, código 137, transporte truncado, processo morto e JSON inválido não viram sucesso; três tentativas iguais estacionam com causa e liberam fila independente.

#### T012 — Revisão independente e integração

- **Papel / dependências / maturidade:** validação; T007, T011; planned.
- **Entradas e execução:** contratos de entrega, branches/patches e schemas; preparar revisão de evidências, detecção de conflito e política de integração por lote pequeno; testar fluxo com tarefa piloto real.
- **Saída:** review record, gate de integração e relatório de custo do piloto.
- **Aceite:** autor não é seu próprio revisor; rejeição volta à fila; nenhum estado muda para done só porque o worker declarou sucesso.

### Fase C — Varredura completa dos artefatos

#### T013 — Inventário físico e grafo de arquivos

- **Papel / dependências / maturidade:** artefatos; T008; partial.
- **Entradas e execução:** APKs/splits e inventário REA existente; listar membros, arquivos internos, bibliotecas, metadata, bundles e dados; detectar duplicatas, extras, arquivos ausentes e formatos desconhecidos.
- **Saída:** grafo arquivo→membro→conteúdo/hash com status de inspeção.
- **Aceite:** todos os bytes/ocorrências do escopo físico classificados ou pendência explícita; não repetir inventário base válido.

#### T014 — Diretórios UnityFS, bundles e referências externas

- **Papel / dependências / maturidade:** artefatos; T013; partial.
- **Entradas e execução:** extrator por blocos, ResourceManager/Addressables/GUIDs; indexar entradas, compressão, offsets, fileIDs e dependências; verificar chaves compostas e proveniência.
- **Saída:** mapa de resolução de referências e extrator/cache limitado em memória.
- **Aceite:** cada referência resolve de forma única ou gera unknown; colisão de nomes nunca escolhe primeiro arquivo; evitar carregar 1,3 GB por pergunta.

#### T015 — Catálogo integral de cenas e prefabs

- **Papel / dependências / maturidade:** artefatos; T014; partial.
- **Entradas e execução:** 254 cenas de BuildSettings, prefabs e roots; gerar filho por cena/prefab, validar scene path↔serialized file, hierarquia ativa/inativa, componentes, dependências, objetos e scripts.
- **Saída:** `scenes.jsonl`, catálogos por cena e relatórios de vínculo.
- **Aceite:** todas as cenas e prefabs descobertos classificados, não apenas oito extraídos; bases de editor e auxiliares não contam como mundos jogáveis.

#### T016 — Controles, handlers e navegação

- **Papel / dependências / maturidade:** comportamento; T015; partial.
- **Entradas e execução:** Button/EventTrigger, inputs próprios, UnityEvents, código de registro de listeners e dados; catalogar gestos, hitboxes, visibilidade, guard, callback, destino e retorno. Incluir controles ocultos condicionais.
- **Saída:** catálogo de controles e grafo de navegação com arestas por classe de evidência.
- **Aceite:** nenhuma ação fica sem handler ou unknown; `m_Calls=[]` não é classificado como sem funcionalidade.

#### T017 — Texturas, sprites, atlas e materiais

- **Papel / dependências / maturidade:** artefatos; T014; partial.
- **Entradas e execução:** PNGs, Texture2D, SpriteAtlas, materiais e shaders; resolver texturas por referência real, UVs, pivots, bordas, recortes, cores e variantes; rastrear conteúdo faltante/corrompido.
- **Saída:** catálogo de renderização e mapa material→textura→origem.
- **Aceite:** ambiguidade de pixels do mesmo nome/dimensão resolvida por identidade ou pendente; nenhuma página visível faltante fica ocultada.

#### T018 — Áudio, vídeo, Spine e animações

- **Papel / dependências / maturidade:** artefatos; T014; partial.
- **Entradas e execução:** clips, nomes por cena, skeleton/atlas/skins, timelines, controllers e eventos; indexar parâmetros, duração, dependências e seleção dinâmica.
- **Saída:** índices de animação/som/vídeo e relações com cenas/componentes.
- **Aceite:** coleções existentes reutilizadas; atlas e animação catalogados não são contados como comportamento executado.

#### T019 — Configurações, catálogos, localização e saves

- **Papel / dependências / maturidade:** artefatos; T014; partial.
- **Entradas e execução:** JSON/TextAssets, tabelas, idiomas, save models, PlayerPrefs e configurações remotas declaradas; recuperar schemas, defaults, versões e referências.
- **Saída:** catálogo de dados e contratos de serialização/localização.
- **Aceite:** dados locais separados de payload remoto/valor de decisão offline; preço zero do catálogo não vira preço original.

#### T020 — Fechar falhas e reconciliar a cobertura estática

- **Papel / dependências / maturidade:** validação; T005, T015–T019; partial.
- **Entradas e execução:** fila das 126 classes e novos erros; corrigir typetrees/alinhamento/campos com exemplos mínimos, reprocessar só objetos afetados, reconciliar total e arquivos com formatos ainda desconhecidos.
- **Saída:** cobertura por objeto, erro resolvido e desconhecido remanescente.
- **Aceite:** nenhum erro desaparece por ignorar classe ou trocar denominador; marco V só passa após classificação de todo o universo ampliado.

### Fase D — Recuperar código real IL2CPP

#### T021 — Parear libil2cpp, metadata e módulos

- **Papel / dependências / maturidade:** lógica; T004, T013; partial.
- **Entradas e execução:** split arm64, `global-metadata.dat`, ELF e versão Unity; identificar/validar metadata v31 quando confirmado, módulos, CodeRegistration/MetadataRegistration e tabelas; usar ferramentas existentes compatíveis.
- **Saída:** manifesto do par binário/metadata e mapa de módulos/registrations.
- **Aceite:** consistência de versão, limites, contagens e endereços verificada; metadata incompatível falha explicitamente. Não executar bypass para obter resultado.

#### T022 — Inventário canônico de métodos e código

- **Papel / dependências / maturidade:** lógica; T021; partial.
- **Entradas e execução:** metadata, ELF, Cpp2IL e bases existentes; mapear token/definição→ponteiro→VA→offset→intervalos; incluir locais, wrappers, invokers, thunks, métodos sem corpo e funções nativas sem metadata.
- **Saída:** `methods.jsonl` e classificação de intervalos executáveis.
- **Aceite:** não limitar universo ao `.dynsym`; aliases e corpos compartilhados não inflam métricas; regiões não explicadas geram filhos unknown.

#### T023 — Tipos, layouts e ABI

- **Papel / dependências / maturidade:** lógica; T021–T022; partial.
- **Entradas e execução:** fields offsets, value/reference types, arrays, interfaces, delegates, strings e ABI arm64/IL2CPP; conferir offsets por acessos de código e dados, incluindo GC/write barriers e chamadas runtime.
- **Saída:** dicionário de tipos e contratos de layout versionados.
- **Aceite:** estruturas usadas nos dossiês têm offsets justificados; não confundir objeto managed com estrutura nativa nem renomear acesso incerto como campo conhecido.

#### T024 — Generics, virtual dispatch, reflexão e callbacks

- **Papel / dependências / maturidade:** lógica; T022–T023; planned.
- **Entradas e execução:** vtables, interfaces, generic sharing/RGCTX, invokers, delegates, reflexão, registro de eventos e callbacks; reconstruir conjuntos possíveis de alvos e identidade de instanciações.
- **Saída:** grafo de chamadas com resolução/proveniência e unknown por call site.
- **Aceite:** nenhuma ligação é presumida só por nome; mesmo endereço pode representar vários contratos genéricos; alvos desconhecidos impedem certificação dos efeitos dependentes.

#### T025 — Recuperação de corpos por método

- **Papel / dependências / maturidade:** lógica; T022–T024; planned.
- **Entradas e execução:** fila por método real; usar REA/decompilador disponível para assembly, CFG e pseudocódigo, com bytes e intervalos. Priorizar navegação/save/interação; agrupar funções compartilhadas e manter diffs por variante.
- **Saída:** dossiê completo por método com contrato da seção 6 e lacunas.
- **Aceite:** C# vazio continua pendente; pseudocódigo sem memória/efeitos ou saída truncada não recebe lógica recuperada; toda função obrigatória ganha filho rastreável.

#### T026 — Coroutines, async, eventos e máquinas de estado

- **Papel / dependências / maturidade:** lógica; T024–T025; planned.
- **Entradas e execução:** MoveNext, state fields, yield/wait, closures, cancelamento e callbacks; reconstruir ordem temporal, estados, transições, efeitos e descarte.
- **Saída:** contratos temporais e diagramas/tabelas executáveis por máquina.
- **Aceite:** entrada, todos os estados, término, erro e cancelamento explicados; função de início sozinha não certifica coroutine.

#### T027 — Harness de contratos e comparação diferencial

- **Papel / dependências / maturidade:** validação; T023–T026; planned.
- **Entradas e execução:** métodos e contratos piloto; criar referência independente, fixtures de estado e observadores de retorno/memória/chamadas; usar emulação só quando adequada e cenário runtime para efeitos Unity/GC/física não modelados.
- **Saída:** runners por classe de contrato e registros de divergência.
- **Aceite:** mutação intencional de retorno/flag/estado é detectada; stubs, RNG, relógio e domínio testado explícitos; comparação do clone consigo mesmo não vale como oráculo.

#### T028 — Auditar todo o universo de lógica

- **Papel / dependências / maturidade:** validação; T020, T025–T027; planned.
- **Entradas e execução:** métodos, intervalos, componentes e grafo; revisar funções sem callers, inicializadores, código raro e helpers; classificar terceiros por proveniência/contrato, sem reimplementar Unity inteiro sem necessidade.
- **Saída:** cobertura de métodos lógicos, corpos únicos, bytes únicos e dependências externas.
- **Aceite:** cada método do jogo é explicado ou pendente explícito; import de biblioteca não disfarça lógica própria ausente; marco L não passa com dependências desconhecidas obrigatórias.

### Fase E — Recuperar funcionalidades e sistemas compartilhados

Cada pacote desta fase cria filhos por componente/tipo/família. Eles usam os contratos recuperados em T025–T027; podem começar em paralelo para métodos já disponíveis, sem esperar o binário inteiro. T028 continua aberto até incorporar todos os filhos novos.

#### T029 — Boot, Home, scene manager e transições

- **Papel / dependências / maturidade:** lógica; T016, T025–T027; partial.
- **Entradas e execução:** HomePlayButton, GameSceneManager, WorldManager, loading e overrides; rastrear Play, mundo salvo, três hooks, init/load/unload, retorno, troca de mundo e falhas.
- **Saída:** contrato de navegação por estado e rota vertical Home→mapa→ambiente→retorno.
- **Aceite:** destino e guarda vêm do código/evidência, não da quadra do protótipo; ordem e estado persistido conhecidos.

#### T030 — Save, objetos persistentes e progresso

- **Papel / dependências / maturidade:** lógica; T019, T025–T027; partial.
- **Entradas e execução:** classes PersistentData, IDs, inventário, estado de cena e prefs; recuperar defaults, ownership, identidade, ordem de gravação, reset, migração e recuperação de erro.
- **Saída:** schema original observável, contrato de adaptação offline e fixtures por revisão.
- **Aceite:** avatar, itens, posições e progresso sobrevivem aos ciclos previstos; diferença de formato não oculta perda semântica de dados.

#### T031 — Input, seleção, arraste e câmera

- **Papel / dependências / maturidade:** lógica; T016, T025–T027; partial.
- **Entradas e execução:** pointer/touch, drag/drop, prioridades, hitboxes, multitouch, câmera/pan/zoom e safe area; recuperar competição UI/mundo e cancelamento.
- **Saída:** contratos de gesto→alvo→efeito e parâmetros por dispositivo/cena.
- **Aceite:** tocar, arrastar, soltar, cancelar e sobrepor objetos têm regra reproduzível; sem callbacks duplicados ou gestos inventados por conveniência.

#### T032 — Avatares, NPCs, pets e movimentação

- **Papel / dependências / maturidade:** lógica; T018, T025–T027, T031; partial.
- **Entradas e execução:** tipos Character/Toddler/Baby/animais, spawn/despawn, seleção, locomoção, posição, orientação, estados, segurar objetos e interações entre entidades.
- **Saída:** state machines e contratos por tipo com dados/efeitos.
- **Aceite:** cada família existente nos artefatos classificada; não usar skeleton Character para todos os presets nem avatar decorativo como movimento recuperado.

#### T033 — Editor, SUT, roupas, cores e compatibilidade

- **Papel / dependências / maturidade:** lógica; T017–T019, T025–T027; partial.
- **Entradas e execução:** probes/empacotadores existentes, templates, SUT map, materiais, recoloring, categorias, sorteio, presets, bloquear/desbloquear, salvar/cancelar/reset.
- **Saída:** catálogo e algoritmo de composição por tipo com compatibilidade e fixtures visuais.
- **Aceite:** peças e tint/duas cores têm fonte correta; combinação inválida e opção indisponível têm regra; seleção persiste e é usada em gameplay.

#### T034 — Física, containers, inventário de cena e objetos

- **Papel / dependências / maturidade:** lógica; T015, T025–T027, T031–T032; partial.
- **Entradas e execução:** colisões, triggers, ordenar/profundidade, pegar/soltar, encaixar, empilhar, carregar, abrir/fechar, mover, juntar/separar, consumo, spawn e destruição.
- **Saída:** catálogo de capacidades e contratos de transição/ownership.
- **Aceite:** cada handler e efeito real mapeado; ciclos duplicação/perda de item e reinício testáveis; parâmetros de física não substituídos por números arbitrários sem declarar diferença.

#### T035 — Animações contextuais e interações especializadas

- **Papel / dependências / maturidade:** lógica; T018, T025–T027, T032–T034; partial.
- **Entradas e execução:** todas as famílias LevelCA/DropArea/ItemHandler; agrupar pelo contrato, conferir overrides e dados de cada variante; incluir sentar, dormir, comer, banho, instrumentos, esportes, cozinhar/crafting/receitas, limpar, transformar itens e objetos especiais quando encontrados nos artefatos.
- **Saída:** índice componente→regra→animação→efeito→save e filhos de exceção.
- **Aceite:** nenhum tipo fica sem classificação; handlers raros não desaparecem por amostragem de família; transições entram/saem/cancelam corretamente.

#### T036 — Renderização, áudio, vídeo, clima e tempo

- **Papel / dependências / maturidade:** lógica; T017–T018, T025–T027; partial.
- **Entradas e execução:** sorting, clipping, shaders, partículas, timelines, música por cena, mixer, mute, loop, vídeos, clima/dia/noite e efeitos temporais presentes.
- **Saída:** contratos audiovisuais e parâmetros por estado/cena.
- **Aceite:** material/atlas faltante é defeito visível, não warning ignorado; música exata por referência; efeito de preferências e pausa comprovado.

#### T037 — Menus, loja, catálogo, passes, presentes e conquistas

- **Papel / dependências / maturidade:** lógica; T016, T019, T025–T027; partial.
- **Entradas e execução:** UI interna, filtros/abas, perfil, settings, widgets, gifts/passes/hunts; recuperar a porção cliente, disponibilidade, requisições declaradas e feedback.
- **Saída:** contrato por controle/fluxo e tabela original↔adaptação offline.
- **Aceite:** menus ocultos mapeados, estados de erro/cancelamento conhecidos; taxas/preços/limites do servidor permanecem desconhecidos quando não presentes.

#### T038 — Contrato da economia e atividades locais

- **Papel / dependências / maturidade:** comportamento; T006, T030, T037; partial.
- **Entradas e execução:** OFFLINE_HOME_RULES, saldo/inventário, quiz e serviços existentes; formalizar transações, idempotência, recompensas, datas, falha de I/O e reentrada. Separar recuperação original de extensão pedagógica.
- **Saída:** especificação versionada e matriz de teste da economia autorizada.
- **Aceite:** não pedir novamente autorização de política já registrada; não inventar novas políticas; salvar saldo/inventário/recompensa atomicamente e sem duplicação.

#### T039 — Fronteiras online, conteúdo remoto e integrações

- **Papel / dependências / maturidade:** lógica; T013, T024–T026, T037; partial.
- **Entradas e execução:** tipos de requisição/resposta, chamadas cliente, login/cloud/multiplayer/remote config/analytics/ads/IAP; mapear entradas/saídas, cache, timeout e pontos de acoplamento por análise local.
- **Saída:** mapa de contratos e dependências, ausências de backend, substituições offline permitidas.
- **Aceite:** serviço não acessado nem falsamente recuperado; inventário registra tudo e métricas mostram divergências; runtime offline não depende de SDK remoto para iniciar/jogar.

#### T040 — Android, lifecycle e bibliotecas de suporte

- **Papel / dependências / maturidade:** lógica; T013, T025–T027, T030, T036; partial.
- **Entradas e execução:** launcher/manifest/JNI/plugins/Unity bridges, storage, orientação, pause/resume, contexto GL, input e retomada; classificar libs de terceiros e proteções sem contorno.
- **Saída:** contrato de integração Android e matriz de lifecycle/compatibilidade.
- **Aceite:** toda fronteira nativa/managed relevante tem contrato; comportamento em encerramento/recriação conhecido ou cenário pendente explícito.

### Fase F — Expandir para todos os mundos, ambientes e regras

#### T041 — Mapas, zonas, edifícios e transportes

- **Papel / dependências / maturidade:** comportamento; T015–T016, T029, T031; partial.
- **Entradas e execução:** seis mapas candidatos, 115 edifícios, 101 entradas e 14 zonas; criar filhos por mapa/edifício, resolver pertencimento espacial/lógico, limites de câmera, transporte, andares e seleção.
- **Saída:** grafo completo mapa↔zona↔edifício↔ambiente, com condições e retorno.
- **Aceite:** todas as referências/variantes classificadas; não inferir zona por ancestralidade que já falhou nem desbloqueio por `_isFree=0`.

#### T042 — Dossiê funcional por cena e prefab

- **Papel / dependências / maturidade:** comportamento; T015, T029–T037; partial.
- **Entradas e execução:** expandir um filho por cena/prefab, enumerando todos os objetos interativos, capacidades, personagens, scripts, spawn, defaults e dependências; reconciliar com o catálogo completo. Criar filhos próprios para UGC/construção/decoração, seleção de layouts, transporte/veículos e CarMaker quando identificados, sem absorvê-los num genérico “outros”.
- **Saída:** pacote de implementação/QA por cena e catálogo de prefabs reutilizáveis.
- **Aceite:** nenhuma cena recebe done só por exportar sprites; cada componente obrigatório tem contrato ou bloqueio rastreado; todos os 254 paths classificados inclusive auxiliares.

#### T043 — Atividades, minijogos, pontuação e puzzles

- **Papel / dependências / maturidade:** lógica; T034–T035, T042; partial.
- **Entradas e execução:** expandir loops encontrados em todos os ambientes; regras de início/término, pontuação, sensores, RNG, falha, reset e recompensa. Priorizar discrepância da quadra: uma tacada não pode incrementar várias vezes sem regra comprovada.
- **Saída:** contratos por atividade e vetores de estado/temporização.
- **Aceite:** “Cesta!” ou animação não substitui regra; pontuação/recompensa bate com a referência no domínio definido.

#### T044 — Segredos, progressão, eventos e conteúdo condicional

- **Papel / dependências / maturidade:** comportamento; T019, T030, T035, T037, T042; planned.
- **Entradas e execução:** flags, colecionáveis, secrets, quests/hunts, calendário, tutoriais e conteúdo condicional; seguir dependências locais e separar o que depende de backend.
- **Saída:** grafo de condições/desbloqueios e cenários alternativos.
- **Aceite:** caminhos raros e condições temporais enumerados; ausência em captura não vira “não existe”; eventos remotos não viram regra inventada original.

#### T045 — Corpus runtime do original

- **Papel / dependências / maturidade:** comportamento; T001–T002, T016; partial.
- **Entradas e execução:** gravar cenários do original por rota/feature com aparelho, build, estado/save descartável, gesto, câmera, sequência, áudio, tela/log e resultado; reutilizar capturas antigas válidas. Execução exclusiva do dispositivo.
- **Saída:** cenários versionados, fixtures e observações rotuladas OBSERVED.
- **Aceite:** sem alterar saves reais; observações cobrem todos os comportamentos obrigatórios acessíveis; recurso indisponível fica bloqueado em vez de observado ficticiamente.

#### T046 — Reconciliação cruzada de funcionalidades

- **Papel / dependências / maturidade:** validação; T028–T045; planned.
- **Entradas e execução:** cruzar classes usadas, métodos, cenas, prefabs, controles, catálogo e cenários; detectar órfãos, listeners dinâmicos, objetos sem regra e regra sem teste. Abrir filhos novos nas fases anteriores.
- **Saída:** matriz de rastreabilidade e backlog residual priorizado.
- **Aceite:** zero lacuna obrigatória para marco L; classificação online não finge lógica backend; a descoberta aumenta denominadores e reabre pais quando necessário.

### Fase G — Construir a cópia com o conhecimento recuperado

Cada pacote pode começar por uma fatia cujo contrato já passou em revisão, sem aguardar todas as cenas. A conclusão do pai exige todos os seus filhos. Alterar arquivos comuns somente pela integração; preservar funcionalidades já implementadas e validadas.

#### T047 — Fundação offline e contratos de runtime

- **Papel / dependências / maturidade:** implementação; T006, T012, T029–T031; partial.
- **Entradas e execução:** cliente existente; consolidar scene routing, carregamento incremental, estado único, save versionado, eventos, clock/RNG controláveis e adaptadores sem rede.
- **Saída:** fundação mantida em fonte próprio e testes de integração.
- **Aceite:** inicialização offline reproduzível, retorno/save consistentes e nenhuma delegação escondida a lógica original ausente ou SDK remoto.

#### T048 — Home, loading, mapas e navegação fiel

- **Papel / dependências / maturidade:** implementação; T029, T041, T047; partial.
- **Entradas e execução:** preservar Home/loading existentes, substituir destinos provisórios por mapas e ambientes corretos, implementar hitboxes, guardas, estado salvo, transições, viagem e retorno.
- **Saída:** fatia Home→mapa→ambiente→retorno com roteiro comparável.
- **Aceite:** Play segue o fluxo original recuperado; quiz secundário; sem sobreposição, callbacks duplicados ou painel substituindo mapa.

#### T049 — Avatares completos e editor

- **Papel / dependências / maturidade:** implementação; T032–T033, T047; partial.
- **Entradas e execução:** runtime Spine/SUT já existente; ampliar categorias/tipos, cores, presets, animações, limites e persistência; corrigir atlas/material e usar o mesmo estado em todas as cenas.
- **Saída:** editor e personagens com filhos por categoria/tipo/contrato.
- **Aceite:** salvar/cancelar/reset e combinações corretas; aparência idêntica após reinício, sem páginas visíveis ausentes; catálogo coberto e diferenças explícitas.

#### T050 — Motor de interação e capacidades compartilhadas

- **Papel / dependências / maturidade:** implementação; T031–T036, T047, T049; partial.
- **Entradas e execução:** implementar sistemas reutilizáveis de movimento, drag/drop, física, containers, ownership, CA, áudio e efeitos com dados por prefab; não copiar classe vazia como script funcional.
- **Saída:** runtime de capacidades e testes por contrato/override.
- **Aceite:** handlers originais mapeados têm equivalente demonstrado; regressão entre famílias detectada; variantes de dados preservadas.

#### T051 — Reconstruir todos os ambientes por fatias

- **Papel / dependências / maturidade:** implementação; T042–T044, T048–T050; partial.
- **Entradas e execução:** um filho por ambiente com visual+interação+regra+áudio+save+retorno; importar só dependências corretas e testar a fatia antes de expandir. Reutilizar prefabs/capacidades sem perder exceções.
- **Saída:** cenas jogáveis completas e seus pacotes de validação.
- **Aceite:** todo ambiente obrigatório e conteúdo descoberto acessível no produto conforme política; fundo com avatar decorativo ou sala única não fecha o pai.

#### T052 — Economia, inventário, recompensas e pedagogia

- **Papel / dependências / maturidade:** implementação; T030, T037–T038, T047; unverified.
- **Entradas e execução:** auditar OfflineHomeService e testes novos antes de editar; completar loja/catálogo local, presentes, passe, saldo/inventário e quiz conforme regras autorizadas; testar rollback/reentrada/data.
- **Saída:** serviços locais, telas e ledger de transações consistentes.
- **Aceite:** sem dinheiro real, sem preço original inventado, sem pagamento duplicado; regras de produto e diferenças de paridade separadas; reinício não perde propriedade/saldo.

#### T053 — Telas auxiliares e conteúdo condicional

- **Papel / dependências / maturidade:** implementação; T037, T039, T044, T047, T052; partial.
- **Entradas e execução:** completar settings/idiomas, progresso, perfil local, eventos e demais modos locais recuperados; integrar cada controle com função real ou classificá-lo como divergência fora do escopo offline.
- **Saída:** matriz de controles implementados com retorno/feedback/persistência.
- **Aceite:** todos os controles obrigatórios funcionais; mensagem “indisponível” não conta como reprodução; login/multiplayer não recebem falsa equivalência.

#### T054 — Assets, build e pacote Android reproduzível

- **Papel / dependências / maturidade:** implementação; T040, T047; partial.
- **Entradas e execução:** build atual e dependências importadas; pipeline incremental de empacotamento por cena, auditoria de assets ausentes, configurações Android, assinatura local, variantes dev/release e checks de conteúdo.
- **Saída:** APK de fonte atual com manifesto de build/inputs/hashes e logs.
- **Aceite:** checkout/inputs declarados produzem app instalável; sem Development Console/erros repetidos na entrega; build bem-sucedida não substitui teste no aparelho.

### Fase H — Validar, reabrir defeitos e fechar

#### T055 — Suítes de contratos e integração automatizada

- **Papel / dependências / maturidade:** validação; T027, T047–T054; partial.
- **Entradas e execução:** testes existentes e contratos novos; completar EditMode/PlayMode para estado, migração, interação, navegação, economia e catálogos; adicionar detectores de divergência significativos e CI por paths/dependências.
- **Saída:** suítes, matriz requisito→teste e XML/logs por revisão.
- **Aceite:** testes verificam comportamento, não espelham implementação; nenhum skip obrigatório tratado como verde; mudanças invalidam evidência afetada.

#### T056 — Replays comparativos original versus cópia

- **Papel / dependências / maturidade:** validação; T045, T048–T055; partial.
- **Entradas e execução:** executar mesmos cenários/estado/gestos/aspecto; comparar efeitos, sequência, posições, hitboxes, imagem, áudio, saldo/progresso e persistência. Definir tolerâncias observáveis e não determinismo por tipo.
- **Saída:** veredito por cenário, diffs mínimos reproduzíveis e bugs priorizados.
- **Aceite:** todas as rotas obrigatórias aprovadas no escopo; screenshots isoladas não certificam a lógica; divergência intencional tem autorização/rationale, não é mascarada por tolerância ampla.

#### T057 — Limites, corrupção e interrupções

- **Papel / dependências / maturidade:** validação; T030, T040, T055; planned.
- **Entradas e execução:** save corrompido/truncado, falha I/O, assets faltantes, cancelar drag/load, foco, pause/resume, encerramento/reabertura, multitouch e relógio alterado; fuzzing limitado em parsers relevantes.
- **Saída:** matriz de robustez e regressões por falha.
- **Aceite:** não perder estado válido, não duplicar itens/moedas, não travar em loading; diferenças de comportamento do original ficam documentadas.

#### T058 — Aparelhos, modo offline e desempenho

- **Papel / dependências / maturidade:** validação; T054–T057; partial.
- **Entradas e execução:** matriz Android/ABI/GPU/aspecto declarada, sessões longas e modo avião; medir tempo de carregamento, frame time, memória, uso de áudio e escalonamento por cenas.
- **Saída:** relatórios por aparelho/build e perfis de gargalo.
- **Aceite:** metas definidas por comparação e uso real, sem requisito arbitrário; nenhum fluxo obrigatório exige rede/login; aparelho ausente continua cobertura pendente.

#### T059 — Auditoria final de cobertura e lacunas

- **Papel / dependências / maturidade:** validação; T046, T051–T058; planned.
- **Entradas e execução:** refazer reconciliação de métodos, objetos, cenas, funcionalidades, testes, implementações e bugs; buscar TODOs funcionais, fallbacks e dependências da `.so` original para executar lógica do cliente novo.
- **Saída:** relatório dos três marcos V/L/C, cobertura multidimensional e residual de divergências externas.
- **Aceite:** nenhum unknown/bug obrigatório, certificado/evidência obsoleta ou filho perdido; total classificado e total equivalente apresentados separadamente; toda lógica local do produto mantida em fonte.

#### T060 — Reprodução independente e encerramento

- **Papel / dependências / maturidade:** validação; T059; planned.
- **Entradas e execução:** outro agente/ambiente reproduz build, testes e cenários críticos usando documentação/artefatos permitidos, sem contexto oculto; coordenador confere gates, limitações e estado persistido.
- **Saída:** pacote final local, manual de reprodução, relatório de aceite e checkpoint de encerramento.
- **Aceite:** V/L/C aprovados no escopo declarado, todos os filhos obrigatórios aceitos e recurso externo não disfarçado como recuperado; só então declarar objetivo concluído. Não publicar APK/assets automaticamente.

## 8. Primeiras ondas executáveis e paralelismo

1. **Onda 1:** T001/T003 em sequência de identidade; T004 e leitura de T002 em paralelo. Consolidar T005/T006 sem tocar o cliente existente.
2. **Onda 2:** implementar T007–T012 incrementalmente; inventariar T013/T014 e parear IL2CPP T021 com agentes distintos, entradas imutáveis.
3. **Onda 3:** extrair cenas/controles T015/T016; lógica T022–T027; dados/assets T017–T020. Um único executor de cada banco nativo mutável.
4. **Onda 4:** fechar piloto T029 e uma rota real; iniciar T045 assim que houver dispositivo. Implementar T047/T048 apenas para contrato aprovado.
5. **Onda 5:** expandir sistemas T030–T040 e mundos T041–T044; paralelizar recuperação por família e implementação por módulo exclusivo, integrado em lotes revisáveis.
6. **Onda 6:** construir todos os filhos de T049–T054; executar T055–T058 por fatia, sem esperar o fim para descobrir defeitos.
7. **Onda final:** T046/T059/T060 reconciliam tudo; novos achados reabrem filhos e retornam à onda correspondente.

Dependências do catálogo são gates de fechamento; para iniciar uma fatia de um pacote pai parcialmente pronto, gerar filhos com dependências exatas já satisfeitas. Nunca marcar o pai inteiro concluído para liberar artificialmente outro pacote. Ciclos de chamadas são resolvidos por contratos de interface e grupos de métodos fortemente conectados, com teste do conjunto antes da certificação.

## 9. Métricas e gates automáticos

Publicar numerador/denominador, versão/hash e conjunto de desconhecidos para cada eixo:

- Artefatos e formatos classificados; objetos decodificados; classes com falha.
- Cenas/prefabs/controles inventariados e contratos revisados.
- Métodos lógicos explicados, corpos únicos analisados, união de bytes explicados; generics e aliases separados.
- Call sites indiretos resolvidos; estados/caminhos relevantes com contrato; efeitos externos pendentes.
- Funcionalidades especificadas, implementadas e comparadas em runtime.
- Assets referenciados resolvidos e conteúdo integrado por cena.
- Cenários obrigatórios aprovados, bugs abertos e plataformas verificadas.
- Serviços originais não reproduzidos, adaptações offline e conteúdo externo indisponível.

Não tirar média desses eixos para inventar um percentual global. Marco V depende da reconciliação de inventário; L depende de contratos e desconhecidos; C depende de implementação e validação. Uma funcionalidade grande e um getter simples não têm peso equivalente por contagem.

O gate final rejeita: filho obrigatório não done; input/evidência stale; implementação sem contrato; contrato sem validação adequada; cenário obrigatório skipped; placeholder; controle sem classificação; dado ambíguo escolhido por nome; diferença de backend escondida; revisão inexistente. Mudança de domínio/precondição para esconder falha exige revisão e aparece na cobertura.

## 10. Prompt do coordenador e handoff de worker

```text
Você coordena a reconstrução offline do Avatar World neste workspace.
Leia AVATAR_WORLD_MASTER_PLAN.md e a fila/estado persistido. Preserve mudanças
existentes e regras de produto já autorizadas. Reconcile evidências antes de
refazer trabalho. Gere filhos por inventário, obtenha leases e distribua apenas
tarefas com escopo, inputs, paths, dependências e aceite exatos.
Use REA para evidência de artefatos/código quando disponível; distinga outputs
de outras ferramentas. Não trate DiffableCs vazio como implementação.
Execute o loop da seção 4, com checkpoint e revisão independente. Integre
fatias pequenas; mantenha denominadores dinâmicos e divergências externas.
Quando houver bloqueio real, registre causa/recurso e siga trabalho independente.
Não encerre em protótipo nem alegue 100% só por classificação ou testes parciais.
Finalize apenas com T060 aceito, ou entregue checkpoint explícito de bloqueio.
```

Pacote mínimo de worker:

```text
Task: <id/child-id>; role: <papel>; revision/input hashes: <refs>
Goal: <uma pergunta/entrega concreta>; existing accepted work: <refs>
Read only: <paths/trechos/evidence ids>; write only: <paths exclusivos>
Dependencies/interfaces: <ids>; exclusive resources: <locks>
Steps/hypothesis: <lote limitado>; acceptance: <checks observáveis>
Return: result.json + evidências + diff/patch quando exigido + unknowns
        + próximo passo + resumo curto. Não altere status global nem escopo.
```

A autonomia prevista não elimina limites de ferramentas, aparelho ausente ou informações inexistentes. Ela elimina retrabalho e interrupções desnecessárias quando há tarefa independente autorizada para executar. Este plano não autoriza inventar respostas ou relaxar o aceite para manter um loop rodando.
