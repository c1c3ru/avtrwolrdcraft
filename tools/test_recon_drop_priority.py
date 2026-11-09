"""Pins the drop-priority/eligibility proof and rejects tampered inputs."""
import json
from pathlib import Path
import tempfile
import unittest

import recon_drop_priority as drop


class DropPriorityTests(unittest.TestCase):
    source = drop.nav.ROOT / 'out/recon/il2cpp'

    @classmethod
    def setUpClass(cls):
        cls.report = drop.probe(cls.source)

    def test_sort_uses_compare_consumers_on_the_static_drop_area_list(self):
        sort = self.report['SortDropAreas']
        self.assertIn('LevelDropArea.List', sort['list'])
        self.assertIn('CompareConsumers', sort['comparator'])

    def test_comparator_orders_by_entity_then_sorting_element_descending(self):
        compare = self.report['CompareConsumers']
        self.assertEqual(compare['consumer_interface_slots'],
                         {'0': 'GetEntity', '2': 'GetSortPriority', '4': 'GetSortingElement'})
        self.assertEqual(len(compare['order']), 4)
        self.assertIn('descending', compare['direction'])

    def test_droppable_steps_and_basic_tests(self):
        steps = self.report['IsDroppableUnderItem']['steps']
        self.assertTrue(steps[0].startswith('PerformBasicTests'))
        self.assertIn('IsPointInsideShape', steps[1])
        basic = self.report['PerformBasicTests']['steps']
        self.assertIn('dropArea.CanConsumeItem(levelItem) (virtual slot 14)', basic)

    def test_renamed_comparator_symbol_is_rejected(self):
        with tempfile.TemporaryDirectory() as temporary:
            source = Path(temporary)
            for name in ('libil2cpp.so', 'global-metadata.dat'):
                (source / name).symlink_to(self.source / name)
            rows = [json.loads(line) for line in (self.source / 'metadata_methods.jsonl').read_text().splitlines()]
            hits = [r for r in rows if r['token'] == drop.COMPARE_TOKEN]
            self.assertEqual(len(hits), 1)
            hits[0]['name'] = 'InventedComparator'
            (source / 'metadata_methods.jsonl').write_text(''.join(json.dumps(r) + '\n' for r in rows))
            with self.assertRaisesRegex(ValueError, 'cached symbol metadata mismatch'):
                drop.probe(source)

    def test_wrong_comparator_branch_encoding_is_rejected(self):
        original = drop.branch_is

        def tampered(elf, address, kind, target):
            return original(elf, address, kind, target + 4 if address == 0x22c41c0 else target)

        drop.branch_is = tampered
        try:
            with self.assertRaisesRegex(ValueError, 'branch mismatch at 0x22c41c0'):
                drop.probe(self.source)
        finally:
            drop.branch_is = original


if __name__ == '__main__':
    unittest.main()
