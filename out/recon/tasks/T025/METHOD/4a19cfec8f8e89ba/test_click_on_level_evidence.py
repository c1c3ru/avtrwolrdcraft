import json
from pathlib import Path
import unittest

HERE = Path(__file__).resolve().parent


class ClickOnLevelEvidenceTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.result = json.loads((HERE / "result.json").read_text())
        cls.contract = json.loads((HERE / "method-contract.json").read_text())
        cls.flow = json.loads((HERE / "control-flow.json").read_text())
        cls.unknowns = [json.loads(line) for line in (HERE / "unknowns.jsonl").read_text().splitlines()]

    def test_metadata_window_is_not_mislabeled_as_complete_body(self):
        self.assertFalse(self.result["method_body_fully_bounded"])
        self.assertIn("not proven", self.result["method_body_extent"])
        self.assertIn("not the complete body", self.result["method"])
        self.assertEqual(self.contract["method_body_extent_status"],
                         "candidate_window_only; next metadata start does not prove complete or noncontiguous body/exception extents")
        self.assertIn("does not prove", self.flow["bound_limit"])

    def test_indirect_dispatches_remain_unknown(self):
        blrs = {entry["site"] for entry in self.flow["control_flow_encodings"] if entry["kind"] == "BLR"}
        self.assertEqual(blrs, {"0x2108ee4", "0x2108fe0"})
        self.assertFalse(self.contract["verification"]["semantic_certification"])
        unresolved = " ".join(item for item in self.contract["unknowns"])
        self.assertIn("delegate's actual bound target", unresolved)
        self.assertIn("vtable slot", unresolved)

    def test_candidate_window_identity_and_call_counts_are_pinned(self):
        identity = self.contract["method_identity"]
        self.assertEqual((identity["token"], identity["vaddr"], identity["exclusive_stop"], identity["body_bytes"]),
                         ("0x06006081", "0x2108e90", "0x2109014", 388))
        self.assertEqual(len(self.contract["verified_calls"]), 13)
        self.assertGreaterEqual(len(self.unknowns), 5)


if __name__ == "__main__":
    unittest.main()
