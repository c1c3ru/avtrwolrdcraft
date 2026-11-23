# Recon estático dos botões da Home sem ação — 2026-11-23

Método: `tools/recon_disasm.py` (AArch64 com Capstone, chamadas e strings resolvidas) sobre `out/recon/il2cpp/libil2cpp.so`.
Reinstalar o ambiente: `tools/venv/bin/python -m pip install -r tools/requirements-recon.txt`. O script agora usa
`out/recon/il2cpp` do próprio repositório (antes apontava para um checkout que não existe mais). Saídas brutas em
`out/recon/home_buttons/*.asm` (não versionadas). **Estático apenas: nada foi validado em aparelho.**

## Resultado por botão

| Botão da Home | Classe / método lido | O que o binário mostra | Dá para fazer offline? |
|---|---|---|---|
| `HolidayButton` | `Game.World.HolidayGameModeButton.OnButtonPress` | Alterna o "modo feriado": grava o clima de cada mundo de uma lista estática com `WeatherManager.SaveWeatherForWorld(mundo, 8)` (`SetHolidayWeatherOnWorlds`), liga as caçadas de evento (`HuntsAchievementData.TryEnableEventHunt`), chama `WorldResetManager.ResetStorePack` e toca som. Só aparece se há feriado ativo (`MatchActiveStateIfHolidayIsAvaileable` → `HolidayConfig.GetExcludeHolidaysValue`, config remota). | **Parcial.** O clima 8 é Halloween (nota em `tools/build_interior_slice.py`). O cliente só tem clima 0/1/6 em `sky.json`; falta extrair o céu do clima 8. As caçadas e o reset de pacote dependem de dados que ainda não temos. |
| `AvatarPassButton`, `AvatarPassButton_Small`, `World_ShopButton` (passe) | `StoreAvatarPassButton.OnClick` → `StoreAvatarPassPurchaseWindow.Show`; `StoreAvatarPassGiftsButton.OnClick` → `StoreUtils.ShowStoreAndFocusOnAvatarPassGiftsCategory` | Só abrem janela de compra/loja focada na categoria de presentes do passe. A compra é IAP e o estado vem do servidor (`StoreAvatarPassNextRewardStatusCloudResponse`). | Não: compra com dinheiro real e dados do servidor. |
| `AvatarPassChangeWidget` | `AvatarPassChangeWidget.OnClick` → `AvatarPassChangeWindow.Show` | Janela de troca de plano; o `AvatarPassChangeWindow` tem `OnManageSubscriptionsButtonClick` e `SendAcceptToCloud`. | Não: assinatura e nuvem. |
| `NewUserGiftCurrency` | `StoreNewUserGiftCurrencyButton.OnClick` | Abre a loja (`StoreViewManager.Show`) no item de moeda de presente (`_itemIndex is -1!` se não achar). Resgate pede ID de avatar (`OnClickWhileRequireAvatarID`). | Não: depende de conta e do servidor. |
| `GiftsWidget`, `ClothesDropGiftsWidget` | `HomeNewClothesDropBadge.Init` → `ClothesDropUtils.CheckIsAnyNewDropExist` | É uma **bolinha de "novo"**: compara o drop de roupas vigente (`ClothesDropDataMap.GetDropDataForTime`, por data) com o último visto (`GetLastDropNameSeen`). A janela de drops é por data e vem de `ClothesDropDataMap`. | **Parcial.** Precisa dos dados de `ClothesDropDataMap` (asset) e de uma regra de datas; hoje não temos o conteúdo. |

## Conclusões

1. Passe, presente de novo usuário e troca de plano são compra/assinatura/conta: continuam fora do escopo (`NOT_REPRODUCED.md`).
2. O candidato real é o **modo feriado**: lógica curta e clara. Falta o céu Halloween (clima 8) e saber a lista de mundos
   da lista estática (`0x1db2508`, campo estático lido em `adrp x19, #0x41b7000 + 0xd00`). Próximo passo: extrair a lista e o
   `WorldWeather.Halloween` dos assets, depois ligar o `HolidayButton` ao sistema de céu do cliente.
3. Os drops de roupa dependem de um asset `ClothesDropDataMap` (cai no grupo T020/ScriptableObject); não tentado.

## Limites desta leitura

- Corpos de métodos lidos por disassembly, sem decompilação semântica: valores como o `8` e a lista de mundos foram lidos no
  código, não executados.
- A identificação do clima 8 como Halloween vem de uma nota do próprio projeto, não foi reconfirmada aqui no enum original.
