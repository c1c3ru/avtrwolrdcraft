#!/usr/bin/env python3
"""Diff visual aproximado: compara a captura de cada interior do nosso build (device_world_smoke.py)
com as capturas reais do original (levantamento em out/device/avatar-original-survey-*).

Como as cameras iniciais diferem (o original abre num ponto de rolagem e nos centramos no avatar),
cada captura nossa e deslizada na horizontal sobre cada vista do original da mesma cena; a nota e a
melhor correlacao normalizada (1.0 = identico). Faixa do topo (botoes) e area do avatar do jogador sao
ignoradas. E uma medida aproximada: serve para achar interiores muito diferentes, nao para aprovar arte.

Uso: python3 tools/device_visual_diff.py [--smoke out/device/tests/world_smoke]
        [--survey out/device/avatar-original-survey-2026-11-09] [--out out/device/tests/visual_diff]
"""
import argparse, json, sys
from pathlib import Path
import numpy as np
from PIL import Image

# chave do interior no nosso build -> cena confirmada do original (casamento por nome; marcado "incerto" quando duvidoso)
PAIRS = {
    "hospital_t1s4": ("Level_Hospital_F1_L157", False),
    "bank_t1s4": ("Level_Bank_L148", False),
    "courthouse_t1s4": ("Level_CourtHouse_L147", False),
    "fire_station_t1s4": ("Level_FireStation_F0_L154", False),
    "police_station_t1s4": ("Level_PoliceStation_L145", False),
    "post_office_t1s4": ("Level_PostOffice_L146", False),
    "bakery_build_t1s3": ("Level_Bakery_L20", False),
    "hiphop_build_t1s3": ("Level_HipHopStudio_L18", False),
    "ballet": ("Level_BalletStudio_L19", False),
    "branding_skater_t1s3": ("Level_SkaterShopBrand_L28", False),
    "shoes_shop_t1s4": ("Level_ShoeShopBrand_L26", False),
    "daycare_t1z2": ("Level_Infants_Daycare_L24", False),
    "pet_store_t1s3": ("Level_PetShelter_L22", False),
    "barbershop_t1s2": ("Level_MiniBarbershop_Z1B5L1", False),
    "mkr_kawaii_house_t1s1": ("Level_KawaiiHouse_F2_L33", True),
    "school_t1s2": ("Level_SchoolHallway_L12", True),
    "pharmacy_t1s2": ("Level_DoctorOffice_L17", True),
    "family_house_t1s1": ("Level_GirlsLivingRoom_Z1B1L1", True),
    "kawaii_shop_t1s4": ("Level_KawaiiShopBrand_L27", True),
    "toddlerbaby_t1s3": ("Level_ToddlerBabyShop_L45", True),
    "yoga_build_t1s3": ("Level_MiniYogaStudio_Z1B2L1", True),
}
S = 8  # reducao


def prep(path):
    im = Image.open(path).convert("L")
    im = im.resize((im.width // S, im.height // S), Image.BILINEAR)
    a = np.asarray(im, dtype=np.float32)
    # o canto inferior esquerdo recebe o painel "Development Console" do build de desenvolvimento (so no nosso app)
    a[int(820 / S):, : int(1280 / S)] = a.mean()
    return a[int(200 / S):, :]  # sem a faixa dos botoes


def best_ncc(ours, theirs):
    """Melhor correlacao normalizada deslizando 'ours' na horizontal sobre 'theirs'."""
    best = -1.0
    h = min(ours.shape[0], theirs.shape[0])
    o, t = ours[:h], theirs[:h]
    for sh in range(-o.shape[1] // 2, o.shape[1] // 2 + 1, 2):
        if sh >= 0:
            x, y = o[:, sh:], t[:, : t.shape[1] - sh]
        else:
            x, y = o[:, : o.shape[1] + sh], t[:, -sh:]
        if x.shape[1] < 80:
            continue
        x = x - x.mean(); y = y - y.mean()
        d = float(np.sqrt((x * x).sum() * (y * y).sum()))
        if d > 0:
            best = max(best, float((x * y).sum() / d))
    return best


def main():
    ap = argparse.ArgumentParser()
    ap.add_argument("--smoke", default="out/device/tests/world_smoke")
    ap.add_argument("--survey", default="out/device/avatar-original-survey-2026-11-09")
    ap.add_argument("--out", default="out/device/tests/visual_diff")
    a = ap.parse_args()
    smoke, survey, out = Path(a.smoke), Path(a.survey), Path(a.out)
    out.mkdir(parents=True, exist_ok=True)
    report = json.loads((smoke / "world_smoke_report.json").read_text())
    verified = {s["scene"]: s for s in json.loads((survey / "verified-scenes.json").read_text())["scenes"]}
    rows = []
    for r in report["results"]:
        pair = PAIRS.get(r["key"])
        if not pair or pair[0] not in verified:
            continue
        scene, uncertain = pair
        ours = prep(smoke / r["screenshot"])
        scores = []
        for cap in verified[scene]["captures"]:
            p = survey / cap
            if p.exists():
                scores.append((best_ncc(ours, prep(p)), cap))
        if not scores:
            continue
        score, cap = max(scores)
        rows.append({"key": r["key"], "original_scene": scene, "uncertain_match": uncertain,
                     "best_ncc": round(score, 3), "best_original_capture": cap, "our_capture": r["screenshot"]})
        # lado a lado para revisao humana
        a_im = Image.open(smoke / r["screenshot"]).convert("RGB").resize((800, 360))
        b_im = Image.open(survey / cap).convert("RGB").resize((800, 360))
        sheet = Image.new("RGB", (1600, 360)); sheet.paste(a_im, (0, 0)); sheet.paste(b_im, (800, 0))
        sheet.save(out / f"{r['key']}__vs__{scene}.png")
        print(f"{score:5.2f}  {'?' if uncertain else ' '} {r['key']:28s} vs {scene}")
    rows.sort(key=lambda x: x["best_ncc"])
    (out / "visual_diff_report.json").write_text(json.dumps({"method": "best horizontal-shift NCC at 1/8 scale; top bar excluded", "pairs": rows}, indent=2) + "\n")
    print(f"\n{len(rows)} pares comparados; menor nota: {rows[0]['best_ncc'] if rows else '-'}")
    return 0


if __name__ == "__main__":
    sys.exit(main())
