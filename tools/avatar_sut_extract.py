"""Extrai texturas SUT reais (por path_id) de out/assets/resources.assets para PNG local.
Entrada: out/assets/avatar-resources.json (path -> file/path_id, gerado por avatar_bundle_inventory.py).
Saida: out/sut-extract/<item>/<template>__<path_id>.png (ambos path_ids por template, para
comparar e escolher o util - a mesma pasta SUT referencia 2 path_ids por template).
Uso: tools/venv/bin/python tools/avatar_sut_extract.py <prefixo1> [<prefixo2> ...]
"""
import json
import pathlib
import sys

ROOT = pathlib.Path(__file__).resolve().parents[1]
OUT = ROOT / 'out/sut-extract'
OUT.mkdir(parents=True, exist_ok=True)

import UnityPy

prefixes = sys.argv[1:]
if not prefixes:
    raise SystemExit('informe ao menos um prefixo de path SUT (ex.: sutsystem/skins/character/shirt/shirt_formal/shirt_formal_1/)')

with open(ROOT / 'out/assets/avatar-resources.json') as f:
    refs = json.load(f)

wanted = [r for r in refs if any(r['path'].startswith(p) for p in prefixes)]
if not wanted:
    raise SystemExit('nenhuma referencia encontrada para os prefixos informados')
print('referencias encontradas:', len(wanted))

env = UnityPy.load(str(ROOT / 'out/assets/resources.assets'))
by_path_id = {obj.path_id: obj for obj in env.objects if obj.type.name == 'Texture2D'}
print('Texture2D no resources.assets:', len(by_path_id))

exported = 0
for ref in wanted:
    obj = by_path_id.get(ref['path_id'])
    if obj is None:
        print('AUSENTE path_id', ref['path_id'], ref['path'])
        continue
    data = obj.read()
    item_dir = OUT / pathlib.PurePosixPath(ref['path']).parent.name
    item_dir.mkdir(parents=True, exist_ok=True)
    template = pathlib.PurePosixPath(ref['path']).name
    out_path = item_dir / f"{template}__{ref['path_id']}.png"
    data.image.save(out_path)
    print('OK', ref['path'], ref['path_id'], data.image.size, '->', out_path)
    exported += 1

print('total exportado:', exported)
