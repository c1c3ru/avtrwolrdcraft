"""Pins the contextual-animation handler inventory on the real dump (skipped when the dump is absent)."""
import os
import unittest
from pathlib import Path

import recon_ca_families as families

DUMP = Path(os.environ.get('RECON_DUMP_ROOT') or families.DEFAULT_DUMP)


@unittest.skipUnless(DUMP.is_dir(), 'dump not available (set RECON_DUMP_ROOT)')
class CaFamiliesTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.report = families.build(DUMP)

    def test_counts(self):
        self.assertEqual((self.report['handlers'], len(self.report['direct_children'])), (798, 51))

    def test_known_specialised_handlers_are_in_the_closure(self):
        classes = self.report['classes']
        for name in ('LevelCAPetOnToddlerHandlerBase', 'LevelCAPairAnimalNearDogHandlerBase', 'LevelCAWindsurfDropAreaHandler',
                     'LevelCAConductorDropAreaHandler', 'LevelCAPenaltyKickDropAreaHandler'):
            self.assertIn(name, classes, name)

    def test_closure_is_transitive_not_just_direct_children(self):
        direct = set(self.report['direct_children'])
        self.assertGreater(self.report['handlers'], len(direct))
        self.assertIn('LevelCAHandlerBase', {b for c in self.report['classes'].values() for b in c['bases']})


if __name__ == '__main__':
    unittest.main()
