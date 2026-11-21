import copy
import unittest

import recon_stage_handlers as plan


class StageHandlerPlanTests(unittest.TestCase):
    def test_thirteen_edges_deduplicate_to_twelve_exact_methoddefs(self):
        report = plan.build_manifest()
        self.assertEqual(report["registration_edges"], 13)
        self.assertEqual(report["unique_handler_methoddefs"], 12)
        self.assertEqual(report["deduplicated_handlers"], 12)
        ids = [task["id"] for task in report["tasks"]]
        self.assertEqual(len(ids), len(set(ids)))

    def test_every_child_is_pending_hash_pinned_and_isolated(self):
        report = plan.build_manifest()
        for task in report["tasks"]:
            self.assertEqual(task["state"], "pending")
            self.assertEqual(task["parent_id"], "T025")
            self.assertEqual(len(task["input_refs"]), 5)
            self.assertTrue(all(len(item["sha256"]) == 64 for item in task["input_refs"]))
            self.assertEqual(len(task["allowed_paths"]), 1)
            self.assertTrue(task["allowed_paths"][0].endswith("/**"))
            self.assertEqual(len(task["outputs"]), 4)
            self.assertIn("independent", task["acceptance"])
            self.assertIn("partial/ready", task["input_and_steps"])

    def test_shared_destroy_current_items_handler_has_one_task(self):
        report = plan.build_manifest()
        matches = [task for task in report["tasks"]
                   if task["scope"]["method_identity"]["name"] == "DestroyCurrentItems"]
        self.assertEqual(len(matches), 1)
        self.assertEqual(matches[0]["scope"]["method_definition_index"], 12968)


if __name__ == "__main__":
    unittest.main()
