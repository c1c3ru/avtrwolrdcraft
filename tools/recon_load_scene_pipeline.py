"""Static proof of the scene-change pipeline around GameSceneManager.LoadScene.

Covers LoadScene (reentrancy guard, cache clears, state, stage events, delegate),
LoadSceneImplement and OnActiveSceneChanged (state reset). Reads libil2cpp.so and
global-metadata.dat only; nothing is executed.
"""
import argparse
import json
from pathlib import Path

import recon_callback_probe as callback
import recon_navigation as nav

CALLBACK_TOKEN = '0x0600570f'
WINDOWS = {  # name -> (start, exclusive stop); stop is the next metadata method start
    'LoadScene': (0x20728d4, 0x2072c5c),
    'LoadSceneImplement': (0x2072cc8, 0x2072d84),
    'OnActiveSceneChanged': (0x2072644, 0x207271c),
}
CLEAR_CALLS = ['AvatarSpineTexturesManager.ClearAllTextureData', 'SUTUtils.ClearTexturesCache',
               'CarPartsLoader.ClearLoadedParts', 'CarAppearance.ClearIconCache']
# GameSceneManager static field offsets (Cpp2IL declarations, PWC/GameSceneManager.cs).
FIELDS = {0x0: 'OnBeforeSceneLoadStage1Action', 0x8: 'OnBeforeSceneLoadStage2Action',
          0x10: 'OnBeforeSceneLoadStage3Action', 0x20: 'PreviousSceneName',
          0x28: 'CurrentlyLoadingSceneName', 0x30: 'IsSceneChangingInProgress',
          0x40: 'Multiplayer_LoadingSceneNameInProgress'}


def decode(word, mask, value, fields):
    if word & mask != value:
        return None
    return {name: getter(word) for name, getter in fields.items()}


REG = {'rt': lambda w: w & 31, 'rn': lambda w: (w >> 5) & 31}
LDRB = lambda w: decode(w, 0xffc00000, 0x39400000, {**REG, 'imm': lambda w: (w >> 10) & 0xfff})
STRB = lambda w: decode(w, 0xffc00000, 0x39000000, {**REG, 'imm': lambda w: (w >> 10) & 0xfff})
LDR_X = lambda w: decode(w, 0xffc00000, 0xf9400000, {**REG, 'imm': lambda w: ((w >> 10) & 0xfff) * 8})
STR_X_PRE = lambda w: decode(w, 0xffe00c00, 0xf8000c00, {**REG, 'imm': lambda w: (w >> 12) & 0xff})


def at(elf, address, decoder, **expected):
    decoded = decoder(nav.word(elf, address))
    nav.require(decoded is not None and all(decoded[k] == v for k, v in expected.items()),
                f'instruction mismatch at {address:#x}: {decoded} vs {expected}')


def controls(elf, resolve, start, stop):
    found = {}
    for address in range(start, stop, 4):
        control = nav.branch(address, nav.word(elf, address))
        if control and control['kind'] in ('BL', 'B') and control['target'] is not None:
            found[address] = {**control, 'rows': resolve(control['target'])}
    return found


def label(row):
    return '%s.%s' % (row['declaring_type'].rsplit('.', 1)[-1], row['name'])


def class_at(elf, meta, adrp_site, ldr_site):
    return callback.typedef_name(meta, nav.metadata_usage(elf, nav.adrp_ldr(elf, adrp_site, ldr_site)['got_vaddr']))


GAME_SCENE_MANAGER_SLOT = 0x41b4e60  # class slot is not a plain encoded usage; identity is by declared layout


def same_slot(elf, adrp_site, ldr_site, expected=GAME_SCENE_MANAGER_SLOT):
    nav.require(nav.adrp_ldr(elf, adrp_site, ldr_site)['got_vaddr'] == expected,
                f'class slot mismatch at {adrp_site:#x}')


def prove_load_scene(elf, meta, resolve, rows):
    start, stop = WINDOWS['LoadScene']
    calls = controls(elf, resolve, start, stop)
    named = [(a, label(c['rows'][0])) for a, c in sorted(calls.items()) if c['rows']]
    clear_sites = [a for a, n in named if n in CLEAR_CALLS]
    nav.require([n for _, n in named if n in CLEAR_CALLS] == CLEAR_CALLS, 'cache-clear sequence changed')
    # Reentrancy guard: GameSceneManager.IsSceneChangingInProgress (+0x30) -> LogError -> return.
    same_slot(elf, 0x207299c, 0x20729a4)
    at(elf, 0x2072a18, LDRB, imm=0x30, rn=8)
    guard = nav.branch(0x2072a1c, nav.word(elf, 0x2072a1c))
    nav.require(guard['kind'] == 'CBZ' and guard['target'] == 0x2072a5c, 'guard branch mismatch')
    error = calls[0x2072a58]
    nav.require(error['kind'] == 'B' and label(error['rows'][0]) == 'Debug.LogError', 'guard does not log an error')
    message = nav.literal(meta, nav.metadata_usage(elf, nav.adrp_ldr(elf, 0x2072a28, 0x2072a34)['got_vaddr']))
    nav.require(message['literal'] == 'Scene loading is already in progress!', 'guard message mismatch')
    # State written before the transition starts.
    at(elf, 0x2072b28, STRB, rt=8, imm=0x30)
    nav.require(nav.word(elf, 0x2072b24) == 0x52800028, 'flag value is not constant 1')
    at(elf, 0x2072b30, STR_X_PRE, imm=0x28)
    at(elf, 0x2072b48, STR_X_PRE, imm=0x20)
    nav.require(label(calls[0x2072b38]['rows'][0]) == 'GameSceneManager.GetActiveSceneName', 'previous-scene source changed')
    nav.require(max(clear_sites) < 0x2072b28, 'caches are not cleared before the flag is set')
    # Stage events 1..3 are loaded from static+0x0/0x8/0x10 and invoked when non-null.
    at(elf, 0x2072b5c, LDR_X, imm=0x0)
    at(elf, 0x2072b8c, LDR_X, imm=0x8)
    at(elf, 0x2072bbc, LDR_X, imm=0x10)
    for site in (0x2072b70, 0x2072ba0, 0x2072bd0):
        nav.require(nav.branch(site, nav.word(elf, site))['kind'] == 'BLR', f'stage invoke is not BLR at {site:#x}')
    # Delegate bound to <LoadScene>b__0 and handed to LoadingScreenManager.Instance.StartSceneTransition.
    callback_row = [r for r in rows if r['token'] == CALLBACK_TOKEN]
    nav.require(len(callback_row) == 1 and callback_row[0]['name'] == '<LoadScene>b__0', 'callback row missing')
    method_usage = nav.metadata_usage(elf, nav.adrp_ldr(elf, 0x2072c18, 0x2072c1c)['got_vaddr'])
    nav.require(method_usage['kind'] == 3 and method_usage['index'] == callback_row[0]['method_definition_index'],
                'delegate method is not <LoadScene>b__0')
    nav.require(label(calls[0x2072c30]['rows'][0]) == 'Action..ctor', 'delegate constructor mismatch')
    at(elf, 0x2072c0c, LDR_X, rt=20, rn=8, imm=0)
    nav.require(class_at(elf, meta, 0x2072bf4, 0x2072bf8) == 'PWC.LoadingScreen.LoadingScreenManager',
                'transition receiver class mismatch')
    tail = calls[0x2072c54]
    nav.require(tail['kind'] == 'B' and label(tail['rows'][0]) == 'LoadingScreenManager.StartSceneTransition',
                'LoadScene tail call mismatch')
    return {
        'class_identity': 'GameSceneManager inferred from declared static layout; class slot 0x41b4e60 has no decodable usage',
        'reentrancy_guard': {'field': FIELDS[0x30], 'on_true': 'Debug.LogError(%r) and return' % message['literal']},
        'cache_clears_in_order': CLEAR_CALLS,
        'state_before_transition': ['%s = true' % FIELDS[0x30], '%s = sceneName' % FIELDS[0x28],
                                    '%s = GetActiveSceneName()' % FIELDS[0x20]],
        'stage_events_invoked_if_non_null': [FIELDS[0x0], FIELDS[0x8], FIELDS[0x10]],
        'transition': 'LoadingScreenManager.Instance.StartSceneTransition(new Action(closure, <LoadScene>b__0))',
        'delegate_method_token': CALLBACK_TOKEN,
    }


def prove_implement(elf, meta, resolve):
    calls = controls(elf, resolve, *WINDOWS['LoadSceneImplement'])
    nav.require(class_at(elf, meta, 0x2072d0c, 0x2072d10) == 'PWC.Multiplayer.MPManager', 'flag class mismatch')
    at(elf, 0x2072d34, LDRB, imm=0, rn=8)
    guard = nav.branch(0x2072d3c, nav.word(elf, 0x2072d3c))
    nav.require(guard['kind'] == 'CBZ' and guard['target'] == 0x2072d60, 'multiplayer skip branch mismatch')
    clear = calls[0x2072d5c]
    nav.require(label(clear['rows'][0]) == 'MPOwnership.Clear' and clear['rows'][0]['parameter_count'] == 0,
                'MPOwnership.Clear call mismatch')
    nav.require(nav.word(elf, 0x2072cd8) == 0xaa0003f3 and nav.word(elf, 0x2072d70) == 0xaa1303e0,
                'sceneName is not forwarded unchanged')
    tail = calls[0x2072d80]
    row = tail['rows'][0]
    nav.require(tail['kind'] == 'B' and label(row) == 'SceneManager.LoadSceneAsync' and row['parameter_count'] == 1,
                'LoadSceneImplement tail call mismatch')
    return {'if_multiplayer': 'MPOwnership.Clear()',
            'then': 'tail call SceneManager.LoadSceneAsync(sceneName) (1-parameter overload; result discarded, void)'}


def prove_scene_changed(elf, meta):
    same_slot(elf, 0x2072650, 0x2072658)
    at(elf, 0x20726c0, STRB, rt=31, imm=0x30)
    at(elf, 0x20726f8, STR_X_PRE, rt=31, imm=0x40)
    at(elf, 0x2072710, STR_X_PRE, rt=31, imm=0x28)
    return {'resets': ['%s = false' % FIELDS[0x30], '%s = null' % FIELDS[0x40], '%s = null' % FIELDS[0x28]],
            'caveat': 'who subscribes this handler to SceneManager.activeSceneChanged is not proven here'}


def probe(source):
    binary = (source / 'libil2cpp.so').read_bytes()
    metadata = (source / 'global-metadata.dat').read_bytes()
    nav.verify_pair(binary, metadata)
    elf, meta = nav.Elf(binary), nav.Metadata(metadata)
    rows, resolve = nav.load_index(source / 'metadata_methods.jsonl', elf, meta)
    for name, (start, stop) in WINDOWS.items():
        owner = resolve(start)
        nav.require(len(owner) == 1 and owner[0]['name'] == name, f'{name} identity mismatch at {start:#x}')
        following = min(int(r['vaddr'], 16) for r in rows if r['vaddr'] and int(r['vaddr'], 16) > start)
        nav.require(following == stop, f'{name} next-method boundary mismatch')
    return {
        'schema_version': 1, 'scope': 'bounded static proof; no execution',
        'native_sha256': nav.sha(binary), 'metadata_sha256': nav.sha(metadata),
        'LoadScene': prove_load_scene(elf, meta, resolve, rows),
        'LoadSceneImplement': prove_implement(elf, meta, resolve),
        'OnActiveSceneChanged': prove_scene_changed(elf, meta),
    }


if __name__ == '__main__':
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--source', type=Path, default=nav.ROOT / 'out/recon/il2cpp')
    parser.add_argument('--report', type=Path, default=nav.ROOT / 'out/recon/load_scene_pipeline.json')
    args = parser.parse_args()
    nav.atomic_json(args.report, probe(args.source))
    print(f'Pipeline proof written to {args.report}')
