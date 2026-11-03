#!/usr/bin/env python3
"""Extract one file from a UnityFS archive without materializing the whole bundle.

The UnityFS block stream is decoded only for blocks overlapping the requested entry.
The source archive and unrelated entries are never modified. Output is written via a
temporary sibling and atomic rename.

Example:
  tools/venv/bin/python tools/unityfs_extract_entry.py level8
"""
import argparse
import io
import os
from pathlib import Path, PurePosixPath
import struct
import sys

from UnityPy.helpers import CompressionHelper

ROOT = Path(__file__).resolve().parents[1]
DEFAULT_BUNDLE = ROOT / "out/assets/avatar-datapack.unity3d"
DEFAULT_OUTPUT = ROOT / "out/scene-extract"


def cstr(stream):
    value = bytearray()
    while len(value) < 4096:
        byte = stream.read(1)
        if not byte:
            raise ValueError("UnityFS string truncated")
        if byte == b"\0":
            return value.decode("utf-8")
        value.extend(byte)
    raise ValueError("UnityFS string exceeds limit")


def number(stream, fmt):
    size = struct.calcsize(">" + fmt)
    data = stream.read(size)
    if len(data) != size:
        raise ValueError("UnityFS metadata truncated")
    return struct.unpack(">" + fmt, data)[0]


def decode(data, expected, flags):
    mode = flags & 63
    if mode == 0:
        result = data
    elif mode == 1:
        result = CompressionHelper.decompress_lzma(data)
    elif mode in (2, 3):
        result = CompressionHelper.decompress_lz4(data, expected)
    else:
        raise ValueError("unsupported UnityFS compression: " + str(mode))
    if len(result) != expected:
        raise ValueError("UnityFS block size mismatch")
    return result


def read_directory(source, archive_size):
    if cstr(source) != "UnityFS":
        raise ValueError("not a UnityFS archive")
    version = number(source, "I")
    player, engine = cstr(source), cstr(source)
    declared_size, compressed, uncompressed, flags = (
        number(source, fmt) for fmt in ("q", "I", "I", "I")
    )
    if version < 7 or flags & ~0x3ff or declared_size != archive_size:
        raise ValueError("unsupported UnityFS header or archive size mismatch")
    if flags & 0x400 or uncompressed > 32 * 1024 * 1024:
        raise ValueError("UnityFS metadata exceeds configured safety bound")
    source.seek((source.tell() + 15) & ~15)
    blocks_start = source.tell()
    if flags & 0x80:
        source.seek(declared_size - compressed)
    metadata = io.BytesIO(decode(source.read(compressed), uncompressed, flags))
    source.seek(blocks_start if flags & 0x80 else blocks_start + compressed)
    if flags & 0x200:
        source.seek((source.tell() + 15) & ~15)
    data_start = source.tell()
    metadata.read(16)
    block_count = number(metadata, "I")
    blocks = [tuple(number(metadata, fmt) for fmt in ("I", "I", "H"))
              for _ in range(block_count)]
    entries = []
    for _ in range(number(metadata, "I")):
        offset, size, entry_flags = (number(metadata, fmt) for fmt in ("q", "q", "I"))
        entries.append({"path": cstr(metadata), "offset": offset,
                        "size": size, "flags": entry_flags})
    return version, player, engine, blocks, entries, data_start


def extract(bundle, entry_name, destination):
    size_on_disk = bundle.stat().st_size
    with bundle.open("rb") as source:
        version, player, engine, blocks, entries, data_start = read_directory(source, size_on_disk)
        matches = [entry for entry in entries if entry["path"] == entry_name]
        if len(matches) != 1:
            available = [entry["path"] for entry in entries if entry_name in entry["path"]][:8]
            raise ValueError(f"expected exactly one entry {entry_name!r}, found {len(matches)}; similar={available}")
        entry = matches[0]
        safe_parts = PurePosixPath(entry["path"]).parts
        if not safe_parts or any(part in ("..", ".") for part in safe_parts):
            raise ValueError("unsafe archive entry path")
        destination.parent.mkdir(parents=True, exist_ok=True)
        temp = destination.with_name(destination.name + ".part")
        raw_offset = 0
        packed_offset = data_start
        with temp.open("wb") as target:
            for raw_size, packed_size, block_flags in blocks:
                left = max(entry["offset"], raw_offset)
                right = min(entry["offset"] + entry["size"], raw_offset + raw_size)
                if left < right:
                    if raw_size > 64 * 1024 * 1024:
                        raise ValueError("overlapping block exceeds 64 MiB memory bound")
                    source.seek(packed_offset)
                    data = decode(source.read(packed_size), raw_size, block_flags)
                    target.write(data[left - raw_offset:right - raw_offset])
                raw_offset += raw_size
                packed_offset += packed_size
            target.flush()
            os.fsync(target.fileno())
        if temp.stat().st_size != entry["size"]:
            temp.unlink(missing_ok=True)
            raise ValueError("extracted entry size mismatch")
        temp.replace(destination)
    return {"entry": entry, "unityfs_version": version, "player": player,
            "engine": engine, "output": str(destination), "bytes": destination.stat().st_size}


def main(argv=None):
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("entry", help="exact UnityFS directory entry, e.g. level8")
    parser.add_argument("--bundle", type=Path, default=DEFAULT_BUNDLE)
    parser.add_argument("--output-dir", type=Path, default=DEFAULT_OUTPUT)
    parser.add_argument("--force", action="store_true", help="replace only the selected generated entry")
    args = parser.parse_args(argv)
    try:
        if not args.bundle.is_file():
            raise ValueError("bundle unavailable: " + str(args.bundle))
        relative = PurePosixPath(args.entry)
        if relative.is_absolute() or any(part in ("..", ".") for part in relative.parts):
            raise ValueError("entry must be a safe relative archive path")
        output_root = args.output_dir.resolve()
        destination = (output_root / Path(*relative.parts)).resolve()
        if output_root not in destination.parents:
            raise ValueError("destination escapes output directory")
        if destination.exists() and not args.force:
            raise ValueError("output exists; use --force to replace this generated entry")
        result = extract(args.bundle, args.entry, destination)
        print(f"extracted {result['entry']['path']}: {result['bytes']} bytes -> {result['output']}")
        print(f"UnityFS v{result['unityfs_version']}, Unity {result['engine']}, player {result['player']}")
        return 0
    except (OSError, ValueError) as error:
        print("unityfs_extract_entry:", error, file=sys.stderr)
        return 2


if __name__ == "__main__":
    sys.exit(main())
