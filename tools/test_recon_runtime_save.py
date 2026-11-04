import json
from pathlib import Path
import tempfile
import unittest

import recon_runtime_save


class RuntimeSaveSummaryTests(unittest.TestCase):
    def setUp(self):
        self.temp = tempfile.TemporaryDirectory()
        self.root = Path(self.temp.name)
        (self.root / "Levels/World").mkdir(parents=True)
        self.save = self.root / "Levels/World/World"
        self.save.write_text(json.dumps({
            "Prefabs": {"prefab-guid": [json.dumps({"sceneObjects": ["runtime-guid"]})]},
            "SceneObjects": {
                "static-guid": {"GameCameraPD": json.dumps({"xPosition": 1.0, "yPosition": 2.0, "size": 3.0})},
                "runtime-guid": {"TransformPD": json.dumps({"parent": "root", "position": {"x": -2.0, "y": 4.0}, "isFlipped": True})},
            },
            "NewAndSyncedSceneObjects": [],
            "BuildNumber": 228,
        }), encoding="utf-8")
        self.static_report = self.root / "level4.json"
        self.static_report.write_text(json.dumps({"PDSceneObjects": [
            {"scene_guid": "static-guid"}, {"scene_guid": "static-only"},
        ]}), encoding="utf-8")

    def tearDown(self):
        self.temp.cleanup()

    def test_summary_omits_identifiers_and_values(self):
        report = recon_runtime_save.build_report(self.root, {"World": self.static_report})
        summary = report["saves"][0]
        encoded = json.dumps(report)
        self.assertNotIn("runtime-guid", encoded)
        self.assertNotIn("static-guid", encoded)
        self.assertEqual(summary["build_number"], 228)
        self.assertEqual(summary["counts"], {
            "prefab_guids": 1, "prefab_instances": 1, "scene_objects": 2,
            "new_and_synced_scene_objects": 0,
        })
        self.assertEqual(summary["payloads"]["schemas"]["TransformPD"]["count"], 1)
        self.assertEqual(summary["transform_pd"]["position_range"]["x_min"], -2.0)

    def test_static_comparison_counts_intersection_without_listing_keys(self):
        report = recon_runtime_save.build_report(self.root, {"World": self.static_report})
        comparison = report["saves"][0]["static_scene_comparison"]
        self.assertEqual(comparison, {
            "static_scene_guids": 2, "runtime_scene_keys": 2, "intersection": 1,
            "static_only": 1, "runtime_only": 1,
        })

    def test_rejects_unexpected_root_collection_type(self):
        self.save.write_text(json.dumps({"Prefabs": [], "SceneObjects": {},
                                         "NewAndSyncedSceneObjects": [], "BuildNumber": 228}), encoding="utf-8")
        with self.assertRaisesRegex(ValueError, "unexpected types"):
            recon_runtime_save.summarize_save(self.save, self.root)


if __name__ == "__main__":
    unittest.main()
