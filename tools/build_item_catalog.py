#!/usr/bin/env python3
"""store_catalog.json -> Resources/Store/items.json (um item por GUID, campos curtos g/n/c).

O preco NAO vem daqui: e calculado por categoria em Core/Economy/ItemPricing.cs (os precos do arquivo de origem sao 0).

Categoria de 1 caractere (ex.: "c" de "C_Scissors", "x" de "X_Obstacle_L150") e artefato da extracao: o
extrator de store_catalog.json usa o primeiro token do nome do asset antes de "_" como categoria, o que
funciona para nomes descritivos ("Cushion_04..." -> "cushion") mas produz lixo quando o asset usa um
prefixo de letra unica. 417 itens caiam assim na categoria "c", que virava um dos 8 chips mostrados ao
jogador sem significado nenhum. Tratado igual a categoria vazia: cai em "outros".
uso: build_item_catalog.py
"""
import json
from pathlib import Path

ROOT = Path(__file__).resolve().parent.parent
src = json.loads((ROOT / "store_catalog.json").read_text())["items"]
seen, items = set(), []
for i in src:
    g, n, c = i["guid"], (i.get("name") or "").strip(), (i.get("category") or "").strip()
    if g in seen or not n:
        continue
    seen.add(g)
    items.append({"g": g, "n": n, "c": c if len(c) > 1 else "outros"})
out = ROOT / "client/AvatarWorldClient/Assets/Resources/Store/items.json"
out.write_text(json.dumps({"items": items}, ensure_ascii=False, separators=(",", ":")))
print(f"{len(items)} itens únicos de {len(src)} linhas -> {out} ({out.stat().st_size/1e6:.2f} MB)")
