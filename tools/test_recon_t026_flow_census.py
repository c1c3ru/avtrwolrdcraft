import struct
import unittest
import recon_t026_flow_census as probe

class Memory:
    def __init__(self,words):self.data=b''.join(struct.pack('<I',w) for w in words)
    def offset(self,address,size):
        pos=address-0x1000
        if pos<0 or pos+size>len(self.data):raise ValueError('outside fixture')
        return pos

class FlowCensusTests(unittest.TestCase):
    def graph(self,words):return probe.flow(Memory(words),0x1000,0x1000+len(words)*4,lambda _:[])

    def test_branch_does_not_linearize_unreachable_bytes(self):
        r=self.graph([0x14000002,0xd503201f,0xd65f03c0])
        self.assertEqual(r['reachable_addresses'],['0x1000','0x1008'])
        self.assertFalse(r['complete_body_proven'])

    def test_blr_records_unknown_callback_and_conditional_fallthrough(self):
        r=self.graph([0xd63f0120,0xd65f03c0])
        self.assertEqual(r['calls'][0]['kind'],'BLR')
        self.assertIsNone(r['calls'][0]['target'])
        self.assertEqual(r['reachable_instruction_count'],2)
        self.assertIn('assumed',r['calls'][0]['returns'])

    def test_unknown_system_control_not_silently_fallthrough(self):
        r=self.graph([0xd69f03e0,0xd65f03c0]) # ERET is not a normal iterator RET.
        self.assertEqual(r['reachable_instruction_count'],1)
        self.assertEqual(r['instruction_edges'][0]['kind'],'unknown_control')

    def test_trap_stops_local_flow(self):
        r=self.graph([0xd4200000,0xd65f03c0])
        self.assertEqual(r['reachable_instruction_count'],1)
        self.assertEqual(r['instruction_edges'][0]['kind'],'trap_or_supervisor_boundary')

    def test_external_branch_is_explicit_unproven_exit(self):
        r=self.graph([0x14000004])
        self.assertFalse(r['instruction_edges'][0]['inside'])
        self.assertEqual(r['instruction_edges'][0]['target'],'0x1010')
        self.assertFalse(r['exception_edges_recovered'])

class EntryGuardsTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        import json
        src=probe.nav.ROOT/'out/recon/il2cpp'
        cls.elf=probe.nav.Elf((src/'libil2cpp.so').read_bytes())
        cls.meta=probe.nav.Metadata((src/'global-metadata.dat').read_bytes())
        image,methods=cls.meta.image_methods('Assembly-CSharp.dll')
        cls.module=dict(probe.nav.codegen_module(cls.elf,'Assembly-CSharp.dll',len(methods)),type_start=image['type_start'],type_count=image['type_count'])
        rows=[json.loads(l) for l in (probe.nav.ROOT/'out/recon/t026-inventory/machines.jsonl').read_text().splitlines()]
        cls.addressed=next(r for r in rows if r['move_next'].get('vaddr'))
        cls.null=next(r for r in rows if not r['move_next'].get('vaddr'))

    def test_changed_owner_not_accepted_by_token_alone(self):
        import copy
        item=copy.deepcopy(self.addressed);item['type_definition_index']+=1
        with self.assertRaisesRegex(ValueError,'type identity'):
            probe.validate_entry(self.elf,self.meta,self.module,item)

    def test_forged_null_pointer_cannot_skip_native_evidence(self):
        import copy
        item=copy.deepcopy(self.addressed);item['move_next']['vaddr']=None
        with self.assertRaisesRegex(ValueError,'codegen pointer'):
            probe.validate_entry(self.elf,self.meta,self.module,item)

    def test_real_null_pointer_is_preserved(self):
        self.assertEqual(probe.validate_entry(self.elf,self.meta,self.module,self.null),0)

if __name__=='__main__':unittest.main()
