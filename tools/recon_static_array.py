#!/usr/bin/env python3
"""Le o conteudo de um array estatico inicializado por `RuntimeHelpers.InitializeArray` num .cctor (ex.: HolidayGameModeButton._holidayWeatherWorlds).

Acha no .cctor o slot da .got cujo token e tag 4 (FieldInfo), resolve `fieldRefs[idx]` -> (tipo, indice no tipo) -> campo global em `<PrivateImplementationDetails>`
-> `fieldDefaultValues` -> blob em `fieldAndParameterDefaultValueData` e imprime os inteiros de 32 bits. Metadata v31 (layout validado em global-metadata 31).

uso: tools/venv/bin/python tools/recon_static_array.py --data out/recon/il2cpp_1.230 HolidayGameModeButton [--count 4]
"""
import argparse, json, struct, sys
from pathlib import Path
from capstone import Cs, CS_ARCH_ARM64, CS_MODE_ARM

HERE = Path(__file__).resolve().parent
sys.path.insert(0, str(HERE))
import recon_il2cpp as r  # noqa: E402


def main():
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument("type_suffix")
    ap.add_argument("--data", type=Path, default=HERE.parent / "out" / "recon" / "il2cpp")
    ap.add_argument("--count", type=int, default=0, help="numero de elementos (0 = ate 64 bytes do blob)")
    a = ap.parse_args()
    meta = r.Metadata((a.data / "global-metadata.dat").read_bytes())
    elf = r.Elf((a.data / "libil2cpp.so").read_bytes())
    d = meta.data
    names = ["stringLiteral", "stringLiteralData", "string", "events", "properties", "methods", "parameterDefaultValues", "fieldDefaultValues",
             "fieldAndParameterDefaultValueData", "fieldMarshaledSizes", "parameters", "fields", "genericParameters", "genericParameterConstraints",
             "genericContainers", "nestedTypes", "interfaces", "vtableMethods", "interfaceOffsets", "typeDefinitions", "images", "assemblies", "fieldRefs"]
    T = {n: struct.unpack_from("<ii", d, 8 + i * 8) for i, n in enumerate(names)}
    so = T["string"][0]

    def s(i):
        return d[so + i:d.index(b"\0", so + i)].decode()

    rows = [json.loads(l) for l in (a.data / "assembly_csharp_methods.jsonl").open()]
    cctor = next(x for x in rows if x["name"] == ".cctor" and x["declaring_type"].endswith(a.type_suffix) and x.get("vaddr"))
    va = int(cctor["vaddr"], 16)
    code = elf.data[elf.offset(va, 0x200):][:0x200]
    pages, slots = {}, []
    for ins in Cs(CS_ARCH_ARM64, CS_MODE_ARM).disasm(code, va):
        if ins.mnemonic == "adrp":
            reg, _, val = ins.op_str.partition(", ")
            pages[reg] = int(val.lstrip("#"), 16)
        elif ins.mnemonic == "ldr" and "[" in ins.op_str:
            dst, _, mem = ins.op_str.partition(", ")
            base = mem.strip("[]!").split(",")[0].strip()
            if base in pages and "#" in mem:
                slots.append(pages[base] + int(mem.split("#")[1].strip("]!"), 16))
        if ins.mnemonic == "ret" or (ins.mnemonic == "b" and ins.address > va + 0x20):
            break
    field_token = None
    for slot in slots:
        t = elf.relocations.get(slot)
        if t is None:
            continue
        v = struct.unpack_from("<Q", elf.data, elf.offset(t, 8))[0]
        if v < 2 ** 32 and v & 1 and (v >> 29) == 4:
            field_token = (v & 0x1FFFFFFF) >> 1
    if field_token is None:
        raise SystemExit("nenhum token de FieldInfo (tag 4) no .cctor")
    type_index, field_in_type = struct.unpack_from("<ii", d, T["fieldRefs"][0] + field_token * 8)
    td0 = T["typeDefinitions"][0]
    start = None
    for k in range(T["typeDefinitions"][1] // 88):
        ints = struct.unpack_from("<22i", d, td0 + k * 88)
        if ints[2] == type_index:
            start = ints[8]
            owner = s(ints[0])
            break
    gf = start + field_in_type
    fdv0, fdvn = T["fieldDefaultValues"]
    blob = None
    for k in range(fdvn // 12):
        fi, ti, di = struct.unpack_from("<iii", d, fdv0 + k * 12)
        if fi == gf:
            base = T["fieldAndParameterDefaultValueData"][0]
            blob = d[base + di:base + di + (a.count * 4 if a.count else 64)]
            break
    n = len(blob) // 4
    print(json.dumps({"build": str(a.data), "cctor": cctor["vaddr"], "fieldRef": field_token, "owner_type": owner, "global_field": gf,
                      "values": list(struct.unpack("<%di" % n, blob))}))


if __name__ == "__main__":
    main()
