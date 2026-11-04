"""Direct callers (bl/b) of methods selected by 'Type.Method' suffix, via the structural VA map. Static, read-only.
Virtual/interface/delegate calls are NOT seen here; absent callers means 'not called directly'.
Data lives in the main checkout's out/ (not versioned); override with --data."""
from __future__ import annotations
import argparse, bisect, json
from pathlib import Path
import numpy as np

DEFAULT_DATA = Path("/home/deppi/avatarworld-re/out/recon/il2cpp")


def main():
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument("targets", nargs="+", help="e.g. LevelItem.OnBeginDragInternal")
    ap.add_argument("--data", type=Path, default=DEFAULT_DATA)
    ap.add_argument("--output", type=Path)
    a = ap.parse_args()
    data = (a.data / "libil2cpp.so").read_bytes()
    rows = [json.loads(l) for l in (a.data / "assembly_csharp_methods.jsonl").open()]
    rows = [x for x in rows if x.get("vaddr")]
    delta = int(rows[0]["vaddr"], 16) - int(rows[0]["file_offset"], 16)
    starts = sorted((int(x["vaddr"], 16), x["declaring_type"] + "." + x["name"]) for x in rows)
    sv = [s for s, _ in starts]
    w = np.frombuffer(data[: len(data) // 4 * 4], dtype="<u4")
    hits = {}
    for op, kind in ((0x25, "bl"), (0x05, "b")):
        idx = np.nonzero((w >> 26) == op)[0]
        imm = (w[idx] & 0x3FFFFFF).astype(np.int64)
        imm = np.where(imm >= 1 << 25, imm - (1 << 26), imm)
        hits[kind] = (idx, idx * 4 + imm * 4 + delta)
    out = {}
    for t in a.targets:
        vas = [s for s, n in starts if n.endswith("." + t) or n == t]
        res = {}
        for tv in vas:
            for kind, (idx, tgt) in hits.items():
                for i in idx[tgt == tv]:
                    va = int(i) * 4 + delta
                    k = bisect.bisect_right(sv, va) - 1
                    res.setdefault(starts[k][1], set()).add(kind)
        out[t] = {"targets": [hex(v) for v in vas], "callers": {k: sorted(v) for k, v in sorted(res.items())}}
        print(t, [hex(v) for v in vas[:4]], len(vas), "target(s)")
        for k, v in out[t]["callers"].items():
            print("   ", k, "/".join(v))
    if a.output:
        a.output.write_text(json.dumps(out, indent=1) + "\n")


if __name__ == "__main__":
    main()
