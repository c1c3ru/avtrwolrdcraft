#!/usr/bin/env python3
"""store_catalog.json -> Resources/Store/items.json (um item por GUID, campos curtos g/n/c).

O preco NAO vem daqui: e calculado por categoria em Core/Economy/ItemPricing.cs (os precos do arquivo de origem sao 0).
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
    items.append({"g": g, "n": n, "c": c or "outros"})
out = ROOT / "client/AvatarWorldClient/Assets/Resources/Store/items.json"
out.write_text(json.dumps({"items": items}, ensure_ascii=False, separators=(",", ":")))
print(f"{len(items)} itens únicos de {len(src)} linhas -> {out} ({out.stat().st_size/1e6:.2f} MB)")
