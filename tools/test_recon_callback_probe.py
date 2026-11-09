"""Checks probe identity and rejection of a stale symbol cache."""
import json
from pathlib import Path
import tempfile
import unittest

import recon_callback_probe as callback


class CallbackProbeTests(unittest.TestCase):
    source = callback.nav.ROOT / 'out/recon/il2cpp'

    def test_original_callback_has_home_guard_and_local_load(self):
        report = callback.probe(self.source)
        self.assertEqual(report['scene_guard_literal']['literal'], 'Home')
        calls = {row['site']: row for row in report['control_encodings']}
        self.assertEqual(calls['0x2073590']['metadata_targets'][0]['name'], 'LoadSceneImplement')
        self.assertEqual(calls['0x2073504']['target'], 0x2073578)

    def test_multiplayer_guard_chain_names_mpmanager_statics(self):
        guard = callback.probe(self.source)['multiplayer_guard']
        self.assertEqual(guard['static_class'], 'PWC.Multiplayer.MPManager')
        self.assertEqual(guard['static_flag']['offset'], '0x0')
        self.assertEqual(guard['static_instance']['offset'], '0x38')
        self.assertEqual(guard['host_only_call']['metadata_targets'][0]['name'], 'IsHostAndOnlyPlayer')

    def test_multiplayer_path_sends_request_and_never_loads_locally(self):
        sequence = callback.probe(self.source)['multiplayer_sequence']
        names = [call['name'] for call in sequence['calls']]
        self.assertEqual(names, callback.MP_CALLS)
        self.assertLess(names.index('MPManager.SendWaitForPlayerForSceneChangeRequest'),
                        names.index('MPUtils.DestroyAllGameObjectsInLoadedScenes'))
        self.assertFalse(sequence['loads_scene_locally'])

    def test_wrong_static_class_is_rejected(self):
        original = callback.typedef_name
        callback.typedef_name = lambda meta, usage: 'PWC.Other.Manager'
        try:
            with self.assertRaisesRegex(ValueError, 'static class is not MPManager'):
                callback.probe(self.source)
        finally:
            callback.typedef_name = original

    def test_corrupted_local_load_symbol_is_rejected(self):
        with tempfile.TemporaryDirectory() as temporary:
            source = Path(temporary)
            for name in ('libil2cpp.so', 'global-metadata.dat'):
                (source / name).symlink_to(self.source / name)
            rows = [json.loads(line) for line in
                    (self.source / 'metadata_methods.jsonl').read_text().splitlines()]
            modified = 0
            for row in rows:
                if row['vaddr'] == '0x2072cc8':
                    row['name'] = 'InventedSceneLoader'
                    modified += 1
            self.assertEqual(modified, 1)
            (source / 'metadata_methods.jsonl').write_text(
                ''.join(json.dumps(row) + '\n' for row in rows))
            with self.assertRaisesRegex(ValueError, 'cached symbol metadata mismatch'):
                callback.probe(source)


if __name__ == '__main__':
    unittest.main()
