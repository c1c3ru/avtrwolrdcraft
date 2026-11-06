"""Extract bounded AArch64 method windows for focused reverse-engineering scopes.

This is a metadata-addressed disassembly aid. The next metadata method start is
only a conservative window boundary; it is not proof of a complete function.
"""
from __future__ import annotations

import argparse
import hashlib
import json
from pathlib import Path
import re
import subprocess

ROOT = Path(__file__).resolve().parents[1]
TARGET_GROUPS = {
  "save": {
    "PWC.PersistentData.PersistentDataManager": {
        "SaveProgress", "SaveProgressInAllScenes", "SaveDataForScene", "SaveDataInternal",
        "LoadProgress", "LoadData", "LoadDataInternal", "SetPersistentData",
        "SpawnRuntimePrefabs", "DestroySceneObjectsThatAreNotInTheSavedData",
        "GetSceneData", "GetSceneDataDict", "GetDataFromRootGameObjects",
        "GetSceneObjects", "GetPrefabRuntimeSpawns", "GetNewAndSyncedSceneGuids",
        "GetSceneObjectsToKeepOnLoad", "SetDefaltLevelDataForSceneObjects",
        "SpawnPrefabsFromDefaultData", "DeleteDataForActiveScene", "CanSaveScene",
        "GetFilePath", "GetActiveSceneFilePath", "GetLevelDefaultDataFileName",
        "GetLevelDefaultDataString", "EnsureFolder", "GetFolder", "GetFolderWithoutOverrides",
        "SaveSceneObjectsToKeepOnLoad",
    },
    "PWC.Level.LevelUserData": {"SetLevelData", "DeleteSceneData"},
    "PWC.PersistentData.PDScene": {".ctor", "AddSceneObject", "TryAddPrefabData", "TryRemoveSceneGuid",
                                   "TryGetPrefabDataForSceneGuid", "get_SceneObjects", "get_Prefabs"},
    "PWC.PersistentData.PDPrefab": {"EnsureSceneObjectGuids", "GetSceneObjectsData", "SetSceneObjectsData"},
    "PWC.GameSoundPlayer": {"GetPersistentData", "SetPersistentData"},
    "PWC.UGC.UGCNewPresetGridFloorHandler": {"GetPersistentData", "SetPersistentData"},
    "PWC.UGC.UGCStorePackGridFloorHandler": {"GetPersistentData", "SetPersistentData"},
    "PWC.Level.LevelItem": {"GetPersistentData", "SetPersistentData"},
    "PWC.Level.LevelItemOrientationHandler": {"GetPersistentData", "SetPersistentData"},
    "PWC.Level.LevelBag": {"GetPersistentData", "SetPersistentData"},
    "PWC.Level.LevelFillableItemHandler": {"GetPersistentData", "SetPersistentData"},
    "Game.Level.LevelBasketballScoreBoard": {"GetPersistentData", "SetPersistentData"},
  },
  "input": {
    "PWC.Multiplayer.MPPointerInputModule": {
        "CallBeginDrag", "GetMousePointerEventData", "GetPointerData", "GetTouchPointerEventData",
        "IsPointerOverGameObject", "ProcessDrag", "ProcessMove", "ShouldStartDrag", "StateForMouseButton",
    },
    "PWC.Multiplayer.MPStandaloneInputModule": {
        "CallEndDrag", "Process", "ProcessMouseEvent", "ProcessMousePress", "ProcessTouchEvents",
        "ProcessTouchPress", "ReleaseMouse", "TryClick",
    },
    "PWC.DragDropItemBase": {
        "GetDragPositionForThisFramePostModifications", "GetDragPositionForThisFramePreModifications",
        "GetPointerPosition", "GetPointerPositionForDrag", "GetPointerScreenPosition", "OnBeginDrag",
        "OnBeginDragInternal", "OnDrag", "OnEndDrag", "OnEndDragInternal", "OnPointerClick",
        "OnPointerClickInternal", "OnPointerDown", "OnPointerUp", "OnSyncPosition", "StartSyncPosition",
        "StopSyncPosition",
    },
    "PWC.InteractableItem": {
        "LockEventSystemToCurrentCShape", "OnCShapeSynced", "OnPointerDown", "OnPointerUp",
        "SyncCurrentCShape", "UnlockEventSystemFromCurrentCShape",
    },
    "PWC.Level.LevelItem": {
        "AssignCurrentDropAreaifExists", "CanBeDroppedOn", "DropOnDropArea", "FallOnDropArea",
        "GetMostRelevantDropAreaToFallOn", "GetMostRelevantDropAreaUnderPosition", "LandNow",
        "OnBeginDragInternal", "OnEndDragInternal", "OnPointerClickInternal", "OnPointerDown",
        "SetItemOrientationForDropAreaIfPossible", "SnapToDropArea", "TweenToProperPositionOnDropArea",
    },
    "PWC.Level.LevelDropArea": {
        "CanConsumeItem", "GetBottomPositionOnDropAreaAtX", "GetBottomProperPoisitoinOnDropAreaFromPosition",
        "GetXPositionOnDropArea", "OnAllHierarchyChildrenDropAreaItemBeginDrop",
        "OnAllHierarchyChildrenDropAreaItemEndDrop", "OnAllHierarchyChildrenDropAreaItemInterruptDrop",
        "OnAllHierarchyChildrenDropAreaItemPickUp", "SortDropAreas", "TryGetBottomPositionOnDropAreaAtX",
    },
    "PWC.Level.LevelConsumerAreaBase": {"CanConsumeItem", "ReleaseItems", "TryLevelItemDropInteraction"},
    "PWC.Level.LevelScrollCameraOnDrag": {"OnBeginDrag", "OnDrag", "OnEndDrag"},
  },
  "characters": {
    "PWC.Level.LevelCharacter": {"Init", "DestroyAvatar", "OnBeginDragInternal", "OnEndDragInternal", "OnSyncPosition", "OnItemPutInBone", "PlayProperIdleAnimation", "GetPersistentData", "SetPersistentData"},
    "PWC.Level.LevelToddler": {"Init", "DestroyAvatar", "OnBeginDragInternal", "OnEndDragInternal", "OnSyncPosition", "OnMovement", "OnBeginMovement", "OnEndMovement", "OnSpawnDuringGameplay", "GetMovementType", "PlayProperIdleAnimation", "GetPersistentData", "SetPersistentData"},
    "PWC.Level.LevelBaby": {"Init", "DestroyAvatar", "OnBeginDragInternal", "OnEndDragInternal", "OnSyncPosition", "GetPersistentData", "SetPersistentData"},
    "PWC.Level.LevelCharacterAnimator": {"GetMovementType", "OnBeginMovement", "OnEndMovement", "OnMovement", "PlayProperIdleAnimation", "PlayStandIdleAnimation", "PlayIdleAnimationOnCharacterInit", "SetAnimation", "SetAddAnimationInternal", "ShouldPlayFallHighAnimation", "UpdateMovementOverrideHandler"},
    "PWC.Level.LevelAnimal": {"Init", "DestroyAvatar", "OnBeginDragInternal", "OnEndDragInternal", "OnSyncPosition", "OnMovement", "OnBeginMovement", "OnEndMovement", "ForceNormalDragging", "ForceSyncPosition", "GetWalkingAnimationName", "GetRunningAnimationName", "GetStandingIdleAnimationName", "GetPersistentData", "SetPersistentData"},
    "Game.Level.LevelCat": {"Init", "DestroyAvatar", "OnEndDragInternal", "OnEndLand", "PlayProperIdleAnimation", "GetPersistentData", "SetPersistentData"},
    "Game.Level.LevelDog": {"Init", "DestroyAvatar", "OnEndDragInternal", "OnEndLand", "PlayProperIdleAnimation", "PutInMouth", "GetPersistentData", "SetPersistentData"},
    "Game.Level.LevelHorse": {"Init", "DestroyAvatar", "OnEndDragInternal", "OnEndLand", "OnSpawnDuringGameplay", "UpdateRider", "UpdateRiderOffsetPoisition", "SetAnimationToRider", "AddAnimationToRider", "GetPersistentData", "SetPersistentData"},
    "PWC.Level.LevelAvatarOneTimeSpawner": {"OnLevelPrePostInit", "PlaceAvatarInScene", "SpawnAvatar", "HandleCAHandlers", "GetPersistentData", "SetPersistentData"},
    "PWC.Level.LevelAvatarData": {"ApplyDataIfExists", "ApplyDataInternal", "SaveData", "SaveDataInternal"},
  },
  "clothing": {
    "PWC.AvatarMaker.AvatarMakerThumbsManager": {
        "AddExpansionPackThumbs", "AddItemSpritesOutsideAnyPack", "AddItemSpritesWithNoThumb",
        "AddOwnedExpansionPacksThumbs", "FilterByClaimedInventoryFlags", "FillSections",
        "GetOwnedPackFlagsInTabOrder", "GetPremiumItemsNames", "GetRelevantInventorySkins",
        "Init", "OnExpansionPackChanged", "OnThumbClick", "TryFillColorSections",
    },
    "PWC.AvatarMaker.AvatarMakerExpansionPackManager": {
        "AddExpansionPackCategory", "GetAvailableExpansionPackCategories", "InitAvailableExpansionPacks",
        "PressOnCurrentExpanisonPack",
    },
    "PWC.AvatarMaker.AvatarMakerExpansionPackCategory": {
        "Init", "InitLocalizedTooltipText", "InitTooltipText", "OnPointerClick",
        "SetActiveAccordingToCurrentSpineType", "TryGetRelevantCategoryInCurrentExpansion",
    },
    "PWC.Inventory.InventorySkinsBuildData": {
        "ContainsItem", "EnsureInit", "GetPremiumSkinsInventoryFlags", "GetDictionaryForSpecificFlagType",
        "TryGetCategoriesFromFlag", "TryGetSkinsFromFlag", "TryGetSkinsFromFlagForSpine", "TryGetText",
    },
    "PWC.Inventory.InventorySkinsUtils": {
        "ForEachOwnedPremiumSkinFlag", "GetAllCategories", "IsFlagInteractionPerformed",
        "SetFlagInteractionPerformed", "SetNewFlagNotSeenYet",
    },
    "PWC.Inventory.InventoryManager": {"ContainsFlagType", "GetFlagCount"},
    "PWC.Inventory.InventoryFlagTypeExtensionMethods": {"GetStorePackName", ".cctor"},
  },
  "contextual": {
    "PWC.LevelContextualAnimation.LevelCAConfig": {"CreateAnimationName", "IsValid"},
    "ReactionAnimationData": {"GetResolvedReactionAnimationName"},
    "Game.Level.LevelReactionOfAvatarsOnCAAnimationHandler": {"FindReactionIfExist"},
    "<>c__DisplayClass32_0": {"<FindReactionIfExist>b__0"},
    "PWC.AvatarSpine.SpineTypeExtensionMethods": {"HasCAPrefixForCAAnimations"},
    "PWC.Level.ContextualAnimation.LevelCAHandlerBase": {"GetAnimationSuffix"},
    **{f"Game.Level.ContextualAnimation.{name}": {"GetAnimationSuffix"} for name in (
        "LevelCAToddlerBottleItemHandler", "LevelCAToyCarToddlerItemHandler",
        "LevelCAToddlerPlayablesItemHandler", "LevelCAToddlerHandler",
        "LevelCASmallPetOnToddlerHandler", "LevelCADogOnToddlerHandler",
        "LevelCAToddlerBlanketItemHandler", "LevelCAToddlerDancingClothingSpineSkinHandler",
        "LevelCAToddlerFavoritePlushieItemHandler", "LevelCACatOnToddlerHandler",
        "LevelCAToddlerDrinkablesItemHandler", "LevelCAToddlerEdiblesItemHandler",
        "LevelCAToddlerPacifierItemHandler",
    )},
    "PWC.PSDToLevel.LevelContextualAnimation.LevelCADropAreaHandlerWithData": {
        "GetAnimations", "GetData", "GetFolderName", "GetForcedToSitAnimation",
        "GetLockedAnimationName", "GetPriority", "GetSpineType", "IsForceToSitWhenPossible",
    },
    "PWC.PSDToLevel.LevelContextualAnimation.LevelCAItemHandlerWithData": {
        "GetAnimations", "GetData", "GetFolderName", "GetLockedAnimationName", "GetSpineType",
    },
  },
}


def sha256(path: Path) -> str:
    digest = hashlib.sha256()
    with path.open("rb") as source:
        for block in iter(lambda: source.read(1024 * 1024), b""):
            digest.update(block)
    return digest.hexdigest()


def main() -> None:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--index", type=Path, default=ROOT / "out/recon/il2cpp/metadata_methods.jsonl")
    parser.add_argument("--binary", type=Path, default=ROOT / "out/recon/il2cpp/libil2cpp.so")
    parser.add_argument("--objdump", type=Path, default=Path("/usr/lib/llvm-21/bin/llvm-objdump"))
    parser.add_argument("--scope", choices=sorted(TARGET_GROUPS), default="save")
    parser.add_argument("--output", type=Path)
    args = parser.parse_args()
    args.index = args.index.resolve()
    args.binary = args.binary.resolve()
    args.objdump = args.objdump.resolve()
    defaults = {"save": "T030/persistence-asm", "input": "T031/input-asm", "characters": "T032/character-asm",
                "clothing": "T033/gates-asm", "contextual": "T035/contextual-asm"}
    args.output = (args.output or ROOT / "out/recon/tasks" / defaults[args.scope]).resolve()
    selected = TARGET_GROUPS[args.scope]
    rows = [json.loads(line) for line in args.index.read_text(encoding="utf-8").splitlines()]
    valid = [row for row in rows if row.get("vaddr")]
    starts = sorted({int(row["vaddr"], 16) for row in valid})
    targets = [row for row in valid if row["name"] in selected.get(row["declaring_type"], set())]
    found = {(row["declaring_type"], row["name"]) for row in targets}
    if not targets:
        raise SystemExit("no mapped target methods found")
    if not args.objdump.is_file():
        raise SystemExit(f"AArch64 disassembler unavailable: {args.objdump}")
    args.output.mkdir(parents=True, exist_ok=True)
    methods_by_address: dict[int, list[dict]] = {}
    for item in valid:
        methods_by_address.setdefault(int(item["vaddr"], 16), []).append(item)
    report = {
        "scope": args.scope,
        "description": "bounded metadata-addressed AArch64 windows; not a semantic or complete-body claim",
        "inputs": {"index": str(args.index.relative_to(ROOT)), "index_sha256": sha256(args.index),
                   "binary": str(args.binary.relative_to(ROOT)), "binary_sha256": sha256(args.binary)},
        "tool": str(args.objdump), "target_types": sorted(selected),
        "requested_methods": {name: sorted(names) for name, names in selected.items()}, "mapped_methods": [],
        "missing_methods": {name: sorted(methods - {m for t, m in found if t == name})
                             for name, methods in selected.items()},
        "limits": ["Window ends at the next distinct metadata method start or 16384 bytes, whichever comes first.",
                   "The next start is not a proven function boundary; tail calls, shared bodies, generics, and indirect calls need separate analysis."],
    }
    for row in sorted(targets, key=lambda item: (int(item["vaddr"], 16), item["name"])):
        start = int(row["vaddr"], 16)
        end = min(next((address for address in starts if address > start), start + 16384), start + 16384)
        filename = row["name"].replace("/", "_") + "_" + start.to_bytes(8, "big").hex() + ".asm.txt"
        output = args.output / filename
        command = [str(args.objdump), "-d", f"--start-address={start:#x}", f"--stop-address={end:#x}", str(args.binary)]
        result = subprocess.run(command, check=False, capture_output=True, text=True, timeout=45)
        if result.returncode:
            raise SystemExit(f"objdump failed for {row['name']}: {result.stderr[:1000]}")
        output.write_text(result.stdout, encoding="utf-8")
        direct_calls = []
        indirect_calls = []
        for line in result.stdout.splitlines():
            match = re.match(r"\s*([0-9a-f]+):.*?\b(bl|b)\s+0x([0-9a-f]+)", line)
            if match:
                target = int(match.group(3), 16)
                direct_calls.append({"site": "0x" + match.group(1), "kind": match.group(2),
                                     "target": hex(target),
                                     "metadata_candidates": [{"type": callee["declaring_type"], "name": callee["name"],
                                                              "token": callee.get("token")} for callee in methods_by_address.get(target, [])]})
            elif re.search(r"\bblr\s+x\d+", line):
                indirect_calls.append({"site": "0x" + line.strip().split(":", 1)[0],
                                       "instruction": line.strip().split(":", 1)[1].strip(),
                                       "target": "UNKNOWN_indirect"})
        report["mapped_methods"].append({"declaring_type": row["declaring_type"], "name": row["name"], "token": row.get("token"),
                                          "vaddr": row["vaddr"], "file_offset": row.get("file_offset"),
                                          "window_stop_exclusive": hex(end), "window_bytes": end - start,
                                          "boundary": "next distinct metadata start, capped at 16384; not proven body extent",
                                          "assembly": str(output.relative_to(ROOT)), "command": command,
                                          "direct_branches": direct_calls, "indirect_calls": indirect_calls})
    report_path = args.output / "report.json"
    report_path.write_text(json.dumps(report, ensure_ascii=False, indent=2) + "\n", encoding="utf-8")
    print(json.dumps({"methods": len(targets), "missing": sum(map(len, report["missing_methods"].values())),
                      "report": str(report_path.relative_to(ROOT)),
                      "binary_sha256": report["inputs"]["binary_sha256"]}, ensure_ascii=False, indent=2))


if __name__ == "__main__":
    main()
