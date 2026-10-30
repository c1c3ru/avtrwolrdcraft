"""Gera store_catalog.json: itens (PDPrefab) com guid/nome e preco PLACEHOLDER em pazuCurrency.
Os precos reais ficam no servidor do jogo e nao estao no APK; os valores abaixo sao de design proprio e editaveis."""
import sys, gzip, json, re, collections, UnityPy
prefabs = [json.loads(l) for l in gzip.open("out/mb/PWC.PersistentData.PDPrefab.jsonl.gz", "rt")]
want = {p["m_GameObject"]["m_PathID"] for p in prefabs}
env = UnityPy.load("x/data/assets/bin/Data/datapack.unity3d")
names = {}
for o in env.objects:
    if o.type.name == "GameObject" and o.path_id in want:
        names[o.path_id] = o.read().m_Name
cat = lambda n: re.split(r"[_\- ]", n)[0].lower() if n else "misc"
items = []
for p in prefabs:
    n = names.get(p["m_GameObject"]["m_PathID"], "")
    items.append({"guid": p["_prefabGuid"], "name": n, "category": cat(n), "sceneObjects": len(p["_sceneObjects"]),
                  "price": {"pazuCurrency": 0, "loyaltyPoints": 0}})
by = collections.Counter(i["category"] for i in items)
json.dump({"_nota": "preco 0 = a definir; valores reais pertencem ao servidor do jogo", "currencies": ["pazuCurrency", "loyaltyPoints"],
           "items": items}, open("store_catalog.json", "w"), indent=1)
print("itens", len(items), "com nome", sum(1 for i in items if i["name"]), "guids unicos", len({i["guid"] for i in items}))
print(by.most_common(12))
