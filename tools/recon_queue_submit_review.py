#!/usr/bin/env python3
"""Submete uma tarefa da fila viva com evidencia e registra o veredito de um revisor distinto.

Rode na raiz do repo cuja fila (`reports/recon/tasks.json`) tem `root` valido nesta maquina
(senao `python3 tools/recon_queue.py status` ate funciona, mas claim/checkpoint falham com
"reference must resolve to a regular file within queue root"; nesse caso use `relocate` antes).

  python3 tools/recon_queue_submit_review.py submit <task_id> [doc_extra ...]
  python3 tools/recon_queue_submit_review.py accept <task_id> "<nota com as ressalvas>"
  python3 tools/recon_queue_submit_review.py reject <task_id> "<motivo>"

`submit` = claim -> start -> checkpoint evidence_ready (evidencia = todos os arquivos de
out/recon/tasks/<task_id>/ + docs extras). `accept`/`reject` usam um ator DIFERENTE do autor,
exigencia da fila (revisor nao pode ser autor de nenhuma tentativa). Nada aqui marca `done`
sem um veredito explicito de quem executa o comando.
"""
import glob
import os
import sys
from pathlib import Path

sys.path.insert(0, str(Path(__file__).resolve().parent))
from recon_queue import Queue  # noqa: E402

AUTHOR = "agente-re-capstone-claude"
REVIEWER = "revisor-independente-subagente"


def main():
    if len(sys.argv) < 3:
        sys.exit(__doc__)
    step, tid = sys.argv[1], sys.argv[2]
    q = Queue(Path("reports/recon/tasks.json"))
    if step == "submit":
        c = q.claim(tid, AUTHOR, 3600)
        lid = c["lease"]["id"]
        q.heartbeat(tid, AUTHOR, lid, start=True)
        base = f"out/recon/tasks/{tid}"
        evidence = sorted(p for p in glob.glob(base + "/*") if os.path.isfile(p) and not p.endswith(".pyc"))
        evidence += sys.argv[3:]
        q.checkpoint(tid, AUTHOR, lid, "evidence_ready",
                     "Contrato recuperado por Capstone + metadata; adendo followup_2026-11-23.json; "
                     "revisao independente em docs/REVIEW_INDEPENDENT_RE_2026-11-23.md. "
                     "Reservas: LSDA formal e validacao dinamica abertas.", evidence)
        print("submetida", tid, len(evidence), "evidencias")
    elif step in ("accept", "reject"):
        if len(sys.argv) < 4:
            sys.exit("falta a nota/justificativa")
        q.review(tid, REVIEWER, step == "accept", sys.argv[3])
        print("revisao registrada:", step, tid)
    else:
        sys.exit(__doc__)


if __name__ == "__main__":
    main()
