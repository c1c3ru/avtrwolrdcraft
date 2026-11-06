#!/usr/bin/env python3
"""Draggable items and drop areas of every map-linked scene (PWC.Level.LevelItem / LevelDropArea).

Needs UnityPy (use a venv). For each scene level<N> writes, into tools/data/scene_items.json:
  items:     LevelItem GameObjects with their descendant GameObject ids (to tag exported renderers)
  dropAreas: LevelDropArea GameObjects with the world-space polygon of their PolygonCollider2D,
             _sortPriority, _allowOverlappingItems, _maxItemsWidth/_maxItemsHeight.
Layout/evidence only: acceptance rules of concrete drop-area subclasses are not recovered.

uso: export_scene_items.py [--scene-dir out/scene-extract] [--mb out/mb] [--only level5 ...]
"""
import argparse
import gzip
import json
import math
from collections import defaultdict
from pathlib import Path

import UnityPy

ROOT = Path(__file__).resolve().parents[1]


def z_angle(q):
    return math.atan2(2 * (q['w'] * q['z'] + q['x'] * q['y']), 1 - 2 * (q['y'] ** 2 + q['z'] ** 2))


def load_by_file(mb, cls):
    out = defaultdict(list)
    for l in gzip.open(mb / f'{cls}.jsonl.gz', 'rt'):
        r = json.loads(l)
        out[r['_file']].append(r)
    return out


def main(argv=None):
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument('--scene-dir', type=Path, default=Path('/home/deppi/avatarworld-re/out/scene-extract'))
    ap.add_argument('--mb', type=Path, default=ROOT / 'out/mb')
    ap.add_argument('--map', type=Path, default=ROOT / 'tools/data/level_scene_map.json')
    ap.add_argument('--output', type=Path, default=ROOT / 'tools/data/scene_items.json')
    ap.add_argument('--only', nargs='*')
    args = ap.parse_args(argv)

    items_mb = load_by_file(args.mb, 'PWC.Level.LevelItem')
    areas_mb = load_by_file(args.mb, 'PWC.Level.LevelDropArea')
    result = {}
    for entry in json.loads(args.map.read_text()):
        level = f"level{entry['buildIndex']}"
        if args.only and level not in args.only:
            continue
        items, areas = items_mb.get(level, []), areas_mb.get(level, [])
        if not items and not areas:
            result[level] = {'items': [], 'dropAreas': []}
            continue
        env = UnityPy.load(str(args.scene_dir / level))
        tr, go_tr, names, active, polys = {}, {}, {}, {}, defaultdict(list)
        for o in env.objects:
            if o.assets_file.name != level:
                continue
            t = o.type.name
            if t in ('Transform', 'RectTransform'):
                d = o.read_typetree()
                tr[o.path_id] = d
                go_tr[d['m_GameObject']['m_PathID']] = o.path_id
            elif t == 'GameObject':
                d = o.read_typetree()
                names[o.path_id] = d['m_Name']
                active[o.path_id] = bool(d['m_IsActive'])
            elif t == 'PolygonCollider2D':
                d = o.read_typetree()
                if d.get('m_Enabled', 1) and not d.get('m_IsTrigger', 0) or True:
                    polys[d['m_GameObject']['m_PathID']].append(d)
        children = defaultdict(list)
        for pid, d in tr.items():
            parent = d['m_Father']['m_PathID']
            if parent and parent in tr:
                children[tr[parent]['m_GameObject']['m_PathID']].append(d['m_GameObject']['m_PathID'])
        cache = {}

        def world(pid):
            if pid in cache:
                return cache[pid]
            d = tr[pid]
            p, s = d['m_LocalPosition'], d['m_LocalScale']
            a = z_angle(d['m_LocalRotation'])
            parent = d['m_Father']['m_PathID']
            if not parent or parent not in tr:
                cache[pid] = (p['x'], p['y'], s['x'], s['y'], a)
                return cache[pid]
            px, py, psx, psy, pr = world(parent)
            c, sn = math.cos(pr), math.sin(pr)
            cache[pid] = (px + c * p['x'] * psx - sn * p['y'] * psy, py + sn * p['x'] * psx + c * p['y'] * psy,
                          psx * s['x'], psy * s['y'], pr + a)
            return cache[pid]

        def chain_active(gid):
            pid = go_tr[gid]
            while pid and pid in tr:
                if not active.get(tr[pid]['m_GameObject']['m_PathID'], True):
                    return False
                pid = tr[pid]['m_Father']['m_PathID']
            return True

        def descendants(gid):
            out, stack = [], [gid]
            while stack:
                g = stack.pop()
                out.append(g)
                stack.extend(children.get(g, []))
            return out

        def depth(gid):
            n, pid = 0, go_tr[gid]
            while tr[pid]['m_Father']['m_PathID'] in tr:
                n += 1
                pid = tr[pid]['m_Father']['m_PathID']
            return n

        out_items = []
        for r in items:
            gid = r['m_GameObject']['m_PathID']
            if gid not in go_tr or not chain_active(gid):
                continue
            x, y, sx, sy, rot = world(go_tr[gid])
            out_items.append({'go': names.get(gid, ''), 'goId': gid, 'x': round(x, 4), 'y': round(y, 4),
                              'depth': depth(gid), 'bottomWidth': r['_bottomWidth'],
                              'descendants': descendants(gid)})
        out_areas = []
        for r in areas:
            gid = r['m_GameObject']['m_PathID']
            if gid not in go_tr or not chain_active(gid) or gid not in polys:
                continue
            x, y, sx, sy, rot = world(go_tr[gid])
            c, sn = math.cos(rot), math.sin(rot)
            for col in polys[gid]:
                off = col.get('m_Offset', {'x': 0, 'y': 0})
                for path in col['m_Points']['m_Paths']:
                    pts = []
                    for p in path:
                        lx, ly = (p['x'] + off['x']) * sx, (p['y'] + off['y']) * sy
                        pts.extend([round(x + c * lx - sn * ly, 4), round(y + sn * lx + c * ly, 4)])
                    if len(pts) >= 6:
                        out_areas.append({'go': names.get(gid, ''), 'priority': r['_sortPriority'],
                                          'allowOverlap': bool(r['_allowOverlappingItems']),
                                          'maxW': r['_maxItemsWidth'], 'maxH': r['_maxItemsHeight'],
                                          'canConsumeCharacters': bool(r['_canConsumeCharacters']), 'poly': pts})
        result[level] = {'items': out_items, 'dropAreas': out_areas}
        print(level, entry['name'], len(out_items), 'items', len(out_areas), 'drop-area polygons')
    args.output.write_text(json.dumps(result, separators=(',', ':')))


if __name__ == '__main__':
    main()
