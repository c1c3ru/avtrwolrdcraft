# Cobertura da engenharia reversa — 2026-11-04

## Critério

O inventário separa quatro níveis: **varredura** (conteúdo classificado), **lógica** (contrato do original sustentado por evidência), **implementação offline** e **validação** (teste/comparação do comportamento). Um documento ou tarefa existente não equivale a etapa concluída. Este checkpoint reflete os relatórios e fila atuais; não certifica cobertura total.

## Estado medido

- Fila: revisão 20, 447 tarefas; 3 `done`, 443 `pending`, 1 `stale`; nenhum lease ativo. O `done` restrito cobre identidade da base e pré-requisitos do índice IL2CPP, não paridade do app.
- Cenas: 254 filhos inventariados sob T015, ainda não concluídos na fila. A classificação de BuildSettings não prova reconstrução das 254 cenas.
- Dumps MonoBehaviour: 126 classes/tipos com falha permanecem registrados sob T020; proporção de objetos decodificados não substitui análise por classe, layout ou proveniência.
- Contratos estáticos aprofundados: bootstrap/navegação, callback Home Play/deep link, transição de cena, toque em edifício, gate de acesso. Permanecem dependências indiretas, exceções, handlers e/ou validação runtime em vários contratos.
- Implementação Unity: há Home, avatar visual, quiz local, quadra protótipo e início do mapa World. O próprio `OFFLINE_RECONSTRUCTION_STATUS.md` classifica Play como divergente do original, loja como pendente e vários serviços como dependentes do backend.
- Validação: `LOOP_STATE.md` registra em 2026-11-04 a comparação no aparelho do mapa (composição, arrasto, entrada/retorno da quadra). Uso esse registro como evidência fornecida pela rodada do usuário; não exijo nova atividade no celular. Capturas antigas continuam vinculadas ao APK/revisão descritos em cada entrada.

## Matriz por domínio

Os estados abaixo resumem `reports/recon/features.jsonl`; os IDs apontam para as tarefas canônicas.

| Domínio | Varredura | Lógica | Implementação offline | Validação | Tarefas |
|---|---|---|---|---|---|
| Navegação Home, mapas e ambientes | Parcial | Não fechada | Reconciliar código existente | Reconciliar evidências | T029, T041, T048 |
| Avatares, NPCs e movimento | Parcial | Não fechada | Reconciliar código existente | Reconciliar evidências | T032, T049 |
| Editor, roupas, SUT e presets | Parcial | Não fechada | Reconciliar código existente | Reconciliar evidências | T033, T049 |
| Gestos, objetos e física | Parcial | Não fechada | Reconciliar código existente | Reconciliar evidências | T031, T034, T050 |
| Animações contextuais | Parcial | Não fechada | Reconciliar código existente | Reconciliar evidências | T035, T050 |
| Ambientes e prefabs | Parcial | Não fechada | Reconciliar código existente | Reconciliar evidências | T042, T051 |
| Atividades e pontuação | Parcial | Não fechada | Reconciliar código existente | Reconciliar evidências | T043, T051 |
| Save e progressão | Parcial | Não fechada | Reconciliar código existente | Reconciliar evidências | T030, T044 |
| Render, áudio, clima e tempo | Parcial | Não fechada | Reconciliar código existente | Reconciliar evidências | T036, T050 |
| Loja, presentes, passes e conquistas | Parcial | Não fechada | Reconciliar código existente | Reconciliar evidências | T037, T052, T053 |
| Serviços online e conteúdo remoto | Parcial | Não fechada | Divergência offline a especificar | Reconciliar limites | T039 |

Atualizações (2026-11-04):

- T031: contrato estático de ponteiro/arraste e pilotos `level4`/`level8` em `docs/RECON_INPUT_CONTRACT.md` e `out/recon/tasks/T031/`. Avança entrada, mas não fecha física, gestos completos ou validação dinâmica.
- T032: classificação de presets e contratos iniciais de spawn/movimento em `docs/RECON_CHARACTER_CONTRACT.md` e `out/recon/tasks/T032/`. Avança inventário, mas não fecha locomoção entre famílias, NPCs ou validação dinâmica.

Ambas as linhas permanecem Parciais.

## Backlog que impede declarar a etapa concluída

1. Promover filhos de cenas e classes de dump só após reconciliação dos arquivos reais e revisão; manter `unknown` para itens sem evidência.
2. Reconciliar relatórios existentes de cada domínio com revisão exata do cliente, assembly, APK e testes; atualizar pais sem converter documentação antiga em aceite.
3. Completar os contratos de handlers/dispatch e dependências que ligam mapa → prédio → cena → retorno, incluindo caminhos com erro.
4. Comparar ambientes e interações originais, cena a cena; o protótipo de quadra e o início do mapa não cobrem o catálogo inteiro.
5. Definir fronteiras offline para loja, conta, eventos e multiplayer sem inventar preço ou recompensa de servidor; documentar como divergências.
6. Validar a build atual no aparelho e ligar capturas/logs ao hash do APK e revisão do código em teste.
7. Executar T046/T059/T060 apenas depois de todos os universos/filhos terem estados revisados e sem incógnitas obrigatórias escondidas.

## Próxima fatia recomendada

Prosseguir T030 com a resolução dos despachos indiretos/CFG e comparação de um save runtime para `level8`, usando [RECON_SAVE_CONTRACT.md](RECON_SAVE_CONTRACT.md) e os dois relatórios-piloto em `out/recon/tasks/T030/`. O save estático já tem cadeia principal e cena jogável comparada, mas o cliente ainda não modela posições/objetos por cena. O mapa World tem evidência de aparelho registrada em 04/11, e continua parcial (barra superior, clima/tempo e outros destinos faltam). Em paralelo, seguir T015/T020 em lotes pequenos por cena/classe. Não converter cobertura estática em paridade de gameplay.

Fontes: `reports/recon/tasks.json` (revisão 20), `reports/recon/features.jsonl`, `reports/recon/dump_coverage.json`, `docs/OFFLINE_RECONSTRUCTION_STATUS.md`, `docs/RECON_HOME_PLAY_HANDOFF.md` e `LOOP_STATE.md`.
