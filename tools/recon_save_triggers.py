"""Static proof of when the original saves/loads/resets progress, and of the PlayerPrefs keys involved.

Reads libil2cpp.so and global-metadata.dat only; nothing is executed. Direct bl/b call sites only
(see recon_camera_drag.direct_callers). A literal found inside a method window next to a PlayerPrefs
call is evidence the method uses that key, not proof of the key's role.
"""
import argparse
import bisect
import struct
from pathlib import Path

import recon_callback_probe as callback
import recon_camera_drag as camera
import recon_drop_priority as drop
import recon_load_scene_pipeline as pipe
import recon_navigation as nav

PDM = 'PWC.PersistentData.PersistentDataManager'
WINDOWS = {
    'OnBeforeSceneLoadStage2': (0x21e09b0, 0x21e09b4),
    'SaveProgressInAllScenes': (0x21e09b4, 0x21e0a48),
    'Awake': (0x21e0658, 0x21e0738),
    'CanSaveScene': (0x21e5f74, 0x21e6100),
    'OnApplicationPause': (0x21e6100, 0x21e6198),
}
GAME_SCENE_MANAGER_SLOT = pipe.GAME_SCENE_MANAGER_SLOT
EXPECTED_CALLERS = {  # PersistentDataManager method -> exact set of direct callers
    'SaveProgressInAllScenes': {f'{PDM}.OnApplicationPause', f'{PDM}.OnBeforeSceneLoadStage2'},
    'SaveProgress': {'PWC.Level.Maker.LevelMakerSplitLevelManager.SaveCurrentData',
                     'PWC.Multiplayer.MPManager.TrySaveCurrentSceneAndGetSceneData', f'{PDM}.SaveProgressInAllScenes'},
    'LoadProgress': {'PWC.Level.LevelManager.Init', 'PWC.Level.Maker.LevelMakerSplitLevelManager.LoadCurrentLevel',
                     'PWC.World.WorldManager.Init'},
    'DeleteDataForActiveScene': {'PWC.Level.LevelUpgradeTracker.ResetCurrentLevelPD'},
    'CanSaveScene': {f'{PDM}.OnApplicationPause'},
}
# method (suffix) -> literal keys that must appear in its window together with a PlayerPrefs call
KEYS = {
    'PWC.AvatarSpine.AvatarSpineDataManager.SaveCharacter': ['AvatarSpineData_'],
    'PWC.AvatarSpine.AvatarSpineDataManager.SaveIDList': ['AvatarSpineDataIDList'],
    'PWC.Level.LevelAvatarData.Save': ['LevelCharacterData_'],
    'PWC.Level.LevelAvatarData.SetIDsList': ['LevelCharacterData_List'],
    'PWC.World.Buildings.WorldBuildingsDataManager.SaveBuildingData': ['WorldBuildingData_'],
    'PWC.WorldMakerData.WorldMakerDataManager.SaveMakerHouseData': ['WorldMakerHouseData_'],
    'PWC.WorldMakerData.WorldMakerDataManager.SaveMakerStreetData': ['WorldMakerStreetData_'],
    f'{PDM}.SaveSceneObjectsToKeepOnLoad': ['PazuWorld_PersistantData_KeepObjectsOnLoad'],
    'PWC.AWGameSettings.SetMusicMute': ['AW_Mute_Music'],
    'PWC.AWGameSettings.SetSFXMute': ['AW_Mute_SFX'],
    'PWC.AWGameSettings.SetLanguageCode': ['AW_Language_Code'],
    'Game.Store.StoreManager.MigrateStateFileIfNeeded': ['Store_DidMigrateStateFileIfNeeded', 'StoreState'],
    'PWC.Inventory.ItemsTracker.InventoryItemsTracker.MigrateStateFileIfNeeded':
        ['InventoryItemsTracker_DidMigrateStateFileIfNeeded', 'PWCInventoryItemsTracker_State'],
}
PREFS_WRITERS = ('SetInt', 'SetFloat', 'SetString')


def method_windows(rows):
    named = sorted((int(r['vaddr'], 16), r['declaring_type'] + '.' + r['name']) for r in rows if r.get('vaddr'))
    starts = [a for a, _ in named]
    windows = {}
    for address, name in named:
        following = starts[bisect.bisect_right(starts, address)] if bisect.bisect_right(starts, address) < len(starts) else address + 0x400
        windows.setdefault(name, []).append((address, following))
    return windows


def window_literals(elf, meta, start, stop):
    pages, literals = {}, set()
    for address in range(start, stop, 4):
        word = nav.word(elf, address)
        if word & 0x9f000000 == 0x90000000:
            immediate = ((word >> 5) & 0x7ffff) << 2 | ((word >> 29) & 3)
            pages[word & 31] = (address & ~0xfff) + (nav.signed(immediate, 21) << 12)
        elif word & 0xffc00000 == 0xf9400000 and ((word >> 5) & 31) in pages:
            got = pages[(word >> 5) & 31] + ((word >> 10) & 0xfff) * 8
            try:
                usage = nav.metadata_usage(elf, got)
                if usage['kind'] == 5:
                    literals.add(nav.literal(meta, usage)['literal'])
            except (ValueError, struct.error):
                pass
    return literals


def prove_triggers(elf, meta, resolve, rows):
    # Scene change saves: Stage2 handler is a tail call to SaveProgressInAllScenes, no CanSaveScene check.
    stage2 = nav.branch(0x21e09b0, nav.word(elf, 0x21e09b0))
    nav.require(stage2['kind'] == 'B' and stage2['target'] == 0x21e09b4, 'Stage2 handler is not a tail call to SaveProgressInAllScenes')
    # Awake subscribes the Stage2 handler to GameSceneManager.OnBeforeSceneLoadStage2Action.
    calls = pipe.controls(elf, resolve, *WINDOWS['Awake'])
    subscribe = [c for c in calls.values() if c['rows'] and pipe.label(c['rows'][0]) == 'GameSceneManager.add_OnBeforeSceneLoadStage2Action']
    nav.require(len(subscribe) == 1, 'Awake does not subscribe to OnBeforeSceneLoadStage2Action')
    usage = nav.metadata_usage(elf, nav.adrp_ldr(elf, 0x21e06a8, 0x21e06b8)['got_vaddr'])   # x20 = delegate MethodInfo slot
    handler = [r for r in rows if r['method_definition_index'] == usage['index']]
    nav.require(usage['kind'] == 3 and [r['name'] for r in handler] == ['OnBeforeSceneLoadStage2'], 'Awake delegate is not OnBeforeSceneLoadStage2')
    pipe.at(elf, 0x21e06fc, pipe.LDR_X, rt=2, rn=20, imm=0)                                  # Action ctor method argument
    pipe.at(elf, 0x21e06ec, lambda w: pipe.decode(w, 0xffe00c00, 0xf8000c00, {'imm': lambda w: (w >> 12) & 0x1ff}), imm=0x38)  # Instance = this
    # Pause saves only when pausing (bool argument in w20) and when CanSaveScene allows it.
    pause_flag = nav.branch(0x21e613c, nav.word(elf, 0x21e613c))
    nav.require(pause_flag['kind'] == 'TBZ' and pause_flag['register'] == 20 and pause_flag['bit'] == 0 and pause_flag['target'] == 0x21e6158,
                'pause flag test changed')
    pause_calls = pipe.controls(elf, resolve, *WINDOWS['OnApplicationPause'])
    nav.require(pipe.label(pause_calls[0x21e6140]['rows'][0]) == 'PersistentDataManager.CanSaveScene', 'pause does not call CanSaveScene')
    tail = pause_calls[0x21e6154]
    nav.require(tail['kind'] == 'B' and pipe.label(tail['rows'][0]) == 'PersistentDataManager.SaveProgressInAllScenes', 'pause does not save')
    # CanSaveScene = !IsSceneChangingInProgress && (LevelManager.Instance == null || Instance.IsPostInit)
    pipe.same_slot(elf, 0x21e5f80, 0x21e5f88)
    pipe.at(elf, 0x21e6004, pipe.LDRB, imm=0x30)                    # GameSceneManager.IsSceneChangingInProgress
    nav.require(callback.typedef_name(meta, nav.metadata_usage(elf, nav.adrp_ldr(elf, 0x21e6014, 0x21e6018)['got_vaddr'])) == 'PWC.Level.LevelManager',
                'CanSaveScene second class is not LevelManager')
    pipe.at(elf, 0x21e6070, pipe.LDR_X, imm=0x30)                   # LevelManager.Instance
    pipe.at(elf, 0x21e60e4, pipe.LDRB, imm=0x39)                    # LevelManager.IsPostInit
    for site, kind, target in [(0x21e6008, 'CBZ', 0x21e6014), (0x21e6094, 'TBZ', 0x21e60ec), (0x21e60e8, 'CBZ', 0x21e600c)]:
        control = nav.branch(site, nav.word(elf, site))
        nav.require(control['kind'] == kind and control['target'] == target, f'CanSaveScene branch mismatch at {site:#x}')
    nav.require(nav.word(elf, 0x21e600c) == 0x2a1f03e0 and nav.word(elf, 0x21e60ec) == 0x52800020, 'CanSaveScene results are not false/true')
    return {
        'writes': [
            'scene change: GameSceneManager.LoadScene invokes OnBeforeSceneLoadStage2Action (after IsSceneChangingInProgress = true) '
            '-> PersistentDataManager.OnBeforeSceneLoadStage2 -> SaveProgressInAllScenes (no CanSaveScene check)',
            'OnApplicationPause(true) -> CanSaveScene() -> SaveProgressInAllScenes',
            'LevelMakerSplitLevelManager.SaveCurrentData and MPManager.TrySaveCurrentSceneAndGetSceneData call SaveProgress directly'],
        'can_save_scene': '!GameSceneManager.IsSceneChangingInProgress && (LevelManager.Instance == null || LevelManager.Instance.IsPostInit)',
        'not_found': 'no OnApplicationQuit or OnApplicationFocus handler exists on PersistentDataManager (method list)',
    }


def prove_callers(elf, rows):
    by_name = {r['name']: int(r['vaddr'], 16) for r in rows if r['declaring_type'] == PDM and r.get('vaddr')}
    found = camera.direct_callers(elf, [r for r in rows if r.get('vaddr')], {n: by_name[n] for n in EXPECTED_CALLERS})
    for name, expected in EXPECTED_CALLERS.items():
        nav.require(found[name] == expected, f'callers of {name} changed: {sorted(found[name] ^ expected)}')
    return {name: sorted(owners) for name, owners in found.items()}


def prove_keys(elf, meta, rows):
    windows = method_windows(rows)
    prefs = {r['vaddr']: r['name'] for r in rows if r['declaring_type'] == 'UnityEngine.PlayerPrefs' and r['name'] in PREFS_WRITERS + ('DeleteKey',)}
    prefs_targets = {int(v, 16) for v in prefs}
    report = {}
    for method, wanted in KEYS.items():
        nav.require(method in windows, f'method missing: {method}')
        literals, calls = set(), {}
        for start, stop in windows[method]:                      # all overloads of the method name
            literals |= window_literals(elf, meta, start, stop)
            calls.update(pipe.controls(elf, lambda a: [], start, stop))
        nav.require(all(key in literals for key in wanted), f'{method}: literals {wanted} not in window')
        nav.require(any(c['target'] in prefs_targets for c in calls.values()), f'{method}: no PlayerPrefs write in window')
        report[method] = wanted
    return report


MIGRATIONS = {  # method -> expected named call order
    'Game.Store.StoreManager.MigrateStateFileIfNeeded': (0x1d817a0, 0x1d818e0),
    'PWC.Inventory.ItemsTracker.InventoryItemsTracker.MigrateStateFileIfNeeded': (0x2140184, 0x21402c4),
}
MIGRATION_CALLS = ['PlayerPrefs.GetInt', 'User.HasAccessToken', 'PlayerPrefs.SetInt',
                   'PWCUtils.MigrateAndroidBuildFileFromPrivateToNormalIfNeeded']
BUILD_NUMBER_METHODS = [f'{PDM}.GetDataFromRootGameObjects', f'{PDM}.LoadDataInternal']


def prove_versioning(elf, meta, resolve, rows):
    for method, (start, stop) in MIGRATIONS.items():
        owner = resolve(start)
        nav.require(len(owner) == 1 and owner[0]['declaring_type'] + '.' + owner[0]['name'] == method, f'{method} identity mismatch')
        names, _ = drop.named_sequence(elf, resolve, (start, stop))
        nav.require([n for _, n in names] == MIGRATION_CALLS, f'{method} call sequence changed')
    windows = method_windows(rows)
    for method in BUILD_NUMBER_METHODS:
        literals = set()
        for start, stop in windows[method]:
            literals |= window_literals(elf, meta, start, stop)
        nav.require('BuildNumber' in literals, f'{method} does not reference the BuildNumber key')
    by_name = {r['name']: int(r['vaddr'], 16) for r in rows if r['declaring_type'] == PDM and r.get('vaddr')}
    callers = camera.direct_callers(elf, [r for r in rows if r.get('vaddr')],
                                    {'get': by_name['get_LastLoadedDataBuildNumber'], 'set': by_name['set_LastLoadedDataBuildNumber']})
    return {
        'migrations': 'StoreManager and InventoryItemsTracker run a one-time, flag-guarded file-location migration '
                      '(GetInt flag -> User.HasAccessToken branch -> SetInt flag -> MigrateAndroidBuildFileFromPrivateToNormalIfNeeded)',
        'schema_versioning': 'scene data JSON carries a BuildNumber key (written in GetDataFromRootGameObjects, read in LoadDataInternal)',
        'build_number_consumers': {'get_direct_callers': sorted(callers['get']), 'set_direct_callers': sorted(callers['set']),
                                   'caveat': 'both accessors have no direct callers although LoadDataInternal must set the value: the '
                                             'compiler inlines trivial accessors, so absence of callers proves nothing'},
    }


CLOUD = 'PazuCore.PazuCloud.PazuCloudManager'
CLOUD_CALLERS = {  # PazuCloudManager method -> game-side callers that must be present (containment, not equality)
    'SendOperation': {'Game.Store.StoreManager.ClaimItemInternal', 'PWC.Achievements.AWACloudBridge.ClaimAchievementsImplement',
                      'PWC.Achievements.AWACloudBridge.GetAchievementsWorth', 'PWC.CloudProgress.CPManager.Download',
                      'PWC.CloudProgress.CPManager.Upload', 'PWC.AvatarPassChange.AvatarPassChangeWindow.SendAcceptToCloud',
                      'PWC.GamePopups.RefundGamePopup.OnButtonPress'},
    'SendOperationWhenPossible': {'Game.Store.StoreManager.GetStoreData', 'PWC.CloudProgress.CPManager.GetCurrentProfileMetadataFromCloud'},
    'VerifyReceipt': {'PazuCore.PazuUnityPurchaser.ProcessPurchase'},
}


def prove_cloud_boundary(elf, rows):
    by_name = {r['name']: int(r['vaddr'], 16) for r in rows if r['declaring_type'] == CLOUD and r.get('vaddr')}
    found = camera.direct_callers(elf, [r for r in rows if r.get('vaddr')], {n: by_name[n] for n in CLOUD_CALLERS})
    for name, expected in CLOUD_CALLERS.items():
        nav.require(expected <= found[name], f'cloud callers of {name} missing: {sorted(expected - found[name])}')
    leaks = sorted(owner for owner in found['SendOperation'] | found['SendOperationWhenPossible'] if owner.startswith(PDM))
    nav.require(not leaks, f'PersistentDataManager calls the server directly: {leaks}')
    return {
        'server_bound': {name: sorted(expected) for name, expected in CLOUD_CALLERS.items()},
        'reading': ['store claims, achievement claims, IAP receipts, cloud profile upload/download and avatar-pass changes go '
                    'through PazuCloudManager.SendOperation (server-only)',
                    'PersistentDataManager does not call SendOperation directly: scene persistence is local files'],
        'persistent_data_manager_direct_server_calls': leaks,
    }


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
    return {'schema_version': 1, 'scope': 'bounded static proof; no execution',
            'native_sha256': nav.sha(binary), 'metadata_sha256': nav.sha(metadata),
            'triggers': prove_triggers(elf, meta, resolve, rows),
            'direct_callers': prove_callers(elf, rows),
            'playerprefs_keys': prove_keys(elf, meta, rows),
            'versioning': prove_versioning(elf, meta, resolve, rows),
            'cloud_boundary': prove_cloud_boundary(elf, rows)}


if __name__ == '__main__':
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--source', type=Path, default=nav.ROOT / 'out/recon/il2cpp')
    parser.add_argument('--report', type=Path, default=nav.ROOT / 'out/recon/save_triggers.json')
    args = parser.parse_args()
    nav.atomic_json(args.report, probe(args.source))
    print(f'Save trigger proof written to {args.report}')
