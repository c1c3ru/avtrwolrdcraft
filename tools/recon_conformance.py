"""Differential conformance check: the C# contracts versus values extracted from the ORIGINAL artifacts (T027).
For every check in tools/conformance_manifest.json it reads the original-side value (.rodata float, fmov immediate,
serialized field, enum stub, metadata string literal, skeleton animation name) and the C#-side value (regex/enum/contains)
and fails on any mismatch. Needs capstone for fmov immediates (pip install capstone in a venv).
Data lives in the main checkout's out/ (override with --root); the manifest and C# are read from this checkout."""
from __future__ import annotations
import argparse, gzip, json, re, struct, sys
from pathlib import Path

HERE = Path(__file__).resolve().parent
sys.path.insert(0, str(HERE))
import recon_il2cpp as r  # noqa: E402

DATA_ROOT = Path("/home/deppi/avatarworld-re")


def csharp_enum(text: str, name: str) -> dict:
    m = re.search(r"enum\s+" + re.escape(name) + r"\s*\{([^}]*)\}", text)
    if not m:
        raise ValueError("enum " + name + " not found in C#")
    out, nxt = {}, 0
    for part in m.group(1).split(","):
        part = part.strip()
        if not part:
            continue
        if "=" in part:
            k, v = [x.strip() for x in part.split("=")]
            nxt = int(v, 0)
        else:
            k = part
        out[k] = nxt
        nxt += 1
    return out


def stub_enum(text: str, name: str | None) -> dict:
    pat = r"enum\s+" + (re.escape(name) if name else r"\w+") + r"\s*\{([^}]*)\}"
    m = re.search(pat, text)
    if not m:
        raise ValueError("enum not found in stub")
    out = {}
    for line in m.group(1).splitlines():
        mm = re.match(r"\s*(\w+)\s*=\s*(-?\d+)", line)
        if mm:
            out[mm.group(1)] = int(mm.group(2))
    return out


def main():
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument("--manifest", type=Path, default=HERE / "conformance_manifest.json")
    ap.add_argument("--root", type=Path, default=DATA_ROOT, help="checkout that holds out/ (not versioned)")
    ap.add_argument("--checkout", type=Path, default=HERE.parent, help="checkout whose C# sources are checked")
    a = ap.parse_args()
    manifest = json.loads(a.manifest.read_text(encoding="utf-8"))
    cs_root = a.checkout / manifest["csharp_root"]
    il2 = a.root / "out/recon/il2cpp"
    elf = r.Elf((il2 / "libil2cpp.so").read_bytes())
    meta = r.Metadata((il2 / "global-metadata.dat").read_bytes())
    lt, lb = struct.unpack_from("<II", meta.data, 8)
    so, _ = struct.unpack_from("<II", meta.data, 16)
    literals = set()
    for i in range(lb // 8):
        ln, di = struct.unpack_from("<II", meta.data, lt + i * 8)
        literals.add(meta.data[so + di:so + di + ln].decode("utf-8", "replace"))
    anims: dict = {}
    for line in (a.root / "out/recon/tasks/T032/skel-dump.jsonl").open():
        d = json.loads(line)
        anims.setdefault(d["file"].split(".skel")[0], set()).update(x["Name"] for x in d.get("animations", []))
    cap = None

    fails, total = [], 0
    for c in manifest["checks"]:
        total += 1
        try:
            src = (cs_root / c["csharp"]["file"]).read_text(encoding="utf-8")
            k = c["kind"]
            if k in ("float_rodata", "fmov_immediate", "serialized_value"):
                if k == "float_rodata":
                    va = int(c["va"], 16)
                    orig = struct.unpack_from("<f", elf.data, elf.offset(va, 4))[0]
                elif k == "fmov_immediate":
                    if cap is None:
                        from capstone import Cs, CS_ARCH_ARM64, CS_MODE_ARM
                        cap = Cs(CS_ARCH_ARM64, CS_MODE_ARM)
                    va = int(c["va"], 16)
                    ins = next(cap.disasm(elf.data[elf.offset(va, 4):elf.offset(va, 4) + 4], va))
                    mm = re.search(r"#(-?[0-9.]+)", ins.op_str)
                    if ins.mnemonic != "fmov" or not mm:
                        raise ValueError("not an fmov immediate at " + c["va"] + ": " + ins.mnemonic + " " + ins.op_str)
                    orig = float(mm.group(1))
                else:
                    vals = {json.loads(l)[c["field"]] for l in gzip.open(a.root / f"out/mb/{c['mb']}.jsonl.gz", "rt")}
                    if len(vals) != 1:
                        raise ValueError("field has several values: " + str(sorted(vals)))
                    orig = float(next(iter(vals)))
                got = float(re.search(c["csharp"]["regex"], src).group(1))
                if abs(orig - c["expect"]) > 1e-6 * max(1.0, abs(c["expect"])):
                    raise ValueError(f"original {orig} != manifest {c['expect']}")
                if abs(got - orig) > 1e-6 * max(1.0, abs(orig)):
                    raise ValueError(f"C# {got} != original {orig}")
            elif k == "enum":
                stub = (a.root / "out/cpp2il/DiffableCs/Assembly-CSharp" / c["stub"]).read_text(errors="ignore")
                orig = stub_enum(stub, c.get("stub_enum"))
                mine = csharp_enum(src, c["csharp"]["enum"])
                mapping = c["csharp"].get("csharp_names", {})
                for name, val in orig.items():
                    cname = mapping.get(name, name)
                    if mine.get(cname) != val:
                        raise ValueError(f"{name}={val} in original, C# {cname}={mine.get(cname)}")
            elif k == "string_literal":
                if c["text"] not in literals:
                    raise ValueError("literal not found in the original metadata")
                if '"' + c["text"] + '"' not in src:
                    raise ValueError("exact literal not present in C# source")
            elif k == "animations":
                pool = anims.get(c["skeleton"])
                if pool is None:
                    raise ValueError("skeleton not found: " + c["skeleton"])
                missing = [n for n in c["names"] if n not in pool]
                if missing:
                    raise ValueError("not in skeleton: " + str(missing))
                absent = [s for s in c["csharp"].get("contains", []) if '"' + s + '"' not in src]
                if absent:
                    raise ValueError("not in C# source: " + str(absent))
            else:
                raise ValueError("unknown kind " + k)
        except Exception as e:  # noqa: BLE001
            fails.append((c["id"], str(e)))
    for cid, msg in fails:
        print("FAIL", cid, "-", msg)
    print(f"conformance: {total - len(fails)}/{total} checks pass")
    sys.exit(1 if fails else 0)


if __name__ == "__main__":
    main()
