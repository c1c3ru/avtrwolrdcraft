"""Fecha as ultimas 3 tarefas T020/CLASS (PazuCore.WindowManager/LocalizationManager/GameExtraSettings)
que tinham a mesma mensagem nativa das 27 ja fechadas por
close_nullref_confirmed_tasks_2026-11-22.py, mas nao foram fechadas junto por nao terem a string
"SerializableDictionaryBase" no proprio arquivo decompilado. Achado: elas referenciam subclasses
NOMEADAS desse generico (Name_Back_Scene, Country_SupportedLanguages etc.) - mesmo mecanismo,
so que indireto. Ver docs/RECON_T020_NODE_TREE_TRIAGE_2026-11-22.md.
"""
import json, sys
from pathlib import Path

sys.path.insert(0, "/home/c1c3ru/avtrwolrdcraft/.claude/worktrees/gentle-squishing-bird/tools")
from recon_queue import Queue

ACTOR = "agente-artefatos-claude"
QUEUE_PATH = Path("/home/c1c3ru/avtrwolrdcraft/.claude/worktrees/gentle-squishing-bird/reports/recon/tasks.json")
WORKTREE_OUT = Path("/home/c1c3ru/avtrwolrdcraft/.claude/worktrees/gentle-squishing-bird/out/recon/tasks/T020/CLASS")
MAIN_OUT = Path("/home/c1c3ru/avtrwolrdcraft/out/recon/tasks/T020/CLASS")

q = Queue(QUEUE_PATH)
d = json.loads(QUEUE_PATH.read_text())
by_name = {t["scope"]["class_name"]: t["id"] for t in d["tasks"] if t["id"].startswith("T020/CLASS/")}

targets = {
    "PazuCore.WindowManager": {
        "field_name": "nameBackScene",
        "field_type": "Name_Back_Scene",
        "intermediate_chain": "Name_Back_Scene : SerializableDictionaryBase<String, BackSceneLoadConfig>",
        "file": "out/cpp2il/DiffableCs/Assembly-CSharp/PazuCore/WindowManager.cs",
    },
    "PazuCore.LocalizationManager": {
        "field_name": "supportedCountries",
        "field_type": "Country_SupportedLanguages",
        "intermediate_chain": "Country_SupportedLanguages : SerializableDictionaryBase<Country, SupportedLanguages>",
        "file": "out/cpp2il/DiffableCs/Assembly-CSharp/PazuCore/LocalizationManager.cs",
    },
    "PazuCore.GameExtraSettings": {
        "field_name": "nameBackScene (also backgroundMusics, audioEvents - same mechanism, not individually isolated which one trips the crash first)",
        "field_type": "Name_Back_Scene / Name_Audio / Name_AudioEvent",
        "intermediate_chain": "Name_Back_Scene : SerializableDictionaryBase<String, BackSceneLoadConfig>; "
                              "Name_Audio : SerializableDictionaryBase<String, BackgroundMusicConfig>; "
                              "Name_AudioEvent : SerializableDictionaryBase<String, AudioSimultaneousConfigCollection>",
        "file": "out/cpp2il/DiffableCs/Assembly-CSharp/PazuCore/GameExtraSettings.cs",
    },
}

for cname, info in targets.items():
    tid = by_name[cname]
    task_hash = tid.rsplit("/", 1)[-1]
    claimed = q.claim(tid, ACTOR, 3600)
    lease_id = claimed["lease"]["id"]
    q.heartbeat(tid, ACTOR, lease_id, start=True)
    err_count = claimed["scope"]["declared_counts"].get("err", 0)

    contract = {
        "class": cname,
        "assembly": "Assembly-CSharp",
        "unity_class_id": "MonoBehaviour (114)",
        "original_failure": "node generation raises AssertionError: failed to dump nodes as json "
                              "(native message: 'Object reference not set to an instance of an object.')",
        "root_cause": {
            "summary": (
                f"Same TypeTreeGeneratorAPI limitation as the 27 other classes already closed under "
                f"this signature, but reached via an INDIRECT path: the field `{info['field_name']}` "
                f"is declared with type `{info['field_type']}`, which is a NAMED SUBCLASS of "
                f"SerializableDictionaryBase<TKey,TValue> rather than the raw generic used directly "
                f"as the field type. The crash happens all the same, because the actual serialized "
                "layout still comes from the generic base class's own fields (TKey[]/TValue[] "
                "specialized arrays) regardless of whether the field type is the raw generic or a "
                "named subclass of it."
            ),
            "chain": info["intermediate_chain"],
            "confirmed_in_source": info["file"],
            "revision_note": (
                "This class was initially left OPEN/unconfirmed (2026-11-22, same session) because "
                "a first-pass grep for the literal string 'SerializableDictionaryBase' in its own "
                "decompiled file found nothing - it only appears in the intermediate named-subclass "
                "file, not this class's own file. Found by checking this class's field types against "
                "the full list of SerializableDictionaryBase subclasses in the codebase "
                "(Country_SupportedLanguages, Name_Audio, Name_AudioEvent, Name_Back_Scene)."
            ),
        },
        "fix": "None available without a different type-tree extraction tool.",
        "resolvability": "Blocked on tooling, not on data or analysis effort.",
    }

    recount = {
        "class": cname,
        "before": {"err": err_count},
        "after": {"ok": 0, "bad": 0, "err": err_count},
        "status": "confirmed_blocked_by_typetreegeneratorapi_limitation_indirect_serializabledict",
        "object_identities": (
            "NOT individually identified (path_id/file) - node-generation-time failure, needs the "
            "datapack to even enumerate. Only the aggregate count is known."
        ),
        "unresolved_objects": f"{err_count} objects of this class, identities unknown",
    }

    result = {
        "task": tid,
        "title": claimed["title"],
        "actor": ACTOR,
        "summary": (
            f"{cname}: confirmed as the same TypeTreeGeneratorAPI SerializableDictionaryBase<K,V> "
            f"limitation as the 27 classes closed earlier this session, reached indirectly via the "
            f"named subclass `{info['field_type']}` on field `{info['field_name']}`. Initially left "
            "open because a literal string grep missed the indirect reference; resolved by checking "
            "field types against the full subclass list instead of the raw generic string."
        ),
        "evidence": [
            f"out/recon/tasks/T020/CLASS/{task_hash}/class-contract.json",
            f"out/recon/tasks/T020/CLASS/{task_hash}/recount.json",
            info["file"],
            "docs/RECON_T020_NODE_TREE_TRIAGE_2026-11-22.md",
        ],
    }

    for outdir in (WORKTREE_OUT, MAIN_OUT):
        od = outdir / task_hash
        od.mkdir(parents=True, exist_ok=True)
        (od / "class-contract.json").write_text(json.dumps(contract, indent=1, ensure_ascii=False), encoding="utf-8")
        (od / "recount.json").write_text(json.dumps(recount, indent=1, ensure_ascii=False), encoding="utf-8")
        (od / "result.json").write_text(json.dumps(result, indent=1, ensure_ascii=False), encoding="utf-8")

    checkpointed = q.checkpoint(
        tid, ACTOR, lease_id, "blocked_external",
        note=(f"{cname}: mesmo limite do TypeTreeGeneratorAPI, alcancado indiretamente via "
              f"subclasse nomeada `{info['field_type']}` (campo `{info['field_name']}`) que deriva "
              f"de SerializableDictionaryBase<K,V>. Confirmado no fonte decompilado. Ver "
              f"docs/RECON_T020_NODE_TREE_TRIAGE_2026-11-22.md."),
        evidence=[
            f"out/recon/tasks/T020/CLASS/{task_hash}/class-contract.json",
            f"out/recon/tasks/T020/CLASS/{task_hash}/recount.json",
        ],
    )
    print(f"{cname} -> {checkpointed['state']}", flush=True)

print(json.dumps(q.status(), indent=1))
