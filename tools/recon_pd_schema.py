"""Catalog of the declared persistent-data payload types (the *PD classes and their fields).

Reads the Cpp2IL declarations only (Assembly-CSharp/**/PersistentData/*.cs). A declaration shows field names, types
and offsets; it does not show how a value is produced, serialized or migrated. Override the dump with RECON_DUMP_ROOT.
"""
import argparse
import json
import os
import re
from pathlib import Path

ROOT = Path(__file__).resolve().parent.parent
DEFAULT_DUMP = ROOT / 'out/cpp2il/DiffableCs/Assembly-CSharp'
PD_DIRS = ['PWC/PersistentData', 'Game/PersistentData', 'PWC/ScavengerHunt/PersistentData',
           'PWC/Level/PWC/PersistentData', 'PWC/Level/ContextualAnimation/PersistentData']
TYPE = re.compile(r'^(\t*)(?:\[[^\]]*\]\s*)*(?:public|private|protected|internal)(?: (?:abstract|sealed|static|readonly|partial))* '
                  r'(class|struct|interface|enum) ([\w`<>]+)(?: : ([^{]+))?$')
FIELD = re.compile(r'^(\t*)(?:public|private|protected|internal)((?: (?:static|readonly|const|volatile))*) '
                   r'([^;(]+?) ([\w<>`$.]+)(?: = [^;]+)?; //Field offset: (0x[0-9A-Fa-f]+)')
# Persisted outside the PersistentData namespaces: store claims, placed inventory items, avatar appearance.
EXTRA_FILES = ['Game/Store/StoreState.cs', 'PWC/Inventory/ItemsTracker/InventoryItemsTracker.cs',
               'PWC/AvatarSpine/AvatarSpineData.cs', 'PWC/AvatarSpine/SkinData.cs', 'PWC/AvatarSpine/TextureData.cs']
ITEM_WORDS =('Inventory', 'Store', 'Item', 'Outfit', 'Cloth', 'Skin', 'Appearance', 'Purchase', 'Claim', 'Flag', 'Pack', 'Gift')


def parse_file(path, namespace_dir):
    types, stack = [], []
    for line in path.read_text(encoding='utf-8').splitlines():
        match = TYPE.match(line)
        if match:
            depth = len(match.group(1))
            while stack and stack[-1][0] >= depth:
                stack.pop()
            entry = {'name': match.group(3), 'kind': match.group(2), 'bases': (match.group(4) or '').strip(),
                     'file': f'{namespace_dir}/{path.name}', 'fields': []}
            types.append(entry)
            stack.append((depth, entry))
            continue
        field = FIELD.match(line)
        if field and stack and 'static' not in field.group(2) and 'const' not in field.group(2):
            depth = len(field.group(1))
            owner = [entry for d, entry in stack if d == depth - 1]
            if owner:
                owner[-1]['fields'].append({'name': field.group(4), 'type': field.group(3).strip(), 'offset': field.group(5)})
    return types


def implementers(dump, interface='IHasPersistentData'):
    """Classes anywhere in the assembly whose declared base list names the interface."""
    found = []
    for path in sorted(dump.rglob('*.cs')):
        for line in path.read_text(encoding='utf-8').splitlines():
            match = TYPE.match(line)
            if match and match.group(1) == '' and interface in (match.group(4) or '').replace(' ', '').split(','):
                found.append(match.group(3))
    return found


def build(dump):
    types = []
    for directory in PD_DIRS:
        folder = dump / directory
        if folder.is_dir():
            for path in sorted(folder.glob('*.cs')):
                types.extend(parse_file(path, directory))
    extra = []
    for relative in EXTRA_FILES:
        path = dump / relative
        if path.is_file():
            extra.extend(parse_file(path, relative.rsplit('/', 1)[0]))
    payloads = [t for t in types if t['name'].endswith('PD') and t['kind'] in ('class', 'struct')]
    return {
        'schema_version': 1,
        'scope': 'declared types only; no serialization, migration or default semantics',
        'counts': {'types': len(types), 'payload_pd_types': len(payloads),
                   'interfaces': sum(t['kind'] == 'interface' for t in types), 'enums': sum(t['kind'] == 'enum' for t in types),
                   'payload_fields': sum(len(t['fields']) for t in payloads)},
        'implements_has_persistent_data': sorted(implementers(dump)),
        'item_related_payloads': sorted(t['name'] for t in payloads if any(w in t['name'] for w in ITEM_WORDS)),
        'types': types,
        'persisted_outside_pd': extra,
    }


if __name__ == '__main__':
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--dump', type=Path, default=Path(os.environ.get('RECON_DUMP_ROOT') or DEFAULT_DUMP))
    parser.add_argument('--output', type=Path, default=ROOT / 'reports/recon/persistent_data_schema.json')
    args = parser.parse_args()
    if not args.dump.is_dir():
        raise SystemExit(f'dump not found: {args.dump} (set RECON_DUMP_ROOT)')
    report = build(args.dump)
    args.output.parent.mkdir(parents=True, exist_ok=True)
    args.output.write_text(json.dumps(report, indent=1, ensure_ascii=False) + '\n', encoding='utf-8')
    print(json.dumps(report['counts']))
