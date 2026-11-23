#!/usr/bin/env python3
"""Exporta os drops de roupa do original (PWC.Level.ClothesDropDataMap + PDTextBulkData) para Resources/ClothesDrops/drops.json.

Cada ClothesDropDataMap_<Loja>_L<level> e uma lista de (data, conjunto de pecas); o conjunto e um PDTextBulkData
"ClothesDrop_BulkData_<Tema>[_LD<n>]_L<level>" com skins por tipo de esqueleto (so spineType 1 = adulto humano tem pecas aqui).
Skin "Shirt_Special/643" vira o id do editor "shirt_special_643". Conjunto "Empty" = sem drop naquela data.

Fonte: out/mb/*.jsonl.gz (dumps do datapack). uso: python3 tools/export_clothes_drops.py
"""
import gzip, json, re
from pathlib import Path

ROOT = Path(__file__).resolve().parent.parent
DEST = ROOT / "client/AvatarWorldClient/Assets/Resources/ClothesDrops/drops.json"


def rows(name):
    for l in gzip.open(ROOT / f"out/mb/{name}.jsonl.gz", "rt"):
        r = json.loads(l)
        if r.get("_file") == "resources.assets":
            yield r


def main():
    bulk = {r["_path_id"]: r for r in rows("PWC.PersistentData.PDTextBulkData") if r["m_Name"].startswith("ClothesDrop")}
    stores = []
    for m in sorted(rows("PWC.Level.ClothesDropDataMap"), key=lambda r: r["m_Name"]):
        match = re.match(r"ClothesDropMap_(.+?)_L(\d+)$", m["m_Name"])
        drops = []
        for d in m["_timeToClothesData"]:
            b = bulk[d["data"]["m_PathID"]]
            n = re.match(r"ClothesDrop_BulkData_(.+?)(?:_LD\d+)?_L\d+$", b["m_Name"])
            items = []
            for sp in b["_clothingItemsBySpineType"]:
                if sp["spineType"] != 1:
                    continue
                for c in sp["clothingPD"]:
                    i = c["skinName"].lower().replace("/", "_")
                    if i not in items:
                        items.append(i)
            drops.append({"date": "%04d-%02d-%02d" % (d["year"], d["month"], d["day"]),
                          "name": n.group(1) if n else b["m_Name"], "items": items})
        drops.sort(key=lambda x: x["date"])
        stores.append({"key": match.group(1), "levelType": int(match.group(2)), "drops": drops})
    DEST.parent.mkdir(parents=True, exist_ok=True)
    DEST.write_text(json.dumps({"stores": stores}, ensure_ascii=False))
    print(len(stores), "lojas,", sum(len(s["drops"]) for s in stores), "drops ->", DEST)


if __name__ == "__main__":
    main()
