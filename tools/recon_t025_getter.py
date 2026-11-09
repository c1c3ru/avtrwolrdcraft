#!/usr/bin/env python3
"""Refresh the bounded world getter dossier; reject unsupported completeness."""
import argparse
import json
from pathlib import Path

import recon_navigation as nav
import recon_scene_subscribers as ident
import recon_t025_generics as generics
from recon_t025_implement import normal_cfg

TASK='T025/METHOD/d417091ede9f01e0'
START,STOP=0x2073238,0x207330c


def verify(elf,meta,index):
    _,resolve=nav.load_index(index,elf,meta)
    method=ident.method(resolve,('Assembly-CSharp.dll','PWC.GameSceneManager','GetCurrentWorldSceneName','0x06005708',START))
    nav.require(method['parameter_count']==0,'getter arity mismatch')
    getter=nav.verify_getter(elf,meta)
    generic=generics.verify(elf,meta)
    cfg=normal_cfg(elf,resolve,START,STOP)
    nav.require(cfg['reachable_instructions']==53,'getter local CFG coverage mismatch')
    exits=[e for e in cfg['edges'] if not e['inside']]
    nav.require(exits==[dict(site='0x2073308',target=None,kind='RET',inside=False)],'unexpected local getter exit')
    expected={0x20732b4:('System.Enum','ToString',0),0x20732cc:('UnityEngine.PlayerPrefs','GetString',2),
              0x20732ec:('PWC.GameSceneManager','IsSceneAvailable',1)}
    for site,(owner,name,arity) in expected.items():
        call=nav.branch(site,nav.word(elf,site));targets=resolve(call['target'])
        nav.require(len(targets)==1 and (targets[0]['declaring_type'],targets[0]['name'],targets[0]['parameter_count'])==(owner,name,arity),
                    'getter named overload mismatch')
    # Binding resolution narrows the unknown, but doesn't certify callee bodies.
    nav.require([b['method']['name'] for b in generic['bindings']]==['.ctor','Add','Contains'],'expected exact generic identities')
    return method,getter,generic,cfg


def run(source,output):
    binary=(source/'libil2cpp.so').read_bytes();metadata=(source/'global-metadata.dat').read_bytes()
    nav.verify_pair(binary,metadata)
    elf,meta=nav.Elf(binary),nav.Metadata(metadata)
    method,getter,generic,cfg=verify(elf,meta,source/'metadata_methods.jsonl')
    offset=elf.offset(START,STOP-START);body=binary[offset:offset+STOP-START]
    nav.require(nav.sha(body)==nav.SLICE_HASHES['GetCurrentWorldSceneName'],'getter inspection bytes mismatch')
    output.mkdir(parents=True,exist_ok=True)
    unknowns=[dict(id='body-regions',question='Full/noncontiguous body and exception regions not proven by bounded CFG.'),
              dict(id='helpers',question='Runtime lazy metadata/class initialization, exceptions and GC behavior.'),
              dict(id='external',question='Enum.ToString and Unity PlayerPrefs GetString behavior beyond the guarded calling convention.'),
              dict(id='collection',question='HashSet requested identities resolved; canonical bodies, sharing correctness, null/errors and cache concurrency remain open.'),
              dict(id='reference',question='No original runtime/emulation/oracle comparison in this task.')]
    contract=dict(schema_version=2,task_id=TASK,scope='Bounded local ARM64 getter contract with exact generic binding annex',
                  status='STATIC_local_contract_not_semantic_certification',semantic_completion=False,method_identity=method,
                  input_pair=dict(native_sha256=nav.sha(binary),metadata_sha256=nav.sha(metadata)),
                  signature_abi='Static zero managed arguments; hidden MethodInfo not consumed; x0 returns managed string reference.',
                  bytes_ranges=dict(inspection_start=hex(START),inspection_exclusive_stop=hex(STOP),bytes=len(body),
                                    sha256=nav.sha(body),complete_body_proven=False),
                  arguments_return=getter['return'],registers='x19 fallback, x20 PlayerPrefs candidate, x0 result; SP temporary enum.',
                  fields_offsets=['Enum temporary type pointer +0, -1 sentinel +8, value1 +16; native class-init +0xe0 guard.'],
                  memory=getter['effects'],effects=getter['effects'],callees_callbacks=cfg['calls'],
                  exceptions='No exception edges recovered; per-callee exceptions/initialization may prevent normal return.',
                  coroutine_async='No coroutine state machine identified in this pinned local body.',
                  state_before_after='Reads saved preference; availability callee may populate static build-scene-name cache.',
                  invalid_inputs='No managed inputs; stored preference validity is passed to availability callee. Null/corrupt/runtime failures open.',
                  termination='Under normal-return calls, both init guard paths reach RET 0x2073308.',
                  pseudocode=getter['pseudocode'],verified_getter=getter,
                  availability_generic_bindings=generic['bindings'],registration=generic['registration'],
                  generic_resolution_limit=generic['unknowns'],unknowns=unknowns,
                  erratum='Supersedes prior method_body_fully_bounded=true: 53 reachable instructions in an inspection window do not prove complete body regions.',
                  provenance=dict(producer_sha256=nav.sha(Path(__file__).read_bytes()),
                                  generic_producer_sha256=nav.sha(Path(generics.__file__).read_bytes()),
                                  cfg_producer_sha256=nav.sha(Path(__import__('recon_t025_implement').__file__).read_bytes()),
                                  navigation_sha256=nav.sha(Path(nav.__file__).read_bytes()),
                                  index_sha256=nav.sha((source/'metadata_methods.jsonl').read_bytes())),game_executed=False)
    nav.atomic_json(output/'method-contract.json',contract);nav.atomic_json(output/'control-flow.json',cfg)
    (output/'unknowns.jsonl').write_text(''.join(json.dumps(u)+'\n' for u in unknowns))
    result=dict(task_id=TASK,status='partial',semantic_completion=False,method_body_fully_bounded=False,
                local_normal_cfg_covered=True,reachable_instructions=53,exact_generic_identities=3,
                contract=str(output/'method-contract.json'),control_flow=str(output/'control-flow.json'),
                erratum=contract['erratum'])
    nav.atomic_json(output/'result.json',result)
    return result

if __name__=='__main__':
    p=argparse.ArgumentParser(description=__doc__)
    p.add_argument('--source',type=Path,default=nav.ROOT/'out/recon/il2cpp')
    p.add_argument('--output',type=Path,default=nav.ROOT/'out/recon/tasks'/TASK)
    a=p.parse_args();print(run(a.source,a.output))
