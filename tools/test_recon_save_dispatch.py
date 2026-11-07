import copy
import unittest

import recon_save_dispatch


class SaveDispatchTests(unittest.TestCase):
    def test_all_focused_contracts_verify_against_current_evidence(self):
        report = recon_save_dispatch.build_report()
        self.assertEqual(len(report["contracts"]), 4)
        self.assertTrue(all(row["status"] == "verified_call_shape" for row in report["contracts"]))
        self.assertEqual({row["kind"] for row in report["contracts"]}, {"delegate", "interface_dispatch"})

    def test_wrong_site_is_rejected(self):
        contract = copy.deepcopy(recon_save_dispatch.CONTRACTS[0])
        contract["site"] = "00000000"
        with self.assertRaisesRegex(ValueError, "call site"):
            recon_save_dispatch.verify_contract(contract)

    def test_missing_anchor_is_rejected(self):
        contract = copy.deepcopy(recon_save_dispatch.CONTRACTS[0])
        contract["anchors"].append("instruction that cannot exist")
        with self.assertRaisesRegex(ValueError, "anchors missing"):
            recon_save_dispatch.verify_contract(contract)


if __name__ == "__main__":
    unittest.main()
