#!/usr/bin/env python3
"""Recover strings from MonoBehaviours whose class failed to decode in out/mb (the 126 classes of out/mb/_stats.json).

The typed dump (tools/mb_dump.py) cannot read those objects, so any animation, sound or label name they hold is missing from
every coverage count. This tool reads the raw bytes of exactly those objects, in bounded UnityFS block ranges (never the
whole bundle), and scans them for length-prefixed strings (int32 length + UTF-8 bytes) at every byte offset: Unity does not
align the length field after a bool.

Evidence level: a string found in the raw bytes of an object of class C is "C holds this string"; it does not say which field
or how the game uses it. Short or generic strings can occur by chance, so consumers must weigh them.

Needs UnityPy (use tools/venv/bin/python). Reads the datapack read-only.
"""
from __future__ import annotations

import argparse
import bisect
import json
import struct
from collections import defaultdict
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
MONOBEHAVIOUR = 114
MIN_LEN, MAX_LEN = 3, 160


class Bundle:
    """Random access to a UnityFS bundle's decompressed stream, decoding one block at a time."""

    def __init__(self, path: Path):
        from unityfs_extract_entry import decode, read_directory   # lazy: needs UnityPy (tools/venv)
        self._decode = decode
        self.source = path.open('rb')
        _, _, _, blocks, entries, packed = read_directory(self.source, path.stat().st_size)
        self.entries = entries
        self.spans, raw = [], 0
        for raw_size, packed_size, flags in blocks:
            self.spans.append((raw, raw + raw_size, packed, packed_size, flags))
            raw += raw_size
            packed += packed_size
        self.starts = [span[0] for span in self.spans]
        self.cached = (-1, b'')
        self.blocks_decoded = 0

    def read(self, start: int, size: int) -> bytes:
        end, index, parts = start + size, bisect.bisect_right(self.starts, start) - 1, []
        while index < len(self.spans) and self.spans[index][0] < end:
            left, right, packed, packed_size, flags = self.spans[index]
            if self.cached[0] != index:
                self.source.seek(packed)
                self.cached = (index, self._decode(self.source.read(packed_size), right - left, flags))
                self.blocks_decoded += 1
            parts.append(self.cached[1][max(start, left) - left:min(end, right) - left])
            index += 1
        data = b''.join(parts)
        if len(data) != size:
            raise ValueError(f'short read at {start}+{size}')
        return data


def printable(chunk: bytes) -> str | None:
    try:
        text = chunk.decode('utf-8')
    except UnicodeDecodeError:
        return None
    if any(ord(c) < 32 or ord(c) == 127 for c in text) or text.strip() != text or text.isdigit():
        return None
    return text


def scan_strings(data: bytes, start: int = 28) -> set[str]:
    found, size = set(), len(data)
    for i in range(start, size - 4 - MIN_LEN + 1):
        length = struct.unpack_from('<I', data, i)[0]
        if MIN_LEN <= length <= MAX_LEN and i + 4 + length <= size:
            text = printable(data[i + 4:i + 4 + length])
            if text is not None:
                found.add(text)
    return found


def script_classes(base_bundle: Path) -> dict[int, str]:
    import UnityPy
    env = UnityPy.load(str(base_bundle))
    result = {}
    for obj in env.objects:
        if obj.type.name == 'MonoScript':
            script = obj.read()
            result[obj.path_id] = f'{script.m_Namespace}.{script.m_ClassName}'.strip('.')
    return result


def run(datapack: Path, base_bundle: Path, stats: Path, limit_files: int = 0):
    from UnityPy.files.SerializedFile import SerializedFile
    from UnityPy.streams import EndianBinaryReader
    failing = set(json.loads(stats.read_text())['erros'])
    classes = script_classes(base_bundle)
    wanted = {pid for pid, name in classes.items() if name in failing}
    bundle = Bundle(datapack)
    per_class = defaultdict(lambda: {'objects': 0, 'strings': set(), 'files': set()})
    seen = scanned = mismatched = 0
    serialized = [e for e in bundle.entries if not e['path'].endswith('.resS') and e['size'] > 48]
    for number, entry in enumerate(serialized):
        if limit_files and number >= limit_files:
            break
        header = bundle.read(entry['offset'], 48)
        if struct.unpack_from('>I', header, 8)[0] < 22:
            continue
        metadata_end = struct.unpack_from('>q', header, 32)[0]
        if not 48 <= metadata_end <= entry['size']:
            continue
        asset = SerializedFile(EndianBinaryReader(bundle.read(entry['offset'], metadata_end)), name=entry['path'])
        objects = sorted((o for o in asset.objects.values() if o.class_id == MONOBEHAVIOUR), key=lambda o: o.byte_start)
        for obj in objects:
            seen += 1
            head = bundle.read(entry['offset'] + obj.byte_start, min(obj.byte_size, 28))
            if len(head) < 28:
                continue
            script_id = struct.unpack_from('<q', head, 20)[0]
            if script_id not in classes:
                mismatched += 1
                continue
            if script_id not in wanted:
                continue
            data = bundle.read(entry['offset'] + obj.byte_start, obj.byte_size)
            slot = per_class[classes[script_id]]
            slot['objects'] += 1
            slot['files'].add(entry['path'])
            slot['strings'] |= scan_strings(data)
            scanned += 1
    return {
        'schema_version': 1,
        'scope': 'raw length-prefixed strings of MonoBehaviours whose class failed to decode; evidence that the class holds a string, not how it is used',
        'bundle_blocks_decoded': bundle.blocks_decoded, 'monobehaviours_seen': seen, 'objects_scanned': scanned,
        'objects_with_unknown_script': mismatched, 'failing_classes': len(failing), 'classes_found': len(per_class),
        'classes': {name: {'objects': v['objects'], 'files': len(v['files']), 'strings': sorted(v['strings'])}
                    for name, v in sorted(per_class.items(), key=lambda kv: -kv[1]['objects'])},
    }


def summarize_report(report: dict) -> dict:
    """Small, versionable view: per class the object/file/string counts, without the strings themselves."""
    summary = {k: v for k, v in report.items() if k != 'classes'}
    summary['classes'] = {name: {'objects': info['objects'], 'files': info['files'], 'strings': len(info['strings'])}
                          for name, info in report['classes'].items()}
    return summary


if __name__ == '__main__':
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--datapack', type=Path, default=ROOT / 'x/data/assets/bin/Data/datapack.unity3d')
    parser.add_argument('--base', type=Path, default=ROOT / 'x/base/assets/bin/Data/data.unity3d')
    parser.add_argument('--stats', type=Path, default=ROOT / 'out/mb/_stats.json')
    parser.add_argument('--output', type=Path, default=ROOT / 'out/recon/undecoded_strings.json')
    parser.add_argument('--limit-files', type=int, default=0, help='debug: stop after N serialized files')
    parser.add_argument('--summary-output', type=Path, help='also write the small per-class summary here')
    args = parser.parse_args()
    report = run(args.datapack, args.base, args.stats, args.limit_files)
    args.output.parent.mkdir(parents=True, exist_ok=True)
    args.output.write_text(json.dumps(report, ensure_ascii=False) + '\n', encoding='utf-8')
    if args.summary_output:
        args.summary_output.parent.mkdir(parents=True, exist_ok=True)
        args.summary_output.write_text(json.dumps(summarize_report(report), indent=1, ensure_ascii=False) + '\n', encoding='utf-8')
    print({k: v for k, v in report.items() if k != 'classes'})
