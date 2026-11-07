"""Bounded static evidence for LoadScene's closure; does not execute the game."""
import argparse
from pathlib import Path

import recon_navigation as nav


def probe(source):
    binary = (source / 'libil2cpp.so').read_bytes()
    metadata = (source / 'global-metadata.dat').read_bytes()
    nav.verify_pair(binary, metadata)
    elf, meta = nav.Elf(binary), nav.Metadata(metadata)
    rows, resolve = nav.load_index(source / 'metadata_methods.jsonl', elf, meta)
    start, stop = 0x2073488, 0x207378c
    owner = resolve(start)
    nav.require(len(owner) == 1 and owner[0]['token'] == '0x0600570f'
                and owner[0]['name'] == '<LoadScene>b__0', 'callback identity mismatch')
    nav.require(min(int(r['vaddr'], 16) for r in rows
                    if r['vaddr'] and int(r['vaddr'], 16) > start) == stop,
                'next method boundary mismatch')
    literal_got = nav.adrp_ldr(elf, 0x20734a0, 0x20734a8)
    home = nav.literal(meta, nav.metadata_usage(elf, literal_got['got_vaddr']))
    nav.require(home['literal'] == 'Home', 'scene guard literal mismatch')
    controls = []
    for address in range(start, stop, 4):
        control = nav.branch(address, nav.word(elf, address))
        if not control:
            continue
        target = control.get('target')
        names = resolve(target) if target is not None else []
        controls.append({'site': hex(address), **control, 'metadata_targets': names})
    offset = elf.offset(start, stop - start)
    return {
        'schema_version': 1,
        'scope': 'bounded static callback probe; no runtime equivalence claim',
        'native_sha256': nav.sha(binary), 'metadata_sha256': nav.sha(metadata),
        'index_sha256': nav.sha((source / 'metadata_methods.jsonl').read_bytes()),
        'method': owner[0], 'start': hex(start), 'exclusive_stop': hex(stop),
        'window_sha256': nav.sha(binary[offset:offset + stop - start]),
        'scene_guard_literal': home, 'control_encodings': controls,
        'limitations': [
            'Linear window ending at next metadata start is not a complete CFG/body proof.',
            'Metadata targets revalidated; unresolved helpers remain unnamed.',
            'Field names require declarations; shared static flag semantics remain open.',
            'No multiplayer operation, target execution or queue acceptance performed.',
        ],
    }


if __name__ == '__main__':
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--source', type=Path, default=nav.ROOT / 'out/recon/il2cpp')
    parser.add_argument('--report', type=Path,
                        default=nav.ROOT / 'out/recon/load_scene_callback.json')
    args = parser.parse_args()
    result = probe(args.source)
    nav.atomic_json(args.report, result)
    print(f"Callback {result['start']}: {len(result['control_encodings'])} control encodings; {args.report}")
