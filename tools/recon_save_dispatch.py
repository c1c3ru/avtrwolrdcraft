"""Verify focused indirect-dispatch contracts in the T030 AArch64 windows.

This does not recover runtime addresses for virtual/interface targets. It proves
the call-site shapes and records the semantic target justified by the managed
declarations and surrounding data flow.
"""
from __future__ import annotations

import argparse
import hashlib
import json
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
ASM = ROOT / "out/recon/tasks/T030/persistence-asm"
MANAGER = ROOT / "out/cpp2il/DiffableCs/Assembly-CSharp/PWC/PersistentData/PersistentDataManager.cs"
INTERFACE = ROOT / "out/cpp2il/DiffableCs/Assembly-CSharp/PWC/PersistentData/IHasPersistentData.cs"
PDPREFAB = ROOT / "out/cpp2il/DiffableCs/Assembly-CSharp/PWC/PersistentData/PDPrefab.cs"
PDSCENE = ROOT / "out/cpp2il/DiffableCs/Assembly-CSharp/PWC/PersistentData/PDScene.cs"

CONTRACTS = [
    {
        "method": "PersistentDataManager.GetFilePath",
        "assembly": "GetFilePath_00000000021e24b4.asm.txt",
        "site": "21e2520",
        "target": "PersistentDataManager.TryOverrideFileNameAction.Invoke(Scene, out string)",
        "kind": "delegate",
        "confidence": "high",
        "anchors": ["ldr x9, [x8, #0x18]", "ldr x0, [x8, #0x40]", "add x2, sp, #0x8", "blr x9", "tbz w0"],
        "reason": "SceneDataDelegate returns bool and writes an out string; a false result enters the normal path builder.",
    },
    {
        "method": "PersistentDataManager.GetDataFromRootGameObjects",
        "assembly": "GetDataFromRootGameObjects_00000000021e0f18.asm.txt",
        "site": "21e1654",
        "target": "IHasPersistentData.GetPersistentData()",
        "kind": "interface_dispatch",
        "confidence": "high",
        "anchors": ["add x0, x8, #0x138", "ldp x8, x1, [x0]", "mov x0, x28", "blr x8", "cbz x0"],
        "reason": "The loop dispatches on the persistent component and immediately tests the returned data object before dictionary insertion.",
    },
    {
        "method": "PersistentDataManager.SetPersistentData",
        "assembly": "SetPersistentData_00000000021e52d0.asm.txt",
        "site": "21e54f8",
        "target": "IHasPersistentData.SetPersistentData(allData, sceneObjects)",
        "kind": "interface_dispatch",
        "confidence": "high",
        "anchors": ["add x0, x8, #0x138", "ldp x8, x3, [x0]", "mov x0, x25", "mov x1, x23", "mov x2, x19", "blr x8"],
        "reason": "The three managed arguments match the interface setter and the call occurs inside the persistent-component loop.",
    },
    {
        "method": "PersistentDataManager.LoadDataInternal",
        "assembly": "LoadDataInternal_00000000021e2a50.asm.txt",
        "site": "21e2eac",
        "target": "PersistentDataManager.OnDataLoadedAction.Invoke(Scene)",
        "kind": "delegate",
        "confidence": "medium",
        "anchors": ["ldr x9, [x8, #0x18]", "ldr x0, [x8, #0x40]", "ldr w1, [sp, #0x28]", "blr x9"],
        "reason": "The only matching static Action<Scene> notification in the managed declaration is OnDataLoadedAction; no concrete delegate target is recoverable statically.",
    },
    # --- Entries below extend the original four with the remaining indirect-call
    # sites found once recon_save_cfg.py parsed every branch kind (not only bl/b)
    # across the T030 windows. Each PersistentDataManager static delegate field is
    # loaded through `ldr x8, [x8, #0xb8]` (per-type static-fields block) followed
    # by `ldr x8, [x8, #<field offset>]`; the field offset is the exact offset
    # PersistentDataManager.cs records for that field, which is why it identifies
    # the delegate. The delegate object's own fields (invoke pointer, target,
    # extra data) are always at +0x18/+0x40/+0x28 regardless of which field holds
    # the instance -- that part of the shape was already established by the four
    # entries above and is reused here, not re-derived.
    {
        "method": "PersistentDataManager.SaveProgress",
        "assembly": "SaveProgress_00000000021e0a48.asm.txt",
        "site": "21e0ab8",
        "target": "PersistentDataManager.OnPreSaveProgressAction.Invoke(Scene)",
        "kind": "delegate",
        "confidence": "high",
        "anchors": ["ldr x8, [x8, #0xb8]", "ldr x8, [x8, #0x28]", "ldr x9, [x8, #0x18]", "ldr x0, [x8, #0x40]", "blr x9"],
        "reason": "Static-fields offset 0x28 matches PersistentDataManager.cs's OnPreSaveProgressAction (Action<Scene>, field offset 0x28); the one explicit argument is the masked scene handle already live in this method.",
    },
    {
        "method": "PersistentDataManager.SaveProgress",
        "assembly": "SaveProgress_00000000021e0a48.asm.txt",
        "site": "21e0b10",
        "target": "PersistentDataManager.OnPostSaveProgressAction.Invoke(Scene)",
        "kind": "delegate_tail_call",
        "confidence": "high",
        "anchors": ["ldr x8, [x8, #0xb8]", "ldr x8, [x8, #0x30]", "ldr x3, [x8, #0x18]", "ldr x0, [x8, #0x40]", "br x3"],
        "reason": "Static-fields offset 0x30 matches OnPostSaveProgressAction (Action<Scene>, field offset 0x30). The callee-saved registers are restored and the delegate's invoke pointer is reached via `br x3`, not `blr`: a genuine tail call recon_save_static.py's blr-only scan did not record as an indirect site at all.",
    },
    {
        "method": "PersistentDataManager.SaveDataInternal",
        "assembly": "SaveDataInternal_00000000021e2578.asm.txt",
        "site": "21e2644",
        "target": "PersistentDataManager.TryOverrideFileNameAction.Invoke(Scene, out string)",
        "kind": "delegate",
        "confidence": "high",
        "anchors": ["ldr x8, [x8, #0xb8]", "ldr x8, [x8, #0x20]", "ldr x9, [x8, #0x18]", "ldr x0, [x8, #0x40]", "add x2, sp, #0x8", "blr x9"],
        "reason": "Same static-fields offset 0x20 and (Scene, out string) argument shape already confirmed for GetFilePath's TryOverrideFileNameAction call; SaveDataInternal resolves the same override before writing.",
    },
    {
        "method": "PersistentDataManager.GetFolder",
        "assembly": "GetFolder_00000000021e279c.asm.txt",
        "site": "21e2814",
        "target": "PersistentDataManager.OverrideGetFolderNameAction.Invoke()",
        "kind": "delegate",
        "confidence": "high",
        "anchors": ["ldr x8, [x8, #0xb8]", "ldr x8, [x8, #0x10]", "ldr x9, [x8, #0x18]", "ldr x0, [x8, #0x40]", "blr x9"],
        "reason": "Static-fields offset 0x10 matches OverrideGetFolderNameAction (Func<String>, field offset 0x10); no explicit argument register is set beyond the delegate's own target, matching a zero-argument Func.",
    },
    {
        "method": "PersistentDataManager.GetLevelDefaultDataFileName",
        "assembly": "GetLevelDefaultDataFileName_00000000021e288c.asm.txt",
        "site": "21e28f8",
        "target": "PersistentDataManager.TryOverrideSceneDefaultDataFileNameAction.Invoke(Scene, out string)",
        "kind": "delegate",
        "confidence": "high",
        "anchors": ["ldr x8, [x8, #0xb8]", "ldr x8, [x8, #0x18]", "ldr x9, [x8, #0x18]", "ldr x0, [x8, #0x40]", "add x2, sp, #0x8", "blr x9"],
        "reason": "Static-fields offset 0x18 matches TryOverrideSceneDefaultDataFileNameAction (SceneDataDelegate, field offset 0x18); the (Scene, out string) argument shape matches that delegate type.",
    },
    {
        "method": "PersistentDataManager.DestroySceneObjectsThatAreNotInTheSavedData",
        "assembly": "DestroySceneObjectsThatAreNotInTheSavedData_00000000021e3828.asm.txt",
        "site": "21e3eec",
        "target": "PDPrefab.OnBeforeDestroyOnSceneLoadAction.Invoke()",
        "kind": "delegate",
        "confidence": "medium",
        "anchors": ["ldr x8, [x0, #0x40]", "ldr x0, [x8, #0x40]", "ldr x1, [x8, #0x28]", "ldr x9, [x8, #0x18]", "blr x9"],
        "reason": "Unlike the other delegate sites this one is not read through PersistentDataManager's static-fields block: x8 comes from offset 0x40 of an instance (x0), which matches PDPrefab.cs's own OnBeforeDestroyOnSceneLoadAction field (instance field offset 0x40, Action). No explicit argument register is set, matching a zero-argument Action.",
    },
    {
        "method": "PersistentDataManager.SetDefaltLevelDataForSceneObjects",
        "assembly": "SetDefaltLevelDataForSceneObjects_00000000021e56c8.asm.txt",
        "site": "21e58a4",
        "target": "IHasPersistentData.SetPersistentData(allData, sceneObjects)",
        "kind": "interface_dispatch",
        "confidence": "high",
        "anchors": ["add x0, x8, #0x138", "ldp x8, x3, [x0]", "mov x0, x20", "mov x1, x25", "blr x8"],
        "reason": "Same +0x138 interface-slot shape and two explicit managed arguments already confirmed for the loop's own SetPersistentData call; this is the matching call inside the default-data application path.",
    },
    {
        "method": "PersistentDataManager.SetDefaltLevelDataForSceneObjects",
        "assembly": "SetDefaltLevelDataForSceneObjects_00000000021e56c8.asm.txt",
        "site": "21e59a4",
        "target": "IHasPersistentData.SetPersistentData(allData, sceneObjects)",
        "kind": "interface_dispatch",
        "confidence": "high",
        "anchors": ["add x0, x8, #0x138", "ldp x8, x3, [x0]", "mov x0, x26", "mov x1, x24", "mov x2, x19", "blr x8"],
        "reason": "Second call in the same method, same +0x138 interface slot and two-argument shape, for the method's other default-data source (new vs. existing preset).",
    },
    {
        "method": "PDScene.AddSceneObject",
        "assembly": "AddSceneObject_00000000021dcf10.asm.txt",
        "site": "21dd220",
        "target": "UNRESOLVED: likely Exception.ToString() inside a catch-block logging shim",
        "kind": "virtual_dispatch",
        "confidence": "low",
        "anchors": ["ldr x8, [x29]", "ldp x9, x1, [x8, #0x168]", "mov x0, x29", "blr x9"],
        "reason": "Reached only after `bl __cxa_end_catch` and a null check on x29 (the caught exception), inside a block that builds a two-argument log string beforehand. The +0x168 slot off the exception's own klass is consistent with an inherited System.Object.ToString() virtual slot, but no cross-reference proves the concrete slot index; this is the generic IL2CPP try/catch logging pattern, not evidence about AddSceneObject's own persistence logic.",
    },
    {
        "method": "PDScene.TryAddPrefabData",
        "assembly": "TryAddPrefabData_00000000021dd448.asm.txt",
        "site": "21dd688",
        "target": "UNRESOLVED: interface dispatch via a runtime interface-method cache probe",
        "kind": "interface_dispatch",
        "confidence": "low",
        "anchors": ["add w9, w9, #0x1", "sxtw #4", "add x0, x8, #0x138", "ldp x8, x1, [x0]", "blr x8"],
        "reason": "This call goes through the full IL2CPP interface-call cache lookup (linked cache-slot probe before the slot add), unlike the simpler direct-vtable shape used by the already-confirmed IHasPersistentData calls elsewhere. TryAddPrefabData's own signature (string, SceneData) gives no managed reason to expect an IHasPersistentData receiver here, so that hypothesis is explicitly not claimed; the receiver's real type is unresolved.",
    },
    {
        "method": "PDScene.TryAddPrefabData",
        "assembly": "TryAddPrefabData_00000000021dd448.asm.txt",
        "site": "21dd720",
        "target": "UNRESOLVED: interface dispatch via a runtime interface-method cache probe",
        "kind": "interface_dispatch",
        "confidence": "low",
        "anchors": ["add w9, w9, #0x2", "sxtw #4", "add x0, x8, #0x138", "ldp x8, x2, [x0]", "blr x8"],
        "reason": "Second cache-probed interface call in the same method, one explicit argument (x1); the argument count matches neither IHasPersistentData.GetPersistentData() (0 args) nor SetPersistentData (2 args), so no specific interface member is claimed.",
    },
    {
        "method": "LevelItem.GetPersistentData",
        "assembly": "GetPersistentData_00000000022f123c.asm.txt",
        "site": "22f12e0",
        "target": "UNRESOLVED: instance delegate field at LevelItem+0x318",
        "kind": "delegate",
        "confidence": "low",
        "anchors": ["ldr x8, [x19, #0x318]", "ldr x9, [x8, #0x18]", "ldr x0, [x8, #0x40]", "mov x1, x19", "blr x9"],
        "reason": "Same delegate-object shape (+0x18/+0x40/+0x28) as the PersistentDataManager sites, but the holder field is at offset 0x318 of the LevelItem instance itself, not of PersistentDataManager's static-fields block; LevelItem.cs's full field layout was not reconciled against this offset, so no specific field name is claimed.",
    },
    {
        "method": "LevelItem.SetPersistentData",
        "assembly": "SetPersistentData_00000000022f151c.asm.txt",
        "site": "22f17c0",
        "target": "UNRESOLVED: virtual call through LevelItem's own vtable",
        "kind": "virtual_dispatch",
        "confidence": "low",
        "anchors": ["ldr x9, [x19]", "ldr x8, [x9, #0x6c8]", "ldr x1, [x9, #0x6d0]", "blr x8"],
        "reason": "x9 is LevelItem's own klass pointer (loaded from the object header, not an interface-offset table), and 0x6c8/0x6d0 sit far into the vtable, consistent with one of the many virtual hooks this class overrides. No vtable layout recovery was done to name the slot.",
    },
    {
        "method": "LevelItem.SetPersistentData",
        "assembly": "SetPersistentData_00000000022f151c.asm.txt",
        "site": "22f1888",
        "target": "UNRESOLVED: virtual call through LevelItem's own vtable",
        "kind": "virtual_dispatch",
        "confidence": "low",
        "anchors": ["ldr x9, [x19]", "ldr x8, [x9, #0x6b8]", "ldr x3, [x9, #0x6c0]", "blr x8"],
        "reason": "Second virtual call in the same method at an adjacent vtable slot (0x6b8/0x6c0, 0x10 below the first); same unresolved-slot caveat applies.",
    },
]


def sha256(path: Path) -> str:
    return hashlib.sha256(path.read_bytes()).hexdigest()


def verify_contract(contract: dict) -> dict:
    path = ASM / contract["assembly"]
    lines = path.read_text(encoding="utf-8").splitlines()
    site_index = next((index for index, line in enumerate(lines) if line.lstrip().startswith(contract["site"] + ":")), None)
    if site_index is None:
        raise ValueError(f"call site {contract['site']} missing in {path}")
    window = "\n".join(" ".join(line.split()) for line in lines[max(0, site_index - 14):site_index + 5])
    missing = [anchor for anchor in contract["anchors"] if " ".join(anchor.split()) not in window]
    if missing:
        raise ValueError(f"anchors missing at {contract['site']}: {missing}")
    return {
        key: value for key, value in contract.items() if key != "anchors"
    } | {
        "site": "0x" + contract["site"],
        "assembly": str(path.relative_to(ROOT)),
        "assembly_sha256": sha256(path),
        "verified_anchors": contract["anchors"],
        "status": "verified_call_shape",
    }


def build_report() -> dict:
    return {
        "description": "focused indirect-call shapes for T030; semantic targets combine AArch64 data flow with managed declarations",
        "managed_sources": {
            str(MANAGER.relative_to(ROOT)): sha256(MANAGER),
            str(INTERFACE.relative_to(ROOT)): sha256(INTERFACE),
            str(PDPREFAB.relative_to(ROOT)): sha256(PDPREFAB),
            str(PDSCENE.relative_to(ROOT)): sha256(PDSCENE),
        },
        "contracts": [verify_contract(contract) for contract in CONTRACTS],
        "limits": [
            "Interface dispatch resolves a slot shape, not every concrete runtime implementation.",
            "Delegate invocation identifies the delegate field signature, not subscribed runtime methods.",
            "Exception edges and callees outside the bounded assembly windows remain unresolved.",
            "Entries whose target starts with 'UNRESOLVED' have a verified call-site shape but no claimed concrete target; status=verified_call_shape there certifies the shape only, not the target.",
            "virtual_dispatch entries read a slot from the receiver's own klass vtable rather than from an interface-offset table or a delegate field; no vtable layout recovery was performed to name those slots.",
        ],
    }


def main() -> None:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--output", type=Path, default=ROOT / "out/recon/tasks/T030/save-dispatch-contract.json")
    args = parser.parse_args()
    report = build_report()
    args.output.parent.mkdir(parents=True, exist_ok=True)
    args.output.write_text(json.dumps(report, ensure_ascii=False, indent=2) + "\n", encoding="utf-8")
    print(json.dumps({"contracts": len(report["contracts"]), "output": str(args.output)}, indent=2))


if __name__ == "__main__":
    main()
