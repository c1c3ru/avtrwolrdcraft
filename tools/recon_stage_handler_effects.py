#!/usr/bin/env python3
"""Recover effects of the five already-identified Stage/scene-event handlers.

Scope: the five positive registration->handler bindings from
reports/recon/scene_subscribers.json ("Cinco ligações verificadas"):
BackgroundPlanetSoundHandler.OnBeforeSceneLoadStage1,
PersistentDataManager.OnBeforeSceneLoadStage2, LevelManager.OnBeforeSceneLoadStage2,
LevelManager.OnBeforeSceneLoadStage3 and GameSceneManager.OnActiveSceneChanged.

Each handler's bounded window (candidate owner VA to next distinct metadata method
start) is disassembled with the known-good LLVM objdump, decisive opcodes are
pinned, direct call targets are re-resolved against the current metadata/codegen
pair (never trusted from a cache alone), and static-field writes are tied to the
exact field-offset declarations already extracted in out/cpp2il. This is STATIC
evidence from the cached shipped pair only: no target execution, emulation, or
device/runtime observation. Handler effects downstream of a resolved callee
(e.g. PersistentDataManager.SaveProgress body, LeanTween.cancel body) are
explicitly left open.
"""
from __future__ import annotations

import argparse
import bisect
import hashlib
import json
from pathlib import Path
import re
import subprocess
import sys

ROOT = Path(__file__).resolve().parents[1]
sys.path.insert(0, str(ROOT / "tools"))
import recon_navigation as nav  # noqa: E402

SOURCE = ROOT / "out/recon/il2cpp"
INDEX = SOURCE / "metadata_methods.jsonl"
PRIOR = ROOT / "reports/recon/scene_subscribers.json"
CPP2IL = ROOT / "out/cpp2il/DiffableCs/Assembly-CSharp"
LLVM_CANDIDATES = [
    Path.home() / "Unity/Hub/Editor/6000.6.6f1/Editor/Data/PlaybackEngines/AndroidPlayer/NDK"
    "/toolchains/llvm/prebuilt/linux-x86_64/bin/llvm-objdump",
]


def sha(data: bytes) -> str:
    return hashlib.sha256(data).hexdigest()


def find_llvm() -> Path:
    for candidate in LLVM_CANDIDATES:
        if candidate.is_file():
            return candidate
    ndk_hits = sorted((Path.home() / "Android/Sdk/ndk").glob(
        "*/toolchains/llvm/prebuilt/linux-x86_64/bin/llvm-objdump"))
    if ndk_hits:
        return ndk_hits[-1]
    raise FileNotFoundError("no llvm-objdump found under known Unity/NDK locations")


def require_source_field(cs_relpath, declaration_fragment):
    path = ROOT / cs_relpath
    text = path.read_text(encoding="utf-8")
    nav.require(declaration_fragment in text,
                f"expected field declaration not found verbatim in {cs_relpath}: {declaration_fragment!r}")
    return {"path": cs_relpath, "sha256": sha(path.read_bytes()), "declaration": declaration_fragment}


HANDLERS = [
    {
        "id": "BackgroundPlanetSoundHandler.OnBeforeSceneLoadStage1",
        "task_dir": "T025/HANDLER/00005600",
        "class_name": "PWC.BackgroundPlanetSoundHandler",
        "method_name": "OnBeforeSceneLoadStage1",
        "va": 0x2069448,
        "window_hint": None,
    },
    {
        "id": "PersistentDataManager.OnBeforeSceneLoadStage2",
        "task_dir": "T025/HANDLER/00006e43",
        "class_name": "PWC.PersistentData.PersistentDataManager",
        "method_name": "OnBeforeSceneLoadStage2",
        "va": 0x21e09b0,
        "window_hint": None,
    },
    {
        "id": "LevelManager.OnBeforeSceneLoadStage2",
        "task_dir": "T025/HANDLER/0000849b",
        "class_name": "PWC.Level.LevelManager",
        "method_name": "OnBeforeSceneLoadStage2",
        "va": 0x2313e64,
        "window_hint": None,
    },
    {
        "id": "LevelManager.OnBeforeSceneLoadStage3",
        "task_dir": "T025/HANDLER/0000849c",
        "class_name": "PWC.Level.LevelManager",
        "method_name": "OnBeforeSceneLoadStage3",
        "va": 0x2313e70,
        "window_hint": None,
    },
    {
        "id": "GameSceneManager.OnActiveSceneChanged",
        "task_dir": "T025/HANDLER/000056fb",
        "class_name": "PWC.GameSceneManager",
        "method_name": "OnActiveSceneChanged",
        "va": 0x2072644,
        "window_hint": None,
    },
]


def parse_disassembly(text):
    rows = []
    for line in text.splitlines():
        m = re.match(r"\s*([0-9a-f]+):\s+([0-9a-f]{8})\s+(.*)$", line)
        if m:
            rows.append({"address": int(m.group(1), 16), "word": int(m.group(2), 16), "text": m.group(3)})
    return rows


def bounded_window(start, starts):
    i = bisect.bisect_right(starts, start)
    return starts[i] if i < len(starts) else start + 4


def disassemble(llvm, binary_path, start, stop):
    command = [str(llvm), "-d", f"--start-address={start:#x}", f"--stop-address={stop:#x}", str(binary_path)]
    result = subprocess.run(command, capture_output=True, text=True, timeout=30)
    nav.require(result.returncode == 0, f"llvm-objdump failed for {start:#x}: {result.stderr}")
    return result.stdout, command


def analyze_background_planet_sound(elf, meta, resolve, insns, start, stop):
    nav.expect(elf, 0x2069474, 0xb9405a68)   # ldr w8,[x19,#0x58]
    nav.expect(elf, 0x2069478, 0x7100051f)   # cmp w8,#1
    nav.require(nav.branch(0x206947c, nav.word(elf, 0x206947c)) == {"kind": "B.cond", "condition": 11, "target": 0x20694c8},
                "tween-id guard (b.lt) changed")
    nav.expect(elf, 0x20694c4, 0xb9005a7f)   # str wzr,[x19,#0x58]
    get_game_object = nav.branch(0x2069490, nav.word(elf, 0x2069490))
    lean_cancel = nav.branch(0x20694c0, nav.word(elf, 0x20694c0))
    nav.require(get_game_object["kind"] == "BL", "expected direct BL to get_gameObject")
    nav.require(lean_cancel["kind"] == "BL", "expected direct BL to LeanTween.cancel")
    go_sym = resolve(get_game_object["target"])
    cancel_sym = resolve(lean_cancel["target"])
    nav.require(any(r["name"] == "get_gameObject" for r in go_sym), "get_gameObject target changed")
    nav.require(any(r["name"] == "cancel" and r["declaring_type"] == "LeanTween" for r in cancel_sym),
                "LeanTween.cancel target changed")
    field = require_source_field(
        "out/cpp2il/DiffableCs/Assembly-CSharp/PWC/BackgroundPlanetSoundHandler.cs",
        "private int _tweenId; //Field offset: 0x58")
    return {
        "field_source": field,
        "pseudocode": [
            "if (this._tweenId >= 1):",
            "    LeanTween.cancel(this.gameObject, this._tweenId, false)",
            "    this._tweenId = 0",
        ],
        "effects": [
            "reads instance field _tweenId (offset 0x58)",
            "when >= 1: calls Component.get_gameObject() then LeanTween.cancel(gameObject, tweenId, false)",
            "unconditionally writes 0 to _tweenId (offset 0x58) at method exit",
        ],
        "calls": [
            {"site": hex(0x2069490), "target": hex(get_game_object["target"]), "resolved": go_sym},
            {"site": hex(0x20694c0), "target": hex(lean_cancel["target"]), "resolved": cancel_sym},
        ],
        "unknowns": ["LeanTween.cancel body/exceptions and actual tween-scheduler state are not observed",
                     "get_gameObject fake-null/exception behavior not observed"],
    }


def analyze_persistent_data_save(elf, meta, resolve, start, stop):
    # start here is the OnBeforeSceneLoadStage2 VA; it is a 4-byte tail-jump thunk.
    nav.require(nav.branch(start, nav.word(elf, start)) == {"kind": "B", "target": start + 4},
                "OnBeforeSceneLoadStage2 is no longer a 4-byte tail-jump thunk")
    thunk_target = resolve(start + 4)
    nav.require(any(r["name"] == "SaveProgressInAllScenes" for r in thunk_target),
                "thunk no longer forwards to SaveProgressInAllScenes")
    scene_count = nav.branch(0x21e0a00, nav.word(elf, 0x21e0a00))
    get_scene_at = nav.branch(0x21e0a24, nav.word(elf, 0x21e0a24))
    save_progress = nav.branch(0x21e0a30, nav.word(elf, 0x21e0a30))
    nav.require(nav.branch(0x21e0a08, nav.word(elf, 0x21e0a08)) ==
                {"kind": "B.cond", "condition": 10, "target": 0x21e0a3c}, "loop exit guard changed")
    nav.require(nav.branch(0x21e0a38, nav.word(elf, 0x21e0a38)) == {"kind": "B", "target": 0x21e09ec},
                "loop backedge changed")
    nav.expect(elf, 0x21e0a34, 0x11000694)  # add w20,w20,#1
    count_sym = resolve(scene_count["target"])
    get_scene_sym = resolve(get_scene_at["target"])
    save_sym = resolve(save_progress["target"])
    nav.require(any(r["name"] == "get_sceneCount" for r in count_sym), "get_sceneCount target changed")
    nav.require(any(r["name"] == "GetSceneAt" for r in get_scene_sym), "GetSceneAt target changed")
    nav.require(any(r["name"] == "SaveProgress" for r in save_sym), "per-scene SaveProgress target changed")
    return {
        "thunk": {"site": hex(start), "target_vaddr": hex(start + 4), "resolved": thunk_target},
        "pseudocode": [
            "OnBeforeSceneLoadStage2() -> tailcall SaveProgressInAllScenes()",
            "SaveProgressInAllScenes():",
            "    for (i = 0; i < SceneManager.sceneCount; i++):",
            "        scene = SceneManager.GetSceneAt(i)",
            "        this.SaveProgress(scene)",
        ],
        "effects": [
            "no own body: OnBeforeSceneLoadStage2 is a direct tail-branch to SaveProgressInAllScenes",
            "loops i=0..SceneManager.sceneCount-1, calling SceneManager.GetSceneAt(i) then this.SaveProgress(scene) each iteration",
        ],
        "calls": [
            {"site": hex(0x21e0a00), "target": hex(scene_count["target"]), "resolved": count_sym},
            {"site": hex(0x21e0a24), "target": hex(get_scene_at["target"]), "resolved": get_scene_sym},
            {"site": hex(0x21e0a30), "target": hex(save_progress["target"]), "resolved": save_sym},
        ],
        "unknowns": ["PersistentDataManager.SaveProgress(Scene) body/exceptions are a separate unrecovered callee",
                     "actual persisted data, file/IO effects and failure handling are not observed"],
    }


def analyze_level_manager_stage2(elf):
    nav.expect(elf, 0x2313e64, 0x52800028)  # mov w8,#1
    nav.expect(elf, 0x2313e68, 0x3900e808)  # strb w8,[x0,#0x3a]
    nav.require(nav.branch(0x2313e6c, nav.word(elf, 0x2313e6c)) == {"kind": "RET", "register": 30, "target": None},
                "expected immediate RET")
    field = require_source_field(
        "out/cpp2il/DiffableCs/Assembly-CSharp/PWC/Level/LevelManager.cs",
        "private bool <IsAboutToLoadScene>k__BackingField; //Field offset: 0x3A")
    return {
        "field_target": field,
        "pseudocode": ["this.IsAboutToLoadScene = true"],
        "effects": ["writes instance field IsAboutToLoadScene (offset 0x3a) to true; no calls, no other state read/written"],
        "calls": [],
        "unknowns": ["downstream readers of IsAboutToLoadScene are outside this bounded window"],
    }


def analyze_level_manager_stage3(elf, meta):
    nav.expect(elf, 0x2313eac, 0xf9400260)   # ldr x0,[x19]  (GameSceneManager class ptr)
    nav.expect(elf, 0x2313ec8, 0xf9400281)   # ldr x1,[x20]  (string-literal usage slot)
    nav.expect(elf, 0x2313ecc, 0xf9405c00)   # ldr x0,[x0,#0xb8]  (static fields ptr)
    nav.expect(elf, 0x2313ed4, 0xf8018c01)   # str x1,[x0,#0x18]!
    nav.require(nav.branch(0x2313edc, nav.word(elf, 0x2313edc)) == {"kind": "B", "target": 0x1b88694},
                "expected GC write-barrier tail branch")
    class_ref = nav.adrp_ldr(elf, 0x2313e7c, 0x2313e84)
    nav.require(class_ref["got_vaddr"] == 0x41b4e60, "GameSceneManager class-ptr GOT slot changed")
    literal_ref = nav.adrp_ldr(elf, 0x2313eb0, 0x2313eb8)
    nav.require(literal_ref["got_vaddr"] == 0x41acba0, "string-literal usage GOT slot changed")
    usage = nav.metadata_usage(elf, literal_ref["got_vaddr"])
    literal = nav.literal(meta, usage)
    field = require_source_field(
        "out/cpp2il/DiffableCs/Assembly-CSharp/PWC/GameSceneManager.cs",
        "public static string CurrentSceneSuffix; //Field offset: 0x18")
    return {
        "literal_usage": literal,
        "field_target": field,
        "pseudocode": [f"GameSceneManager.CurrentSceneSuffix = {literal['literal']!r}"],
        "effects": [
            "ensures GameSceneManager static-class initialization (guarded)",
            f"writes static field CurrentSceneSuffix (offset 0x18 of GameSceneManager static fields) from a "
            f"string-literal metadata usage slot (kind 5, index {literal['index']}) decoding to {literal['literal']!r}, with GC write barrier",
        ],
        "calls": [],
        "unknowns": [
            "the method's own `this` (LevelManager instance) parameter is unused in this window; only a GameSceneManager static field is touched",
            "runtime timing of the metadata-usage slot self-patch (raw encoded token on disk vs resolved String* at first use) is not observed",
        ],
    }


def analyze_on_active_scene_changed(elf, meta):
    nav.expect(elf, 0x20726b8, 0xf9405c08)   # ldr x8,[x0,#0xb8]
    nav.expect(elf, 0x20726c0, 0x3900c11f)   # strb wzr,[x8,#0x30]
    nav.expect(elf, 0x20726f0, 0xf9405c00)   # ldr x0,[x0,#0xb8]
    nav.expect(elf, 0x20726f8, 0xf8040c1f)   # str xzr,[x0,#0x40]!
    nav.expect(elf, 0x207270c, 0xf9405d00)   # ldr x0,[x8,#0xb8]
    nav.expect(elf, 0x2072710, 0xf8028c1f)   # str xzr,[x0,#0x28]!
    for site in (0x20726fc,):
        nav.require(nav.branch(site, nav.word(elf, site)) == {"kind": "BL", "target": 0x1b88694},
                    "expected GC write-barrier BL")
    nav.require(nav.branch(0x2072718, nav.word(elf, 0x2072718)) == {"kind": "B", "target": 0x1b88694},
                "expected GC write-barrier tail B")
    fields = [
        require_source_field(
            "out/cpp2il/DiffableCs/Assembly-CSharp/PWC/GameSceneManager.cs",
            "private static bool <IsSceneChangingInProgress>k__BackingField; //Field offset: 0x30"),
        require_source_field(
            "out/cpp2il/DiffableCs/Assembly-CSharp/PWC/GameSceneManager.cs",
            "public static string CurrentlyLoadingSceneName; //Field offset: 0x28"),
        require_source_field(
            "out/cpp2il/DiffableCs/Assembly-CSharp/PWC/GameSceneManager.cs",
            "private static string <Multiplayer_LoadingSceneNameInProgress>k__BackingField; //Field offset: 0x40"),
    ]
    return {
        "field_targets": fields,
        "pseudocode": [
            "GameSceneManager.IsSceneChangingInProgress = false",
            "GameSceneManager.Multiplayer_LoadingSceneNameInProgress = null",
            "GameSceneManager.CurrentlyLoadingSceneName = null",
        ],
        "effects": [
            "writes static field IsSceneChangingInProgress (offset 0x30) to false",
            "writes static field Multiplayer_LoadingSceneNameInProgress (offset 0x40) to null, with GC write barrier",
            "writes static field CurrentlyLoadingSceneName (offset 0x28) to null, with GC write barrier",
        ],
        "calls": [],
        "unknowns": [
            "this closes the long-open 'who clears IsSceneChangingInProgress' question from "
            "docs/RECON_NAVIGATION_CONTRACT.md (2026-11-04), but the Unity activeSceneChanged "
            "(Scene,LoadSceneMode) parameters themselves are unused in this window and the subscriber "
            "(un)registration lifetime/order remain open",
        ],
    }


ANALYZERS = {
    "BackgroundPlanetSoundHandler.OnBeforeSceneLoadStage1": analyze_background_planet_sound,
    "PersistentDataManager.OnBeforeSceneLoadStage2": analyze_persistent_data_save,
    "LevelManager.OnBeforeSceneLoadStage2": analyze_level_manager_stage2,
    "LevelManager.OnBeforeSceneLoadStage3": analyze_level_manager_stage3,
    "GameSceneManager.OnActiveSceneChanged": analyze_on_active_scene_changed,
}


def run(output_root: Path, report_path: Path):
    binary_path = SOURCE / "libil2cpp.so"
    metadata_path = SOURCE / "global-metadata.dat"
    binary, metadata = binary_path.read_bytes(), metadata_path.read_bytes()
    nav.verify_pair(binary, metadata)
    elf, meta = nav.Elf(binary), nav.Metadata(metadata)
    rows, resolve = nav.load_index(INDEX, elf, meta)
    starts = sorted({int(r["vaddr"], 16) for r in rows if r.get("vaddr")})
    llvm = find_llvm()
    prior = json.loads(PRIOR.read_text(encoding="utf-8"))
    results = []
    for spec in HANDLERS:
        matches = resolve(spec["va"])
        nav.require(any(r["declaring_type"] == spec["class_name"] and r["name"] == spec["method_name"] for r in matches),
                    f"{spec['id']}: identity does not join to pinned metadata/codegen pointer")
        identity = next(r for r in matches if r["declaring_type"] == spec["class_name"] and r["name"] == spec["method_name"])
        stop = bounded_window(spec["va"], starts)
        asm_text, command = disassemble(llvm, binary_path, spec["va"], stop)
        insns = parse_disassembly(asm_text)
        analyzer = ANALYZERS[spec["id"]]
        if spec["id"] == "BackgroundPlanetSoundHandler.OnBeforeSceneLoadStage1":
            detail = analyzer(elf, meta, resolve, insns, spec["va"], stop)
        elif spec["id"] == "PersistentDataManager.OnBeforeSceneLoadStage2":
            detail = analyzer(elf, meta, resolve, spec["va"], stop)
        elif spec["id"] in ("LevelManager.OnBeforeSceneLoadStage2",):
            detail = analyzer(elf)
        elif spec["id"] == "LevelManager.OnBeforeSceneLoadStage3":
            detail = analyzer(elf, meta)
        else:
            detail = analyzer(elf, meta)
        task_dir = ROOT / "out/recon/tasks" / spec["task_dir"]
        task_dir.mkdir(parents=True, exist_ok=True)
        asm_path = task_dir / "handler.asm.txt"
        asm_path.write_text(asm_text, encoding="utf-8")
        window_bytes = elf.data[elf.offset(spec["va"]):elf.offset(stop - 1) + 1]
        contract = {
            "schema_version": 1,
            "task_id": spec["task_dir"],
            "status": "STATIC_candidate_contract_checked_not_certified",
            "semantic_completion": False,
            "method_identity": identity,
            "bounded_window": {
                "start": hex(spec["va"]), "exclusive_stop": hex(stop), "bytes": stop - spec["va"],
                "sha256": sha(window_bytes),
                "bound_limit": "candidate window capped at next distinct metadata method start; noncontiguous body and exception extents are not proven",
            },
            "assembly_path": str(asm_path.relative_to(ROOT)), "assembly_sha256": sha(asm_text.encode()),
            "disassembly_command": command,
            "detail": detail,
            "input_pair": {"native_sha256": sha(binary), "metadata_sha256": sha(metadata)},
            "source_registration_edge": next(
                (e for e in prior["edges"] if e["handler"]["declaring_type"] == spec["class_name"]
                 and e["handler"]["name"] == spec["method_name"]), None),
            "evidence_class": "STATIC_and_DERIVED_from_original_cached_bytes",
            "runtime_or_device_observed": False,
        }
        control_flow = {
            "task_id": spec["task_dir"], "start": hex(spec["va"]), "exclusive_stop": hex(stop),
            "decoded_branches": [
                {"site": hex(ins["address"]), "word": hex(ins["word"]),
                 **({"decoded": nav.branch(ins["address"], ins["word"])} if nav.branch(ins["address"], ins["word"]) else {})}
                for ins in insns if nav.branch(ins["address"], ins["word"])
            ],
            "bound_limit": contract["bounded_window"]["bound_limit"],
        }
        unknowns = [{"unknown_id": f"{spec['task_dir']}/effects_{idx}", "question": question}
                    for idx, question in enumerate(detail["unknowns"])]
        unknowns.append({"unknown_id": f"{spec['task_dir']}/body_and_cfg",
                          "question": "Bounded window ends at next metadata start; full/noncontiguous body and exception CFG extents are not proven."})
        result = {
            "task_id": spec["task_dir"], "status": "partial", "semantic_completion": False,
            "method_body_fully_bounded": False,
            "method": spec["id"] + ": " + "; ".join(detail["effects"]),
            "contract": str((task_dir / "method-contract.json").relative_to(ROOT)),
            "control_flow": str((task_dir / "control-flow.json").relative_to(ROOT)),
            "unknowns": str((task_dir / "unknowns.jsonl").relative_to(ROOT)),
            "verification": {"pinned_opcodes": "passed", "named_call_targets_revalidated": "passed",
                              "field_declarations_matched_verbatim": "passed", "runtime_or_device": False},
            "next_action": "Preserve open callee/runtime unknowns; do not mark done without independent review.",
        }
        nav.atomic_json(task_dir / "method-contract.json", contract)
        nav.atomic_json(task_dir / "control-flow.json", control_flow)
        (task_dir / "unknowns.jsonl").write_text(
            "".join(json.dumps(x, ensure_ascii=False) + "\n" for x in unknowns), encoding="utf-8")
        nav.atomic_json(task_dir / "result.json", result)
        results.append({"id": spec["id"], "task_dir": spec["task_dir"], "pseudocode": detail["pseudocode"],
                        "effects": detail["effects"]})
    summary = {
        "schema_version": 1, "kind": "T025_five_identified_handler_effects",
        "scope": "Effects of the five positive registration->handler edges from reports/recon/scene_subscribers.json",
        "native_sha256": sha(binary), "metadata_sha256": sha(metadata),
        "source_report_sha256": sha(PRIOR.read_bytes()),
        "producer_sha256": sha(Path(__file__).read_bytes()),
        "handlers": results,
        "limits": [
            "Each window is bounded by the next distinct metadata method start; full/noncontiguous body and exception regions are not proven.",
            "Resolved callees (LeanTween.cancel, PersistentDataManager.SaveProgress, Unity scene APIs) are named and argument-matched, but their own bodies/exceptions are separate unrecovered dependencies.",
            "No target execution, emulation, or device/runtime observation; all five results stay static_candidate_not_runtime_validated.",
        ],
    }
    nav.atomic_json(report_path, summary)
    print(json.dumps({"report": str(report_path), "handlers": [r["id"] for r in results]}, indent=2, ensure_ascii=False))
    return summary


if __name__ == "__main__":
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--report", type=Path, default=ROOT / "reports/recon/stage_handler_effects_2026-11-08.json")
    args = parser.parse_args()
    run(ROOT / "out/recon/tasks", args.report)
