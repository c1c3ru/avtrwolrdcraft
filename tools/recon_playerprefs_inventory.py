"""Inventory direct PlayerPrefs writer callers and nearby literal candidates.

This is bounded static analysis of the original IL2CPP ARM64 image. A literal
near a writer is a candidate key, not proof of the argument value. Indirect
calls and keys supplied by callers remain outside this inventory.
"""
import argparse
import json
import os
import re
from pathlib import Path

import recon_navigation as nav
from recon_camera_drag import direct_callers
from recon_save_triggers import KEYS, method_windows, window_literals

ROOT = Path(__file__).resolve().parent.parent
OPERATIONS = ('SetInt', 'SetFloat', 'SetString', 'DeleteKey')
KEY_SHAPED = re.compile(r'^[A-Za-z][A-Za-z0-9_./:-]{2,127}$')


def build(source):
    binary = (source / 'libil2cpp.so').read_bytes()
    metadata = (source / 'global-metadata.dat').read_bytes()
    nav.verify_pair(binary, metadata)
    elf, meta = nav.Elf(binary), nav.Metadata(metadata)
    rows, _ = nav.load_index(source / 'metadata_methods.jsonl', elf, meta)
    valid = [row for row in rows if row.get('vaddr')]
    targets = {row['name']: int(row['vaddr'], 16) for row in valid
               if row['declaring_type'] == 'UnityEngine.PlayerPrefs' and row['name'] in OPERATIONS}
    nav.require(set(targets) == set(OPERATIONS), 'PlayerPrefs writer method inventory changed')
    callers = direct_callers(elf, valid, targets)
    operations_by_method = {}
    for operation, methods in callers.items():
        for method in methods:
            operations_by_method.setdefault(method, []).append(operation)

    windows = method_windows(rows)
    methods = []
    for name, operations in sorted(operations_by_method.items()):
        literals = set()
        for start, stop in windows.get(name, []):
            literals.update(window_literals(elf, meta, start, stop))
        methods.append({
            'method': name,
            'operations': sorted(operations),
            'key_literal_candidates': sorted(value for value in literals if KEY_SHAPED.fullmatch(value)),
            'audited_in_L03': name in KEYS,
        })

    counts = {operation: len(names) for operation, names in callers.items()}
    return {
        'schema_version': 1,
        'scope': 'direct ARM64 BL callers of PlayerPrefs writers; nearby string literals are candidates only',
        'coverage_caveats': [
            'Indirect calls and aliases are not attributed by this scan.',
            'A nearby identifier-shaped string is not proved to be the argument passed as the key.',
            'A writer with no candidate literal may receive a dynamic key from its caller or a static field.',
        ],
        'counts': {
            'writer_callers_by_operation': counts,
            'writer_operations_total': sum(counts[name] for name in OPERATIONS[:3]),
            'unique_writer_methods': len(set().union(*(callers[name] for name in OPERATIONS[:3]))),
            'delete_key_methods': counts['DeleteKey'],
            'methods_with_L03_key_assertions': sum(method['method'] in KEYS for method in methods
                                                   if any(op != 'DeleteKey' for op in method['operations'])),
        },
        'methods': methods,
    }


if __name__ == '__main__':
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--source', type=Path,
                        default=Path(os.environ.get('RECON_IL2CPP_ROOT') or ROOT / 'out/recon/il2cpp'))
    parser.add_argument('--output', type=Path, default=ROOT / 'out/recon/playerprefs_inventory.json')
    args = parser.parse_args()
    report = build(args.source)
    args.output.parent.mkdir(parents=True, exist_ok=True)
    args.output.write_text(json.dumps(report, indent=2, ensure_ascii=False) + '\n', encoding='utf-8')
    print(json.dumps(report['counts'], ensure_ascii=False))
