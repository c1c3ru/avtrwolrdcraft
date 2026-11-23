# LevelDigHoleArea.OnBeforeSceneLoadStage1 / DetachContainerAreaChildrenIfNeeded — 2026-11-23

T025/HANDLER/00002d72. Estatico (Capstone), `libil2cpp.so` sha256 `b63661fa60c2...`, `global-metadata.dat` v31.
Ferramentas: `tools/il2cpp_field_offsets.py`, `tools/il2cpp_method_usage.py`.

## Callback
`LevelDigHoleArea.OnBeforeSceneLoadStage1` (`0x1e29da8`, MethodDef 11634) e um `b 0x1e299b4`: tail-call sem mexer em `x0`, repassa o receiver para
`DetachContainerAreaChildrenIfNeeded` (MethodDef 11635, `0x1e299b4`, 596 bytes ate `0x1e29c07`).

## Corpo do helper (pseudo-codigo)
```
if (this.IsInteractable) return;                                   // LevelDigArea.<IsInteractable>k__BackingField, +0x51 (bool)
_containerAreaLevelItems.Clear();                                  // List<LevelItem> em +0x78; Clear inline: version++, size=0, Array.Clear(items,0,oldSize) (0x3379f00)
foreach (LevelItem item in _containerArea.GetImmediateChildrenItems()) {   // +0x68 LevelContainerArea; 0x227b1f8 = LevelConsumerAreaBase.GetImmediateChildrenItems(); List<LevelItem>.GetEnumerator
    _containerAreaLevelItems.Add(item);                            // Add inline (size<capacity) ou slow path 0x2cf071c; wbarrier 0x1b88694
    item.transform.SetParent(null);                                // get_transform 0x3cc84a8; Transform.SetParent(Transform) 0x3cd4fac com null
}
// try/finally: Enumerator.Dispose() (GOT 0x41b55c8) em todos os caminhos
```
Em palavras: quando a area de escavar **nao esta interagivel**, antes de carregar a cena ela guarda em `_containerAreaLevelItems` os itens filhos imediatos da
area-container e os solta do pai (`SetParent(null)`, ou seja, para a raiz da cena), provavelmente para que sobrevivam/nao sejam destruidos junto com a area.
A lista guardada e a mesma que o resto da classe usa depois (nao analisado aqui).

## Evidencias
| Item | Resultado |
|---|---|
| `[this+0x51]` | `LevelDigArea.<IsInteractable>k__BackingField` (typeDef 2061, tabela de offsets) |
| `[this+0x68]` / `+0x78` | `_containerArea` / `_containerAreaLevelItems` (typeDef 2062; confere com Cpp2IL) |
| GOT `0x41b55e0` | `List<LevelItem>.GetEnumerator` |
| GOT `0x41b55d0` / `0x41b55d8` / `0x41b55c8` | `Enumerator<LevelItem>.MoveNext` / `get_Current` / `Dispose` |
| GOT `0x41bb1e0` / `0x41bb1e8` | `List<LevelItem>.Add` / `Clear` |
| Excecoes | NRE (`0x1b88980`) se `_containerAreaLevelItems`, `_containerArea`, retorno de `GetImmediateChildren...` ou item for nulo; o bloco em `0x1e29b94..0x1e29c07` e o landing pad que faz `Dispose` do enumerador e re-lanca (`0x1b88978`, nome nao confirmado) |

## Confianca / aberto
- Alta: ramos, campos, tipos genericos, nomes dos callees diretos (todos achados por endereco ou GOT).
- Media: stubs `0x2cf12b4` (List.GetEnumerator), `0x29c0b20` (MoveNext), `0x2cf071c` (List.Add slow path/AddWithResize), `0x1b88694` (GC write barrier), `0x1b88978`
  (re-lanca excecao): nomeados pelo papel no chamador e pelos GOT de classArgs, sem corpo conferido.
- Nao decodificado: LSDA/tabela de excecao formal (so o landing pad visivel por fluxo), corpo de `GetImmediateChildrenItems`, quem consome `_containerAreaLevelItems`
  depois (provavel recolocacao ao recarregar), validacao dinamica. Revisao independente pendente. Fila nao alterada.

## Correcao apos revisao independente
`LevelDigHoleArea.OnGamePause` (`0x1e299b0`) tambem e `b 0x1e299b4`: o desanexar roda **tambem ao pausar o jogo**, nao so antes de carregar a cena. `OnGameResume` (`0x1e29c08`) tem forma parecida e nao foi analisado.
