#!/usr/bin/env python3
"""Export every scene a World-map building opens as a static "scene slice" for the Unity client.

Input : out/scene-extract/level<N>_world.json (+ level<N>.export.json/<sprite>.png) from export_world_map.py
        and tools/data/level_scene_map.json (LevelType -> Level_<name> -> build index, from
        tools/build_level_scene_map.py).
Output: <res>/Scenes/<LevelTypeName>/scene.json + sprites/*.png, and <res>/Scenes/index.json.
Layout/evidence only (SpriteRenderers). Draw order is rebuilt from the exporter's sortPath.
Skipped on purpose: night variants, cloud/train placeholders (no sprite), Spine, characters, scripts.

uso: export_scene_slices.py [--scene-dir out/scene-extract] [--res client/.../Assets/Resources] [--only NAME ...]
"""
import argparse
import json
import shutil
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]


def sort_key(r):
    return ([tuple(p) for p in r['sortPath']], r['go_id'])


def main(argv=None):
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument('--scene-dir', type=Path, default=Path('/home/deppi/avatarworld-re/out/scene-extract'))
    ap.add_argument('--res', type=Path, default=ROOT / 'client/AvatarWorldClient/Assets/Resources')
    ap.add_argument('--map', type=Path, default=ROOT / 'tools/data/level_scene_map.json')
    ap.add_argument('--only', nargs='*')
    args = ap.parse_args(argv)

    out_root = args.res / 'Scenes'
    out_root.mkdir(parents=True, exist_ok=True)
    index = []
    total_sprites = 0
    for entry in json.loads(args.map.read_text()):
        name = entry['name']
        if args.only and name not in args.only:
            continue
        n = f"level{entry['buildIndex']}"
        data = json.loads((args.scene_dir / f'{n}_world.json').read_text())
        rows = []
        for r in data['renderers']:
            if r.get('cloud') or r.get('cloudRain') or r.get('train'):
                continue
            if 'night' in r['go'].lower() or 'night' in r['sprite'].lower():
                continue
            rows.append(r)
        # Spine (animations.spines) entra na mesma ordenacao dos sprites; Avatar_Spine (personagens) fica de fora:
        # sem a aparencia/skins aplicadas ele nao e um elemento de cenario.
        spines = [sp for sp in (data.get('animations') or {}).get('spines', []) if sp['skeleton'] != 'Avatar_Spine']
        merged = [(sort_key(r), 0, r) for r in rows] + [(([tuple(p) for p in sp['sortPath']], 1 << 40), 1, sp) for sp in spines]
        merged.sort(key=lambda t: (t[0], t[1]))
        spine_rows = []
        for rank, (_, kind, sp) in enumerate(merged):
            if kind:
                spine_rows.append({'skeleton': sp['skeleton'], 'x': round(sp['x'], 4), 'y': round(sp['y'], 4),
                                   'sx': sp['sx'], 'sy': sp['sy'], 'animation': sp['animation'], 'loop': sp['loop'],
                                   'followCamera': sp.get('followCamera', False), 'offsetX': round(sp.get('offsetX', sp['x']), 4),
                                   'offsetY': round(sp.get('offsetY', sp['y']), 4), 'rank': rank})
            else:
                sp['_rank'] = rank
        rows = [r for _, kind, r in merged if not kind]
        sdir = out_root / name / 'sprites'
        sdir.mkdir(parents=True, exist_ok=True)
        rend, used = [], set()
        minx = miny = 1e9
        maxx = maxy = -1e9
        for r in rows:
            rank = r['_rank']
            sprite = r['sprite'][:-4] if r['sprite'].endswith('.png') else r['sprite']
            src = args.scene_dir / f'{n}.export.json' / f'{sprite}.png'
            if not src.exists():
                continue
            if sprite not in used:
                used.add(sprite)
                dst = sdir / f'{sprite}.png'
                if not dst.exists():
                    shutil.copyfile(src, dst)
            ppu = r['ppu'] or 100.0
            w, h = r['size'][0] / ppu * abs(r['sx']), r['size'][1] / ppu * abs(r['sy'])
            left, bottom = r['x'] - r['pivot'][0] * w, r['y'] - r['pivot'][1] * h
            minx, maxx = min(minx, left), max(maxx, left + w)
            miny, maxy = min(miny, bottom), max(maxy, bottom + h)
            row = {'sprite': sprite, 'go': r['go'], 'x': round(r['x'], 4), 'y': round(r['y'], 4),
                   'sx': round(r['sx'], 4), 'sy': round(r['sy'], 4), 'rot': round(r['rot'], 5),
                   'pivotX': r['pivot'][0], 'pivotY': r['pivot'][1], 'ppu': ppu, 'rank': rank,
                   'color': [round(c, 4) for c in r['color']], 'flipX': r['flipX'], 'flipY': r['flipY'],
                   'weathers': r['weathers']}
            if r['drawMode'] != 0:  # sliced/tiled: estica ate drawSize (aproximacao)
                row['drawW'], row['drawH'] = r['drawSize']
            rend.append(row)
        scene = {'name': name, 'levelType': entry['levelType'], 'orthoSize': data['camera'].get('orthoSize', 5.12),
                 'minX': minx, 'maxX': maxx, 'minY': miny, 'maxY': maxy, 'renderers': rend, 'spines': spine_rows}
        (out_root / name / 'scene.json').write_text(json.dumps(scene, separators=(',', ':')))
        total_sprites += len(used)
        index.append({'levelType': entry['levelType'], 'name': name, 'renderers': len(rend), 'sprites': len(used)})
        print(f"{name}: {len(rend)} renderers, {len(used)} sprites, x[{minx:.1f},{maxx:.1f}] y[{miny:.1f},{maxy:.1f}]")
    (out_root / 'index.json').write_text(json.dumps({'scenes': index}, indent=1))
    print(f'{len(index)} scenes, {total_sprites} sprites -> {out_root}')


if __name__ == '__main__':
    main()
