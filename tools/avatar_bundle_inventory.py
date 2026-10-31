"""Inventaria paths SUT preservando (arquivo, path_id), sem carregar o bundle inteiro.
Uso: tools/venv/bin/python tools/avatar_bundle_inventory.py [--extract-resources | --list-only]
Entrada local em assets/; saidas derivadas em out/assets/ (ignoradas no Git).
Suporta somente UnityFS v7+ sem criptografia, com compressao 0/1/2/3.
"""
import argparse
import io
import json
import pathlib
import shutil
import struct
import sys
import zipfile

ROOT = pathlib.Path(__file__).resolve().parents[1]
OUT = ROOT / 'out/assets'
OUT.mkdir(parents=True, exist_ok=True)


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


parser = argparse.ArgumentParser(description=__doc__)
parser.add_argument('--list-only', action='store_true', help='Inspeciona o diretorio UnityFS e termina; requer extrair o bundle de 1.3 GB.')
parser.add_argument('--extract-resources', action='store_true', help='Extrai resources.assets por blocos (opcional, nao necessario para indexar os PNGs existentes).')
parser.add_argument('--force', action='store_true', help='Refaz arquivo serializado derivado se --extract-resources estiver ativo.')
args = parser.parse_args()
from UnityPy.helpers import CompressionHelper

if args.extract_resources or args.list_only:
    bundle = OUT / 'avatar-datapack.unity3d'
    if not bundle.exists():
        with zipfile.ZipFile(ROOT / 'assets/split_UnityDataAssetPack.apk') as archive:
            with archive.open('assets/bin/Data/datapack.unity3d') as source, bundle.open('wb') as target:
                shutil.copyfileobj(source, target, 8 * 1024 * 1024)
    with bundle.open('rb') as source:
        if cstr(source) != 'UnityFS':
            raise ValueError('formato nao suportado')
        version = number(source, 'I')
        player, engine = cstr(source), cstr(source)
        size, compressed, uncompressed, flags = (number(source, x) for x in ('q', 'I', 'I', 'I'))
        if version < 7 or flags & ~0x3ff or size != bundle.stat().st_size:
            raise ValueError('header nao suportado ou tamanho divergente')
        if flags & 0x400 or uncompressed > 32 * 1024 * 1024:
            raise ValueError('metadata fora do limite')
        source.seek((source.tell() + 15) & ~15)
        start = source.tell()
        if flags & 0x80:
            source.seek(size - compressed)
        info = io.BytesIO(decode(source.read(compressed), uncompressed, flags))
        source.seek(start if flags & 0x80 else start + compressed)
        if flags & 0x200:
            source.seek((source.tell() + 15) & ~15)
        data_start = source.tell()
        info.read(16)
        blocks = [tuple(number(info, x) for x in ('I', 'I', 'H')) for _ in range(number(info, 'I'))]
        entries = []
        for _ in range(number(info, 'I')):
            offset, length, entry_flags = (number(info, x) for x in ('q', 'q', 'I'))
            entries.append({'path': cstr(info), 'offset': offset, 'size': length, 'flags': entry_flags})
        (OUT / 'avatar-bundle-directory.json').write_text(json.dumps(entries, indent=2))
        entry = next(e for e in entries if e['path'] == 'resources.assets')
        print('UnityFS', version, engine, 'entries', len(entries), 'resources', entry, flush=True)
        if args.list_only:
            sys.exit(0)
        target_path = OUT / 'resources.assets'
        if args.force or not target_path.exists() or target_path.stat().st_size != entry['size']:
            partial_path = target_path.with_suffix('.assets.part')
            with partial_path.open('wb') as target:
                raw_offset = 0
                for raw_size, packed_size, block_flags in blocks:
                    if raw_size > 64 * 1024 * 1024:
                        raise ValueError('bloco fora do limite de memoria')
                    left = max(entry['offset'], raw_offset)
                    right = min(entry['offset'] + entry['size'], raw_offset + raw_size)
                    if left < right:
                        data = decode(source.read(packed_size), raw_size, block_flags)
                        target.write(data[left - raw_offset:right - raw_offset])
                    else:
                        source.seek(packed_size, 1)
                    raw_offset += raw_size
            if partial_path.stat().st_size != entry['size']:
                raise ValueError('arquivo extraido incompleto')
            partial_path.replace(target_path)
# ResourceManager fica no data.unity3d do APK base, nao em resources.assets.
# Ler apenas resources.assets produz env.container vazio e perde todos os paths SUT.
import UnityPy
base_path = ROOT / 'assets/base.apk'
if not base_path.exists():
    base_path = ROOT / 'apk/base.apk'
print('reading ResourceManager from base APK', flush=True)
with zipfile.ZipFile(base_path) as archive:
    base_data = archive.read('assets/bin/Data/data.unity3d')
env = UnityPy.load(base_data)
result = []
managers = 0
for obj in env.objects:
    if obj.type.name != 'ResourceManager':
        continue
    managers += 1
    file = obj.assets_file
    externals = [pathlib.PurePosixPath(e.path.replace('\\', '/')).name for e in file.externals]
    for path, ptr in obj.read_typetree()['m_Container']:
        if not path.lower().startswith('sutsystem/skins/character/'):
            continue
        file_id = ptr['m_FileID']
        if file_id < 0 or file_id > len(externals):
            raise ValueError('referencia externa invalida')
        target_file = file.name if file_id == 0 else externals[file_id - 1]
        result.append({'path': path, 'file': target_file, 'path_id': ptr['m_PathID']})
if not managers or not result:
    raise ValueError('Nenhum path SUT Character encontrado; inventario NAO concluido')
output = OUT / 'avatar-resources.json'
partial = output.with_suffix('.json.tmp')
partial.write_text(json.dumps(result, indent=2))
partial.replace(output)
print('SUT Character refs:', len(result), 'unique paths:', len({r['path'] for r in result}),
      'files:', sorted({r['file'] for r in result}), 'output:', output, flush=True)
