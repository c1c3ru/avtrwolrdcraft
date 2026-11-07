"""Compare one exported Unity scene's serialized persistent components to Cpp2IL fields."""
from __future__ import annotations

import argparse
import hashlib
import json
from pathlib import Path
import re
import struct
import sys

ROOT = Path(__file__).resolve().parents[1]
for package_path in (ROOT / "tools" / "venv" / "lib").glob("python*/site-packages"):
    sys.path.insert(0, str(package_path))
import UnityPy  # noqa: E402

TYPES = {
    "GameSoundPlayer", "UGCNewPresetGridFloorHandler", "UGCStorePackGridFloorHandler",
    "PDSceneObject", "PersistentDataManager", "LevelBasketballScoreBoard", "LevelItem",
    "LevelItemOrientationHandler", "LevelBag", "LevelFillableItemHandler", "LevelLight",
    "LightSource", "LevelRuntimeColoredSpriteHandler",
}
ENUM_SOURCES = {
    "StorePackType": ROOT / "out/cpp2il/DiffableCs/Assembly-CSharp/Store/StorePackType.cs",
    "InventoryFlagType": ROOT / "out/cpp2il/DiffableCs/Assembly-CSharp/PWC/Inventory/InventoryFlagType.cs",
}


def enum_name(source: Path, value: int) -> str | None:
    match = re.search(rf"^\s*([A-Za-z_]\w*)\s*=\s*{value}\s*,?\s*$", source.read_text(encoding="utf-8"), re.M)
    return match.group(1) if match else None


def sha256(path: Path) -> str:
    digest = hashlib.sha256()
    with path.open("rb") as source:
        for block in iter(lambda: source.read(1024 * 1024), b""):
            digest.update(block)
    return digest.hexdigest()


def string_at(data: bytes, offset: int) -> tuple[str, int]:
    length = struct.unpack_from("<I", data, offset)[0]
    end = offset + 4 + length
    if end > len(data):
        raise ValueError(f"serialized string length {length} exceeds MonoBehaviour payload")
    return data[offset + 4:end].decode("utf-8"), end


def main() -> None:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("scene", nargs="?", default="level4")
    parser.add_argument("--scene-dir", type=Path, default=ROOT / "out/scene-extract")
    parser.add_argument("--inspect", type=Path)
    parser.add_argument("--output", type=Path, default=ROOT / "out/recon/tasks/T030/scene-pilot.json")
    args = parser.parse_args()
    scene_path = (args.scene_dir / args.scene).resolve()
    inspect_path = (args.inspect or args.scene_dir / (args.scene + ".inspect.json")).resolve()
    args.output = args.output.resolve()
    if not scene_path.is_file() or not inspect_path.is_file():
        raise SystemExit("scene or existing inspector report missing")
    scene_report = json.loads(inspect_path.read_text(encoding="utf-8"))
    env = UnityPy.load(str(scene_path))
    mono = {obj.path_id: obj for obj in env.objects if obj.type.name == "MonoBehaviour"}
    persistent = []
    pd_objects = []
    for row in scene_report["behaviours"]:
        script = row["script"]
        if script["name"] not in TYPES:
            continue
        obj = mono.get(row["mono_behaviour_path_id"])
        if obj is None:
            raise SystemExit(f"scene report MonoBehaviour missing: {row['mono_behaviour_path_id']}")
        standard = obj.read(check_read=False)
        raw = obj.get_raw_data()
        item = {"game_object": row["game_object"], "game_object_path_id": row["game_object_path_id"],
                "mono_behaviour_path_id": row["mono_behaviour_path_id"], "type": script["name"],
                "serialized_bytes": len(raw)}
        tail = raw[32:]
        if script["name"] == "GameSoundPlayer":
            if len(tail) != 12:
                raise SystemExit(f"unexpected GameSoundPlayer payload size {len(tail)}")
            ignore_distance, ignore_pd = struct.unpack_from("<II", tail)
            distance = struct.unpack_from("<f", tail, 8)[0]
            item["serialized_fields"] = {"_ignoreDistance": bool(ignore_distance),
                                         "_ignorePD": bool(ignore_pd), "_distanceFactor": distance}
        elif script["name"] == "UGCNewPresetGridFloorHandler":
            guid, end = string_at(raw, 32)
            if end != len(raw):
                raise SystemExit("unexpected trailing UGCNewPresetGridFloorHandler payload")
            item["serialized_fields"] = {"_presetPDPrefabReference.prefabGuid": guid}
        elif script["name"] == "UGCStorePackGridFloorHandler":
            if len(tail) < 12:
                raise SystemExit("short UGCStorePackGridFloorHandler payload")
            pack, flag = struct.unpack_from("<ii", tail)
            guid, end = string_at(raw, 40)
            if end != len(raw):
                raise SystemExit("unexpected trailing UGCStorePackGridFloorHandler payload")
            item["serialized_fields"] = {"_storePackType": {"value": pack, "name": enum_name(ENUM_SOURCES["StorePackType"], pack)},
                                         "_inventoryFlagType": {"value": flag, "name": enum_name(ENUM_SOURCES["InventoryFlagType"], flag)},
                                         "_presetPDPrefabReference.prefabGuid": guid,
                                         "enum_sources": [str(ENUM_SOURCES["StorePackType"].relative_to(ROOT)),
                                                          str(ENUM_SOURCES["InventoryFlagType"].relative_to(ROOT))]}
        elif script["name"] == "PDSceneObject":
            guid, end = string_at(raw, 32)
            aligned_end = (end + 3) & ~3
            if aligned_end != len(raw) or any(raw[end:aligned_end]):
                raise SystemExit(f"PDSceneObject sceneGuid payload mismatch at path {obj.path_id}")
            pd_objects.append({"game_object": row["game_object"], "game_object_path_id": row["game_object_path_id"],
                               "mono_behaviour_path_id": row["mono_behaviour_path_id"],
                               "scene_guid": guid, "serialized_bytes": len(raw)})
            continue
        elif script["name"] == "PersistentDataManager":
            item["serialized_custom_payload_bytes"] = len(tail)
            item["interpretation"] = "scene contains the manager component; its runtime file path/state is not serialized here"
            persistent.append(item)
            continue
        elif script["name"] not in {"GameSoundPlayer", "UGCNewPresetGridFloorHandler", "UGCStorePackGridFloorHandler"}:
            item["serialized_script_payload_hex"] = tail.hex()
            item["interpretation"] = "raw Unity serialization retained; field-by-field decode requires its serialized type tree"
        persistent.append(item)
    result = {
        "scene": args.scene,
        "inputs": {"scene": str(scene_path.relative_to(ROOT)), "scene_sha256": sha256(scene_path),
                   "inspector_report": str(inspect_path.relative_to(ROOT)), "inspector_sha256": sha256(inspect_path)},
        "scene_counts": {"unity_objects": scene_report["object_count"],
                         "mono_behaviours": len(scene_report["behaviours"]),
                         "PersistentDataManager_components": sum(1 for b in scene_report["behaviours"] if b["script"]["name"] == "PersistentDataManager"),
                         "PDSceneObject_components": len(pd_objects),
                         "PDPrefab_components": sum(1 for b in scene_report["behaviours"] if b["script"]["name"] == "PDPrefab"),
                         "serialized_persistent_handlers": sum(1 for b in scene_report["behaviours"] if b["script"]["name"] in TYPES and b["script"]["name"] not in {"PDSceneObject", "PersistentDataManager"})},
        "persistent_components": persistent,
        "PDSceneObjects": pd_objects,
        "scene_guid_summary": {"unique_count": len({item["scene_guid"] for item in pd_objects}),
                               "uuid_shaped_count": sum(1 for item in pd_objects if len(item["scene_guid"]) == 36 and item["scene_guid"].count("-") == 4),
                               "name_shaped_count": sum(1 for item in pd_objects if not (len(item["scene_guid"]) == 36 and item["scene_guid"].count("-") == 4))},
        "interpretation_limits": ["Unity's MonoBehaviour base envelope is separated from script payload at byte offset 32 for this scene format.",
                                  "Decoded fields are matched to Cpp2IL field order/types; this does not reveal saved PlayerPrefs/files or runtime values.",
                                  "Scene GUID uniqueness is measured within this scene only; cross-scene collision behavior and GUID assignment are not proven by this sample."],
    }
    args.output.parent.mkdir(parents=True, exist_ok=True)
    args.output.write_text(json.dumps(result, ensure_ascii=False, indent=2) + "\n", encoding="utf-8")
    print(json.dumps({"scene": args.scene, "pd_scene_objects": len(pd_objects),
                      "persistent_components": len(persistent), "report": str(args.output.relative_to(ROOT)),
                      "scene_sha256": result["inputs"]["scene_sha256"]}, ensure_ascii=False, indent=2))


if __name__ == "__main__":
    main()
