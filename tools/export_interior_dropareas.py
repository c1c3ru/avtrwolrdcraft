#!/usr/bin/env python3
"""Per-interior drop-area data in the PR #16 layout: Interiors/<key>/<key>_dropareas.json.

Source: this branch's Resources/Scenes/<Name>/scene.json (dropAreas exported by export_scene_items.py from the
original PolygonCollider2D + LevelDropArea fields). Coordinates are the same world space as Interiors/<key>/<key>.json.
The interior renderer list comes from a git ref (default origin/maps-animations-lfs), so no PNG/Resources of #16 is
needed here. Output = {"areas":[{go, kind, priority, maxW, maxH, entityOrder, poly}]}, a small text file per interior.

  go            GameObject name of the LevelDropArea
  kind          class name (LevelDropArea, LevelFloorArea, LevelSingleItemDropArea, ...)
  priority      _sortPriority;  maxW/maxH = _maxItemsWidth/_maxItemsHeight (0 = unlimited)
  entityOrder   index in the interior's renderers of the LAST renderer of the LevelItem that owns the area
                (ILevelConsumer.GetEntity; used by CompareConsumers); -1 = scene area without entity
  poly          world polygon [x0,y0,x1,y1,...]

uso: export_interior_dropareas.py [--ref origin/maps-animations-lfs] [--out tools/data/interior_dropareas]
"""
import argparse
import json
import re
import subprocess
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
UNITY = 'client/AvatarWorldClient/Assets'


def git_show(ref, path):
    return subprocess.check_output(['git', 'show', f'{ref}:{path}'], cwd=ROOT, text=True)


def main(argv=None):
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument('--ref', default='origin/maps-animations-lfs')
    ap.add_argument('--out', type=Path, default=ROOT / 'tools/data/interior_dropareas')
    args = ap.parse_args(argv)

    catalog = git_show(args.ref, f'{UNITY}/Scripts/Core/World/InteriorCatalog.cs')
    entries = [(int(a), b, c) for a, b, c in re.findall(r'\{ (\d+), "(\w+)" \}, // .*? -> (level\d+)', catalog)]
    scenes = {o['levelType']: o['name'] for o in json.loads((ROOT / 'tools/data/level_scene_map.json').read_text())}
    args.out.mkdir(parents=True, exist_ok=True)
    total = 0
    for level_type, key, _ in entries:
        name = scenes.get(level_type)
        if name is None:
            print('sem cena minha para', key)
            continue
        scene = json.loads((ROOT / UNITY / f'Resources/Scenes/{name}/scene.json').read_text())
        theirs = json.loads(git_show(args.ref, f'{UNITY}/Resources/Interiors/{key}/{key}.json'))['renderers']
        # indice (go, sprite, x, y) -> posicoes no interior do #16, na ordem (mesmo criterio de mark_interior_items.py)
        slots = {}
        for i, r in enumerate(theirs):
            slots.setdefault((r['go'], r['sprite'], round(r['x'], 4), round(r['y'], 4)), []).append(i)
        item_last = {}
        by_rank = {}
        for r in scene['renderers']:
            by_rank[r['rank']] = r
            if r.get('item', -1) >= 0:
                k = (r['go'], r['sprite'], round(r['x'], 4), round(r['y'], 4))
                hit = slots.get(k)
                if hit:
                    idx = hit.pop(0)
                    item_last[r['item']] = max(item_last.get(r['item'], -1), idx)
        areas = []
        for a in scene['dropAreas']:
            order = -1
            if a['entityOrder'] >= 0:
                owner = by_rank.get(a['entityOrder'], {}).get('item', -1)
                order = item_last.get(owner, -1)
            areas.append({'go': a['go'], 'kind': a['kind'], 'priority': a['priority'], 'maxW': a['maxW'],
                          'maxH': a['maxH'], 'entityOrder': order, 'poly': a['poly']})
        (args.out / f'{key}_dropareas.json').write_text(json.dumps({'areas': areas}, separators=(',', ':')))
        total += len(areas)
        print(f'{key:30} {len(areas):4} areas, {sum(1 for x in areas if x["entityOrder"] >= 0):3} com entidade')
    print('total', total, 'areas em', len(entries), 'interiores ->', args.out)


if __name__ == '__main__':
    main()
