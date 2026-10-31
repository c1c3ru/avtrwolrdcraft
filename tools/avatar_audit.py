"""Auditoria retomavel, somente leitura dos assets: atlas, PNGs, presets e skins reais.
Nao interpreta o binario Spine em Python nem declara gameplay implementado.
Use --inventory com o JSON produzido pelo probe Unity; sem ele essa parte fica pendente.
"""
import argparse
from collections import Counter, defaultdict
import hashlib
import json
from pathlib import Path
import struct

ROOT = Path(__file__).resolve().parents[1]


def sha256(path):
    digest = hashlib.sha256()
    with path.open('rb') as source:
        for block in iter(lambda: source.read(1024 * 1024), b''):
            digest.update(block)
    return digest.hexdigest()


def png_size(path):
    with path.open('rb') as source:
        header = source.read(24)
    if header[:8] != b'\x89PNG\r\n\x1a\n' or header[12:16] != b'IHDR':
        raise ValueError('PNG invalido: ' + str(path))
    return struct.unpack('>II', header[16:24])


def atlas_pages(path):
    # Cada pagina comeca apos linha vazia; regioes internas nao iniciam pagina.
    pages = []
    current = None
    next_page = True
    for raw in path.read_text(encoding='utf-8-sig').splitlines():
        line = raw.strip()
        if not line:
            next_page = True
            continue
        if next_page:
            current = {'name': line, 'size': None}
            pages.append(current)
            next_page = False
        elif line.startswith('size:') and current['size'] is None:
            current['size'] = [int(v) for v in line.split(':', 1)[1].split(',')]
    if not pages or any(p['size'] is None for p in pages):
        raise ValueError('Atlas sem dimensoes de paginas; auditar formato antes de continuar')
    return pages


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--assets', type=Path, default=ROOT / 'assets')
    parser.add_argument('--inventory', type=Path, default=ROOT / 'out/avatar-spine-inventory.json')
    parser.add_argument('--output', type=Path, default=ROOT / 'out/avatar-pipeline/audit.json')
    args = parser.parse_args()
    inputs = args.assets / 'spine_textasset/TextAsset'
    atlas = inputs / 'Avatar_Spine.atlas_109005.txt'
    skeleton = inputs / 'Avatar_Spine.skel_108595.txt'
    presets_path = inputs / 'PremadeCharactersJson_109356.txt'
    for path in (atlas, skeleton, presets_path):
        if not path.is_file():
            parser.error('Entrada ausente: ' + str(path))
    index = defaultdict(list)
    for path in (args.assets / 'textures_png/Texture2D').glob('*.png'):
        name, separator, path_id = path.stem.rpartition('_')
        if separator and path_id.isdigit():
            index[name.casefold()].append(path)
    if not index:
        parser.error('Nenhum PNG extraido encontrado')
    pages = atlas_pages(atlas)
    counts = Counter()
    page_results = []
    for page in pages:
        candidates = []
        for path in index[Path(page['name']).stem.casefold()]:
            if list(png_size(path)) == page['size']:
                candidates.append(str(path.relative_to(args.assets)))
        status = 'missing' if not candidates else ('unique' if len(candidates) == 1 else 'ambiguous')
        counts[status] += 1
        page_results.append({**page, 'status': status, 'candidates': candidates})
    presets = json.loads(presets_path.read_text())['AvatarSpineDatas']
    report = {
        'status': 'inventory_only_not_gameplay',
        'sources': [{'path': str(p), 'bytes': p.stat().st_size, 'sha256': sha256(p)} for p in (skeleton, atlas, presets_path)],
        'atlas': {'pages': len(pages), 'resolution_counts': dict(counts), 'details': page_results},
        'presets': {'all_types': len(presets)},
        'limitations': ['Nome e dimensoes nao comprovam identidade da textura.',
                        'Candidatos ambiguos nao foram escolhidos automaticamente.',
                        'Isto nao valida GPU, Android, coloração dupla ou personalizacao jogavel.'],
    }
    if args.inventory.is_file():
        inv = json.loads(args.inventory.read_text())
        skins = {r['name'] for r in inv['skins']}
        characters = [p for p in presets if p.get('SpineType') == 1]
        refs = [s['SkinName'] for p in characters for s in p['SkinsData']]
        missing = Counter(s for s in refs if s not in skins)
        report['skeleton'] = {k: inv[k] for k in ('version', 'bones', 'slots', 'pages', 'regions')}
        report['skeleton'].update(skins=len(skins), animations=len(inv['animations']), inventory_sha256=sha256(args.inventory))
        report['presets'].update(character_presets=len(characters), skin_references=len(refs),
                                 unresolved_skin_references=sum(missing.values()), unresolved_names=dict(missing))
    else:
        report['limitations'].append('Inventario Unity ausente: comparacao de skins pendente.')
    args.output.parent.mkdir(parents=True, exist_ok=True)
    temporary = args.output.with_suffix('.json.tmp')
    temporary.write_text(json.dumps(report, indent=2, ensure_ascii=False))
    temporary.replace(args.output)
    print(json.dumps({'report': str(args.output), 'pages': len(pages), 'resolution': dict(counts),
                      'skin_comparison': 'skeleton' in report, 'gameplay_validated': False}, ensure_ascii=False))
    return 1 if counts['missing'] else 0


if __name__ == '__main__':
    raise SystemExit(main())
