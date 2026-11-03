"""Meaningful mutation/identity guards for the shipped navigation pilot.

These tests require the cached original pair; absence is a failure, not a skip.
They check the evidence verifier, not execution equivalence of the game.
"""
import copy
from pathlib import Path
import struct
import unittest

import recon_navigation as nav


class NavigationContractTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        source = nav.ROOT / "out/recon/il2cpp"
        cls.binary = (source / "libil2cpp.so").read_bytes()
        cls.metadata = (source / "global-metadata.dat").read_bytes()
        cls.elf = nav.Elf(cls.binary)
        cls.meta = nav.Metadata(cls.metadata)
        cls.contract = nav.verify_getter(cls.elf, cls.meta)

    def mutated_elf(self, address, instruction):
        result = copy.copy(self.elf)
        result.data = bytearray(self.binary)
        struct.pack_into("<I", result.data, self.elf.offset(address, 4), instruction)
        return result

    def mutated_metadata_byte(self, offset, value):
        result = copy.copy(self.meta)
        result.data = bytearray(self.metadata)
        result.data[offset] = value
        return result

    def test_original_pair_identity(self):
        nav.verify_pair(self.binary, self.metadata)

    def test_changed_native_hash_rejected(self):
        mutated = self.mutated_elf(0x20732f4, 0x9a930280)
        with self.assertRaisesRegex(ValueError, "native identity"):
            nav.verify_pair(mutated.data, self.metadata)

    def test_changed_metadata_hash_rejected(self):
        changed = bytearray(self.metadata)
        changed[-1] ^= 1
        with self.assertRaisesRegex(ValueError, "metadata identity"):
            nav.verify_pair(self.binary, changed)

    def test_real_key_and_default_from_metadata(self):
        self.assertEqual(self.contract["key"]["literal"], "GAME_CURRENT_WORLD")
        self.assertEqual(self.contract["default_enum"]["type"], "PWC.Game.LevelWorldType")
        constants = self.contract["default_enum"]["constants"]
        self.assertEqual(constants["World"]["value"], 1)
        self.assertEqual(constants["College"]["value"], 6)
        self.assertEqual(self.contract["default_enum"]["value"], 1)

    def test_literal_mutation_detected_without_hash_gate(self):
        offset = self.contract["key"]["literal_file_offset"]
        changed = self.mutated_metadata_byte(offset, ord("X"))
        with self.assertRaisesRegex(ValueError, "key literal mismatch"):
            nav.verify_getter(self.elf, changed)

    def test_compressed_enum_constant_mutation_detected(self):
        offset = self.contract["default_enum"]["constants"]["World"]["file_offset"]
        with self.assertRaisesRegex(ValueError, "World default"):
            nav.verify_getter(self.elf, self.mutated_metadata_byte(offset, 4))

    def test_unsupported_compressed_enum_encoding_rejected(self):
        offset = self.contract["default_enum"]["constants"]["World"]["file_offset"]
        with self.assertRaisesRegex(ValueError, "unsupported enum compressed"):
            nav.verify_getter(self.elf, self.mutated_metadata_byte(offset, 0x80))

    def test_default_opcode_changed_to_two_rejected(self):
        with self.assertRaisesRegex(ValueError, "opcode mismatch"):
            nav.verify_getter(self.mutated_elf(0x20732a0, 0x5280004a), self.meta)

    def test_selection_condition_inversion_rejected(self):
        instruction = nav.word(self.elf, 0x20732f4) ^ (1 << 12)  # NE -> EQ
        with self.assertRaisesRegex(ValueError, "selection condition/register mismatch"):
            nav.verify_getter(self.mutated_elf(0x20732f4, instruction), self.meta)

    def test_selection_candidate_register_mutation_rejected(self):
        instruction = nav.word(self.elf, 0x20732f4) ^ (1 << 5)
        with self.assertRaisesRegex(ValueError, "selection condition/register mismatch"):
            nav.verify_getter(self.mutated_elf(0x20732f4, instruction), self.meta)

    def test_candidate_state_move_mutation_rejected(self):
        with self.assertRaisesRegex(ValueError, "opcode mismatch"):
            nav.verify_getter(self.mutated_elf(0x20732d4, 0xaa0003f3), self.meta)

    def test_availability_target_mutation_rejected(self):
        instruction = nav.word(self.elf, 0x20732ec) + 1  # BL target moved +4
        with self.assertRaisesRegex(ValueError, "callee changed"):
            nav.verify_getter(self.mutated_elf(0x20732ec, instruction), self.meta)

    def test_class_init_guard_inversion_rejected(self):
        instruction = nav.word(self.elf, 0x20732dc) ^ (1 << 24)
        with self.assertRaisesRegex(ValueError, "class-init guard changed"):
            nav.verify_getter(self.mutated_elf(0x20732dc, instruction), self.meta)

    def test_key_ldr_register_mutation_rejected(self):
        instruction = nav.word(self.elf, 0x2073260) ^ 1
        with self.assertRaisesRegex(ValueError, "key slot must be"):
            nav.verify_getter(self.mutated_elf(0x2073260, instruction), self.meta)

    def test_adrp_ldr_invalid_base_rejected(self):
        instruction = nav.word(self.elf, 0x2073260) ^ (1 << 5)
        with self.assertRaisesRegex(ValueError, "base-register mismatch"):
            nav.verify_getter(self.mutated_elf(0x2073260, instruction), self.meta)

    def test_getter_return_removed_rejected(self):
        with self.assertRaisesRegex(ValueError, "opcode mismatch"):
            nav.verify_getter(self.mutated_elf(0x2073308, 0xd503201f), self.meta)

    def test_window_mutation_outside_getter_rejected(self):
        changed = self.mutated_elf(0x2073178, nav.word(self.elf, 0x2073178) + 1)
        resolver = lambda address: [{"name": "IsSceneAvailable", "declaring_type": "PWC.GameSceneManager"}]
        with self.assertRaisesRegex(ValueError, "window bytes changed"):
            nav.code_window(changed, "IsSceneAvailable", resolver)

    def test_direct_backward_branch_decoding(self):
        decoded = nav.branch(0x20731ec, nav.word(self.elf, 0x20731ec))
        self.assertEqual(decoded, {"kind": "B", "target": 0x2073164})

    def test_indirect_loading_tail_is_unknown(self):
        self.assertEqual(nav.branch(0x20fe4ac, nav.word(self.elf, 0x20fe4ac)),
                         {"kind": "BR", "register": 4, "target": None})

    def test_real_transition_anchors(self):
        result = nav.verify_transition_anchors(self.elf)
        self.assertEqual(result["direct_call_sites"], 21)

    def test_mutated_cache_store_detected(self):
        with self.assertRaisesRegex(ValueError, "opcode mismatch"):
            nav.verify_transition_anchors(self.mutated_elf(0x2073140, 0xf8040c14))

    def test_mutated_loop_exit_condition_detected(self):
        instruction = nav.word(self.elf, 0x2073180) ^ 1
        with self.assertRaisesRegex(ValueError, "signed exit changed"):
            nav.verify_transition_anchors(self.mutated_elf(0x2073180, instruction))

    def test_mutated_loading_virtual_register_detected(self):
        instruction = nav.word(self.elf, 0x20fe4ac) ^ (1 << 5)
        with self.assertRaisesRegex(ValueError, "virtual tail dispatch changed"):
            nav.verify_transition_anchors(self.mutated_elf(0x20fe4ac, instruction))

    def test_mutated_stage_callback_detected(self):
        instruction = nav.word(self.elf, 0x2072ba0) ^ (1 << 5)
        with self.assertRaisesRegex(ValueError, "stage callback"):
            nav.verify_transition_anchors(self.mutated_elf(0x2072ba0, instruction))

    def test_static_checks_do_not_claim_emulation_or_certification(self):
        self.assertEqual(self.contract["status"], "STATIC_candidate_contract_checked_not_certified")
        self.assertTrue(self.contract["unknowns"])


if __name__ == "__main__":
    unittest.main()
