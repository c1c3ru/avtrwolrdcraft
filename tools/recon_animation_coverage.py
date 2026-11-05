"""Animation coverage per skeleton: which Spine animation names are referenced by name from
  1. the CA catalog (Resources/ContextualAnimations/ca-catalog.json, resolved with CreateAnimationName),
  2. code string literals (global-metadata.dat),
  3. any serialized string value in out/mb (full scan, same walk as recon_audio_scan_all.py).
Reports per skeleton: total animations, referenced, unreferenced; plus overall distinct names. Static, read-only.
A name that is not referenced here may still be played through names built at runtime (prefix + suffix); that is reported
separately through 'prefix' coverage (code literal ending in '/' or '_' that prefixes >= 3 names)."""
from __future__ import annotations
import argparse, collections, gzip, json, struct, sys
from pathlib import Path

sys.path.insert(0, str(Path(__file__).resolve().parent))
import recon_il2cpp as r  # noqa: E402

ROOT = Path("/home/deppi/avatarworld-re")


def walk(v, out):
    if isinstance(v, str):
        if 2 < len(v) < 120:
            out.add(v)
    elif isinstance(v, list):
        for x in v[:300]:
            walk(x, out)
    elif isinstance(v, dict):
        for x in v.values():
            walk(x, out)


def main():
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument("--root", type=Path, default=ROOT)
    ap.add_argument("--checkout", type=Path, default=Path(__file__).resolve().parent.parent)
    ap.add_argument("--output", type=Path, required=True)
    a = ap.parse_args()
    skel = collections.defaultdict(set)
    for line in (a.root / "out/recon/tasks/T032/skel-dump.jsonl").open():
        d = json.loads(line)
        skel[d["file"].split(".skel")[0]].update(x["Name"] for x in d.get("animations", []))
    all_names = set().union(*skel.values())

    cat = json.loads((a.checkout / "client/AvatarWorldClient/Assets/Resources/ContextualAnimations/ca-catalog.json").read_text(encoding="utf-8"))
    ca_names = set()
    for h in cat["handlers"]:
        prefix = h["spineType"] in (1, 2, 13)
        for c in h["configs"]:
            folder = c["folderNameOverride"] or h["folderName"]
            n = c["name"] if c["isNameFullAnimationName"] else (("CA/" if prefix else "") + folder + "/" + c["name"])
            for cand in (n, n.replace("CA/", "", 1), n + "__Sitting"):
                ca_names.add(cand)
            for extra in (c["alternateIdleAnimation"], c["preAnimation"]):
                if extra:
                    ca_names.update({extra, ("CA/" if prefix else "") + folder + "/" + extra})
        if h["lockedAnimation"]:
            ca_names.add(h["lockedAnimation"])

    meta = r.Metadata((a.root / "out/recon/il2cpp/global-metadata.dat").read_bytes())
    lt, lb = struct.unpack_from("<II", meta.data, 8)
    so, _ = struct.unpack_from("<II", meta.data, 16)
    lits = set()
    for i in range(lb // 8):
        ln, di = struct.unpack_from("<II", meta.data, lt + i * 8)
        lits.add(meta.data[so + di:so + di + ln].decode("utf-8", "replace"))

    serialized = set()
    for f in sorted((a.root / "out/mb").glob("*.jsonl.gz")):
        for line in gzip.open(f, "rt"):
            walk(json.loads(line), serialized)

    prefixes = [s for s in lits if (s.endswith("/") or s.endswith("_")) and 3 <= len(s) <= 40]
    per, tot = {}, collections.Counter()
    for sk, names in sorted(skel.items()):
        by_catalog = {n for n in names if n in ca_names}
        by_lit = {n for n in names if n in lits}
        by_ser = {n for n in names if n in serialized}
        by_prefix = {n for n in names if any(n.startswith(p) for p in prefixes)}
        exact = by_catalog | by_lit | by_ser
        per[sk] = {"animations": len(names), "referenced_exact": len(exact), "catalog": len(by_catalog), "code_literal": len(by_lit),
                   "serialized": len(by_ser), "covered_by_code_prefix_only": len(by_prefix - exact)}
    exact_all = {n for n in all_names if n in ca_names or n in lits or n in serialized}
    prefix_only = {n for n in all_names - exact_all if any(n.startswith(p) for p in prefixes)}
    out = {"skeletons": len(skel), "distinct_animation_names": len(all_names), "referenced_exact": len(exact_all),
           "covered_by_prefix_only": len(prefix_only), "unreferenced": len(all_names) - len(exact_all) - len(prefix_only),
           "per_skeleton": per}
    a.output.write_text(json.dumps(out, indent=1) + "\n")
    print({k: v for k, v in out.items() if k != "per_skeleton"})
    for sk in ("Avatar_Spine", "Toddler_Spine", "Baby_Spine", "Pet_Dog_Spine", "Pet_Cat_Spine", "Pet_Horse"):
        print(sk, per.get(sk))


if __name__ == "__main__":
    main()
