#!/usr/bin/env python3
"""Decodifica slots de GOT de metadata-usage (MethodRef) para metodo generico + argumentos de tipo.

Uso: python3 -I tools/il2cpp_method_usage.py <libil2cpp.so> <global-metadata.dat> <GOT_hex> [GOT_hex ...]
GOT_hex = endereco do slot de GOT lido pelo codigo (ex. `adrp x8,0x41b8000; ldr x8,[x8,#0xad8]` -> 41b8ad8).
Cadeia: GOT --(R_AARCH64_RELATIVE)--> variavel em .data com valor codificado (bits 29-31 = tipo, 6 = MethodRef;
indice = (valor & 0x1FFFFFFF) >> 1) -> MetadataRegistration.methodSpecs[i] {methodDef, classInst, methodInst}
-> genericInsts[j] {argc, Il2CppType**} -> Il2CppType {data=typeDefIdx para CLASS(0x12)/VALUETYPE(0x11), bits}.
MetadataRegistration e achada por `fieldOffsetsCount == numero de typeDefs` (ver il2cpp_field_offsets.py); os campos
anteriores seguem a ordem do struct (genericInsts = +3*8, types = +7*8, methodSpecs = +9*8 a partir do inicio).
Validado em 2026-11-23 com PDSceneObject (TryGetComponent) e LevelItem (GetComponentsInChildren) usados por DestroyLevelItem.
Requer pyelftools. Estatico apenas.
"""
import struct
import sys

from elftools.elf.elffile import ELFFile


def main():
    so_path, meta_path, gots = sys.argv[1], sys.argv[2], sys.argv[3:]
    so = open(so_path, "rb").read()
    m = open(meta_path, "rb").read()
    e = ELFFile(open(so_path, "rb"))
    rela = {}
    sec = e.get_section_by_name(".rela.dyn")
    d = so[sec["sh_offset"]:sec["sh_offset"] + sec["sh_size"]]
    for i in range(0, len(d), 24):
        off, info, add = struct.unpack("<QQq", d[i:i + 24])
        if info & 0xFFFFFFFF == 1027:
            rela[off] = add
    segs = [(g["p_vaddr"], g["p_vaddr"] + g["p_filesz"], g["p_offset"])
            for g in e.iter_segments() if g["p_type"] == "PT_LOAD"]

    def v2o(va):
        for lo, hi, off in segs:
            if lo <= va < hi:
                return off + va - lo
        raise ValueError(hex(va))

    def q(va):
        return rela.get(va) if va in rela else struct.unpack("<Q", so[v2o(va):v2o(va) + 8])[0]

    def hdr(i):
        return struct.unpack("<ii", m[8 + i * 8:16 + i * 8])

    str_off, _ = hdr(2)
    m_off, _ = hdr(5)
    td_off, td_size = hdr(19)
    n_types = td_size // 88

    def s(i):
        return m[str_off + i:m.index(b"\0", str_off + i)].decode()

    def tname(t):
        r = struct.unpack("<2i", m[td_off + t * 88:td_off + t * 88 + 8])
        return (s(r[1]) + "." if s(r[1]) else "") + s(r[0])

    def mname(i):
        r = struct.unpack("<2i", m[m_off + i * 36:m_off + i * 36 + 8])
        return tname(r[1]) + "." + s(r[0])

    # MetadataRegistration: achar fieldOffsetsCount (campo #10) como no il2cpp_field_offsets.py
    dr = e.get_section_by_name(".data.rel.ro")
    blob = so[dr["sh_offset"]:dr["sh_offset"] + dr["sh_size"]]
    tgt = struct.pack("<Q", n_types)
    base = None
    i = blob.find(tgt)
    while i >= 0:
        if i % 8 == 0 and blob[i + 16:i + 24] == tgt and (dr["sh_addr"] + i + 8) in rela:
            base = dr["sh_addr"] + i - 10 * 8
            break
        i = blob.find(tgt, i + 1)
    assert base, "MetadataRegistration nao encontrada"
    generic_insts, types, method_specs = q(base + 3 * 8), q(base + 7 * 8), q(base + 9 * 8)
    print(f"# MetadataRegistration @ {hex(base)}")

    def inst(j):
        p = q(generic_insts + 8 * j)
        argc, argv = q(p), q(p + 8)
        out = []
        for k in range(argc):
            tp = q(argv + 8 * k)
            data = q(tp)
            kind = (struct.unpack("<I", so[v2o(tp + 8):v2o(tp + 12)])[0] >> 16) & 0xFF
            out.append(tname(data) if kind in (0x11, 0x12) and data < n_types else f"<tipo kind={hex(kind)} data={hex(data)}>")
        return out

    for g in gots:
        var = rela[int(g, 16)]
        v = struct.unpack("<I", so[v2o(var):v2o(var) + 4])[0]
        kind, idx = v >> 29, (v & 0x1FFFFFFF) >> 1
        if kind != 6:
            print(f"GOT {g}: valor {hex(v)} tipo {kind} (nao e MethodRef), indice {idx}")
            continue
        md, ci, mi = struct.unpack("<3i", so[v2o(method_specs + 12 * idx):v2o(method_specs + 12 * idx) + 12])
        cls = f" classArgs={inst(ci)}" if ci >= 0 else ""
        mth = f"<{', '.join(inst(mi))}>" if mi >= 0 else ""
        print(f"GOT {g}: {mname(md)}{mth}{cls}")


if __name__ == "__main__":
    main()
