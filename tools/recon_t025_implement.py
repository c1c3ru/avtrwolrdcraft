#!/usr/bin/env python3
"""Guard LoadSceneImplement's local normal-return CFG and explicit callee gaps.

This is a static dossier, not a recovered whole-program or runtime contract.
"""
import argparse
from pathlib import Path
import struct
import subprocess
import time

import recon_navigation as nav
import recon_scene_subscribers as identity
import recon_t025_generics as generics

START, STOP = 0x2072cc8, 0x2072d84
TASK = 'T025/METHOD/e579655ba8e57adf'
ANCHORS = {0x2072cd8:0xaa0003f3, 0x2072d2c:0xf9400108, 0x2072d30:0xf9405d08,
           0x2072d34:0x39400108, 0x2072d58:0xaa1f03e0, 0x2072d70:0xaa1303e0,
           0x2072d78:0xaa1f03e1, 0x2072d7c:0xf84207fe}
BRANCHES = {0x2072cdc:dict(kind='TBNZ',register=8,bit=0,target=0x2072d00),
            0x2072d08:dict(kind='CBNZ',register=8,width=32,target=0x2072d20),
            0x2072d3c:dict(kind='CBZ',register=8,width=32,target=0x2072d60),
            0x2072d50:dict(kind='CBNZ',register=8,width=32,target=0x2072d58),
            0x2072d68:dict(kind='CBNZ',register=8,width=32,target=0x2072d70)}


def type_usage(elf, meta, adrp, ldr, expected):
    ref = nav.adrp_ldr(elf,adrp,ldr)
    usage = nav.metadata_usage(elf,ref['got_vaddr'])
    nav.require(usage['kind']==1,'expected typeinfo usage')
    table=meta.tables['types']; matches=[]
    for i in range(table['count']):
        row=struct.unpack_from('<16I8H2I',meta.data,table['offset']+i*88)
        if row[2]==usage['index']:
            fullname=(meta.string(row[1])+'.'+meta.string(row[0])).lstrip('.')
            matches.append((i,fullname))
    nav.require(len(matches)==1 and matches[0][1]==expected,'typeinfo owner mismatch')
    return dict(usage=usage,typedef_index=matches[0][0],owner=expected,adrp=hex(adrp),ldr=hex(ldr))


def normal_cfg(elf, resolve, start=START, stop=STOP):
    pending=[start]; seen=set(); edges=[]; calls=[]
    while pending:
        pc=pending.pop()
        if pc in seen: continue
        seen.add(pc)
        op=nav.branch(pc,nav.word(elf,pc))
        successors=[]
        if op:
            kind=op['kind']; target=op.get('target')
            if kind in ('BL','BLR'):
                calls.append(dict(site=hex(pc),kind=kind,target=hex(target) if target is not None else None,
                                  metadata_targets=resolve(target) if target is not None else []))
            if kind in ('B','B.cond','CBZ','CBNZ','TBZ','TBNZ'):
                successors.append((target,'taken'))
            if kind in ('RET','BR'):
                edges.append(dict(site=hex(pc),target=None,kind=kind,inside=False))
            if kind not in ('B','RET','BR'): successors.append((pc+4,'fallthrough'))
        else: successors.append((pc+4,'fallthrough'))
        for target,kind in successors:
            inside=start<=target<stop and target%4==0
            edges.append(dict(site=hex(pc),target=hex(target),kind=kind,inside=inside))
            if inside: pending.append(target)
    return dict(entry=hex(start),inspection_exclusive_stop=hex(stop),
                reachable_instructions=len(seen),instruction_addresses=[hex(p) for p in sorted(seen)],
                edges=edges,calls=calls,
                complete_body_proven=False,exception_edges_recovered=False,
                assumptions=['Calls return normally; exceptions and asynchronous Unity effects remain outside this CFG.',
                             'Inspection range is pinned bytes, not proof of all function regions.'])


def verify(elf,meta,index):
    _,resolve=nav.load_index(index,elf,meta)
    method=identity.method(resolve,('Assembly-CSharp.dll','PWC.GameSceneManager','LoadSceneImplement','0x060056ff',START))
    nav.require(method['parameter_count']==1,'entry arity mismatch')
    for site,word in ANCHORS.items():nav.expect(elf,site,word)
    for site,expected in BRANCHES.items():
        nav.require(nav.branch(site,nav.word(elf,site))==expected,'conditional branch mismatch')
    mp=type_usage(elf,meta,0x2072d20,0x2072d24,'PWC.Multiplayer.MPManager')
    ownership=type_usage(elf,meta,0x2072d40,0x2072d44,'PWC.Multiplayer.MPOwnership')
    unity=type_usage(elf,meta,0x2072d28,0x2072d38,'UnityEngine.SceneManagement.SceneManager')
    clear=identity.method(resolve,('Assembly-CSharp.dll','PWC.Multiplayer.MPOwnership','Clear','0x06005e99',0x20d7e78))
    nav.require(clear['parameter_count']==0,'Clear overload mismatch')
    for site,target,kind in [(0x2072d5c,0x20d7e78,'BL'),(0x2072d80,0x3cdc604,'B')]:
        nav.require(nav.branch(site,nav.word(elf,site))==dict(kind=kind,target=target),'named call target mismatch')
    load=[r for r in resolve(0x3cdc604) if r['declaring_type']=='UnityEngine.SceneManagement.SceneManager' and r['name']=='LoadSceneAsync']
    nav.require(len(load)==1 and load[0]['parameter_count']==1,'LoadSceneAsync overload mismatch')
    generic=generics.verify(elf,meta)
    fields=[f for f in generic['field_bindings'] if f['declaring_type']=='PWC.Multiplayer.MPManager']
    nav.require(len(fields)==1 and fields[0]['offset']==0 and fields[0]['static'], 'multiplayer registered field mismatch')
    cfg=normal_cfg(elf,resolve)
    nav.require(cfg['reachable_instructions']==47,'unexpected local coverage')
    exits=[e for e in cfg['edges'] if not e['inside']]
    nav.require(exits==[dict(site='0x2072d80',target='0x3cdc604',kind='taken',inside=False)],'unexpected local exit')
    return method,dict(mp_manager=mp,ownership=ownership,unity=unity,clear=clear,load_scene_async=load[0],
                            multiplayer_field=fields[0],ownership_clear_generic_bindings=generic['clear_bindings']),cfg


def run(source,output,objdump):
    binary=(source/'libil2cpp.so').read_bytes();metadata=(source/'global-metadata.dat').read_bytes()
    nav.verify_pair(binary,metadata)
    elf,meta=nav.Elf(binary),nav.Metadata(metadata)
    method,bindings,cfg=verify(elf,meta,source/'metadata_methods.jsonl')
    offset=elf.offset(START,STOP-START)
    nav.require(nav.sha(binary[offset:offset+STOP-START])==nav.SLICE_HASHES['LoadSceneImplement'],'whole inspection slice changed')
    output.mkdir(parents=True,exist_ok=True)
    cmd=[str(objdump),'-d',f'--start-address={START}',f'--stop-address={STOP}',str(source/'libil2cpp.so')]
    start=time.monotonic();result=subprocess.run(cmd,capture_output=True,text=True,timeout=30)
    nav.require(result.returncode==0,'LLVM failed: '+result.stderr)
    listing=output/'LoadSceneImplement.asm.txt';listing.write_text(result.stdout)
    unknowns=[dict(id='body-regions',question='Noncontiguous body/exception regions not proven by this bounded local CFG.'),
              dict(id='init',question='Metadata initialization, class initialization, GC and exception behavior of native helpers.'),
              dict(id='clear',question='Full memory, callbacks, exceptions and termination effects of MPOwnership.Clear().'),
              dict(id='unity-load',question='Native engine LoadSceneAsync failure/null/invalid-string semantics and later completion.'),
              dict(id='runtime',question='No original runtime or independent behavioral oracle execution.')]
    declarations=[]
    for relative,required in [(
            'out/cpp2il/DiffableCs/Assembly-CSharp/PWC/GameSceneManager.cs',
            'public static void LoadSceneImplement(string sceneName)'),(
            'out/cpp2il/DiffableCs/Assembly-CSharp/PWC/Multiplayer/MPManager.cs',
            '<IsMultiplayerGame>k__BackingField; //Field offset: 0x0'),(
            'out/cpp2il/DiffableCs/UnityEngine.CoreModule/UnityEngine/SceneManagement/SceneManager.cs',
            'public static AsyncOperation LoadSceneAsync(string sceneName)')]:
        path=nav.ROOT/relative
        content=path.read_bytes()
        nav.require(required in content.decode(), 'source declaration mismatch: '+relative)
        declarations.append(dict(path=relative,sha256=nav.sha(content),declaration=required,
                                 classification='STATIC_extracted_declaration_not_recovered_body'))
    contract=dict(schema_version=1,task_id=TASK,status='STATIC_local_contract_with_explicit_dependencies',
                  semantic_completion=False,method_identity=method,
                  input_pair=dict(native_sha256=nav.sha(binary),metadata_sha256=nav.sha(metadata)),
                  signature_abi=dict(signature='static void LoadSceneImplement(string sceneName)',
                                     entry='AAPCS64 x0=managed string reference; no this; hidden MethodInfo is not consumed in this slice.',
                                     return_value='Managed declaration void; tailcall passes through engine native return register without consuming it.'),
                  bytes_ranges=dict(inspection_start=hex(START),inspection_exclusive_stop=hex(STOP),bytes=STOP-START,
                                    sha256=nav.sha(binary[offset:offset+STOP-START]),complete_body_proven=False),
                  source_declarations=declarations,bindings=bindings,arguments_return='sceneName x0 saved x19, restored to x0 at tail; MethodInfo x1=null.',
                  registers='x19 preserves sceneName, x20 holds metadata class slot; caller-saved registers vary across helpers.',
                  fields_offsets=['MPManager class +0xb8 -> statics; byte at statics+0 tested before optional Clear.',
                                  'Class-init guard reads class+0xe0; lazy-init bytes at 0x44fc6fd and 0x44fa56b.'],
                  memory=['Local stack frame 32 bytes and saved registers.', 'Writes 1 to two metadata initialization guards.',
                          'Reads class/GOT pointers and MPManager statics; transitive callee effects remain unknown.'],
                  effects=['If multiplayer byte is zero, bypass MPOwnership.Clear.',
                           'If nonzero, call parameterless MPOwnership.Clear after guarded class init.',
                           'Both local paths tailcall LoadSceneAsync with the original string reference.'],
                  callees_callbacks=cfg['calls'],exceptions='No exception edges reconstructed; calls may throw or fail to return.',
                  coroutine_async='Not a coroutine body; delegates scheduling/loading to engine async API; completion is external.',
                  state_before_after='No input mutation or scene-state completion established; engine owns asynchronous state.',
                  invalid_inputs='No local null/empty/availability check on sceneName in this inspected path; engine response unknown.',
                  termination='Under normal-return helpers, all local paths reach the one engine tailcall; engine termination unknown.',
                  pseudocode=['ensure lazy metadata/class initializations as guarded',
                              'if MPManager.IsMultiplayerGame: MPOwnership.Clear()',
                              'SceneManager.LoadSceneAsync(sceneName)  // engine contract remains external'],
                  unknowns=unknowns,
                  provenance=dict(producer_sha256=nav.sha(Path(__file__).read_bytes()),
                                  helpers_sha256={Path(m.__file__).name:nav.sha(Path(m.__file__).read_bytes()) for m in (nav,identity,generics)},
                                  index_sha256=nav.sha((source/'metadata_methods.jsonl').read_bytes()),
                                  command=cmd,returncode=result.returncode,duration_seconds=round(time.monotonic()-start,3),
                                  listing_sha256=nav.sha(listing.read_bytes())),game_executed=False)
    nav.atomic_json(output/'method-contract.json',contract);nav.atomic_json(output/'control-flow.json',cfg)
    (output/'unknowns.jsonl').write_text(''.join(__import__('json').dumps(u)+'\n' for u in unknowns))
    summary=dict(task_id=TASK,status='partial',semantic_completion=False,method_body_fully_bounded=False,
                 local_normal_cfg_covered=True,reachable_instructions=47,unknowns=len(unknowns),
                 contract=str(output/'method-contract.json'),control_flow=str(output/'control-flow.json'))
    nav.atomic_json(output/'result.json',summary)
    return summary

if __name__=='__main__':
    p=argparse.ArgumentParser(description=__doc__)
    p.add_argument('--source',type=Path,default=nav.ROOT/'out/recon/il2cpp')
    p.add_argument('--output',type=Path,default=nav.ROOT/'out/recon/tasks'/TASK)
    p.add_argument('--objdump',type=Path,default=Path.home()/'Unity/Hub/Editor/6000.6.6f1/Editor/Data/PlaybackEngines/AndroidPlayer/NDK/toolchains/llvm/prebuilt/linux-x86_64/bin/llvm-objdump')
    a=p.parse_args();print(run(a.source,a.output,a.objdump))
