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
