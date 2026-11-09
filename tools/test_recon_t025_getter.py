import copy
from pathlib import Path
import struct
import tempfile
import unittest

import recon_t025_getter as probe

class GetterTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.source=probe.nav.ROOT/'out/recon/il2cpp'
        cls.binary=(cls.source/'libil2cpp.so').read_bytes()
        cls.meta=probe.nav.Metadata((cls.source/'global-metadata.dat').read_bytes())
        cls.elf=probe.nav.Elf(cls.binary);cls.index=cls.source/'metadata_methods.jsonl'

    def test_reversed_return_selection_rejected(self):
        elf=copy.copy(self.elf);elf.data=bytearray(self.binary)
        pc=0x20732f4
        struct.pack_into('<I',elf.data,elf.offset(pc,4),probe.nav.word(self.elf,pc)^(1<<12))
        with self.assertRaisesRegex(ValueError,'selection'):
            probe.verify(elf,self.meta,self.index)

    def test_regression_no_full_body_claim_after_binding_resolution(self):
        import json
        with tempfile.TemporaryDirectory() as tmp:
            out=Path(tmp)
            result=probe.run(self.source,out)
            self.assertFalse(result['method_body_fully_bounded'])
            self.assertFalse(result['semantic_completion'])
            self.assertEqual(result['exact_generic_identities'],3)
            self.assertEqual(result['reachable_instructions'],53)
            contract=json.loads((out/'method-contract.json').read_text())
            self.assertTrue(contract['availability_generic_bindings'])
            self.assertTrue(contract['unknowns'])
            self.assertFalse(json.loads((out/'control-flow.json').read_text())['complete_body_proven'])

if __name__=='__main__':unittest.main()
