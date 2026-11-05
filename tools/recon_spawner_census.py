"""Cross LevelAvatarOneTimeSpawner (out/mb) with the preset catalog: avatarId -> family, per scene. Static, read-only.
Data lives in the main checkout's out/ (not versioned); override with --root."""
from __future__ import annotations
import argparse, collections, gzip, json
from pathlib import Path

DEFAULT_ROOT = Path("/home/deppi/avatarworld-re")


def main():
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument("--root", type=Path, default=DEFAULT_ROOT)
    ap.add_argument("--output", type=Path, required=True)
    a = ap.parse_args()
    # Catalogo = PremadeCharactersJson + todo TextAsset com "AvatarSpineDatas" (avatares por nivel, mesmo esquema).
    NAMES = {1: "Character", 2: "Baby", 3: "Cat", 4: "Dog", 13: "Toddler", 14: "Horse"}  # por contagem e faixas de id (T032)
    family_key = "SpineType"
    family, source = {}, collections.Counter()
    for f in sorted((a.root / "out/assets/TextAsset").glob("*.txt")):
        if f.stat().st_size > 20_000_000 or "skel" in f.name or "atlas" in f.name:
            continue
        text = f.read_text(errors="ignore")
        if '"AvatarSpineDatas"' not in text:
            continue
        try:
            items = json.loads(text)["AvatarSpineDatas"]
        except Exception:
            continue
        for it in items:
            if "ID" in it and "SpineType" in it:
                if it["ID"] not in family:
                    source["premade" if f.name.startswith("PremadeCharacters") else "level-files"] += 1
                family.setdefault(it["ID"], NAMES.get(it["SpineType"], "type%s" % it["SpineType"]))
    rows = [json.loads(l) for l in gzip.open(a.root / "out/mb/PWC.Level.LevelAvatarOneTimeSpawner.jsonl.gz", "rt")]
    per_scene = collections.defaultdict(list)
    by_family = collections.Counter()
    unknown = []
    for r in rows:
        fam = family.get(r["_avatarId"])
        if fam is None:
            unknown.append(r["_avatarId"])
            fam = "UNKNOWN"
        by_family[fam] += 1
        per_scene[r["_file"]].append({
            "avatarId": r["_avatarId"], "family": fam, "playAnimation": bool(r["_playAnimation"]),
            "allowWhenAlreadyInGame": bool(r["_allowSpawnWhenAlreadyInGame"]),
            "prefabOverride": r["_prefabOverride"].get("prefabGuid", ""), "flipped": bool(r["_isFlipped"]),
            "hasSpawnPoint": bool(r["_spawnPoint"]["m_PathID"])})
    out = {"catalog_sources": dict(source), "catalog_total": len(family), "preset_family_key": family_key, "spawners": len(rows), "by_family": dict(by_family),
           "unknown_avatar_ids": sorted(set(unknown)),
           "scenes": {k: v for k, v in sorted(per_scene.items())},
           "flag_counts": {"playAnimation": sum(1 for r in rows if r["_playAnimation"]),
                           "allowWhenAlreadyInGame": sum(1 for r in rows if r["_allowSpawnWhenAlreadyInGame"]),
                           "prefabOverride": sum(1 for r in rows if r["_prefabOverride"].get("prefabGuid")),
                           "flipped": sum(1 for r in rows if r["_isFlipped"]),
                           "noSpawnPoint": sum(1 for r in rows if not r["_spawnPoint"]["m_PathID"])}}
    a.output.write_text(json.dumps(out, indent=1) + "\n")
    print("family key:", family_key, "| spawners:", len(rows), "| scenes:", len(per_scene))
    print("by family:", dict(by_family))
    print("flags:", out["flag_counts"], "| unknown ids:", len(set(unknown)))


if __name__ == "__main__":
    main()
