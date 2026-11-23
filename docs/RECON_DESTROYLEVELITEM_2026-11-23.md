# PWC.Level.LevelUtils.DestroyLevelItem(LevelItem levelItem, bool shouldAddRestoreData = true) — 2026-11-23

Fecha o U2 de `T025/HANDLER/000032a8`. Corpo `0x232b9ac..0x232bf94` (1512 bytes), de
`out/recon/tasks/T025/HANDLER/000032a8/destroy_level_item_callee.asm.txt`; callees por `out/recon/il2cpp/*_methods.jsonl`.
Estatico apenas (Capstone), sem Hopper/Ghidra. `libil2cpp.so` sha256 `b63661fa60c2...`. `w20` = `shouldAddRestoreData`, `x19` = `levelItem`.

## Fluxo (pseudo-codigo)
```
if (levelItem == null)  { Debug.LogError("levelItem is null!"); return; }              // op_Equality 0x3ccb8d8, LogError 0x3ca5b88
items = levelItem.GetComponentsInChildren<LevelItem>(true);                              // 0x24f1424 (generico, T inferido, ver abaixo)
foreach (child in items) {                                                               // inclui o proprio item e filhos, inativos tambem
    if (PWCUtils.IsDestroyed(child)) continue;                                           // 0x2083020
    OnBeforeDestroyLevelItemAction?.Invoke(child);                                       // static Action<LevelItem> (statics+0x8) de LevelUtils
    child.<virtual @vtable+0x738>();                                                     // CONFIRMADO: LevelItem.OnBeforeDestroyWhileInGameplay (slot 96)
    child.gameObject.tag = "Destroyed";                                                  // get_gameObject 0x3cc84e4 / set_tag 0x3cc8a10
    if (child != levelItem)                                                              // op_Equality
        child.<virtual @vtable+0x508>(true);                                             // CONFIRMADO: LevelItem.DetachFromParentIfExists(true) (slot 61)
    if (shouldAddRestoreData) {
        if (child.TryGetComponent<PDSceneObject>(out pd)) {                              // 0x24f17fc
            if (!string.IsNullOrEmpty(pd.sceneGuid /*+0x20*/)) {                         // 0x31dffdc
                if (LevelDefaultData.TryGetSceneOwnerForItem(pd.sceneGuid, out owner))   // 0x22c96b4
                    LevelDefaultDataItemsToRestore.AddItem(owner, pd.sceneGuid);         // 0x22c9f64
                else if (InventoryManager.<static +0xb8>.itemsTracker.IsTrackingSceneGuid(pd.sceneGuid))  // 0x213f900
                    InventoryItemsTracker.AddItemToRestore(pd.sceneGuid);                // 0x213fb38
                else
                    child.<virtual @vtable+0x748>();                                     // CONFIRMADO: AddToCustomRestoreDataBeforeDestroyWhileInGameplay (slot 97)
            }
        } else
            Debug.LogError("No PDSceneObject found on levelItem[" + child.name + "]");   // get_name 0x3cce6d0, Concat 0x31dfa68
    }
}
// depois do laco:
if (levelItem.TryGetComponent<LevelCAHandlerBase>(out x))                                // 0x24f17fc (decodificado em RECON_GENERIC_USAGES)
    if ((h = levelItem.GetComponentInParent<ICATarget>()) != null)                       // 0x24f0dbc
        CATargetExtensionMethods.RemoveCAHandlersAndUpdateGame(h, x.gameObject, false);  // 0x23adf98
levelItem.gameObject.SetActive(false);                                                   // 0x3ccad98
levelItem.DetachFromParentIfExists(true);                                               // mesmo despacho do filho
Object.Destroy(levelItem.gameObject);                                                    // 0x3ccf03c
```

## Efeitos que importam
- **Persistencia/restauracao** (so com `shouldAddRestoreData`): cada item destruido com `sceneGuid` vira entrada de restauracao em
  `LevelDefaultDataItemsToRestore` (se pertence a um dono de cena padrao) ou em `InventoryItemsTracker` (se o guid e rastreado pelo
  inventario); senao o proprio item grava dados custom (virtual). Item sem `PDSceneObject` so loga erro.
- **Ordem**: evento global antes, depois `tag="Destroyed"`, desativa e so entao `Object.Destroy`.
- `DestroyCurrentItems` chama com `true`, entao o ciclo de nivel registra restauracao para cada item removido.

## Confianca / ainda aberto
- Alta: ramos, callees nomeados (todos achados no indice por endereco), strings (`"levelItem is null!"`, `"Destroyed"`,
  `"No PDSceneObject found on levelItem["`).
- Tipos dos genericos **provados** pela cadeia GOT -> methodSpecs -> genericInsts (`docs/RECON_GENERIC_USAGES_2026-11-23.md`); o ultimo e `GetComponentInParent<ICATarget>`, nao `GetComponent`.
  `0x24f17fc` do laco = `PDSceneObject` pelo texto de erro; os dois usos finais nao foram decodificados).
- Os 3 despachos virtuais foram **resolvidos** pela vtable do metadata (`docs/RECON_LEVELITEM_VTABLE_2026-11-23.md`).
- Offsets `pd+0x20` (sceneGuid), `InventoryManager.Instance` (estatico +0x8) e `.ItemsTracker` (+0x38) **confirmados** pela tabela de metadata
  (`docs/RECON_FIELD_OFFSETS_2026-11-23.md`); no pseudo-codigo, `InventoryManager.<static +0xb8>.itemsTracker` = `InventoryManager.Instance.ItemsTracker`.
- Fila nao alterada; revisao independente pendente.
