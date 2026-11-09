import unittest

import recon_save_cfg


class SaveCfgTests(unittest.TestCase):
    def test_hex_target_skips_symbolic_annotation_offset(self):
        # llvm-objdump prints "<symbol+0x...>" after the real target; that
        # annotation's own offset must not be mistaken for the branch target.
        operands = "w8, #0x0, 0x21e24f8 <__start_il2cpp+0x5912e8>"
        self.assertEqual(recon_save_cfg.hex_target(operands), 0x21E24F8)

    def test_hex_target_handles_plain_conditional_branch(self):
        self.assertEqual(recon_save_cfg.hex_target("0x21e2530"), 0x21E2530)

    def test_bl_targets_outside_window_do_not_count_as_incomplete(self):
        # A `bl` to a far-away shared runtime helper is an ordinary call, not
        # evidence that the function's own body was cut short by the window.
        insns = [
            (0x1000, "stp", "x29, x30, [sp, #-0x10]!"),
            (0x1004, "bl", "0x9999000 <shared_helper>"),
            (0x1008, "ret", ""),
        ]
        cfg = recon_save_cfg.build_cfg(insns, 0x1000, 0x100C)
        self.assertEqual(cfg["out_of_window_targets"], [])
        self.assertTrue(cfg["ends_in_return"])

    def test_unconditional_jump_outside_window_is_flagged(self):
        insns = [
            (0x1000, "cmp", "w0, #0x0"),
            (0x1004, "b", "0x9999000 <far_away>"),
        ]
        cfg = recon_save_cfg.build_cfg(insns, 0x1000, 0x1008)
        self.assertEqual(len(cfg["out_of_window_targets"]), 1)
        self.assertEqual(cfg["out_of_window_targets"][0]["kind"], "b")

    def test_report_against_committed_t030_evidence(self):
        report = recon_save_cfg.ASM_DIR / "cfg-report.json"
        self.assertTrue(report.is_file(), "run recon_save_cfg.py to regenerate cfg-report.json")
        import json

        data = json.loads(report.read_text(encoding="utf-8"))
        self.assertEqual(len(data["methods"]), 58)
        by_name = {(m["declaring_type"], m["name"]): m for m in data["methods"]}
        for target in [
            "GetDataFromRootGameObjects",
            "LoadDataInternal",
            "GetFilePath",
            "SaveDataInternal",
            "SetPersistentData",
        ]:
            m = by_name[("PWC.PersistentData.PersistentDataManager", target)]
            self.assertTrue(m["bounded_within_window"], f"{target} has an intra-function jump leaving its window")


if __name__ == "__main__":
    unittest.main()
