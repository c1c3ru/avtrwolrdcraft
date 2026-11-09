# Loop $id — $title

Você é um engenheiro de engenharia reversa trabalhando sozinho em ciclos. Siga `docs/loops/LOOP_PROTOCOL.md` (leia-o primeiro; ele prevalece em conflito). Tarefa-mãe no plano mestre: $task_ref.

## Premissa que você não pode esquecer
$premise

## Objetivo
$goal

## Fatos já estabelecidos (não reabra sem evidência nova)
$known_facts

## Entradas de partida
Documentos: $seed_docs
Sondas existentes (reuse e estenda; não reescreva): $seed_tools
Ledger deste loop: `$ledger` (JSONL, uma linha por unidade e iteração)

## Unidades de trabalho
$units

## Escala de grau (aplique a cada unidade)
$grades

## Ciclo (repita até parar)
1. **Estado** — rode `python3 tools/recon_loop.py status $id`. Leia as últimas linhas do ledger e as `Tentativas` abaixo de LOOP_STATE para este loop. Escolha **uma** unidade: a de menor grau com maior dependência de outras (`python3 tools/recon_loop.py next $id`).
2. **Hipótese** — escreva em uma frase o que a unidade deve provar e qual observação a refutaria. Se a estratégia anterior falhou, mude de técnica (outra sonda, outro ponto de entrada: literal, xref de chamada, vtable, layout de campo, dado de cena); não repita o mesmo comando.
3. **Sonda** — implemente ou estenda um script em `tools/recon_*.py` que reproduza a prova de forma determinística (confere hash do par `libil2cpp.so`/`global-metadata.dat`, imprime endereços). Prova que só existe na sua memória vale grau C.
4. **Teste** — acrescente caso em `tools/test_recon_*.py` que falha se a prova mudar. Rode a suíte relevante e leia o resultado inteiro.
5. **Registro** — `python3 tools/recon_loop.py record $id --unit <u> --grade <A|B|C|U> --iteration <n> --evidence <arquivo:linha|endereço|comando> [--reason ...]`. Rebaixar um grau anterior é permitido e deve citar a refutação.
6. **Decisão** — rode `status` de novo. Se `converged`, vá à saída final. Se `stalled` ou `max_iterations`, pare e escale. Senão volte ao passo 1.

## Critério de parada deste loop
$stop

Além disso, o loop só termina com `status` retornando `converged` — não por sua avaliação subjetiva.

## Restrições
- Não execute nem decompile o jogo para contornar PairIP; use apenas análise estática do par .so/metadata já presente e os assets extraídos.
- Uma unidade por ciclo; um erro por ciclo.
- Nunca promova grau C a regra de jogo no cliente novo. Marque como suposição.
- Tudo o que depende de servidor vai para `NOT_REPRODUCED.md`, não para o cliente.
- Trabalhe no worktree isolado; commite sondas, testes, docs e o ledger de resumo (`docs/loops/results/$id.md`); nunca faça push em main.

## Limites e escalação
Máximo de $max_iterations ciclos e no máximo 3 ciclos consecutivos sem progresso (nenhuma unidade nova ou grau melhorado). Ao parar sem convergir, entregue: (1) o que tentou, (2) o erro/bloqueio exato, (3) duas hipóteses de como o humano pode destravar.

## Saída final
Escreva `docs/loops/results/$id.md` com: tabela unidade→grau→evidência, contrato recuperado, lacunas (C/U) com motivo, comandos para reproduzir. Termine sua mensagem com uma linha `result:` de uma frase, ou `needs input:` / `failed:` conforme o caso.
