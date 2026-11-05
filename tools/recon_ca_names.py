"""Check Contextual Animation configs (LevelCAItemHandlerData in out/mb) against skeleton animation names (skel-dump.jsonl).
Hypothesis under test for LevelCAConfig.CreateAnimationName: 'CA/{folder}/{name}', or just {name} when isNameFullAnimationName.
folder = folderNameOverride or the handler FolderName. Static, read-only; data lives in the main checkout's out/."""
from __future__ import annotations
import argparse, collections, gzip, json
from pathlib import Path

ROOT = Path("/home/deppi/avatarworld-re")
SPINE = {1: "Avatar_Spine", 13: "Toddler_Spine", 2: "Baby_Spine", 3: "Pet_Cat_Spine", 4: "Pet_Dog_Spine", 14: "Pet_Horse"}


def main():
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument("--root", type=Path, default=ROOT)
    ap.add_argument("--output", type=Path, required=True)
    a = ap.parse_args()
    anims = collections.defaultdict(set)
    for l in (a.root / "out/recon/tasks/T032/skel-dump.jsonl").open():
        r = json.loads(l)
        anims[r["file"].split(".skel")[0]].update(x["Name"] for x in r.get("animations", []))
    cls = "PWC.PSDToLevel.LevelContextualAnimation.LevelCAItemHandlerData"
    stats = collections.Counter()
    misses, by_type = [], collections.Counter()
    form = collections.Counter()
    seen = set()
    for l in gzip.open(a.root / f"out/mb/{cls}.jsonl.gz", "rt"):
        h = json.loads(l)
        sk = SPINE.get(h.get("CharacterSpineType"))
        by_type[h.get("CharacterSpineType")] += 1
        for c in h.get("LevelCAConfigs", []):
            key = (h["m_Name"], c["name"], c.get("folderNameOverride", ""), h.get("FolderName", ""), h.get("CharacterSpineType"))
            if key in seen:
                continue
            seen.add(key)
            folder = c.get("folderNameOverride") or h.get("FolderName", "")
            name = c["name"] if c.get("isNameFullAnimationName") else f"CA/{folder}/{c['name']}"
            stats["configs"] += 1
            if sk is None:
                stats["unknown_spine_type"] += 1
                continue
            pool = anims[sk]
            bare = name[3:] if name.startswith("CA/") else name
            if name in pool or name + "__Sitting" in pool:
                stats["found"] += 1
                stats["found_with_CA_prefix"] += 1
                form[(h.get("CharacterSpineType"), "CA/")] += 1
            elif bare in pool:
                stats["found"] += 1
                stats["found_without_CA_prefix"] += 1
                form[(h.get("CharacterSpineType"), "bare")] += 1
            else:
                stats["missing"] += 1
                if len(misses) < 25:
                    misses.append({"handler": h["m_Name"], "spine": sk, "tried": name})
            for extra in ("alternateIdleAnimation", "preAnimation"):
                v = c.get(extra)
                if v:
                    stats["extra_" + extra] += 1
                    cand = [v, f"CA/{folder}/{v}"]
                    stats["extra_found"] += any(x in pool for x in cand)
    out = {"prefix_form_by_spine_type": {f"{k[0]}:{k[1]}": v for k, v in sorted(form.items(), key=str)}, "stats": dict(stats), "by_spine_type": dict(by_type), "sample_misses": misses}
    a.output.write_text(json.dumps(out, indent=1) + "\n")
    print(dict(stats), "| spine types:", dict(by_type))
    print("form by spine type:", {f"{k[0]}:{k[1]}": v for k, v in sorted(form.items(), key=str)})
    for m in misses[:8]:
        print("  miss", m)


if __name__ == "__main__":
    main()
