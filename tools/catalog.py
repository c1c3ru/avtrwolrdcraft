import sys, collections, json, UnityPy
env = UnityPy.load(sys.argv[1])
counts = collections.Counter()
names = collections.defaultdict(list)
for o in env.objects:
    counts[o.type.name] += 1
    if len(names[o.type.name]) < 8 and o.type.name in ("GameObject","Texture2D","Mesh","AudioClip","Shader","MonoBehaviour","AnimationClip","Material"):
        try:
            d = o.read(); names[o.type.name].append(getattr(d, "m_Name", "") or "")
        except Exception as e:
            names[o.type.name].append(f"<err {e.__class__.__name__}>")
print(json.dumps({"total": sum(counts.values()), "types": counts.most_common(20), "samples": names}, indent=1))
