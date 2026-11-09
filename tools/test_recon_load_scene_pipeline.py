"""Pins the scene-change pipeline proof and rejects tampered inputs."""
import json
import os
from pathlib import Path
import tempfile
import unittest

import recon_load_scene_pipeline as pipeline


SOURCE = Path(os.environ.get('RECON_IL2CPP_ROOT') or pipeline.nav.ROOT / 'out/recon/il2cpp')


@unittest.skipUnless(SOURCE.is_dir(), 'IL2CPP cache unavailable (set RECON_IL2CPP_ROOT)')
class PipelineTests(unittest.TestCase):
    source = SOURCE

    @classmethod
    def setUpClass(cls):
        cls.report = pipeline.probe(cls.source)

    def test_load_scene_guard_state_and_delegate(self):
        load = self.report['LoadScene']
        self.assertEqual(load['reentrancy_guard']['field'], 'IsSceneChangingInProgress')
        self.assertIn('Scene loading is already in progress!', load['reentrancy_guard']['on_true'])
        self.assertEqual(load['cache_clears_in_order'], pipeline.CLEAR_CALLS)
        self.assertEqual(load['delegate_method_token'], '0x0600570f')
        self.assertTrue(load['transition'].startswith('LoadingScreenManager.Instance.StartSceneTransition'))

    def test_implement_clears_ownership_only_in_multiplayer_then_loads_async(self):
        implement = self.report['LoadSceneImplement']
        self.assertEqual(implement['if_multiplayer'], 'MPOwnership.Clear()')
        self.assertIn('SceneManager.LoadSceneAsync(sceneName)', implement['then'])

    def test_active_scene_changed_resets_all_three_fields(self):
        resets = self.report['OnActiveSceneChanged']['resets']
        self.assertEqual(sorted(resets), sorted([
            'IsSceneChangingInProgress = false', 'Multiplayer_LoadingSceneNameInProgress = null',
            'CurrentlyLoadingSceneName = null']))

    def test_renamed_symbols_are_rejected_by_the_index_check(self):
        for vaddr in ('0x217a958', '0x20d7e78'):  # a cache-clear callee and MPOwnership.Clear
            self._with_modified_index(vaddr, 'InventedClear', 'cached symbol metadata mismatch')

    def _with_modified_index(self, vaddr, new_name, pattern):
        with tempfile.TemporaryDirectory() as temporary:
            source = Path(temporary)
            for name in ('libil2cpp.so', 'global-metadata.dat'):
                (source / name).symlink_to(self.source / name)
            rows = [json.loads(line) for line in (self.source / 'metadata_methods.jsonl').read_text().splitlines()]
            hits = [row for row in rows if row['vaddr'] == vaddr]
            self.assertEqual(len(hits), 1)
            hits[0]['name'] = new_name
            (source / 'metadata_methods.jsonl').write_text(''.join(json.dumps(row) + '\n' for row in rows))
            with self.assertRaisesRegex(ValueError, pattern):
                pipeline.probe(source)


if __name__ == '__main__':
    unittest.main()
