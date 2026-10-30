"""(chave = arquivo serializado + path_id; path_id colide entre arquivos)
Acha raizes de hierarquia (Transform sem pai) no datapack, com tamanho da subarvore e nome. Saida: out/scene_roots.json"""
import json, collections, UnityPy
env = UnityPy.load("x/data/assets/bin/Data/datapack.unity3d")
father, go_of, names, comps = {}, {}, {}, {}
for o in env.objects:
    t = o.type.name
    if t in ("Transform", "RectTransform"):
        d = o.read(); k = (o.assets_file.name, o.path_id); father[k] = (o.assets_file.name, d.m_Father.m_PathID) if d.m_Father.m_PathID else None; go_of[k] = (o.assets_file.name, d.m_GameObject.m_PathID)
    elif t == "GameObject":
        d = o.read(); names[(o.assets_file.name, o.path_id)] = d.m_Name
children = collections.defaultdict(list)
for tr, f in father.items():
    if f: children[f].append(tr)
size = {}
def count(t):
    stack, n = [t], 0
    while stack:
        x = stack.pop(); n += 1; stack.extend(children.get(x, []))
    return n
roots = [t for t, f in father.items() if f is None]
out = [{"file": t[0], "transform": t[1], "go": go_of[t][1], "name": names.get(go_of[t], ""), "size": count(t)} for t in roots]
json.dump(out, open("out/scene_roots.json", "w"))
print("raizes", len(out), "transforms", len(father))
perfile = collections.Counter(); [perfile.update({r["file"]: r["size"]}) for r in out]
small = sorted(((n, f) for f, n in perfile.items() if f.startswith("level")))[:12]
print("menores levels (transforms, arquivo):", small)
