#!/usr/bin/env python3
"""Resume local avatar investigations; no installation, gameplay or APK build is implicit."""
from __future__ import annotations

import argparse
import hashlib
import importlib.util
import json
import os
from pathlib import Path
import shutil
import signal
import subprocess
import sys
import tempfile
from datetime import datetime, timezone

ROOT = Path(__file__).resolve().parents[1]
OUT = ROOT / "out/avatar-pipeline"
PROJECT = ROOT / "client/AvatarWorldClient"
TEXT = ROOT / "assets/spine_textasset/TextAsset"
TEXTURES = ROOT / "assets/textures_png/Texture2D"
ATLAS = TEXT / "Avatar_Spine.atlas_109005.txt"
SKEL = TEXT / "Avatar_Spine.skel_108595.txt"
PRESETS = TEXT / "PremadeCharactersJson_109356.txt"
BUNDLE = ROOT / "assets/split_UnityDataAssetPack.apk"
INVENTORY_SCRIPT = ROOT / "tools/avatar_bundle_inventory.py"
SPINE_OUTPUT = ROOT / "out/avatar-spine-inventory.json"
RENDER_OUTPUT = ROOT / "out/avatar-render-probe.json"
BUNDLE_OUTPUT = ROOT / "out/assets/avatar-resources.json"
TEXTURE_FILES = (
    "MultiPack__Body_Outline_31883.png", "MultiPack__Body_Shadow_87873.png",
    "MultiPack__Body_Solid_99707.png", "MultiPack__Ear_Shadow_76723.png",
    "Eyes_01_1_Color_21563.png", "Eyes_01_1_P_18738.png",
    "Hair_Front_01_Color_56300.png", "Hair_Front_02_Color_21315.png",
)


def now():
    return datetime.now(timezone.utc).isoformat()


def atomic_json(path, value):
    path.parent.mkdir(parents=True, exist_ok=True)
    temporary = None
    try:
        with tempfile.NamedTemporaryFile("w", encoding="utf-8", dir=path.parent,
                                         prefix=path.name + ".", suffix=".tmp", delete=False) as stream:
            temporary = Path(stream.name)
            json.dump(value, stream, ensure_ascii=False, indent=2)
            stream.write("\n")
            stream.flush()
            os.fsync(stream.fileno())
        os.replace(temporary, path)
    finally:
        if temporary is not None and temporary.exists():
            temporary.unlink()


def read_json(path):
    try:
        return json.loads(path.read_text(encoding="utf-8"))
    except (OSError, ValueError) as error:
        return {"read_error": str(error)}


def state():
    value = read_json(OUT / "state.json")
    if not isinstance(value, dict) or "read_error" in value:
        return {"schema": 1, "steps": {}}
    value.setdefault("steps", {})
    return value


def save_step(name, value):
    current = state()
    current["steps"][name] = value
    current["updated_at"] = now()
    atomic_json(OUT / "state.json", current)


def file_info(path):
    try:
        stat = path.stat()
        return {"path": str(path), "size": stat.st_size, "mtime_ns": stat.st_mtime_ns,
                "file": path.is_file()}
    except OSError:
        return {"path": str(path), "missing": True}


def fingerprint(paths, extra=None):
    # Metadata signatures avoid hashing gigabytes on every resume. --force bypasses the cache.
    data = {"inputs": [file_info(path) for path in paths], "extra": extra}
    return hashlib.sha256(json.dumps(data, sort_keys=True).encode()).hexdigest()


def find_unity(requested):
    candidate = requested or shutil.which("unity")
    if not candidate:
        local = Path.home() / ".local/bin/unity"
        if local.is_file():
            candidate = str(local)
    if not candidate:
        return None
    resolved = shutil.which(candidate) or str(Path(candidate).expanduser().absolute())
    return resolved if Path(resolved).is_file() and os.access(resolved, os.X_OK) else None


def doctor(args, quiet=False):
    unity = find_unity(args.unity)
    has_unitypy = importlib.util.find_spec("UnityPy") is not None
    required = [BUNDLE, ATLAS, SKEL, PRESETS, INVENTORY_SCRIPT,
                PROJECT / "ProjectSettings/ProjectVersion.txt"]
    texture_inputs = [TEXTURES / name for name in TEXTURE_FILES]
    missing = [str(path) for path in required if not path.is_file()]
    missing_textures = [str(path) for path in texture_inputs if not path.is_file()]
    editor_sources = [PROJECT / "Assets/Editor/AvatarAssetProbe.cs",
                      PROJECT / "Assets/Editor/AvatarRenderProbe.cs"]
    missing_probes = [str(path) for path in editor_sources if not path.is_file()]
    result = {
        "checked_at": now(), "python": sys.executable, "python_version": sys.version,
        "unity_executable": unity, "unity_requested": args.unity,
        "unity_editor_version_requested": "6000.6.6f1",
        "unity_license_checked": False, "unity_editor_execution_checked": False,
        "UnityPy_available_in_this_python": has_unitypy,
        "inputs": [file_info(path) for path in required],
        "missing_inputs": missing, "missing_probe_sources": missing_probes,
        "missing_render_textures": missing_textures,
        "inventory_ready": BUNDLE.is_file() and INVENTORY_SCRIPT.is_file() and has_unitypy,
        "unity_probes_ready": bool(unity) and ATLAS.is_file() and SKEL.is_file()
                              and not missing_textures and not missing_probes,
        "notes": ["Does not install dependencies or execute Unity.",
                  "An executable named unity may be unrelated to Unity Editor; select the CLI or Editor explicitly if needed.",
                  "A present executable does not prove license, Android module or Editor availability.",
                  "No avatar editor, clothing gameplay or APK is produced by doctor."],
    }
    atomic_json(OUT / "doctor.json", result)
    save_step("doctor", {"status": "checked", "checked_at": result["checked_at"],
                         "report": str(OUT / "doctor.json")})
    if not quiet:
        print(json.dumps(result, ensure_ascii=False, indent=2))
    return result


def stop_process(process):
    if process.poll() is not None:
        return
    if os.name == "posix":
        try:
            os.killpg(process.pid, signal.SIGTERM)
            process.wait(timeout=10)
            return
        except ProcessLookupError:
            return
        except subprocess.TimeoutExpired:
            try:
                os.killpg(process.pid, signal.SIGKILL)
            except ProcessLookupError:
                pass
    else:
        process.kill()
    process.wait()


def run_step(name, argv, inputs, outputs, args):
    signature = fingerprint(inputs, argv)
    previous = state()["steps"].get(name, {})
    output_state = [file_info(path) for path in outputs]
    if (not args.force and previous.get("status") == "succeeded"
            and previous.get("input_signature") == signature
            and previous.get("outputs") == output_state
            and all(path.is_file() for path in outputs)):
        print(name + ": retomado; resultado anterior preservado (use --force para repetir).")
        return True
    entry = {"status": "running", "started_at": now(), "argv": argv,
             "input_signature": signature, "log": str(OUT / (name + ".log"))}
    save_step(name, entry)
    before = [file_info(path) for path in outputs]
    OUT.mkdir(parents=True, exist_ok=True)
    process = None
    error = None
    returncode = None
    try:
        with (OUT / (name + ".log")).open("w", encoding="utf-8") as log:
            process = subprocess.Popen(argv, cwd=ROOT, stdout=log, stderr=subprocess.STDOUT,
                                       start_new_session=os.name == "posix")
            try:
                returncode = process.wait(timeout=args.timeout)
            except subprocess.TimeoutExpired:
                stop_process(process)
                error = "timeout after " + str(args.timeout) + " seconds"
            except KeyboardInterrupt:
                stop_process(process)
                error = "interrupted by user"
    except OSError as exception:
        error = str(exception)
    after = [file_info(path) for path in outputs]
    if error is None and returncode != 0:
        error = "command exited with code " + str(returncode)
    if error is None:
        for path in outputs:
            result = read_json(path) if path.suffix == ".json" else None
            if not path.is_file() or (isinstance(result, dict) and "read_error" in result):
                error = "missing or invalid output: " + str(path)
                break
        if error is None and before == after:
            error = "outputs were not updated; existing artifacts do not prove this run succeeded"
    entry.update(status="succeeded" if error is None else "failed", finished_at=now(),
                 returncode=returncode, outputs=after, error=error)
    save_step(name, entry)
    print(name + ": " + entry["status"] + (" — " + error if error else ""))
    return error is None


def unity_argv(executable, method, log):
    # The CLI is lowercase 'unity'; the Editor executable is conventionally 'Unity'.
    direct_editor = Path(executable).name in ("Unity", "Unity.exe")
    editor_flags = ["-nographics", "-executeMethod", method]
    if direct_editor:
        return [executable, "-batchmode", "-quit", "-projectPath", str(PROJECT),
                "-logFile", str(log)] + editor_flags
    return [executable, "run", str(PROJECT), "--no-tail", "--log-file", str(log),
            "--"] + editor_flags


def probes(args, readiness=None):
    ready = readiness or doctor(args, quiet=True)
    if not ready["unity_probes_ready"]:
        save_step("probe", {"status": "blocked", "checked_at": now(),
                            "reason": "Missing Unity executable, probe source or local input; see doctor.json"})
        print("probe: pré-requisitos ausentes; consulte out/avatar-pipeline/doctor.json")
        return False
    common = [ATLAS, SKEL, PROJECT / "ProjectSettings/ProjectVersion.txt"]
    tasks = [
        ("inspect", "AvatarWorld.EditorTools.AvatarAssetProbe.Inspect",
         common + [PROJECT / "Assets/Editor/AvatarAssetProbe.cs"], [SPINE_OUTPUT]),
        ("render", "AvatarWorld.EditorTools.AvatarRenderProbe.Render",
         common + [PROJECT / "Assets/Editor/AvatarRenderProbe.cs"]
         + [TEXTURES / name for name in TEXTURE_FILES],
         [RENDER_OUTPUT, ROOT / "out/avatar-preview.png", ROOT / "out/avatar-preview-hair-2.png"]),
    ]
    # Unity has an exclusive lock per project: never run the probes in parallel.
    for name, method, inputs, outputs in tasks:
        log = OUT / (name + "-editor.log")
        argv = unity_argv(ready["unity_executable"], method, log)
        if not run_step(name, argv, inputs, outputs, args):
            return False
    return True


def report(args):
    inventory = read_json(SPINE_OUTPUT)
    render = read_json(RENDER_OUTPUT)
    bundle = read_json(BUNDLE_OUTPUT)
    summary = {"generated_at": now(), "pipeline_state": state(), "artifacts": {},
               "limitations": [
                   "Artifact presence alone does not prove this pipeline executed or that an avatar editor exists.",
                   "CPU render probe is not GPU, clothing gameplay, touch, persistence or Android validation.",
                   "Preset SkinName references may require external SUT mappings; missing FindSkin names are not automatically missing assets.",
                   "Texture names/dimensions can collide; preserve (serialized file, path_id) references.",
                   "This pipeline never installs packages, builds an APK or declares complete gameplay."]}
    if isinstance(inventory, dict) and "read_error" not in inventory:
        skins = inventory.get("skins", [])
        summary["artifacts"]["spine"] = {"path": str(SPINE_OUTPUT),
            "version": inventory.get("version"), "bones": inventory.get("bones"),
            "slots": inventory.get("slots"), "pages": inventory.get("pages"),
            "regions": inventory.get("regions"), "skins": len(skins),
            "animations": len(inventory.get("animations", []))}
        presets = read_json(PRESETS)
        if isinstance(presets, dict) and isinstance(presets.get("AvatarSpineDatas"), list):
            characters = [p for p in presets["AvatarSpineDatas"] if p.get("SpineType") == 1]
            names = {s.get("name") for s in skins}
            references = [s.get("SkinName") for p in characters for s in p.get("SkinsData", [])]
            summary["artifacts"]["preset_coverage"] = {
                "character_presets": len(characters), "skin_references": len(references),
                "references_absent_as_direct_skins": sum(name not in names for name in references)}
    else:
        summary["artifacts"]["spine"] = {"available": False, "detail": inventory}
    summary["artifacts"]["render"] = render
    summary["artifacts"]["bundle"] = ({"path": str(BUNDLE_OUTPUT), "entries": len(bundle)}
                                         if isinstance(bundle, list) else bundle)
    atomic_json(OUT / "report.json", summary)
    save_step("report", {"status": "generated", "finished_at": now(),
                         "report": str(OUT / "report.json")})
    print(json.dumps(summary, ensure_ascii=False, indent=2))
    return True


def parser():
    common = argparse.ArgumentParser(add_help=False)
    common.add_argument("--with-unity", action="store_true", help="Inclui probes Unity em all; probe já é explícito.")
    common.add_argument("--force", action="store_true", help="Repete etapas mesmo com estado anterior válido.")
    common.add_argument("--unity", metavar="PATH", help="Executável da CLI unity ou do Editor Unity.")
    common.add_argument("--timeout", type=float, default=1800, metavar="SECONDS",
                        help="Limite por processo, em segundos (padrão: 1800).")
    result = argparse.ArgumentParser(description=__doc__)
    sub = result.add_subparsers(dest="command", required=True)
    for name, help_text in (
        ("doctor", "Verifica entradas/dependências sem instalar nem executar Unity."),
        ("probe", "Executa Inspect e Render no Unity, em série."),
        ("report", "Resume inventários existentes, estado e limitações."),
        ("all", "doctor, inventário do bundle, probes opcionais e relatório."),
    ):
        sub.add_parser(name, parents=[common], help=help_text)
    return result


def main():
    cli = parser()
    args = cli.parse_args()
    if args.timeout <= 0:
        cli.error("--timeout deve ser positivo")
    if args.command == "doctor":
        readiness = doctor(args)
        return 0 if readiness["inventory_ready"] and not readiness["missing_inputs"] else 1
    if args.command == "report":
        report(args)
        return 0
    if args.command == "probe":
        ok = probes(args)
        report(args)
        return 0 if ok else 1
    readiness = doctor(args, quiet=True)
    ok = readiness["inventory_ready"]
    if ok:
        ok = run_step("bundle-inventory", [sys.executable, str(INVENTORY_SCRIPT)],
                      [BUNDLE, INVENTORY_SCRIPT], [BUNDLE_OUTPUT], args)
    else:
        save_step("bundle-inventory", {"status": "blocked", "checked_at": now(),
                                      "reason": "Missing APK, inventory script or UnityPy; see doctor.json"})
        print("bundle-inventory: pré-requisitos ausentes; consulte doctor.json")
    if args.with_unity and ok:
        ok = probes(args, readiness)
    elif not args.with_unity:
        print("Unity não solicitado; use all --with-unity para executar os probes.")
    report(args)
    return 0 if ok else 1


if __name__ == "__main__":
    raise SystemExit(main())
