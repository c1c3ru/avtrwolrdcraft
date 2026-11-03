# Fila local de tarefas: uso e limites

Implementação inicial de T007/T009/T011 e importação delimitada de filhos de T010 do [plano mestre](AVATAR_WORLD_MASTER_PLAN.md). O comando mantém estado, posse de tarefas e revisão. **Não executa agentes, ferramentas REA, builds, testes Unity ou loops em background.** Os geradores específicos de datasets e o executor persistente são componentes separados.

Arquivos:

- `tools/recon_queue.py`: CLI Python, somente biblioteca padrão; requer Linux/POSIX (`fcntl`, fsync de diretório).
- `tools/test_recon_queue.py`: testes com diretórios temporários e uma disputa real entre processos.
- `docs/AVATAR_WORLD_TASKS.json`: semente de planejamento; não editar seus estados para fingir execução.
- `reports/recon/tasks.json`: destino padrão da fila viva, criado somente por `init` explícito.

## Inicialização e leitura

Executar a partir da raiz do projeto:

```bash
python3 tools/recon_queue.py init --seed docs/AVATAR_WORLD_TASKS.json
python3 tools/recon_queue.py status
python3 tools/recon_queue.py ready
```

`init` recusa sobrescrever uma fila existente, verifica o SHA-256 do documento referenciado pela semente, IDs, dependências e ciclos. Todos os estados da semente devem ser `pending`, sem leases. O comando preserva maturidade herdada e não conclui tarefa por arquivo existente.

`ready` lista tarefas cujas dependências estão `done`, incluindo as ainda não configuradas. Seu campo `configured` distingue esse caso. Trata-se de prontidão estrutural: `claim` revalida hashes e locks antes de autorizar posse. `status` informa contagens e leases expirados, sem recuperá-los automaticamente.

## Gate de horário para novos trabalhos

```bash
python3 tools/recon_queue.py pause --until '2026-11-03T15:00:00-03:00' \
  --note 'Não iniciar novos trabalhos antes do horário autorizado'
```

O horário precisa estar no futuro e conter timezone explícito. A fila persiste `control.not_before`; antes do limite, `ready` retorna lista vazia e `claim` falha. No instante do limite ou depois dele, novos claims voltam a ser permitidos se as demais condições estiverem satisfeitas. `status.pause.active` expõe o estado, conservando a informação histórica após expirar.

O gate não mata processos, não libera leases ativos e permite concluir checkpoint/heartbeat/revisão da tarefa em curso. Não inicia qualquer trabalho automaticamente ao chegar o horário. O exemplo é apenas sintaxe: usar a data e hora efetivamente autorizadas pelo usuário; não criar uma nova pausa ao retomar uma pausa anterior já expirada.

## Importação atômica de tarefas filhas

```bash
python3 tools/recon_queue.py import-children --manifest reports/recon/discovery_children.json \
  --actor coordenador --note 'Expansão delimitada a partir do inventário revisado'
```

Manifesto aceito:

```json
{
  "schema_version": 1,
  "kind": "child_planning_specs",
  "tasks": [{
    "id": "T015/SCENE/3-home",
    "parent_id": "T015",
    "role": "artefatos",
    "dependencies": ["T001"],
    "state": "pending",
    "acceptance": "Reconciliar os componentes desta cena com identidades e limites explícitos",
    "input_refs": [{"path": "out/navigation-map/scenes.json", "sha256": "HASH_SHA256_REAL", "selector": {"build_index": 3}}],
    "allowed_paths": ["out/recon/tasks/T015/SCENE/3-home/**"],
    "resource_locks": ["task-output:T015/SCENE/3-home"],
    "outputs": ["out/recon/tasks/T015/SCENE/3-home/result.json"],
    "evidence_refs": [], "attempts": [], "owner": null, "lease": null, "review": null
  }]
}
```

Substituir o hash ilustrativo pelo digest real do arquivo. `selector` é metadado preservado, não uma prova de que o conteúdo selecionado está correto. Inputs são revalidados por caminho e SHA-256; arquivos de saída esperados não precisam existir ainda.

A importação aceita até 1.000 filhos por manifesto e exige IDs únicos em toda a fila/lote, parent existente e ocioso, estado inicial `pending`, ausência de owner/lease/revisão/tentativas, aceite não vazio, papel, dependências explícitas, inputs exatos e paths/outputs não vazios. A validação inteira e a checagem de hashes acontecem sob o lock, antes de uma única escrita atômica; qualquer falha rejeita todo o lote. Manifesto e seu hash ficam no histórico.

Inputs repetidos entre filhos são hashados uma vez por caminho resolvido contido na raiz **durante essa operação**. Hashes esperados conflitantes para o mesmo arquivo rejeitam o lote. O importador compara device/inode/tamanho/mtime/ctime antes/depois do hash e revalida essas identidades e a resolução dos paths imediatamente antes de gravar: alteração durante a importação falha. Esse fingerprint é apenas verificação de estabilidade da operação, não prova criptográfica persistida nem autorização para reutilizar hash em importações futuras. O histórico registra `unique_input_files_hashed`; selectors diferentes preservam metadados sem repetir leitura dos mesmos bytes.

Filhos não dependem de o pai estar `done`: o pai pode permanecer `pending` enquanto filhos delimitados progridem. Declarar as dependências reais do filho, como baseline ou interfaces já revisadas. A fila rejeita dependência do próprio pai/ancestral e ciclos indiretos que combinem dependências e fechamento de filhos. Um pai só pode ser aprovado depois de todos os filhos descobertos concluídos com revisão independente.

Importação não executa tarefas nem promove algo a `done`. Filhos importados com hashes/escopo válidos ficam configurados para claim sujeito às dependências e locks; isso não comprova a disponibilidade semântica de pré-requisitos omitidos. O gerador/coordenador deve listar todas as dependências verdadeiras. Novos filhos não podem ser anexados a pai em execução/revisão ou já concluído; rejeitar/reconfigurar o pacote ou implementar uma reabertura explícita antes de expandir esse escopo.

Para experimentar sem tocar a fila oficial, prefixar **cada** comando com `--queue /tmp/avatar-recon-demo/tasks.json`. `--root` de `init` permite declarar explicitamente a raiz onde estão os inputs; todos os comandos seguintes usam a raiz persistida.

## Preparar uma tarefa antes de delegar

```bash
python3 tools/recon_queue.py configure T001 --actor coordenador \
  --input docs/AVATAR_WORLD_MASTER_PLAN.md \
  --input docs/AVATAR_WORLD_TASKS.json \
  --allowed-path 'out/recon/tasks/T001/**' \
  --resource baseline-write
python3 tools/recon_queue.py claim T001 --actor agente-artefatos --seconds 600
```

`configure` registra os hashes atuais dos inputs e torna a tarefa elegível a claim; `--input` deve apontar arquivos concretos e pode ser repetido. Paths precisam ser relativos à raiz, sem `..`; referências via symlink que escapam da raiz são rejeitadas. Não usar diretórios ou globs nos inputs. `--allowed-path` e `--resource` podem ser repetidos; se omitidos, conservam os valores existentes.

O coordenador deve conferir se os inputs e paths realmente delimitam o trabalho. O programa valida arquivos/hashes, mas não deduz se o pacote está semanticamente completo. Recursos são nomes compartilhados exatos, por exemplo `device:SERIAL`, `unity:AvatarWorldClient` ou `rea:libil2cpp-db`; aliases diferentes não se bloqueiam. `allowed_paths` é um contrato para o worker e não um sandbox imposto pelo CLI.

`claim` retorna um objeto com `lease.id`. Esse token precisa ser copiado para os próximos comandos. Não há variável de shell criada automaticamente.

## Iniciar, renovar e salvar checkpoint

```bash
python3 tools/recon_queue.py start T001 --actor agente-artefatos --lease-id TOKEN
python3 tools/recon_queue.py heartbeat T001 --actor agente-artefatos --lease-id TOKEN
python3 tools/recon_queue.py checkpoint T001 --actor agente-artefatos --lease-id TOKEN \
  --state running --note 'Hashes coletados; falta reconciliar os splits' \
  --evidence out/recon/tasks/T001/tentativa-1/progress.json
```

`start` e `heartbeat` renovam o lease pelo TTL original. Tokens incorretos, outro owner e lease expirado falham. Checkpoint não é heartbeat: renovar antes de o prazo vencer. Outputs são criados pelo worker, não pelo CLI.

Para bloqueio ou falha, usar checkpoint com `failed_retryable`, `blocked_external` ou `needs_input`. A nota deve apontar causa e próximo passo. Esses estados liberam o lease e recursos, preservando referências no histórico da tentativa. `failed_retryable` permite novo claim; bloqueios exigem `configure` explícito quando o coordenador tiver resolvido ou delimitado o novo pacote.

O programa não encerra processos quando recebe checkpoint. O worker deve terminar sua operação e deixar o recurso ocioso antes de declarar bloqueio ou enviar evidência final.

Para uma entrega parcial bem-sucedida que ainda não satisfaz todo o aceite, usar `--state ready`. Isso grava nota e evidências na tentativa, libera o lease e os recursos e permite outro worker continuar com os mesmos inputs e escopo, sem classificar o trabalho como falha ou aprovar a tarefa:

```bash
python3 tools/recon_queue.py checkpoint T001 --actor agente-artefatos --lease-id TOKEN \
  --state ready --note 'Lote concluído; próximo passo: reconciliar cópias e revisão do cliente' \
  --evidence out/recon/tasks/T001/tentativa-1/result.json
```

O claim seguinte gera token novo e conserva as evidências anteriores no histórico da tentativa. `ready` não certifica comportamento e não satisfaz dependências que exigem `done`.

## Submissão e revisão independente

```bash
python3 tools/recon_queue.py checkpoint T001 --actor agente-artefatos --lease-id TOKEN \
  --state evidence_ready --note 'Baseline pronta; revisar hashes, versões e lacunas' \
  --evidence out/recon/tasks/T001/tentativa-1/result.json
python3 tools/recon_queue.py review T001 --actor agente-validador \
  --verdict accept --note 'Conferi identidade, splits e limites conforme o aceite T001'
```

Submissão exige pelo menos um arquivo de evidência, revalida inputs e grava seu hash. O estado persistido passa diretamente a `review`, liberando o lease de execução. Existência de arquivo **não** marca `done`.

Revisão aceita somente tarefa em `review`; o reviewer não pode ser nenhum autor registrado nas tentativas. Para aceitar, revalida hashes de inputs, evidências e dependências transitivas; pais com filhos descobertos ainda não `done` são recusados. A conclusão resulta de um veredito explícito, acompanhado de justificativa.

Uma revisão rejeitada (`--verdict reject`) passa a `rejected`, permitindo nova tentativa. A rejeição pode registrar evidências stale sem aprová-las; depois, o coordenador reconfigura os inputs corretos. Aprovação de evidência stale sempre falha.

Os nomes de atores são identificadores locais declarados pelo operador. **Não há autenticação nem prova de que dois nomes correspondem a agentes/pessoas diferentes.** A revisão técnica continua sendo responsabilidade de quem executa o papel; a ferramenta apenas registra e verifica separação dos identificadores e transições. Ela não certifica equivalência semântica automaticamente.

## Retomada de lease expirado

```bash
python3 tools/recon_queue.py recover T001 --actor coordenador --confirm-idle \
  --note 'Verifiquei que worker/processo e recurso estão ociosos; outputs preservados'
python3 tools/recon_queue.py claim T001 --actor novo-worker --seconds 600
```

Expiração sozinha não libera tarefa ou lock lógico, mesmo que outro worker queira um recurso igual. O coordenador precisa verificar processo/recurso e declarar `--confirm-idle`. O comando não verifica essa declaração pelo sistema operacional; não mata processos, apaga arquivos ou rouba automaticamente trabalho. Recuperação cria estado `stale`, conserva o histórico e libera a posse anterior; novo claim gera token diferente. Um processo antigo com o token anterior não consegue renovar ou submeter resultado.

## Integridade, concorrência e limites atuais

- Todas as operações usam `flock` em arquivo `.lock` separado. Uma disputa real sobre a mesma fila concede um único claim. Locks coordenam apenas processos que usam este CLI.
- Cada mutação valida tudo antes de gravar, usa temporário no mesmo diretório, fsync, substituição atômica e fsync do diretório. Uma falha anterior ao replace mantém o estado anterior. Arquivos parciais deixados por uma morte abrupta não são importados como evidência nem promovidos.
- Não editar a fila à mão durante execução. O modelo é local e confiável; não protege contra alguém com permissão para adulterar seus JSONs, código, relógio ou nomes de atores.
- Inputs alterados bloqueiam claim/submissão/aprovação. Evidência stale de uma dependência concluída também bloqueia claim e aprovação dos descendentes; não há invalidação automática de estados já `done` nem comando de reabertura nesta versão. Esse gerenciamento é parte de T010 e deve ser implementado antes de manutenção ampla de entregas concluídas.
- A fila importa especificações de filhos geradas por ferramentas externas; não descobre automaticamente novas funcionalidades, modifica dependências existentes, executa aceitadores por tipo, produz métricas V/L/C, gerencia orçamento/tokens ou inicia agentes.
- Não há autenticação remota, scheduler persistente, mutex entre filas distintas, análise da completude de um resultado ou supervisão de processo. Um documento/plano e essa fila não significam reconstrução autônoma ativa.
- Um recurso exclusivo protege apenas quem declarou o mesmo nome. Trabalhos fora do CLI e caminhos sobrepostos ainda precisam de coordenação e worktrees isolados.

## Verificação executada

```bash
python3 -m unittest discover -s tools -p test_recon_queue.py -v
```

Casos cobertos: configuração obrigatória; dependências; reviewer separado; falsificação simples de `done`; hashes stale; rejeição de evidência stale sem aprovação; erros de transição; bloqueio/falha e histórico; entrega parcial retomável via `ready`; token/dono/heartbeat; lease expirado sem roubo; recursos exclusivos; recuperação com declaração explícita; concorrência real entre claims de pai ou filho; escape via symlink; ciclos; importação atômica inválida; parent ausente/ocupado; fechamento independente de filhos; gate de horário antes/depois e timestamps sem timezone; interrupção simulada antes do replace preservando a fila.

Os testes criam somente filas temporárias. A execução deles não inicializa ou avança `reports/recon/tasks.json`.
