"""Build basic-block control-flow graphs for the T030 save/persistence AArch64 windows.

Reuses the already-extracted objdump windows in out/recon/tasks/T030/persistence-asm/
(same binary SHA256 recorded in report.json). Unlike recon_save_static.py, which only
records `bl`/unconditional `b` targets, this parses every branch kind the ELF/AArch64
ISA uses for control flow (b, b.cond, cbz, cbnz, tbz, tbnz, bl, blr, ret) to build real
basic blocks and edges, and reports whether every intra-function branch target stays
inside the captured window (a necessary, not sufficient, condition for a complete CFG).
"""
from __future__ import annotations

import argparse
import hashlib
import json
import re
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
ASM_DIR = ROOT / "out/recon/tasks/T030/persistence-asm"
REPORT = ASM_DIR / "report.json"

INSN_RE = re.compile(r"^\s*([0-9a-f]+):\s+[0-9a-f]+\s+(\S+)\s*(.*)$")
COND_B = re.compile(r"^b\.(eq|ne|cs|hs|cc|lo|mi|pl|vs|vc|hi|ls|ge|lt|gt|le|al|nv)$")


def sha256(path: Path) -> str:
    digest = hashlib.sha256()
    with path.open("rb") as source:
        for block in iter(lambda: source.read(1024 * 1024), b""):
            digest.update(block)
    return digest.hexdigest()


def parse_instructions(text: str) -> list[tuple[int, str, str]]:
    out = []
    for line in text.splitlines():
        m = INSN_RE.match(line)
        if not m:
            continue
        addr = int(m.group(1), 16)
        mnem = m.group(2)
        operands = m.group(3).strip()
        out.append((addr, mnem, operands))
    return out


def hex_target(operands: str) -> int | None:
    # llvm-objdump appends a symbolic annotation after the real target, e.g.
    # "0x21e24f8 <__start_il2cpp+0x5912e8>" -- that annotation's own "+0x..."
    # offset is itself a hex literal and must not be mistaken for the target.
    # Strip everything from "<" onward first, then take the LAST hex literal
    # in what remains (tbz/tbnz and cbz/cbnz list a register/bit-position
    # before the address, e.g. "w8, #0x0, 0x21e24f8").
    operands = operands.split("<", 1)[0]
    matches = re.findall(r"0x([0-9a-f]+)", operands)
    return int(matches[-1], 16) if matches else None


def build_cfg(instructions: list[tuple[int, str, str]], window_start: int, window_stop: int) -> dict:
    addrs = [a for a, _, _ in instructions]
    addr_set = set(addrs)
    leaders = {window_start} if addrs else set()
    edges = []
    out_of_window_targets = []
    indirect_sites = []
    for i, (addr, mnem, operands) in enumerate(instructions):
        next_addr = instructions[i + 1][0] if i + 1 < len(instructions) else None
        is_branch = False
        if mnem in ("b", "bl"):
            tgt = hex_target(operands)
            is_branch = True
            if tgt is not None:
                leaders.add(tgt)
                edges.append({"from": hex(addr), "kind": mnem, "to": hex(tgt)})
                # `bl` is a call: its target is expected to live outside this window
                # (a shared runtime/managed helper) and says nothing about whether this
                # function's own body is fully captured. Only `b` is an intra-function
                # (or tail-call) jump relevant to the completeness/boundedness signal.
                if mnem == "b" and (tgt < window_start or tgt >= window_stop):
                    out_of_window_targets.append({"site": hex(addr), "kind": mnem, "target": hex(tgt)})
            if mnem == "b" and next_addr is not None:
                leaders.add(next_addr)
        elif COND_B.match(mnem) or mnem in ("cbz", "cbnz", "tbz", "tbnz"):
            tgt = hex_target(operands)
            is_branch = True
            if tgt is not None:
                leaders.add(tgt)
                edges.append({"from": hex(addr), "kind": mnem, "to": hex(tgt)})
                if tgt < window_start or tgt >= window_stop:
                    out_of_window_targets.append({"site": hex(addr), "kind": mnem, "target": hex(tgt)})
            if next_addr is not None:
                leaders.add(next_addr)
                edges.append({"from": hex(addr), "kind": "fallthrough", "to": hex(next_addr)})
        elif mnem in ("blr", "br"):
            is_branch = True
            indirect_sites.append({"site": hex(addr), "instruction": f"{mnem} {operands}".strip()})
        elif mnem == "ret":
            is_branch = True
            if next_addr is not None:
                leaders.add(next_addr)
    leaders = sorted(a for a in leaders if a in addr_set or a == window_start)
    blocks = []
    for idx, start in enumerate(leaders):
        stop = leaders[idx + 1] if idx + 1 < len(leaders) else (addrs[-1] + 4 if addrs else start)
        block_insns = [a for a in addrs if start <= a < stop]
        blocks.append({"start": hex(start), "stop_exclusive": hex(stop), "instruction_count": len(block_insns)})
    return {
        "basic_block_count": len(blocks),
        "blocks": blocks,
        "intra_function_edges": edges,
        "indirect_call_sites": indirect_sites,
        "out_of_window_targets": out_of_window_targets,
        "last_instruction": {"address": hex(addrs[-1]), "mnemonic": instructions[-1][1]} if instructions else None,
        "ends_in_return": instructions[-1][1] == "ret" if instructions else False,
    }


def main() -> None:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--report", type=Path, default=REPORT)
    parser.add_argument("--asm-dir", type=Path, default=ASM_DIR)
    parser.add_argument("--output", type=Path, default=ASM_DIR / "cfg-report.json")
    parser.add_argument("--only", nargs="*", default=None, help="Optional subset of declaring_type.name to process")
    args = parser.parse_args()

    report = json.loads(args.report.read_text(encoding="utf-8"))
    binary_sha = report["inputs"]["binary_sha256"]
    results = []
    for m in report["mapped_methods"]:
        qualified = f"{m['declaring_type']}.{m['name']}"
        if args.only and qualified not in args.only:
            continue
        asm_path = ROOT / m["assembly"]
        text = asm_path.read_text(encoding="utf-8")
        insns = parse_instructions(text)
        start = int(m["vaddr"], 16)
        stop = int(m["window_stop_exclusive"], 16)
        cfg = build_cfg(insns, start, stop)
        results.append({
            "declaring_type": m["declaring_type"],
            "name": m["name"],
            "vaddr": m["vaddr"],
            "assembly": m["assembly"],
            "assembly_sha256": sha256(asm_path),
            "window_stop_exclusive": m["window_stop_exclusive"],
            "bounded_within_window": len(cfg["out_of_window_targets"]) == 0,
            **cfg,
        })
    out = {
        "description": "Basic-block CFGs derived from already-extracted AArch64 windows (same binary as persistence-asm/report.json). 'bounded_within_window' is a necessary but not sufficient completeness signal: a true function boundary requires that every branch target plus the final return/tail resolve inside the window.",
        "binary_sha256": binary_sha,
        "source_report": str(args.report.relative_to(ROOT)),
        "methods": results,
    }
    args.output.write_text(json.dumps(out, ensure_ascii=False, indent=2) + "\n", encoding="utf-8")
    unbounded = [f"{r['declaring_type']}.{r['name']}" for r in results if not r["bounded_within_window"]]
    print(json.dumps({"methods": len(results), "unbounded": unbounded, "output": str(args.output.relative_to(ROOT))}, indent=2))


if __name__ == "__main__":
    main()
