"""Negative guards for exact generic call-site identities, without whole-pair gate."""
import copy
import struct
import unittest

import recon_t025_generics as probe


class T025GenericBindingsTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        source=probe.nav.ROOT/'out/recon/il2cpp'
        cls.binary=(source/'libil2cpp.so').read_bytes()
        cls.metadata=(source/'global-metadata.dat').read_bytes()
        probe.nav.verify_pair(cls.binary,cls.metadata)
        cls.elf=probe.nav.Elf(cls.binary);cls.meta=probe.nav.Metadata(cls.metadata)
        cls.result=probe.verify(cls.elf,cls.meta)

    def changed_word(self,address,word):
        elf=copy.copy(self.elf);elf.data=bytearray(self.binary)
        struct.pack_into('<I',elf.data,elf.offset(address,4),word)
        return elf

    def test_three_exact_requested_string_and_canonical_object_bindings(self):
        self.assertEqual([b['method']['name'] for b in self.result['bindings']],['.ctor','Add','Contains'])
        self.assertTrue(all(b['requested_class_instantiation']['type_name']=='System.String' for b in self.result['bindings']))
        self.assertTrue(all(b['canonical_class_instantiation']['type_name']=='System.Object' for b in self.result['bindings']))
        self.assertEqual(self.result['tables']['generic_method_functions']['count'],75923)

    def test_wrong_methodspec_definition_rejected(self):
        site=0xc15780+90084*12
        with self.assertRaisesRegex(ValueError,'requested MethodSpec mismatch'):
            probe.verify(self.changed_word(site,91268),self.meta)

    def test_wrong_string_argument_rejected(self):
        site=0x4380d08+8
        with self.assertRaisesRegex(ValueError,'type code mismatch'):
            probe.verify(self.changed_word(site,0x1c0000),self.meta)

    def test_same_typecode_but_wrong_metadata_identity_rejected(self):
        elf=self.changed_word(0x4380d08,6710)
        with self.assertRaisesRegex(ValueError,'metadata identity mismatch'):
            probe.verify(elf,self.meta)

    def test_wrong_call_target_rejected(self):
        site=probe.SPECS[0]['site']
        with self.assertRaisesRegex(ValueError,'call target mismatch'):
            probe.verify(self.changed_word(site,probe.nav.word(self.elf,site)^1),self.meta)

    def test_wrong_function_pointer_relocation_rejected(self):
        elf=copy.copy(self.elf);elf.relocations=dict(self.elf.relocations)
        slot=int(self.result['bindings'][0]['function_pointer_slot'],16)
        elf.relocations[slot]+=4
        with self.assertRaisesRegex(ValueError,'pointer target mismatch'):
            probe.verify(elf,self.meta)

    def test_wrong_registration_argument_relocation_rejected(self):
        elf=copy.copy(self.elf);elf.relocations=dict(self.elf.relocations)
        elf.relocations[0x41e1638]+=8
        with self.assertRaisesRegex(ValueError,'registration argument mismatch'):
            probe.verify(elf,self.meta)

    def test_wrong_methodinfo_register_rejected(self):
        site=probe.SPECS[0]['ref'][1]
        w=probe.nav.word(self.elf,site)
        with self.assertRaisesRegex(ValueError,'MethodInfo register mismatch'):
            probe.verify(self.changed_word(site,(w&~31)|9),self.meta)

    def test_wrong_raw_method_token_rejected(self):
        meta=copy.copy(self.meta);meta.data=bytearray(self.metadata)
        site=meta.tables['methods']['offset']+91258*36+24
        struct.pack_into('<I',meta.data,site,0x06000ccc)
        with self.assertRaisesRegex(ValueError,'MethodDef identity mismatch'):
            probe.verify(self.elf,meta)


    def test_clear_bindings_and_static_mp_flag(self):
        self.assertEqual(len(self.result['clear_bindings']),2)
        self.assertTrue(all(b['method']['name']=='Clear' and b['method']['declaring_type']=='System.Collections.Generic.Dictionary`2' for b in self.result['clear_bindings']))
        self.assertEqual(self.result['field_bindings'][0]['field_name'],'<IsMultiplayerGame>k__BackingField')
        self.assertEqual(self.result['field_bindings'][0]['offset'],0)
        self.assertEqual(self.result['field_bindings'][1]['offset'],72)

    def test_clear_methodspec_mutation_rejected(self):
        with self.assertRaisesRegex(ValueError,'Clear MethodSpec mismatch'):
            probe.verify(self.changed_word(0xc15780+86334*12,48547),self.meta)

    def test_mp_flag_offset_mutation_rejected(self):
        with self.assertRaisesRegex(ValueError,'field offset mismatch'):
            probe.verify(self.changed_word(0xb66b10,4),self.meta)

    def test_cache_field_offset_mutation_rejected(self):
        with self.assertRaisesRegex(ValueError,'field offset mismatch'):
            probe.verify(self.changed_word(0xb659a0+10*4,80),self.meta)


if __name__=='__main__':unittest.main()
