#!/usr/bin/env python3
"""Extrai ClothesDropDataMap e os PDTextBulkData `ClothesDrop_*` de um `resources.assets` ja extraido (tools/unityfs_extract.py), sem abrir o datapack inteiro.

Mesma tecnica de tools/mb_retry_failed_classes.py: TypeTreeGenerator alimentado pelo par libil2cpp.so + global-metadata.dat do MESMO build, scripts do data.unity3d,
leitura com check_read=True (falha se sobrar/faltar byte). Saida: <out>/PWC.Level.ClothesDropDataMap.jsonl.gz e <out>/PWC.PersistentData.PDTextBulkData.jsonl.gz.

uso: tools/venv/bin/python tools/clothes_drops_from_assets.py --il2cpp out/recon/il2cpp_1.230 --data-unity3d out/device/dp/data.unity3d \\
        --resources out/device/dp/resources.assets --out out/recon/il2cpp_1.230/mb
"""
import argparse, gzip, json, sys
from pathlib import Path
import UnityPy
from UnityPy.helpers.TypeTreeGenerator import TypeTreeGenerator

HERE = Path(__file__).resolve().parent
sys.path.insert(0, str(HERE))
from mb_retry_failed_classes import fix_mislabeled_vectors  # noqa: E402

WANT = {"PWC.Level.ClothesDropDataMap", "PWC.PersistentData.PDTextBulkData"}


def main():
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument("--il2cpp", type=Path, required=True)
    ap.add_argument("--data-unity3d", type=Path, required=True)
    ap.add_argument("--resources", type=Path, required=True)
    ap.add_argument("--out", type=Path, required=True)
    a = ap.parse_args()
    g = TypeTreeGenerator("2022.3.70f1")
    g.load_il2cpp((a.il2cpp / "libil2cpp.so").read_bytes(), (a.il2cpp / "global-metadata.dat").read_bytes())
    base = UnityPy.load(str(a.data_unity3d))
    scripts = {o.path_id: o.read() for o in base.objects if o.type.name == "MonoScript"}
    print("scripts:", len(scripts), flush=True)
    wanted = {pid: s for pid, s in scripts.items() if f"{s.m_Namespace}.{s.m_ClassName}".strip(".") in WANT}
    print("scripts alvo:", {pid: f"{s.m_Namespace}.{s.m_ClassName}" for pid, s in wanted.items()}, flush=True)
    nodes = {}
    for pid, s in wanted.items():
        ns = json.loads(g.get_nodes_as_json(s.m_AssemblyName.removesuffix(".dll"), f"{s.m_Namespace}.{s.m_ClassName}"))
        for n in ns:
            if n["m_Name"] == "m_Enabled" and n["m_Level"] == 1:
                n["m_MetaFlag"] = 16384
        fix_mislabeled_vectors(ns)
        nodes[pid] = ns
    env = UnityPy.load(str(a.resources))
    a.out.mkdir(parents=True, exist_ok=True)
    files, counts = {}, {}
    for o in env.objects:
        if o.type.name != "MonoBehaviour":
            continue
        raw = o.read(check_read=False)
        pid = raw.m_Script.m_PathID
        if pid not in wanted:
            continue
        cname = f"{wanted[pid].m_Namespace}.{wanted[pid].m_ClassName}"
        d = o.read_typetree(nodes[pid], check_read=True)
        if cname.endswith("PDTextBulkData") and not str(d.get("m_Name", "")).startswith("ClothesDrop"):
            continue
        d["_path_id"] = o.path_id
        d["_file"] = o.assets_file.name
        if cname not in files:
            files[cname] = gzip.open(a.out / f"{cname}.jsonl.gz", "wt")
        files[cname].write(json.dumps(d, default=str) + "\n")
        counts[cname] = counts.get(cname, 0) + 1
    for f in files.values():
        f.close()
    print("gravados:", counts)


if __name__ == "__main__":
    main()
