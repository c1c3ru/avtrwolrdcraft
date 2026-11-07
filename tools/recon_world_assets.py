#!/usr/bin/env python3
"""Index world scenes, vehicles, avatar accessories, and pets from Unity ResourceManager paths."""
from __future__ import annotations

import argparse
import csv
import gzip
import hashlib
import json
import re
import zipfile
from collections import Counter, defaultdict
from pathlib import Path

import UnityPy

ROOT = Path(__file__).resolve().parents[1]
DEFAULT_APK = ROOT / "apk/base.apk"
DEFAULT_TEXT = ROOT / "out/assets/TextAsset"
DEFAULT_STORE = ROOT / "store_catalog.json"
DEFAULT_WORLD = ROOT / "out/scene-extract/level4_world.json"
DEFAULT_AVATAR_GATES = ROOT / "out/recon/tasks/T033/clothing-gates-crosswalk.json"
DEFAULT_FLAGS = ROOT / "out/cpp2il/DiffableCs/Assembly-CSharp/PWC/Inventory/InventoryFlagType.cs"
DEFAULT_OUT = ROOT / "out/recon/tasks/T042"
PET_DATA_NAME = "PetMaker_BreedsData_109863.txt"


def sha256(path: Path) -> str:
    digest = hashlib.sha256()
    with path.open("rb") as stream:
        for block in iter(lambda: stream.read(1024 * 1024), b""):
            digest.update(block)
    return digest.hexdigest()


def enum_names(path: Path) -> set[str]:
    body = path.read_text(encoding="utf-8")
    body = body[body.index("{") + 1 : body.rindex("}")]
    names = set()
    for raw in body.splitlines():
        line = raw.split("//", 1)[0].strip().rstrip(",")
        match = re.match(r"([A-Za-z_][A-Za-z0-9_]*)", line)
        if match:
            names.add(match.group(1))
    return names


def canonical(value: str) -> str:
    return re.sub(r"_(?:color|p)$", "", value.casefold())


def main() -> int:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--apk", type=Path, default=DEFAULT_APK)
    parser.add_argument("--text-assets", type=Path, default=DEFAULT_TEXT)
    parser.add_argument("--store-catalog", type=Path, default=DEFAULT_STORE)
    parser.add_argument("--world-map", type=Path, default=DEFAULT_WORLD)
    parser.add_argument("--avatar-gates", type=Path, default=DEFAULT_AVATAR_GATES)
    parser.add_argument("--flags", type=Path, default=DEFAULT_FLAGS)
    parser.add_argument("--output-dir", type=Path, default=DEFAULT_OUT)
    args = parser.parse_args()
    out = args.output_dir
    out.mkdir(parents=True, exist_ok=True)

    with zipfile.ZipFile(args.apk) as apk:
        data = apk.read("assets/bin/Data/data.unity3d")
    env = UnityPy.load(data)
    containers = []
    managers = 0
    for obj in env.objects:
        if obj.type.name != "ResourceManager":
            continue
        managers += 1
        asset_file = obj.assets_file
        externals = [Path(e.path.replace("\\", "/")).name for e in asset_file.externals]
        for path, pointer in obj.read_typetree()["m_Container"]:
            file_id = pointer["m_FileID"]
            if file_id < 0 or file_id > len(externals):
                raise ValueError(f"bad external file id {file_id} for {path}")
            file_name = asset_file.name if file_id == 0 else externals[file_id - 1]
            containers.append({"path": path, "file": file_name, "path_id": pointer["m_PathID"]})
    if managers != 1 or not containers:
        raise ValueError(f"unexpected ResourceManager inventory: managers={managers}, rows={len(containers)}")

    # Keep the lossless path-ID mapping compact; the detailed JSON summary below is human-readable.
    index_path = out / "resource-container-index.json.gz"
    with gzip.open(index_path, "wt", encoding="utf-8", newline="\n", compresslevel=9) as stream:
        json.dump(containers, stream, ensure_ascii=False, separators=(",", ":"))

    sut_items: dict[tuple[str, str, str], set[str]] = defaultdict(set)
    sut_refs: Counter[tuple[str, str, str]] = Counter()
    sut_paths = set()
    for row in containers:
        parts = row["path"].lower().split("/")
        if len(parts) < 5 or parts[:2] != ["sutsystem", "skins"]:
            continue
        spine = parts[2]
        item = parts[-2] if len(parts) > 4 else parts[-1]
        taxonomy = "/".join(parts[3:-2]) or "(root)"
        key = (spine, taxonomy, item)
        sut_items[key].add(row["path"])
        sut_refs[key] += 1
        sut_paths.add(row["path"])

    sut_by_spine = defaultdict(lambda: {"item_ids": set(), "taxonomies": Counter(), "resource_paths": set(), "references": 0})
    sut_categories = defaultdict(lambda: {"item_ids": set(), "resource_paths": set(), "references": 0})
    for (spine, taxonomy, item), paths in sut_items.items():
        group = sut_by_spine[spine]
        group["item_ids"].add(item)
        group["taxonomies"][taxonomy] += 1
        group["resource_paths"].update(paths)
        group["references"] += sut_refs[(spine, taxonomy, item)]
        category = (spine, taxonomy)
        sut_categories[category]["item_ids"].add(item)
        sut_categories[category]["resource_paths"].update(paths)
        sut_categories[category]["references"] += sut_refs[(spine, taxonomy, item)]

    sut_summary = {
        "reference_rows": sum(v["references"] for v in sut_by_spine.values()),
        "unique_resource_paths": len(sut_paths),
        "by_spine_type": {
            spine: {
                "unique_item_folders": len(v["item_ids"]),
                "resource_paths": len(v["resource_paths"]),
                "container_references": v["references"],
                "taxonomy_counts": dict(sorted(v["taxonomies"].items())),
                "item_ids": sorted(v["item_ids"]),
            }
            for spine, v in sorted(sut_by_spine.items())
        },
        "by_category": {
            f"{spine}/{taxonomy}": {
                "unique_item_folders": len(v["item_ids"]),
                "resource_paths": len(v["resource_paths"]),
                "container_references": v["references"],
                "item_ids": sorted(v["item_ids"]),
            }
            for (spine, taxonomy), v in sorted(sut_categories.items())
        },
    }

    scene_counts = defaultdict(lambda: {"paths": set(), "references": 0, "sample_paths": []})
    for row in containers:
        parts = row["path"].lower().split("/")
        if len(parts) < 4 or parts[:2] != ["level", "sceneitems"]:
            continue
        scene = parts[2]
        group = scene_counts[scene]
        group["paths"].add(row["path"])
        group["references"] += 1
    scenes = [
        {"scene_key": name, "unique_resource_paths": len(v["paths"]), "container_references": v["references"]}
        for name, v in sorted(scene_counts.items())
    ]
    world_buildings = []
    map_access = Counter()
    if args.world_map.exists():
        world_buildings = json.loads(args.world_map.read_text(encoding="utf-8")).get("buildings", [])
        for building in world_buildings:
            key = (str(building.get("isFree", "unknown")), str(bool(building.get("underConstruction", False))))
            map_access[key] += 1

    car_groups = defaultdict(lambda: {"items": set(), "paths": set(), "references": 0})
    car_root_counts = Counter()
    for row in containers:
        parts = row["path"].lower().split("/")
        if parts[0] == "carsmaker":
            sub = parts[1] if len(parts) > 1 else "(root)"
            car_root_counts[sub] += 1
            if len(parts) >= 4:
                category = parts[2]
                item = parts[3]
                group = car_groups[category]
                group["items"].add(item)
                group["paths"].add(row["path"])
                group["references"] += 1
        elif parts[0] == "cars":
            car_root_counts["cars"] += 1
    vehicles = {
        "resource_reference_rows_by_root": dict(sorted(car_root_counts.items())),
        "carmaker_categories": {
            category: {"unique_item_ids": len(v["items"]), "unique_paths": len(v["paths"]),
                       "container_references": v["references"], "item_ids": sorted(v["items"])}
            for category, v in sorted(car_groups.items())
        },
    }
    flag_names = enum_names(args.flags)
    car_part_pack_candidates = defaultdict(set)
    for category, group in car_groups.items():
        for item in group["items"]:
            match = re.search(r"_p(\d+)$", item, re.I)
            if match:
                car_part_pack_candidates[match.group(1)].add(item)
    vehicles["pack_suffix_candidates"] = {
        pack_num: {
            "unique_part_ids": len(items),
            "item_ids": sorted(items),
            "enum_flags_with_same_pack_number": sorted(
                name for name in flag_names if re.search(rf"p{pack_num}(?:$|[^0-9])", name, re.I)
            ),
            "evidence": "part-name suffix and enum pack number agree; entitlement association is a candidate, not proof of runtime gate",
        }
        for pack_num, items in sorted(car_part_pack_candidates.items(), key=lambda pair: int(pair[0]))
    }

    store_data = json.loads(args.store_catalog.read_text(encoding="utf-8"))
    store_rows = store_data.get("items", [])
    wanted_store_categories = {"map", "vehicle", "car", "pet", "animal", "dog", "cat", "horse", "accessories"}
    store_summary = defaultdict(lambda: {"rows": 0, "unique_names": set(), "files": set()})
    for row in store_rows:
        category = str(row.get("category", "")).lower()
        if category in wanted_store_categories:
            group = store_summary[category]
            group["rows"] += 1
            group["unique_names"].add(row.get("name", ""))
            group["files"].add(row.get("file", ""))
    store_summary_out = {
        k: {"rows": v["rows"], "unique_names": len(v["unique_names"]), "files": sorted(v["files"])}
        for k, v in sorted(store_summary.items())
    }

    pet_path = args.text_assets / PET_DATA_NAME
    pet_rows = list(csv.DictReader(pet_path.open(encoding="utf-8", newline="")))
    pets_by_spine = defaultdict(list)
    for row in pet_rows:
        pets_by_spine[row["SpineType"]].append(row)
    pet_summary = {
        "breed_preset_data": {
            spine: {
                "rows": len(rows),
                "unique_breeds": sorted({r["Breed_Name"] for r in rows}),
                "default_rows": sum(r["Is_Default"].casefold() == "yes" for r in rows),
                "nondefault_rows": sum(r["Is_Default"].casefold() != "yes" for r in rows),
                "presets": [{"name": r["Name"], "breed": r["Breed_Name"], "default": r["Is_Default"],
                             "prefab": r["Prefab"], "size": r["Size"], "body_color": r["Body_Color"],
                             "pattern": r["Pattern_Name"], "pattern_color": r["Pattern_Color"]} for r in rows],
            }
            for spine, rows in sorted(pets_by_spine.items())
        },
        "sut_item_counts": {spine: sut_by_spine[spine]["item_ids"] and len(sut_by_spine[spine]["item_ids"]) or 0
                            for spine in ("dog", "cat", "horse")},
    }
    pet_breed_flag_candidates = {}
    for spine, rows in sorted(pets_by_spine.items()):
        breed_map = {}
        for breed in sorted({row["Breed_Name"] for row in rows}):
            letter = breed.removeprefix("Breed_")
            flag_candidate = f"{spine}_{letter}"
            breed_rows = [row for row in rows if row["Breed_Name"] == breed]
            breed_map[breed] = {
                "enum_flag_candidate": flag_candidate if flag_candidate in flag_names else None,
                "preset_rows": len(breed_rows),
                "default_rows": sum(row["Is_Default"].casefold() == "yes" for row in breed_rows),
                "evidence": "lexical breed/flag match only; exact runtime entitlement path not recovered",
            }
        pet_breed_flag_candidates[spine] = breed_map
    pet_summary["breed_flag_candidates"] = pet_breed_flag_candidates

    gate_data = json.loads(args.avatar_gates.read_text(encoding="utf-8"))
    gated_items: dict[tuple[str, str, str], set[str]] = defaultdict(set)
    sut_gate_rows = []
    for gate in gate_data["rows"]:
        spine = gate["spine"].casefold()
        key_name = canonical(gate["skin_name"])
        for (sut_spine, taxonomy, item), _paths in sut_items.items():
            if sut_spine == spine and canonical(item) == key_name:
                gated_items[(sut_spine, taxonomy, item)].add(gate["flag"])
                sut_gate_rows.append({"spine": gate["spine"], "taxonomy": taxonomy, "item_id": item,
                                      "skin_name": gate["skin_name"], "flag": gate["flag"],
                                      "dataset": gate["dataset"]})
    gated_by_spine = Counter(spine for spine, _taxonomy, _item in gated_items)
    gated_by_category = Counter((spine, taxonomy) for spine, taxonomy, _item in gated_items)
    avatar_gate_crosswalk = {
        "source": str(args.avatar_gates.relative_to(ROOT)),
        "sha256": sha256(args.avatar_gates),
        "unique_sut_items_with_explicit_flags": len(gated_items),
        "item_counts_by_spine": dict(sorted(gated_by_spine.items())),
        "item_counts_by_category": {f"{spine}/{taxonomy}": count for (spine, taxonomy), count in sorted(gated_by_category.items())},
        "matches": sut_gate_rows,
    }

    text_asset_names = sorted(p.name for p in args.text_assets.glob("*.txt"))
    relevant_config_assets = [
        name for name in text_asset_names
        if re.search(r"(petmaker|carmaker|carbreed|carvehicle|vehicle.*pack|map.*pack|world.*map)", name, re.I)
    ]
    text_asset_map = {}
    for name in relevant_config_assets:
        path = args.text_assets / name
        text_asset_map[name] = {"bytes": path.stat().st_size, "sha256": sha256(path)}

    world_map = None
    if args.world_map.exists():
        wd = json.loads(args.world_map.read_text(encoding="utf-8"))
        world_map = {
            "source": str(args.world_map.relative_to(ROOT)),
            "sha256": sha256(args.world_map),
            "level": wd.get("level"),
            "renderers": len(wd.get("renderers", [])),
            "unique_sprite_names": len({x.get("sprite") for x in wd.get("renderers", []) if x.get("sprite")}),
            "objects": wd.get("object_count"),
            "building_records": len(wd.get("buildings", [])),
            "raw_isFree_and_under_construction_counts": {
                f"isFree={free}; underConstruction={construction}": count
                for (free, construction), count in sorted(map_access.items())
            },
            "buildings": world_buildings,
        }

    report = {
        "status": "static_resource_inventory_mapped_runtime_contracts_partial",
        "inputs": {
            "base_apk": {"path": str(args.apk.relative_to(ROOT)), "sha256": sha256(args.apk)},
            "resource_manager_rows": len(containers),
            "resource_manager_unique_paths": len({r["path"] for r in containers}),
            "store_catalog": {"path": str(args.store_catalog.relative_to(ROOT)), "sha256": sha256(args.store_catalog),
                              "rows": len(store_rows)},
            "petmaker_breeds_data": {"path": str(pet_path.relative_to(ROOT)), "sha256": sha256(pet_path)},
            "avatar_gate_crosswalk": {"path": str(args.avatar_gates.relative_to(ROOT)), "sha256": sha256(args.avatar_gates)},
            "inventory_flag_enum": {"path": str(args.flags.relative_to(ROOT)), "sha256": sha256(args.flags)},
        },
        "world_map": world_map,
        "maps": {
            "sceneitem_scene_count": len(scenes),
            "scenes": scenes,
            "verified_world_map": "The extracted World map has a separate visual/interaction report; scene path presence alone does not establish gameplay parity.",
        },
        "vehicles": vehicles,
        "accessories": {
            "character_sut_categories": {k: v for k, v in sut_summary["by_category"].items() if "/accessories/" in k},
            "store_catalog_inventory": store_summary_out.get("accessories", {"rows": 0, "unique_names": 0, "files": []}),
            "explicit_inventory_flag_matches": {
                k: v for k, v in avatar_gate_crosswalk["item_counts_by_category"].items()
                if k.startswith("character/accessories/")
            },
        },
        "pets": pet_summary,
        "avatar_inventory_flags_crosswalk": avatar_gate_crosswalk,
        "store_catalog_counts": store_summary_out,
        "related_text_asset_configs": text_asset_map,
        "sut": sut_summary,
        "limits": [
            "ResourceManager path presence and item naming prove bundled asset availability, not that the player owns or can access the item.",
            "The store_catalog is a scene-item catalog and does not encode a complete store entitlement or purchase map.",
            "PetMaker_BreedsData records presets/default markers; non-default does not itself reveal the exact entitlement flag.",
            "CarsMaker part resource names include pack suffixes, but suffix-to-entitlement mappings need direct UI/config or flag evidence.",
            "The 176 sceneitem groups are resource directories, not a complete verified playable-scene list; T042 requires per-scene contracts.",
        ],
        "full_resource_container_index_gzip": str(index_path.relative_to(ROOT)),
    }
    report_path = out / "world-vehicles-accessories-pets.json"
    report_path.write_text(json.dumps(report, ensure_ascii=False, indent=2) + "\n", encoding="utf-8")
    summary = {
        "status": report["status"],
        "resource_rows": len(containers),
        "sceneitem_scenes": len(scenes),
        "sut_by_spine": {k: {"item_folders": v["unique_item_folders"], "resources": v["resource_paths"]}
                         for k, v in sut_summary["by_spine_type"].items()},
        "carmaker": {k: v["unique_item_ids"] for k, v in vehicles["carmaker_categories"].items()},
        "pet_breed_rows": {k: v["rows"] for k, v in pet_summary["breed_preset_data"].items()},
        "report": str(report_path.relative_to(ROOT)),
        "path_index_gzip": {"path": str(index_path.relative_to(ROOT)), "bytes": index_path.stat().st_size},
    }
    print(json.dumps(summary, ensure_ascii=False, indent=2))
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
