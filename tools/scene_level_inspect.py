#!/usr/bin/env python3
"""Summarize one extracted Unity serialized level and its real scene components.

Pairs with unityfs_extract_entry.py; it inspects the small scene file and base-data
bundle without loading the 1.3 GB datapack as one UnityPy environment.
"""
import argparse
from collections import Counter
import json
from pathlib import Path
import sys
import traceback

import UnityPy

ROOT = Path(__file__).resolve().parents[1]


def main(argv=None):
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("level", help="serialized scene name, e.g. level8")
    parser.add_argument("--scene-dir", type=Path, default=ROOT / "out/scene-extract")
    parser.add_argument("--base-data", type=Path, default=ROOT / "out/scene-extract/base/globalgamemanagers.assets")
    parser.add_argument("--output", type=Path)
    parser.add_argument("--debug", action="store_true", help="show traceback for parser errors")
    args = parser.parse_args(argv)
    try:
        scene_path = args.scene_dir / args.level
        if not scene_path.is_file() or not args.base_data.is_file():
            raise ValueError("extracted level or base-data bundle missing")
        scene = UnityPy.load(str(scene_path))
        base = UnityPy.load(str(args.base_data))
        scene_file = next((file for file in scene.files.values() if file.name == args.level), None)
        if scene_file is None:
            raise ValueError("UnityPy did not expose the selected level file")

        scripts = {}
        for obj in base.objects:
            if obj.type.name != "MonoScript":
                continue
            data = obj.read()
            scripts[obj.path_id] = {
                "name": data.m_ClassName,
                "namespace": data.m_Namespace,
                "assembly": data.m_AssemblyName,
            }

        objects = {obj.path_id: obj for obj in scene.objects}
        names = {}
        transforms = {}
        for obj in scene.objects:
            if obj.type.name == "GameObject":
                names[obj.path_id] = obj.read().m_Name
            elif obj.type.name in ("Transform", "RectTransform"):
                data = obj.read(check_read=False)
                transforms[data.m_GameObject.m_PathID] = {
                    "transform_path_id": obj.path_id,
                    "parent_transform_path_id": data.m_Father.m_PathID,
                    "local_position": {"x": data.m_LocalPosition.x, "y": data.m_LocalPosition.y,
                                        "z": data.m_LocalPosition.z},
                    "local_scale": {"x": data.m_LocalScale.x, "y": data.m_LocalScale.y,
                                    "z": data.m_LocalScale.z},
                    "local_rotation": {"x": data.m_LocalRotation.x, "y": data.m_LocalRotation.y,
                                        "z": data.m_LocalRotation.z, "w": data.m_LocalRotation.w},
                }

        types = Counter(obj.type.name for obj in scene.objects)
        sprite_renderers = []
        behaviour_rows = []
        behaviour_types = Counter()
        unresolved_scripts = Counter()
        for obj in scene.objects:
            if obj.type.name == "SpriteRenderer":
                data = obj.read(check_read=False)
                go_id = data.m_GameObject.m_PathID
                sprite = data.m_Sprite
                sprite_file_id = getattr(sprite, "m_FileID", 0) if sprite else 0
                sprite_path_id = getattr(sprite, "m_PathID", 0) if sprite else 0
                externals = [Path(ref.path.replace("\\", "/")).name for ref in scene_file.externals]
                file_name = args.level if sprite_file_id == 0 else (
                    externals[sprite_file_id - 1] if 0 < sprite_file_id <= len(externals) else "<invalid-file-id>"
                )
                sprite_renderers.append({
                    "game_object": names.get(go_id, "<missing GameObject>"),
                    "game_object_path_id": go_id,
                    "transform": transforms.get(go_id),
                    "sprite": {"file": file_name, "path_id": sprite_path_id},
                    "enabled": data.m_Enabled,
                    "sorting_layer_id": data.m_SortingLayerID,
                    "sorting_order": data.m_SortingOrder,
                    "color": {"r": data.m_Color.r, "g": data.m_Color.g,
                              "b": data.m_Color.b, "a": data.m_Color.a},
                })
            elif obj.type.name == "MonoBehaviour":
                data = obj.read(check_read=False)
                go_id = data.m_GameObject.m_PathID
                script_id = data.m_Script.m_PathID
                script = scripts.get(script_id)
                if script is None:
                    unresolved_scripts[str(script_id)] += 1
                    script = {"name": "<unresolved>", "namespace": "", "assembly": ""}
                qualified = (script["namespace"] + "." if script["namespace"] else "") + script["name"]
                behaviour_types[qualified] += 1
                behaviour_rows.append({"game_object": names.get(go_id, "<missing GameObject>"),
                                       "game_object_path_id": go_id,
                                       "mono_behaviour_path_id": obj.path_id,
                                       "script": script})

        roots = []
        for obj in scene.objects:
            if obj.type.name not in ("Transform", "RectTransform"):
                continue
            data = obj.read()
            if data.m_Father.m_PathID == 0:
                go_id = data.m_GameObject.m_PathID
                roots.append({"game_object": names.get(go_id, "<missing GameObject>"),
                              "game_object_path_id": go_id, "transform_path_id": obj.path_id})

        report = {
            "level": args.level,
            "scene_bytes": scene_path.stat().st_size,
            "object_count": len(scene.objects),
            "object_type_counts": dict(types),
            "external_files": [ref.path for ref in scene_file.externals],
            "roots": roots,
            "sprite_renderer_count": len(sprite_renderers),
            "sprite_renderers": sprite_renderers,
            "behaviour_counts": dict(behaviour_types),
            "behaviours": behaviour_rows,
            "unresolved_script_ids": dict(unresolved_scripts),
        }
        output = args.output or (args.scene_dir / (args.level + "-report.json"))
        output.parent.mkdir(parents=True, exist_ok=True)
        output.write_text(json.dumps(report, indent=2, ensure_ascii=False) + "\n", encoding="utf-8")
        print(f"{args.level}: {len(scene.objects)} objects, {len(sprite_renderers)} SpriteRenderers, "
              f"{len(behaviour_types)} distinct gameplay scripts")
        print("external files:", ", ".join(Path(x).name for x in report["external_files"]))
        print("top scripts:", sorted(behaviour_types.items(), key=lambda item: (-item[1], item[0]))[:20])
        print("report:", output)
        return 0
    except (OSError, ValueError, KeyError, AttributeError, IndexError) as error:
        print("scene_level_inspect:", error, file=sys.stderr)
        if args.debug:
            traceback.print_exc()
        return 2


if __name__ == "__main__":
    sys.exit(main())
