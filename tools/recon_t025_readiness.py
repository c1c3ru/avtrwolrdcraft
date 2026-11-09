#!/usr/bin/env python3
"""Reconcile T025 scope without equating addresses/contracts to recovered logic.

Read-only against the live queue. Writes a complete Assembly-CSharp registry and
an acceptance audit; does not create/approve tasks or infer absent method kinds.
"""
import argparse
from collections import Counter
import json
from pathlib import Path

import recon_navigation as nav


REQUIRED = ('signature_abi', 'bytes_ranges', 'cfg', 'arguments_return', 'registers',
            'fields_offsets', 'memory', 'effects', 'callees_callbacks', 'exceptions',
            'coroutine_async', 'state_before_after', 'invalid_inputs', 'termination')


def task_rows(queue):
    tasks = queue['tasks']
    return list(tasks.values()) if isinstance(tasks, dict) else tasks


def reconcile(methods, queue):
    tasks = task_rows(queue)
    by_id = {t['id']: t for t in tasks}
    parent = by_id['T025']
    by_identity = {}
    children = [t for t in tasks if t.get('parent_id') == 'T025']
    unmatched = []
    keys = {(m['image'], m['token']) for m in methods}
    nav.require(len(keys) == len(methods), 'duplicate method identity in inventory')
    for child in children:
        m = child.get('scope', {}).get('method_identity', {})
        key = (m.get('image'), m.get('token'))
        if key not in keys:
            unmatched.append(child['id'])
        else:
            by_identity.setdefault(key, []).append(child)
    ledger = []
    for m in methods:
        matched = by_identity.get((m['image'], m['token']), [])
        ledger.append(dict(image=m['image'], token=m['token'], declaring_type=m['declaring_type'],
                           name=m['name'], parameter_count=m['parameter_count'], vaddr=m.get('vaddr'),
                           method_definition_index=m['method_definition_index'],
                           address_status='indexed_nonnull_not_body_proof' if m.get('vaddr') else 'unresolved_pointer_not_classified_as_abstract',
                           child_ids=[t['id'] for t in matched], child_states=[t['state'] for t in matched],
                           acceptance_status='requires_live_evidence_and_review_validation' if any(t['state']=='done' for t in matched)
                           else 'not_accepted'))
    deps = [{'id':d, 'state':by_id[d]['state']} for d in parent['dependencies']]
    summary = dict(indexed_methods=len(methods), indexed_nonnull_addresses=sum(bool(m.get('vaddr')) for m in methods),
                   indexed_null_pointers=sum(not m.get('vaddr') for m in methods),
                   distinct_nonnull_addresses=len({m['vaddr'] for m in methods if m.get('vaddr')}),
                   methods_with_children=sum(bool(r['child_ids']) for r in ledger),
                   methods_without_children=sum(not r['child_ids'] for r in ledger),
                   live_children=len(children), child_state_counts=dict(Counter(t['state'] for t in children)))
    blockers = []
    if any(d['state']!='done' for d in deps): blockers.append('Parent prerequisites not accepted: '+', '.join(d['id'] for d in deps if d['state']!='done'))
    if summary['methods_without_children']: blockers.append('Inventory entries without T025 children or reviewed scope disposition')
    if summary['indexed_null_pointers']: blockers.append('Null method pointers require classification/resolution; absence does not establish abstract or irrelevant code')
    if any(t['state']!='done' for t in children): blockers.append('Discovered child tasks remain unaccepted')
    if unmatched: blockers.append('Child method identity missing from inventory')
    # This gate deliberately never certifies semantics from a state-only audit.
    blockers.append('Independent semantic and hash validation of all required dossiers is not performed by this scope audit')
    return ledger, dict(schema_version=1, scope='Assembly-CSharp MethodDefs only; not a complete native/generic-instantiation universe',
                        queue_revision=queue.get('revision'), parent_state=parent['state'], dependencies=deps,
                        summary=summary, unmatched_children=unmatched, blockers=blockers,
                        required_dossier_fields=list(REQUIRED), can_close_t025=False, queue_modified=False,
                        limits=['Method index reused as a structural baseline; no bodies or generic instances recovered by enumeration.',
                                'No automatic done promotion; queue state and files alone do not establish semantic acceptance.',
                                'Third-party ownership, generated methods, shared code and non-metadata native methods require explicit scope reconciliation.'])


def run(root, report, registry):
    import fcntl
    queue_path = root/'reports/recon/tasks.json'
    index_path = root/'out/recon/il2cpp/assembly_csharp_methods.jsonl'
    # Shared lock cooperates with the live queue CLI's exclusive writer lock.
    with queue_path.with_suffix('.json.lock').open('a+') as lock:
        fcntl.flock(lock, fcntl.LOCK_SH)
        queue_bytes = queue_path.read_bytes()
        index_bytes = index_path.read_bytes()
        queue = json.loads(queue_bytes)
        methods = [json.loads(line) for line in index_bytes.splitlines()]
        ledger, result = reconcile(methods, queue)
        data = ''.join(json.dumps(r,ensure_ascii=False,sort_keys=True)+'\n' for r in ledger).encode()
        nav.require(index_path.read_bytes()==index_bytes, 'index changed during scope audit')
        nav.require(queue_path.read_bytes()==queue_bytes, 'queue changed during scope audit')
        # Immutable generation first; the report is the commit pointer. A failure
        # can leave an unreferenced generation, never replace a prior registry.
        destination = registry.with_name(registry.stem+'.'+nav.sha(data)+registry.suffix)
        destination.parent.mkdir(parents=True, exist_ok=True)
        if destination.exists():
            nav.require(destination.read_bytes()==data, 'immutable registry content mismatch')
        else:
            import tempfile
            with tempfile.NamedTemporaryFile(dir=destination.parent, delete=False) as f:
                f.write(data)
                temporary=Path(f.name)
            temporary.replace(destination)
        result['inputs']=[{'path':str(p.relative_to(root)), 'sha256':nav.sha(content)}
                          for p,content in ((queue_path,queue_bytes),(index_path,index_bytes))]
        result['registry']={'path':str(destination.relative_to(root)), 'sha256':nav.sha(data), 'records':len(ledger)}
        result['producer_sha256']=nav.sha(Path(__file__).read_bytes())
        result['publication']='Immutable registry generation; atomic report publishes snapshot. It is not a live queue monitor.'
        nav.atomic_json(report,result)
        return result


if __name__=='__main__':
    parser=argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--root',type=Path,default=nav.ROOT)
    parser.add_argument('--report',type=Path,default=nav.ROOT/'reports/recon/t025_readiness.json')
    parser.add_argument('--registry',type=Path,default=nav.ROOT/'out/recon/t025/method_registry.jsonl')
    a=parser.parse_args()
    r=run(a.root.resolve(),a.report,a.registry)
    print(json.dumps({'summary':r['summary'],'can_close_t025':r['can_close_t025']},ensure_ascii=False))
