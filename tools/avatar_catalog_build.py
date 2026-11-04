#!/usr/bin/env python3
"""Amplia o catalogo de roupas do editor de avatar a partir dos recursos SUT do original.

Entradas (geradas por avatar_bundle_inventory.py): out/assets/avatar-resources.json e out/assets/Texture2D/*.png;
atlas: client/AvatarWorldClient/Assets/Resources/AvatarSpine/Avatar_Spine.atlas.txt.
Um item (pasta sutsystem/skins/character/<cat>/<set>/<item>/) so entra se TODAS as pecas tiverem
(a) exatamente um PNG extraido <peca>_<path_id>.png, (b) pagina de atlas de mesmo nome, (c) PNG com as dimensoes da pagina.
Itens com sufixo _color/_p (precisam de cor/camada extra) ficam de fora.

Saidas: PNGs em Resources/AvatarSpine/Clothing, itens novos em clothing-manifest.json (os existentes sao preservados
na frente) e Scripts/Core/Avatar/AvatarCatalogData.cs (IDs por categoria).
uso: tools/venv/bin/python tools/avatar_catalog_build.py [--per-category 100]
"""
import argparse
import collections
import json
import os
import re
import shutil
import struct
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
UNITY = ROOT / 'client/AvatarWorldClient/Assets'
CLOTHING = UNITY / 'Resources/AvatarSpine/Clothing'
MANIFEST = UNITY / 'Resources/AvatarSpine/clothing-manifest.json'
ATLAS = UNITY / 'Resources/AvatarSpine/Avatar_Spine.atlas.txt'
DATA_CS = UNITY / 'Scripts/Core/Avatar/AvatarCatalogData.cs'
TEXTURES = ROOT / 'out/assets/Texture2D'

# categoria do editor -> prefixos de (categoria/conjunto) do SUT, na ordem de preferencia
CATEGORIES = {
    'Shirt': ['shirt/shirt_formal', 'shirt/shirt_casual', 'shirt/shirt_jobs', 'shirt/shirt_special'],
    'Bottom': ['bottom/bottom_special', 'bottom/bottom_casual', 'bottom/bottom_formal', 'bottom/bottom_jobs'],
    'Shoes': ['legs/legs_shoes'],
    'Accessory': ['accessories/accessories_face/accessories_face_glasses', 'accessories/accessories_body/accessories_body_neck'],
    'Mouth': ['mouth'],  # pasta de 3 niveis: mouth/<item>/<peca>
    'Eyebrows': ['eyebrows'],  # idem; todos os itens sao _color (tinta pela paleta General)
}
THREE_LEVEL = {'mouth', 'eyebrows'}
COLOR_CATEGORIES = {'Eyebrows'}  # categorias cujos itens _color entram (recebem tinta Multiply)
# IDs que ja existiam (os padroes) continuam sendo os primeiros de cada categoria
KEEP_FIRST = {
    'Shirt': ['shirt_formal_1', 'shirt_casual_1'],
    'Bottom': ['bottom_special_1', 'bottom_special_10'],
    'Shoes': ['legs_shoes_1', 'legs_shoes_10'],
    'Accessory': ['accessories_face_glasses_1', 'accessories_body_neck_1'],
    # boca padrao = o anexo embutido no esqueleto (Body_Outline/Mouth_Regular), nao e um item do SUT
    'Mouth': ['mouth_default'],
    'Eyebrows': ['eyebrows_default'],
}
BUILT_IN = {'mouth_default', 'eyebrows_default'}


def png_size(path):
    with open(path, 'rb') as fh:
        header = fh.read(24)
    return struct.unpack('>II', header[16:24])


def natural(value):
    return [int(p) if p.isdigit() else p for p in re.split(r'(\d+)', value)]


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--per-category', type=int, default=100)
    args = parser.parse_args()

    rows = json.loads((ROOT / 'out/assets/avatar-resources.json').read_text(encoding='utf-8'))
    lines = ATLAS.read_text(encoding='utf-8-sig').splitlines()
    pages, page_case = {}, {}
    for i, line in enumerate(lines[:-1]):
        name, following = line.strip(), lines[i + 1].strip()
        if name.lower().endswith('.png') and following.startswith('size:'):
            m = re.fullmatch(r'size:\s*(\d+)\s*,\s*(\d+)\s*', following)
            pages[name[:-4].casefold()] = tuple(int(v) for v in m.groups())
            page_case[name[:-4].casefold()] = name[:-4]
    tex = collections.defaultdict(list)
    for name in os.listdir(TEXTURES):
        tex[name.casefold()].append(name)

    groups = collections.defaultdict(lambda: collections.defaultdict(set))
    for r in rows:
        p = r['path'].casefold().split('/')
        if p[3] == 'accessories':
            if len(p) < 8: continue
            key, item, piece = '/'.join(p[3:6]), p[6], p[7]
        elif p[3] in THREE_LEVEL:
            if len(p) < 6: continue
            key, item, piece = p[3], p[4], p[5]
        else:
            if len(p) < 7: continue
            key, item, piece = p[3] + '/' + p[4], p[5], p[6]
        groups[(key, item)][piece].add(r['path_id'])

    def resolve(key, item):
        built = []
        for piece, pids in groups[(key, item)].items():
            cands = [t for pid in pids for t in tex.get(f'{piece}_{pid}.png', [])]
            if len(cands) != 1 or piece not in pages or png_size(TEXTURES / cands[0]) != pages[piece]:
                return None
            built.append((piece, cands[0], int(cands[0].rsplit('_', 1)[1][:-4])))
        return built

    manifest = json.loads(MANIFEST.read_text(encoding='utf-8'))
    existing = {it['id']: it for it in manifest['items']}
    chosen = {}
    for category, prefixes in CATEGORIES.items():
        ids = list(KEEP_FIRST[category])
        quota = max(args.per_category, len(ids))
        per_prefix = max(1, (quota - len(ids)) // len(prefixes))
        for prefix in prefixes:
            skip = r'_p$' if category in COLOR_CATEGORIES else r'(_color|_p)$'
            candidates = sorted((it for (k, it) in groups if k == prefix and not re.search(skip, it)), key=natural)
            taken = 0
            for item in candidates:
                if item in ids: continue
                if taken >= per_prefix: break
                if item in existing or resolve(prefix, item):
                    ids.append(item); chosen[item] = (prefix, item); taken += 1
        # segunda passada: conjuntos pequenos nao preenchem a cota; completa com os maiores
        for prefix in prefixes:
            if len(ids) >= quota: break
            skip = r'_p$' if category in COLOR_CATEGORIES else r'(_color|_p)$'
            candidates = sorted((it for (k, it) in groups if k == prefix and not re.search(skip, it)), key=natural)
            for item in candidates:
                if len(ids) >= quota: break
                if item in ids: continue
                if item in existing or resolve(prefix, item):
                    ids.append(item); chosen[item] = (prefix, item)
        chosen[category] = ids[:quota]

    CLOTHING.mkdir(parents=True, exist_ok=True)
    new_items = []
    for category in CATEGORIES:
        for item_id in chosen[category]:
            if item_id in existing or item_id in BUILT_IN: continue
            prefix, item = chosen[item_id]
            built = resolve(prefix, item)
            pieces = []
            for piece, filename, pid in sorted(built):
                out_name = f'{piece}__{pid}.png'
                shutil.copyfile(TEXTURES / filename, CLOTHING / out_name)
                pieces.append({'template': 'Templates/' + page_case[piece], 'file': out_name})
            new_items.append({'id': item_id, 'pieces': pieces})
    manifest['items'] = list(existing.values()) + [it for it in new_items if it['id'] not in existing]
    MANIFEST.write_text(json.dumps(manifest, indent=2), encoding='utf-8')

    with open(DATA_CS, 'w', encoding='utf-8') as out:
        out.write('// <auto-generated> por tools/avatar_catalog_build.py - nao editar a mao. </auto-generated>\n')
        out.write('namespace AvatarWorld.Core.Avatar\n{\n    /// <summary>IDs de roupa disponiveis no editor (itens reais do SUT com textura, pagina e dimensoes conferidas).</summary>\n')
        out.write('    public static class AvatarCatalogData\n    {\n')
        for category in CATEGORIES:
            out.write(f'        public static readonly string[] {category} =\n        {{\n')
            for item_id in chosen[category]:
                out.write(f'            "{item_id}",\n')
            out.write('        };\n\n')
        out.write('    }\n}\n')
    total = sum(len(chosen[c]) for c in CATEGORIES)
    print(f'{total} itens ({", ".join(c + " " + str(len(chosen[c])) for c in CATEGORIES)}); {len(new_items)} novos; PNGs copiados')


if __name__ == '__main__':
    main()
