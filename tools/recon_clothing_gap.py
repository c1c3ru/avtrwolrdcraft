"""Audit clothing IDs available from the extracted SUT against the offline catalog."""
from __future__ import annotations

import argparse
import collections
import hashlib
import json
from pathlib import Path
import re
import struct

ROOT = Path(__file__).resolve().parents[1]
DEFAULT_PREFIXES = {
    "Shirt": ["shirt/shirt_formal", "shirt/shirt_casual", "shirt/shirt_jobs", "shirt/shirt_special"],
    "Bottom": ["bottom/bottom_special", "bottom/bottom_casual", "bottom/bottom_formal", "bottom/bottom_jobs"],
    "Shoes": ["legs/legs_shoes"],
    "Accessory": ["accessories/accessories_face/accessories_face_glasses", "accessories/accessories_body/accessories_body_neck"],
    "Mouth": ["mouth"], "Eyebrows": ["eyebrows"], "HairBack": ["hair/hair_back"],
}
CORE = ("Shirt", "Bottom", "Shoes", "Accessory")


def sha256(path: Path) -> str:
    h = hashlib.sha256()
    with path.open("rb") as stream:
        for block in iter(lambda: stream.read(1024 * 1024), b""):
            h.update(block)
    return h.hexdigest()


def png_size(path: Path) -> tuple[int, int]:
    with path.open("rb") as stream:
        header = stream.read(24)
    if len(header) != 24 or header[:8] != b"\x89PNG\r\n\x1a\n" or header[12:16] != b"IHDR":
        return (0, 0)
    return struct.unpack(">II", header[16:24])


def natural(value: str) -> list[object]:
    return [int(part) if part.isdigit() else part for part in re.split(r"(\d+)", value)]


def main() -> None:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--target", type=int, default=2174, help="user-specified target item count")
    parser.add_argument("--output", type=Path, default=ROOT / "out/recon/tasks/T033/clothing-gap-audit.json")
    parser.add_argument("--resources", type=Path, default=ROOT / "out/assets/avatar-resources.json")
    parser.add_argument("--textures", type=Path, default=ROOT / "out/assets/Texture2D")
    parser.add_argument("--atlas", type=Path, default=ROOT / "client/AvatarWorldClient/Assets/Resources/AvatarSpine/Avatar_Spine.atlas.txt")
    parser.add_argument("--manifest", type=Path, default=ROOT / "client/AvatarWorldClient/Assets/Resources/AvatarSpine/clothing-manifest.json")
    parser.add_argument("--catalog", type=Path, default=ROOT / "client/AvatarWorldClient/Assets/Scripts/Core/Avatar/AvatarCatalogData.cs")
    args = parser.parse_args()
    resources, textures, atlas, manifest_path, catalog_path = (p.resolve() for p in
                                                               (args.resources, args.textures, args.atlas, args.manifest, args.catalog))
    rows = json.loads(resources.read_text(encoding="utf-8"))
    atlas_lines = atlas.read_text(encoding="utf-8-sig").splitlines()
    pages: dict[str, tuple[int, int]] = {}
    for index, line in enumerate(atlas_lines[:-1]):
        match = re.fullmatch(r"size:\s*(\d+)\s*,\s*(\d+)\s*", atlas_lines[index + 1].strip())
        name = line.strip()
        if name.casefold().endswith(".png") and match:
            pages[name[:-4].casefold()] = tuple(int(value) for value in match.groups())
    texture_names: dict[str, list[Path]] = collections.defaultdict(list)
    for path in textures.iterdir():
        if path.is_file() and path.suffix.casefold() == ".png":
            texture_names[path.name.casefold()].append(path)
    groups: dict[tuple[str, str], dict[str, set[int]]] = collections.defaultdict(lambda: collections.defaultdict(set))
    for row in rows:
        parts = row["path"].casefold().split("/")
        if len(parts) < 6 or parts[:3] != ["sutsystem", "skins", "character"]:
            continue
        if parts[3] == "accessories":
            if len(parts) < 8:
                continue
            key, item, piece = "/".join(parts[3:6]), parts[6], parts[7]
        elif parts[3] in {"mouth", "eyebrows"}:
            key, item, piece = parts[3], parts[4], parts[5]
        else:
            if len(parts) < 7:
                continue
            key, item, piece = parts[3] + "/" + parts[4], parts[5], parts[6]
        groups[(key, item)][piece].add(row["path_id"])
    size_cache: dict[Path, tuple[int, int]] = {}

    def resolvable(pieces: dict[str, set[int]]) -> tuple[bool, list[str]]:
        unresolved = []
        for piece, path_ids in pieces.items():
            expected = pages.get(piece.casefold())
            candidates = [path for path_id in path_ids
                          for path in texture_names.get(f"{piece}_{path_id}.png".casefold(), [])]
            if len(candidates) != 1 or expected is None:
                unresolved.append(piece + ":missing_or_ambiguous")
                continue
            actual = size_cache.setdefault(candidates[0], png_size(candidates[0]))
            if actual != expected:
                unresolved.append(piece + ":dimension_mismatch")
        return not unresolved, unresolved

    categories: dict[str, dict] = {}
    resolved_by_key: dict[str, list[str]] = collections.defaultdict(list)
    for (key, item), pieces in groups.items():
        entry = categories.setdefault(key, {"source_item_folders": 0, "strictly_resolvable": 0,
                                             "strictly_resolvable_ids": [], "currently_selected_by_builder": 0,
                                             "builder_selected_resolvable": 0, "excluded_suffix_color": 0,
                                             "excluded_suffix_p": 0})
        entry["source_item_folders"] += 1
        good, _ = resolvable(pieces)
        entry["strictly_resolvable"] += int(good)
        if good:
            entry["strictly_resolvable_ids"].append(item)
            resolved_by_key[key].append(item)
        category = next((name for name, prefixes in DEFAULT_PREFIXES.items() if key in prefixes), None)
        skip = r"_p$" if category in {"Eyebrows", "HairBack"} else r"(_color|_p)$"
        selected = category is not None and not re.search(skip, item)
        entry["currently_selected_by_builder"] += int(selected)
        entry["builder_selected_resolvable"] += int(selected and good)
        entry["excluded_suffix_color"] += int(category is not None and item.endswith("_color") and not selected)
        entry["excluded_suffix_p"] += int(category is not None and item.endswith("_p") and not selected)
    for entry in categories.values():
        entry.pop("strictly_resolvable_ids")
    data = json.loads(manifest_path.read_text(encoding="utf-8"))
    manifest_ids = [item["id"] for item in data["items"]]
    catalog_source = catalog_path.read_text(encoding="utf-8")
    catalog_ids = {name: re.findall(r'^\s*"([^"]+)"', body, re.M)
                   for name, body in re.findall(r"public static readonly string\[\] (\w+) =\s*\{(.*?)\};", catalog_source, re.S)}
    catalog_counts = {name: len(values) for name, values in catalog_ids.items()}
    core_current = sum(catalog_counts.get(name, 0) for name in CORE)
    candidate_counts = {name: sum(categories.get(key, {}).get("builder_selected_resolvable", 0)
                                   for key in DEFAULT_PREFIXES[name]) for name in CORE}
    core_candidate = sum(candidate_counts.values())
    exact_quotas = {name: args.target * count // core_candidate for name, count in candidate_counts.items()}
    remainder_order = sorted(CORE, key=lambda name: (-(args.target * candidate_counts[name] % core_candidate), name))
    for name in remainder_order[:args.target - sum(exact_quotas.values())]:
        exact_quotas[name] += 1
    # Provisional, source-weighted preview: retain the current IDs first, then fill each category
    # using the same per-prefix balancing rule as avatar_catalog_build.py.
    proposed = {}
    for name in ("Shirt", "Bottom", "Shoes", "Accessory"):
        quota = exact_quotas[name]
        prefixes = DEFAULT_PREFIXES[name]
        selected_ids = list(dict.fromkeys(catalog_ids.get(name, [])))
        if len(selected_ids) > quota:
            selected_ids = selected_ids[:quota]
        per_prefix = max(1, (quota - len(selected_ids)) // len(prefixes))
        for prefix in prefixes:
            items = sorted(resolved_by_key.get(prefix, []), key=natural)
            taken = 0
            for item in items:
                if item in selected_ids:
                    continue
                if taken >= per_prefix:
                    break
                selected_ids.append(item)
                taken += 1
        for prefix in prefixes:
            if len(selected_ids) >= quota:
                break
            for item in sorted(resolved_by_key.get(prefix, []), key=natural):
                if item in selected_ids:
                    continue
                selected_ids.append(item)
                if len(selected_ids) >= quota:
                    break
        if len(selected_ids) != quota:
            raise SystemExit(f"cannot fill provisional quota for {name}: {len(selected_ids)}/{quota}")
        proposed[name] = selected_ids
    inputs = {name: {"path": str(path.relative_to(ROOT)), "sha256": sha256(path)} for name, path in
              [("resources", resources), ("atlas", atlas), ("manifest", manifest_path), ("catalog", catalog_path)]}
    texture_inventory = sorted(path.name.casefold() for path in textures.iterdir() if path.is_file() and path.suffix.casefold() == ".png")
    texture_names_hash = hashlib.sha256("\n".join(texture_inventory).encode()).hexdigest()
    result = {"target_count": args.target, "target_origin": "User-stated; no corresponding 2,174-ID source list is configured in this repository.",
              "inputs": inputs, "texture_directory": str(textures.relative_to(ROOT)),
              "texture_png_count": len(texture_inventory), "texture_filename_inventory_sha256": texture_names_hash,
              "resource_rows": len(rows), "atlas_pages": len(pages), "source_unique_sut_item_folders": sum(x["source_item_folders"] for x in categories.values()),
              "current_manifest_unique_ids": len(set(manifest_ids)), "current_catalog_ids_by_category": catalog_counts,
              "current_four_primary_categories_count": core_current,
              "current_four_primary_categories_target_delta": max(0, args.target - core_current),
              "resolvable_candidates_in_four_primary_categories": core_candidate,
              "resolvable_candidates_by_primary_category": candidate_counts,
              "provisional_exact_target_allocation": exact_quotas,
              "core_candidate_delta_to_target": core_candidate - args.target,
              "category_counts": categories,
              "limits": ["Strictly resolvable means every resource piece has exactly one extracted PNG, an atlas page, and matching dimensions; it does not validate clothing attachment compatibility or visual rendering.",
                         "Target category distribution is not inferred from the aggregate count.",
                         "The generator's current 100-item cap is an explicit selection limit, not a source-asset deficit."]}
    output = args.output.resolve()
    output.parent.mkdir(parents=True, exist_ok=True)
    candidate_path = output.parent / f"clothing-candidate-{args.target}.json"
    candidate = {"status": "provisional_review_only", "target_count": args.target,
                 "allocation_method": "proportional to strictly resolvable candidates; largest remainder; current IDs retained first",
                 "allocation": exact_quotas,
                 "current_count_by_category": {name: catalog_counts.get(name, 0) for name in CORE},
                 "added_count_by_category": {name: len(proposed[name]) - catalog_counts.get(name, 0) for name in CORE},
                 "items_by_category": proposed, "total": sum(map(len, proposed.values())),
                 "source_hashes": inputs,
                 "limitations": ["This allocation is an engineering proposal; category proportions were not recovered from original UI data.",
                                "IDs pass texture/template page/dimension resolution but have not been validated for runtime attachment compatibility or visual correctness.",
                                "Integration via avatar_catalog_build.py --selection does not prove original ordering, purchase gates, or runtime rendering."]}
    candidate_path.write_text(json.dumps(candidate, ensure_ascii=False, indent=2) + "\n", encoding="utf-8")
    result["provisional_candidate"] = str(candidate_path.relative_to(ROOT))
    output.write_text(json.dumps(result, ensure_ascii=False, indent=2) + "\n", encoding="utf-8")
    print(json.dumps({"target": args.target, "current_four_primary_categories": core_current,
                      "strictly_resolvable_core_candidates": core_candidate,
                      "all_source_items": result["source_unique_sut_item_folders"],
                      "manifest_ids": result["current_manifest_unique_ids"],
                      "catalog_ids_by_category": catalog_counts,
                      "report": str(output.relative_to(ROOT))}, ensure_ascii=False, indent=2))


if __name__ == "__main__":
    main()
