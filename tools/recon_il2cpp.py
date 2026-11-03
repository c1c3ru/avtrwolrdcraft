"""Offline, bounded bootstrap for this game's metadata-v31/AArch64 IL2CPP pair.

No original file or protection is modified. Produces structural method mappings,
not recovered source, proven body extents, or function semantics. The deliberately
narrow metadata layout is validated against table ranges, type ownership, image
membership, token sequence, relocation-backed codegen module and executable VAs.
"""
from __future__ import annotations

import argparse
from collections import Counter
import hashlib
import json
from pathlib import Path
import shutil
import struct
import subprocess
import tempfile
import zipfile

ROOT = Path(__file__).resolve().parents[1]
TARGET_TYPES = {"Game.Home.HomePlayButton", "PWC.GameSceneManager", "PWC.World.Buildings.WorldBuilding"}


def digest(path):
    value = hashlib.sha256()
    with path.open("rb") as stream:
        for chunk in iter(lambda: stream.read(1024 * 1024), b""):
            value.update(chunk)
    return value.hexdigest()


def atomic_json(path, value):
    path.parent.mkdir(parents=True, exist_ok=True)
    with tempfile.NamedTemporaryFile("w", dir=path.parent, encoding="utf-8", delete=False) as stream:
        temporary = Path(stream.name)
        json.dump(value, stream, ensure_ascii=False, indent=2)
        stream.write("\n")
    temporary.replace(path)


def member(source, name, output):
    output.parent.mkdir(parents=True, exist_ok=True)
    value = hashlib.sha256()
    with zipfile.ZipFile(source) as archive:
        info = archive.getinfo(name)
        with archive.open(info) as stream, tempfile.NamedTemporaryFile("wb", dir=output.parent, delete=False) as target:
            temporary = Path(target.name)
            for chunk in iter(lambda: stream.read(1024 * 1024), b""):
                value.update(chunk)
                target.write(chunk)
    sha = value.hexdigest()
    reused = output.exists() and output.stat().st_size == info.file_size and digest(output) == sha
    if reused:
        temporary.unlink()
    else:
        temporary.replace(output)
    return {"apk": str(source.relative_to(ROOT)), "member": name, "bytes": info.file_size,
            "zip_crc32": f"{info.CRC:08x}", "sha256": sha,
            "derived_path": str(output.relative_to(ROOT)), "reused_verified": reused}


class Elf:
    def __init__(self, data):
        self.data = data
        if data[:6] != b"\x7fELF\x02\x01":
            raise ValueError("requires little-endian ELF64")
        self.machine = struct.unpack_from("<H", data, 18)[0]
        if self.machine != 183:
            raise ValueError("only AArch64 is supported by this bootstrap")
        self.entry = struct.unpack_from("<Q", data, 24)[0]
        phoff, shoff = struct.unpack_from("<QQ", data, 32)
        phsize, phcount, shsize, shcount, names_index = struct.unpack_from("<5H", data, 54)
        self.loads = []
        for idx in range(phcount):
            p = struct.unpack_from("<II6Q", data, phoff + idx * phsize)
            if p[0] == 1:
                if p[2] + p[5] > len(data):
                    raise ValueError("ELF LOAD exceeds file")
                self.loads.append({"vaddr": p[3], "file_offset": p[2], "file_size": p[5],
                                   "memory_size": p[6], "flags": p[1]})
        sections = [struct.unpack_from("<II4QII2Q", data, shoff + idx * shsize) for idx in range(shcount)]
        name_header = sections[names_index]
        names = data[name_header[4]:name_header[4] + name_header[5]]
        self.relocations = {}
        self.relocation_counts = Counter()
        self.sections = []
        for s in sections:
            name = names[s[0]:names.find(b"\0", s[0])].decode("utf-8")
            self.sections.append({"name": name, "type": s[1], "vaddr": s[3],
                                  "file_offset": s[4], "bytes": s[5], "flags": s[2]})
            if s[1] != 4:
                continue
            if s[9] != 24 or s[4] + s[5] > len(data) or s[5] % 24:
                raise ValueError("unsupported/malformed RELA section")
            for offset in range(s[4], s[4] + s[5], s[9]):
                address, info, addend = struct.unpack_from("<QQq", data, offset)
                kind = info & 0xffffffff
                self.relocation_counts[kind] += 1
                if kind == 1027:  # R_AARCH64_RELATIVE: linked pointer is B + A.
                    if address in self.relocations:
                        raise ValueError("duplicate relative relocation")
                    self.relocations[address] = addend

    def offset(self, address, width=1):
        choices = [p["file_offset"] + address - p["vaddr"] for p in self.loads
                   if p["vaddr"] <= address and address + width <= p["vaddr"] + p["file_size"]]
        if len(choices) != 1:
            raise ValueError(f"VA has no unique file mapping: {address:#x}")
        return choices[0]

    def pointer(self, address):
        return self.relocations.get(address, struct.unpack_from("<Q", self.data, self.offset(address, 8))[0])

    def executable(self, address):
        return any(p["flags"] & 1 and p["vaddr"] <= address < p["vaddr"] + p["file_size"] for p in self.loads)

    def va_for_offset(self, offset):
        choices = [p["vaddr"] + offset - p["file_offset"] for p in self.loads
                   if p["file_offset"] <= offset < p["file_offset"] + p["file_size"]]
        if len(choices) != 1:
            raise ValueError("file offset has ambiguous/no LOAD mapping")
        return choices[0]


class Metadata:
    def __init__(self, data):
        self.data = data
        sanity, version = struct.unpack_from("<II", data)
        if sanity != 0xFAB11BAF or version != 31:
            raise ValueError("requires plaintext metadata magic FAB11BAF, version 31")
        self.version = version
        self.tables = {}
        for label, header, stride in [("strings", 24, 1), ("methods", 48, 36),
                                      ("types", 160, 88), ("images", 168, 40)]:
            start, size = struct.unpack_from("<II", data, header)
            if start < 256 or start + size > len(data) or size % stride:
                raise ValueError(f"metadata {label} incompatible with narrow v31 layout")
            self.tables[label] = {"offset": start, "bytes": size, "stride": stride, "count": size // stride}
        self.types = []
        t = self.tables["types"]
        for idx in range(t["count"]):
            row = struct.unpack_from("<16I8H2I", data, t["offset"] + idx * 88)
            self.types.append({"index": idx, "name": self.string(row[0]), "namespace": self.string(row[1]),
                               "method_start": row[9], "method_count": row[16], "token": row[25]})
        self.images = []
        t = self.tables["images"]
        for idx in range(t["count"]):
            row = struct.unpack_from("<10I", data, t["offset"] + idx * 40)
            if row[2] + row[3] > len(self.types):
                raise ValueError("image type range exceeds table")
            self.images.append({"index": idx, "name": self.string(row[0]),
                                "type_start": row[2], "type_count": row[3]})

    def string(self, index):
        table = self.tables["strings"]
        if index >= table["bytes"]:
            raise ValueError("string index outside metadata string table")
        offset = table["offset"] + index
        end = self.data.find(b"\0", offset, table["offset"] + table["bytes"])
        if end < 0:
            raise ValueError("unterminated metadata string")
        return self.data[offset:end].decode("utf-8")

    def image_methods(self, image_name):
        images = [image for image in self.images if image["name"] == image_name]
        if len(images) != 1:
            raise ValueError("expected one metadata image")
        image = images[0]
        methods = []
        table = self.tables["methods"]
        seen = set()
        for typ in self.types[image["type_start"]:image["type_start"] + image["type_count"]]:
            if not typ["method_count"]:
                continue
            if typ["method_start"] + typ["method_count"] > table["count"]:
                raise ValueError("type methods exceed metadata method table")
            for idx in range(typ["method_start"], typ["method_start"] + typ["method_count"]):
                row = struct.unpack_from("<7I4H", self.data, table["offset"] + idx * 36)
                token, rid = row[6], row[6] & 0xffffff
                if row[1] != typ["index"] or token >> 24 != 6 or rid in seen:
                    raise ValueError("method declaring type/token inconsistent with v31 layout")
                seen.add(rid)
                methods.append({"method_definition_index": idx, "declaring_type_index": typ["index"],
                                "declaring_type": (typ["namespace"] + "." + typ["name"]).lstrip("."),
                                "name": self.string(row[0]), "token": f"0x{token:08x}", "rid": rid,
                                "parameter_count": row[10], "flags": row[7], "implementation_flags": row[8],
                                "slot": row[9], "generic_container_index": row[5]})
        if seen != set(range(1, len(methods) + 1)):
            raise ValueError("image method tokens are not dense and unique")
        return image, methods


def codegen_module(elf, name, count):
    encoded = name.encode() + b"\0"
    strings = []
    cursor = 0
    while (cursor := elf.data.find(encoded, cursor)) >= 0:
        strings.append(elf.va_for_offset(cursor))
        cursor += 1
    candidates = []
    for address, addend in elf.relocations.items():
        if addend not in strings:
            continue
        field_count = struct.unpack_from("<Q", elf.data, elf.offset(address + 8, 8))[0]
        pointers = elf.pointer(address + 16)
        if field_count == count:
            elf.offset(pointers, count * 8)
            candidates.append({"module_vaddr": address, "name_vaddr": addend,
                               "method_count": field_count, "method_pointers_vaddr": pointers})
    if len(candidates) != 1:
        raise ValueError(f"expected one structurally valid codegen module, found {len(candidates)}")
    return candidates[0]


def bounded_disassembly(elf, meta, output, selected_methods):
    # Index the other 95 images only to name direct call targets. This does not
    # claim their semantics, native-only functions or generic instantiations.
    all_methods = []
    modules = []
    for image in meta.images:
        _, rows = meta.image_methods(image["name"])
        module = codegen_module(elf, image["name"], len(rows))
        modules.append({"image": image["name"], **module})
        for row in rows:
            slot = module["method_pointers_vaddr"] + (row["rid"] - 1) * 8
            address = elf.pointer(slot)
            if address and (address % 4 or not elf.executable(address)):
                raise ValueError("nonzero cross-image method pointer not executable/aligned")
            all_methods.append({"image": image["name"], "declaring_type": row["declaring_type"],
                                "name": row["name"], "token": row["token"],
                                "method_definition_index": row["method_definition_index"],
                                "parameter_count": row["parameter_count"],
                                "vaddr": hex(address) if address else None,
                                "file_offset": hex(elf.offset(address)) if address else None})
    with (output / "metadata_methods.jsonl").open("w", encoding="utf-8") as stream:
        for row in all_methods:
            stream.write(json.dumps(row, ensure_ascii=False) + "\n")
    by_address = {}
    for row in all_methods:
        if row["vaddr"]:
            by_address.setdefault(int(row["vaddr"], 16), []).append(row)
    starts = sorted(by_address)
    candidates = sorted((Path.home() / "Android/Sdk/ndk").glob("*/toolchains/llvm/prebuilt/linux-x86_64/bin/llvm-objdump"),
                        key=lambda p: tuple(int(v) for v in p.parents[5].name.split(".")))
    llvm = str(candidates[-1]) if candidates else shutil.which("llvm-objdump")
    windows = []
    wanted = {"LoadPlayScene", "LoadScene", "LoadSceneImplement", "GetCurrentWorldSceneName", "ClickOnLevel"}
    for row in selected_methods:
        if row["name"] not in wanted or not row["vaddr"]:
            continue
        start = int(row["vaddr"], 16)
        next_start = next((a for a in starts if a > start), start + 2048)
        stop = min(next_start, start + 2048)
        path = output / (row["declaring_type"] + "." + row["name"] + ".asm.txt")
        commands = []
        if llvm:
            command = [llvm, "-d", f"--start-address={start:#x}", f"--stop-address={stop:#x}", str(output / "libil2cpp.so")]
            result = subprocess.run(command, capture_output=True, text=True, timeout=30)
            if result.returncode:
                raise ValueError(f"llvm-objdump failed: {result.stderr[:500]}")
            path.write_text(result.stdout, encoding="utf-8")
            commands = command
        branches = []
        for address in range(start, stop, 4):
            word = struct.unpack_from("<I", elf.data, elf.offset(address, 4))[0]
            if word & 0xfc000000 in (0x94000000, 0x14000000):
                delta = word & 0x3ffffff
                if delta & 0x2000000:
                    delta -= 0x4000000
                target = address + delta * 4
                branches.append({"site": hex(address), "word": hex(word),
                                 "encoding": "BL" if word & 0xfc000000 == 0x94000000 else "B",
                                 "target": hex(target), "metadata_targets": by_address.get(target, [])})
            elif word & 0xfffffc1f == 0xd63f0000:
                branches.append({"site": hex(address), "word": hex(word), "encoding": "BLR",
                                 "register": f"x{(word >> 5) & 31}", "target": None,
                                 "status": "UNKNOWN_indirect_call_target"})
        windows.append({"declaring_type": row["declaring_type"], "name": row["name"],
                        "start": hex(start), "exclusive_stop": hex(stop),
                        "bound_basis": "bounded linear window capped at next distinct metadata method start; NOT a proven complete body",
                        "assembly_path": str(path.relative_to(ROOT)) if llvm else None,
                        "command": commands, "branch_encoding_candidates": branches,
                        "limitations": ["linear decode; reachability and complete body coverage not established",
                                        "branches outside window and indirect calls need CFG/callee analysis",
                                        "llvm nearest-export labels are not recovered method names; use metadata_targets instead"]})
    return {"llvm_objdump": llvm, "metadata_images_structurally_joined": len(modules),
            "metadata_methods_indexed": len(all_methods),
            "metadata_method_null_pointers": sum(row["vaddr"] is None for row in all_methods),
            "modules": modules, "windows": windows}


def getter_operands(elf, meta):
    """Exact-binary static probe; operands are not portable to another release."""
    expected = "b63661fa60c23ebef1c2da4bb5288ad787eb3da36b22d4bdf285401f1643d728"
    if hashlib.sha256(elf.data).hexdigest() != expected:
        return {"status": "UNKNOWN_operand_probe_not_supported_for_this_binary"}
    # Check the literal-bearing LDR and enum value MOV from the saved assembly.
    if struct.unpack_from("<I", elf.data, elf.offset(0x2073288, 4))[0] != 0xf942dc00:
        raise ValueError("getter LDR opcode changed")
    if struct.unpack_from("<I", elf.data, elf.offset(0x20732a0, 4))[0] != 0x5280002a:
        raise ValueError("getter enum immediate opcode changed")
    key_got = 0x41c85b8
    key_usage = elf.pointer(key_got)
    encoded = struct.unpack_from("<Q", elf.data, elf.offset(key_usage, 8))[0]
    kind, index = encoded >> 29, (encoded & 0x1fffffff) >> 1
    literals, literal_bytes = struct.unpack_from("<II", meta.data, 8)
    strings, string_bytes = struct.unpack_from("<II", meta.data, 16)
    if kind != 5 or index >= literal_bytes // 8:
        raise ValueError("getter string metadata usage mismatch")
    length, data_index = struct.unpack_from("<II", meta.data, literals + index * 8)
    if data_index + length > string_bytes:
        raise ValueError("getter literal data out of bounds")
    literal = meta.data[strings + data_index:strings + data_index + length].decode("utf-8")
    if literal != "GAME_CURRENT_WORLD":
        raise ValueError("getter key is not expected source constant")
    type_got = 0x41b7d08
    type_usage = elf.pointer(type_got)
    type_encoded = struct.unpack_from("<Q", elf.data, elf.offset(type_usage, 8))[0]
    type_index = (type_encoded & 0x1fffffff) >> 1
    table = meta.tables["types"]
    types = []
    for idx, typ in enumerate(meta.types):
        byval = struct.unpack_from("<I", meta.data, table["offset"] + idx * 88 + 8)[0]
        if byval == type_index:
            types.append(typ["namespace"] + "." + typ["name"])
    if type_encoded >> 29 != 1 or types != ["PWC.Game.LevelWorldType"]:
        raise ValueError("getter enum metadata usage mismatch")
    return {"evidence_class": "DERIVED_static_operand_metadata_usage_join", "binary_sha256": expected,
            "getter_vaddr": "0x2073238",
            "key": {"got_vaddr": hex(key_got), "usage_vaddr": hex(key_usage), "encoded_usage": hex(encoded),
                    "usage_kind": kind, "literal_index": index, "literal": literal},
            "enum": {"got_vaddr": hex(type_got), "usage_vaddr": hex(type_usage), "encoded_usage": hex(type_encoded),
                     "type_index": type_index, "matching_types": types, "value_immediate": 1,
                     "enum_name_from_existing_stub": "World"},
            "static_contract_candidate": "Read PlayerPrefs.GetString(GAME_CURRENT_WORLD, LevelWorldType.World.ToString()); return stored candidate if IsSceneAvailable(candidate), else default.",
            "limits": ["metadata usage decoding is narrow interpretation cross-checked by literal/type and source stub",
                       "IsSceneAvailable body, runtime class initialization and exception effects not certified",
                       "not a differential or device test"]}


def run(root_output, report_path):
    root_output.mkdir(parents=True, exist_ok=True)
    meta_input = member(ROOT / "assets/base.apk", "assets/bin/Data/Managed/Metadata/global-metadata.dat", root_output / "global-metadata.dat")
    elf_input = member(ROOT / "assets/split_config.arm64_v8a.apk", "lib/arm64-v8a/libil2cpp.so", root_output / "libil2cpp.so")
    meta = Metadata((root_output / "global-metadata.dat").read_bytes())
    elf = Elf((root_output / "libil2cpp.so").read_bytes())
    image, methods = meta.image_methods("Assembly-CSharp.dll")
    module = codegen_module(elf, image["name"], len(methods))
    counters = Counter()
    for method in methods:
        slot = module["method_pointers_vaddr"] + (method["rid"] - 1) * 8
        address = elf.pointer(slot)
        method.update({"image": image["name"], "pointer_slot_vaddr": f"0x{slot:x}",
                       "pointer_via_relative_relocation": slot in elf.relocations,
                       "body_extent": "UNKNOWN_not_inferred_from_next_pointer",
                       "semantic_status": "UNKNOWN_not_decompiled_or_executed"})
        if address:
            if not elf.executable(address) or address % 4:
                raise ValueError(f"nonzero method pointer not aligned executable AArch64: {method}")
            offset = elf.offset(address, 16)
            method.update({"vaddr": f"0x{address:x}", "file_offset": f"0x{offset:x}",
                           "first_16_bytes": elf.data[offset:offset + 16].hex(),
                           "mapping_status": "DERIVED_structurally_validated_metadata_module_relocation_join"})
            counters["nonzero_executable_method_pointers"] += 1
        else:
            method.update({"vaddr": None, "file_offset": None, "mapping_status": "UNKNOWN_null_method_pointer"})
            counters["null_method_pointers"] += 1
    methods.sort(key=lambda row: row["rid"])
    with (root_output / "assembly_csharp_methods.jsonl").open("w", encoding="utf-8") as stream:
        for row in methods:
            stream.write(json.dumps(row, ensure_ascii=False) + "\n")
    targets = [row for row in methods if row["declaring_type"] in TARGET_TYPES]
    disassembly = bounded_disassembly(elf, meta, root_output, targets)
    atomic_json(root_output / "pilot_disassembly.json", disassembly)
    atomic_json(root_output / "getter_operands.json", getter_operands(elf, meta))
    tools = {name: shutil.which(name) for name in ["Cpp2IL", "dotnet", "readelf", "objdump", "llvm-objdump", "aarch64-linux-gnu-objdump"]}
    report = {"schema_version": 1, "scope": "offline structural IL2CPP bootstrap; no semantic recovery claim",
              "inputs": {"metadata": meta_input, "native": elf_input},
              "metadata": {"magic": "0xfab11baf", "version": meta.version, "tables": meta.tables,
                           "image_count": len(meta.images), "selected_image": image},
              "elf": {"format": "ELF64 little-endian", "machine": "EM_AARCH64", "type": "ET_DYN",
                      "entry": hex(elf.entry), "load_segments": elf.loads, "sections": elf.sections,
                      "relative_relocations": len(elf.relocations), "relocation_types": dict(elf.relocation_counts)},
              "codegen_module_candidate": module,
              "checks_passed": ["metadata table ranges/divisibility", "all selected type/method owner relationships",
                                "dense unique MethodDef token RIDs", "image method count equals codegen module count",
                                "unique module-name RELATIVE relocation and readable method table",
                                "all nonzero selected module method pointers aligned in file-backed executable LOAD"],
              "counts": {"assembly_csharp_methods": len(methods), **counters,
                         "unique_nonzero_method_starts": len({row["vaddr"] for row in methods if row["vaddr"]}),
                         "pilot_target_methods": len(targets)},
              "pilot_targets": targets, "tool_paths": tools,
              "cross_image_index": {"images": disassembly["metadata_images_structurally_joined"],
                                    "methods": disassembly["metadata_methods_indexed"],
                                    "null_pointers": disassembly["metadata_method_null_pointers"],
                                    "index_path": str((root_output / "metadata_methods.jsonl").relative_to(ROOT))},
              "pilot_disassembly_path": str((root_output / "pilot_disassembly.json").relative_to(ROOT)),
              "getter_operands_path": str((root_output / "getter_operands.json").relative_to(ROOT)),
              "llvm_objdump": disassembly["llvm_objdump"],
              "methods_index": str((root_output / "assembly_csharp_methods.jsonl").relative_to(ROOT)),
              "limitations": [
                  "Metadata layout is deliberately narrow v31 interpretation; validated structurally against this pair, not a general IL2CPP parser",
                  "Module struct recognized from name/count/method table; full CodeRegistration and MetadataRegistration are not yet recovered",
                  "Assembly-CSharp has detailed mappings; the other 95 metadata images have a lightweight structural index for naming branch targets; native functions outside metadata remain unindexed",
                  "Null pointers can denote abstract/generic/shared/runtime-resolved methods; they remain unknown",
                  "No complete method body size is asserted; next pointer is not a reliable function bound",
                  "Bounded linear assembly windows are disassembled; no pseudocode decompilation, emulator run, target launch or PairIP modification performed",
                  "Generic instantiations, virtual/interface targets, RGCTX, exception paths and callbacks require further analysis",
                  "Derived linked VAs are not observed runtime addresses; ELF load base remains unknown",
              ]}
    atomic_json(report_path, report)
    print(json.dumps({"report": str(report_path), "counts": report["counts"],
                      "metadata_version": meta.version, "module_vaddr": hex(module["module_vaddr"]),
                      "targets": [{key: row[key] for key in ["declaring_type", "name", "token", "vaddr", "file_offset"]}
                                  for row in targets if row["name"] in ["LoadPlayScene", "LoadScene", "LoadSceneImplement", "GetCurrentWorldSceneName", "ClickOnLevel"]]}, indent=2))
    return report


def self_test(output):
    """Fail-closed negative guards on disposable copies of the actual input pair."""
    binary = (output / "libil2cpp.so").read_bytes()
    metadata = (output / "global-metadata.dat").read_bytes()
    passed = []

    def rejects(label, operation):
        try:
            operation()
        except ValueError:
            passed.append(label)
        else:
            raise AssertionError(f"negative guard accepted invalid input: {label}")

    rejects("wrong ELF magic", lambda: Elf(b"BAD!" + binary[4:]))
    altered = bytearray(binary)
    struct.pack_into("<H", altered, 18, 62)
    rejects("unsupported x86-64 machine", lambda: Elf(altered))
    altered = bytearray(metadata)
    struct.pack_into("<I", altered, 4, 29)
    rejects("unsupported metadata version", lambda: Metadata(altered))
    altered = bytearray(metadata)
    struct.pack_into("<I", altered, 52, 1)
    rejects("method table stride mismatch", lambda: Metadata(altered))
    altered = bytearray(metadata)
    method_offset = struct.unpack_from("<I", metadata, 48)[0]
    struct.pack_into("<I", altered, method_offset + 4, 0xffffffff)
    rejects("method/type owner mismatch", lambda: Metadata(altered).image_methods("Assembly-CSharp.dll"))
    elf = Elf(binary)
    rejects("unmapped address", lambda: elf.offset(0xffffffffffffffff))
    meta = Metadata(metadata)
    _, methods = meta.image_methods("Assembly-CSharp.dll")
    rejects("codegen/metadata method-count mismatch", lambda: codegen_module(elf, "Assembly-CSharp.dll", len(methods) + 1))
    result = {"passed": len(passed), "failed": 0, "checks": passed,
              "scope": "negative guards; complete structural mapping checked separately by normal command"}
    atomic_json(output / "self_test.json", result)
    print(json.dumps(result, indent=2))


if __name__ == "__main__":
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--output", type=Path, default=ROOT / "out/recon/il2cpp")
    parser.add_argument("--report", type=Path, default=ROOT / "reports/recon/il2cpp_bootstrap.json")
    parser.add_argument("--self-test", action="store_true", help="verify negative guards against derived local pair without re-extraction")
    args = parser.parse_args()
    if args.self_test:
        self_test(args.output)
    else:
        run(args.output, args.report)
