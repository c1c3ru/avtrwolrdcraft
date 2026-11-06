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
import hashlib
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
    'HairBack': ['hair/hair_back'],  # cabelo traseiro (coques, rabos): itens _color
    'Hat': ['hat/hat_a', 'hat/hat_b', 'hat/hat_c', 'hat/hat_d'],
    'Jacket': ['jacket/jacket_special', 'jacket/jacket_casual', 'jacket/jacket_formal'],
}
THREE_LEVEL = {'mouth', 'eyebrows'}
COLOR_CATEGORIES = {'Eyebrows', 'HairBack'}  # categorias cujos itens _color entram (recebem tinta Multiply)
# IDs que ja existiam (os padroes) continuam sendo os primeiros de cada categoria
KEEP_FIRST = {
    'Shirt': ['shirt_formal_1', 'shirt_casual_1'],
    'Bottom': ['bottom_special_1', 'bottom_special_10'],
    'Shoes': ['legs_shoes_1', 'legs_shoes_10'],
    'Accessory': ['accessories_face_glasses_1', 'accessories_body_neck_1'],
    # boca padrao = o anexo embutido no esqueleto (Body_Outline/Mouth_Regular), nao e um item do SUT
    'Mouth': ['mouth_default'],
    'Eyebrows': ['eyebrows_default'],
    'HairBack': ['hair_back_none'],
    'Hat': ['hat_none'],
    'Jacket': ['jacket_none'],
}
BUILT_IN = {'mouth_default', 'eyebrows_default', 'hair_back_none', 'hat_none', 'jacket_none'}
# cabelo da frente = skins Hair_Front/N_Color do esqueleto (1 pagina cada); os dois primeiros ja existiam
HAIR_FRONT_FIRST = ['Hair_Front/1_Color', 'Hair_Front/2_Color']


def png_size(path):
    with open(path, 'rb') as fh:
        header = fh.read(24)
    return struct.unpack('>II', header[16:24])


def natural(value):
    return [int(p) if p.isdigit() else p for p in re.split(r'(\d+)', value)]


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--per-category', type=int, default=100)
    parser.add_argument('--selection', type=Path, help='JSON with exact category IDs from recon_clothing_gap.py')
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
    selection = None
    if args.selection:
        selection = json.loads(args.selection.read_text(encoding='utf-8'))
        if selection.get('status') != 'provisional_review_only' or not isinstance(selection.get('items_by_category'), dict):
            raise SystemExit('selection must be a provisional candidate JSON from recon_clothing_gap.py')
        if not set(selection['items_by_category']).issubset(CATEGORIES):
            raise SystemExit('selection contains a category not supported by this generator')
        if any(not isinstance(v, list) for v in selection['items_by_category'].values()):
            raise SystemExit('each selected category must contain an ID array')
        if selection.get('total') != sum(len(v) for v in selection['items_by_category'].values()):
            raise SystemExit('selection total does not match its category arrays')

    # ---- cabelo da frente: skins Hair_Front/N_Color do inventario do esqueleto ----
    front = {}
    inventory_path = ROOT / 'out/avatar-spine-inventory.json'
    if inventory_path.exists():
        inventory = json.loads(inventory_path.read_text(encoding='utf-8'))
        tex_all = collections.defaultdict(list)
        for name in os.listdir(TEXTURES):
            m = re.match(r'(.*)_(\d+)\.png$', name)
            if m: tex_all[m.group(1).casefold()].append((name, int(m.group(2))))
        for skin in inventory['skins']:
            m = re.fullmatch(r'Hair_Front/(\d+)_Color', skin['name'])
            if not m or len(skin['pages']) != 1: continue
            page = skin['pages'][0][:-4]
            cands = [c for c in tex_all.get(page.casefold(), []) if png_size(TEXTURES / c[0]) == pages.get(page.casefold())]
            if len(cands) == 1:
                front[skin['name']] = (page, cands[0][0], cands[0][1])
    front_ids = list(HAIR_FRONT_FIRST) + [k for k in sorted(front, key=natural) if k not in HAIR_FRONT_FIRST]
    front_ids = [i for i in front_ids if i in front][:max(args.per_category, 2)]
    chosen = {}
    for category, prefixes in CATEGORIES.items():
        if selection and category in selection['items_by_category']:
            ids = selection['items_by_category'][category]
            if not isinstance(ids, list) or len(ids) != len(set(ids)):
                raise SystemExit(f'invalid or duplicate selected IDs in {category}')
            if any(not isinstance(item, str) or not re.fullmatch(r'[A-Za-z0-9_]+', item) for item in ids):
                raise SystemExit(f'invalid item ID in {category}')
            for item in ids:
                if item in BUILT_IN: continue  # ids embutidos no esqueleto: sem pasta no SUT
                prefix = next((candidate for candidate in prefixes if (candidate, item) in groups), None)
                if prefix is None:
                    raise SystemExit(f'no exact SUT folder for {category}/{item}')
                if item not in existing and not resolve(prefix, item):
                    raise SystemExit(f'unresolved SUT textures for {category}/{item}')
                chosen[item] = (prefix, item)
            chosen[category] = list(ids)
            continue
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
    meta_template_path = next(iter(CLOTHING.glob('*.png.meta')), None)
    if meta_template_path is None:
        raise SystemExit('cannot create Unity texture metadata: no existing .png.meta template')
    meta_template = meta_template_path.read_text(encoding='utf-8')

    def ensure_meta(path):
        meta_path = Path(str(path) + '.meta')
        if meta_path.exists():
            return
        relative = path.relative_to(UNITY).as_posix()
        guid = hashlib.sha256(('avatarworld-re:' + relative).encode('utf-8')).hexdigest()[:32]
        if not re.search(r'^guid:\s*[0-9a-fA-F]{32}\s*$', meta_template, re.M):
            raise SystemExit('existing Unity metadata template has no valid GUID line')
        meta_text = re.sub(r'^guid:\s*[0-9a-fA-F]{32}\s*$', 'guid: ' + guid, meta_template, count=1, flags=re.M)
        meta_path.write_text('\n'.join(line.rstrip() for line in meta_text.splitlines()) + '\n', encoding='utf-8')

    new_items = []
    for hair_id in front_ids:
        if hair_id in existing and existing[hair_id]['pieces'][0].get('skin'): continue
        page, filename, pid = front[hair_id]
        out_name = f'{page.casefold()}__{pid}.png'
        shutil.copyfile(TEXTURES / filename, CLOTHING / out_name)
        ensure_meta(CLOTHING / out_name)
        # skin = nome do skin do esqueleto; template so serve para derivar a pagina de atlas (Templates/<pagina>)
        piece = {'template': 'Templates/' + page, 'file': out_name, 'skin': hair_id}
        if hair_id in existing: existing[hair_id] = {'id': hair_id, 'pieces': [piece]}
        else: new_items.append({'id': hair_id, 'pieces': [piece]})
    for category in CATEGORIES:
        for item_id in chosen[category]:
            if item_id in existing or item_id in BUILT_IN: continue
            prefix, item = chosen[item_id]
            built = resolve(prefix, item)
            pieces = []
            for piece, filename, pid in sorted(built):
                out_name = f'{piece}__{pid}.png'
                shutil.copyfile(TEXTURES / filename, CLOTHING / out_name)
                ensure_meta(CLOTHING / out_name)
                pieces.append({'template': 'Templates/' + page_case[piece], 'file': out_name})
            new_items.append({'id': item_id, 'pieces': pieces})
    manifest['items'] = list(existing.values()) + [it for it in new_items if it['id'] not in existing]
    chosen['Hair'] = front_ids
    MANIFEST.write_text(json.dumps(manifest, indent=2), encoding='utf-8')

    with open(DATA_CS, 'w', encoding='utf-8') as out:
        out.write('// <auto-generated> por tools/avatar_catalog_build.py - nao editar a mao. </auto-generated>\n')
        out.write('namespace AvatarWorld.Core.Avatar\n{\n    /// <summary>IDs de roupa disponiveis no editor (itens reais do SUT com textura, pagina e dimensoes conferidas).</summary>\n')
        out.write('    public static class AvatarCatalogData\n    {\n')
        for category in list(CATEGORIES) + ['Hair']:
            out.write(f'        public static readonly string[] {category} =\n        {{\n')
            for item_id in chosen[category]:
                out.write(f'            "{item_id}",\n')
            out.write('        };\n\n')
        out.write('    }\n}\n')
    total = sum(len(chosen[c]) for c in list(CATEGORIES) + ['Hair'])
    if selection:
        print(f"selection target={selection['total']}; categories={', '.join(c + ' ' + str(len(selection['items_by_category'][c])) for c in selection['items_by_category'])}")
    print(f'{total} itens ({", ".join(c + " " + str(len(chosen[c])) for c in list(CATEGORIES) + ["Hair"])}); {len(new_items)} novos; PNGs copiados')


if __name__ == '__main__':
    main()
