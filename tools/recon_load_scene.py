"""Verify the bounded GameSceneManager.LoadScene/LoadSceneImplement contract.

Static evidence only: no game execution, no semantic certification, no automatic
queue acceptance. The statics offsets are checked against the Cpp2IL dump by hand
(docs/RECON_LOAD_SCENE_CONTRACT.md), not read back from binary metadata.
"""
import argparse
import json
from pathlib import Path

import recon_navigation as nav

LOAD, LOAD_STOP = 0x20728d4, 0x2072c64
IMPL, IMPL_STOP = 0x2072cc8, 0x2072d84
TASK_OUTPUT = nav.ROOT / 'out/recon/tasks/T029/LOAD_SCENE'
LOAD_CALLS = {
    0x2072a58: ('UnityEngine.Debug', 'LogError', 'B'),
    0x2072a78: ('PWC.AvatarSpine.AvatarSpineTexturesManager', 'ClearAllTextureData', 'BL'),
    0x2072a98: ('PWC.SUTSystem.SUTUtils', 'ClearTexturesCache', 'BL'),
    0x2072ab8: ('PWC.CarsMaker.CarPartsLoader', 'ClearLoadedParts', 'BL'),
    0x2072ad8: ('PWC.CarsMaker.CarAppearance', 'ClearIconCache', 'BL'),
    0x2072b38: ('PWC.GameSceneManager', 'GetActiveSceneName', 'BL'),
    0x2072c54: ('PWC.LoadingScreen.LoadingScreenManager', 'StartSceneTransition', 'B'),
}
IMPL_CALLS = {
    0x2072d5c: ('PWC.Multiplayer.MPOwnership', 'Clear', 'BL'),
    0x2072d80: ('UnityEngine.SceneManagement.SceneManager', 'LoadSceneAsync', 'B'),
}
# Words that carry the decisive data flow (static offsets are GameSceneManager's:
# 0x0/0x8/0x10 Stage1-3 events, 0x20 PreviousSceneName, 0x28 CurrentlyLoadingSceneName,
# 0x30 IsSceneChangingInProgress; MPManager static 0x0 IsMultiplayerGame).
LOAD_ANCHORS = {
    0x2072a18: 0x3940c108, 0x2072a1c: 0x34000208,   # ldrb in-progress; cbz -> proceed
    0x2072b24: 0x52800028, 0x2072b28: 0x3900c008,   # in-progress = true
    0x2072b30: 0xf8028c01, 0x2072b48: 0xf8020d00,   # CurrentlyLoading, Previous names
    0x2072b60: 0xb40000c8, 0x2072b90: 0xb40000c8, 0x2072bc0: 0xb40000a8,  # stage null checks
    0x2072c34: 0xb4000134,                          # transition instance null check
}
IMPL_ANCHORS = {0x2072d34: 0x39400108, 0x2072d3c: 0x34000128}


def check_calls(elf, resolve, calls):
    out = []
    for site, (owner, name, kind) in calls.items():
        control = nav.branch(site, nav.word(elf, site))
        nav.require(control and control['kind'] == kind, f'call encoding mismatch at {site:#x}')
        targets = resolve(control['target'])
        nav.require(len(targets) == 1 and (targets[0]['declaring_type'], targets[0]['name']) == (owner, name),
                    f'callee mismatch at {site:#x}')
        out.append({'site': hex(site), 'target': targets[0]})
    return out


def verify(elf, meta, resolve, rows):
    for start, stop, name, token in [(LOAD, LOAD_STOP, 'LoadScene', None), (IMPL, IMPL_STOP, 'LoadSceneImplement', None)]:
        ident = resolve(start)
        nav.require(len(ident) == 1 and ident[0]['declaring_type'] == 'PWC.GameSceneManager'
                    and ident[0]['name'] == name, f'{name} identity mismatch')
    literal = nav.literal(meta, nav.metadata_usage(elf, nav.adrp_ldr(elf, 0x2072a28, 0x2072a34)['got_vaddr']))
    nav.require(literal['literal'] == 'Scene loading is already in progress!', 'in-progress literal mismatch')
    for address, expected in {**LOAD_ANCHORS, **IMPL_ANCHORS}.items():
        nav.expect(elf, address, expected)
    return {'load_scene': resolve(LOAD)[0], 'load_scene_implement': resolve(IMPL)[0],
            'in_progress_literal': literal,
            'load_scene_calls': check_calls(elf, resolve, LOAD_CALLS),
            'implement_calls': check_calls(elf, resolve, IMPL_CALLS),
            'verified_operand_anchors': len(LOAD_ANCHORS) + len(IMPL_ANCHORS)}


def run(source, output):
    binary = (source / 'libil2cpp.so').read_bytes()
    metadata = (source / 'global-metadata.dat').read_bytes()
    nav.verify_pair(binary, metadata)
    elf, meta = nav.Elf(binary), nav.Metadata(metadata)
    rows, resolve = nav.load_index(source / 'metadata_methods.jsonl', elf, meta)
    contract = verify(elf, meta, resolve, rows)
    contract.update(schema_version=1, status='static_candidate_not_runtime_validated',
                    native_sha256=nav.sha(binary), metadata_sha256=nav.sha(metadata))
    contract['candidate'] = [
        'LoadScene(sceneName, considerMultiplayer, mp_nextSceneId) allocates a closure with the three arguments.',
        'If IsSceneChangingInProgress: Debug.LogError("Scene loading is already in progress!") and return; scene not changed.',
        'Else clear Spine, SUT, car-part and car-icon caches (static helpers, no arguments).',
        'Set IsSceneChangingInProgress=true, CurrentlyLoadingSceneName=sceneName, PreviousSceneName=GetActiveSceneName().',
        'Invoke OnBeforeSceneLoadStage1, Stage2, Stage3 actions in order when non-null.',
        'LoadingScreenManager.Instance.StartSceneTransition(new Action(closure.<LoadScene>b__0)); null Instance -> failure helper.',
        'After the fade, <LoadScene>b__0 (T029 callback probe) routes to LoadSceneImplement or the multiplayer path.',
        'LoadSceneImplement(sceneName): if MPManager.IsMultiplayerGame then MPOwnership.Clear(); SceneManager.LoadSceneAsync(sceneName).',
    ]
    contract['unknowns'] = [
        'IsSceneAvailable is not called by LoadScene itself; behaviour for an unavailable scene is the Unity LoadSceneAsync failure path.',
        'Who resets IsSceneChangingInProgress to false (OnActiveSceneChanged / CancelCurrentSceneChangingProgress not decoded).',
        'Subscribers of Stage1-3 actions and the fade implementation in StartSceneTransition.',
        'Exception edges and the complete method bodies; windows end at the next metadata method start.',
    ]
    nav.atomic_json(output / 'method-contract.json', contract)
    nav.atomic_json(output / 'result.json', {'status': 'partial', 'semantic_completion': False,
                                              'contract': str(output / 'method-contract.json'),
                                              'unknowns': contract['unknowns']})
    return contract


if __name__ == '__main__':
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--source', type=Path, default=nav.ROOT / 'out/recon/il2cpp')
    parser.add_argument('--output', type=Path, default=TASK_OUTPUT)
    args = parser.parse_args()
    args.output.mkdir(parents=True, exist_ok=True)
    report = run(args.source, args.output)
    print(json.dumps({'status': report['status'], 'anchors': report['verified_operand_anchors'],
                      'output': str(args.output)}))
