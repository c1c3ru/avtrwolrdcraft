#!/usr/bin/env python3
"""Exporta o interior de todo predio do mapa que tem cena (out/recon/building_scenes.json) e gera o catalogo.

Para cada predio resolvido (tools/recon_building_scenes.py): tools/export_interior.py <levelN> <chave>. Pula chaves ja
exportadas. Falhas nao param o lote: ficam em out/recon/interiors_export.json. No fim imprime as linhas de
InteriorCatalog.cs (defaultLevel -> chave).

uso: tools/venv/bin/python tools/export_all_interiors.py [--max-roots 600]
"""
import argparse, json, re, subprocess, sys, time
from pathlib import Path

ROOT = Path(__file__).resolve().parent.parent
PY = str(ROOT / "tools/venv/bin/python")
DEST = ROOT / "client/AvatarWorldClient/Assets/Resources/Interiors"
LOG = ROOT / "out/recon/interiors_export.json"


def slug(name):
    return re.sub(r"[^a-z0-9]+", "_", name.lower()).strip("_")


def main():
    ap = argparse.ArgumentParser()
    ap.add_argument("--max-roots", type=int, default=600, help="pula cenas com mais objetos raiz que isto (ruas enormes)")
    a = ap.parse_args()
    rows = json.loads((ROOT / "out/recon/building_scenes.json").read_text())["buildings"]
    seen, jobs = {}, []
    for r in rows:
        if not r["file"] or r["file"] in seen:
            continue
        seen[r["file"]] = r
        jobs.append(r)
    done = json.loads(LOG.read_text()) if LOG.exists() else {}
    existing = {"level206": "dentist", "level30": "ballet", "level15": "cabin"}
    for r in jobs:
        lvl = r["file"]
        key = existing.get(lvl) or slug(r["building"])
        if (DEST / key / f"{key}.json").exists():
            done[lvl] = {"key": key, "status": "ok", "defaultLevel": r["defaultLevel"], "building": r["building"]}
            continue
        if (r["rootObjects"] or 0) > a.max_roots:
            done[lvl] = {"key": key, "status": f"pulado: {r['rootObjects']} raizes", "defaultLevel": r["defaultLevel"], "building": r["building"]}
            continue
        t = time.time()
        p = subprocess.run([PY, "tools/export_interior.py", lvl, key], cwd=ROOT, capture_output=True, text=True)
        ok = p.returncode == 0 and (DEST / key / f"{key}.json").exists()
        done[lvl] = {"key": key, "status": "ok" if ok else "falhou: " + (p.stderr or p.stdout)[-200:],
                     "defaultLevel": r["defaultLevel"], "building": r["building"], "seconds": round(time.time() - t)}
        LOG.write_text(json.dumps(done, indent=1, ensure_ascii=False))
        print(lvl, key, done[lvl]["status"][:60], flush=True)
    LOG.write_text(json.dumps(done, indent=1, ensure_ascii=False))
    print("\nCatalogo:")
    for lvl, d in sorted(done.items(), key=lambda kv: kv[1]["defaultLevel"]):
        if d["status"] == "ok":
            print(f'            {{ {d["defaultLevel"]}, "{d["key"]}" }}, // {d["building"]} -> {lvl}')


if __name__ == "__main__":
    main()
