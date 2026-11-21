import hashlib
import json
from pathlib import Path

ROOT = Path(__file__).resolve().parent
REPO = ROOT.parents[5]

def test_handler_identity_and_extent():
    contract = json.loads((ROOT / "method-contract.json").read_text())
    cfg = json.loads((ROOT / "control-flow.json").read_text())
    method = contract["method"]
    assert method["token"] == "0x06003cd2"
    assert method["vaddr"] == "0x1f04f28"
    assert method["extent"]["bytes"] == 32
    assert cfg["extent"]["end_exclusive"] == "0x1f04f48"
    assert cfg["extent"]["instruction_count"] == 8
    text = (ROOT / "handler.asm.txt").read_text()
    assert "cbz    w8, #0x1f04f40" in text
    assert "bl     #0x1f04f48" in text
    assert text.rstrip().endswith("ret")

def test_cfg_gate_and_open_edges():
    cfg = json.loads((ROOT / "control-flow.json").read_text())
    edges = [edge for block in cfg["blocks"] for edge in block.get("edges", [])]
    assert {edge["condition"] for edge in edges} >= {"_isInsideSlide == 0", "_isInsideSlide != 0"}
    assert any(call["target"] == "0x1f04f48" for call in cfg["call_edges"])
    unknowns = [json.loads(line) for line in (ROOT / "unknowns.jsonl").read_text().splitlines()]
    assert len(unknowns) >= 5 and all(item["status"] == "open" for item in unknowns)
    result = json.loads((ROOT / "result.json").read_text())
    assert result["state"] == "ready" and result["semantic_completion"] is False

def test_evidence_hashes_and_artifact_presence():
    contract = json.loads((ROOT / "method-contract.json").read_text())
    for evidence in contract["evidence"]:
        path = REPO / evidence["path"]
        assert path.is_file(), evidence["path"]
        assert hashlib.sha256(path.read_bytes()).hexdigest() == evidence["sha256"], evidence["path"]
    for name in ("handler.asm.txt", "save_item_in_bulk_data.asm.txt", "set_in_slide_data.asm.txt", "save_helper_trampoline.asm.txt"):
        assert (ROOT / name).is_file()

if __name__ == "__main__":
    tests = [test_handler_identity_and_extent, test_cfg_gate_and_open_edges, test_evidence_hashes_and_artifact_presence]
    for test in tests:
        test()
    print(f"{len(tests)} structural integrity checks passed; no semantic or runtime validation.")
