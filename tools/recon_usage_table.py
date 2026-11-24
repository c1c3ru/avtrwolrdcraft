#!/usr/bin/env python3
"""Tabela de usos de metadata do IL2CPP (as entradas da .data apontadas pela .got): quais sao tokens validos e quais nao.

O codigo do jogo carrega `ldr x0, [GOT]` -> endereco A na .data e chama `InitializeRuntimeMetadata(A)` (0x1b561d0). Essa funcao le *A:
  bit0 == 0           -> ja e ponteiro resolvido, devolve como esta;
  bit0 == 1           -> token: tag = (v >> 29) & 7, indice = (v >> 1) & 0x0FFFFFFF; tag 1 = tipo/classe, 3 = metodo (MethodDef),
                         4 = campo (fieldRefs: tipo + indice), 5 = string literal, 6 = MethodRef (generico).
Este script classifica cada entrada e lista os blocos contiguos que NAO sao tokens de 32 bits.

uso: tools/venv/bin/python tools/recon_usage_table.py [--data out/recon/il2cpp]
"""
import argparse, collections, struct, zlib
from pathlib import Path
import sys

HERE = Path(__file__).resolve().parent
sys.path.insert(0, str(HERE))
import recon_il2cpp as r  # noqa: E402


def main():
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument("--data", type=Path, default=HERE.parent / "out" / "recon" / "il2cpp")
    a = ap.parse_args()
    elf = r.Elf((a.data / "libil2cpp.so").read_bytes())
    got = next(s for s in elf.sections if s["name"] == ".got")
    data = next(s for s in elf.sections if s["name"] == ".data")
    lo, hi = data["vaddr"], data["vaddr"] + data["bytes"]
    targets = sorted({elf.relocations[v] for v in range(got["vaddr"], got["vaddr"] + got["bytes"], 8) if v in elf.relocations})
    targets = [t for t in targets if lo <= t < hi]
    tags, nontoken = collections.Counter(), []
    for t in targets:
        v = struct.unpack_from("<Q", elf.data, elf.offset(t, 8))[0]
        if v == 0:
            tags["zero"] += 1
        elif v < 2 ** 32 and v & 1:
            tags["tag%d" % (v >> 29)] += 1
        else:
            nontoken.append(t)
    print("entradas na .data apontadas pela .got:", len(targets))
    print("tokens por tag:", dict(sorted(tags.items())), "| nao-token:", len(nontoken))
    runs, cur = [], None
    for t in nontoken:
        if cur and t == cur[1] + 8:
            cur[1] = t
        else:
            if cur:
                runs.append(cur)
            cur = [t, t]
    if cur:
        runs.append(cur)
    for s, e in runs:
        n = (e - s) // 8 + 1
        raw = elf.data[elf.offset(s, n * 8):][: n * 8]
        vals = struct.unpack("<%dQ" % n, raw)
        print("bloco %#x..%#x  %d entradas | metades baixas distintas %d | metades altas distintas %d | zlib %.2f | bit0=1 em %d%%" % (
            s, e, n, len({v & 0xFFFFFFFF for v in vals}), len({v >> 32 for v in vals}), len(zlib.compress(raw, 9)) / len(raw),
            100 * sum(v & 1 for v in vals) // n))


if __name__ == "__main__":
    main()
