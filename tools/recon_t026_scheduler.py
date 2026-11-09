#!/usr/bin/env python3
"""Guard coroutine API wrappers and distinguish packaged ABI from API reference.

Engine icall implementations are external to this IL2CPP wrapper investigation.
"""
import argparse
import bisect
from pathlib import Path
import struct
import subprocess
import time
import recon_navigation as nav
import recon_scene_subscribers as identity

OWNER='UnityEngine.MonoBehaviour'
# name, token, start; code before next metadata start is only inspection window.
METHODS=[('start_enumerator','StartCoroutine','0x0600075c',0x3ccbf8c),
         ('stop_enumerator','StopCoroutine','0x0600075e',0x3ccc0c4),
         ('stop_coroutine','StopCoroutine','0x0600075f',0x3ccc1f8),
         ('stop_string','StopCoroutine','0x06000760',0x3ccc32c),
         ('stop_all','StopAllCoroutines','0x06000761',0x3ccc370),
         ('start_managed','StartCoroutineManaged2','0x0600076c',0x3ccc07c),
         ('stop_enumerator_managed','StopCoroutineFromEnumeratorManaged','0x0600076e',0x3ccc1b4),
         ('stop_coroutine_managed','StopCoroutineManaged','0x0600076d',0x3ccc2e8)]
RESOLVERS=[(0x3ccbfac,0x3ccbfb0,0x3ccbfb4,'UnityEngine.MonoBehaviour::IsObjectMonoBehaviour(UnityEngine.Object)'),
           (0x3ccbfd8,0x3ccbfdc,0x3ccbfe0,'UnityEngine.MonoBehaviour::StartCoroutineManaged2(System.Collections.IEnumerator)'),
           (0x3ccc0e4,0x3ccc0e8,0x3ccc0ec,'UnityEngine.MonoBehaviour::IsObjectMonoBehaviour(UnityEngine.Object)'),
           (0x3ccc110,0x3ccc114,0x3ccc118,'UnityEngine.MonoBehaviour::StopCoroutineFromEnumeratorManaged(System.Collections.IEnumerator)'),
           (0x3ccc218,0x3ccc21c,0x3ccc220,'UnityEngine.MonoBehaviour::IsObjectMonoBehaviour(UnityEngine.Object)'),
           (0x3ccc244,0x3ccc248,0x3ccc24c,'UnityEngine.MonoBehaviour::StopCoroutineManaged(UnityEngine.Coroutine)'),
           (0x3ccc348,0x3ccc34c,0x3ccc350,'UnityEngine.MonoBehaviour::StopCoroutine(System.String)'),
           (0x3ccc388,0x3ccc38c,0x3ccc390,'UnityEngine.MonoBehaviour::StopAllCoroutines()'),
           (0x3ccc098,0x3ccc09c,0x3ccc0a0,'UnityEngine.MonoBehaviour::StartCoroutineManaged2(System.Collections.IEnumerator)'),
           (0x3ccc1d0,0x3ccc1d4,0x3ccc1d8,'UnityEngine.MonoBehaviour::StopCoroutineFromEnumeratorManaged(System.Collections.IEnumerator)'),
           (0x3ccc304,0x3ccc308,0x3ccc30c,'UnityEngine.MonoBehaviour::StopCoroutineManaged(UnityEngine.Coroutine)')]


def native_string(elf,adrp,add):
    a,b=nav.word(elf,adrp),nav.word(elf,add)
    nav.require(a&0x9f00001f==0x90000000,'icall ADRP x0 mismatch')
    nav.require(b&0xffc003ff==0x91000000,'icall ADD x0,x0 mismatch')
    imm=((a>>5)&0x7ffff)<<2|((a>>29)&3)
    address=(adrp&~0xfff)+(nav.signed(imm,21)<<12)+((b>>10)&0xfff)
    offset=elf.offset(address,1);tail=elf.data[offset:offset+256]
    end=tail.find(b'\0');nav.require(end>=0,'icall name has no bounded terminator')
    return dict(address=hex(address),file_offset=hex(offset),value=tail[:end].decode('ascii'),sha256=nav.sha(tail[:end+1]))


def verify(elf,meta,index):
    rows,resolve=nav.load_index(index,elf,meta)
    methods={k:identity.method(resolve,('UnityEngine.CoreModule.dll',OWNER,n,t,a)) for k,n,t,a in METHODS}
    names=[]
    for adrp,add,site,expected in RESOLVERS:
        ref=native_string(elf,adrp,add)
        nav.require(ref['value']==expected,'icall exact name mismatch')
        nav.require(nav.branch(site,nav.word(elf,site))==dict(kind='BL',target=0x1b886ac),'icall resolver target mismatch')
        names.append(dict(**ref,argument_sites=[hex(adrp),hex(add)],resolver_site=hex(site)))
    guards=[]
    for entry,null_site,null_target,test_site,false_target,br_site in [
        (0x3ccbf8c,0x3ccbf94,0x3ccc000,0x3ccbfc8,0x3ccc034,0x3ccbffc),
        (0x3ccc0c4,0x3ccc0cc,0x3ccc138,0x3ccc100,0x3ccc16c,0x3ccc134),
        (0x3ccc1f8,0x3ccc200,0x3ccc26c,0x3ccc234,0x3ccc2a0,0x3ccc268)]:
        nav.require(nav.branch(null_site,nav.word(elf,null_site))==dict(kind='CBZ',register=1,width=64,target=null_target),'routine null guard mismatch')
        nav.require(nav.branch(test_site,nav.word(elf,test_site))==dict(kind='TBZ',register=0,bit=0,target=false_target),'MonoBehaviour predicate guard mismatch')
        # Calls preserve original host and enumerator/Coroutine into x0/x1 at tail.
        for pc,word in [(entry+20,0xaa0103f3),(entry+24,0xaa0003f4),(br_site-16,0xaa1403e0),(br_site-12,0xaa1303e1),(br_site,0xd61f0040)]:
            nav.expect(elf,pc,word)
        guards.append(dict(entry=hex(entry),null_guard=hex(null_site),null_path=hex(null_target),object_kind_guard=hex(test_site),invalid_host_path=hex(false_target),native_tail=hex(br_site)))
    exceptions=[]
    for null_site,arg_site in [(0x3ccc02c,0x3ccc060),(0x3ccc164,0x3ccc198),(0x3ccc298,0x3ccc2cc)]:
        for site,target,owner,token in [(null_site,0x3359434,'System.NullReferenceException','0x060008a3'),(arg_site,0x32cd86c,'System.ArgumentException','0x060003c1')]:
            nav.require(nav.branch(site,nav.word(elf,site))==dict(kind='BL',target=target),'exception ctor branch mismatch')
            method=identity.method(resolve,('mscorlib.dll',owner,'.ctor',token,target))
            exceptions.append(dict(site=hex(site),method=method,exception_dispatch='helper behavior remains external'))
    literals=[]
    for a,b,expected in [(0x3ccc014,0x3ccc018,'routine is null'),(0x3ccc048,0x3ccc04c,'Coroutines can only be stopped on a MonoBehaviour')]:
        ref=nav.adrp_ldr(elf,a,b);literal=nav.literal(meta,nav.metadata_usage(elf,ref['got_vaddr']))
        nav.require(literal['literal']==expected,'exception text mismatch');literals.append(literal)
    for pc,word in [(0x3ccc36c,0xd61f0040),(0x3ccc3a8,0xd61f0020),(0x3ccc0bc,0xd61f0040),
                    (0x3ccc1f4,0xd61f0040),(0x3ccc328,0xd61f0040)]:nav.expect(elf,pc,word)
    starts=sorted({int(r['vaddr'],16) for r in rows if r.get('vaddr')})
    windows={}
    for key,m in methods.items():
        start=int(m['vaddr'],16);stop=starts[bisect.bisect_right(starts,start)];offset=elf.offset(start,stop-start)
        windows[key]=dict(start=hex(start),exclusive_stop=hex(stop),sha256=nav.sha(elf.data[offset:offset+stop-start]),complete_body_proven=False)
    return dict(methods=methods,icall_resolver_arguments=names,guards=guards,exception_constructors=exceptions,exception_literals=literals,inspection_windows=windows)


def produce(source,output,report,objdump):
    binary=(source/'libil2cpp.so').read_bytes();metadata=(source/'global-metadata.dat').read_bytes();nav.verify_pair(binary,metadata)
    result=verify(nav.Elf(binary),nav.Metadata(metadata),source/'metadata_methods.jsonl')
    output.mkdir(parents=True,exist_ok=True);commands=[]
    for key,w in result['inspection_windows'].items():
        cmd=[str(objdump),'-d','--start-address='+w['start'],'--stop-address='+w['exclusive_stop'],str(source/'libil2cpp.so')]
        t=time.monotonic();p=subprocess.run(cmd,capture_output=True,text=True,timeout=30);nav.require(p.returncode==0,'LLVM failed: '+p.stderr)
        dest=output/(key+'.asm.txt');dest.write_text(p.stdout)
        commands.append(dict(command=cmd,returncode=p.returncode,duration_seconds=round(time.monotonic()-t,3),output=str(dest),sha256=nav.sha(dest.read_bytes())))
    sources=[dict(url='https://docs.unity3d.com/2022.3/Documentation/ScriptReference/MonoBehaviour.'+n+'.html',authority='external_official_API_reference_not_packaged_runtime_observation') for n in ['StartCoroutine','StopCoroutine','StopAllCoroutines']]
    result.update(schema_version=1,scope='Eight packaged coroutine wrappers; names/guards/ABI and external API contract separated',
                  native_sha256=nav.sha(binary),metadata_sha256=nav.sha(metadata),producer_sha256=nav.sha(Path(__file__).read_bytes()),
                  helpers_sha256={Path(m.__file__).name:nav.sha(Path(m.__file__).read_bytes()) for m in (nav,identity)},
                  index_sha256=nav.sha((source/'metadata_methods.jsonl').read_bytes()),commands=commands,
                  external_reference_sources=sources,
                  documented_contract=dict(start='Declared API resumes yielded work on later frames, unless stopped/completed; order of completion is not guaranteed.',
                                           cancellation='Declared API stops by matching name/enumerator/Coroutine on the receiving behaviour; StopAll applies to that behaviour.',
                                           lifetime='Declared API stops on destruction of MonoBehaviour or deactivation of its GameObject; disabling only the component does not stop coroutines.'),
                  unknowns=['Engine pointers resolved via icall are not statically bound to libunity implementations in this report.',
                            'No original scheduler timing, disposal order, exception propagation or host lifecycle execution observed.',
                            'External API documentation is a reference contract, not evidence the original APK executed those paths.',
                            'Native string overload has no managed routine-null or MonoBehaviour test in inspected wrapper; native validation remains external.',
                            'Wrapper slices are not proof of all method/exception regions.'],game_executed=False,semantic_completion=False,queue_modified=False)
    nav.atomic_json(output/'result.json',result);nav.atomic_json(report,result);return result

if __name__=='__main__':
    p=argparse.ArgumentParser(description=__doc__)
    p.add_argument('--source',type=Path,default=nav.ROOT/'out/recon/il2cpp')
    p.add_argument('--output',type=Path,default=nav.ROOT/'out/recon/t026-scheduler')
    p.add_argument('--report',type=Path,default=nav.ROOT/'reports/recon/t026_scheduler.json')
    p.add_argument('--objdump',type=Path,default=Path.home()/'Unity/Hub/Editor/6000.6.6f1/Editor/Data/PlaybackEngines/AndroidPlayer/NDK/toolchains/llvm/prebuilt/linux-x86_64/bin/llvm-objdump')
    a=p.parse_args();r=produce(a.source,a.output,a.report,a.objdump);print({'wrappers':len(r['methods']),'resolver_sites':len(r['icall_resolver_arguments'])})
