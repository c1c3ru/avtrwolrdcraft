"""Mutation guards for condition coroutine transitions, timing and lifecycle."""
import copy
import struct
import unittest

import recon_t026_condition as probe


class ConditionCoroutineTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        source=probe.nav.ROOT/'out/recon/il2cpp';cls.binary=(source/'libil2cpp.so').read_bytes();cls.metadata=(source/'global-metadata.dat').read_bytes()
        probe.nav.verify_pair(cls.binary,cls.metadata);cls.elf=probe.nav.Elf(cls.binary);cls.meta=probe.nav.Metadata(cls.metadata);cls.index=source/'metadata_methods.jsonl'
        cls.result=probe.verify(cls.elf,cls.meta,cls.index)

    def mutate(self,site,word):
        elf=copy.copy(self.elf);elf.data=bytearray(self.binary);struct.pack_into('<I',elf.data,elf.offset(site,4),word);return elf

    def rejected(self,site,word):
        with self.assertRaises(ValueError):probe.verify(self.mutate(site,word),self.meta,self.index)

    def test_eight_methods_nine_fields_and_exact_duration(self):
        self.assertEqual(len(self.result['methods']),8);self.assertEqual(len(self.result['fields']),9)
        self.assertEqual(self.result['threshold']['bits'],'0x3dcccccd')
        self.assertEqual(self.result['fields'][0]['offset'],16);self.assertEqual(self.result['fields'][-1]['offset'],72)
        self.assertFalse(any(m['complete_body_proven'] for m in self.result['methods']))

    def test_changed_predicate_generic_argument_rejected(self):self.rejected(0x437bf98,6710)

    def test_changed_state_resume_branch_rejected(self):self.rejected(0x1cbee78,probe.nav.word(self.elf,0x1cbee78)^1)
    def test_changed_timeout_polarity_rejected(self):self.rejected(0x1cbef48,probe.nav.word(self.elf,0x1cbef48)^1)
    def test_changed_nonpositive_timeout_polarity_rejected(self):self.rejected(0x1cbef40,probe.nav.word(self.elf,0x1cbef40)^1)
    def test_changed_predicate_return_bit_rejected(self):self.rejected(0x1cbef14,probe.nav.word(self.elf,0x1cbef14)^(1<<19))
    def test_changed_timer_increment_rejected(self):self.rejected(0x1cbef34,0x1e223821)
    def test_changed_threshold_rejected(self):self.rejected(0xb2fdfc,0x3e4ccccd)
    def test_changed_dispose_rejected(self):self.rejected(0x1cbee30,0xd503201f)
    def test_changed_current_offset_rejected(self):self.rejected(0x1cbef94,0xf9401000)
    def test_changed_initial_factory_state_rejected(self):self.rejected(0x1cb81ac,0x52800021)
    def test_changed_wait_constructor_target_rejected(self):self.rejected(0x1cbeee0,probe.nav.word(self.elf,0x1cbeee0)^1)
    def test_changed_registered_field_offset_rejected(self):self.rejected(0xb59b68+8*4,76)
    def test_changed_reset_throw_boundary_rejected(self):self.rejected(0x1cbefd0,probe.nav.word(self.elf,0x1cbefd0)^1)
    def test_changed_timeout_callback_null_guard_rejected(self):self.rejected(0x1cbef50,probe.nav.word(self.elf,0x1cbef50)^(1<<24))

if __name__=='__main__':unittest.main()
