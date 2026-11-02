"""Map packaged scenes and cached world records without claiming recovered method bodies.

Run: tools/venv/bin/python tools/map_world_navigation.py
Reads the small base UnityFS member and existing gzip dumps; never loads datapack.
"""
import argparse
from collections import Counter
import gzip
import hashlib
import json
from pathlib import Path
import re
import zipfile

ROOT = Path(__file__).resolve().parents[1]
CS = ROOT / "out/cpp2il/DiffableCs/Assembly-CSharp"
CLASSES = {
    "play": "Game.Home.HomePlayButton",
    "home": "Game.Home.HomeManager",
    "worlds": "PWC.World.WorldManager",
    "zones": "PWC.World.WorldZone",
    "buildings": "PWC.World.Buildings.WorldBuilding",
    "building_levels": "PWC.World.Buildings.WorldBuildingLevel",
    "scene_info": "PWC.Level.LevelSceneInfo",
}


def sha(path):
    digest = hashlib.sha256()
    with path.open("rb") as stream:
        for chunk in iter(lambda: stream.read(1024 * 1024), b""):
            digest.update(chunk)
    return digest.hexdigest()


def enum(path):
    text = path.read_text()
    values = {}
    for name, value in re.findall(r"^\s*(\w+)\s*=\s*(-?\d+)\s*,?\s*$", text, re.M):
        number = int(value)
        if number in values:
            raise ValueError(f"ambiguous enum alias {path}: {number}")
        values[number] = name
    if not values:
        raise ValueError(f"no explicit enum values: {path}")
    return values


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--output", type=Path, default=ROOT / "out/navigation-map")
    args = parser.parse_args()
    import UnityPy

    inputs = {}

    def track(path):
        inputs[str(path.relative_to(ROOT))] = {"bytes": path.stat().st_size, "sha256": sha(path)}
        return path

    base = track(ROOT / "assets/base.apk")
    member = "assets/bin/Data/data.unity3d"
    with zipfile.ZipFile(base) as archive:
        raw = archive.read(member)
    env = UnityPy.load(raw)
    settings = [obj.read_typetree() for obj in env.objects if obj.type.name == "BuildSettings"]
    if len(settings) != 1 or not settings[0].get("scenes"):
        raise ValueError("expected one nonempty packaged BuildSettings")
    level_types = enum(track(CS / "PWC/Game/LevelType.cs"))
    building_types = enum(track(CS / "PWC/Game/World/Buildings/WorldBuildingType.cs"))
    roots = json.loads(track(ROOT / "out/scene_roots.json").read_text())
    root_index = {}
    for row in roots:
        root_index.setdefault(row["file"], []).append(row)
    directory = json.loads(track(ROOT / "out/assets/avatar-bundle-directory.json").read_text())
    available = {item["path"] for item in directory}
    scenes = []
    scene_names = {}
    for index, path in enumerate(settings[0]["scenes"]):
        name = Path(path).stem
        serialized = f"level{index}"
        row = {"build_index": index, "scene_path": path, "scene_name": name,
               "serialized_candidate": serialized,
               "serialized_binding_status": "INFERRED_build_index_convention_not_independently_verified",
               "candidate_present_in_cached_bundle_directory": serialized in available,
               "cached_roots": root_index.get(serialized, []),
               "evidence_class": "STATIC_buildsettings_from_base_apk"}
        scenes.append(row)
        scene_names.setdefault(name, []).append(row)

    cached = {}
    for label, cls in CLASSES.items():
        path = track(ROOT / "out/mb" / (cls + ".jsonl.gz"))
        with gzip.open(path, "rt", encoding="utf-8") as stream:
            rows = [json.loads(line) for line in stream if line.strip()]
        seen = set()
        for row in rows:
            key = (row["_file"], row["_path_id"])
            if key in seen:
                raise ValueError(f"duplicate composite identity in {cls}: {key}")
            seen.add(key)
        cached[label] = rows

    def identity(row):
        return {"serialized_file": row["_file"], "path_id": row["_path_id"],
                "game_object_ref": row.get("m_GameObject"),
                "evidence_class": "STATIC_cached_dump",
                "source_reextraction_verified_this_run": False}

    def destination(value):
        name = level_types.get(value)
        matches = scene_names.get("Level_" + name, []) if name else []
        return {"level_type": value, "level_type_name": name,
                "scene_candidates": [{"scene_path": s["scene_path"], "build_index": s["build_index"]}
                                     for s in matches],
                "status": "STATIC_exact_name_join_not_runtime_edge" if len(matches) == 1 else "UNKNOWN_scene_binding"}

    world_keys = {(row["_file"], row["_path_id"]) for row in cached["zones"]}
    worlds = []
    for row in cached["worlds"]:
        zone_refs = []
        for ref in row.get("_zones", []):
            resolved = ref.get("m_FileID") == 0 and (row["_file"], ref.get("m_PathID")) in world_keys
            zone_refs.append({"reference": ref, "resolved_in_same_file": resolved})
        worlds.append({**identity(row), "bg_music": row.get("_BGMusicName"),
                       "ugc_bg_music": row.get("_ugcBGMusicName"), "zones": zone_refs})
    buildings = []
    for row in cached["buildings"]:
        buildings.append({**identity(row), "building_type": row.get("_buildingType"),
                          "building_type_name": building_types.get(row.get("_buildingType")),
                          "default_destination": destination(row.get("_defaultLevelType")),
                          "additional_destinations": [destination(v) for v in row.get("_moreValidLevelTypes", [])],
                          "is_free_serialized": row.get("_isFree"),
                          "runtime_access_status": "UNKNOWN_remote_config_and_runtime_not_evaluated",
                          "persistent_click_calls": row.get("OnClickAction", {}).get("m_PersistentCalls", {}).get("m_Calls", [])})
    entries = [{**identity(row), "destination": destination(row.get("_levelType"))}
               for row in cached["building_levels"]]
    # Resolve actual Transform ancestry only for scenes already extracted locally.
    # No nearest-zone or name-based membership is invented when not an ancestor.
    hierarchy_counts = Counter()
    for file in sorted({row["serialized_file"] for row in buildings}):
        scene_path = ROOT / "out/scene-extract" / file
        if not scene_path.is_file():
            continue
        track(scene_path)
        scene_env = UnityPy.load(str(scene_path))
        names, go_transforms, transform_go, parents = {}, {}, {}, {}
        behaviour_refs = {}
        for obj in scene_env.objects:
            if obj.type.name == "GameObject":
                names[obj.path_id] = obj.read().m_Name
            elif obj.type.name in ("Transform", "RectTransform"):
                data = obj.read(check_read=False)
                if data.m_GameObject.m_FileID != 0 or data.m_Father.m_FileID != 0:
                    raise ValueError(f"unexpected external Transform relationship in {file}")
                go_transforms[data.m_GameObject.m_PathID] = obj.path_id
                transform_go[obj.path_id] = data.m_GameObject.m_PathID
                parents[obj.path_id] = data.m_Father.m_PathID
            elif obj.type.name == "MonoBehaviour":
                data = obj.read(check_read=False)
                behaviour_refs[obj.path_id] = (data.m_GameObject.m_FileID, data.m_GameObject.m_PathID)
        zone_gos = {row["m_GameObject"]["m_PathID"]: row["_path_id"]
                    for row in cached["zones"] if row["_file"] == file and row["m_GameObject"]["m_FileID"] == 0}
        for row in buildings:
            if row["serialized_file"] != file:
                continue
            go = row["game_object_ref"]
            if behaviour_refs.get(row["path_id"]) != (go["m_FileID"], go["m_PathID"]):
                raise ValueError(f"cached MB/GameObject disagrees with serialized scene: {file}:{row['path_id']}")
            row["game_object_binding_revalidated"] = True
            if go["m_FileID"] != 0:
                row["hierarchy_status"] = "UNKNOWN_external_game_object"
                continue
            current = go_transforms.get(go["m_PathID"])
            visited, chain, zones = set(), [], []
            while current:
                if current in visited:
                    raise ValueError(f"Transform cycle in {file}: {current}")
                visited.add(current)
                obj_go = transform_go.get(current)
                chain.append({"transform_path_id": current, "game_object_path_id": obj_go,
                              "name": names.get(obj_go)})
                if obj_go in zone_gos:
                    zones.append({"serialized_file": file, "path_id": zone_gos[obj_go]})
                current = parents.get(current)
            row["game_object_name"] = names.get(go["m_PathID"])
            row["ancestor_chain"] = chain
            row["zone_ancestors"] = zones
            row["hierarchy_status"] = "STATIC_transform_chain" if chain else "UNKNOWN_missing_transform"
            hierarchy_counts["buildings_with_transform_chain" if chain else "buildings_missing_transform"] += 1
            if zones:
                hierarchy_counts["buildings_with_zone_ancestor"] += 1
    unresolved = [row for row in buildings if row["default_destination"]["status"].startswith("UNKNOWN")]
    unresolved_entries = [row for row in entries if row["destination"]["status"].startswith("UNKNOWN")]
    report = {
        "schema_version": 1,
        "scope": "packaged scenes and cached Home/world/building destinations; no runtime replay",
        "inputs": inputs,
        "base_member": {"path": member, "sha256": hashlib.sha256(raw).hexdigest()},
        "counts": {"packaged_scenes": len(scenes), "level_enum_values": len(level_types),
                   **{key: len(value) for key, value in cached.items()},
                   "buildings_without_exact_scene_join": len(unresolved),
                   "building_levels_without_exact_scene_join": len(unresolved_entries)},
        "hierarchy_counts": dict(hierarchy_counts),
        "home_play_records": cached["play"],
        "home_music_records": [{**identity(r), "theme": r.get("_themeSoundName")} for r in cached["home"]],
        "worlds": worlds, "buildings": buildings, "building_levels": entries,
        "scene_info_names": sorted({r.get("m_Name", "") for r in cached["scene_info"]}),
        "unknowns": [
            "HomePlayButton.LoadPlayScene body and actual chosen destination are not recovered by this tool",
            "Build index to serialized levelN is a convention-based candidate, not independently verified for every scene",
            "Cached MB, scene roots and directory are hashed but their complete provenance to current splits is not revalidated",
            "Zone ancestor checks are reported per building; absence of ancestor does not resolve spatial zone membership",
            "Serialized isFree does not establish runtime entitlement, remote flags or local economy",
            "Runtime listeners may exist even when persistent click calls are empty",
        ],
    }
    args.output.mkdir(parents=True, exist_ok=True)
    (args.output / "navigation.json").write_text(json.dumps(report, ensure_ascii=False, indent=2) + "\n")
    (args.output / "scenes.json").write_text(json.dumps(scenes, ensure_ascii=False, indent=2) + "\n")
    print(json.dumps({"counts": report["counts"], "world_files": [w["serialized_file"] for w in worlds],
                      "world_music": dict(Counter(w["bg_music"] for w in worlds)),
                      "unresolved_default_levels": [b["default_destination"] for b in unresolved],
                      "output": str(args.output)}, ensure_ascii=False, indent=2))


if __name__ == "__main__":
    main()
