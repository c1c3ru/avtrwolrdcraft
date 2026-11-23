# LevelSlideSwitcherHandler.OnBeforeSceneLoadStage1 — 2026-11-23

T025/HANDLER/00003cd1. Estatico (Capstone), `libil2cpp.so` sha256 `b63661fa60c2...`, metadata v31. Disassembly de entrada em
`out/recon/tasks/T025/HANDLER/00003cd1/*.asm.txt`; campos/genericos via `tools/il2cpp_field_offsets.py` e `tools/il2cpp_method_usage.py`.
Nota: o nome `SetInSildeData` (sic) e do original.

## Campos (`Game.Level.WaterSlide.LevelSlideSwitcherHandler`, typeDef 2734, tabela de metadata)
`_dropAreas` 0x20 (lista de `LevelSingleItemDropArea`), `_currentLevelType` 0x28, `_nextSceneLevelType` 0x2c, `_isInsideSlide` 0x30, `_includeRoot` 0x31.

## Fluxo
```
OnBeforeSceneLoadStage1()                       // 0x1f04f28, MethodDef 15569, 32 bytes
{   bool changed = false;
    if (_isInsideSlide) SaveItemInBulkData(ref changed);       // changed nao e lido aqui
}

SaveItemInBulkData(ref bool changed)            // 0x1f04f48
{   changed = false;
    if (_includeRoot) {
        foreach (GameObject go in SceneManager.GetActiveScene().GetRootGameObjects())      // 0x3cdb658 / 0x3cdae08
            if (go.TryGetComponent<ILevelLivingBeing>(out _) && go.TryGetComponent<LevelItem>(out item))   // 0x25751c8 x2
                SetInSildeData(item, ref changed);
    }
    foreach (LevelSingleItemDropArea area in _dropAreas) {
        LevelItem item = area.GetSingleLevelItem();                   // 0x2286ab8
        if (item != null) SetInSildeData(item, ref changed);          // op_Equality 0x3ccb8d8
    }
}

SetInSildeData(LevelItem item, ref bool changed)  // 0x1f05214
{   if (item is LevelCharacter c)  c.interactionHandler.FreeHands();  // [+0x388] -> LevelCharacterInteractionHandler.FreeHands (0x22a3214)
    if (item is LevelToddler t)    t.FreeHands();                      // 0x2340a54
    changed = true;
    item.transform.SetParent(null, true);                              // get_transform 0x3cc84a8 / SetParent(Transform,bool) 0x3cd4ff4
    string key = "Slide_" + _currentLevelType.ToString();              // box LevelType + Enum.ToString 0x338d9a0 + Concat 0x31d3914
    SeparatedPDManager.AddToBulkData(key, item.GetPDPrefab());         // 0x21e8620, 0x22f424c
    LevelUtils.DestroyLevelItem(item, true);                           // 0x232b9ac (ver RECON_DESTROYLEVELITEM)
}
```
Em palavras: ao sair da cena estando no escorregador, os itens/seres vivos soltos (na raiz da cena, se `_includeRoot`) e os itens unicos de cada area de queda sao
"guardados": soltam as maos do personagem/crianca, saem do pai, entram no pacote persistente `SeparatedPDManager` sob a chave `Slide_<LevelType atual>` (como
prefab persistente) e sao destruidos com restauracao (`DestroyLevelItem(..., true)`), para serem recriados na cena seguinte.

## Provado vs inferido
- Provado (tabelas): offsets de campo; `TryGetComponent<ILevelLivingBeing>` (GOT `0x41bfb18`) e `TryGetComponent<LevelItem>` (GOT `0x41bad58`); nomes dos callees por endereco;
  strings `"Slide_"`. A chave usa `_currentLevelType` (+0x28), **nao** `_nextSceneLevelType` (+0x2c): o handler nao altera nenhum dos dois (fecha U6 no que toca a este metodo).
- Inferido: `is LevelCharacter/LevelToddler` vem do teste de hierarquia de classe (`[klass+0x130]` profundidade e `[klass+0xc8]` tabela de tipos) contra os GOT de
  `LevelCharacter`/`LevelToddler`; `[item+0x388]` = `LevelCharacter.<InteractionHandler>` (confirmado pela tabela de campos na revisao independente); `SetParent(null, true)` pela
  ordem de argumentos `(x1=null, w2=1)`; stub `0x25751c8` e `GameObject.TryGetComponent<T>(out)` (pelo GOT, sem corpo lido).
- Aberto: formato de `AddToBulkData`/consumo da chave `Slide_*` na cena seguinte; LSDA formal; validacao dinamica; revisao independente. Fila nao alterada.

## Helpers de excecao
`0x1b88980` NRE e `0x1b88988` IOORE (ver `RECON_RUNTIME_HELPERS_2026-11-23.md`): no handler, `item` nulo em `SetInSildeData`, elemento de array nulo ou indice fora do limite.
