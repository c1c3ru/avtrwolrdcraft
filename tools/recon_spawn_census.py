"""Count character/spawner script components per scene from inspector reports (static)."""
from __future__ import annotations
import argparse, collections, hashlib, json, re
from pathlib import Path
ROOT = Path(__file__).resolve().parents[1]
PAT = re.compile(r"Character|Avatar|Spawn|Cat$|Dog$|Horse|Toddler|Baby|Animal|Rider|Pet$|NPC|Seat|Mount", re.I)

def main():
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument("reports", nargs="+", type=Path)
    ap.add_argument("--output", type=Path, required=True)
    a = ap.parse_args()
    out = {"scenes": {}}
    for r in a.reports:
        r = r.resolve(); d = json.loads(r.read_text(encoding="utf-8"))
        c = collections.Counter()
        for row in d["behaviours"]:
            s = row["script"]; n = (s["namespace"] + "." if s["namespace"] else "") + s["name"]
            if PAT.search(s["name"]): c[n] += 1
        out["scenes"][d["level"]] = {"report": str(r.relative_to(ROOT)),
            "sha256": hashlib.sha256(r.read_bytes()).hexdigest(),
            "behaviours": len(d["behaviours"]), "matching": dict(sorted(c.items()))}
    a.output.write_text(json.dumps(out, indent=2, ensure_ascii=False) + "\n")
    for k, v in out["scenes"].items(): print(k, v["behaviours"], v["matching"])

if __name__ == "__main__":
    main()
