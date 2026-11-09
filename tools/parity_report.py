#!/usr/bin/env python3
"""Relatório de paridade do clone offline vs. Avatar World original.

Só lê arquivos locais (sem rede, sem Unity). Grava out/parity.json e adiciona
uma linha em out/parity_history.jsonl (uma por dia) para ver a tendência.

Uso: python3 tools/parity_report.py [--no-history]
"""
import json, re, sys, datetime, pathlib, collections

ROOT = pathlib.Path(__file__).resolve().parent.parent
if "--root" in sys.argv:  # medir outro checkout/worktree (ex.: branch de trabalho)
    ROOT = pathlib.Path(sys.argv[sys.argv.index("--root") + 1]).resolve()
CLIENT = ROOT / "client/AvatarWorldClient/Assets"
RES = CLIENT / "Resources"
OUT = ROOT / "out"


def jload(p, default=None):
    try:
        return json.load(open(p))
    except Exception:
        return default


def count_files(d, pattern):
    return sum(1 for _ in d.glob(pattern)) if d.exists() else 0


def pct(a, b):
    return round(100.0 * a / b, 1) if b else None


def main():
    m = {}

    # Cenas / interiores
    bs = jload(OUT / "recon/building_scenes.json", {})
    scenes_total = bs.get("sceneCount", 254)
    buildings = len(bs.get("buildings", []))
    interiors = [d for d in (RES / "Interiors").iterdir() if d.is_dir() and d.name != "covers"] if (RES / "Interiors").exists() else []
    exp = jload(OUT / "recon/interiors_export.json", {})
    exp_bad = sorted(k for k, v in exp.items() if v.get("status") != "ok")
    m["scenes"] = {
        "total_buildsettings": scenes_total,
        "buildings_mapped": buildings,
        "interiors_in_client": len(interiors),
        "interiors_with_items": sum(1 for d in interiors if list(d.glob("*_items.json"))),
        "interiors_with_npcs": sum(1 for d in interiors if list(d.glob("*_npcs.json"))),
        "interior_export_failures": exp_bad,
        "interiors_pct_of_scenes": pct(len(interiors), scenes_total),
    }

    # Mapas
    maps = [d for d in (RES / "Maps").iterdir() if d.is_dir()] if (RES / "Maps").exists() else []
    m["maps"] = {"count": len(maps), "names": sorted(d.name for d in maps)}

    # Loja
    items = (jload(RES / "Store/items.json", {}) or {}).get("items", [])
    cat = jload(ROOT / "store_catalog.json")
    cat = cat.get("items", []) if isinstance(cat, dict) else (cat or [])
    guids = len({e.get("guid") for e in cat if isinstance(e, dict)}) or None
    m["store"] = {
        "items_in_client": len(items),
        "catalog_unique_guids": guids,
        "pct": pct(len(items), guids) if guids else None,
        "packs": count_files(RES / "Store/packs", "*") // 2,
    }

    # Código original vs. cliente
    asm = OUT / "cpp2il/DiffableCs/Assembly-CSharp"
    orig_total = count_files(asm, "**/*.cs")
    orig_level = count_files(asm / "Game/Level", "**/*.cs")
    client_cs = [p for p in CLIENT.glob("Scripts/**/*.cs")]
    client_loc = 0
    for p in client_cs:
        try:
            client_loc += sum(1 for _ in open(p, errors="ignore"))
        except OSError:
            pass
    m["code"] = {
        "original_classes_assembly_csharp": orig_total,
        "original_classes_game_level": orig_level,
        "client_cs_files": len(client_cs),
        "client_loc": client_loc,
    }

    # Testes
    tests = 0
    for p in (CLIENT / "Tests").glob("**/*.cs"):
        tests += len(re.findall(r"\[(Test|TestCase|UnityTest)\b", open(p, errors="ignore").read()))
    m["tests"] = {"edit_mode_test_methods": tests}

    # Recon (RE) — evidência produzida
    task_dirs = [d for d in (OUT / "recon/tasks").iterdir() if d.is_dir()] if (OUT / "recon/tasks").exists() else []
    recon_docs = count_files(ROOT / "docs", "RECON_*.md")
    m["recon"] = {"task_dirs_with_evidence": sorted(d.name for d in task_dirs), "recon_docs": recon_docs,
                  "tool_scripts": count_files(ROOT / "tools", "*.py")}

    # Fila de tarefas (ledger)
    tj = jload(ROOT / "docs/AVATAR_WORLD_TASKS.json", {})
    tasks = tj.get("tasks", [])
    states = collections.Counter(t.get("state") for t in tasks)
    evid = {d.name for d in task_dirs}
    stale = sorted(t["id"] for t in tasks if t.get("state") in ("pending", None) and t["id"] in evid)
    m["task_ledger"] = {"total": len(tasks), "states": dict(states),
                        "pending_but_has_evidence": stale}

    # Estimativa agregada (pesos de julgamento; ver docs/PARITY_SURVEY_2026-11-09.md)
    areas = {
        "interiors": m["scenes"]["interiors_pct_of_scenes"] or 0,
        "store": m["store"]["pct"] or 0,
    }
    m["areas_measured_pct"] = areas

    m["generated"] = datetime.datetime.now().isoformat(timespec="seconds")
    m["branch"] = (lambda r: r.stdout.strip())(__import__("subprocess").run(
        ["git", "-C", str(ROOT), "branch", "--show-current"], capture_output=True, text=True))
    OUT.mkdir(exist_ok=True)
    json.dump(m, open(OUT / "parity.json", "w"), indent=1, ensure_ascii=False)

    if "--no-history" not in sys.argv:
        day = m["generated"][:10]
        hist = OUT / "parity_history.jsonl"
        lines = hist.read_text().splitlines() if hist.exists() else []
        lines = [l for l in lines if not l.startswith('{"day": "%s"' % day)]
        lines.append(json.dumps({"day": day, "interiors": len(interiors), "scenes": scenes_total,
                                 "store_items": len(items), "tests": tests, "client_loc": client_loc,
                                 "ledger_states": dict(states)}))
        hist.write_text("\n".join(lines) + "\n")

    s = m["scenes"]
    print(f"Interiores: {s['interiors_in_client']}/{scenes_total} cenas ({s['interiors_pct_of_scenes']}%) "
          f"| itens {s['interiors_with_items']} | NPCs {s['interiors_with_npcs']} | falhas export {len(exp_bad)}")
    print(f"Mapas: {len(maps)} | Loja: {len(items)}/{guids} itens ({m['store']['pct']}%)")
    print(f"Código: {len(client_cs)} .cs / {client_loc} linhas no cliente; original {orig_total} classes ({orig_level} em Game/Level)")
    print(f"Testes EditMode: {tests} | Ledger: {dict(states)} | pendentes com evidência: {stale}")
    print("-> out/parity.json")


if __name__ == "__main__":
    main()
