#!/usr/bin/env python3
"""Create a small, auditable SUT avatar asset package without running Unity.

Inputs: ResourceManager JSON rows {path, file, path_id, type?}, the Spine probe
inventory {skins:[{name,pages,...}]}, extracted PNGs and optional atlas metadata.
An --item Category/ID selects the exact resource folder category_id beneath
sutsystem/skins/character. Match each path basename + _<path_id>.png by casefold;
never pick the first candidate. References lacking a PNG are skipped only if
another reference for the SAME resource path resolves a texture (Sprite/Texture
pairs are common). Every retained reference preserves (file,path_id).

Templates are matched by exact casefold of Templates/<resource basename>.
An additional *_p texture without its own template remains unresolved; no
suffix removal or fabricated association is used. PNG IHDR dimensions are
checked against unambiguous atlas page metadata when available.

The manifest includes copied assets, hashes, original references, templates,
pages, skipped references and unresolved dependencies. Exit 0 means static
package dependencies resolved, NOT a rendered or implemented game. Exit 1 means
partial/unresolved dependencies (confirmed assets are still packaged); exit 2
means invalid input/CLI/IO failure. --force overwrites only generated manifest
and matching asset filenames; it never removes arbitrary existing files.

Example:
  python tools/avatar_package.py --item Shirt_Formal/1 \\
    --item Bottom_Special/6 --item Legs_Shoes/41
"""
import argparse
import hashlib
import json
from pathlib import Path, PurePosixPath
import re
import shutil
import struct
import sys

ROOT = Path(__file__).resolve().parents[1]
PNG_SIGNATURE = b"\x89PNG\r\n\x1a\n"


def digest(path):
    hasher = hashlib.sha256()
    with path.open('rb') as source:
        for block in iter(lambda: source.read(1024 * 1024), b''):
            hasher.update(block)
    return hasher.hexdigest()


def display_path(path):
    try:
        return str(path.resolve().relative_to(ROOT))
    except ValueError:
        return str(path.resolve())


def png_size(path):
    with path.open('rb') as source:
        header = source.read(24)
    if len(header) != 24 or header[:8] != PNG_SIGNATURE or header[12:16] != b'IHDR':
        raise ValueError('Not a PNG with IHDR: ' + str(path))
    width, height = struct.unpack('>II', header[16:24])
    if not width or not height:
        raise ValueError('Invalid PNG dimensions: ' + str(path))
    return [width, height]


def atlas_pages(path):
    if not path.is_file():
        return {}, ['Atlas metadata unavailable: ' + display_path(path)]
    lines = path.read_text(encoding='utf-8-sig').splitlines()
    pages = {}
    for index, line in enumerate(lines[:-1]):
        name = line.strip()
        following = lines[index + 1].strip()
        if name and following.startswith('size:'):
            match = re.fullmatch(r'size:\s*(\d+)\s*,\s*(\d+)\s*', following)
            if match:
                pages.setdefault(name.casefold(), []).append([int(v) for v in match.groups()])
    return pages, []


def resolve_template(stem, templates):
    candidates = templates.get(('Templates/' + stem).casefold(), [])
    if len(candidates) == 1:
        return candidates[0], None
    if len(candidates) > 1:
        return None, 'Ambiguous template: Templates/' + stem
    if stem.casefold().endswith('_p'):
        return None, 'Additional _p layer has no exact template; association remains unresolved'
    return None, 'No exact template: Templates/' + stem


def checked_resource_rows(data):
    if not isinstance(data, list):
        raise ValueError('Resource inventory must be a JSON array')
    for row in data:
        if not isinstance(row, dict) or not all(key in row for key in ('path', 'file', 'path_id')):
            raise ValueError('Each resource row must contain path, file and path_id')
        if not isinstance(row['path'], str) or not isinstance(row['file'], str):
            raise ValueError('Resource path/file must be strings')
        if not isinstance(row['path_id'], int) or isinstance(row['path_id'], bool):
            raise ValueError('Resource path_id must be an integer')
    return data


def main(argv=None):
    parser = argparse.ArgumentParser(description=__doc__, formatter_class=argparse.RawDescriptionHelpFormatter)
    parser.add_argument('--item', action='append', required=True, metavar='CATEGORY/ID')
    parser.add_argument('--output', type=Path, default=ROOT / 'out/avatar-pipeline/package')
    parser.add_argument('--force', action='store_true')
    parser.add_argument('--resources', type=Path, default=ROOT / 'out/assets/avatar-resources.json')
    parser.add_argument('--inventory', type=Path, default=ROOT / 'out/avatar-spine-inventory.json')
    parser.add_argument('--textures', type=Path, default=ROOT / 'assets/textures_png/Texture2D')
    parser.add_argument('--atlas', type=Path, default=ROOT / 'assets/spine_textasset/TextAsset/Avatar_Spine.atlas_109005.txt')
    args = parser.parse_args(argv)
    try:
        output = args.output.resolve()
        texture_root = args.textures.resolve()
        if output == texture_root or output in texture_root.parents or texture_root in output.parents:
            raise ValueError('Output must be separate from the source texture directory')
        if output.exists() and (not output.is_dir() or (any(output.iterdir()) and not args.force)):
            raise ValueError('Output exists and is not empty; use --force to overwrite generated files')
        if not texture_root.is_dir():
            raise ValueError('Texture directory unavailable: ' + str(texture_root))
        rows = checked_resource_rows(json.loads(args.resources.read_text(encoding='utf-8')))
        inventory = json.loads(args.inventory.read_text(encoding='utf-8'))
        if not isinstance(inventory, dict) or not isinstance(inventory.get('skins'), list):
            raise ValueError('Spine inventory must contain a skins array')
        templates = {}
        for skin in inventory['skins']:
            if not isinstance(skin, dict) or not isinstance(skin.get('name'), str) or not isinstance(skin.get('pages'), list):
                raise ValueError('Invalid skin inventory row')
            templates.setdefault(skin['name'].casefold(), []).append(skin)
        pages, warnings = atlas_pages(args.atlas)
        pngs = {}
        for path in texture_root.rglob('*'):
            if path.is_file() and path.suffix.casefold() == '.png':
                pngs.setdefault(path.name.casefold(), []).append(path)
        inputs = {}
        for name, path in [('resources', args.resources), ('spine_inventory', args.inventory), ('atlas', args.atlas)]:
            if path.is_file():
                inputs[name] = {'path': display_path(path), 'sha256': digest(path)}
        manifest = {'schema_version': 1, 'status': 'unresolved',
                    'validation': 'Static resource/template matching only; no rendering or gameplay validated',
                    'inputs': inputs, 'warnings': warnings, 'items': [], 'assets': []}
        copy_sources = {}
        errors = 0
        for item in dict.fromkeys(args.item):
            if not re.fullmatch(r'[A-Za-z0-9_]+/[A-Za-z0-9_]+', item):
                raise ValueError('Expected CATEGORY/ID with letters, digits or underscores: ' + item)
            category, identifier = item.split('/')
            category_lower = category.casefold()
            folder = (category_lower + '_' + identifier).casefold()
            category_parts = category_lower.split('_')
            if category_parts[0] == 'accessories' and len(category_parts) >= 2:
                prefix = ('sutsystem/skins/character/accessories/accessories_' +
                          category_parts[1] + '/' + category_lower + '/' + folder + '/')
            else:
                prefix = ('sutsystem/skins/character/' + category_parts[0] + '/' +
                          category_lower + '/' + folder + '/')
            result = {'item': item, 'resource_folder': folder, 'bindings': [], 'skipped': [], 'unresolved': []}
            manifest['items'].append(result)
            groups = {}
            for row in rows:
                normalized = row['path'].replace('\\', '/').strip('/').casefold()
                # ResourceManager paths are relative to Resources, occasionally with a leading prefix.
                if normalized.startswith(prefix) or ('/' + prefix) in normalized:
                    groups.setdefault(normalized, []).append(row)
            if not groups:
                result['unresolved'].append({'reason': 'No resource paths for exact item folder'})
                errors += 1
                continue
            for resource_path, references in sorted(groups.items()):
                stem = PurePosixPath(resource_path).stem
                matches, absent, seen = [], [], set()
                for row in references:
                    key = (row['file'], row['path_id'])
                    if key in seen:
                        continue
                    seen.add(key)
                    reference = {'file': row['file'], 'path_id': row['path_id'], 'path': row['path']}
                    if row.get('type') and row['type'] != 'Texture2D':
                        absent.append(dict(reference, reason='Non-Texture2D reference: ' + row['type']))
                        continue
                    candidates = pngs.get((stem + '_' + str(row['path_id']) + '.png').casefold(), [])
                    if len(candidates) == 1:
                        matches.append((reference, candidates[0]))
                    elif not candidates:
                        absent.append(dict(reference, reason='No matching extracted PNG; may be a Sprite reference'))
                    else:
                        result['unresolved'].append(dict(reference, reason='Multiple matching PNGs',
                                                         candidates=[display_path(p) for p in candidates]))
                        errors += 1
                if not matches:
                    result['unresolved'].append({'path': resource_path, 'reason': 'No uniquely confirmed texture for this path', 'references': absent})
                    errors += 1
                    continue
                result['skipped'].extend(absent)
                if len(matches) > 1:
                    result['unresolved'].append({'path': resource_path, 'reason': 'Multiple texture references for one path',
                                                 'references': [ref for ref, _ in matches]})
                    errors += 1
                    continue
                reference, source = matches[0]
                source_hash = digest(source)
                target = Path('assets') / (source_hash[:16] + '-' + source.name)
                copy_sources[str(target)] = source
                actual_size = png_size(source)
                template, reason = resolve_template(stem, templates)
                binding = {'resource': reference, 'asset': str(target), 'source': display_path(source),
                           'sha256': source_hash, 'png_dimensions': actual_size,
                           'template': template['name'] if template else None,
                           'pages': template['pages'] if template else [], 'atlas_dimensions': {},
                           'dimension_validation': 'unavailable'}
                result['bindings'].append(binding)
                if reason:
                    result['unresolved'].append({'path': resource_path, 'asset': str(target), 'reason': reason})
                    errors += 1
                if template:
                    expected = []
                    for page in template['pages']:
                        dimensions = pages.get(page.casefold(), [])
                        if len(dimensions) == 1:
                            binding['atlas_dimensions'][page] = dimensions[0]
                            expected.append(dimensions[0])
                    if len(template['pages']) == 1 and len(expected) == 1:
                        match = actual_size == expected[0]
                        binding['dimension_validation'] = 'matched' if match else 'mismatch'
                        if not match:
                            result['unresolved'].append({'path': resource_path, 'reason': 'PNG dimensions differ from exact template atlas page',
                                                         'actual': actual_size, 'expected': expected[0]})
                            errors += 1
                    else:
                        binding['dimension_validation'] = 'unavailable_or_multiple_pages'
        for relative, source in sorted(copy_sources.items()):
            manifest['assets'].append({'path': relative, 'source': display_path(source),
                                       'sha256': digest(source), 'bytes': source.stat().st_size})
        if not copy_sources:
            errors += 1
            manifest['warnings'].append('No items had uniquely resolved textures')
        manifest['status'] = 'resolved-static' if errors == 0 else 'partial-unresolved'
        manifest['unresolved_count'] = errors
        (output / 'assets').mkdir(parents=True, exist_ok=True)
        for relative, source in copy_sources.items():
            destination = output / relative
            shutil.copyfile(source, destination)
            if digest(destination) != digest(source):
                raise OSError('Copied asset hash mismatch: ' + str(destination))
        manifest_path = output / 'manifest.json'
        manifest_path.write_text(json.dumps(manifest, indent=2, ensure_ascii=False) + '\n', encoding='utf-8')
        print(f"{manifest['status']}: {len(manifest['items'])} items, {len(copy_sources)} PNGs, {errors} unresolved dependencies")
        print('Manifest:', manifest_path)
        return 0 if errors == 0 else 1
    except (OSError, ValueError, KeyError, TypeError) as error:
        print('avatar_package:', error, file=sys.stderr)
        return 2


if __name__ == '__main__':
    sys.exit(main())
