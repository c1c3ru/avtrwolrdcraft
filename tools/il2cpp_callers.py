#!/usr/bin/env python3
"""Acha chamadores diretos (BL/B imediato) de um ou mais enderecos no libil2cpp.so e os nomeia pelo indice de metodos.

Uso: python3 -I tools/il2cpp_callers.py <libil2cpp.so> <dir out/recon/il2cpp> <addr_hex> [addr_hex ...]
Varre a secao `il2cpp` (codigo dos metodos gerados) palavra a palavra: BL = 0x94000000|imm26, B = 0x14000000|imm26 (alvo = pc + imm26*4).
Cada chamador e atribuido ao metodo cujo vaddr inicial e o maior <= endereco (aproximacao; metodos sem indice ficam como ?).
Nao ve chamadas indiretas (blr/vtable/delegate). Requer pyelftools. Estatico.
"""
import bisect
import json
import struct
import sys

from elftools.elf.elffile import ELFFile


def main():
    so_path, idx_dir, addrs = sys.argv[1], sys.argv[2], [int(a, 16) for a in sys.argv[3:]]
    e = ELFFile(open(so_path, "rb"))
    sec = e.get_section_by_name("il2cpp")
    data = open(so_path, "rb").read()[sec["sh_offset"]:sec["sh_offset"] + sec["sh_size"]]
    base = sec["sh_addr"]

    starts, names = [], []
    rows = []
    for fn in ("assembly_csharp_methods", "UnityEngine.CoreModule_methods"):
        for line in open(f"{idx_dir}/{fn}.jsonl"):
            d = json.loads(line)
            if d.get("vaddr"):
                rows.append((int(d["vaddr"], 16), f"{d['declaring_type']}.{d['name']}"))
    rows.sort()
    starts = [r[0] for r in rows]
    names = [r[1] for r in rows]

    want = set(addrs)
    hits = {a: [] for a in addrs}
    words = struct.unpack(f"<{len(data) // 4}I", data[:len(data) // 4 * 4])
    for i, w in enumerate(words):
        op = w & 0xFC000000
        if op not in (0x94000000, 0x14000000):
            continue
        imm = w & 0x03FFFFFF
        if imm & 0x02000000:
            imm -= 0x04000000
        pc = base + i * 4
        tgt = pc + imm * 4
        if tgt in want:
            k = bisect.bisect_right(starts, pc) - 1
            hits[tgt].append((pc, "BL" if op == 0x94000000 else "B", names[k] if k >= 0 else "?"))
    for a in addrs:
        print(f"== chamadores de {hex(a)}: {len(hits[a])}")
        for pc, kind, who in hits[a]:
            print(f"   {hex(pc)} {kind} {who}")


if __name__ == "__main__":
    main()
