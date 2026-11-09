"""Original-input and mutation checks for the static loading/fade verifier.

Missing cached inputs fail rather than skip. These tests do not run the game.
"""
import copy
import json
import struct
import unittest

import recon_loading_fade as fade


class LoadingFadeTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        source = fade.ROOT / "out/recon/il2cpp"
        cls.binary = (source / "libil2cpp.so").read_bytes()
        cls.metadata = (source / "global-metadata.dat").read_bytes()
        fade.nav.verify_pair(cls.binary, cls.metadata)
        cls.elf, cls.meta = fade.nav.Elf(cls.binary), fade.nav.Metadata(cls.metadata)
        _, cls.resolve = fade.nav.load_index(source / "metadata_methods.jsonl", cls.elf, cls.meta)
        # Store callable as staticmethod; avoid injecting unittest's self argument.
        cls.resolve = staticmethod(cls.resolve)
        raw = json.loads((fade.ROOT / "out/recon/loading-fade/raw-binding.json").read_text())
        cls.raw = {int(key): bytes.fromhex(value) for key, value in raw["raw_hex"].items()}
        cls.scripts = {int(key): value for key, value in raw["scripts"].items()}

    def native_mutation(self, site, replacement):
        changed = copy.copy(self.elf)
        changed.data = bytearray(self.binary)
        struct.pack_into("<I", changed.data, self.elf.offset(site, 4), replacement)
        return changed

    def metadata_mutation(self, offset, replacement):
        changed = copy.copy(self.meta)
        changed.data = bytearray(self.metadata)
        struct.pack_into("<I", changed.data, offset, replacement)
        return changed

    def test_real_pair_prefab_and_native_contract(self):
        actual = fade.verify_code(self.elf, self.meta, self.resolve)
        self.assertEqual(actual["virtual_fade_target"]["method_definition_index"], 24520)
        self.assertEqual(actual["virtual_background_target"]["name"], "set_raycastTarget")
        self.assertEqual(actual["fade_duration_seconds"], 0.25)
        self.assertEqual(fade.verify_prefab(self.raw, self.scripts)["manager"]["prefab"], 242)

    def test_full_pair_identity_detects_changed_native(self):
        changed = self.native_mutation(0x20fe878, 0x1e2c1002)
        with self.assertRaisesRegex(ValueError, "native identity mismatch"):
            fade.nav.verify_pair(changed.data, self.metadata)

    def test_virtual_native_slot_mutation_rejected(self):
        with self.assertRaisesRegex(ValueError, "opcode mismatch"):
            fade.verify_code(self.native_mutation(0x20fe49c, 0xa9588d04), self.meta, self.resolve)

    def test_metadata_virtual_token_mutation_rejected(self):
        binding = fade.virtual_slot(self.meta, fade.SCREEN, 4, 24520, "Fade")
        changed = self.metadata_mutation(binding["encoded_file_offset"], 0x6000bf93)
        with self.assertRaisesRegex(ValueError, "virtual metadata method target"):
            fade.virtual_slot(changed, fade.SCREEN, 4, 24520, "Fade")

    def test_out_of_range_virtual_slot_rejected(self):
        with self.assertRaisesRegex(ValueError, "virtual slot outside"):
            fade.virtual_slot(self.meta, fade.SCREEN, 5, 24520, "Fade")

    def test_method_virtual_slot_disagreement_rejected(self):
        table = self.meta.tables["methods"]["offset"]
        changed = copy.copy(self.meta)
        changed.data = bytearray(self.metadata)
        struct.pack_into("<H", changed.data, table + 24520 * 36 + 32, 5)
        with self.assertRaisesRegex(ValueError, "slot/name mismatch"):
            fade.virtual_slot(changed, fade.SCREEN, 4, 24520, "Fade")

    def test_duration_change_rejected_without_hash_gate(self):
        with self.assertRaisesRegex(ValueError, "fade duration/register changed"):
            fade.verify_code(self.native_mutation(0x20fe878, 0x1e2c1002), self.meta, self.resolve)

    def test_alpha_polarity_inversion_rejected(self):
        changed = self.native_mutation(0x20fe858, fade.nav.word(self.elf, 0x20fe858) ^ (1 << 12))
        with self.assertRaisesRegex(ValueError, "opcode mismatch"):
            fade.verify_code(changed, self.meta, self.resolve)

    def test_completion_branch_inversion_rejected(self):
        changed = self.native_mutation(0x20feb08, fade.nav.word(self.elf, 0x20feb08) ^ (1 << 24))
        with self.assertRaisesRegex(ValueError, "opcode mismatch"):
            fade.verify_code(changed, self.meta, self.resolve)

    def test_completion_null_callback_guard_removal_rejected(self):
        with self.assertRaisesRegex(ValueError, "opcode mismatch"):
            fade.verify_code(self.native_mutation(0x20feb10, 0xd503201f), self.meta, self.resolve)

    def test_destroy_target_mutation_rejected(self):
        changed = self.native_mutation(0x20feb7c, fade.nav.word(self.elf, 0x20feb7c) + 1)
        with self.assertRaisesRegex(ValueError, "named fade callee changed"):
            fade.verify_code(changed, self.meta, self.resolve)

    def test_clock_stop_call_mutation_rejected(self):
        changed = self.native_mutation(0x20feb38, fade.nav.word(self.elf, 0x20feb38) + 1)
        with self.assertRaisesRegex(ValueError, "named fade callee changed"):
            fade.verify_code(changed, self.meta, self.resolve)

    def test_completion_callback_binding_swap_rejected(self):
        usage = fade.nav.metadata_usage(self.elf, 0x41cc840)
        changed = self.native_mutation(int(usage["usage_vaddr"], 16), int(usage["encoded"], 16) - 2)
        with self.assertRaisesRegex(ValueError, "callback metadata usage mismatch"):
            fade.verify_code(changed, self.meta, self.resolve)

    def test_coroutine_yield_removed_rejected(self):
        with self.assertRaisesRegex(ValueError, "opcode mismatch"):
            fade.verify_code(self.native_mutation(0x1cbed84, 0x2a1f03e0), self.meta, self.resolve)

    def test_coroutine_callback_register_changed_rejected(self):
        with self.assertRaisesRegex(ValueError, "opcode mismatch"):
            fade.verify_code(self.native_mutation(0x1cbedac, 0xd63f0100), self.meta, self.resolve)

    def test_prefab_reference_mutation_rejected(self):
        raw = dict(self.raw)
        manager = bytearray(raw[259])
        struct.pack_into("<q", manager, 36, 243)
        raw[259] = manager
        with self.assertRaisesRegex(ValueError, "manager prefab reference changed"):
            fade.verify_prefab(raw, self.scripts)

    def test_screen_component_reference_mutation_rejected(self):
        raw = dict(self.raw)
        screen = bytearray(raw[242])
        struct.pack_into("<q", screen, 36, 211)
        raw[242] = screen
        with self.assertRaisesRegex(ValueError, "screen field references changed"):
            fade.verify_prefab(raw, self.scripts)

    def test_script_type_substitution_rejected(self):
        scripts = copy.deepcopy(self.scripts)
        scripts[4067]["class"] = "AnotherScreen"
        with self.assertRaisesRegex(ValueError, "MonoScript class identity"):
            fade.verify_prefab(self.raw, scripts)

    def test_background_image_type_substitution_rejected(self):
        scripts = copy.deepcopy(self.scripts)
        scripts[5535]["class"] = "AnotherGraphic"
        with self.assertRaisesRegex(ValueError, "background Image script identity"):
            fade.verify_prefab(self.raw, scripts)

    def test_float_decoder_matches_real_immediates(self):
        self.assertEqual(fade.fmov_float(0x1e2a1002), 0.25)
        self.assertEqual(fade.fmov_float(0x1e2c1004), 0.5)
        self.assertEqual(fade.fmov_float(0x1e2e1004), 1.0)

    def test_result_remains_static_without_runtime_certification(self):
        report = json.loads((fade.ROOT / "reports/recon/loading_fade_contract.json").read_text())
        self.assertFalse(report["runtime_executed"])
        self.assertFalse(report["emulated"])
        self.assertFalse(report["queue_promoted"])
        self.assertTrue(report["unknowns"])


if __name__ == "__main__":
    unittest.main()
