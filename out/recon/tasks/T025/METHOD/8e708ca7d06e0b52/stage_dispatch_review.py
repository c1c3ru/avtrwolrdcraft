#!/usr/bin/env python3
"""Guard the three indirect dispatch sequences in GameSceneManager.LoadScene.

This deliberately does not name the runtime delegate targets or bind the
static slots to a declaring class: the TypeInfo provenance needs resolution.
"""
import json
from pathlib import Path
import struct
import sys

ROOT = Path(__file__).resolve().parents[6]
sys.path.insert(0, str(ROOT / "tools"))
import recon_navigation as nav

NATIVE = ROOT / "out/recon/il2cpp/libil2cpp.so"
METADATA = ROOT / "out/recon/il2cpp/global-metadata.dat"
INDEX = ROOT / "out/recon/il2cpp/metadata_methods.jsonl"
METHOD_START = 0x20728D4
METHOD_STOP = 0x2072C5C
BODY_SHA256 = "5ad1f0b55ba081cdadf0751b05fa7db5c5cec832482e26694608d5c596ea80a7"
GROUPS = [
    {"slot": 0, "load": 0x2072B5C, "null_guard": 0x2072B60, "guard_target": 0x2072B78, "method": 0x2072B64,
     "target": 0x2072B68, "method_info": 0x2072B6C, "invoke": 0x2072B70,
     "words": [0xF9400108, 0xB40000C8, 0xF9400D09, 0xF9402100, 0xF9401501, 0xD63F0120]},
    {"slot": 8, "load": 0x2072B88, "null_guard": 0x2072B90, "guard_target": 0x2072BA8, "method": 0x2072B94,
     "target": 0x2072B98, "method_info": 0x2072B9C, "invoke": 0x2072BA0,
     "words": [0xF9405C08, 0xB40000C8, 0xF9400D09, 0xF9402100, 0xF9401501, 0xD63F0120]},
    {"slot": 16, "load": 0x2072BBC, "null_guard": 0x2072BC0, "guard_target": 0x2072BD4, "method": 0x2072BC4,
     "target": 0x2072BC8, "method_info": 0x2072BCC, "invoke": 0x2072BD0,
     "words": [0xF9400908, 0xB40000A8, 0xF9400D09, 0xF9402100, 0xF9401501, 0xD63F0120]},
]


def verify(binary=None, metadata=None, index=INDEX):
    binary = NATIVE.read_bytes() if binary is None else bytes(binary)
    metadata = METADATA.read_bytes() if metadata is None else bytes(metadata)
    nav.verify_pair(binary, metadata)
    elf, meta = nav.Elf(binary), nav.Metadata(metadata)
    _, resolve = nav.load_index(index, elf, meta)
    method = resolve(METHOD_START)
    matches = [r for r in method if (r["image"], r["declaring_type"], r["name"], r["token"])
               == ("Assembly-CSharp.dll", "PWC.GameSceneManager", "LoadScene", "0x060056fe")]
    nav.require(len(matches) == 1, "LoadScene identity mismatch")
    body = binary[elf.offset(METHOD_START, METHOD_STOP - METHOD_START):
                  elf.offset(METHOD_START, METHOD_STOP - METHOD_START) + METHOD_STOP - METHOD_START]
    nav.require(nav.sha(body) == BODY_SHA256, "LoadScene bounded window changed")

    groups = []
    for group in GROUPS:
        sites = [group["load"], group["null_guard"], group["method"], group["target"],
                 group["method_info"], group["invoke"]]
        words = [nav.word(elf, site) for site in sites]
        nav.require(words == group["words"], "delegate dispatch opcode sequence changed")
        guard = nav.branch(group["null_guard"], words[1])
        nav.require(guard["kind"] == "CBZ" and guard["target"] == group["guard_target"],
                    "delegate null guard target changed")
        nav.require(nav.branch(group["invoke"], words[-1]) == {"kind": "BLR", "register": 9, "target": None},
                    "indirect invoke register changed")
        groups.append({"candidate_slot_offset": hex(group["slot"]),
                       "anchors": [{"site": hex(site), "word": hex(word)} for site, word in zip(sites, words)],
                       "normal_local_path": "if loaded reference is non-null, load three words at object offsets 0x18/0x40/0x28 into x9/x0/x1, then BLR x9",
                       "otherwise": "CBZ bypasses the indirect call"})

    # Record the actual TypeInfo use near the beginning. This is intentionally
    # kept separate from the candidate offsets to prevent an unsupported join.
    class_ref = nav.adrp_ldr(elf, 0x20728E8, 0x20728F0)
    type_use = nav.metadata_usage(elf, class_ref["got_vaddr"])
    nav.require(type_use["kind"] == 1 and type_use["index"] == 36503,
                "LoadScene TypeInfo provenance changed")
    typedef_matches = []
    table = meta.tables["types"]
    for i in range(table["count"]):
        raw = struct.unpack_from("<16I8H2I", meta.data, table["offset"] + i * 88)
        if raw[2] == type_use["index"]:
            typedef_matches.append({"index": i, "name": meta.string(raw[0]), "namespace": meta.string(raw[1])})
    nav.require(typedef_matches == [{"index": 3802, "name": "<>c__DisplayClass28_0", "namespace": ""}],
                "TypeInfo owner no longer matches the reviewed nested display class")
    return {"classification": "STATIC_indirect_dispatch_shape_targets_unresolved",
            "method": matches[0], "native_sha256": nav.sha(binary), "metadata_sha256": nav.sha(metadata),
            "bounded_method_window": {"start": hex(METHOD_START), "exclusive_stop": hex(METHOD_STOP),
                                      "bytes": METHOD_STOP - METHOD_START, "sha256": BODY_SHA256,
                                      "limit": "next metadata pointer bounds the inspection window, not all body/exception regions"},
            "ordered_dispatches": groups,
            "typeinfo_provenance": {**class_ref, "usage": type_use, "resolved_typedef_candidates": typedef_matches},
            "candidate_field_layout": {"source": "T025 fieldOffsets metadata join plus FieldDef tokens for PWC.GameSceneManager",
                                       "fields": [{"name": "OnBeforeSceneLoadStage1Action", "token": "0x04003b9d", "offset": 0},
                                                  {"name": "OnBeforeSceneLoadStage2Action", "token": "0x04003b9e", "offset": 8},
                                                  {"name": "OnBeforeSceneLoadStage3Action", "token": "0x04003b9f", "offset": 16}],
                                       "binding_status": "CANDIDATE_only; not joined to the static-data base used at these three loads"},
            "unknowns": ["The referenced TypeInfo resolves to the nested LoadScene display class; this does not establish that the three loaded values are GameSceneManager event backing fields.",
                         "Runtime delegate targets, invocation-list order, handler effects, exceptions, and Unity execution are not recovered by this sequence.",
                         "The inspected window is bounded by the next MethodDef start; complete body and exception regions remain open."],
            "game_executed": False, "runtime_observed": False}


def main():
    result = verify()
    destination = Path(__file__).with_name("stage_dispatch_review.json")
    destination.write_text(json.dumps(result, indent=2) + "\n", encoding="utf-8")
    print(json.dumps({"dispatches": len(result["ordered_dispatches"]),
                      "classification": result["classification"], "report": str(destination)}))


if __name__ == "__main__":
    main()
