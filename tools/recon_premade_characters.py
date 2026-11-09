#!/usr/bin/env python3
"""Premade characters (the NPCs): data schema, id resolution, pet breeds and how the original loads them.

Two parts, both static:
  * data  - every TextAsset shaped {"AvatarSpineDatas": [...]} (PremadeCharactersJson plus one JSON per newer scene), the pet
            breed CSV (PetMaker_BreedsData) and the NPC lists of the interiors (tools/recon_interior_npcs.py);
  * loader - AvatarSpineDataManager.TryLoadPremadeListFromResources / LoadPremadeCharactersFromResources in libil2cpp.so.

Reads game assets under --assets (out/assets) read-only; the loader proof needs the IL2CPP cache (out/recon/il2cpp).
"""
from __future__ import annotations

import argparse
import collections
import csv
import io
import json
import re
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
PREMADE_HEAD = '{"AvatarSpineDatas"'
ENTRY_KEYS = ['BuildNumber', 'Config', 'ID', 'SizeType', 'SkinsData', 'SpineType']
# SkinData declares CategoryType, SkinName, Colors (Color32[]), ColorA and ColorB (Nullable<Color>); the JSON omits unset ones.
SKIN_KEY_VARIANTS = [['CategoryType', 'ColorA', 'ColorB', 'SkinName'], ['CategoryType', 'Colors', 'SkinName'], ['CategoryType', 'SkinName']]
SPINE_TYPES = {1: 'Character', 2: 'Baby', 3: 'Cat', 4: 'Dog', 13: 'Toddler', 14: 'Horse', 15: 'Cow', 16: 'Chicken', 17: 'Car'}   # PWC.AvatarSpine.SpineType (declaration)
# Skins that the base Avatar_Spine rig already carries; the rest are clothing pieces imported separately.
BASE_RIG_FOLDERS = {'Hair_Front', 'Eyes', 'Hair_Facial', 'Back_A', 'Back_B', 'Body_Whites', 'Body_Shad', 'Ear_Shad', 'Body_Other',
                    'Accessories_Face_General'}


def load_premade(asset_dir: Path):
    """Merge every premade JSON like the original does and report duplicate ids the same way it would (error, not merge)."""
    entries, source, files, duplicates = {}, {}, {}, []
    for path in sorted(asset_dir.iterdir()):
        if path.stat().st_size < 200:
            continue
        with path.open(encoding='utf-8', errors='replace') as handle:
            if not handle.read(len(PREMADE_HEAD)).startswith(PREMADE_HEAD):
                continue
        data = json.loads(path.read_text(encoding='utf-8'))['AvatarSpineDatas']
        files[path.name] = {'entries': len(data), 'id_min': min(x['ID'] for x in data), 'id_max': max(x['ID'] for x in data)}
        for entry in data:
            if entry['ID'] in entries:
                duplicates.append({'id': entry['ID'], 'files': [source[entry['ID']], path.name]})
            entries[entry['ID']] = entry
            source[entry['ID']] = path.name
    return entries, source, files, duplicates


def parse_breeds(text: str):
    rows = list(csv.DictReader(io.StringIO(text)))
    return rows


def normalize_skin(skin_name: str) -> str:
    """Client catalog id for a skin name: lower case, '/' -> '_' (Shirt_Formal/1 -> shirt_formal_1)."""
    return skin_name.lower().replace('/', '_')


def client_catalog_ids(catalog_cs: str) -> set[str]:
    return set(re.findall(r'"([a-z0-9_]+)"', catalog_cs))


def resolve_npcs(interiors: dict, premade: dict, breeds_by_name: dict):
    refs = [(name, avatar['id']) for name, v in interiors.items() for avatar in (v.get('avatars') or [])]
    pet_by_id = {pet['id']: pet for v in interiors.values() for pet in (v.get('pets') or [])}
    resolved = [i for _, i in refs if i in premade]
    unresolved = sorted({i for _, i in refs if i not in premade})
    pets = {i: {'name': pet_by_id[i]['name'], 'in_breed_table': pet_by_id[i]['name'] in breeds_by_name}
            for i in unresolved if i in pet_by_id}
    return {'references': len(refs), 'distinct_ids': len({i for _, i in refs}), 'resolved': len(resolved),
            'unresolved_ids': unresolved, 'unresolved_that_are_pets': pets,
            'interiors': len({n for n, _ in refs})}


def client_skin_coverage(interiors: dict, premade: dict, catalog_ids: set[str]):
    ids = {a['id'] for v in interiors.values() for a in (v.get('avatars') or [])}
    per_folder = collections.defaultdict(lambda: [0, 0])
    fully_dressable = characters = 0
    for npc_id in sorted(ids):
        entry = premade.get(npc_id)
        if not entry or entry['SpineType'] != 1:
            continue
        characters += 1
        dressable = True
        for skin in entry['SkinsData']:
            folder = skin['SkinName'].split('/')[0]
            in_client = normalize_skin(skin['SkinName']) in catalog_ids
            per_folder[folder][0] += 1
            per_folder[folder][1] += in_client
            if not in_client and folder not in BASE_RIG_FOLDERS:
                dressable = False
        fully_dressable += dressable
    missing = {f: n - k for f, (n, k) in per_folder.items() if f not in BASE_RIG_FOLDERS and n - k > 0}
    return {'character_npcs': characters, 'fully_dressable_with_client_catalog': fully_dressable,
            'slots_missing_in_client_by_folder': dict(sorted(missing.items(), key=lambda kv: -kv[1]))}


def color_formats(premade: dict):
    """SkinData carries ColorA/ColorB (Nullable<Color>, floats; legacy) or Colors (Color32[], bytes). Relate them to BuildNumber."""
    groups = collections.defaultdict(list)
    mixed = 0
    for entry in premade.values():
        formats = {('Colors' if 'Colors' in s else 'ColorA/ColorB') for s in entry['SkinsData'] if 'Colors' in s or 'ColorA' in s}
        mixed += len(formats) > 1
        groups[next(iter(formats)) if len(formats) == 1 else ('none' if not formats else 'mixed')].append(entry['BuildNumber'])
    report = {name: {'entries': len(b), 'build_min': min(b), 'build_max': max(b)} for name, b in groups.items()}
    report['entries_mixing_both_formats'] = mixed
    legacy, new = groups.get('ColorA/ColorB'), groups.get('Colors')
    report['formats_split_cleanly_by_build'] = bool(legacy and new and max(legacy) < min(new))
    return report


def schema_report(premade: dict):
    entry_keys = collections.Counter(tuple(sorted(e.keys())) for e in premade.values())
    skin_keys = collections.Counter(tuple(sorted(s.keys())) for e in premade.values() for s in e['SkinsData'])
    folders = collections.defaultdict(collections.Counter)
    for entry in premade.values():
        for skin in entry['SkinsData']:
            folders[(entry['SpineType'], skin['CategoryType'])][skin['SkinName'].split('/')[0]] += 1
    return {
        'entry_keys': [list(k) for k in entry_keys], 'skin_keys': sorted(list(k) for k in skin_keys),
        'color_format_by_build': color_formats(premade),
        'spine_types': {SPINE_TYPES.get(k, str(k)): v for k, v in collections.Counter(e['SpineType'] for e in premade.values()).items()},
        'size_types': dict(collections.Counter(e['SizeType'] for e in premade.values())),
        'config_keys': sorted({k for e in premade.values() for k in (e.get('Config') or {})}),
        'category_folder_pairs': len(folders),
        'character_category_to_folder_is_one_to_one_except_case': all(
            len({f.lower() for f in c}) == 1 for (t, _), c in folders.items() if t == 1),
    }


def build_report(assets: Path, interiors_path: Path, catalog_path: Path | None):
    premade, source, files, duplicates = load_premade(assets)
    breeds_file = next(p for p in assets.iterdir() if p.name.startswith('PetMaker_BreedsData'))
    breeds = parse_breeds(breeds_file.read_text(encoding='utf-8'))
    by_name = {row['Name']: row for row in breeds}
    interiors = json.loads(interiors_path.read_text())
    report = {
        'schema_version': 1,
        'scope': 'static data; how the game uses a premade id at run time beyond the loader proof is not shown here',
        'files': files, 'avatars': len(premade), 'duplicate_ids_across_files': duplicates,
        'schema': schema_report(premade),
        'pet_breeds': {'rows': len(breeds), 'by_species': dict(collections.Counter(r['SpineType'] for r in breeds)),
                       'columns': list(breeds[0].keys())},
        'interior_npcs': resolve_npcs(interiors, premade, by_name),
    }
    if catalog_path is not None:
        report['client_catalog'] = client_skin_coverage(interiors, premade, client_catalog_ids(catalog_path.read_text(encoding='utf-8')))
    return report


# ---- loader proof (IL2CPP) -------------------------------------------------------------------------------------------

LOADER = {'TryLoadPremadeListFromResources': (0x216e3b4, 0x216ea84), 'LoadPremadeCharactersFromResources': (0x216ca00, 0x216cca0),
          'TryLoadPremadeListFromResourcesFromASingleJson': (0x2171694, 0x2171a44)}
LIST_LITERALS = {'PremadeData/', ': json is null or empty!', ': Failed to parse json!', ': AvatarSpineDatas is null!',
                 ': ID[', '] is already in use in file name[', ']!'}
SINGLE_LITERALS = {'PremadeData/', 'No PremadeData found for jsonAssetName['}
LOAD_CALLS = ['AvatarSpineDataManager.TryLoadPremadeListFromResources', 'PlayerPrefs.GetInt', 'AvatarSpineDataManager.TryLoadAvatarSpineData',
              'AvatarSpineDataManager.SaveCharacter', 'AvatarSpineDataManager.SaveCharacter', 'PlayerPrefs.SetInt',
              'AvatarSpineDataManager.SaveCharacter']
KEY = 'CafeteriaPremadesTempOverrideKey'


MGR = 'PWC.AvatarSpine.AvatarSpineDataManager'
CONSUMERS = {  # method of AvatarSpineDataManager -> callers that must be present (containment), with what they mean
    'LoadPremadeCharactersFromResources': {f'{MGR}.Init'},
    'ResetPremadeCharacter': {'PWC.Level.LevelCharactersRandomizer.SpawnCharacter'},
    'TryLoadPremadeCharacterFromResources': {'PWC.Level.LevelCharacter.DestroyAvatar', 'PWC.Level.LevelToddler.DestroyAvatar',
                                             'PWC.Level.LevelBaby.DestroyAvatar', 'Game.Level.LevelCat.DestroyAvatar',
                                             'Game.Level.LevelDog.DestroyAvatar', 'Game.Level.LevelHorse.DestroyAvatar'},
    'IsPremadeID': {'PWC.LevelPhone.ContactsPage.GetContactsIfNeeded', 'PWC.Level.LevelUIScrollCharacterItem.OnPointerClick',
                    'PWC.Level.LevelAvatarData.ShouldAvatarBeInGameObjectScene', f'{MGR}.ResetPremadeCharacter'},
    'TryLoadPremadeFromResources': {'PWC.CloudProgress.CPAvatarDataHelper.TryAddAvatarsSpineData'},
    'TryLoadPremadeListFromResources': {'PWC.PremadeCharacters.PremadeCharactersDisplayManager.Start', 'PWC.WorldReset.WorldResetManager.ResetScene'},
    'IsOldPremadePet': {'Game.Level.LevelCat.SetPersistentData', 'Game.Level.LevelDog.SetPersistentData'},
}


def prove_consumers(source: Path):
    import recon_camera_drag as camera
    import recon_navigation as nav
    binary, metadata = (source / 'libil2cpp.so').read_bytes(), (source / 'global-metadata.dat').read_bytes()
    nav.verify_pair(binary, metadata)
    elf, meta = nav.Elf(binary), nav.Metadata(metadata)
    rows, _ = nav.load_index(source / 'metadata_methods.jsonl', elf, meta)
    rows = [r for r in rows if r.get('vaddr')]
    by_name = {r['name']: int(r['vaddr'], 16) for r in rows if r['declaring_type'] == MGR}
    found = camera.direct_callers(elf, rows, {n: by_name[n] for n in CONSUMERS})
    for method, expected in CONSUMERS.items():
        nav.require(expected <= found[method], f'{method}: missing callers {sorted(expected - found[method])}')
    return {
        'boot': 'AvatarSpineDataManager.Init -> LoadPremadeCharactersFromResources (premades copied into the local save)',
        'restore_on_destroy': 'DestroyAvatar of Character/Toddler/Baby/Cat/Dog/Horse -> TryLoadPremadeCharacterFromResources (original data reloaded)',
        'random_spawn': 'LevelCharactersRandomizer.SpawnCharacter -> ResetPremadeCharacter',
        'ui': 'phone ContactsPage and LevelUIScrollCharacterItem use IsPremadeID',
        'migration': 'IsOldPremadePet is called by LevelCat/LevelDog.SetPersistentData and by the PerformAvatarSpineDataMigration local function',
        'cloud': 'CPAvatarDataHelper.TryAddAvatarsSpineData -> TryLoadPremadeFromResources',
        'callers_checked': {m: sorted(c) for m, c in CONSUMERS.items()},
        'caveat': 'direct bl/b callers only; what each caller does with the data was not opened',
    }


def prove_loader(source: Path):
    import recon_load_scene_pipeline as pipe
    import recon_navigation as nav
    import recon_save_triggers as st
    binary, metadata = (source / 'libil2cpp.so').read_bytes(), (source / 'global-metadata.dat').read_bytes()
    nav.verify_pair(binary, metadata)
    elf, meta = nav.Elf(binary), nav.Metadata(metadata)
    rows, resolve = nav.load_index(source / 'metadata_methods.jsonl', elf, meta)
    for name, (start, stop) in LOADER.items():
        owner = resolve(start)
        nav.require(len(owner) == 1 and owner[0]['name'] == name, f'{name} identity mismatch')
        following = min(int(r['vaddr'], 16) for r in rows if r['vaddr'] and int(r['vaddr'], 16) > start)
        nav.require(following == stop, f'{name} next-method boundary mismatch')
    literals = {n: st.window_literals(elf, meta, *LOADER[n]) for n in LOADER}
    nav.require(LIST_LITERALS <= literals['TryLoadPremadeListFromResources'], 'list loader literals changed')
    nav.require(SINGLE_LITERALS <= literals['TryLoadPremadeListFromResourcesFromASingleJson'], 'single-json loader literals changed')
    nav.require(KEY in literals['LoadPremadeCharactersFromResources'], 'override key literal missing')
    calls = pipe.controls(elf, resolve, *LOADER['LoadPremadeCharactersFromResources'])
    names = [pipe.label(c['rows'][0]) for _, c in sorted(calls.items()) if c['rows']]
    nav.require(names == LOAD_CALLS, f'LoadPremadeCharactersFromResources call order changed: {names}')
    listing = pipe.controls(elf, resolve, *LOADER['TryLoadPremadeListFromResources'])
    listing_names = {pipe.label(c['rows'][0]) for c in listing.values() if c['rows']}
    nav.require({'TextAsset.get_text', 'Object.get_name', 'Debug.LogError', 'Int32.ToString'} <= listing_names, 'list loader calls changed')
    return {
        'list_loader': 'reads every TextAsset under Resources "PremadeData/" (generic LoadAll, not name-resolved); per asset: empty -> error, '
                       'parse failure -> error, AvatarSpineDatas null -> error; an id already seen in another file -> error '
                       '"ID[n] is already in use in file name[x]!" (so ids are globally unique)',
        'single_json_loader': 'loads one named asset from "PremadeData/"; unknown name -> error',
        'copy_to_save': f'LoadPremadeCharactersFromResources: list -> PlayerPrefs.GetInt("{KEY}") -> per premade TryLoadAvatarSpineData (saved copy) -> '
                        f'SaveCharacter (writes AvatarSpineData_<id>) -> PlayerPrefs.SetInt("{KEY}")',
        'inferred': ['the key gates a one-time refresh of some premades; which ones, and the loop condition, were not decoded'],
    }


def main(argv=None) -> int:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--assets', type=Path, default=ROOT / 'out/assets/TextAsset')
    parser.add_argument('--interiors', type=Path, default=ROOT / 'out/recon/interior_npcs.json')
    parser.add_argument('--catalog', type=Path, default=ROOT / 'client/AvatarWorldClient/Assets/Scripts/Core/Avatar/AvatarCatalogData.cs')
    parser.add_argument('--il2cpp', type=Path, default=ROOT / 'out/recon/il2cpp')
    parser.add_argument('--output', type=Path, default=ROOT / 'reports/recon/premade_characters.json')
    args = parser.parse_args(argv)
    report = build_report(args.assets, args.interiors, args.catalog if args.catalog.exists() else None)
    report['loader'] = prove_loader(args.il2cpp)
    report['consumers'] = prove_consumers(args.il2cpp)
    args.output.parent.mkdir(parents=True, exist_ok=True)
    args.output.write_text(json.dumps(report, indent=1, ensure_ascii=False) + '\n', encoding='utf-8')
    print(json.dumps({k: report[k] for k in ('avatars', 'duplicate_ids_across_files')} | {'npcs': report['interior_npcs']}, ensure_ascii=False))
    return 0


if __name__ == '__main__':
    raise SystemExit(main())
