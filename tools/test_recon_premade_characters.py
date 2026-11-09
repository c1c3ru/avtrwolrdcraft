"""Premade-character data helpers (synthetic) and the loader proof (needs the IL2CPP cache; real-data checks skip without assets)."""
import json
import os
import tempfile
import unittest
from pathlib import Path

import recon_premade_characters as premade


def entry(identifier, spine=1, skins=()):
    return {'ID': identifier, 'SpineType': spine, 'SizeType': 1, 'BuildNumber': 0, 'Config': {'isDisplayInPhone': False},
            'SkinsData': [{'CategoryType': i, 'SkinName': s, 'ColorA': {}, 'ColorB': {}} for i, s in enumerate(skins)]}


def write(directory, name, entries):
    (Path(directory) / name).write_text(json.dumps({'AvatarSpineDatas': entries}), encoding='utf-8')


class DataTests(unittest.TestCase):
    def test_merge_reports_duplicate_ids_across_files_like_the_original(self):
        with tempfile.TemporaryDirectory() as tmp:
            write(tmp, 'A.txt', [entry(1, skins=['Shirt_Formal/1']), entry(2)] + [entry(100 + i) for i in range(3)])
            write(tmp, 'B.txt', [entry(2)] + [entry(200 + i) for i in range(5)])
            merged, source, files, duplicates = premade.load_premade(Path(tmp))
        self.assertEqual(len(merged), 10)   # 5 + 6 entries, id 2 appears twice
        self.assertEqual(duplicates, [{'id': 2, 'files': ['A.txt', 'B.txt']}])
        self.assertEqual(files['A.txt'], {'entries': 5, 'id_min': 1, 'id_max': 102})

    def test_non_premade_text_assets_are_ignored(self):
        with tempfile.TemporaryDirectory() as tmp:
            (Path(tmp) / 'notes.txt').write_text('x' * 500)
            (Path(tmp) / 'tiny.txt').write_text('{}')
            write(tmp, 'P.txt', [entry(1)] * 1 + [entry(i) for i in range(2, 30)])
            merged, *_ = premade.load_premade(Path(tmp))
        self.assertEqual(len(merged), 29)

    def test_skin_normalisation_matches_client_catalog_ids(self):
        self.assertEqual(premade.normalize_skin('Shirt_Formal/1'), 'shirt_formal_1')
        self.assertEqual(premade.normalize_skin('Hair_Front/18_Color'), 'hair_front_18_color')

    def test_npc_resolution_separates_pets_from_missing_avatars(self):
        interiors = {'a': {'avatars': [{'id': 1}, {'id': 2}, {'id': 900005}], 'pets': [{'id': 900005, 'name': 'Cat_A_1'}]},
                     'b': {'avatars': [{'id': 1}, {'id': 999}], 'pets': []}}
        result = premade.resolve_npcs(interiors, {1: entry(1), 2: entry(2)}, {'Cat_A_1': {}})
        self.assertEqual((result['references'], result['distinct_ids'], result['resolved']), (5, 4, 3))
        self.assertEqual(result['unresolved_ids'], [999, 900005])
        self.assertEqual(result['unresolved_that_are_pets'], {900005: {'name': 'Cat_A_1', 'in_breed_table': True}})

    def test_client_coverage_ignores_base_rig_folders_and_counts_missing_clothing(self):
        interiors = {'a': {'avatars': [{'id': 1}, {'id': 2}]}}
        npcs = {1: entry(1, skins=['Eyes/1', 'Shirt_Formal/1']), 2: entry(2, skins=['Eyes/2', 'Hat_A/5'])}
        coverage = premade.client_skin_coverage(interiors, npcs, {'shirt_formal_1'})
        self.assertEqual(coverage['fully_dressable_with_client_catalog'], 1)
        self.assertEqual(coverage['slots_missing_in_client_by_folder'], {'Hat_A': 1})

    def test_breed_csv(self):
        rows = premade.parse_breeds('SpineType,Name\nCat,Cat_A_1\nDog,Dog_A_1\n')
        self.assertEqual([r['Name'] for r in rows], ['Cat_A_1', 'Dog_A_1'])


ASSETS = Path(os.environ.get('RECON_ASSETS_ROOT') or premade.ROOT / 'out/assets/TextAsset')
INTERIORS = Path(os.environ.get('RECON_INTERIORS') or premade.ROOT / 'out/recon/interior_npcs.json')


@unittest.skipUnless(ASSETS.is_dir() and INTERIORS.is_file(), 'game assets unavailable (set RECON_ASSETS_ROOT / RECON_INTERIORS)')
class RealDataTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.report = premade.build_report(ASSETS, INTERIORS, None)

    def test_counts_and_global_id_uniqueness(self):
        self.assertEqual(self.report['avatars'], 1324)
        self.assertEqual(len(self.report['files']), 59)
        self.assertEqual(self.report['duplicate_ids_across_files'], [])

    def test_schema_matches_the_declared_class(self):
        self.assertEqual(self.report['schema']['entry_keys'], [premade.ENTRY_KEYS])
        self.assertEqual(self.report['schema']['skin_keys'], sorted(premade.SKIN_KEY_VARIANTS))

    def test_color_format_is_a_function_of_build_number(self):
        formats = self.report['schema']['color_format_by_build']
        self.assertEqual(formats['entries_mixing_both_formats'], 0)
        self.assertTrue(formats['formats_split_cleanly_by_build'])
        self.assertLess(formats['ColorA/ColorB']['build_max'], formats['Colors']['build_min'])

    def test_interior_npcs_resolve_except_pets(self):
        npcs = self.report['interior_npcs']
        self.assertEqual((npcs['references'], npcs['resolved']), (389, 386))
        self.assertEqual(npcs['unresolved_ids'], [900005, 900009, 900017])

    def test_pet_breed_table(self):
        self.assertEqual(self.report['pet_breeds']['by_species'], {'Dog': 19, 'Cat': 14, 'Horse': 2})


SOURCE = Path(os.environ.get('RECON_IL2CPP_ROOT') or premade.ROOT / 'out/recon/il2cpp')


@unittest.skipUnless(SOURCE.is_dir(), 'IL2CPP cache unavailable (set RECON_IL2CPP_ROOT)')
class LoaderProofTests(unittest.TestCase):
    def test_loader_proof(self):
        proof = premade.prove_loader(SOURCE)
        self.assertIn('already in use', proof['list_loader'])
        self.assertIn('SaveCharacter', proof['copy_to_save'])

    def test_consumers_cover_boot_destroy_random_spawn_phone_and_cloud(self):
        proof = premade.prove_consumers(SOURCE)
        checked = proof['callers_checked']
        self.assertIn('PWC.Level.LevelCharacter.DestroyAvatar', checked['TryLoadPremadeCharacterFromResources'])
        self.assertIn('PWC.LevelPhone.ContactsPage.GetContactsIfNeeded', checked['IsPremadeID'])
        self.assertIn('restore_on_destroy', proof)

    def test_missing_consumer_is_rejected(self):
        original = set(premade.CONSUMERS['ResetPremadeCharacter'])
        premade.CONSUMERS['ResetPremadeCharacter'].add('PWC.Level.LevelManager.Init')
        try:
            with self.assertRaisesRegex(ValueError, 'missing callers'):
                premade.prove_consumers(SOURCE)
        finally:
            premade.CONSUMERS['ResetPremadeCharacter'].clear()
            premade.CONSUMERS['ResetPremadeCharacter'].update(original)

    def test_changed_call_order_is_rejected(self):
        original = list(premade.LOAD_CALLS)
        premade.LOAD_CALLS[1], premade.LOAD_CALLS[2] = premade.LOAD_CALLS[2], premade.LOAD_CALLS[1]
        try:
            with self.assertRaisesRegex(ValueError, 'call order changed'):
                premade.prove_loader(SOURCE)
        finally:
            premade.LOAD_CALLS[:] = original

    def test_missing_literal_is_rejected(self):
        original = set(premade.LIST_LITERALS)
        premade.LIST_LITERALS.add('this literal does not exist')
        try:
            with self.assertRaisesRegex(ValueError, 'list loader literals changed'):
                premade.prove_loader(SOURCE)
        finally:
            premade.LIST_LITERALS.clear()
            premade.LIST_LITERALS.update(original)


if __name__ == '__main__':
    unittest.main()
