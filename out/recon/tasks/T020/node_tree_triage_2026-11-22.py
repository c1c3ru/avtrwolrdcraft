"""Produces out/recon/tasks/T020/node_tree_triage_2026-11-22.json: a RAM-safe triage of the ~124
still-failing MonoBehaviour classes in out/mb/_stats.json (T020 family), done WITHOUT loading
x/base/assets/bin/Data/datapack.unity3d (the 1.3GB load that reliably OOMs this machine - see
LOOP_STATE.md 2026-11-21 and T020/CLASS/d723b7b66951bef8/attempt1-oom.log).

Insight: TypeTreeGenerator.get_nodes_as_json() only needs il2cpp_in/ (libil2cpp.so + global-metadata.dat,
~90MB total) plus x/base/assets/bin/Data/data.unity3d (16MB, just for MonoScript name->assembly lookup) -
neither of which caused any OOM in this session. Generating the type-tree nodes for a class and checking
whether tools/mb_dump.py's fix_mislabeled_vectors finds/fixes a List<String> field tells us, per class,
whether the already-landed fix (PR #64) is likely to resolve it - without touching any actual object data.

This is a HYPOTHESIS CHECK, not a resolution: acceptance for each T020/CLASS task still requires reading
real objects with check_read=True (needs the datapack, which needs more RAM than this machine reliably has).
Do not mark any of the "same_bug_likely_fixed" classes done/evidence_ready from this alone.

Requer il2cpp_in/ e x/ extraidos na raiz do repo (gitignored - ver docstring de tools/mb_retry_failed_classes.py
para o passo a passo de extracao a partir das APKs). Num worktree, esses diretorios normalmente so existem no
checkout principal (nao sao copiados pro worktree); rode a partir do checkout principal ou ajuste ROOT.

uso: python3 out/recon/tasks/T020/node_tree_triage_2026-11-22.py
"""
import json
from pathlib import Path
import UnityPy
from UnityPy.helpers.TypeTreeGenerator import TypeTreeGenerator

ROOT = Path(__file__).resolve().parents[4]

# TypeTreeGeneratorAPI's native extension prints its own diagnostic (e.g. 'Type "X" was not found in
# the IL2CPP metadata.' or 'Object reference not set to an instance of an object.') straight to the
# process's real stdout fd, separately from the generic Python exception it then raises - redirecting
# fd 1 around the call to capture it reliably was tried and did NOT work (the native code appears to
# write before Python-level flush/dup2 takes effect in a way that isn't consistently interceptable
# this way). So this script only records the generic Python-side exception text; for the real native
# message, rerun with that one class in isolation and read the terminal directly, or see
# out/recon/tasks/T020/node_tree_triage_2026-11-22.json's "native_message" field, captured manually on
# 2026-11-22 for the classes that failed node generation in that run.


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


def main():
    stats = json.loads((ROOT / "out/mb/_stats.json").read_text(encoding="utf-8"))
    remaining = list(stats["erros"].items())

    g = TypeTreeGenerator("2022.3.70f1")
    g.load_il2cpp((ROOT / "il2cpp_in/libil2cpp.so").read_bytes(),
                  (ROOT / "il2cpp_in/global-metadata.dat").read_bytes())
    base = UnityPy.load(str(ROOT / "x/base/assets/bin/Data/data.unity3d"))
    scripts = {}
    for o in base.objects:
        if o.type.name == "MonoScript":
            s = o.read()
            cname = f"{s.m_Namespace}.{s.m_ClassName}".strip(".")
            scripts[cname] = (s.m_AssemblyName.removesuffix(".dll"), s.m_Namespace, s.m_ClassName)

    results = {}
    for cname, err in remaining:
        entry = scripts.get(cname)
        if entry is None:
            results[cname] = {"original_error": err, "triage": "class_not_in_base_data_unity3d_MonoScripts"}
            continue
        asm, ns, cls = entry
        full = f"{ns}.{cls}" if ns else cls
        try:
            nodes = json.loads(g.get_nodes_as_json(asm, full))
        except Exception as e:
            results[cname] = {"original_error": err, "triage": "node_generation_failed",
                               "python_exception": f"{type(e).__name__}: {e}",
                               "note": "rerun this one class alone and read stdout for the real native message"}
            continue
        for n in nodes:
            if n["m_Name"] == "m_Enabled" and n["m_Level"] == 1:
                n["m_MetaFlag"] = 16384
        fixed_fields = fix_mislabeled_vectors(nodes)
        results[cname] = {
            "original_error": err,
            "triage": "same_bug_likely_fixed" if fixed_fields else "different_root_cause",
            "mislabeled_fields_found": fixed_fields,
        }

    out_path = ROOT / "out/recon/tasks/T020/node_tree_triage_2026-11-22.json"
    out_path.write_text(json.dumps(results, indent=1, ensure_ascii=False), encoding="utf-8")

    from collections import Counter
    print(Counter(v["triage"] for v in results.values()))


if __name__ == "__main__":
    main()
