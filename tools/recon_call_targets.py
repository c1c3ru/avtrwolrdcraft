"""Resolve direct bl targets in extracted asm windows to methods via the structural VA map."""
from __future__ import annotations
import argparse, json, re
from pathlib import Path
ROOT = Path(__file__).resolve().parents[1]
BL = re.compile(r"^\s*([0-9a-f]+):\s+[0-9a-f]{8}\s+bl\s+0x([0-9a-f]+)")

def main():
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument("asm", nargs="+", type=Path)
    ap.add_argument("--map", type=Path, default=ROOT / "out/recon/il2cpp/assembly_csharp_methods.jsonl")
    ap.add_argument("--output", type=Path, required=True)
    a = ap.parse_args()
    va = {}
    for line in a.map.open(encoding="utf-8"):
        r = json.loads(line)
        if not r.get("vaddr"): continue
        va.setdefault(int(r["vaddr"], 16), r["declaring_type"] + "." + r["name"])
    out = {}
    for f in a.asm:
        calls, unres = [], {}
        for line in f.read_text().splitlines():
            m = BL.match(line)
            if not m: continue
            t = int(m.group(2), 16)
            if t in va: calls.append(va[t])
            else: unres[hex(t)] = unres.get(hex(t), 0) + 1
        out[f.name] = {"resolved": calls, "unresolved_targets": unres}
        print(f.name, "->", sorted(set(calls)), "unresolved:", len(unres))
    a.output.write_text(json.dumps(out, indent=1) + "\n")

if __name__ == "__main__":
    main()
