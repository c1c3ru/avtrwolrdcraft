"""Bounded static evidence for LoadScene's closure; does not execute the game."""
import argparse
import struct
from pathlib import Path

import recon_navigation as nav


LOCAL = 0x2073578
# (site, kind, target): every guard of the callback that sends control to the local load.
GUARD_SITES = [(0x20734fc, 'TBZ', LOCAL), (0x2073504, 'CBZ', LOCAL),
               (0x207353c, 'CBZ', LOCAL), (0x2073568, 'CBZ', 0x2073788),
               (0x2073574, 'TBZ', 0x20735ac)]
LDRB_STATIC0 = 0x39400100          # ldrb wN, [x8, #0]; destination register masked out
LDR_X_8_PLUS_0x38 = 0xf9401d00      # ldr x0, [x8, #0x38]


def typedef_name(meta, usage):
    nav.require(usage['kind'] == 1, 'usage is not a type info')
    table = meta.tables['types']
    found = []
    for idx in range(table['count']):
        row = struct.unpack_from('<16I8H2I', meta.data, table['offset'] + idx * 88)
        if row[2] == usage['index']:
            found.append(meta.string(row[1]) + '.' + meta.string(row[0]))
    nav.require(len(found) == 1, 'type info does not map uniquely to a typedef')
    return found[0]


def multiplayer_guard(elf, meta, resolve):
    """Prove the decision chain between the local and the multiplayer load path."""
    for site, kind, target in GUARD_SITES:
        control = nav.branch(site, nav.word(elf, site))
        nav.require(control and control['kind'] == kind and control['target'] == target,
                    f'guard encoding mismatch at {site:#x}')
    nav.require(nav.word(elf, 0x2073538) & 0xffc003e0 == LDRB_STATIC0, 'static flag load is not LDRB Wt,[x8,#0]')
    nav.require(nav.word(elf, 0x2073564) == LDR_X_8_PLUS_0x38, 'instance load is not LDR X0,[x8,#0x38]')
    klass = typedef_name(meta, nav.metadata_usage(elf, nav.adrp_ldr(elf, 0x2073528, 0x207352c)['got_vaddr']))
    host = nav.branch(0x2073570, nav.word(elf, 0x2073570))
    names = resolve(host['target'])
    nav.require(host['kind'] == 'BL' and [n['name'] for n in names] == ['IsHostAndOnlyPlayer'],
                'host-only call target mismatch')
    nav.require(klass == 'PWC.Multiplayer.MPManager', 'static class is not MPManager')
    return {
        'static_class': klass,
        'static_flag': {'site': '0x2073538', 'offset': '0x0', 'declared_as': 'IsMultiplayerGame backing field'},
        'static_instance': {'site': '0x2073564', 'offset': '0x38', 'declared_as': 'Instance backing field'},
        'null_instance_target': '0x2073788 (helper call; NullReferenceException pattern, unnamed)',
        'host_only_call': {'site': '0x2073570', 'metadata_targets': names},
        'decision': ('multiplayer path iff sceneName != "Home" && considerMultiplayer && '
                     'MPManager.IsMultiplayerGame && !MPManager.Instance.IsHostAndOnlyPlayer(); '
                     'otherwise GameSceneManager.LoadSceneImplement(sceneName); null Instance raises'),
    }


MP_START, MP_HOST_ELSE, MP_JOIN, EPILOGUE = 0x20735ac, 0x20736b0, 0x20736dc, 0x2073594
MP_CALLS = ['Guid.NewGuid', 'Guid.ToString', 'MPManager.IsHost', 'MPData_SceneChangeRequest..ctor',
            'GameSceneManager.GetActiveSceneId', 'MPManager.SendWaitForPlayerForSceneChangeRequest',
            'GameSceneManager.GetActiveSceneId', 'MPDataHelper_SceneChangeRequest.TrySendEvent',
            'MPUtils.DestroyAllGameObjectsInLoadedScenes', 'MPManager.GetPlayerUID',
            'MPManager.ClearPlayerFromScenes']


def multiplayer_sequence(controls):
    """Ordered named calls of the multiplayer path plus the host/non-host split and join."""
    by_site = {int(row['site'], 16): row for row in controls}
    named = [(site, '%s.%s' % (row['metadata_targets'][0]['declaring_type'].rsplit('.', 1)[-1],
                               row['metadata_targets'][0]['name']))
             for site, row in sorted(by_site.items())
             if site >= MP_START and row['kind'] == 'BL' and row['metadata_targets']]
    nav.require([name for _, name in named] == MP_CALLS, 'multiplayer call sequence changed')
    for site, kind, target in [(0x20735fc, 'TBZ', MP_HOST_ELSE), (0x20736ac, 'B', MP_JOIN),
                               (0x2073784, 'B', EPILOGUE)]:
        row = by_site[site]
        nav.require(row['kind'] == kind and row['target'] == target, f'multiplayer branch mismatch at {site:#x}')
    nav.require(all(row['target'] != 0x2072cc8 for site, row in by_site.items()
                    if site >= MP_START and row.get('target')), 'multiplayer path reaches LoadSceneImplement')
    return {'calls': [{'site': hex(site), 'name': name} for site, name in named],
            'host': 'IsHost true -> new MPData_SceneChangeRequest -> GetActiveSceneId -> SendWaitForPlayerForSceneChangeRequest',
            'non_host': 'IsHost false (0x20736b0) -> GetActiveSceneId -> MPDataHelper_SceneChangeRequest.TrySendEvent',
            'join': '0x20736dc: DestroyAllGameObjectsInLoadedScenes -> GetPlayerUID -> ClearPlayerFromScenes -> return',
            'loads_scene_locally': False}


def probe(source):
    binary = (source / 'libil2cpp.so').read_bytes()
    metadata = (source / 'global-metadata.dat').read_bytes()
    nav.verify_pair(binary, metadata)
    elf, meta = nav.Elf(binary), nav.Metadata(metadata)
    rows, resolve = nav.load_index(source / 'metadata_methods.jsonl', elf, meta)
    start, stop = 0x2073488, 0x207378c
    owner = resolve(start)
    nav.require(len(owner) == 1 and owner[0]['token'] == '0x0600570f'
                and owner[0]['name'] == '<LoadScene>b__0', 'callback identity mismatch')
    nav.require(min(int(r['vaddr'], 16) for r in rows
                    if r['vaddr'] and int(r['vaddr'], 16) > start) == stop,
                'next method boundary mismatch')
    literal_got = nav.adrp_ldr(elf, 0x20734a0, 0x20734a8)
    home = nav.literal(meta, nav.metadata_usage(elf, literal_got['got_vaddr']))
    nav.require(home['literal'] == 'Home', 'scene guard literal mismatch')
    controls = []
    for address in range(start, stop, 4):
        control = nav.branch(address, nav.word(elf, address))
        if not control:
            continue
        target = control.get('target')
        names = resolve(target) if target is not None else []
        controls.append({'site': hex(address), **control, 'metadata_targets': names})
    offset = elf.offset(start, stop - start)
    return {
        'schema_version': 1,
        'scope': 'bounded static callback probe; no runtime equivalence claim',
        'native_sha256': nav.sha(binary), 'metadata_sha256': nav.sha(metadata),
        'index_sha256': nav.sha((source / 'metadata_methods.jsonl').read_bytes()),
        'method': owner[0], 'start': hex(start), 'exclusive_stop': hex(stop),
        'window_sha256': nav.sha(binary[offset:offset + stop - start]),
        'scene_guard_literal': home, 'multiplayer_guard': multiplayer_guard(elf, meta, resolve),
        'multiplayer_sequence': multiplayer_sequence(controls),
        'control_encodings': controls,
        'limitations': [
            'Linear window ending at next metadata start is not a complete CFG/body proof.',
            'Metadata targets revalidated; unresolved helpers remain unnamed.',
            'Static field names come from Cpp2IL declarations (offsets 0x0/0x38), not from the binary.',
            'No multiplayer operation, target execution or queue acceptance performed.',
        ],
    }


if __name__ == '__main__':
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--source', type=Path, default=nav.ROOT / 'out/recon/il2cpp')
    parser.add_argument('--report', type=Path,
                        default=nav.ROOT / 'out/recon/load_scene_callback.json')
    args = parser.parse_args()
    result = probe(args.source)
    nav.atomic_json(args.report, result)
    print(f"Callback {result['start']}: {len(result['control_encodings'])} control encodings; {args.report}")
