#!/usr/bin/env python3
"""Quantos metodos de Assembly-CSharp usam entradas do bloco nao-token da tabela de usos de metadata (ver docs/RECON_IL2CPP_USAGE_TABLE_2026-11-24.md).

Para cada metodo, desmonta [vaddr, proximo_inicio) e acompanha `adrp xN, PAGE` seguido de `ldr xM, [xN, #off]`: PAGE+off e um slot da .got;
o slot aponta (relocacao) para uma entrada A da tabela. Conta metodos que carregam pelo menos um A dentro do bloco nao-token.
Heuristica: so enxerga o par adrp+ldr direto (padrao do IL2CPP), nao copias de registrador nem acessos indiretos.

uso: tools/venv/bin/python tools/recon_usage_impact.py [--data out/recon/il2cpp] [--limit N] [--json saida.json]
"""
import argparse, bisect, collections, json, struct, sys
from pathlib import Path
from capstone import Cs, CS_ARCH_ARM64, CS_MODE_ARM

HERE = Path(__file__).resolve().parent
sys.path.insert(0, str(HERE))
import recon_il2cpp as r  # noqa: E402


def main():
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument("--data", type=Path, default=HERE.parent / "out" / "recon" / "il2cpp")
    ap.add_argument("--limit", type=int, default=0)
    ap.add_argument("--json", type=Path)
    a = ap.parse_args()
    elf = r.Elf((a.data / "libil2cpp.so").read_bytes())
    got = next(s for s in elf.sections if s["name"] == ".got")
    data = next(s for s in elf.sections if s["name"] == ".data")
    # entradas nao-token alvo da .got
    nontoken = set()
    for v in range(got["vaddr"], got["vaddr"] + got["bytes"], 8):
        t = elf.relocations.get(v)
        if t is None or not (data["vaddr"] <= t < data["vaddr"] + data["bytes"]):
            continue
        x = struct.unpack_from("<Q", elf.data, elf.offset(t, 8))[0]
        if x != 0 and not (x < 2 ** 32 and x & 1):
            nontoken.add(t)
    rows_all = []
    for f in a.data.glob("*_methods.jsonl"):
        for l in f.open():
            x = json.loads(l)
            if x.get("vaddr"):
                rows_all.append((int(x["vaddr"], 16), x))
    # assembly_csharp_methods.jsonl e metadata_methods.jsonl repetem os metodos de Assembly-CSharp: um por vaddr
    rows_all = list({va: (va, x) for va, x in rows_all}.values())
    rows_all.sort(key=lambda p: p[0])
    starts = [p[0] for p in rows_all]
    cs = Cs(CS_ARCH_ARM64, CS_MODE_ARM)
    total = hit = 0
    by_type = collections.Counter(); type_total = collections.Counter(); hits = []
    for va, x in rows_all:
        if x.get("image") != "Assembly-CSharp.dll":
            continue
        if a.limit and total >= a.limit:
            break
        i = bisect.bisect_right(starts, va)
        end = starts[i] if i < len(starts) else va + 0x400
        if end - va > 0x4000:
            end = va + 0x4000
        try:
            code = elf.data[elf.offset(va, end - va):][: end - va]
        except ValueError:
            continue
        total += 1
        pages, used = {}, 0
        for ins in cs.disasm(code, va):
            if ins.mnemonic == "adrp":
                reg, _, val = ins.op_str.partition(", ")
                pages[reg] = int(val.lstrip("#"), 16)
            elif ins.mnemonic == "ldr" and "[" in ins.op_str:
                dst, _, mem = ins.op_str.partition(", ")
                base = mem.strip("[]!").split(",")[0].strip()
                if base in pages and dst.startswith("x") and "#" in mem:
                    slot = pages[base] + int(mem.split("#")[1].strip("]!"), 16)
                    t = elf.relocations.get(slot)
                    if t in nontoken:
                        used += 1
                pages.pop(dst, None)
        decl = x["declaring_type"]
        type_total[decl] += 1
        if used:
            hit += 1; by_type[decl] += 1
            hits.append({"type": decl, "method": x["name"], "vaddr": hex(va), "block_slots_used": used})
    print("metodos de Assembly-CSharp analisados:", total)
    print("com pelo menos um uso do bloco nao-token:", hit, "(%.1f%%)" % (100 * hit / max(total, 1)))
    print("tipos com algum metodo afetado:", len(by_type), "de", len(type_total))
    print("tipos mais afetados:", by_type.most_common(8))
    if a.json:
        a.json.write_text(json.dumps({"analyzed": total, "affected": hit, "methods": hits}, indent=1))


if __name__ == "__main__":
    main()
