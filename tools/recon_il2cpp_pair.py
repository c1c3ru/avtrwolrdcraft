#!/usr/bin/env python3
"""Gera as tabelas de metodos (assembly_csharp_methods.jsonl, metadata_methods.jsonl) para um par libil2cpp.so + global-metadata.dat qualquer.

`recon_il2cpp.run` so sabe extrair o par de `assets/*.apk`; este script faz o mesmo trabalho sobre uma pasta que ja contem os dois arquivos
(por exemplo o build instalado no aparelho: out/recon/il2cpp_1.230).

uso: tools/venv/bin/python tools/recon_il2cpp_pair.py out/recon/il2cpp_1.230
"""
import json, sys
from pathlib import Path

HERE = Path(__file__).resolve().parent
sys.path.insert(0, str(HERE))
import recon_il2cpp as r  # noqa: E402


def main():
    out = Path(sys.argv[1]).resolve()
    meta = r.Metadata((out / "global-metadata.dat").read_bytes())
    elf = r.Elf((out / "libil2cpp.so").read_bytes())
    image, methods = meta.image_methods("Assembly-CSharp.dll")
    module = r.codegen_module(elf, image["name"], len(methods))
    nonzero = nulls = 0
    for m in methods:
        slot = module["method_pointers_vaddr"] + (m["rid"] - 1) * 8
        address = elf.pointer(slot)
        m.update({"image": image["name"], "pointer_slot_vaddr": f"0x{slot:x}", "pointer_via_relative_relocation": slot in elf.relocations})
        if address:
            off = elf.offset(address, 16)
            m.update({"vaddr": f"0x{address:x}", "file_offset": f"0x{off:x}", "first_16_bytes": elf.data[off:off + 16].hex()})
            nonzero += 1
        else:
            m.update({"vaddr": None, "file_offset": None})
            nulls += 1
    methods.sort(key=lambda row: row["rid"])
    with (out / "assembly_csharp_methods.jsonl").open("w", encoding="utf-8") as s:
        for row in methods:
            s.write(json.dumps(row, ensure_ascii=False) + "\n")
    r.bounded_disassembly(elf, meta, out, [])
    print(json.dumps({"dir": str(out), "metadata_version": meta.version, "methods": len(methods), "nonzero_pointers": nonzero, "null_pointers": nulls,
                      "module_vaddr": hex(module["module_vaddr"])}))


if __name__ == "__main__":
    main()
