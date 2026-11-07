"""String literals per method of given types, decoded from raw AArch64 (adrp+ldr only; no disassembler needed).
Window = method start .. next method start (capped); literals may include neighbours' tail if the cap is hit."""
from __future__ import annotations
import argparse, bisect, json, struct, sys
from pathlib import Path
ROOT = Path(__file__).resolve().parents[1]
sys.path.insert(0, str(ROOT / "tools"))
import recon_il2cpp as r  # noqa: E402

def main():
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument("types", nargs="+", help="declaring-type suffixes, e.g. LevelBaby")
    ap.add_argument("--output", type=Path, required=True)
    ap.add_argument("--cap", type=int, default=0x1400)
    a = ap.parse_args()
    d = ROOT / "out/recon/il2cpp"
    meta = r.Metadata((d / "global-metadata.dat").read_bytes()); elf = r.Elf((d / "libil2cpp.so").read_bytes())
    lt, lb = struct.unpack_from("<II", meta.data, 8); so, _ = struct.unpack_from("<II", meta.data, 16)
    rows = [json.loads(l) for l in (d / "assembly_csharp_methods.jsonl").open()]
    rows = [x for x in rows if x.get("vaddr")]
    starts = sorted({int(x["vaddr"], 16) for x in rows})
    out = {}
    for x in rows:
        if not x["declaring_type"].endswith(tuple(a.types)): continue
        va = int(x["vaddr"], 16); i = bisect.bisect_right(starts, va)
        end = min(starts[i] if i < len(starts) else va + a.cap, va + a.cap)
        code = elf.data[elf.offset(va, end - va):elf.offset(va, end - va) + end - va]
        regs, lits = {}, []
        for k in range(0, len(code) - 3, 4):
            w = struct.unpack_from("<I", code, k)[0]; pc = va + k
            if (w & 0x9F000000) == 0x90000000:  # ADRP
                imm = (((w >> 5) & 0x7FFFF) << 2) | ((w >> 29) & 3)
                if imm >= 1 << 20: imm -= 1 << 21
                regs[w & 31] = (pc & ~0xFFF) + (imm << 12)
            elif (w & 0xFFC00000) == 0xF9400000:  # LDR Xt,[Xn,#imm]
                n = (w >> 5) & 31
                if n in regs:
                    got = regs[n] + (((w >> 10) & 0xFFF) << 3)
                    try:
                        enc = struct.unpack_from("<Q", elf.data, elf.offset(elf.pointer(got), 8))[0]
                    except Exception: continue
                    if enc >> 29 == 5:
                        idx = (enc & 0x1FFFFFFF) >> 1
                        if idx < lb // 8:
                            ln, di = struct.unpack_from("<II", meta.data, lt + idx * 8)
                            s = meta.data[so + di:so + di + ln].decode("utf-8", "replace")
                            if s not in lits: lits.append(s)
        if lits: out[x["declaring_type"] + "." + x["name"]] = lits
    a.output.write_text(json.dumps(out, indent=1, ensure_ascii=False) + "\n")
    for k, v in out.items(): print(k, v)

if __name__ == "__main__":
    main()
