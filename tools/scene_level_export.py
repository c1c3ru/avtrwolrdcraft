#!/usr/bin/env python3
"""Export only SpriteRenderer images referenced by a level inspection report.

This reads the small serialized level, plus referenced sharedassets/resources files;
it does not reopen the 1.3 GB UnityFS datapack. Texture streaming data is read from
the adjacent .resS files. Outputs are local evidence, not Unity-ready scenes.
"""
import argparse
import json
import os
from pathlib import Path, PurePosixPath
import re
import sys

import UnityPy

ROOT = Path(__file__).resolve().parents[1]


def safe_name(value):
    value = re.sub(r"[^A-Za-z0-9_.-]+", "_", value).strip("_.")
    return value[:100] or "sprite"


def main(argv=None):
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("level", help="extracted level, e.g. level8")
    parser.add_argument("--scene-dir", type=Path, default=ROOT / "out/scene-extract")
    parser.add_argument("--resource-dir", type=Path, default=ROOT / "out/assets")
    parser.add_argument("--report", type=Path)
    parser.add_argument("--output", type=Path)
    parser.add_argument("--force", action="store_true", help="replace only files named by this report")
    args = parser.parse_args(argv)
    try:
        report_path = args.report or (args.scene_dir / (args.level + "-report.json"))
        report = json.loads(report_path.read_text(encoding="utf-8"))
        if report.get("level") != args.level or not isinstance(report.get("sprite_renderers"), list):
            raise ValueError("report does not match level or lacks SpriteRenderer inventory")
        scene_path = args.scene_dir / args.level
        if not scene_path.is_file():
            raise ValueError("extracted scene file missing: " + str(scene_path))

        needed = {(item["sprite"]["file"], item["sprite"]["path_id"])
                  for item in report["sprite_renderers"] if item["sprite"]["path_id"]}
        env = UnityPy.load(str(scene_path))
        source_paths = {}
        for file_name, _ in needed:
            if PurePosixPath(file_name).name != file_name:
                raise ValueError("unsafe external asset filename: " + file_name)
            if file_name == "resources.assets":
                source = args.resource_dir / file_name
            else:
                source = args.scene_dir / file_name
            if not source.is_file():
                raise ValueError("referenced serialized asset not extracted: " + str(source))
            source_paths[file_name] = source
        # UnityPy resolves .resS stream companions beside the level file. The large
        # resources.assets.resS is already present under out/assets; expose it by a
        # local symlink instead of copying 1.28 GB into the scene work directory.
        for file_name, source in source_paths.items():
            streamed_source = source.with_name(file_name + ".resS")
            streamed_local = args.scene_dir / (file_name + ".resS")
            if not streamed_source.is_file():
                continue
            if streamed_local.exists() or streamed_local.is_symlink():
                if streamed_local.resolve() != streamed_source.resolve():
                    raise ValueError("stream companion already exists with a different target: " + str(streamed_local))
            else:
                streamed_local.symlink_to(os.path.relpath(streamed_source, streamed_local.parent))
        for source in source_paths.values():
            env.load_file(str(source))

        objects = {}
        for obj in env.objects:
            key = (obj.assets_file.name, obj.path_id)
            if key in needed and obj.type.name == "Sprite":
                objects[key] = obj
        if len(objects) != len(needed):
            missing = sorted(needed - set(objects))
            raise ValueError(f"{len(missing)} referenced Sprite objects unresolved: {missing[:8]}")

        output = args.output or (args.scene_dir / (args.level + "-sprites"))
        output.mkdir(parents=True, exist_ok=True)
        written, seen_paths = [], set()
        by_key = {key: obj for key, obj in objects.items()}
        for index, item in enumerate(report["sprite_renderers"]):
            sprite_ref = item["sprite"]
            key = (sprite_ref["file"], sprite_ref["path_id"])
            if not key[1]:
                continue
            obj = by_key[key]
            data = obj.read(check_read=False)
            filename = f"{key[0].replace('.assets', '')}_{key[1]}_{safe_name(data.m_Name)}.png"
            destination = output / filename
            if destination in seen_paths:
                continue
            seen_paths.add(destination)
            if destination.exists() and not args.force:
                raise ValueError("output already exists; use --force to replace report-owned files")
            image = data.image
            if image is None or image.width == 0 or image.height == 0:
                raise ValueError("Sprite has no readable image: " + str(key))
            image.save(destination)
            item["exported_png"] = str(destination)
            written.append({"file": destination.name, "source": {"file": key[0], "path_id": key[1]},
                            "game_object": item["game_object"], "size": list(image.size)})

        report["exported_sprites"] = written
        report["sprite_export_validation"] = (
            "Referenced Sprite images decoded to PNG; this does not reconstruct a Unity scene or gameplay."
        )
        report_path.write_text(json.dumps(report, indent=2, ensure_ascii=False) + "\n", encoding="utf-8")
        print(f"{args.level}: {len(written)} SpriteRenderer PNGs exported -> {output}")
        print("updated report:", report_path)
        return 0
    except (OSError, ValueError, KeyError, TypeError, AttributeError) as error:
        print("scene_level_export:", error, file=sys.stderr)
        return 2


if __name__ == "__main__":
    sys.exit(main())
