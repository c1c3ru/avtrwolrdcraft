#!/usr/bin/env python3
"""Create bounded hash-bound child planning specs, without changing the live queue.

Includes all failing MB classes and packaged scenes, but only five navigation
pilot methods. Two narrow prerequisite reviews avoid falsely completing the
entire IL2CPP identity/index parent packages to unblock those pilot methods.
"""
import argparse
from collections import Counter
import copy
import hashlib
import json
from pathlib import Path
import re
import tempfile

ROOT = Path(__file__).resolve().parents[1]
PILOTS = (
    ("Game.Home.HomePlayButton", "LoadPlayScene", "0x060054ef", 0),
    ("PWC.GameSceneManager", "GetCurrentWorldSceneName", "0x06005708", 0),
    ("PWC.GameSceneManager", "LoadScene", "0x060056fe", 3),
    ("PWC.GameSceneManager", "LoadSceneImplement", "0x060056ff", 1),
    ("PWC.World.Buildings.WorldBuilding", "ClickOnLevel", "0x06006081", 1),
)


class SourceError(ValueError):
    pass


def digest(path):
    h = hashlib.sha256()
    with path.open("rb") as stream:
        for chunk in iter(lambda: stream.read(1024 * 1024), b""):
            h.update(chunk)
    return h.hexdigest()


def short_id(value):
    return hashlib.sha256(value.encode("utf-8")).hexdigest()[:16]


def natural(value):
    return isinstance(value, int) and not isinstance(value, bool) and value >= 0


def valid_sha(value):
    return isinstance(value, str) and re.fullmatch(r"[0-9a-f]{64}", value) is not None


def atomic_write(path, data):
    path.parent.mkdir(parents=True, exist_ok=True)
    temporary = None
    try:
        with tempfile.NamedTemporaryFile("w", encoding="utf-8", dir=path.parent,
                                         prefix="." + path.name + ".", delete=False) as out:
            json.dump(data, out, ensure_ascii=False, indent=2, allow_nan=False)
            out.write("\n")
            temporary = Path(out.name)
        temporary.replace(path)
    finally:
        if temporary is not None:
            temporary.unlink(missing_ok=True)


class Sources:
    """Hash a source once per run, retaining a compact selector per child ref."""
    def __init__(self, root):
        self.root = root.resolve()
        self.refs = {}

    def path(self, relative):
        if not isinstance(relative, str) or not relative or Path(relative).is_absolute() or ".." in Path(relative).parts:
            raise SourceError("source path must be relative and contained in root")
        path = (self.root / relative).resolve()
        if not path.is_relative_to(self.root) or not path.is_file():
            raise SourceError(f"source missing or outside root: {relative}")
        return path

    def ref(self, relative, selector=None, expected=None):
        if relative not in self.refs:
            path = self.path(relative)
            before = path.stat()
            value = {"path": relative, "sha256": digest(path), "bytes": before.st_size}
            after = path.stat()
            if (before.st_size, before.st_mtime_ns, before.st_ctime_ns) != (after.st_size, after.st_mtime_ns, after.st_ctime_ns):
                raise SourceError(f"source changed while hashing: {relative}")
            self.refs[relative] = value
        result = dict(self.refs[relative])
        if expected is not None and (not valid_sha(expected) or result["sha256"] != expected):
            raise SourceError(f"source hash does not match declared identity: {relative}")
        if selector is not None:
            result["selector"] = selector
        return result

    def load(self, relative):
        self.ref(relative)
        try:
            return json.loads(self.path(relative).read_text(encoding="utf-8"))
        except (OSError, ValueError) as error:
            raise SourceError(f"invalid JSON source: {relative}: {error}") from error


def task(task_id, parent, role, title, dependencies, maturity, refs, scope,
         questions, steps, acceptance, output_names, extra_locks=()):
    output_dir = f"out/recon/tasks/{task_id}"
    return {
        "id": task_id, "parent_id": parent, "title": title, "role": role,
        "dependencies": dependencies, "baseline_maturity": maturity,
        "state": "pending", "planning_seed": True, "scope": scope,
        "input_refs": refs, "allowed_paths": [output_dir + "/**"],
        "resource_locks": ["task-output:" + task_id, *extra_locks],
        "questions": questions, "steps": steps,
        "input_and_steps": " ".join(steps),
        "outputs": [output_dir + "/" + name for name in output_names],
        "acceptance": acceptance, "evidence_refs": [], "unknown_ids": [],
        "attempts": [], "owner": None, "lease": None, "review": None,
        "next_action": "Wait for exact dependencies, claim exclusive outputs, revalidate input hashes, then execute the bounded scope; never autoaccept.",
        "readiness": {"dependencies_require_live_queue_acceptance": True,
                      "body_recovery_or_scene_binding_not_implied_by_discovery": True},
    }


def generate(root=ROOT):
    sources = Sources(Path(root))
    baseline_path = "reports/recon/baseline.json"
    coverage_path = "reports/recon/dump_coverage.json"
    scenes_path = "out/navigation-map/scenes.json"
    methods_path = "out/recon/il2cpp/assembly_csharp_methods.jsonl"
    bootstrap_path = "reports/recon/il2cpp_bootstrap.json"
    baseline = sources.load(baseline_path)
    coverage = sources.load(coverage_path)
    scenes = sources.load(scenes_path)
    bootstrap = sources.load(bootstrap_path)
    if (baseline.get("schema_version") != 1 or baseline.get("package_version_identity_consistent") is not True
            or baseline.get("signatures_verified_and_certificate_digests_consistent") is not True):
        raise SourceError("baseline must have verified consistent package/version/signatures")
    apks = baseline.get("apks", [])
    if not isinstance(apks, list) or not apks:
        raise SourceError("baseline APK inventory required")
    for apk in apks:
        if not isinstance(apk, dict) or not valid_sha(apk.get("sha256")):
            raise SourceError("invalid baseline APK identity")
    base = [a for a in apks if a.get("path") == "assets/base.apk"]
    if len(base) != 1:
        raise SourceError("exactly one base APK identity required")
    base_ref = sources.ref("assets/base.apk", expected=base[0]["sha256"])
    baseline_ref = sources.ref(baseline_path)

    # Preserve both failure causes and failure counts; dedupe identical repeated
    # source rows but reject conflicting identities or totals instead of hiding them.
    if coverage.get("schema_version") != 1 or not isinstance(coverage.get("error_classes"), list):
        raise SourceError("unsupported MB coverage source")
    error_rows = {}
    for row in coverage["error_classes"]:
        if (not isinstance(row, dict) or not isinstance(row.get("class"), str) or not row["class"]
                or not isinstance(row.get("error"), str) or not row["error"]
                or not isinstance(row.get("declared"), dict)):
            raise SourceError("invalid error class record")
        if any(not natural(v) for v in row["declared"].values()) or row["declared"].get("err", 0) <= 0:
            raise SourceError("failing class must retain positive integer err count")
        prior = error_rows.setdefault(row["class"], row)
        if prior != row:
            raise SourceError(f"conflicting duplicate class: {row['class']}")
    if coverage.get("error_class_count") != len(error_rows):
        raise SourceError("error class count does not match unique records")
    failed_objects = sum(row["declared"]["err"] for row in error_rows.values())
    if coverage.get("declared_totals", {}).get("err") != failed_objects:
        raise SourceError("failed-object total does not match class failures")
    tasks = []
    for cls, row in sorted(error_rows.items()):
        task_id = "T020/CLASS/" + short_id(base_ref["sha256"] + ":" + cls)
        refs = [baseline_ref, sources.ref(coverage_path, {"class": cls})]
        original = coverage.get("classes", {}).get(cls, {})
        if "declared" in original and original["declared"] != row["declared"]:
            raise SourceError(f"class counters disagree between summary and class detail: {cls}")
        if "error" in original and original["error"] != row["error"]:
            raise SourceError(f"class cause disagrees between summary and class detail: {cls}")
        task_scope = {"class_name": cls, "failure_cause": row["error"],
                      "declared_counts": row["declared"],
                      "existing_dump_present": original.get("dump_exists"),
                      "provenance_status": "UNKNOWN_layout_and_current_split_linkage_not_revalidated",
                      "expected_reprocess_limit": row["declared"]["err"]}
        tasks.append(task(task_id, "T020", "artefatos", f"Corrigir decodificação de {cls}",
                          ["T001"], "partial", refs, task_scope,
                          ["Which typetree/alignment/layout operation causes this exact failure?",
                           "Which exact serialized object identities failed, and can only those be reprocessed?"],
                          ["Read this class failure and counters; locate original per-object inputs without redumping the full bundle.",
                           "Recover a minimal failing fixture and validate field offsets/alignment against correct script/metadata identity.",
                           "Implement parser correction as an isolated patch, rerun only affected objects and reconcile counts before independent review."],
                          "Preserve original err count/cause, identify every affected object, demonstrate corrected decoding/layout and exact count reconciliation; unresolved objects remain explicit unknowns.",
                          ["class-contract.json", "recount.json", "result.json"]))

    if not isinstance(scenes, list) or not scenes:
        raise SourceError("nonempty scene array required")
    scene_rows = {}
    for row in scenes:
        if (not isinstance(row, dict) or not natural(row.get("build_index"))
                or not isinstance(row.get("scene_path"), str) or not row["scene_path"]
                or not isinstance(row.get("scene_name"), str) or not row["scene_name"]
                or not isinstance(row.get("serialized_binding_status"), str)
                or not row["serialized_binding_status"]):
            raise SourceError("invalid scene record or missing binding status")
        previous = scene_rows.setdefault(row["build_index"], row)
        if previous != row:
            raise SourceError("conflicting scene records at one build index")
    for index, row in sorted(scene_rows.items()):
        task_id = f"T015/SCENE/{index:03d}-" + short_id(base_ref["sha256"] + ":" + row["scene_path"])
        scene_scope = {key: copy.deepcopy(row.get(key)) for key in (
            "build_index", "scene_path", "scene_name", "serialized_candidate",
            "serialized_binding_status", "candidate_present_in_cached_bundle_directory", "evidence_class")}
        scene_scope["cached_root_count"] = len(row.get("cached_roots", []))
        scene_scope["content_classification"] = "UNKNOWN_gameplay_auxiliary_or_editor_requires_scene_review"
        tasks.append(task(task_id, "T015", "artefatos", f"Varrer cena {index}: {row['scene_name']}",
                          ["T001"], "partial", [baseline_ref, base_ref,
                          sources.ref(scenes_path, {"build_index": index, "scene_path": row["scene_path"]})], scene_scope,
                          ["Does the serialized candidate independently bind to this BuildSettings scene path?",
                           "What are all active/inactive objects, scripts, controls, prefab and external dependencies?"],
                          ["Reuse cached scene/root records, retaining their inferred binding status until independently checked.",
                           "Verify the exact scene-to-serialized-file relationship and selectively extract only missing entries into owned output paths.",
                           "Inventory complete scene hierarchy/components/references, classify gameplay/editor/auxiliary, and emit unknowns plus child feature candidates."],
                          "Independently justify scene binding, reconcile all scene objects/references and classify every component; sprite export or a name/index join alone is insufficient.",
                          ["scene-contract.json", "objects.jsonl", "unknowns.jsonl", "result.json"],
                          ["scene-extraction:" + str(row.get("serialized_candidate") or short_id(row["scene_path"]))]))

    # Bind the extracted pair to bootstrap metadata AND byte identities inventoried
    # directly from the APK members by the independent baseline collector.
    pair_refs = [baseline_ref, sources.ref(bootstrap_path)]
    pair = {}
    for key in ("native", "metadata"):
        record = bootstrap.get("inputs", {}).get(key)
        if not isinstance(record, dict) or not valid_sha(record.get("sha256")):
            raise SourceError(f"missing bootstrap {key} identity")
        matches = [member for apk in apks if apk.get("path") == record.get("apk")
                   for member in apk.get("selected_members", [])
                   if member.get("name") == record.get("member") and member.get("sha256") == record["sha256"]]
        if len(matches) != 1:
            raise SourceError(f"bootstrap {key} does not match an inventoried APK member")
        pair[key] = {k: record[k] for k in ("apk", "member", "derived_path", "sha256")}
        pair_refs.append(sources.ref(record["derived_path"], expected=record["sha256"]))
    pair_id = "T021/PAIR/" + pair["native"]["sha256"][:12] + "-" + pair["metadata"]["sha256"][:12]
    pilot_index_id = "T022/PILOT_INDEX/" + pair["native"]["sha256"][:12]
    tasks.append(task(pair_id, "T021", "validação", "Revisar identidade do par IL2CPP/metadata deste piloto",
                      ["T001"], "partial", pair_refs,
                      {"pair": pair, "scope_limit": "Only exact input identity/version/ABI pairing; full registrations and T021 parent remain incomplete."},
                      ["Do source APK members and derived files have identical hashes, compatible metadata version and native ABI?"],
                      ["Independently compare the two derived file hashes with baseline APK member hashes and bootstrap identities.",
                       "Check metadata magic/version and ELF ABI, record provenance/limitations, and submit independent acceptance for only this narrow pair."],
                      "Independent reviewer confirms exact APK/member/derived identities, metadata version and ELF ABI; do not imply recovered registrations, generic dispatch or all of parent T021.",
                      ["pair-review.json", "result.json"]))

    methods_ref = sources.ref(methods_path)
    selected, seen_tokens = {}, set()
    expected_by_token = {pilot[2]: pilot for pilot in PILOTS}
    try:
        with sources.path(methods_path).open(encoding="utf-8") as stream:
            for line_number, line in enumerate(stream, 1):
                if not line.strip():
                    continue
                row = json.loads(line)
                if not isinstance(row, dict) or not isinstance(row.get("token"), str):
                    raise SourceError(f"invalid method record at line {line_number}")
                token = row["token"]
                if token not in expected_by_token:
                    continue
                if token in seen_tokens:
                    raise SourceError(f"duplicate selected method token: {token}")
                seen_tokens.add(token)
                cls, name, _, params = expected_by_token[token]
                if (row.get("declaring_type"), row.get("name"), row.get("parameter_count"), row.get("image")) != (cls, name, params, "Assembly-CSharp.dll"):
                    raise SourceError(f"pilot token points to unexpected identity/overload: {token}")
                for address in ("vaddr", "file_offset"):
                    if not isinstance(row.get(address), str) or not re.fullmatch(r"0x[0-9a-fA-F]+", row[address]):
                        raise SourceError(f"pilot has no valid {address}: {token}")
                if not row.get("mapping_status") or not row.get("body_extent") or not row.get("semantic_status"):
                    raise SourceError(f"pilot mapping/body/semantic status missing: {token}")
                selected[token] = row
    except (OSError, json.JSONDecodeError) as error:
        raise SourceError(f"invalid method index: {error}") from error
    if set(selected) != set(expected_by_token):
        raise SourceError("selected pilot method tokens missing from index")
    tasks.append(task(pilot_index_id, "T022", "validação", "Revisar joins token/endereço dos cinco métodos piloto",
                      ["T001", pair_id], "partial", [*pair_refs, methods_ref],
                      {"image": "Assembly-CSharp.dll", "tokens": sorted(selected),
                       "scope_limit": "Only five selected token/owner/RID/relocation/address joins; full T022 inventory remains incomplete."},
                      ["Do all five tokens point to the exact owner/overload and file-backed executable address in the reviewed pair?"],
                      ["Independently check selected token/owner/RID and relocation joins against metadata/native bytes.",
                       "Check executable address/file offset and first bytes; retain unknown body extents, shared/generic and indirect-call limits.",
                       "Submit a narrow review record for only the five index entries; do not certify semantics or full index coverage."],
                      "Five identities/addresses independently validated against the reviewed pair; no implicit proof of function size, indirect call targets, game behavior or parent T022 completion.",
                      ["pilot-index-review.json", "result.json"], ["native-analysis:avatar-arm64"]))
    for cls, name, token, _ in PILOTS:
        row = selected[token]
        task_id = "T025/METHOD/" + short_id(pair["native"]["sha256"] + ":" + pair["metadata"]["sha256"]
                                                   + ":Assembly-CSharp.dll:" + token + ":" + cls)
        tasks.append(task(task_id, "T025", "lógica", f"Recuperar contrato de {cls}.{name} ({token})",
                          ["T001", pilot_index_id], "partial",
                          [*pair_refs, sources.ref(methods_path, {"image": row["image"], "token": token})],
                          {"method_identity": {key: row.get(key) for key in (
                              "image", "token", "method_definition_index", "declaring_type", "name", "parameter_count",
                              "vaddr", "file_offset", "mapping_status", "body_extent", "semantic_status")},
                           "native_sha256": pair["native"]["sha256"], "metadata_sha256": pair["metadata"]["sha256"],
                           "existing_evidence": "Bounded assembly windows exist from earlier bootstrap; reuse after checking their inputs/profile, without assuming complete bodies."},
                          ["What are complete executable body ranges, CFG, guards, state and side effects of this method?",
                           "Which direct/indirect callees and runtime prerequisites remain unknown?"],
                          ["Require accepted narrow pair/index prerequisites, then inspect existing bounded assembly and references using the exact binary identity.",
                           "Recover all body ranges and control paths, signature/layout, calls, state and effects; follow needed callees with explicit child requests.",
                           "Produce candidate pseudocode and a contract with tests/fixtures and unresolved paths; leave semantics uncertified until independent review and adequate original/reference validation."],
                          "Complete bounded method contract with justified bytes/ranges/CFG, all observable effects and callee conditions, validated tests and independent review; unresolved relevant body/indirect paths prevent semantic completion.",
                          ["method-contract.json", "control-flow.json", "unknowns.jsonl", "result.json"],
                          ["native-analysis:avatar-arm64"]))

    ids = [row["id"] for row in tasks]
    if len(set(ids)) != len(ids):
        raise SourceError("generated duplicate child IDs")
    by_id = {row["id"]: row for row in tasks}
    for row in tasks:
        if row["parent_id"] in row["dependencies"]:
            raise SourceError("child cannot depend on its own parent closure")
        if any(dep not in by_id and dep != "T001" for dep in row["dependencies"]):
            raise SourceError("unknown exact prerequisite")
    # No timestamps, owners or source list positions: regeneration is byte-stable
    # for unchanged sources, and identities survive source record reordering.
    return {"schema_version": 1, "kind": "child_planning_specs", "generator_version": 1,
            "target": "Avatar World v1.227 / baseline-bound local artifacts",
            "scope": "Initial failing classes, packaged scenes and five navigation methods only; no live queue mutation or completed work claim.",
            "sources": [sources.refs[key] for key in sorted(sources.refs)],
            "counts": {"tasks": len(tasks), "parents": dict(sorted(Counter(t["parent_id"] for t in tasks).items())),
                       "failing_classes": len(error_rows), "failed_objects_preserved": failed_objects,
                       "scenes": len(scene_rows), "narrow_prerequisites": 2, "selected_methods": len(selected)},
            "required_existing_dependencies": ["T001"],
            "limits": ["All children are pending planning specs, never automatic completion or readiness.",
                       "Scene serialized bindings retain the source inferred/unknown status until independently checked.",
                       "Method body and semantic unknowns are preserved; selected token/address join is not a recovered implementation.",
                       "The 36,421-method index is streamed, but only the five exact pilot tokens generate method work now.",
                       "The parent T021/T022 packages remain incomplete even if their narrow prerequisite children are later reviewed."],
            "tasks": tasks}


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--root", type=Path, default=ROOT)
    parser.add_argument("--output", type=Path)
    args = parser.parse_args()
    output = args.output or args.root / "reports/recon/discovery_children.json"
    result = generate(args.root)
    atomic_write(output, result)
    print(json.dumps({"counts": result["counts"], "output": str(output),
                      "sha256": digest(output), "queue_modified": False}, ensure_ascii=False, indent=2))


if __name__ == "__main__":
    main()
