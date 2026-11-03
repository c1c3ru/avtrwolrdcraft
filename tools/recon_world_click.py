"""Verify the bounded building-tap contract: WorldBuilding click -> LoadScene.

Static evidence only: no game execution, no semantic certification, no automatic
queue acceptance. Field offsets (+0x48 buildingType, +0x4c default level, +0x50 valid
levels, +0x88 OnClickBuildingAction, +0x90 OnClickAction) come from the Cpp2IL dump.
"""
import argparse
import json
from pathlib import Path

import recon_navigation as nav

TASK_OUTPUT = nav.ROOT / 'out/recon/tasks/T029/WORLD_CLICK'
METHODS = {
    0x2108cc4: ('PWC.World.Buildings.WorldBuilding', 'OnPointerClickInternal'),
    0x2108e90: ('PWC.World.Buildings.WorldBuilding', 'ClickOnLevel'),
    0x2102b1c: ('PWC.World.WorldEnterableEntity', 'LoadScene'),
    0x2109220: ('PWC.World.Buildings.WorldBuildingsDataManager', 'SaveBuildingData'),
    0x2109014: ('PWC.World.Buildings.WorldBuildingsDataManager', 'TryLoadBuildingData'),
    0x2072888: ('PWC.GameSceneManager', 'SetCurrentWorldSceneName'),
    0x2102aa0: ('PWC.World.WorldEnterableEntity', 'OnPointerClick'),
}
CALLS = {
    0x2108e30: ('PWC.World.Buildings.WorldBuildingsDataManager', 'TryLoadBuildingData', 'BL'),
    0x2108e78: ('PWC.World.Buildings.WorldBuilding', 'ClickOnLevel', 'BL'),
    0x2108f28: ('PWC.InteractionHistory.InteractionHistoryManager', 'MarkBuildingAsInteracted', 'BL'),
    0x2108f68: ('PWC.InteractionHistory.InteractionHistoryManager', 'SetFocusedBuildingType', 'BL'),
    0x2108f90: ('PWC.World.Buildings.WorldBuilding', 'IsCurrentlyFree', 'BL'),
    0x2108f9c: ('PazuCore.Utils', 'IsGameUnlocked', 'BL'),
    0x2108fb0: ('UnityEngine.Events.UnityEvent', 'Invoke', 'BL'),
    0x2108fbc: ('PWC.World.Buildings.WorldBuildingsDataManager', 'SaveBuildingData', 'BL'),
    0x2108fc8: ('PWC.CoreExtensions', 'GetSceneName', 'BL'),
    0x2108ffc: ('PWC.World.Buildings.WorldBuilding', 'TryGetRemoteConfigItem', 'BL'),
    0x2109008: ('PWC.World.WorldBuildingPreviewPopup', 'Show', 'BL'),
    0x2102b7c: ('PazuCore.SoundManager', 'Stop', 'BL'),
    0x2102b94: ('PWC.GameSceneManager', 'GetActiveSceneName', 'BL'),
    0x2102b9c: ('PWC.GameSceneManager', 'SetCurrentWorldSceneName', 'BL'),
    0x2102bb8: ('PWC.GameSceneManager', 'LoadScene', 'B'),
    0x2109314: ('UnityEngine.PlayerPrefs', 'SetString', 'BL'),
    0x20728d0: ('UnityEngine.PlayerPrefs', 'SetString', 'B'),
    0x2108d8c: ('UnityEngine.Object', 'op_Inequality', 'BL'),
    0x21090d0: ('UnityEngine.PlayerPrefs', 'GetString', 'BL'),
    0x21090dc: ('System.String', 'IsNullOrEmpty', 'BL'),
}
LITERALS = {  # (adrp, ldr) -> literal
    (0x2109258, 0x210925c): 'WorldBuildingData_',
    (0x21092c8, 0x21092cc): 'WorldBuildingData_',
    (0x20728a8, 0x20728ac): 'GAME_CURRENT_WORLD',
}
ANCHORS = {
    # level choice: multiplayer -> default (+0x4c); else saved level kept only if in valid list (+0x50)
    0x2108e1c: 0x34000068, 0x2108e20: 0xb9404e61, 0x2108e28: 0xb9404a60,
    0x2108e40: 0x6b08003f, 0x2108e44: 0x54000180, 0x2108e5c: 0x3100041f, 0x2108e60: 0x54000060,
    # access gate: SettingsManager.Instance -> ExtraSettings(+0x28) -> useTimeLock(+0x73); IsCurrentlyFree; IsGameUnlocked
    0x2108f7c: 0xf9401508, 0x2108f6c: 0xf94002a8,
    0x2108f84: 0x3941cd08, 0x2108f94: 0x37000080, 0x2108fa0: 0x360002a0,
    # SaveBuildingData(buildingType @+0x48, level); virtual LoadScene slot loaded from vtable
    0x2108fb4: 0xb9404a60, 0x2108fb8: 0x2a1403e1, 0x2108fd8: 0xf9414d09, 0x2108fdc: 0xf9415102,
    0x2108fe0: 0xd63f0120,
    # WorldEnterableEntity.LoadScene: Stop(1001), then LoadScene(scene, true, null)
    0x2102b74: 0x52807d21, 0x2102ba8: 0x52800021,
    # SaveBuildingData skips PlayerPrefs.SetString when multiplayer
    0x21092a0: 0x350003c8,
    # UGC gate: UGCManager static Instance(+0x30) alive and IsEditMode(+0x28) -> return without entering
    0x2108d70: 0xf9401934, 0x2108d90: 0x360002c0, 0x2108dd8: 0xf9401908,
    0x2108de0: 0x3940a108, 0x2108de4: 0x350004c8, 0x2108e88: 0xd65f03c0,
    # TryLoadBuildingData: empty/null string -> level 0 and false; else generic Enum.TryParse
    0x21090e0: 0x36000080, 0x21090e4: 0x2a1f03e0, 0x21090e8: 0xb900027f, 0x210911c: 0x940fd583,
    # OnPointerClick: ignore when PointerEventData.dragging(+0x145) or WorldResetManager.IsGameInResetMode(+0x18)
    0x2102aac: 0x39451428, 0x2102ab0: 0x35000208, 0x2102ae8: 0x39406108, 0x2102aec: 0x34000088,
    0x2102b08: 0xf9414502, 0x2102b0c: 0xf9414901, 0x2102b14: 0xd61f0040,
}


def verify(elf, meta, resolve):
    for site, (owner, name) in METHODS.items():
        ident = resolve(site)
        nav.require(len(ident) == 1 and (ident[0]['declaring_type'], ident[0]['name']) == (owner, name),
                    f'{name} identity mismatch')
    literals = []
    for (adrp, ldr), expected in LITERALS.items():
        found = nav.literal(meta, nav.metadata_usage(elf, nav.adrp_ldr(elf, adrp, ldr)['got_vaddr']))
        nav.require(found['literal'] == expected, f'literal mismatch at {ldr:#x}')
        literals.append({'site': hex(ldr), 'literal': found['literal']})
    for address, expected in ANCHORS.items():
        nav.expect(elf, address, expected)
    confirmed = []
    for site, (owner, name, kind) in CALLS.items():
        control = nav.branch(site, nav.word(elf, site))
        nav.require(control and control['kind'] == kind, f'call encoding mismatch at {site:#x}')
        targets = resolve(control['target'])
        nav.require(len(targets) == 1 and (targets[0]['declaring_type'], targets[0]['name']) == (owner, name),
                    f'callee mismatch at {site:#x}')
        confirmed.append({'site': hex(site), 'target': targets[0]})
    return {'methods': {hex(a): list(v) for a, v in METHODS.items()}, 'literals': literals,
            'verified_calls': confirmed, 'verified_operand_anchors': len(ANCHORS)}


def run(source, output):
    binary = (source / 'libil2cpp.so').read_bytes()
    metadata = (source / 'global-metadata.dat').read_bytes()
    nav.verify_pair(binary, metadata)
    elf, meta = nav.Elf(binary), nav.Metadata(metadata)
    _, resolve = nav.load_index(source / 'metadata_methods.jsonl', elf, meta)
    contract = verify(elf, meta, resolve)
    contract.update(schema_version=1, status='static_candidate_not_runtime_validated',
                    native_sha256=nav.sha(binary), metadata_sha256=nav.sha(metadata))
    contract['candidate'] = [
        'OnPointerClick(eventData): ignored when eventData.dragging or WorldResetManager.IsGameInResetMode; else virtual OnPointerClickInternal (tail branch through vtable).',
        'OnPointerClickInternal gate: if UGCManager.Instance is alive and Instance.IsEditMode then return (no scene change). Otherwise pick level.',
        'Level: MPManager.IsMultiplayerGame -> defaultLevel(+0x4c); else TryLoadBuildingData(buildingType); '
        'saved level is used only if it differs from default and List<LevelType>.IndexOf(valid list +0x50) != -1; else default.',
        'Then this.ClickOnLevel(level).',
        'ClickOnLevel: invoke OnClickBuildingAction(this, level) if set; InteractionHistory.MarkBuildingAsInteracted and SetFocusedBuildingType.',
        'Gate: SettingsManager.Instance.ExtraSettings.useTimeLock (GameExtraSettings +0x73, dump) nonzero -> enter; else enter only if IsCurrentlyFree() or Utils.IsGameUnlocked(null); null Instance/ExtraSettings -> failure helper; otherwise TryGetRemoteConfigItem + WorldBuildingPreviewPopup.Show(buildingType, item) and do not enter.',
        'Enter: OnClickAction.Invoke() if set; SaveBuildingData(buildingType, level); scene = GetSceneName(level) ("Level_"+name); virtual LoadScene(scene).',
        'SaveBuildingData: unless multiplayer, PlayerPrefs.SetString("WorldBuildingData_"+buildingType, level.ToString()). TryLoadBuildingData reads it with default "" and parses.',
        'WorldEnterableEntity.LoadScene(scene): SoundManager.Stop(1001) if instance; SetCurrentWorldSceneName(GetActiveSceneName()) -> PlayerPrefs.SetString("GAME_CURRENT_WORLD", activeScene); GameSceneManager.LoadScene(scene, true, null).',
    ]
    contract['unknowns'] = [
        'Virtual slot 0x298 in ClickOnLevel is inferred to be LoadScene(string) from the dump (WorldEnterableEntity override); vtable not decoded.',
        'Meaning of useTimeLock at the gate: its polarity is decoded (nonzero skips the free/unlocked check) but its semantics and the shipped value are not recovered (ScriptableObject data not read).',
        'Virtual slot for OnPointerClickInternal in OnPointerClick (0x288/0x290 pair) is not decoded; only the abstract declaration in the dump is known.',
        'TryLoadBuildingData tail is a generic Enum.TryParse<LevelType>(string, out level) (0x210911c, generic instance not resolved by name): unparsable string -> false, level left at its parse default.',
        'MarkBuildingAsInteracted/SetFocusedBuildingType effects; preview popup UI.',
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
    print(json.dumps({'status': report['status'], 'calls': len(report['verified_calls']),
                      'anchors': report['verified_operand_anchors'], 'output': str(args.output)}))
