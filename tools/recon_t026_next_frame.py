#!/usr/bin/env python3
"""Recover a bounded next-frame iterator lifecycle from original bytes/metadata.

This produces a static transition table, not a Unity timing measurement or an
independent executable oracle. Unknown helpers/scheduler/exception regions stay open.
"""
import argparse
import bisect
import json
from pathlib import Path
import struct
import subprocess
import time

import recon_navigation as nav
import recon_scene_subscribers as identity
import recon_t025_generics as registration
from recon_t025_implement import type_usage

MACHINE='<ExecuteNextFrameCoroutine>d__38'
METHODS=[('factory','PazuCore.Utils','ExecuteNextFrameCoroutine','0x060011d5',0x1cb83f8),
         ('start','PazuCore.Utils','ExecuteNextFrame','0x060011d4',0x1cb3a60),
         ('ctor',MACHINE,'.ctor','0x06001263',0x1cbed28),
         ('dispose',MACHINE,'System.IDisposable.Dispose','0x06001264',0x1cbed50),
         ('move',MACHINE,'MoveNext','0x06001265',0x1cbed54),
         ('generic_current',MACHINE,'System.Collections.Generic.IEnumerator<System.Object>.get_Current','0x06001266',0x1cbedc0),
         ('reset',MACHINE,'System.Collections.IEnumerator.Reset','0x06001267',0x1cbedc8),
         ('current',MACHINE,'System.Collections.IEnumerator.get_Current','0x06001268',0x1cbee00)]
# Each instruction contributing state/data/control in MoveNext, not a name heuristic.
MOVE_WORDS=[0xa9bf4ffe,0xb9401008,0xaa0003f3,0x7100051f,0x54000160,0x35000248,
            0xf8018e7f,0x12800008,0xaa1303e0,0xaa1f03e1,0xb81f8268,0x97fb2645,
            0x52800020,0xb81f8260,0x1400000a,0xf9401268,0x12800009,0xb9001269,
            0xb4000108,0xf9400d09,0xf9402100,0xf9401501,0xd63f0120,0x2a1f03e0,
            0xa8c14ffe,0xd65f03c0,0x97fb26f1]
ANCHORS={0x1cb8410:0xaa0003f3,0x1cb843c:0xaa0003f4,0x1cb8448:0xaa1403e0,0x1cb8450:0xaa1303e1,
         0x1cbed30:0x2a0103f3,0x1cbed38:0xaa0003f4,0x1cb8434:0x2a1f03e1,0x1cb844c:0xf8020c13,0x1cbed40:0xb9001293,
         0x1cbed50:0xd65f03c0,0x1cbedc0:0xf9400c00,0x1cbedc4:0xd65f03c0,
         0x1cbee00:0xf9400c00,0x1cbee04:0xd65f03c0,
         0x1cb3a64:0xaa0003f3,0x1cb3a68:0xaa0103e0,0x1cb3a70:0xb40000d3,
         0x1cb3a74:0xaa0003e1,0x1cb3a78:0xaa1303e0,0x1cb3a7c:0xaa1f03e2,
         0x1cbeddc:0xaa1f03e1,0x1cbede0:0xaa0003f3,0x1cbedf4:0xaa0003e1,0x1cbedf8:0xaa1303e0}
CALLS=[(0x1cb3a6c,0x1cb83f8,'PazuCore.Utils','ExecuteNextFrameCoroutine','BL'),
       (0x1cb3a84,0x3ccbf8c,'UnityEngine.MonoBehaviour','StartCoroutine','B'),
       (0x1cb8440,0x1cbed28,MACHINE,'.ctor','BL'),
       (0x1cbed3c,0x339a46c,'System.Object','.ctor','BL'),
       (0x1cbede4,0x3359350,'System.NotSupportedException','.ctor','BL')]


def verify(elf,meta,index):
    rows,resolve=nav.load_index(index,elf,meta)
    methods={key:identity.method(resolve,('Assembly-CSharp.dll',owner,name,token,va))
             for key,owner,name,token,va in METHODS}
    for i,word in enumerate(MOVE_WORDS):nav.expect(elf,0x1cbed54+4*i,word)
    for pc,word in ANCHORS.items():nav.expect(elf,pc,word)
    calls=[]
    for pc,target,owner,name,kind in CALLS:
        nav.require(nav.branch(pc,nav.word(elf,pc))==dict(kind=kind,target=target),'named lifecycle branch mismatch')
        candidates=resolve(target)
        nav.require(len(candidates)==1 and (candidates[0]['declaring_type'],candidates[0]['name'])==(owner,name),'named lifecycle callee mismatch')
        calls.append(dict(site=hex(pc),target=candidates[0]))
    factory_type=type_usage(elf,meta,0x1cb8404,0x1cb840c,MACHINE)
    reset_type=type_usage(elf,meta,0x1cbedcc,0x1cbedd0,'System.NotSupportedException')
    reset_ref=nav.adrp_ldr(elf,0x1cbede8,0x1cbedec)
    reset_usage=nav.metadata_usage(elf,reset_ref['got_vaddr'])
    nav.require(reset_usage['kind']==3 and reset_usage['index']==4710,'Reset throw-site method usage mismatch')
    nav.require(nav.branch(0x1cbedfc,nav.word(elf,0x1cbedfc))==dict(kind='BL',target=0x1b8884c),'Reset helper target mismatch')
    reg=registration.verify(elf,meta)
    typedef=629;typ=meta.types[typedef]
    nav.require(typ['name']==MACHINE,'iterator typedef mismatch')
    traw=struct.unpack_from('<16I8H2I',meta.data,meta.tables['types']['offset']+typedef*88)
    # Reconfirm nested owner using byvalTypeIndex, not the repeated short name.
    owner_index=traw[3]
    owners=[]
    for i,t in enumerate(meta.types):
        byval=struct.unpack_from('<I',meta.data,meta.tables['types']['offset']+i*88+8)[0]
        if byval==owner_index:owners.append(t['namespace']+'.'+t['name'])
    nav.require(owners==['PazuCore.Utils'],'iterator declaring owner mismatch')
    start,size=struct.unpack_from('<II',meta.data,96)
    field_table=int(reg['tables']['field_offsets']['vaddr'],16)
    offsets=elf.pointer(field_table+8*typedef)
    fields=[]
    nav.require(traw[18]==3,'iterator field count mismatch')
    for local,(name,expected) in enumerate([('<>1__state',16),('<>2__current',24),('action',32)]):
        idx=traw[8]+local
        nav.require(idx<size//12,'iterator field outside metadata')
        raw=struct.unpack_from('<3I',meta.data,start+12*idx)
        offset=struct.unpack_from('<i',elf.data,elf.offset(offsets+local*4,4))[0]
        nav.require(meta.string(raw[0])==name and offset==expected,'iterator field metadata/offset mismatch')
        fields.append(dict(name=name,field_index=idx,token=hex(raw[2]),offset=offset,offset_address=hex(offsets+local*4)))
    starts=sorted({int(r['vaddr'],16) for r in rows if r.get('vaddr')})
    windows={}
    for key,m in methods.items():
        begin=int(m['vaddr'],16);stop=starts[bisect.bisect_right(starts,begin)]
        off=elf.offset(begin,stop-begin)
        windows[key]=dict(start=hex(begin),exclusive_stop=hex(stop),bytes=stop-begin,
                          sha256=nav.sha(elf.data[off:off+stop-begin]),complete_body_proven=False)
    return dict(methods=methods,fields=fields,calls=calls,factory_allocated_type=factory_type,reset_exception_type=reset_type,reset_method_usage=reset_usage,
                inspection_windows=windows,registration=reg['registration'])


def produce(source,output,report,objdump):
    begin=time.monotonic();binary=(source/'libil2cpp.so').read_bytes();metadata=(source/'global-metadata.dat').read_bytes()
    nav.verify_pair(binary,metadata)
    result=verify(nav.Elf(binary),nav.Metadata(metadata),source/'metadata_methods.jsonl')
    output.mkdir(parents=True,exist_ok=True);commands=[]
    for key,w in result['inspection_windows'].items():
        cmd=[str(objdump),'-d','--start-address='+w['start'],'--stop-address='+w['exclusive_stop'],str(source/'libil2cpp.so')]
        t=time.monotonic();p=subprocess.run(cmd,capture_output=True,text=True,timeout=30)
        nav.require(p.returncode==0,'LLVM failed: '+p.stderr)
        dest=output/(key+'.asm.txt');dest.write_text(p.stdout)
        commands.append(dict(command=cmd,returncode=p.returncode,duration_seconds=round(time.monotonic()-t,3),output=str(dest),sha256=nav.sha(dest.read_bytes())))
    transitions=[dict(operation='factory',precondition='allocation/base constructor/write barrier return normally',state_after=0,action='store argument at +0x20',result='new iterator'),
                 dict(operation='MoveNext',state_before=0,steps=['Current=null','state=-1','write barrier','state=1'],state_after=1,result=True,callback_invoked=False,evidence_sites=['0x1cbed6c','0x1cbed7c','0x1cbed88']),
                 dict(operation='MoveNext',state_before=1,action_nonnull=True,steps=['state=-1','invoke Action via delegate registers','return false if callback returns'],state_after=-1,result=False,callback_invoked=True,evidence_sites=['0x1cbed98','0x1cbedac']),
                 dict(operation='MoveNext',state_before=1,action_nonnull=False,steps=['state=-1','branch to helper 0x1b88980'],state_after=-1,result='UNKNOWN_failure_helper_does_not_return_in_modeled_path',callback_invoked=False,evidence_sites=['0x1cbed98','0x1cbed9c','0x1cbedbc']),
                 dict(operation='MoveNext',state_before='any int32 except 0 and 1',state_after='unchanged',result=False,callback_invoked=False,evidence_sites=['0x1cbed68','0x1cbedb0']),
                 dict(operation='Dispose',state_before='any',state_after='unchanged',effects='one RET; no state/action/current stores in inspected body',callback_invoked=False,evidence_sites=['0x1cbed50']),
                 dict(operation='get_Current (both interfaces)',result='read reference at +0x18',state_after='unchanged',evidence_sites=['0x1cbedc0','0x1cbee00']),
                 dict(operation='Reset',steps=['construct NotSupportedException','pass exception and Reset MethodInfo to helper 0x1b8884c'],result='INFERRED_throw; exact helper semantics unknown',state_after='no local state write',evidence_sites=['0x1cbede4','0x1cbedfc'])]
    unknowns=['Unity scheduler semantics of yield null and StartCoroutine; no measured frame/time duration.',
              'StopCoroutine, host destruction, pause/timescale and cancellation dispatch are external; Dispose alone does not mark iterator cancelled.',
              'Helper initialization/allocation/write barrier/null-failure/exception dispatch internals and full exception regions.',
              'Callback target, side effects, exceptions and thread behavior; no target execution or reentrancy experiment.',
              'Inspection windows end at next metadata start; no global async/event/coroutine coverage.']
    result.update(schema_version=1,scope='One iterator lifecycle plus factory/StartCoroutine boundary',classification='STATIC_bytes_metadata_derived_transition_table',
                  native_sha256=nav.sha(binary),metadata_sha256=nav.sha(metadata),
                  producer_sha256=nav.sha(Path(__file__).read_bytes()),
                  helpers_sha256={Path(m.__file__).name:nav.sha(Path(m.__file__).read_bytes()) for m in (nav,identity,registration)},
                  type_usage_helper_sha256=nav.sha(Path(__import__('recon_t025_implement').__file__).read_bytes()),
                  index_sha256=nav.sha((source/'metadata_methods.jsonl').read_bytes()),
                  transitions=transitions,normal_path_precondition='Calls to initialization, constructors, allocation and write barriers return normally unless an error path is explicitly described.',
                  exception_order='state=-1 store precedes callback dispatch: if callback throws after entry, this local state write has already occurred; subsequent scheduler handling unknown.',
                  cancellation_limit='Dispose is a no-op in inspected bytes. It does not itself prevent a subsequent manual MoveNext(state=1) from reaching Action.',
                  current_limit='Normal first yield sets Current=null; later MoveNext(state=1) does not rewrite Current/action. Constructor only initializes state, not those reference fields.',
                  commands=commands,unknowns=unknowns,semantic_completion=False,game_executed=False,
                  duration_seconds=round(time.monotonic()-begin,3),queue_modified=False)
    nav.atomic_json(output/'result.json',result);nav.atomic_json(report,result)
    return result

if __name__=='__main__':
    p=argparse.ArgumentParser(description=__doc__)
    p.add_argument('--source',type=Path,default=nav.ROOT/'out/recon/il2cpp')
    p.add_argument('--output',type=Path,default=nav.ROOT/'out/recon/tasks/T026/STATE_MACHINE/execute-next-frame')
    p.add_argument('--report',type=Path,default=nav.ROOT/'reports/recon/t026_next_frame.json')
    p.add_argument('--objdump',type=Path,default=Path.home()/'Unity/Hub/Editor/6000.6.6f1/Editor/Data/PlaybackEngines/AndroidPlayer/NDK/toolchains/llvm/prebuilt/linux-x86_64/bin/llvm-objdump')
    a=p.parse_args();r=produce(a.source,a.output,a.report,a.objdump)
    print({'methods':len(r['methods']),'transitions':len(r['transitions']),'semantic_completion':r['semantic_completion']})
