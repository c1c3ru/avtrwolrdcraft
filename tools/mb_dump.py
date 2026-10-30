"""Despeja os campos dos MonoBehaviours de um bundle Unity IL2CPP em out/mb/<Classe>.jsonl.gz.
uso: mb_dump.py <bundle> <outdir> <limite_por_classe(0=todos)>"""
import sys, os, re, gzip, json, collections, faulthandler, traceback, UnityPy
faulthandler.enable()
from UnityPy.helpers.TypeTreeGenerator import TypeTreeGenerator
bundle, outdir, limit = sys.argv[1], sys.argv[2], int(sys.argv[3])
g = TypeTreeGenerator("2022.3.70f1")
g.load_il2cpp(open("il2cpp_in/libil2cpp.so", "rb").read(), open("il2cpp_in/global-metadata.dat", "rb").read())
base = UnityPy.load("x/base/assets/bin/Data/data.unity3d")
scripts = {o.path_id: o.read() for o in base.objects if o.type.name == "MonoScript"}
nodes_cache = {}
def nodes_for(s):
    k = (s.m_AssemblyName, s.m_Namespace, s.m_ClassName)
    if k not in nodes_cache:
        asm = s.m_AssemblyName.removesuffix(".dll")
        try:
            ns = json.loads(g.get_nodes_as_json(asm, f"{s.m_Namespace}.{s.m_ClassName}" if s.m_Namespace else s.m_ClassName))
            for n in ns:  # m_Enabled (UInt8) precisa do flag de alinhamento, como no Unity
                if n["m_Name"] == "m_Enabled" and n["m_Level"] == 1: n["m_MetaFlag"] = 16384
            nodes_cache[k] = ns
        except Exception as e:
            nodes_cache[k] = None
    return nodes_cache[k]
env = UnityPy.load(bundle)
os.makedirs(outdir, exist_ok=True)
safe = lambda s: re.sub(r'[^\w.\-]+', '_', s)
files, errs, stat = {}, {}, collections.defaultdict(lambda: collections.Counter())
seen = 0
written = 0
marker = os.open(os.path.join(outdir, "_last.txt"), os.O_WRONLY | os.O_CREAT | os.O_TRUNC)
for o in env.objects:
    if o.type.name != "MonoBehaviour": continue
    seen += 1
    if seen % 20000 == 0:
        for f in files.values(): f.flush()
        print(f"PROGRESSO {seen}", flush=True, file=sys.stderr)
    pid = o.read(check_read=False).m_Script.m_PathID
    s = scripts[pid]; cname = f"{s.m_Namespace}.{s.m_ClassName}".strip(".")
    st = stat[cname]
    if limit and st["ok"] + st["bad"] + st["err"] >= limit: continue
    os.pwrite(marker, f"{seen} {cname} path_id={o.path_id}".ljust(200).encode(), 0)
    nodes = nodes_for(s)
    try:
        d = o.read_typetree(nodes) if nodes else o.read_typetree()  # sem nós gerados: usa o type tree embutido
        if d["m_Script"]["m_PathID"] != pid: st["bad"] += 1; continue
        st["ok"] += 1
        if cname not in files: files[cname] = gzip.open(os.path.join(outdir, safe(cname) + ".jsonl.gz"), "wt")
        # path_id so e unico dentro do arquivo serializado: guarda tambem o arquivo
        d["_path_id"] = o.path_id
        d["_file"] = o.assets_file.name
        files[cname].write(json.dumps(d, default=str) + "\n")
        written += 1
    except BaseException as e:
        if not isinstance(e, Exception): traceback.print_exc(); raise
        st["err"] += 1
        errs.setdefault(cname, f"{type(e).__name__}: {str(e)[:120]}")
for f in files.values(): f.close()
tot = collections.Counter()
for c in stat.values(): tot.update(c)
json.dump({"stats": {k: dict(v) for k, v in stat.items()}, "erros": errs}, open(os.path.join(outdir, "_stats.json"), "w"), indent=1)
print("classes", len(stat), dict(tot), "gravados", written)
if written != tot["ok"]:
    sys.exit(f"ERRO: gravados {written} != ok {tot['ok']}")
