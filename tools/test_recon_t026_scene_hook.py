"""Negative guards for conditional loading-manager sceneLoaded hook evidence."""
import copy
from pathlib import Path
import struct
import unittest

import recon_t026_scene_hook as probe


class SceneHookTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.source=probe.nav.ROOT/'out/recon/il2cpp'
        cls.binary=(cls.source/'libil2cpp.so').read_bytes();cls.metadata=(cls.source/'global-metadata.dat').read_bytes()
        probe.nav.verify_pair(cls.binary,cls.metadata)
        cls.elf=probe.nav.Elf(cls.binary);cls.meta=probe.nav.Metadata(cls.metadata);cls.index=cls.source/'metadata_methods.jsonl'
        cls.result=probe.verify(cls.elf,cls.meta,cls.index)

    def mutate(self,address,value):
        elf=copy.copy(self.elf);elf.data=bytearray(self.binary)
        struct.pack_into('<I',elf.data,elf.offset(address,4),value);return elf

    def test_paired_conditional_slot4_hook(self):
        r=self.result
        self.assertEqual([e['operation'] for e in r['edges']],['add','remove'])
        self.assertEqual(r['conditional_virtual_slot']['method_definition_index'],24515)
        self.assertEqual([e['event_accessor']['token'] for e in r['edges']],['0x060009c2','0x060009c3'])
        self.assertEqual(r['canonical_delegate_constructor']['class_arguments'][1]['type'],'System.Int32Enum')
        self.assertTrue(any('Runtime receiver' in p for p in r['preconditions']))

    def test_each_wrong_accessor_target_rejected(self):
        for s in probe.SPECS:
            with self.subTest(operation=s['operation']):
                with self.assertRaisesRegex(ValueError,'accessor branch mismatch'):
                    probe.verify(self.mutate(s['site'],probe.nav.word(self.elf,s['site'])^1),self.meta,self.index)

    def test_wrong_constructor_target_rejected(self):
        site=probe.SPECS[0]['ctor']
        with self.assertRaisesRegex(ValueError,'constructor branch mismatch'):
            probe.verify(self.mutate(site,probe.nav.word(self.elf,site)^1),self.meta,self.index)

    def test_lost_delegate_target_this_rejected(self):
        for site in [0x20fe260,0x20fe67c]:
            with self.subTest(site=hex(site)):
                with self.assertRaises(ValueError):
                    probe.verify(self.mutate(site,0xaa1f03e1),self.meta,self.index)

    def test_other_virtual_slot_rejected(self):
        for site in [0x20fe264,0x20fe684]:
            with self.subTest(site=hex(site)):
                with self.assertRaises(ValueError):
                    probe.verify(self.mutate(site,probe.nav.word(self.elf,site)+(2<<10)),self.meta,self.index)

    def test_metadata_slot_handler_mutation_rejected(self):
        meta=copy.copy(self.meta);meta.data=bytearray(self.metadata)
        offset=self.result['conditional_virtual_slot']['encoded_file_offset']
        word=struct.unpack_from('<I',meta.data,offset)[0];struct.pack_into('<I',meta.data,offset,word^2)
        with self.assertRaisesRegex(ValueError,'virtual metadata method target mismatch'):
            probe.verify(self.elf,meta,self.index)

    def test_canonical_constructor_pointer_mutation_rejected(self):
        elf=copy.copy(self.elf);elf.relocations=dict(self.elf.relocations)
        slot=int(self.result['canonical_delegate_constructor']['pointer_slot'],16);elf.relocations[slot]+=4
        with self.assertRaisesRegex(ValueError,'constructor pointer mismatch'):
            probe.verify(elf,self.meta,self.index)

    def test_canonical_enum_identity_mutation_rejected(self):
        address=int(self.result['canonical_delegate_constructor']['class_arguments'][1]['address'],16)
        with self.assertRaisesRegex(ValueError,'canonical argument mismatch'):
            probe.verify(self.mutate(address,11802),self.meta,self.index)


if __name__=='__main__':unittest.main()
