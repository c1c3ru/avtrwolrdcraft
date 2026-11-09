#!/usr/bin/env python3
"""Exporta as artes dos carros do mapa (Resources do original: cars/car<N>/{down,up,sideways}) para
Resources/WorldCars/car<N>_<dir>.png + cars.json (pivot/ppu). So as 3 direcoes; os farois (*_light) ficam de fora.

uso: tools/venv/bin/python tools/export_car_sprites.py
"""
import collections, gzip, json, re
from pathlib import Path

import UnityPy

ROOT = Path(__file__).resolve().parent.parent
OUT = ROOT / "client/AvatarWorldClient/Assets/Resources/WorldCars"


def main():
    index = json.load(gzip.open(ROOT / "out/recon/tasks/T042/resource-container-index.json.gz", "rt"))
    want = collections.defaultdict(list)
    for r in index:
        m = re.match(r"cars/car(\d+)/(down|up|sideways)$", r["path"])
        if m and r["file"] == "resources.assets":
            want[(int(m.group(1)), m.group(2))].append(r["path_id"])
    env = UnityPy.load(str(ROOT / "out/scene-extract/resources.assets"))
    objs = {o.path_id: o for o in env.objects}
    OUT.mkdir(parents=True, exist_ok=True)
    rows = []
    for (n, direction), pids in sorted(want.items()):
        # cada recurso aparece com dois path_id (duplicata do container): fica o primeiro que for um Sprite
        for pid in pids:
            o = objs.get(pid)
            if o is None or o.type.name != "Sprite":
                continue
            d = o.read()
            name = f"car{n}_{direction}"
            d.image.save(OUT / f"{name}.png")
            t = o.read_typetree()
            rows.append({"car": n, "dir": direction, "file": name, "pivotX": t["m_Pivot"]["x"], "pivotY": t["m_Pivot"]["y"],
                         "ppu": t["m_PixelsToUnits"], "w": d.image.size[0], "h": d.image.size[1]})
            break
    (OUT / "cars.json").write_text(json.dumps({"sprites": rows}))
    print(f"{len(rows)} sprites de {len({r['car'] for r in rows})} carros -> {OUT}")


if __name__ == "__main__":
    main()
