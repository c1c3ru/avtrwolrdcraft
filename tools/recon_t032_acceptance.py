"""Audit the bounded T032 evidence; never promote reconstruction or queue state.

Run the three local probes first, as documented in RECON_T032_PROGRESS.md.
This audit verifies identities, source hashes and evidence cardinalities. Static
recovery and runtime/implementation acceptance remain distinct.
"""
from __future__ import annotations

import argparse
import hashlib
import json
from pathlib import Path
import subprocess
import sys

ROOT = Path(__file__).resolve().parents[1]
NATIVE = "b63661fa60c23ebef1c2da4bb5288ad787eb3da36b22d4bdf285401f1643d728"
METADATA = "1ea14cf5829d5c31e5e967b1608b5701020ab0d24bd4ab69d9f1e2b243467bc6"


def digest(path):
    h = hashlib.sha256()
    with path.open("rb") as stream:
        for block in iter(lambda: stream.read(1024 * 1024), b""):
            h.update(block)
    return h.hexdigest()


PROBES = (
    "callbacks/probe.py", "families/check.py", "families/engine_calls.py",
    "families/delegates.py", "callbacks/review_families.py", "npc/validate.py",
    "families/review_npc.py",
)


def audit(root=ROOT):
    base = root / "out/recon/tasks/T032"
    checks = []
    # Re-read original bytes on every audit. Cached JSON cardinalities alone
    # must not be accepted as fresh native evidence.
    probe_runs = []
    for relative in PROBES:
        script = base / relative
        result = subprocess.run([sys.executable, str(script)], cwd=root,
                                capture_output=True, text=True, timeout=120)
        probe_runs.append({"script": str(script.relative_to(root)),
                           "sha256": digest(script), "exit_code": result.returncode})
        if result.returncode:
            raise RuntimeError(f"Probe failed: {relative}\n{result.stderr}\n{result.stdout}")

    def check(name, condition):
        checks.append({"check": name, "passed": bool(condition)})

    def load(path):
        return json.loads(path.read_text())

    def verify(path, expected):
        full = root / path
        check("sha256:" + path, full.is_file() and digest(full) == expected)

    verify("out/recon/il2cpp/libil2cpp.so", NATIVE)
    verify("out/recon/il2cpp/global-metadata.dat", METADATA)
    dispatch = load(base / "callbacks/dispatch.json")
    check("dispatch_pair", dispatch["native_sha256"] == NATIVE
          and dispatch["metadata_sha256"] == METADATA)
    for key, count in [("virtual_calls", 21), ("interface_calls", 9),
                       ("persistent_interface_calls", 2), ("step_callbacks", 3),
                       ("families", 6)]:
        check(key, len(dispatch[key]) == count)
    for path, sha in load(base / "npc/manifest.json")["sources"].items():
        verify(path, sha)
    for entry in load(base / "families/manifest.json"):
        path = entry.get("source") or str((base / "families" / entry["path"]).relative_to(root))
        verify(path, entry["sha256"])
    caps = load(base / "families/capabilities.json")
    check("seven_capabilities", len(caps) == 7)
    running = [r for r in caps if r["method"] == "HasRunningAnimations"]
    check("running_is_false", len(running) == 1 and running[0]["returns"] is False)
    techs = [r for r in caps if "LevelTech" in r["type"]]
    check("five_techs_no_walking", len(techs) == 5 and all(r["returns"] is False for r in techs))
    census = load(base / "npc/census.json")
    maps = census["PWC.Level.LevelSceneAvatarMap"]
    avatars = [a for row in maps["rows"] for a in row["avatars"]]
    check("229_maps_1170_phone_records", maps["count"] == 229 and len(avatars) == 1170
          and all(type(a["isOnPhone"]) in (bool, int) and a["isOnPhone"] == 1 for a in avatars))
    validation = load(base / "npc/validation.json")
    check("npc_checks", bool(validation["checks"]) and validation["passed"] is True
          and all(c["passed"] is True for c in validation["checks"]))
    device = load(root / "reports/recon/t032_device_version_check.json")
    check("runtime_not_misrepresented", device["matches_analyzed_version"] is False
          and device["game_launched"] is False and device["installed_binary_sha256_verified"] is False)
    queue = load(root / "reports/recon/tasks.json")
    task = next(t for t in queue["tasks"] if t["id"] == "T032")
    states = {t["id"]: t["state"] for t in queue["tasks"]}
    blockers = [{"id": dep, "state": states[dep]} for dep in task["dependencies"]
                if states[dep] != "done"]
    check("parent_not_falsely_done", task["state"] != "done")
    evidence = []
    for directory in ("callbacks", "families", "npc"):
        for path in sorted((base / directory).rglob("*")):
            if path.is_file() and "__pycache__" not in path.parts:
                evidence.append({"path": str(path.relative_to(root)), "sha256": digest(path)})
    return {
        "schema_version": 1, "task_id": "T032", "date": "2026-11-08",
        "scope": "bounded static callback dispatch, NPC position/autonomy and movement-family recovery",
        "evidence_integrity_passed": all(c["passed"] for c in checks),
        "checks": checks, "evidence": evidence, "probe_runs": probe_runs,
        "queue_snapshot": {"state": task["state"], "blockers": blockers},
        "runtime_acceptance": False, "implementation_acceptance": False,
        "parent_acceptance": False,
        "remaining": [
            "Dynamic listener cardinality/order, cancellation and behavior on a hash-matched 1.227 runtime.",
            "Noncanonical metadata usage for Baby static delegates; field/signature attribution is separate from type binding.",
            "Derived virtual receivers and scripts outside the examined NPC movement paths.",
            "Client reconciliation: animal Forced_To_Walk, track1 overlay with locked CA, false running capability, Baby/tech routing.",
            "Canonical T018, T025-T027 and T031 dependency acceptance.",
        ],
    }


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--output", type=Path, default=ROOT / "reports/recon/t032_acceptance.json")
    args = parser.parse_args()
    report = audit()
    args.output.parent.mkdir(parents=True, exist_ok=True)
    args.output.write_text(json.dumps(report, ensure_ascii=False, indent=2) + "\n")
    print(json.dumps({"evidence_integrity_passed": report["evidence_integrity_passed"],
                      "checks": len(report["checks"]), "parent_acceptance": False,
                      "output": str(args.output)}, indent=2))
    raise SystemExit(0 if report["evidence_integrity_passed"] else 1)


if __name__ == "__main__":
    main()
