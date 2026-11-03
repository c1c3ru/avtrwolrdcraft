"""Negative guards for Home Play evidence, independent of the full-file hash."""
import copy
import json
from pathlib import Path
import struct
import tempfile
import unittest

import recon_home_play as home


class HomePlayTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        source = home.nav.ROOT / 'out/recon/il2cpp'
        cls.elf = home.nav.Elf((source / 'libil2cpp.so').read_bytes())
        cls.meta = home.nav.Metadata((source / 'global-metadata.dat').read_bytes())
        _, resolver = home.nav.load_index(source / 'metadata_methods.jsonl', cls.elf, cls.meta)
        cls.resolve = staticmethod(resolver)

    def mutate(self, address, word):
        changed = copy.copy(self.elf)
        changed.data = bytearray(self.elf.data)
        struct.pack_into('<I', changed.data, changed.offset(address, 4), word)
        return changed

    def test_key_calls_and_unknown_dispatch(self):
        result = home.verify(self.elf, self.meta, self.resolve)
        self.assertEqual(result['pending_key']['literal'], 'pazucore_pending_deep_link')
        self.assertEqual(len(result['verified_calls']), 11)
        self.assertEqual(result['unresolved_indirect_dispatch']['site'], '0x2058174')

    def test_dispatch_receiver_field_anchor_mutation_rejected(self):
        result = home.verify(self.elf, self.meta, self.resolve)
        self.assertEqual(result['dispatch_candidate']['confidence'], 'inferred')
        with self.assertRaisesRegex(ValueError, 'opcode mismatch'):
            home.verify(self.mutate(0x205810c, 0xf9401914), self.meta, self.resolve)  # +0x30

    def test_guard_polarity_and_scene_return_value_mutations_rejected(self):
        # Includes the wrong zero-value propagation observed in external pseudo-C.
        for address, instruction in [(0x2058054, 0x370002c0), (0x20580a0, 0x370001a0),
                                     (0x20580cc, 0xaa1f03f3), (0x20581cc, 0xaa1f03e0),
                                     (0x20581d4, 0x52800001), (0x20580a4, 0x52800073)]:
            with self.subTest(address=hex(address)), self.assertRaisesRegex(ValueError, 'opcode mismatch'):
                home.verify(self.mutate(address, instruction), self.meta, self.resolve)

    def test_deleted_key_side_effect_cannot_be_replaced_by_read(self):
        address, target = 0x2058184, 0x3cc5a70
        word = 0x94000000 | (((target - address) // 4) & 0x3ffffff)
        with self.assertRaisesRegex(ValueError, 'callee mismatch'):
            home.verify(self.mutate(address, word), self.meta, self.resolve)

    def test_changed_pending_key_rejected(self):
        result = home.verify(self.elf, self.meta, self.resolve)
        changed = copy.copy(self.meta)
        changed.data = bytearray(self.meta.data)
        changed.data[result['pending_key']['literal_file_offset']] = ord('X')
        with self.assertRaisesRegex(ValueError, 'pending key mismatch'):
            home.verify(self.elf, changed, self.resolve)

    def test_cfg_preserves_indirect_and_unknown_boundary(self):
        flow = home.bounded_flow(self.elf)
        self.assertEqual(flow['reachable_instruction_count'], 145)
        self.assertIn({'from': '0x2058174', 'to': None, 'kind': 'unresolved_call'}, flow['edges'])
        self.assertIn({'from': '0x20581e8', 'to': '0x20581ec', 'kind': 'fallthrough',
                       'inside': False}, flow['edges'])

    def test_external_listing_wrong_byte_or_missing_instruction_rejected(self):
        rows = []
        for address in range(home.START, home.STOP, 4):
            offset = self.elf.offset(address, 4)
            rows.append(f'{address:#x} {self.elf.data[offset:offset+4].hex()} instruction')
        with tempfile.TemporaryDirectory() as temporary:
            path = Path(temporary) / 'listing.json'
            def write(lines):
                path.write_text(json.dumps({'id': 'fixture', 'result': {'assembly': '\n'.join(lines)}}))
            write(rows)
            self.assertEqual(home.compare_craft(self.elf, path)['verified_instruction_bytes'], 145)
            write(rows[:-1])
            with self.assertRaisesRegex(ValueError, 'missing or duplicate'):
                home.compare_craft(self.elf, path)
            rows[0] = f'{home.START:#x} 00000000 instruction'
            write(rows)
            with self.assertRaisesRegex(ValueError, 'bytes/address mismatch'):
                home.compare_craft(self.elf, path)


if __name__ == '__main__':
    unittest.main()
