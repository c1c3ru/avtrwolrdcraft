import struct
import unittest

import stage_dispatch_review as probe


class StageDispatchTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.binary = probe.NATIVE.read_bytes()
        cls.metadata = probe.METADATA.read_bytes()

    def rejected(self, site, word):
        mutated = bytearray(self.binary)
        struct.pack_into("<I", mutated, probe.nav.Elf(self.binary).offset(site, 4), word)
        with self.assertRaises(ValueError):
            probe.verify(mutated, self.metadata)

    def test_three_guarded_indirect_calls_and_ambiguity_preserved(self):
        report = probe.verify(self.binary, self.metadata)
        self.assertEqual(len(report["ordered_dispatches"]), 3)
        self.assertEqual([int(item["candidate_slot_offset"], 16) for item in report["ordered_dispatches"]], [0, 8, 16])
        self.assertEqual(report["typeinfo_provenance"]["resolved_typedef_candidates"][0]["index"], 3802)
        self.assertEqual(report["candidate_field_layout"]["binding_status"],
                         "CANDIDATE_only; not joined to the static-data base used at these three loads")

    def test_null_guard_mutation_rejected(self):
        site = probe.GROUPS[0]["null_guard"]
        self.rejected(site, probe.nav.word(probe.nav.Elf(self.binary), site) ^ 1)

    def test_indirect_target_register_mutation_rejected(self):
        site = probe.GROUPS[1]["invoke"]
        self.rejected(site, probe.nav.word(probe.nav.Elf(self.binary), site) ^ 1)

    def test_nonfirst_dispatch_sequence_mutation_rejected(self):
        site = probe.GROUPS[2]["method_info"]
        self.rejected(site, probe.nav.word(probe.nav.Elf(self.binary), site) ^ 1)


if __name__ == "__main__":
    unittest.main()
