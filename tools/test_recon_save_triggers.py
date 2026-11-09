"""Pins the save/load trigger proof, CanSaveScene and the PlayerPrefs key inventory."""
import unittest
import os
from pathlib import Path

import recon_save_triggers as triggers


SOURCE = Path(os.environ.get('RECON_IL2CPP_ROOT') or triggers.nav.ROOT / 'out/recon/il2cpp')


@unittest.skipUnless(SOURCE.is_dir(), 'IL2CPP cache unavailable (set RECON_IL2CPP_ROOT)')
class SaveTriggerTests(unittest.TestCase):
    source = SOURCE

    @classmethod
    def setUpClass(cls):
        cls.report = triggers.probe(cls.source)

    def test_scene_change_and_pause_are_the_only_automatic_saves(self):
        callers = self.report['direct_callers']
        self.assertEqual(callers['SaveProgressInAllScenes'], sorted([
            'PWC.PersistentData.PersistentDataManager.OnApplicationPause',
            'PWC.PersistentData.PersistentDataManager.OnBeforeSceneLoadStage2']))
        self.assertEqual(callers['CanSaveScene'], ['PWC.PersistentData.PersistentDataManager.OnApplicationPause'])

    def test_can_save_scene_rule(self):
        rule = self.report['triggers']['can_save_scene']
        self.assertIn('!GameSceneManager.IsSceneChangingInProgress', rule)
        self.assertIn('LevelManager.Instance.IsPostInit', rule)

    def test_loads_and_reset_callers(self):
        callers = self.report['direct_callers']
        self.assertEqual(callers['LoadProgress'], sorted([
            'PWC.Level.LevelManager.Init', 'PWC.Level.Maker.LevelMakerSplitLevelManager.LoadCurrentLevel', 'PWC.World.WorldManager.Init']))
        self.assertEqual(callers['DeleteDataForActiveScene'], ['PWC.Level.LevelUpgradeTracker.ResetCurrentLevelPD'])

    def test_playerprefs_key_inventory(self):
        keys = self.report['playerprefs_keys']
        self.assertEqual(keys['PWC.Level.LevelAvatarData.Save'], ['LevelCharacterData_'])
        self.assertIn('StoreState', keys['Game.Store.StoreManager.MigrateStateFileIfNeeded'])
        self.assertIn('PazuWorld_PersistantData_KeepObjectsOnLoad',
                      keys['PWC.PersistentData.PersistentDataManager.SaveSceneObjectsToKeepOnLoad'])

    def test_migrations_move_files_and_scene_data_carries_a_build_number(self):
        versioning = self.report['versioning']
        self.assertIn('file-location migration', versioning['migrations'])
        self.assertIn('BuildNumber', versioning['schema_versioning'])
        self.assertIn('inlines trivial accessors', versioning['build_number_consumers']['caveat'])
        helper = versioning['file_migration_helper']
        self.assertEqual([call['method'] for call in helper['calls']], [
            'Utils.IsAndroidBuild', 'FileManager.TryLoadTextFile',
            'FileManager.SaveTextFile', 'FileManager.DeleteTextFile'])

    def test_scene_persistence_is_local_and_economy_claims_are_server_bound(self):
        cloud = self.report['cloud_boundary']
        self.assertIn('Game.Store.StoreManager.ClaimItemInternal', cloud['server_bound']['SendOperation'])
        self.assertIn('PWC.CloudProgress.CPManager.Upload', cloud['server_bound']['SendOperation'])
        self.assertEqual(cloud['persistent_data_manager_direct_server_calls'], [])

    def test_cloud_game_data_is_a_string_but_its_game_payload_initializer_is_unresolved(self):
        sync = self.report['cloud_boundary']['game_data_sync']
        callers = sync['direct_callers']
        self.assertEqual(callers['GameDataManager.Init'], [])
        self.assertEqual(callers['PazuCloudManager.SetGameData'], [
            'PazuCore.PazuCloud.PazuCloudGameDataManager.SendGameDataInternal'])
        self.assertIn('gameDataJson', sync['declarations']['set_request'])
        self.assertIn('unknown', sync['inner_game_payload'])

    def test_missing_cloud_caller_is_rejected(self):
        original = triggers.CLOUD_CALLERS['VerifyReceipt']
        triggers.CLOUD_CALLERS['VerifyReceipt'] = original | {'PWC.Level.LevelManager.Init'}
        try:
            with self.assertRaisesRegex(ValueError, 'cloud callers of VerifyReceipt missing'):
                triggers.probe(self.source)
        finally:
            triggers.CLOUD_CALLERS['VerifyReceipt'] = original

    def test_changed_caller_expectation_is_rejected(self):
        original = triggers.EXPECTED_CALLERS['SaveProgress']
        triggers.EXPECTED_CALLERS['SaveProgress'] = original - {'PWC.Multiplayer.MPManager.TrySaveCurrentSceneAndGetSceneData'}
        try:
            with self.assertRaisesRegex(ValueError, 'callers of SaveProgress changed'):
                triggers.probe(self.source)
        finally:
            triggers.EXPECTED_CALLERS['SaveProgress'] = original

    def test_missing_key_is_rejected(self):
        method = 'PWC.Level.LevelAvatarData.Save'
        original = triggers.KEYS[method]
        triggers.KEYS[method] = ['LevelCharacterData_DoesNotExist']
        try:
            with self.assertRaisesRegex(ValueError, 'not in window'):
                triggers.probe(self.source)
        finally:
            triggers.KEYS[method] = original


if __name__ == '__main__':
    unittest.main()
