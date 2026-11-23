# LevelSpawnOnLevelPostInit.DestroyCurrentItems — alvo 0x24f0700 (2026-11-23)

Fecha o U1 de `T025/HANDLER/000032a8`. Fonte: `libil2cpp.so` sha256 `b63661fa60c2...`, Capstone 5.0.7 + pyelftools, indices em
`out/recon/il2cpp/*_methods.jsonl`, assinaturas em `out/cpp2il/.../LevelUtils.cs`. Sem Hopper/Ghidra.

## 0x24f0700 (48 bytes uteis, 0x24f0700..0x24f0790)
1. Garante o MethodInfo generico (`x1`, `[x1+0x38]` = contexto/rgctx; se nulo resolve via `0x1b886e8`/`0x1b7b99c`).
2. `typeof(T)`: `[ctx+8]` -> `0x33659d0` = `System.Type.GetTypeFromHandle`.
3. `0x3cc85dc` = `UnityEngine.Component.GetComponentFastPath(Type, IntPtr)` com `this=transform` e saida em pilha; retorna o componente (nulo se nao houver).
=> e a instanciacao compartilhada de `Component.GetComponent<T>()` (corpo padrao do Unity), nao um MethodDef indexado (por isso U1).

## Tipo T
O retorno vai direto como 1o argumento de `LevelUtils.DestroyLevelItem(LevelItem levelItem, bool shouldAddRestoreData = true)`
(`0x232b9ac`, segundo arg `w1=1`). Logo **T = `LevelItem`** (inferido pela assinatura e **provado** depois: GOT `0x41aceb8` -> `GetComponent<LevelItem>`, ver `RECON_GENERIC_USAGES_2026-11-23.md`).

## Efeito de DestroyCurrentItems (consolidado)
Se `_isNewEveryLoad` (+0x38): para cada ponto de `_points` (+0x30) nao nulo com `childCount >= 1`, pega `GetChild(0).GetComponent<LevelItem>()`
e chama `DestroyLevelItem(item, true)`. O `null` do GetComponent segue para `DestroyLevelItem` (sem checagem no chamador; o corpo dele nao foi lido).

## Ainda aberto
U2 (corpo de `DestroyLevelItem`, 1512 bytes), U3 (offsets de campo via tabela de metadata), U4 (helpers `0x1b886e8/0x1b88980/0x1b88988`),
revisao independente. Fila nao alterada.
