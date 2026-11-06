#!/usr/bin/env python3
"""Contrato de reconstrução: afirmações com evidência + vetores de teste.

Adaptado do padrão "analysis contract" do harness-for-rea (MIT, protonspy), reescrito
em Python stdlib. Diferenças deliberadas, porque aqui o original NÃO roda (PairIP, sem
dispositivo): toda constante diz o seu `status` (sourced|estimated|invented) e todo
vetor diz a sua `provenance` (runtime-observed|static-derived).

Uso:
  recon_contract.py validate  contracts/x.contract.json      # esquema
  recon_contract.py check     contracts/x.contract.json      # fontes existem/linhas válidas
  recon_contract.py replay    contracts/x.contract.json -- CMD [ARGS...]
      roda CMD <args do vetor> com o stdin do vetor e compara stdout (byte a byte) e exit code.
"""
from __future__ import annotations

import argparse
import json
import re
import subprocess
import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parent.parent

SRC_LINES = re.compile(r"^(?P<path>[^:@\s][^:@]*):(?P<a>\d+)(?:-(?P<b>\d+))?$")
SRC_ADDR = re.compile(r"^(?P<path>[^:@\s][^:@]*)@0x(?P<addr>[0-9a-fA-F]{1,16})$")
SRC_EV = re.compile(r"^(ev|unk)_[0-9a-f]{64}$")

STATUSES = {"sourced", "estimated", "invented"}
PROVENANCES = {"runtime-observed", "static-derived"}
SEVERITIES = {"low", "medium", "high"}


def parse_source(src: str):
    """('lines', path, a, b) | ('addr', path, addr) | ('ev', id) | None se inválida."""
    if SRC_EV.match(src):
        return ("ev", src)
    if m := SRC_LINES.match(src):
        a = int(m["a"])
        b = int(m["b"]) if m["b"] else a
        return ("lines", m["path"], a, b)
    if m := SRC_ADDR.match(src):
        return ("addr", m["path"], int(m["addr"], 16))
    return None


def _str(d: dict, key: str, problems: list, where: str, required=True) -> str | None:
    v = d.get(key)
    if v is None:
        if required:
            problems.append(f"{where}: falta '{key}'")
        return None
    if not isinstance(v, str) or not v.strip():
        problems.append(f"{where}.{key}: deve ser texto não vazio")
        return None
    return v


def validate(c: object) -> list[str]:
    p: list[str] = []
    if not isinstance(c, dict):
        return ["contrato: deve ser um objeto JSON"]
    known = {"version", "subject", "target", "functions", "constants", "unknowns", "vectors"}
    for k in c.keys() - known:
        p.append(f"contrato: chave desconhecida '{k}'")
    if c.get("version") != 1:
        p.append("contrato.version: deve ser 1")
    _str(c, "subject", p, "contrato")

    def src_ok(d: dict, where: str, required: bool):
        s = _str(d, "source", p, where, required)
        if s is not None and parse_source(s) is None:
            p.append(f"{where}.source: formato inválido '{s}' (path:12-30 | path@0x401000 | ev_<64hex>)")
        return s

    for i, f in enumerate(c.get("functions", [])):
        w = f"functions[{i}]"
        _str(f, "name", p, w)
        src_ok(f, w, required=True)
        for k in ("inputs", "outputs", "sideEffects"):
            if not isinstance(f.get(k, []), list):
                p.append(f"{w}.{k}: deve ser lista")

    for i, k in enumerate(c.get("constants", [])):
        w = f"constants[{i}]"
        _str(k, "name", p, w)
        if "value" not in k or not isinstance(k["value"], (str, int, float, bool)):
            p.append(f"{w}.value: obrigatório (texto, número ou booleano)")
        st = k.get("status")
        if st not in STATUSES:
            p.append(f"{w}.status: deve ser um de {sorted(STATUSES)}")
        elif st == "sourced":
            src_ok(k, w, required=True)
        else:
            # estimated/invented não afirmam o original: dizem de onde veio e onde vive a invenção
            _str(k, "basis", p, w)
            src_ok(k, w, required=False)
            if st == "invented":
                _str(k, "reimplementation", p, w)

    for i, u in enumerate(c.get("unknowns", [])):
        w = f"unknowns[{i}]"
        _str(u, "question", p, w)
        if u.get("severity") not in SEVERITIES:
            p.append(f"{w}.severity: deve ser um de {sorted(SEVERITIES)}")

    seen = set()
    for i, v in enumerate(c.get("vectors", [])):
        w = f"vectors[{i}]"
        n = _str(v, "name", p, w)
        if n in seen:
            p.append(f"{w}.name: duplicado '{n}'")
        seen.add(n)
        pv = v.get("provenance")
        if pv not in PROVENANCES:
            p.append(f"{w}.provenance: deve ser um de {sorted(PROVENANCES)}")
        args = v.get("args", [])
        if not isinstance(args, list) or not all(isinstance(a, str) for a in args):
            p.append(f"{w}.args: deve ser lista de textos")
        for k in ("stdin",):
            if not isinstance(v.get(k, ""), str):
                p.append(f"{w}.{k}: deve ser texto")
        if not isinstance(v.get("stdout"), str):
            p.append(f"{w}.stdout: obrigatório (texto)")
        ec = v.get("exitCode", 0)
        if not isinstance(ec, int) or isinstance(ec, bool) or not 0 <= ec <= 255:
            p.append(f"{w}.exitCode: inteiro 0..255")
        s = _str(v, "source", p, w)
        if s is not None:
            if pv == "static-derived" and parse_source(s) is None:
                p.append(f"{w}.source: static-derived exige fonte no formato path:N | path@0x.. | ev_..")
            # runtime-observed: a fonte é o comando/captura executado no original (texto livre)
    return p


def check_sources(c: dict) -> list[str]:
    """Cada fonte `path:a-b` aponta para arquivo existente e linhas dentro do arquivo."""
    p: list[str] = []
    entries = []
    for sec in ("functions", "constants", "vectors"):
        for i, d in enumerate(c.get(sec, [])):
            if isinstance(d.get("source"), str):
                entries.append((f"{sec}[{i}]", d["source"], d.get("provenance")))
    for where, s, prov in entries:
        if prov == "runtime-observed":
            continue
        ps = parse_source(s)
        if ps is None or ps[0] == "ev":
            continue  # ev_ ids vivem no REA, não no disco
        path = ROOT / ps[1]
        if not path.is_file():
            p.append(f"{where}: arquivo inexistente '{ps[1]}'")
        elif ps[0] == "lines":
            n = sum(1 for _ in path.open("rb"))
            if not (1 <= ps[2] <= ps[3] <= n):
                p.append(f"{where}: linhas {ps[2]}-{ps[3]} fora de '{ps[1]}' ({n} linhas)")
    return p


def replay(c: dict, cmd: list[str], timeout: int = 30) -> list[str]:
    """Roda a reimplementação contra cada vetor; devolve as divergências."""
    diffs: list[str] = []
    for v in c.get("vectors", []):
        try:
            r = subprocess.run(
                cmd + v.get("args", []),
                input=v.get("stdin", "").encode(),
                capture_output=True,
                timeout=timeout,
                cwd=ROOT,
            )
        except (OSError, subprocess.TimeoutExpired) as e:
            diffs.append(f"{v['name']}: não executou ({e})")
            continue
        want = v["stdout"].encode()
        if r.stdout != want:
            diffs.append(f"{v['name']}: stdout difere\n  esperado: {want!r}\n  obtido:   {r.stdout!r}")
        if r.returncode != v.get("exitCode", 0):
            diffs.append(f"{v['name']}: exit {r.returncode}, esperado {v.get('exitCode', 0)}")
    return diffs


def _load(path: str) -> dict:
    return json.loads(Path(path).read_text(encoding="utf-8"))


def main(argv=None) -> int:
    ap = argparse.ArgumentParser(description=__doc__, formatter_class=argparse.RawDescriptionHelpFormatter)
    sub = ap.add_subparsers(dest="cmd", required=True)
    for name in ("validate", "check", "replay"):
        s = sub.add_parser(name)
        s.add_argument("contract")
        if name == "replay":
            s.add_argument("--provenance", choices=sorted(PROVENANCES), help="só vetores desta proveniência")
            s.add_argument("command", nargs=argparse.REMAINDER, help="-- CMD [ARGS...]")
    a = ap.parse_args(argv)
    c = _load(a.contract)
    problems = validate(c)
    if a.cmd == "check" and not problems:
        problems = check_sources(c)
    if a.cmd == "replay" and not problems:
        cmd = [x for x in a.command if x != "--"] if a.command[:1] == ["--"] else a.command
        if not cmd:
            problems = ["replay: informe o comando da reimplementação depois de --"]
        else:
            if a.provenance:
                c["vectors"] = [v for v in c.get("vectors", []) if v["provenance"] == a.provenance]
            problems = replay(c, cmd)
            if not problems:
                print(f"ok: {len(c.get('vectors', []))} vetores idênticos byte a byte")
                return 0
    if problems:
        print("\n".join(problems), file=sys.stderr)
        return 1
    print("ok")
    return 0


if __name__ == "__main__":
    sys.exit(main())
