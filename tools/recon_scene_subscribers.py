#!/usr/bin/env python3
"""Guard five static scene-event signup/handler edges in the cached shipped pair.

No active REA target, target execution, installation or queue change. Raw direct
caller scan is candidate discovery only; the five reported edges also require
MethodDef metadata, codegen-pointer joins and explicit argument-flow opcodes.
"""
import argparse
import bisect
from collections import Counter
from pathlib import Path
import struct
import subprocess
import time

import recon_navigation as nav


ACTION_CTOR = ("mscorlib.dll", "System.Action", ".ctor", "0x06000379", 0x32cd13c)
SPECS = [
    {"event": "GameSceneManager.OnBeforeSceneLoadStage1Action",
     "caller": ("Assembly-CSharp.dll", "PWC.BackgroundPlanetSoundHandler", "Awake", "0x060055ff", 0x20691dc),
     "handler": ("Assembly-CSharp.dll", "PWC.BackgroundPlanetSoundHandler", "OnBeforeSceneLoadStage1", "0x06005601", 0x2069448),
     "add": ("Assembly-CSharp.dll", "PWC.GameSceneManager", "add_OnBeforeSceneLoadStage1Action", "0x060056f0", 0x20692dc),
     "method_ref_sites": (0x20691f0, 0x2069200), "method_register": 20,
     "constructor_site": 0x206927c, "constructor_target": 0x32cd13c,
     "signup_site": 0x2069294, "signup_kind": "BL", "target_object": "this saved in x19",
     "anchors": {0x2069208: 0xaa0003f3, 0x206926c: 0xf9400282, 0x2069270: 0xaa1303e1,
                 0x2069274: 0xaa1f03e3, 0x2069278: 0xaa0003f4, 0x2069290: 0xaa1403e0}},
    {"event": "GameSceneManager.OnBeforeSceneLoadStage2Action",
     "caller": ("Assembly-CSharp.dll", "PWC.PersistentData.PersistentDataManager", "Awake", "0x06006e3e", 0x21e0658),
     "handler": ("Assembly-CSharp.dll", "PWC.PersistentData.PersistentDataManager", "OnBeforeSceneLoadStage2", "0x06006e44", 0x21e09b0),
     "add": ("Assembly-CSharp.dll", "PWC.GameSceneManager", "add_OnBeforeSceneLoadStage2Action", "0x060056f2", 0x2071fec),
     "method_ref_sites": (0x21e06a8, 0x21e06b8), "method_register": 20,
     "constructor_site": 0x21e070c, "constructor_target": 0x32cd13c,
     "signup_site": 0x21e0734, "signup_kind": "B", "target_object": "this saved in x19",
     "anchors": {0x21e066c: 0xaa0003f3, 0x21e06fc: 0xf9400282, 0x21e0700: 0xaa1303e1,
                 0x21e0704: 0xaa1f03e3, 0x21e0708: 0xaa0003f4, 0x21e0720: 0xaa1403e0,
                 0x21e072c: 0xaa1f03e1}},
    {"event": "GameSceneManager.OnBeforeSceneLoadStage2Action",
     "caller": ("Assembly-CSharp.dll", "PWC.Level.LevelManager", "Awake", "0x0600848e", 0x2310b8c),
     "handler": ("Assembly-CSharp.dll", "PWC.Level.LevelManager", "OnBeforeSceneLoadStage2", "0x0600849c", 0x2313e64),
     "add": ("Assembly-CSharp.dll", "PWC.GameSceneManager", "add_OnBeforeSceneLoadStage2Action", "0x060056f2", 0x2071fec),
     "method_ref_sites": (0x2310cac, 0x2310cc4), "method_register": 22,
     "constructor_site": 0x2310d48, "constructor_target": 0x32cd13c,
     "signup_site": 0x2310d64, "signup_kind": "BL", "target_object": "this saved in x19",
     "anchors": {0x2310bb4: 0xaa0003f3, 0x2310d38: 0xf94002c2, 0x2310d3c: 0xaa1303e1,
                 0x2310d40: 0xaa1f03e3, 0x2310d44: 0xaa0003f4, 0x2310d5c: 0xaa1403e0,
                 0x2310d60: 0xaa1f03e1}},
    {"event": "GameSceneManager.OnBeforeSceneLoadStage3Action",
     "caller": ("Assembly-CSharp.dll", "PWC.Level.LevelManager", "Awake", "0x0600848e", 0x2310b8c),
     "handler": ("Assembly-CSharp.dll", "PWC.Level.LevelManager", "OnBeforeSceneLoadStage3", "0x0600849d", 0x2313e70),
     "add": ("Assembly-CSharp.dll", "PWC.GameSceneManager", "add_OnBeforeSceneLoadStage3Action", "0x060056f4", 0x20721a4),
     "method_ref_sites": (0x2310cd8, 0x2310ce8), "method_register": 29,
     "constructor_site": 0x2310d80, "constructor_target": 0x32cd13c,
     "signup_site": 0x2310d8c, "signup_kind": "BL", "target_object": "this saved in x19",
     "anchors": {0x2310bb4: 0xaa0003f3, 0x2310d70: 0xf94003a2, 0x2310d74: 0xaa1303e1,
                 0x2310d78: 0xaa1f03e3, 0x2310d7c: 0xaa0003f4, 0x2310d84: 0xaa1403e0,
                 0x2310d88: 0xaa1f03e1}},
    {"event": "UnityEngine.SceneManagement.SceneManager.activeSceneChanged",
     "caller": ("Assembly-CSharp.dll", "PWC.GameSceneManager", ".cctor", "0x060056fa", 0x20724cc),
     "handler": ("Assembly-CSharp.dll", "PWC.GameSceneManager", "OnActiveSceneChanged", "0x060056fc", 0x2072644),
     "add": ("UnityEngine.CoreModule.dll", "UnityEngine.SceneManagement.SceneManager", "add_activeSceneChanged", "0x060009c6", 0x3cdc02c),
     "method_ref_sites": (0x20724e0, 0x20724f0), "method_register": 19,
     "constructor_site": 0x2072540, "constructor_target": 0x305a558,
     "signup_site": 0x2072568, "signup_kind": "B", "target_object": "null (static handler)",
     "anchors": {0x2072530: 0xf9400262, 0x2072534: 0xaa1f03e1,
                 0x2072538: 0xaa1f03e3, 0x207253c: 0xaa0003f3,
                 0x2072554: 0xaa1303e0, 0x2072560: 0xaa1f03e1}},
]


def method(resolve, expected):
    image, cls, name, token, va = expected
    candidates = resolve(va)  # revalidates raw metadata + codegen pointer, not only cached names
    exact = [row for row in candidates if (row["image"], row["declaring_type"], row["name"], row["token"])
             == (image, cls, name, token)]
    nav.require(len(exact) == 1, f"exact method identity mismatch: {cls}.{name} {token}")
    return exact[0]


def raw_instruction(elf, address):
    word = nav.word(elf, address)
    return {"site": hex(address), "file_offset": hex(elf.offset(address, 4)),
            "word": hex(word), "bytes_le": struct.pack("<I", word).hex()}


def verify_edges(elf, meta, index):
    """Verify anchors independently of outer full-file hash; useful for mutations."""
    rows, resolve = nav.load_index(index, elf, meta)
    indexed_by_definition = {row["method_definition_index"]: row for row in rows}
    starts = sorted({int(row["vaddr"], 16) for row in rows if row.get("vaddr")})
    edges, windows = [], {}
    action_ctor = method(resolve, ACTION_CTOR)
    for spec in SPECS:
        caller = method(resolve, spec["caller"])
        handler = method(resolve, spec["handler"])
        addition = method(resolve, spec["add"])
        ref = nav.adrp_ldr(elf, *spec["method_ref_sites"])
        nav.require(ref["destination_register"] == spec["method_register"], "handler MethodInfo reference register mismatch")
        usage = nav.metadata_usage(elf, ref["got_vaddr"])
        nav.require(usage["kind"] == 3, "handler reference is not MethodDef usage")
        nav.require(usage["index"] == handler["method_definition_index"], "handler MethodDef usage mismatch")
        nav.require(indexed_by_definition.get(usage["index"]) == handler, "handler cached index mismatch")
        # Loading that usage into x2 and preserving its delegate object before
        # calling the exact add method is guarded through explicit raw opcodes.
        for site, opcode in spec["anchors"].items():
            nav.expect(elf, site, opcode)
        constructor = nav.branch(spec["constructor_site"], nav.word(elf, spec["constructor_site"]))
        nav.require(constructor == {"kind": "BL", "target": spec["constructor_target"]}, "constructor call target mismatch")
        signup = nav.branch(spec["signup_site"], nav.word(elf, spec["signup_site"]))
        nav.require(signup == {"kind": spec["signup_kind"], "target": spec["add"][4]}, "registration branch target/kind mismatch")
        start = spec["caller"][4]
        position = bisect.bisect_right(starts, start)
        stop = starts[position]
        nav.require(start <= spec["signup_site"] < stop, "registration site outside candidate caller window")
        offset = elf.offset(start, stop - start)
        key = caller["declaring_type"] + "." + caller["name"]
        windows[key] = {"start": hex(start), "exclusive_stop": hex(stop),
                        "bytes": stop - start, "sha256": nav.sha(elf.data[offset:offset + stop - start]),
                        "limit": "Next metadata start is only a bounded inspection window, not full/noncontiguous CFG/body proof."}
        sites = sorted({*spec["anchors"], *spec["method_ref_sites"], spec["constructor_site"], spec["signup_site"]})
        edges.append({"classification": "DERIVED_static_registration_edge_not_runtime_observed",
                      "event": spec["event"], "caller": caller, "handler": handler,
                      "event_add_method": addition, "target_object": spec["target_object"],
                      "handler_metadata_usage": usage,
                      "handler_got_reference": {**ref, "got_vaddr": hex(ref["got_vaddr"])},
                      "constructor_call": {**raw_instruction(elf, spec["constructor_site"]),
                                           "target": hex(spec["constructor_target"]),
                                           "metadata_method": action_ctor if spec["constructor_target"] == ACTION_CTOR[4] else None,
                                           "identity_limit": None if spec["constructor_target"] == ACTION_CTOR[4]
                                           else "Typed delegate-construction helper at this VA is not named by this metadata index; argument flow and final Unity event add are guarded."},
                      "registration_branch": {**raw_instruction(elf, spec["signup_site"]),
                                              "kind": signup["kind"], "target": hex(signup["target"])},
                      "raw_argument_flow_anchors": [raw_instruction(elf, site) for site in sites],
                      "precondition": "Normal execution reaches the signup after metadata/class initialization and object/delegate construction.",
                      "limits": ["Does not prove handler invocation, side effects, subscription order across instances or lifetime/unsubscription.",
                                 "Exceptions, lazy-init helpers and indirect/generated calls outside this guarded flow remain unmodeled."]})
    return edges, windows, rows, resolve


def direct_candidates(elf, rows, resolve):
    """Discover raw executable B/BL encodings; do not call these validated edges."""
    targets = {spec["add"][4] for spec in SPECS[:4]}
    starts = sorted({int(row["vaddr"], 16) for row in rows if row.get("vaddr")})
    hits = []
    for segment in elf.loads:
        if not segment["flags"] & 1:
            continue
        data = memoryview(elf.data)[segment["file_offset"]:segment["file_offset"] + segment["file_size"]]
        for index, (word,) in enumerate(struct.iter_unpack("<I", data[:len(data) // 4 * 4])):
            if word >> 26 not in (0x25, 0x05):
                continue
            address = segment["vaddr"] + index * 4
            target = address + nav.signed(word & 0x3ffffff, 26) * 4
            if target not in targets:
                continue
            at = bisect.bisect_right(starts, address) - 1
            hits.append({**raw_instruction(elf, address), "target": hex(target),
                         "kind": "BL" if word >> 26 == 0x25 else "B",
                         "target_methods": resolve(target),
                         "owner_candidate": resolve(starts[at]) if at >= 0 else [],
                         "classification": "STATIC_direct_encoding_candidate_nearest_owner_not_CFG_proven"})
    return hits


def produce(source, output, report, objdump):
    source, output, report = Path(source), Path(output), Path(report)
    binary = (source / "libil2cpp.so").read_bytes()
    metadata = (source / "global-metadata.dat").read_bytes()
    nav.verify_pair(binary, metadata)
    elf, meta = nav.Elf(binary), nav.Metadata(metadata)
    index = source / "metadata_methods.jsonl"
    edges, windows, rows, resolve = verify_edges(elf, meta, index)
    candidates = direct_candidates(elf, rows, resolve)
    output.mkdir(parents=True, exist_ok=True)
    commands = []
    for key, window in windows.items():
        command = [str(objdump), "-d", "--start-address=" + window["start"],
                   "--stop-address=" + window["exclusive_stop"], str(source / "libil2cpp.so")]
        before = time.monotonic()
        result = subprocess.run(command, capture_output=True, text=True, timeout=30)
        nav.require(result.returncode == 0, "LLVM disassembly failed: " + result.stderr)
        destination = output / (key + ".asm.txt")
        destination.write_text(result.stdout, encoding="utf-8")
        commands.append({"command": command, "returncode": result.returncode,
                         "duration_seconds": round(time.monotonic() - before, 3),
                         "output": str(destination), "output_sha256": nav.sha(destination.read_bytes())})
    counts = Counter(hit["target_methods"][0]["name"] for hit in candidates)
    result = {"schema_version": 1, "scope": "Five positive static scene-event signup/handler edges; bounded investigation only.",
              "evidence_class": "STATIC_bytes_and_metadata_with_DERIVED_edges",
              "native_sha256": nav.sha(binary), "metadata_sha256": nav.sha(metadata),
              "method_index_sha256": nav.sha(index.read_bytes()),
              "producer_sha256": nav.sha(Path(__file__).read_bytes()),
              "helper_sha256": nav.sha(Path(nav.__file__).read_bytes()),
              "summary": {"validated_positive_edges": len(edges), "inspected_windows": len(windows),
                          "raw_direct_candidates": len(candidates), "candidate_event_add_counts": dict(counts)},
              "edges": edges, "inspection_windows": windows, "direct_encoding_candidates": candidates,
              "commands": commands,
              "unknowns": ["No runtime registration or invocation was observed.",
                           "The other direct candidates are discovery leads, not validated signup/handler edges in this report.",
                           "Indirect registration, delegates created elsewhere, reflection, dynamically loaded code, unsubscription and cross-instance ordering remain open.",
                           "The activeSceneChanged typed construction helper at 0x305a558 has no resolved metadata identity here.",
                           "Handler bodies/effects and full method extents are outside this registration probe.",
                           "No absence claim or complete subscriber graph follows from this bounded scan."],
              "queue_modified": False, "game_executed": False, "active_REA_target_used": False}
    nav.atomic_json(report, result)
    return result


if __name__ == "__main__":
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--source", type=Path, default=nav.ROOT / "out/recon/il2cpp")
    parser.add_argument("--output", type=Path, default=nav.ROOT / "out/recon/scene-subscribers")
    parser.add_argument("--report", type=Path, default=nav.ROOT / "reports/recon/scene_subscribers.json")
    parser.add_argument("--objdump", type=Path,
                        default=Path.home() / "Unity/Hub/Editor/6000.6.6f1/Editor/Data/PlaybackEngines/AndroidPlayer/NDK/toolchains/llvm/prebuilt/linux-x86_64/bin/llvm-objdump")
    args = parser.parse_args()
    result = produce(args.source, args.output, args.report, args.objdump)
    print(f"Five guarded static edges; {result['summary']['raw_direct_candidates']} raw caller candidates; {args.report}")
