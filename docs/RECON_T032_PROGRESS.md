# T032 — callbacks, posição de NPC e movimento por família

Recuperação estática de 2026-11-08, sobre Avatar World **1.227 / code228**. Os três recortes solicitados foram aprofundados com bytes ARM64, metadata e dados serializados; o pacote pai continua sem aceite completo. Não houve alteração de gameplay no cliente. A integração pertence à T049 e precisa reconciliar as diferenças abaixo antes de reivindicar paridade.

| Recorte | Resultado sustentado | Limite |
| --- | --- | --- |
| Dispatch | 21 virtuais, 9 chamadas ILevelAvatar, 2 IHasPersistentData; slots concretos para seis famílias; três closures de passo com todos os opcodes conferidos | Receptor derivado pode sobrescrever virtual; ordem/cardinalidade dinâmica de listeners não executada |
| NPC | Caller faz spawn ou reposicionamento direto; fundo inicializa aparência e toca animação seguida de idle; walkway transporta itens por tween | Isso não prova ausência de autonomia em outros scripts/cenas |
| Famílias | Nome real de caminhada, capabilities de corrida/caminhada e velocidade por deltaTime recuperados; Baby herda movimento físico da base | Composição com CA travada e ciclo completo de cancelamento ainda precisam de integração/validação |

## Dispatch de callbacks

`LevelAnimal.OnMovement` despacha `GetPickUpLoopAnimationName` (slot154), `HasRunningAnimations` (147), `GetWalkingAnimationName` (158) e `GetRunningAnimationName` (159). A vtable substitui as antigas atribuições por semelhança de strings. Cat/Dog/Horse herdam esses métodos. O probe também resolve `GetLockedAnimationName` no início do movimento do Character/Animal.

As closures de passo de Animal, CharacterAnimator e Toddler retornam se `OnStepContact` for nulo; caso contrário encaminham `(entidade, spineEvent)`. Ignoram TrackEntry e não filtram o nome do evento. O animator encaminha `_character`. Essa descoberta não mede quantas vezes o Spine emite eventos.

Baby/Cat/Dog/Horse respeitam o virtual `LevelDropArea.OverrideAvatarEndDropAnimation` ao aterrissar. Os oito indiretos de `PlaceAvatarInScene` foram resolvidos, incluindo disponibilidade de área, `GetLevelItem`, `SitAvatarOn`, consumo e snap. A polaridade peculiar do gate de Sleep foi preservada: o ramo aborta quando o virtual retorna verdadeiro; não foi corrigida por suposição.

Baby begin despacha `(this,true)` e land `(this,false,true)`. Layout, assinatura e outro consumidor do mesmo GOT apontam unicamente a `CATargetEvents.OnSelectedAction` e `OnUpdateCAListAction`; **a atribuição nominal permanece inferida** porque o metadata usage do GOT é não canônico. Os subscribers concretos não foram fechados.

Fontes: [relatório de dispatch](../out/recon/tasks/T032/callbacks/REPORT.md), [probe](../out/recon/tasks/T032/callbacks/probe.py), [joins](../out/recon/tasks/T032/callbacks/dispatch.json), [callbacks Baby](../out/recon/tasks/T032/families/delegates.json).

## Posição e autonomia de NPC

Os 229 mapas de cena contêm 1.170 registros, 1.157 IDs distintos e todos os registros têm `isOnPhone=true`. Não são um inventário de NPCs colocados no mundo. `GetAllLevelDefaultAvatarsID` filtra essa flag; `RestoreMakerExcludedSkinClothingIfNeeded` consome as coordenadas para restaurar roupas excluídas; AvatarAwake utiliza o sceneGuid. O relatório preserva o universo examinado e os consumidores encontrados.

`LevelCharacterCaller.CallCharacter` usa callPoint ou a própria posição. Se o Character existente satisfaz a condição de visibilidade, pode animá-lo no lugar; para convocá-lo, chama `DetachFromParentIfExists(true)` e grava diretamente a posição. Se ausente, faz spawn. Não há caminhada interpolada nesse método. `Renderer.isVisible` é o teste concreto recuperado.

Managers de fundo de Character/Toddler inicializam aparência; `SetAnimation` toca a faixa0 sem loop e enfileira o idle com loop. Nenhum dos corpos examinados escolhe destino ou escreve posição. Walkway é um mecanismo distinto de transporte de LevelItem, com tween e cancelamento por clique; não comprova decisão autônoma de NPC.

Fontes: [contrato de NPC](../out/recon/tasks/T032/npc/REPORT.md), [censo](../out/recon/tasks/T032/npc/census.json), [validação de bytes](../out/recon/tasks/T032/npc/validation.json).

## Movimento por família e diferenças no cliente

- Animal desbloqueado usa `Track_Animations/Forced_To_Walk` na **faixa0**. Com animação travada, preserva a principal e sobrepõe caminhada em **faixa1**; a limpeza dessa faixa também faz parte do fluxo. O cliente atual usa `General/Walking` e ainda precisa dessa reconciliação.
- `LevelAnimal.HasRunningAnimations` retorna falso e não há override nas subclasses locais recuperadas. O ramo genérico de corrida existe, mas o gate impede sua entrada. Testes antigos com o bool configurado como true exercitam uma capacidade sintética; não são evidência de corrida no original.
- Cinco tipos Tech (Bird/Cat/Dog/Rabbit/Robot) retornam false em HasWalkingAnimations: o movimento físico continua pela base sem acionar a máquina animada. Horse retorna false em HasSwimmingAnimations.
- Baby herda `LevelItem.OnSyncPosition`, sem máquina própria de ciclos de caminhada. Não deve cair no fallback Character do enum atual do cliente.
- Character e Toddler mantêm os contratos anteriores de histerese. Animal usa deslocamento de `Transform.position` dividido por **Time.deltaTime**, confirmado pelo codegen module Unity; a unidade deixa de ser inferência neste caminho.

Fontes: [famílias](../out/recon/tasks/T032/families/REPORT.md), [capabilities](../out/recon/tasks/T032/families/capabilities.json), [joins Unity](../out/recon/tasks/T032/families/engine_calls.json), [revisão independente](../out/recon/tasks/T032/callbacks/review-families.json).

## Verificação, estado e reprodução

Os probes de dispatch, capabilities, chamadas Unity e delegates foram executados; as verificações de NPC e as revisões independentes também passaram. São verificações de artefatos estáticos, não testes de jogo. O [auditor integrado](../tools/recon_t032_acceptance.py) confere hashes, contagens, limitações e o estado real da fila; [recibo](../reports/recon/t032_acceptance.json). A integridade de evidência não equivale ao aceite do pai.

O Android conectado tem **1.228 / code229** e estava bloqueado. Apenas metadados foram lidos; não houve abertura do jogo, downgrade ou alteração de dados. Essa versão não certifica execução da **1.227**. [Recibo do aparelho](../reports/recon/t032_device_version_check.json).

T032 permanece pending na fila: T018, T025, T026, T027 e T031 não têm aceite completo. Continuam necessários runtime correspondente ao binário, ordem/cardinalidade/cancelamento de callbacks, alvos dinâmicos residuais e reconciliação de implementação. Não foram removidos gates nem reduzido o aceite para concluir o pacote.

```bash
python3 out/recon/tasks/T032/callbacks/probe.py
python3 out/recon/tasks/T032/families/check.py
python3 out/recon/tasks/T032/families/engine_calls.py
python3 out/recon/tasks/T032/families/delegates.py
python3 out/recon/tasks/T032/callbacks/review_families.py
tools/venv/bin/python out/recon/tasks/T032/npc/validate.py
tools/venv/bin/python tools/recon_t032_acceptance.py
```

As coletas de ASM (`collect.py` e `npc/extract.py`) e o validador de NPC exigem capstone no interpretador, disponível em `tools/venv/bin/python`. O auditor executa novamente sete probes antes de conferir seus resultados, incluindo comparação integral dos censos com os gzip originais, rejeitando falhas e registrando hashes dos scripts. A primeira execução com Python do sistema falhou pela ausência de capstone; a execução válida usa o venv indicado. O auditor também foi corrigido para aceitar o bool serializado como inteiro 1, conforme os dumps originais. Preservar os manifests anteriores quando uma coleta aceita precisar mudar.
