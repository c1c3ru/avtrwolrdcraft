import json, UnityPy, traceback
from UnityPy.helpers.TypeTreeGenerator import TypeTreeGenerator

def fix_mislabeled_vectors(nodes):
    n = len(nodes)
    fixed = []
    for i, node in enumerate(nodes):
        if node["m_Type"] != "string":
            continue
        lvl = node["m_Level"]
        j = i + 1
        children = []
        while j < n and nodes[j]["m_Level"] > lvl:
            if nodes[j]["m_Level"] == lvl + 1:
                children.append(nodes[j])
            j += 1
        if not children or children[0]["m_Name"] != "Array":
            continue
        arr_lvl = children[0]["m_Level"]
        k = i + 2
        arr_children = []
        while k < n and nodes[k]["m_Level"] > arr_lvl:
            if nodes[k]["m_Level"] == arr_lvl + 1:
                arr_children.append(nodes[k])
            k += 1
        data_child = next((c for c in arr_children if c["m_Name"] == "data"), None)
        if data_child is not None and data_child["m_Type"] != "char":
            node["m_Type"] = "vector"
            fixed.append(node["m_Name"])
    return fixed

TARGETS = {
    "Game.Level.LevelOnSpecificPairAnimationBetweenSpecificAvatars",
    "Game.Level.LevelStaticConditionsResolverWithDropAreas",
    "Game.Level.LevelStaticConditionsResolver",
    "Game.Level.LevelSecretVehicleInWorldPositionListener",
    "Game.Level.LevelStaticConditionsResolverWithParkedVehicles",
    "BWYW.DailyTasksData",
    "BWYW.BWYWGiftData",
    "Game.Level.LevelRecipeSecret",
    "Game.Level.LevelItemConditionsResolver",
}

g = TypeTreeGenerator("2022.3.70f1")
g.load_il2cpp(
    open("/home/c1c3ru/avtrwolrdcraft/il2cpp_in/libil2cpp.so", "rb").read(),
    open("/home/c1c3ru/avtrwolrdcraft/il2cpp_in/global-metadata.dat", "rb").read(),
)
print("il2cpp loaded", flush=True)

base = UnityPy.load("/home/c1c3ru/avtrwolrdcraft/x/base/assets/bin/Data/data.unity3d")
scripts_by_pathid = {}
scripts_by_name = {}
for o in base.objects:
    if o.type.name == "MonoScript":
        s = o.read()
        cname = f"{s.m_Namespace}.{s.m_ClassName}".strip(".")
        entry = (s.m_AssemblyName.removesuffix(".dll"), s.m_Namespace, s.m_ClassName)
        scripts_by_pathid[o.path_id] = (cname, entry)
        scripts_by_name[cname] = entry
print("base scripts loaded:", len(scripts_by_pathid), flush=True)

nodes_cache = {}
def nodes_for(cname):
    if cname not in nodes_cache:
        asm, ns, cls = scripts_by_name[cname]
        full = f"{ns}.{cls}" if ns else cls
        nodes = json.loads(g.get_nodes_as_json(asm, full))
        for n in nodes:
            if n["m_Name"] == "m_Enabled" and n["m_Level"] == 1:
                n["m_MetaFlag"] = 16384
        fix_mislabeled_vectors(nodes)
        nodes_cache[cname] = nodes
    return nodes_cache[cname]

print("loading datapack...", flush=True)
env = UnityPy.load("/home/c1c3ru/avtrwolrdcraft/x/base/assets/bin/Data/datapack.unity3d")
print("datapack loaded", flush=True)

results = {}
seen = 0
for o in env.objects:
    if o.type.name != "MonoBehaviour":
        continue
    raw = o.read(check_read=False)
    pid = raw.m_Script.m_PathID
    entry = scripts_by_pathid.get(pid)
    if entry is None:
        continue
    cname, (asm, ns, cls) = entry
    if cname not in TARGETS:
        continue
    seen += 1
    rec = results.setdefault(cname, {"ref_types_present": None, "ref_types_count": None,
                                       "objects": []})
    af = o.assets_file
    rec["ref_types_present"] = af.ref_types is not None
    rec["ref_types_count"] = len(af.ref_types) if af.ref_types else 0
    obj_rec = {"path_id": o.path_id, "file": af.name, "byte_size": o.byte_size}
    try:
        nodes = nodes_for(cname)
        d = o.read_typetree(nodes, check_read=True)
        obj_rec["status"] = "ok"
    except Exception as e:
        obj_rec["status"] = "error"
        obj_rec["error"] = f"{type(e).__name__}: {e}"
    rec["objects"].append(obj_rec)
    print(f"[{seen}] {cname} path_id={o.path_id} file={af.name} ref_types={rec['ref_types_count']} -> {obj_rec['status']}", flush=True)

json.dump(results, open("/home/c1c3ru/avtrwolrdcraft/.claude/worktrees/gentle-squishing-bird/out/recon/tasks/T020/serializeref_probe_2026-11-22.json", "w"), indent=1, ensure_ascii=False)
print("DONE", {k: len(v["objects"]) for k, v in results.items()}, flush=True)
