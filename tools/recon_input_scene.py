"""Extract bounded pointer, collider and gesture evidence from one scene."""
from __future__ import annotations

import argparse
import hashlib
import json
from pathlib import Path
import sys

ROOT = Path(__file__).resolve().parents[1]
for package_path in (ROOT / "tools" / "venv" / "lib").glob("python*/site-packages"):
    sys.path.insert(0, str(package_path))
import UnityPy  # noqa: E402

FOCUS = {"EventSystem", "StandaloneInputModule", "MPStandaloneInputModule", "GraphicRaycaster",
         "CShape", "LevelItem", "LevelBouncyBall", "LevelBSBasketballItemHandler", "LevelBSHoop",
         "LevelBasketballScoreBoard", "LevelScrollCameraOnDrag", "LevelDropArea", "InteractableItem",
         "DragDropItemBase"}


def sha256(path: Path) -> str:
    digest = hashlib.sha256()
    with path.open("rb") as source:
        for block in iter(lambda: source.read(1024 * 1024), b""):
            digest.update(block)
    return digest.hexdigest()


def xy(value) -> list[float]:
    return [float(value.x), float(value.y)]


def main() -> None:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("scene", choices=["level4", "level8"])
    parser.add_argument("--scene-dir", type=Path, default=ROOT / "out/scene-extract")
    parser.add_argument("--inspect", type=Path)
    parser.add_argument("--output", type=Path)
    args = parser.parse_args()
    scene_path = (args.scene_dir / args.scene).resolve()
    inspect_path = (args.inspect or args.scene_dir / (args.scene + ".inspect.json")).resolve()
    output = (args.output or ROOT / "out/recon/tasks/T031" / (args.scene + "-input-scene.json")).resolve()
    if not scene_path.is_file() or not inspect_path.is_file():
        raise SystemExit("scene or inspector report missing")
    inspected = json.loads(inspect_path.read_text(encoding="utf-8"))
    env = UnityPy.load(str(scene_path))
    game_objects: dict[int, str] = {}
    transforms: dict[int, dict] = {}
    for obj in env.objects:
        if obj.type.name == "GameObject":
            game_objects[obj.path_id] = obj.read(check_read=False).m_Name
        elif obj.type.name in {"Transform", "RectTransform"}:
            data = obj.read(check_read=False)
            game_objects.setdefault(data.m_GameObject.m_PathID, "<unnamed>")
            transforms[data.m_GameObject.m_PathID] = {
                "local_position": xy(data.m_LocalPosition),
                "local_scale": [float(data.m_LocalScale.x), float(data.m_LocalScale.y), float(data.m_LocalScale.z)],
            }
    type_by_path = {obj.path_id: obj.type.name for obj in env.objects}
    component_types_by_go: dict[int, list[str]] = {}
    for obj in env.objects:
        if obj.type.name not in {"Transform", "RectTransform"}:
            continue
        tr = obj.read(check_read=False)
        go = next((g for g in env.objects if g.type.name == "GameObject" and g.path_id == tr.m_GameObject.m_PathID), None)
        if go is None:
            continue
        go_data = go.read(check_read=False)
        component_types_by_go[go.path_id] = [type_by_path.get(ref.component.m_PathID, "<unknown>")
                                              for ref in go_data.m_Component]
    focused = []
    for row in inspected["behaviours"]:
        if row["script"]["name"] not in FOCUS:
            continue
        go_id = row["game_object_path_id"]
        item = {"game_object": row["game_object"], "game_object_path_id": go_id,
                "mono_behaviour_path_id": row["mono_behaviour_path_id"],
                "type": (row["script"]["namespace"] + "." if row["script"]["namespace"] else "") + row["script"]["name"],
                "components_on_game_object": component_types_by_go.get(go_id, []),
                "transform": transforms.get(go_id)}
        focused.append(item)
    colliders = []
    for obj in env.objects:
        if "Collider2D" not in obj.type.name:
            continue
        data = obj.read(check_read=False)
        go_id = data.m_GameObject.m_PathID
        item = {"type": obj.type.name, "path_id": obj.path_id, "game_object": game_objects.get(go_id),
                "game_object_path_id": go_id, "enabled": bool(data.m_Enabled),
                "is_trigger": bool(getattr(data, "m_IsTrigger", False)),
                "offset": xy(getattr(data, "m_Offset", type("V", (), {"x": 0, "y": 0})())),
                "transform": transforms.get(go_id)}
        points = getattr(data, "m_Points", None)
        paths = getattr(points, "m_Paths", []) if points else []
        item["paths"] = [{"point_count": len(path),
                           "local_bounds": ([min(p.x for p in path), min(p.y for p in path),
                                             max(p.x for p in path), max(p.y for p in path)] if path else None)}
                          for path in paths]
        colliders.append(item)
    result = {
        "scene": args.scene,
        "inputs": {"scene": str(scene_path.relative_to(ROOT)), "scene_sha256": sha256(scene_path),
                   "inspector_report": str(inspect_path.relative_to(ROOT)), "inspector_sha256": sha256(inspect_path)},
        "scene_summary": {"object_count": inspected["object_count"],
                          "collider_type_counts": {name: count for name, count in inspected["object_type_counts"].items() if "Collider" in name or "Rigidbody" in name},
                          "focused_component_counts": {name: count for name, count in inspected["behaviour_counts"].items() if name.rsplit(".", 1)[-1] in FOCUS}},
        "focused_components": focused,
        "colliders": colliders,
        "limits": ["Collider geometry is recorded in local coordinates with the owning GameObject transform, not converted into world-space hitboxes.",
                   "Unity EventSystem raycast order and runtime callbacks are established from assembly windows separately; this scene serialization does not prove live pointer competition or cancellation."],
    }
    output.parent.mkdir(parents=True, exist_ok=True)
    output.write_text(json.dumps(result, ensure_ascii=False, indent=2) + "\n", encoding="utf-8")
    print(json.dumps({"scene": args.scene, "focused_components": len(focused), "colliders": len(colliders),
                      "report": str(output.relative_to(ROOT)), "scene_sha256": result["inputs"]["scene_sha256"]}, ensure_ascii=False, indent=2))


if __name__ == "__main__":
    main()
