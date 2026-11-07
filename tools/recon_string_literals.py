"""Resolve adrp+ldr GOT operands in asm windows to IL2CPP metadata-usage literals (static, read-only)."""
from __future__ import annotations
import argparse, json, re, struct, sys
from pathlib import Path
ROOT = Path(__file__).resolve().parents[1]
sys.path.insert(0, str(ROOT / "tools"))
import recon_il2cpp as r  # noqa: E402

ADRP = re.compile(r"^\s*([0-9a-f]+):\s+[0-9a-f]{8}\s+adrp\s+(x\d+),\s+0x([0-9a-f]+)")
LDR = re.compile(r"^\s*([0-9a-f]+):\s+[0-9a-f]{8}\s+ldr\s+(x\d+),\s+\[(x\d+),\s+#0x([0-9a-f]+)\]")
KINDS = {1: "type", 2: "typeinfo?", 3: "method?", 4: "field?", 5: "string"}

def main():
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument("asm", nargs="+", type=Path)
    ap.add_argument("--output", type=Path, required=True)
    a = ap.parse_args()
    d = ROOT / "out/recon/il2cpp"
    meta = r.Metadata((d / "global-metadata.dat").read_bytes()); elf = r.Elf((d / "libil2cpp.so").read_bytes())
    lit_tab, lit_bytes = struct.unpack_from("<II", meta.data, 8)
    str_off, str_bytes = struct.unpack_from("<II", meta.data, 16)
    out = {}
    for f in a.asm:
        pages, seen = {}, {}
        for line in f.read_text().splitlines():
            m = ADRP.match(line)
            if m: pages[m.group(2)] = int(m.group(3), 16); continue
            m = LDR.match(line)
            if not m or m.group(3) not in pages: continue
            got = pages[m.group(3)] + int(m.group(4), 16)
            try:
                usage = elf.pointer(got)
                enc = struct.unpack_from("<Q", elf.data, elf.offset(usage, 8))[0]
            except Exception:
                continue
            kind, idx = enc >> 29, (enc & 0x1fffffff) >> 1
            if got in seen: continue
            row = {"insn": m.group(1), "got": hex(got), "kind": KINDS.get(kind, kind), "index": idx}
            if kind == 5 and idx < lit_bytes // 8:
                ln, di = struct.unpack_from("<II", meta.data, lit_tab + idx * 8)
                row["literal"] = meta.data[str_off + di:str_off + di + ln].decode("utf-8", "replace")
            seen[got] = row
        out[f.name] = list(seen.values())
        print(f.name, [x.get("literal") for x in seen.values() if "literal" in x])
    a.output.write_text(json.dumps(out, indent=1, ensure_ascii=False) + "\n")

if __name__ == "__main__":
    main()
