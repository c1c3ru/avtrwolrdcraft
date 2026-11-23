#!/usr/bin/env python3
"""Limites de corpo de metodos IL2CPP (AArch64, Capstone): onde o metodo comeca, onde o proximo comeca, e se o fluxo fecha dentro.

Para cada vaddr: desmonta [inicio, proximo_inicio), faz a busca de alcancabilidade a partir da entrada (b/b.cond/cbz/tbz seguem os dois
caminhos; ret/br/b nao seguem; bl segue) e reporta: instrucoes alcancaveis x total, alvos de desvio fora do intervalo, ultima instrucao,
preenchimento depois dela e se ha fluxo que cai no proximo metodo. NAO prova ausencia de regioes de excecao/frias separadas: so bound
estatico do trecho contiguo.

uso: tools/venv/bin/python tools/recon_body_bounds.py 0x2073238 [0x20728d4 ...] [--data out/recon/il2cpp] [--json saida.json]
"""
from __future__ import annotations
import argparse, bisect, json, sys
from pathlib import Path
from capstone import Cs, CS_ARCH_ARM64, CS_MODE_ARM, CS_OP_IMM

HERE = Path(__file__).resolve().parent
sys.path.insert(0, str(HERE))
import recon_il2cpp as r  # noqa: E402

# Thunks de excecao do IL2CPP: `str x30; bl <helper>` onde o helper monta a excecao (mensagem em .rodata) e chama o raise. Tratados como
# sem retorno por PADRAO ESTRUTURAL (nao provado executando): 0x1b88980 = NullReference, 0x1b88988 = IndexOutOfRange.
NORETURN_THUNKS = {0x1B88980, 0x1B88988}

COND_BRANCH = {"b.eq", "b.ne", "b.hs", "b.lo", "b.mi", "b.pl", "b.vs", "b.vc", "b.hi", "b.ls", "b.ge", "b.lt", "b.gt", "b.le", "b.al", "b.nv",
               "cbz", "cbnz", "tbz", "tbnz"}


def analyze(elf, cs, starts, va):
    i = bisect.bisect_right(starts, va)
    nxt = starts[i] if i < len(starts) else None
    if nxt is None:
        return {"vaddr": hex(va), "error": "sem proximo metodo conhecido"}
    code = elf.data[elf.offset(va, nxt - va):][: nxt - va]
    ins = {x.address: x for x in cs.disasm(code, va)}
    decoded = sum(x.size for x in ins.values())
    reach, work, outside = set(), [va], set()
    while work:
        a = work.pop()
        if a in reach or a not in ins:
            continue
        reach.add(a)
        x = ins[a]
        tgt = None
        if x.mnemonic in COND_BRANCH or x.mnemonic == "b":
            tgt = int(x.op_str.split("#")[-1], 16)
            if va <= tgt < nxt:
                work.append(tgt)
            else:
                outside.add(tgt)
        if x.mnemonic in ("ret", "b", "br"):
            continue
        if x.mnemonic == "bl" and int(x.op_str.lstrip("#"), 16) in NORETURN_THUNKS:
            continue
        work.append(a + x.size)
    addrs = sorted(ins)
    last_reach = max(reach) if reach else va
    tail = [ins[a] for a in addrs if a > last_reach]
    lx = ins[last_reach]
    ends_noreturn = lx.mnemonic == "bl" and int(lx.op_str.lstrip("#"), 16) in NORETURN_THUNKS
    falls_into_next = (last_reach + lx.size == nxt) and lx.mnemonic not in ("ret", "b", "br") and not ends_noreturn
    return {
        "vaddr": hex(va), "next_method": hex(nxt), "bytes": nxt - va, "decoded_bytes": decoded, "all_bytes_decode": decoded == nxt - va,
        "instructions": len(ins), "reachable": len(reach), "unreachable": len(ins) - len(reach),
        "unreachable_ops": sorted({ins[a].mnemonic for a in ins if a not in reach}),
        "last_reachable": "%x %s %s" % (last_reach, ins[last_reach].mnemonic, ins[last_reach].op_str),
        "tail_after_last_reachable": [x.mnemonic for x in tail][:6],
        "branch_targets_outside_range": sorted(hex(t) for t in outside),
        "outside_targets_are_method_starts": {hex(t): (t in set(starts)) for t in sorted(outside)},
        "ends_in_assumed_noreturn_thunk": ends_noreturn,
        "falls_into_next_method": falls_into_next,
        "calls": sum(1 for a in reach if ins[a].mnemonic == "bl"),
    }


def main():
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument("vaddr", nargs="+")
    ap.add_argument("--data", type=Path, default=HERE.parent / "out" / "recon" / "il2cpp")
    ap.add_argument("--json", type=Path)
    a = ap.parse_args()
    elf = r.Elf((a.data / "libil2cpp.so").read_bytes())
    starts = sorted({int(json.loads(l)["vaddr"], 16) for f in a.data.glob("*_methods.jsonl") for l in f.open() if json.loads(l).get("vaddr")})
    cs = Cs(CS_ARCH_ARM64, CS_MODE_ARM)
    out = [analyze(elf, cs, starts, int(v, 16)) for v in a.vaddr]
    for o in out:
        print(json.dumps(o, ensure_ascii=False))
    if a.json:
        a.json.write_text(json.dumps(out, indent=1))


if __name__ == "__main__":
    main()
