"""Mutation tests validate shipped evidence, not Unity execution or timing."""
import copy
import struct
import unittest
import recon_t026_next_frame as probe

class NextFrameTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.source=probe.nav.ROOT/'out/recon/il2cpp'
        cls.binary=(cls.source/'libil2cpp.so').read_bytes()
        cls.meta=probe.nav.Metadata((cls.source/'global-metadata.dat').read_bytes())
        probe.nav.verify_pair(cls.binary,cls.meta.data)
        cls.elf=probe.nav.Elf(cls.binary);cls.index=cls.source/'metadata_methods.jsonl'
        cls.result=probe.verify(cls.elf,cls.meta,cls.index)

    def changed(self,pc,word):
        e=copy.copy(self.elf);e.data=bytearray(self.binary)
        struct.pack_into('<I',e.data,e.offset(pc,4),word)
        return e

    def test_identities_fields_and_no_complete_body_claim(self):
        self.assertEqual(len(self.result['methods']),8)
        self.assertEqual([f['offset'] for f in self.result['fields']],[16,24,32])
        self.assertEqual(self.result['reset_exception_type']['owner'],'System.NotSupportedException')
        self.assertFalse(any(w['complete_body_proven'] for w in self.result['inspection_windows'].values()))

    def test_dispose_state_mutation_rejected(self):
        with self.assertRaises(ValueError):
            probe.verify(self.changed(0x1cbed50,0xb900101f),self.meta,self.index)

    def test_callback_null_guard_reversed_rejected(self):
        w=probe.nav.word(self.elf,0x1cbed9c)
        with self.assertRaises(ValueError):
            probe.verify(self.changed(0x1cbed9c,w^(1<<24)),self.meta,self.index)

    def test_resume_state_before_callback_write_rejected(self):
        with self.assertRaises(ValueError):
            probe.verify(self.changed(0x1cbed98,0xd503201f),self.meta,self.index)

    def test_current_reference_offset_rejected(self):
        with self.assertRaises(ValueError):
            probe.verify(self.changed(0x1cbedc0,0xf9401000),self.meta,self.index)

    def test_factory_initial_state_changed_rejected(self):
        with self.assertRaises(ValueError):
            probe.verify(self.changed(0x1cb8434,0x52800021),self.meta,self.index)

    def test_reset_exception_constructor_changed_rejected(self):
        pc=0x1cbede4
        with self.assertRaisesRegex(ValueError,'branch mismatch'):
            probe.verify(self.changed(pc,probe.nav.word(self.elf,pc)^1),self.meta,self.index)

    def test_registered_state_offset_changed_rejected(self):
        f=self.result['fields'][0]
        with self.assertRaisesRegex(ValueError,'field metadata/offset'):
            probe.verify(self.changed(int(f['offset_address'],16),20),self.meta,self.index)

if __name__=='__main__':unittest.main()
