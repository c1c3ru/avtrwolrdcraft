"""Build a compact, hash-addressed inventory of avatar families and level classes."""
from __future__ import annotations

import argparse
import hashlib
import json
from pathlib import Path
import re

ROOT = Path(__file__).resolve().parents[1]
SPINE_TYPES = {0: "None", 1: "Character", 2: "Baby", 3: "Cat", 4: "Dog", 5: "Bird",
               6: "Other", 7: "Fish", 8: "Hamster", 9: "Lizard", 10: "Turtle",
               11: "Rabbit", 12: "Snake", 13: "Toddler", 14: "Horse", 15: "Cow",
               16: "Chicken", 17: "Car"}


def sha256(path: Path) -> str:
    h = hashlib.sha256()
    with path.open("rb") as stream:
        for block in iter(lambda: stream.read(1024 * 1024), b""):
            h.update(block)
    return h.hexdigest()


def main() -> None:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--presets", type=Path, default=ROOT / "out/assets/TextAsset/PremadeCharactersJson_109356.txt")
    parser.add_argument("--assembly", type=Path, default=ROOT / "out/cpp2il/DiffableCs/Assembly-CSharp")
    parser.add_argument("--output", type=Path, default=ROOT / "out/recon/tasks/T032/character-inventory.json")
    args = parser.parse_args()
    presets_path, assembly_root, output = args.presets.resolve(), args.assembly.resolve(), args.output.resolve()
    data = json.loads(presets_path.read_text(encoding="utf-8"))
    rows = data["AvatarSpineDatas"]
    counts: dict[str, int] = {}
    size_counts: dict[str, int] = {}
    ids: dict[str, list[int]] = {}
    for row in rows:
        type_name = SPINE_TYPES.get(row.get("SpineType"), f"Unknown({row.get('SpineType')})")
        counts[type_name] = counts.get(type_name, 0) + 1
        ids.setdefault(type_name, []).append(row["ID"])
        size_name = {0: "None", 1: "Big", 2: "Medium", 3: "Small"}.get(row.get("SizeType"), str(row.get("SizeType")))
        size_counts[size_name] = size_counts.get(size_name, 0) + 1
    classes = []
    pattern = re.compile(r"public\s+(?:(abstract|sealed)\s+)?class\s+(\w+)\s*:\s*([^\n{]+)")
    for path in sorted(assembly_root.rglob("*.cs")):
        source = path.read_text(encoding="utf-8", errors="replace")
        match = pattern.search(source)
        if not match:
            continue
        name, bases = match.group(2), match.group(3).strip()
        if name not in {"LevelCharacter", "LevelToddler", "LevelBaby", "LevelAnimal"} and "LevelAnimal" not in bases:
            continue
        namespace_match = re.search(r"namespace\s+([^;{]+)", source)
        classes.append({"name": name, "namespace": namespace_match.group(1).strip() if namespace_match else "<global>",
                        "abstract": match.group(1) == "abstract", "bases": bases,
                        "declares_ILevelAvatar": "ILevelAvatar" in bases,
                        "source": str(path.relative_to(ROOT)), "source_sha256": sha256(path)})
    result = {
        "inputs": {"presets": str(presets_path.relative_to(ROOT)), "presets_sha256": sha256(presets_path),
                   "assembly_stub_root": str(assembly_root.relative_to(ROOT))},
        "preset_count": len(rows), "preset_counts_by_spine_type": counts,
        "preset_ids_by_spine_type": {name: {"count": len(values), "min": min(values), "max": max(values)}
                                      for name, values in ids.items()},
        "preset_counts_by_size_type": size_counts,
        "level_character_classes": classes,
        "limits": ["Cpp2IL class stubs establish declarations and interfaces, not runtime behavior.",
                   "Premade preset counts do not measure scene NPC populations or unlocked catalog coverage."]
    }
    output.parent.mkdir(parents=True, exist_ok=True)
    output.write_text(json.dumps(result, ensure_ascii=False, indent=2) + "\n", encoding="utf-8")
    print(json.dumps({"presets": len(rows), "families": counts, "level_classes": len(classes),
                      "output": str(output.relative_to(ROOT)), "presets_sha256": result["inputs"]["presets_sha256"]},
                     ensure_ascii=False, indent=2))


if __name__ == "__main__":
    main()
