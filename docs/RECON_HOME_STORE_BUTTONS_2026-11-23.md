# Botoes da Home ligados a loja: passe, presentes do passe e presente de novo usuario — 2026-11-23

Estatico (Capstone), `libil2cpp.so` sha256 `b63661fa60c2...`. Disassembly de entrada em `out/recon/home_buttons/*.asm`; campos por `tools/il2cpp_field_offsets.py`,
enum por Cpp2IL (`Store/StorePackType.cs`). Complementa `docs/RECON_*` e o "Passe de Avatar offline" do `LOOP_STATE.md`.

## OnClick de cada botao
| Botao | O que faz |
|---|---|
| `AvatarPassChangeWidget.OnClick` | tail call `AvatarPassChangeWindow.Show()` (`0x2196794`) |
| `StoreAvatarPassButton.OnClick` | `StoreAvatarPassPurchaseWindow.Show(false)` (`0x1d6efe0`, `w0=0`) |
| `StoreAvatarPassGiftsButton.OnClick` | `StoreManager.SourceValueForClaimCloudRequests = "StoreAvatarPassGiftsButton"` (estatico +0x10, gravado com write barrier) e tail call `StoreUtils.ShowStoreAndFocusOnAvatarPassGiftsCategory()` (`0x1da8648`) |
| `StoreNewUserGiftCurrencyButton.OnClick` | se `_itemIndex` (+0x38) == -1: `Debug.LogError("_itemIndex is -1!")`; senao `StoreManager.SourceValueForClaimCloudRequests = "StoreNewUserGiftCurrencyButton"`, `StoreViewManagerBase.FocusOnPackItemIndex = _itemIndex` (estatico +0x0) e `StoreViewManager.Show(null, null)` (`0x1d9a45c`) |

O campo `SourceValueForClaimCloudRequests` (`StoreManager` estatico +0x10) so rotula a origem do resgate nas chamadas ao servidor; offline nao tem equivalente. O passe de avatar
(compra, janela de troca de plano, presentes do passe) abre janelas que dependem de dados do servidor (`StoreAvatarPassNextRewardStatusCloudResponse`).

## StoreNewUserGiftCurrencyButton: quando o botao aparece (`<Start>d__5.MoveNext`, `0x1d74a80`)
Campos: `_view` 0x20, `_giftEnableEvents` 0x28, `_giftDisableEvents` 0x30, `_itemIndex` 0x38 (`UnityEvent`s). Corrotina:
```
_itemIndex = -1;
// aguarda os dados da loja (yield enquanto !StoreManager.Instance.IsDataReady(); dispara StoreManager.GetStoreData(null) se nao houver busca em andamento)
if (MPManager.IsMultiplayerGame)  show = false;                                   // GOT 0x41b5350 (mesmo estatico de LoadSceneImplement)
else {
    show = StoreUtils.TryGetNewUserGiftItemIndex(out _itemIndex)                  // 0x1d9f380 = TryGetPackItemIndex(StorePackType.NewUserGiftCurrency /*1000004*/, out idx)
           && StoreManager.Instance.CurrentData.<lista de itens>[_itemIndex].<estado /*+0x20*/> != 2;   // 2 = ja resgatado (inferido; enum nao confirmado)
}
_view.SetActive(show);
(show ? _giftEnableEvents : _giftDisableEvents).Invoke();
```
(`show` tambem fica falso se `PazuCore.Utils.IsEditor` e o objeto de referencia for nulo; ramo so de editor.)
- Provado: `1000004` = `StorePackType.NewUserGiftCurrency`; `TryGetNewUserGiftItemIndex` e um tail call de `TryGetPackItemIndex(GetPackName(1000004), out idx)`.
- A classe do item, `StorePackItemNewUserGiftCurrency` (`_currencyText` 0x38, `_claimButton` 0x40, `_isClaimingInProgress` 0x48), recebe o valor em `Init(Item)`; o valor da moeda
  e o resgate (`StoreClaimItemCloudResponse`) vem do servidor. **A quantia do presente nao esta no binario**: continua decisao do usuario (recompensa ficticia local).

## Efeito para o cliente offline
- Presente de novo usuario: nada a recuperar alem da regra de visibilidade acima (uma vez por conta, some quando resgatado). Implementacao local = flag "resgatado" no save e recompensa a definir.
- Passe: o desenho local ja existente (`AvatarPass.cs`) segue sendo do cliente; o original so abre janelas de compra/troca (dinheiro real).
- `ShopButton`/`World_ShopButton`: abre a loja pelos mesmos `StoreManager`/`StoreViewManager.Show`; sem lacuna de RE alem dos dados de servidor.

## Aberto
Enum do estado do item (`!= 2`), corpo de `StoreViewManager.Show`, `ShowStoreAndFocusOnAvatarPassGiftsCategory`, `AvatarPassChangeWindow.Show`. Validacao em aparelho; revisao independente.
