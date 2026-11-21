"""Classifica, por heuristica de nome + categoria dos itens, os 224 pacotes de PWC.Inventory.InventoryBuildData
(unico objeto do genero no jogo: packGuid -> lista de itens). Complementa docs/RECON_STORE_HOUSE_BUNDLES_2026-11-07.md,
que resolve apenas os 7 temas de Casas; este script da uma visao geral de TODOS os pacotes (Casa, Moda, Bebe, Pet,
Celebracao, Veiculo, Esporte, Indefinido).
Entrada: store_catalog.json, out/mb/PWC.Inventory.InventoryBuildData.jsonl.gz
Saida: out/recon/store_all_packs_overview.json
uso: python3 tools/recon_store_packs_overview.py
"""
import json, gzip, re, collections
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]

FURNITURE_CATS = {'carpet', 'wall', 'ceiling', 'floor', 'table', 'chair', 'lamp', 'shelf', 'cabinet', 'closet',
                   'plant', 'picture', 'poster', 'painting', 'vase', 'rug', 'curtain', 'mirror', 'sofa', 'bed',
                   'desk', 'bench', 'sticker', 'box', 'basket', 'plate', 'cup', 'bowl', 'glass', 'bottle',
                   'candle', 'towel', 'soap', 'bag', 'pool', 'door', 'window', 'stair', 'balcony', 'garage',
                   'kitchen', 'bathroom', 'bedroom', 'toy', 'book', 'small', 'big', 'tray', 'napkin', 'fork',
                   'knife', 'spoon', 'sticky', 'pencil', 'garden', 'yard', 'pouffe', 'decor', 'kettle',
                   'ornament', 'wardrobe', 'pillow', 'light', 'statue', 'coffee', 'seed', 'ugc', 'bush',
                   'tree', 'fence', 'sand'}
PET_CATS = {'dog', 'cat', 'pet', 'plushie', 'hamster', 'horse'}
BABY_CATS = {'baby', 'toddler', 'pacifier', 'wrap', 'kids', 'kid'}
CELEB_CATS = {'balloon', 'candle', 'food', 'cake', 'gift'}
# familias de pacote ja confirmadas em docs/RECON_STORE_HOUSE_BUNDLES_2026-11-07.md como comodos de um tema de
# Casas (por prefixo de nome compartilhado) - sobrescreve o conteudo dos itens, que pode ser misto (ex.: um
# quarto de bebe dentro da casa Natural Chic ainda e um comodo, nao um pacote de bebe avulso).
KNOWN_HOUSE_ROOM_PREFIXES = ('BubbleGlam', 'GalxeHM', 'IslandHM', 'NaturalChic', 'SnowyHM',
                              'KawaiiHouseP29', 'KawaiiHouseP30', 'ModernGarage', 'ModernLivingRoomAndBalcony')


def bucket_for(name, p, by_guid):
    if name.startswith(KNOWN_HOUSE_ROOM_PREFIXES):
        return 'Casa/comodo'
    items = p['items'] if isinstance(p['items'], list) else []
    cats = collections.Counter()
    for ig in items:
        h = by_guid.get(ig, [])
        if h:
            cats[h[0].get('category', '?')] += 1
    total = sum(cats.values()) or 1
    furn = sum(c for k, c in cats.items() if k in FURNITURE_CATS)
    pet = sum(c for k, c in cats.items() if k in PET_CATS)
    baby = sum(c for k, c in cats.items() if k in BABY_CATS)
    celeb = sum(c for k, c in cats.items() if k in CELEB_CATS)
    char = cats.get('character', 0)
    nl = name.lower()
    # sinais fortes por nome primeiro
    if re.search(r'house|hm(bathroom|bedroom|kitchen|living|lounge|lumi|sky|vega|balcony|beach|outdoors)|mansion|dollhouse', nl):
        return 'Casa/comodo'
    if re.search(r'vehicle|truck|limo|scooter|bicycle|tractor|^rv|boat|catamarn|longboard', nl):
        return 'Veiculo'
    if re.search(r'wedding|birthday|party|graduation|newyears|pumpkin|valentine|costumes?\d|winterofjoy', nl):
        return 'Celebracao'
    if re.search(r'sport|basketball|football|gym|tennis|ski|skate|cheerlead|horsegrooming', nl):
        return 'Esporte'
    if re.search(r'^y2k|^pf\d|pf\d+box|daizy|daisy|makeup|glam|hiphop|popstar|swim|fashion|edgy|prepto', nl):
        return 'Moda/avatar'
    if total == 0:
        return 'Bundle-capa (0 itens diretos)'
    # fallback por conteudo dos itens: escolhe o grupo com maior contagem, exige minimo de 20% para aceitar
    scores = {'Casa/comodo': furn, 'Pet': pet, 'Bebe/crianca': baby, 'Celebracao': celeb, 'Moda/avatar': char}
    best_bucket, best_score = max(scores.items(), key=lambda kv: kv[1])
    if best_score / total > 0.2:
        return best_bucket
    return 'Indefinido'


def main():
    cat = json.loads((ROOT / 'store_catalog.json').read_text(encoding='utf-8'))['items']
    by_guid = {}
    for it in cat:
        by_guid.setdefault(it['guid'], []).append(it)

    with gzip.open(ROOT / 'out/mb/PWC.Inventory.InventoryBuildData.jsonl.gz', 'rt') as f:
        inv = json.loads(f.readline())
    packs = inv['packToItems']['packs']

    by_name = {}
    for p in packs:
        hits = by_guid.get(p['guid'], [])
        name = hits[0]['name'] if hits else None
        if name:
            by_name[name] = p

    rows = []
    for name, p in by_name.items():
        items = p['items'] if isinstance(p['items'], list) else []
        rows.append({'pack_name': name, 'guid': p['guid'], 'item_count': len(items),
                      'bucket': bucket_for(name, p, by_guid)})
    rows.sort(key=lambda r: (r['bucket'], r['pack_name']))

    dest = ROOT / 'out/recon/store_all_packs_overview.json'
    dest.write_text(json.dumps(rows, indent=1, ensure_ascii=False), encoding='utf-8')

    by_bucket = collections.Counter()
    items_bucket = collections.Counter()
    for r in rows:
        by_bucket[r['bucket']] += 1
        items_bucket[r['bucket']] += r['item_count']
    for b in sorted(by_bucket, key=lambda x: -by_bucket[x]):
        print(f"{by_bucket[b]:3d} packs  {items_bucket[b]:5d} itens  {b}")
    print('total', len(rows), sum(r['item_count'] for r in rows))


if __name__ == '__main__':
    main()
