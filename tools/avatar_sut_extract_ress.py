"""Extrai resources.assets.resS (stream de texturas) do datapack.unity3d, reaproveitando o
mesmo parser de blocos UnityFS do avatar_bundle_inventory.py. Necessario porque UnityPy le
Texture2D com m_StreamData de um arquivo .resS separado, que a extracao anterior nao copiou
(so pegou resources.assets). Uso: tools/venv/bin/python tools/avatar_sut_extract_ress.py
"""
import io
import json
import pathlib
import struct
import sys

ROOT = pathlib.Path(__file__).resolve().parents[1]
OUT = ROOT / 'out/assets'
from UnityPy.helpers import CompressionHelper  # noqa: E402


def cstr(stream):
    value = bytearray()
    while len(value) < 4096:
        b = stream.read(1)
        if not b:
            raise ValueError('string truncada')
        if b == b'\0':
            return value.decode('utf-8')
        value.extend(b)
    raise ValueError('string longa demais')


def number(stream, fmt):
    return struct.unpack('>' + fmt, stream.read(struct.calcsize('>' + fmt)))[0]


def decode(data, expected, flags):
    mode = flags & 63
    if mode == 0:
        result = data
    elif mode == 1:
        result = CompressionHelper.decompress_lzma(data)
    elif mode in (2, 3):
        result = CompressionHelper.decompress_lz4(data, expected)
    else:
        raise ValueError('compressao nao suportada: ' + str(mode))
    if len(result) != expected:
        raise ValueError('tamanho descomprimido divergente')
    return result

bundle = OUT / 'avatar-datapack.unity3d'
if not bundle.exists():
    raise SystemExit('avatar-datapack.unity3d ausente; rode avatar_bundle_inventory.py --extract-resources primeiro')

with bundle.open('rb') as source:
    if cstr(source) != 'UnityFS':
        raise ValueError('formato nao suportado')
    version = number(source, 'I')
    player, engine = cstr(source), cstr(source)
    size, compressed, uncompressed, flags = (number(source, x) for x in ('q', 'I', 'I', 'I'))
    source.seek((source.tell() + 15) & ~15)
    start = source.tell()
    if flags & 0x80:
        source.seek(size - compressed)
    info = io.BytesIO(decode(source.read(compressed), uncompressed, flags))
    source.seek(start if flags & 0x80 else start + compressed)
    if flags & 0x200:
        source.seek((source.tell() + 15) & ~15)
    info.read(16)
    blocks = [tuple(number(info, x) for x in ('I', 'I', 'H')) for _ in range(number(info, 'I'))]
    entries = []
    for _ in range(number(info, 'I')):
        offset, length, entry_flags = (number(info, x) for x in ('q', 'q', 'I'))
        entries.append({'path': cstr(info), 'offset': offset, 'size': length, 'flags': entry_flags})
    entry = next(e for e in entries if e['path'] == 'resources.assets.resS')
    print('target entry', entry, flush=True)
    target_path = OUT / 'resources.assets.resS'
    partial_path = target_path.with_suffix('.resS.part')
    with partial_path.open('wb') as target:
        raw_offset = 0
        written = 0
        for raw_size, packed_size, block_flags in blocks:
            left = max(entry['offset'], raw_offset)
            right = min(entry['offset'] + entry['size'], raw_offset + raw_size)
            if left < right:
                data = decode(source.read(packed_size), raw_size, block_flags)
                target.write(data[left - raw_offset:right - raw_offset])
                written += right - left
            else:
                source.seek(packed_size, 1)
            raw_offset += raw_size
            if raw_offset % (200 * 1024 * 1024) < raw_size:
                print('...', raw_offset, 'bytes de entrada processados', flush=True)
    if partial_path.stat().st_size != entry['size']:
        raise ValueError(f"arquivo extraido incompleto: {partial_path.stat().st_size} != {entry['size']}")
    partial_path.replace(target_path)
    print('OK', target_path, target_path.stat().st_size, 'bytes', flush=True)
