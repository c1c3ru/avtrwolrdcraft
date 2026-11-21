#!/usr/bin/env python3
"""Structural checks only; they do not prove reconstructed game semantics."""
import hashlib
import json
from pathlib import Path

ROOT = Path(__file__).resolve().parents[6]
TASK = ROOT / "out/recon/tasks/T025/HANDLER/000032a8"


def test_inputs_and_method_identity():
    c = json.loads((TASK / "method-contract.json").read_text())
    m = c["method"]
    assert (m["token"], m["method_definition_index"], m["vaddr"]) == (
        "0x060032a9", 12968, "0x1e64abc")
    expected = {
        "out/recon/il2cpp/libil2cpp.so": "b63661fa60c23ebef1c2da4bb5288ad787eb3da36b22d4bdf285401f1643d728",
        "out/recon/il2cpp/global-metadata.dat": "1ea14cf5829d5c31e5e967b1608b5701020ab0d24bd4ab69d9f1e2b243467bc6",
        "out/recon/il2cpp/metadata_methods.jsonl": "7d6a73ceae5f67589766b8bb7878caed08eb56d1619b1cd55302135482b20eeb",
        "out/recon/method-extents.jsonl": "6d336b3c67b4e3fda688018eb88854b99fd88cc7d08cd6cdca2cefa8af64c717",
    }
    for name, digest in expected.items():
        assert hashlib.sha256((ROOT / name).read_bytes()).hexdigest() == digest


def test_instruction_evidence_and_partial_status():
    flow = json.loads((TASK / "control-flow.json").read_text())
    result = json.loads((TASK / "result.json").read_text())
    asm = (TASK / "handler.asm.txt").read_text()
    assert flow["extent"]["bytes"] == 208
    assert "1e64b48  bl     #0x3cd61fc" in asm
    assert "1e64b60  bl     #0x232b9ac" in asm
    assert "1e64af0  cbz    w8, #0x1e64b74" in asm
    assert result["semantic_completion"] is False
    assert result["state"] == "ready"


def test_unknowns_and_callee_boundary_remain_explicit():
    rows = [json.loads(x) for x in (TASK / "unknowns.jsonl").read_text().splitlines()]
    c = json.loads((TASK / "method-contract.json").read_text())
    assert len(rows) >= 5
    assert any(x["topic"] == "DestroyLevelItem semantics" for x in rows)
    assert c["callee_boundary"]["extent_bytes"] == 1512
    assert "semantic recovery incomplete" in c["callee_boundary"]["status"]


if __name__ == "__main__":
    for test in (test_inputs_and_method_identity,
                 test_instruction_evidence_and_partial_status,
                 test_unknowns_and_callee_boundary_remain_explicit):
        test()
    print("3 structural checks passed; semantic recovery remains partial")
