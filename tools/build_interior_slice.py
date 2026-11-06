#!/usr/bin/env python3
"""Converte o export de uma cena de interior (export_world_map.py --level levelN) em Resources/Interiors/<chave>/.

Gera <chave>.json no formato WorldMapData (renderers com rank ja ordenado) e copia so os PNGs usados.
Visual apenas: nenhum script do original (itens arrastaveis, luz, som) e reproduzido.

uso: build_interior_slice.py <levelN> <chave> [--scene-dir out/scene-extract]
"""
import argparse, json, shutil
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]


def copy_spine(name, dest):
    """Esqueleto/atlas/textura do Spine (ja extraidos em out/assets) -> Resources/MapSpine/<nome>/."""
    src = ROOT / "out/assets"
    skel = next((src / "TextAsset").glob(f"{name}.skel_*.txt"), None)
    atlas = next((src / "TextAsset").glob(f"{name}.atlas_*.txt"), None)
    tex = next((src / "Texture2D").glob(f"{name}_*.png"), None)
    if name.startswith("Avatar") or not (skel and atlas and tex):
        return False  # avatares (Avatar_Spine, multi-pagina) sao do runtime do avatar; sem arquivos, a camada e omitida
    out = dest / name
    out.mkdir(parents=True, exist_ok=True)
    shutil.copyfile(skel, out / f"{name}.skel.bytes")
    shutil.copyfile(atlas, out / f"{name}.atlas.txt")
    shutil.copyfile(tex, out / f"{name}.png")
    return True


def main():
    ap = argparse.ArgumentParser()
    ap.add_argument("level"); ap.add_argument("key")
    ap.add_argument("--scene-dir", type=Path, default=ROOT / "out/scene-extract")
    ap.add_argument("--dest", type=Path, default=ROOT / "client/AvatarWorldClient/Assets/Resources/Interiors")
    a = ap.parse_args()
    world = json.loads((a.scene_dir / f"{a.level}_world.json").read_text())
    # PNGs: <level>.export.json/ (scene_level_export.py, nuvens) e <level>_export/ (export antigo do level4)
    png_dirs = [a.scene_dir / f"{a.level}.export.json", a.scene_dir / f"{a.level}_export"]
    out = a.dest / a.key
    (out / "sprites").mkdir(parents=True, exist_ok=True)

    sort_key = lambda r: [list(p) for p in r["sortPath"]]
    spines_in = (world.get("animations") or {}).get("spines", [])
    # Sprites e esqueletos Spine dividem a mesma ordem de desenho (rank denso sobre o sortPath).
    cars_in = (world.get("animations") or {}).get("cars", [])
    ordered = sorted([("s", r) for r in world["renderers"]] + [("p", sp) for sp in spines_in] + [("c", c) for c in cars_in],
                     key=lambda kv: sort_key(kv[1]))
    ranks = {id(r): i for i, (_, r) in enumerate(ordered)}
    rows = [r for kind, r in ordered if kind == "s"]
    renderers, skipped, left, right = [], 0, 1e9, -1e9
    SUPPORTED_WEATHER = {0, 1, 6}  # Clear, Rain, Snow (Halloween=8 e Snow_Xmas=7 nao entram: ver WorldWeather no cliente)
    rows = [r for r in rows if not r["weathers"] or SUPPORTED_WEATHER & set(r["weathers"])]
    for r in rows:
        rank = ranks[id(r)]
        name = r["sprite"].removesuffix(".png")
        src = next((d / f"{name}.png" for d in png_dirs if (d / f"{name}.png").exists()), None)
        if src is None:
            skipped += 1
            continue
        shutil.copyfile(src, out / "sprites" / f"{name}.png")
        w = r["size"][0] / r["ppu"] * abs(r["sx"])
        if not r.get("cloud"):  # nuvens derivam ate o ponto final e nao definem a area da cena
            left = min(left, r["x"] - r["pivot"][0] * w); right = max(right, r["x"] + (1 - r["pivot"][0]) * w)
        renderers.append({"sprite": name, "go": r["go"], "x": r["x"], "y": r["y"], "z": r["z"], "sx": r["sx"], "sy": r["sy"],
                          "rot": r["rot"], "rank": rank, "color": r["color"], "flipX": r["flipX"], "flipY": r["flipY"],
                          "pivotX": r["pivot"][0], "pivotY": r["pivot"][1], "ppu": r["ppu"], "weathers": r["weathers"],
                          "cloud": r.get("cloud", 0), "cloudRain": r.get("cloudRain", False), "train": r.get("train", 0)})
    buildings = [{"name": b["name"], "x0": b["bounds"][0], "y0": b["bounds"][1], "x1": b["bounds"][2], "y1": b["bounds"][3],
                  "defaultLevel": b["defaultLevel"], "buildingType": b["buildingType"]}
                 for b in world.get("buildings", []) if b.get("bounds")]
    spines = []
    for sp in spines_in:
        if not copy_spine(sp["skeleton"], a.dest.parent / "MapSpine"):
            continue
        spines.append({"skeleton": sp["skeleton"], "x": sp["x"], "y": sp["y"], "sx": sp["sx"], "sy": sp["sy"], "rank": ranks[id(sp)],
                       "loop": sp["loop"], "animation": sp["animation"], "followCamera": sp["followCamera"],
                       "offsetX": sp["offsetX"], "offsetY": sp["offsetY"]})
    data = {"camera": {"orthoSize": 5.12, "startX": round((left + right) / 2, 2), "startY": 0.12,
                       "minX": round(left, 2), "maxX": round(right, 2)},
            "renderers": renderers, "buildings": buildings, "animations": {**{"clouds": None, "trains": []}, **{k: v for k, v in (world.get("animations") or {}).items() if k not in ("spines", "cars")}, "spines": spines,
                       "cars": [{**{k: v for k, v in c.items() if k != "sortPath"}, "rank": ranks[id(c)]} for c in cars_in]}}
    (out / f"{a.key}.json").write_text(json.dumps(data))
    print(f"{len(renderers)} renderers, {len(buildings)} prédios ({skipped} sem png), x {left:.1f}..{right:.1f} -> {out}")


if __name__ == "__main__":
    main()
