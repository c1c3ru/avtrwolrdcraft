"""Version-pinned metadata/native dispatch joins; static evidence, no runtime."""
import argparse
import bisect
import json
from pathlib import Path
import re
import struct
import sys

ROOT = Path(__file__).resolve().parents[5]
sys.path.insert(0, str(ROOT / 'tools'))
import recon_navigation as nav

FAMILIES = ['PWC.Level.LevelCharacter', 'PWC.Level.LevelToddler',
            'PWC.Level.LevelBaby', 'Game.Level.LevelCat', 'Game.Level.LevelDog',
            'Game.Level.LevelHorse']
VIRTUAL_SITES = [
    ('PWC.Level.LevelCharacter', 0x22af374, 0x508, 'DetachFromParentIfExists'),
    ('PWC.Level.LevelAnimal', 0x2264fd0, 0xad8, 'GetPickUpLoopAnimationName'),
    ('PWC.Level.ContextualAnimation.LevelCAHandlerBase', 0x2264de0, 0x2e8, 'GetLockedAnimationName'),
    ('PWC.Level.LevelAnimal', 0x2265494, 0xad8, 'GetPickUpLoopAnimationName'),
    ('PWC.Level.LevelAnimal', 0x226560c, 0xad8, 'GetPickUpLoopAnimationName'),
    ('PWC.Level.LevelAnimal', 0x22656c8, 0xa68, 'HasRunningAnimations'),
    ('PWC.Level.LevelAnimal', 0x226576c, 0xb18, 'GetWalkingAnimationName'),
    ('PWC.Level.LevelAnimal', 0x2265868, 0xad8, 'GetPickUpLoopAnimationName'),
    ('PWC.Level.LevelAnimal', 0x22658c0, 0xb18, 'GetWalkingAnimationName'),
    ('PWC.Level.LevelAnimal', 0x2265974, 0xa68, 'HasRunningAnimations'),
    ('PWC.Level.LevelAnimal', 0x2265a78, 0xb28, 'GetRunningAnimationName'),
    ('PWC.Level.ContextualAnimation.LevelCAHandlerBase', 0x22a1284, 0x2e8, 'GetLockedAnimationName'),
    ('PWC.Level.LevelDropArea', 0x1dc4c20, 0x318, 'OverrideAvatarEndDropAnimation'),
    ('PWC.Level.LevelDropArea', 0x1dc60fc, 0x318, 'OverrideAvatarEndDropAnimation'),
    ('PWC.Level.LevelDropArea', 0x1dc9150, 0x318, 'OverrideAvatarEndDropAnimation'),
    ('PWC.Level.LevelDropArea', 0x229b960, 0x318, 'OverrideAvatarEndDropAnimation'),
    ('PWC.Level.LevelSitArea', 0x2299798, 0x2d8, 'IsAvailableForAvatar'),
    ('PWC.Level.LevelSleepArea', 0x2299814, 0x2d8, 'IsAvailableForAvatar'),
    ('PWC.Level.LevelDropArea', 0x2299898, 0x3b8, 'IsAvailableForItems'),
    ('PWC.Level.LevelDropArea', 0x22999bc, 0x218, 'CanConsumeItem'),
    ('PWC.Level.LevelItem', 0x22999e4, 0x578, 'SnapToDropArea'),
]
# Both slow-path argument and fast-path slot addition are checked.
INTERFACE_SITES = [
    (0x2299764, 0x229990c, 0x2299920, 7, 'GetLevelItem'),
    (0x2299800, 0x2299964, 0x2299980, 19, 'SitAvatarOn'),
    (0x2299900, 0x229998c, 0x22999a0, 7, 'GetLevelItem'),
    (0x2294534, 0x2294540, 0x2294554, 7, 'GetLevelItem'),
    (0x2294610, 0x229461c, 0x2294630, 8, 'GetPDPrefab'),
    (0x2294684, 0x2294690, 0x22946a4, 4, 'get_ID'),
    (0x2294868, 0x2294874, 0x2294888, 7, 'GetLevelItem'),
    (0x22956cc, 0x22956d8, 0x22956ec, 7, 'GetLevelItem'),
    (0x22958e8, 0x2295abc, 0x2295ad0, 8, 'GetPDPrefab'),
]


def build(source):
    binary = (source / 'libil2cpp.so').read_bytes()
    metadata = (source / 'global-metadata.dat').read_bytes()
    nav.verify_pair(binary, metadata)
    elf, meta = nav.Elf(binary), nav.Metadata(metadata)
    rows, resolve = nav.load_index(source / 'metadata_methods.jsonl', elf, meta)
    byindex = {r['method_definition_index']: r for r in rows}
    types = {(t['namespace'] + '.' + t['name']).lstrip('.'): t for t in meta.types}
    rawtypes = {t['index']: struct.unpack_from('<16I8H2I', metadata,
                meta.tables['types']['offset'] + t['index'] * 88) for t in meta.types}
    vbase, vsize = struct.unpack_from('<II', metadata, 144)
    ibase, isize = struct.unpack_from('<II', metadata, 152)

    def virtual(name, slot):
        typ = types[name]
        row = rawtypes[typ['index']]
        nav.require(0 <= slot < row[21], 'slot outside type vtable')
        off = vbase + (row[14] + slot) * 4
        nav.require(off + 4 <= vbase + vsize, 'slot outside table')
        enc = struct.unpack_from('<I', metadata, off)[0]
        nav.require(enc >> 29 == 3 and enc & 1, 'unsupported vtable encoding')
        index = (enc & 0x1fffffff) >> 1
        method = byindex[index]
        return dict(receiver=name, slot=slot, metadata_file_offset=off,
                    encoded=hex(enc), target=method)

    def interface(name, iface, index):
        row = rawtypes[types[name]['index']]
        wanted = rawtypes[types[iface]['index']][2]
        matches = []
        for i in range(row[15], row[15] + row[23]):
            nav.require((i+1)*8 <= isize, 'interface offset outside table')
            t, off = struct.unpack_from('<Ii', metadata, ibase+i*8)
            if t == wanted:
                matches.append((i, off))
        nav.require(len(matches) == 1, 'interface offset ambiguous/missing')
        i, off = matches[0]
        return dict(interface=iface, interface_method_index=index,
                    interface_offset_file_offset=ibase+i*8,
                    interface_vtable_offset=off, **virtual(name, off+index))

    def context(site, count=8):
        return [{'site': hex(a), 'word': hex(nav.word(elf, a))}
                for a in range(site-count*4, site+4, 4)]

    virtuals=[]
    for receiver, site, offset, expected in VIRTUAL_SITES:
        # The call's x9 comes from the preceding load pair from x8.
        nav.expect(elf, site, 0xd63f0120)
        expected_load = 0xf9400000 | ((offset//8) << 10) | (8 << 5) | 9
        load_sites = [a for a in range(site-24, site, 4)
                      if nav.word(elf, a) == expected_load]
        nav.require(len(load_sites) == 1, 'virtual pointer load missing')
        slot=(offset-0x138)//16
        nav.require(0x138+slot*16 == offset, 'misaligned native virtual offset')
        target=virtual(receiver, slot)
        nav.require(target['target']['name'] == expected, 'virtual name mismatch')
        virtuals.append(dict(site=hex(site), native_offset=hex(offset),
                             instructions=context(site), **target))

    iface=types['PWC.Level.ILevelAvatar']
    ifacemethods=[byindex[i] for i in range(iface['method_start'], iface['method_start']+iface['method_count'])]
    interfaces=[]
    for slow, fast, call, index, expected in INTERFACE_SITES:
        nav.expect(elf, slow-8, 0x52800002 | (index << 5))
        nav.require(nav.branch(slow, nav.word(elf, slow))['target'] == 0x1b7ba44,
                    'interface slow resolver mismatch')
        nav.expect(elf, fast, 0x11000129 | (index << 10))
        nav.expect(elf, call, 0xd63f0100)
        nav.require(ifacemethods[index]['name'] == expected, 'interface method mismatch')
        interfaces.append(dict(slow_resolver=hex(slow), fast_slot_add=hex(fast),
                               call=hex(call), interface_index=index, target=ifacemethods[index],
                               instructions=context(call)))

    # Verify the metadata usage supplying ILevelAvatar to the native interface lookup.
    got=0x41acdb8
    usage=nav.metadata_usage(elf,got)
    nav.require(usage['encoded'] == hex(0x2000ab7f), 'ILevelAvatar usage changed')
    nav.require(rawtypes[iface['index']][2] == (0xab7e >> 1), 'interface type usage join failed')

    family=[]
    for name in FAMILIES:
        family.append(dict(receiver=name,
            drag_slots=[virtual(name,s) for s in [27,29,30,74,75]],
            avatar_interface=[interface(name,'PWC.Level.ILevelAvatar',i) for i in [4,7,8,9,10,12,13,15,19]]))

    persistent=[]
    pt=types['PWC.PersistentData.IHasPersistentData']
    pu=nav.metadata_usage(elf,0x41c9c38)
    nav.require((int(pu['encoded'],16)&0x1fffffff)>>1 == rawtypes[pt['index']][2], 'persistent usage join')
    for slow,fast,call,index,name in [(0x2294acc,0x2294ad8,0x2294ae8,0,'GetPersistentData'),
                                      (0x2295d88,0x2295d94,0x2295db0,1,'SetPersistentData')]:
        nav.require(nav.branch(slow,nav.word(elf,slow))['target']==0x1b7ba44,'persistent slow path')
        nav.expect(elf,slow-4 if index==0 else slow-8,0x2a1f03e2 if index==0 else 0x52800022)
        nav.expect(elf,fast,0x8b091108 if index==0 else 0x11000529)
        nav.expect(elf,call,0xd63f0100)
        target=byindex[pt['method_start']+index]
        nav.require(target['name']==name,'persistent declaration order')
        persistent.append(dict(interface_usage=pu,slow_resolver=hex(slow),fast_slot=hex(fast),
                               call=hex(call),interface_index=index,target=target,instructions=context(call)))

    step_callbacks=[]
    for receiver,start,eventoff,character in [('PWC.Level.LevelAnimal',0x2267430,0x3e8,False),
                    ('PWC.Level.LevelCharacterAnimator',0x22a66b4,0x68,True),
                    ('PWC.Level.LevelToddler',0x23442d4,0x448,False)]:
        expected=[0xf9400008 | ((eventoff//8)<<10),0xb40000c8,
                  0xf9400c01 if character else 0xaa0003e1,0xf9400d04,
                  0xf9402100,0xf9401503,0xd61f0080,0xd65f03c0]
        for i,w in enumerate(expected):nav.expect(elf,start+i*4,w)
        step_callbacks.append(dict(receiver=receiver,method=resolve(start),start=hex(start),stop=hex(start+32),
            window_sha256=nav.sha(binary[elf.offset(start,32):elf.offset(start,32)+32]),
            instructions=context(start+28,7),event_field_offset=hex(eventoff),event='OnStepContact',
            receiver_argument='animator._character' if character else 'this',
            behavior='null delegate returns; otherwise forwards receiver and incoming spineEvent; ignores trackEntry; no event-name filter'))

    declarations=[]
    for name in ['LevelAnimal','LevelCharacterAnimator','LevelToddler','LevelBaby','ILevelAvatar','LevelDropArea']:
        p=ROOT/'out/cpp2il/DiffableCs/Assembly-CSharp/PWC/Level'/f'{name}.cs'
        declarations.append(dict(path=str(p.relative_to(ROOT)),sha256=nav.sha(p.read_bytes())))
    spawn_types=[]
    for got,name in [(0x41b8a00,'PWC.Level.LevelSitArea'),(0x41bb970,'PWC.Level.LevelSleepArea'),
                     (0x41b8908,'PWC.Level.LevelDropArea')]:
        u=nav.metadata_usage(elf,got)
        nav.require((int(u['encoded'],16)&0x1fffffff)>>1 == rawtypes[types[name]['index']][2], 'spawn area type join')
        spawn_types.append(dict(type=name,usage=u))

    # Historical objdump text is accepted only after every displayed instruction matches.
    snapshots=[]
    for path in sorted((ROOT/'out/recon/tasks/T032/character-asm').glob('*.asm.txt')):
        if not any(path.name.startswith(p) for p in ['OnMovement_', 'OnBeginMovement_',
                    'PlaceAvatarInScene_', 'SaveDataInternal_', 'ApplyDataInternal_', 'OnEndLand_']):
            continue
        instructions=[]
        for line in path.read_text().splitlines():
            hit=re.match(r'\s*([0-9a-f]+):\s+([0-9a-f]{8})\s+(.+)',line)
            if hit:
                site,w=int(hit[1],16),int(hit[2],16)
                nav.expect(elf,site,w)
                instructions.append(dict(site=hex(site),word=hex(w),text=hit[3]))
        nav.require(bool(instructions),'empty snapshot')
        snapshots.append(dict(path=str(path.relative_to(ROOT)), sha256=nav.sha(path.read_bytes()),
                              verified_instruction_count=len(instructions)))
    return dict(schema_version=1, scope='static metadata/native dispatch joins; no target execution',
        native_sha256=nav.sha(binary),metadata_sha256=nav.sha(metadata),
        interface_usage=usage, virtual_calls=virtuals, interface_calls=interfaces,
        persistent_interface_calls=persistent,step_callbacks=step_callbacks,
        declaration_sources=declarations,spawn_area_types=spawn_types,
        families=family, verified_historical_disassembly=snapshots,
        limits=['Il2CppClass vtable base0x138/stride16 is correlated with native fast paths; live memory not observed.',
                'Native virtual receiver is conditional on declared field/base type; subclasses may override.',
                'Metadata methods and native pointers do not prove dynamic callback cardinality or full CFG.',
                'ILevelAvatar method indices are declaration order; concrete mappings use metadata interface offsets.'])


if __name__ == '__main__':
    ap=argparse.ArgumentParser(description=__doc__)
    ap.add_argument('--source',type=Path,default=ROOT/'out/recon/il2cpp')
    ap.add_argument('--report',type=Path,default=Path(__file__).with_name('dispatch.json'))
    a=ap.parse_args()
    report=build(a.source)
    nav.atomic_json(a.report,report)
    print(json.dumps(dict(virtual_calls=len(report['virtual_calls']),interface_calls=len(report['interface_calls']),
                          families=len(report['families']), report=str(a.report))))
