"""Pins direct PlayerPrefs writer coverage on the real IL2CPP dump."""
import os
import unittest
from pathlib import Path

import recon_playerprefs_inventory as inventory

SOURCE = Path(os.environ.get('RECON_IL2CPP_ROOT') or inventory.ROOT / 'out/recon/il2cpp')


@unittest.skipUnless(SOURCE.is_dir(), 'IL2CPP cache unavailable (set RECON_IL2CPP_ROOT)')
class PlayerPrefsInventoryTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.report = inventory.build(SOURCE)
        cls.methods = {item['method']: item for item in cls.report['methods']}

    def test_direct_writer_callers(self):
        self.assertEqual(self.report['counts']['writer_callers_by_operation'], {
            'SetInt': 73, 'SetFloat': 4, 'SetString': 50, 'DeleteKey': 27})
        self.assertEqual(self.report['counts']['writer_operations_total'], 127)

    def test_previously_proved_keys_remain_in_inventory(self):
        method = 'PWC.PersistentData.PersistentDataManager.SaveSceneObjectsToKeepOnLoad'
        self.assertTrue(self.methods[method]['audited_in_L03'])
        self.assertIn('PazuWorld_PersistantData_KeepObjectsOnLoad',
                      self.methods[method]['key_literal_candidates'])


if __name__ == '__main__':
    unittest.main()
