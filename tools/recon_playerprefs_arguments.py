"""Trace direct PlayerPrefs writer key arguments through a bounded ARM64 subset.

Literal results are emitted only when every analyzed control-flow path gives
the same string literal in x0. Unknown and parameter-derived keys stay explicit.
This does not cover indirect calls, reflection, or instructions outside the
decoder below.
"""
import argparse
from collections import defaultdict, deque
import json
import os
from pathlib import Path

import recon_camera_drag as camera
import recon_navigation as nav
from recon_save_triggers import KEYS, method_windows

ROOT = Path(__file__).resolve().parent.parent
OPERATIONS = ('SetInt', 'SetFloat', 'SetString', 'DeleteKey')
UNKNOWN = ('unknown',)


def reg_value(register, state):
    return ('zero',) if register == 31 else state.get(register, UNKNOWN)


def set_reg(register, value, state):
    if register != 31:
        state[register] = value


def merge_states(left, right):
    return {key: left.get(key, UNKNOWN) if left.get(key, UNKNOWN) == right.get(key, UNKNOWN) else UNKNOWN
            for key in left.keys() | right.keys()}


def metadata_literal(elf, metadata, address):
    try:
        usage = nav.metadata_usage(elf, address)
        if usage['kind'] == 5:
            return ('literal', nav.literal(metadata, usage)['literal'])
    except (ValueError, IndexError):
        pass
    return UNKNOWN


def transfer(elf, metadata, address, word, state):
    """Update tracked registers; return a recognized direct memory store if any."""
    if word & 0x9f000000 == 0x90000000:  # ADRP
        immediate = ((word >> 5) & 0x7ffff) << 2 | ((word >> 29) & 3)
        page = (address & ~0xfff) + (nav.signed(immediate, 21) << 12)
        set_reg(word & 31, ('addr', page), state)
        return

    if word & 0xffc00000 == 0xf9400000:  # LDR X, unsigned immediate
        base_reg, target = (word >> 5) & 31, word & 31
        offset = ((word >> 10) & 0xfff) * 8
        base = reg_value(base_reg, state)
        value = UNKNOWN
        if base_reg == 31:
            value = state.get(('sp', offset), UNKNOWN)
        elif base[0] == 'addr':
            value = metadata_literal(elf, metadata, base[1] + offset)
        elif base[0] == 'offset' and base[1][0] == 'addr':
            value = metadata_literal(elf, metadata, base[1][1] + base[2] + offset)
        elif base[0] == 'literal':
            value = base
        elif base[0] in ('arg', 'field', 'return', 'offset'):
            value = ('field', base, offset)
        set_reg(target, value, state)
        return

    if word & 0xffe0ffe0 in (0xaa0003e0, 0x2a0003e0):  # MOV X/Wd, X/Wm
        set_reg(word & 31, reg_value((word >> 16) & 31, state), state)
        return

    if word & 0xffc00000 in (0x91000000, 0x11000000):  # ADD X/Wd, X/Wn, #imm
        base_reg, target = (word >> 5) & 31, word & 31
        immediate = (word >> 10) & 0xfff
        if word & (1 << 22):
            immediate <<= 12
        base = reg_value(base_reg, state)
        value = ('offset', base, immediate) if base[0] in ('arg', 'field', 'addr', 'return') else UNKNOWN
        set_reg(target, value, state)
        return

    # Stack stores used for saved arguments, without modeling arbitrary heap writes.
    if word & 0xffc00000 in (0xf9000000, 0xb9000000):
        base_reg, source = (word >> 5) & 31, word & 31
        scale = 8 if word & 0xffc00000 == 0xf9000000 else 4
        offset = ((word >> 10) & 0xfff) * scale
        if base_reg == 31:
            state[('sp', offset)] = reg_value(source, state)
        return

    # Stores, compares and branches don't define a general-purpose destination.
    if word & 0xffc00000 in (0x39000000, 0x79000000, 0xb9000000, 0xf9000000,
                              0xa9000000, 0xa8800000, 0xa9800000):
        return
    if word & 0x7c000000 in (0x14000000, 0x34000000, 0x36000000) or \
            word & 0xff000010 == 0x54000000 or word & 0xfffffc1f in (0xd61f0000, 0xd65f0000):
        return

    # For unsupported instructions, conservatively invalidate the encoded Rd.
    set_reg(word & 31, UNKNOWN, state)


def build(source):
    binary = (source / 'libil2cpp.so').read_bytes()
    metadata_bytes = (source / 'global-metadata.dat').read_bytes()
    elf, metadata = nav.Elf(binary), nav.Metadata(metadata_bytes)
    rows, _ = nav.load_index(source / 'metadata_methods.jsonl', elf, metadata)
    valid = [row for row in rows if row.get('vaddr')]
    targets = {row['name']: int(row['vaddr'], 16) for row in valid
               if row['declaring_type'] == 'UnityEngine.PlayerPrefs' and row['name'] in OPERATIONS}
    nav.require(set(targets) == set(OPERATIONS), 'PlayerPrefs writer identities changed')
    callers = camera.direct_callers(elf, valid, targets)
    writer_methods = set().union(*callers.values())
    windows = method_windows(rows)
    methods_by_address = {}
    for row in valid:
        methods_by_address.setdefault(int(row['vaddr'], 16), row['declaring_type'] + '.' + row['name'])

    site_values = defaultdict(set)
    site_kinds = {}
    helper_calls = []
    for method in sorted(writer_methods):
        for start, stop in windows.get(method, []):
            incoming = {start: {register: ('arg', register) for register in range(8)}}
            pending, steps = deque([start]), 0
            while pending and steps < 20000:
                address = pending.popleft()
                steps += 1
                state = incoming[address].copy()
                word = nav.word(elf, address)
                branch = nav.branch(address, word)
                transfer(elf, metadata, address, word, state)
                fallthrough = address + 4
                successors = []

                if branch:
                    if branch['kind'] in ('BL', 'B') and branch['target'] in targets.values():
                        operation = next(name for name, target in targets.items() if target == branch['target'])
                        site_values[(address, method, operation)].add(state.get(0, UNKNOWN))
                        site_kinds[(address, method, operation)] = branch['kind']
                    if branch['kind'] == 'BL' and branch['target'] in methods_by_address:
                        helper_calls.append({'method': method, 'address': address,
                                             'target': branch['target'],
                                             'arguments': [state.get(register, UNKNOWN) for register in range(4)]})
                    if branch['kind'] == 'RET':
                        continue
                    if branch['kind'] == 'B':
                        if branch['target'] is not None and start <= branch['target'] < stop:
                            successors = [branch['target']]
                    elif branch['kind'] in ('BL', 'BLR'):
                        for register in range(19):
                            state.pop(register, None)
                        state[0] = ('return', branch.get('target'))
                        successors = [fallthrough]
                    else:
                        successors = [fallthrough]
                        target = branch.get('target')
                        if target is not None and start <= target < stop:
                            successors.append(target)
                else:
                    successors = [fallthrough]

                for successor in successors:
                    if not start <= successor < stop:
                        continue
                    if successor not in incoming:
                        incoming[successor] = state.copy()
                        pending.append(successor)
                    else:
                        merged = merge_states(incoming[successor], state)
                        if merged != incoming[successor]:
                            incoming[successor] = merged
                            pending.append(successor)

    call_sites = []
    literal_counts = defaultdict(int)
    for (address, method, operation), values in sorted(site_values.items()):
        value = next(iter(values)) if len(values) == 1 else ('unknown',)
        argument = {'kind': value[0]}
        if value[0] == 'literal':
            argument['value'] = value[1]
            literal_counts[value[1]] += 1
        elif value[0] == 'arg':
            argument['argument_index'] = value[1]
        elif value[0] == 'field':
            argument['base'] = value[1]
            argument['byte_offset'] = value[2]
        elif value[0] == 'return':
            argument['helper_method'] = methods_by_address.get(value[1], hex(value[1]) if value[1] else None)
            candidates = [call for call in helper_calls if call['method'] == method and
                          call['target'] == value[1] and call['address'] < address]
            if candidates:
                helper = max(candidates, key=lambda call: call['address'])
                argument['helper_callsite'] = hex(helper['address'])
                argument['helper_arguments'] = [
                    {'index': index, 'kind': item[0],
                     'value': item[1:] if item[0] != 'literal' else item[1]}
                    for index, item in enumerate(helper['arguments'])
                ]
        call_sites.append({'method': method, 'address': hex(address), 'operation': operation,
                           'audited_in_L03': method in KEYS,
                           'branch': site_kinds[(address, method, operation)], 'key_argument': argument,
                           'argument_path_count': len(values)})

    exact_count = sum(site['key_argument']['kind'] == 'literal' for site in call_sites)
    audited_sites = [site for site in call_sites if site['audited_in_L03']]
    remaining_set_methods = {site['method'] for site in call_sites
                             if site['operation'] in ('SetInt', 'SetFloat', 'SetString') and
                             not site['audited_in_L03']}
    return {
        'schema_version': 1,
        'scope': 'direct ARM64 BL/B call sites to UnityEngine.PlayerPrefs writers; bounded register/stack dataflow',
        'limitations': [
            'Indirect calls, reflection, and PlayerPrefs wrappers are outside this direct-call scan.',
            'Only the instruction subset decoded in this tool is tracked; unsupported writes invalidate the destination register.',
            'A literal is called exact only when all analyzed paths agree on the same string in x0.',
            'Argument-, field-, and helper-derived keys remain symbolic and require caller/asset/runtime resolution.',
        ],
        'counts': {'methods': len(writer_methods), 'direct_call_sites': len(call_sites),
                   'sites_with_proven_literal_key': exact_count,
                   'sites_with_dynamic_or_unresolved_key': len(call_sites) - exact_count,
                   'unique_proven_literal_keys': len(literal_counts),
                   'L03_audited_sites': len(audited_sites),
                   'remaining_Set_writer_methods': len(remaining_set_methods),
                   'remaining_Set_sites_with_proven_literal_key': sum(
                       site['key_argument']['kind'] == 'literal' for site in call_sites
                       if site['operation'] in ('SetInt', 'SetFloat', 'SetString') and
                       not site['audited_in_L03'])},
        'literal_key_usage': dict(sorted(literal_counts.items())),
        'call_sites': call_sites,
    }


if __name__ == '__main__':
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--source', type=Path,
                        default=Path(os.environ.get('RECON_IL2CPP_ROOT') or ROOT / 'out/recon/il2cpp'))
    parser.add_argument('--output', type=Path, default=ROOT / 'out/recon/playerprefs_argument_trace.json')
    args = parser.parse_args()
    report = build(args.source)
    args.output.parent.mkdir(parents=True, exist_ok=True)
    args.output.write_text(json.dumps(report, indent=2, ensure_ascii=False) + '\n', encoding='utf-8')
    print(json.dumps(report['counts'], ensure_ascii=False))
