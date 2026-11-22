"""Fecha em lote, na fila formal (tools/recon_queue.py), as tarefas T020/CLASS cuja causa raiz e
'tipo removido do binario IL2CPP shipado' (ver docs/RECON_T020_NODE_TREE_TRIAGE_2026-11-22.md,
categoria type_stripped_from_release_il2cpp_metadata). Usado uma vez em 2026-11-22 pras 20 classes
PWC.EditorApp.*; rodar de novo so se outra leva de classes cair nessa mesma categoria (gerar o
mapeamento classe->task_id a partir de reports/recon/tasks.json['tasks'][i]['scope']['class_name']
e passar como entrada, no lugar do /tmp/stripped_task_ids.json hardcoded abaixo).

Fecha como blocked_external, nao evidence_ready: o criterio de aceite de cada tarefa exige
identificar cada objeto afetado (path_id/arquivo exato), que so da pra saber abrindo o
datapack.unity3d (bloqueado por RAM nesta maquina) - so a contagem agregada e conhecida.
"""
import json, sys
from pathlib import Path

sys.path.insert(0, "/home/c1c3ru/avtrwolrdcraft/.claude/worktrees/gentle-squishing-bird/tools")
from recon_queue import Queue

ACTOR = "agente-artefatos-claude"
QUEUE_PATH = Path("/home/c1c3ru/avtrwolrdcraft/.claude/worktrees/gentle-squishing-bird/reports/recon/tasks.json")
WORKTREE_OUT = Path("/home/c1c3ru/avtrwolrdcraft/.claude/worktrees/gentle-squishing-bird/out/recon/tasks/T020/CLASS")
MAIN_OUT = Path("/home/c1c3ru/avtrwolrdcraft/out/recon/tasks/T020/CLASS")

mapping = json.load(open("/tmp/stripped_task_ids.json"))

q = Queue(QUEUE_PATH)

for cname, tid in mapping.items():
    short = cname.rsplit(".", 1)[-1]
    task_hash = tid.rsplit("/", 1)[-1]
    claimed = q.claim(tid, ACTOR, 3600)
    lease_id = claimed["lease"]["id"]
    q.heartbeat(tid, ACTOR, lease_id, start=True)

    err_count = claimed["scope"]["declared_counts"]["err"]
    ns, _, cls_only = cname.rpartition(".")
    il2cpp_style_name = f"{ns}::{cls_only}"
    contract = {
        "class": cname,
        "assembly": "Assembly-CSharp",
        "unity_class_id": "MonoBehaviour (114)",
        "original_failure": f'Type "{il2cpp_style_name}" was not found in the IL2CPP metadata.',
        "root_cause": {
            "summary": (
                "The type does not exist in this build's IL2CPP metadata/binary at all. "
                "TypeTreeGenerator.get_nodes_as_json() fails immediately with "
                f'\'Type "{cname.rsplit(".", 1)[0]}::{short}" was not found in the IL2CPP metadata.\' '
                "before any field layout can even be attempted - this is not a parsing bug, "
                "the type genuinely is not present to parse."
            ),
            "evidence": (
                "Confirmed 2026-11-22: not one of the 20 PWC.EditorApp.* classes with this exact "
                "failure signature exists anywhere in out/cpp2il/DiffableCs (the full Cpp2IL static "
                "decompile of this build's Assembly-CSharp) - not even the literal string "
                "'EditorApp' appears anywhere in that decompiled tree. Checked systematically "
                "(grep across the whole tree), not by sampling."
            ),
            "interpretation": (
                "Classic Unity/IL2CPP managed code stripping: PWC.EditorApp.* is internal level/content "
                "editor tooling (login, search, hierarchy, level-editor panels - judging by the class "
                "names) that is never statically referenced by the shipped game code path, so the "
                "IL2CPP build stripped the types entirely. A stale MonoScript object (just a name "
                "string pointing at the now-absent type) remains in the serialized assets, which is "
                "why out/mb/_stats.json still lists it as a failing class instead of simply absent."
            ),
        },
        "fix": "None possible - the type is not in the binary to parse. Not a tools/mb_dump.py bug.",
        "resolvability": "Confirmed unresolvable with any static-analysis approach against this build. "
                          "The only theoretical recourse would be an older/different build of the APK that "
                          "still ships this editor tooling, which is out of scope.",
    }

    recount = {
        "class": cname,
        "before": {"err": err_count, "err_message": "ValueError or EOFError depending on instance - "
                                                       "root cause is identical: type not in IL2CPP metadata"},
        "after": {"ok": 0, "bad": 0, "err": err_count},
        "status": "confirmed_unresolvable_type_stripped_from_release_binary",
        "object_identities": (
            "NOT individually identified (path_id/file) - doing so needs the datapack.unity3d "
            "container opened (needs ~6GB+ RAM, repeatedly OOM'd on this machine, see LOOP_STATE.md "
            "2026-11-21/22). Only the aggregate count from out/mb/_stats.json is known. This is an "
            "explicit, named gap, not a silently-skipped detail: the exact object count "
            f"({err_count}) is known and preserved; which specific serialized objects they are is not."
        ),
        "unresolved_objects": f"{err_count} objects of this class, identities unknown (see object_identities)",
    }

    result = {
        "task": tid,
        "title": claimed["title"],
        "actor": ACTOR,
        "summary": (
            f"{cname}: confirmed as type-stripped-from-release-binary, not a decoding bug. "
            "Checkpointed as blocked_external rather than evidence_ready because this task's "
            "acceptance criterion 'identify every affected object' cannot be met without the "
            "datapack (which repeatedly OOMs this machine) - only the aggregate failure count is "
            "known, not individual object path_ids. See docs/RECON_T020_NODE_TREE_TRIAGE_2026-11-22.md "
            "for the full cross-class investigation (20 classes, same root cause, same evidence method)."
        ),
        "evidence": [
            f"out/recon/tasks/T020/CLASS/{task_hash}/class-contract.json",
            f"out/recon/tasks/T020/CLASS/{task_hash}/recount.json",
            "docs/RECON_T020_NODE_TREE_TRIAGE_2026-11-22.md",
            "out/recon/tasks/T020/node_tree_triage_2026-11-22.json",
        ],
        "next_action_if_ram_available": (
            "If this is ever revisited with enough RAM to load datapack.unity3d: confirm the object "
            "count/identities for completeness, but do NOT expect the type to become readable - the "
            "root cause (type absent from IL2CPP metadata) cannot be fixed by any parser change."
        ),
    }

    for sub, outdir in ((WORKTREE_OUT, WORKTREE_OUT), (MAIN_OUT, MAIN_OUT)):
        d = outdir / task_hash
        d.mkdir(parents=True, exist_ok=True)
        (d / "class-contract.json").write_text(json.dumps(contract, indent=1, ensure_ascii=False), encoding="utf-8")
        (d / "recount.json").write_text(json.dumps(recount, indent=1, ensure_ascii=False), encoding="utf-8")
        (d / "result.json").write_text(json.dumps(result, indent=1, ensure_ascii=False), encoding="utf-8")

    checkpointed = q.checkpoint(
        tid, ACTOR, lease_id, "blocked_external",
        note=(f"{cname}: confirmado ausente do binario IL2CPP shipado (nao existe no out/cpp2il "
              f"decompilado inteiro, verificacao sistematica 2026-11-22). Nao e bug de parsing - "
              f"nao ha o que corrigir. Identificacao individual dos {err_count} objetos (path_id/arquivo) "
              f"bloqueada por RAM (precisa do datapack). Ver docs/RECON_T020_NODE_TREE_TRIAGE_2026-11-22.md."),
        evidence=[
            f"out/recon/tasks/T020/CLASS/{task_hash}/class-contract.json",
            f"out/recon/tasks/T020/CLASS/{task_hash}/recount.json",
        ],
    )
    print(f"{cname} -> {checkpointed['state']}", flush=True)

print(json.dumps(q.status(), indent=1))
print("ALL DONE")
