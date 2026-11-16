#!/usr/bin/env python3
"""Smoke dos 6 mundos do seletor (Campus, Bairro, Cidade, Fazenda, Resort, Montanha) no aparelho (adb).

Para cada mundo: abre o seletor (globo), toca no icone, espera carregar e VALIDA a troca pelo log do jogo
`WorldMap: <N> elementos, <M> predios` contra os dados do mapa (Resources/Maps/*/*.json e WorldSlice/world.json);
confere que o app segue vivo e sem FATAL, e salva a captura. Um mundo cujo log nao bate fica "nao verificado".

Uso: python3 tools/device_worlds_smoke.py --assets client/AvatarWorldClient/Assets \
        [--package com.c1c3ru.avatarworldoffline.test] [--out out/device/tests/worlds]
Saida: <out>/worlds_report.json. Exit 0 = todos os mundos verificados e vivos.
"""
import argparse, json, re, subprocess, sys, time
from pathlib import Path

GLOBE = (468, 95)
PLAY = (1830, 530)
# ordem do seletor (WorldMapRuntime.Maps): nome, json, x do icone na faixa inicial; a faixa mostra ~4 icones
WORLDS = [
    ("Campus", "Resources/Maps/college/college.json"),
    ("Bairro", "Resources/WorldSlice/world.json"),
    ("Cidade", "Resources/Maps/stardust/stardust.json"),
    ("Fazenda", "Resources/Maps/countryside/countryside.json"),
    ("Resort", "Resources/Maps/vacation/vacation.json"),
    ("Montanha", "Resources/Maps/snowy/snowy.json"),
]
ICON_X0, ICON_STEP = 640, 145
SCROLLED_ICON_X = {"Resort": 1000, "Montanha": 1132}  # com a faixa rolada ate o fim
STRIP_VISIBLE_MAX_X = 1150
FATAL = ("FATAL EXCEPTION", "ANR in", "Fatal signal", "SIGSEGV")


def main():
    ap = argparse.ArgumentParser()
    ap.add_argument("--assets", default="client/AvatarWorldClient/Assets")
    ap.add_argument("--package", default="com.c1c3ru.avatarworldoffline.test")
    ap.add_argument("--out", default="out/device/tests/worlds")
    ap.add_argument("--load-wait", type=float, default=14)
    a = ap.parse_args()
    assets, out = Path(a.assets), Path(a.out)
    out.mkdir(parents=True, exist_ok=True)

    def adb(*args, binary=False):
        r = subprocess.run(["adb"] + list(args), capture_output=True)
        return r.stdout if binary else r.stdout.decode("utf-8", "replace")

    if "\tdevice" not in adb("devices"):
        print("sem aparelho adb")
        return 2

    expected = {}
    for name, path in WORLDS:
        d = json.loads((assets / path).read_text())
        expected[name] = (len(d["renderers"]), len(d["buildings"]))

    adb("shell", "am", "force-stop", a.package)
    adb("shell", "monkey", "-p", a.package, "-c", "android.intent.category.LAUNCHER", "1")
    time.sleep(25)
    adb("shell", "input", "tap", str(PLAY[0]), str(PLAY[1]))
    time.sleep(9)

    results = []
    for idx, (name, _) in enumerate(WORLDS):
        want_el, want_b = expected[name]
        x = ICON_X0 + ICON_STEP * idx
        adb("logcat", "-c")
        adb("shell", "input", "tap", str(GLOBE[0]), str(GLOBE[1]))
        time.sleep(2)
        scrolled = 0
        if x > STRIP_VISIBLE_MAX_X:
            # icone fora da faixa: arrasta a faixa ate o limite (ela so rola ~220 px; medido no aparelho). Depois disso
            # Resort fica em x~1000 e Montanha em x~1132, nao onde a posicao inicial sugere.
            scrolled = 600
            adb("shell", "input", "swipe", "1100", "95", str(1100 - scrolled), "95", "500")
            time.sleep(1)
            x = SCROLLED_ICON_X[name]
        adb("shell", "input", "tap", str(x), "95")
        time.sleep(a.load_wait)
        log = adb("logcat", "-d", "-s", "Unity")
        m = list(re.finditer(r"WorldMap: (\d+) elementos, (\d+) predios", log))
        got = (int(m[-1].group(1)), int(m[-1].group(2))) if m else None
        shot = out / f"world_{idx}_{name}.png"
        shot.write_bytes(adb("exec-out", "screencap", "-p", binary=True))
        alive = bool(adb("shell", "pidof", a.package).strip())
        fatal = [l[:160] for l in adb("logcat", "-d").splitlines() if any(f in l for f in FATAL) and a.package in l][:2]
        verified = got == (want_el, want_b)
        results.append({"world": name, "icon_tap": [x, 95], "strip_scrolled_px": scrolled,
                        "expected": {"elements": want_el, "buildings": want_b},
                        "logged": None if got is None else {"elements": got[0], "buildings": got[1]},
                        "verified_by_log": verified, "alive": alive, "fatal": fatal, "screenshot": shot.name,
                        "note": "" if verified else "sem log de troca (mundo ja selecionado?) ou log diferente do esperado"})
        print(f"{'OK ' if verified and alive and not fatal else 'FAIL'} {name:9s} esperado={want_el}/{want_b} log={got} vivo={alive}", flush=True)
        if not alive:
            break

    ok = all(r["verified_by_log"] and r["alive"] and not r["fatal"] for r in results) and len(results) == len(WORLDS)
    (out / "worlds_report.json").write_text(json.dumps({"package": a.package, "time": time.strftime("%FT%T%z"), "ok": ok, "worlds": results}, indent=2, ensure_ascii=False) + "\n")
    print("todos verificados" if ok else "ha mundos nao verificados ou com falha")
    return 0 if ok else 1


if __name__ == "__main__":
    sys.exit(main())
