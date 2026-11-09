#!/usr/bin/env python3
"""Pinned static lifecycle of PazuCore.Utils.ExecuteOnConditionCoroutine."""
import argparse
from pathlib import Path
import struct
import subprocess
import time

import recon_navigation as nav
import recon_scene_subscribers as identity
import recon_t025_generics as generics

OWNER='<ExecuteOnConditionCoroutine>d__30'
METHODS=[
 (OWNER,'.ctor','0x06001269',0x1cbee08,0x1cbee30,'5577ab2217be634a139e09e9e7ebb79e51b6e234f2213548a2436e090d32781b'),
 (OWNER,'System.IDisposable.Dispose','0x0600126a',0x1cbee30,0x1cbee34,'110f46b5b35c069160560c6ad6786f647dd44e8760a52a46fc22dbbcd7630b91'),
 (OWNER,'MoveNext','0x0600126b',0x1cbee34,0x1cbef94,'56b310ea63cfeec82fac5f0c952088240844e519306f27a0642f18c96f1c8b01'),
 (OWNER,'System.Collections.Generic.IEnumerator<System.Object>.get_Current','0x0600126c',0x1cbef94,0x1cbef9c,'bd237e5d99f6462770946dd64c9d5273577f92aeb78154ba485fef49e0d73851'),
 (OWNER,'System.Collections.IEnumerator.Reset','0x0600126d',0x1cbef9c,0x1cbefd4,'77629be747756560c5c181d9b9943f71d6d485843c0f83e79af296fb60305647'),
 (OWNER,'System.Collections.IEnumerator.get_Current','0x0600126e',0x1cbefd4,0x1cbefdc,'bd237e5d99f6462770946dd64c9d5273577f92aeb78154ba485fef49e0d73851'),
 ('PazuCore.Utils','ExecuteOnCondition','0x060011cc',0x1ca91bc,0x1ca91f0,'78410228768395da3d29510b84edf97001e9448bd461a9d0e02703584d628419'),
 ('PazuCore.Utils','ExecuteOnConditionCoroutine','0x060011cd',0x1cb8158,0x1cb8210,'0c6fad3681b6b84086230586afc8dea296b617d10be14c0919ca08cfddb1f13b'),
]
FIELDS=[('<>1__state',16),('<>2__current',24),('checkInterval',32),('maxWaitTime',36),('onMaxWaitTimeReached',40),('condition',48),('action',56),('<wait>5__2',64),('<safeTimer>5__3',72)]
ANCHORS={
 0x1cbee20:0xb9001293,0x1cbee30:0xd65f03c0,
 0x1cbee70:0xb9401268,0x1cbee74:0x7100051f,0x1cbee78:0x54000560,0x1cbee7c:0x35000748,
 0x1cbee84:0xbd402268,0x1cbee88:0xbd4dfd09,0x1cbee90:0xb9001268,
 0x1cbee94:0x1e292100,0x1cbee98:0x54000165,0x1cbeeb4:0x529999a8,0x1cbeeb8:0x72a7b988,
 0x1cbeebc:0x4ea91d28,0x1cbeec0:0xb9002268,0x1cbeed4:0x4ea81d00,
 0x1cbeee8:0xf8040eb4,0x1cbeef8:0xb9000abf,0x1cbeefc:0xf9401a68,
 0x1cbef00:0xb4000108,0x1cbef04:0xf9400d09,0x1cbef08:0xf9402100,0x1cbef0c:0xf9401501,
 0x1cbef10:0xd63f0120,0x1cbef14:0x360002c0,0x1cbef18:0xf9401e68,0x1cbef1c:0xb50001c8,
 0x1cbef24:0xbd404a61,0x1cbef28:0x2d440262,0x1cbef30:0xb9001268,
 0x1cbef34:0x1e222821,0x1cbef38:0x1e202008,0x1cbef3c:0xbd004a61,0x1cbef40:0x54fffded,
 0x1cbef44:0x1e202020,0x1cbef48:0x54fffdab,0x1cbef4c:0xf9401668,0x1cbef50:0xb40000a8,
 0x1cbef54:0xf9400d09,0x1cbef58:0xf9402100,0x1cbef5c:0xf9401501,0x1cbef60:0xd63f0120,
 0x1cbef64:0x2a1f03e0,0x1cbef6c:0xf9402261,0x1cbef70:0xf8018e61,0x1cbef7c:0x52800020,0x1cbef80:0xb81f8260,
 0x1cbef94:0xf9400c00,0x1cbefd4:0xf9400c00,
 0x1cb81ac:0x2a1f03e1,0x1cb81c4:0xf8030c15,0x1cb81d4:0xf8038c14,0x1cb81e4:0x2d0422c9,0x1cb81e8:0xf8028c13,
 0x1ca91c4:0xaa0103e0,0x1ca91c8:0xaa0203e1,0x1ca91cc:0xaa0303e2,
}
CALLS=[
 (0x1cbee1c,0x339a46c,'mscorlib.dll','System.Object','.ctor','0x06000fb2'),
 (0x1cbeeb0,0x1ca5714,'Assembly-CSharp.dll','PazuCore.Utils','SystemLogError','0x0600120c'),
 (0x1cbeee0,0x3cd11cc,'UnityEngine.CoreModule.dll','UnityEngine.WaitForSeconds','.ctor','0x060007e5'),
 (0x1cbefb8,0x3359350,'mscorlib.dll','System.NotSupportedException','.ctor','0x0600089e'),
 (0x1cb81b8,0x1cbee08,'Assembly-CSharp.dll',OWNER,'.ctor','0x06001269'),
 (0x1ca91d0,0x1cb8158,'Assembly-CSharp.dll','PazuCore.Utils','ExecuteOnConditionCoroutine','0x060011cd'),
 (0x1ca91e8,0x3ccbf8c,'UnityEngine.CoreModule.dll','UnityEngine.MonoBehaviour','StartCoroutine','0x0600075c'),
]


def verify(elf,meta,index):
    _,resolve=nav.load_index(index,elf,meta)
    reg=generics.verify(elf,meta)
    methods=[]
    for owner,name,token,start,stop,digest in METHODS:
        row=identity.method(resolve,('Assembly-CSharp.dll',owner,name,token,start))
        methods.append(dict(identity=row,inspection_start=hex(start),inspection_exclusive_stop=hex(stop),
                            bytes=stop-start,sha256=digest,complete_body_proven=False))
    for site,word in ANCHORS.items():nav.expect(elf,site,word)
    calls=[]
    for site,target,image,owner,name,token in CALLS:
        kind='B' if site==0x1ca91e8 else 'BL'
        nav.require(nav.branch(site,nav.word(elf,site))==dict(kind=kind,target=target),'condition lifecycle call target mismatch')
        calls.append(dict(site=hex(site),target=hex(target),identity=identity.method(resolve,(image,owner,name,token,target))))
    # Native fieldOffsets join confirms names/offsets without trusting Cpp2IL comments.
    typ=meta.types[630];nav.require(typ['name']==OWNER and typ['namespace']=='','condition coroutine TypeDef mismatch')
    traw=struct.unpack_from('<16I8H2I',meta.data,meta.tables['types']['offset']+630*88)
    nav.require(traw[18]==len(FIELDS),'condition field count mismatch')
    # declaring type is a byval type-index in this metadata layout.
    parents=[]
    for t in meta.types:
        raw=struct.unpack_from('<16I8H2I',meta.data,meta.tables['types']['offset']+t['index']*88)
        if raw[2]==traw[3]:parents.append(t['namespace']+'.'+t['name'])
    nav.require(parents==['PazuCore.Utils'],'condition coroutine parent mismatch')
    field_base,field_bytes=struct.unpack_from('<II',meta.data,96)
    offset_ptr=elf.pointer(int(reg['tables']['field_offsets']['vaddr'],16)+630*8)
    fields=[]
    for j,(name,expected_offset) in enumerate(FIELDS):
        field_index=traw[8]+j;nav.require(field_index<field_bytes//12,'condition field metadata bounds')
        raw=struct.unpack_from('<3I',meta.data,field_base+field_index*12)
        offset=struct.unpack_from('<i',elf.data,elf.offset(offset_ptr+j*4,4))[0]
        nav.require(meta.string(raw[0])==name and offset==expected_offset,'condition field identity/offset mismatch')
        type_ptr=elf.pointer(int(reg['tables']['types']['vaddr'],16)+raw[1]*8)
        data=elf.pointer(type_ptr);bits=struct.unpack_from('<I',elf.data,elf.offset(type_ptr+8,4))[0]
        type_name=None
        if j in [4,6,7]:
            expected='System.Action' if j in [4,6] else 'UnityEngine.WaitForSeconds'
            nav.require(data<len(meta.types),'condition field type bounds')
            type_name=meta.types[data]['namespace']+'.'+meta.types[data]['name']
            nav.require(type_name==expected and ((bits>>16)&255)==0x12,'condition field managed type mismatch')
        elif j==5:
            nav.require(((bits>>16)&255)==0x15,'condition field generic type mismatch')
            generic_class=data; definition_type=elf.pointer(generic_class);definition=elf.pointer(definition_type)
            nav.require(definition<len(meta.types),'condition Func definition bounds')
            nav.require(meta.types[definition]['namespace']=='System' and meta.types[definition]['name']=='Func`1','condition Func definition mismatch')
            instance=elf.pointer(generic_class+8)
            nav.require(struct.unpack_from('<I',elf.data,elf.offset(instance,4))[0]==1,'condition Func argument count mismatch')
            arg_type=elf.pointer(elf.pointer(instance+8));arg=elf.pointer(arg_type)
            nav.require(arg<len(meta.types) and meta.types[arg]['namespace']=='System' and meta.types[arg]['name']=='Boolean','condition Func Boolean argument mismatch')
            nav.require(((struct.unpack_from('<I',elf.data,elf.offset(arg_type+8,4))[0]>>16)&255)==2,'condition Func Boolean code mismatch')
            type_name='System.Func<System.Boolean>'
        fields.append(dict(name=name,metadata_index=field_index,token=hex(raw[2]),offset=offset,offset_value_address=hex(offset_ptr+j*4),
                           type_index=raw[1],type_pointer=hex(type_ptr),type_bits=hex(bits),confirmed_managed_type=type_name))
    # Exact constant and operand, not a matching floating literal elsewhere.
    nav.expect(elf,0x1cbee80,0xb0ff7388)
    threshold=struct.unpack_from('<I',elf.data,elf.offset(0xb2fdfc,4))[0]
    nav.require(threshold==0x3dcccccd,'condition interval threshold mismatch')
    literal=nav.literal(meta,nav.metadata_usage(elf,nav.adrp_ldr(elf,0x1cbee9c,0x1cbeea0)['got_vaddr']))
    nav.require(literal['literal']=="checkInterval can't be below 0.1f!",'condition clamp log literal mismatch')
    for adrp,ldr,expected in [(0x1cb816c,0x1cb8174,40979),(0x1cbeec4,0x1cbeec8,33039),(0x1cbefa0,0x1cbefa4,27794)]:
        use=nav.metadata_usage(elf,nav.adrp_ldr(elf,adrp,ldr)['got_vaddr'])
        nav.require(use['kind']==1 and use['index']==expected,'condition allocated type usage mismatch')
        expected_type={40979:OWNER,33039:'UnityEngine.WaitForSeconds',27794:'System.NotSupportedException'}[expected]
        mapped=[]
        for t in meta.types:
            row=struct.unpack_from('<16I8H2I',meta.data,meta.tables['types']['offset']+t['index']*88)
            if row[2]==use['index']:mapped.append((t['namespace']+'.'+t['name']).lstrip('.'))
        nav.require(mapped==[expected_type],'condition allocated TypeDef mismatch')
    reset_usage=nav.metadata_usage(elf,nav.adrp_ldr(elf,0x1cbefbc,0x1cbefc0)['got_vaddr'])
    nav.require(reset_usage['kind']==3 and reset_usage['index']==4716,'Reset MethodInfo usage mismatch')
    nav.require(nav.branch(0x1cbefd0,nav.word(elf,0x1cbefd0))==dict(kind='BL',target=0x1b8884c),'Reset throw boundary mismatch')
    for site in [0x1cbef20,0x1ca91ec,0x1cb820c]:
        nav.require(nav.branch(site,nav.word(elf,site))==dict(kind='BL',target=0x1b88980),'null failure boundary mismatch')
    for method in methods:
        start=int(method['inspection_start'],16);off=elf.offset(start,method['bytes'])
        nav.require(nav.sha(elf.data[off:off+method['bytes']])==method['sha256'],'condition pinned inspection bytes mismatch')
    return dict(methods=methods,fields=fields,callees=calls,threshold=dict(address='0xb2fdfc',bits='0x3dcccccd',value_float32=struct.unpack('<f',struct.pack('<I',threshold))[0],log=literal))


def produce(source,output,report,objdump):
    before=time.monotonic();binary=(source/'libil2cpp.so').read_bytes();metadata=(source/'global-metadata.dat').read_bytes()
    nav.verify_pair(binary,metadata);result=verify(nav.Elf(binary),nav.Metadata(metadata),source/'metadata_methods.jsonl')
    output.mkdir(parents=True,exist_ok=True);commands=[]
    for method in result['methods']:
        name=method['identity']['name'];cmd=[str(objdump),'-d','--start-address='+method['inspection_start'],'--stop-address='+method['inspection_exclusive_stop'],str(source/'libil2cpp.so')]
        start=time.monotonic();p=subprocess.run(cmd,capture_output=True,text=True,timeout=30);nav.require(p.returncode==0,'LLVM failed: '+p.stderr)
        dest=output/(name.replace('/','_')+'.asm.txt');dest.write_text(p.stdout)
        commands.append(dict(command=cmd,returncode=p.returncode,duration_seconds=round(time.monotonic()-start,3),output=str(dest),sha256=nav.sha(dest.read_bytes())))
    result.update(schema_version=1,scope='Eight pinned methods: factory/wrapper plus six-method condition coroutine lifecycle.',
      classification='STATIC_state_machine_contract_not_original_runtime_equivalence',semantic_completion=False,
      state_table=[dict(state=0,entry='write -1; clamp ordered interval<0.1f; create one WaitForSeconds; safeTimer=0',transition='evaluate required condition before first yield'),
                   dict(state=1,entry='write -1; safeTimer=float32(safeTimer+checkInterval)',transition='if maxWaitTime ordered >0 and timer ordered >=max: optional timeout callback then false; else evaluate condition'),
                   dict(state='other (including -1)',entry='no coroutine state write',transition='return false after lazy metadata guard')],
      predicate_paths=[dict(condition='null',effect='call runtime failure helper0x1b88980; exception semantics outside recut'),
                       dict(condition='returns bool bit0=0',effect='Current=existing wait; state=1; return true'),
                       dict(condition='returns bool bit0=1, action nonnull',effect='invoke required action; return false with state -1'),
                       dict(condition='returns bool bit0=1, action null',effect='call runtime failure helper0x1b88980')],
      timeout=dict(timer_source='Accumulated checkInterval once per state1 resumption, not measured deltaTime/wall clock.',
                   order='Timeout check precedes condition re-evaluation on resume.',nonpositive='maxWaitTime<=0 disables timeout; first condition check occurs regardless of positive maximum.',
                   callback='onMaxWaitTimeReached nullable; null means return false without invoking it.',
                   floats='FCMP/B.PL skips clamp for unordered NaN; B.LE/B.LT skip timeout for unordered NaN. Engine WaitForSeconds behavior for NaN/Infinity not established.'),
      disposal=dict(opcode='RET only',effects='No state change, callback, field clear or wait disposal in this method. Manual MoveNext after Dispose can still resume state1.',
                    cancellation_limit='Unity StopCoroutine/destruction/scheduler cancellation not observed; no cancellation token or explicit cancellation path in these pinned methods.'),
      current='Both IEnumerator.Current getters return field+0x18; no clear on normal termination observed in the pinned MoveNext.',
      reset='Allocates System.NotSupportedException and calls throw-boundary helper0x1b8884c with Reset MethodInfo; exact exception helper behavior unmodeled.',
      factory='Ctor sets supplied state after Object..ctor. Factory supplies state0 and stores condition/action/interval/max/timeout fields; wrapper forwards floats s0/s1 and calls MonoBehaviour.StartCoroutine.',
      callbacks=[dict(site='0x1cbef10',kind='Func<bool>.Invoke shape',receiver='condition field+0x30; dynamic delegate target unknown'),
                 dict(site='0x1cbef60',kind='Action.Invoke shape',receiver='action field+0x38 or timeout field+0x28; dynamic delegate target unknown')],
      errors='No catch/finally path identified in the pinned windows; out-of-window exception regions not proven; init/allocation/log/predicate/action/wait/engine/helper exceptions not modeled. State is set -1 before allocations/callback work on states0/1.',
      unknowns=['Full noncontiguous body and exception regions not proven by next-metadata-start inspection ranges.',
                'Unity WaitForSeconds scaled-time/scheduling/negative/NaN semantics and StartCoroutine/StopCoroutine engine behavior not observed.',
                'Dynamic predicate/action targets, their mutations/reentrancy/exceptions, GC and lazy-init helper behavior unknown.',
                'No wall-clock measurement, native execution, independent behavioral oracle, or whole-T026 acceptance follows from these bytes.'],
      native_sha256=nav.sha(binary),metadata_sha256=nav.sha(metadata),index_sha256=nav.sha((source/'metadata_methods.jsonl').read_bytes()),
      producer_sha256=nav.sha(Path(__file__).read_bytes()),helpers_sha256={Path(m.__file__).name:nav.sha(Path(m.__file__).read_bytes()) for m in [nav,identity,generics]},
      commands=commands,duration_seconds=round(time.monotonic()-before,3),game_executed=False,queue_modified=False,active_REA_target_used=False)
    nav.atomic_json(report,result);return result


if __name__=='__main__':
    p=argparse.ArgumentParser(description=__doc__)
    p.add_argument('--source',type=Path,default=nav.ROOT/'out/recon/il2cpp');p.add_argument('--output',type=Path,default=nav.ROOT/'out/recon/t026-condition');p.add_argument('--report',type=Path,default=nav.ROOT/'reports/recon/t026_condition.json')
    p.add_argument('--objdump',type=Path,default=Path.home()/'Unity/Hub/Editor/6000.6.6f1/Editor/Data/PlaybackEngines/AndroidPlayer/NDK/toolchains/llvm/prebuilt/linux-x86_64/bin/llvm-objdump')
    a=p.parse_args();r=produce(a.source,a.output,a.report,a.objdump);print({'methods':len(r['methods']),'fields':len(r['fields']),'report':str(a.report)})
