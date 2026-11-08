#!/usr/bin/env python3
"""Extract bounded local control-flow facts for interface-discovered state machines.

No state meanings, exception coverage, runtime behavior or completion inferred.
"""
import argparse
import bisect
from collections import Counter
import json
from pathlib import Path
import struct
import time

import recon_navigation as nav


def flow(elf,start,stop,resolve):
    nav.require(start%4==0 and stop%4==0 and start<stop,'invalid inspection window')
    pending=[start];seen=set();edges=[];calls=[];unknowns=[]
    while pending:
        pc=pending.pop()
        if pc in seen:continue
        seen.add(pc)
        word=nav.word(elf,pc);branch=nav.branch(pc,word)
        successors=[]
        if branch:
            kind=branch['kind'];target=branch.get('target')
            if kind in ('BL','BLR'):
                calls.append(dict(site=hex(pc),kind=kind,target=hex(target) if target is not None else None,
                                  metadata_targets=resolve(target) if target is not None else [],
                                  exceptions='not modeled',returns='assumed for local fallthrough only'))
            if kind in ('B','B.cond','CBZ','CBNZ','TBZ','TBNZ'):successors.append((target,'taken'))
            if kind in ('RET','BR'):edges.append(dict(site=hex(pc),kind=kind,target=None,inside=False))
            if kind not in ('B','BR','RET'):successors.append((pc+4,'fallthrough'))
        elif word&0xffe0001f in (0xd4200000,0xd4000001,0xd4400000):
            edges.append(dict(site=hex(pc),target=None,kind='trap_or_supervisor_boundary',inside=False))
        elif (word>>25)&15 in (10,11):
            # Unhandled branch/system encodings are exits, never silently linear.
            unknowns.append(dict(site=hex(pc),word=hex(word),reason='unmodeled branch/system encoding'))
            edges.append(dict(site=hex(pc),target=None,kind='unknown_control',inside=False))
        else:successors.append((pc+4,'fallthrough'))
        for target,kind in successors:
            inside=start<=target<stop and target%4==0
            edges.append(dict(site=hex(pc),target=hex(target),kind=kind,inside=inside))
            if inside:pending.append(target)
    return dict(reachable_instruction_count=len(seen),reachable_addresses=[hex(p) for p in sorted(seen)],
                instruction_edges=edges,calls=calls,unknown_control=unknowns,
                complete_body_proven=False,exception_edges_recovered=False,
                assumptions=['All calls may return for this local graph; nonreturning/throwing callees are not classified.',
                             'A next-metadata-start/capped range is an inspection bound, not body extent proof.',
                             'State dispatch/yield/field semantics have not been recovered by this graph extraction.'])


def validate_entry(elf,meta,module,machine):
    typedef=machine['type_definition_index']
    nav.require(0<=typedef<len(meta.types),'inventory owner type outside metadata')
    nav.require(module['type_start']<=typedef<module['type_start']+module['type_count'],'inventory owner outside game image')
    typ=meta.types[typedef]
    name=(typ['namespace']+'.'+typ['name']).lstrip('.')
    traw=struct.unpack_from('<16I8H2I',meta.data,meta.tables['types']['offset']+typedef*88)
    nav.require(machine['name']==name and machine['type_token']==f'0x{traw[25]:08x}','inventory type identity mismatch')
    method=machine['move_next'];idx=method['method_definition_index'];table=meta.tables['methods']
    nav.require(0<=idx<table['count'],'inventory method outside metadata')
    raw=struct.unpack_from('<7I4H',meta.data,table['offset']+idx*36)
    nav.require(raw[1]==typedef and meta.string(raw[0])=='MoveNext' and                method['token']==f'0x{raw[6]:08x}' and raw[10]==method['parameter_count'],                'inventory method ownership/identity mismatch')
    rid=raw[6]&0xffffff
    nav.require(0<rid<=module['method_count'],'inventory method RID outside module')
    pointer=elf.pointer(module['method_pointers_vaddr']+(rid-1)*8)
    expected=int(method['vaddr'],16) if method.get('vaddr') else 0
    nav.require(pointer==expected,'inventory null/non-null codegen pointer mismatch')
    return pointer


def run(root,inventory,output,report,cap):
    before=time.monotonic();source=root/'out/recon/il2cpp'
    binary=(source/'libil2cpp.so').read_bytes();metadata=(source/'global-metadata.dat').read_bytes();nav.verify_pair(binary,metadata)
    index=source/'metadata_methods.jsonl'
    elf,meta=nav.Elf(binary),nav.Metadata(metadata)
    rows,resolve=nav.load_index(index,elf,meta)
    starts=sorted({int(r['vaddr'],16) for r in rows if r.get('vaddr')})
    image,image_methods=meta.image_methods('Assembly-CSharp.dll')
    module=dict(nav.codegen_module(elf,'Assembly-CSharp.dll',len(image_methods)),type_start=image['type_start'],type_count=image['type_count'])
    inventory_bytes=inventory.read_bytes();machines=[json.loads(l) for l in inventory_bytes.splitlines()]
    nav.require(len({m['type_definition_index'] for m in machines})==len(machines),'duplicate machine identity')
    output.mkdir(parents=True,exist_ok=True);records=[]
    for machine in machines:
        validate_entry(elf,meta,module,machine)
        method=machine['move_next'];address=method.get('vaddr')
        record=dict(type_definition_index=machine['type_definition_index'],type_token=machine['type_token'],
                    owner=machine['owner'],name=machine['name'],kind=machine['kind'],scope_disposition=machine['scope_disposition'],
                    method=method,semantic_completion=False,can_accept_machine=False)
        if not address:
            record.update(status='unresolved_pointer',unknown='MethodSpec/generic/native mapping required; no bytes fabricated.')
        else:
            start=int(address,16)
            candidates=resolve(start)
            exact=[r for r in candidates if r['method_definition_index']==method['method_definition_index']]
            nav.require(len(exact)==1 and exact[0]['token']==method['token'],'machine entry identity mismatch')
            position=bisect.bisect_right(starts,start)
            next_start=starts[position] if position<len(starts) else None
            stop=min(next_start,start+cap) if next_start is not None else start+cap
            offset=elf.offset(start,stop-start);data=binary[offset:offset+stop-start]
            graph=flow(elf,start,stop,resolve)
            raw=output/(machine['type_token'][2:]+'.bin')
            raw.write_bytes(data)
            record.update(status='bounded_flow_only',inspection=dict(start=address,exclusive_stop=hex(stop),bytes=len(data),
                          sha256=nav.sha(data),raw_path=str(raw.relative_to(root)),next_metadata_start=hex(next_start) if next_start else None,
                          capped=next_start is None or next_start>start+cap,complete_body_proven=False),flow=graph)
        path=output/(machine['type_token'][2:]+'.json')
        nav.atomic_json(path,record)
        records.append(dict(type_token=machine['type_token'],owner=machine['owner'],kind=machine['kind'],status=record['status'],
                            path=str(path.relative_to(root)),sha256=nav.sha(path.read_bytes()),
                            bytes=record.get('inspection',{}).get('bytes',0),
                            reachable_instructions=record.get('flow',{}).get('reachable_instruction_count',0),
                            capped=record.get('inspection',{}).get('capped',False),semantic_completion=False))
    result=dict(schema_version=1,scope='Bounded MoveNext local-flow evidence for every interface inventory entry; lifecycle semantics not recovered',
                native_sha256=nav.sha(binary),metadata_sha256=nav.sha(metadata),index_sha256=nav.sha(index.read_bytes()),
                inventory=dict(path=str(inventory.relative_to(root)),sha256=nav.sha(inventory_bytes)),
                producer_sha256=nav.sha(Path(__file__).read_bytes()),navigation_sha256=nav.sha(Path(nav.__file__).read_bytes()),
                counts=dict(machines=len(records),statuses=dict(Counter(r['status'] for r in records)),
                            inspection_bytes=sum(r['bytes'] for r in records),reachable_instructions=sum(r['reachable_instructions'] for r in records),
                            capped=sum(r['capped'] for r in records),semantically_accepted=0),
                records=records,duration_seconds=round(time.monotonic()-before,3),semantic_completion=False,can_close_t026=False,
                queue_modified=False,game_executed=False,
                limits=['Direct-interface inventory is not proof of all inherited/manual/generated machines or all callbacks/events.',
                        'Raw/code graphs do not establish field/memory effects, yield values, async builder semantics, errors, cancellation or temporal behavior.',
                        'Excluded QA/lobby entries remain present for coverage; no scope exclusion is expanded here.'])
    nav.atomic_json(report,result);return result

if __name__=='__main__':
    p=argparse.ArgumentParser(description=__doc__)
    p.add_argument('--root',type=Path,default=nav.ROOT)
    p.add_argument('--inventory',type=Path,default=nav.ROOT/'out/recon/t026-inventory/machines.jsonl')
    p.add_argument('--output',type=Path,default=nav.ROOT/'out/recon/t026-flow-census')
    p.add_argument('--report',type=Path,default=nav.ROOT/'reports/recon/t026_flow_census.json')
    p.add_argument('--cap',type=int,default=65536)
    a=p.parse_args();nav.require(a.cap>=4 and a.cap%4==0,'cap must be positive aligned bytes')
    r=run(a.root,a.inventory,a.output,a.report,a.cap);print(r['counts'])
