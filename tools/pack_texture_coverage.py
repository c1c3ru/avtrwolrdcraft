#!/usr/bin/env python3
"""Mede, por pacote de moda do original, quantas pecas tem textura utilizavel pelo editor de avatar.

Entradas: out/recon/tasks/T033/clothing-gates-crosswalk.json (pacote -> skins), out/assets/avatar-resources.json,
out/assets/Texture2D/*.png e o atlas do esqueleto. Uma peca e "resolvivel" pela mesma regra de avatar_catalog_build.py:
cada sub-peca tem exatamente um PNG <peca>_<path_id>.png com as dimensoes da pagina do atlas.
Tambem informa se a categoria da peca e suportada pelo editor e se o id ja esta no AvatarCatalogData.
Saida: tabela no stdout e out/recon/pack_texture_coverage.json (nao versionado).
uso: python3 tools/pack_texture_coverage.py
"""
import collections, json, os, re, struct
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
UNITY = ROOT / 'client/AvatarWorldClient/Assets'
TEXTURES = ROOT / 'out/assets/Texture2D'
ATLAS = UNITY / 'Resources/AvatarSpine/Avatar_Spine.atlas.txt'
DATA_CS = UNITY / 'Scripts/Core/Avatar/AvatarCatalogData.cs'
# familia da peca (prefixo do skin) -> categoria do editor; o resto nao tem categoria no editor hoje
EDITOR_FAMILY = {'shirt': 'Shirt', 'bottom': 'Bottom', 'legs_shoes': 'Shoes', 'mouth': 'Mouth',
                 'eyebrows': 'Eyebrows', 'hair_back': 'HairBack', 'hat': 'Hat', 'jacket': 'Jacket',
                 'accessories_body_neck': 'Accessory',
                 'accessories_face_glasses': 'Accessory'}


def png_size(p):
    with open(p, 'rb') as fh:
        return struct.unpack('>II', fh.read(24)[16:24])


def family(skin):
    s = skin.lower()
    for key in ('legs_shoes', 'hair_back', 'accessories_body_neck', 'accessories_face_glasses'):
        if s.startswith(key): return key
    return s.split('_')[0]


def make_resolver():
    """Devolve (resolvable(item), items): textura unica por sub-peca, pagina do atlas e skin Templates/<peca> no esqueleto."""
    rows = json.loads((ROOT / 'out/assets/avatar-resources.json').read_text(encoding='utf-8'))
    lines = ATLAS.read_text(encoding='utf-8-sig').splitlines()
    pages = {}
    for i, line in enumerate(lines[:-1]):
        n, f = line.strip(), lines[i + 1].strip()
        if n.lower().endswith('.png') and f.startswith('size:'):
            pages[n[:-4].casefold()] = tuple(int(v) for v in re.findall(r'\d+', f))
    inventory = json.loads((ROOT / 'out/avatar-spine-inventory.json').read_text(encoding='utf-8'))
    skins = {s['name'].casefold() for s in inventory['skins']}
    tex = collections.defaultdict(list)
    for n in os.listdir(TEXTURES): tex[n.casefold()].append(n)
    items = collections.defaultdict(lambda: collections.defaultdict(set))  # item -> peca -> path_ids
    for r in rows:
        p = r['path'].casefold().split('/')
        if len(p) >= 6 and p[:3] == ['sutsystem', 'skins', 'character']:
            items[p[-2]][p[-1]].add(r['path_id'])

    def resolvable(item):
        pieces = items.get(item)
        if not pieces: return 'sem_recurso'
        for piece, pids in pieces.items():
            c = [t for pid in pids for t in tex.get(f'{piece}_{pid}.png', [])]
            if len(c) != 1: return 'sem_png'
            if piece not in pages or png_size(TEXTURES / c[0]) != pages[piece]: return 'atlas'
            if 'templates/' + piece not in skins: return 'sem_skin'
        return 'ok'
    return resolvable, items


def main():
    cross = json.loads((ROOT / 'out/recon/tasks/T033/clothing-gates-crosswalk.json').read_text(encoding='utf-8'))
    resolvable, _ = make_resolver()
    catalog = set(re.findall(r'"([^"]+)"', DATA_CS.read_text(encoding='utf-8')))
    out = {}
    for r in cross['rows']:
        item = r['skin_name'].lower()
        fam = family(item)
        out.setdefault(r['flag'], []).append({
            'skin': r['skin_name'], 'family': fam, 'editor_category': EDITOR_FAMILY.get(fam),
            'texture': resolvable(item), 'in_catalog': item in catalog})
    summary = {}
    print(f"{'pacote':32}{'total':>6}{'ok':>5}{'ok+editor':>10}{'ja no catalogo':>15}")
    for flag, lst in sorted(out.items(), key=lambda kv: -sum(1 for x in kv[1] if x['texture'] == 'ok' and x['editor_category'])):
        ok = [x for x in lst if x['texture'] == 'ok']
        ed = [x for x in ok if x['editor_category']]
        cat = [x for x in lst if x['in_catalog']]
        summary[flag] = {'total': len(lst), 'texture_ok': len(ok), 'texture_ok_editor_category': len(ed),
                         'already_in_catalog': len(cat), 'pieces': lst}
        print(f'{flag:32}{len(lst):>6}{len(ok):>5}{len(ed):>10}{len(cat):>15}')
    dest = ROOT / 'out/recon/pack_texture_coverage.json'
    dest.write_text(json.dumps(summary, indent=1), encoding='utf-8')
    print('->', dest.relative_to(ROOT))


if __name__ == '__main__':
    main()
