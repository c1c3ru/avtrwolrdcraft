#!/usr/bin/env python3
"""Gera os dados dos tipos de avatar Toddler (crianca) e Baby (bebe) para o cliente.

Entradas (nao versionadas, em out/): out/assets/Texture2D/*.png e out/assets/TextAsset/<Kind>_Spine.{skel,atlas}_*.txt
(avatar_bundle_inventory.py), out/recon/tasks/T034/other-skins.json (itens SUT que nao sao Character, lidos do ResourceManager
do APK base) e out/recon/tasks/T034/<Kind>.skins.json (skin -> attachments -> region path, dump do esqueleto).
Um item de roupa so entra se TODAS as pecas tiverem exatamente um PNG <peca>_<path_id>.png, pagina de atlas de mesmo nome,
PNG com as dimensoes da pagina e skin "Templates/<pagina>" no esqueleto. Rosto (cabelo/boca/sobrancelha/olhos/corpo) vem dos
skins do esqueleto, resolvendo cada region -> pagina pelo atlas e pagina -> textura unica por nome+dimensoes.

Saidas: Resources/AvatarSpine/Kinds/<Kind>/{Spine.atlas.txt, Spine.skel.bytes, manifest.json}, PNGs em
Resources/AvatarSpine/Clothing e Scripts/Core/Avatar/AvatarKindCatalogData.cs.
uso: tools/venv/bin/python tools/avatar_kind_build.py
"""
import collections
import hashlib
import json
import re
import shutil
import struct
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
UNITY = ROOT / 'client/AvatarWorldClient/Assets'
CLOTHING = UNITY / 'Resources/AvatarSpine/Clothing'
KINDS_DIR = UNITY / 'Resources/AvatarSpine/Kinds'
DATA_CS = UNITY / 'Scripts/Core/Avatar/AvatarKindCatalogData.cs'
TEXTURES = ROOT / 'out/assets/Texture2D'
TEXT = ROOT / 'out/assets/TextAsset'
T034 = ROOT / 'out/recon/tasks/T034'

KINDS = {
    'Toddler': {
        'skel': 'Toddler_Spine.skel_109615.txt', 'atlas': 'Toddler_Spine.atlas_108537.txt', 'prefix': 'tdl_',
        'cats': {'Shirt': [('toddler', 'shirt'), ('toddler', 'jacket'), ('toddler', 'onepiece')], 'Bottom': [('toddler', 'bottom'), ('toddler', 'diaper')],
                 'Shoes': [('toddler', 'legs')],
                 'Accessory': [('toddler', 'neck'), ('toddler', 'bag'), ('toddler', 'back'), ('toddler', 'carrier'), ('toddler', 'item')]},
        'body': [('Body_Whites/Body_Whites', 'skin'), ('Body_Shad/Body_Shad', 'shadow'), ('Ear_Shad/Ear_Shad', 'ear'), ('Body_Other/Body_Other', '')],
    },
    'Baby': {
        'skel': 'Baby_Spine.skel_108922.txt', 'atlas': 'Baby_Spine.atlas_109843.txt', 'prefix': 'baby_',
        'cats': {'Shirt': [('baby', 'wrap'), ('baby', 'bib')], 'Accessory': [('baby', 'glasses'), ('baby', 'hat'), ('baby', 'carrier')]},
        'body': [('Body_Solid/Body_Solid', 'skin'), ('Body_Shadow/Body_Shadow', 'shadow'), ('Ear_Shadow/Ear_Shadow', 'ear'), ('Body_Outline/Body_Outline', '')],
    },
}
FACE = {'Hair': 'Hair_Front/', 'Mouth': 'Mouth/', 'Eyebrows': 'Eyebrows/'}
ALL_CATEGORIES = ['Hair', 'HairBack', 'Shirt', 'Bottom', 'Shoes', 'Accessory', 'Mouth', 'Eyebrows']


def natural(value):
    return [int(p) if p.isdigit() else p for p in re.split(r'(\d+)', value)]


def png_size(path):
    with open(path, 'rb') as fh:
        header = fh.read(24)
    return struct.unpack('>II', header[16:24])


def parse_atlas(path):
    """pagina(casefold) -> (nome, (w,h)); regiao -> nome da pagina."""
    lines = path.read_text(encoding='utf-8-sig').splitlines()
    pages, regions, current = {}, {}, None
    i = 0
    while i < len(lines) - 1:
        line = lines[i].strip()
        if line.lower().endswith('.png') and lines[i + 1].strip().startswith('size:'):
            m = re.fullmatch(r'size:\s*(\d+)\s*,\s*(\d+)\s*', lines[i + 1].strip())
            current = line[:-4]
            pages[current.casefold()] = (current, (int(m.group(1)), int(m.group(2))))
            i += 2
            continue
        if current and line and ':' not in line:
            regions[line] = current
        i += 1
    return pages, regions


def piece_entry(page, out_name, skins):
    entry = {'template': 'Templates/' + page, 'file': out_name}
    if 'Templates/' + page not in skins:
        entry['skin'] = 'Item_Templates/' + page  # itens de mao da crianca (bicicleta, instrumentos)
    return entry


def main():
    resources = json.loads((T034 / 'other-skins.json').read_text(encoding='utf-8'))
    tex = {}
    for name in TEXTURES.iterdir():
        tex[name.name.casefold()] = name.name
    meta_template_path = next(iter(CLOTHING.glob('*.png.meta')))
    meta_template = meta_template_path.read_text(encoding='utf-8')

    def ensure_meta(path):
        meta_path = Path(str(path) + '.meta')
        if meta_path.exists():
            return
        relative = path.relative_to(UNITY).as_posix()
        guid = hashlib.sha256(('avatarworld-re:' + relative).encode('utf-8')).hexdigest()[:32]
        text = re.sub(r'^guid:\s*[0-9a-fA-F]{32}\s*$', 'guid: ' + guid, meta_template, count=1, flags=re.M)
        meta_path.write_text('\n'.join(line.rstrip() for line in text.splitlines()) + '\n', encoding='utf-8')

    def copy_texture(filename, out_name):
        dest = CLOTHING / out_name
        if not dest.exists():
            shutil.copyfile(TEXTURES / filename, dest)
        ensure_meta(dest)

    CLOTHING.mkdir(parents=True, exist_ok=True)
    chosen_all = {}
    for kind, cfg in KINDS.items():
        pages, regions = parse_atlas(TEXT / cfg['atlas'])
        skins = {s['name']: s for s in json.loads((T034 / f'{kind}.skins.json').read_text(encoding='utf-8'))['skins']}

        # textura unica por nome+dimensoes (rosto/corpo: sem path SUT)
        by_name = collections.defaultdict(list)
        for f in TEXTURES.iterdir():
            m = re.match(r'(.*)_(\d+)\.png$', f.name)
            if m:
                by_name[m.group(1).casefold()].append((f.name, int(m.group(2))))

        def unique_texture(page):
            name, size = pages[page.casefold()]
            c = [x for x in by_name.get(name.casefold(), []) if png_size(TEXTURES / x[0]) == size]
            return c[0] if len(c) == 1 else None

        manifest, chosen = [], {c: [] for c in ALL_CATEGORIES}

        def skin_pieces(skin_name, require_unique=True):
            pieces, seen = [], set()
            for att in skins[skin_name]['atts']:
                page = regions.get(att['path'] or '')
                if page is None:
                    return None
                if page in seen:
                    continue
                seen.add(page)
                found = unique_texture(page)
                if found is None:
                    return None
                filename, pid = found
                out_name = f'{page.casefold()}__{pid}.png'
                copy_texture(filename, out_name)
                pieces.append({'template': 'Templates/' + page, 'file': out_name, 'skin': skin_name})
            return pieces or None

        # corpo + olhos (fixos)
        body_pieces = []
        for skin_name, role in cfg['body']:
            pieces = skin_pieces(skin_name)
            if pieces is None:
                raise SystemExit(f'{kind}: corpo nao resolvido: {skin_name}')
            for p in pieces:
                p['role'] = role
            body_pieces += pieces
        eyes = []
        for skin_name, role in (('Eyes/Eyes_1_Color', 'eye'), ('Eyes/Eyes_1_Color-p', '')):
            pieces = skin_pieces(skin_name)
            if pieces is None:
                raise SystemExit(f'{kind}: olhos nao resolvidos: {skin_name}')
            for p in pieces:
                p['role'] = role
            eyes += pieces
        manifest.append({'id': '__body', 'pieces': body_pieces + eyes})

        # rosto: cabelo, boca, sobrancelha
        for category, prefix in FACE.items():
            names = sorted((s for s in skins if s.startswith(prefix)), key=natural)
            for skin_name in names:
                pieces = skin_pieces(skin_name)
                if pieces is None:
                    continue
                item_id = cfg['prefix'] + skin_name.split('/', 1)[1].lower()
                manifest.append({'id': item_id, 'pieces': pieces})
                chosen[category].append(item_id)

        # roupas: itens SUT (toddler/baby) agrupados por pasta
        groups = collections.defaultdict(lambda: collections.defaultdict(set))
        for r in resources:
            p = r['path'].casefold().split('/')
            if len(p) < 6 or p[2] != kind.casefold():
                continue
            groups[(p[2], p[3], p[-2])][p[-1]].add(r['path_id'])
        for category, sets in cfg['cats'].items():
            for sk, cat in sets:
                items = sorted((it for (k, c, it) in groups if k == sk and c == cat and not re.search(r'(_color|_p)$', it)), key=natural)
                for item in items:
                    pieces, ok = [], True
                    for piece, pids in sorted(groups[(sk, cat, item)].items()):
                        cands = [tex[f'{piece}_{pid}.png'] for pid in pids if f'{piece}_{pid}.png' in tex]
                        if len(cands) != 1 or piece not in pages or png_size(TEXTURES / cands[0]) != pages[piece][1]:
                            ok = False
                            break
                        page = pages[piece][0]
                        if 'Templates/' + page not in skins and 'Item_Templates/' + page not in skins:
                            ok = False
                            break
                        pid = int(cands[0].rsplit('_', 1)[1][:-4])
                        out_name = f'{piece}__{pid}.png'
                        pieces.append((page, cands[0], out_name))
                    if not ok or not pieces:
                        continue
                    item_id = cfg['prefix'] + item
                    if item_id in chosen[category]:
                        continue
                    for page, filename, out_name in pieces:
                        copy_texture(filename, out_name)
                    manifest.append({'id': item_id, 'pieces': [piece_entry(page, out_name, skins) for page, _, out_name in pieces]})
                    chosen[category].append(item_id)

        out_dir = KINDS_DIR / kind
        out_dir.mkdir(parents=True, exist_ok=True)
        shutil.copyfile(TEXT / cfg['atlas'], out_dir / 'Spine.atlas.txt')
        shutil.copyfile(TEXT / cfg['skel'], out_dir / 'Spine.skel.bytes')
        (out_dir / 'manifest.json').write_text(json.dumps({'items': manifest}, indent=1), encoding='utf-8')
        chosen_all[kind] = chosen
        print(kind, {c: len(v) for c, v in chosen.items()}, 'itens no manifesto:', len(manifest))

    with open(DATA_CS, 'w', encoding='utf-8') as out:
        out.write('// <auto-generated> por tools/avatar_kind_build.py - nao editar a mao. </auto-generated>\n')
        out.write('namespace AvatarWorld.Core.Avatar\n{\n    /// <summary>IDs por categoria dos tipos Crianca (Toddler) e Bebe (Baby), resolvidos a partir dos esqueletos e dos itens SUT.</summary>\n')
        out.write('    public static class AvatarKindCatalogData\n    {\n')
        for kind, chosen in chosen_all.items():
            out.write(f'        public static class {kind}\n        {{\n')
            for category in ALL_CATEGORIES:
                ids = chosen[category]
                out.write(f'            public static readonly string[] {category} =\n            {{\n')
                for item_id in ids:
                    out.write(f'                "{item_id}",\n')
                out.write('            };\n')
            out.write('        }\n')
        out.write('    }\n}\n')


if __name__ == '__main__':
    main()
