"""Annotated AArch64 disassembly of one method (capstone): calls resolved to names, GOT string literals inlined.
Needs capstone (pip install capstone in a venv). Data from the main checkout's out/ (override with --data)."""
from __future__ import annotations
import argparse, bisect, json, re, struct, sys
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
    if a.method.startswith("@"):
        target = [x for x in rows if int(x["vaddr"], 16) == int(a.method[1:], 16)]
    else:
        typ, _, meth = a.method.rpartition(".")
        target = [x for x in rows if x["name"] == meth and x["declaring_type"].endswith(typ)]
    if not target:
        raise SystemExit("method not found")
    # indice de tipo (Il2CppType) -> nome, via byvalTypeIndex da definicao de tipo (campo +8 do registro de 88 bytes)
    type_names = {}
    table = meta.tables["types"]
    for idx, typ in enumerate(meta.types):
        byval = struct.unpack_from("<I", meta.data, table["offset"] + idx * 88 + 8)[0]
        type_names.setdefault(byval, (typ["namespace"] + "." if typ["namespace"] else "") + typ["name"])
    iface_methods = {}   # tipo -> nomes de metodo na ordem de definicao (indice do despacho de interface)
    for line in (a.data / "metadata_methods.jsonl").open():
        m = json.loads(line)
        iface_methods.setdefault(m["declaring_type"].split(".")[-1], []).append((m["method_definition_index"], m["name"]))
    for k in iface_methods:
        iface_methods[k] = [n for _, n in sorted(iface_methods[k])]
    last_type, last_w2 = None, None
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
            if ins.mnemonic == "mov" and ins.op_str.startswith("w2, #"):
                last_w2 = int(ins.op_str.split("#")[1], 0)
            if ins.mnemonic in ("bl", "b"):
                t = int(ins.op_str.lstrip("#"), 16)
                if t in names:
                    note = "  ; -> " + names[t]
                elif t == 0x1B7BA44 and last_type and last_w2 is not None:     # GetInterfaceInvokeData
                    lst = iface_methods.get(last_type.split(".")[-1], [])
                    note = "  ; IFACE %s.%s" % (last_type.split(".")[-1], lst[last_w2] if last_w2 < len(lst) else "#%d" % last_w2)
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
                        if enc >> 29 == 1:
                            tname = type_names.get((enc & 0x1FFFFFFF) >> 1)
                            if tname:
                                note = "  ; type " + tname
                                if re.match(r"I[A-Z]", tname.split(".")[-1]):
                                    last_type = tname
                        if enc >> 29 == 5:
                            idx = (enc & 0x1FFFFFFF) >> 1
                            ln, di = struct.unpack_from("<II", meta.data, lt + idx * 8)
                            note = '  ; "' + meta.data[so + di:so + di + ln].decode("utf-8", "replace") + '"'
                    except Exception:
                        pass
                # dst no longer holds a page base after this load (even when it was not
                # itself the GOT-chase base above): drop any stale adrp page recorded for
                # it so a later unrelated `ldr x9,[x8,#off]` is not misread as a GOT chase.
                pages.pop(dst, None)
            print("%x  %-6s %s%s" % (ins.address, ins.mnemonic, ins.op_str, note))


if __name__ == "__main__":
    main()
