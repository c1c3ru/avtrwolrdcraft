"""Static proof, with slot names, of how contextual-animation handlers are added to and removed from a target.

Resolves every vtable-slot load feeding a virtual call in AddCAHandlerAndUpdateGame / RemoveCAHandlerAndUpdateGame
against Il2CppMethodDefinition.slot of LevelCAHandlerBase (not against position or signature guesses).
Reads libil2cpp.so and global-metadata.dat only; nothing is executed.
"""
import argparse
import bisect
from pathlib import Path

import recon_camera_drag as camera
import recon_load_scene_pipeline as pipe
import recon_navigation as nav
import recon_t031_dispatch as dispatch

EXT = 'PWC.Level.ContextualAnimation.CATargetExtensionMethods'
BASE = ('PWC.Level.ContextualAnimation', 'LevelCAHandlerBase')
WINDOWS = {
    'AddCAHandlerAndUpdateGame': (0x23ac654, 0x23aca54),
    'RemoveCAHandlerAndUpdateGame': (0x23acdb0, 0x23ad1d4),
}
# (site of the vtable load, expected slot, expected handler method)
ADD_SLOTS = [(0x23ac6cc, 6, 'IsValidForTarget'), (0x23ac770, 32, 'IsLockedToTarget'), (0x23ac934, 27, 'GetLockedAnimationName'),
             (0x23ac9c4, 12, 'OnAddedToTarget'), (0x23ac9d8, 39, 'IsRelevantForTarget'), (0x23aca08, 53, 'IsSilent')]
REMOVE_SLOTS = [(0x23acea4, 13, 'OnRemovedFromTarget'), (0x23ad098, 36, 'AllowReturnToIdleAnimationWhenRemovedFromTarget'),
                (0x23ad180, 53, 'IsSilent')]
# GetLockedAnimationName is called on the result of the previous call (the target's locked handler), not on the argument.
INFERRED_RECEIVER = {(0x23ac934, 27)}
ADD_CALLS =['Behaviour.get_enabled', 'CATargetExtensionMethods.AddCAHandler', 'Object.op_Inequality',
             'CATargetExtensionMethods.SetForceSitIfNeeded']
REMOVE_CALLS = ['Object.op_Equality', 'Object.op_Equality']


def handler_register(elf, start):
    """Register that receives the handler argument (x1) in the prologue: `mov xH, x1`."""
    found = [(nav.word(elf, a) & 31) for a in range(start, start + 0x40, 4) if nav.word(elf, a) & 0xffe0ffe0 == 0xaa0003e0
             and (nav.word(elf, a) >> 16) & 31 == 1]
    nav.require(len(found) == 1, 'cannot identify the handler register')
    return found[0]


def receiver_register(elf, site):
    """Register R in the `ldr xT,[xR]` (object header load) that feeds the `ldp` slot load at `site`."""
    base = (nav.word(elf, site) >> 5) & 31
    for address in range(site - 4, site - 20, -4):
        word = nav.word(elf, address)
        if word & 0xffc00000 == 0xf9400000 and (word >> 10) & 0xfff == 0 and word & 31 == base:
            return (word >> 5) & 31
    raise ValueError(f'no object-header load before {site:#x}')


def slot_load(elf, site):
    word = nav.word(elf, site)
    decoded = pipe.LDR_X(word) or camera.LDP_X(word)
    nav.require(decoded is not None, f'no LDR/LDP at {site:#x}')
    nav.require(decoded['imm'] >= 0x138 and (decoded['imm'] - 0x138) % 16 == 0, f'not a vtable slot load at {site:#x}')
    return dispatch.slot_from_offset(decoded['imm'])


def prove_window(elf, meta, resolve, name, slots, calls):
    start, stop = WINDOWS[name]
    owner = resolve(start)
    nav.require(len(owner) == 1 and owner[0]['name'] == name, f'{name} identity mismatch')
    named = dispatch.virtual_slots(meta, *BASE)
    ordered, handler = [], handler_register(elf, start)
    for site, slot, method in slots:
        nav.require(slot_load(elf, site) == slot, f'slot at {site:#x} is not {slot}')
        nav.require(named.get(slot, ('',))[0] == method, f'slot {slot} is not {method}')
        if (site, slot) not in INFERRED_RECEIVER:
            nav.require(receiver_register(elf, site) == handler, f'receiver of {method} at {site:#x} is not the handler argument')
        ordered.append(method)
    nav.require(sorted(s for s, _, _ in slots) == [s for s, _, _ in slots], f'{name} slot order is not ascending in address')
    names, _ = _named(elf, resolve, (start, stop))
    nav.require([n for _, n in names] == calls, f'{name} direct call sequence changed')
    return ordered


def _named(elf, resolve, window):
    found = pipe.controls(elf, resolve, *window)
    return [(a, pipe.label(c['rows'][0])) for a, c in sorted(found.items()) if c['rows']], found


EVENT_CLASS_SLOT = 0x41bd548   # CATargetEvents: class slot has no decodable usage; identity is by declared static layout (+0x8)


def prove_update_event(elf):
    """Both orchestrators end by invoking the static delegate at CATargetEvents+0x8 (Action<ICATarget,bool,bool>)."""
    for name, adrp_site, ldr_site, null_site, null_target, flag_site, flag_word, tail in [
            ('add', 0x23ac9e8, 0x23ac9ec, 0x23ac9fc, 0x23aca40, 0x23aca30, 0x52800022, 0x23aca3c),
            ('remove', 0x23ad160, 0x23ad164, 0x23ad174, 0x23ad1bc, 0x23ad1b0, 0x2a1f03e2, 0x23ad1b8)]:
        nav.require(nav.adrp_ldr(elf, adrp_site, ldr_site)['got_vaddr'] == EVENT_CLASS_SLOT, f'{name}: event class slot changed')
        pipe.at(elf, ldr_site + 8, pipe.LDR_X, rt=8, rn=8, imm=0xb8)                    # static fields
        pipe.at(elf, ldr_site + 12, pipe.LDR_X, rt=21, rn=8, imm=0x8)                   # static +0x8 = OnUpdateCAListAction
        control = nav.branch(null_site, nav.word(elf, null_site))
        nav.require(control['kind'] == 'CBZ' and control['target'] == null_target, f'{name}: null delegate does not skip the call')
        nav.require(nav.word(elf, flag_site) == flag_word, f'{name}: "added" flag argument changed')
        nav.require(nav.word(elf, tail) == 0xd61f00a0, f'{name}: delegate is not invoked by a tail call (br x5)')
    gate = nav.branch(0x23ac9e4, nav.word(elf, 0x23ac9e4))      # tbz w0,#0 after IsRelevantForTarget (slot 39 call at 0x23ac9e0)
    nav.require(gate['kind'] == 'TBZ' and gate['target'] == 0x23aca40, 'Add is not gated by IsRelevantForTarget')
    return {'add': 'if handler.IsRelevantForTarget(target): CATargetEvents.OnUpdateCAListAction?.Invoke(target, true, handler.IsSilent())',
            'remove': 'CATargetEvents.OnUpdateCAListAction?.Invoke(target, false, handler.IsSilent()) (no relevance gate)',
            'inference': 'class identity by declared layout: CATargetEvents static +0x8 is Action<ICATarget,bool,bool> OnUpdateCAListAction'}


def class_slot_users(elf, rows, got):
    """Methods that load the class slot `got` with an adrp+ldr pair (so: that touch the static class)."""
    named = sorted((int(r['vaddr'], 16), r['declaring_type'] + '.' + r['name']) for r in rows if r.get('vaddr'))
    starts = [a for a, _ in named]
    delta = int(rows[0]['vaddr'], 16) - int(rows[0]['file_offset'], 16)
    words = camera.np.frombuffer(elf.data[:len(elf.data) // 4 * 4], dtype='<u4')
    page, offset = got & ~0xfff, got & 0xfff
    candidates = camera.np.nonzero(((words & 0xffc00000) == 0xf9400000) & (((words >> 10) & 0xfff) == offset // 8))[0]
    owners = set()
    for i in candidates:
        base = int((words[i] >> 5) & 31)
        for back in range(1, 6):
            word = int(words[i - back])
            if word & 0x9f000000 == 0x90000000 and word & 31 == base:
                immediate = ((word >> 5) & 0x7ffff) << 2 | ((word >> 29) & 3)
                immediate = immediate - (1 << 21) if immediate & (1 << 20) else immediate
                if (((int(i) - back) * 4 + delta) & ~0xfff) + (immediate << 12) == page:
                    owners.add(named[bisect.bisect_right(starts, int(i) * 4 + delta) - 1][1])
                break
    return owners


EVENT_SUBSCRIBERS = {  # touch the CATargetEvents class in an Awake/OnDestroy pair (subscribe / unsubscribe)
    'PWC.LevelContextualAnimation.LevelContextualAnimationMenu', 'PWC.LevelContextualAnimation.LevelContextualAnimationItem',
    'Game.Level.ContextualAnimation.LevelCACellPhoneItemHandler', 'PWC.AvatarSpeech.AvatarSpeechUIMenu'}
EVENT_PUBLISHERS = {'PWC.Level.LevelCharacter.OnPointerClickInternal', 'PWC.Level.LevelToddler.OnPointerClickInternal',
                    'PWC.Level.LevelBaby.OnPointerClickInternal', 'PWC.Level.LevelAnimal.OnPointerClickInternal',
                    'PWC.Level.ContextualAnimation.CATargetExtensionMethods.AddCAHandlerAndUpdateGame',
                    'PWC.Level.ContextualAnimation.CATargetExtensionMethods.RemoveCAHandlerAndUpdateGame'}


def prove_event_users(elf, rows):
    users = class_slot_users(elf, rows, EVENT_CLASS_SLOT)
    for subscriber in EVENT_SUBSCRIBERS:
        for method in ('Awake', 'OnDestroy'):
            nav.require(f'{subscriber}.{method}' in users, f'{subscriber}.{method} does not touch CATargetEvents')
    nav.require(EVENT_PUBLISHERS <= users, f'publishers missing: {sorted(EVENT_PUBLISHERS - users)}')
    return {'subscribers_awake_ondestroy': sorted(EVENT_SUBSCRIBERS), 'publishers': sorted(EVENT_PUBLISHERS), 'methods_touching_events': len(users),
            'caveat': 'touching the class slot does not prove which of the three static delegates is used'}


NAME_WINDOWS = {'CreateAnimationName': (0x212fe74, 0x2130054), 'HasCAPrefixForCAAnimations': (0x2187938, 0x2187954)}
CA_PREFIX_WORDS = [0x51000408, 0x7100091f, 0x1a9f27e8, 0x7100341f, 0x1a9f17e9, 0x2a080120, 0xd65f03c0]
# sub w8,w0,#1; cmp w8,#2; cset w8,lo; cmp w0,#13; cset w9,eq; orr w0,w9,w8; ret  ==>  (t-1) < 2 (1 or 2) || t == 13


def prove_name_rule(elf, meta, resolve, rows):
    for name, (start, stop) in NAME_WINDOWS.items():
        owner = resolve(start)
        nav.require(len(owner) == 1 and owner[0]['name'] == name, f'{name} identity mismatch')
        following = min(int(r['vaddr'], 16) for r in rows if r['vaddr'] and int(r['vaddr'], 16) > start)
        nav.require(following == stop, f'{name} next-method boundary mismatch')
    nav.require([nav.word(elf, a) for a in range(0x2187938, 0x2187954, 4)] == CA_PREFIX_WORDS, 'HasCAPrefixForCAAnimations logic changed')
    spine = SPINE_TYPES
    named = dispatch.virtual_slots(meta, *BASE)
    pipe.at(elf, 0x212fed4, pipe.LDRB, rn=20, imm=0x2c)                       # config.isNameFullAnimationName
    pipe.at(elf, 0x212fedc, pipe.LDR_X, rt=0, rn=20, imm=0x10)                # ... -> return config.name
    pipe.at(elf, 0x212fef4, pipe.LDR_X, rt=0, rn=20, imm=0x20)                # config.folderNameOverride
    for site, slot, method in [(0x212ff10, 7, 'GetFolderName'), (0x212ff30, 52, 'GetSpineType'), (0x2130008, 54, 'GetAnimationSuffix')]:
        nav.require(slot_load(elf, site) == slot and named.get(slot, ('',))[0] == method, f'slot {slot} is not {method}')
        nav.require(receiver_register(elf, site) == 19, f'{method} is not called on the handler argument')
    literals = {}
    for key, (adrp_site, ldr_site) in {'prefix': (0x212ff44, 0x212ff50), 'empty': (0x212ff48, 0x212ff54), 'separator': (0x212ffc4, 0x212ffc8)}.items():
        usage = nav.metadata_usage(elf, nav.adrp_ldr(elf, adrp_site, ldr_site)['got_vaddr'])
        literals[key] = nav.literal(meta, usage)['literal']
    nav.require(literals == {'prefix': 'CA/', 'empty': '', 'separator': '/'}, f'literals changed: {literals}')
    nav.require(nav.word(elf, 0x212ff64) == 0x9a891108, 'prefix is not chosen with csel ...,ne')                    # ne -> "CA/"
    nav.require(nav.word(elf, 0x212ff60) == 0x528000a1, 'array length is not 5')                                    # mov w1,#5
    for site, offset in [(0x212ff88, 0x20), (0x212ffa8, 0x28), (0x212ffd4, 0x30), (0x212fff4, 0x38), (0x2130028, 0x40)]:
        word = nav.word(elf, site)
        nav.require(word & 0xffe00c00 == 0xf8000c00 and (word >> 12) & 0x1ff == offset, f'array element store changed at {site:#x}')
    nav.require(nav.word(elf, 0x212ffec) == 0xf9400a81, 'config.name is not element 3')                              # ldr x1,[x20,#0x10]
    return {
        'rule': 'isNameFullAnimationName ? config.name : String.Concat(prefix, folder, "/", config.name, handler.GetAnimationSuffix())',
        'folder': 'config.folderNameOverride unless empty, else handler.GetFolderName()',
        'prefix': f'"CA/" when HasCAPrefixForCAAnimations(handler.GetSpineType()) else ""; true for SpineType {spine["Character"]} (Character), '
                  f'{spine["Baby"]} (Baby), {spine["Toddler"]} (Toddler)',
        'literals': literals,
    }


SPINE_TYPES = {'Character': 1, 'Baby': 2, 'Toddler': 13}
CA = 'PWC.Level.ContextualAnimation.CATargetExtensionMethods'
# Direct callers that must be present (containment). Grouped by what starts the animation.
TRIGGERS = {
    'PlayContextualAnimation': {
        'user menu': {'PWC.LevelContextualAnimation.LevelContextualAnimationMenu.OnAnimationItemClick'},
        'multiplayer replay': {'PWC.Multiplayer.MPDataHelper_CA.HandleData'},
        'spawn / randomizer': {'PWC.Level.LevelCharactersRandomizer.HandleCAHandlers', 'PWC.Level.LevelAvatarOneTimeSpawner.HandleCAHandlers',
                               'Game.Level.LevelInitCharacterStateOnPack.InitIfNeeded', 'Game.Level.LevelInitAnimalStateOnPack.InitIfNeeded'},
        'drop-area events': {'Game.Level.ContextualAnimation.LevelCAAlterSideDropAreaHandler.OnEventTrigger',
                             'Game.Level.ContextualAnimation.LevelCAPenaltyKickDropAreaHandler.OnAnimationBegin',
                             'Game.Level.LevelFoodFightDropAreaHandler.SpawnAndThrowGoo'},
        'conductor (reaction on others)': {'Game.Level.ContextualAnimation.LevelCAConductorDropAreaHandler.SetAnimationOnOther'},
    },
    'AddCAHandlerAndUpdateGame': {
        'item drop lands': {'PWC.Level.LevelDropActionAreaWithCAData.OnItemEndLand'},
        'pair interaction': {'PWC.Level.LevelPairInteractionAreaBase.TryAddCAHandler'},
        'gear ramps/rails': {'PWC.Level.LevelSkateboardItemHandler.AddRampDropAreaCA', 'PWC.Level.LevelSnowboardItemHandler.AddRailDropAreaCA',
                             'PWC.Level.LevelRollerBladesItemHandler.AddRampDropAreaCA', 'PWC.Level.LevelToddlerCarItemHandler.AddRampDropAreaCA'},
        'clothing': {'PWC.Level.LevelClothingUtils.TryAddCAHandlerFromSkinName'},
        'carrying': {'Game.Level.ContextualAnimation.LevelBabyOnCharacterHandlerSelector.AddCarrierHandler',
                     'Game.Level.ContextualAnimation.LevelDogOnCharacterHandlerSelector.AddCarrierHandler',
                     'Game.Level.ContextualAnimation.LevelToddlerOnCharacterHandlerSelector.AddCarrierHandler'},
        'weather': {'Game.Level.LevelAddCAOnAllCharactersHandlerByWeather.AddCaScriptToAvatar'},
        'character init': {'PWC.Level.LevelCharacter.Init'},
    },
    'RemoveCAHandlerAndUpdateGame': {
        'drag begin': {'PWC.Level.LevelDropActionAreaWithCAData.OnBeginDrag'},
        'pair interaction': {'PWC.Level.LevelPairInteractionAreaBase.TryRemoveCurrentCAHandler'},
        'clothing': {'PWC.Level.LevelClothingUtils.TryRemoveCAHandlerFromSkinName'},
        'weather': {'Game.Level.LevelAddCAOnAllCharactersHandlerByWeather.RemoveCAScriptFromAvatar'},
        'pair animation begin': {'PWC.Level.ContextualAnimation.LevelCAPairAnimalNearCharacterHandlerBase.OnAnimationBegin',
                                 'Game.Level.ContextualAnimation.LevelCAPairCharacterNearCharacterHandler.OnAnimationBegin'},
    },
}


def prove_triggers(elf, rows):
    by_name = {r['name']: int(r['vaddr'], 16) for r in rows if r['declaring_type'] == CA and r.get('vaddr')}
    found = camera.direct_callers(elf, [r for r in rows if r.get('vaddr')], {n: by_name[n] for n in TRIGGERS})
    for method, groups in TRIGGERS.items():
        for group, expected in groups.items():
            nav.require(expected <= found[method], f'{method} {group}: missing {sorted(expected - found[method])}')
    return {method: {group: sorted(expected) for group, expected in groups.items()} for method, groups in TRIGGERS.items()}


def probe(source):
    binary = (source / 'libil2cpp.so').read_bytes()
    metadata = (source / 'global-metadata.dat').read_bytes()
    nav.verify_pair(binary, metadata)
    elf, meta = nav.Elf(binary), nav.Metadata(metadata)
    rows, resolve = nav.load_index(source / 'metadata_methods.jsonl', elf, meta)
    for name, (start, stop) in WINDOWS.items():
        following = min(int(r['vaddr'], 16) for r in rows if r['vaddr'] and int(r['vaddr'], 16) > start)
        nav.require(following == stop, f'{name} next-method boundary mismatch')
    return {
        'schema_version': 1, 'scope': 'bounded static proof; no execution',
        'native_sha256': nav.sha(binary), 'metadata_sha256': nav.sha(metadata),
        'add': {'handler_virtual_calls_in_order': prove_window(elf, meta, resolve, 'AddCAHandlerAndUpdateGame', ADD_SLOTS, ADD_CALLS),
                'direct_calls_in_order': ADD_CALLS,
                'inferred': ['GetLockedAnimationName is called on the target\'s locked handler (result of the previous call), '
                             'not on the handler argument; its slot name is proven, its receiver is inferred']},
        'remove': {'handler_virtual_calls_in_order': prove_window(elf, meta, resolve, 'RemoveCAHandlerAndUpdateGame', REMOVE_SLOTS, REMOVE_CALLS),
                   'direct_calls_in_order': REMOVE_CALLS},
        'triggers': prove_triggers(elf, rows),
        'animation_name': prove_name_rule(elf, meta, resolve, rows),
        'list_updated_event': prove_update_event(elf),
        'event_users': prove_event_users(elf, [r for r in rows if r.get('vaddr')]),
    }


if __name__ == '__main__':
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--source', type=Path, default=nav.ROOT / 'out/recon/il2cpp')
    parser.add_argument('--report', type=Path, default=nav.ROOT / 'out/recon/ca_lifecycle.json')
    args = parser.parse_args()
    nav.atomic_json(args.report, probe(args.source))
    print(f'CA lifecycle proof written to {args.report}')
