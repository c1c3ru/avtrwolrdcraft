#!/usr/bin/env python3
"""Collect local reconstruction baseline; no install, launch, network or source edits.

Incremental hash reuse requires an unchanged stat fingerprint and a prior SHA256.
Use --verify to rehash and recount everything rather than trusting that shortcut.
"""
import argparse
from collections import Counter
from datetime import datetime, timezone
import gzip
import hashlib
import json
from pathlib import Path
import re
import shutil
import subprocess
import tempfile
import time
import xml.etree.ElementTree as ET
import zipfile

ROOT = Path(__file__).resolve().parents[1]
VERSION = 1


def atomic_json(path, value):
    path.parent.mkdir(parents=True, exist_ok=True)
    with tempfile.NamedTemporaryFile("w", dir=path.parent, prefix=path.name + ".", delete=False) as out:
        json.dump(value, out, ensure_ascii=False, indent=2)
        out.write("\n")
        temporary = Path(out.name)
    temporary.replace(path)


def fingerprint(path):
    s = path.stat()
    return {"size": s.st_size, "mtime_ns": s.st_mtime_ns, "ctime_ns": s.st_ctime_ns,
            "device": s.st_dev, "inode": s.st_ino}


def digest_stream(stream):
    h = hashlib.sha256()
    for chunk in iter(lambda: stream.read(1024 * 1024), b""):
        h.update(chunk)
    return h.hexdigest()


def run(command):
    started = time.monotonic()
    try:
        p = subprocess.run(command, capture_output=True, text=True, timeout=90)
        return {"command": command, "returncode": p.returncode,
                "duration_seconds": round(time.monotonic() - started, 3),
                "stdout": p.stdout, "stderr": p.stderr}
    except (OSError, subprocess.TimeoutExpired) as error:
        return {"command": command, "returncode": None, "error": str(error),
                "duration_seconds": round(time.monotonic() - started, 3)}


def sdk_tool(name):
    found = shutil.which(name)
    if found:
        return found
    versions = sorted((Path.home() / "Android/Sdk/build-tools").glob("*/" + name), reverse=True)
    return str(versions[0]) if versions else None


def collect(root=ROOT, output=None, verify=False):
    root = root.resolve()
    output = (output or root / "reports/recon").resolve()
    previous = {}
    with Path(__file__).open("rb") as stream:
        collector_sha256 = digest_stream(stream)
    prior_path = output / "baseline.json"
    if prior_path.exists():
        previous = json.loads(prior_path.read_text())
    prior_inputs = previous.get("inputs", {}) if previous.get("collector_version") == VERSION else {}
    inputs, hash_counts = {}, Counter()

    def relative(path):
        return str(path.relative_to(root))

    def identify(path):
        key, before = relative(path), fingerprint(path)
        prior = prior_inputs.get(key, {})
        if not verify and prior.get("fingerprint") == before and prior.get("sha256"):
            digest = prior["sha256"]
            mode = "cached_stat_fingerprint"
        else:
            with path.open("rb") as stream:
                digest = digest_stream(stream)
            mode = "streamed_sha256"
        if before != fingerprint(path):
            raise ValueError(f"input changed while hashing: {key}")
        record = {"sha256": digest, "bytes": before["size"], "fingerprint": before,
                  "hash_mode": mode}
        inputs[key] = record
        hash_counts[mode] += 1
        return record

    commands = {name: run(["git", "-C", str(root), *args]) for name, args in {
        "head": ["rev-parse", "HEAD"], "status": ["status", "--porcelain=v1"],
        "branch": ["branch", "--show-current"]}.items()}
    aapt2, apksigner = sdk_tool("aapt2"), sdk_tool("apksigner")
    tools = {"aapt2": aapt2, "apksigner": apksigner}
    tool_identities = {}
    for name, executable in tools.items():
        if executable:
            with Path(executable).open("rb") as stream:
                tool_identities[name] = {"path": executable, "sha256": digest_stream(stream)}
    apks = []
    for path in sorted((root / "assets").glob("*.apk")):
        entry = {"path": relative(path), **identify(path)}
        prior_apk = next((a for a in previous.get("apks", [])
                          if a.get("path") == entry["path"] and a.get("sha256") == entry["sha256"]), None)
        if (prior_apk and not verify and previous.get("tool_identities") == tool_identities
                and previous.get("collector_sha256") == collector_sha256):
            for key in ("badging", "package", "signing", "selected_members", "member_count", "duplicate_member_names"):
                entry[key] = prior_apk[key]
            entry["inspection_mode"] = "reused_for_same_apk_hash_and_tool_paths"
        else:
            badging = run([aapt2, "dump", "badging", str(path)]) if aapt2 else {"error": "aapt2 not found"}
            package_line = next((line for line in badging.get("stdout", "").splitlines() if line.startswith("package:")), "")
            entry["package"] = dict(re.findall(r"(\w+)='([^']*)'", package_line))
            entry["badging"] = {k: v for k, v in badging.items() if k != "stdout"}
            entry["badging"]["package_line"] = package_line
            signing = run([apksigner, "verify", "--print-certs", str(path)]) if apksigner else {"error": "apksigner not found"}
            entry["signing"] = signing
            selected = []
            with zipfile.ZipFile(path) as archive:
                names = archive.namelist()
                entry["member_count"] = len(names)
                entry["duplicate_member_names"] = [n for n, c in Counter(names).items() if c > 1]
                for item in archive.infolist():
                    if item.filename.endswith((".so", "global-metadata.dat")) or item.filename in (
                            "classes.dex", "assets/bin/Data/data.unity3d", "assets/bin/Data/datapack.unity3d"):
                        member = {"name": item.filename, "bytes": item.file_size,
                                  "compressed_bytes": item.compress_size, "crc32": f"{item.CRC:08x}"}
                        # Hash IL2CPP/metadata directly from zip; keep giant data member inventory-only.
                        if item.filename.endswith((".so", "global-metadata.dat")):
                            with archive.open(item) as stream:
                                member["sha256"] = digest_stream(stream)
                        selected.append(member)
            entry["selected_members"] = selected
            entry["inspection_mode"] = "read_zip_and_local_android_sdk"
        apks.append(entry)
    if not apks:
        raise ValueError("no assets APK inputs")

    copies = [{"path": relative(path), **identify(path)} for path in sorted((root / "apk").glob("*.apk"))]
    for copy in copies:
        copy["matches_assets"] = [a["path"] for a in apks if a["sha256"] == copy["sha256"]]

    stats_path = root / "out/mb/_stats.json"
    identify(stats_path)
    stats = json.loads(stats_path.read_text())
    previous_dump_path = output / "dump_coverage.json"
    previous_dump = json.loads(previous_dump_path.read_text()) if previous_dump_path.exists() else {}
    prior_records = previous_dump.get("classes", {})
    class_records, errors = {}, []
    totals, actual_totals = Counter(), Counter()
    for cls, counters in stats["stats"].items():
        totals.update(counters)
        path = root / "out/mb" / (cls + ".jsonl.gz")
        record = {"declared": counters, "dump_exists": path.exists()}
        if path.exists():
            file_id = identify(path)
            record["input_sha256"] = file_id["sha256"]
            prior = prior_records.get(cls, {})
            if (not verify and prior.get("input_sha256") == file_id["sha256"]
                    and previous.get("collector_sha256") == collector_sha256):
                actual = prior["actual"]
            else:
                actual = Counter()
                identities = set()
                with gzip.open(path, "rt", encoding="utf-8") as stream:
                    for line in stream:
                        if not line.strip():
                            continue
                        row = json.loads(line)
                        actual["rows"] += 1
                        if "_file" not in row or "_path_id" not in row:
                            actual["missing_identity"] += 1
                        else:
                            key = (row["_file"], row["_path_id"])
                            if key in identities:
                                actual["duplicate_identity_within_class"] += 1
                            identities.add(key)
            record["actual"] = dict(actual)
            actual_totals.update(actual)
        else:
            record["actual"] = {}
        record["row_count_matches_declared_ok"] = record["actual"].get("rows", 0) == counters.get("ok", 0)
        if cls in stats.get("erros", {}):
            record["error"] = stats["erros"][cls]
            errors.append({"class": cls, "declared": counters, "error": record["error"]})
        class_records[cls] = record
    extra = sorted(path.name for path in (root / "out/mb").glob("*.jsonl.gz")
                   if path.name.removesuffix(".jsonl.gz") not in stats["stats"])
    dump = {"schema_version": 1, "evidence_class": "STATIC_local_dumps_recounted",
            "stats_input": relative(stats_path), "class_count": len(class_records),
            "error_class_count": len(errors), "declared_totals": dict(totals),
            "actual_totals": dict(actual_totals), "error_classes": errors,
            "classes_with_count_mismatch": [c for c, r in class_records.items() if not r["row_count_matches_declared_ok"]],
            "extra_dump_files_not_in_stats": extra, "classes": class_records,
            "limitations": ["Recount validates cached JSONL identities/counts, not correct type layouts or provenance to current APK splits.",
                            "Duplicate checks are within each class; cross-class object collisions are not checked here."]}

    source_paths = sorted(set((root / "client/AvatarWorldClient/Assets/Scripts").rglob("*.cs")) |
                          set((root / "client/AvatarWorldClient/Assets/Tests").rglob("*.cs")))
    source_manifest = {relative(p): identify(p)["sha256"] for p in source_paths}
    source_digest = hashlib.sha256(json.dumps(source_manifest, sort_keys=True).encode()).hexdigest()
    tests = []
    for path in sorted((root / "out").glob("test-results*.xml")):
        info = identify(path)
        xml = ET.parse(path).getroot()
        newer = [relative(p) for p in source_paths if p.stat().st_mtime_ns > path.stat().st_mtime_ns]
        tests.append({"path": relative(path), "sha256": info["sha256"], "attributes": xml.attrib,
                      "evidence_class": "HISTORICAL_test_execution_not_rerun",
                      "source_revision_binding": "UNKNOWN_no_build_input_manifest_in_xml",
                      "current_sources_newer_than_xml": newer,
                      "freshness_note": "mtime comparison is only a warning; no current source equivalence is certified"})
    derived = []
    for name in ("out/navigation-map/navigation.json", "out/avatar-spine-inventory.json",
                 "out/avatar-gpu-probe-report.json", "out/avatar-render-probe.json",
                 "out/avatar-outfit-probe-report.json", "out/rea-avatar-base-20261101.json"):
        path = root / name
        if path.exists():
            item = {"path": name, **identify(path), "maturity": "existing_evidence_reuse_candidate"}
            data = json.loads(path.read_text())
            item["summary"] = data.get("counts") or {k: v for k, v in data.items()
                                                    if isinstance(v, (int, float, str, bool))}
            derived.append(item)
    doc_paths = [root / "docs" / n for n in ("OFFLINE_HOME_RULES.md", "OFFLINE_RECONSTRUCTION_STATUS.md",
                 "REA_NAVIGATION_MAPPING_2026-11-01.md", "AVATAR_ASSET_FINDINGS.md")]
    docs = [{"path": relative(p), **identify(p)} for p in doc_paths if p.exists()]
    builds = [{"path": relative(p), **identify(p), "source_binding": "UNKNOWN_no_build_input_manifest"}
              for p in sorted((root / "client/AvatarWorldClient/Builds").glob("*.apk"))]
    existing = {"schema_version": 1, "client_source_manifest": source_manifest,
                "client_source_manifest_sha256": source_digest,
                "tests": tests, "derived_evidence": derived, "docs": docs, "builds": builds,
                "reconciliation": [
                    {"area": "navigation", "state": "partial", "reuse": "254 scene paths, 115 building and 101 entry destination joins; verified in earlier mapping run",
                     "remaining": "method bodies, runtime transitions, zone membership, full scene behavior"},
                    {"area": "avatar", "state": "partial", "reuse": "existing skeleton/SUT probes, renderer/editor and saved appearance",
                     "remaining": "all families/catalog, material ambiguity, full behavior and integrated runtime parity"},
                    {"area": "offline_economy", "state": "implemented_with_historical_tests",
                     "reuse": "authorized local rules, OfflineHomeService and existing test XML/device reports",
                     "remaining": "bind exact source/build/test revisions and distinguish offline design from original backend parity"},
                ], "limitations": ["No Unity build/tests, device action or replay executed by this collector.",
                                    "Existing log/XML/screenshots are historical observations, never current functional equivalence."]}
    packages = [a.get("package", {}) for a in apks]
    identity_ok = all(p.get("name") == "com.pazugames.avatarworld" and p.get("versionCode") == "228" for p in packages)
    identity_ok = identity_ok and all(a.get("badging", {}).get("returncode") == 0 for a in apks)
    certs = []
    for a in apks:
        certs.append(re.findall(r"Signer #\d+ certificate SHA-256 digest: (\w+)", a.get("signing", {}).get("stdout", "")))
    signing_ok = bool(certs) and all(certs) and all(c == certs[0] for c in certs) and all(a.get("signing", {}).get("returncode") == 0 for a in apks)
    baseline = {"schema_version": 1, "collector_version": VERSION, "collector_sha256": collector_sha256,
                "collected_at": datetime.now(timezone.utc).isoformat(), "evidence_class": "STATIC_local_tools",
                "tools": tools, "tool_identities": tool_identities, "git": commands, "apks": apks, "copies": copies,
                "package_version_identity_consistent": identity_ok,
                "signatures_verified_and_certificate_digests_consistent": signing_ok,
                "inputs": inputs, "hash_operations": dict(hash_counts),
                "source_manifest_sha256": source_digest,
                "limits": ["Version/package/signature consistency does not prove current remote availability or official provenance.",
                           "ZIP central-directory inventory is not a complete behavioral analysis or all-member decompression check.",
                           "Incremental SHA reuse trusts unchanged stat fingerprints; --verify independently rehashes/recounts inputs.",
                           "Native/metadata hashes bind bytes in splits; registration and method mapping remain separate tasks."]}
    atomic_json(output / "baseline.json", baseline)
    atomic_json(output / "existing_work.json", existing)
    atomic_json(output / "dump_coverage.json", dump)
    return {"identity_consistent": identity_ok, "signing_consistent": signing_ok,
            "apks": len(apks), "hash_operations": dict(hash_counts), "dump_classes": len(class_records),
            "declared_dump_totals": dict(totals), "actual_dump_totals": dict(actual_totals),
            "error_classes": len(errors), "count_mismatches": len(dump["classes_with_count_mismatch"]),
            "dump_identity_issues": actual_totals["missing_identity"] + actual_totals["duplicate_identity_within_class"],
            "test_reports": len(tests), "outputs": str(output)}


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--root", type=Path, default=ROOT)
    parser.add_argument("--output", type=Path)
    parser.add_argument("--verify", action="store_true")
    args = parser.parse_args()
    started = time.monotonic()
    result = collect(args.root, args.output, args.verify)
    result["duration_seconds"] = round(time.monotonic() - started, 3)
    print(json.dumps(result, ensure_ascii=False, indent=2))
    return 0 if (result["identity_consistent"] and result["signing_consistent"]
                 and not result["count_mismatches"] and not result["dump_identity_issues"]) else 1


if __name__ == "__main__":
    raise SystemExit(main())
