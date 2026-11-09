import copy
import json
from pathlib import Path
import tempfile
import unittest

import recon_t025_readiness as audit


class ReadinessTests(unittest.TestCase):
    def setUp(self):
        self.methods=[dict(image='Assembly-CSharp.dll',token='0x06000001',declaring_type='A',name='F',
                           parameter_count=0,method_definition_index=0,vaddr='0x1000'),
                      dict(image='Assembly-CSharp.dll',token='0x06000002',declaring_type='A',name='G',
                           parameter_count=0,method_definition_index=1,vaddr=None)]
        self.queue=dict(revision=1,tasks=[dict(id='T022',state='pending'),
                        dict(id='T025',state='pending',dependencies=['T022']),
                        dict(id='T025/F',parent_id='T025',state='ready',scope=dict(method_identity=self.methods[0]))])

    def test_inventory_counts_nulls_and_missing_children(self):
        ledger,r=audit.reconcile(self.methods,self.queue)
        self.assertEqual(r['summary']['methods_without_children'],1)
        self.assertEqual(r['summary']['indexed_null_pointers'],1)
        self.assertFalse(r['can_close_t025'])
        self.assertIn('not_classified_as_abstract',ledger[1]['address_status'])

    def test_done_states_do_not_certify_semantics(self):
        q=copy.deepcopy(self.queue)
        q['tasks'][0]['state']='done'
        q['tasks'][2]['state']='done'
        _,r=audit.reconcile(self.methods[:1],q)
        self.assertFalse(r['can_close_t025'])
        self.assertEqual(r['summary']['methods_without_children'],0)
        self.assertIn('semantic',r['blockers'][-1])

    def test_wrong_image_not_matched_by_token(self):
        q=copy.deepcopy(self.queue)
        q['tasks'][2]['scope']['method_identity']['image']='Other.dll'
        _,r=audit.reconcile(self.methods,q)
        self.assertEqual(r['unmatched_children'],['T025/F'])
        self.assertEqual(r['summary']['methods_without_children'],2)

    def test_duplicate_identity_rejected(self):
        with self.assertRaisesRegex(ValueError,'duplicate'):
            audit.reconcile(self.methods+self.methods,self.queue)

    def test_registry_snapshot_and_queue_unchanged(self):
        with tempfile.TemporaryDirectory() as tmp:
            root=Path(tmp)
            queue=root/'reports/recon/tasks.json'
            index=root/'out/recon/il2cpp/assembly_csharp_methods.jsonl'
            queue.parent.mkdir(parents=True);index.parent.mkdir(parents=True)
            queue.write_text(json.dumps(self.queue))
            index.write_text(''.join(json.dumps(m)+'\n' for m in self.methods))
            before=queue.read_bytes()
            report=root/'reports/recon/audit.json'
            r=audit.run(root,report,root/'out/recon/registry.jsonl')
            self.assertEqual(queue.read_bytes(),before)
            self.assertEqual(r['inputs'][0]['sha256'],audit.nav.sha(before))
            registry=root/r['registry']['path']
            self.assertEqual(r['registry']['sha256'],audit.nav.sha(registry.read_bytes()))
            self.assertEqual(json.loads(report.read_text())['registry'],r['registry'])

if __name__=='__main__':unittest.main()
