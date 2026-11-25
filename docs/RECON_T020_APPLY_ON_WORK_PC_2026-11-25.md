# T020: aplicar a evidencia das 74 classes na fila formal (passo A, na maquina cujo root existe) — 2026-11-25

Contexto: `RECON_T020_QUEUE_REGISTRATION_2026-11-25.md`. Nesta maquina nao da para registrar (o `root` da fila nao existe e a relocacao e recusada por `T025/METHOD/5fe1bb4a25183678`).
O pacote abaixo permite aplicar onde o root existe.

## Pacote
`reports/recon/t020_evidence_1.230/<hash>/{class-contract,recount,result}.json` para as **74** tarefas `T020/CLASS/<hash>` (1,7 MB). Sao as mesmas evidencias descritas no doc acima
(causa verificada por ablacao; reconciliacao: 61 exatas, 13 divergem para mais).

## Passos (na maquina do `root`)
```
git fetch origin && git switch t020-evidence-package        # ou main, depois do merge do PR do pacote
mkdir -p out/recon/tasks/T020/CLASS
cp -r reports/recon/t020_evidence_1.230/* out/recon/tasks/T020/CLASS/
python3 tools/recon_t020_register.py --apply-queue --no-write --limit 2    # teste com 2 tarefas
python3 tools/recon_t020_register.py --apply-queue --no-write              # as 74 (leva alguns minutos: ~3 mutacoes por tarefa, cada uma revalida a fila inteira)
git add reports/recon/tasks.json && git commit -m "T020: 74 tarefas T020/CLASS em review (evidencia do 1.230)"
```
O script: `configure` se a tarefa estava `blocked_external` (so `BWYWGiftData`), `claim`, `start` e `checkpoint evidence_ready`; a fila a leva a `review`. **Nunca** marca `done`: falta o revisor independente.
Requisitos: `python3` e `tools/recon_queue.py`; nao precisa de UnityPy, do build nem dos dumps (`--no-write`). As entradas declaradas das tarefas (`reports/recon/baseline.json`, `dump_coverage.json`) e as evidencias das
tarefas `done` precisam bater com os hashes registrados na fila, como em qualquer operacao dela.

## Verificado aqui (sem tocar na fila real)
Numa pasta simulada contendo so o pacote e os arquivos que a fila referencia, com o `root` ajustado na copia, `--apply-queue --no-write --limit 3` levou 3 tarefas a `review`. A fila real continuou na revisao 235.

## Passo B (depois de A)
Resolver `T025/METHOD/5fe1bb4a25183678` (3 de 4 hashes de evidencia desatualizados; reenviar com hashes atuais ou rejeitar por evidencia desatualizada, decisao de revisor) e so entao relocar a fila para esta maquina.
Fazer B antes de A criaria dois `tasks.json` divergentes (arquivo de ~1 MB), com conflito de merge.
