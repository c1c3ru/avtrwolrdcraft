"""Classifier and raw-string scanner: behaviour on synthetic data (no game files needed)."""
import struct
import unittest

import recon_animation_orphans as orphans
import recon_undecoded_strings as undecoded


def blob(*strings, lead=28):
    data = bytearray(b'\x00' * lead)
    for text in strings:
        raw = text.encode()
        data += struct.pack('<I', len(raw)) + raw
    return bytes(data)


class ScannerTests(unittest.TestCase):
    def test_finds_length_prefixed_strings_even_when_unaligned(self):
        data = b'\x00' * 28 + b'\x01' + struct.pack('<I', 9) + b'Idle_Loop' + b'\x00' * 3
        self.assertIn('Idle_Loop', undecoded.scan_strings(data))

    def test_rejects_control_characters_digits_and_padding(self):
        data = blob('ok_name', 'bad\x01name', '12345', ' padded ')
        self.assertEqual(undecoded.scan_strings(data), {'ok_name'})

    def test_ignores_lengths_that_run_past_the_object(self):
        data = b'\x00' * 28 + struct.pack('<I', 100) + b'short'
        self.assertEqual(undecoded.scan_strings(data), set())

    def test_header_is_skipped(self):
        data = blob('Header_Looks_Like_A_Name', lead=0)
        self.assertEqual(undecoded.scan_strings(data, start=28), set())


class ClassifierTests(unittest.TestCase):
    def classify(self, names, **kw):
        defaults = dict(catalog_names=set(), literals=set(), decoded=set(), raw_by_string={})
        defaults.update(kw)
        return {n: kind for n, (kind, _) in orphans.classify(names, **defaults).items()}

    def test_priority_order(self):
        result = self.classify(
            ['A/exact_lit', 'A/in_catalog', 'A/in_raw_name', 'Blow', '.Test_Animations/X', 'Pre/fix_me', 'Gone/thing', 'Seen/thing'],
            catalog_names={'A/in_catalog'}, literals={'A/exact_lit', 'Pre/'}, raw_by_string={'A/in_raw_name': ['Cls'], 'Blow': ['Cls']},
            folder_seen=lambda folder: folder != 'Gone')
        self.assertEqual(result, {
            'A/exact_lit': 'exact_decoded', 'A/in_catalog': 'exact_decoded', 'A/in_raw_name': 'exact_undecoded',
            'Blow': 'exact_undecoded_weak', '.Test_Animations/X': 'authoring', 'Pre/fix_me': 'prefix_only',
            'Gone/thing': 'absent_folder', 'Seen/thing': 'unreferenced'})

    def test_root_level_names_never_become_absent_folder(self):
        self.assertEqual(self.classify(['Lonely_Name'], folder_seen=lambda folder: False), {'Lonely_Name': 'unreferenced'})

    def test_authoring_convention(self):
        for name in ('.Spine_Technical_Stuff/Idle_Pose', 'Unused/Quarelling', 'General/Face_TEST', '*Test'):
            self.assertTrue(orphans.is_authoring(name), name)
        for name in ('General/Walking', 'Testing_Station/Idle', 'Contest/Win'):
            self.assertFalse(orphans.is_authoring(name), name)

    def test_summary_separates_evidence_from_classification(self):
        result = {'a': ('exact_decoded', []), 'b': ('exact_undecoded', ['C']), 'c': ('authoring', []), 'd': ('absent_folder', []),
                  'e': ('prefix_only', []), 'f': ('unreferenced', [])}
        summary = orphans.summarize(result)
        self.assertEqual(summary['with_exact_evidence_percent'], round(100 * 2 / 6, 2))
        self.assertEqual(summary['with_any_link_percent'], round(100 * 3 / 6, 2))      # exact + prefix, not authoring/absent
        self.assertEqual(summary['classified_percent'], round(100 * 5 / 6, 2))
        self.assertEqual(summary['unresolved_percent'], round(100 * 1 / 6, 2))

    def test_folder_seen_uses_segments_identifiers_and_raw_strings(self):
        seen = orphans.make_folder_seen({'Alpha_Folder'}, {'Beta_Folder'}, {'Gamma_Folder'}, b'\x00Delta_Folder\x00')
        for folder in ('Alpha_Folder', 'X_Folder/Beta_Folder', 'Gamma_Folder', 'Delta_Folder'):
            self.assertTrue(seen(folder), folder)
        self.assertFalse(seen('Nowhere_Folder'))
        self.assertFalse(seen('abc'))      # segments shorter than 4 chars never count


if __name__ == '__main__':
    unittest.main()
