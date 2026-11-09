#!/usr/bin/env python3
"""Export the moving parts of the original World map (level4) next to world.json.

world.json (tools/export_world_map.py) only carries static SpriteRenderers. This adds
Resources/WorldSlice/motion.json with the scene data of the components that move things:
WorldCloud (+ WorldCloudsSpawner bounds), WorldTrain (start/goto transforms and times),
WorldRoadPoint graph + WorldCarsController, and Spine SkeletonAnimation placements.
Evidence/layout only: speeds and easing are not in the Cpp2IL dump (bodies are empty), so the
client fills them with documented approximations.

uso: export_world_motion.py [--scene-dir out/scene-extract] [--mb out/mb] [--output motion.json]
"""
import argparse
import gzip
import json
import math
from pathlib import Path

import UnityPy

ROOT = Path(__file__).resolve().parents[1]
LEVEL = 'level4'


def load_mb(mb_dir, cls):
    path = mb_dir / f'{cls}.jsonl.gz'
    if not path.exists():
        return []
    return [r for r in (json.loads(l) for l in gzip.open(path, 'rt')) if r['_file'] == LEVEL]


def z_angle(q):
    return math.atan2(2 * (q['w'] * q['z'] + q['x'] * q['y']), 1 - 2 * (q['y'] ** 2 + q['z'] ** 2))


def main(argv=None):
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--scene-dir', type=Path, default=ROOT / 'out/scene-extract')
    parser.add_argument('--mb', type=Path, default=ROOT / 'out/mb')
    parser.add_argument('--output', type=Path,
                        default=ROOT / 'client/AvatarWorldClient/Assets/Resources/WorldSlice/motion.json')
    args = parser.parse_args(argv)

    env = UnityPy.load(str(args.scene_dir / LEVEL))
    env.load_file(str(args.scene_dir / 'sharedassets4.assets'))
    go_name, go_active, go_tr, tr, sr_go, sr_info = {}, {}, {}, {}, {}, {}
    skel_names = {}
    for o in env.objects:
        f = o.assets_file.name
        if f == LEVEL:
            t = o.type.name
            if t == 'GameObject':
                d = o.read_typetree()
                go_name[o.path_id] = d['m_Name']
                go_active[o.path_id] = bool(d['m_IsActive'])
            elif t == 'Transform':
                d = o.read_typetree()
                tr[o.path_id] = d
                go_tr[d['m_GameObject']['m_PathID']] = o.path_id
            elif t == 'SpriteRenderer':
                d = o.read_typetree()
                sr_go[o.path_id] = d['m_GameObject']['m_PathID']
                sr_info[o.path_id] = (d['m_Sprite']['m_PathID'], d['m_SortingOrder'])
        elif f == 'sharedassets4.assets' and o.type.name == 'MonoBehaviour':
            try:
                d = o.read_typetree()
            except Exception:
                continue
            if 'atlasAssets' in d or 'skeletonJSON' in d:
                skel_names[o.path_id] = d.get('m_Name', '')

    world = {}

    def world_of(pid):
        if pid in world:
            return world[pid]
        d = tr[pid]
        p, s, q = d['m_LocalPosition'], d['m_LocalScale'], d['m_LocalRotation']
        parent = d['m_Father']['m_PathID']
        if not parent:
            world[pid] = (p['x'], p['y'], s['x'], s['y'], z_angle(q))
            return world[pid]
        px, py, psx, psy, pr = world_of(parent)
        c, sn = math.cos(pr), math.sin(pr)
        world[pid] = (px + c * p['x'] * psx - sn * p['y'] * psy,
                      py + sn * p['x'] * psx + c * p['y'] * psy,
                      psx * s['x'], psy * s['y'], pr + z_angle(q))
        return world[pid]

    def active_chain(gid):
        pid = go_tr[gid]
        while pid:
            if not go_active.get(tr[pid]['m_GameObject']['m_PathID'], True):
                return False
            pid = tr[pid]['m_Father']['m_PathID']
        return True

    def at_go(gid):
        x, y, sx, sy, rot = world_of(go_tr[gid])
        return {'go': go_name.get(gid, ''), 'x': x, 'y': y, 'sx': sx, 'sy': sy, 'rot': rot}

    def at_tr(pid):
        x, y, sx, sy, rot = world_of(pid)
        return {'go': go_name.get(tr[pid]['m_GameObject']['m_PathID'], ''), 'x': x, 'y': y}

    out = {'level': LEVEL}

    spawner = load_mb(args.mb, 'PWC.World.WorldCloudsSpawner')[0]
    out['cloudBounds'] = {'minY': spawner['_minYPosition'], 'maxY': spawner['_maxYPosition'],
                          'endX': world_of(spawner['_endPoint']['m_PathID'])[0]}
    clouds = []
    for r in load_mb(args.mb, 'PWC.World.WorldCloud'):
        gid = r['m_GameObject']['m_PathID']
        row = at_go(gid)
        row['active'] = active_chain(gid)
        for key in ('_clearSpriteRenderer', '_rainSpriteRenderer'):
            sid = r[key]['m_PathID']
            if sid in sr_go:
                row[key[1:-14]] = {'go': go_name.get(sr_go[sid], ''), **{k: v for k, v in at_go(sr_go[sid]).items() if k in ('x', 'y')}}
        clouds.append(row)
    out['clouds'] = clouds

    # Sprites das nuvens: no level4 os WorldCloud nao tem sprite (o spawner sorteia em runtime das tres listas),
    # entao nenhum PNG deles existe em world.json; exporta aqui as 12 do WorldCloudsSpawner.
    sprites_dir = args.output.parent / 'sprites'
    cloud_sprites = {}
    wanted = {'clear': spawner['_clearCloudSprites'], 'rain': spawner['_rainCloudsSprites'],
              'heavy': spawner['_heavyRainCloudsSprites']}
    by_id = {o.path_id: o for o in env.objects
             if o.assets_file.name == 'sharedassets4.assets' and o.type.name == 'Sprite'}
    for kind, refs in wanted.items():
        rows = []
        for ref in refs:
            o = by_id[ref['m_PathID']]
            d = o.read_typetree()
            fname = f"sharedassets4_{o.path_id}_{d['m_Name']}"
            o.read().image.save(sprites_dir / f'{fname}.png')
            rows.append({'file': fname, 'pivotX': d['m_Pivot']['x'], 'pivotY': d['m_Pivot']['y'],
                         'ppu': d['m_PixelsToUnits']})
        cloud_sprites[kind] = rows
    out['cloudSprites'] = cloud_sprites

    trains = []
    for r in load_mb(args.mb, 'PWC.World.WorldTrain'):
        gid = r['m_GameObject']['m_PathID']
        row = at_go(gid)
        row['start'] = at_tr(r['_startPos']['m_PathID'])
        row['goTo'] = at_tr(r['_goToPos']['m_PathID'])
        row['toInitialSeconds'] = r['_goToInitialPosTime']
        row['toGoToSeconds'] = r['_goToGoToPosTime']
        trains.append(row)
    out['trains'] = trains

    points = {}
    for r in load_mb(args.mb, 'PWC.World.WorldRoadPoint'):
        gid = r['m_GameObject']['m_PathID']
        row = at_go(gid)
        points[r['_path_id']] = {'id': r['_path_id'], 'x': row['x'], 'y': row['y'],
                                 'next': [n['m_PathID'] for n in r['_nextPoints']]}
    out['roadPoints'] = list(points.values())
    out['carControllers'] = [{'sortingOrder': r['_sortingOrder'], 'numberOfCars': r['NumberOfCars'],
                              'carsIndexes': r['_carsIndexes'], 'speed': r['_speed'],
                              'roadPoints': [p['m_PathID'] for p in r['_roadPoints']]}
                             for r in load_mb(args.mb, 'PWC.World.WorldCarsController')]

    spines = []
    for r in load_mb(args.mb, 'Spine.Unity.SkeletonAnimation'):
        gid = r['m_GameObject']['m_PathID']
        row = at_go(gid)
        row['active'] = active_chain(gid)
        row['skeletonAssetId'] = r['skeletonDataAsset']['m_PathID']
        row['skeleton'] = skel_names.get(row['skeletonAssetId'], '')
        row['animation'] = r['_animationName']
        row['loop'] = bool(r['loop'])
        spines.append(row)
    out['spines'] = spines

    args.output.write_text(json.dumps(out, indent=1))
    print(f"{len(clouds)} clouds, {len(trains)} trains, {len(points)} road points, "
          f"{len(out['carControllers'])} car controllers, {len(spines)} spines -> {args.output}")


if __name__ == '__main__':
    main()
