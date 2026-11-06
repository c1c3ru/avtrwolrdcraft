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
    level_assets = next(o.assets_file for o in env.objects if o.assets_file.name == args.level)

    def objs_level_externals(ref):
        return level_assets.externals[ref['m_FileID'] - 1].path

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

    # Animacoes do mapa (WorldCloud / WorldCloudsSpawner / WorldTrain): so os dados; o movimento e do cliente.
    cloud_mbs = load_mb(args.mb, 'PWC.World.WorldCloud', level)
    cloud_roots = {r['m_GameObject']['m_PathID'] for r in cloud_mbs}
    rain_pids = {r['_rainSpriteRenderer']['m_PathID'] for r in cloud_mbs if r.get('_rainSpriteRenderer')}
    clear_pids = {r['_clearSpriteRenderer']['m_PathID'] for r in cloud_mbs if r.get('_clearSpriteRenderer')}
    # As nuvens do original nascem SEM sprite: o spawner sorteia da lista (clear/rain). Exporta essas listas.
    cloud_png_dir = args.scene_dir / f'{level}.export.json'
    cloud_png_dir.mkdir(parents=True, exist_ok=True)
    cloud_entries = {'clear': [], 'rain': []}
    for sp_mb in load_mb(args.mb, 'PWC.World.WorldCloudsSpawner', level):
        for kind, field in (('clear', '_clearCloudSprites'), ('rain', '_rainCloudsSprites')):
            for i, ref in enumerate(sp_mb.get(field) or []):
                ext = Path(objs_level_externals(ref)).name
                o = objs.get((ext, ref['m_PathID']))
                if o is None:
                    continue
                img = o.read().image
                name = f"{Path(ext).stem}_{ref['m_PathID']}_Cloud_{kind}_{i}"
                img.save(cloud_png_dir / f'{name}.png')
                entry = {'file': name, 'size': list(img.size), 'source': {'file': ext, 'path_id': ref['m_PathID']}}
                exported[(ext, ref['m_PathID'])] = entry
                cloud_entries[kind].append(entry)
    train_mbs = load_mb(args.mb, 'PWC.World.WorldTrain', level)
    train_roots = {r['m_GameObject']['m_PathID'] for r in train_mbs}

    def nearest(gid, roots):
        while gid:
            if gid in roots:
                return gid
            gid = go_parent.get(gid, 0)
        return 0

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
        is_cloud = pid in clear_pids or pid in rain_pids
        if is_cloud and sp['m_PathID'] == 0:
            pool = cloud_entries['rain' if pid in rain_pids else 'clear']
            entry = pool[nearest(gid, cloud_roots) % len(pool)] if pool else None
        else:
            entry = exported.get((sprite_file, sp['m_PathID']))
        if entry is None:
            skipped['no exported sprite'] += 1
            continue
        if not d['m_Enabled'] and not is_cloud:
            skipped['renderer disabled'] += 1
            continue
        wx, wy, wz, sx, sy, rot, active = world_of(go_tr[gid])
        if not active and not is_cloud:
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
                     'weathers': sorted(weather[pid]) if pid in weather else [],
                     'cloud': nearest(gid, cloud_roots), 'cloudRain': pid in rain_pids, 'train': nearest(gid, train_roots)})

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
    def pos(tr_ref):
        w = world_of(tr_ref['m_PathID'])
        return w[0], w[1]

    animations = {'clouds': None, 'trains': [], 'spines': []}
    # Esqueletos Spine da cena (Sun_Moon = ceu, Water_Reflections = brilhos na agua): posicao, escala e ordem de desenho.
    sk_names = {}
    for rec in (json.loads(l) for l in gzip.open(args.mb / 'Spine.Unity.SkeletonDataAsset.jsonl.gz', 'rt')):
        sk_names[(rec['_file'], rec['_path_id'])] = rec['m_Name'].removesuffix('_SkeletonData')
    mesh_order = {}
    for (f, pid), o in objs.items():
        if f == level and o.type.name == 'MeshRenderer':
            d = o.read_typetree()
            mesh_order[d['m_GameObject']['m_PathID']] = d['m_SortingOrder']
    cam_gids = {r['m_GameObject']['m_PathID'] for r in load_mb(args.mb, 'PWC.World.WorldCamera', level)}
    for rec in load_mb(args.mb, 'Spine.Unity.SkeletonAnimation', level):
        gid = rec['m_GameObject']['m_PathID']
        ref = rec['skeletonDataAsset']
        ext = Path(objs_level_externals(ref)).name if ref['m_FileID'] else level
        name = sk_names.get((ext, ref['m_PathID']))
        if name is None or gid not in go_tr or not go_active.get(gid, True):
            continue
        wx, wy, wz, sx, sy, rot, active = world_of(go_tr[gid])
        cam = nearest(gid, cam_gids)  # filho da WorldCamera: acompanha a tela (offset = posicao - camera na cena)
        cx, cy = world_of(go_tr[cam])[:2] if cam else (0.0, 0.0)
        animations['spines'].append({'skeleton': name, 'x': wx, 'y': wy, 'z': wz, 'sx': sx, 'sy': sy, 'loop': bool(rec['loop']),
                                     'followCamera': bool(cam), 'offsetX': wx - cx, 'offsetY': wy - cy,
                                     'animation': rec.get('_animationName') or '', 'sortPath': sort_path(gid, mesh_order.get(gid, 0), wz)})
    for r in load_mb(args.mb, 'PWC.World.WorldCloudsSpawner', level):
        sx, sy = world_of(go_tr[r['m_GameObject']['m_PathID']])[:2]
        ex, ey = pos(r['_endPoint'])
        animations['clouds'] = {'startX': sx, 'endX': ex, 'minY': r['_minYPosition'], 'maxY': r['_maxYPosition']}
    for r in train_mbs:
        gx, gy = pos(r['_goToPos']); sx, sy = pos(r['_startPos'])
        animations['trains'].append({'id': r['m_GameObject']['m_PathID'], 'startX': sx, 'startY': sy, 'goX': gx, 'goY': gy,
                                     'toGoSeconds': r['_goToGoToPosTime'], 'toStartSeconds': r['_goToInitialPosTime']})
    out = {'level': level, 'weather': args.weather, 'camera': {'orthoSize': 5.12}, 'animations': animations,
           'renderers': rows, 'buildings': buildings, 'skipped': dict(skipped)}
    path = args.output or args.scene_dir / f'{level}_world.json'
    path.write_text(json.dumps(out))
    print(f'{sum(1 for r in rows if r["cloud"])} sprites de nuvem, {sum(1 for r in rows if r["train"])} de trem;', f'{len(rows)} renderers, {len(buildings)} buildings, skipped {dict(skipped)} -> {path}')


if __name__ == '__main__':
    main()
