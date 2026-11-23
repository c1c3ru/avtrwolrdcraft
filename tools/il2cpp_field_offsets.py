#!/usr/bin/env python3
"""Offsets de campo IL2CPP juntando global-metadata.dat (v31) com MetadataRegistration.fieldOffsets do libil2cpp.so.

Uso: python3 -I tools/il2cpp_field_offsets.py <libil2cpp.so> <global-metadata.dat> Nome [Nome...]
Nome = nome simples ou Namespace.Nome. Campos estaticos aparecem com o offset dentro de static_fields.
Requer: pyelftools. Estatico apenas. A tabela e achada pelo padrao
  qword N | ptr(fieldOffsets) | qword N   (N = numero de typeDefinitions = tamanho/88)
em .data.rel.ro; ponteiros vem de R_AARCH64_RELATIVE (.rela.dyn).
Validado em 2026-11-23: DeepLinkManager._mapLinkToLevel == 0x28 (igual ao Cpp2IL).
"""
import struct
import sys

from elftools.elf.elffile import ELFFile


def main():
    so_path, meta_path, names = sys.argv[1], sys.argv[2], sys.argv[3:]
    so = open(so_path, "rb").read()
    m = open(meta_path, "rb").read()
    magic, ver = struct.unpack("<Ii", m[:8])
    assert magic == 0xFAB11BAF and ver == 31, f"metadata {hex(magic)} v{ver} nao suportada"

    def hdr(i):
        return struct.unpack("<ii", m[8 + i * 8:16 + i * 8])

    str_off, _ = hdr(2)
    fld_off, _ = hdr(11)
    td_off, td_size = hdr(19)
    n_types = td_size // 88

    def s(i):
        return m[str_off + i:m.index(b"\0", str_off + i)].decode()

    types = []
    for t in range(n_types):
        r = struct.unpack("<9i", m[td_off + t * 88:td_off + t * 88 + 36])
        cnt = struct.unpack("<8H", m[td_off + t * 88 + 64:td_off + t * 88 + 80])[2]
        types.append((s(r[0]), s(r[1]), r[8], cnt))

    e = ELFFile(open(so_path, "rb"))
    rela = {}
    sec = e.get_section_by_name(".rela.dyn")
    d = so[sec["sh_offset"]:sec["sh_offset"] + sec["sh_size"]]
    for i in range(0, len(d), 24):
        off, info, add = struct.unpack("<QQq", d[i:i + 24])
        if info & 0xFFFFFFFF == 1027:  # R_AARCH64_RELATIVE
            rela[off] = add

    segs = [(sg["p_vaddr"], sg["p_vaddr"] + sg["p_filesz"], sg["p_offset"])
            for sg in e.iter_segments() if sg["p_type"] == "PT_LOAD"]

    def v2o(va):
        for lo, hi, off in segs:
            if lo <= va < hi:
                return off + va - lo
        raise ValueError(hex(va))

    dr = e.get_section_by_name(".data.rel.ro")
    blob = so[dr["sh_offset"]:dr["sh_offset"] + dr["sh_size"]]
    tgt = struct.pack("<Q", n_types)
    table = None
    i = blob.find(tgt)
    while i >= 0:
        if i % 8 == 0 and blob[i + 16:i + 24] == tgt and (dr["sh_addr"] + i + 8) in rela:
            table = rela[dr["sh_addr"] + i + 8]
            break
        i = blob.find(tgt, i + 1)
    assert table, "MetadataRegistration.fieldOffsets nao encontrada"
    print(f"# fieldOffsets @ {hex(table)}, typeDefs={n_types}")

    for name in names:
        for t, (n, ns, fs, cnt) in enumerate(types):
            if name not in (n, f"{ns}.{n}" if ns else n):
                continue
            p = rela.get(table + 8 * t, 0)
            offs = struct.unpack(f"<{cnt}i", so[v2o(p):v2o(p) + 4 * cnt]) if p and cnt else None
            print(f"== {ns + '.' if ns else ''}{n} typeIdx={t} fields={cnt}")
            for k in range(cnt):
                nm = struct.unpack("<3i", m[fld_off + (fs + k) * 12:fld_off + (fs + k) * 12 + 12])[0]
                print(f"   {s(nm)} off={hex(offs[k]) if offs else None}")


if __name__ == "__main__":
    main()
