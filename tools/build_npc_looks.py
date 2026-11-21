#!/usr/bin/env python3
"""Converte a aparencia dos NPCs (PremadeCharactersJson) em looks do cliente e lista os itens extras do manifesto.

Entradas: out/assets/TextAsset/*.txt com "AvatarSpineDatas" (ID, SkinsData[SkinName, ColorA/B]), out/recon/interior_npcs.json
(posicoes por interior; tools/recon_interior_npcs.py), Resources/AvatarSpine/palettes.json e pack_texture_coverage.make_resolver.
Saidas: Resources/Interiors/<chave>/<chave>_npcs.json  ({"npcs":[{id,x,y,look}]}) e out/recon/npc_hidden_items.json
(ids que precisam de PNG no manifesto mas NAO entram nas listas do editor; usado por avatar_catalog_build.py --hidden-items).
Cada campo do look e um id de item, "none" (sem peca) ou o padrao; cores viram o indice mais proximo nas paletas oficiais.
Pecas extras sem categoria no editor (bochechas, complexion, meias, bolsas, pulseiras, piercing, aneis, luvas, mascara, barba)
vao em look.extras = [{Id, Tint:[r,g,b]|[]}] (chaves iguais aos campos de ExtraItem: JsonUtility diferencia maiusculas), aplicadas como skins soltas no render do NPC (tinta = Colors[0]/255 quando existe).
uso: python3 tools/build_npc_looks.py
"""
import glob, hashlib, json, re, sys
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
UNITY = ROOT / 'client/AvatarWorldClient/Assets'
sys.path.insert(0, str(Path(__file__).resolve().parent))
from pack_texture_coverage import make_resolver  # noqa: E402

FIELDS = ['Hair', 'HairBack', 'Shirt', 'Bottom', 'Shoes', 'Accessory', 'Mouth', 'Eyebrows', 'Hat', 'Jacket']


def item_for(skin_name):
    """SkinName do original -> (campo do look, id do item) ou None se o cliente nao suporta."""
    prefix, _, rest = skin_name.partition('/')
    p = prefix.lower()
    item = f'{p}_{rest.lower()}'.replace('/', '_')
    if prefix == 'Hair_Front': return 'Hair', skin_name
    if p == 'hair_back': return 'HairBack', item
    if p.startswith('shirt_') or p.startswith('onepiece_'): return 'Shirt', item
    if p.startswith('bottom_'): return 'Bottom', item
    if p == 'legs_shoes': return 'Shoes', item
    if p in ('accessories_face_glasses', 'accessories_body_neck'): return 'Accessory', item
    if p == 'mouth': return 'Mouth', item
    if p == 'eyebrows': return 'Eyebrows', item
    if p.startswith('hat_'): return 'Hat', item
    if p.startswith('jacket_'): return 'Jacket', item
    return None


EXTRA_PREFIXES = ('face_cheeks', 'face_complexion', 'legs_socks', 'accessories_face_piercing', 'accessories_body_bags',
                  'accessories_body_bracelets', 'accessories_body_rings', 'accessories_body_gloves', 'accessories_face_general',
                  'accessories_face_mask', 'hair_facial')


def extra_for(skin_name):
    prefix, _, rest = skin_name.partition('/')
    if prefix.lower() not in EXTRA_PREFIXES: return None
    return f'{prefix.lower()}_{rest.lower()}'.replace('/', '_')


def nearest(rgb, palette):
    return min(range(len(palette)), key=lambda i: sum((a - b) ** 2 for a, b in zip(rgb, palette[i])))


def main():
    pal = json.loads((UNITY / 'Resources/AvatarSpine/palettes.json').read_text())
    skin_pal = [e['display'][:3] for e in pal['skin']]
    eye_pal = [e['colors'][0]['c'][:3] for e in pal['eyes']]
    gen_pal = [e['display'][:3] for e in pal['general']]
    rgb = lambda c: [(c.get('ColorA') or {}).get(k, 1.0) for k in 'rgb']  # noqa: E731
    looks = {}
    for f in glob.glob(str(ROOT / 'out/assets/TextAsset/*.txt')):
        t = open(f, errors='ignore').read()
        if 'AvatarSpineDatas' not in t: continue
        try: d = json.loads(t)
        except ValueError: continue
        for a in d['AvatarSpineDatas']: looks[a['ID']] = a
    resolvable, _ = make_resolver()
    npcs = json.loads((ROOT / 'out/recon/interior_npcs.json').read_text())
    hidden, missing_tex, unsupported = set(), 0, 0
    per_key = {}
    for key, v in npcs.items():
        out = []
        for av in v['avatars']:
            a = looks.get(av['id'])
            if not a or a['SpineType'] != 1: continue  # so adultos/criancas "Character" (SpineType 1); bebes/pets depois
            look = {k: 'none' for k in FIELDS}
            look.update(skinIndex=0, eyesIndex=0, colors=[], extras=[])
            for s in a['SkinsData']:
                name = s['SkinName']
                if name.startswith('Body_Whites'): look['skinIndex'] = nearest(rgb(s), skin_pal)
                elif name.startswith('Eyes/'): look['eyesIndex'] = nearest(rgb(s), eye_pal)
                ex = extra_for(name)
                if ex:
                    if resolvable(ex) == 'ok':
                        c = (s.get('Colors') or [None])[0]
                        tint = [round(c[k] / 255.0, 4) for k in 'rgb'] if c else []
                        look['extras'].append({'Id': ex, 'Tint': tint})
                        hidden.add(('Extra', ex))
                    else: missing_tex += 1
                    continue
                m = item_for(name)
                if not m:
                    unsupported += 1
                    continue
                field, item = m
                if field == 'Accessory' and look['Accessory'] != 'none' and 'glasses' not in item: continue
                if field == 'Hair':
                    ok = True  # Hair_Front/N_Color: validado pelo gerador (skin do esqueleto)
                else:
                    ok = resolvable(item) == 'ok'
                if not ok: missing_tex += 1; continue
                look[field] = item
                hidden.add((field, item))
                if name.lower().endswith('_color'):
                    key_field = 'Hair' if field in ('Hair', 'HairBack') else field
                    look['colors'].append({'Category': key_field, 'Index': nearest(rgb(s), gen_pal)})
            out.append({'id': av['id'], 'x': av['x'], 'y': av['y'], 'look': look})
        per_key[key] = out
        path = UNITY / f'Resources/Interiors/{key}/{key}_npcs.json'
        path.write_text(json.dumps({'npcs': out}))
        meta = path.with_name(path.name + '.meta')
        if not meta.exists():
            tmpl = (UNITY / f'Resources/Interiors/{key}/{key}.json.meta').read_text()
            guid = hashlib.sha256(f'avatarworld-re:Interiors/{key}_npcs'.encode()).hexdigest()[:32]
            meta.write_text(re.sub(r'guid: [0-9a-f]{32}', 'guid: ' + guid, tmpl))
    by_field = {}
    for field, item in sorted(hidden): by_field.setdefault(field, []).append(item)
    (ROOT / 'out/recon/npc_hidden_items.json').write_text(json.dumps(by_field, indent=1))
    print('NPCs:', sum(len(v) for v in per_key.values()), 'em', sum(1 for v in per_key.values() if v), 'interiores')
    print('itens unicos por campo:', {k: len(v) for k, v in by_field.items()}, '| sem textura:', missing_tex, '| categorias sem suporte:', unsupported)


if __name__ == '__main__':
    main()
