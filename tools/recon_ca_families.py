"""Inventory of the contextual-animation handler classes: the full subclass closure of LevelCAHandlerBase.

Reads the Cpp2IL declarations only. A declaration shows inheritance, not behaviour; use it to find *which* classes exist
and how they group, then probe the ones that matter. Override the dump with RECON_DUMP_ROOT.
"""
import argparse
import json
import os
import re
from collections import defaultdict
from pathlib import Path

ROOT = Path(__file__).resolve().parent.parent
DEFAULT_DUMP = ROOT / 'out/cpp2il/DiffableCs/Assembly-CSharp'
CLASS = re.compile(r'^(?:\[[^\]]*\]\s*)*(?:public|internal)(?: (?:abstract|sealed|static))* class ([\w`<>]+)(?: : ([^{]+))?$')
BASE = 'LevelCAHandlerBase'
FAMILY_WORDS = ('Pair', 'Carrier', 'OnBone', 'DropArea', 'Item', 'Parent', 'Skin', 'Toddler', 'Baby', 'Dog', 'Cat', 'Horse',
                'Fish', 'Bird', 'Sit', 'Sleep', 'Eat', 'Drink')


def parents(dump):
    result, files = {}, {}
    for path in sorted(dump.rglob('*.cs')):
        for line in path.read_text(encoding='utf-8').splitlines():
            match = CLASS.match(line)
            if match and match.group(2):
                result[match.group(1)] = [b.strip().split('<')[0] for b in match.group(2).split(',')]
                files[match.group(1)] = str(path.relative_to(dump))
    return result, files


def closure(parent, root):
    found, frontier = set(), {root}
    while frontier:
        found |= frontier - {root}
        frontier = {c for c, bases in parent.items() if frontier & set(bases)} - found
    return found


def build(dump):
    parent, files = parents(dump)
    handlers = closure(parent, BASE)
    families = defaultdict(list)
    for name in sorted(handlers):
        words = [w for w in FAMILY_WORDS if w in name] or ['Other']
        families[words[0]].append(name)
    return {
        'schema_version': 1, 'scope': 'declared inheritance only',
        'root': BASE, 'handlers': len(handlers),
        'direct_children': sorted(c for c, bases in parent.items() if BASE in bases),
        'by_family_word': {k: len(v) for k, v in sorted(families.items(), key=lambda kv: -len(kv[1]))},
        'namespaces': sorted({str(Path(files[n]).parent) for n in handlers}),
        'classes': {n: {'bases': parent[n], 'file': files[n]} for n in sorted(handlers)},
    }


if __name__ == '__main__':
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--dump', type=Path, default=Path(os.environ.get('RECON_DUMP_ROOT') or DEFAULT_DUMP))
    parser.add_argument('--output', type=Path, default=ROOT / 'reports/recon/ca_handler_families.json')
    args = parser.parse_args()
    if not args.dump.is_dir():
        raise SystemExit(f'dump not found: {args.dump} (set RECON_DUMP_ROOT)')
    report = build(args.dump)
    args.output.parent.mkdir(parents=True, exist_ok=True)
    args.output.write_text(json.dumps(report, indent=1, ensure_ascii=False) + '\n', encoding='utf-8')
    print(json.dumps({'handlers': report['handlers'], 'direct_children': len(report['direct_children']),
                      'families': report['by_family_word']}))
