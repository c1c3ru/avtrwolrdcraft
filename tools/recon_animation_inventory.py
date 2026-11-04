#!/usr/bin/env python3
"""Build a hash-addressed inventory of Spine, Unity, and contextual animation resources."""
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
DEFAULT_SKEL_JSONL = ROOT / "out/recon/tasks/T032/skel-dump.jsonl"
DEFAULT_TEXT_ASSETS = ROOT / "out/assets/TextAsset"
DEFAULT_RESOURCES_ASSETS = ROOT / "out/scene-extract/resources.assets"
DEFAULT_BASE_APK = ROOT / "apk/base.apk"
DEFAULT_ASSEMBLY = ROOT / "out/cpp2il/DiffableCs/Assembly-CSharp"
DEFAULT_MB = ROOT / "out/mb"
DEFAULT_ANIMATOR_LITERALS = ROOT / "out/recon/tasks/T032/animator-literals.json"
DEFAULT_OUTPUT = ROOT / "out/recon/tasks/T035"


def sha256(path: Path) -> str:
    digest = hashlib.sha256()
    with path.open("rb") as stream:
        for block in iter(lambda: stream.read(1024 * 1024), b""):
            digest.update(block)
    return digest.hexdigest()


def filename_family(name: str) -> str:
    value = name.casefold()
    if "avatar_spine" in value or "avatar" in value or "character" in value:
        return "avatar_or_character"
    if any(token in value for token in ("dog", "cat", "horse", "bird", "fish", "hamster", "rabbit", "turtle", "lizard", "snake", "cow", "chicken", "pet")):
        return "animal_or_pet"
    if any(token in value for token in ("car", "vehicle", "jeep", "motorhome", "rv_")):
        return "vehicle"
    if value.startswith(("ui_", "button_", "menu_", "loading")):
        return "ui"
    return "other_spine_asset"


def component_rows(root: Path) -> list[dict]:
    classes = []
    pattern = re.compile(r"(?:(?:public|internal)\s+)?(?:(?:abstract|sealed|static)\s+)*class\s+(LevelCA\w+)\s*(?::\s*([^\n{]+))?")
    for path in sorted(root.rglob("*.cs")):
        source = path.read_text(encoding="utf-8", errors="replace")
        namespace_match = re.search(r"namespace\s+([^;{]+)", source)
        namespace = namespace_match.group(1).strip() if namespace_match else "<global>"
        for match in pattern.finditer(source):
            class_name, base_name = match.group(1), (match.group(2) or "").strip()
            classes.append({"class": class_name, "namespace": namespace, "base": base_name,
                            "source": str(path.relative_to(ROOT)), "source_sha256": sha256(path)})
    return classes


def contextual_instances(class_name: str, namespace: str, mb_dir: Path) -> dict:
    path = mb_dir / (namespace.replace("/", ".") + "." + class_name + ".jsonl.gz")
    if not path.exists():
        return {"inventory_file": None, "instances": 0, "scene_files": {}}
    scenes = Counter()
    count = 0
    with gzip.open(path, "rt", encoding="utf-8") as stream:
        for line in stream:
            if not line.strip():
                continue
            row = json.loads(line)
            count += 1
            scenes[str(row.get("_file", "unknown"))] += 1
    return {"inventory_file": str(path.relative_to(ROOT)), "instances": count,
            "scene_files": dict(sorted(scenes.items()))}


def unity_animations(resources_path: Path, apk_path: Path) -> dict:
    env = UnityPy.load(str(resources_path))
    objects = {obj.path_id: obj for obj in env.objects}

    def read(path_id: int):
        obj = objects.get(path_id)
        if obj is None:
            return None
        try:
            return obj.read()
        except Exception:
            return None

    gameobject_names = {}
    for obj in env.objects:
        if obj.type.name != "GameObject":
            continue
        data = read(obj.path_id)
        if data is not None:
            gameobject_names[obj.path_id] = data.m_Name

    clips = []
    for obj in env.objects:
        if obj.type.name != "AnimationClip":
            continue
        data = read(obj.path_id)
        if data is None:
            continue
        curves = list(data.m_FloatCurves) + list(data.m_RotationCurves) + list(data.m_PositionCurves) + list(data.m_ScaleCurves) + list(data.m_EulerCurves) + list(data.m_PPtrCurves)
        clip_length = max([event.time for event in data.m_Events] + [0.0])
        for curve in curves:
            times = []
            curve_data = getattr(curve, "curve", None)
            keyframes = getattr(curve_data, "m_Curve", None) or getattr(curve, "m_Curve", None) or []
            for key in keyframes:
                time = getattr(key, "time", getattr(key, "m_Time", None))
                if time is not None:
                    times.append(float(time))
            if times:
                clip_length = max(clip_length, max(times))
        clips.append({"path_id": obj.path_id, "name": data.m_Name, "sample_rate": data.m_SampleRate,
                      "approx_duration_seconds_from_keys_or_events": clip_length,
                      "curve_count": len(curves), "float_curve_count": len(data.m_FloatCurves),
                      "object_reference_curve_count": len(data.m_PPtrCurves),
                      "events": [{"name": e.functionName, "time": e.time, "int": e.intParameter,
                                  "float": e.floatParameter, "string": e.data} for e in data.m_Events]})

    controllers = []
    for obj in env.objects:
        if obj.type.name != "AnimatorController":
            continue
        data = read(obj.path_id)
        if data is None:
            continue
        controllers.append({"path_id": obj.path_id, "name": data.m_Name,
                            "clip_path_ids": [p.m_PathID for p in data.m_AnimationClips],
                            "clip_names": [read(p.m_PathID).m_Name for p in data.m_AnimationClips if read(p.m_PathID)],
                            "state_and_transition_names": [name for _hash, name in data.m_TOS if name],
                            "layer_count": len(data.m_Controller.m_LayerArray) if data.m_Controller else 0})

    animators = []
    legacy_animations = []
    for obj in env.objects:
        if obj.type.name not in ("Animator", "Animation"):
            continue
        data = read(obj.path_id)
        if data is None:
            continue
        go_id = data.m_GameObject.m_PathID
        go_name = gameobject_names.get(go_id, "")
        if obj.type.name == "Animator":
            pointer = data.m_Controller
            ctrl = read(pointer.m_PathID) if pointer and pointer.m_PathID else None
            animators.append({"path_id": obj.path_id, "game_object": go_name,
                              "controller_path_id": pointer.m_PathID if pointer else 0,
                              "controller": ctrl.m_Name if ctrl else None, "enabled": bool(data.m_Enabled)})
        else:
            clip_ptrs = list(data.m_Animations)
            legacy_animations.append({"path_id": obj.path_id, "game_object": go_name,
                                      "play_automatically": bool(data.m_PlayAutomatically),
                                      "clip_path_ids": [p.m_PathID for p in clip_ptrs],
                                      "clip_names": [read(p.m_PathID).m_Name for p in clip_ptrs if read(p.m_PathID)]})

    resource_names = defaultdict(list)
    with zipfile.ZipFile(apk_path) as archive:
        base_data = archive.read("assets/bin/Data/data.unity3d")
    base_env = UnityPy.load(base_data)
    resource_manager_count = 0
    for obj in base_env.objects:
        if obj.type.name != "ResourceManager":
            continue
        resource_manager_count += 1
        asset_file = obj.assets_file
        externals = [Path(e.path.replace("\\", "/")).name for e in asset_file.externals]
        for path, pointer in obj.read_typetree()["m_Container"]:
            file_id = pointer["m_FileID"]
            file_name = asset_file.name if file_id == 0 else externals[file_id - 1]
            if file_name == resources_path.name and pointer["m_PathID"] in {c["path_id"] for c in clips} | {c["path_id"] for c in controllers}:
                resource_names[pointer["m_PathID"]].append(path)
    return {"resource_manager_count": resource_manager_count,
            "clips": clips, "controllers": controllers, "animator_components": animators,
            "legacy_animation_components": legacy_animations,
            "resource_manager_paths_by_path_id": {str(pid): sorted(set(paths)) for pid, paths in resource_names.items()}}


def main() -> int:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--skeleton-jsonl", type=Path, default=DEFAULT_SKEL_JSONL)
    parser.add_argument("--text-assets", type=Path, default=DEFAULT_TEXT_ASSETS)
    parser.add_argument("--resources-assets", type=Path, default=DEFAULT_RESOURCES_ASSETS)
    parser.add_argument("--base-apk", type=Path, default=DEFAULT_BASE_APK)
    parser.add_argument("--assembly", type=Path, default=DEFAULT_ASSEMBLY)
    parser.add_argument("--mb-dir", type=Path, default=DEFAULT_MB)
    parser.add_argument("--animator-literals", type=Path, default=DEFAULT_ANIMATOR_LITERALS)
    parser.add_argument("--output-dir", type=Path, default=DEFAULT_OUTPUT)
    args = parser.parse_args()
    output_dir = args.output_dir
    output_dir.mkdir(parents=True, exist_ok=True)

    rows = [json.loads(line) for line in args.skeleton_jsonl.read_text(encoding="utf-8").splitlines() if line.strip()]
    source_files = {p.name: p for p in args.text_assets.glob("*.skel*")}
    dumped = {row["file"] for row in rows}
    missing_dump = sorted(set(source_files) - dumped)
    extra_dump = sorted(dumped - set(source_files))
    if missing_dump or extra_dump:
        raise SystemExit(f"skeleton dump/source mismatch: missing={missing_dump[:8]} extra={extra_dump[:8]}")
    animation_freq = Counter()
    animation_rows = []
    skeletons = []
    for row in rows:
        if row.get("error"):
            continue
        source = source_files[row["file"]]
        family = filename_family(row["file"])
        anim_names = []
        for animation in row.get("animations", []):
            name = animation["Name"]
            animation_freq[name] += 1
            anim_names.append(name)
            animation_rows.append({"skeleton_file": row["file"], "family_heuristic": family,
                                   "animation": name, "duration_seconds": animation["Duration"]})
        skeletons.append({"file": row["file"], "source_sha256": sha256(source), "bytes": source.stat().st_size,
                          "family_heuristic": family, "version": row.get("version"),
                          "animation_count": len(row.get("animations", [])), "animation_names": anim_names,
                          "animations": row.get("animations", []), "skin_count": len(row.get("skins", [])),
                          "skins": row.get("skins", []), "slot_count": len(row.get("slots", [])),
                          "slots": row.get("slots", []), "bone_count": row.get("bones", 0),
                          "event_names": row.get("events", [])})
    animation_csv = output_dir / "spine-animation-rows.csv"
    with animation_csv.open("w", encoding="utf-8", newline="") as stream:
        writer = csv.DictWriter(stream, fieldnames=["skeleton_file", "family_heuristic", "animation", "duration_seconds"],
                                lineterminator="\n")
        writer.writeheader()
        writer.writerows(animation_rows)

    contextual = component_rows(args.assembly)
    for component in contextual:
        component["instance_inventory"] = contextual_instances(component["class"], component["namespace"], args.mb_dir)
    contextual_base_counts = Counter(row["base"] or "(no explicit base)" for row in contextual)
    contextual_instance_counts = Counter()
    for row in contextual:
        contextual_instance_counts[row["class"]] = row["instance_inventory"]["instances"]

    literals = json.loads(args.animator_literals.read_text(encoding="utf-8")) if args.animator_literals.exists() else {}
    known_animation_names = set(animation_freq)
    animation_literals = []
    for method, refs in literals.items():
        for ref in refs:
            literal = ref.get("literal")
            if literal is not None:
                animation_literals.append({"method": method, "literal": literal,
                                           "exact_skeleton_animation_match": literal in known_animation_names})

    unity = unity_animations(args.resources_assets, args.base_apk)
    families = Counter(item["family_heuristic"] for item in skeletons)
    report = {
        "status": "static_animation_inventory_complete_for_extracted_skeletons_partial_for_runtime_semantics",
        "inputs": {
            "skeleton_dump": {"path": str(args.skeleton_jsonl.relative_to(ROOT)), "sha256": sha256(args.skeleton_jsonl)},
            "skeleton_source_files": {"directory": str(args.text_assets.relative_to(ROOT)),
                                      "count": len(source_files), "total_bytes": sum(p.stat().st_size for p in source_files.values()),
                                      "filename_inventory_sha256": hashlib.sha256("\n".join(sorted(source_files)).encode()).hexdigest()},
            "resources_assets": {"path": str(args.resources_assets.relative_to(ROOT)), "sha256": sha256(args.resources_assets)},
            "base_apk": {"path": str(args.base_apk.relative_to(ROOT)), "sha256": sha256(args.base_apk)},
            "assembly_root": str(args.assembly.relative_to(ROOT)),
            "animator_literals": {"path": str(args.animator_literals.relative_to(ROOT)), "sha256": sha256(args.animator_literals)},
        },
        "spine": {
            "skeleton_file_count": len(skeletons), "dump_errors": sum(bool(row.get("error")) for row in rows),
            "animation_rows": len(animation_rows), "unique_animation_names": len(animation_freq),
            "skeletons_by_filename_family_heuristic": dict(sorted(families.items())),
            "total_skins": sum(row["skin_count"] for row in skeletons),
            "total_slots": sum(row["slot_count"] for row in skeletons),
            "animation_name_frequency": dict(sorted(animation_freq.items())),
            "skeletons": skeletons,
            "animation_rows_csv": str(animation_csv.relative_to(ROOT)),
        },
        "unity_animation": unity,
        "avatar_animator_literals": {
            "literal_count": len(animation_literals),
            "exact_matches_to_spine_animation_names": sum(x["exact_skeleton_animation_match"] for x in animation_literals),
            "references": animation_literals,
        },
        "contextual_animation_handlers": {
            "class_count": len(contextual), "classes_with_serialized_instances": sum(bool(x["instance_inventory"]["instances"]) for x in contextual),
            "serialized_instance_count": sum(x["instance_inventory"]["instances"] for x in contextual),
            "classes_by_base": dict(sorted(contextual_base_counts.items())),
            "classes_by_serialized_instance_count": dict(sorted(contextual_instance_counts.items())),
            "classes": contextual,
        },
        "coverage_check": {"source_skeletons": len(source_files), "dumped_skeletons": len(dumped),
                           "missing_dump_files": missing_dump, "dump_files_without_source": extra_dump,
                           "all_extracted_skeletons_parsed": not missing_dump and not extra_dump and not any(r.get("error") for r in rows)},
        "limits": [
            "Filename-family classification is a heuristic; exact role should be assigned from asset references or scene usage.",
            "Unity AnimationClip duration is an approximation from the latest parsed curve/event key when present.",
            "Contextual handler class/instance inventories map code and scene presence, not exact animation transitions, trigger order, cancellation, or gameplay effect.",
            "Only extracted local bundle assets are covered; dynamically delivered remote content is outside this inventory.",
        ],
    }
    output = output_dir / "animation-inventory.json"
    output.write_text(json.dumps(report, ensure_ascii=False, indent=2) + "\n", encoding="utf-8")
    summary = {
        "status": report["status"], "spine_files": len(skeletons), "spine_animation_rows": len(animation_rows),
        "unique_spine_animation_names": len(animation_freq), "skeleton_families": dict(sorted(families.items())),
        "unity_clips": len(unity["clips"]), "unity_controllers": len(unity["controllers"]),
        "animator_components": len(unity["animator_components"]),
        "legacy_animation_components": len(unity["legacy_animation_components"]),
        "contextual_classes": len(contextual),
        "contextual_classes_with_instances": sum(bool(x["instance_inventory"]["instances"]) for x in contextual),
        "contextual_instances": sum(x["instance_inventory"]["instances"] for x in contextual),
        "exact_locomotion_literal_matches": report["avatar_animator_literals"]["exact_matches_to_spine_animation_names"],
        "report": str(output.relative_to(ROOT)), "csv": str(animation_csv.relative_to(ROOT)),
    }
    print(json.dumps(summary, ensure_ascii=False, indent=2))
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
