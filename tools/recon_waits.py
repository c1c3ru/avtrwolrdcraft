"""WaitForSeconds / WaitForSecondsRealtime durations in coroutine MoveNext bodies (static; needs capstone).
For each bl to the constructor, scans backwards for the instruction that defines s0:
  fmov s0,#imm | adrp+ldr s0 (rodata) | mov/movk w + fmov s0,w | fmov s0,wzr. Anything else is reported 'dynamic'.
Input: out/recon/tasks/T032/coroutines.jsonl (tools/recon_coroutines.py) and the CoreModule method map
(tools/recon_image_methods.py UnityEngine.CoreModule.dll). Data lives in the main checkout's out/."""
from __future__ import annotations
import argparse, bisect, collections, json, re, struct, sys
from pathlib import Path

sys.path.insert(0, str(Path(__file__).resolve().parent))
import recon_il2cpp as r  # noqa: E402
from capstone import Cs, CS_ARCH_ARM64, CS_MODE_ARM  # noqa: E402

ROOT = Path("/home/deppi/avatarworld-re")
CTORS = {"UnityEngine.WaitForSeconds": "WaitForSeconds", "UnityEngine.WaitForSecondsRealtime": "WaitForSecondsRealtime"}


def f32(bits):
    return struct.unpack("<f", struct.pack("<I", bits & 0xFFFFFFFF))[0]


def trace(insns, idx, target, elf, depth=0):
    """Valor de `target` (registrador s) antes de insns[idx], recuando; segue copias fmov sA, sB."""
    for back in range(idx - 1, max(idx - 40, -1), -1):
        b = insns[back]
        if b.mnemonic == "fmov":
            dst, _, src = b.op_str.partition(", ")
            if dst != target:
                continue
            mm = re.match(r"#(-?[0-9.]+)$", src)
            if mm:
                return float(mm.group(1)), "fmov_imm"
            if src == "wzr":
                return 0.0, "zero"
            if re.match(r"s\d+$", src) and depth < 3:
                v, how = trace(insns, back, src, elf, depth + 1)
                return v, ("copy:" + how) if v is not None else "dynamic"
            if re.match(r"w\d+$", src):
                lo = hi = None
                for k in range(back - 1, max(back - 8, -1), -1):
                    c = insns[k]
                    m2 = re.match(re.escape(src) + r", #(0x[0-9a-f]+|\d+)(?:, lsl #(\d+))?$", c.op_str)
                    if m2 and c.mnemonic in ("mov", "movz", "movk"):
                        imm = int(m2.group(1), 0) << int(m2.group(2) or 0)
                        if c.mnemonic == "movk":
                            hi = imm if hi is None else hi
                        else:
                            lo = imm
                            break
                if lo is not None or hi is not None:
                    return f32((lo or 0) | (hi or 0)), "mov_fmov"
            return None, "dynamic"
        if b.mnemonic == "ldr" and b.op_str.startswith(target + ", ["):
            m3 = re.match(re.escape(target) + r", \[(x\d+), #(0x[0-9a-f]+)\]$", b.op_str)
            if m3:
                base, off = m3.group(1), int(m3.group(2), 16)
                for k in range(back - 1, max(back - 12, -1), -1):
                    c = insns[k]
                    if c.mnemonic == "adrp" and c.op_str.startswith(base + ", "):
                        page = int(c.op_str.split("#")[1], 16)
                        try:
                            return struct.unpack_from("<f", elf.data, elf.offset(page + off, 4))[0], "rodata"
                        except Exception:
                            return None, "dynamic"
            return None, "dynamic"
        if b.op_str.startswith(target + ", ") and b.mnemonic in ("fadd", "fmul", "fsub", "fdiv", "scvtf", "ucvtf", "fcvt", "ldur"):
            return None, "dynamic"
    return None, "dynamic"


def main():
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument("--root", type=Path, default=ROOT)
    ap.add_argument("--output", type=Path, required=True)
    ap.add_argument("--cap", type=int, default=0x3000)
    a = ap.parse_args()
    il2 = a.root / "out/recon/il2cpp"
    elf = r.Elf((il2 / "libil2cpp.so").read_bytes())
    ctor_va = {}
    for line in (il2 / "UnityEngine.CoreModule_methods.jsonl").open():
        m = json.loads(line)
        if m["declaring_type"] in CTORS and m["name"] == ".ctor" and m.get("vaddr"):
            ctor_va[int(m["vaddr"], 16)] = CTORS[m["declaring_type"]]
    rows = [json.loads(l) for l in (il2 / "assembly_csharp_methods.jsonl").open()]
    rows = [x for x in rows if x.get("vaddr")]
    starts = sorted({int(x["vaddr"], 16) for x in rows})
    cs = Cs(CS_ARCH_ARM64, CS_MODE_ARM)
    cors = [json.loads(l) for l in (a.root / "out/recon/tasks/T032/coroutines.jsonl").open()]
    out, kinds, values = [], collections.Counter(), collections.Counter()
    for co in cors:
        va = int(co["vaddr"], 16)
        i = bisect.bisect_right(starts, va)
        end = min(starts[i] if i < len(starts) else va + a.cap, va + a.cap)
        code = elf.data[elf.offset(va, end - va):][: end - va]
        insns = list(cs.disasm(code, va))
        waits = []
        for idx, ins in enumerate(insns):
            if ins.mnemonic != "bl":
                continue
            tgt = int(ins.op_str.lstrip("#"), 16)
            if tgt not in ctor_va:
                continue
            value, how = trace(insns, idx, "s0", elf)
            waits.append({"kind": ctor_va[tgt], "seconds": None if value is None else round(value, 6), "how": how, "at": hex(ins.address)})
            kinds[how] += 1
            if value is not None:
                values[round(value, 4)] += 1
        if waits:
            out.append({"owner": co["owner"], "method": co["method"], "vaddr": co["vaddr"], "waits": waits})
    a.output.write_text("\n".join(json.dumps(e, ensure_ascii=False) for e in out) + "\n")
    print("coroutines with WaitForSeconds:", len(out), "| waits:", sum(kinds.values()), "| how:", dict(kinds))
    print("most common seconds:", values.most_common(12))


if __name__ == "__main__":
    main()
