#!/usr/bin/env python3
"""Classify every Spine animation name by the kind of evidence that the game refers to it.

Extends tools/recon_animation_coverage.py with the strings recovered from objects the typed dump could not decode
(tools/recon_undecoded_strings.py) and with an explicit, separately counted "authoring content" class.

Classes, in priority order (a name gets the first that applies):
  exact_decoded        the exact name is in the CA catalog, in a code string literal or in a decoded serialized field
  exact_undecoded      the exact name (>= 6 chars) is a string inside the raw bytes of an object of a class that failed to decode
  exact_undecoded_weak same, but shorter than 6 chars: can occur by chance, so it is reported apart
  authoring            by naming convention only (dot-prefixed folder, Unused/, *_TEST ...)
  prefix_only          a code literal ending in '/' or '_' prefixes the name; the name is probably built at run time
  absent_folder        no exact link and the folder never appears as a literal, decoded/raw string or metadata identifier
  unreferenced         none of the above

authoring and absent_folder classify a name as probable non-use; they are NOT evidence either way. "classified" in the summary
means every class except unreferenced.
"""
from __future__ import annotations

import argparse
import collections
import gzip
import json
import re
import struct
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
AUTHORING = re.compile(r'(^|/)\.|(^|/)Unused(/|$)|[_ -]TEST($|[_ /(-])|(^|/)Test_|_Test(_|$)|Template|Technical', re.I)
WEAK_LENGTH = 6


def is_authoring(name: str) -> bool:
    return bool(AUTHORING.search(name)) or name.startswith('*')


def ca_catalog_names(catalog: dict) -> set[str]:
    names = set()
    for handler in catalog['handlers']:
        prefix = handler['spineType'] in (1, 2, 13)
        for config in handler['configs']:
            folder = config['folderNameOverride'] or handler['folderName']
            name = config['name'] if config['isNameFullAnimationName'] else (('CA/' if prefix else '') + folder + '/' + config['name'])
            names.update({name, name.replace('CA/', '', 1), name + '__Sitting'})
            for extra in (config['alternateIdleAnimation'], config['preAnimation']):
                if extra:
                    names.update({extra, ('CA/' if prefix else '') + folder + '/' + extra})
        if handler['lockedAnimation']:
            names.add(handler['lockedAnimation'])
    return names


def decoded_strings(mb_dir: Path) -> set[str]:
    found = set()

    def walk(value):
        if isinstance(value, str):
            if len(value) > 2:
                found.add(value)
        elif isinstance(value, list):
            for item in value:
                walk(item)
        elif isinstance(value, dict):
            for item in value.values():
                walk(item)

    for path in sorted(mb_dir.glob('*.jsonl.gz')):
        with gzip.open(path, 'rt') as handle:
            for line in handle:
                walk(json.loads(line))
    return found


def code_literals(metadata: bytes) -> set[str]:
    table, size = struct.unpack_from('<II', metadata, 8)
    data, _ = struct.unpack_from('<II', metadata, 16)
    found = set()
    for i in range(size // 8):
        length, index = struct.unpack_from('<II', metadata, table + i * 8)
        found.add(metadata[data + index:data + index + length].decode('utf-8', 'replace'))
    return found


def classify(names, catalog_names, literals, decoded, raw_by_string, folder_seen=lambda folder: True):
    """raw_by_string: string -> sorted list of classes whose undecoded objects hold it.
    folder_seen(folder) -> True when the folder (or one of its path segments) appears anywhere as a string or identifier."""
    prefixes = [s for s in literals if (s.endswith('/') or s.endswith('_')) and 3 <= len(s) <= 40]
    result = {}
    for name in sorted(names):
        folder = name.rpartition('/')[0]
        if name in catalog_names or name in literals or name in decoded:
            result[name] = ('exact_decoded', [])
        elif name in raw_by_string and len(name) >= WEAK_LENGTH:
            result[name] = ('exact_undecoded', raw_by_string[name])
        elif name in raw_by_string:
            result[name] = ('exact_undecoded_weak', raw_by_string[name])
        elif is_authoring(name):
            result[name] = ('authoring', [])
        elif any(name.startswith(p) for p in prefixes):
            result[name] = ('prefix_only', [])
        elif folder and not folder_seen(folder):
            result[name] = ('absent_folder', [])
        else:
            result[name] = ('unreferenced', [])
    return result


def make_folder_seen(literals, decoded, raw_strings, metadata: bytes):
    """A folder counts as seen when any segment of >= 4 chars is a literal, a decoded or raw string, or a metadata identifier."""
    def seen(folder: str) -> bool:
        for segment in [folder] + folder.split('/'):
            if len(segment) >= 4 and (segment in literals or segment in decoded or segment in raw_strings
                                      or metadata.find(b'\x00' + segment.encode() + b'\x00') >= 0):
                return True
        return False
    return seen


def summarize(result: dict) -> dict:
    counts = collections.Counter(kind for kind, _ in result.values())
    total = len(result)
    classes = collections.Counter(c for kind, cs in result.values() if kind == 'exact_undecoded' for c in cs)
    unresolved = counts['unreferenced']
    return {'names': total, 'counts': dict(counts),
            'percent': {k: round(100 * v / total, 2) for k, v in counts.items()},
            'with_exact_evidence_percent': round(100 * (counts['exact_decoded'] + counts['exact_undecoded']) / total, 2),
            'with_any_link_percent': round(100 * (total - counts['authoring'] - counts['absent_folder'] - unresolved) / total, 2),
            'classified_percent': round(100 * (total - unresolved) / total, 2),
            'unresolved_percent': round(100 * unresolved / total, 2),
            'reading': {'classified': 'every class except unreferenced; authoring and absent_folder are classifications as probable '
                                      'non-use, NOT evidence of use',
                        'weak_short_hits': sorted(n for n, (kind, _) in result.items() if kind == 'exact_undecoded_weak')},
            'undecoded_classes_that_explain_names': dict(classes.most_common())}


def main(argv=None) -> int:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--root', type=Path, default=ROOT, help='checkout with out/ (skel-dump, mb, il2cpp metadata)')
    parser.add_argument('--catalog', type=Path, default=ROOT / 'client/AvatarWorldClient/Assets/Resources/ContextualAnimations/ca-catalog.json')
    parser.add_argument('--undecoded', type=Path, required=True, help='output of tools/recon_undecoded_strings.py')
    parser.add_argument('--output', type=Path, default=ROOT / 'reports/recon/animation_orphans.json')
    args = parser.parse_args(argv)
    skeletons = collections.defaultdict(set)
    for line in (args.root / 'out/recon/tasks/T032/skel-dump.jsonl').open():
        row = json.loads(line)
        skeletons[row['file'].split('.skel')[0]].update(a['Name'] for a in row.get('animations', []))
    names = set().union(*skeletons.values())
    raw = collections.defaultdict(set)
    for cls, info in json.loads(args.undecoded.read_text())['classes'].items():
        for text in info['strings']:
            raw[text].add(cls)
    metadata = (args.root / 'out/recon/il2cpp/global-metadata.dat').read_bytes()
    literals, decoded = code_literals(metadata), decoded_strings(args.root / 'out/mb')
    result = classify(names, ca_catalog_names(json.loads(args.catalog.read_text(encoding='utf-8'))), literals, decoded,
                      {k: sorted(v) for k, v in raw.items()}, make_folder_seen(literals, decoded, set(raw), metadata))
    by_skeleton = {}
    for skeleton, owned in sorted(skeletons.items()):
        counts = collections.Counter(result[n][0] for n in owned)
        if counts.get('unreferenced') or counts.get('authoring'):
            by_skeleton[skeleton] = dict(counts)
    report = {'schema_version': 1, 'summary': summarize(result), 'skeletons_with_open_names': by_skeleton,
              'unreferenced': [n for n, (kind, _) in result.items() if kind == 'unreferenced'],
              'absent_folder': [n for n, (kind, _) in result.items() if kind == 'absent_folder'],
              'authoring': [n for n, (kind, _) in result.items() if kind == 'authoring'],
              'exact_undecoded': {n: cs for n, (kind, cs) in result.items() if kind == 'exact_undecoded'}}
    args.output.parent.mkdir(parents=True, exist_ok=True)
    args.output.write_text(json.dumps(report, indent=1, ensure_ascii=False) + '\n', encoding='utf-8')
    print(json.dumps(report['summary'], ensure_ascii=False))
    return 0


if __name__ == '__main__':
    raise SystemExit(main())
