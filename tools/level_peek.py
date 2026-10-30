import sys, collections, UnityPy
lvl = sys.argv[1]
env = UnityPy.load("x/data/assets/bin/Data/datapack.unity3d")
base = UnityPy.load("x/base/assets/bin/Data/data.unity3d")
smap = {o.path_id: o.read().m_ClassName for o in base.objects if o.type.name == "MonoScript"}
objs = [o for o in env.objects if o.assets_file.name == lvl]
cnt = collections.Counter(o.type.name for o in objs)
print(lvl, "objetos", len(objs), dict(cnt.most_common(8)))
go = {o.path_id: o.read().m_Name for o in objs if o.type.name == "GameObject"}
cls = collections.Counter()
for o in objs:
    if o.type.name == "MonoBehaviour":
        cls[smap.get(o.read(check_read=False).m_Script.m_PathID, "?")] += 1
print("scripts:", cls.most_common(14))
print("GameObjects:", [n for n in go.values()][:50])
