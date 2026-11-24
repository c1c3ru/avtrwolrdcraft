#!/usr/bin/env python3
"""Reextrai instancias de MonoBehaviour de classes que falhavam (T020) sem carregar o datapack inteiro: arquivo serializado por arquivo.

1. descomprime os arquivos serializados (flags 4) do UnityFS em blocos (tools/unityfs_extract.py), uma passada so;
2. para cada arquivo, abre so ele no UnityPy e le, com TypeTreeGenerator do MESMO build + check_read=True, as instancias das classes alvo.
Memoria: o maior arquivo e `resources.assets` (334 MB); pico medido ~1 GB.

uso: tools/venv/bin/python tools/mb_stream_extract.py --bundle out/device/dp/datapack.unity3d --il2cpp out/recon/il2cpp_1.230 \\
        --data-unity3d out/device/dp/data.unity3d --classes out/recon/t020_targets.json --out out/recon/il2cpp_1.230/mb_t020
"""
import argparse, collections, gzip, json, re, sys
from pathlib import Path
import UnityPy
from UnityPy.helpers.TypeTreeGenerator import TypeTreeGenerator

HERE = Path(__file__).resolve().parent
sys.path.insert(0, str(HERE))
import unityfs_extract as ufs  # noqa: E402
from mb_retry_failed_classes import fix_mislabeled_vectors  # noqa: E402


def extract_serialized(bundle, dest):
    f, data_start, blocks, nodes = ufs.parse(bundle)
    dest.mkdir(parents=True, exist_ok=True)
    outs = {n: (open(dest / n, "wb"), off, off + sz) for n, off, sz, fl in nodes if fl & 4}
    f.seek(data_start)
    pos = 0
    for u, c, fl in blocks:
        raw = f.read(c)
        end = pos + u
        need = [(n, o) for n, o in outs.items() if o[1] < end and o[2] > pos]
        if need:
            buf = ufs.decompress(raw, fl & 0x3F, u)
            for n, (fh, lo, hi) in need:
                fh.write(buf[max(lo, pos) - pos:min(hi, end) - pos])
        pos = end
    for fh, _, _ in outs.values():
        fh.close()
    return sorted(outs)


def main():
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument("--bundle", type=Path, required=True)
    ap.add_argument("--il2cpp", type=Path, required=True)
    ap.add_argument("--data-unity3d", type=Path, required=True)
    ap.add_argument("--classes", type=Path, required=True, help="JSON {grupo: [classe, ...]}")
    ap.add_argument("--out", type=Path, required=True)
    ap.add_argument("--tmp", type=Path, default=Path("out/device/dp/ser"))
    ap.add_argument("--only", nargs="*", default=[], help="processar so estes arquivos (nomes)")
    a = ap.parse_args()
    groups = json.loads(a.classes.read_text())
    wanted_names = {c: g for g, cs in groups.items() for c in cs}
    files = sorted(p.name for p in a.tmp.glob("*")) if a.tmp.exists() and any(a.tmp.iterdir()) else extract_serialized(a.bundle, a.tmp)
    print("arquivos serializados:", len(files), flush=True)
    g = TypeTreeGenerator("2022.3.70f1")
    g.load_il2cpp((a.il2cpp / "libil2cpp.so").read_bytes(), (a.il2cpp / "global-metadata.dat").read_bytes())
    base = UnityPy.load(str(a.data_unity3d))
    scripts = {o.path_id: o.read() for o in base.objects if o.type.name == "MonoScript"}
    pid_class = {pid: f"{s.m_Namespace}.{s.m_ClassName}".strip(".") for pid, s in scripts.items()}
    targets = {pid: c for pid, c in pid_class.items() if c in wanted_names}
    print("classes alvo com script:", len(set(targets.values())), "de", len(wanted_names), flush=True)
    nodes, gen_err = {}, {}
    for pid, c in targets.items():
        s = scripts[pid]
        try:
            ns = json.loads(g.get_nodes_as_json(s.m_AssemblyName.removesuffix(".dll"), c))
            for n in ns:
                if n["m_Name"] == "m_Enabled" and n["m_Level"] == 1:
                    n["m_MetaFlag"] = 16384
            fix_mislabeled_vectors(ns)
            nodes[pid] = ns
        except Exception as e:  # noqa: BLE001
            gen_err[c] = f"{type(e).__name__}: {str(e)[:150]}"
    print("arvores geradas:", len({targets[p] for p in nodes}), "| falha ao gerar:", len(gen_err), flush=True)
    a.out.mkdir(parents=True, exist_ok=True)
    stat = collections.defaultdict(collections.Counter)
    errs = {}
    writers = {}
    for fn in files:
        if a.only and fn not in a.only:
            continue
        try:
            env = UnityPy.load(str(a.tmp / fn))
        except Exception as e:  # noqa: BLE001
            print("  nao abriu", fn, type(e).__name__, flush=True)
            continue
        for o in env.objects:
            if o.type.name != "MonoBehaviour":
                continue
            try:
                head = o.get_raw_data()[:28]
                import struct
                pid = struct.unpack_from("<q", head, 20)[0]
            except Exception:  # noqa: BLE001
                continue
            if pid not in targets:
                continue
            c = targets[pid]
            if pid not in nodes:
                stat[c]["sem_arvore"] += 1
                continue
            try:
                d = o.read_typetree(nodes[pid], check_read=True)
                d["_path_id"], d["_file"] = o.path_id, fn
                if c not in writers:
                    writers[c] = gzip.open(a.out / (re.sub(r"[^\w.\-]+", "_", c) + ".jsonl.gz"), "wt")
                writers[c].write(json.dumps(d, default=str) + "\n")
                stat[c]["ok"] += 1
            except BaseException as e:  # noqa: BLE001
                if not isinstance(e, Exception):
                    raise
                stat[c]["err"] += 1
                errs.setdefault(c, f"{type(e).__name__}: {str(e)[:200]}")
        del env
    for w in writers.values():
        w.close()
    out = {"groups": {gname: {c: dict(stat[c]) for c in cs} for gname, cs in groups.items()}, "errors": errs, "tree_generation_errors": gen_err}
    (a.out / "_stats.json").write_text(json.dumps(out, indent=1))
    ok = sum(1 for c in wanted_names if stat[c]["ok"] and not stat[c]["err"])
    print("classes 100%% ok: %d | com erro: %d | sem instancia achada: %d" % (ok, sum(1 for c in wanted_names if stat[c]["err"]), sum(1 for c in wanted_names if not stat[c])))


if __name__ == "__main__":
    main()
