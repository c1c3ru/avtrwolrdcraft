# Genericos de DestroyCurrentItems / DestroyLevelItem decodificados — 2026-11-23

Estatico: `libil2cpp.so` sha256 `b63661fa60c2...` + `global-metadata.dat` v31. Ferramenta: `tools/il2cpp_method_usage.py`.

## Cadeia usada
Slot de GOT lido pelo codigo (`adrp/ldr`) -> variavel em `.data` (via RELATIVE) com valor codificado: bits 29-31 = tipo (6 = MethodRef),
indice = `(valor & 0x1FFFFFFF) >> 1` -> `MetadataRegistration.methodSpecs[i]` (`{methodDef, classInst, methodInst}`; registro em `0x40d10c0`,
`methodSpecs` x97827, `genericInsts` x9494) -> `genericInsts[j]` -> `Il2CppType` (CLASS `0x12`, `data` = typeDefIdx).

## Resultado
| GOT | Chamada no assembly | Metodo generico |
|---|---|---|
| `0x41aceb8` | `0x24f0700` em `DestroyCurrentItems` | `Component.GetComponent<LevelItem>()` (era inferencia por assinatura; agora provado) |
| `0x41ba5d0` | `0x24f1424` em `DestroyLevelItem` | `Component.GetComponentsInChildren<LevelItem>(bool)` |
| `0x41b6bc0` | `0x24f17fc` no laco | `Component.TryGetComponent<PDSceneObject>(out)` |
| `0x41b8ad8` | `0x24f17fc` apos o laco | `Component.TryGetComponent<LevelCAHandlerBase>(out)` |
| `0x41d6210` | `0x24f0dbc` apos o laco | `Component.GetComponentInParent<ICATarget>()` |

Tipos: `PWC.Level.ContextualAnimation.LevelCAHandlerBase` (typeDef 6253), `PWC.Level.ContextualAnimation.ICATarget` (6281), `PWC.PersistentData.PDSceneObject` (4923),
`PWC.Level.LevelItem` (5880).

## Correcao ao pseudo-codigo de `DestroyLevelItem`
Depois do laco:
```
if (levelItem.TryGetComponent<LevelCAHandlerBase>(out handler))
    if ((target = levelItem.GetComponentInParent<ICATarget>()) != null)       // era "GetComponent<Y>" (errado: e InParent)
        CATargetExtensionMethods.RemoveCAHandlersAndUpdateGame(target, handler.gameObject, false);
```
Ou seja, ao destruir, se o item tem um handler de animacao contextual e algum ancestral (ou ele mesmo) e `ICATarget`, os handlers de CA sao removidos
do alvo e o jogo e atualizado. Os tipos de `PDSceneObject` no laco ficam provados (antes: deduzidos do texto de erro).

## Estado de T025/HANDLER/000032a8
U1-U4, nomes dos virtuais e tipos genericos: fechados (estatico). Resta a revisao independente e validacao dinamica (nao feita). Fila nao alterada.
