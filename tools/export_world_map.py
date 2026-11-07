#!/usr/bin/env python3
"""Compose the original World map (serialized level4) into a flat renderer list.

Reads the extracted level file and its sprite-export report; resolves the Transform
hierarchy (2D: position, z rotation, scale), active flags, weather visibility and
WorldBuilding entry points. Evidence/layout only: no behaviour of the original scripts
is reproduced. Output: <out>/level4_world.json.

uso: export_world_map.py [--weather 0] [--scene-dir out/scene-extract] [--mb out/mb]
"""
import argparse
import collections
import glob
import gzip
import json
import math
from pathlib import Path

import UnityPy

ROOT = Path(__file__).resolve().parents[1]


def load_mb(mb_dir, cls, level):
    path = mb_dir / f'{cls}.jsonl.gz'
    if not path.exists():
        return []
    return [r for r in (json.loads(l) for l in gzip.open(path, 'rt')) if r['_file'] == level]


def z_angle(q):
    return math.atan2(2 * (q['w'] * q['z'] + q['x'] * q['y']), 1 - 2 * (q['y'] ** 2 + q['z'] ** 2))


def main(argv=None):
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--level', default='level4')
    parser.add_argument('--weather', type=int, default=0, help='WeatherType value (0 = Clear)')
    parser.add_argument('--scene-dir', type=Path, default=ROOT / 'out/scene-extract')
    parser.add_argument('--mb', type=Path, default=ROOT / 'out/mb')
    parser.add_argument('--report', type=Path)
    parser.add_argument('--externals', nargs='*', default=['sharedassets4.assets', 'sharedassets3.assets', 'resources.assets'],
                        help='arquivos serializados extras que o level referencia (padrao: os do level4)')
    parser.add_argument('--output', type=Path)
    args = parser.parse_args(argv)
    report = json.loads((args.report or args.scene_dir / f'{args.level}.inspect.json').read_text())
    exported = {(e['source']['file'], e['source']['path_id']): e for e in report['exported_sprites']}

    env = UnityPy.load(str(args.scene_dir / args.level))
    for name in args.externals:
        env.load_file(str(args.scene_dir / name))
    objs = {(o.assets_file.name, o.path_id): o for o in env.objects}
    level = args.level

    go_active, go_name, go_tr = {}, {}, {}
    go_parent = {}
    groups = {}  # GameObject path_id -> (sorting order, layer id) of its SortingGroup
    tr = {}
    for (f, pid), o in objs.items():
        if f != level:
            continue
        if o.type.name == 'GameObject':
            d = o.read_typetree()
            go_active[pid] = bool(d['m_IsActive']); go_name[pid] = d['m_Name']
        elif o.type.name in ('Transform', 'RectTransform'):
            d = o.read_typetree()
            tr[pid] = d
            go_tr[d['m_GameObject']['m_PathID']] = pid
        elif o.type.name == 'SortingGroup':
            d = o.read_typetree()
            groups[d['m_GameObject']['m_PathID']] = (d['m_SortingOrder'], d['m_SortingLayerID'])
    for pid, d in tr.items():
        par = d['m_Father']['m_PathID']
        go_parent[d['m_GameObject']['m_PathID']] = tr[par]['m_GameObject']['m_PathID'] if par else 0

    world = {}

    def world_of(pid):
        if pid in world:
            return world[pid]
        d = tr[pid]
        p, s, q = d['m_LocalPosition'], d['m_LocalScale'], d['m_LocalRotation']
        local = (p['x'], p['y'], p['z'], s['x'], s['y'], z_angle(q))
        parent = d['m_Father']['m_PathID']
        gid = d['m_GameObject']['m_PathID']
        active = go_active.get(gid, True)
        if not parent:
            world[pid] = (local[0], local[1], local[2], local[3], local[4], local[5], active)
            return world[pid]
        px, py, pz, psx, psy, pr, pa = world_of(parent)
        c, sn = math.cos(pr), math.sin(pr)
        x = px + (c * local[0] * psx - sn * local[1] * psy)
        y = py + (sn * local[0] * psx + c * local[1] * psy)
        world[pid] = (x, y, pz + local[2], psx * local[3], psy * local[4], pr + local[5], pa and active)
        return world[pid]

    weather = {}
    for r in load_mb(args.mb, 'Game.Level.LevelSpriteRendererVisibleByWeather', level):
        weather[r['_spriteRenderer']['m_PathID']] = set(r['_supportedWeatherTypes'])

    # Runtime-state badges (new content markers) are visible in the static export only.
    badge_roots = set()
    for cls in ('PWC.World.Buildings.WorldBuildingNewBadge', 'PWC.World.Buildings.WorldBuildingRetroHuntNewBadge'):
        for r in load_mb(args.mb, cls, level):
            badge_roots.add(r['m_GameObject']['m_PathID'])

    def under(gid, roots):
        while gid:
            if gid in roots:
                return True
            gid = go_parent.get(gid, 0)
        return False

    def sort_path(gid, order, z):
        chain = []
        node = gid
        while node:
            if node in groups:
                gx = world_of(go_tr[node])[2]
                chain.append((groups[node][0], -gx))
            node = go_parent.get(node, 0)
        chain.reverse()
        return chain + [(order, -z)]

    rows, skipped = [], collections.Counter()
    for (f, pid), o in objs.items():
        if f != level or o.type.name != 'SpriteRenderer':
            continue
        d = o.read_typetree()
        gid = d['m_GameObject']['m_PathID']
        sp = d['m_Sprite']
        if sp['m_FileID'] == 0:
            sprite_file = level
        else:
            sprite_file = Path(o.assets_file.externals[sp['m_FileID'] - 1].path).name
        entry = exported.get((sprite_file, sp['m_PathID']))
        if entry is None:
            skipped['no exported sprite'] += 1
            continue
        if not d['m_Enabled']:
            skipped['renderer disabled'] += 1
            continue
        wx, wy, wz, sx, sy, rot, active = world_of(go_tr[gid])
        if not active:
            skipped['inactive hierarchy'] += 1
            continue
        if under(gid, badge_roots):
            skipped['badge'] += 1
            continue
        if go_name.get(gid, '').startswith(('Fashion_Drop', 'Iris')):
            skipped['event marker / screen iris overlay'] += 1
            continue
        if 'night' in entry['file'].lower() or 'night' in go_name.get(gid, '').lower():
            skipped['night variant (name heuristic)'] += 1
            continue
        c = d['m_Color']
        rows.append({'go': go_name.get(gid, ''), 'go_id': gid, 'sprite': entry['file'], 'size': entry['size'],
                     'x': wx, 'y': wy, 'z': wz, 'sx': sx, 'sy': sy, 'rot': rot,
                     'order': d['m_SortingOrder'], 'sortPath': sort_path(gid, d['m_SortingOrder'], wz), 'color': [c['r'], c['g'], c['b'], c['a']],
                     'flipX': bool(d['m_FlipX']), 'flipY': bool(d['m_FlipY']), 'drawMode': d['m_DrawMode'],
                     'drawSize': [d['m_Size']['x'], d['m_Size']['y']],
                     # LevelSpriteRendererVisibleByWeather: vazio = sempre visivel; senao so nos climas listados
                     'weathers': sorted(weather[pid]) if pid in weather else []})

    # Buildings that ship an under-construction variant ("_UC_") show it instead of the day-mode art
    # (not released in 1.227: construction tape in the original map). Both are active in the static export.
    uc_parents = {go_parent.get(r['go_id'], 0) for r in rows if '_UC' in r['go']}
    def under_uc_parent(gid):
        while gid:
            if gid in uc_parents:
                return True
            gid = go_parent.get(gid, 0)
        return False
    before = len(rows)
    # (filtro de DayMode removido: no original a arte do predio fica sob a fita da obra)
    skipped['day-mode art replaced by under-construction variant'] += before - len(rows)

    # pivot / ppu of every exported sprite
    meta = {}
    for (f, pid), o in objs.items():
        if o.type.name == 'Sprite' and (f, pid) in exported:
            d = o.read_typetree()
            meta[(f, pid)] = {'pivot': [d['m_Pivot']['x'], d['m_Pivot']['y']], 'ppu': d['m_PixelsToUnits'],
                              'rect': [d['m_Rect']['width'], d['m_Rect']['height']]}
    by_file = {e['file']: meta.get(k) for k, e in exported.items()}
    for r in rows:
        m = by_file.get(r['sprite'])
        r['pivot'], r['ppu'] = (m['pivot'], m['ppu']) if m else ([0.5, 0.5], 100.0)

    def inside(gid, root):
        while gid:
            if gid == root:
                return True
            gid = go_parent.get(gid, 0)
        return False

    def bounds_of(r):
        w, h = r['size'][0] / r['ppu'] * abs(r['sx']), r['size'][1] / r['ppu'] * abs(r['sy'])
        left, bottom = r['x'] - r['pivot'][0] * w, r['y'] - r['pivot'][1] * h
        return left, bottom, left + w, bottom + h

    buildings = []
    for b in load_mb(args.mb, 'PWC.World.Buildings.WorldBuilding', level):
        gid = b['m_GameObject']['m_PathID']
        wx, wy, wz, sx, sy, rot, active = world_of(go_tr[gid])
        root = go_parent.get(gid, 0) or gid
        boxes = [bounds_of(r) for r in rows if inside(r['go_id'], root)]
        box = None
        if boxes:
            box = [min(v[0] for v in boxes), min(v[1] for v in boxes),
                   max(v[2] for v in boxes), max(v[3] for v in boxes)]
        buildings.append({'go': go_name.get(gid, ''), 'name': go_name.get(root, ''), 'go_id': gid,
                          'x': wx, 'y': wy, 'active': active, 'bounds': box,
                          'underConstruction': any(inside(r['go_id'], root) and '_UC' in r['go'] for r in rows),
                          'buildingType': b['_buildingType'], 'defaultLevel': b['_defaultLevelType'],
                          'moreLevels': b.get('_moreValidLevelTypes') or [], 'isFree': b['_isFree']})
    out = {'level': level, 'weather': args.weather, 'camera': {'orthoSize': 5.12},
           'renderers': rows, 'buildings': buildings, 'skipped': dict(skipped)}
    path = args.output or args.scene_dir / f'{level}_world.json'
    path.write_text(json.dumps(out))
    print(f'{len(rows)} renderers, {len(buildings)} buildings, skipped {dict(skipped)} -> {path}')


if __name__ == '__main__':
    main()
