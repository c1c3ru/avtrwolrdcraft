#!/usr/bin/env python3
"""Smoke test no aparelho via adb: abre o app, toca em Play, confere que continua vivo,
sem crash/FATAL no logcat, e salva capturas e um relatorio JSON.

Uso: python3 tools/device_smoke.py [--package com.c1c3ru.avatarworldoffline]
                                   [--out out/device/tests] [--serial SERIAL]
Saida: <out>/smoke_report.json (exit 0 = tudo passou, 1 = alguma checagem falhou,
2 = sem aparelho).
"""
import argparse, json, subprocess, sys, time
from pathlib import Path

PLAY_TAP = (1830, 530)  # botao Play da Home (tela logica 2400x1080)
FATAL = ("FATAL EXCEPTION", "ANR in", "Fatal signal", "signal 11", "SIGSEGV")


def main():
    ap = argparse.ArgumentParser()
    ap.add_argument("--package", default="com.c1c3ru.avatarworldoffline")
    ap.add_argument("--out", default="out/device/tests")
    ap.add_argument("--serial")
    ap.add_argument("--boot-wait", type=float, default=25)
    ap.add_argument("--nav-wait", type=float, default=8)
    a = ap.parse_args()
    adb = ["adb"] + (["-s", a.serial] if a.serial else [])
    out = Path(a.out)
    out.mkdir(parents=True, exist_ok=True)

    def sh(*args, binary=False):
        r = subprocess.run(adb + list(args), capture_output=True)
        return r.stdout if binary else r.stdout.decode("utf-8", "replace")

    if "\tdevice" not in sh("devices"):
        print("sem aparelho adb (conecte e autorize a depuracao USB)")
        return 2

    checks = []

    def check(name, ok, detail=""):
        checks.append({"name": name, "ok": bool(ok), "detail": detail})
        print(("PASS" if ok else "FAIL"), name, detail)

    def shot(name):
        (out / name).write_bytes(sh("exec-out", "screencap", "-p", binary=True))

    def crashes():
        log = sh("logcat", "-d")
        return [l[:200] for l in log.splitlines() if any(f in l for f in FATAL) and a.package in l]

    sh("shell", "am", "force-stop", a.package)
    sh("logcat", "-c")
    sh("shell", "monkey", "-p", a.package, "-c", "android.intent.category.LAUNCHER", "1")
    time.sleep(a.boot_wait)
    pid = sh("shell", "pidof", a.package).strip()
    check("launch: processo vivo", pid, f"pid={pid}")
    top = sh("shell", "dumpsys", "activity", "activities")
    check("launch: app em primeiro plano", a.package in next((l for l in top.splitlines() if "topResumedActivity" in l), ""))
    check("launch: sem crash", not crashes(), "; ".join(crashes()[:2]))
    shot("smoke_launch.png")

    sh("shell", "input", "tap", *map(str, PLAY_TAP))
    time.sleep(a.nav_wait)
    check("play: processo segue vivo", sh("shell", "pidof", a.package).strip())
    check("play: sem crash", not crashes(), "; ".join(crashes()[:2]))
    shot("smoke_after_play.png")

    mem = sh("shell", "dumpsys", "meminfo", a.package)
    total = next((l.split() for l in mem.splitlines() if l.strip().startswith("TOTAL ") and "PSS" not in l), None)
    pss_mb = round(int(total[1]) / 1024) if total else None
    check("memoria PSS < 1500 MB", pss_mb is not None and pss_mb < 1500, f"{pss_mb} MB")

    report = {"package": a.package, "checks": checks, "ok": all(c["ok"] for c in checks), "time": time.strftime("%FT%T%z")}
    (out / "smoke_report.json").write_text(json.dumps(report, indent=2, ensure_ascii=False) + "\n")
    return 0 if report["ok"] else 1


if __name__ == "__main__":
    sys.exit(main())
