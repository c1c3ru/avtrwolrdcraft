#!/usr/bin/env python3
"""Marca, em cada interior exportado, quais renderers sao itens arrastaveis do original (GameObject com LevelItem).

Le out/scene-extract/<levelN>.inspect.json (behaviours) e <levelN>_world.json (renderers com go_id) e grava
Resources/Interiors/<chave>/<chave>_items.json = {"items": [indices em renderers]}. A cadeia chave -> levelN vem dos
comentarios de InteriorCatalog.cs. So o proprio GameObject do LevelItem e marcado (filhos nao).
uso: python3 tools/mark_interior_items.py
"""
import collections, hashlib, json, re
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
UNITY = ROOT / 'client/AvatarWorldClient/Assets'
SCENES = ROOT / 'out/scene-extract'


def pick(interior, rows, go_ids):
    wanted = collections.Counter((r['go'], r['sprite'].removesuffix('.png'), round(r['x'], 4), round(r['y'], 4))
                                 for r in rows if r.get('go_id') in go_ids)
    idx = []
    for i, r in enumerate(json.loads(interior.read_text())['renderers']):
        k = (r['go'], r['sprite'], round(r['x'], 4), round(r['y'], 4))
        if wanted[k] > 0:
            wanted[k] -= 1
            idx.append(i)
    return idx


def main():
    catalog = (UNITY / 'Scripts/Core/World/InteriorCatalog.cs').read_text(encoding='utf-8')
    levels = dict(re.findall(r'"(\w+)" \}, // .*? -> (level\d+)', catalog))
    total = 0
    for key, level in sorted(levels.items()):
        interior = UNITY / f'Resources/Interiors/{key}/{key}.json'
        inspect, world = SCENES / f'{level}.inspect.json', SCENES / f'{level}_world.json'
        if not (interior.exists() and inspect.exists() and world.exists()): print('pulado', key, level); continue
        behaviours = json.loads(inspect.read_text())['behaviours']
        rows = json.loads(world.read_text())['renderers']
        idx = pick(interior, rows, {b['game_object_path_id'] for b in behaviours if b['script']['name'] == 'LevelItem'})
        # mobilia com animacao contextual do original (cadeira, maca...): nao arrasta, o avatar vai ate ela ao tocar
        spots = pick(interior, rows, {b['game_object_path_id'] for b in behaviours if b['script']['name'] == 'LevelContextualAnimationItem'})
        spots = [i for i in spots if i not in set(idx)]
        out = interior.with_name(f'{key}_items.json')
        out.write_text(json.dumps({'items': idx, 'spots': spots}))
        meta = out.with_name(out.name + '.meta')
        if not meta.exists():
            tmpl = interior.with_name(interior.name + '.meta').read_text()
            guid = hashlib.sha256(f'avatarworld-re:Interiors/{key}_items'.encode()).hexdigest()[:32]
            meta.write_text(re.sub(r'guid: [0-9a-f]{32}', 'guid: ' + guid, tmpl))
        total += len(idx)
        print(f'{key:30} {level:9} {len(idx):4} itens {len(spots):3} pontos')
    print('total', total)


if __name__ == '__main__':
    main()
