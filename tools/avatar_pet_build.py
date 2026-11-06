#!/usr/bin/env python3
"""Gera os dados dos pets simples (variantes prontas): Bird, Chicken, Fish, Hamster, Lizard, Rabbit, Snake, Turtle.

Cada variante e um skin completo do esqueleto (ex.: Rabbit_A_1). Para cada uma resolve-se attachment -> regiao do atlas ->
pagina -> textura unica por nome+dimensoes (nao ha paths SUT para estes pets). Variantes com alguma pagina sem textura unica
ficam de fora. O skin "default" (anexos de emocao/efeitos) e carregado em melhor esforco.

Entradas: out/assets/{Texture2D,TextAsset}, out/recon/tasks/T034/pets/<Especie>.json (dump do esqueleto; ver docs/AVATAR_KINDS.md).
Saidas: Resources/AvatarSpine/Pets/<Especie>/{Spine.atlas.txt,Spine.skel.bytes,pet.json}, PNGs em Resources/AvatarSpine/Clothing
e Scripts/Core/Avatar/PetCatalogData.cs.
uso: tools/venv/bin/python tools/avatar_pet_build.py
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
PETS_DIR = UNITY / 'Resources/AvatarSpine/Pets'
DATA_CS = UNITY / 'Scripts/Core/Avatar/PetCatalogData.cs'
TEXTURES = ROOT / 'out/assets/Texture2D'
TEXT = ROOT / 'out/assets/TextAsset'
DUMPS = ROOT / 'out/recon/tasks/T034/pets'
SPECIES = ['Rabbit', 'Hamster', 'Bird', 'Chicken', 'Turtle', 'Lizard', 'Snake', 'Fish']
IDLES = ['General/Chilling', 'General/Blinking']


def png_size(path):
    with open(path, 'rb') as fh:
        header = fh.read(24)
    return struct.unpack('>II', header[16:24])


def natural(value):
    return [int(p) if p.isdigit() else p for p in re.split(r'(\d+)', value)]


def parse_atlas(path):
    lines = path.read_text(encoding='utf-8-sig').splitlines()
    pages, regions, current = {}, {}, None
    for i in range(len(lines) - 1):
        line = lines[i].strip()
        if line.lower().endswith('.png') and lines[i + 1].strip().startswith('size:'):
            m = re.fullmatch(r'size:\s*(\d+)\s*,\s*(\d+)\s*', lines[i + 1].strip())
            current = line[:-4]
            pages[current.casefold()] = (current, (int(m.group(1)), int(m.group(2))))
        elif current and line and ':' not in line and not line.lower().endswith('.png'):
            regions[line] = current
    return pages, regions


def main():
    by_name = collections.defaultdict(list)
    for f in TEXTURES.iterdir():
        m = re.match(r'(.*)_(\d+)\.png$', f.name)
        if m:
            by_name[m.group(1).casefold()].append((f.name, int(m.group(2))))
    meta_template = next(iter(CLOTHING.glob('*.png.meta'))).read_text(encoding='utf-8')

    def ensure_meta(path):
        meta = Path(str(path) + '.meta')
        if meta.exists():
            return
        guid = hashlib.sha256(('avatarworld-re:' + path.relative_to(UNITY).as_posix()).encode()).hexdigest()[:32]
        text = re.sub(r'^guid:\s*[0-9a-fA-F]{32}\s*$', 'guid: ' + guid, meta_template, count=1, flags=re.M)
        meta.write_text('\n'.join(line.rstrip() for line in text.splitlines()) + '\n', encoding='utf-8')

    result = {}
    for species in SPECIES:
        atlas_file = next(TEXT.glob(f'Pet_{species}_Spine.atlas_*.txt'))
        skel_file = next(TEXT.glob(f'Pet_{species}_Spine.skel_*.txt'))
        pages, regions = parse_atlas(atlas_file)
        dump = json.loads((DUMPS / f'{species}.json').read_text(encoding='utf-8'))
        skins = {s['name']: s for s in dump['skins']}

        def unique_texture(page):
            name, size = pages[page.casefold()]
            cands = [x for x in by_name.get(name.casefold(), []) if png_size(TEXTURES / x[0]) == size]
            return cands[0] if len(cands) == 1 else None

        def pieces_of(skin_name, strict):
            pieces, seen = [], set()
            for att in skins[skin_name]['atts']:
                page = regions.get(att['path'] or '')
                if page is None or page in seen:
                    if page is None and strict:
                        return None
                    continue
                seen.add(page)
                found = unique_texture(page)
                if found is None:
                    if strict:
                        return None
                    continue
                filename, pid = found
                out_name = f'{page.casefold()}__{pid}.png'
                dest = CLOTHING / out_name
                if not dest.exists():
                    shutil.copyfile(TEXTURES / filename, dest)
                ensure_meta(dest)
                pieces.append({'template': 'Templates/' + page, 'file': out_name, 'skin': skin_name})
            return pieces

        variants = []
        dropped = []
        for name in sorted((n for n in skins if re.fullmatch(species + r'_[A-Z]_\d+', n)), key=natural):
            pieces = pieces_of(name, True)
            if pieces:
                variants.append({'id': name.lower(), 'pieces': pieces})
            else:
                dropped.append(name)
        base = pieces_of('default', False)
        idle = next((a for a in IDLES if a in dump['animations']), dump['animations'][0])
        out_dir = PETS_DIR / species
        out_dir.mkdir(parents=True, exist_ok=True)
        shutil.copyfile(atlas_file, out_dir / 'Spine.atlas.txt')
        shutil.copyfile(skel_file, out_dir / 'Spine.skel.bytes')
        (out_dir / 'pet.json').write_text(json.dumps({'species': species, 'idle': idle, 'basePieces': base, 'variants': variants}, indent=1), encoding='utf-8')
        result[species] = [v['id'] for v in variants]
        print(species, 'variantes', len(variants), 'descartadas', dropped, 'idle', idle, 'base', len(base))

    with open(DATA_CS, 'w', encoding='utf-8') as out:
        out.write('// <auto-generated> por tools/avatar_pet_build.py - nao editar a mao. </auto-generated>\n')
        out.write('using System.Collections.Generic;\n\nnamespace AvatarWorld.Core.Avatar\n{\n')
        out.write('    /// <summary>Pets simples (variantes prontas): especie -> ids de variante; cada variante e um skin completo do esqueleto Pet_&lt;Especie&gt;_Spine.</summary>\n')
        out.write('    public static class PetCatalogData\n    {\n')
        out.write('        public static readonly string[] Species = { ' + ', '.join(f'"{s}"' for s in SPECIES) + ' };\n\n')
        out.write('        public static readonly Dictionary<string, string[]> Variants = new Dictionary<string, string[]>\n        {\n')
        for species, ids in result.items():
            out.write(f'            {{ "{species}", new[] {{ ' + ', '.join(f'"{i}"' for i in ids) + ' } },\n')
        out.write('        };\n    }\n}\n')


if __name__ == '__main__':
    main()
