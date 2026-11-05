"""Annotated AArch64 disassembly of one method (capstone): calls resolved to names, GOT string literals inlined.
Needs capstone (pip install capstone in a venv). Data from the main checkout's out/ (override with --data)."""
from __future__ import annotations
import argparse, bisect, json, struct, sys
from pathlib import Path

HERE = Path(__file__).resolve().parent
sys.path.insert(0, str(HERE))
import recon_il2cpp as r  # noqa: E402
from capstone import Cs, CS_ARCH_ARM64, CS_MODE_ARM  # noqa: E402

DEFAULT_DATA = Path("/home/deppi/avatarworld-re/out/recon/il2cpp")


def main():
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument("method", help="Type.Method suffix, e.g. LevelAvatarOneTimeSpawner.OnLevelPrePostInit")
    ap.add_argument("--data", type=Path, default=DEFAULT_DATA)
    ap.add_argument("--cap", type=int, default=0x1400)
    a = ap.parse_args()
    meta = r.Metadata((a.data / "global-metadata.dat").read_bytes())
    elf = r.Elf((a.data / "libil2cpp.so").read_bytes())
    lt, lb = struct.unpack_from("<II", meta.data, 8)
    so, _ = struct.unpack_from("<II", meta.data, 16)
    rows = [json.loads(l) for l in (a.data / "assembly_csharp_methods.jsonl").open()]
    rows = [x for x in rows if x.get("vaddr")]
    names = {int(x["vaddr"], 16): x["declaring_type"].split(".")[-1] + "." + x["name"] for x in rows}
    starts = sorted(names)
    typ, _, meth = a.method.rpartition(".")
    target = [x for x in rows if x["name"] == meth and x["declaring_type"].endswith(typ)]
    if not target:
        raise SystemExit("method not found")
    cs = Cs(CS_ARCH_ARM64, CS_MODE_ARM)
    cs.detail = False
    for x in target[:1]:
        va = int(x["vaddr"], 16)
        i = bisect.bisect_right(starts, va)
        end = min(starts[i] if i < len(starts) else va + a.cap, va + a.cap)
        code = elf.data[elf.offset(va, end - va):][: end - va]
        pages = {}
        for ins in cs.disasm(code, va):
            note = ""
            if ins.mnemonic in ("bl", "b"):
                t = int(ins.op_str.lstrip("#"), 16)
                if t in names:
                    note = "  ; -> " + names[t]
            elif ins.mnemonic == "adrp":
                reg, _, val = ins.op_str.partition(", ")
                pages[reg] = int(val.lstrip("#"), 16)
            elif ins.mnemonic == "ldr" and "[" in ins.op_str:
                dst, _, mem = ins.op_str.partition(", ")
                base_reg = mem.strip("[]!").split(",")[0].strip()
                if base_reg in pages and dst.startswith("x") and "#" in mem:
                    off = int(mem.split("#")[1].strip("]!"), 16)
                    got = pages[base_reg] + off
                    try:
                        enc = struct.unpack_from("<Q", elf.data, elf.offset(elf.pointer(got), 8))[0]
                        if enc >> 29 == 5:
                            idx = (enc & 0x1FFFFFFF) >> 1
                            ln, di = struct.unpack_from("<II", meta.data, lt + idx * 8)
                            note = '  ; "' + meta.data[so + di:so + di + ln].decode("utf-8", "replace") + '"'
                    except Exception:
                        pass
            print("%x  %-6s %s%s" % (ins.address, ins.mnemonic, ins.op_str, note))


if __name__ == "__main__":
    main()
