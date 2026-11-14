#!/usr/bin/env python3
"""Exporta o gradiente do ceu (PWC.BackgroundSky + BackgroundSkyConfig) para Resources/WorldSlice/sky.json.

Os 6 mapas usam as MESMAS configuracoes (clear 721800, rain 721802, snow 721803) e os mesmos parametros
(smoothness/middle). Cada config tem 4 transicoes de horario (nightToSunrise, sunriseToDay, dayToSunset,
sunsetToNight) com 4 cores de topo e 4 de base. Halloween (721801) nao entra (clima nao suportado no cliente).

uso: python3 tools/export_sky.py
"""
import gzip, json
from pathlib import Path

ROOT = Path(__file__).resolve().parent.parent
PHASES = ["nightToSunrise", "sunriseToDay", "dayToSunset", "sunsetToNight"]
WEATHERS = [(0, "clear", 721800, "_clearSmoothness", "_clearMiddle"),
            (1, "rain", 721802, "_rainSmoothness", "_rainMiddle"),
            (6, "snow", 721803, "_snowSmoothness", "_snowMiddle")]


def main():
    configs = {}
    for l in gzip.open(ROOT / "out/mb/PWC.BackgroundSkyConfig.jsonl.gz", "rt"):
        r = json.loads(l)
        if r["_file"] == "resources.assets":
            configs[r["_path_id"]] = r
    sky = next(json.loads(l) for l in gzip.open(ROOT / "out/mb/PWC.BackgroundSky.jsonl.gz", "rt")
               if json.loads(l)["_file"] == "level4")
    out = []
    for weather, name, pid, sm, mid in WEATHERS:
        c = configs[pid]
        rgb = lambda arr: [[round(x["r"], 5), round(x["g"], 5), round(x["b"], 5), round(x["a"], 5)] for x in arr]
        out.append({"weather": weather, "name": name, "smoothness": sky[sm], "middle": sky[mid],
                    "phases": [{"name": p, "top": rgb(c[p + "TopColors"]), "bottom": rgb(c[p + "BottomColors"])} for p in PHASES]})
    dest = ROOT / "client/AvatarWorldClient/Assets/Resources/WorldSlice/sky.json"
    # JsonUtility nao le matriz [[...]]: cada cor vira {r,g,b,a}
    for cfg in out:
        for ph in cfg["phases"]:
            for k in ("top", "bottom"):
                ph[k] = [{"r": c[0], "g": c[1], "b": c[2], "a": c[3]} for c in ph[k]]
    dest.write_text(json.dumps({"configs": out}))
    print(f"{len(out)} configs de clima -> {dest}")


if __name__ == "__main__":
    main()
