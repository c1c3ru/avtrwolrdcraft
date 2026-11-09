"""Negative guards for the Stage1-3 indirect-dispatch decode."""
import copy
import struct
import unittest

import recon_stage_dispatch as sd


class StageDispatchTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        source = sd.nav.ROOT / 'out/recon/il2cpp'
        cls.elf = sd.nav.Elf((source / 'libil2cpp.so').read_bytes())
        cls.meta = sd.nav.Metadata((source / 'global-metadata.dat').read_bytes())
        cls.rows, resolver = sd.nav.load_index(source / 'metadata_methods.jsonl', cls.elf, cls.meta)
        cls.resolve = staticmethod(resolver)

    def mutate(self, address, word):
        changed = copy.copy(self.elf)
        changed.data = bytearray(self.elf.data)
        struct.pack_into('<I', changed.data, changed.offset(address, 4), word)
        return changed

    def decode(self, elf, stage):
        return sd.decode_stage(elf, stage, sd.STAGES[stage])

    def test_three_stages_decode(self):
        for stage in (1, 2, 3):
            result = self.decode(self.elf, stage)
            self.assertEqual(result['indirect_call'], {'kind': 'BLR', 'register': 9, 'target': None})
            self.assertEqual(result['null_guard']['kind'], 'CBZ')

    def test_event_field_offset_rejected(self):
        # Stage1 reading offset 0x8 (Stage2's slot) instead of its own 0x0.
        with self.assertRaisesRegex(ValueError, 'opcode mismatch'):
            self.decode(self.mutate(0x2072b5c, 0xf9400508), 1)

    def test_invoke_candidate_offset_rejected(self):
        # Stage2 reading the BLR target from +0x20 instead of +0x18.
        with self.assertRaisesRegex(ValueError, 'opcode mismatch'):
            self.decode(self.mutate(0x2072b94, 0xf9401109), 2)

    def test_arg_registers_rejected(self):
        # Stage3 swapping arg0/arg1 source offsets (+0x28 into x0 instead of +0x40).
        with self.assertRaisesRegex(ValueError, 'opcode mismatch'):
            self.decode(self.mutate(0x2072bc8, 0xf9401500), 3)

    def test_null_guard_polarity_rejected(self):
        # Stage1 cbz -> cbnz would invoke only when the event IS null.
        with self.assertRaisesRegex(ValueError, 'null-guard changed'):
            self.decode(self.mutate(0x2072b60, 0xb50000c8), 1)

    def test_indirect_register_rejected(self):
        # Stage2 blr x9 -> blr x10 would mean a different field supplies the target.
        with self.assertRaisesRegex(ValueError, 'indirect dispatch changed'):
            self.decode(self.mutate(0x2072ba0, 0xd63f0140), 2)

    def test_identity_guard_in_run(self):
        self.assertEqual(len(self.resolve(0x20728d4)), 1)

    def test_idiom_scan_finds_many_occurrences(self):
        result = sd.scan_idiom(self.elf, self.rows, self.resolve)
        self.assertGreater(result['total_occurrences_in_executable_segments'], 100)


if __name__ == '__main__':
    unittest.main()
