"""Summarize original Avatar World scene saves without copying raw user data.

The report keeps hashes, counts, payload schemas and aggregate transform ranges.
Scene object identifiers and serialized values are deliberately omitted.
"""
from __future__ import annotations

import argparse
from collections import Counter
import hashlib
import json
from pathlib import Path
from typing import Any

ROOT = Path(__file__).resolve().parents[1]
ROOT_KEYS = {"Prefabs", "SceneObjects", "NewAndSyncedSceneObjects", "BuildNumber"}


def sha256(path: Path) -> str:
    digest = hashlib.sha256()
    with path.open("rb") as source:
        for block in iter(lambda: source.read(1024 * 1024), b""):
            digest.update(block)
    return digest.hexdigest()


def source_path(path: Path) -> str:
    """Use a repository-relative path, or only the filename for external fixtures."""
    try:
        return str(path.relative_to(ROOT))
    except ValueError:
        return path.name


def json_type(value: Any) -> str:
    if value is None:
        return "null"
    if isinstance(value, bool):
        return "boolean"
    if isinstance(value, (int, float)):
        return "number"
    if isinstance(value, str):
        return "string"
    if isinstance(value, list):
        return "array"
    if isinstance(value, dict):
        return "object"
    return type(value).__name__


def summarize_payloads(scene_objects: dict[str, Any]) -> tuple[dict[str, Any], dict[str, Any]]:
    payload_counts: Counter[str] = Counter()
    payload_fields: dict[str, Counter[str]] = {}
    malformed: Counter[str] = Counter()
    positions: list[tuple[float, float]] = []
    parent_count = 0
    flipped_count = 0

    for value in scene_objects.values():
        if not isinstance(value, dict):
            malformed["scene_object_not_object"] += 1
            continue
        for payload_name, encoded in value.items():
            payload_counts[payload_name] += 1
            if not isinstance(encoded, str):
                malformed["payload_not_string"] += 1
                continue
            try:
                decoded = json.loads(encoded)
            except json.JSONDecodeError:
                malformed["payload_invalid_json"] += 1
                continue
            if not isinstance(decoded, dict):
                malformed["payload_json_not_object"] += 1
                continue
            fields = payload_fields.setdefault(payload_name, Counter())
            for field, field_value in decoded.items():
                fields[f"{field}:{json_type(field_value)}"] += 1
            if payload_name == "TransformPD":
                position = decoded.get("position")
                if isinstance(position, dict) and isinstance(position.get("x"), (int, float)) and isinstance(position.get("y"), (int, float)):
                    positions.append((float(position["x"]), float(position["y"])))
                parent_count += int(bool(decoded.get("parent")))
                flipped_count += int(decoded.get("isFlipped") is True)

    schemas = {
        name: {"count": payload_counts[name], "fields": dict(sorted(payload_fields.get(name, {}).items()))}
        for name in sorted(payload_counts)
    }
    transform = {
        "count": payload_counts.get("TransformPD", 0),
        "decoded_positions": len(positions),
        "with_parent": parent_count,
        "flipped": flipped_count,
        "position_range": None if not positions else {
            "x_min": min(x for x, _ in positions), "x_max": max(x for x, _ in positions),
            "y_min": min(y for _, y in positions), "y_max": max(y for _, y in positions),
        },
    }
    return {"schemas": schemas, "malformed": dict(sorted(malformed.items()))}, transform


def load_static_guids(report_path: Path) -> set[str]:
    report = json.loads(report_path.read_text(encoding="utf-8"))
    return {row["scene_guid"] for row in report.get("PDSceneObjects", []) if isinstance(row.get("scene_guid"), str)}


def summarize_save(path: Path, base: Path, static_guids: set[str] | None = None) -> dict[str, Any]:
    data = json.loads(path.read_text(encoding="utf-8"))
    if not isinstance(data, dict):
        raise ValueError(f"save root is not an object: {path}")
    prefabs = data.get("Prefabs", {})
    scene_objects = data.get("SceneObjects", {})
    synced = data.get("NewAndSyncedSceneObjects", [])
    if not isinstance(prefabs, dict) or not isinstance(scene_objects, dict) or not isinstance(synced, list):
        raise ValueError(f"save root collections have unexpected types: {path}")
    prefab_instances = sum(len(value) for value in prefabs.values() if isinstance(value, list))
    payloads, transform = summarize_payloads(scene_objects)
    result: dict[str, Any] = {
        "path": str(path.relative_to(base)),
        "bytes": path.stat().st_size,
        "sha256": sha256(path),
        "root_schema": {key: json_type(value) for key, value in sorted(data.items())},
        "unknown_root_keys": sorted(set(data) - ROOT_KEYS),
        "build_number": data.get("BuildNumber"),
        "counts": {
            "prefab_guids": len(prefabs), "prefab_instances": prefab_instances,
            "scene_objects": len(scene_objects), "new_and_synced_scene_objects": len(synced),
        },
        "payloads": payloads,
        "transform_pd": transform,
    }
    if static_guids is not None:
        runtime_guids = set(scene_objects)
        result["static_scene_comparison"] = {
            "static_scene_guids": len(static_guids),
            "runtime_scene_keys": len(runtime_guids),
            "intersection": len(static_guids & runtime_guids),
            "static_only": len(static_guids - runtime_guids),
            "runtime_only": len(runtime_guids - static_guids),
        }
    return result


def parse_scene_report(value: str) -> tuple[str, Path]:
    if "=" not in value:
        raise argparse.ArgumentTypeError("scene report must be SAVE_NAME=REPORT.json")
    name, raw_path = value.split("=", 1)
    if not name or not raw_path:
        raise argparse.ArgumentTypeError("scene report must be SAVE_NAME=REPORT.json")
    return name, Path(raw_path)


def build_report(save_root: Path, scene_reports: dict[str, Path]) -> dict[str, Any]:
    levels = save_root / "Levels"
    if not levels.is_dir():
        raise ValueError(f"Levels directory missing below {save_root}")
    static = {name: load_static_guids(path) for name, path in scene_reports.items()}
    saves = []
    skipped_non_json = []
    for path in sorted(levels.rglob("*")):
        if not path.is_file() or "GlobalPD" in path.parts or "Images" in path.parts:
            continue
        try:
            saves.append(summarize_save(path, save_root, static.get(path.name)))
        except (UnicodeDecodeError, json.JSONDecodeError, ValueError) as error:
            skipped_non_json.append({"path": str(path.relative_to(save_root)), "reason": type(error).__name__})
    return {
        "description": "sanitized structural summary of original runtime scene saves; raw saves are not copied",
        "source": {"save_file_count": len(saves), "raw_source_retained": False},
        "scene_reports": {name: {"path": source_path(path), "sha256": sha256(path)}
                          for name, path in sorted(scene_reports.items())},
        "saves": saves,
        "skipped_non_json": skipped_non_json,
        "limits": [
            "Hashes identify the local capture but the raw save is intentionally not versioned.",
            "Aggregate schemas and ranges prove serialization shape, not complete gameplay semantics.",
            "A static scene match compares keys only; runtime-spawned prefabs legitimately add keys.",
        ],
    }


def main() -> None:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("save_root", type=Path)
    parser.add_argument("--scene-report", action="append", type=parse_scene_report, default=[])
    parser.add_argument("--output", type=Path, default=ROOT / "out/recon/tasks/T030/runtime-save-summary.json")
    args = parser.parse_args()
    save_root = args.save_root.resolve()
    scene_reports = {name: path.resolve() for name, path in args.scene_report}
    report = build_report(save_root, scene_reports)
    args.output.parent.mkdir(parents=True, exist_ok=True)
    args.output.write_text(json.dumps(report, ensure_ascii=False, indent=2) + "\n", encoding="utf-8")
    print(json.dumps({"saves": len(report["saves"]), "output": str(args.output),
                      "raw_source_retained": False}, ensure_ascii=False, indent=2))


if __name__ == "__main__":
    main()
