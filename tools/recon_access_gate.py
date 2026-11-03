"""Verify the building access-gate inputs: IsCurrentlyFree, IsAllWorldFree, User.IsLocked.

Static evidence only: no game execution, no semantic certification, no automatic
queue acceptance. Field names/offsets come from the Cpp2IL dump.
"""
import argparse
import gzip
import json
from pathlib import Path

import recon_navigation as nav

TASK_OUTPUT = nav.ROOT / 'out/recon/tasks/T029/WORLD_CLICK'
METHODS = {
    0x2109138: ('PWC.World.Buildings.WorldBuilding', 'IsCurrentlyFree'),
    0x207cc00: ('PWC.PWCConstants', '.cctor'),
    0x1cbb7a8: ('PazuCore.Utils', 'IsGameUnlocked'),
    0x1cefe70: ('PazuCore.PazuCloud.User', 'IsLocked'),
    0x1cd9d44: ('PazuCore.PazuCloud.User', 'IsFullVersion'),
    0x1cd9da8: ('PazuCore.PazuCloud.User', 'IsSubscriptionActive'),
}
CALLS = {
    0x1cbb7ec: ('PazuCore.PazuCloud.User', 'IsLocked', 'BL'),
    0x1cd9d84: ('PazuCore.PazuCloud.User', 'GetFullVersionKey', 'BL'),
    0x1cd9d90: ('UnityEngine.PlayerPrefs', 'GetInt', 'BL'),
    0x1cefebc: ('PazuCore.PazuCloud.User', 'IsFullVersion', 'BL'),
    0x1cefed0: ('PazuCore.Utils', 'get_IsIOS', 'BL'),
    0x1ceff10: ('PazuCore.PazuCloud.User', 'HasAccessToken', 'BL'),
    0x1ceff28: ('PazuCore.PazuCloud.User', 'IsSubscriptionActive', 'BL'),
    0x1ceff40: ('PazuCore.PazuCloud.User', 'IsActiveDevice', 'BL'),
    0x1cefff0: ('PazuCore.AF.TimeLimit.TimeLimitDataManager', 'IsTimerLimitReached', 'BL'),
    0x1cefff8: ('PazuCore.PazuCloud.GamesPackUtils', 'IsThisGameFullVersionExistInKeychain', 'BL'),
}
LITERALS = {(0x1cd9dd0, 0x1cd9dd4): 'is_active_subscription', (0x1cd9ddc, 0x1cd9de0): '1'}
ANCHORS = {
    # IsCurrentlyFree: _isFree(+0x58) || _isFreeFromRemoteConfig(+0x70) || PWCConstants.IsAllWorldFree(static +0x0)
    0x2109164: 0x39416268, 0x2109168: 0x35000068, 0x210916c: 0x3941c268, 0x2109170: 0x340000a8,
    0x2109174: 0x52800020, 0x21091a4: 0x39400108, 0x21091a8: 0x7100011f, 0x21091ac: 0x1a9f07e0,
    # PWCConstants..cctor: IsAllWorldFree = true
    0x207cc38: 0x52800029, 0x207cc3c: 0xf9405d08, 0x207cc40: 0x39000109,
    # IsGameUnlocked = !User.IsLocked()
    0x1cbb7f4: 0x2a2003e8, 0x1cbb7f8: 0x12000100,
    # IsFullVersion: PlayerPrefs.GetInt(key, 0) == 1
    0x1cd9d98: 0x7100041f,
    # IsLocked: ExtraSettings.useTimeLock (+0x73) gates the timer branch; timer-not-reached -> unlocked
    0x1ceffac: 0x3941cd08, 0x1ceffb0: 0x34000248, 0x1cefff4: 0x3607f680,
}


def serialized_inputs():
    """Per-building _isFree and GameExtraSettings tail from already-extracted data."""
    out = {}
    mb = nav.ROOT / 'out/mb/PWC.World.Buildings.WorldBuilding.jsonl.gz'
    if mb.exists():
        rows = [json.loads(line) for line in gzip.open(mb, 'rt')]
        free = {}
        for row in rows:
            free[str(row.get('_isFree'))] = free.get(str(row.get('_isFree')), 0) + 1
        out['world_building_is_free_counts'] = free
        out['world_building_records'] = len(rows)
    return out


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
    return {'literals': literals, 'verified_calls': confirmed, 'verified_operand_anchors': len(ANCHORS)}


def run(source, output):
    binary = (source / 'libil2cpp.so').read_bytes()
    metadata = (source / 'global-metadata.dat').read_bytes()
    nav.verify_pair(binary, metadata)
    elf, meta = nav.Elf(binary), nav.Metadata(metadata)
    _, resolve = nav.load_index(source / 'metadata_methods.jsonl', elf, meta)
    contract = verify(elf, meta, resolve)
    contract.update(schema_version=1, status='static_candidate_not_runtime_validated',
                    native_sha256=nav.sha(binary), metadata_sha256=nav.sha(metadata),
                    serialized_inputs=serialized_inputs())
    contract['candidate'] = [
        'IsCurrentlyFree() = _isFree || _isFreeFromRemoteConfig || PWCConstants.IsAllWorldFree.',
        'PWCConstants..cctor sets IsAllWorldFree = true, so IsCurrentlyFree() is true for every building in 1.227 (candidate; static initialiser read, order vs other writers not proven).',
        'Therefore the ClickOnLevel gate enters without the preview popup; IsGameUnlocked is not reached.',
        'IsGameUnlocked() = !User.IsLocked(). IsLocked: full version (PlayerPrefs.GetInt(GetFullVersionKey(),0)==1) -> unlocked; subscription path (token + "is_active_subscription"=="1" in keychain + active device); ExtraSettings.useTimeLock -> TimeLimitDataManager.IsTimerLimitReached; else !GamesPackUtils.IsThisGameFullVersionExistInKeychain.',
        'Serialized GameExtraSettings (datapack sharedassets1 path 214, 544 bytes) tail decodes to useNewEndSession=1, useAnalytics=1, useActionBarHomePlayButton=0, useTimeLock=0, useActionBarNextGameWidget=1, androidUseGoogleAnalytics=0, dontOfferSubscriptionPurchase=1 (manual parse, each bool in its own 4-byte unit; moderate confidence).',
        'All 115 WorldBuilding records have _isFree = 0 (out/mb); _isFreeFromRemoteConfig is runtime/server data.',
    ]
    contract['unknowns'] = [
        'Whether another static writer or the remote config can change IsAllWorldFree at runtime (field is readonly; assumed constant).',
        'GameExtraSettings tail layout was parsed manually; confirm field order with a generated typetree.',
        'GetFullVersionKey literal, IsActiveDevice, IsTimerLimitReached and keychain helpers are not decoded; irrelevant while IsAllWorldFree is true.',
        'Behaviour of the 7 LevelTypes without scenes and of buildings under construction (BurgerRestaurant/GasStation/CarWash) is not governed by this gate.',
    ]
    nav.atomic_json(output / 'access-gate-contract.json', contract)
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
