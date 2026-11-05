#!/usr/bin/env python3
"""Liga cada prédio do mapa (world.json) à cena de interior do original.

Cadeia: building.defaultLevel -> enum PWC.Game.LevelType (dump Cpp2IL) -> "Level_<nome>.unity" na lista de cenas
do BuildSettings (globalgamemanagers, dentro de base.apk/assets/bin/Data/data.unity3d) -> arquivo serializado
`level<indice>` do datapack. O indice da lista é o N de levelN (confere: MiniBasketball_L1 = indice 8 = level8).

uso: tools/venv/bin/python tools/recon_building_scenes.py   (grava out/recon/building_scenes.json)
"""
import collections, json, re, subprocess, sys
from pathlib import Path

ROOT = Path(__file__).resolve().parent.parent
DATA = ROOT / "out/ggm/assets/bin/Data/data.unity3d"
ENUM = ROOT / "out/cpp2il/DiffableCs/Assembly-CSharp/PWC/Game/LevelType.cs"
WORLD = ROOT / "client/AvatarWorldClient/Assets/Resources/WorldSlice/world.json"
ROOTS = ROOT / "out/scene_roots.json"
OUT = ROOT / "out/recon/building_scenes.json"


def build_settings_scenes():
    if not DATA.exists():
        DATA.parent.mkdir(parents=True, exist_ok=True)
        subprocess.run(["unzip", "-o", "-q", str(ROOT / "apk/base.apk"), "assets/bin/Data/data.unity3d", "-d", str(ROOT / "out/ggm")], check=True)
    import UnityPy
    for o in UnityPy.load(str(DATA)).objects:
        if o.type.name == "BuildSettings":
            return list(o.read().scenes)
    sys.exit("BuildSettings ausente")


def main():
    scenes = build_settings_scenes()
    by_name = {Path(p).stem: i for i, p in enumerate(scenes)}
    enum = {int(v): n for n, v in re.findall(r"^\s*(\w+) = (\d+),", ENUM.read_text(), re.M)}
    roots = collections.Counter(r["file"] for r in json.loads(ROOTS.read_text()))
    rows = []
    for b in json.loads(WORLD.read_text())["buildings"]:
        lv = b.get("defaultLevel", 0)
        name = enum.get(lv)
        idx = by_name.get("Level_" + name) if name else None
        rows.append({
            "building": b["name"], "defaultLevel": lv, "levelType": name,
            "scene": scenes[idx] if idx is not None else None,
            "file": f"level{idx}" if idx is not None else None,
            "rootObjects": roots.get(f"level{idx}") if idx is not None else None,
            "bounds": [b["x0"], b["y0"], b["x1"], b["y1"]],
        })
    OUT.parent.mkdir(parents=True, exist_ok=True)
    OUT.write_text(json.dumps({"sceneCount": len(scenes), "buildings": rows}, indent=1, ensure_ascii=False))
    ok = [r for r in rows if r["file"]]
    print(f"{len(scenes)} cenas no BuildSettings; {len(ok)}/{len(rows)} prédios resolvidos para um levelN")
    for r in sorted(ok, key=lambda r: r["rootObjects"] or 0)[:12]:
        print(f'  {r["building"]:32} {r["levelType"]:28} {r["file"]:9} raízes={r["rootObjects"]}')
    for r in rows:
        if not r["file"]:
            print("  sem cena:", r["building"], r["defaultLevel"], r["levelType"])


if __name__ == "__main__":
    main()
