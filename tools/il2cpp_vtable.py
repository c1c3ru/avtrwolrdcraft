#!/usr/bin/env python3
"""Resolve slots de vtable de um tipo IL2CPP (metadata v31) para nomes de metodo.

Uso: python3 -I tools/il2cpp_vtable.py <global-metadata.dat> <Namespace.Tipo> [slot ...]
Sem slots imprime a vtable inteira. Offset de chamada no assembly -> slot: (offset - 0x138) / 16
(vtable de Il2CppClass comeca em +0x138, 16 bytes por entrada: {methodPtr, methodInfo}).
Formatos usados (v31): typeDefinition = 88 bytes (vtableStart = int #14, vtable_count = u16 #5 apos 64 bytes),
methodDefinition = 36 bytes (nameIndex, declaringType, ...), vtableMethods = uint32 codificado:
bits 29-31 = tipo de uso (3 = MethodDef), bit 0 = flag, indice = (valor & 0x1FFFFFFF) >> 1.
Validado em 2026-11-23: slots 0..3 de qualquer classe = Equals/Finalize/GetHashCode/ToString.
"""
import struct
import sys


def main():
    meta, want, slots = sys.argv[1], sys.argv[2], [int(x) for x in sys.argv[3:]]
    m = open(meta, "rb").read()
    assert struct.unpack("<Ii", m[:8]) == (0xFAB11BAF, 31)

    def hdr(i):
        return struct.unpack("<ii", m[8 + i * 8:16 + i * 8])

    str_off, _ = hdr(2)
    m_off, _ = hdr(5)
    vt_off, _ = hdr(17)
    td_off, td_size = hdr(19)

    def s(i):
        return m[str_off + i:m.index(b"\0", str_off + i)].decode()

    def typedef(t):
        b = td_off + t * 88
        r = struct.unpack("<16i", m[b:b + 64])
        vcount = struct.unpack("<8H", m[b + 64:b + 80])[5]
        return s(r[0]), s(r[1]), r[14], vcount

    def method(i):
        r = struct.unpack("<2i", m[m_off + i * 36:m_off + i * 36 + 8])
        return s(r[0]), r[1]

    for t in range(td_size // 88):
        name, ns, vstart, vcount = typedef(t)
        if want not in (name, f"{ns}.{name}"):
            continue
        print(f"== {ns}.{name} typeIdx={t} vtable_count={vcount}")
        for sl in (slots or range(vcount)):
            e = struct.unpack("<I", m[vt_off + (vstart + sl) * 4:vt_off + (vstart + sl) * 4 + 4])[0]
            if e >> 29 != 3:
                print(f"slot {sl} (+{hex(0x138 + 16 * sl)}): uso tipo {e >> 29} raw={hex(e)}")
                continue
            mn, dt = method((e & 0x1FFFFFFF) >> 1)
            print(f"slot {sl} (+{hex(0x138 + 16 * sl)}): {typedef(dt)[0] if 0 <= dt < td_size // 88 else dt}.{mn}")


if __name__ == "__main__":
    main()
