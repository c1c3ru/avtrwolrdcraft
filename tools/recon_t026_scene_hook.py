#!/usr/bin/env python3
"""Guard conditional virtual sceneLoaded signup/removal in the shipped loading manager.

Static evidence only. Concrete slot4 is checked in metadata; no live class layout,
Unity invocation, delegate equality or successful unsubscription is asserted.
"""
import argparse
from pathlib import Path
import struct
import subprocess
import time

import recon_navigation as nav
import recon_loading_fade as loading
import recon_scene_subscribers as identities
import recon_t025_generics as generics

OWNER='PWC.LoadingScreen.LoadingScreenManager'
SCENE_MANAGER='UnityEngine.SceneManagement.SceneManager'
CTOR=0x305a4a0
SPECS=[dict(name='Awake',token='0x06005fc2',start=0x20fe1b4,stop=0x20fe2d8,
            sha256='ae2332d417092b4c1d46df06e8b73a3ee799a5e004ff83c70856e3bf35b18b91',
            operation='add',site=0x20fe294,target=0x3cdbc5c,event_token='0x060009c2',kind='BL',ctor=0x20fe278,
            anchors={0x20fe1c8:0xaa0003f3,0x20fe254:0xf9400268,0x20fe260:0xaa1303e1,
                     0x20fe264:0xf940c102,0x20fe270:0xaa1f03e3,0x20fe274:0xaa0003f4,
                     0x20fe28c:0xaa1403e0,0x20fe290:0xaa1f03e1}),
       dict(name='OnDestroy',token='0x06005fc5',start=0x20fe5e4,stop=0x20fe6bc,
            sha256='0f6c5e1f1f9c0da6060d53d4aae42001f1b74ea4d1bf76bec17d9dc9190ad2a2',
            operation='remove',site=0x20fe6b4,target=0x3cdbd50,event_token='0x060009c3',kind='B',ctor=0x20fe690,
            anchors={0x20fe5f4:0xaa0003f3,0x20fe674:0xf9400268,0x20fe67c:0xaa1303e1,
                     0x20fe680:0xaa1f03e3,0x20fe684:0xf940c102,0x20fe68c:0xaa0003f4,
                     0x20fe6a4:0xaa1403e0,0x20fe6ac:0xaa1f03e1})]


def verify(elf,meta,index):
    _,resolve=nav.load_index(index,elf,meta)
    handler=identities.method(resolve,('Assembly-CSharp.dll',OWNER,'OnSceneLoaded','0x06005fc4',0x20fe4b4))
    nav.require(handler['parameter_count']==2,'handler arity mismatch')
    slot=loading.virtual_slot(meta,OWNER,4,24515,'OnSceneLoaded')
    nav.require(slot['declaring_type_index']==4257 and slot['parameters']==2,'slot owner/arity mismatch')
    # Canonical typed delegate constructor, not proof of requested enum instantiation.
    tables=generics.verify(elf,meta)['tables']
    tf=tables['generic_method_functions'];row_address=int(tf['vaddr'],16)+58912*16
    row=struct.unpack_from('<4i',elf.data,elf.offset(row_address,16))
    nav.require(row==(65692,58745,4427,-1),'delegate canonical function row mismatch')
    ms=tables['method_specs'];spec_address=int(ms['vaddr'],16)+row[0]*12
    spec=struct.unpack_from('<3i',elf.data,elf.offset(spec_address,12))
    nav.require(spec==(87512,6724,-1),'delegate canonical MethodSpec mismatch')
    ctor_method=generics.metadata_method(meta,87512,('UnityEngine.CoreModule.dll','UnityEngine.Events.UnityAction`2','.ctor','0x06000980',2))
    pointers=tables['generic_method_pointers'];pointer_slot=int(pointers['vaddr'],16)+row[1]*8
    nav.require(elf.pointer(pointer_slot)==CTOR and elf.executable(CTOR),'delegate constructor pointer mismatch')
    insts=tables['generic_insts'];inst_address=elf.pointer(int(insts['vaddr'],16)+6724*8)
    nav.require(struct.unpack_from('<I',elf.data,elf.offset(inst_address,4))[0]==2,'delegate generic arity mismatch')
    argv=elf.pointer(inst_address+8);args=[]
    for i,(expected_index,expected_name) in enumerate([(11802,'UnityEngine.SceneManagement.Scene'),(6693,'System.Int32Enum')]):
        typ=elf.pointer(argv+i*8);data,bits=struct.unpack_from('<QI',elf.data,elf.offset(typ,12))
        nav.require(data==expected_index and (bits>>16)&255==0x11,'delegate canonical argument mismatch')
        t=meta.types[data];name=(t['namespace']+'.'+t['name']).lstrip('.')
        nav.require(name==expected_name,'delegate canonical argument metadata mismatch')
        args.append(dict(type=name,type_definition_index=data,type_code='0x11',address=hex(typ)))
    edges=[]
    for s in SPECS:
        caller=identities.method(resolve,('Assembly-CSharp.dll',OWNER,s['name'],s['token'],s['start']))
        nav.require(caller['parameter_count']==0,'caller arity mismatch')
        event=identities.method(resolve,('UnityEngine.CoreModule.dll',SCENE_MANAGER,s['operation']+'_sceneLoaded',s['event_token'],s['target']))
        nav.require(event['parameter_count']==1,'event arity mismatch')
        for address,word in s['anchors'].items():nav.expect(elf,address,word)
        nav.require(nav.branch(s['ctor'],nav.word(elf,s['ctor']))=={'kind':'BL','target':CTOR},'delegate constructor branch mismatch')
        nav.require(nav.branch(s['site'],nav.word(elf,s['site']))=={'kind':s['kind'],'target':s['target']},'event accessor branch mismatch')
        edges.append(dict(classification='STATIC_conditional_virtual_handler_event_edge',operation=s['operation'],caller=caller,event_accessor=event,
                          site=hex(s['site']),target=hex(s['target']),kind=s['kind'],constructor_site=hex(s['ctor']),
                          target_object='this preserved in x19; passed as x1',handler_source='x2 loaded from [this.klass+0x180]',
                          raw_anchors=[identities.raw_instruction(elf,a) for a in sorted(s['anchors'])]))
    return dict(handler=handler,conditional_virtual_slot=slot,edges=edges,
                canonical_delegate_constructor=dict(method=ctor_method,target=hex(CTOR),generic_function_row_address=hex(row_address),
                                                     generic_function_row=list(row),method_spec_address=hex(spec_address),method_spec=list(spec),
                                                     pointer_slot=hex(pointer_slot),class_instantiation_index=6724,class_arguments=args),
                preconditions=['Normal execution reaches each guarded delegate construction and event accessor.',
                               'Runtime receiver resolves slot4 to the distributed LoadingScreenManager implementation; a derived override may change the handler.',
                               'Native class vtable base0x138 and16-byte pointer/MethodInfo pairs make offset0x180 the slot4 MethodInfo half. Runtime class memory was not observed.'],
                unknowns=['Runtime delegate creation/registration/invocation/removal and Unity lifetime were not observed.',
                          'Delegate allocation type metadata and requested Scene/LoadSceneMode generic constructor MethodSpec were not resolved here. Canonical Scene/Int32Enum helper does not establish requested instantiation alone.',
                          'Accessor internals, delegate equality, generic sharing, helper effects and exceptions remain unmodeled.',
                          'Only bounded Awake/OnDestroy slices inspected; complete CFG/body and noncontiguous or exceptional ranges are not proven.',
                          'Handler body/state-machine and timing are outside this event-hook probe.'])


def produce(source,output,report,objdump):
    binary=(source/'libil2cpp.so').read_bytes();metadata=(source/'global-metadata.dat').read_bytes();nav.verify_pair(binary,metadata)
    elf,meta=nav.Elf(binary),nav.Metadata(metadata)
    result=verify(elf,meta,source/'metadata_methods.jsonl');commands=[];windows=[]
    output.mkdir(parents=True,exist_ok=True)
    for s in SPECS:
        offset=elf.offset(s['start'],s['stop']-s['start']);body=binary[offset:offset+s['stop']-s['start']]
        nav.require(nav.sha(body)==s['sha256'],'inspection slice changed')
        command=[str(objdump),'-d',f"--start-address={s['start']}",f"--stop-address={s['stop']}",str(source/'libil2cpp.so')]
        start=time.monotonic();p=subprocess.run(command,capture_output=True,text=True,timeout=30);nav.require(p.returncode==0,'LLVM failed: '+p.stderr)
        path=output/(s['name']+'.asm.txt');path.write_text(p.stdout)
        commands.append(dict(command=command,returncode=p.returncode,duration_seconds=round(time.monotonic()-start,3),output=str(path),sha256=nav.sha(path.read_bytes())))
        windows.append(dict(start=hex(s['start']),inspection_exclusive_stop=hex(s['stop']),sha256=nav.sha(body),bytes=len(body),complete_body_proven=False))
    result.update(schema_version=1,scope='LoadingScreenManager paired sceneLoaded hook: conditional concrete virtual slot identity and canonical delegate constructor pointer join.',
                  native_sha256=nav.sha(binary),metadata_sha256=nav.sha(metadata),producer_sha256=nav.sha(Path(__file__).read_bytes()),
                  helpers_sha256={Path(m.__file__).name:nav.sha(Path(m.__file__).read_bytes()) for m in (nav,loading,identities,generics)},
                  method_index_sha256=nav.sha((source/'metadata_methods.jsonl').read_bytes()),inspection_windows=windows,commands=commands,
                  game_executed=False,queue_modified=False,active_REA_target_used=False,semantic_completion=False)
    nav.atomic_json(report,result);return result


if __name__=='__main__':
    p=argparse.ArgumentParser(description=__doc__)
    p.add_argument('--source',type=Path,default=nav.ROOT/'out/recon/il2cpp')
    p.add_argument('--output',type=Path,default=nav.ROOT/'out/recon/t026-scene-hook')
    p.add_argument('--report',type=Path,default=nav.ROOT/'reports/recon/t026_scene_hook.json')
    p.add_argument('--objdump',type=Path,default=Path.home()/'Unity/Hub/Editor/6000.6.6f1/Editor/Data/PlaybackEngines/AndroidPlayer/NDK/toolchains/llvm/prebuilt/linux-x86_64/bin/llvm-objdump')
    a=p.parse_args();r=produce(a.source,a.output,a.report,a.objdump);print(dict(edges=len(r['edges']),report=str(a.report)))
