"""Pins the persistent-data schema catalog on the real dump (skipped when the dump is absent)."""
import os
import unittest
from pathlib import Path

import recon_pd_schema as schema

DUMP = Path(os.environ.get('RECON_DUMP_ROOT') or schema.DEFAULT_DUMP)


@unittest.skipUnless(DUMP.is_dir(), 'dump not available (set RECON_DUMP_ROOT)')
class PdSchemaTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.report = schema.build(DUMP)
        cls.types = {t['name']: t for t in cls.report['types']}
        cls.extra = {t['name']: t for t in cls.report['persisted_outside_pd']}

    def fields(self, table, name):
        return [(f['name'], f['type']) for f in table[name]['fields']]

    def test_counts(self):
        counts = self.report['counts']
        self.assertEqual((counts['types'], counts['payload_pd_types'], counts['payload_fields']), (185, 129, 220))
        self.assertEqual(len(self.report['implements_has_persistent_data']), 269)

    def test_level_item_payload_matches_the_documented_contract(self):
        self.assertEqual(self.fields(self.types, 'LevelItemPD'), [
            ('parent', 'string'), ('position', 'Vector2'), ('isMoving', 'bool'), ('itemOnAvatarType', 'ItemOnAvatarType'),
            ('itemOnCharacterType', 'ItemOnAvatarType'), ('isFlipped', 'bool')])
        self.assertEqual(self.fields(self.types, 'IntArrayPD'), [('values', 'Int32[]')])

    def test_items_stores_and_appearance_are_persisted_outside_pd(self):
        self.assertEqual(self.fields(self.extra, 'StoreState')[0], ('claimedItems', 'List<String>'))
        self.assertEqual([n for n, _ in self.fields(self.extra, 'Item')],
                         ['sceneGuid', 'prefabGuid', 'sceneName', 'position', 'pdSnapshot'])
        self.assertIn(('BuildNumber', 'int'), self.fields(self.extra, 'AvatarSpineData'))

    def test_static_and_const_members_are_not_fields(self):
        names = {f['name'] for t in self.report['types'] for f in t['fields']}
        self.assertFalse({n for n in names if n.isupper() and len(n) > 6})


if __name__ == '__main__':
    unittest.main()
