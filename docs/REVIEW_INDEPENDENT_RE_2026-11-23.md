# Revisao independente da engenharia reversa estatica — 2026-11-23

Escopo: docs `RECON_*_2026-11-23.md` de `T025/HANDLER/000032a8`, `00002d72`, `00003cd1` e `T025/METHOD` (LoadScene, LoadSceneImplement,
HomePlayButton.LoadPlayScene, GetCurrentWorldSceneName, WorldBuilding.ClickOnLevel). `libil2cpp.so` sha256 `b63661fa60c2...` (conferido).
Nao alterei `reports/recon/tasks.json`, `LOOP_STATE.md`, nem marquei tarefa como done. Sem commit.

## Metodo (independente dos docs e das ferramentas do repo)
Scripts proprios (fora do repo) com capstone + pyelftools:
- disassembly cru por endereco virtual (le o ELF direto), lendo ramos `tbz/tbnz/cbz/cbnz` linha a linha;
- parser proprio do `global-metadata.dat` v31 (typeDefinitions 88 B, methods 36 B, fields 12 B, vtableMethods, fieldDefaultValues, string literals),
  `MetadataRegistration` em `0x40d10c0` (types, methodSpecs, genericInsts, fieldOffsets), relocs `R_AARCH64_RELATIVE` para as variaveis de metadata-usage;
- nomes de callees por endereco conferidos nos `*_methods.jsonl` **e** pelo comportamento (strings, assinatura, ordem de argumentos);
- varredura propria de todos os `bl/b` de `.text` + secao `il2cpp` para achar chamadores (sem usar `tools/il2cpp_callers.py`);
- offsets de campo e slots de vtable lidos das tabelas do metadata (e, para vtable, tambem pelo campo `slot` do proprio MethodDef).

Cuidados que um leitor de assembly precisa ter (encontrados no caminho, nao sao erros dos docs): (a) o linker insere veneers (erratum 843419):
um `b #0x3f932d0` no meio de uma funcao (ex. `0x1f0500c`) executa `ldr x25,[x25,#0xd58]` e volta (`b #0x1f05010`); (b) algumas variaveis de metadata-usage
(ex. GOT `0x41c85c8`, `0x41b4e60`, `0x41c7a98`) tem bytes de alta entropia no arquivo e nao decodificam; para elas a classe so se prova pelo uso/callee, nao pela GOT.

## Tabela por tarefa

Legenda: C = CONFIRMADO, R = REFUTADO, NV = NAO VERIFICAVEL.

### T025/HANDLER/000032a8 (DestroyLevelItem / DestroyCurrentItems / genericos / vtable / offsets / helpers)
| # | Afirmacao | Veredito | Evidencia |
|---|---|---|---|
| 1 | `0x232b9ac` = `LevelUtils.DestroyLevelItem(LevelItem,bool)`, w20=shouldAddRestoreData, x19=levelItem | C | jsonl idx 34221; `mov w20,w1; mov x19,x0` em `232b9d8/dc` |
| 2 | `levelItem == null` -> LogError("levelItem is null!") e retorna | C | `232bac4 op_Equality(x19,null)`; `tbz w0` pula so se false; literal 19231 = "levelItem is null!"; `b 232bf6c` (epilogo) |
| 3 | `0x3ccb8d8` = `UnityEngine.Object.op_Equality` | C | jsonl 87070; semantica do ponto 2 |
| 4 | `GetComponentsInChildren<LevelItem>(true)` (includeInactive=true) | C | `232bb08 mov w1,#1`; GOT `0x41ba5d0` -> methodSpec -> `LevelItem` |
| 5 | Laco pula item destruido (`PWCUtils.IsDestroyed`) | C | `232bb7c/80 tbnz w0 -> 232bd5c` (continue); `0x2083020` = IsDestroyed |
| 6 | `OnBeforeDestroyLevelItemAction` e estatico `Action<LevelItem>` em LevelUtils +0x8, chamado antes do virtual | C | `232bb84..bb0` com class GOT `0x41da0b8` = LevelUtils; campo `+0x8` tipo `Action<LevelItem>` (metadata) |
| 7 | Virtual `+0x738` = slot 96 = `LevelItem.OnBeforeDestroyWhileInGameplay` | C | vtableMethods do typeDef 5880 e campo `slot` do MethodDef (96) |
| 8 | `+0x748` = slot 97 = `AddToCustomRestoreDataBeforeDestroyWhileInGameplay` | C | idem (slot 97) |
| 9 | `+0x508` = slot 61 = `DetachFromParentIfExists(bool)` chamado com `true` | C (nome/slot/arg) | idem (slot 61); `mov w1,#1` em `232bc10` |
| 10 | Base da vtable em `Il2CppClass+0x138` (slot=(off-0x138)/16) | C | tres slots independentes (61, 96, 97) coincidem com os offsets do asm so com base 0x138 |
| 11 | `child.gameObject.tag = "Destroyed"` (get_gameObject, set_tag) | C | `3cc84e4`/`3cc8a10`; literal 5282 = "Destroyed" |
| 12 | **`if (child != levelItem) child.DetachFromParentIfExists(true)`** | **R** | `232bbf8..c08`: `op_Equality(x23=child, x19=levelItem)`; `tbz w0,#0,232bc24` pula o detach quando **nao** sao iguais. O detach executa quando `child == levelItem` (so o proprio item raiz; os filhos nao sao desanexados no laco). Doc invertido |
| 13 | `shouldAddRestoreData` falso pula todo o bloco de restore | C | `232bc24 tbz w20,#0 -> 232bd5c` |
| 14 | `TryGetComponent<PDSceneObject>(out)`; falso -> LogError("No PDSceneObject found on levelItem["+name+"]") | C | `232bc3c/40 tbz w0 -> 232bcfc`; literais 9682 e 15955 ("]"); `Concat` 3 args `31dfa68` |
| 15 | sceneGuid em `pd+0x20`; `IsNullOrEmpty` verdadeiro -> pula | C | `232bc4c ldr x0,[x8,#0x20]`; `tbnz w0 -> 232bd5c`; offset 0x20 pela tabela |
| 16 | `LevelDefaultData.TryGetSceneOwnerForItem(guid,out owner)` verdadeiro -> `LevelDefaultDataItemsToRestore.AddItem(owner,guid)` | C | `232bca0/a4 tbz -> 232bd70`; `232bcd4 x0=owner,x1=guid; bl 22c9f64` |
| 17 | Senao: `InventoryManager.Instance.ItemsTracker.IsTrackingSceneGuid(guid)` -> `AddItemToRestore(guid)` | C | `Instance` estatico +0x8, `ItemsTracker` +0x38 (tabela de campos); `213f900`/`213fb38` |
| 18 | Senao (nao rastreado): virtual `+0x748` | C | `232be0c tbz w0 -> 232be94 -> blr [x8+0x748]` |
| 19 | Pos-laco: `TryGetComponent<LevelCAHandlerBase>` e `GetComponentInParent<ICATarget>` (0 args) | C | GOT `0x41b8ad8` e `0x41d6210` decodificados em methodSpecs; `cbz x0 -> 232bf08` |
| 20 | `RemoveCAHandlersAndUpdateGame(target, handler.gameObject, false)` | C | `232bee0..f04`: x0=target, x1=get_gameObject(handler), w2=0 |
| 21 | Depois: `SetActive(false)`, detach virtual(true) no proprio item, `Object.Destroy(gameObject)` | C | `232bf18..f68` (w1=0 em SetActive; `0x508` com w1=1; `3ccf03c`) |
| 22 | Corpo ocupa `0x232b9ac..0x232bf94` (1512 B) | C | proximo prologo em `232bf94` |
| 23 | DestroyCurrentItems = `0x1e64abc`: se `_isNewEveryLoad`(+0x38), para cada `_points`(+0x30) nao nulo com `childCount>=1`: `GetChild(0).GetComponent<LevelItem>()` -> `DestroyLevelItem(x,true)` | C | `1e64aec ldrb [x19,#0x38]; cbz`; `1e64b2c..b60`; `3cd5d98`=get_childCount, `3cd61fc`=GetChild; sem cbz apos `24f0700` (null segue p/ DestroyLevelItem) |
| 24 | `0x24f0700` = Component.GetComponent<T>() generico (T=LevelItem), via `GetTypeFromHandle`+`GetComponentFastPath` | C | disasm `24f0700..24f0790`; GOT `0x41aceb8` -> `Component.GetComponent<LevelItem>` |
| 25 | Tabela de offsets (LevelSpawnOnLevelPostInit `_points 0x30`/`_isNewEveryLoad 0x38`, PDSceneObject `sceneGuid 0x20`, InventoryManager `Instance 0x8` / `ItemsTracker 0x38`, LevelUtils `OnBeforeDestroyLevelItemAction 0x8`, InventoryItemsTracker `_itemsState 0x10`) | C (7/7) | `fieldOffsets[typeIdx]` lido por mim |
| 26 | Tipos: LevelCAHandlerBase 6253, ICATarget 6281, PDSceneObject 4923, LevelItem 5880 | C | nomes dos typeDefs |
| 27 | `0x1b88980` = NRE, `0x1b88988` = IOORE (strings `System`/`NullReferenceException`/`IndexOutOfRangeException`) | C | `0x1b48f78`/`0x1b48fc4`; rodata `0xb32dce`, `0xb42dd5`, `0xb49f4d` |
| 28 | `0x1b8885c` = ClassInit (retorna se `[klass+0xe0]!=0`) | C | `1bbd2d8: ldr w8,[x22,#0xe0]; cbz...; ret` |
| 29 | `0x1b886e8` = resolve lazy de metadata-usage (type/method/string) | NV (so por padrao de uso) | e wrapper de `0x1bc8270 -> 0x1b561d0`; corpo nao lido |

### T025/HANDLER/00002d72 (LevelDigHoleArea)
| # | Afirmacao | Veredito | Evidencia |
|---|---|---|---|
| 30 | `OnBeforeSceneLoadStage1` (`0x1e29da8`, MethodDef 11634) = `b 0x1e299b4` (tail-call), helper = MethodDef 11635, 596 B | C | `1e29da8: b #0x1e299b4`; fim em `0x1e29c08` |
| 31 | `if (IsInteractable) return` (+0x51 de LevelDigArea) | C | `1e29a2c ldrb [x19,#0x51]; cbnz -> 1e29b58 (ret)`; campo 0x51 em typeDef 2061 (pai de DigHoleArea) |
| 32 | `_containerAreaLevelItems` (+0x78) `Clear()` inline (version++, size=0, Array.Clear(items,0,oldSize)) | C | `1e29a3c..5c`; `3379f00` = Array.Clear(3 args) |
| 33 | `_containerArea` (+0x68) `.GetImmediateChildrenItems()` (`0x227b1f8`, LevelConsumerAreaBase) | C | `1e29a60..6c`; hierarquia LevelContainerArea < LevelDropArea < LevelConsumerAreaBase |
| 34 | `List<LevelItem>.Add` inline com slow path, depois `item.transform.SetParent(null)` (**1 arg**, `0x3cd4fac`) | C | `1e29b2c..3c`: `x1=null,x2=null`; `3cd4fac` = SetParent(1 par.) (diferente de `3cd4ff4` = 2 par.) |
| 35 | Enumerator.Dispose em todos os caminhos (try/finally) | C | `1e29b44 -> 29c0b1c` e landing pad `1e29b94..` |
| 36 | GOTs `41b55c8/d0/d8/e0`, `41bb1e0/e8` = Dispose/MoveNext/get_Current/GetEnumerator, Add/Clear de `List<LevelItem>` | C | methodSpecs decodificados; nota: `get_Current` nao e chamado, e lido inline (`ldr x20,[sp,#0x30]`) |
| 37 | Campos `_containerArea 0x68`, `_containerAreaLevelItems 0x78`, tipos | C | tabela; tipos `LevelContainerArea` e `List<LevelItem>` |
| 38 | (omissao) Doc diz que so `OnBeforeSceneLoadStage1` chama o helper | R parcial | `OnGamePause` (`0x1e299b0`) tambem e `b 0x1e299b4`: o desanexar tambem roda ao pausar. A conclusao "antes de carregar a cena" fica incompleta; `OnGameResume` (`0x1e29c08`) e outra funcao de mesma forma, nao analisada |

### T025/HANDLER/00003cd1 (LevelSlideSwitcherHandler)
| # | Afirmacao | Veredito | Evidencia |
|---|---|---|---|
| 39 | `OnBeforeSceneLoadStage1` (`0x1f04f28`, 32 B): `if (_isInsideSlide[+0x30]) SaveItemInBulkData(ref changed)` | C | `1f04f30 ldrb [x0,#0x30]; cbz -> ret` |
| 40 | Campos 0x20/0x28/0x2c/0x30/0x31 | C | tabela |
| 41 | `if (_includeRoot)` percorre `SceneManager.GetActiveScene().GetRootGameObjects()`, `TryGetComponent<ILevelLivingBeing>` E `TryGetComponent<LevelItem>` -> SetInSildeData | C | `1f04fb4 cbz`; `3cdb658/3cdae08`; ambos `tbz w0` pulam; GOTs reais `0x41bfb18` e `0x41bad58` (via veneer `0x3f932d0`) |
| 42 | Depois: `foreach _dropAreas -> GetSingleLevelItem()`, se `!= null` -> SetInSildeData | C | `1f050a8..e4`: `tbnz w0` (item==null) pula |
| 43 | SetInSildeData: `is LevelCharacter` -> `[+0x388].FreeHands()` | C | GOT `41ace48`=LevelCharacter; `+0x388` = `<InteractionHandler>k__BackingField` (agora **confirmado** pela tabela; o doc dizia "nao confirmado"); `22a3214` |
| 44 | `is LevelToddler` -> `FreeHands()` | C | GOT `41ad358`; `2340a54` |
| 45 | `changed = true`; `transform.SetParent(null, true)` (2 args) | C | `strb 1,[x21]`; `x1=null,w2=1; bl 3cd4ff4` |
| 46 | Chave `"Slide_" + _currentLevelType.ToString()` (+0x28, nao `_nextSceneLevelType`) | C | box de `LevelType` com valor de `[x20,#0x28]` em `1f0535c`; `Enum.ToString`, `Concat(2)`; literal 12387 = "Slide_" |
| 47 | `SeparatedPDManager.AddToBulkData(key, item.GetPDPrefab())`, depois `DestroyLevelItem(item,true)` | C | `1f05388` (GetPDPrefab), `1f053b0` (AddToBulkData x0=key,x1=pd), `1f053b8..c0` (w1=1) |
| 48 | Digitos de GOT do doc (`0x41bf0b18`, `0x41ba0d58`) | R (erro de grafia) | corretos: `0x41bfb18`, `0x41bad58`. Sem impacto semantico |

### T025/METHOD GameSceneManager.LoadScene / LoadSceneImplement / lambda
| # | Afirmacao | Veredito | Evidencia |
|---|---|---|---|
| 49 | Campos estaticos de GameSceneManager (Stage1 0, Stage2 8, Stage3 0x10, Suffix 0x18, Previous 0x20, Loading 0x28, InProgress 0x30, Override 0x38, MP 0x40) | C | tabela |
| 50 | `LoadScene` (`0x20728d4`): closure sceneName +0x10, considerMultiplayer +0x18 (byte), mp_nextSceneId +0x20 | C | `20729ac..cc` |
| 51 | Trava ligada; se ja ligada -> LogError("Scene loading is already in progress!") e sai | C | `2072a1c cbz w8 -> 2072a5c`; literal 11931; tail `b 3ca5b88` |
| 52 | Ordem: ClearAllTextureData, SUTUtils.ClearTexturesCache, CarPartsLoader.ClearLoadedParts, CarAppearance.ClearIconCache, trava=1, Loading=sceneName, Previous=GetActiveSceneName | C | `2072a78/a98/ab8/ad8/b28/b30/b38..48` |
| 53 | Stage1, Stage2, Stage3 (null-guarded) nessa ordem (+0, +8, +0x10) | C | `2072b58..bd0` |
| 54 | `LoadingScreenManager.Instance.StartSceneTransition(new Action(closure.<LoadScene>b__0))` tail-call | C | `1b88970` (new), `32cd13c` Action..ctor, `b 20fe2d8`; unico chamador direto de `20fe2d8` e `LoadScene` (varredura propria) |
| 55 | Lambda: `single = !(sceneName != "Home" && consider && IsMultiplayerGame && !IsHostAndOnlyPlayer())` | C | `31df55c` = `String.op_Inequality`; `tbz w0 -> 2073578` (igual a "Home" -> single); `cbz [x19,#0x18]`; `ldrb [statics+0]` (MPManager.`<IsMultiplayerGame>` +0x0); `20d2c6c tbz -> multiplayer`. Direcao correta |
| 56 | Ramo multiplayer: host -> `MPData_SceneChangeRequest{guid +0x28, from +0x30, to +0x38, base +0x10 = 1}` + `SendWaitForPlayerForSceneChangeRequest`; nao-host -> `TrySendEvent(from,to,guid)`; depois `DestroyAllGameObjectsInLoadedScenes`, `ClearPlayerFromScenes(GetPlayerUID())`, `Multiplayer_LoadingSceneNameInProgress=sceneName`, **sem** `LoadSceneImplement` | C | `20735ac..2073784`; `to = mp_nextSceneId ?? sceneName` (`cbnz x1`) ; `IsHost tbz -> 20736b0` e o ramo nao-host |
| 57 | `LoadSceneImplement` (`0x2072cc8`): se `MPManager.IsMultiplayerGame` -> `MPOwnership.Clear()`; `SceneManager.LoadSceneAsync(sceneName)` (1 arg, retorno descartado) | C | `2072d34..5c`; GOT `0x41b5350` = **MPManager** (decodifica; o doc dizia "nao decodificado") -> upgrade de media para alta |
| 58 | Offline (`IsMultiplayerGame==false`) sempre cai em `LoadSceneImplement` | C | `2073578..590` |

### T025/METHOD GetCurrentWorldSceneName, ciclo da trava, WorldBuilding.ClickOnLevel, chamadores
| # | Afirmacao | Veredito | Evidencia |
|---|---|---|---|
| 59 | `GetCurrentWorldSceneName` (`0x2073238`): `default=((LevelWorldType)1).ToString()`; `saved=PlayerPrefs.GetString("GAME_CURRENT_WORLD", default)`; retorna `IsSceneAvailable(saved)? saved : default` | C | box int 1 em `20732a0/b0`; literal 6540; `tst w0; csel x0,x20(saved),x19(default),ne`. `LevelWorldType.World` = 1 (fieldDefaultValues, codificacao comprimida 2 -> 1) |
| 60 | Trava +0x30 so e zerada em `OnActiveSceneChanged` (`0x2072644`) e `CancelCurrentSceneChangingProgress` (`0x207256c`), junto com +0x28 e +0x40; `set_IsSceneChangingInProgress` sem chamador direto | C (para os dois sites e o setter) / NV (exclusividade) | ambos fazem `strb wzr,[statics,#0x30]` e `str xzr,[+0x40]`,`[+0x28]`; varredura de `bl/b` ao setter: 0 hits. Nao varri escritas diretas de `+0x30` em todo o binario |
| 61 | ClickOnLevel (`0x2108e90`): `OnClickBuildingAction?.Invoke(this,level)`; `MarkBuildingAsInteracted(_buildingType)`; `SetFocusedBuildingType`; `useTimeLock(+0x73) || IsCurrentlyFree() || IsGameUnlocked()` | C | `2108ec8..a0`: `cbnz` (useTimeLock) e `tbnz` (IsCurrentlyFree) levam ao ramo liberado; `tbz` de IsGameUnlocked leva ao bloqueado. Offsets `_buildingType 0x48`, `OnClickBuildingAction 0x88`, `OnClickAction 0x90`, `SettingsManager._extraSettings 0x28`, `GameExtraSettings.useTimeLock 0x73` pela tabela |
| 62 | Ramo liberado: `OnClickAction.Invoke`, `SaveBuildingData(_buildingType, level)`, `this.LoadScene(GetSceneName(level))` virtual slot 22 | C | `+0x298` = slot 22 = `WorldEnterableEntity.LoadScene` na vtable de WorldBuilding (metadata) |
| 63 | Ramo bloqueado: `TryGetRemoteConfigItem(out item)` + `WorldBuildingPreviewPopup.Show(buildingType,item)` | C | `2108ff4..2109008` |
| 64 | Chamadores diretos de ClickOnLevel: `WorldBuilding.OnPointerClickInternal` e `WorldBuildingLevel.OnPointerClick` | C | varredura propria |
| 65 | 50 chamadores diretos de `LoadScene` | C com ressalva | varredura propria: **50 call sites em 49 metodos** (`LevelInstancedLevelExitSwitcher.LoadScene` tem 2); todos os nomes citados no doc aparecem (inclusive `StarsPass`, `BWYW`, `MPUtils`) |

### T025/METHOD HomePlayButton.LoadPlayScene
| # | Afirmacao | Veredito | Evidencia |
|---|---|---|---|
| 66 | `InteractionHistoryManager.Instance.OnClickHomePlayButton()` primeiro | C | `2058030..44` (Instance = statics+8) |
| 67 | `if (PlayerPrefs.HasKey("pazucore_pending_deep_link"))`; falso -> `GetCurrentWorldSceneName()` | C | `2058050 HasKey; tbz w0 -> 20580ac`; literal 20002 |
| 68 | Verdadeiro: `SoundManager.Stop(1001)` (0x3e9), `GetString(key,"")`; vazio -> level = 2 | C | `2058070 mov w1,#0x3e9`; literal default id 0 = ""; `tbz w0 -> 20580d4` (nao vazio -> mapa); vazio `mov w19,#2` |
| 69 | `LevelType` 2 = `GirlsRoom_Z1B1L2` | C | fieldDefaultValues (2 decodificado de 4); 1 = GirlsLivingRoom_Z1B1L1 |
| 70 | Nao vazio: `DeepLinkManager.Instance._mapLinkToLevel(+0x28)` via despacho de interface, slot 0 = `IDictionary<string,LevelType>.get_Item(key)` | C (inferencia forte) | `2058104..174`; classe da interface (GOT `0x41c7a98`) **nao decodifica**; mas `IDictionary`2` tem `get_Item` como metodo 0 e a propriedade `get_MapLinkToLevel` retorna `IDictionary<string,LevelType>` (metadata); o campo e `SerializableDictionaryBase<string,LevelType>` |
| 71 | Depois: `DeleteKey`, `Save`, `SaveBuildingData(0, level)`, `GetSceneName(level)`, `LoadScene(scene,true,null)` tail-call | C | `2058184..1e4`: w0=0, w1=level; `w1=1,x2=0,x3=0; b 20728d4` |

## Discordancias e erros achados
1. **ERRO (semantico)** `RECON_DESTROYLEVELITEM`: o detach virtual (`+0x508`, `DetachFromParentIfExists(true)`) dentro do laco e executado quando
   `child == levelItem`, nao `!=`. `232bc04 bl op_Equality; 232bc08 tbz w0,#0,232bc24`. So o proprio item raiz e destacado no laco (e de novo depois do laco);
   os filhos sao destruidos junto com o pai. Corrigir o pseudo-codigo e a frase "filhos no laco e depois o proprio item" em `RECON_LEVELITEM_VTABLE`
   (tabela, linha `+0x508`): no laco e so o proprio item.
2. **Omissao** `RECON_DIGHOLE_DETACH`: `OnGamePause` (`0x1e299b0`) tambem e tail-call para o helper; a descricao "antes de carregar a cena" cobre so um dos dois gatilhos.
3. **Texto obsoleto** `RECON_DESTROYLEVELITEM` ("Confianca / ainda aberto"): ainda diz "os dois usos finais nao foram decodificados" e cita `GetComponent<Y>`, contradizendo
   `RECON_GENERIC_USAGES`. Idem `RECON_RUNTIME_HELPERS`, secao "Ainda aberto", e a nota sobre `GetComponent<Y>()` no bullet de DestroyLevelItem.
   `RECON_FIELD_OFFSETS` e `RECON_LEVELITEM_VTABLE` ("Ainda aberto") tambem ficaram com listas de pendencias ja fechadas.
4. **Grafia** `RECON_SLIDE_SWITCHER`: GOT `0x41bf0b18` -> `0x41bfb18`; `0x41ba0d58` -> `0x41bad58`.
5. **Contagem** `RECON_SCENE_NAVIGATION_GRAPH`: "50 chamadores diretos" = 50 call sites em 49 metodos.
6. **Melhorias (nao sao erros)**: `LevelCharacter+0x388` e `<InteractionHandler>` (confirmado); GOT `0x41b5350` e `MPManager` (confirmado); `0x41b55d8` (`get_Current`)
   so aparece no prologo de inicializacao, o laco le o campo inline.
7. **Limitacoes que continuam**: identidade do slot de interface em `0x2058174` e inferida (GOT sem decodificar); `0x1b886e8` so por padrao de uso; exclusividade dos
   escritores de `IsSceneChangingInProgress` nao provada por varredura global; nada validado dinamicamente.

## Veredito por tarefa
| Tarefa | Veredito | Afirmacoes verificadas |
|---|---|---|
| T025/HANDLER/000032a8 (6 docs) | **Aceitar com ressalvas**: corrigir o item 1 (sentido do `if` do detach) e limpar texto obsoleto antes de marcar done | 29 (27 C, 1 R, 1 NV) |
| T025/HANDLER/00002d72 | **Aceitar com ressalvas**: incluir o gatilho `OnGamePause` | 9 (8 C, 1 R parcial) |
| T025/HANDLER/00003cd1 | **Aceitar** (apenas erro de grafia de GOT) | 10 (9 C, 1 R de grafia) |
| T025/METHOD LoadScene / LoadSceneImplement | **Aceitar** | 10 C |
| T025/METHOD GetCurrentWorldSceneName, ClickOnLevel, grafo | **Aceitar com ressalvas** (contagem de chamadores; exclusividade da trava nao provada) | 7 (6 C, 1 parcial) |
| T025/METHOD HomePlayButton.LoadPlayScene | **Aceitar** | 6 C |

Total: 71 afirmacoes verificadas (62 confirmadas, 2 refutadas de forma substantiva (detach `!=`, omissao `OnGamePause`), 1 refutacao de grafia, 3 com ressalva/NV, restante com notas).
