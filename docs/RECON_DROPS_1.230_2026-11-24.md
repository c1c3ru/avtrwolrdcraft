# Agenda de drops de roupa no 1.230, e como extrair sem estourar a memoria — 2026-11-24

## Resultado
Os dados de drops do build instalado (1.230) foram extraidos de `datapack.unity3d` e comparados com os que o cliente usa (`Resources/ClothesDrops/drops.json`, do build antigo):
**identicos**. Mesmas 6 lojas, 71 drops, mesmas datas (2024-06-04 a 2025-09-01) e mesmas pecas em cada conjunto. Nao ha drops novos no 1.230.
(Mapas lidos: `EveningStore_L107` 2, `Fashionshop_L2` 18, `KPopStore_L126` 4, `Kawaiishop_L5` 21, `ShoeShopBrand_L26` 24, `ShoesAndBags_Store_L121` 2.)
Entao o cliente nao precisa de atualizacao de dados por causa do 1.230.

## Como (e por que isso importa alem dos drops)
O bloqueio documentado era memoria: o UnityPy passa de 5,8 GB de RSS so para abrir o `datapack.unity3d` (1,3 GB comprimido, 3,38 GB descomprimido).
- `tools/unityfs_extract.py`: le o cabecalho UnityFS (formato 8, blocos LZ4HC) e **descomprime bloco a bloco**, gravando so os nos pedidos. Extrair `resources.assets` (334 MB) leva ~3 s e quase nenhuma memoria.
- `tools/clothes_drops_from_assets.py`: abre so esse `resources.assets` no UnityPy, com `TypeTreeGenerator` alimentado pelo `libil2cpp.so` + `global-metadata.dat` do mesmo build,
  e le `ClothesDropDataMap` (6 objetos) e `PDTextBulkData ClothesDrop_*` (71) com `check_read=True`. **Pico de memoria medido: 1,1 GB.**
- `tools/export_clothes_drops.py` ganhou `--mb` e `--out` para exportar de qualquer pasta de dumps.
Reproduzir:
```
tools/venv/bin/python tools/unityfs_extract.py out/device/dp/datapack.unity3d --extract resources.assets --out out/device/dp/
tools/venv/bin/python tools/clothes_drops_from_assets.py --il2cpp out/recon/il2cpp_1.230 --data-unity3d out/device/dp/data.unity3d \
    --resources out/device/dp/resources.assets --out out/recon/il2cpp_1.230/mb
python3 tools/export_clothes_drops.py --mb out/recon/il2cpp_1.230/mb --out out/recon/drops_1.230.json
```

## Implicacao para o T020 (nao feito)
O T020 tinha 65 classes `same_bug_likely_fixed` e 9 `serialize_reference` marcadas como "precisam so de RAM para confirmar". Extrair o `.assets` que contem os objetos e abrir so ele
cabe em ~1 GB, entao essa premissa de memoria provavelmente caiu. Nao tentei nenhuma delas; fica como proximo passo.

## Limites
- Comparei dados serializados deste `resources.assets`; outros arquivos do bundle (`sharedassets*`, `level*`) nao foram tocados.
- A comparacao e entre o JSON exportado do build antigo e o do 1.230 (mesma ferramenta nos dois), nao entre os binarios dos assets.
