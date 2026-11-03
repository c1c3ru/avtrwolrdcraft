"""Verify the bounded Home Play contract against the shipped ARM64/metadata pair.

No game execution, semantic certification or automatic queue acceptance.
"""
import argparse
import json
import re
from pathlib import Path

import recon_navigation as nav

START, STOP = 0x2057fa8, 0x20581ec
TASK_OUTPUT = nav.ROOT / 'out/recon/tasks/T025/METHOD/5fe1bb4a25183678'
CALLS = {
    0x2058044: ('PWC.InteractionHistory.InteractionHistoryManager', 'OnClickHomePlayButton'),
    0x2058050: ('UnityEngine.PlayerPrefs', 'HasKey'),
    0x2058078: ('PazuCore.SoundManager', 'Stop'),
    0x2058090: ('UnityEngine.PlayerPrefs', 'GetString'),
    0x205809c: ('System.String', 'IsNullOrEmpty'),
    0x20580c8: ('PWC.GameSceneManager', 'GetCurrentWorldSceneName'),
    0x2058184: ('UnityEngine.PlayerPrefs', 'DeleteKey'),
    0x205818c: ('UnityEngine.PlayerPrefs', 'Save'),
    0x205819c: ('PWC.World.Buildings.WorldBuildingsDataManager', 'SaveBuildingData'),
    0x20581a8: ('PWC.CoreExtensions', 'GetSceneName'),
    0x20581e4: ('PWC.GameSceneManager', 'LoadScene'),
}


def verify(elf, meta, resolve):
    identity = resolve(START)
    nav.require(len(identity) == 1 and identity[0]['token'] == '0x060054ef'
                and identity[0]['declaring_type'] == 'Game.Home.HomePlayButton'
                and identity[0]['name'] == 'LoadPlayScene', 'Home Play identity mismatch')
    # Verify both literal operands, not a standalone occurrence of the string.
    key = nav.literal(meta, nav.metadata_usage(elf,
        nav.adrp_ldr(elf, 0x2058038, 0x205803c)['got_vaddr']))
    empty = nav.literal(meta, nav.metadata_usage(elf,
        nav.adrp_ldr(elf, 0x205807c, 0x2058084)['got_vaddr']))
    nav.require(key['literal'] == 'pazucore_pending_deep_link', 'pending key mismatch')
    nav.require(empty['literal'] == '', 'deep link default mismatch')
    # Decisive instruction/operand anchors: key flow, branch polarity, preserved
    # return values, indirect dispatch, enum default, side-effect arguments, tail.
    anchors = {
        0x205803c: 0xf94216b5, 0x2058084: 0xf945d108,
        0x2058048: 0xf94002a0, 0x205804c: 0xaa1f03e1,
        0x2058054: 0x360002c0, 0x2058070: 0x52807d21,
        0x2058080: 0xf94002a0, 0x2058088: 0xaa1f03e2,
        0x205808c: 0xf9400101, 0x2058094: 0xaa1f03e1,
        0x2058098: 0xaa0003f3, 0x20580a0: 0x360001a0,
        0x20580a4: 0x52800053, 0x20580a8: 0x14000035,
        0x20580c4: 0xaa1f03e0, 0x20580cc: 0xaa0003f3,
        0x20580d0: 0x1400003f, 0x2058168: 0xa9400808,
        0x205816c: 0xaa1403e0, 0x2058170: 0xaa1303e1,
        0x2058174: 0xd63f0100, 0x2058178: 0x2a0003f3,
        0x205817c: 0xf94002a0, 0x2058180: 0xaa1f03e1,
        0x2058188: 0xaa1f03e0, 0x2058190: 0x2a1f03e0,
        0x2058194: 0x2a1303e1, 0x2058198: 0xaa1f03e2,
        0x20581a0: 0x2a1303e0, 0x20581a4: 0xaa1f03e1,
        0x20581b4: 0xaa0003f3, 0x20581cc: 0xaa1303e0,
        0x20581d4: 0x52800021, 0x20581d8: 0xaa1f03e2,
        0x20581dc: 0xaa1f03e3,
    }
    for address, expected in anchors.items():
        nav.expect(elf, address, expected)
    confirmed = []
    for site, expected in CALLS.items():
        control = nav.branch(site, nav.word(elf, site))
        nav.require(control and control['kind'] == ('B' if site == 0x20581e4 else 'BL'),
                    f'call encoding mismatch at {site:#x}')
        targets = resolve(control['target'])
        nav.require(len(targets) == 1 and
                    (targets[0]['declaring_type'], targets[0]['name']) == expected,
                    f'callee mismatch at {site:#x}')
        confirmed.append({'site': hex(site), 'target': targets[0]})
    return {'method': identity[0], 'pending_key': key, 'default_string': empty,
            'verified_calls': confirmed, 'verified_operand_anchors': len(anchors),
            'unresolved_indirect_dispatch': {'site': '0x2058174', 'register': 'x8',
                'argument': 'pending deep link string in x1', 'result': 'w0 saved in w19'}}


def bounded_flow(elf):
    """Instruction reachability assuming calls return; excludes exception edges."""
    pending, seen, edges = [START], set(), []
    while pending:
        pc = pending.pop()
        if pc in seen:
            continue
        seen.add(pc)
        control = nav.branch(pc, nav.word(elf, pc))
        successors = []
        if control:
            kind, target = control['kind'], control.get('target')
            if kind in ('B', 'B.cond', 'CBZ', 'CBNZ', 'TBZ', 'TBNZ'):
                successors.append((target, 'branch'))
            if kind in ('BL', 'BLR'):
                edges.append({'from': hex(pc), 'to': hex(target) if target is not None else None,
                              'kind': 'call' if target is not None else 'unresolved_call'})
            if kind == 'RET':
                edges.append({'from': hex(pc), 'to': None, 'kind': 'return'})
            if kind == 'BR':
                edges.append({'from': hex(pc), 'to': None, 'kind': 'unresolved_jump'})
            if kind not in ('B', 'BR', 'RET'):
                successors.append((pc + 4, 'fallthrough'))
        else:
            successors.append((pc + 4, 'fallthrough'))
        for target, kind in successors:
            inside = START <= target < STOP and target % 4 == 0
            edges.append({'from': hex(pc), 'to': hex(target), 'kind': kind, 'inside': inside})
            if inside:
                pending.append(target)
    return {'start': hex(START), 'exclusive_stop': hex(STOP),
            'reachable_instruction_count': len(seen), 'edges': edges,
            'assumptions': ['Direct/indirect calls may return; exception edges not reconstructed.',
                            'Boundary at next metadata start does not establish complete function body.',
                            'Final null-failure helper fallthrough is retained as an unknown exit.']}


def compare_craft(elf, path):
    evidence = json.loads(path.read_text())
    assembly = evidence['result']['assembly']
    rows = re.findall(r'^\s*(0x[0-9a-f]+)\s+([0-9a-f]{8})\s+', assembly, re.M)
    observed = {int(address, 16): bytes.fromhex(encoded) for address, encoded in rows}
    nav.require(len(rows) == len(observed) == (STOP - START) // 4,
                'Craft listing missing or duplicate instructions')
    for pc in range(START, STOP, 4):
        offset = elf.offset(pc, 4)
        nav.require(observed.get(pc) == elf.data[offset:offset + 4],
                    f'Craft bytes/address mismatch at {pc:#x}')
    return {'evidence_id': evidence['id'], 'verified_instruction_bytes': len(rows),
            'scope': 'Address and byte agreement only; pseudocode semantics not certified.'}


def run(source, output, craft=None):
    binary = (source / 'libil2cpp.so').read_bytes()
    metadata = (source / 'global-metadata.dat').read_bytes()
    nav.verify_pair(binary, metadata)
    elf, meta = nav.Elf(binary), nav.Metadata(metadata)
    _, resolve = nav.load_index(source / 'metadata_methods.jsonl', elf, meta)
    contract = verify(elf, meta, resolve)
    offset = elf.offset(START, STOP - START)
    contract.update(schema_version=1, status='static_candidate_not_runtime_validated',
                    native_sha256=nav.sha(binary), metadata_sha256=nav.sha(metadata),
                    window_sha256=nav.sha(binary[offset:offset + STOP - START]))
    if craft:
        contract['craft_comparison'] = compare_craft(elf, craft)
    unknowns = [
        'Resolve interface target at 0x2058174 for nonempty deep links.',
        'Recover helpers, exceptions and independent body bounds.',
        'Verify effect of interaction-history callback and SaveBuildingData arguments.',
        'Validate original absent/empty/nonempty pending key scenarios on device.',
        'Close callees of world lookup, scene load, fade and return.',
    ]
    contract['candidate'] = [
        'Invoke OnClickHomePlayButton on the observed manager instance.',
        'If pending key is absent: scene = GetCurrentWorldSceneName().',
        'Otherwise Stop(1001), read pending key with empty default.',
        'Empty/null value: level = 2; nonempty: level = unresolved interface call(value).',
        'Pending branch deletes the key and calls PlayerPrefs.Save().',
        'Pending branch calls SaveBuildingData(0, level), then scene = GetSceneName(level).',
        'Both normal paths tail-call LoadScene(scene, true, null).',
    ]
    contract['unknowns'] = unknowns
    nav.atomic_json(output / 'method-contract.json', contract)
    nav.atomic_json(output / 'control-flow.json', bounded_flow(elf))
    (output / 'unknowns.jsonl').write_text(''.join(json.dumps({'question': u}) + '\n' for u in unknowns))
    nav.atomic_json(output / 'result.json', {'status': 'partial', 'semantic_completion': False,
        'verified_calls': len(CALLS), 'contract': str(output / 'method-contract.json'),
        'unknowns': unknowns})
    return contract


if __name__ == '__main__':
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--source', type=Path, default=nav.ROOT / 'out/recon/il2cpp')
    parser.add_argument('--output', type=Path, default=TASK_OUTPUT)
    parser.add_argument('--craft-listing', type=Path)
    args = parser.parse_args()
    report = run(args.source, args.output, args.craft_listing)
    print(json.dumps({'status': report['status'], 'calls': len(report['verified_calls']),
                      'key': report['pending_key']['literal'], 'output': str(args.output)}))
