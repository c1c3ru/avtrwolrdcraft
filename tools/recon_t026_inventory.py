#!/usr/bin/env python3
"""Metadata/interface-led T026 discovery. Produces planning, never semantic acceptance.

Keeps historic name-scan records, explicit QA/lobby exclusions, and unresolved
scope leads. Interfaces/owners come from raw metadata plus pinned registration.
"""
import argparse
from collections import Counter,defaultdict
import json
from pathlib import Path
import struct
import time

import recon_navigation as nav
import recon_t025_generics as registration

INTERFACES={'System.Collections.IEnumerator','System.Collections.Generic.IEnumerator`1',
            'System.Runtime.CompilerServices.IAsyncStateMachine','System.Collections.Generic.IAsyncEnumerator`1'}
REQUIRED=('entry_factory','all_states','yield_wait_order','completion','error','cancellation_disposal',
          'current_reset','callbacks_callees','memory_effects','exceptions','temporal_assumptions','independent_validation')


def scope_disposition(owner,typedef):
    if owner=='LobbyHelloWorld' or owner.startswith('PWC.QA.') or owner.startswith('RTA'):
        return 'excluded_reimplementation_scope_only','Existing explicit QA/automation/lobby exclusion; retain inventory and review dependencies.'
    if typedef==629 and owner=='PazuCore.Utils':
        return 'required_concrete_helper','Concrete loading dependency: ExecuteNextFrameCoroutine; not a blanket SDK inclusion.'
    if owner.startswith(('Game.Level','PWC.Level','PWC.World','Game.Home','Game.Store')):
        return 'required_historical_169','Matches historical gameplay/world/home/store prefix grouping; each semantic contract still pending.'
    if owner.startswith(('Game.','PWC.')) and not owner.startswith('PWC.Multiplayer.'):
        return 'required_additional_game_candidate','Game/PWC owner outside historical169 retained pending; missing prefix membership is not exclusion.'
    if owner.startswith(('PazuCore.','Google.','Firebase.','PWC.Multiplayer.')):
        return 'conditional_dependency_pending','SDK/multiplayer kept pending dependency disposition; cannot silently exclude required helpers.'
    return 'unresolved_scope_pending','No explicit scope exclusion established; resolve ownership/reachability/dependencies before closure.'


class MetadataTypes:
    def __init__(self,elf,meta,tables):
        self.elf,self.meta=elf,meta
        self.native_types=int(tables['types']['vaddr'],16);self.native_count=tables['types']['count']
        self.interface_start,self.interface_bytes=struct.unpack_from('<II',meta.data,136)
        nav.require(self.interface_bytes%4==0 and self.interface_start+self.interface_bytes<=len(meta.data),'interface table bounds')
        self.raw=[struct.unpack_from('<16I8H2I',meta.data,meta.tables['types']['offset']+i*88) for i in range(len(meta.types))]
        self.byval={}
        for i,row in enumerate(self.raw):self.byval.setdefault(row[2],[]).append(i)
        self.cache={}

    def name(self,idx):
        t=self.meta.types[idx];return (t['namespace']+'.'+t['name']).lstrip('.')

    def pointer_type(self,pointer):
        data,bits=struct.unpack_from('<QI',self.elf.data,self.elf.offset(pointer,12));code=(bits>>16)&255
        if code==0x15:
            generic_class=self.elf.pointer(pointer)
            definition=self.pointer_type(self.elf.pointer(generic_class))
            return dict(**{k:v for k,v in definition.items() if k not in ('type_code','type_pointer')},
                        type_code=hex(code),type_pointer=hex(pointer),generic_class=hex(generic_class),
                        generic_arguments='Not decoded; definition identity only.')
        nav.require(code in (0x12,0x11,0x0e,0x1c) and 0<=data<len(self.meta.types),'unsupported interface/base native type')
        return dict(type_definition_index=data,name=self.name(data),type_code=hex(code),type_pointer=hex(pointer))

    def native_type(self,index):
        nav.require(0<=index<self.native_count,'native type outside registration')
        if index not in self.cache:
            self.cache[index]=self.pointer_type(self.elf.pointer(self.native_types+8*index))
        return dict(self.cache[index],native_type_index=index)

    def owner_chain(self,idx):
        chain=[];seen=set()
        while True:
            nav.require(idx not in seen,'declaring owner cycle');seen.add(idx);chain.append(idx)
            declaring=self.raw[idx][3]
            if declaring==0xffffffff:break
            candidates=self.byval.get(declaring,[])
            nav.require(len(candidates)==1,'declaring owner ambiguous');idx=candidates[0]
        return chain

    def interfaces(self,idx):
        row=self.raw[idx]
        nav.require((row[13]+row[22])*4<=self.interface_bytes or row[22]==0,'interface list outside metadata')
        result=[]
        for local in range(row[22]):
            offset=self.interface_start+(row[13]+local)*4;index=struct.unpack_from('<I',self.meta.data,offset)[0]
            result.append(dict(self.native_type(index),metadata_offset=hex(offset)))
        return result


def build(elf,meta,index_path,historical):
    reg=registration.verify(elf,meta);types=MetadataTypes(elf,meta,reg['tables'])
    image,raw_methods=meta.image_methods('Assembly-CSharp.dll');_,resolve=nav.load_index(index_path,elf,meta)
    bytype=defaultdict(list)
    for m in raw_methods:bytype[m['declaring_type_index']].append(m)
    historical_by_va={r['vaddr']:r for r in historical};nav.require(len(historical_by_va)==len(historical),'duplicate historical address')
    machines=[];unknowns=[];events=[];closures=[];native_interface_counts=Counter()
    event_start,event_bytes=struct.unpack_from('<II',meta.data,32)
    nav.require(event_bytes%24==0 and event_start+event_bytes<=len(meta.data),'events table bounds')
    for idx in range(image['type_start'],image['type_start']+image['type_count']):
        row=types.raw[idx];chain=types.owner_chain(idx);owner=types.name(chain[-1]);ownertype=chain[-1]
        name=types.name(idx)
        try:ifs=types.interfaces(idx)
        except (ValueError,IndexError,struct.error) as exc:
            unknowns.append(dict(type_definition_index=idx,name=name,question='Interface decoding unresolved: '+str(exc)));ifs=[]
        found={i['name'] for i in ifs}&INTERFACES
        if found:
            native_interface_counts.update(found)
            methods=[]
            for m in bytype[idx]:
                # Revalidate every nonnull address through current raw metadata/codegen joins.
                # Address lookup is by definition, never by repeated short generated name.
                methods.append(dict(m))
            machine=dict(type_definition_index=idx,type_token=f'0x{row[25]:08x}',name=name,
                         owner=owner,owner_type_definition_index=ownertype,
                         owner_chain=[dict(index=i,name=types.name(i),byval_type_index=types.raw[i][2]) for i in chain],
                         interfaces=ifs,kind='async_metadata_interface' if 'System.Runtime.CompilerServices.IAsyncStateMachine' in found
                         else 'async_enumerator_metadata_interface' if 'System.Collections.Generic.IAsyncEnumerator`1' in found
                         else 'enumerator_metadata_interface',methods=methods,classification='STATIC_metadata_interface_identity_not_recovered_logic')
            machine['scope_disposition'],machine['scope_reason']=scope_disposition(owner,idx)
            machine['semantic_completion']=False;machines.append(machine)
        for local in range(row[19]):
            ev_idx=row[10]+local;nav.require(0<=ev_idx<event_bytes//24,'event outside metadata')
            off=event_start+ev_idx*24;raw=struct.unpack_from('<6I',meta.data,off)
            accessors=[]
            for operation,relative_method in zip(('add','remove','raise'),raw[2:5]):
                if relative_method==0xffffffff:continue
                nav.require(relative_method<row[16],'event relative accessor outside declaring type')
                method_idx=row[9]+relative_method
                matches=[m for m in bytype[idx] if m['method_definition_index']==method_idx]
                nav.require(len(matches)==1,'event accessor method identity mismatch')
                accessors.append(dict(operation=operation,method=matches[0]))
            events.append(dict(event_index=ev_idx,declaring_type=name,owner=owner,name=meta.string(raw[0]),
                               token=f'0x{raw[5]:08x}',metadata_offset=hex(off),accessors=accessors,
                               status='STATIC_event_declaration_not_subscriber_lifetime_contract'))
        short=meta.types[idx]['name']
        if short=='<>c' or short.startswith('<>c__DisplayClass'):
            closures.append(dict(type_definition_index=idx,type_token=f'0x{row[25]:08x}',name=name,owner=owner,
                                 method_definition_indices=[m['method_definition_index'] for m in bytype[idx]],
                                 classification='INFERRED_name_shape_closure_candidate_not_complete_callback_universe'))
    # Enrich only selected machine methods with current codegen pointer identities.
    cached=[json.loads(l) for l in index_path.read_bytes().splitlines()]
    cached_by_definition={r['method_definition_index']:r for r in cached if r['image']=='Assembly-CSharp.dll'}
    for machine in machines:
        for m in machine['methods']:
            cached_row=cached_by_definition.get(m['method_definition_index'])
            nav.require(cached_row is not None,'machine method missing from cached index')
            if cached_row.get('vaddr'):
                matches=resolve(int(cached_row['vaddr'],16))
                nav.require(any(r['method_definition_index']==m['method_definition_index'] and r['token']==m['token'] for r in matches),'machine codegen join mismatch')
            m['vaddr']=cached_row.get('vaddr');m['body_status']='UNKNOWN_not_recovered_by_inventory'
        moves=[m for m in machine['methods'] if m['name']=='MoveNext']
        nav.require(len(moves)==1,'machine MoveNext identity ambiguous or absent')
        machine['move_next']=moves[0]
        history=historical_by_va.get(moves[0]['vaddr'])
        if history:
            nav.require(history['owner']==machine['owner'] and history['state_machine']==machine['name'],'historic owner/machine mismatch')
        machine['historical_record']=history
        if history is None and machine['scope_disposition']=='required_historical_169':
            machine['scope_disposition']='required_additional_game_candidate'
            machine['scope_reason']='New metadata-interface discovery in gameplay prefix family, absent from historical169; retained required/pending.'
    mapped={m['move_next']['vaddr'] for m in machines};unmatched=[r for r in historical if r['vaddr'] not in mapped]
    return dict(machines=machines,events=events,closure_candidates=closures,interface_decode_unknowns=unknowns,
                historical_unmatched=unmatched,registration=reg['registration'],image=image,
                interface_detection_counts=dict(native_interface_counts),metadata_type_count=image['type_count'])


def planning_specs(machines,refs):
    tasks=[]
    for m in machines:
        identifier='T026/STATE_MACHINE/'+('execute-next-frame' if m['type_definition_index']==629 else m['type_token'][2:])
        path='out/recon/tasks/'+identifier
        tasks.append(dict(id=identifier,parent_id='T026',title='Reconcile lifecycle '+m['owner']+'::'+m['name'],role='lógica',state='pending',
                          dependencies=['T022','T023','T024','T025'],planning_seed=False,evidence_refs=[],attempts=[],owner=None,lease=None,review=None,unknown_ids=[],
                          scope=dict(type_definition_index=m['type_definition_index'],type_token=m['type_token'],owner=m['owner'],
                                     machine=m['name'],kind=m['kind'],disposition=m['scope_disposition'],reason=m['scope_reason']),
                          input_refs=refs,allowed_paths=[path+'/**'],outputs=[path+'/result.json'],
                          resource_locks=['task-output:'+identifier],
                          acceptance='For required lifecycle certification: entry and all states/yields, completion/error/cancel/Dispose/Current/Reset, memory/callback/dependency effects and temporal boundaries explained with pinned bytes and independent review. For an excluded candidate, review only the existing scope exclusion and prove no required dependency is hidden; do not fabricate a semantic lifecycle contract.',
                          questions=['Which original lifecycle/async interface does this type implement?','Does this candidate belong to required scope or a justified existing exclusion?','Which body, scheduler, callback and exception gaps remain?'],
                          next_action='Planning only; reconcile existing child IDs, prerequisites, paths and scope before importing or claiming.'))
    return dict(schema_version=1,kind='child_planning_specs',tasks=tasks,
                import_limit='Not imported. All449 records remain pending planning; execute-next-frame may already exist and must be reconciled, never duplicated.',
                semantic_completion=False)


def produce(source,root,output,report):
    begin=time.monotonic();native=source/'libil2cpp.so';metadata=source/'global-metadata.dat';index=source/'metadata_methods.jsonl'
    binary=native.read_bytes();md=metadata.read_bytes();index_bytes=index.read_bytes();nav.verify_pair(binary,md)
    history_path=root/'out/recon/tasks/T032/coroutines.jsonl';history_bytes=history_path.read_bytes();history=[json.loads(l) for l in history_bytes.splitlines()]
    result=build(nav.Elf(binary),nav.Metadata(md),index,history)
    nav.require(index.read_bytes()==index_bytes,'method index changed during inventory')
    nav.require(history_path.read_bytes()==history_bytes,'historical inventory changed during inventory')
    output.mkdir(parents=True,exist_ok=True)
    refs=[dict(path=str(p.relative_to(root)),sha256=nav.sha(content)) for p,content in [(native,binary),(metadata,md),(index,index_bytes),(history_path,history_bytes)]]
    for relative in ['docs/RECON_COROUTINES.md','docs/AVATAR_WORLD_MASTER_PLAN.md','reports/recon/loading_fade_contract.json']:
        path=root/relative;refs.append(dict(path=relative,sha256=nav.sha(path.read_bytes())))
    artifacts={}
    for key in ['machines','events','closure_candidates','interface_decode_unknowns','historical_unmatched']:
        path=output/(key+'.jsonl');data=''.join(json.dumps(r,ensure_ascii=False,sort_keys=True)+'\n' for r in result[key]).encode();path.write_bytes(data)
        artifacts[key]=dict(path=str(path.relative_to(root)),sha256=nav.sha(data),records=len(result[key]))
    manifest=planning_specs(result['machines'],refs);path=output/'child_specs.json';nav.atomic_json(path,manifest)
    artifacts['child_specs']=dict(path=str(path.relative_to(root)),sha256=nav.sha(path.read_bytes()),tasks=len(manifest['tasks']))
    machines=result['machines'];historic=[m for m in machines if m['historical_record']];extra=[m for m in machines if not m['historical_record']]
    report_data=dict(schema_version=1,scope='Assembly-CSharp raw interfaces/owners, historical437 reconciliation and pending lifecycle planning. No semantic acceptance.',
                     inputs=refs,producer_sha256=nav.sha(Path(__file__).read_bytes()),
                     helpers_sha256={Path(m.__file__).name:nav.sha(Path(m.__file__).read_bytes()) for m in (nav,registration)},
                     counts=dict(metadata_types=result['metadata_type_count'],historical_records=len(history),interface_machine_types=len(machines),
                                 kinds=dict(Counter(m['kind'] for m in machines)),historical_kinds=dict(Counter(m['kind'] for m in historic)),
                                 newly_detected=len(extra),historical_unmatched=len(result['historical_unmatched']),
                                 scope_dispositions=dict(Counter(m['scope_disposition'] for m in machines)),
                                 historical_169=sum(m['scope_disposition']=='required_historical_169' for m in machines),
                                 events=len(result['events']),closure_candidates=len(result['closure_candidates']),interface_decode_unknowns=len(result['interface_decode_unknowns'])),
                     new_machine_identities=[dict(type_definition_index=m['type_definition_index'],owner=m['owner'],name=m['name'],kind=m['kind'],scope_disposition=m['scope_disposition']) for m in extra],
                     artifacts=artifacts,registration=result['registration'],semantic_completion=False,can_close_t026=False,
                     state_machine_discovery_complete=False,event_and_callback_discovery_complete=False,
                     queue_modified=False,game_executed=False,
                     corrections=['Historical all437 are IEnumerator claim is false: original metadata includes IAsyncStateMachine types. No absence-of-async inference from narrow call scans is accepted.',
                                  'Historical169 remains one prefix-defined subset, not a complete required game universe. Other Game/PWC candidates remain pending; QA/lobby exclusions alone are preserved explicitly.'],
                     closure_criteria=list(REQUIRED),
                     remaining_universe=['Inherited-interface-only/manual machines not directly declaring a recognized interface require further inventory; direct interfaces alone are not global completeness.',
                                         'Metadata event declarations are not actual subscriber lists or lifecycle proofs; registration/removal/callback targets and effects need child contracts.',
                                         'Closure list uses name shapes only and is not complete for callbacks/local functions/delegates/reflection/native scheduler hooks.',
                                         'SDK/multiplayer helpers enter as concrete required dependencies; unresolved ownership/reachability is not a scope exclusion.',
                                         'All machine child specs remain planning pending; accepted bodies and whole temporal/state/error/cancel contracts are not created by enumeration.'],
                     duration_seconds=round(time.monotonic()-begin,3))
    nav.atomic_json(report,report_data);return report_data


if __name__=='__main__':
    p=argparse.ArgumentParser(description=__doc__)
    p.add_argument('--root',type=Path,default=nav.ROOT);p.add_argument('--source',type=Path,default=nav.ROOT/'out/recon/il2cpp')
    p.add_argument('--output',type=Path,default=nav.ROOT/'out/recon/t026-inventory');p.add_argument('--report',type=Path,default=nav.ROOT/'reports/recon/t026_inventory.json')
    a=p.parse_args();r=produce(a.source,a.root,a.output,a.report);print(json.dumps(r['counts'],ensure_ascii=False))
