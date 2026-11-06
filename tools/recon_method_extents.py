"""Validate method extents (start .. next method start) in Assembly-CSharp by inspecting the last instruction (static).
A method extent is 'proven' only if the last instruction before the next start is a terminator (ret, b, br, brk) or a
direct call to a noreturn helper (a bl target that ends many methods). Others are kept as 'unproven'.
Data lives in the main checkout's out/ (override with --data)."""
from __future__ import annotations
import argparse, collections, json, struct, sys
from pathlib import Path

sys.path.insert(0, str(Path(__file__).resolve().parent))
import recon_il2cpp as r  # noqa: E402

DEFAULT_DATA = Path("/home/deppi/avatarworld-re/out/recon/il2cpp")


def classify(w):
    if w == 0xD65F03C0: return "ret"
    if (w & 0xFC000000) == 0x14000000: return "b"
    if (w & 0xFFFFFC1F) == 0xD61F0000: return "br"
    if (w & 0xFFE0001F) == 0xD4200000: return "brk"
    if (w & 0xFC000000) == 0x94000000: return "bl"
    if (w & 0xFFFFFC1F) == 0xD65F0000: return "ret"
    return "other"


def main():
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument("--data", type=Path, default=DEFAULT_DATA)
    ap.add_argument("--output", type=Path, required=True)
    a = ap.parse_args()
    elf = r.Elf((a.data / "libil2cpp.so").read_bytes())
    rows = [json.loads(l) for l in (a.data / "assembly_csharp_methods.jsonl").open()]
    rows = [x for x in rows if x.get("vaddr")]
    starts = sorted({int(x["vaddr"], 16) for x in rows})
    nxt = {s: starts[i + 1] for i, s in enumerate(starts[:-1])}
    last_kind, bl_targets, per = collections.Counter(), collections.Counter(), {}
    for s in starts[:-1]:
        end = nxt[s]
        if end - s < 4 or end - s > 0x40000:
            per[s] = ("odd", end - s, None)
            continue
        w = struct.unpack_from("<I", elf.data, elf.offset(end - 4, 4))[0]
        k = classify(w)
        t = None
        if k == "bl":
            imm = w & 0x3FFFFFF
            imm = imm - (1 << 26) if imm >= 1 << 25 else imm
            t = end - 4 + imm * 4
            bl_targets[t] += 1
        per[s] = (k, end - s, t)
        last_kind[k] += 1
    noreturn = {t for t, c in bl_targets.items() if c >= 50}      # alvo que termina >= 50 metodos: helper noreturn
    proven = unproven = 0
    out = []
    for s in starts[:-1]:
        k, size, t = per[s]
        ok = k in ("ret", "b", "br", "brk") or (k == "bl" and t in noreturn)
        proven += ok
        unproven += (not ok)
        out.append({"vaddr": hex(s), "bytes": size, "last": k, "proven": ok})
    a.output.write_text("\n".join(json.dumps(e) for e in out) + "\n")
    print("methods:", len(starts) - 1, "| proven:", proven, "| unproven:", unproven)
    print("last instruction kinds:", dict(last_kind))
    print("noreturn helper targets:", [hex(t) for t in sorted(noreturn)][:8])


if __name__ == "__main__":
    main()
