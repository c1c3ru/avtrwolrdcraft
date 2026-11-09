import copy
import struct
import unittest
import recon_t026_scheduler as probe

class SchedulerTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        source=probe.nav.ROOT/'out/recon/il2cpp'
        cls.binary=(source/'libil2cpp.so').read_bytes();cls.meta=probe.nav.Metadata((source/'global-metadata.dat').read_bytes())
        probe.nav.verify_pair(cls.binary,cls.meta.data)
        cls.elf=probe.nav.Elf(cls.binary);cls.index=source/'metadata_methods.jsonl'
        cls.result=probe.verify(cls.elf,cls.meta,cls.index)

    def change(self,pc,word):
        elf=copy.copy(self.elf);elf.data=bytearray(self.binary)
        struct.pack_into('<I',elf.data,elf.offset(pc,4),word);return elf

    def test_wrappers_and_actual_null_exception_identity(self):
        self.assertEqual(len(self.result['methods']),8)
        self.assertEqual(len(self.result['icall_resolver_arguments']),11)
        self.assertEqual(self.result['exception_constructors'][0]['method']['declaring_type'],'System.NullReferenceException')
        self.assertFalse(any(w['complete_body_proven'] for w in self.result['inspection_windows'].values()))

    def test_wrong_icall_name_rejected(self):
        pc=0xb50f93
        with self.assertRaisesRegex(ValueError,'exact name'):
            probe.verify(self.change(pc,probe.nav.word(self.elf,pc)^1),self.meta,self.index)

    def test_wrong_resolver_target_rejected(self):
        pc=0x3ccc118
        with self.assertRaisesRegex(ValueError,'resolver target'):
            probe.verify(self.change(pc,probe.nav.word(self.elf,pc)^1),self.meta,self.index)

    def test_null_guard_reversed_rejected(self):
        pc=0x3ccc0cc
        with self.assertRaisesRegex(ValueError,'null guard'):
            probe.verify(self.change(pc,probe.nav.word(self.elf,pc)^(1<<24)),self.meta,self.index)

    def test_host_predicate_reversed_rejected(self):
        pc=0x3ccc234
        with self.assertRaisesRegex(ValueError,'predicate guard'):
            probe.verify(self.change(pc,probe.nav.word(self.elf,pc)^(1<<24)),self.meta,self.index)

    def test_lost_enumerator_argument_rejected(self):
        with self.assertRaises(ValueError):
            probe.verify(self.change(0x3ccc128,0xaa1f03e1),self.meta,self.index)

    def test_changed_exception_type_target_rejected(self):
        pc=0x3ccc164
        with self.assertRaisesRegex(ValueError,'exception ctor'):
            probe.verify(self.change(pc,probe.nav.word(self.elf,pc)^1),self.meta,self.index)

    def test_stop_all_tail_register_rejected(self):
        with self.assertRaises(ValueError):
            probe.verify(self.change(0x3ccc3a8,0xd61f0040),self.meta,self.index)

if __name__=='__main__':unittest.main()
