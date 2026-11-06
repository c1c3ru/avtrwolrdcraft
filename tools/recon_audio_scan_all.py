"""Scan EVERY serialized MonoBehaviour row (out/mb) for string values that equal an AudioClip base name.
Output: per clip, the classes (and field names) that reference it; plus classes ranked by distinct clips referenced.
Complements recon_audio_coverage.py, which only looks at sound-looking classes/fields. Static, read-only."""
from __future__ import annotations
import argparse, collections, gzip, json, os, re
from pathlib import Path

ROOT = Path("/home/deppi/avatarworld-re")


def tokens(s):
    for part in re.split(r"[\^;|]", s):
        part = part.strip().replace("\\", "/").split("/")[-1]
        part = re.sub(r"\.(wav|mp3|ogg)$", "", part, flags=re.I)
        if part:
            yield part.lower()


def walk(prefix, v, out):
    if isinstance(v, str):
        if 2 < len(v) < 90:
            out.append((prefix, v))
    elif isinstance(v, list):
        for x in v[:200]:
            walk(prefix, x, out)
    elif isinstance(v, dict):
        for k, x in v.items():
            walk(k, x, out)


def main():
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument("--root", type=Path, default=ROOT)
    ap.add_argument("--output", type=Path, required=True)
    a = ap.parse_args()
    lower = {}
    for f in os.listdir(a.root / "out/assets/AudioClip"):
        m = re.match(r"(.+)_(\d+)\.\w+$", f)
        if m:
            lower[m.group(1).lower()] = m.group(1)
    refs = collections.defaultdict(lambda: collections.Counter())      # clip -> {class.field: n}
    cls_clips = collections.defaultdict(set)
    rows = 0
    for f in sorted((a.root / "out/mb").glob("*.jsonl.gz")):
        cls = f.name.replace(".jsonl.gz", "")
        for line in gzip.open(f, "rt"):
            rows += 1
            found = []
            walk("", json.loads(line), found)
            for field, val in found:
                for t in tokens(val):
                    if t in lower:
                        clip = lower[t]
                        refs[clip][cls + "." + field] += 1
                        cls_clips[cls].add(clip)
    out = {
        "rows_scanned": rows, "clips_referenced": len(refs),
        "classes_referencing_clips": len(cls_clips),
        "top_classes": sorted(((c, len(v)) for c, v in cls_clips.items()), key=lambda x: -x[1])[:30],
        "clips": {k: dict(v.most_common(3)) for k, v in sorted(refs.items())},
    }
    a.output.write_text(json.dumps(out, ensure_ascii=False) + "\n")
    print("rows", rows, "| clips referenced anywhere in serialized data:", len(refs), "| classes:", len(cls_clips))
    for c, n in out["top_classes"][:12]:
        print("  ", n, c)


if __name__ == "__main__":
    main()
