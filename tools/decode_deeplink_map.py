#!/usr/bin/env python3
"""Decodifica `PazuCore.DeepLink.DeepLinkManager._mapLinkToLevel` a partir dos bytes crus do MonoBehaviour.

Uso: python3 -I tools/decode_deeplink_map.py <bytes_crus.bin> <LevelType.cs> <saida.json>

O TypeTreeGenerator da UnityPy quebra em `SerializableDictionaryBase<K,V>`, entao o objeto (sharedassets1.assets, path_id 265, 6028 bytes) foi extraido cru
(`o.get_raw_data()`, com tools/lowmem_unitypy.py) e lido a mao. Layout provado: cabecalho MonoBehaviour (GameObject PPtr 12 bytes, m_Enabled+pad, Script PPtr 12 bytes,
m_Name string vazia) = 0x20 bytes, 3 ints zero (0x20..0x2b), depois TRES listas na ordem: chaves (N strings), chaves de novo (N strings; cópia do dicionario serializavel)
e valores (N int32 = `PWC.Game.LevelType`). Cada string = int32 tamanho + bytes + padding a 4. O arquivo inteiro e consumido (6028/6028 bytes).
"""
import json
import re
import struct
import sys


def main():
    raw = open(sys.argv[1], "rb").read()
    i = 0x2C

    def strings(i):
        n = struct.unpack_from("<i", raw, i)[0]
        i += 4
        out = []
        for _ in range(n):
            ln = struct.unpack_from("<i", raw, i)[0]
            i += 4
            out.append(raw[i:i + ln].decode("utf8"))
            i = (i + ln + 3) & ~3
        return out, i

    keys, i = strings(i)
    keys2, i = strings(i)
    n = struct.unpack_from("<i", raw, i)[0]
    i += 4
    levels = list(struct.unpack_from(f"<{n}i", raw, i))
    i += 4 * n
    assert i == len(raw), f"sobraram {len(raw) - i} bytes"
    assert keys == keys2 and len(keys) == n
    enum = {}
    for line in open(sys.argv[2]):
        m = re.match(r"\s*(\w+) = (\d+),", line)
        if m:
            enum[int(m.group(2))] = m.group(1)
    out = {k: {"level": v, "name": enum.get(v, "?")} for k, v in zip(keys, levels)}
    json.dump(out, open(sys.argv[3], "w"), indent=1)
    print(f"{n} entradas; sem nome no enum: {sorted({v for v in levels if v not in enum})}; {i}/{len(raw)} bytes")


if __name__ == "__main__":
    main()
