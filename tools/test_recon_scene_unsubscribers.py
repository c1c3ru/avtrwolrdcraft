"""Mutations must reject wrong handler, target and delegate argument flow."""
import copy
import struct
import unittest

import recon_scene_unsubscribers as probe


class SceneUnsubscribersTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.source = probe.nav.ROOT/'out/recon/il2cpp'
        cls.binary = (cls.source/'libil2cpp.so').read_bytes()
        cls.metadata = (cls.source/'global-metadata.dat').read_bytes()
        probe.nav.verify_pair(cls.binary, cls.metadata)
        cls.elf = probe.nav.Elf(cls.binary)
        cls.meta = probe.nav.Metadata(cls.metadata)
        cls.index = cls.source/'metadata_methods.jsonl'
        cls.edges, cls.windows = probe.verify_edges(cls.elf, cls.meta, cls.index)

    def mutate(self, site, value):
        elf = copy.copy(self.elf)
        elf.data = bytearray(self.binary)
        struct.pack_into('<I', elf.data, elf.offset(site,4), value)
        return elf

    def test_four_pairs_and_three_windows(self):
        self.assertEqual(len(self.edges),4)
        self.assertEqual(len(self.windows),3)
        self.assertEqual([e['handler']['token'] for e in self.edges],
                         ['0x06005601','0x06006e44','0x0600849c','0x0600849d'])
        self.assertTrue(all(e['caller']['name']=='OnDestroy' for e in self.edges))

    def test_each_remove_target_mutation_rejected(self):
        for spec in probe.SPECS:
            with self.subTest(pair=spec['pair']):
                site=spec['site']
                elf=self.mutate(site,probe.nav.word(self.elf,site)^1)
                with self.assertRaisesRegex(ValueError,'branch mismatch'):
                    probe.verify_edges(elf,self.meta,self.index)

    def test_wrong_delegate_target_object_rejected(self):
        for site in [0x2069578,0x21e0800,0x23111d4,0x2311214]:
            with self.subTest(site=hex(site)):
                with self.assertRaises(ValueError):
                    probe.verify_edges(self.mutate(site,0xaa1f03e1),self.meta,self.index)

    def test_other_handler_methodinfo_rejected(self):
        # Redirect only OnDestroy's LDR to the adjacent GOT slot: Awake remains valid.
        for spec in probe.SPECS:
            site=spec['ref'][1]
            with self.subTest(pair=spec['pair']):
                with self.assertRaises(ValueError):
                    probe.verify_edges(self.mutate(site,probe.nav.word(self.elf,site)+(1<<10)),self.meta,self.index)

    def test_wrong_constructor_rejected(self):
        spec=probe.SPECS[0]
        site=spec['ctor']
        with self.assertRaisesRegex(ValueError,'branch mismatch'):
            probe.verify_edges(self.mutate(site,probe.nav.word(self.elf,site)^1),self.meta,self.index)


if __name__=='__main__':
    unittest.main()
