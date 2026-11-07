"""Negative guards for the building access-gate inputs."""
import copy
import struct
import unittest

import recon_access_gate as ag


class AccessGateTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        source = ag.nav.ROOT / 'out/recon/il2cpp'
        cls.elf = ag.nav.Elf((source / 'libil2cpp.so').read_bytes())
        cls.meta = ag.nav.Metadata((source / 'global-metadata.dat').read_bytes())
        _, resolver = ag.nav.load_index(source / 'metadata_methods.jsonl', cls.elf, cls.meta)
        cls.resolve = staticmethod(resolver)

    def mutate(self, address, word):
        changed = copy.copy(self.elf)
        changed.data = bytearray(self.elf.data)
        struct.pack_into('<I', changed.data, changed.offset(address, 4), word)
        return changed

    def verify(self, elf=None, meta=None):
        return ag.verify(elf or self.elf, meta or self.meta, self.resolve)

    def test_contract_verifies(self):
        result = self.verify()
        self.assertEqual(len(result['verified_calls']), 10)
        self.assertEqual({item['literal'] for item in result['literals']}, {'is_active_subscription', '1'})

    def test_is_all_world_free_value_cannot_change(self):
        # mov w9,#0 instead of #1 would make buildings paid; verifier must notice
        with self.assertRaisesRegex(ValueError, 'opcode mismatch'):
            self.verify(self.mutate(0x207cc38, 0x52800009))

    def test_is_currently_free_logic_mutations_rejected(self):
        for address, word in [(0x2109168, 0x34000068), (0x2109164, 0x39416668), (0x21091ac, 0x1a9f17e0)]:
            with self.subTest(address=hex(address)), self.assertRaisesRegex(ValueError, 'opcode mismatch'):
                self.verify(self.mutate(address, word))

    def test_is_game_unlocked_negation_rejected(self):
        with self.assertRaisesRegex(ValueError, 'opcode mismatch'):
            self.verify(self.mutate(0x1cbb7f4, 0x2a0003e8))  # drops mvn

    def test_changed_subscription_literal_rejected(self):
        found = ag.nav.literal(self.meta, ag.nav.metadata_usage(
            self.elf, ag.nav.adrp_ldr(self.elf, 0x1cd9dd0, 0x1cd9dd4)['got_vaddr']))
        changed = copy.copy(self.meta)
        changed.data = bytearray(self.meta.data)
        changed.data[found['literal_file_offset']] = ord('X')
        with self.assertRaisesRegex(ValueError, 'literal mismatch'):
            self.verify(meta=changed)


if __name__ == '__main__':
    unittest.main()
