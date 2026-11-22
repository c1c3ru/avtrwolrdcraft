"""Fecha em lote, na fila formal (tools/recon_queue.py), as tarefas T020/CLASS cuja causa raiz e
'TypeTreeGeneratorAPI quebra num campo SerializableDictionaryBase<K,V> cru' (ver
docs/RECON_T020_NODE_TREE_TRIAGE_2026-11-22.md). So fecha as que tem o campo CONFIRMADO no fonte
decompilado (/tmp/nullref_confirmed_fields.json) - as 3 excecoes com a mesma mensagem nativa mas
sem esse campo (GameExtraSettings, LocalizationManager, WindowManager) ficam de fora de proposito.

Fecha como blocked_external, nao evidence_ready: mesmo motivo do script irmao
close_type_stripped_tasks_2026-11-22.py - identificar cada objeto afetado exige o datapack.
"""
import json, sys
from pathlib import Path

sys.path.insert(0, "/home/c1c3ru/avtrwolrdcraft/.claude/worktrees/gentle-squishing-bird/tools")
from recon_queue import Queue

ACTOR = "agente-artefatos-claude"
QUEUE_PATH = Path("/home/c1c3ru/avtrwolrdcraft/.claude/worktrees/gentle-squishing-bird/reports/recon/tasks.json")
WORKTREE_OUT = Path("/home/c1c3ru/avtrwolrdcraft/.claude/worktrees/gentle-squishing-bird/out/recon/tasks/T020/CLASS")
MAIN_OUT = Path("/home/c1c3ru/avtrwolrdcraft/out/recon/tasks/T020/CLASS")

mapping = json.load(open("/tmp/nullref_confirmed_task_ids.json"))
fields = json.load(open("/tmp/nullref_confirmed_fields.json"))

q = Queue(QUEUE_PATH)

for cname, tid in mapping.items():
    task_hash = tid.rsplit("/", 1)[-1]
    fdata = fields[cname]
    claimed = q.claim(tid, ACTOR, 3600)
    lease_id = claimed["lease"]["id"]
    q.heartbeat(tid, ACTOR, lease_id, start=True)

    err_count = claimed["scope"]["declared_counts"].get("err", 0)

    contract = {
        "class": cname,
        "assembly": "Assembly-CSharp",
        "unity_class_id": "MonoBehaviour (114)",
        "original_failure": "ValueError or EOFError at read time; node generation itself raises "
                              "AssertionError: failed to dump nodes as json (native message: "
                              "'Object reference not set to an instance of an object.')",
        "root_cause": {
            "summary": (
                f"TypeTreeGeneratorAPI crashes while resolving the field `{fdata['field_name']}` "
                f"declared as a raw generic instantiation `{fdata['field_type']}` (from "
                "RotaryHeart.Lib.SerializableDictionary, a third-party asset) directly on this "
                "class - not through a named, non-generic subclass. Confirmed present in the "
                f"decompiled source: {fdata['file']}."
            ),
            "mechanism": (
                "SerializableDictionaryBase<TKey,TValue> declares [SerializeField] private TKey[] "
                "_keys; TValue[] _values; (plus a legacy _keyValues list). When TKey/TValue are "
                "supplied as a raw, unnamed closed generic instantiation on the field itself "
                "(rather than via a concrete non-generic subclass), TypeTreeGeneratorAPI's native "
                "IL2CPP metadata walker throws an internal null reference exception while trying "
                "to resolve the specialized array element types - before any type tree node is "
                "produced for this class at all."
            ),
            "confirmed_not_a_parsing_bug_in_this_repo": (
                "This is identical in nature to the bug already fixed in tools/mb_dump.py "
                "(fix_mislabeled_vectors, for mislabeled List<String> root nodes) but happens one "
                "level earlier and inside the native extension itself - there is no Python-side "
                "node list to post-process, because get_nodes_as_json() raises before returning "
                "anything. TypeTreeGeneratorAPI is already at its latest published version (0.0.10, "
                "checked 2026-11-21); no newer release to try."
            ),
        },
        "fix": "None available without a different type-tree extraction tool (this one cannot "
               "resolve raw generic SerializableDictionaryBase<K,V> fields at all).",
        "resolvability": "Blocked on tooling, not on data or analysis effort.",
    }

    recount = {
        "class": cname,
        "before": {"err": err_count},
        "after": {"ok": 0, "bad": 0, "err": err_count},
        "status": "confirmed_blocked_by_typetreegeneratorapi_limitation",
        "object_identities": (
            "NOT individually identified (path_id/file) - this is a node-generation-time failure "
            "(happens before any object of the class is even attempted), and confirming the exact "
            "object count/identities would need the datapack.unity3d container opened anyway "
            "(repeatedly OOM'd on this machine, see LOOP_STATE.md). Only the aggregate count from "
            f"out/mb/_stats.json is known ({err_count})."
        ),
        "unresolved_objects": f"{err_count} objects of this class, identities unknown",
    }

    result = {
        "task": tid,
        "title": claimed["title"],
        "actor": ACTOR,
        "summary": (
            f"{cname}: confirmed blocked by a TypeTreeGeneratorAPI limitation resolving the raw "
            f"generic field `{fdata['field_name']}: {fdata['field_type']}` - verified present in "
            "the decompiled source (not inferred from the error message alone; checked "
            "individually, 27 of 30 classes sharing this native error signature have this exact "
            "field shape, 3 do not and were left open/undiagnosed rather than batch-closed on an "
            "unverified assumption). Checkpointed as blocked_external, not evidence_ready: exact "
            "object identities are unknown (needs the datapack, which repeatedly OOMs this "
            "machine)."
        ),
        "evidence": [
            f"out/recon/tasks/T020/CLASS/{task_hash}/class-contract.json",
            f"out/recon/tasks/T020/CLASS/{task_hash}/recount.json",
            fdata["file"],
            "docs/RECON_T020_NODE_TREE_TRIAGE_2026-11-22.md",
            "out/recon/tasks/T020/node_tree_triage_2026-11-22.json",
        ],
        "not_batch_closed_without_individual_verification": (
            "PazuCore.GameExtraSettings, PazuCore.LocalizationManager and PazuCore.WindowManager "
            "share the same native error message but do NOT have a SerializableDictionaryBase<K,V> "
            "field in their decompiled source - their real trigger is still unknown and they were "
            "deliberately left pending/ready rather than closed with an unverified claim."
        ),
    }

    for outdir in (WORKTREE_OUT, MAIN_OUT):
        d = outdir / task_hash
        d.mkdir(parents=True, exist_ok=True)
        (d / "class-contract.json").write_text(json.dumps(contract, indent=1, ensure_ascii=False), encoding="utf-8")
        (d / "recount.json").write_text(json.dumps(recount, indent=1, ensure_ascii=False), encoding="utf-8")
        (d / "result.json").write_text(json.dumps(result, indent=1, ensure_ascii=False), encoding="utf-8")

    checkpointed = q.checkpoint(
        tid, ACTOR, lease_id, "blocked_external",
        note=(f"{cname}: campo `{fdata['field_name']}: {fdata['field_type']}` confirmado no fonte "
              f"decompilado ({fdata['file']}) - TypeTreeGeneratorAPI quebra ao resolver esse padrao "
              f"de dicionario generico cru (limitacao da lib nativa, ja na versao mais recente). "
              f"Identificacao individual dos {err_count} objetos bloqueada por RAM. Ver "
              f"docs/RECON_T020_NODE_TREE_TRIAGE_2026-11-22.md."),
        evidence=[
            f"out/recon/tasks/T020/CLASS/{task_hash}/class-contract.json",
            f"out/recon/tasks/T020/CLASS/{task_hash}/recount.json",
        ],
    )
    print(f"{cname} -> {checkpointed['state']}", flush=True)

print(json.dumps(q.status(), indent=1))
print("ALL DONE")
