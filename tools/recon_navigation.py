"""Guarded, offline T029 navigation evidence from the cached shipped IL2CPP pair.

No extraction, target execution, emulation or decompiler is performed. The small
decoder recognizes selected AArch64 operands/control flow, not general semantics.
"""
from __future__ import annotations

import argparse
import hashlib
import json
from pathlib import Path
import struct
import subprocess

from recon_il2cpp import ROOT, Elf, Metadata, atomic_json, codegen_module

NATIVE_SHA = "b63661fa60c23ebef1c2da4bb5288ad787eb3da36b22d4bdf285401f1643d728"
META_SHA = "1ea14cf5829d5c31e5e967b1608b5701020ab0d24bd4ab69d9f1e2b243467bc6"
GETTER = 0x2073238
WINDOWS = {
    "GetCurrentWorldSceneName": ("PWC.GameSceneManager", GETTER, 0x207330c),
    "IsSceneAvailable": ("PWC.GameSceneManager", 0x207305c, GETTER),
    "LoadScene": ("PWC.GameSceneManager", 0x20728d4, 0x2072c5c),
    "LoadSceneImplement": ("PWC.GameSceneManager", 0x2072cc8, 0x2072d84),
    "StartSceneTransition": ("PWC.LoadingScreen.LoadingScreenManager", 0x20fe2d8, 0x20fe4b4),
}
SLICE_HASHES = {
    "GetCurrentWorldSceneName": "95abb656b53d704fc34a79caa08b727e730a0ce46076f64dddd2a83bfc97d8c2",
    "IsSceneAvailable": "f065a64562b96865b277517e81e6e2b514d742646a3f67c1481c1c957a1644f2",
    "LoadScene": "5ad1f0b55ba081cdadf0751b05fa7db5c5cec832482e26694608d5c596ea80a7",
    "LoadSceneImplement": "b083d22fd95c3607d455eda12cae911668727b55f99a5e7bfb9392c879cfb0ed",
    "StartSceneTransition": "8b96fdcc0a263cc55ed4fb582e76124b1efbcc8d7033f42c53bc8a23ca1c957f",
}


def require(condition, message):
    if not condition:
        raise ValueError(message)


def sha(data):
    return hashlib.sha256(data).hexdigest()


def verify_pair(binary, metadata):
    require(sha(binary) == NATIVE_SHA, "native identity mismatch; contract is version-specific")
    require(sha(metadata) == META_SHA, "metadata identity mismatch; contract is pair-specific")


def word(elf, address):
    return struct.unpack_from("<I", elf.data, elf.offset(address, 4))[0]


def expect(elf, address, expected):
    actual = word(elf, address)
    require(actual == expected, f"opcode mismatch at {address:#x}: {actual:#x} != {expected:#x}")


def signed(value, bits):
    return value - (1 << bits) if value & (1 << (bits - 1)) else value


def branch(address, instruction):
    if instruction & 0x7c000000 == 0x14000000:
        return {"kind": "BL" if instruction >> 31 else "B",
                "target": address + signed(instruction & 0x3ffffff, 26) * 4}
    if instruction & 0xff000010 == 0x54000000:
        return {"kind": "B.cond", "condition": instruction & 15,
                "target": address + signed((instruction >> 5) & 0x7ffff, 19) * 4}
    if instruction & 0x7e000000 == 0x34000000:
        return {"kind": "CBNZ" if instruction & 0x1000000 else "CBZ",
                "register": instruction & 31, "width": 64 if instruction >> 31 else 32,
                "target": address + signed((instruction >> 5) & 0x7ffff, 19) * 4}
    if instruction & 0x7e000000 == 0x36000000:
        return {"kind": "TBNZ" if instruction & 0x1000000 else "TBZ", "register": instruction & 31,
                "bit": ((instruction >> 31) << 5) | ((instruction >> 19) & 31),
                "target": address + signed((instruction >> 5) & 0x3fff, 14) * 4}
    for opcode, kind in [(0xd61f0000, "BR"), (0xd63f0000, "BLR"), (0xd65f0000, "RET")]:
        if instruction & 0xfffffc1f == opcode:
            return {"kind": kind, "register": (instruction >> 5) & 31, "target": None}
    return None


def adrp_ldr(elf, adrp_site, ldr_site):
    first, second = word(elf, adrp_site), word(elf, ldr_site)
    require(first & 0x9f000000 == 0x90000000, f"expected ADRP at {adrp_site:#x}")
    require(second & 0xffc00000 == 0xf9400000, f"expected unsigned LDR X at {ldr_site:#x}")
    base_register = first & 31
    require((second >> 5) & 31 == base_register, "ADRP/LDR base-register mismatch")
    immediate = ((first >> 5) & 0x7ffff) << 2 | ((first >> 29) & 3)
    address = (adrp_site & ~0xfff) + (signed(immediate, 21) << 12) + ((second >> 10) & 0xfff) * 8
    return {"adrp_site": hex(adrp_site), "ldr_site": hex(ldr_site), "got_vaddr": address,
            "base_register": base_register, "destination_register": second & 31}


def metadata_usage(elf, got):
    usage = elf.pointer(got)
    encoded = struct.unpack_from("<Q", elf.data, elf.offset(usage, 8))[0]
    require(encoded >> 32 == 0 and encoded & 1, "not a supported encoded metadata usage")
    return {"got_vaddr": hex(got), "usage_vaddr": hex(usage), "encoded": hex(encoded),
            "kind": encoded >> 29, "index": (encoded & 0x1fffffff) >> 1}


def literal(meta, usage):
    require(usage["kind"] == 5, "metadata usage is not string literal")
    offset, size = struct.unpack_from("<II", meta.data, 8)
    data, count = struct.unpack_from("<II", meta.data, 16)
    require(usage["index"] < size // 8 and offset + size <= len(meta.data), "literal index out of bounds")
    length, start = struct.unpack_from("<II", meta.data, offset + usage["index"] * 8)
    require(start + length <= count and data + count <= len(meta.data), "literal data out of bounds")
    return {**usage, "literal": meta.data[data + start:data + start + length].decode("utf-8"),
            "literal_file_offset": data + start, "literal_bytes": length}


def enum_value(meta, usage, value):
    require(usage["kind"] == 1, "metadata usage is not type info")
    table = meta.tables["types"]
    matches = []
    for idx in range(table["count"]):
        row = struct.unpack_from("<16I8H2I", meta.data, table["offset"] + idx * 88)
        if row[2] == usage["index"]:
            matches.append((idx, row))
    require(len(matches) == 1, "type info does not map uniquely to metadata typedef")
    idx, typ = matches[0]
    fullname = meta.string(typ[1]) + "." + meta.string(typ[0])
    require(fullname == "PWC.Game.LevelWorldType", "getter enum type mismatch")
    fields, field_bytes = struct.unpack_from("<II", meta.data, 96)
    defaults, default_bytes = struct.unpack_from("<II", meta.data, 64)
    data, data_bytes = struct.unpack_from("<II", meta.data, 72)
    require(typ[8] + typ[18] <= field_bytes // 12, "enum field range out of bounds")
    constants = {}
    for at in range(defaults, defaults + default_bytes, 12):
        field, default_type, start = struct.unpack_from("<III", meta.data, at)
        if not typ[8] <= field < typ[8] + typ[18]:
            continue
        field_name = meta.string(struct.unpack_from("<I", meta.data, fields + field * 12)[0])
        require(start < data_bytes, "enum default data out of bounds")
        encoded = meta.data[data + start]
        # All constants of this enum are small positive zigzag-compressed ints.
        require(encoded < 0x80 and encoded % 2 == 0, "unsupported enum compressed integer")
        constants[field_name] = {"value": encoded >> 1, "encoded_byte": hex(encoded),
                                 "field_index": field, "default_type_index": default_type,
                                 "file_offset": data + start}
    require(constants.get("World", {}).get("value") == value == 1, "World default does not match instruction")
    return {**usage, "type_definition_index": idx, "type": fullname, "constants": constants,
            "selected": "World", "value": value,
            "decode_scope": "one-byte nonnegative compressed defaults of this exact enum"}


def verify_getter(elf, meta):
    """Validate operands/data flow independently of the full-artifact hash gate."""
    key_ref = adrp_ldr(elf, 0x2073250, 0x2073260)
    require(key_ref["destination_register"] == 19, "key slot must be preserved in x19")
    key = literal(meta, metadata_usage(elf, key_ref["got_vaddr"]))
    require(key["literal"] == "GAME_CURRENT_WORLD", "getter key literal mismatch")
    type_ref = adrp_ldr(elf, 0x207324c, 0x207325c)
    require(type_ref["destination_register"] == 22, "enum slot must be in x22")
    expect(elf, 0x20732a0, 0x5280002a)  # MOV w10,#1
    default = enum_value(meta, metadata_usage(elf, type_ref["got_vaddr"]), 1)
    # The compiler saves default in x19 and fetched candidate in x20.
    for address, opcode in [
        (0x2073298, 0xf94002c8), (0x20732a4, 0x910023e0),
        (0x20732a8, 0xaa1f03e1), (0x20732ac, 0xa900a7e8), (0x20732b0, 0xb9001bea),
        (0x20732b8, 0xf9400268), (0x20732bc, 0xaa0003f3), (0x20732c0, 0xaa1303e1),
        (0x20732c4, 0xaa1f03e2), (0x20732c8, 0xaa0803e0),
        (0x20732d4, 0xaa0003f4), (0x20732e8, 0xaa1403e0),
        (0x20732f0, 0x7200001f), (0x2073308, 0xd65f03c0),
    ]:
        expect(elf, address, opcode)
    selected = word(elf, 0x20732f4)
    require(selected & 0xffe00c00 == 0x9a800000, "expected 64-bit CSEL")
    selection = {"destination": selected & 31, "if_true": (selected >> 5) & 31,
                 "if_false": (selected >> 16) & 31, "condition": (selected >> 12) & 15}
    require(selection == {"destination": 0, "if_true": 20, "if_false": 19, "condition": 1},
            "getter return selection condition/register mismatch")
    calls = {0x20732b4: 0x338d9a0, 0x20732cc: 0x3cc5a70, 0x20732ec: 0x207305c}
    for site, target in calls.items():
        require(branch(site, word(elf, site)) == {"kind": "BL", "target": target}, "getter callee changed")
    require(branch(0x2073268, word(elf, 0x2073268)) ==
            {"kind": "TBNZ", "register": 8, "bit": 0, "target": 0x2073298}, "getter metadata-init guard changed")
    require(branch(0x20732dc, word(elf, 0x20732dc)) ==
            {"kind": "CBNZ", "register": 9, "width": 32, "target": 0x20732e8}, "getter class-init guard changed")
    return {"status": "STATIC_candidate_contract_checked_not_certified", "key": key,
            "default_enum": default, "selection": selection,
            "calls": [{"site": hex(site), "target": hex(target)} for site, target in calls.items()],
            "parameters": [], "return": "string: stored candidate if availability bit0 nonzero; else default World name",
            "pseudocode": ["ensure metadata/class initialization as guarded in code",
                           "fallback = LevelWorldType.World.ToString()",
                           "candidate = PlayerPrefs.GetString(\"GAME_CURRENT_WORLD\", fallback)",
                           "return (IsSceneAvailable(candidate) & 1) != 0 ? candidate : fallback"],
            "effects": ["reads PlayerPrefs through external GetString",
                        "writes lazy metadata-init flag and stack enum temporary",
                        "callee IsSceneAvailable may initialize a static scene-name cache",
                        "runtime helpers/class initialization may have further effects"],
            "unknowns": ["runtime initialization/exception behavior", "Unity PlayerPrefs/Enum implementations",
                         "generic HashSet implementation equivalence", "threading/concurrency and actual device behavior"]}


def load_index(path, elf, meta):
    rows = []
    by_address = {}
    with path.open(encoding="utf-8") as stream:
        for line in stream:
            row = json.loads(line)
            rows.append(row)
            if row["vaddr"]:
                by_address.setdefault(int(row["vaddr"], 16), []).append(row)
    # Revalidate each named external call against current metadata and module
    # before attributing semantics; the cache is only a lookup accelerator.
    modules = {}
    validated = set()

    def resolve(address):
        matches = by_address.get(address, [])
        for row in matches:
            identity = (row["image"], row["token"], row["method_definition_index"])
            if identity in validated:
                continue
            table = meta.tables["methods"]
            idx = row["method_definition_index"]
            require(0 <= idx < table["count"], "index method outside metadata")
            raw = struct.unpack_from("<7I4H", meta.data, table["offset"] + idx * 36)
            typ = meta.types[raw[1]]
            fullname = (typ["namespace"] + "." + typ["name"]).lstrip(".")
            require(meta.string(raw[0]) == row["name"] and fullname == row["declaring_type"] and
                    f"0x{raw[6]:08x}" == row["token"] and raw[10] == row["parameter_count"], "cached symbol metadata mismatch")
            if row["image"] not in modules:
                image, methods = meta.image_methods(row["image"])
                modules[row["image"]] = (image, codegen_module(elf, row["image"], len(methods)))
            image, module = modules[row["image"]]
            require(image["type_start"] <= raw[1] < image["type_start"] + image["type_count"], "cached symbol image mismatch")
            slot = module["method_pointers_vaddr"] + ((raw[6] & 0xffffff) - 1) * 8
            require(elf.pointer(slot) == address, "cached symbol pointer mismatch")
            validated.add(identity)
        return matches

    return rows, resolve


def code_window(elf, name, resolve):
    cls, start, stop = WINDOWS[name]
    require(any(row["name"] == name and row["declaring_type"] == cls for row in resolve(start)), "pilot method identity mismatch")
    data = elf.data[elf.offset(start):elf.offset(stop - 1) + 1]
    require(sha(data) == SLICE_HASHES[name], f"pilot window bytes changed: {name}")
    control = []
    for address in range(start, stop, 4):
        decoded = branch(address, word(elf, address))
        if not decoded:
            continue
        target = decoded.get("target")
        control.append({"site": hex(address), "opcode": hex(word(elf, address)), **decoded,
                        "target": hex(target) if target is not None else None,
                        "target_inside_window": start <= target < stop if target is not None else None,
                        "metadata_targets": resolve(target) if target is not None and not start <= target < stop else [],
                        "reachability": "STATIC_encoding_not_runtime_observation"})
    return {"class": cls, "name": name, "start": hex(start), "exclusive_stop": hex(stop),
            "sha256": sha(data), "bytes": len(data), "control_flow_encodings": control,
            "bound_limit": "candidate window capped at next metadata start; noncontiguous body and exception extents not proven",
            "decode_limit": "selected branch encodings only; dataflow checks are explicit in getter guard"}


def verify_transition_anchors(elf):
    """Guard decisive inspected sites, without claiming their callees' effects."""
    calls = {
        0x2073178: 0x3cdb5f8, 0x207318c: 0x3cdc97c, 0x20731b0: 0x32e6058,
        0x20731e4: 0x2b5b5a0, 0x2073230: 0x2b5aab0,
        0x2072a58: 0x3ca5b88, 0x2072a78: 0x217a958, 0x2072a98: 0x208bcc0,
        0x2072ab8: 0x2159d10, 0x2072ad8: 0x21527a0, 0x2072b38: 0x2072c64,
        0x2072c54: 0x20fe2d8, 0x2072d5c: 0x20d7e78, 0x2072d80: 0x3cdc604,
        0x20fe380: 0x3ccab90, 0x20fe3bc: 0x3cc79b8, 0x20fe3dc: 0x3f313b0,
        0x20fe404: 0x3ccab90, 0x20fe430: 0x3cc79b8, 0x20fe448: 0x3cc84a8,
        0x20fe470: 0x25bb3a4,
    }
    for site, target in calls.items():
        decoded = branch(site, word(elf, site))
        require(decoded and decoded["kind"] in ("BL", "B") and decoded["target"] == target,
                f"transition direct-call anchor changed: {site:#x}")
    for address, opcode in [
        (0x20730f8, 0xf9402508), (0x2073140, 0xf8048c14),  # cache slot+0x48
        (0x20731e8, 0x11000694),  # loop i++
        (0x2072a18, 0x3940c108), (0x2072b28, 0x3900c008),  # changing flag+0x30
        (0x2072b30, 0xf8028c01), (0x2072b48, 0xf8020d00),  # loading+0x28, previous+0x20
        (0x20fe438, 0xf9401295), (0x20fe474, 0xf8028e80),  # prefab+0x20/current screen+0x28
    ]:
        expect(elf, address, opcode)
    for site in (0x2072b70, 0x2072ba0, 0x2072bd0):
        require(branch(site, word(elf, site)) == {"kind": "BLR", "register": 9, "target": None},
                "stage callback indirect dispatch changed")
    require(branch(0x20fe4ac, word(elf, 0x20fe4ac)) == {"kind": "BR", "register": 4, "target": None},
            "loading virtual tail dispatch changed")
    require(branch(0x2073180, word(elf, 0x2073180)) ==
            {"kind": "B.cond", "condition": 10, "target": 0x20731f0}, "scene loop signed exit changed")
    require(branch(0x20731ec, word(elf, 0x20731ec)) == {"kind": "B", "target": 0x2073164},
            "scene loop backedge changed")
    require(branch(0x2072a1c, word(elf, 0x2072a1c)) ==
            {"kind": "CBZ", "register": 8, "width": 32, "target": 0x2072a5c}, "already-changing guard changed")
    return {"direct_call_sites": len(calls), "field_loop_and_indirect_anchors": "passed",
            "limit": "anchors and linked symbol identity; not callee execution or complete semantic proof"}


def run(output, report_path, source):
    binary_path, metadata_path = source / "libil2cpp.so", source / "global-metadata.dat"
    binary, metadata = binary_path.read_bytes(), metadata_path.read_bytes()
    verify_pair(binary, metadata)
    elf, meta = Elf(binary), Metadata(metadata)
    _, resolve = load_index(source / "metadata_methods.jsonl", elf, meta)
    required_symbols = {
        0x338d9a0: ("System.Enum", "ToString"),
        0x3cc5a70: ("UnityEngine.PlayerPrefs", "GetString"),
        0x3cdb5f8: ("UnityEngine.SceneManagement.SceneManager", "get_sceneCountInBuildSettings"),
        0x3cdc97c: ("UnityEngine.SceneManagement.SceneUtility", "GetScenePathByBuildIndex"),
        0x32e6058: ("System.IO.Path", "GetFileNameWithoutExtension"),
        0x3cdc604: ("UnityEngine.SceneManagement.SceneManager", "LoadSceneAsync"),
        0x3f313b0: ("UnityEngine.EventSystems.EventSystem", "get_current"),
        0x3cc84a8: ("UnityEngine.Component", "get_transform"),
        0x3cc79b8: ("UnityEngine.Behaviour", "set_enabled"),
    }
    for address, expected in required_symbols.items():
        require(any((row["declaring_type"], row["name"]) == expected for row in resolve(address)),
                f"required named callee missing/mismatched in index: {address:#x}")
    getter = verify_getter(elf, meta)
    anchors = verify_transition_anchors(elf)
    windows = [code_window(elf, name, resolve) for name in WINDOWS]
    output.mkdir(parents=True, exist_ok=True)
    llvm = sorted((Path.home() / "Android/Sdk/ndk").glob("*/toolchains/llvm/prebuilt/linux-x86_64/bin/llvm-objdump"),
                  key=lambda p: tuple(int(part) for part in p.parents[5].name.split(".")))
    for window in windows:
        if llvm:
            command = [str(llvm[-1]), "-d", f"--start-address={window['start']}", f"--stop-address={window['exclusive_stop']}", str(binary_path)]
            result = subprocess.run(command, capture_output=True, text=True, timeout=30)
            require(result.returncode == 0, f"LLVM disassembly failed: {result.stderr}")
            path = output / (window["name"] + ".asm.txt")
            path.write_text(result.stdout, encoding="utf-8")
            window["assembly"] = str(path.relative_to(ROOT))
            window["command"] = command
    availability = {
        "status": "STATIC_candidate_with_unresolved_generic_operations",
        "parameter": "sceneName:string", "return": "bool from terminal generic collection operation",
        "pseudocode": ["ensure metadata and class initialization",
                       "if static_scene_names == null:",
                       "    static_scene_names = construct_collection()  // generic ctor binding remains unknown",
                       "    for i = 0; i < SceneManager.sceneCountInBuildSettings; i++:",
                       "        path = SceneUtility.GetScenePathByBuildIndex(i)",
                       "        name = Path.GetFileNameWithoutExtension(path)",
                       "        add_to_collection(static_scene_names, name)  // generic binding unknown",
                       "return contains_candidate(static_scene_names, sceneName)  // generic binding unknown"],
        "evidence": ["static reference at offset0x48 tested at0x20730f8/0x20730fc and stored at0x2073140",
                     "build-count call0x2073178; signed i>=count exit0x2073180; increment0x20731e8; backedge0x20731ec",
                     "scene-path call0x207318c; basename-without-extension call0x20731b0",
                     "generic add candidate0x20731e4; terminal generic lookup candidate tailB0x2073230"],
        "effects": ["allocates and stores cache when initially null", "mutates cache while enumerating build scenes",
                    "runtime init helpers and GC write-barrier helper calls"],
        "inference": "collection is HashSet<string> per existing field declaration; generic ctor/Add/Contains binding not recovered here",
        "unknowns": ["generic MethodSpec targets/semantics", "cache invalidation/concurrency", "null/exception behavior"]}
    flow = {
        "LoadScene": {
            "parameters": ["sceneName:string", "considerMultiplayer:bool", "mp_nextSceneId:string"],
            "pseudocode": ["allocate closure; store sceneName, considerMultiplayer&1, mp_nextSceneId",
                           "if IsSceneChangingInProgress: tailcall Debug.LogError(message); no scene-transition dispatch on that path",
                           "clear avatar/SUT/car caches via four named calls",
                           "IsSceneChangingInProgress=true; CurrentlyLoadingSceneName=sceneName; PreviousSceneName=GetActiveSceneName()",
                           "invoke optional stage1,stage2,stage3 delegates in order",
                           "construct Action bound to closure; tailcall LoadingScreenManager.Instance.StartSceneTransition(action)"],
            "indirect_calls": ["0x2072b70", "0x2072ba0", "0x2072bd0"],
            "unknowns": ["delegate bodies and ordering side effects beyond call sites", "closure callback actual implementation", "metadata/class-init and allocation exceptions"]},
        "LoadSceneImplement": {
            "parameters": ["sceneName:string"],
            "pseudocode": ["ensure metadata/class initialization",
                           "if multiplayer-static-flag: MPOwnership.Clear()",
                           "tailcall SceneManager.LoadSceneAsync(sceneName)"],
            "unknowns": ["identity/default of flag at loaded static-fields byte0", "Unity async operation/lifecycle", "load errors and runtime initialization"]},
        "StartSceneTransition": {
            "parameters": ["this:LoadingScreenManager", "onFadeComplete:Action"],
            "pseudocode": ["disable existing selected Behaviour and current EventSystem when non-null by Unity object checks",
                           "instantiate _screenPrefab under this.transform; assign _currentScreen with write barrier",
                           "tail-dispatch virtual slot through BR x4, arguments include true and onFadeComplete"],
            "indirect_calls": ["0x20fe4ac:BR x4"],
            "unknowns": ["first disabled Behaviour exact field identity", "generic Instantiate target binding", "virtual receiver method and fade/callback timing", "Unity fake-null/exception behavior"]},
    }
    contract = {"schema_version": 1, "scope": "T029 focused static candidate; no runtime/emulation/certification",
                "input_pair": {"native": {"path": str(binary_path.relative_to(ROOT)), "sha256": sha(binary)},
                               "metadata": {"path": str(metadata_path.relative_to(ROOT)), "sha256": sha(metadata)}},
                "tool_sources": {"navigation_script_sha256": sha(Path(__file__).read_bytes()),
                                 "bootstrap_script_sha256": sha((ROOT / "tools/recon_il2cpp.py").read_bytes()),
                                 "cached_index_sha256": sha((source / "metadata_methods.jsonl").read_bytes())},
                "source_declarations": [{"path": str(path.relative_to(ROOT)), "sha256": sha(path.read_bytes()),
                                         "role": "field names/offsets from prior extraction; method bodies are empty"}
                                        for path in [ROOT / "out/cpp2il/DiffableCs/Assembly-CSharp/PWC/GameSceneManager.cs",
                                                     ROOT / "out/cpp2il/DiffableCs/Assembly-CSharp/PWC/LoadingScreen/LoadingScreenManager.cs"]],
                "evidence_class": "STATIC_and_DERIVED_from_original_cached_bytes", "getter": getter,
                "verified_transition_anchors": anchors,
                "availability": availability, "transition_contracts": flow, "windows": windows,
                "verification": {"input_identity": "passed", "getter_opcode_operands_calls_and_selection": "passed",
                                 "selected_windows_exact_hash": "passed", "named_method_bindings_rechecked": "passed",
                                 "target_executed": False, "emulated": False, "semantic_certification": False},
                "remaining": ["recover generic/indirect targets and closure callback",
                              "validate full CFG/body/exception ranges and runtime-init helpers",
                              "differential/device scenarios using matching original state"]}
    atomic_json(output / "getter_guard.json", getter)
    atomic_json(report_path, contract)
    print(json.dumps({"report": str(report_path), "windows": len(windows), "getter_key": getter["key"]["literal"],
                      "default": getter["default_enum"]["selected"], "status": "static candidate, not semantic certification"}, indent=2))
    return contract


if __name__ == "__main__":
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--source", type=Path, default=ROOT / "out/recon/il2cpp")
    parser.add_argument("--output", type=Path, default=ROOT / "out/recon/navigation")
    parser.add_argument("--report", type=Path, default=ROOT / "reports/recon/navigation_contract.json")
    args = parser.parse_args()
    run(args.output, args.report, args.source)
