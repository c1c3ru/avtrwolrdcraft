import sys, collections, json, UnityPy
base = UnityPy.load("x/base/assets/bin/Data/data.unity3d")
smap = {}
for o in base.objects:
    if o.type.name == "MonoScript":
        d = o.read(); smap[o.path_id] = f"{d.m_AssemblyName}:{d.m_Namespace}.{d.m_ClassName}".replace(":.", ":")
env = UnityPy.load(sys.argv[1])
cls = collections.Counter(); samples = {}; tt = collections.Counter(); ext = collections.Counter()
for o in env.objects:
    if o.type.name != "MonoBehaviour": continue
    p = o.read(check_read=False).m_Script
    ext[p.m_FileID] += 1
    name = smap.get(p.m_PathID, f"<script {p.m_FileID}/{p.m_PathID}>") if p.m_FileID == 1 else f"<ext{p.m_FileID}/{p.m_PathID}>"
    cls[name] += 1
    if name not in samples:
        try: samples[name] = o.read_typetree(); tt["ok"] += 1
        except Exception as e: samples[name] = None; tt[type(e).__name__] += 1
json.dump({"classes": cls.most_common(), "typetree": tt, "fileids": ext}, open(sys.argv[2], "w"), indent=1)
json.dump(samples, open(sys.argv[2].replace(".json", "_samples.json"), "w"), default=str)
print("classes", len(cls), "typetree", dict(tt), "fileids", dict(ext))
