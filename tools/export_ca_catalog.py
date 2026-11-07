"""Export the Contextual Animation item-handler catalog (LevelCAItemHandlerData in out/mb) to a compact JSON for the client.
Deduplicates identical handlers repeated across scenes. Output fields use the names of AvatarWorld.Core.Avatar.CAHandlerEntry /
CAConfigEntry so Unity's JsonUtility can read them. Static, read-only; data lives in the main checkout's out/."""
from __future__ import annotations
import argparse, gzip, json
from pathlib import Path

ROOT = Path("/home/deppi/avatarworld-re")
CLS = "PWC.PSDToLevel.LevelContextualAnimation.LevelCAItemHandlerData"


def main():
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument("--root", type=Path, default=ROOT)
    ap.add_argument("--output", type=Path, required=True)
    a = ap.parse_args()
    seen, handlers = set(), []
    total = 0
    for line in gzip.open(a.root / f"out/mb/{CLS}.jsonl.gz", "rt"):
        h = json.loads(line)
        total += 1
        configs = [{
            "name": c["name"],
            "folderNameOverride": c.get("folderNameOverride", ""),
            "isNameFullAnimationName": bool(c.get("isNameFullAnimationName")),
            "repetitions": c.get("repetitions", 1),
            "trackIndex": c.get("trackIndex", 0),
            "alternateIdleAnimation": c.get("alternateIdleAnimation", ""),
            "preAnimation": c.get("preAnimation", ""),
            "keepCurrentAnimation": bool(c.get("keepCurrentAnimation")),
            "isDisableOtherAnimations": bool(c.get("isDisableOtherAnimations")),
            "ensureRequiredTextures": bool(c.get("ensureRequiredTextures")),
        } for c in h.get("LevelCAConfigs", [])]
        entry = {
            "name": h.get("m_Name", ""),
            "spineType": h.get("CharacterSpineType", 0),
            "folderName": h.get("FolderName", ""),
            "boneName": h.get("BoneName", ""),
            "lockedAnimation": h.get("LockedAnimation", ""),
            "isSingleCA": bool(h.get("IsSingleCA")),
            "dontApplyForceToSit": bool(h.get("DontApplyForceToSit")),
            "configs": configs,
        }
        key = json.dumps(entry, sort_keys=True)
        if key in seen:
            continue
        seen.add(key)
        handlers.append(entry)
    handlers.sort(key=lambda e: (e["spineType"], e["name"]))
    a.output.parent.mkdir(parents=True, exist_ok=True)
    a.output.write_text(json.dumps({"handlers": handlers}, separators=(",", ":"), ensure_ascii=False) + "\n", encoding="utf-8")
    cfg = sum(len(e["configs"]) for e in handlers)
    print(f"rows {total} -> unique handlers {len(handlers)}, configs {cfg}, bytes {a.output.stat().st_size}")


if __name__ == "__main__":
    main()
