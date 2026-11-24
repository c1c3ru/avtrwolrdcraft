#!/usr/bin/env python3
"""Reprocessa so os MonoBehaviours das classes com erro de `out/mb/_stats.json` com `tools/lowmem_unitypy.py` (baixa memoria).

Uso (na raiz do repo): python3 -I tools/mb_retry_errors_lowmem.py <datapack.unity3d> <staging_dir> <resumo.json> [tmp_dir]
 - reaproveita `nodes_for`/`fix_mislabeled_vectors` de tools/mb_dump.py (mesmo type tree corrigido);
 - grava `<staging_dir>/<Classe>.jsonl.gz` (campos + `_path_id` + `_file`, mesmo schema do mb_dump) SO para objetos que decodificam e cujo m_Script confere;
 - `resumo.json` = por classe {ok, err, bad, first_err, no_nodes}. Nao escreve em out/mb: integrar e decisao de quem roda.
Pico de RSS ~2,5 GB (881.898 MonoBehaviours). Usa `tmp_dir` (default /tmp) para o arquivo de blocos descomprimidos (~3,3 GB em disco).
Reproduz o passe de 2026-11-24 (63 classes resolvidas; ver docs/RECON_T020_LOWMEM_2026-11-24.md).
"""
import collections
import faulthandler
import gc
import gzip
import json
import os
import re
import sys

import UnityPy
from UnityPy.helpers.TypeTreeGenerator import TypeTreeGenerator

sys.path.insert(0, os.path.dirname(os.path.abspath(__file__)))
import lowmem_unitypy as L  # noqa: E402

faulthandler.enable()
bundle, staging, outp = sys.argv[1], sys.argv[2], sys.argv[3]
tmp = sys.argv[4] if len(sys.argv) > 4 else "/tmp"
want = set(json.load(open("out/mb/_stats.json"))["erros"])
src = open("tools/mb_dump.py").read().split("env = UnityPy.load(bundle)")[0]
g = TypeTreeGenerator("2022.3.70f1")
g.load_il2cpp(open("il2cpp_in/libil2cpp.so", "rb").read(), open("il2cpp_in/global-metadata.dat", "rb").read())
ns = dict(g=g, json=json, UnityPy=UnityPy, sys=sys, os=os, re=re, gzip=gzip, collections=collections)
exec("nodes_cache = {}\n" + src.split("nodes_cache = {}")[1], ns)
nodes_for = ns["nodes_for"]

L.install(tmp, "base")
base = UnityPy.load("x/base/assets/bin/Data/data.unity3d")
scripts = {o.path_id: o.read() for o in base.objects if o.type.name == "MonoScript"}
del base
gc.collect()
L.TMP["tag"] = "datapack"
env = UnityPy.load(bundle)
os.makedirs(staging, exist_ok=True)
safe = lambda x: re.sub(r"[^\w.\-]+", "_", x)
files = {}
res = collections.defaultdict(lambda: {"ok": 0, "err": 0, "bad": 0, "first_err": None, "no_nodes": False})
for o in env.objects:
    if o.type.name != "MonoBehaviour":
        continue
    try:
        pid = o.read(check_read=False).m_Script.m_PathID
        s = scripts[pid]
    except Exception:
        continue
    cname = f"{s.m_Namespace}.{s.m_ClassName}".strip(".")
    if cname not in want:
        continue
    r = res[cname]
    nodes = nodes_for(s)
    if not nodes:
        r["no_nodes"] = True
    try:
        d = o.read_typetree(nodes) if nodes else o.read_typetree()
        if d["m_Script"]["m_PathID"] != pid:
            r["bad"] += 1
            continue
        r["ok"] += 1
        d["_path_id"], d["_file"] = o.path_id, o.assets_file.name
        if cname not in files:
            files[cname] = gzip.open(os.path.join(staging, safe(cname) + ".jsonl.gz"), "wt")
        files[cname].write(json.dumps(d, default=str) + "\n")
    except Exception as e:
        r["err"] += 1
        r["first_err"] = r["first_err"] or f"{type(e).__name__}: {str(e)[:120]}"
for f in files.values():
    f.close()
json.dump({"classes": res}, open(outp, "w"), indent=1)
print("FIM", len(res), "classes")
