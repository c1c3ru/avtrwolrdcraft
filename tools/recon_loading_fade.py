"""T029 shipped loading-prefab, virtual Fade and callback lifecycle evidence.

Reads the cached exact native/metadata pair and only the required UnityFS entry
from the original asset-pack APK. No target runs or runtime-equivalence claims.
"""
from __future__ import annotations

import argparse
import gzip
import json
from pathlib import Path
import struct
import subprocess
import sys
import zipfile

import recon_navigation as nav

ROOT = nav.ROOT
SCREEN = "PWC.LoadingScreen.LoadingScreenScreen"
MANAGER = "PWC.LoadingScreen.LoadingScreenManager"
ASSET_SHA = "66fd0e2732064ddfeaf2d4f596b8f25d81376a703e7b5878c2d9585c5e3ec792"
BASE_SHA = "c7edf76ff14254ecab9dc4162962f5d49d8e13be6e2e74e38f7d992f8c77ca07"
SERIALIZED_SHA = "26dfd17a8ee7fe41621de3feabed192f66f81343322eecf81e314d4d0c91d91c"
METHODS = {
    24514: (0x20fe2d8, MANAGER, "StartSceneTransition"),
    24515: (0x20fe4b4, MANAGER, "OnSceneLoaded"),
    24519: (0x20fe6c4, "<>c__DisplayClass8_0", "<OnSceneLoaded>b__0"),
    24520: (0x20fe6ec, SCREEN, "Fade"),
    24521: (0x20fe92c, SCREEN, "AnimateClock"),
    24524: (0x20feab4, "<>c__DisplayClass5_0", "<Fade>b__0"),
    24525: (0x20fead8, "<>c__DisplayClass5_0", "<Fade>b__1"),
    4563: (0x1cb3a60, "PazuCore.Utils", "ExecuteNextFrame"),
    4564: (0x1cb83f8, "PazuCore.Utils", "ExecuteNextFrameCoroutine"),
    4708: (0x1cbed54, "<ExecuteNextFrameCoroutine>d__38", "MoveNext"),
}
ANCHORS = {
    # Manager Fade(true,callback): concrete receiver; slot pair; BR x4.
    0x20fe438: 0xf9401295, 0x20fe474: 0xf8028e80,
    0x20fe49c: 0xa9578d04, 0x20fe4a4: 0x52800021, 0x20fe4ac: 0xd61f0080,
    # Fade closure stores this/value/action, true-only raycast target and clock.
    0x20fe788: 0xf8010c14, 0x20fe79c: 0xf8020ed5, 0x20fe7a8: 0x381f82d7,
    0x20fe7b4: 0x34000168, 0x20fe7c4: 0x52800021,
    0x20fe7c8: 0xf9416509, 0x20fe7cc: 0xf9416902, 0x20fe7d0: 0xd63f0120,
    0x20fe7d4: 0x52800021, 0x20fe844: 0x1e2e1000, 0x20fe848: 0x1e2703e1,
    0x20fe84c: 0x7100011f, 0x20fe858: 0x1e200c29,
    0x20fe880: 0x4ea81d00, 0x20fe884: 0x4ea91d21,
    # Completion: true invokes optional action; false cancels clock and destroys.
    0x20feb08: 0x34000128, 0x20feb0c: 0xf9401268, 0x20feb10: 0xb4000388,
    0x20feb28: 0xd61f0040, 0x20feb34: 0x2a1f03e1, 0x20feb88: 0xd65f03c0,
    # Scene-loaded false-fade callback + immediate clear of manager field.
    0x20fe52c: 0xf8428e75, 0x20fe550: 0x360000a0, 0x20fe570: 0xf8010ea1,
    0x20fe5bc: 0xf900027f, 0x20fe6c8: 0xf9400800,
    0x20fe6d4: 0x2a1f03e1, 0x20fe6d8: 0xaa1f03e2,
    0x20fe6dc: 0xa9578d04, 0x20fe6e4: 0xd61f0080,
    # Clock true: separate hands; rotate -360 over1/.5s; setLoopType(1).
    0x20fe974: 0x36000775, 0x20fe9c0: 0x52b87688, 0x20fe9c4: 0x1e2e1004,
    0x20fea18: 0x1e2c1004, 0x20fea30: 0x52b87688,
    0x20fe9e8: 0x52800021, 0x20fea50: 0x52800021,
    # Coroutine state0 yields null/state1; state1 calls then returns false.
    0x1cbed58: 0xb9401008, 0x1cbed60: 0x7100051f, 0x1cbed64: 0x54000160,
    0x1cbed6c: 0xf8018e7f, 0x1cbed84: 0x52800020, 0x1cbed88: 0xb81f8260,
    0x1cbed90: 0xf9401268, 0x1cbed98: 0xb9001269, 0x1cbedac: 0xd63f0120,
    0x1cbedb0: 0x2a1f03e0, 0x1cbedb8: 0xd65f03c0,
    0x1cb8434: 0x2a1f03e1, 0x1cb844c: 0xf8020c13,
}
CALLS = {
    0x20fe7dc: (SCREEN, "AnimateClock", "BL"),
    0x20fe818: ("LeanTween", "cancel", "BL"),
    0x20fe838: ("UnityEngine.CanvasGroup", "get_alpha", "BL"),
    0x20fe88c: ("LeanTween", "value", "BL"),
    0x20fe8d4: ("LTDescr", "setOnUpdate", "BL"),
    0x20fe91c: ("LTDescr", "setOnComplete", "B"),
    0x20fead0: ("UnityEngine.CanvasGroup", "set_alpha", "B"),
    0x20feb38: (SCREEN, "AnimateClock", "BL"),
    0x20feb48: ("UnityEngine.Component", "get_gameObject", "BL"),
    0x20feb7c: ("UnityEngine.Object", "Destroy", "B"),
    0x20fe5b8: ("PazuCore.Utils", "ExecuteNextFrame", "BL"),
    0x20fe54c: ("UnityEngine.Object", "op_Equality", "BL"),
    0x20fe9e0: ("LeanTween", "rotateAroundLocal", "BL"),
    0x20fea38: ("LeanTween", "rotateAroundLocal", "BL"),
    0x20fe9f4: ("LTDescr", "setLoopType", "BL"),
    0x20fea5c: ("LTDescr", "setLoopType", "B"),
    0x20fea78: ("LeanTween", "cancel", "BL"),
    0x20fea84: ("LeanTween", "cancel", "BL"),
    0x20feaa4: ("LeanTween", "cancel", "B"),
    0x1cb3a6c: ("PazuCore.Utils", "ExecuteNextFrameCoroutine", "BL"),
    0x1cb3a84: ("UnityEngine.MonoBehaviour", "StartCoroutine", "B"),
}


def file_sha(path):
    import hashlib
    digest = hashlib.sha256()
    with path.open("rb") as stream:
        for chunk in iter(lambda: stream.read(1024 * 1024), b""):
            digest.update(chunk)
    return digest.hexdigest()


def unity_modules():
    for path in (ROOT / "tools/venv/lib").glob("python*/site-packages"):
        sys.path.insert(0, str(path))
    import UnityPy
    from unityfs_extract_entry import decode, read_directory
    return UnityPy, decode, read_directory


def selected_serialized(output):
    """Read only overlapping UnityFS blocks directly inside stored ZIP member."""
    UnityPy, decode, read_directory = unity_modules()
    apk = ROOT / "assets/split_UnityDataAssetPack.apk"
    nav.require(file_sha(apk) == ASSET_SHA, "asset-pack APK identity mismatch")
    with zipfile.ZipFile(apk) as archive:
        info = archive.getinfo("assets/bin/Data/datapack.unity3d")
        nav.require(info.compress_type == 0, "bounded seeking requires stored ZIP member")
        with archive.open(info) as source:
            version, player, engine, blocks, entries, data_start = read_directory(source, info.file_size)
            matches = [entry for entry in entries if entry["path"] == "sharedassets1.assets"]
            nav.require(len(matches) == 1, "serialized file entry is ambiguous")
            entry = matches[0]
            raw_offset, packed_offset = 0, data_start
            data, consumed = bytearray(), 0
            for raw_size, packed_size, flags in blocks:
                left, right = max(entry["offset"], raw_offset), min(entry["offset"] + entry["size"], raw_offset + raw_size)
                if left < right:
                    nav.require(raw_size <= 64 * 1024 * 1024, "selected block exceeds memory bound")
                    source.seek(packed_offset)
                    unpacked = decode(source.read(packed_size), raw_size, flags)
                    consumed += packed_size
                    data.extend(unpacked[left - raw_offset:right - raw_offset])
                raw_offset += raw_size
                packed_offset += packed_size
    nav.require(len(data) == entry["size"] and nav.sha(data) == SERIALIZED_SHA, "selected serialized file hash mismatch")
    output.mkdir(parents=True, exist_ok=True)
    path = output / "sharedassets1.assets"
    if not path.exists() or file_sha(path) != SERIALIZED_SHA:
        path.write_bytes(data)
    env = UnityPy.load(bytes(data))
    objects = {obj.path_id: obj for obj in env.objects}
    raw = {pid: objects[pid].get_raw_data() for pid in (259, 242, 291)}
    base = ROOT / "assets/base.apk"
    nav.require(file_sha(base) == BASE_SHA, "base APK identity mismatch")
    with zipfile.ZipFile(base) as archive:
        base_member = archive.read("assets/bin/Data/data.unity3d")
    base_env = UnityPy.load(base_member)
    scripts = {}
    for obj in base_env.objects:
        if obj.type.name == "MonoScript" and obj.path_id in (1499, 4067, 5535):
            script = obj.read()
            scripts[obj.path_id] = {"class": script.m_ClassName, "namespace": script.m_Namespace,
                                    "assembly": script.m_AssemblyName}
    canvas = objects[210].read()
    return raw, scripts, {"asset_apk_sha256": ASSET_SHA, "base_apk_sha256": BASE_SHA,
                          "base_unityfs_member_sha256": nav.sha(base_member),
                          "selected_entry": entry, "selected_sha256": SERIALIZED_SHA,
                          "compressed_block_bytes_read": consumed, "engine": engine,
                          "canvas_alpha": canvas.m_Alpha, "canvas_blocks_raycasts": canvas.m_BlocksRaycasts,
                          "canvas_interactable": canvas.m_Interactable,
                          "manager_go_name": objects[86].read().m_Name,
                          "screen_go_name": objects[81].read().m_Name}


def pptr(data, offset):
    return struct.unpack_from("<iq", data, offset)


def verify_prefab(raw, scripts):
    manager, screen = raw[259], raw[242]
    nav.require(len(manager) == 44 and len(screen) == 92, "serialized component size changed")
    nav.require(pptr(manager, 0) == (0, 86) and pptr(screen, 0) == (0, 81), "component GameObject binding mismatch")
    nav.require(pptr(manager, 16) == (1, 1499) and pptr(screen, 16) == (1, 4067), "MonoScript binding mismatch")
    nav.require(struct.unpack_from("<I", manager, 28)[0] == struct.unpack_from("<I", screen, 28)[0] == 0,
                "script envelope name/payload changed")
    nav.require(pptr(manager, 32) == (0, 242), "manager prefab reference changed")
    refs = [pptr(screen, 32 + n * 12) for n in range(5)]
    nav.require(refs == [(0, 210), (0, 291), (0, 83), (0, 37), (0, 40)], "loading screen field references changed")
    nav.require(pptr(raw[291], 16) == (1, 5535), "background component script changed")
    nav.require(scripts.get(5535) == {"class": "Image", "namespace": "UnityEngine.UI", "assembly": "UnityEngine.UI"},
                "background Image script identity changed")
    for script, cls in [(1499, "LoadingScreenManager"), (4067, "LoadingScreenScreen")]:
        nav.require(scripts.get(script) == {"class": cls, "namespace": "PWC.LoadingScreen", "assembly": "Assembly-CSharp"},
                    "original MonoScript class identity mismatch")
    return {"manager": {"file": "sharedassets1.assets", "path_id": 259, "game_object": 86, "prefab": 242},
            "screen": {"file": "sharedassets1.assets", "path_id": 242, "game_object": 81, "script": 4067,
                       "canvas_group": 210, "background": 291, "clock_hours": 83, "clock_minutes": 37, "clock_nose": 40},
            "runtime_precondition": "serialized prefab and runtime type not replaced before Instantiate; generic Instantiate semantics remain external"}


def virtual_slot(meta, fullname, slot, expected_index, expected_name):
    matches = [t for t in meta.types if (t["namespace"] + "." + t["name"]).lstrip(".") == fullname]
    nav.require(len(matches) == 1, "virtual receiver typedef ambiguous")
    t = matches[0]
    row = struct.unpack_from("<16I8H2I", meta.data, meta.tables["types"]["offset"] + t["index"] * 88)
    vtables, size = struct.unpack_from("<II", meta.data, 144)
    nav.require(slot < row[21] and (row[14] + slot + 1) * 4 <= size, "virtual slot outside metadata table")
    file_offset = vtables + (row[14] + slot) * 4
    encoded = struct.unpack_from("<I", meta.data, file_offset)[0]
    nav.require(encoded >> 29 == 3 and encoded & 1, "unsupported metadata vtable encoding")
    method_index = (encoded & 0x1fffffff) >> 1
    nav.require(method_index == expected_index, "virtual metadata method target mismatch")
    method = struct.unpack_from("<7I4H", meta.data, meta.tables["methods"]["offset"] + method_index * 36)
    nav.require(meta.string(method[0]) == expected_name and method[9] == slot, "method slot/name mismatch")
    return {"receiver_type": fullname, "type_definition_index": t["index"], "slot": slot,
            "encoded": hex(encoded), "encoded_file_offset": file_offset,
            "method_definition_index": method_index, "name": expected_name,
            "declaring_type_index": method[1], "token": hex(method[6]), "parameters": method[10]}


def fmov_float(word):
    nav.require(word & 0xffe01fe0 == 0x1e201000, "not an FMOV S immediate")
    imm = (word >> 13) & 0xff
    b = (imm >> 6) & 1
    exponent = ((1 - b) << 7) | (0x7c if b else 0) | ((imm >> 4) & 3)
    bits = ((imm >> 7) << 31) | (exponent << 23) | ((imm & 15) << 19)
    return struct.unpack("<f", struct.pack("<I", bits))[0]


def verify_code(elf, meta, resolve):
    methods = []
    for index, (address, owner, name) in METHODS.items():
        found = resolve(address)
        nav.require(len(found) == 1 and (found[0]["declaring_type"], found[0]["name"], found[0]["method_definition_index"]) ==
                    (owner, name, index), "loading method identity mismatch")
        methods.append(found[0])
    for address, expected in ANCHORS.items():
        nav.expect(elf, address, expected)
    duration_word = nav.word(elf, 0x20fe878)
    nav.require(duration_word & 31 == 2 and fmov_float(duration_word) == 0.25, "fade duration/register changed")
    calls = []
    for site, (owner, name, kind) in CALLS.items():
        decoded = nav.branch(site, nav.word(elf, site))
        nav.require(decoded and decoded["kind"] == kind, "call instruction kind changed")
        found = resolve(decoded["target"])
        nav.require(len(found) == 1 and (found[0]["declaring_type"], found[0]["name"]) == (owner, name),
                    f"named fade callee changed at {site:#x}")
        calls.append({"site": hex(site), "target": found[0]})
    screen_slot = virtual_slot(meta, SCREEN, 4, 24520, "Fade")
    raycast_slot = virtual_slot(meta, "UnityEngine.UI.Image", 25, 99720, "set_raycastTarget")
    callbacks = []
    for got, index, name in [(0x41cc838, 24524, "<Fade>b__0"), (0x41cc840, 24525, "<Fade>b__1"),
                             (0x41cc828, 24519, "<OnSceneLoaded>b__0")]:
        usage = nav.metadata_usage(elf, got)
        nav.require(usage["kind"] == 3 and usage["index"] == index, "callback metadata usage mismatch")
        callbacks.append({**usage, "name": name})
    return {"methods": methods, "verified_native_anchors": len(ANCHORS), "verified_calls": calls,
            "virtual_fade_target": screen_slot, "virtual_background_target": raycast_slot,
            "virtual_layout_limit": "native offset0x178/0x2c8 corresponds slots4/25 if vtable starts at0x138; runtime class memory not observed",
            "callback_usages": callbacks, "fade_duration_seconds": 0.25,
            "fade_alpha_targets": {"value_true": 1.0, "value_false": 0.0},
            "effects_status": "STATIC_candidate_not_runtime_certified"}


def run(source, output, report):
    binary, metadata = (source / "libil2cpp.so").read_bytes(), (source / "global-metadata.dat").read_bytes()
    nav.verify_pair(binary, metadata)
    elf, meta = nav.Elf(binary), nav.Metadata(metadata)
    rows, resolve = nav.load_index(source / "metadata_methods.jsonl", elf, meta)
    result = verify_code(elf, meta, resolve)
    raw, scripts, serialized = selected_serialized(output)
    result["prefab_binding"] = verify_prefab(raw, scripts)
    result["serialized_evidence"] = serialized
    starts = sorted(int(r["vaddr"], 16) for r in rows if r["vaddr"])
    llvm = sorted((Path.home() / "Android/Sdk/ndk").glob("*/toolchains/llvm/prebuilt/linux-x86_64/bin/llvm-objdump"))[-1]
    windows = []
    for method in result["methods"]:
        address = int(method["vaddr"], 16)
        stop = next(x for x in starts if x > address)
        nav.require(stop - address <= 4096, "loading window exceeds bound")
        command = [str(llvm), "-d", f"--start-address={address:#x}", f"--stop-address={stop:#x}", str(source / "libil2cpp.so")]
        text = subprocess.run(command, capture_output=True, text=True, timeout=30)
        nav.require(text.returncode == 0, "LLVM disassembly failed")
        name = f"{method['method_definition_index']}-{method['name'].replace('<','').replace('>','')}"
        path = output / (name + ".asm.txt")
        path.write_text(text.stdout)
        chunk = binary[elf.offset(address):elf.offset(stop - 1) + 1]
        windows.append({"method_definition_index": method["method_definition_index"], "start": hex(address),
                        "exclusive_stop": hex(stop), "sha256": nav.sha(chunk), "path": str(path.relative_to(ROOT)),
                        "bound": "next metadata method candidate, not proof of complete/noncontiguous body"})
    result.update(schema_version=1, status="partial_static_candidate_no_semantic_certification",
                  binary_sha256=nav.sha(binary), metadata_sha256=nav.sha(metadata),
                  script_sha256=nav.sha(Path(__file__).read_bytes()), windows=windows,
                  runtime_executed=False, emulated=False, queue_promoted=False)
    result["candidate_lifecycle"] = [
        "StartSceneTransition instantiates serialized LoadingScreenScreen, calls virtual slot4 Fade(true,onFadeComplete).",
        "Fade(true) sets Image.raycastTarget=true via slot25 and starts clock tweens; false skips this start branch.",
        "Fade cancels existing CanvasGroup.gameObject tweens; reads current alpha; LeanTween.value(gameObject,current,target,0.25).",
        "Target is1.0 for true,0.0 for false; onUpdate callback writes CanvasGroup.alpha; completion handler is Fadeb__1.",
        "Completion true: invoke onComplete if nonnull, otherwise return; do not destroy loading screen in this branch.",
        "Completion false: AnimateClock(false), Destroy(screen.gameObject); onComplete is not invoked in this branch.",
        "OnSceneLoaded: when current screen is non-null, capture it, ExecuteNextFrame(manager,closure), clear manager._currentScreen.",
        "ExecuteNextFrame wraps coroutine: first MoveNext yields null, second invokes Action and returns false (scheduling is Unity-owned).",
        "OnSceneLoaded closure calls capturedScreen.Fade(false,null) through slot4.",
        "AnimateClock(true) rotates hours/minutes by-360 with durations1.0/0.5 and setLoopType(1); actual loop scheduling/effect still external.",
        "AnimateClock(false) cancels tween by clockHours,clockMinutes,clockNose object references.",
    ]
    result["unknowns"] = [
        "Actual elapsed tween duration/ease/time scale, interruptions and LeanTween callback dispatch semantics not executed.",
        "Generic Instantiate binding and runtime class overrides/replacement not inspected; target conditional on shipped prefab.",
        "Runtime Il2CppClass layout not observed; native-slot offset correlated with metadata slots and concrete prefab.",
        "Who subscribes LoadingScreenManager.OnSceneLoaded and re-enables input/EventSystem after loading remains open.",
        "Exception/GC/class-init bodies and complete native CFG ranges are not certified.",
        "Scene-load callback body handled by existing recon_load_scene/callback contract, not re-proven here.",
    ]
    nav.atomic_json(output / "raw-binding.json", {"raw_hex": {str(k): v.hex() for k, v in raw.items()}, "scripts": scripts,
                                                 "binding": result["prefab_binding"], "source": serialized})
    nav.atomic_json(report, result)
    print(json.dumps({"status": result["status"], "anchors": result["verified_native_anchors"],
                      "calls": len(result["verified_calls"]), "fade_target": "LoadingScreenScreen.Fade",
                      "duration": result["fade_duration_seconds"], "report": str(report)}, indent=2))
    return result


if __name__ == "__main__":
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--source", type=Path, default=ROOT / "out/recon/il2cpp")
    parser.add_argument("--output", type=Path, default=ROOT / "out/recon/loading-fade")
    parser.add_argument("--report", type=Path, default=ROOT / "reports/recon/loading_fade_contract.json")
    args = parser.parse_args()
    run(args.source, args.output, args.report)
