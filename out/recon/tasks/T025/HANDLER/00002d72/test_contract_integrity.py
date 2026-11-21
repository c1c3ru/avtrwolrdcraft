#!/usr/bin/env python3
"""Integrity checks for this partial, evidence-only RE checkpoint.

These assertions validate identities, pinned inputs and honest partial status;
they do not establish helper semantics or replace native disassembly review.
"""
import hashlib
import json
from pathlib import Path

ROOT = Path(__file__).resolve().parents[6]
TASK = ROOT / "out/recon/tasks/T025/HANDLER/00002d72"


def test_pinned_inputs_and_method_identity():
    contract = json.loads((TASK / "method-contract.json").read_text())
    method = contract["method"]
    assert method["token"] == "0x06002d73"
    assert method["method_definition_index"] == 11634
    assert method["vaddr"] == "0x1e29da8"
    expected = {
        "out/recon/il2cpp/libil2cpp.so": "b63661fa60c23ebef1c2da4bb5288ad787eb3da36b22d4bdf285401f1643d728",
        "out/recon/il2cpp/global-metadata.dat": "1ea14cf5829d5c31e5e967b1608b5701020ab0d24bd4ab69d9f1e2b243467bc6",
        "out/recon/il2cpp/metadata_methods.jsonl": "7d6a73ceae5f67589766b8bb7878caed08eb56d1619b1cd55302135482b20eeb",
        "out/recon/method-extents.jsonl": "6d336b3c67b4e3fda688018eb88854b99fd88cc7d08cd6cdca2cefa8af64c717",
    }
    for relative, digest in expected.items():
        assert hashlib.sha256((ROOT / relative).read_bytes()).hexdigest() == digest


def test_thunk_and_helper_are_separate_and_partial():
    contract = json.loads((TASK / "method-contract.json").read_text())
    flow = json.loads((TASK / "control-flow.json").read_text())
    result = json.loads((TASK / "result.json").read_text())
    assert contract["method"]["extent"]["bytes"] == 4
    assert contract["method"]["extent"]["target"] == "0x1e299b4"
    assert flow["extent"]["bytes"] == 4
    assert flow["blocks"][1]["id"] == "H0"
    assert result["state"] == "ready"
    assert result["semantic_completion"] is False
    assert result["acceptance_gaps"]


def test_unknowns_are_valid_jsonl_and_blocking_gaps_remain():
    rows = [json.loads(line) for line in (TASK / "unknowns.jsonl").read_text().splitlines()]
    assert len(rows) >= 5
    assert {row["severity"] for row in rows} >= {"blocking", "nonblocking"}
    assert any(row["topic"] == "helper semantic body" for row in rows)


if __name__ == "__main__":
    for test in (test_pinned_inputs_and_method_identity,
                 test_thunk_and_helper_are_separate_and_partial,
                 test_unknowns_are_valid_jsonl_and_blocking_gaps_remain):
        test()
    print("3 checkpoint integrity checks passed (semantic recovery remains partial)")
