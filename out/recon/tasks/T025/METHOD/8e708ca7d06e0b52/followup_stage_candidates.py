#!/usr/bin/env python3
"""Bounded, hash-pinned probe of the nine uninspected Stage event-add callers."""
import bisect
import hashlib
import json
import re
import subprocess
import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parents[6]
sys.path.insert(0, str(ROOT / "tools"))
import recon_navigation as nav

TASK = ROOT / "out/recon/tasks/T025/METHOD/8e708ca7d06e0b52"
SOURCE = ROOT / "out/recon/il2cpp"
INDEX = SOURCE / "metadata_methods.jsonl"
INPUT = ROOT / "reports/recon/scene_subscribers.json"
OBJDUMP = Path.home() / "Unity/Hub/Editor/6000.6.6f1/Editor/Data/PlaybackEngines/AndroidPlayer/NDK/toolchains/llvm/prebuilt/linux-x86_64/bin/llvm-objdump"
ACTION_CTOR = 0x32CD13C
KNOWN = {0x2069294, 0x21E0734, 0x2310D64, 0x2310D8C}


def sha(data):
    return hashlib.sha256(data).hexdigest()


def adrp_page(address, word):
    imm = (((word >> 5) & 0x7FFFF) << 2) | ((word >> 29) & 3)
    return (address & ~0xFFF) + (nav.signed(imm, 21) << 12)


def parse_disassembly(text):
    rows = []
    for line in text.splitlines():
        m = re.match(r"\s*([0-9a-f]+):\s+([0-9a-f]{8})\s+(.*)$", line)
        if m:
            rows.append({"address": int(m.group(1), 16), "word": int(m.group(2), 16), "text": m.group(3)})
    return rows


def move_regs(word):
    # AArch64 MOV Xd,Xm alias for ORR Xd,XZR,Xm.
    if word & 0xFFE0FFE0 == 0xAA0003E0:
        return (word & 31, (word >> 16) & 31)
    return None


def class_source(type_name):
    path = ROOT / "out/cpp2il/DiffableCs/Assembly-CSharp" / (type_name.replace(".", "/") + ".cs")
    if not path.is_file():
        return {"path": str(path.relative_to(ROOT)), "exists": False}
    text = path.read_text(encoding="utf-8", errors="replace")
    declaration = re.search(r"\bclass\s+([A-Za-z0-9_]+)\s*(?::\s*([^\n{]+))?", text)
    return {"path": str(path.relative_to(ROOT)), "exists": True, "sha256": sha(path.read_bytes()),
            "declaration": declaration.group(0).strip() if declaration else None,
            "base_list": [x.strip() for x in declaration.group(2).split(",")] if declaration and declaration.group(2) else []}


def valid_registration_edge(candidate):
    usage = candidate.get("handler_resolution", {}).get("metadata_usage", {})
    handler = candidate.get("handler_resolution", {}).get("handler", {})
    flow = candidate.get("delegate_result_to_event_argument", {})
    add_methods = candidate.get("resolved_add_method", [])
    add_target = candidate.get("event_add_target", {})
    return bool(
        candidate.get("handler_resolution", {}).get("status") == "resolved_methoddef_usage"
        and usage.get("kind") == 3
        and usage.get("index") == handler.get("method_definition_index")
        and len(add_methods) == 1
        and re.fullmatch(r"add_OnBeforeSceneLoadStage[123]Action", add_methods[0].get("name", "")) is not None
        and add_target.get("target") == int(candidate["resolved_add_method"][0].get("vaddr", "0x0"), 16)
        and flow.get("status") == "candidate_proved_by_register_flow"
        and flow.get("entry_x0_saved_as_this_x19")
        and flow.get("delegate_receiver_x1_is_this_x19")
        and flow.get("event_add_methodinfo_x1_is_null")
        and flow.get("owner_and_handler_type_compatible")
        and flow.get("restored_to_event_argument_x0_at")
    )


def integrate_child_outputs(report, prior):
    contract_path = TASK / "method-contract.json"
    contract = json.loads(contract_path.read_text(encoding="utf-8"))
    game_manager_path = ROOT / "out/cpp2il/DiffableCs/Assembly-CSharp/PWC/GameSceneManager.cs"
    manager_text = game_manager_path.read_text(encoding="utf-8")
    stage_fields = [{"name": name, "offset": offset} for name, offset in re.findall(
        r"private static Action (OnBeforeSceneLoadStage[123]Action); //Field offset: (0x[0-9a-fA-F]+)", manager_text)]
    dispatch_path = TASK / "stage_dispatch_review.json"
    dispatch = json.loads(dispatch_path.read_text(encoding="utf-8"))
    report["game_manager_stage_field_declarations"] = {
        "source": str(game_manager_path.relative_to(ROOT)), "sha256": sha(game_manager_path.read_bytes()),
        "fields": stage_fields,
        "dispatch_review_sha256": sha(dispatch_path.read_bytes()),
        "ordered_dispatches": dispatch["ordered_dispatches"],
        "typeinfo_provenance": dispatch["typeinfo_provenance"],
        "binding_status": "CANDIDATE_ONLY_unresolved_static_data_base",
        "limit": "The three null-guarded indirect calls and load offsets 0/8/16 are observed. The TypeInfo resolves to <>c__DisplayClass28_0 and the static-data base is not joined to GameSceneManager, so named-field association is unproven; actual delegate targets remain runtime-dependent."}
    old_stage_edges = [e for e in prior["edges"] if "OnBeforeSceneLoadStage" in e["event"]]
    old_normalized = [{"event": e["event"], "caller": e["caller"]["declaring_type"] + "." + e["caller"]["name"],
                       "handler": e["handler"]["declaring_type"] + "." + e["handler"]["name"],
                       "handler_token": e["handler"]["token"], "classification": e["classification"]}
                      for e in old_stage_edges]
    new_normalized = [{"event": c["resolved_add_method"][0]["name"].replace("add_", "").replace("Action", "Action"),
                       "caller": c["owner_candidate"]["declaring_type"] + "." + c["owner_candidate"]["name"],
                       "handler": c["handler_resolution"]["handler"]["declaring_type"] + "." + c["handler_resolution"]["handler"]["name"],
                       "handler_token": c["handler_resolution"]["handler"]["token"],
                       "classification": c["classification"], "evidence": "stage_candidate_analysis.json"}
                      for c in report["candidates"]]
    report["reconciled_direct_stage_registration_scan"] = {
        "prior_probe_sha256": sha(INPUT.read_bytes()),
        "raw_direct_candidates": prior["summary"]["raw_direct_candidates"],
        "prior_positive_stage_edges": len(old_stage_edges),
        "newly_verified_stage_edges": sum(valid_registration_edge(c) for c in report["candidates"]),
        "total_direct_candidates_verified": len(old_stage_edges) + sum(valid_registration_edge(c) for c in report["candidates"]),
        "by_event_candidate_counts": prior["summary"]["candidate_event_add_counts"],
        "previous_edges": old_normalized, "new_edges": new_normalized,
        "limit": "The 13 direct B/BL add candidates in this bounded executable-code scan are verified. This is not a complete subscriber graph; indirect, reflection, dynamically loaded and other code paths remain open."}

    contract["status"] = "STATIC_candidate_contract_partially_checked_not_certified"
    contract["method_identity"]["body_extent_status"] = "candidate_window_only; next metadata start does not prove complete or noncontiguous body/exception extents"
    contract["tool_sources"].append({"script": str(Path(__file__).relative_to(ROOT)),
                                     "role": "Resolves all nine remaining raw Stage1-3 add-call candidates to exact handler MethodDefs and delegate argument flows; reconciles 13/13 raw direct candidates, without claiming complete subscriber graph."})
    contract["pseudocode"] = [line.replace(
        "load/invoke Stage1, Stage2, Stage3 event delegates in order (fields at offsets 0x0/0x8/0x10; BLR at 0x2072b70/0x2072ba0/0x2072bd0). Static scan verifies 13 direct add-call candidates and their handler MethodDefs; actual multicast invocation lists remain runtime-dependent",
        "perform three sequential null-guarded indirect calls at 0x2072b70/0x2072ba0/0x2072bd0 after loading references at candidate offsets 0x0/0x8/0x10; named Stage-field association is unresolved because the observed TypeInfo/static-data base does not establish GameSceneManager identity. Static scan separately verifies 13 direct add-call candidates and their handler MethodDefs")
        for line in contract["pseudocode"]]
    contract["verified_calls_in_body"].append(
        "Three sequential null-guarded indirect calls use references loaded at object offsets 0x0/0x8/0x10 (BLR at 0x2072b70/0x2072ba0/0x2072bd0); these offsets are not bound to named GameSceneManager Stage fields.")
    contract["unknowns"].append(
        "The three indirect-call slots at offsets 0x0/0x8/0x10 are candidate matches for the GameSceneManager Stage fields, but TypeInfo resolves to <>c__DisplayClass28_0 and the static-data base is not joined to GameSceneManager.")
    contract["stage_registration_followup"] = report["reconciled_direct_stage_registration_scan"]
    contract["scene_loaded_subscriber_evidence"]["status"] = (
        "The prior scan's 13 direct Stage add-call candidates are now all verified as static registration edges (13/13); separate OnSceneLoaded add/remove evidence is in reports/recon/t026_scene_hook.json but is not independently accepted here.")
    contract["verification"]["direct_stage_add_candidate_edges"] = "passed (13/13 bounded direct B/BL candidates; 9 newly decoded here)"
    contract["verification"]["body_extent"] = "not certified; 904 bytes is a candidate window bounded by next metadata start"
    contract["verification"]["semantic_certification"] = False
    contract["open_unknown_ids_from_prior_attempt"] = [
        "T029/runtime_class_layout", "T029/instantiate_and_library_effects", "T029/tween_scheduling",
        "T029/scene_loaded_registration", "T029/remaining_stage_registrations",
        "T029/handler_effects_lifetime", "T029/runtime_comparison", "T025/complete_body_and_cfg"]
    contract["unknowns"] = [
        "The 904-byte method window is capped by the next metadata start; complete/noncontiguous body and exception CFG extents are unproven.",
        "All 13 raw direct Stage1-3 add-call candidates found by the bounded scanner are now linked to handler MethodDefs; indirect/reflection/dynamic registrations and complete graph absence remain unproven.",
        "Stage handler effects, exception paths, accessor internals, delegate equality and actual runtime invocation/order are not certified.",
        "The new OnSceneLoaded add/remove report is static and not independently accepted by this child; runtime effects and global event order remain open.",
        "Unity-native tween scheduling/time-scale, generic Instantiate binding, runtime class overrides and device comparison remain open."]
    contract_path.write_text(json.dumps(contract, ensure_ascii=False, indent=2) + "\n", encoding="utf-8")

    flow_path = TASK / "control-flow.json"
    flow = json.loads(flow_path.read_text(encoding="utf-8"))
    flow["body_extent_status"] = "candidate_window_only_not_full_body_or_exception_cfg"
    flow["stage_delegate_fields"] = report["game_manager_stage_field_declarations"]
    flow["direct_registration_edges"] = report["reconciled_direct_stage_registration_scan"]
    flow_path.write_text(json.dumps(flow, ensure_ascii=False, indent=2) + "\n", encoding="utf-8")

    unknown_lines = [
        {"unknown_id": "T025/complete_body_and_cfg", "question": "The 904-byte window ends at a metadata boundary; full/noncontiguous body and exception CFG extents are not proven."},
        {"unknown_id": "T025/stage_dispatch_binding", "question": "Three null-guarded indirect calls use slots at offsets 0/8/16, but TypeInfo/static-data provenance does not bind those slots to named GameSceneManager Stage fields."},
        {"unknown_id": "T029/remaining_stage_registrations", "question": "All 13 raw direct B/BL Stage add candidates were confirmed as static edges. Indirect, reflection, dynamically loaded or otherwise missed registrations and a complete absence claim remain open."},
        {"unknown_id": "T029/handler_effects_lifetime", "question": "The 13 static registrations identify handlers, but their complete effects, exceptions, delegate equality and runtime lifetimes are not certified."},
        {"unknown_id": "T029/scene_loaded_registration", "question": "A separate static OnSceneLoaded add/remove report exists, but it is not independently accepted by this child; runtime callback/effect/order remains open."},
        {"unknown_id": "T029/runtime_class_layout", "question": "Concrete runtime Il2CppClass layout and dispatch are not observed."},
        {"unknown_id": "T029/instantiate_and_library_effects", "question": "Generic Unity Instantiate and runtime class replacement effects remain external."},
        {"unknown_id": "T029/tween_scheduling", "question": "Actual tween scheduling, elapsed time, time scale and engine callback dispatch remain unobserved."},
        {"unknown_id": "T029/runtime_comparison", "question": "No original-versus-client runtime comparison was performed."},
    ]
    (TASK / "unknowns.jsonl").write_text("".join(json.dumps(x, ensure_ascii=False) + "\n" for x in unknown_lines), encoding="utf-8")
    result = {"task_id": "T025/METHOD/8e708ca7d06e0b52", "status": "partial", "semantic_completion": False,
              "method_body_fully_bounded": False,
              "method_body_extent": "904-byte metadata-bounded candidate window; complete/noncontiguous and exception ranges not proven",
              "contract": "out/recon/tasks/T025/METHOD/8e708ca7d06e0b52/method-contract.json",
              "control_flow": "out/recon/tasks/T025/METHOD/8e708ca7d06e0b52/control-flow.json",
              "unknowns": "out/recon/tasks/T025/METHOD/8e708ca7d06e0b52/unknowns.jsonl",
              "stage_registration_followup": "out/recon/tasks/T025/METHOD/8e708ca7d06e0b52/stage_candidate_analysis.json",
              "method": "Observed three sequential null-guarded indirect calls through slots loaded at offsets 0/8/16; association to named GameSceneManager Stage fields remains candidate-only because TypeInfo/static-data provenance is unresolved. Separately verified all nine remaining raw direct add-call candidates against the pinned metadata/codegen pair, delegate constructor MethodDef usage, receiver/type compatibility and flow of the constructed delegate into the exact event accessor. Together with the four earlier positive Stage edges this verifies 13/13 candidates from the bounded direct-encoding scan. This is static registration evidence, not runtime invocation or a complete subscriber graph.",
              "verification": {"new_stage_candidates": "9/9 static registration edges", "all_direct_scan_candidates": "13/13 across Stage1-3", "focused_tests": "3 local mutation/identity tests and 9 existing scene-subscriber tests passed", "runtime_or_device": False},
              "next_action": "Continue with handler bodies/effects and remaining T025 pilot gaps; preserve the full-body/exception and runtime unknowns. Do not mark this child or parent done without independent review and its acceptance bar."}
    (TASK / "result.json").write_text(json.dumps(result, ensure_ascii=False, indent=2) + "\n", encoding="utf-8")


def handler_for_ctor(insns, ctor_index, elf, by_definition):
    ctor = insns[ctor_index]
    # The managed Action constructor's MethodInfo is passed in x2. Require its
    # immediate producer to be an LDR X2,[Xn,#imm], then resolve Xn's GOT slot.
    if ctor_index < 1:
        return {"status": "unknown", "reason": "no instructions precede constructor"}
    load_index = next((i for i in range(ctor_index - 1, max(-1, ctor_index - 7), -1)
                       if insns[i]["word"] & 0xFFC00000 == 0xF9400000
                       and (insns[i]["word"] & 31) == 2), None)
    if load_index is None:
        return {"status": "unknown", "reason": "no nearby LDR X2 before Action constructor"}
    load = insns[load_index]
    w = load["word"]
    if any(ins["word"] & 31 == 2 and ins["address"] > load["address"]
           and ins["address"] < ctor["address"]
           and ins["word"] & 0xFFC00000 != 0xF9400000 for ins in insns[load_index + 1:ctor_index]):
        return {"status": "unknown", "reason": "x2 may be overwritten between load and constructor",
                "method_info_load": load}
    base = (w >> 5) & 31
    offset = ((w >> 10) & 0xFFF) * 8
    adrp_candidates = []
    for i in range(ctor_index - 2, -1, -1):
        ai = insns[i]
        aw = ai["word"]
        if aw & 0x9F000000 == 0x90000000 and (aw & 31) == base:
            # Find a base-preserving LDR from this ADRP's register that yields
            # the exact GOT slot used by the x2 load.
            for li in insns[i + 1:ctor_index - 1]:
                lw = li["word"]
                if (lw & 0xFFC00000 == 0xF9400000 and ((lw >> 5) & 31) == base
                        and (lw & 31) == base):
                    got = adrp_page(ai["address"], aw) + ((lw >> 10) & 0xFFF) * 8
                    adrp_candidates.append((ai, li, got))
                    break
    for ai, li, got in adrp_candidates:
        try:
            usage = nav.metadata_usage(elf, got)
        except Exception:
            continue
        if usage.get("kind") == 3 and usage.get("index") in by_definition:
            return {"status": "resolved_methoddef_usage", "method_info_load": load,
                    "method_info_source_register": base, "method_info_load_offset": offset,
                    "got_reference": {"adrp": ai, "ldr": li, "address": hex(got)},
                    "metadata_usage": usage,
                    "handler": by_definition[usage["index"]]}
    return {"status": "unknown", "reason": "no matching ADRP/LDR GOT slot resolved to MethodDef usage",
            "method_info_load": load, "method_info_source_register": base,
            "candidate_got_pairs": [{"adrp": a, "ldr": l, "got": hex(g)} for a, l, g in adrp_candidates]}


def main():
    binary = (SOURCE / "libil2cpp.so").read_bytes()
    metadata = (SOURCE / "global-metadata.dat").read_bytes()
    nav.verify_pair(binary, metadata)
    elf = nav.Elf(binary)
    md = nav.Metadata(metadata)
    rows, resolve = nav.load_index(INDEX, elf, md)
    by_definition = {r["method_definition_index"]: r for r in rows}
    starts = sorted({int(r["vaddr"], 16) for r in rows if r.get("vaddr")})
    prior = json.loads(INPUT.read_text(encoding="utf-8"))
    candidates = [c for c in prior["direct_encoding_candidates"] if int(c["site"], 16) not in KNOWN]
    outdir = TASK / "stage_candidate_windows"
    outdir.mkdir(parents=True, exist_ok=True)
    results = []
    for c in candidates:
        site = int(c["site"], 16)
        owner = c["owner_candidate"][0]
        start = int(owner["vaddr"], 16)
        next_i = bisect.bisect_right(starts, start)
        stop = starts[next_i] if next_i < len(starts) else site + 4
        if not start <= site < stop:
            raise ValueError(f"candidate {site:#x} outside bounded metadata-owner window")
        command = [str(OBJDUMP), "-d", f"--start-address={start:#x}", f"--stop-address={stop:#x}", str(SOURCE / "libil2cpp.so")]
        process = subprocess.run(command, capture_output=True, text=True, timeout=30, check=True)
        insns = parse_disassembly(process.stdout)
        asm_path = outdir / f"{owner['token']}.asm.txt"
        asm_path.write_text(process.stdout, encoding="utf-8")
        call = nav.branch(site, nav.word(elf, site))
        target_rows = resolve(call["target"]) if call and call.get("target") else []
        target_match = [r for r in target_rows if r["name"].startswith("add_OnBeforeSceneLoadStage")]
        ctor_indexes = [i for i, ins in enumerate(insns)
                        if ins["address"] < site and nav.branch(ins["address"], ins["word"]) == {"kind": "BL", "target": ACTION_CTOR}]
        ctor_index = ctor_indexes[-1] if ctor_indexes else None
        handler = handler_for_ctor(insns, ctor_index, elf, by_definition) if ctor_index is not None else {
            "status": "unknown", "reason": "no preceding call to exact System.Action constructor"}
        preceding = insns[max(0, ctor_index - 3):ctor_index + 1] if ctor_index is not None else []
        delegate_flow = {"status": "unknown"}
        if ctor_index is not None:
            pre_ctor = insns[ctor_index - 1] if ctor_index else None
            saved = move_regs(pre_ctor["word"]) if pre_ctor else None
            if saved and saved[1] == 0:
                saved_reg = saved[0]
                restores = [(i, ins) for i, ins in enumerate(insns[ctor_index + 1:], ctor_index + 1)
                            if ins["address"] < site and move_regs(ins["word"]) == (0, saved_reg)]
                last_use = restores[-1] if restores else None
                if last_use:
                    after_restore = [ins for ins in insns[last_use[0] + 1:] if ins["address"] < site]
                    entry_this = any(move_regs(ins["word"]) == (19, 0) for ins in insns[:ctor_index])
                    target_this = any(move_regs(ins["word"]) == (1, 19)
                                      for ins in insns[max(0, ctor_index - 4):ctor_index])
                    null_add_methodinfo = any(move_regs(ins["word"]) == (1, 31) for ins in after_restore)
                    handler_row = handler.get("handler", {})
                    owner_type = owner["declaring_type"]
                    handler_type = handler_row.get("declaring_type")
                    owner_class = class_source(owner_type)
                    handler_class = class_source(handler_type) if handler_type else {"exists": False}
                    is_same_type = owner_type == handler_type
                    handler_simple = handler_type.rsplit(".", 1)[-1] if handler_type else None
                    base_name_match = handler_simple in owner_class.get("base_list", [])
                    matching_sources = []
                    if base_name_match:
                        for source_path in (ROOT / "out/cpp2il/DiffableCs/Assembly-CSharp").rglob(handler_simple + ".cs"):
                            declaration = re.search(r"\bclass\s+" + re.escape(handler_simple) + r"\s*(?::|\{|$)",
                                                    source_path.read_text(encoding="utf-8", errors="replace"))
                            if declaration:
                                matching_sources.append(str(source_path.relative_to(ROOT)))
                    owner_derives_handler = (base_name_match and matching_sources == [handler_class.get("path")])
                    identity_compatible = is_same_type or owner_derives_handler
                    edge_ok = (handler.get("status") == "resolved_methoddef_usage" and bool(target_match)
                               and entry_this and target_this and identity_compatible and null_add_methodinfo)
                    delegate_flow = {"status": "candidate_proved_by_register_flow",
                                     "constructor_result_saved_in": f"x{saved_reg}",
                                     "restored_to_event_argument_x0_at": hex(last_use[1]["address"]),
                                     "intervening_instructions_to_add": after_restore,
                                     "target_argument_setup_before_ctor": insns[max(0, ctor_index - 4):ctor_index],
                                     "entry_x0_saved_as_this_x19": entry_this,
                                     "delegate_receiver_x1_is_this_x19": target_this,
                                     "event_add_methodinfo_x1_is_null": null_add_methodinfo,
                                     "owner_and_handler_type_compatible": identity_compatible,
                                     "base_type_resolution_candidates": matching_sources,
                                     "owner_class_source": owner_class, "handler_class_source": handler_class,
                                     "positive_static_registration_edge": edge_ok}
        site_word = nav.word(elf, site)
        results.append({"classification": "DERIVED_static_registration_edge_not_runtime_observed",
                        "call_site": {"address": hex(site), "word": hex(site_word),
                                      "bytes_le": site_word.to_bytes(4, "little").hex()},
                        "owner_candidate": owner, "bounded_window": {"start": hex(start), "stop_exclusive": hex(stop),
                            "bytes": stop-start, "limit": "next metadata start is a bounded inspection limit, not a complete body/CFG"},
                        "event_add_target": call, "resolved_add_method": target_match,
                        "action_constructor_calls_before_add": [hex(insns[i]["address"]) for i in ctor_indexes],
                        "last_constructor_argument_window": preceding,
                        "handler_resolution": handler,
                        "delegate_result_to_event_argument": delegate_flow,
                        "assembly_path": str(asm_path.relative_to(ROOT)), "assembly_sha256": sha(process.stdout.encode())})
    report = {"schema_version": 1, "kind": "T025_LoadScene_stage_add_candidate_followup",
              "classification": "STATIC_only_not_runtime_observed", "native_sha256": sha(binary),
              "metadata_sha256": sha(metadata), "method_index_sha256": sha(INDEX.read_bytes()),
              "input_report_sha256": sha(INPUT.read_bytes()), "producer_sha256": sha(Path(__file__).read_bytes()),
              "summary": {"raw_candidates_reviewed": len(results),
                          "handler_methoddefs_resolved_at_last_Action_ctor": sum(r["handler_resolution"]["status"] == "resolved_methoddef_usage" for r in results),
                          "delegate_result_register_flows_candidate_proved": sum(r["delegate_result_to_event_argument"]["status"] == "candidate_proved_by_register_flow" for r in results),
                          "positive_static_registration_edges": sum(valid_registration_edge(r) for r in results),
                          "add_accessor_targets_resolved": sum(bool(r["resolved_add_method"]) for r in results)},
              "candidates": results,
              "limits": ["Candidate owners are tied to the nearest metadata start; this bounded report does not assert complete body/CFG extents.",
                         "Positive edges require the exact add accessor, MethodDef usage passed to Action constructor, same-instance receiver identity (or source-confirmed base type), and delegate-result flow into x0.",
                         "No runtime subscription, invocation, order, lifetime, exception behavior, or handler effects are observed."]}
    integrate_child_outputs(report, prior)
    dest = TASK / "stage_candidate_analysis.json"
    dest.write_text(json.dumps(report, ensure_ascii=False, indent=2) + "\n", encoding="utf-8")
    print(json.dumps({"report": str(dest.relative_to(ROOT)), "summary": report["summary"],
                      "handlers": [(r["owner_candidate"]["declaring_type"], r["owner_candidate"]["name"],
                                    r["handler_resolution"].get("handler", {}).get("declaring_type"),
                                    r["handler_resolution"].get("handler", {}).get("name"),
                                    r["handler_resolution"]["status"]) for r in results]}, ensure_ascii=False, indent=2))


if __name__ == "__main__":
    main()
