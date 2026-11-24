#!/usr/bin/env python3
"""Extrai arquivos de um bundle UnityFS (formato 6-8) descomprimindo bloco a bloco, sem carregar o bundle inteiro em memoria.

Motivo: UnityPy passa de 5,8 GB de RSS so para abrir o datapack.unity3d (docs/RECON_DUMP_ERRORS_2026-11-07.md). Aqui a memoria e do tamanho de um bloco.
Suporta blocos LZ4/LZ4HC e sem compressao; LZMA nao (falha com mensagem clara). Cabecalho de blocks-info comprimido com LZ4/LZ4HC.

uso:
  tools/venv/bin/python tools/unityfs_extract.py BUNDLE --list
  tools/venv/bin/python tools/unityfs_extract.py BUNDLE --extract NOME [NOME ...] --out DIR     (NOME = nome exato do no)
"""
import argparse, struct, sys
from pathlib import Path
import lz4.block


def read_header(f):
    sig = f.read(8)
    if sig != b"UnityFS\x00":
        raise SystemExit("nao e UnityFS: %r" % sig)
    ver = struct.unpack(">I", f.read(4))[0]

    def cstr():
        b = bytearray()
        while True:
            c = f.read(1)
            if c == b"\0":
                return b.decode()
            b += c

    cstr(); cstr()
    size, csz, usz, flags = struct.unpack(">qIII", f.read(20))
    return ver, size, csz, usz, flags


def decompress(data, kind, usize):
    if kind == 0:
        return data
    if kind in (2, 3):
        return lz4.block.decompress(data, uncompressed_size=usize)
    raise SystemExit("compressao %d (LZMA?) nao suportada" % kind)


def parse(path):
    f = open(path, "rb")
    ver, size, csz, usz, flags = read_header(f)
    if ver >= 7:  # alinhamento de 16 bytes antes do blocks-info
        f.seek((f.tell() + 15) & ~15)
    if flags & 0x80:
        raise SystemExit("blocks-info no fim do arquivo: nao suportado")
    info = decompress(f.read(csz), flags & 0x3F, usz)
    data_start = f.tell()
    if ver >= 7 and (flags & 0x200):
        data_start = (data_start + 15) & ~15
    p = 16  # hash do blocks-info
    nblocks = struct.unpack_from(">i", info, p)[0]; p += 4
    blocks = []
    for _ in range(nblocks):
        u, c, fl = struct.unpack_from(">IIH", info, p); p += 10
        blocks.append((u, c, fl))
    nnodes = struct.unpack_from(">i", info, p)[0]; p += 4
    nodes = []
    for _ in range(nnodes):
        off, sz, fl = struct.unpack_from(">qqI", info, p); p += 20
        end = info.index(b"\0", p)
        nodes.append((info[p:end].decode(), off, sz, fl)); p = end + 1
    return f, data_start, blocks, nodes


def main():
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument("bundle", type=Path)
    ap.add_argument("--list", action="store_true")
    ap.add_argument("--extract", nargs="+", default=[])
    ap.add_argument("--out", type=Path, default=Path("."))
    a = ap.parse_args()
    f, data_start, blocks, nodes = parse(a.bundle)
    if a.list or not a.extract:
        print("blocos:", len(blocks), "| compressao dos blocos:", sorted({b[2] & 0x3F for b in blocks}), "| descomprimido total:", sum(b[0] for b in blocks))
        for name, off, sz, fl in nodes:
            print("%12d  off %12d  flags %d  %s" % (sz, off, fl, name))
        return
    want = {n: [] for n in a.extract}
    a.out.mkdir(parents=True, exist_ok=True)
    outs = {}
    for name, off, sz, fl in nodes:
        if name in want:
            outs[name] = (open(a.out / name, "wb"), off, off + sz)
    if not outs:
        raise SystemExit("nenhum dos nos pedidos existe")
    f.seek(data_start)
    pos = 0
    for u, c, fl in blocks:
        raw = f.read(c)
        end = pos + u
        needed = [(n, o) for n, o in outs.items() if o[1] < end and o[2] > pos]
        if needed:
            buf = decompress(raw, fl & 0x3F, u)
            for n, (fh, lo, hi) in needed:
                s, e = max(lo, pos) - pos, min(hi, end) - pos
                fh.write(buf[s:e])
        pos = end
    for n, (fh, lo, hi) in outs.items():
        fh.close()
        print("extraido", n, hi - lo, "bytes")


if __name__ == "__main__":
    main()
