#!/usr/bin/env python3
"""Recover AvatarMaker flag-to-skin tables from Unity serialized data and cross-reference the selected catalog."""
from __future__ import annotations

import argparse
import hashlib
import json
import re
import struct
from collections import defaultdict
from pathlib import Path

import UnityPy

ROOT = Path(__file__).resolve().parents[1]
DEFAULT_ASSETS = ROOT / "out/scene-extract/resources.assets"
DEFAULT_GLOBAL = ROOT / "out/scene-extract/base/globalgamemanagers.assets"
DEFAULT_CANDIDATE = ROOT / "out/recon/tasks/T033/clothing-candidate-2174.json"
DEFAULT_FLAGS = ROOT / "out/cpp2il/DiffableCs/Assembly-CSharp/PWC/Inventory/InventoryFlagType.cs"
DEFAULT_SPINES = ROOT / "out/cpp2il/DiffableCs/Assembly-CSharp/PWC/AvatarSpine/SpineType.cs"
DEFAULT_OUTPUT = ROOT / "out/recon/tasks/T033/clothing-gates-crosswalk.json"
DATASETS = {"ExpansionPacksBuildData": "expansion", "InventorySkinsBuildData": "premium"}
FAMILY_PREFIXES = (
    "Accessories", "Legs_Shoes", "Legs", "Shirt", "Bottom", "Jacket", "OnepieceNH",
    "Onepiece", "Hair", "Hat", "Face", "Eyes", "Mouth", "Eyebrows", "Glasses",
    "Sticker", "Wrap", "Bib", "Back", "Seat", "Car", "Hood", "Hub", "Roof",
    "Diaper", "Bag", "Neck", "Body", "Shoes", "Carrier",
)


def sha256(path: Path) -> str:
    h = hashlib.sha256()
    with path.open("rb") as f:
        for block in iter(lambda: f.read(1024 * 1024), b""):
            h.update(block)
    return h.hexdigest()


def enum_map(path: Path) -> dict[int, str]:
    text = path.read_text(encoding="utf-8")
    body = text[text.index("{") + 1 : text.rindex("}")]
    values: dict[int, str] = {}
    current = -1
    for raw in body.splitlines():
        line = raw.split("//", 1)[0].strip().rstrip(",")
        if not line:
            continue
        m = re.fullmatch(r"([A-Za-z_][A-Za-z0-9_]*)\s*(?:=\s*(-?\d+))?", line)
        if not m:
            continue
        current = int(m.group(2)) if m.group(2) is not None else current + 1
        values[current] = m.group(1)
    return values


def read_i32(data: bytes, offset: int) -> tuple[int, int]:
    if offset + 4 > len(data):
        raise ValueError(f"truncated int32 at {offset}")
    return struct.unpack_from("<i", data, offset)[0], offset + 4


def read_string(data: bytes, offset: int) -> tuple[str, int]:
    size, offset = read_i32(data, offset)
    if size < 0 or offset + size > len(data):
        raise ValueError(f"invalid string size {size} at {offset - 4}")
    value = data[offset : offset + size].decode("utf-8")
    offset = (offset + size + 3) & ~3
    return value, offset


def parse_table(raw: bytes) -> tuple[str, list[dict]]:
    # MonoBehaviour header (40 bytes), serialized m_Name string, then field list at offset 56.
    offset = 56
    count, offset = read_i32(raw, offset)
    if count < 0 or count > 10000:
        raise ValueError(f"invalid pack count {count}")
    rows = []
    for _ in range(count):
        flag, offset = read_i32(raw, offset)
        spine_count, offset = read_i32(raw, offset)
        if spine_count < 0 or spine_count > 100:
            raise ValueError(f"invalid spine count {spine_count}")
        for _ in range(spine_count):
            spine_type, offset = read_i32(raw, offset)
            skin_count, offset = read_i32(raw, offset)
            if skin_count < 0 or skin_count > 10000:
                raise ValueError(f"invalid skin count {skin_count}")
            for _ in range(skin_count):
                skin, offset = read_string(raw, offset)
                rows.append({"flag_value": flag, "spine_value": spine_type, "skin_name": skin})
    if offset != len(raw):
        raise ValueError(f"parser stopped at {offset}; object length {len(raw)}")
    return "", rows


def family(skin: str) -> str:
    return next((p for p in FAMILY_PREFIXES if skin == p or skin.startswith(p + "_")), "Unknown")


def canonical(skin: str) -> str:
    value = skin.casefold()
    return re.sub(r"_(?:color|p)$", "", value)


def main() -> int:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--assets", type=Path, default=DEFAULT_ASSETS)
    parser.add_argument("--global", dest="global_assets", type=Path, default=DEFAULT_GLOBAL)
    parser.add_argument("--candidate", type=Path, default=DEFAULT_CANDIDATE)
    parser.add_argument("--flags", type=Path, default=DEFAULT_FLAGS)
    parser.add_argument("--spines", type=Path, default=DEFAULT_SPINES)
    parser.add_argument("--output", type=Path, default=DEFAULT_OUTPUT)
    args = parser.parse_args()

    flag_names = enum_map(args.flags)
    spine_names = enum_map(args.spines)
    candidate = json.loads(args.candidate.read_text(encoding="utf-8"))
    catalog: dict[str, set[str]] = {
        category: {item.casefold() for item in items}
        for category, items in candidate["items_by_category"].items()
    }
    normalized_to_candidates: dict[str, list[tuple[str, str]]] = defaultdict(list)
    for category, items in catalog.items():
        for item in sorted(items):
            normalized_to_candidates[canonical(item)].append((category, item))

    env = UnityPy.load(str(args.assets), str(args.global_assets))
    script_id = None
    for obj in env.objects:
        if obj.type.name != "MonoScript":
            continue
        try:
            script = obj.read()
        except Exception:
            continue
        if script.m_ClassName == "InventorySkinsBuildData" and script.m_Namespace == "PWC.Inventory":
            script_id = obj.path_id
            break
    if script_id is None:
        raise SystemExit("InventorySkinsBuildData MonoScript not found in globalgamemanagers")

    data_objects = {}
    for obj in env.objects:
        if obj.type.name != "MonoBehaviour":
            continue
        try:
            mono = obj.read(check_read=False)
        except Exception:
            continue
        if mono.m_Script.m_FileID == 1 and mono.m_Script.m_PathID == script_id and mono.m_Name in DATASETS:
            data_objects[mono.m_Name] = obj
    if set(data_objects) != set(DATASETS):
        raise SystemExit(f"expected both build-data objects; found {sorted(data_objects)}")

    rows = []
    table_summary = {}
    for object_name, obj in data_objects.items():
        raw = obj.get_raw_data()
        _, parsed = parse_table(raw)
        dataset = DATASETS[object_name]
        table_summary[dataset] = {
            "unity_object_path_id": obj.path_id,
            "pack_count": struct.unpack_from("<i", raw, 56)[0],
            "skin_row_count": len(parsed),
            "serialized_bytes": len(raw),
        }
        for row in parsed:
            flag_name = flag_names.get(row["flag_value"], f"UnknownFlag_{row['flag_value']}")
            spine_name = spine_names.get(row["spine_value"], f"UnknownSpine_{row['spine_value']}")
            name = row["skin_name"]
            matches = normalized_to_candidates.get(canonical(name), [])
            rows.append({
                "dataset": dataset,
                "flag_value": row["flag_value"],
                "flag": flag_name,
                "spine_value": row["spine_value"],
                "spine": spine_name,
                "skin_name": name,
                "skin_family": family(name),
                "catalog_matches": [{"category": c, "id": i} for c, i in matches],
            })

    locked_by_id: dict[tuple[str, str], set[str]] = defaultdict(set)
    for row in rows:
        for match in row["catalog_matches"]:
            locked_by_id[(match["category"], match["id"])].add(row["flag"])
    counts = {}
    for category, items in catalog.items():
        states = defaultdict(int)
        for item in items:
            flags = locked_by_id.get((category, item), set())
            states["listed_in_gate_map" if flags else "not_listed_in_recovered_maps"] += 1
        counts[category] = dict(sorted(states.items()))
    map_hit_counts = defaultdict(int)
    for row in rows:
        if row["catalog_matches"]:
            map_hit_counts[row["dataset"]] += len(row["catalog_matches"])
    report = {
        "status": "static_crosswalk_recovered_with_unclassified_items",
        "method": "Parsed the two serialized InventorySkinsBuildData MonoBehaviours from resources.assets; nested List fields are read from Unity raw serialization and verified to consume each full object byte range.",
        "inputs": {
            "resources_assets": {"path": str(args.assets.relative_to(ROOT)), "sha256": sha256(args.assets)},
            "globalgamemanagers_assets": {"path": str(args.global_assets.relative_to(ROOT)), "sha256": sha256(args.global_assets)},
            "candidate": {"path": str(args.candidate.relative_to(ROOT)), "sha256": sha256(args.candidate)},
            "flag_enum": {"path": str(args.flags.relative_to(ROOT)), "sha256": sha256(args.flags)},
            "spine_enum": {"path": str(args.spines.relative_to(ROOT)), "sha256": sha256(args.spines)},
        },
        "table_objects": table_summary,
        "catalog_item_count": sum(map(len, catalog.values())),
        "catalog_gate_status_counts": counts,
        "catalog_exact_crosswalk_hits_by_dataset": dict(sorted(map_hit_counts.items())),
        "interpretation": {
            "listed_in_gate_map": "This exact catalog item is explicitly associated with a recovered inventory flag.",
            "not_listed_in_recovered_maps": "No exact item-name match in the recovered tables; this is not proof the item is free.",
            "coverage": "The table gives pack flags and skin names. UI category integer mapping is not serialized in these two objects; skin_family is derived from the skin-name prefix.",
        },
        "rows": rows,
    }
    args.output.parent.mkdir(parents=True, exist_ok=True)
    args.output.write_text(json.dumps(report, ensure_ascii=False, indent=2) + "\n", encoding="utf-8")
    print(json.dumps({k: report[k] for k in (
        "status", "table_objects", "catalog_item_count", "catalog_gate_status_counts", "catalog_exact_crosswalk_hits_by_dataset"
    )}, ensure_ascii=False, indent=2))
    print(f"full_report={args.output.relative_to(ROOT)}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
