# Virtuais de LevelItem usados por DestroyLevelItem — 2026-11-23

Resolve os 3 despachos virtuais de `PWC.Level.LevelUtils.DestroyLevelItem` (T025/HANDLER/000032a8). Estatico: `global-metadata.dat` v31 +
`tools/il2cpp_vtable.py`. Slot = `(offset - 0x138) / 16` (vtable de `Il2CppClass` em `+0x138`, 16 bytes por entrada).

| Offset no assembly | Slot | Metodo (typeIdx 5880 `PWC.Level.LevelItem`, vtable_count 103) | Onde |
|---|---|---|---|
| `+0x738` | 96 | `LevelItem.OnBeforeDestroyWhileInGameplay()` | antes de marcar `tag="Destroyed"`, por item |
| `+0x748` | 97 | `LevelItem.AddToCustomRestoreDataBeforeDestroyWhileInGameplay()` | quando o guid nao tem dono de cena padrao nem e rastreado pelo inventario |
| `+0x508` | 61 | `LevelItem.DetachFromParentIfExists(bool callDetachEvent)` com `true` | dentro do laco so quando `child == levelItem` (o proprio item raiz; filhos nao), e de novo depois do laco antes do `Destroy` |

## Validacao
- Slots 0..3 da mesma vtable saem `Object.Equals/Finalize/GetHashCode/ToString`, a ordem exata da vtable de `System.Object`.
- Vizinhos coerentes: slot 60 `CacheLevelItemsUnderSelfForNotifyEvents`, 62 `OnBeforeDetachFromParent` (cercam `DetachFromParentIfExists`);
  98 `OnBeforeDestroyDueToItemsCountClamp` (irmao dos dois destroy acima).
- Codificacao de `vtableMethods` (v31): `valor >> 29 == 3` (MethodDef) e indice = `(valor & 0x1FFFFFFF) >> 1`. Sem o `>> 1` os nomes saem sem sentido.
- Correcao de formato: `MethodDefinition` = 36 bytes (o `32` anotado antes estava errado; so afeta ferramentas, nao os docs anteriores).

## Efeito em T025/HANDLER/000032a8
Fecha os nomes dos virtuais (tipos dos genericos fechados em `RECON_GENERIC_USAGES`). Ver `REVIEW_INDEPENDENT_RE_2026-11-23.md`.
