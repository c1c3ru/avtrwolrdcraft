#!/usr/bin/env python3
"""Decode the three Stage1-3 indirect-call sites inside GameSceneManager.LoadScene's
own body (previously only flagged as `BLR x9`, target unknown).

No REA target, no execution, no queue change. Pure static ARM64 + IL2CPP metadata
decode against the cached shipped pair, reusing recon_navigation.py's decoder.
"""
import argparse
import bisect
import json
import struct
from pathlib import Path

import recon_navigation as nav

# Each stage reloads the static-fields pointer fresh (defensive codegen, not a
# cached base register across the three), then loads its own event field at the
# offset the contract already documents (0x0/0x8/0x10), null-checks it, and -- if
# non-null -- loads three more 64-bit words out of the *delegate instance itself*
# (not out of GameSceneManager) before branching indirectly through one of them.
STAGES = {
    1: {"field_offset": 0x0, "reload_x0": 0x2072b54, "static_ptr": 0x2072b58, "field": 0x2072b5c,
        "null_guard": 0x2072b60, "func_ptr": 0x2072b64, "arg0": 0x2072b68, "arg1": 0x2072b6c, "blr": 0x2072b70,
        "resume": 0x2072b78},
    2: {"field_offset": 0x8, "reload_x0": 0x2072b84, "static_ptr": 0x2072b88, "field": 0x2072b8c,
        "null_guard": 0x2072b90, "func_ptr": 0x2072b94, "arg0": 0x2072b98, "arg1": 0x2072b9c, "blr": 0x2072ba0,
        "resume": 0x2072ba8},
    3: {"field_offset": 0x10, "reload_x0": 0x2072bb4, "static_ptr": 0x2072bb8, "field": 0x2072bbc,
        "null_guard": 0x2072bc0, "func_ptr": 0x2072bc4, "arg0": 0x2072bc8, "arg1": 0x2072bcc, "blr": 0x2072bd0,
        "resume": 0x2072bd4},
}
# Delegate-instance field offsets read at every stage, relative to the loaded
# delegate object (x8), not to GameSceneManager. Candidate labels follow the
# public IL2CPP Il2CppDelegate ABI (method_ptr-free invoke_impl / m_target /
# method triad) but that struct identity is NOT independently confirmed for
# this exact Unity/IL2CPP build -- only the offsets, registers and argument
# roles are binary-verified facts.
DELEGATE_FIELD_OFFSETS = {"invoke_candidate": 0x18, "arg0_candidate_target": 0x40, "arg1_candidate_method": 0x28}
STATIC_FIELDS_PTR_OFFSET = 0xb8
# Reused idiom: ldr x9,[x_d,#0x18]; ldr x0,[x_d,#0x40]; ldr x1,[x_d,#0x28]; blr x9.
IDIOM_WORDS = (0xf9400d09, 0xf9402100, 0xf9401501, 0xd63f0120)
REPORT = nav.ROOT / "reports/recon/stage_dispatch.json"


def opcode_for_load(rn, rt, byte_offset):
    require_multiple_of_8 = byte_offset % 8 == 0
    nav.require(require_multiple_of_8, "unsigned 64-bit LDR immediate must be a multiple of 8")
    return 0xf9400000 | ((byte_offset // 8) << 10) | (rn << 5) | rt


def decode_stage(elf, stage, sites):
    decoded = {"stage": stage, "event_field_offset": hex(sites["field_offset"])}
    expectations = {
        sites["reload_x0"]: opcode_for_load(23, 0, 0),             # ldr x0, [x23]
        sites["static_ptr"]: opcode_for_load(0, 8, STATIC_FIELDS_PTR_OFFSET),  # ldr x8, [x0, #0xb8]
        sites["field"]: opcode_for_load(8, 8, sites["field_offset"]),          # ldr x8, [x8, #field]
        sites["func_ptr"]: opcode_for_load(8, 9, DELEGATE_FIELD_OFFSETS["invoke_candidate"]),
        sites["arg0"]: opcode_for_load(8, 0, DELEGATE_FIELD_OFFSETS["arg0_candidate_target"]),
        sites["arg1"]: opcode_for_load(8, 1, DELEGATE_FIELD_OFFSETS["arg1_candidate_method"]),
    }
    for address, expected in expectations.items():
        nav.expect(elf, address, expected)
    null_guard = nav.branch(sites["null_guard"], nav.word(elf, sites["null_guard"]))
    nav.require(null_guard == {"kind": "CBZ", "register": 8, "width": 64, "target": sites["resume"]},
                f"stage {stage} null-guard changed")
    blr = nav.branch(sites["blr"], nav.word(elf, sites["blr"]))
    nav.require(blr == {"kind": "BLR", "register": 9, "target": None}, f"stage {stage} indirect dispatch changed")
    decoded["sites"] = {name: hex(addr) for name, addr in sites.items()}
    decoded["null_guard"] = null_guard
    decoded["indirect_call"] = blr
    decoded["candidate_semantics"] = (
        f"If GameSceneManager's static OnBeforeSceneLoadStage{stage}Action field (static-fields+{hex(sites['field_offset'])}) "
        "is non-null: load the delegate instance's own +0x18/+0x40/+0x28 words into x9/x0/x1 and `blr x9` -- "
        "an indirect call through a per-instance function pointer, not a branch to any fixed handler address. "
        "x0/x1 are the AArch64 ABI's first two integer arguments to that call."
    )
    return decoded


def scan_idiom(elf, rows, resolve):
    """How common is this exact 4-instruction sequence elsewhere in the same .so?
    Corroborating evidence only: a shared compiler idiom is not proof that every
    hit here is itself an Action/event dispatch, and this list is not exhaustive
    beyond the aligned, 4-byte-word, executable-segment scan performed."""
    starts = sorted({int(row["vaddr"], 16) for row in rows if row.get("vaddr")})
    hits = []
    for segment in elf.loads:
        if not segment["flags"] & 1:
            continue
        data = memoryview(elf.data)[segment["file_offset"]:segment["file_offset"] + segment["file_size"]]
        limit = len(data) // 4 * 4
        words = struct.unpack_from(f"<{limit // 4}I", data[:limit])
        for index in range(len(words) - 3):
            if words[index:index + 4] == IDIOM_WORDS:
                hits.append(segment["vaddr"] + index * 4)
    samples = []
    for address in hits[:5] + hits[-5:]:
        at = bisect.bisect_right(starts, address) - 1
        owner = resolve(starts[at]) if at >= 0 else []
        samples.append({"site": hex(address),
                        "nearest_owner_candidate": [(row["declaring_type"], row["name"]) for row in owner]})
    return {"total_occurrences_in_executable_segments": len(hits), "sample_sites": samples,
            "classification": "STATIC_recurring_idiom_candidate_not_a_claim_about_every_hit",
            "limit": "4-byte-aligned exact-word scan of executable LOAD segments only; not a disassembly-verified count."}


def run(source, report_path):
    source, report_path = Path(source), Path(report_path)
    binary = (source / "libil2cpp.so").read_bytes()
    metadata = (source / "global-metadata.dat").read_bytes()
    nav.verify_pair(binary, metadata)
    elf, meta = nav.Elf(binary), nav.Metadata(metadata)
    rows, resolve = nav.load_index(source / "metadata_methods.jsonl", elf, meta)
    ident = resolve(0x20728d4)
    nav.require(len(ident) == 1 and ident[0]["declaring_type"] == "PWC.GameSceneManager" and ident[0]["name"] == "LoadScene",
                "LoadScene identity mismatch")
    stages = [decode_stage(elf, stage, sites) for stage, sites in STAGES.items()]
    idiom = scan_idiom(elf, rows, resolve)
    report = {
        "schema_version": 1,
        "scope": "GameSceneManager.LoadScene's own Stage1-3 indirect dispatch sites; bounded decode, not full CFG.",
        "evidence_class": "STATIC_bytes_and_metadata_with_DERIVED_candidate_semantics",
        "native_sha256": nav.sha(binary), "metadata_sha256": nav.sha(metadata),
        "method_index_sha256": nav.sha((source / "metadata_methods.jsonl").read_bytes()),
        "producer_sha256": nav.sha(Path(__file__).read_bytes()),
        "helper_sha256": nav.sha(Path(nav.__file__).read_bytes()),
        "stages": stages,
        "idiom_corroboration": idiom,
        "candidate": [
            "Each stage re-reads the static-fields pointer (GameSceneManager statics + 0xb8) fresh instead of reusing a cached register across stages -- defensive/non-CSE codegen, not three different pointers.",
            "The event field itself (static-fields+0x0/0x8/0x10, matching the already-documented Stage1/2/3 offsets) holds a delegate object reference; CBZ on it reproduces 'invoke only if non-null' (an empty C# event is a null field).",
            "If non-null, three words are read out of the delegate OBJECT (not out of GameSceneManager): +0x18 into x9 (the BLR target), +0x40 into x0, +0x28 into x1, then `blr x9`.",
            "This exact 4-instruction load/load/load/blr sequence recurs widely elsewhere in the same .so across unrelated classes (UIElements, WebSocketSharp closures, generated display classes), so it reads as IL2CPP's generic compiled idiom for invoking a 0-arg/void delegate instance directly, not something special-cased for these three events.",
        ],
        "unknowns": [
            "Whether delegate+0x18/+0x40/+0x28 are exactly Il2CppDelegate.invoke_impl/m_target/method (or differently-named fields with the same offsets) is a candidate label from the public IL2CPP ABI shape, not independently confirmed against this build's own headers.",
            "Which concrete handler(s) actually run through this indirect call -- and in what order for Stage2, which docs/RECON_SCENE_SUBSCRIBERS.md shows has two static-registration edges (PersistentDataManager, LevelManager) -- is a runtime property of the delegate object built by those add_* calls, not something these three call sites fix by themselves.",
            "Whether these BLR targets are ever anything other than the Action-shaped single/multicast dispatch already described (reflection, dynamically rebuilt delegates) is not ruled out.",
            "No device/runtime observation of these three calls was performed.",
        ],
        "status": "static_candidate_not_runtime_validated",
    }
    nav.atomic_json(report_path, report)
    return report


if __name__ == "__main__":
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--source", type=Path, default=nav.ROOT / "out/recon/il2cpp")
    parser.add_argument("--report", type=Path, default=REPORT)
    args = parser.parse_args()
    result = run(args.source, args.report)
    print(json.dumps({"status": result["status"],
                      "idiom_occurrences": result["idiom_corroboration"]["total_occurrences_in_executable_segments"],
                      "report": str(args.report)}))
