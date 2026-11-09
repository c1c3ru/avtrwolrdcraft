#!/usr/bin/env python3
"""Verify four bounded OnDestroy -> scene-event remove edges in shipped IL2CPP."""
import argparse
import bisect
from pathlib import Path
import subprocess
import time

import recon_scene_subscribers as signup

nav = signup.nav
# Paired with SPECS[0:4]; explicit MethodInfo and argument-flow sites from LLVM.
SPECS = [
    dict(pair=0, caller_token='0x06005602', start=0x20694d4,
         ref=(0x20694e8, 0x20694f8), reg=20, ctor=0x2069584, site=0x206959c,
         remove_token='0x060056f1', remove=0x2069640,
         anchors={0x2069500:0xaa0003f3, 0x2069574:0xf9400282, 0x2069578:0xaa1303e1,
                  0x206957c:0xaa1f03e3, 0x2069580:0xaa0003f4, 0x2069598:0xaa1403e0}),
    dict(pair=1, caller_token='0x06006e3f', start=0x21e0738,
         ref=(0x21e07a0, 0x21e07b0), reg=20, ctor=0x21e080c, site=0x21e0828,
         remove_token='0x060056f3', remove=0x20720c8,
         anchors={0x21e074c:0xaa0003f3, 0x21e07fc:0xf9400282, 0x21e0800:0xaa1303e1,
                  0x21e0804:0xaa1f03e3, 0x21e0808:0xaa0003f4, 0x21e0820:0xaa1403e0,
                  0x21e0824:0xaa1f03e1}),
    dict(pair=2, caller_token='0x06008490', start=0x2310ee4,
         ref=(0x231113c, 0x2311154), reg=22, ctor=0x23111e0, site=0x2311204,
         remove_token='0x060056f3', remove=0x20720c8,
         anchors={0x2310f0c:0xaa0003f3, 0x23111d0:0xf94002c2, 0x23111d4:0xaa1303e1,
                  0x23111d8:0xaa1f03e3, 0x23111dc:0xaa0003f4, 0x23111fc:0xaa1403e0,
                  0x2311200:0xaa1f03e1}),
    dict(pair=3, caller_token='0x06008490', start=0x2310ee4,
         ref=(0x2311168, 0x231117c), reg=21, ctor=0x2311220, site=0x231122c,
         remove_token='0x060056f5', remove=0x2072280,
         anchors={0x2310f0c:0xaa0003f3, 0x2311210:0xf94002a2, 0x2311214:0xaa1303e1,
                  0x2311218:0xaa1f03e3, 0x231121c:0xaa0003f4, 0x2311224:0xaa1403e0,
                  0x2311228:0xaa1f03e1}),
]


def verify_edges(elf, meta, index):
    # Revalidate original registrations in this same byte pair, not a saved report.
    additions, _, rows, resolve = signup.verify_edges(elf, meta, index)
    starts = sorted({int(r['vaddr'], 16) for r in rows if r.get('vaddr')})
    edges, windows = [], {}
    for spec in SPECS:
        addition = additions[spec['pair']]
        owner = addition['caller']['declaring_type']
        caller = signup.method(resolve, ('Assembly-CSharp.dll', owner, 'OnDestroy', spec['caller_token'], spec['start']))
        removal = signup.method(resolve, ('Assembly-CSharp.dll', 'PWC.GameSceneManager',
                               addition['event_add_method']['name'].replace('add_', 'remove_', 1),
                               spec['remove_token'], spec['remove']))
        nav.require(caller['parameter_count'] == 0 and removal['parameter_count'] == 1, 'unexpected method arity')
        ref = nav.adrp_ldr(elf, *spec['ref'])
        nav.require(ref['destination_register'] == spec['reg'], 'handler reference register mismatch')
        usage = nav.metadata_usage(elf, ref['got_vaddr'])
        nav.require(usage['kind'] == 3 and usage['index'] == addition['handler']['method_definition_index'],
                    'remove handler differs from registered MethodDef')
        for site, opcode in spec['anchors'].items():
            nav.expect(elf, site, opcode)
        for site, target in [(spec['ctor'], signup.ACTION_CTOR[4]), (spec['site'], spec['remove'])]:
            nav.require(nav.branch(site, nav.word(elf, site)) == {'kind':'BL', 'target':target}, 'remove/constructor branch mismatch')
        stop = starts[bisect.bisect_right(starts, spec['start'])]
        nav.require(spec['start'] <= min(*spec['ref'], *spec['anchors']) and spec['site'] < stop,
                    'sites outside bounded OnDestroy window')
        offset = elf.offset(spec['start'], stop-spec['start'])
        key = owner+'.OnDestroy'
        windows[key] = dict(start=hex(spec['start']), exclusive_stop=hex(stop),
                            sha256=nav.sha(elf.data[offset:offset+stop-spec['start']]),
                            limit='Next metadata start bounds inspection, not complete CFG or method proof.')
        sites = sorted({*spec['anchors'], *spec['ref'], spec['ctor'], spec['site']})
        edges.append(dict(classification='STATIC_paired_remove_call_not_runtime_observed', event=addition['event'],
                          caller=caller, handler=addition['handler'], remove_method=removal,
                          registration_site=addition['registration_branch']['site'], removal_site=hex(spec['site']),
                          target_object='this saved in x19, also used by paired Awake registration',
                          handler_metadata_usage=usage, constructor_method=signup.method(resolve, signup.ACTION_CTOR),
                          raw_anchors=[signup.raw_instruction(elf, s) for s in sites]))
    return edges, windows


def produce(source, output, report, objdump):
    before = time.monotonic()
    binary = (source/'libil2cpp.so').read_bytes()
    metadata = (source/'global-metadata.dat').read_bytes()
    nav.verify_pair(binary, metadata)
    edges, windows = verify_edges(nav.Elf(binary), nav.Metadata(metadata), source/'metadata_methods.jsonl')
    output.mkdir(parents=True, exist_ok=True)
    commands = []
    for key, window in windows.items():
        cmd = [str(objdump), '-d', '--start-address='+window['start'], '--stop-address='+window['exclusive_stop'], str(source/'libil2cpp.so')]
        start = time.monotonic()
        result = subprocess.run(cmd, capture_output=True, text=True, timeout=30)
        nav.require(result.returncode == 0, 'LLVM failed: '+result.stderr)
        path = output/(key+'.asm.txt')
        path.write_text(result.stdout, encoding='utf-8')
        commands.append(dict(command=cmd, returncode=result.returncode, duration_seconds=round(time.monotonic()-start,3),
                             output=str(path), sha256=nav.sha(path.read_bytes())))
    result = dict(schema_version=1, scope='Four paired stage-event removals across three OnDestroy windows.',
                  native_sha256=nav.sha(binary), metadata_sha256=nav.sha(metadata),
                  method_index_sha256=nav.sha((source/'metadata_methods.jsonl').read_bytes()),
                  producer_sha256=nav.sha(Path(__file__).read_bytes()),
                  helpers_sha256={Path(m.__file__).name:nav.sha(Path(m.__file__).read_bytes()) for m in (signup,nav)},
                  edges=edges, inspection_windows=windows, commands=commands,
                  duration_seconds=round(time.monotonic()-before,3), queue_modified=False, game_executed=False,
                  active_REA_target_used=False,
                  precondition='Normal execution reaches each guarded delegate construction and remove call.',
                  unknowns=['Unity OnDestroy execution, reachability and exception behavior are not observed.',
                            'Delegate equality and event accessor/library internals are not modeled: a remove call does not prove successful removal.',
                            'Lifetime, duplicate registrations, instance ordering and handler effects remain unknown.',
                            'No removal conclusion for the static activeSceneChanged subscription; not investigated here.',
                            'No full CFG or completeness claim; nine prior registration candidates remain open.'])
    nav.atomic_json(report, result)
    return result


if __name__ == '__main__':
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--source', type=Path, default=nav.ROOT/'out/recon/il2cpp')
    parser.add_argument('--output', type=Path, default=nav.ROOT/'out/recon/scene-unsubscribers')
    parser.add_argument('--report', type=Path, default=nav.ROOT/'reports/recon/scene_unsubscribers.json')
    parser.add_argument('--objdump', type=Path, default=Path.home()/'Unity/Hub/Editor/6000.6.6f1/Editor/Data/PlaybackEngines/AndroidPlayer/NDK/toolchains/llvm/prebuilt/linux-x86_64/bin/llvm-objdump')
    args = parser.parse_args()
    result = produce(args.source, args.output, args.report, args.objdump)
    print({'paired_remove_edges':len(result['edges']), 'windows':len(result['inspection_windows']), 'report':str(args.report)})
