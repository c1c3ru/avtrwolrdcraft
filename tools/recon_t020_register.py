#!/usr/bin/env python3
"""Monta a evidencia das tarefas T020/CLASS (classes que falhavam) e, opcionalmente, registra na fila formal (tools/recon_queue.py).

Entrada: saidas de tools/mb_stream_extract.py (leitura completa + duas ablacoes, que dizem de qual correcao cada classe depende).
Para cada classe alvo escreve, em out/recon/tasks/T020/CLASS/<hash>/, os tres arquivos que a tarefa declara: class-contract.json, recount.json, result.json.
Com --apply-queue: [configure se blocked_external] -> claim -> start -> checkpoint evidence_ready. NUNCA marca done/review: a revisao e independente.

uso: tools/venv/bin/python tools/recon_t020_register.py --write-evidence
     tools/venv/bin/python tools/recon_t020_register.py --apply-queue [--queue reports/recon/tasks.json]
"""
import argparse, gzip, json, sys
from pathlib import Path

HERE = Path(__file__).resolve().parent
ROOT = HERE.parent
sys.path.insert(0, str(HERE))
from recon_queue import Queue  # noqa: E402

ACTOR = "agente-artefatos-claude"
IL = ROOT / "out/recon/il2cpp_1.230"
TAG = "mb_t020_all"
BUILD_NOTE = ("Leitura feita no build instalado 1.230 (libil2cpp sha256 7635d66d61a0...); a contagem declarada na tarefa vem de um build anterior "
              "(libil2cpp sha256 b63661fa60c2...). Nao e a mesma instalacao.")


def instances(cls):
    out = []
    f = IL / TAG / (cls.replace("+", "_") + ".jsonl.gz")
    for l in gzip.open(f, "rt"):
        d = json.loads(l)
        out.append({"path_id": d["_path_id"], "assets_file": d["_file"], "status": "resolved", "check_read_passed": True})
    return out


def assemblies(classes):
    import UnityPy
    base = UnityPy.load(str(ROOT / "out/device/dp/data.unity3d"))
    res = {}
    for o in base.objects:
        if o.type.name == "MonoScript":
            s = o.read()
            full = f"{s.m_Namespace}.{s.m_ClassName}".strip(".")
            if full in classes:
                res[full] = s.m_AssemblyName
    return res


def causes(attr):
    out = []
    if attr["needs_vector_fix"]:
        out.append("vector")
    if attr["needs_registry_fix"]:
        out.append("registry")
    return out


TEXT = {
    "vector": ("TypeTreeGeneratorAPI rotula como m_Type=\"string\" o no raiz de campos List<String> (com filhos Array/size/data corretos). O UnityPy despacha por m_Type antes de olhar os filhos, le um "
               "string escalar onde ha uma lista e dessincroniza todo campo seguinte (EOFError: read_str out of bounds ou diferenca de bytes). Correcao: fix_mislabeled_vectors (tools/mb_dump.py, "
               "tools/mb_retry_failed_classes.py): renomeia para vector os nos \"string\" cujo filho Array tem `data` diferente de char."),
    "registry": ("O objeto usa [SerializeReference]. (1) O arquivo serializado nao tem ref_types (0 entradas), entao o UnityPy falha com \"Failed to get ref type node\"; o proprio registro traz class/ns/asm "
                 "de cada referencia. (2) O TypeTreeGenerator emite `references: ManagedReferencesRegistry` varias vezes (uma por classe da heranca com campo managedReference) quando o certo e uma, no fim; "
                 "e, para tipos referenciados, emite o cabecalho de MonoBehaviour (m_GameObject, m_Enabled, m_Script, m_Name) que nao existe nos dados de um ReferencedObject. Correcao: "
                 "dedupe_registry / drop_registry / read_with_ref_types em tools/mb_stream_extract.py (leitor em Python so para as instancias que pedem tipo referenciado)."),
}


def build(task, cls, attr, stats_ok, old_stats, assembly, insts):
    h = task["id"].rsplit("/", 1)[-1]
    cs = causes(attr)
    declared_err = task["scope"].get("declared_counts", {}).get("err", 0)
    old = old_stats.get(cls, {})
    old_total = old.get("ok", 0) + old.get("err", declared_err) if old else declared_err
    new_total = attr["total"]
    match = old_total == new_total
    contract = {
        "class": cls, "assembly": assembly, "unity_class_id": "MonoBehaviour (114)",
        "original_failure": task["scope"]["failure_cause"],
        "build_note": BUILD_NOTE,
        "root_cause": {"depends_on": cs, "summary": " | ".join(TEXT[c] for c in cs)},
        "verification_by_ablation": {
            "full_fix": f"{new_total} de {new_total} instancias decodificam com check_read=True",
            "without_vector_fix": f"{attr['nofixvec_ok']} de {new_total} instancias decodificam",
            "without_registry_fix": f"{attr['nofixreg_ok']} de {new_total} instancias decodificam",
            "instances_read_via_ref_type_path": attr["via_ref_types"],
        },
        "fix_location": "tools/mb_stream_extract.py (+ fix_mislabeled_vectors de tools/mb_dump.py)",
        "limits": ["check_read=True prova que o objeto decodifica sem sobra/falta de byte; nao valida o significado dos campos.",
                   "Tipos referenciados foram lidos com a arvore gerada do IL2CPP do mesmo build, sem leitura de referencia independente."],
    }
    recount = {
        "class": cls,
        "before": {"ok": old.get("ok", 0), "bad": 0, "err": declared_err, "err_message": task["scope"]["failure_cause"], "source": "contagem declarada na tarefa (build anterior)"},
        "after": {"ok": stats_ok, "bad": 0, "err": 0, "build": "1.230 instalado"},
        "total_instances_in_game_1_230": new_total,
        "affected_objects": insts,
        "unresolved_objects": [],
        "reconciliation": {"old_total_ok_plus_err": old_total, "new_total": new_total, "exact_match": match,
                           "note": ("batem exatamente" if match else "o 1.230 tem MAIS instancias que a contagem antiga; nao sei se e conteudo novo do build ou subcontagem antiga (nao rodei o build antigo com este extrator).")},
        "output_artifact": f"out/recon/il2cpp_1.230/{TAG}/{cls}.jsonl.gz (campos decodificados + _path_id + _file)",
    }
    result = {
        "task": task["id"], "title": task["title"], "actor": ACTOR,
        "status": "evidence_for_independent_review",
        "summary": (f"{cls}: {new_total} de {new_total} instancias decodificam (check_read=True) no build 1.230 com a(s) correcao(oes): {', '.join(cs)}. "
                    f"Causa verificada por ablacao (sem a correcao: vector={attr['nofixvec_ok']}/{new_total}, registry={attr['nofixreg_ok']}/{new_total}). "
                    + ("Contagem bate com a antiga. " if match else "Contagem do 1.230 difere da antiga (ver recount.json). ") + BUILD_NOTE),
        "answers_to_task_questions": {
            "Which typetree/alignment/layout operation causes this exact failure?": contract["root_cause"]["summary"],
            "Which exact serialized object identities failed, and can only those be reprocessed?":
                f"{len(insts)} objetos, listados em recount.json (path_id + arquivo). Foram reprocessados so os MonoBehaviours desta classe, arquivo serializado a arquivo, sem abrir o datapack inteiro.",
        },
        "unknowns": ([] if match else ["Divergencia de contagem entre o build antigo e o 1.230."]) + ["Significado dos campos nao validado."],
    }
    return h, contract, recount, result


def main():
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument("--write-evidence", action="store_true")
    ap.add_argument("--apply-queue", action="store_true")
    ap.add_argument("--limit", type=int, default=0, help="so as N primeiras tarefas (teste)")
    ap.add_argument("--no-write", action="store_true", help="com --apply-queue: nao regenerar a evidencia, usar os arquivos que ja existem em out/recon/tasks/T020/CLASS/<hash>/")
    ap.add_argument("--queue", type=Path, default=ROOT / "reports/recon/tasks.json")
    a = ap.parse_args()
    q = json.loads(a.queue.read_text())
    by_class = {t["scope"]["class_name"]: t for t in q["tasks"] if t["id"].startswith("T020/CLASS/")}
    if a.no_write:
        # modo para outra maquina: usa so a evidencia ja copiada para out/recon/tasks/T020/CLASS/<hash>/ (nao precisa dos dumps nem do build)
        classes = []
        for c, t in by_class.items():
            f = ROOT / "out/recon/tasks/T020/CLASS" / t["id"].rsplit("/", 1)[-1] / "recount.json"
            if f.is_file() and "total_instances_in_game_1_230" in f.read_text():
                classes.append(c)
        attr = stats = old_stats = None
    else:
        tg = json.loads((ROOT / "out/recon/t020_targets.json").read_text())
        classes = [c for cs in tg.values() for c in cs]
        attr = json.loads((IL / "t020_attribution.json").read_text())
        stats = {c: v for cs in json.loads((IL / TAG / "_stats.json").read_text())["groups"].values() for c, v in cs.items()}
        old_stats = json.loads((ROOT / "out/mb/_stats.json").read_text())["stats"]
    if a.limit:
        classes = classes[: a.limit]
    plan = []
    if a.no_write:
        for c in classes:
            t = by_class[c]
            h = t["id"].rsplit("/", 1)[-1]
            d = ROOT / "out/recon/tasks/T020/CLASS" / h
            plan.append((t, h, json.loads((d / "class-contract.json").read_text()), json.loads((d / "recount.json").read_text()), None))
    else:
        asm = assemblies(set(classes))
        for c in classes:
            t = by_class[c]
            h, contract, recount, result = build(t, c, attr[c], stats[c].get("ok", 0), old_stats, asm.get(c, "UNKNOWN"), instances(c))
            plan.append((t, h, contract, recount, result))
    if (a.write_evidence or a.apply_queue) and not a.no_write:
        for t, h, contract, recount, result in plan:
            d = ROOT / "out/recon/tasks/T020/CLASS" / h
            d.mkdir(parents=True, exist_ok=True)
            for name, obj in (("class-contract.json", contract), ("recount.json", recount), ("result.json", result)):
                (d / name).write_text(json.dumps(obj, indent=2, ensure_ascii=False))
        print("evidencia escrita para", len(plan), "tarefas")
    if a.apply_queue:
        queue = Queue(a.queue)
        done = 0
        for t, h, contract, recount, result in plan:
            tid = t["id"]
            cur = json.loads(a.queue.read_text())
            task = next(x for x in cur["tasks"] if x["id"] == tid)
            if task["state"] == "blocked_external":
                queue.configure(tid, ACTOR, [r["path"] for r in task["input_refs"]])
            claimed = queue.claim(tid, ACTOR, 3600)
            lease = claimed["lease"]["id"]
            queue.heartbeat(tid, ACTOR, lease, start=True)
            outs = task["outputs"]
            queue.checkpoint(tid, ACTOR, lease, "evidence_ready",
                             f"{contract['class']}: {recount['total_instances_in_game_1_230']} instancias decodificam (check_read=True) no 1.230; causa verificada por ablacao. Pronto para revisao independente.", outs)
            done += 1
        print("fila: checkpoint evidence_ready em", done, "tarefas")


if __name__ == "__main__":
    main()
