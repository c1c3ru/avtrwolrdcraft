#!/usr/bin/env python3
"""Lista os campos (nome e indice de tipo) de um tipo no global-metadata (v31) de um build.

uso: tools/venv/bin/python tools/recon_type_fields.py --data out/recon/il2cpp_1.230 HolidayConfig
"""
import argparse, struct, sys
from pathlib import Path

HERE = Path(__file__).resolve().parent
sys.path.insert(0, str(HERE))
import recon_il2cpp as r  # noqa: E402


def main():
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument("type_suffix")
    ap.add_argument("--data", type=Path, default=HERE.parent / "out" / "recon" / "il2cpp")
    a = ap.parse_args()
    d = r.Metadata((a.data / "global-metadata.dat").read_bytes()).data
    names = ["stringLiteral", "stringLiteralData", "string", "events", "properties", "methods", "parameterDefaultValues", "fieldDefaultValues",
             "fieldAndParameterDefaultValueData", "fieldMarshaledSizes", "parameters", "fields", "genericParameters", "genericParameterConstraints",
             "genericContainers", "nestedTypes", "interfaces", "vtableMethods", "interfaceOffsets", "typeDefinitions"]
    T = {n: struct.unpack_from("<ii", d, 8 + i * 8) for i, n in enumerate(names)}
    so = T["string"][0]
    s = lambda i: d[so + i:d.index(b"\0", so + i)].decode()
    for k in range(T["typeDefinitions"][1] // 88):
        ints = struct.unpack_from("<22i", d, T["typeDefinitions"][0] + k * 88)
        full = (s(ints[1]) + "." if s(ints[1]) else "") + s(ints[0])
        if full.endswith(a.type_suffix):
            fs, fc = ints[8], ints[17] & 0xFFFF
            print("%s  typedef %d  byvalTypeIndex %d  campos %d" % (full, k, ints[2], fc))
            for i in range(fc):
                nm, ty, tok = struct.unpack_from("<iii", d, T["fields"][0] + (fs + i) * 12)
                print("   [%d] %s  (tipo %d)" % (i, s(nm), ty))


if __name__ == "__main__":
    main()
