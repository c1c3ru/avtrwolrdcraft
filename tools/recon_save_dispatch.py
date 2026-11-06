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
        },
        "contracts": [verify_contract(contract) for contract in CONTRACTS],
        "limits": [
            "Interface dispatch resolves a slot shape, not every concrete runtime implementation.",
            "Delegate invocation identifies the delegate field signature, not subscribed runtime methods.",
            "Exception edges and callees outside the bounded assembly windows remain unresolved.",
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
