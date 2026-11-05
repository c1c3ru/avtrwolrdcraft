#!/usr/bin/env python3
"""Exporta um interior do original de ponta a ponta: levelN do datapack -> Resources/Interiors/<chave>/.

Encadeia (cada passo e o script ja existente): unityfs_extract_entry (level + sharedassets que ele referencia),
scene_level_inspect, scene_level_export, export_world_map --level, build_interior_slice.
uso: tools/venv/bin/python tools/export_interior.py <levelN> <chave>
"""
import json, subprocess, sys
from pathlib import Path

ROOT = Path(__file__).resolve().parent.parent
PY = str(ROOT / "tools/venv/bin/python")
SCENES = ROOT / "out/scene-extract"
SKIP = {"globalgamemanagers.assets", "Library/unity default resources"}


def run(*args, check=True):
    r = subprocess.run([PY, *map(str, args)], cwd=ROOT, capture_output=True, text=True)
    if check and r.returncode:
        sys.exit(f"falhou: {' '.join(map(str, args))}\n{r.stderr[-600:]}{r.stdout[-300:]}")
    return r


def extract(entry):
    if not (SCENES / entry).exists():
        run("tools/unityfs_extract_entry.py", entry, check=False)


def main():
    level, key = sys.argv[1:3]
    extract(level)
    inspect = SCENES / f"{level}.inspect.json"
    run("tools/scene_level_inspect.py", level, "--output", inspect)
    externals = [e for e in json.loads(inspect.read_text())["external_files"] if e not in SKIP]
    for e in externals:
        if e != "resources.assets":
            extract(e); extract(e + ".resS")
    run("tools/scene_level_export.py", level, "--resource-dir", SCENES, "--report", inspect,
        "--output", SCENES / f"{level}.export.json", "--force")
    run("tools/export_world_map.py", "--level", level, "--externals", *externals, "--output", SCENES / f"{level}_world.json")
    out = run("tools/build_interior_slice.py", level, key).stdout.strip()
    print(f"{level} -> {key}: {out}")


if __name__ == "__main__":
    main()
