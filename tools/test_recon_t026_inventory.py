"""Guard metadata-led async discovery, scope retention and raw owner/interface joins."""
import copy
import json
from pathlib import Path
import struct
import unittest

import recon_t026_inventory as inventory


class InventoryTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        source=inventory.nav.ROOT/'out/recon/il2cpp'
        cls.binary=(source/'libil2cpp.so').read_bytes();cls.metadata=(source/'global-metadata.dat').read_bytes()
        inventory.nav.verify_pair(cls.binary,cls.metadata)
        cls.elf=inventory.nav.Elf(cls.binary);cls.meta=inventory.nav.Metadata(cls.metadata)
        cls.index=source/'metadata_methods.jsonl'
        cls.historical=[json.loads(l) for l in (inventory.nav.ROOT/'out/recon/tasks/T032/coroutines.jsonl').read_bytes().splitlines()]
        cls.result=inventory.build(cls.elf,cls.meta,cls.index,cls.historical)

    def test_interfaces_correct_historical_absence_of_async_claim(self):
        r=self.result;machines=r['machines']
        self.assertEqual(len(machines),449)
        self.assertEqual(sum(m['kind']=='async_metadata_interface' for m in machines),62)
        self.assertEqual(sum(m['kind']=='enumerator_metadata_interface' for m in machines),387)
        self.assertEqual(sum(m['historical_record'] is None for m in machines),12)
        self.assertFalse(r['historical_unmatched']);self.assertFalse(r['interface_decode_unknowns'])
        self.assertEqual(sum(m['historical_record'] is not None and m['kind']=='async_metadata_interface' for m in machines),57)

    def test_new_nested_local_function_not_discarded_by_name_shape(self):
        m=next(m for m in self.result['machines'] if m['type_definition_index']==2424)
        self.assertEqual(m['owner'],'Game.Level.LevelHelicopterCloudsSpawner')
        self.assertIsNone(m['historical_record'])
        self.assertEqual(m['scope_disposition'],'required_additional_game_candidate')
        self.assertTrue(m['name'].startswith('<<LoadCloudSprites>g__'))

    def test_scope_never_excludes_unlisted_game_world_or_unknown(self):
        self.assertEqual(inventory.scope_disposition('Game.World.LevelWeatherInteractionHandler',1)[0],'required_additional_game_candidate')
        self.assertEqual(inventory.scope_disposition('PazuCore.Utils',629)[0],'required_concrete_helper')
        self.assertEqual(inventory.scope_disposition('PazuCore.UnclassifiedHelper',1)[0],'conditional_dependency_pending')
        self.assertEqual(inventory.scope_disposition('SomeOtherOwner',1)[0],'unresolved_scope_pending')
        self.assertEqual(inventory.scope_disposition('PWC.QA.NewGeneratedMachine',1)[0],'excluded_reimplementation_scope_only')
        self.assertEqual(inventory.scope_disposition('LobbyHelloWorld',1)[0],'excluded_reimplementation_scope_only')

    def test_all_plans_pending_with_true_prerequisites(self):
        tasks=inventory.planning_specs(self.result['machines'],[])['tasks']
        self.assertEqual(len(tasks),449);self.assertEqual(len({t['id'] for t in tasks}),449)
        self.assertTrue(all(t['state']=='pending' and 'T024' in t['dependencies'] and 'T025' in t['dependencies'] for t in tasks))
        self.assertIn('T026/STATE_MACHINE/execute-next-frame',{t['id'] for t in tasks})

    def test_bad_declaring_owner_does_not_fall_back_to_regex_name(self):
        meta=copy.copy(self.meta);meta.data=bytearray(self.metadata)
        offset=meta.tables['types']['offset']+629*88+12
        struct.pack_into('<I',meta.data,offset,0xfffffffe)
        with self.assertRaisesRegex(ValueError,'declaring owner ambiguous'):
            inventory.build(self.elf,meta,self.index,self.historical)

    def test_event_accessor_indices_are_relative_and_owned(self):
        e=next(e for e in self.result['events'] if e['declaring_type']=='ListPositionCtrl' and e['name']=='OnInitAction')
        self.assertEqual([a['method']['declaring_type_index'] for a in e['accessors']],[138,138])
        self.assertEqual([a['method']['method_definition_index'] for a in e['accessors']],[1338,1339])
        self.assertTrue(all(a['method']['name'].startswith(('add_','remove_')) for a in e['accessors']))

    def test_historical169_retained_but_not_total_scope(self):
        machines=self.result['machines']
        self.assertEqual(sum(m['scope_disposition']=='required_historical_169' for m in machines),169)
        self.assertGreater(sum(m['scope_disposition'].startswith('required_') for m in machines),170)
        self.assertTrue(all(m['semantic_completion'] is False for m in machines))


    def test_generated_child_imports_through_real_queue_schema(self):
        import json,tempfile
        from pathlib import Path
        from recon_queue import Queue,digest
        from test_recon_queue import task
        with tempfile.TemporaryDirectory() as tmp:
            root=Path(tmp)
            (root/'plan.md').write_text('exact fixture scope')
            (root/'input.txt').write_text('pinned fixture')
            seed=dict(schema_version=1,kind='planning_seed_not_live_execution_state',source_doc='plan.md',
                      source_doc_sha256=digest(root/'plan.md'),tasks=[task(t) for t in ['T026','T022','T023','T024','T025']])
            path=root/'seed.json';path.write_text(json.dumps(seed))
            queue=Queue(root/'live/tasks.json');queue.init(path,root)
            refs=[dict(path='input.txt',sha256=digest(root/'input.txt'))]
            manifest=inventory.planning_specs(self.result['machines'][:1],refs)
            path=root/'children.json';path.write_text(json.dumps(manifest))
            result=queue.import_children(path,'fixture-coordinator','Real-schema regression for generated lifecycle planning')
            self.assertEqual(result['child_ids'],[manifest['tasks'][0]['id']])


if __name__=='__main__':unittest.main()
