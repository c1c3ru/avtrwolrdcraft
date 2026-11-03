import copy
import json
import multiprocessing
import shutil
from pathlib import Path
import tempfile
import unittest
from unittest.mock import patch

from recon_queue import Queue, QueueError, atomic_write, digest, main, validate


def concurrent_claim(path, actor, start, results, task_id="A"):
    start.wait(5)
    try:
        Queue(path).claim(task_id, actor)
        results.put("claimed")
    except QueueError:
        results.put("denied")


def task(name, dependencies=(), resources=()):
    return {"id": name, "parent_id": None, "state": "pending", "dependencies": list(dependencies),
            "acceptance": "Reviewer compares recorded behavior and scoped results",
            "input_refs": [], "evidence_refs": [], "allowed_paths": ["out/" + name + "/**"],
            "resource_locks": list(resources), "attempts": [], "owner": None, "lease": None,
            "planning_seed": True}


class QueueTests(unittest.TestCase):
    def setUp(self):
        self.tmp = tempfile.TemporaryDirectory()
        self.addCleanup(self.tmp.cleanup)
        self.root = Path(self.tmp.name)
        (self.root / "plan.md").write_text("acceptance and scope\n")
        (self.root / "input.txt").write_text("original bytes\n")
        (self.root / "result.json").write_text('{"observed":"scoped output"}\n')
        self.seed = self.root / "seed.json"
        self.path = self.root / "live/tasks.json"
        self.now = [1000.0]
        self.q = Queue(self.path, clock=lambda: self.now[0])
        self.create([task("A"), task("B", ["A"])])

    def create(self, tasks):
        data = {"schema_version": 1, "kind": "planning_seed_not_live_execution_state",
                "source_doc": "plan.md", "source_doc_sha256": digest(self.root / "plan.md"),
                "tasks": tasks}
        self.seed.write_text(json.dumps(data))
        self.q.init(self.seed, self.root)

    def configured(self, name="A", resources=None):
        self.q.configure(name, "coordinator", ["input.txt"], resources=resources)

    def submit(self, name="A", owner="worker"):
        self.configured(name)
        claim = self.q.claim(name, owner)
        self.q.checkpoint(name, owner, claim["lease"]["id"], "evidence_ready",
                          "Compare output and documented acceptance", ["result.json"])

    def test_seed_does_not_promote_or_allow_unconfigured_claim(self):
        self.assertEqual(self.q.status()["counts"], {"pending": 2})
        self.assertEqual([t["id"] for t in self.q.status(ready=True)], ["A"])
        with self.assertRaisesRegex(QueueError, "configure"):
            self.q.claim("A", "worker")
        with self.assertRaisesRegex(QueueError, "overwrite"):
            self.q.init(self.seed, self.root)

    def relocation_fixture(self):
        self.submit()
        self.q.review("A", "reviewer", True, "Checked evidence")
        self.configured("B")
        target = self.root / "moved"
        target.mkdir()
        for name in ("plan.md", "input.txt", "result.json"):
            shutil.copy2(self.root / name, target / name)
        return target

    def test_relocation_preserves_acceptance_and_allows_dependent_claim(self):
        target = self.relocation_fixture()
        before = self.q.load()
        self.q.relocate(target, "coordinator", "Moved checkout")
        after = self.q.load()
        self.assertEqual(before["tasks"], after["tasks"])
        self.assertEqual(after["revision"], before["revision"] + 1)
        self.assertEqual(after["history"][-1]["previous_root"], str(self.root))
        self.assertEqual(self.q.claim("B", "worker-b")["state"], "leased")

    def test_relocation_rejects_changed_evidence_atomically(self):
        target = self.relocation_fixture()
        before = self.path.read_bytes()
        (target / "result.json").write_text("modified")
        with self.assertRaisesRegex(QueueError, "stale reference"):
            self.q.relocate(target, "coordinator", "Moved checkout")
        self.assertEqual(self.path.read_bytes(), before)

    def test_relocation_rejects_symlink_escape(self):
        target = self.relocation_fixture()
        before = self.path.read_bytes()
        (target / "input.txt").unlink()
        (target / "input.txt").symlink_to(self.root / "input.txt")
        with self.assertRaisesRegex(QueueError, "within queue root"):
            self.q.relocate(target, "coordinator", "Moved checkout")
        self.assertEqual(self.path.read_bytes(), before)

    def test_relocation_refuses_even_expired_unrecovered_lease(self):
        target = self.relocation_fixture()
        self.q.claim("B", "worker-b", ttl=10)
        self.now[0] += 20
        before = self.path.read_bytes()
        with self.assertRaisesRegex(QueueError, "outstanding leases"):
            self.q.relocate(target, "coordinator", "Moved checkout")
        self.assertEqual(self.path.read_bytes(), before)

    def test_dependencies_block_claim_until_independent_approval(self):
        self.configured("B")
        with self.assertRaisesRegex(QueueError, "dependencies"):
            self.q.claim("B", "worker-b")
        self.submit()
        self.assertEqual(self.q.status()["counts"].get("done", 0), 0)
        self.q.review("A", "independent-reviewer", True, "Checked scope and output against input")
        self.assertEqual(self.q.claim("B", "worker-b")["state"], "leased")

    def test_owner_and_lease_token_are_required(self):
        self.configured()
        lease = self.q.claim("A", "worker")["lease"]["id"]
        with self.assertRaisesRegex(QueueError, "mismatch"):
            self.q.heartbeat("A", "other", lease)
        with self.assertRaisesRegex(QueueError, "mismatch"):
            self.q.heartbeat("A", "worker", "wrong-token")
        self.q.heartbeat("A", "worker", lease, start=True)
        self.now[0] += 20
        self.assertEqual(self.q.heartbeat("A", "worker", lease)["lease"]["heartbeat_at"], 1020)

    def test_expiry_does_not_steal_work_or_resources(self):
        self.configured(resources=["device:serial"])
        lease = self.q.claim("A", "worker", ttl=10)["lease"]["id"]
        self.now[0] += 11
        self.assertEqual(self.q.status()["expired_leases"], ["A"])
        with self.assertRaisesRegex(QueueError, "expired leases"):
            self.q.claim("A", "replacement")
        with self.assertRaisesRegex(QueueError, "attestation"):
            self.q.recover("A", "coordinator", "Process checked idle")
        self.q.recover("A", "coordinator", "Checked process idle; outputs retained", True)
        self.assertTrue((self.root / "result.json").exists())
        new = self.q.claim("A", "worker")["lease"]["id"]
        self.assertNotEqual(new, lease)
        with self.assertRaisesRegex(QueueError, "mismatch"):
            self.q.heartbeat("A", "worker", lease)

    def test_shared_resource_exclusive_even_if_lease_expired(self):
        data = self.q.load()
        data["tasks"][1]["dependencies"] = []
        atomic_write(self.path, data)
        self.configured("A", ["unity:project"])
        self.configured("B", ["unity:project"])
        self.q.claim("A", "one", ttl=5)
        self.now[0] += 6
        with self.assertRaisesRegex(QueueError, "resource held"):
            self.q.claim("B", "two")

    def test_author_cannot_review_and_reject_is_retryable(self):
        self.submit()
        with self.assertRaisesRegex(QueueError, "independent"):
            self.q.review("A", "worker", True, "Looks good")
        self.q.review("A", "reviewer", False, "Missing boundary cases")
        new = self.q.claim("A", "worker-two")
        self.assertEqual(len(new["attempts"]), 2)
        self.assertIsNone(new["review"])

    def test_changed_inputs_and_evidence_fail_closed(self):
        self.configured()
        (self.root / "input.txt").write_text("changed")
        with self.assertRaisesRegex(QueueError, "stale"):
            self.q.claim("A", "worker")
        self.submit()
        (self.root / "result.json").write_text("replaced after submit")
        with self.assertRaisesRegex(QueueError, "stale"):
            self.q.review("A", "reviewer", True, "Review must bind actual bytes")
        self.assertEqual(self.q.load()["tasks"][0]["state"], "review")

    def test_stale_evidence_can_be_rejected_but_not_approved(self):
        self.submit()
        (self.root / "result.json").write_text("changed after submission")
        with self.assertRaisesRegex(QueueError, "stale"):
            self.q.review("A", "reviewer", True, "Cannot accept changed output")
        rejected = self.q.review("A", "reviewer", False,
                                 "Output hash changed; reconfigure and resubmit exact result")
        self.assertEqual(rejected["state"], "rejected")
        self.assertEqual(rejected["review"]["verdict"], "reject")
        self.configured()
        self.assertEqual(self.q.claim("A", "worker-two")["state"], "leased")

    def test_invalid_transition_and_missing_evidence_do_not_persist(self):
        self.configured()
        claim = self.q.claim("A", "worker")
        before = self.path.read_bytes()
        with self.assertRaisesRegex(QueueError, "invalid checkpoint"):
            self.q.checkpoint("A", "worker", claim["lease"]["id"], "done", "bypass", [])
        with self.assertRaisesRegex(QueueError, "requires output"):
            self.q.checkpoint("A", "worker", claim["lease"]["id"], "evidence_ready", "submit", [])
        self.assertEqual(self.path.read_bytes(), before)

    def test_failed_and_blocked_checkpoint_release_lease_preserve_attempt(self):
        self.configured()
        claim = self.q.claim("A", "worker")
        self.q.checkpoint("A", "worker", claim["lease"]["id"], "blocked_external",
                          "Device unavailable; next step is bounded static analysis", ["result.json"])
        item = self.q.load()["tasks"][0]
        self.assertEqual(item["state"], "blocked_external")
        self.assertIsNone(item["lease"])
        self.assertEqual(item["attempts"][-1]["evidence_refs"], item["evidence_refs"])
        with self.assertRaisesRegex(QueueError, "not claimable"):
            self.q.claim("A", "other")
        self.configured()
        self.assertEqual(self.q.claim("A", "other")["state"], "leased")

    def test_ready_checkpoint_yields_partial_success_without_certification(self):
        self.configured(resources=["unity:project"])
        first = self.q.claim("A", "worker-one")
        yielded = self.q.checkpoint("A", "worker-one", first["lease"]["id"], "ready",
                                    "Bounded hash pass complete; next reconcile copies", ["result.json"])
        self.assertEqual(yielded["state"], "ready")
        self.assertIsNone(yielded["lease"])
        self.assertIsNone(yielded.get("review"))
        self.assertEqual(self.q.status()["counts"].get("done", 0), 0)
        self.assertEqual(self.q.status(ready=True)[0]["id"], "A")
        second = self.q.claim("A", "worker-two")
        self.assertEqual(second["input_refs"], first["input_refs"])
        self.assertEqual(second["resource_locks"], first["resource_locks"])
        self.assertNotEqual(second["lease"]["id"], first["lease"]["id"])
        self.assertEqual(second["attempts"][0]["state"], "ready")
        self.assertEqual(second["attempts"][0]["evidence_refs"], yielded["evidence_refs"])
        self.assertEqual(len(second["attempts"]), 2)

    def test_atomic_replace_failure_preserves_committed_queue(self):
        before = self.path.read_bytes()
        with patch("recon_queue.os.replace", side_effect=OSError("simulated interruption")):
            with self.assertRaises(OSError):
                self.configured()
        self.assertEqual(self.path.read_bytes(), before)
        self.assertFalse(list(self.path.parent.glob(".tasks.json.*")))
        self.assertEqual(self.q.status()["revision"], 0)

    def test_concurrent_claim_only_one_wins(self):
        self.configured()
        # Real wall-clock expiry is needed for child processes.
        ctx = multiprocessing.get_context("fork")
        start, results = ctx.Event(), ctx.Queue()
        workers = [ctx.Process(target=concurrent_claim, args=(str(self.path), str(i), start, results))
                   for i in range(2)]
        for worker in workers:
            worker.start()
        start.set()
        outcomes = [results.get(timeout=10) for _ in workers]
        for worker in workers:
            worker.join(10)
            self.assertEqual(worker.exitcode, 0)
        self.assertEqual(sorted(outcomes), ["claimed", "denied"])
        self.assertEqual(len(self.q.load()["tasks"][0]["attempts"]), 1)

    def test_invalid_seed_and_symlink_escape_are_rejected(self):
        bad = copy.deepcopy(self.q.load())
        bad["tasks"][0]["dependencies"] = ["B"]
        with self.assertRaisesRegex(QueueError, "cycle"):
            validate(bad)
        with tempfile.TemporaryDirectory() as outside:
            target = Path(outside) / "secret.txt"
            target.write_text("outside")
            (self.root / "escape").symlink_to(target)
            with self.assertRaisesRegex(QueueError, "within queue root"):
                self.q.configure("A", "coordinator", ["escape"])

    def test_changed_dependency_evidence_prevents_descendant_claim(self):
        self.submit()
        self.q.review("A", "reviewer", True, "Independent scope review complete")
        self.configured("B")
        (self.root / "result.json").write_text("dependency output changed")
        with self.assertRaisesRegex(QueueError, "stale"):
            self.q.claim("B", "worker-b")

    def test_done_without_actual_review_is_invalid_schema(self):
        data = self.q.load()
        data["tasks"][0].update(state="done", owner="fake", evidence_refs=[{
            "path": "result.json", "sha256": digest(self.root / "result.json")}])
        with self.assertRaisesRegex(QueueError, "recorded acceptance"):
            validate(data)

    def test_parent_cannot_close_with_unfinished_discovered_child(self):
        data = self.q.load()
        data["tasks"][1]["parent_id"] = "A"
        data["tasks"][1]["dependencies"] = []
        atomic_write(self.path, data)
        self.submit()
        with self.assertRaisesRegex(QueueError, "children"):
            self.q.review("A", "reviewer", True, "Must inspect all child results")

    def child(self, name="A/SCENE/one", parent="A", dependencies=()):
        result = task(name, dependencies)
        result.update(parent_id=parent, role="artifact-agent", outputs=["out/child/result.json"],
                      input_refs=[{"path": "input.txt", "sha256": digest(self.root / "input.txt"),
                                   "selector": {"scene": "one"}}])
        return result

    def import_specs(self, children):
        path = self.root / "children.json"
        path.write_text(json.dumps({"schema_version": 1, "kind": "child_planning_specs", "tasks": children}))
        return self.q.import_children(path, "coordinator", "Bounded reviewed inventory expansion")

    def test_pause_blocks_new_claims_until_aware_deadline(self):
        self.configured()
        self.q.pause("1970-01-01T00:20:00+00:00", "User requested not-before time")
        self.assertTrue(self.q.status()["pause"]["active"])
        self.assertEqual(self.q.status(ready=True), [])
        with self.assertRaisesRegex(QueueError, "paused"):
            self.q.claim("A", "worker")
        self.now[0] = 1200
        self.assertFalse(self.q.status()["pause"]["active"])
        self.assertEqual(self.q.claim("A", "worker")["state"], "leased")

    def test_pause_rejects_naive_or_past_time_and_keeps_active_lease(self):
        self.configured()
        active = self.q.claim("A", "worker")
        before = self.path.read_bytes()
        for timestamp in ("1970-01-01T00:20:00", "1970-01-01T00:00:00+00:00"):
            with self.assertRaises(QueueError):
                self.q.pause(timestamp, "Invalid pause")
        self.assertEqual(before, self.path.read_bytes())
        self.q.pause("1970-01-01T00:20:00+00:00", "Stop new work, not current process")
        self.assertEqual(self.q.load()["tasks"][0]["lease"], active["lease"])
        self.q.checkpoint("A", "worker", active["lease"]["id"], "ready", "Current bounded work ended", [])

    def test_import_children_pending_with_exact_refs_and_no_parent_dependency(self):
        result = self.import_specs([self.child()])
        self.assertEqual(result["child_ids"], ["A/SCENE/one"])
        child = self.q.load()["tasks"][-1]
        self.assertEqual(child["state"], "pending")
        self.assertFalse(child["planning_seed"])
        self.assertEqual(child["input_refs"][0]["selector"], {"scene": "one"})
        self.assertEqual(self.q.claim(child["id"], "worker")["state"], "leased")
        self.assertEqual(self.q.load()["tasks"][0]["state"], "pending")

    def test_import_rejects_duplicate_ids_and_dependency_cycles_atomically(self):
        for specs in ([self.child(), self.child()],
                      [self.child("C", dependencies=["D"]), self.child("D", dependencies=["C"])],
                      [self.child("A")]):
            before = self.path.read_bytes()
            with self.assertRaises(QueueError):
                self.import_specs(specs)
            self.assertEqual(before, self.path.read_bytes())

    def test_import_rejects_missing_parent_parent_dependency_and_forged_execution(self):
        invalid = [self.child(parent="missing"), self.child(dependencies=["A"]),
                   self.child(dependencies=["missing-dependency"])]
        forged = self.child()
        forged["state"] = "done"
        invalid.append(forged)
        for child in invalid:
            before = self.path.read_bytes()
            with self.assertRaises(QueueError):
                self.import_specs([child])
            self.assertEqual(before, self.path.read_bytes())

    def test_import_rejects_stale_refs_and_busy_parent(self):
        child = self.child()
        (self.root / "input.txt").write_text("new bytes")
        with self.assertRaisesRegex(QueueError, "stale"):
            self.import_specs([child])
        self.configured()
        self.q.claim("A", "parent-worker")
        with self.assertRaisesRegex(QueueError, "idle"):
            self.import_specs([self.child()])

    def test_import_rejects_indirect_parent_completion_deadlock(self):
        # B already depends on A. A child waiting for B would prevent A closing.
        before = self.path.read_bytes()
        with self.assertRaisesRegex(QueueError, "closure cycle"):
            self.import_specs([self.child(dependencies=["B"])])
        self.assertEqual(before, self.path.read_bytes())

    def test_import_requires_explicit_scope_and_exact_input_hashes(self):
        for field in ("input_refs", "allowed_paths", "outputs"):
            child = self.child()
            child[field] = []
            before = self.path.read_bytes()
            with self.assertRaisesRegex(QueueError, "requires nonempty"):
                self.import_specs([child])
            self.assertEqual(before, self.path.read_bytes())

    def test_import_batch_limit_prevents_unbounded_expansion(self):
        before = self.path.read_bytes()
        with self.assertRaisesRegex(QueueError, "bounded to 1000"):
            self.import_specs([self.child(str(i)) for i in range(1001)])
        self.assertEqual(before, self.path.read_bytes())

    def test_import_hashes_repeated_resolved_input_only_once(self):
        # Two selectors and an in-root symlink share exact underlying bytes.
        (self.root / "input-alias.txt").symlink_to(self.root / "input.txt")
        children = [self.child("C"), self.child("D"), self.child("E")]
        children[-1]["input_refs"][0]["path"] = "input-alias.txt"
        with patch("recon_queue.digest", wraps=digest) as observed:
            result = self.import_specs(children)
        self.assertEqual(observed.call_count, 1)
        self.assertEqual(result["unique_input_files_hashed"], 1)

    def test_import_conflicting_hashes_for_same_resolved_path_is_atomic(self):
        children = [self.child("C"), self.child("D")]
        children[1]["input_refs"][0]["sha256"] = "0" * 64
        before = self.path.read_bytes()
        with self.assertRaisesRegex(QueueError, "conflicting expected SHA256"):
            self.import_specs(children)
        self.assertEqual(before, self.path.read_bytes())

    def test_import_rejects_input_mutation_during_later_hash(self):
        child = self.child()
        child["input_refs"].append({"path": "result.json", "sha256": digest(self.root / "result.json")})
        before = self.path.read_bytes()

        def hash_and_modify_earlier(path):
            actual = digest(path)
            if path.name == "result.json":
                (self.root / "input.txt").write_text("mutation after input hash, before import commit")
            return actual

        with patch("recon_queue.digest", side_effect=hash_and_modify_earlier):
            with self.assertRaisesRegex(QueueError, "input changed during import"):
                self.import_specs([child])
        self.assertEqual(before, self.path.read_bytes())

    def test_imported_child_claim_is_exclusive_between_processes(self):
        name = "A/SCENE/one"
        self.import_specs([self.child(name)])
        ctx = multiprocessing.get_context("fork")
        start, results = ctx.Event(), ctx.Queue()
        workers = [ctx.Process(target=concurrent_claim,
                               args=(str(self.path), str(i), start, results, name)) for i in range(2)]
        for worker in workers:
            worker.start()
        start.set()
        outcomes = [results.get(timeout=10) for _ in workers]
        for worker in workers:
            worker.join(10)
            self.assertEqual(worker.exitcode, 0)
        self.assertEqual(sorted(outcomes), ["claimed", "denied"])
        self.assertEqual(len(self.q.load()["tasks"][-1]["attempts"]), 1)

    def test_independent_child_review_required_before_parent_can_close(self):
        name = "A/SCENE/one"
        self.import_specs([self.child(name)])
        self.submit("A", "parent-worker")
        with self.assertRaisesRegex(QueueError, "children"):
            self.q.review("A", "parent-reviewer", True, "Parent must await every child")
        child = self.q.claim(name, "child-worker")
        self.q.checkpoint(name, "child-worker", child["lease"]["id"], "evidence_ready",
                          "Bounded child contract ready for review", ["result.json"])
        with self.assertRaisesRegex(QueueError, "independent"):
            self.q.review(name, "child-worker", True, "Self-review prohibited")
        self.q.review(name, "child-reviewer", True, "Verified child contract against evidence")
        self.assertEqual(self.q.review("A", "parent-reviewer", True,
                                      "Reconciled all discovered child acceptance")["state"], "done")
        with self.assertRaisesRegex(QueueError, "idle"):
            self.import_specs([self.child("A/SCENE/new")])


if __name__ == "__main__":
    unittest.main()
