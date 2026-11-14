#!/usr/bin/env python3
"""Generate independent, hash-pinned child specs for verified Stage handlers."""
import argparse
import hashlib
import json
from pathlib import Path
import sys

ROOT = Path(__file__).resolve().parents[1]
sys.path.insert(0, str(ROOT / "tools"))
import recon_navigation as nav

PRIOR = ROOT / "reports/recon/scene_subscribers.json"
FOLLOWUP = ROOT / "out/recon/tasks/T025/METHOD/8e708ca7d06e0b52/stage_candidate_analysis.json"
NATIVE = ROOT / "out/recon/il2cpp/libil2cpp.so"
METADATA = ROOT / "out/recon/il2cpp/global-metadata.dat"
INDEX = ROOT / "out/recon/il2cpp/metadata_methods.jsonl"
INPUTS = [PRIOR, FOLLOWUP, NATIVE, METADATA, INDEX]


def sha(path):
    return hashlib.sha256(path.read_bytes()).hexdigest()


def handler_rows():
    prior = json.loads(PRIOR.read_text(encoding="utf-8"))
    followup = json.loads(FOLLOWUP.read_text(encoding="utf-8"))
    handlers = {}
    for edge in prior["edges"]:
        if "OnBeforeSceneLoadStage" in edge["event"]:
            row = edge["handler"]
            handlers[row["method_definition_index"]] = row
    for candidate in followup["candidates"]:
        row = candidate["handler_resolution"]["handler"]
        handlers[row["method_definition_index"]] = row
    return sorted(handlers.values(), key=lambda row: row["method_definition_index"])


def build_manifest():
    binary, metadata = NATIVE.read_bytes(), METADATA.read_bytes()
    nav.verify_pair(binary, metadata)
    elf, meta = nav.Elf(binary), nav.Metadata(metadata)
    rows, resolve = nav.load_index(INDEX, elf, meta)
    by_def = {row["method_definition_index"]: row for row in rows}
    inputs = [{"path": path.relative_to(ROOT).as_posix(), "sha256": sha(path)} for path in INPUTS]
    tasks = []
    for handler in handler_rows():
        rid = handler["method_definition_index"]
        task_id = f"T025/HANDLER/{rid:08x}"
        task_dir = f"out/recon/tasks/T025/HANDLER/{rid:08x}"
        matches = resolve(int(handler["vaddr"], 16))
        nav.require(sum(1 for row in matches if row == handler) == 1,
                    "handler identity does not join to raw metadata/codegen pointer")
        raw = meta.tables["methods"]
        nav.require(0 <= rid < raw["count"], "handler MethodDef index outside metadata")
        spec = {
            "id": task_id, "parent_id": "T025",
            "title": f"Recuperar efeitos do callback {handler['declaring_type']}.{handler['name']} ({handler['token']})",
            "role": "lógica", "state": "pending", "dependencies": ["T001", "T022/PILOT_INDEX/b63661fa60c2"],
            "planning_seed": False, "evidence_refs": [], "attempts": [], "owner": None,
            "lease": None, "review": None, "unknown_ids": ["T029/handler_effects_lifetime"],
            "scope": {"method_identity": handler, "method_definition_index": rid,
                      "native_sha256": sha(NATIVE), "metadata_sha256": sha(METADATA),
                      "boundary_policy": "do not infer full extent from next MethodDef; recover reachable and noncontiguous/exception regions or leave partial",
                      "classification": "static_MethodDef_handler_edge_from_direct_Stage_candidate_scan"},
            "input_refs": inputs,
            "allowed_paths": [task_dir + "/**"],
            "outputs": [task_dir + "/method-contract.json", task_dir + "/control-flow.json",
                        task_dir + "/unknowns.jsonl", task_dir + "/result.json"],
            "input_and_steps": (
                "Revalidar os hashes do par e a identidade exata do MethodDef. Recuperar parâmetros/retorno, ranges e CFG, "
                "loads/stores, chamadas diretas e indiretas, callbacks, mutações de estado, condições e efeitos sob retorno normal; "
                "separar efeitos de callees/helpers e registrar erros/exceções não resolvidos. Usar LLVM local já instalado, "
                "sem compartilhar arquivos de saída. Criar pseudocódigo e testes de mutação/fixture. Não alterar o cliente. "
                "Se a janela, callback ou exceção não fechar, manter partial/ready e criar children com inputs e hashes exatos."
            ),
            "acceptance": (
                "Contrato e CFG justificam cada bloco/caminho alcançável e os limites de corpo/exceção; parâmetros, dados, "
                "chamadas e efeitos observáveis ligados a bytes/metadata; unknowns relevantes explicitados; fixtures/testes passam; "
                "revisão independente de fonte raw confirma o recorte. Qualquer helper/dispatch/region relevante aberto impede done."
            ),
            "questions": ["Qual estado cada ramo lê/escreve?", "Quais objetos/coleções são criados, destruídos ou alterados?",
                          "Quais delegates, eventos, coroutines e cenas são acionados?", "Quais guards/errors/exception paths afetam o fluxo?"],
            "next_action": "Executar prepare obrigatório; reivindicar apenas depois que as dependências T001/T022 estiverem aceitas; checkpoint partial se body/dispatch/efeitos externos continuarem abertos.",
            "resource_locks": [f"native-method-analysis:{rid:08x}"],
            "code_write_policy": "evidence-only; method-specific output directory; no client implementation"
        }
        tasks.append(spec)
    nav.require(len(tasks) == 12, "expected 12 unique Stage handler MethodDefs")
    nav.require(len({task["id"] for task in tasks}) == len(tasks), "handler task IDs not unique")
    nav.require(all(len(task["input_refs"]) == len(INPUTS) for task in tasks), "handler input reference omitted")
    return {"schema_version": 1, "kind": "child_planning_specs",
            "scope": "12 unique Stage callback MethodDefs from 13 static direct-registration edges; no recovered-handler semantics or acceptance claim.",
            "source_reports": [{"path": p.relative_to(ROOT).as_posix(), "sha256": sha(p)} for p in [PRIOR, FOLLOWUP]],
            "unique_handler_methoddefs": len(tasks), "registration_edges": 13,
            "deduplicated_handlers": len(tasks), "tasks": tasks}


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--output", type=Path, default=ROOT / "reports/recon/t025_stage_handler_children_2026-11-08.json")
    args = parser.parse_args()
    report = build_manifest()
    args.output.parent.mkdir(parents=True, exist_ok=True)
    args.output.write_text(json.dumps(report, ensure_ascii=False, indent=2) + "\n", encoding="utf-8")
    print(json.dumps({"tasks": len(report["tasks"]), "output": str(args.output),
                      "unique_handlers": report["deduplicated_handlers"]}))


if __name__ == "__main__":
    main()
