#!/usr/bin/env python3
"""Local, locked reconstruction task queue. Does not execute agents or analysis tools."""
import argparse
from collections import Counter
from contextlib import contextmanager
import copy
from datetime import datetime
import fcntl
import hashlib
import json
import math
import os
from pathlib import Path
import tempfile
import time
import uuid

STATES = {"pending", "ready", "leased", "running", "evidence_ready", "review", "done",
          "failed_retryable", "blocked_external", "needs_input", "stale", "rejected"}
CLAIMABLE = {"pending", "ready", "failed_retryable", "rejected", "stale"}
ACTIVE = {"leased", "running"}


class QueueError(ValueError):
    pass


def digest(path):
    h = hashlib.sha256()
    with path.open("rb") as source:
        for chunk in iter(lambda: source.read(1024 * 1024), b""):
            h.update(chunk)
    return h.hexdigest()


def relative_path(value):
    p = Path(value)
    if not value or p.is_absolute() or ".." in p.parts:
        raise QueueError("paths must be nonempty and relative without '..'")
    return value


def aware_timestamp(value):
    if not isinstance(value, str):
        raise QueueError("pause time must be an ISO timestamp with timezone")
    instant = datetime.fromisoformat(value.replace("Z", "+00:00"))
    if instant.tzinfo is None or instant.utcoffset() is None:
        raise QueueError("pause time requires an explicit timezone")
    return instant.timestamp()


def validate(data):
    if not isinstance(data, dict) or data.get("schema_version") != 1:
        raise QueueError("unsupported queue/seed schema")
    tasks = data.get("tasks")
    if not isinstance(tasks, list) or not tasks:
        raise QueueError("nonempty tasks array required")
    ids = set()
    for task in tasks:
        if not isinstance(task, dict) or not isinstance(task.get("id"), str) or not task["id"]:
            raise QueueError("task id required")
        if task["id"] in ids:
            raise QueueError("duplicate task id")
        ids.add(task["id"])
        if task.get("state") not in STATES or not isinstance(task.get("dependencies"), list):
            raise QueueError("invalid task state/dependencies")
        if not isinstance(task.get("acceptance"), str) or not task["acceptance"].strip():
            raise QueueError("explicit acceptance required")
        for key in ("input_refs", "evidence_refs", "allowed_paths", "resource_locks", "attempts"):
            if not isinstance(task.get(key), list):
                raise QueueError(f"list required: {key}")
        for path in task["allowed_paths"]:
            if not isinstance(path, str):
                raise QueueError("allowed path must be a string")
            relative_path(path)
        if any(not isinstance(r, str) or not r.strip() for r in task["resource_locks"]):
            raise QueueError("resource names must be nonempty strings")
        if any(not isinstance(a, dict) or not isinstance(a.get("owner"), str) or not a["owner"]
               for a in task["attempts"]):
            raise QueueError("attempt owner required")
        for ref in task["input_refs"] + task["evidence_refs"]:
            if not isinstance(ref, dict) or not isinstance(ref.get("path"), str):
                raise QueueError("invalid evidence/input reference")
            relative_path(ref["path"])
            sha = ref.get("sha256")
            if not isinstance(sha, str) or len(sha) != 64 or any(c not in "0123456789abcdef" for c in sha):
                raise QueueError("reference SHA256 required")
        if task["state"] in ACTIVE:
            lease = task.get("lease")
            if not isinstance(lease, dict) or not lease.get("id") or not task.get("owner"):
                raise QueueError("active task requires owner/lease")
            for field in ("expires_at", "heartbeat_at", "ttl"):
                if not isinstance(lease.get(field), (int, float)) or not math.isfinite(lease[field]):
                    raise QueueError("lease times must be finite numbers")
        elif task.get("lease") is not None:
            raise QueueError("inactive task must not retain a lease")
        if task["state"] in {"review", "done"} and (not task["evidence_refs"] or not task.get("owner")):
            raise QueueError("submitted/completed tasks require evidence and owner")
        if task["state"] == "done":
            review = task.get("review")
            authors = {a["owner"] for a in task["attempts"]} | {task.get("owner")}
            if not isinstance(review, dict) or review.get("verdict") != "accept" or not review.get("note"):
                raise QueueError("done requires recorded acceptance")
            if not review.get("reviewer") or review["reviewer"] in authors:
                raise QueueError("done requires independent reviewer")
    by_id = {t["id"]: t for t in tasks}
    visiting, visited = set(), set()

    def visit(task_id):
        if task_id in visiting:
            raise QueueError("dependency cycle")
        if task_id in visited:
            return
        visiting.add(task_id)
        for dep in by_id[task_id]["dependencies"]:
            if not isinstance(dep, str) or dep not in ids:
                raise QueueError("unknown dependency")
            visit(dep)
        visiting.remove(task_id)
        visited.add(task_id)

    for task_id in ids:
        visit(task_id)
    for task in tasks:
        ancestors = set()
        parent = task.get("parent_id")
        while parent is not None:
            if parent not in ids:
                raise QueueError("unknown parent")
            if parent == task["id"] or parent in ancestors:
                raise QueueError("parent cycle")
            ancestors.add(parent)
            parent = by_id[parent].get("parent_id")
        if ancestors.intersection(task["dependencies"]):
            raise QueueError("child must not depend on parent/ancestor completion")
        if task["state"] == "done" and any(t.get("parent_id") == task["id"] and t["state"] != "done" for t in tasks):
            raise QueueError("done parent has unfinished children")
    # Parent closure is an implicit dependency on every discovered child.
    # Include those edges to reject deadlocks hidden by separate parent/dependency graphs.
    closure_visiting, closure_visited = set(), set()
    children = {}
    for task in tasks:
        children.setdefault(task.get("parent_id"), []).append(task["id"])

    def visit_closure(task_id):
        if task_id in closure_visiting:
            raise QueueError("dependency/parent closure cycle")
        if task_id in closure_visited:
            return
        closure_visiting.add(task_id)
        for dep in by_id[task_id]["dependencies"] + children.get(task_id, []):
            visit_closure(dep)
        closure_visiting.remove(task_id)
        closure_visited.add(task_id)

    for task_id in ids:
        visit_closure(task_id)
    if "control" in data:
        control = data["control"]
        if not isinstance(control, dict) or not control.get("note") or not control.get("actor"):
            raise QueueError("invalid queue scheduling control")
        if aware_timestamp(control.get("not_before")) != control.get("not_before_epoch"):
            raise QueueError("queue scheduling timestamp mismatch")
    return data


def atomic_write(path, data):
    path.parent.mkdir(parents=True, exist_ok=True)
    fd, temp_name = tempfile.mkstemp(prefix="." + path.name + ".", dir=path.parent)
    temp = Path(temp_name)
    try:
        with os.fdopen(fd, "w", encoding="utf-8") as target:
            json.dump(data, target, ensure_ascii=False, indent=2, allow_nan=False)
            target.write("\n")
            target.flush()
            os.fsync(target.fileno())
        os.replace(temp, path)
        dir_fd = os.open(path.parent, os.O_RDONLY | os.O_DIRECTORY)
        try:
            os.fsync(dir_fd)
        finally:
            os.close(dir_fd)
    finally:
        temp.unlink(missing_ok=True)


class Queue:
    def __init__(self, path, clock=time.time):
        self.path = Path(path).resolve()
        self.clock = clock

    @contextmanager
    def locked(self):
        self.path.parent.mkdir(parents=True, exist_ok=True)
        with self.path.with_suffix(self.path.suffix + ".lock").open("a+") as lock:
            fcntl.flock(lock, fcntl.LOCK_EX)
            try:
                yield
            finally:
                fcntl.flock(lock, fcntl.LOCK_UN)

    def init(self, seed, root):
        with self.locked():
            if self.path.exists():
                raise QueueError("queue already exists; refusing overwrite")
            seed = Path(seed).resolve()
            data = validate(json.loads(seed.read_text()))
            if data.get("kind") != "planning_seed_not_live_execution_state":
                raise QueueError("explicit planning seed required")
            if any(t["state"] != "pending" or t.get("lease") for t in data["tasks"]):
                raise QueueError("seed tasks must all be pending without leases")
            root = Path(root).resolve()
            source = root / relative_path(data["source_doc"])
            if digest(source) != data.get("source_doc_sha256"):
                raise QueueError("seed source document hash mismatch")
            data.update(kind="local_live_queue", root=str(root), revision=0,
                        seed_sha256=digest(seed), history=[])
            atomic_write(self.path, data)
            return {"tasks": len(data["tasks"]), "queue": str(self.path)}

    def load(self):
        data = validate(json.loads(self.path.read_text()))
        if data.get("kind") != "local_live_queue" or not Path(data.get("root", "")).is_absolute():
            raise QueueError("not an initialized live queue")
        return data

    def task(self, data, task_id):
        for task in data["tasks"]:
            if task["id"] == task_id:
                return task
        raise QueueError("unknown task id")

    def file_ref(self, data, value):
        relative_path(value)
        root = Path(data["root"])
        path = (root / value).resolve()
        if not path.is_relative_to(root) or not path.is_file():
            raise QueueError("reference must resolve to a regular file within queue root")
        return {"path": value, "sha256": digest(path)}

    def relocate(self, root, actor, note):
        """Move a quiescent queue, preserving approvals only after revalidation."""
        if not actor.strip() or not note.strip():
            raise QueueError("relocation requires actor and rationale")
        with self.locked():
            data = self.load()
            if any(t.get("lease") for t in data["tasks"]):
                raise QueueError("relocation refuses outstanding leases; recover idle workers first")
            previous = data["root"]
            destination = Path(root).resolve()
            if not destination.is_dir():
                raise QueueError("relocation root must be a directory")
            data["root"] = str(destination)
            refs = [{"path": data["source_doc"], "sha256": data["source_doc_sha256"]}]
            for task in data["tasks"]:
                if task["state"] in {"done", "review"}:
                    refs.extend(task["input_refs"] + task["evidence_refs"])
            unique = {(r["path"], r["sha256"]): r for r in refs}
            self.check_refs(data, list(unique.values()))
            data["revision"] += 1
            data["history"].append({"revision": data["revision"], "action": "relocate",
                                    "actor": actor, "at": self.clock(), "note": note,
                                    "previous_root": previous, "root": str(destination),
                                    "verified_refs": len(unique)})
            validate(data)
            atomic_write(self.path, data)
            return {"root": str(destination), "previous_root": previous,
                    "verified_refs": len(unique), "revision": data["revision"]}

    def check_refs(self, data, refs):
        for ref in refs:
            if self.file_ref(data, ref["path"])["sha256"] != ref["sha256"]:
                raise QueueError("stale reference: " + ref["path"])

    def pause_info(self, data):
        control = data.get("control")
        return {**control, "active": self.clock() < control["not_before_epoch"]} if control else None

    def pause(self, until, note, actor="coordinator"):
        timestamp = aware_timestamp(until)
        if timestamp <= self.clock() or not note.strip() or not actor.strip():
            raise QueueError("pause requires a future timestamp, actor and rationale")
        with self.locked():
            data = self.load()
            data["control"] = {"not_before": until, "not_before_epoch": timestamp,
                               "note": note, "actor": actor}
            validate(data)
            data["revision"] += 1
            data["history"].append({"revision": data["revision"], "action": "pause",
                                    "actor": actor, "at": self.clock(), "control": data["control"]})
            atomic_write(self.path, data)
            return self.pause_info(data)

    def import_children(self, manifest, actor, note):
        if not actor.strip() or not note.strip():
            raise QueueError("child import requires actor and rationale")
        manifest = Path(manifest).resolve()
        raw = manifest.read_bytes()
        incoming = json.loads(raw)
        if (not isinstance(incoming, dict) or incoming.get("schema_version") != 1
                or incoming.get("kind") != "child_planning_specs"
                or not isinstance(incoming.get("tasks"), list) or not incoming["tasks"]):
            raise QueueError("nonempty child_planning_specs manifest required")
        if len(incoming["tasks"]) > 1000:
            raise QueueError("child import is bounded to 1000 tasks per manifest")
        children = copy.deepcopy(incoming["tasks"])
        with self.locked():
            data = self.load()
            existing = {t["id"]: t for t in data["tasks"]}
            for child in children:
                if not isinstance(child, dict):
                    raise QueueError("child task must be an object")
                parent = existing.get(child.get("parent_id"))
                if not parent:
                    raise QueueError("child parent must already exist in live queue")
                if parent["state"] in ACTIVE | {"review", "evidence_ready", "done"} or parent.get("lease"):
                    raise QueueError("parent must be idle and incomplete before scope expansion")
                if child.get("state") != "pending" or any(child.get(k) for k in ("owner", "lease", "review", "attempts", "evidence_refs")):
                    raise QueueError("new children must be pending without execution or review history")
                for field in ("input_refs", "allowed_paths", "outputs"):
                    if not isinstance(child.get(field), list) or not child[field]:
                        raise QueueError("child requires nonempty exact " + field)
                if not isinstance(child.get("role"), str) or not child["role"].strip():
                    raise QueueError("child role required")
                for output in child["outputs"]:
                    if not isinstance(output, str):
                        raise QueueError("child output path must be a string")
                    relative_path(output)
                child["planning_seed"] = False
            data["tasks"].extend(children)
            validate(data)
            # Hash each contained resolved input once for this locked import only.
            # No stat-based digest is persisted or reused between operations.
            root = Path(data["root"])
            verified_inputs = {}
            requested_paths = {}

            def fingerprint(path):
                st = path.stat()
                return (st.st_dev, st.st_ino, st.st_size, st.st_mtime_ns, st.st_ctime_ns)

            for child in children:
                for ref in child["input_refs"]:
                    path = (root / relative_path(ref["path"])).resolve()
                    if not path.is_relative_to(root) or not path.is_file():
                        raise QueueError("reference must resolve to a regular file within queue root")
                    requested_paths[ref["path"]] = path
                    prior = verified_inputs.get(path)
                    if prior is not None:
                        if prior["sha256"] != ref["sha256"]:
                            raise QueueError("conflicting expected SHA256 for one input: " + ref["path"])
                        continue
                    before = fingerprint(path)
                    actual = digest(path)
                    if fingerprint(path) != before:
                        raise QueueError("input changed while hashing: " + ref["path"])
                    if actual != ref["sha256"]:
                        raise QueueError("stale reference: " + ref["path"])
                    verified_inputs[path] = {"sha256": actual, "fingerprint": before}
            # A later input read must not conceal an earlier input changing.
            for relative, resolved in requested_paths.items():
                if ((root / relative).resolve() != resolved
                        or fingerprint(resolved) != verified_inputs[resolved]["fingerprint"]):
                    raise QueueError("input changed during import: " + relative)
            data["revision"] += 1
            entry = {"revision": data["revision"], "action": "import_children", "actor": actor,
                     "at": self.clock(), "note": note,
                     "manifest_path": str(manifest), "manifest_sha256": hashlib.sha256(raw).hexdigest(),
                     "unique_input_files_hashed": len(verified_inputs),
                     "child_ids": [c["id"] for c in children]}
            data["history"].append(entry)
            atomic_write(self.path, data)
            return entry

    def blockers(self, data, task):
        states = {t["id"]: t["state"] for t in data["tasks"]}
        return [dep for dep in task["dependencies"] if states[dep] != "done"]

    def check_dependency_evidence(self, data, task, visited=None):
        visited = set() if visited is None else visited
        for dep_id in task["dependencies"]:
            if dep_id in visited:
                continue
            visited.add(dep_id)
            dep = self.task(data, dep_id)
            if dep["state"] != "done":
                raise QueueError("dependency chain no longer done: " + dep_id)
            self.check_refs(data, dep["input_refs"] + dep["evidence_refs"])
            self.check_dependency_evidence(data, dep, visited)

    def owned(self, task, owner, lease_id):
        if task.get("owner") != owner or not task.get("lease") or task["lease"]["id"] != lease_id:
            raise QueueError("owner/lease token mismatch")
        if task["lease"]["expires_at"] <= self.clock():
            raise QueueError("lease expired; explicit idle recovery required")

    def mutate(self, action, task_id, actor, operation):
        if not actor or not actor.strip():
            raise QueueError("actor required")
        with self.locked():
            data = self.load()
            task = self.task(data, task_id)
            result = operation(data, task)
            validate(data)
            data["revision"] += 1
            data["history"].append({"revision": data["revision"], "action": action,
                                    "task": task_id, "actor": actor, "at": self.clock()})
            atomic_write(self.path, data)
            return copy.deepcopy(result if result is not None else task)

    def configure(self, task_id, actor, inputs, paths=None, resources=None):
        def operation(data, task):
            if task["state"] not in CLAIMABLE | {"blocked_external", "needs_input"} or task.get("lease"):
                raise QueueError("task cannot be configured while active or done")
            if not inputs:
                raise QueueError("at least one exact input required")
            task["input_refs"] = [self.file_ref(data, p) for p in inputs]
            if paths is not None:
                task["allowed_paths"] = [relative_path(p) for p in paths]
            if not task["allowed_paths"]:
                raise QueueError("allowed paths required")
            if resources is not None:
                if any(not isinstance(r, str) or not r.strip() for r in resources):
                    raise QueueError("resource names must be nonempty strings")
                task["resource_locks"] = sorted(set(resources))
            task["planning_seed"] = False
            task["state"] = "pending"
        return self.mutate("configure", task_id, actor, operation)

    def claim(self, task_id, owner, ttl=600):
        if not 1 <= ttl <= 86400:
            raise QueueError("lease seconds must be 1..86400")
        def operation(data, task):
            if (pause := self.pause_info(data)) and pause["active"]:
                raise QueueError("queue paused until " + pause["not_before"])
            if task["state"] not in CLAIMABLE or task.get("lease"):
                raise QueueError("task not claimable; expired leases must be recovered explicitly")
            if task.get("planning_seed", True) or not task["input_refs"]:
                raise QueueError("configure exact inputs and scope before claim")
            if self.blockers(data, task):
                raise QueueError("dependencies not done")
            self.check_dependency_evidence(data, task)
            self.check_refs(data, task["input_refs"])
            resources = set(task["resource_locks"])
            for other in data["tasks"]:
                if other.get("lease") and resources.intersection(other["resource_locks"]):
                    raise QueueError("exclusive resource held by " + other["id"])
            now = self.clock()
            task.update(state="leased", owner=owner, review=None, evidence_refs=[],
                        lease={"id": uuid.uuid4().hex, "expires_at": now + ttl,
                               "heartbeat_at": now, "ttl": ttl})
            task["attempts"].append({"id": uuid.uuid4().hex, "owner": owner,
                                     "started_at": now, "lease_id": task["lease"]["id"]})
        return self.mutate("claim", task_id, owner, operation)

    def heartbeat(self, task_id, owner, lease_id, start=False):
        def operation(data, task):
            self.owned(task, owner, lease_id)
            if task["state"] not in {"leased", "running"}:
                raise QueueError("heartbeat/start only for leased or running task")
            now = self.clock()
            task["lease"].update(heartbeat_at=now, expires_at=now + task["lease"]["ttl"])
            if start:
                task["state"] = "running"
        return self.mutate("start" if start else "heartbeat", task_id, owner, operation)

    def checkpoint(self, task_id, owner, lease_id, state, note, evidence):
        if state not in {"running", "ready", "evidence_ready", "failed_retryable", "blocked_external", "needs_input"}:
            raise QueueError("invalid checkpoint state")
        if not note.strip():
            raise QueueError("checkpoint note/next action required")
        def operation(data, task):
            self.owned(task, owner, lease_id)
            if task["state"] not in {"leased", "running"}:
                raise QueueError("checkpoint only from leased/running")
            self.check_refs(data, task["input_refs"])
            refs = [self.file_ref(data, p) for p in evidence]
            if state == "evidence_ready" and not refs:
                raise QueueError("evidence_ready requires output references")
            if state == "evidence_ready":
                expected = set(task.get("outputs", []))
                supplied = {r["path"] for r in refs}
                if expected and not expected.issubset(supplied):
                    raise QueueError("evidence_ready requires every declared output, including the full report")
                report = task.get("outputs", [])[-1] if task.get("outputs") else None
                if report and not Path(data["root"], report).is_file():
                    raise QueueError("full report missing")
            task.update(state=state, evidence_refs=refs, next_action=note)
            task["attempts"][-1].update(checkpoint_at=self.clock(), state=state, note=note,
                                        evidence_refs=copy.deepcopy(refs))
            if state != "running":
                task["lease"] = None
                if state == "evidence_ready":
                    task["state"] = "review"
        return self.mutate("checkpoint", task_id, owner, operation)

    def review(self, task_id, reviewer, accept, note):
        if not note.strip():
            raise QueueError("review rationale required")
        def operation(data, task):
            if task["state"] != "review" or task.get("lease"):
                raise QueueError("task not awaiting review")
            authors = {a["owner"] for a in task["attempts"]}
            if reviewer in authors or reviewer == task.get("owner"):
                raise QueueError("independent reviewer required")
            if accept and self.blockers(data, task):
                raise QueueError("dependencies no longer satisfied")
            if accept:
                self.check_dependency_evidence(data, task)
            if accept and any(t.get("parent_id") == task_id and t["state"] != "done" for t in data["tasks"]):
                raise QueueError("parent still has unfinished discovered children")
            if accept:
                self.check_refs(data, task["input_refs"] + task["evidence_refs"])
            if not task["evidence_refs"]:
                raise QueueError("review requires evidence")
            task["review"] = {"reviewer": reviewer, "verdict": "accept" if accept else "reject",
                              "note": note, "at": self.clock(),
                              "evidence_refs": copy.deepcopy(task["evidence_refs"])}
            task["state"] = "done" if accept else "rejected"
            task["next_action"] = note
        return self.mutate("review", task_id, reviewer, operation)

    def recover(self, task_id, actor, note, confirm_idle=False):
        if not confirm_idle or not note.strip():
            raise QueueError("recovery requires explicit idle attestation and rationale")
        def operation(data, task):
            lease = task.get("lease")
            if not lease or lease["expires_at"] > self.clock():
                raise QueueError("only expired leases can be recovered")
            task["attempts"][-1].update(recovered_at=self.clock(), recovery_note=note,
                                        recovery_actor=actor)
            task.update(state="stale", lease=None, next_action=note)
        return self.mutate("recover", task_id, actor, operation)

    def status(self, ready=False):
        with self.locked():
            data = self.load()
            if ready:
                if (pause := self.pause_info(data)) and pause["active"]:
                    return []
                return [{"id": t["id"], "role": t.get("role"), "configured": not t.get("planning_seed", True)}
                        for t in data["tasks"] if t["state"] in CLAIMABLE and not self.blockers(data, t)]
            return {"revision": data["revision"], "counts": dict(Counter(t["state"] for t in data["tasks"])),
                    "pause": self.pause_info(data),
                    "expired_leases": [t["id"] for t in data["tasks"]
                                       if t.get("lease") and t["lease"]["expires_at"] <= self.clock()]}

    def prepare(self, task_id):
        """Token-efficient mandatory task brief; validate refs before exposing scope."""
        with self.locked():
            data = self.load()
            task = self.task(data, task_id)
            blockers = self.blockers(data, task)
            refs = task["input_refs"] + task["evidence_refs"]
            checked = []
            for ref in refs:
                actual = self.file_ref(data, ref["path"])
                if actual["sha256"] != ref["sha256"]:
                    raise QueueError("stale reference: " + ref["path"])
                checked.append({"path": ref["path"], "sha256": actual["sha256"]})
            deps = []
            for dep in task["dependencies"]:
                parent = self.task(data, dep)
                deps.append({"id": dep, "state": parent["state"],
                             "summary": parent.get("next_action", "")})
            return {"id": task_id, "state": task["state"], "title": task["title"],
                    "objective": task.get("input_and_steps", ""),
                    "acceptance": task["acceptance"], "blockers": blockers,
                    "dependencies": deps, "verified_inputs": checked,
                    "outputs": task["outputs"], "next_action": task.get("next_action", ""),
                    "full_report_path": task["outputs"][-1] if task["outputs"] else None,
                    "summary_only": True}


def main(argv=None):
    p = argparse.ArgumentParser(description=__doc__)
    p.add_argument("--queue", type=Path, default=Path("reports/recon/tasks.json"))
    commands = p.add_subparsers(dest="command", required=True)
    init = commands.add_parser("init")
    init.add_argument("--seed", type=Path, required=True)
    init.add_argument("--root", type=Path, default=Path.cwd())
    commands.add_parser("status")
    commands.add_parser("ready")
    prepare = commands.add_parser("prepare", help="mandatory hash-checked compact task brief")
    prepare.add_argument("task")
    relocate = commands.add_parser("relocate")
    relocate.add_argument("--root", type=Path, required=True)
    relocate.add_argument("--actor", required=True)
    relocate.add_argument("--note", required=True)
    pause = commands.add_parser("pause")
    pause.add_argument("--until", required=True)
    pause.add_argument("--note", required=True)
    pause.add_argument("--actor", default="coordinator")
    children = commands.add_parser("import-children")
    children.add_argument("--manifest", type=Path, required=True)
    children.add_argument("--actor", required=True)
    children.add_argument("--note", required=True)
    for command in ("configure", "claim", "start", "heartbeat", "checkpoint", "review", "recover"):
        sub = commands.add_parser(command)
        sub.add_argument("task")
        sub.add_argument("--actor", required=True)
        if command == "configure":
            sub.add_argument("--input", action="append", required=True)
            sub.add_argument("--allowed-path", action="append")
            sub.add_argument("--resource", action="append")
        if command == "claim":
            sub.add_argument("--seconds", type=int, default=600)
        if command in ("start", "heartbeat", "checkpoint"):
            sub.add_argument("--lease-id", required=True)
        if command in ("checkpoint", "review", "recover"):
            sub.add_argument("--note", required=True)
        if command == "checkpoint":
            sub.add_argument("--state", required=True)
            sub.add_argument("--evidence", action="append", default=[])
        if command == "review":
            sub.add_argument("--verdict", choices=("accept", "reject"), required=True)
        if command == "recover":
            sub.add_argument("--confirm-idle", action="store_true")
    a = p.parse_args(argv)
    q = Queue(a.queue)
    try:
        if a.command == "init":
            result = q.init(a.seed, a.root)
        elif a.command in ("ready", "status"):
            result = q.status(ready=a.command == "ready")
        elif a.command == "prepare":
            result = q.prepare(a.task)
        elif a.command == "pause":
            result = q.pause(a.until, a.note, a.actor)
        elif a.command == "relocate":
            result = q.relocate(a.root, a.actor, a.note)
        elif a.command == "import-children":
            result = q.import_children(a.manifest, a.actor, a.note)
        elif a.command == "configure":
            result = q.configure(a.task, a.actor, a.input, a.allowed_path, a.resource)
        elif a.command == "claim":
            result = q.claim(a.task, a.actor, a.seconds)
        elif a.command in ("start", "heartbeat"):
            result = q.heartbeat(a.task, a.actor, a.lease_id, start=a.command == "start")
        elif a.command == "checkpoint":
            result = q.checkpoint(a.task, a.actor, a.lease_id, a.state, a.note, a.evidence)
        elif a.command == "review":
            result = q.review(a.task, a.actor, a.verdict == "accept", a.note)
        else:
            result = q.recover(a.task, a.actor, a.note, a.confirm_idle)
        print(json.dumps(result, ensure_ascii=False, indent=2))
        return 0
    except (OSError, ValueError, KeyError, TypeError) as error:
        print(json.dumps({"error": str(error)}, ensure_ascii=False))
        return 2


if __name__ == "__main__":
    raise SystemExit(main())
