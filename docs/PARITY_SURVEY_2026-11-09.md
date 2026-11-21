# Levantamento de paridade — 2026-11-09

Medido sobre a branch `world-assets-test-build` (commit `6a2363b5c`). Os percentuais de V/L/C são **estimativas de julgamento** (não há métrica oficial); os números de contagem vêm de `tools/parity_report.py` → `out/parity.json`.

## Marcos (definição em AVATAR_WORLD_MASTER_PLAN.md §1)

| Marco | Estimativa | Base |
|---|---|---|
| V – Varredura | ~70% | Assets extraídos ~99,7% (121.648/121.679 texturas; 2.781 áudios; 2.313 Spine); MonoBehaviours 879.085/881.898; 4.197 classes em `Assembly-CSharp`. Faltam 126 classes MB com erro e vínculo nome↔arquivo dos mapas. |
| L – Lógica recuperada | ~15–20% | Dump IL2CPP só tem assinaturas. Lógica recuperada por sondas pontuais (LoadScene, input/drag, save, animações contextuais, NPCs, carros, céu). 1.551 classes em `Game/Level`, quase nenhuma com lógica recuperada. |
| C – Cópia funcional | ~20–25% | Tabela abaixo. |

## Cópia por área

| Área | Estimativa | Medido |
|---|---|---|
| Home / menus | ~60% | 35 de 39 `Button` do `level3` sem ação equivalente (HomeActions.PendingButtons) |
| Avatar | ~55% | editor Spine + peças das packs |
| Loja | ~50% | 25.812/25.812 itens no cliente, mas **preços inventados** (server-side no original) |
| Mapas | ~40% | 5 mapas em `Resources/Maps` (+ nuvens, trem, carros, céu/tint) |
| Interiores | ~25% | **58/254 cenas (22,8%)**; 58 com itens, 57 com NPCs; 0 falhas de export |
| Gameplay real (minijogos/missões) | ~5% | só quadra (protótipo) e quiz (invenção própria) |
| Online/conta/multiplayer | fora do escopo | não entra no contador (ver NOT_REPRODUCED.md) |

## Achados de processo

- Ledger `AVATAR_WORLD_TASKS.json`: 60/60 em `pending`, embora T025, T029–T033, T035 e T042 tenham evidência em `out/recon/tasks/`.
- Não existia métrica repetível de cobertura → `tools/parity_report.py`.
- Sem diff visual contra o original (capturas ADB do original em `out/device/sbs-nav` podem servir de referência).
- `out/` tem artefatos não versionados.
- Durante esta sessão o checkout principal passou de `world-assets-test-build` para `main` (commit antigo); medições devem usar `--root` apontando para um worktree da branch de trabalho.

## Loops (backlog)

Agendados nesta sessão (cron, só vivem enquanto a sessão está aberta, expiram em 7 dias):

1. **Métrica de paridade** — `python3 tools/parity_report.py`, registra tendência em `out/parity_history.jsonl`.
2. **Sincronizar fila** — reconcilia `AVATAR_WORLD_TASKS.json` com `out/recon/tasks/*` e commits (só atualiza `state`/`evidence_refs`, nunca marca `done` sem revisão).
3. **Exportação de interiores** — lote de cenas ainda sem interior (`export_interior.py`, `mark_interior_items.py`), valida sprites ausentes.

Backlog não agendado: 4 smoke test de cenas, 5 diff visual ADB, 6 lógica de `Game/Level`, 7 interações dos interiores, 8 minijogos, 9 classes MB com erro, 10 CI local.

Guarda comum: cada loop começa com `git branch --show-current`; se não for `world-assets-test-build`, para e avisa, sem trocar de branch.

Uso: `python3 tools/parity_report.py [--root <checkout>] [--no-history]`
