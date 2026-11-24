# Verificacao de T020/CLASS/InventoryBuildData e InventorySkinsBuildData — 2026-11-24

Verificacao feita por Claude (nao foi autor das tentativas) sobre os artefatos ja versionados; **nao** e o veredito formal da fila (o `accept` nao foi registrado, ver fim).
Nao reexecutei a leitura via UnityPy (estoura memoria no host); verifiquei o que o `recount.json` afirma contra os dados ja decodificados em `out/mb`.

| Item | InventoryBuildData (`22379dfdf824449b`) | InventorySkinsBuildData (`90da446022c5664c`) |
|---|---|---|
| Erro original preservado (`before`) | `EOFError: read_str out of bounds`, err=1 | idem, err=2 |
| Instancias reconciliadas | 1/1 (path_id 217, `sharedassets1.assets`) | 2/2 (path_ids 721792 e 721793, `resources.assets`) |
| Linhas em `out/mb/<classe>.jsonl.gz` | 1 | 2 |
| `path_id`+arquivo batem com `affected_objects` | sim | sim |
| `out/mb/_stats.json` | `{ok: 1}`, fora de `erros` | `{ok: 2}`, fora de `erros` |
| Conteudo decodificado | `packToItems.packs[]` com GUID de pacote e lista de GUIDs de itens | `flagsToSkins.packs[]` com `flag`, `spineType` e nomes de skin |
| `m_Script` presente / campos | sim / 5 campos | sim / 5 campos |

Conclusao da verificacao: a reconciliacao de contagem fecha, a causa original esta registrada e os dados decodificados sao coerentes com o schema das demais classes.
Reservas: a releitura dinamica com UnityPy nao foi refeita; o fix foi aplicado antes e as saidas preenchidas depois (`reconciliation_note`).

## Estado na fila
As duas tarefas continuam em `review`. Aprovar exige um revisor que nao seja autor de nenhuma tentativa:
```
python3 tools/recon_queue.py review T020/CLASS/22379dfdf824449b --actor <revisor> --verdict accept --note "..."
python3 tools/recon_queue.py review T020/CLASS/90da446022c5664c --actor <revisor> --verdict accept --note "..."
```
(requer `assets/*.apk` e `out/recon/il2cpp/*` presentes e a fila com `root` valido; hoje o `root` e o worktree `re-capstone-dispatch`.)
