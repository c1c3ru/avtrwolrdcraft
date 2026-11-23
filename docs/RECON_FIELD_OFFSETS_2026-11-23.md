# Offsets de campo por tabela de metadata (U3 de T025/HANDLER/000032a8) — 2026-11-23

Junta `global-metadata.dat` (v31: typeDefinitions de 88 bytes, fields de 12 bytes) com `MetadataRegistration.fieldOffsets` do
`libil2cpp.so` (sha256 `b63661fa60c2...`). Independente do Cpp2IL. Ferramenta: `tools/il2cpp_field_offsets.py`.

## Como a tabela foi achada
`MetadataRegistration` tem `fieldOffsetsCount` e `typeDefinitionsSizesCount`, ambos = numero de typeDefs (16859), separados por um ponteiro.
Busca em `.data.rel.ro` por `qword 16859 | ptr | qword 16859` acha um unico caso: contador em `0x40d1110`, ponteiro (RELATIVE em `.rela.dyn`)
para a tabela `fieldOffsets` em `0x4235148`. `fieldOffsets[typeIdx]` -> `int32[field_count]`, na ordem dos `fields` do metadata.
Validacao cruzada: `DeepLinkManager._mapLinkToLevel = 0x28`, igual ao Cpp2IL e ao uso em `HomePlayButton.LoadPlayScene`.

## Resultado (todos conferem com o assembly de DestroyCurrentItems / DestroyLevelItem)
| Tipo | Campo | Offset | Uso no assembly |
|---|---|---|---|
| `Game.Level.LevelSpawnOnLevelPostInit` | `_points` | 0x30 | `ldr x20,[x19,#0x30]` |
| idem | `_isNewEveryLoad` | 0x38 | `ldrb w8,[x19,#0x38]` |
| `PWC.PersistentData.PDSceneObject` | `sceneGuid` | 0x20 | `ldr x0,[x8,#0x20]` apos `TryGetComponent` |
| `PWC.Inventory.InventoryManager` (estaticos) | `<Instance>k__BackingField` | 0x8 | `ldr x9,[statics,#8]` |
| `PWC.Inventory.InventoryManager` | `<ItemsTracker>k__BackingField` | 0x38 | `ldr x0,[x9,#0x38]` |
| `PWC.Level.LevelUtils` (estaticos) | `OnBeforeDestroyLevelItemAction` | 0x8 | `ldr x8,[x26?]` na chamada do `Action<LevelItem>` |
| `PWC.Inventory.ItemsTracker.InventoryItemsTracker` | `_itemsState` | 0x10 | (nao usado aqui) |

Correcao ao doc de `DestroyLevelItem`: o rastreador e `InventoryManager.Instance.ItemsTracker` (estatico `+8`, depois campo `+0x38`),
nao um "static +0xb8" solto; `+0xb8` e so o ponteiro `static_fields` da classe IL2CPP.

## Ainda aberto
U4 (helpers `0x1b886e8`, `0x1b88980`, `0x1b88988`), nomes dos 3 virtuais, tipos dos dois genericos finais, revisao independente. Fila nao alterada.
