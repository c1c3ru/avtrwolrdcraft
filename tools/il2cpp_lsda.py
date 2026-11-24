#!/usr/bin/env python3
"""Mostra FDE + tabela de call-sites (LSDA) de um metodo em libil2cpp.so (ARM64, .eh_frame/.gcc_except_table).

Uso: python3 -I tools/il2cpp_lsda.py <libil2cpp.so> <addr_hex> [addr_hex ...]
Para cada endereco acha o FDE que o cobre; se o FDE tem ponteiro de LSDA (augmentation 'L'), decodifica o cabecalho e a
tabela de call-sites: [inicio, fim) -> landing pad (0 = sem tratador) e indice de acao. Sem FDE/LSDA o metodo nao tem
regiao de excecao tratada (so propaga). Estatico; requer pyelftools. Nao interpreta as acoes (typeinfo/filtros).
"""
import struct
import sys

from elftools.elf.elffile import ELFFile
from elftools.dwarf.callframe import FDE


def uleb(b, i):
    r = s = 0
    while True:
        x = b[i]
        i += 1
        r |= (x & 0x7F) << s
        s += 7
        if not x & 0x80:
            return r, i


def read_enc(b, i, enc, base_va):
    """Le um valor DW_EH_PE_*; base_va = endereco virtual do byte i (para pcrel)."""
    if enc == 0xFF:
        return None, i
    fmt = enc & 0x0F
    app = enc & 0x70
    if fmt == 0x00:
        v, n = struct.unpack_from("<Q", b, i)[0], 8
    elif fmt == 0x01:
        v, n = uleb(b, i)[0], None
        _, j = uleb(b, i)
        n = j - i
    elif fmt == 0x02:
        v, n = struct.unpack_from("<H", b, i)[0], 2
    elif fmt == 0x03:
        v, n = struct.unpack_from("<I", b, i)[0], 4
    elif fmt == 0x04:
        v, n = struct.unpack_from("<Q", b, i)[0], 8
    elif fmt == 0x09:
        # sleb128
        r = s = 0
        j = i
        while True:
            x = b[j]
            j += 1
            r |= (x & 0x7F) << s
            s += 7
            if not x & 0x80:
                if x & 0x40:
                    r -= 1 << s
                break
        v, n = r, j - i
    elif fmt == 0x0A:
        v, n = struct.unpack_from("<h", b, i)[0], 2
    elif fmt == 0x0B:
        v, n = struct.unpack_from("<i", b, i)[0], 4
    elif fmt == 0x0C:
        v, n = struct.unpack_from("<q", b, i)[0], 8
    else:
        raise ValueError(f"formato DW_EH_PE {hex(enc)} nao suportado")
    if app == 0x10:  # pcrel
        v += base_va + 0
    return v, i + n


def main():
    path, addrs = sys.argv[1], [int(a, 16) for a in sys.argv[2:]]
    f = open(path, "rb")
    e = ELFFile(f)
    dw = e.get_dwarf_info()
    ehs = e.get_section_by_name(".eh_frame")
    gct = e.get_section_by_name(".gcc_except_table")
    gdata = gct.data()
    fdes = []
    for entry in dw.EH_CFI_entries():
        if isinstance(entry, FDE):
            fdes.append(entry)
    starts = sorted((fd["initial_location"], fd["address_range"], fd) for fd in fdes)
    import bisect
    keys = [s[0] for s in starts]
    for a in addrs:
        k = bisect.bisect_right(keys, a) - 1
        print(f"== {hex(a)}")
        if k < 0 or not (starts[k][0] <= a < starts[k][0] + starts[k][1]):
            print("   sem FDE que cubra este endereco")
            continue
        loc, rng, fd = starts[k]
        print(f"   FDE {hex(loc)}..{hex(loc + rng)} ({rng} bytes)")
        aug = fd.augmentation_bytes or b""
        if not aug:
            print("   FDE sem LSDA (sem regioes de excecao tratadas)")
            continue
        lsda_va = fd.lsda_pointer  # pyelftools ja resolve o DW_EH_PE_pcrel da augmentation 'L'
        lenc = fd.cie.augmentation_dict.get('LSDA_encoding')
        if lsda_va is None:
            print('   FDE com augmentation mas sem LSDA')
            continue
        print(f"   LSDA @ {hex(lsda_va)} (enc {hex(lenc)})")
        off = lsda_va - gct["sh_addr"]
        if not (0 <= off < len(gdata)):
            print("   LSDA fora de .gcc_except_table")
            continue
        i = off
        lpstart_enc = gdata[i]
        i += 1
        if lpstart_enc != 0xFF:
            _, i = read_enc(gdata, i, lpstart_enc, gct["sh_addr"] + i)
        ttype_enc = gdata[i]
        i += 1
        if ttype_enc != 0xFF:
            _, i = uleb(gdata, i)
        cs_enc = gdata[i]
        i += 1
        cs_len, i = uleb(gdata, i)
        end = i + cs_len
        print(f"   call-site encoding {hex(cs_enc)}, tabela {cs_len} bytes")
        n = 0
        while i < end:
            st, i = read_enc(gdata, i, cs_enc & 0x0F, 0)
            ln, i = read_enc(gdata, i, cs_enc & 0x0F, 0)
            lp, i = read_enc(gdata, i, cs_enc & 0x0F, 0)
            act, i = uleb(gdata, i)
            n += 1
            lpa = hex(loc + lp) if lp else "-"
            print(f"   [{hex(loc + st)}, {hex(loc + st + ln)}) landing_pad={lpa} acao={act}")
        print(f"   {n} call-sites")


if __name__ == "__main__":
    main()
