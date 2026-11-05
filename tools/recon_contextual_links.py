#!/usr/bin/env python3
"""Join LevelCA components to serialized data and type-specific Spine animation names.

PPtr identities are always (serialized file, path_id). File IDs are resolved from
the source file's own metadata, read in bounded UnityFS ranges and cached by hash.
"""
from __future__ import annotations

import argparse
import bisect
import gzip
import hashlib
import json
import re
import struct
from collections import Counter, defaultdict
from pathlib import Path

from UnityPy.files.SerializedFile import SerializedFile
from UnityPy.streams import EndianBinaryReader

from unityfs_extract_entry import decode, read_directory

ROOT = Path(__file__).resolve().parents[1]
DATA_CLASS = "PWC.PSDToLevel.LevelContextualAnimation.LevelCAItemHandlerData"
REACTION_CLASS = "PWC.PSDToLevel.LevelContextualAnimation.LevelCAReactionsData"
RIGS = {
    1: "Avatar_Spine", 2: "Baby_Spine", 3: "Pet_Cat_Spine", 4: "Pet_Dog_Spine",
    5: "Pet_Bird_Spine", 7: "Pet_Fish_Spine", 8: "Pet_Hamster_Spine",
    9: "Pet_Lizard_Spine", 10: "Pet_Turtle_Spine", 11: "Pet_Rabbit_Spine",
    12: "Pet_Snake_Spine", 13: "Toddler_Spine", 14: "Pet_Horse", 15: "Cow_Pet",
    16: "Pet_Chicken_Spine",
}


def digest(path: Path) -> str:
    h = hashlib.sha256()
    with path.open("rb") as stream:
        for block in iter(lambda: stream.read(1024 * 1024), b""):
            h.update(block)
    return h.hexdigest()


def rel(path: Path) -> str:
    return str(path.resolve().relative_to(ROOT))


def dump_rows(path: Path):
    with gzip.open(path, "rt", encoding="utf-8") as stream:
        for line in stream:
            if line.strip():
                yield json.loads(line)


def identity(row: dict) -> tuple[str, int]:
    if not row.get("_file") or "_path_id" not in row:
        raise ValueError("MonoBehaviour inventory lacks composite object identity")
    return Path(row["_file"]).name, int(row["_path_id"])


def pointers(value, path=""):
    if isinstance(value, dict):
        if "m_FileID" in value and "m_PathID" in value:
            yield path, int(value["m_FileID"]), int(value["m_PathID"])
        else:
            for key, child in value.items():
                yield from pointers(child, f"{path}.{key}" if path else key)
    elif isinstance(value, list):
        for index, child in enumerate(value):
            yield from pointers(child, f"{path}[{index}]")


class ArchiveMetadata:
    def __init__(self, bundle: Path, cache: Path):
        self.bundle = bundle
        self.cache_path = cache
        self.bundle_hash = digest(bundle)
        saved = json.loads(cache.read_text()) if cache.exists() else {}
        self.cached = saved.get("files", {}) if saved.get("bundle_sha256") == self.bundle_hash else {}
        self.used = {}
        self.cache_hits = 0
        self.blocks_decoded = 0
        self.last_block = (-1, b"")
        self.source = bundle.open("rb")
        _, _, _, blocks, entries, packed = read_directory(self.source, bundle.stat().st_size)
        self.entries = {entry["path"]: entry for entry in entries}
        self.blocks = []
        raw = 0
        for raw_size, packed_size, flags in blocks:
            self.blocks.append((raw, raw + raw_size, packed, packed_size, flags))
            raw += raw_size
            packed += packed_size
        self.starts = [block[0] for block in self.blocks]

    def read_range(self, start: int, size: int) -> bytes:
        end = start + size
        index = bisect.bisect_right(self.starts, start) - 1
        result = []
        while index < len(self.blocks):
            left, right, packed, packed_size, flags = self.blocks[index]
            if left >= end:
                break
            if self.last_block[0] != index:
                self.source.seek(packed)
                data = decode(self.source.read(packed_size), right - left, flags)
                self.last_block = index, data
                self.blocks_decoded += 1
            data = self.last_block[1]
            result.append(data[max(start, left) - left:min(end, right) - left])
            index += 1
        combined = b"".join(result)
        if len(combined) != size:
            raise ValueError("incomplete UnityFS metadata range")
        return combined

    def externals(self, name: str) -> list[str]:
        if name in self.used:
            return self.used[name]["externals"]
        if name in self.cached:
            self.used[name] = self.cached[name]
            self.cache_hits += 1
            return self.used[name]["externals"]
        entry = self.entries.get(name)
        if not entry:
            raise ValueError(f"serialized source file missing from bundle: {name}")
        header = self.read_range(entry["offset"], 48)
        version = struct.unpack_from(">I", header, 8)[0]
        if version < 22:
            raise ValueError(f"unsupported serialized header version {version}")
        metadata_end = struct.unpack_from(">q", header, 32)[0]
        if not 48 <= metadata_end <= entry["size"]:
            raise ValueError(f"invalid metadata extent in {name}")
        prefix = self.read_range(entry["offset"], metadata_end)
        asset = SerializedFile(EndianBinaryReader(prefix), name=name)
        value = {"externals": [Path(e.path.replace("\\", "/")).name for e in asset.externals],
                 "metadata_bytes": metadata_end, "metadata_sha256": hashlib.sha256(prefix).hexdigest()}
        self.used[name] = value
        return value["externals"]

    def resolve(self, source: str, file_id: int, path_id: int) -> tuple[str, int] | None:
        if path_id == 0:
            return None
        if file_id == 0:
            return source, path_id
        external = self.externals(source)
        if file_id < 0 or file_id > len(external):
            raise ValueError(f"invalid PPtr file ID {file_id} in {source}")
        return external[file_id - 1], path_id

    def save(self):
        self.source.close()
        merged = dict(self.cached)
        merged.update(self.used)
        self.cache_path.write_text(json.dumps({"bundle_sha256": self.bundle_hash, "files": merged}, indent=2) + "\n")


def base_animation_name(data: dict, config: dict) -> str:
    if config.get("isNameFullAnimationName"):
        return config.get("name") or ""
    folder = config.get("folderNameOverride") or data.get("FolderName") or ""
    prefix = "CA/" if data.get("CharacterSpineType") in (1, 2, 13) else ""
    return prefix + folder + "/" + (config.get("name") or "")


def suffix_rules(asm_report: Path, overrides: list[dict]) -> list[dict]:
    native = json.loads(asm_report.read_text())
    literal_report = json.loads(asm_report.parent.parent.joinpath("contextual-suffix-literals.json").read_text())
    methods = {m["declaring_type"]: m for m in native["mapped_methods"] if m["name"] == "GetAnimationSuffix"}
    standing = {"LevelCACatOnToddlerHandler", "LevelCADogOnToddlerHandler", "LevelCASmallPetOnToddlerHandler"}
    posture = {"LevelCAToddlerBottleItemHandler", "LevelCAToyCarToddlerItemHandler", "LevelCAToddlerPlayablesItemHandler",
               "LevelCAToddlerHandler", "LevelCAToddlerBlanketItemHandler", "LevelCAToddlerFavoritePlushieItemHandler",
               "LevelCAToddlerDrinkablesItemHandler", "LevelCAToddlerEdiblesItemHandler", "LevelCAToddlerPacifierItemHandler"}
    rules = []
    for entry in overrides:
        cls = entry["class"]
        short = cls.rsplit(".", 1)[-1]
        method = methods[cls]
        assembly = ROOT / method["assembly"]
        code = assembly.read_text()
        literals = [item["literal"] for item in literal_report[assembly.name] if "literal" in item]
        if short in standing:
            if literals != ["_Standing"]:
                raise ValueError(f"constant suffix evidence changed: {cls}")
            expression, cases = '"_Standing"', {"all": "_Standing"}
        elif short == "LevelCAToddlerDancingClothingSpineSkinHandler":
            if literals != ["_Sitting", ""] or "#0x440" not in code or "cmp\tw8, #0x2" not in code:
                raise ValueError(f"conditional suffix evidence changed: {cls}")
            expression = 'toddler.PostureType == Sitting ? "_Sitting" : ""'
            cases = {"None": "", "Standing": "", "Sitting": "_Sitting"}
        elif short in posture:
            callees = {(candidate["type"], candidate["name"]) for branch in method["direct_branches"] for candidate in branch["metadata_candidates"]}
            if literals != ["_"] or "#0x440" not in code or ("System.Enum", "ToString") not in callees:
                raise ValueError(f"posture suffix evidence changed: {cls}")
            expression = '"_" + toddler.PostureType.ToString()'
            cases = {"None": "_None", "Standing": "_Standing", "Sitting": "_Sitting"}
        else:
            raise ValueError(f"suffix override needs separate native analysis: {cls}")
        rules.append({"class": cls, "vaddr": method["vaddr"], "assembly": rel(assembly),
                      "assembly_sha256": digest(assembly), "expression": expression,
                      "defined_posture_cases": cases, "source": entry["source"], "native_evidence_checked": True})
    return rules


def verify_pointer_edges(report: dict) -> int:
    count = 0
    metadata = report["metadata"]["files"]
    for asset in report["assets"]:
        expected = asset["file"], asset["path_id"]
        for edge in asset["users"]:
            source, file_id = edge["file"], edge["file_id"]
            target_file = source if file_id == 0 else metadata[source]["externals"][file_id - 1]
            # The stored source pointer ID is retained separately from its resolved target.
            if (target_file, edge["target_path_id"]) != expected:
                raise ValueError(f"edge identity failed independent reconstruction: {edge}")
            count += 1
    if count != report["summary"]["component_scan"]["resolved_data_edges"]:
        raise ValueError("pointer-edge count disagrees with summary")
    return count


def main() -> int:
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument("--bundle", type=Path, default=ROOT / "out/assets/avatar-datapack.unity3d")
    ap.add_argument("--mb", type=Path, default=ROOT / "out/mb")
    ap.add_argument("--inventory", type=Path, default=ROOT / "out/recon/tasks/T035/animation-inventory.json")
    ap.add_argument("--asm-report", type=Path, default=ROOT / "out/recon/tasks/T035/contextual-asm/report.json")
    ap.add_argument("--output", type=Path, default=ROOT / "out/recon/tasks/T035/contextual-links.json")
    args = ap.parse_args()
    args.output.parent.mkdir(parents=True, exist_ok=True)
    inventory = json.loads(args.inventory.read_text())
    rigs = {}
    rig_sources = {}
    for spine_type, rig in RIGS.items():
        matches = [s for s in inventory["spine"]["skeletons"] if s["file"].startswith(rig + ".skel_")]
        if len(matches) != 1:
            raise ValueError(f"expected one source for rig {rig}, found {len(matches)}")
        rigs[spine_type] = set(matches[0]["animation_names"])
        rig_sources[spine_type] = matches[0]["file"]

    sources = []
    data = {}
    for cls, kind in ((DATA_CLASS, "data"), (REACTION_CLASS, "reaction")):
        path = args.mb / (cls + ".jsonl.gz")
        sources.append({"path": rel(path), "sha256": digest(path)})
        for row in dump_rows(path):
            key = identity(row)
            if key in data:
                raise ValueError(f"duplicate composite data identity: {key}")
            data[key] = kind, row
    archive = ArchiveMetadata(args.bundle, args.output.with_name("contextual-metadata-cache.json"))
    data_path_ids = {key[1] for key in data}
    users = defaultdict(list)
    unresolved = []
    handler_stats = Counter()
    class_sources = inventory["contextual_animation_handlers"]["classes"]
    suffix_overrides = []
    for cls in class_sources:
        source = ROOT / cls["source"]
        if cls["class"] != "LevelCAHandlerBase" and re.search(r"GetAnimationSuffix\s*\(", source.read_text()):
            suffix_overrides.append({"class": cls["namespace"] + "." + cls["class"], "source": cls["source"]})
    for path in sorted(args.mb.glob("*.jsonl.gz")):
        if path.name in {DATA_CLASS + ".jsonl.gz", REACTION_CLASS + ".jsonl.gz"}:
            continue
        sources.append({"path": rel(path), "sha256": digest(path)})
        class_name = path.name.removesuffix(".jsonl.gz")
        for row in dump_rows(path):
            source_file, handler_id = identity(row)
            handler_stats["components_scanned"] += 1
            found = False
            for field, file_id, path_id in pointers(row):
                declared_data = "LevelCA" in class_name and field.casefold() in ("data", "_data", "_reactiondata", "_reactionsdata")
                if not path_id:
                    if declared_data:
                        handler_stats["null_declared_data_fields"] += 1
                    continue
                if path_id not in data_path_ids and not declared_data:
                    continue
                target = archive.resolve(source_file, file_id, path_id)
                if target in data:
                    users[target].append({"class": class_name, "file": source_file, "path_id": handler_id,
                                          "field": field, "file_id": file_id, "target_path_id": path_id})
                    handler_stats["resolved_data_edges"] += 1
                    found = True
                elif declared_data:
                    unresolved.append({"class": class_name, "file": source_file, "path_id": handler_id,
                                       "field": field, "target": list(target) if target else None})
            if found:
                handler_stats["components_with_data_edges"] += 1

    asset_rows = []
    configs = Counter()
    reaction_stats = Counter()
    for (file_name, path_id), (kind, row) in sorted(data.items()):
        result = {"file": file_name, "path_id": path_id, "kind": kind, "name": row.get("m_Name"),
                  "users": users[(file_name, path_id)]}
        if kind == "data":
            spine_type = row.get("CharacterSpineType", 0)
            names = rigs.get(spine_type)
            result.update({"spine_type": spine_type, "rig_source": rig_sources.get(spine_type),
                           "data_fields": {k: v for k, v in row.items() if not k.startswith("m_") and not k.startswith("_") and k != "LevelCAConfigs"}})
            result["configs"] = []
            for config in row.get("LevelCAConfigs", []):
                name = base_animation_name(row, config)
                present = name in names if names is not None else None
                configs["total"] += 1
                configs["exact_base_name_present" if present else "unknown_rig" if present is None else "base_name_absent"] += 1
                checked = {"config": config, "base_animation_name": name, "exact_name_present_in_target_rig": present,
                           "name_scope": "full_name_bypasses_handler" if config.get("isNameFullAnimationName") else "empty_suffix_and_data_folder; handler_overrides_require_reconciliation"}
                checked["auxiliary_raw_names"] = {
                    field: {"name": config[field], "raw_name_present_in_target_rig": config[field] in names if names is not None else None}
                    for field in ("preAnimation", "alternateIdleAnimation") if config.get(field)
                }
                result["configs"].append(checked)
        else:
            reactions = []
            for reaction in row.get("_reactions", []):
                spine_type = reaction.get("spineType", 0)
                names = rigs.get(spine_type)
                refs = {}
                if reaction.get("animationName"):
                    initiating_name = reaction["animationName"]
                    source_types = [st for st, animations in rigs.items() if initiating_name in animations]
                    refs["animationName"] = {"name": initiating_name, "role": "initiating_actor; reacting spineType does not identify its rig",
                                             "candidate_source_spine_types": source_types}
                    reaction_stats["initiating_names_present_in_any_rig"] += bool(source_types)
                if reaction.get("reactionAnimationName"):
                    reacting_name = reaction["reactionAnimationName"]
                    present = reacting_name in names if names is not None else None
                    refs["reactionAnimationName"] = {"name": reacting_name, "role": "reacting_actor",
                                                     "exact_name_present_in_reacting_rig": present}
                    reaction_stats["reaction_names_present_in_reacting_rig"] += present is True
                reaction_stats["entries"] += 1
                reactions.append({"config": reaction, "rig_source": rig_sources.get(spine_type), "names": refs})
            result["reactions"] = reactions
        asset_rows.append(result)
    archive.save()
    recovered_suffix_rules = suffix_rules(args.asm_report, suffix_overrides)
    absent_reaction_names = []
    absent_initiating_names = []
    for asset in asset_rows:
        for reaction in asset.get("reactions", []):
            actor = reaction["names"].get("animationName")
            reacting = reaction["names"].get("reactionAnimationName")
            context = {"file": asset["file"], "path_id": asset["path_id"], "asset": asset["name"]}
            if actor and not actor["candidate_source_spine_types"]:
                leaf = actor["name"].rsplit("/", 1)[-1]
                alternatives = [{"spine_type": st, "name": name} for st, names in rigs.items()
                                for name in sorted(names) if name.rsplit("/", 1)[-1] == leaf]
                absent_initiating_names.append({**context, "name": actor["name"], "same_leaf_name_candidates": alternatives})
            if reacting and reacting["exact_name_present_in_reacting_rig"] is not True:
                raw_name = reacting["name"]
                candidates = {raw_name.removeprefix("CA/"), "CA/" + raw_name}
                target_names = rigs.get(reaction["config"].get("spineType"), set())
                absent_reaction_names.append({**context, "name": raw_name, "rig_source": reaction["rig_source"],
                                              "CA_prefix_variant_candidates": sorted(candidates & target_names)})
    summary = {"data_assets": sum(x["kind"] == "data" for x in asset_rows),
               "reaction_assets": sum(x["kind"] == "reaction" for x in asset_rows),
               "assets_with_component_links": sum(bool(x["users"]) for x in asset_rows),
               "component_scan": dict(handler_stats), "config_names": dict(configs), "reactions": dict(reaction_stats),
               "unresolved_declared_data_fields": len(unresolved), "suffix_override_classes": len(suffix_overrides)}
    report = {
        "status": "static_pointer_edges_resolved_animation_name_candidates_checked",
        "inputs": {"bundle": rel(args.bundle), "bundle_sha256": archive.bundle_hash,
                   "animation_inventory": rel(args.inventory), "animation_inventory_sha256": digest(args.inventory),
                   "contextual_native_report": rel(args.asm_report), "contextual_native_report_sha256": digest(args.asm_report),
                   "suffix_literal_report_sha256": digest(args.asm_report.parent.parent / "contextual-suffix-literals.json"),
                   "monobehaviour_inventories": sources},
        "summary": summary,
        "name_rule_evidence": {"CreateAnimationName": "0x212fe74", "HasCAPrefixForCAAnimations": "0x2187938",
                               "formula": "full flag: config.name; otherwise (CA/ for SpineType 1,2,13) + (folderNameOverride or handler.GetFolderName()) + / + config.name + handler.GetAnimationSuffix()",
                               "scope": "Data FolderName and empty suffix are used only as candidates; full names bypass folder/prefix/suffix"},
        "reaction_name_rule_evidence": {
            "FindReactionIfExist_predicate": "0x1ee91b0: System.String.op_Equality compares stored initiating name to requested name",
            "GetResolvedReactionAnimationName": "0x22483d0: nonempty reactionAnimationNames list selects a random element; otherwise returns reactionAnimationName unchanged",
            "scope": "Candidate spelling/folder changes are reported as followups; original data is preserved"},
        "rig_sources_by_spine_type": rig_sources, "assets": asset_rows,
        "unresolved_declared_data_fields": unresolved, "declared_suffix_override_classes": suffix_overrides,
        "suffix_rules": {"posture_enum": {"None": 0, "Standing": 1, "Sitting": 2},
                         "posture_backing_field_offset_in_LevelToddler": "0x440",
                         "base_handler_suffix": "", "overrides": recovered_suffix_rules},
        "metadata": {"source_file_count": len(archive.used), "files": archive.used},
        "followups": {"reaction_name_absences": absent_reaction_names,
                      "initiating_name_absences": absent_initiating_names,
                      "assets_without_direct_serialized_component_reference": [
                          {"file": a["file"], "path_id": a["path_id"], "name": a["name"], "kind": a["kind"]}
                          for a in asset_rows if not a["users"]]},
        "limits": ["Presence of the generated base name in the correct rig does not prove runtime selection, priority, cancellation, or effects.",
                   "Handler-specific folder, SpineType, swappable data and call-time posture must still be reconciled before treating candidates as executed names; suffix formulas are separately recorded.",
                   "A missing base name can be explained by a runtime suffix/override and is not a defect verdict.",
                   "Rig filenames are explicit mappings to the extracted skeleton inventory; full scene-to-SkeletonDataAsset ownership remains separate evidence."],
    }
    report["verification"] = {"pointer_edges_independently_reconstructed": verify_pointer_edges(report),
                              "suffix_override_declarations_covered": len(recovered_suffix_rules) == len(suffix_overrides),
                              "unique_composite_asset_identities": len(data) == len(asset_rows)}
    args.output.write_text(json.dumps(report, ensure_ascii=False, indent=2) + "\n")
    print(json.dumps({"summary": summary, "metadata_files": len(archive.used), "cache_hits": archive.cache_hits,
                      "blocks_decoded": archive.blocks_decoded, "report": rel(args.output)}, ensure_ascii=False, indent=2))
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
