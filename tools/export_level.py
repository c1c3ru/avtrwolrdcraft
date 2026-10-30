"""Exporta uma cena de UI (um arquivo serializado 'levelN' do datapack) para JSON + sprites PNG.

uso: export_level.py <level> <mbdir> <outdir>
  level  nome do arquivo serializado, ex.: level3
  mbdir  saida de mb_dump.py COM o campo _file (out/mb_v2 ou out/mb depois da troca)
  outdir recebe <level>.json e sprites/<arquivo>_<path_id>.png

Chaves sao sempre (arquivo serializado, path_id): o path_id colide entre arquivos.
Componentes sem suporte nao somem em silencio: saem em 'ignoredComponents' e no relatorio final.
"""
import collections, glob, gzip, json, os, sys

import UnityPy

level, mbdir, outdir = sys.argv[1:4]
os.makedirs(os.path.join(outdir, "sprites"), exist_ok=True)

# 1) MonoBehaviours deste level, indexados pelo GameObject dono
mb = collections.defaultdict(dict)
for f in glob.glob(os.path.join(mbdir, "*.jsonl.gz")):
    cls = os.path.basename(f)[: -len(".jsonl.gz")]
    for line in gzip.open(f, "rt"):
        r = json.loads(line)
        if "_file" not in r:
            sys.exit("mbdir sem campo _file: rode mb_dump.py atualizado")
        if r["_file"] == level:
            mb[r["m_GameObject"]["m_PathID"]][cls] = r

# 2) objetos do level + indice de todos os Sprites (podem estar em resources.assets)
env = UnityPy.load("x/data/assets/bin/Data/datapack.unity3d")
lvl_objs, sprites = {}, {}
externals = None
for o in env.objects:
    if o.assets_file.name == level:
        lvl_objs[o.path_id] = o
        if externals is None:
            externals = [os.path.basename(e.path) for e in o.assets_file.externals]
    elif o.type.name == "Sprite":
        sprites[(o.assets_file.name, o.path_id)] = o
if not lvl_objs:
    sys.exit(f"level {level} nao encontrado")
for o in lvl_objs.values():
    if o.type.name == "Sprite":
        sprites[(level, o.path_id)] = o


def resolve_file(file_id):
    return level if file_id == 0 else externals[file_id - 1]


v2 = lambda d: {"x": d["x"], "y": d["y"]}
col = lambda c: {"r": c["r"], "g": c["g"], "b": c["b"], "a": c["a"]}
tt = {}


def typetree(o):
    if o.path_id not in tt:
        tt[o.path_id] = o.read_typetree()
    return tt[o.path_id]


comp_type = {pid: o.type.name for pid, o in lvl_objs.items()}
sprite_files, missing_sprites = {}, []


def export_sprite(ptr):
    pid = ptr["m_PathID"]
    if not pid:
        return ""
    key = (resolve_file(ptr["m_FileID"]), pid)
    name = f"{key[0]}_{key[1]}"
    if name in sprite_files:
        return name
    o = sprites.get(key)
    if o is None:
        missing_sprites.append(name)
        return ""
    try:
        o.read().image.save(os.path.join(outdir, "sprites", name + ".png"))
    except Exception as e:  # sprite sem textura legivel
        missing_sprites.append(f"{name} ({type(e).__name__})")
        return ""
    sprite_files[name] = True
    return name


SUPPORTED = {"UnityEngine.UI.Image", "UnityEngine.UI.Button", "TMPro.TextMeshProUGUI", "UnityEngine.UI.Text"}
ignored = collections.Counter()
nodes = []


def build(tr_pid, parent_idx):
    tr_obj = lvl_objs[tr_pid]
    tr = typetree(tr_obj)
    go_pid = tr["m_GameObject"]["m_PathID"]
    go = typetree(lvl_objs[go_pid])
    idx = len(nodes)
    node = {
        "id": idx, "parent": parent_idx, "name": go["m_Name"], "active": bool(go["m_IsActive"]),
        "hasRect": tr_obj.type.name == "RectTransform",
        "isCanvas": any(comp_type.get(c["component"]["m_PathID"]) == "Canvas" for c in go["m_Component"]),
        "localScale": {"x": tr["m_LocalScale"]["x"], "y": tr["m_LocalScale"]["y"], "z": tr["m_LocalScale"]["z"]},
        "localRotation": {k: tr["m_LocalRotation"][k] for k in "xyzw"},
        "localPosition": {k: tr["m_LocalPosition"][k] for k in "xyz"},
        "hasImage": False, "image": {}, "hasText": False, "text": {}, "hasButton": False, "button": {},
        "ignoredComponents": [],
    }
    if node["hasRect"]:
        node.update(anchorMin=v2(tr["m_AnchorMin"]), anchorMax=v2(tr["m_AnchorMax"]), pivot=v2(tr["m_Pivot"]),
                    anchoredPosition=v2(tr["m_AnchoredPosition"]), sizeDelta=v2(tr["m_SizeDelta"]))
    comps = mb.get(go_pid, {})
    if "UnityEngine.UI.Image" in comps:
        r = comps["UnityEngine.UI.Image"]
        node["hasImage"] = True
        node["image"] = {"sprite": export_sprite(r["m_Sprite"]), "color": col(r["m_Color"]), "imageType": r["m_Type"],
                         "raycastTarget": bool(r["m_RaycastTarget"]), "preserveAspect": bool(r["m_PreserveAspect"]),
                         "enabled": bool(r["m_Enabled"])}
    if "TMPro.TextMeshProUGUI" in comps:
        r = comps["TMPro.TextMeshProUGUI"]
        node["hasText"] = True
        node["text"] = {"text": r["m_text"], "fontSize": r["m_fontSize"], "color": col(r["m_fontColor"]),
                        "hAlign": r["m_HorizontalAlignment"], "vAlign": r["m_VerticalAlignment"],
                        "autoSize": bool(r["m_enableAutoSizing"]), "minSize": r["m_fontSizeMin"],
                        "maxSize": r["m_fontSizeMax"], "enabled": bool(r["m_Enabled"])}
    elif "UnityEngine.UI.Text" in comps:
        r = comps["UnityEngine.UI.Text"]
        node["hasText"] = True
        node["text"] = {"text": r["m_Text"], "fontSize": float(r["m_FontData"]["m_FontSize"]), "color": col(r["m_Color"]),
                        "hAlign": 2, "vAlign": 512, "autoSize": False, "minSize": 0, "maxSize": 0,
                        "enabled": bool(r["m_Enabled"])}
    if "UnityEngine.UI.Button" in comps:
        r = comps["UnityEngine.UI.Button"]
        calls = [{"method": c.get("m_MethodName", ""), "type": c.get("m_TargetAssemblyTypeName", "")}
                 for c in r["m_OnClick"]["m_PersistentCalls"]["m_Calls"]]
        node["hasButton"] = True
        node["button"] = {"interactable": bool(r["m_Interactable"]), "onClick": calls}
    for cls in comps:
        if cls not in SUPPORTED:
            node["ignoredComponents"].append(cls)
            ignored[cls] += 1
    nodes.append(node)
    for ch in tr["m_Children"]:
        build(ch["m_PathID"], idx)


roots = [pid for pid, o in lvl_objs.items()
         if o.type.name in ("Transform", "RectTransform") and typetree(o)["m_Father"]["m_PathID"] == 0]
for pid in roots:
    build(pid, -1)

json.dump({"name": level, "nodes": nodes}, open(os.path.join(outdir, level + ".json"), "w"), indent=1)
print(f"{level}: {len(nodes)} nos, {len(roots)} raizes, {len(sprite_files)} sprites exportados, "
      f"{len(missing_sprites)} sprites ausentes")
print("componentes ignorados:", ignored.most_common(12))
if missing_sprites:
    print("ausentes (amostra):", missing_sprites[:5])
