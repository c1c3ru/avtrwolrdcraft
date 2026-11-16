#!/usr/bin/env python3
"""Smoke de mapa + interiores no aparelho (adb): percorre os predios de um mapa, entra em cada
interior, captura a tela e coleta os logs `Interior:`/`WorldMap:` do logcat.

Como acerta os toques (sem adivinhar coordenadas): o mapa usa camera ortografica
(unidades = orthoSize*2/1080 por pixel), so se move em X (arraste) e a posicao persiste ao voltar
do interior. Com os dados do mapa (`world.json`/`<mapa>.json`) calculamos a posicao de tela de cada
predio e quanto arrastar. Validado no aparelho: o toque previsto abre o predio esperado.

Uso (apos instalar o APK e deixar o aparelho desbloqueado):
  python3 tools/device_world_smoke.py --assets client/AvatarWorldClient/Assets \
      [--package com.c1c3ru.avatarworldoffline.test] [--out out/device/tests/world_smoke] [--only Bank,Mall] [--limit N]
Saida: <out>/world_smoke_report.json e <out>/<nivel>_<nome>.png. Exit 0 = nenhum interior falhou.
"""
import argparse, json, re, subprocess, sys, time
from pathlib import Path

W, H = 2400, 1080
PLAY = (1830, 530)
BACK = (97, 95)
FATAL = ("FATAL EXCEPTION", "ANR in", "Fatal signal", "SIGSEGV")


def main():
    ap = argparse.ArgumentParser()
    ap.add_argument("--assets", default="client/AvatarWorldClient/Assets")
    ap.add_argument("--package", default="com.c1c3ru.avatarworldoffline.test")
    ap.add_argument("--out", default="out/device/tests/world_smoke")
    ap.add_argument("--map-json", default="Resources/WorldSlice/world.json")
    ap.add_argument("--only", default="", help="nomes (substring, separados por virgula)")
    ap.add_argument("--limit", type=int, default=0)
    ap.add_argument("--open-wait", type=float, default=7)
    a = ap.parse_args()

    assets = Path(a.assets)
    out = Path(a.out)
    out.mkdir(parents=True, exist_ok=True)
    data = json.loads((assets / a.map_json).read_text())
    cam = data["camera"]
    u = 2 * cam["orthoSize"] / H  # unidades de mundo por pixel
    half = cam["orthoSize"] * W / H
    catalog = {int(k): v for k, v in re.findall(
        r'\{\s*(\d+),\s*"([^"]+)"\s*\}', (assets / "Scripts/Core/World/InteriorCatalog.cs").read_text())}

    def adb(*args, binary=False):
        r = subprocess.run(["adb"] + list(args), capture_output=True)
        return r.stdout if binary else r.stdout.decode("utf-8", "replace")

    if "\tdevice" not in adb("devices"):
        print("sem aparelho adb")
        return 2

    def clamp(x):
        return min(max(x, cam["minX"] + half), cam["maxX"] - half)

    state = {"x": clamp(cam["startX"])}

    def launch():
        adb("shell", "am", "force-stop", a.package)
        adb("shell", "monkey", "-p", a.package, "-c", "android.intent.category.LAUNCHER", "1")
        time.sleep(22)
        adb("shell", "input", "tap", str(PLAY[0]), str(PLAY[1]))
        time.sleep(8)
        state["x"] = clamp(cam["startX"])

    def alive():
        return bool(adb("shell", "pidof", a.package).strip())

    import io
    import numpy as np
    from PIL import Image

    def grab():
        return Image.open(io.BytesIO(adb("exec-out", "screencap", "-p", binary=True))).convert("RGB")

    def measure_shift(a, b, expect):
        """Quanto o conteudo do mapa andou (px, positivo = para a direita) entre duas capturas.
        Cada arraste perde 45-80 px (folga de toque), entao medimos em vez de assumir."""
        ra = np.asarray(a.convert("L"), dtype=np.float32)[260:900, ::2]
        rb = np.asarray(b.convert("L"), dtype=np.float32)[260:900, ::2]
        best, bs = None, 0
        for s in range(int(expect) - 220, int(expect) + 221, 4):
            h = s // 2
            x, y = (ra[:, : ra.shape[1] - h], rb[:, h:]) if h >= 0 else (ra[:, -h:], rb[:, : rb.shape[1] + h])
            if x.shape[1] < 200:
                continue
            d = float(np.mean(np.abs(x[:, ::2] - y[:, ::2])))
            if best is None or d < best:
                best, bs = d, s
        return bs

    def pan_to(target_x):
        """Move a camera ate target_x em laco fechado: arrasta, mede o deslocamento real e corrige."""
        target_x = clamp(target_x)
        for _ in range(12):
            need = (target_x - state["x"]) / u  # px de camera ainda por andar (+ = direita)
            if abs(need) < 60:
                break
            px = int(min(1900, abs(need)))
            right = need > 0  # camera para a direita => arrasta para a esquerda
            x1, x2 = (2150, 2150 - px) if right else (250, 250 + px)
            before = grab()
            adb("shell", "input", "swipe", str(x1), "900", str(x2), "900", "700")
            time.sleep(1.0)
            after = grab()
            moved = -measure_shift(before, after, -px if right else px)  # px de camera, + = direita
            state["x"] = clamp(state["x"] + moved * u)
            if abs(moved) < 20:  # nao andou (limite do mapa)
                break
        time.sleep(0.5)

    def is_loading(im):
        small = np.asarray(im.resize((240, 108)), dtype=np.int16)
        yel = ((small[:, :, 0] > 220) & (small[:, :, 1] > 140) & (small[:, :, 1] < 235) & (small[:, :, 2] < 90)).mean()
        return yel > 0.35

    def is_map():
        """Mapa tem as pilulas claras (255,224,255) no topo; interior nao."""
        im = grab()
        pts = [(225, 95), (341, 95), (283, 40), (283, 150), (470, 40), (470, 150)]
        return sum(all(abs(c - t) <= 6 for c, t in zip(im.getpixel(p), (255, 224, 255))) for p in pts) >= 5

    targets = []
    for b in data["buildings"]:
        key = catalog.get(b["defaultLevel"])
        targets.append({"b": b, "key": key})
    only = [s.lower() for s in a.only.split(",") if s]
    if only:
        targets = [t for t in targets if any(s in t["b"]["name"].lower() for s in only)]
    with_interior = [t for t in targets if t["key"]]
    without = [t for t in targets if not t["key"]]
    with_interior.sort(key=lambda t: (t["b"]["x0"] + t["b"]["x1"]))
    if a.limit:
        with_interior = with_interior[: a.limit]

    launch()
    results = []
    for i, t in enumerate(with_interior, 1):
        b = t["b"]
        cx, cy = (b["x0"] + b["x1"]) / 2, (b["y0"] + b["y1"]) / 2
        pan_to(cx)
        sx = round(W / 2 + (cx - state["x"]) / u)
        # y visivel do predio, longe dos botoes do topo
        top = max(H / 2 - (b["y1"] - cam["startY"]) / u, 230)
        bot = min(H / 2 - (b["y0"] - cam["startY"]) / u, 1000)
        sy = round((top + bot) / 2) if top < bot else round(H / 2 - (cy - cam["startY"]) / u)
        sx = min(max(sx, 120), W - 120)
        rec = {"name": b["name"], "defaultLevel": b["defaultLevel"], "key": t["key"], "tap": [sx, sy], "cam_x": round(state["x"], 2)}
        adb("logcat", "-c")
        adb("shell", "input", "tap", str(sx), str(sy))
        time.sleep(a.open_wait)
        # a captura so vale depois da tela de carregamento (fundo amarelo/laranja) sair
        img = grab()
        for _ in range(12):
            if not is_loading(img):
                break
            time.sleep(2)
            img = grab()
        log = adb("logcat", "-d", "-s", "Unity")
        full = adb("logcat", "-d")
        shot = out / f"{b['defaultLevel']:03d}_{b['name']}.png"
        img.save(shot)
        m = re.search(r"Interior: (\d+) elementos, (\d+) itens", log)
        n = re.search(r"Interior: (\d+)/(\d+) NPCs", log)
        rec.update({
            "opened": bool(m),
            "elements": int(m.group(1)) if m else None,
            "items": int(m.group(2)) if m else None,
            "npcs_drawn": int(n.group(1)) if n else None,
            "npcs_total": int(n.group(2)) if n else None,
            "missing_sprites": len(re.findall(r"Interior: sprite ausente", log)),
            "npc_failures": len(re.findall(r"Interior: NPC \S+ falhou", log)),
            "fatal": [l[:160] for l in full.splitlines() if any(f in l for f in FATAL) and a.package in l][:2],
            "screenshot": shot.name,
        })
        rec["alive"] = alive()
        ok = rec["opened"] and rec["alive"] and not rec["fatal"]
        rec["ok"] = ok
        results.append(rec)
        print(f"[{i}/{len(with_interior)}] {'OK ' if ok else 'FAIL'} {b['name']} npcs={rec['npcs_drawn']}/{rec['npcs_total']} "
              f"missing={rec['missing_sprites']} npcfail={rec['npc_failures']}", flush=True)
        if not rec["alive"]:
            launch()
            continue
        adb("shell", "input", "tap", str(BACK[0]), str(BACK[1]))
        time.sleep(4)
        if not is_map():
            adb("shell", "input", "tap", str(BACK[0]), str(BACK[1]))
            time.sleep(4)
            if not is_map():
                print("  voltar nao retornou ao mapa; reiniciando o app", flush=True)
                launch()

    prev = out / "world_smoke_report.json"
    if (only or a.limit) and prev.exists():  # reexecucao parcial: troca so as entradas refeitas
        old = json.loads(prev.read_text())["results"]
        redone = {r["name"] for r in results}
        results = [r for r in old if r["name"] not in redone] + results
    report = {
        "package": a.package, "map": a.map_json, "time": time.strftime("%FT%T%z"),
        "tested": len(results), "ok": sum(r["ok"] for r in results),
        "without_interior_not_tapped": [t["b"]["name"] for t in without],
        "results": results,
    }
    (out / "world_smoke_report.json").write_text(json.dumps(report, indent=2, ensure_ascii=False) + "\n")
    bad = [r for r in results if not r["ok"]]
    print(f"\n{report['ok']}/{report['tested']} interiores abriram sem crash; "
          f"{sum(1 for r in results if r['npc_failures'])} com falha de NPC")
    return 1 if bad else 0


if __name__ == "__main__":
    sys.exit(main())
