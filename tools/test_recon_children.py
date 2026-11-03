"""Bounded generator tests; fixtures never execute or modify the original game."""
import copy
import hashlib
import json
from pathlib import Path
import tempfile
import unittest

import recon_children as children


class ChildrenTests(unittest.TestCase):
    def setUp(self):
        self.directory = tempfile.TemporaryDirectory(prefix="recon-children-test-")
        self.addCleanup(self.directory.cleanup)
        self.root = Path(self.directory.name)
        self.write("assets/base.apk", b"base fixture bytes, not an APK")
        self.write("out/recon/il2cpp/libil2cpp.so", b"native fixture bytes")
        self.write("out/recon/il2cpp/global-metadata.dat", b"metadata fixture bytes")
        self.baseline = {
            "schema_version": 1, "package_version_identity_consistent": True,
            "signatures_verified_and_certificate_digests_consistent": True,
            "apks": [{"path": "assets/base.apk", "sha256": self.sha("assets/base.apk"),
                      "selected_members": [{"name": "metadata/member", "sha256": self.sha("out/recon/il2cpp/global-metadata.dat")}]},
                     {"path": "assets/abi.apk", "sha256": "a" * 64,
                      "selected_members": [{"name": "native/member", "sha256": self.sha("out/recon/il2cpp/libil2cpp.so")}]}],
        }
        self.bootstrap = {"inputs": {
            "native": {"apk": "assets/abi.apk", "member": "native/member", "derived_path": "out/recon/il2cpp/libil2cpp.so",
                       "sha256": self.sha("out/recon/il2cpp/libil2cpp.so")},
            "metadata": {"apk": "assets/base.apk", "member": "metadata/member", "derived_path": "out/recon/il2cpp/global-metadata.dat",
                         "sha256": self.sha("out/recon/il2cpp/global-metadata.dat")},
        }}
        self.coverage = {"schema_version": 1, "error_class_count": 2, "declared_totals": {"ok": 9, "err": 7},
                         "error_classes": [{"class": "Fixture.A", "declared": {"ok": 4, "err": 2}, "error": "fixture alignment error"},
                                           {"class": "Fixture.B", "declared": {"ok": 5, "err": 5}, "error": "fixture EOF error"}],
                         "classes": {"Fixture.A": {"dump_exists": True}, "Fixture.B": {"dump_exists": True}}}
        self.scenes = [{"build_index": index, "scene_name": name, "scene_path": f"Assets/{name}.unity",
                        "serialized_candidate": f"level{index}",
                        "serialized_binding_status": "INFERRED_fixture_binding",
                        "candidate_present_in_cached_bundle_directory": True,
                        "cached_roots": [], "evidence_class": "STATIC_fixture"}
                       for index, name in [(3, "Home"), (4, "World")]]
        self.methods = [{"image": "Assembly-CSharp.dll", "token": token,
                         "declaring_type": cls, "name": name, "parameter_count": params,
                         "method_definition_index": index, "vaddr": hex(4096 + index * 16),
                         "file_offset": hex(index * 16), "mapping_status": "DERIVED_fixture",
                         "body_extent": "UNKNOWN_fixture", "semantic_status": "UNKNOWN_fixture"}
                        for index, (cls, name, token, params) in enumerate(children.PILOTS)]
        self.save()

    def write(self, relative, data):
        path = self.root / relative
        path.parent.mkdir(parents=True, exist_ok=True)
        path.write_bytes(data)

    def json(self, relative, data):
        self.write(relative, (json.dumps(data) + "\n").encode())

    def sha(self, relative):
        return hashlib.sha256((self.root / relative).read_bytes()).hexdigest()

    def save(self):
        self.json("reports/recon/baseline.json", self.baseline)
        self.json("reports/recon/dump_coverage.json", self.coverage)
        self.json("reports/recon/il2cpp_bootstrap.json", self.bootstrap)
        self.json("out/navigation-map/scenes.json", self.scenes)
        self.write("out/recon/il2cpp/assembly_csharp_methods.jsonl", "".join(json.dumps(m) + "\n" for m in self.methods).encode())

    def test_bounded_initial_scope_and_no_completion(self):
        result = children.generate(self.root)
        self.assertEqual(result["counts"]["tasks"], 11)
        self.assertEqual(result["counts"]["failed_objects_preserved"], 7)
        self.assertEqual(result["counts"]["parents"], {"T015": 2, "T020": 2, "T021": 1, "T022": 1, "T025": 5})
        self.assertTrue(all(t["state"] == "pending" and not t["evidence_refs"] and t["review"] is None for t in result["tasks"]))
        self.assertTrue(all(t["baseline_maturity"] == "partial" for t in result["tasks"]))

    def test_byte_stable_regeneration_and_ids_stable_after_record_reordering(self):
        before = children.generate(self.root)
        self.assertEqual(before, children.generate(self.root))
        self.scenes.reverse()
        self.coverage["error_classes"].reverse()
        self.methods.reverse()
        self.save()
        after = children.generate(self.root)
        self.assertEqual([t["id"] for t in before["tasks"]], [t["id"] for t in after["tasks"]])

    def test_identical_duplicate_discovery_rows_are_deduped(self):
        self.scenes.append(copy.deepcopy(self.scenes[0]))
        self.coverage["error_classes"].append(copy.deepcopy(self.coverage["error_classes"][0]))
        self.save()
        result = children.generate(self.root)
        self.assertEqual(result["counts"]["tasks"], 11)
        self.assertEqual(result["counts"]["failed_objects_preserved"], 7)

    def test_conflicting_duplicate_class_rejected(self):
        row = copy.deepcopy(self.coverage["error_classes"][0]); row["declared"]["err"] = 99
        self.coverage["error_classes"].append(row); self.save()
        with self.assertRaisesRegex(children.SourceError, "conflicting duplicate class"):
            children.generate(self.root)

    def test_failure_total_cannot_be_hidden_or_reduced(self):
        self.coverage["declared_totals"]["err"] = 6; self.save()
        with self.assertRaisesRegex(children.SourceError, "failed-object total"):
            children.generate(self.root)

    def test_error_class_count_must_match(self):
        self.coverage["error_class_count"] = 1; self.save()
        with self.assertRaisesRegex(children.SourceError, "error class count"):
            children.generate(self.root)

    def test_failure_summary_and_detail_must_agree(self):
        self.coverage["classes"]["Fixture.A"]["declared"] = {"ok": 4, "err": 99}
        self.save()
        with self.assertRaisesRegex(children.SourceError, "counters disagree"):
            children.generate(self.root)

    def test_invalid_failure_counter_rejected(self):
        self.coverage["error_classes"][0]["declared"]["err"] = True; self.save()
        with self.assertRaisesRegex(children.SourceError, "integer err count"):
            children.generate(self.root)

    def test_inferred_scene_binding_is_not_promoted(self):
        result = children.generate(self.root)
        tasks = [t for t in result["tasks"] if t["parent_id"] == "T015"]
        self.assertTrue(all(t["scope"]["serialized_binding_status"] == "INFERRED_fixture_binding" for t in tasks))
        self.scenes[0].pop("serialized_binding_status"); self.save()
        with self.assertRaisesRegex(children.SourceError, "binding status"):
            children.generate(self.root)

    def test_conflicting_build_index_rejected(self):
        row = copy.deepcopy(self.scenes[0]); row["scene_path"] = "Assets/Other.unity"
        self.scenes.append(row); self.save()
        with self.assertRaisesRegex(children.SourceError, "conflicting scene"):
            children.generate(self.root)

    def test_exact_token_owner_and_overload_must_match(self):
        self.methods[0]["parameter_count"] = 1; self.save()
        with self.assertRaisesRegex(children.SourceError, "unexpected identity/overload"):
            children.generate(self.root)

    def test_missing_or_duplicate_pilot_method_rejected(self):
        removed = self.methods.pop(); self.save()
        with self.assertRaisesRegex(children.SourceError, "tokens missing"):
            children.generate(self.root)
        self.methods.extend([removed, copy.deepcopy(removed)]); self.save()
        with self.assertRaisesRegex(children.SourceError, "duplicate selected method"):
            children.generate(self.root)

    def test_native_file_and_baseline_member_hashes_must_match(self):
        self.write("out/recon/il2cpp/libil2cpp.so", b"changed native fixture")
        with self.assertRaisesRegex(children.SourceError, "hash does not match"):
            children.generate(self.root)

    def test_invalid_baseline_and_malformed_index_rejected(self):
        self.baseline["package_version_identity_consistent"] = False; self.save()
        with self.assertRaisesRegex(children.SourceError, "baseline must"):
            children.generate(self.root)
        self.baseline["package_version_identity_consistent"] = True; self.save()
        self.write("out/recon/il2cpp/assembly_csharp_methods.jsonl", b"not-json\n")
        with self.assertRaisesRegex(children.SourceError, "invalid method index"):
            children.generate(self.root)

    def test_hash_refs_dependencies_and_exact_output_ownership(self):
        result = children.generate(self.root)
        by_id = {t["id"]: t for t in result["tasks"]}
        pair = next(t for t in result["tasks"] if t["parent_id"] == "T021")
        pilot = next(t for t in result["tasks"] if t["parent_id"] == "T022")
        self.assertEqual(pair["dependencies"], ["T001"])
        self.assertIn(pair["id"], pilot["dependencies"])
        for task in result["tasks"]:
            self.assertNotIn(task["parent_id"], task["dependencies"])
            self.assertTrue(all(dep == "T001" or dep in by_id for dep in task["dependencies"]))
            self.assertTrue(task["allowed_paths"] and task["resource_locks"] and task["outputs"])
            self.assertTrue(all(out.startswith(f"out/recon/tasks/{task['id']}/") for out in task["outputs"]))
            for ref in task["input_refs"]:
                self.assertEqual(ref["sha256"], self.sha(ref["path"]))
            if task["parent_id"] == "T025":
                self.assertIn(pilot["id"], task["dependencies"])
                self.assertEqual(task["scope"]["method_identity"]["body_extent"], "UNKNOWN_fixture")

    def test_unselected_methods_do_not_expand_work(self):
        self.methods.append({"token": "0x0600ffff", "name": "Other", "image": "Assembly-CSharp.dll"}); self.save()
        result = children.generate(self.root)
        self.assertEqual(result["counts"]["selected_methods"], 5)
        self.assertEqual(result["counts"]["tasks"], 11)

    def test_input_ref_paths_cannot_escape_workspace(self):
        sources = children.Sources(self.root)
        with self.assertRaises(children.SourceError):
            sources.ref("../outside.json")
        with self.assertRaises(children.SourceError):
            sources.ref("/etc/passwd")


if __name__ == "__main__":
    unittest.main()
