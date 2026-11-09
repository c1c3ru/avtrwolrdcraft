import copy
import json
import sys
import unittest
from pathlib import Path

HERE = Path(__file__).resolve().parent
sys.path.insert(0, str(HERE))
from followup_stage_candidates import valid_registration_edge


class StageCandidateAnalysisTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.report = json.loads((HERE / "stage_candidate_analysis.json").read_text(encoding="utf-8"))

    def test_all_nine_remaining_direct_candidates_resolve_and_flow_to_event_add(self):
        candidates = self.report["candidates"]
        self.assertEqual(len(candidates), 9)
        self.assertEqual(self.report["summary"]["handler_methoddefs_resolved_at_last_Action_ctor"], 9)
        self.assertEqual(self.report["summary"]["add_accessor_targets_resolved"], 9)
        self.assertEqual(self.report["summary"]["positive_static_registration_edges"], 9)
        scan = self.report["reconciled_direct_stage_registration_scan"]
        self.assertEqual(scan["raw_direct_candidates"], 13)
        self.assertEqual(scan["prior_positive_stage_edges"], 4)
        self.assertEqual(scan["total_direct_candidates_verified"], 13)
        declarations = self.report["game_manager_stage_field_declarations"]
        offsets = {f["name"]: f["offset"] for f in declarations["fields"]}
        self.assertEqual(offsets, {"OnBeforeSceneLoadStage1Action": "0x0",
                                   "OnBeforeSceneLoadStage2Action": "0x8",
                                   "OnBeforeSceneLoadStage3Action": "0x10"})
        self.assertEqual(declarations["binding_status"], "CANDIDATE_ONLY_unresolved_static_data_base")
        self.assertIn("not joined", declarations["limit"])
        result = json.loads((HERE / "result.json").read_text(encoding="utf-8"))
        self.assertFalse(result["method_body_fully_bounded"])
        for candidate in candidates:
            self.assertTrue(valid_registration_edge(candidate), candidate["owner_candidate"])

    def test_handler_map_is_stable_for_the_pinned_pair(self):
        actual = {(c["owner_candidate"]["declaring_type"],
                   c["handler_resolution"]["handler"]["declaring_type"],
                   c["handler_resolution"]["handler"]["name"],
                   c["resolved_add_method"][0]["name"])
                  for c in self.report["candidates"]}
        self.assertEqual(actual, {
            ("Game.Level.LevelDigHoleArea", "Game.Level.LevelDigHoleArea", "OnBeforeSceneLoadStage1", "add_OnBeforeSceneLoadStage1Action"),
            ("Game.Level.LevelSpawnOnLevelPostInit", "Game.Level.LevelSpawnOnLevelPostInit", "DestroyCurrentItems", "add_OnBeforeSceneLoadStage1Action"),
            ("Game.Level.WaterSlide.LevelSlideSwitcherHandler", "Game.Level.WaterSlide.LevelSlideSwitcherHandler", "OnBeforeSceneLoadStage1", "add_OnBeforeSceneLoadStage1Action"),
            ("Game.Level.Locker.LevelLockerSpawnOnPostInit", "Game.Level.LevelSpawnOnLevelPostInit", "DestroyCurrentItems", "add_OnBeforeSceneLoadStage1Action"),
            ("PWC.AvatarSpeech.AvatarSpeechUIMenu", "PWC.AvatarSpeech.AvatarSpeechUIMenu", "OnBeforeSceneLoadStage1", "add_OnBeforeSceneLoadStage1Action"),
            ("PWC.Level.LevelKillArea", "PWC.Level.LevelKillArea", "OnBeforeSceneLoadStage1", "add_OnBeforeSceneLoadStage1Action"),
            ("PWC.Level.LevelScreenshotManager", "PWC.Level.LevelScreenshotManager", "OnBeforeSceneLoad", "add_OnBeforeSceneLoadStage2Action"),
            ("PWC.Level.LevelNewAvatarManager", "PWC.Level.LevelNewAvatarManager", "OnBeforeSceneLoadStage1", "add_OnBeforeSceneLoadStage1Action"),
            ("PWC.Level.LevelMakerSwitcher", "PWC.Level.LevelMakerSwitcher", "OnBeforeSceneLoadStage3", "add_OnBeforeSceneLoadStage3Action"),
        })

    def test_mutated_methoddef_or_delegate_flow_is_rejected(self):
        original = self.report["candidates"][0]
        for mutate in (
            lambda x: x["handler_resolution"]["metadata_usage"].update(index=0),
            lambda x: x["event_add_target"].update(target=0),
            lambda x: x["delegate_result_to_event_argument"].update(delegate_receiver_x1_is_this_x19=False),
            lambda x: x["delegate_result_to_event_argument"].update(event_add_methodinfo_x1_is_null=False),
            lambda x: x["delegate_result_to_event_argument"].update(owner_and_handler_type_compatible=False),
        ):
            changed = copy.deepcopy(original)
            mutate(changed)
            self.assertFalse(valid_registration_edge(changed))


if __name__ == "__main__":
    unittest.main()
