# Plano de engenharia reversa e reconstrução offline por agentes

**Meta:** mapear sistematicamente o comportamento observável do Avatar World nos APKs/assets locais e reconstruir uma experiência offline funcional, com editor de avatares, ambientes e atividades jogáveis, economia fictícia e desafios pedagógicos. Este plano serve para delegar trabalho em paralelo sem perder evidências, duplicar comandos ou misturar protótipos com paridade.

**Limite da promessa:** “100%” é um objetivo de cobertura verificável sobre os conteúdos, cenas, telas, controles e regras observáveis nos artefatos disponíveis. Não é possível provar cópia integral do código-fonte original nem equivalência de serviços/flags/conteúdo que só existem no backend. Cada parte dinâmica deverá virar regra offline explicitamente definida ou uma divergência documentada. Nenhum endpoint deve ser sondado, nenhum login/compra real deve ser tentado, e nenhuma proteção/licença deve ser contornada durante este plano.

## Objetivo do produto

1. Ao abrir sem rede, o jogador consegue usar as telas e experiências principais mapeadas do jogo.
2. Play abre o fluxo principal de exploração/interação, nunca o quiz como destino substituto.
3. O jogador monta e salva visuais de avatar com peças compatíveis, retoma a aparência após reiniciar e usa o avatar nos ambientes.
4. Conteúdo bloqueado reconstruído é obtido com moedas locais fictícias. Não há IAP, cobrança, checkout nem promessa de valor monetário.
5. Desafios pedagógicos aleatórios são uma atividade opcional. Resposta correta gera recompensa local conforme regras configuradas; repetição, erro, abandono, duplicidade e reinício têm comportamento testado.
6. Todo fluxo possui estado persistente consistente, funciona em modo avião e pode ser validado no Android físico.

## Regras de trabalho para todos os agentes

- Começar pelo estado real: ler este documento, `LOOP_STATE.md`, `docs/OFFLINE_RECONSTRUCTION_STATUS.md`, `docs/AVATAR_GAMEPLAY_PLAN.md` e a tarefa atribuída; conferir `git status` antes de editar. Preservar alterações que já existiam.
- Analisar artefatos locais existentes. Não reextrair bundles/APKs se inventário e hashes correspondentes já existem. Usar a chave de assets `(serialized_file, path_id)`, nunca `path_id` isolado.
- Executar somente ferramentas em lote com limite e cache por hash/versão. Registrar comando, entradas, duração, saída e código de retorno. Não repetir comando verde sem mudança de entrada.
- Cada afirmação recebe uma classe: **observado em runtime**, **extraído estaticamente**, **inferido** ou **desconhecido**. Incluir referência local e confiança. Não transformar ausência de evidência em afirmação.
- “Botão recebe toque”, “tela abre” e “a regra está correta” são três critérios diferentes. Warnings, placeholders, “em breve” e modais de indisponibilidade nunca contam como funcionalidade.
- Agentes de descoberta trabalham primeiro em modo somente leitura e entregam relatório estruturado. Só o integrador modifica arquivos comuns; implementação simultânea deve usar branches/worktrees separados, commits pequenos e arquivos exclusivos.
- Não alterar APK original, dados do usuário, saves reais ou configuração global do Unity. Não apagar arquivos, caches ou locks sem demonstrar que são temporários e não estão em uso.
- Todos os dados do jogo são locais. Não importar dependência que faça rede em runtime. Recursos de build entram no pacote mínimo necessário e são testados offline.

## Forma de divisão e integração

O coordenador mantém o quadro de tarefas abaixo e entrega a cada agente **um pacote de trabalho independente**, com escopo, caminhos permitidos, critério de aceite e limite de tempo/tokens. Um agente não recebe a tarefa vaga “analise o jogo todo”. O mesmo item não pode ter dois agentes alterando os mesmos arquivos.

| Trilha | Trabalho isolado | Saída exigida | Dependência |
| --- | --- | --- | --- |
| A. Inventário e cenas | Catálogo de cenas, hierarquias, entradas/saídas e ativos referenciados | `reports/scenes.jsonl` + síntese, hashes e contagens | Nenhuma; começa primeiro |
| B. Navegação e controles | Mapear todos os controles visíveis por cena, handlers e destino | `reports/controls.jsonl`, incluindo não mapeados e confiança | A |
| C. Avatar e personalização | Skeleton/atlas/skins/SUT, compatibilidade, menus, estado e saves | `reports/avatar.json`, catálogo mínimo validado, casos de teste | A |
| D. Mundos e gameplay | Regras/interações por ambiente e sequência de jogo | Um relatório por cena/loop, assets e testes observáveis | A, B |
| E. Economia e pedagogia | Moeda, desbloqueios, desafios/recompensas e persistência local | Especificação de estado/regras, ledger e testes | B; política de produto acima |
| F. Áudio, opções e progresso | Música/SFX, idioma, perfil, conquistas e dados locais | Matriz de comportamento e lacunas | B |
| G. Integração Unity | Implementar apenas fatias aprovadas, salvar estado e ligar UI ao gameplay | PR/commit pequeno + testes + APK de desenvolvimento | A–F concluídas para a fatia |
| H. QA de paridade | Reproduzir roteiro no APK original e clone offline e comparar | Roteiros, capturas, logs, resultados e bugs classificados | G |

## Backlog detalhado

### Fase 0 — Preparação reproduzível

- [ ] **0.1 Baseline e integridade.** Inventariar APKs/splits, projeto Unity, branches, modificações locais, versão de ferramentas e device. Gravar tamanho/SHA256 dos inputs; excluir `out/`, builds e dumps grandes do commit, exceto quando um artefato de evidência pequeno for necessário.
- [ ] **0.2 Validar ferramentas e cobertura local.** Confirmar Unity Editor/Android module, ADB, Cpp2IL, parser UnityFS/UnityPy e dependências já instaladas. Relatar ferramenta ausente sem instalar automaticamente binários externos.
- [ ] **0.3 Automatizar execução.** Criar/estender `tools/avatar_recon.py` com subcomandos `inventory`, `scene`, `controls`, `assets`, `tests`, `build`, `device` e `report`. Cada etapa usa manifesto de inputs/outputs com SHA256, cache incremental, lock por projeto, timeout, logs e resumo JSON. `--force` refaz somente a etapa solicitada. Scripts não escondem erros nem retornam sucesso se output estiver ausente/vazio.
- [ ] **Aceite da fase:** uma execução normal só faz etapas alteradas; segunda execução sem mudanças reporta cache hit e não repete extrações/build/testes; interrupção deixa estado retomável.

### Fase 1 — Catálogo completo do que está no pacote

- [ ] **1.1 Inventário de cenas.** Para cada cena, registrar nome/ID, quantidade de GameObjects, componentes, Canvas, botões, imagens, scripts MonoBehaviour, referências externas e assets; manter chave `(arquivo serializado, path_id)`.
- [ ] **1.2 Inventário de controles.** Percorrer recursivamente hierarquia ativa e inativa; registrar nome, texto/ícone, posição/anchors, `Button`/handlers/delegates, componente de script, `interactable`, bloqueios de raycast e visibilidade por condição. Comparar lista exportada com os objetos runtime.
- [ ] **1.3 Inventário de assets.** Agrupar sprites/texturas por referência e tamanho; catalogar atlas/Spine, áudio, animações, fontes, prefabs e dependências. Evitar duplicatas por nome e detectar assets ausentes/corrompidos.
- [ ] **1.4 Grafo de navegação.** Cada aresta registra origem, gesto/controle, método, cena/painel de destino, condições, estado alterado, saída/retorno e evidência. Controles cujo destino depende de servidor recebem explicação e classificação, não um destino inventado.
- [ ] **Aceite da fase:** cada cena catalogada possui relatório; cada controle tem estado `mapped`, `server_dependent`, `hidden_runtime`, `duplicate` ou `unknown`; contagens são reconciliadas com os dumps e exceções explicadas.

### Fase 2 — Reconstruir comportamento e estado

- [ ] **2.1 Fluxos de usuário.** Escrever roteiros passo a passo para início frio, Home→Play, seleção/entrada/saída de cada ambiente, editor, loja, desbloqueio, progresso, configurações, desafio e reinício.
- [ ] **2.2 Estado persistido.** Catalogar saldo, inventário, aparência, progresso, desafios concluídos, preferências e versão do save. Identificar defaults, migrações e condições de gravação/carregamento.
- [ ] **2.3 Regras de gameplay.** Para cada loop, registrar input, física/interação, transição, pontuação/recompensa, falha, animação/feedback e edge cases. Seguir métodos decompilados até chamadas e dados; distinguir código real de wrapper/server response.
- [ ] **2.4 Reconstrução da moeda.** Não copiar preço server-side desconhecido. Definir arquivo de configuração local revisado com IDs, custos em moeda fictícia, recompensas, limites e versão; atualizar saldo + inventário numa operação atômica, gerar ledger e tornar duplicações idempotentes.
- [ ] **2.5 Conteúdo pedagógico.** Definir schema versionado de questões, disciplinas, dificuldade, alternativas e resposta; seleção aleatória sem repetição curta, validação, moeda só para acerto, proteção a reabertura/replay e persistência. O quiz nunca ocupa o botão/rota Play.
- [ ] **Aceite da fase:** diagramas/roteiros cobrem todos os fluxos locais; divergências online foram convertidas em regra offline explícita ou estão no relatório de não reprodução; nenhum comportamento crítico depende de rede.

### Fase 3 — Implementar paridade em fatias verticais

Implementar uma cena/loop de cada vez, sempre com **visual + interação + regra + save + retorno + teste**:

- [ ] **3.1 Fundação offline.** Inicialização determinística sem rede; navegação e save versionado; telemetria local/logs desativáveis; recuperação de save inválido sem perder outros campos.
- [ ] **3.2 Home.** Reproduzir layout/ativos/ordem/hitboxes e música específica da cena. Ligar cada botão à funcionalidade observada ou à regra offline aprovada. Nenhum CTA novo pode cobrir hitboxes originais.
- [ ] **3.3 Avatar.** Catálogo de opções e combinações compatíveis; editor visual com prévia real, seleção por categoria, salvar/cancelar/reset, desbloqueios, estado persistido e uso do mesmo avatar nas cenas.
- [ ] **3.4 Mundos.** Implementar todos os ambientes identificados por prioridade de frequência/centralidade. Para cada um: câmera, navegação, colisão, avatar/NPC, objetos interativos, animação/sons, regra principal, retorno e save. Não substituir ambiente por painel textual.
- [ ] **3.5 Loja local e inventário.** Catálogo/pesos de preço definidos explicitamente em moeda fictícia; itens gratuitos e bloqueados; compra local idempotente; saldo insuficiente; reembolso/erro; nenhum componente IAP/checkout.
- [ ] **3.6 Desafios e progresso.** Perguntas aleatórias, pontuação/recompensa auditável, resumo, progresso persistido e apresentação coerente na Home.
- [ ] **3.7 Preferências.** SFX e música separados; idioma e opções que existam no original; persistir e validar efeito real após reiniciar.
- [ ] **Aceite de cada fatia:** correspondência visual suficiente para reconhecer cena/asset, todas as entradas críticas clicáveis e sem sobreposição, regra coberta por testes, APK reproduzível e fluxo no aparelho comprovado.

### Fase 4 — Validação e cobertura

- [ ] **4.1 Testes de lógica.** EditMode para regras puras, migrações, save, economia, quizzes, compatibilidade de avatar e navegação.
- [ ] **4.2 Testes Unity/Play.** Roteiros automáticos para carregar/abrir/fechar telas, raycast/seleção, colisões e transições. Testes não substituem Android.
- [ ] **4.3 Android físico offline.** Instalar build limpa; ativar modo avião; forçar fechamento/reabrir; percorrer fluxos críticos; conferir logs, orientação, safe area, toque, áudio e memória.
- [ ] **4.4 Paridade comparativa.** Capturas do APK original e clone com mesmo aspecto/estado; tabela por controle/tela/ação/feedback/save. Cada diferença recebe severidade, causa e próximo passo.
- [ ] **4.5 Auditoria de rede/dinheiro.** Inspecionar dependências e build para assegurar que nenhum fluxo de runtime pede rede, login ou pagamento. Validar compra com saldo falso e inventário local.
- [ ] **4.6 Cobertura final.** Relacionar total mapeado, implementado equivalente, divergente por backend e não analisado. A conclusão exige 100% de entradas conhecidas classificadas; não exige fingir equivalência dos dados indisponíveis.
- [ ] **Aceite final:** pacote funciona offline após cold start; nenhuma transação real; todos os controles/sistemas observados têm equivalência local ou divergência justificada; inventário de cena/controle sem `unknown`; suíte Unity verde; APK instalado validado; relatório completo anexado.

## Contrato de entrega de cada tarefa delegada

Cada agente retorna exatamente:

1. **Escopo executado** e arquivos lidos/alterados.
2. **Conclusões com evidência**, usando rótulos `OBSERVED`, `STATIC`, `INFERRED`, `UNKNOWN`; caminho do artefato, classe/método/objeto e hash quando aplicável.
3. **Inventário/saída estruturada** em JSONL/JSON versionado; sem colar milhares de linhas no chat.
4. **Comandos executados** com duração, status, arquivos de log e estado de cache; não incluir credenciais.
5. **Pendências e riscos técnicos**, sem marcar placeholder ou teste indireto como concluído.
6. **Mudanças de código** em commit isolado/branch própria, ou patch proposto ao integrador. Nunca editar a branch compartilhada sem tarefa explícita de integração.

Schema mínimo por controle (`reports/controls.jsonl`):

```json
{"scene":"level3","object":"PlayButton","label":"Play","component":"Game.Home.HomePlayButton","method":"LoadPlayScene","destination":"STATIC:...","state_changes":[],"status":"mapped","evidence":[{"kind":"STATIC","path":"out/cpp2il/...","sha256":"..."}],"confidence":"high","offline_rule":null,"clone_status":"pending"}
```

## Eficiência de tokens e execução autônoma

- O coordenador envia tarefas com paths/IDs previamente filtrados e entrega apenas resumo + arquivos de relatório ao próximo agente; dumps integrais ficam locais.
- Cada etapa automatizada imprime resumo compacto: contagens, hash de cache, artefatos alterados, falhas e próximo comando. Logs detalhados ficam em `out/logs/`.
- O cache é indexado por SHA256 de inputs, versão do script/ferramenta e configuração. Excluir cache invalida custo alto sem motivo; `--force` é explícito.
- Procurar uma vez por família de cena/classe e manter índice pesquisável; reutilizar índices para rastrear símbolos/referências, não abrir novamente o bundle de 1,5 GB para cada pergunta.
- O integrador agrupa mudanças relacionadas em PR/commit pequeno após testes. Conflitos são resolvidos contra o trabalho local, nunca com reset/checkout destrutivo.
- A autonomia é limitada por gates verificáveis: agentes podem analisar, codificar, testar e gerar APK localmente; ações destrutivas, publicação/distribuição, credenciais ou mudança de política comercial exigem instrução humana explícita.

## Estado de partida e próxima chamada de trabalho

Estado detalhado da rodada atual: [`OFFLINE_RECONSTRUCTION_STATUS.md`](OFFLINE_RECONSTRUCTION_STATUS.md). Evidências do editor/Spine: [`AVATAR_GAMEPLAY_PLAN.md`](AVATAR_GAMEPLAY_PLAN.md) e [`AVATAR_ASSET_FINDINGS.md`](AVATAR_ASSET_FINDINGS.md). Estado longo do loop: [`../LOOP_STATE.md`](../LOOP_STATE.md).

Ordem recomendada para iniciar agentes: **A inventário de cenas → B controles e grafo de navegação → C avatar → D gameplay por ambiente → E economia/pedagogia → F opções/progresso**, em paralelo sempre que as entradas estiverem prontas. O integrador começa pela automação 0.3 e só então combina relatórios num backlog de implementação com IDs estáveis.

**A primeira rodada não deve implementar outra tela.** Deve preencher as lacunas de inventário e confirmar os fluxos originais e hitboxes com evidência, para que cada fatia seguinte seja construída contra um comportamento conhecido.
