"""Negative guards for the building-tap contract."""
import copy
import struct
import unittest

import recon_world_click as wc


class WorldClickTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        source = wc.nav.ROOT / 'out/recon/il2cpp'
        cls.elf = wc.nav.Elf((source / 'libil2cpp.so').read_bytes())
        cls.meta = wc.nav.Metadata((source / 'global-metadata.dat').read_bytes())
        _, resolver = wc.nav.load_index(source / 'metadata_methods.jsonl', cls.elf, cls.meta)
        cls.resolve = staticmethod(resolver)

    def mutate(self, address, word, elf=None):
        changed = copy.copy(elf or self.elf)
        changed.data = bytearray((elf or self.elf).data)
        struct.pack_into('<I', changed.data, changed.offset(address, 4), word)
        return changed

    def verify(self, elf=None, meta=None):
        return wc.verify(elf or self.elf, meta or self.meta, self.resolve)

    def test_contract_verifies(self):
        result = self.verify()
        self.assertEqual(len(result['verified_calls']), 20)
        self.assertEqual({item['literal'] for item in result['literals']},
                         {'WorldBuildingData_', 'GAME_CURRENT_WORLD'})

    def test_level_choice_mutations_rejected(self):
        # default level read from +0x50 instead of +0x4c; saved-level validity branch inverted
        for address, word in [(0x2108e20, 0xb9405261), (0x2108e60, 0x54000061)]:
            with self.subTest(address=hex(address)), self.assertRaisesRegex(ValueError, 'opcode mismatch'):
                self.verify(self.mutate(address, word))

    def test_gate_polarity_and_flag_offset_rejected(self):
        for address, word in [(0x2108fa0, 0x370002a0), (0x2108f84, 0x3941c908), (0x2108f94, 0x36000080)]:
            with self.subTest(address=hex(address)), self.assertRaisesRegex(ValueError, 'opcode mismatch'):
                self.verify(self.mutate(address, word))

    def test_save_before_scene_name_cannot_change(self):
        # SaveBuildingData replaced by LoadScene's address -> callee mismatch
        word = 0x94000000 | (((0x20728d4 - 0x2108fbc) // 4) & 0x3ffffff)
        with self.assertRaisesRegex(ValueError, 'callee mismatch'):
            self.verify(self.mutate(0x2108fbc, word))

    def test_ugc_and_pointer_gates_rejected(self):
        # UGC edit-mode gate polarity, IsEditMode offset, dragging offset, reset-mode polarity
        for address, word in [(0x2108de4, 0x340004c8), (0x2108de0, 0x3940a508),
                              (0x2102aac, 0x39451828), (0x2102aec, 0x35000088)]:
            with self.subTest(address=hex(address)), self.assertRaisesRegex(ValueError, 'opcode mismatch'):
                self.verify(self.mutate(address, word))

    def test_try_load_empty_handling_rejected(self):
        for address, word in [(0x21090e0, 0x37000080), (0x21090e4, 0x52800020)]:
            with self.subTest(address=hex(address)), self.assertRaisesRegex(ValueError, 'opcode mismatch'):
                self.verify(self.mutate(address, word))

    def test_literals_rejected_when_changed(self):
        changed = copy.copy(self.meta)
        changed.data = bytearray(self.meta.data)
        found = wc.nav.literal(self.meta, wc.nav.metadata_usage(
            self.elf, wc.nav.adrp_ldr(self.elf, 0x20728a8, 0x20728ac)['got_vaddr']))
        changed.data[found['literal_file_offset']] = ord('X')
        with self.assertRaisesRegex(ValueError, 'literal mismatch'):
            self.verify(meta=changed)

    def test_world_scene_persist_call_rejected(self):
        # GAME_CURRENT_WORLD write replaced by a different PlayerPrefs call
        word = 0x14000000 | (((0x3cc5a70 - 0x20728d0) // 4) & 0x3ffffff)
        with self.assertRaisesRegex(ValueError, 'callee mismatch'):
            self.verify(self.mutate(0x20728d0, word))


if __name__ == '__main__':
    unittest.main()
