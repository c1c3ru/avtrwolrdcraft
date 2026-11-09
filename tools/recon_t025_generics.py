#!/usr/bin/env python3
"""Guard IsSceneAvailable's exact MethodRef/MethodSpec bindings in the shipped pair.

Narrow v31/AArch64 investigation. No provider or target execution. Registration
layout is corroborated by argument flow, table bounds and metadata joins; no
claim that table recovery reconstructs runtime generics or collection bodies.
"""
import argparse
from pathlib import Path
import struct
import subprocess
import time

import recon_navigation as nav

CODE_REG = 0x3f9a2d0
META_REG = 0x40d10c0
SPECS = [
    dict(name='.ctor', token='0x06000ccb', arity=0, definition=91258,
         site=0x2073120, target=0x2b5a3bc, kind='BL', ref=(0x2073110,0x2073114),
         method_info_load=0x207311c, method_info_word=0xf9400101,
         got=0x41af358, method_spec=90082, canonical_spec=31746, pointer_index=28106),
    dict(name='Add', token='0x06000cdf', arity=1, definition=91278,
         site=0x20731e4, target=0x2b5b5a0, kind='BL', ref=(0x2073150,0x207315c),
         method_info_load=0x20731dc, method_info_word=0xf9400322,
         got=0x41af0a8, method_spec=90084, canonical_spec=31753, pointer_index=28113),
    dict(name='Contains', token='0x06000cd5', arity=1, definition=91268,
         site=0x2073230, target=0x2b5aab0, kind='B', ref=(0x2073210,0x2073214),
         method_info_load=0x2073224, method_info_word=0xf9400102,
         got=0x41af1f0, method_spec=90086, canonical_spec=31759, pointer_index=28119),
]
REG_ANCHORS = {
    0x198c8d0:0xb00142a1, 0x198c8d4:0xf9431c21,
    0x198c8d8:0xd0013060, 0x198c8dc:0xd0ff9302,
    0x198c8e0:0x910b4000, 0x198c8e4:0x91104042,
    0x198c8e8:0x1407ef7f, 0x1b886e4:0x1400f843,
    # Tail target saves code/meta/options arguments in globals after a call.
    0x1bc67f8:0xaa0203f3, 0x1bc67fc:0xaa0103f4, 0x1bc6800:0xaa0003f5,
    0x1bc67f0:0xa9be57fe, 0x1bc67f4:0xa9014ff4, 0x1bc6804:0x97fe3df8,
    0x1bc6808:0xb0015ac9, 0x1bc680c:0xb0015aca,
    0x1bc6810:0xf905b934, 0x1bc6814:0xf905bd53, 0x1bc6818:0xa9414ff4,
    0x1bc681c:0xb0015ac8, 0x1bc6820:0xf905b515, 0x1bc6824:0xa8c257fe, 0x1bc6828:0xd65f03c0,
}


def table(elf, address, count, stride, label):
    nav.require(0 < count <= 500000, label+' invalid count')
    offset = elf.offset(address, count*stride)
    return dict(label=label, vaddr=hex(address), count=count, stride=stride,
                bytes=count*stride, sha256=nav.sha(elf.data[offset:offset+count*stride]))


def metadata_method(meta, idx, expected):
    tab=meta.tables['methods']
    nav.require(0<=idx<tab['count'], 'MethodDef outside metadata')
    raw=struct.unpack_from('<7I4H',meta.data,tab['offset']+idx*36)
    nav.require(raw[1]<len(meta.types), 'MethodDef owner outside metadata')
    typ=meta.types[raw[1]]
    owner=(typ['namespace']+'.'+typ['name']).lstrip('.')
    images=[i for i in meta.images if i['type_start']<=raw[1]<i['type_start']+i['type_count']]
    nav.require(len(images)==1,'ambiguous MethodDef image')
    actual=(images[0]['name'],owner,meta.string(raw[0]),f'0x{raw[6]:08x}',raw[10])
    nav.require(actual==expected, 'raw MethodDef identity mismatch')
    return dict(image=actual[0],declaring_type=owner,name=actual[2],token=actual[3],
                parameter_count=actual[4],method_definition_index=idx,metadata_offset=hex(tab['offset']+idx*36))


def verify(elf,meta):
    for pc,word in REG_ANCHORS.items():nav.expect(elf,pc,word)
    ref=nav.adrp_ldr(elf,0x198c8d0,0x198c8d4)
    nav.require(ref['destination_register']==1 and elf.pointer(ref['got_vaddr'])==META_REG,
                'metadata registration argument mismatch')
    nav.require(nav.branch(0x198c8e8,nav.word(elf,0x198c8e8))=={'kind':'B','target':0x1b886e4},'registration tail mismatch')
    # Fields correspond to the pinned v31 layout, NOT Unity 6's changed layout.
    fields = dict(generic_classes=(META_REG,8),generic_insts=(META_REG+16,8),
                  generic_method_functions=(META_REG+32,16),types=(META_REG+48,8),
                  method_specs=(META_REG+64,12),field_offsets=(META_REG+80,8),
                  type_definition_sizes=(META_REG+96,8),generic_method_pointers=(CODE_REG+16,8),
                  invokers=(CODE_REG+40,8),codegen_modules=(CODE_REG+120,8))
    tables={}
    for label,(slot,stride) in fields.items():
        count=struct.unpack_from('<I',elf.data,elf.offset(slot,4))[0]
        ptr=elf.pointer(slot+8)
        tables[label]=table(elf,ptr,count,stride,label)
        tables[label]['count_field']=hex(slot)
        tables[label]['pointer_field']=hex(slot+8)
    for key in ['field_offsets','type_definition_sizes']:
        nav.require(tables[key]['count']==meta.tables['types']['count'],'registration type count mismatch')
    nav.require(tables['codegen_modules']['count']==len(meta.images),'module count mismatch')
    # Assert the whole module-name set, not only one lucky count/pointer.
    module_names=[]
    for i in range(tables['codegen_modules']['count']):
        module=elf.pointer(int(tables['codegen_modules']['vaddr'],16)+8*i)
        nameptr=elf.pointer(module); off=elf.offset(nameptr)
        end=elf.data.find(b'\0',off,off+512)
        nav.require(end>=off,'unterminated module name')
        module_names.append(bytes(elf.data[off:end]).decode('utf-8'))
    nav.require(sorted(module_names)==sorted(i['name'] for i in meta.images),'codegen modules/image names mismatch')
    def methodspec(idx):
        tab=tables['method_specs'];nav.require(0<=idx<tab['count'],'MethodSpec outside table')
        return struct.unpack_from('<3i',elf.data,elf.offset(int(tab['vaddr'],16)+12*idx,12))
    def inst(idx,expected_name,expected_code):
        tab=tables['generic_insts'];nav.require(0<=idx<tab['count'],'GenericInst outside table')
        addr=elf.pointer(int(tab['vaddr'],16)+idx*8)
        argc=struct.unpack_from('<I',elf.data,elf.offset(addr,4))[0]
        nav.require(argc==1,'GenericInst arity mismatch')
        argv=elf.pointer(addr+8); typ=elf.pointer(argv)
        typedef,bits=struct.unpack_from('<QI',elf.data,elf.offset(typ,12))
        nav.require((bits>>16)&255==expected_code,'generic argument type code mismatch')
        nav.require(0<=typedef<len(meta.types),'generic argument TypeDef outside metadata')
        identity=meta.types[typedef]
        nav.require(identity['namespace']=='System' and identity['name']==expected_name,'generic argument metadata identity mismatch')
        return dict(index=idx,address=hex(addr),argc=argc,argv=hex(argv),type_address=hex(typ),
                    type_code=hex(expected_code),type_definition_index=typedef,type_name='System.'+expected_name,
                    raw_type_bytes=bytes(elf.data[elf.offset(typ,16):elf.offset(typ,16)+16]).hex())
    wanted={s['pointer_index'] for s in SPECS}|{12863,12973}
    matched={i:[] for i in wanted}
    tf=tables['generic_method_functions']; base=int(tf['vaddr'],16)
    # Structural validation of every row avoids accepting arbitrary payload as table.
    for i in range(tf['count']):
        row=struct.unpack_from('<4i',elf.data,elf.offset(base+i*16,16))
        nav.require(0<=row[0]<tables['method_specs']['count'],'generic function MethodSpec index invalid')
        nav.require(0<=row[1]<tables['generic_method_pointers']['count'],'generic function pointer index invalid')
        nav.require(-1<=row[2]<tables['invokers']['count'],'generic function invoker index invalid')
        if row[1] in wanted:matched[row[1]].append((i,row))
    bindings=[]
    for spec in SPECS:
        nav.require(nav.branch(spec['site'],nav.word(elf,spec['site']))=={'kind':spec['kind'],'target':spec['target']},'generic call target mismatch')
        ref=nav.adrp_ldr(elf,*spec['ref'])
        nav.require(ref['got_vaddr']==spec['got'],'generic MethodInfo GOT mismatch')
        nav.require(ref['destination_register']==(25 if spec['name']=='Add' else 8),'generic MethodInfo register mismatch')
        nav.expect(elf,spec['method_info_load'],spec['method_info_word'])
        usage=nav.metadata_usage(elf,spec['got'])
        nav.require(usage['kind']==6 and usage['index']==spec['method_spec'],'generic MethodRef usage mismatch')
        requested=methodspec(usage['index'])
        nav.require(requested==(spec['definition'],320,-1),'requested MethodSpec mismatch')
        method=metadata_method(meta,requested[0],('System.Core.dll','System.Collections.Generic.HashSet`1',spec['name'],spec['token'],spec['arity']))
        string_inst=inst(requested[1],'String',0x0e)
        matches=matched[spec['pointer_index']]
        nav.require(len(matches)==1,'canonical generic function binding ambiguous')
        row_index,row=matches[0]
        nav.require(row[0]==spec['canonical_spec'],'canonical MethodSpec index mismatch')
        canonical=methodspec(row[0])
        nav.require(canonical==(spec['definition'],62,-1),'canonical MethodSpec identity mismatch')
        object_inst=inst(canonical[1],'Object',0x1c)
        slot=int(tables['generic_method_pointers']['vaddr'],16)+8*row[1]
        nav.require(elf.pointer(slot)==spec['target'] and elf.executable(spec['target']),'canonical generic pointer target mismatch')
        bindings.append(dict(classification='STATIC_exact_MethodRef_binding_and_canonical_pointer_join',
                             call_site=hex(spec['site']),target=hex(spec['target']),kind=spec['kind'],
                             method=method,requested_method_spec=dict(index=spec['method_spec'],raw=list(requested)),
                             requested_class_instantiation=string_inst,method_info_usage=usage,
                             canonical_method_spec=dict(index=row[0],raw=list(canonical)),
                             canonical_class_instantiation=object_inst,
                             generic_function_row=dict(index=row_index,vaddr=hex(base+row_index*16),raw=list(row)),
                             function_pointer_slot=hex(slot)))
    def multi_inst(idx, expected):
        tab=tables['generic_insts'];nav.require(0<=idx<tab['count'],'GenericInst outside table')
        addr=elf.pointer(int(tab['vaddr'],16)+idx*8)
        argc=struct.unpack_from('<I',elf.data,elf.offset(addr,4))[0]
        nav.require(argc==len(expected),'GenericInst arity mismatch')
        argv=elf.pointer(addr+8); args=[]
        for j,(expected_name,expected_code) in enumerate(expected):
            typ=elf.pointer(argv+8*j); typedef,bits=struct.unpack_from('<QI',elf.data,elf.offset(typ,12))
            nav.require((bits>>16)&255==expected_code,'generic argument type code mismatch')
            nav.require(0<=typedef<len(meta.types),'generic argument TypeDef outside metadata')
            identity=meta.types[typedef]; fullname=identity['namespace']+'.'+identity['name']
            nav.require(fullname==expected_name,'generic argument metadata identity mismatch')
            args.append(dict(type_name=fullname,type_code=hex(expected_code),type_definition_index=typedef,
                             type_address=hex(typ),raw_type_bytes=bytes(elf.data[elf.offset(typ,16):elf.offset(typ,16)+16]).hex()))
        return dict(index=idx,address=hex(addr),argc=argc,argv=hex(argv),arguments=args)
    clear_bindings=[]
    clear_specs=[dict(got=0x41cb6b0,ref=(0x20d7ee0,0x20d7ee4),reg=20,usage=86334,inst=1038,
                      args=[('UnityEngine.GameObject',0x12),('System.Int32',0x08)],canonical=15142,
                      cinst=1166,cargs=[('System.Object',0x1c),('System.Int32',0x08)],pointer=12863,target=0x28f3898,
                      loads={0x20d7ee8:0xf9400281,0x20d7f00:0xf9400281},sites=[0x20d7eec,0x20d7f04]),
                 dict(got=0x41cb6b8,ref=(0x20d7f18,0x20d7f1c),reg=8,usage=86341,inst=1039,
                      args=[('UnityEngine.GameObject',0x12),('System.Object',0x1c)],canonical=15252,
                      cinst=73,cargs=[('System.Object',0x1c),('System.Object',0x1c)],pointer=12973,target=0x28f9eec,
                      loads={0x20d7f20:0xf9400101},sites=[0x20d7f24])]
    for spec in clear_specs:
        ref=nav.adrp_ldr(elf,*spec['ref'])
        nav.require(ref['got_vaddr']==spec['got'] and ref['destination_register']==spec['reg'],'Clear MethodInfo reference mismatch')
        usage=nav.metadata_usage(elf,spec['got'])
        nav.require(usage['kind']==6 and usage['index']==spec['usage'],'Clear MethodRef usage mismatch')
        raw=methodspec(usage['index']);nav.require(raw==(48546,spec['inst'],-1),'Clear MethodSpec mismatch')
        method=metadata_method(meta,48546,('mscorlib.dll','System.Collections.Generic.Dictionary`2','Clear','0x06002f5e',0))
        for pc,word in spec['loads'].items():nav.expect(elf,pc,word)
        for pc in spec['sites']:
            nav.require(nav.branch(pc,nav.word(elf,pc))=={'kind':'BL','target':spec['target']},'Clear call target mismatch')
        requested=multi_inst(spec['inst'],spec['args'])
        matches=matched[spec['pointer']];nav.require(len(matches)==1,'Clear canonical function binding ambiguous')
        row_index,row=matches[0]
        nav.require(row[0]==spec['canonical'] and methodspec(row[0])==(48546,spec['cinst'],-1),'Clear canonical MethodSpec mismatch')
        canonical=multi_inst(spec['cinst'],spec['cargs'])
        slot=int(tables['generic_method_pointers']['vaddr'],16)+8*row[1]
        nav.require(elf.pointer(slot)==spec['target'] and elf.executable(spec['target']),'Clear canonical pointer target mismatch')
        clear_bindings.append(dict(classification='STATIC_exact_MethodRef_binding_and_canonical_pointer_join',method=method,
                                   call_sites=[hex(p) for p in spec['sites']],target=hex(spec['target']),method_info_usage=usage,
                                   requested_method_spec=dict(index=usage['index'],raw=list(raw)),requested_class_instantiation=requested,
                                   canonical_method_spec=dict(index=row[0],raw=list(methodspec(row[0]))),canonical_class_instantiation=canonical,
                                   generic_function_row=dict(index=row_index,vaddr=hex(base+row_index*16),raw=list(row)),function_pointer_slot=hex(slot)))
    field_start,field_bytes=struct.unpack_from('<II',meta.data,96)
    nav.require(field_bytes%12==0 and field_start+field_bytes<=len(meta.data),'fields table bounds invalid')
    field_bindings=[]
    for typedef,local,expected_owner,expected_name,expected_token,expected_offset in [
        (4173,17,'PWC.Multiplayer.MPManager','<IsMultiplayerGame>k__BackingField',0x04003fe9,0),
        (3803,10,'PWC.GameSceneManager','_availableSceneNames',0x04003ba7,72)]:
        typ=meta.types[typedef];owner=typ['namespace']+'.'+typ['name']
        nav.require(owner==expected_owner,'field owner mismatch')
        traw=struct.unpack_from('<16I8H2I',meta.data,meta.tables['types']['offset']+typedef*88)
        nav.require(local<traw[18],'field local index invalid')
        field_index=traw[8]+local
        nav.require(field_index<field_bytes//12,'field outside metadata')
        raw=struct.unpack_from('<3I',meta.data,field_start+12*field_index)
        nav.require(meta.string(raw[0])==expected_name and raw[2]==expected_token,'field metadata identity mismatch')
        tab=tables['field_offsets']; offset_ptr=elf.pointer(int(tab['vaddr'],16)+8*typedef)
        field_address=offset_ptr+4*local; offset=struct.unpack_from('<i',elf.data,elf.offset(field_address,4))[0]
        nav.require(offset==expected_offset,'field offset mismatch')
        nav.require(raw[1]<tables['types']['count'],'field type index invalid')
        type_ptr=elf.pointer(int(tables['types']['vaddr'],16)+8*raw[1])
        type_data,type_bits=struct.unpack_from('<QI',elf.data,elf.offset(type_ptr,12))
        nav.require(type_bits&0x10,'field lacks static attribute')
        if typedef==4173:
            nav.require((type_bits>>16)&255==2 and meta.types[type_data]['name']=='Boolean' and meta.types[type_data]['namespace']=='System','MP field Boolean type mismatch')
        field_bindings.append(dict(classification='STATIC_metadata_field_and_registered_offset_join',declaring_type=owner,
                                   type_definition_index=typedef,field_index=field_index,local_field_index=local,
                                   field_name=expected_name,token=hex(raw[2]),field_metadata_offset=hex(field_start+12*field_index),
                                   offset_table_pointer=hex(offset_ptr),offset_value_address=hex(field_address),offset=offset,
                                   type_table_index=raw[1],type_pointer=hex(type_ptr),type_data=type_data,type_bits=hex(type_bits),static=True))
    return dict(tables=tables,bindings=bindings,clear_bindings=clear_bindings,field_bindings=field_bindings,
                registration=dict(code_registration=hex(CODE_REG),metadata_registration=hex(META_REG),
                                  argument_loader='0x198c8d0..0x198c8e8',tail_targets=['0x1b886e4','0x1bc67f0'],
                                  static_argument_storage='0x1bc6810/0x1bc6814/0x1bc6820',
                                  anchors=[dict(address=hex(a),word=hex(w)) for a,w in REG_ANCHORS.items()]),
                unknowns=['Registration argument loader invocation and runtime initialization were not observed.',
                          'Exact MethodRef identities do not prove ctor/Add/Contains body behavior, exceptions or generic sharing correctness.',
                          'Call targets correspond to canonical HashSet<object> table entries; no direct string table row is asserted.',
                          'Collection cache concurrency, invalidation, effects and Unity PlayerPrefs behavior remain open.',
                          'Narrow v31 registration layout is pair-specific; no claim of a universal parser or T024/T025 completion.'])


def produce(source,output,report,objdump):
    begin=time.monotonic(); binary=(source/'libil2cpp.so').read_bytes(); metadata=(source/'global-metadata.dat').read_bytes()
    nav.verify_pair(binary,metadata)
    result=verify(nav.Elf(binary),nav.Metadata(metadata))
    output.mkdir(parents=True,exist_ok=True)
    commands=[]
    for name,start,stop in [('registration',0x198c8d0,0x198c8ec),('registration-storage',0x1bc67f0,0x1bc682c),
                            ('IsSceneAvailable',0x207305c,0x2073238),('MPOwnership.Clear',0x20d7e78,0x20d7f44)]:
        cmd=[str(objdump),'-d',f'--start-address={start}',f'--stop-address={stop}',str(source/'libil2cpp.so')]
        before=time.monotonic(); p=subprocess.run(cmd,capture_output=True,text=True,timeout=30)
        nav.require(p.returncode==0,'LLVM failed: '+p.stderr)
        dest=output/(name+'.asm.txt');dest.write_text(p.stdout)
        commands.append(dict(command=cmd,returncode=p.returncode,duration_seconds=round(time.monotonic()-before,3),output=str(dest),sha256=nav.sha(dest.read_bytes())))
    result.update(schema_version=1,scope='IsSceneAvailable HashSet MethodRefs, MPOwnership Dictionary.Clear MethodRefs, MP flag/cache field offsets; narrow static joins.',
                  native_sha256=nav.sha(binary),metadata_sha256=nav.sha(metadata),producer_sha256=nav.sha(Path(__file__).read_bytes()),
                  helper_sha256=nav.sha(Path(nav.__file__).read_bytes()),commands=commands,
                  duration_seconds=round(time.monotonic()-begin,3),game_executed=False,queue_modified=False,active_REA_target_used=False)
    nav.atomic_json(report,result);return result


if __name__=='__main__':
    p=argparse.ArgumentParser(description=__doc__)
    p.add_argument('--source',type=Path,default=nav.ROOT/'out/recon/il2cpp')
    p.add_argument('--output',type=Path,default=nav.ROOT/'out/recon/t025-generics-investigation')
    p.add_argument('--report',type=Path,default=nav.ROOT/'reports/recon/t025_generic_bindings_investigation.json')
    p.add_argument('--objdump',type=Path,default=Path.home()/'Unity/Hub/Editor/6000.6.6f1/Editor/Data/PlaybackEngines/AndroidPlayer/NDK/toolchains/llvm/prebuilt/linux-x86_64/bin/llvm-objdump')
    a=p.parse_args();r=produce(a.source,a.output,a.report,a.objdump)
    print({'bindings':len(r['bindings']),'report':str(a.report)})
