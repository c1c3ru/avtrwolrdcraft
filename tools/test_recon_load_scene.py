"""Negative guards for the LoadScene contract."""
import copy
import struct
import unittest

import recon_load_scene as ls


class LoadSceneTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        source = ls.nav.ROOT / 'out/recon/il2cpp'
        cls.elf = ls.nav.Elf((source / 'libil2cpp.so').read_bytes())
        cls.meta = ls.nav.Metadata((source / 'global-metadata.dat').read_bytes())
        cls.rows, resolver = ls.nav.load_index(source / 'metadata_methods.jsonl', cls.elf, cls.meta)
        cls.resolve = staticmethod(resolver)

    def mutate(self, address, word):
        changed = copy.copy(self.elf)
        changed.data = bytearray(self.elf.data)
        struct.pack_into('<I', changed.data, changed.offset(address, 4), word)
        return changed

    def verify(self, elf):
        return ls.verify(elf, self.meta, self.resolve, self.rows)

    def test_contract_verifies(self):
        result = self.verify(self.elf)
        self.assertEqual(len(result['load_scene_calls']), 7)
        self.assertEqual(len(result['implement_calls']), 2)

    def test_in_progress_guard_polarity_rejected(self):
        with self.assertRaisesRegex(ValueError, 'opcode mismatch'):
            self.verify(self.mutate(0x2072a1c, 0x35000208))  # cbz -> cbnz

    def test_static_field_offsets_rejected(self):
        for address, word in [(0x2072b28, 0x3900c408), (0x2072b30, 0xf8029c01)]:
            with self.subTest(address=hex(address)), self.assertRaisesRegex(ValueError, 'opcode mismatch'):
                self.verify(self.mutate(address, word))

    def test_wrong_callee_rejected(self):
        # Branch to LoadSceneAsync instead of Debug.LogError.
        word = 0x14000000 | (((0x3cdc604 - 0x2072a58) // 4) & 0x3ffffff)
        with self.assertRaisesRegex(ValueError, 'callee mismatch'):
            self.verify(self.mutate(0x2072a58, word))

    def test_reset_stores_rejected(self):
        # Clearing a different static (+0x38) instead of IsSceneChangingInProgress / loading names.
        for address, word in [(0x20725e8, 0x3900e11f), (0x2072710, 0xf8038c1f), (0x20726f8, 0xf8050c1f)]:
            with self.subTest(address=hex(address)), self.assertRaisesRegex(ValueError, 'opcode mismatch'):
                self.verify(self.mutate(address, word))

    def test_multiplayer_clear_guard_rejected(self):
        with self.assertRaisesRegex(ValueError, 'opcode mismatch'):
            self.verify(self.mutate(0x2072d3c, 0x35000128))


if __name__ == '__main__':
    unittest.main()
