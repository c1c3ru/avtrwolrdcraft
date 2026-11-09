#!/usr/bin/env python3
"""World positions of PWC.Level.LevelSpawn points (where the original spawns avatars) per scene.

Reads out/scene-extract/level<N> with UnityPy (not in the system python: use a venv) and
out/mb/PWC.Level.LevelSpawn.jsonl.gz. Writes tools/data/scene_spawns.json {levelN: [{x, y, go}]}.
Evidence only: which avatar spawns where (LevelAvatarOneTimeSpawner) is not recovered.

uso: export_scene_spawns.py [--scene-dir out/scene-extract] [--mb out/mb] [--only level5 ...]
"""
import argparse
import gzip
import json
import math
from pathlib import Path

import UnityPy

ROOT = Path(__file__).resolve().parents[1]


def z_angle(q):
    return math.atan2(2 * (q['w'] * q['z'] + q['x'] * q['y']), 1 - 2 * (q['y'] ** 2 + q['z'] ** 2))


def main(argv=None):
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument('--scene-dir', type=Path, default=Path('/home/deppi/avatarworld-re/out/scene-extract'))
    ap.add_argument('--mb', type=Path, default=ROOT / 'out/mb')
    ap.add_argument('--map', type=Path, default=ROOT / 'tools/data/level_scene_map.json')
    ap.add_argument('--output', type=Path, default=ROOT / 'tools/data/scene_spawns.json')
    ap.add_argument('--only', nargs='*')
    args = ap.parse_args(argv)

    spawns = {}
    for l in gzip.open(args.mb / 'PWC.Level.LevelSpawn.jsonl.gz', 'rt'):
        r = json.loads(l)
        spawns.setdefault(r['_file'], []).append(r['m_GameObject']['m_PathID'])
    out = {}
    for entry in json.loads(args.map.read_text()):
        level = f"level{entry['buildIndex']}"
        if args.only and level not in args.only:
            continue
        wanted = spawns.get(level, [])
        if not wanted:
            out[level] = []
            continue
        env = UnityPy.load(str(args.scene_dir / level))
        tr, go_tr, names = {}, {}, {}
        for o in env.objects:
            if o.assets_file.name != level:
                continue
            if o.type.name == 'Transform':
                d = o.read_typetree()
                tr[o.path_id] = d
                go_tr[d['m_GameObject']['m_PathID']] = o.path_id
            elif o.type.name == 'GameObject' and o.path_id in wanted:
                names[o.path_id] = o.read_typetree()['m_Name']

        def world(pid):
            d = tr[pid]
            p, s = d['m_LocalPosition'], d['m_LocalScale']
            parent = d['m_Father']['m_PathID']
            if not parent:
                return p['x'], p['y'], s['x'], s['y'], z_angle(d['m_LocalRotation'])
            px, py, psx, psy, pr = world(parent)
            c, sn = math.cos(pr), math.sin(pr)
            return (px + c * p['x'] * psx - sn * p['y'] * psy, py + sn * p['x'] * psx + c * p['y'] * psy,
                    psx * s['x'], psy * s['y'], pr + z_angle(d['m_LocalRotation']))

        out[level] = [{'go': names.get(g, ''), 'x': round(world(go_tr[g])[0], 4), 'y': round(world(go_tr[g])[1], 4)}
                      for g in wanted if g in go_tr]
        print(level, entry['name'], len(out[level]), 'spawns')
    args.output.write_text(json.dumps(out, indent=1))


if __name__ == '__main__':
    main()
