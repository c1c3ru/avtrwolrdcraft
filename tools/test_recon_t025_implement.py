import copy
import struct
import unittest

import recon_t025_implement as probe


class ImplementTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.source=probe.nav.ROOT/'out/recon/il2cpp'
        cls.binary=(cls.source/'libil2cpp.so').read_bytes()
        cls.metadata=(cls.source/'global-metadata.dat').read_bytes()
        probe.nav.verify_pair(cls.binary,cls.metadata)
        cls.elf=probe.nav.Elf(cls.binary);cls.meta=probe.nav.Metadata(cls.metadata)
        cls.index=cls.source/'metadata_methods.jsonl'

    def mutate(self,site,value):
        elf=copy.copy(self.elf);elf.data=bytearray(self.binary)
        struct.pack_into('<I',elf.data,elf.offset(site,4),value)
        return elf

    def test_normal_path_all_47_instructions_and_tail(self):
        _,bindings,cfg=probe.verify(self.elf,self.meta,self.index)
        self.assertEqual(cfg['reachable_instructions'],47)
        self.assertFalse(cfg['complete_body_proven'])
        self.assertEqual(bindings['clear']['parameter_count'],0)
        self.assertEqual(bindings['load_scene_async']['parameter_count'],1)
        self.assertEqual([e['target'] for e in cfg['edges'] if not e['inside']],['0x3cdc604'])

    def test_reversed_multiplayer_branch_rejected(self):
        with self.assertRaisesRegex(ValueError,'conditional branch'):
            probe.verify(self.mutate(0x2072d3c,probe.nav.word(self.elf,0x2072d3c)^(1<<24)),self.meta,self.index)

    def test_wrong_clear_target_rejected(self):
        with self.assertRaisesRegex(ValueError,'named call'):
            probe.verify(self.mutate(0x2072d5c,probe.nav.word(self.elf,0x2072d5c)^1),self.meta,self.index)

    def test_lost_scene_name_rejected(self):
        with self.assertRaises(ValueError):
            probe.verify(self.mutate(0x2072d70,0xaa1f03e0),self.meta,self.index)

    def test_wrong_typeinfo_owner_rejected(self):
        # Redirect the MPManager reference to the neighboring GOT slot, leaving codegen intact.
        with self.assertRaises(ValueError):
            probe.verify(self.mutate(0x2072d24,probe.nav.word(self.elf,0x2072d24)+(1<<10)),self.meta,self.index)

if __name__=='__main__':unittest.main()
