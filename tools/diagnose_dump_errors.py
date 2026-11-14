"""Caracteriza a causa-raiz das classes com erro de dump (reports/recon/dump_coverage.json#error_classes):
tenta gerar o type-tree de cada uma via TypeTreeGenerator (mesma lib que tools/mb_dump.py usa) e classifica
o resultado. Nao reprocessa o bundle de 1,3 GB inteiro - so a geracao de nos, a partir de x/base (16 MB).
Resolve o assembly real de cada classe via MonoScript (como mb_dump.py faz), em vez de supor
"Assembly-CSharp": classes de pacotes (ex.: Spine.Unity) vivem em outros assemblies e falhariam por engano
se o assembly fosse fixo. Ver docs/RECON_DUMP_ERRORS_2026-11-07.md para a leitura dos resultados.

uso: diagnose_dump_errors.py
saida: out/recon/tasks/T020/error_class_diagnosis.json
"""
import json, os, tempfile, collections
from pathlib import Path
import UnityPy
from UnityPy.helpers.TypeTreeGenerator import TypeTreeGenerator

ROOT = Path(__file__).resolve().parent.parent
coverage = json.loads((ROOT / "reports/recon/dump_coverage.json").read_text())
classes = [e["class"] for e in coverage["error_classes"]]

# Namespace.Classe -> assembly real, via MonoScript (mesma fonte que mb_dump.py usa para o dump completo).
base = UnityPy.load(str(ROOT / "x/base/assets/bin/Data/data.unity3d"))
assembly_by_full_name = {}
for o in base.objects:
    if o.type.name != "MonoScript":
        continue
    s = o.read()
    full = f"{s.m_Namespace}.{s.m_ClassName}".strip(".")
    assembly_by_full_name[full] = s.m_AssemblyName.removesuffix(".dll")

g = TypeTreeGenerator("2022.3.70f1")
g.load_il2cpp((ROOT / "il2cpp_in/libil2cpp.so").read_bytes(), (ROOT / "il2cpp_in/global-metadata.dat").read_bytes())

results = []
real_stderr_fd = os.dup(2)
for full in classes:
    assembly = assembly_by_full_name.get(full, "Assembly-CSharp")
    tf = tempfile.TemporaryFile(mode="w+")
    os.dup2(tf.fileno(), 2)  # a lib nativa escreve erro direto no fd 2, nao no sys.stderr do Python
    status, detail = "ok", ""
    try:
        nodes = json.loads(g.get_nodes_as_json(assembly, full))
        if not nodes:
            status, detail = "empty_nodes", ""
    except Exception as e:
        status, detail = "python_exception", f"{type(e).__name__}: {str(e)[:160]}"
    os.dup2(real_stderr_fd, 2)
    tf.seek(0)
    captured = tf.read().strip()
    tf.close()
    if captured:
        detail = (captured.splitlines()[-1] + (" | " + detail if detail else ""))[:200]
        if status == "ok":
            status = "generator_stderr"
    results.append({"class": full, "assembly": assembly, "status": status, "detail": detail})
    print(f"{status:18s} {assembly:20s} {full}  {detail}", flush=True)
os.close(real_stderr_fd)

out = ROOT / "out/recon/tasks/T020/error_class_diagnosis.json"
out.parent.mkdir(parents=True, exist_ok=True)
out.write_text(json.dumps(results, indent=1, ensure_ascii=False))
print(f"\n-> {out}")
print(collections.Counter(r["status"] for r in results))
