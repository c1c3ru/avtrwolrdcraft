# Recon estático dos botões da Home sem ação — 2026-11-23

Método: `tools/recon_disasm.py` (AArch64 com Capstone, chamadas e strings resolvidas) sobre `out/recon/il2cpp/libil2cpp.so`.
Reinstalar o ambiente: `tools/venv/bin/python -m pip install -r tools/requirements-recon.txt`. O script agora usa
`out/recon/il2cpp` do próprio repositório (antes apontava para um checkout que não existe mais). Saídas brutas em
`out/recon/home_buttons/*.asm` (não versionadas). **Estático apenas: nada foi validado em aparelho.**

## Resultado por botão

| Botão da Home | Classe / método lido | O que o binário mostra | Dá para fazer offline? |
|---|---|---|---|
| `HolidayButton` | `Game.World.HolidayGameModeButton.OnButtonPress` | Alterna o "modo feriado": grava o clima de cada mundo de uma lista estática com `WeatherManager.SaveWeatherForWorld(mundo, 8)` (`SetHolidayWeatherOnWorlds`), liga as caçadas de evento (`HuntsAchievementData.TryEnableEventHunt`), chama `WorldResetManager.ResetStorePack` e toca som. Só aparece se há feriado ativo (`MatchActiveStateIfHolidayIsAvaileable` → `HolidayConfig.GetExcludeHolidaysValue`, config remota). | **Feito (parcial).** Lista de mundos e clima resolvidos (abaixo); implementado como chave local. Caçadas, reset de pacote e a regra de "só com feriado ativo" não foram reproduzidos. |
| `AvatarPassButton`, `AvatarPassButton_Small`, `World_ShopButton` (passe) | `StoreAvatarPassButton.OnClick` → `StoreAvatarPassPurchaseWindow.Show`; `StoreAvatarPassGiftsButton.OnClick` → `StoreUtils.ShowStoreAndFocusOnAvatarPassGiftsCategory` | Só abrem janela de compra/loja focada na categoria de presentes do passe. A compra é IAP e o estado vem do servidor (`StoreAvatarPassNextRewardStatusCloudResponse`). | Não: compra com dinheiro real e dados do servidor. |
| `AvatarPassChangeWidget` | `AvatarPassChangeWidget.OnClick` → `AvatarPassChangeWindow.Show` | Janela de troca de plano; o `AvatarPassChangeWindow` tem `OnManageSubscriptionsButtonClick` e `SendAcceptToCloud`. | Não: assinatura e nuvem. |
| `NewUserGiftCurrency` | `StoreNewUserGiftCurrencyButton.OnClick` | Abre a loja (`StoreViewManager.Show`) no item de moeda de presente (`_itemIndex is -1!` se não achar). Resgate pede ID de avatar (`OnClickWhileRequireAvatarID`). | Não: depende de conta e do servidor. |
| `GiftsWidget`, `ClothesDropGiftsWidget` | `HomeNewClothesDropBadge.Init` → `ClothesDropUtils.CheckIsAnyNewDropExist` | É uma **bolinha de "novo"**: compara o drop de roupas vigente (`ClothesDropDataMap.GetDropDataForTime`, por data) com o último visto (`GetLastDropNameSeen`). As peças viram uma sacola de tempo limitado (`LevelLimitedTimeClothesDrop`). | **Feito (parcial).** Os dados já estavam decodificados em `out/mb`; ver "Drops de roupa" abaixo. |

## Dados recuperados nesta rodada

- **Lista de mundos do feriado**: o `.cctor` de `HolidayGameModeButton` (`0x1db332c`) cria um array de 4 `LevelWorldType` e o inicializa por
  `RuntimeHelpers.InitializeArray`. O blob está no `global-metadata.dat`: fieldRef 15 de `<PrivateImplementationDetails>` (typedef 6304,
  `fieldStart` 45012 + 15) → `fieldDefaultValues` → `fieldAndParameterDefaultValueData`. Vale **`[1, 3, 4, 6]`** = World, StarDustCity,
  Countryside, College (`PWC.Game.LevelWorldType`: None 0, World 1, Vacation 2, StarDustCity 3, Countryside 4, SnowyMountain 5, College 6).
- **`WeatherType`** (typedef 1690), constantes de enum lidas como inteiros comprimidos do metadata (o valor bruto não serve): Clear 0, Rain 1,
  Snow 6, Snow_Xmas 7, **Halloween 8**. Isso confirma a nota antiga do projeto. O céu do clima 8 é o `BackgroundSkyConfig` 721801 (já em `out/mb`).
- **Drops de roupa**: `PWC.Level.ClothesDropDataMap` (6 lojas) e os `PDTextBulkData` `ClothesDrop_BulkData_<Tema>_LD<n>_L<nivel>` (71 drops datados,
  2024-06 a 2025-09, 378 peças distintas) já estavam em `out/mb`; não dependiam do UnityPy.
- Método para ler constantes do metadata: header v31, tabelas `fieldRefs`, `fields` (12 bytes), `fieldDefaultValues` (12 bytes) e
  `typeDefinitions` (88 bytes; `fieldStart` no inteiro 8, `field_count` no `ushort` baixo do inteiro 17). Inteiros de enum usam a codificação
  comprimida de il2cpp (1 byte se < 0x80; zigzag: par = n/2, ímpar = -(n+1)/2).

## Conclusões

1. Passe, presente de novo usuário e troca de plano são compra/assinatura/conta: continuam fora do escopo (`NOT_REPRODUCED.md`).
2. O **modo feriado** foi implementado no cliente com a lista e o clima acima (ver `LOOP_STATE.md`).
3. Os **drops de roupa** também: o asset estava decodificado, o cliente ganhou o painel "Novidades de roupas" e a bolinha de "novo".

## Limites desta leitura

- Corpos de métodos lidos por disassembly, sem decompilação semântica: valores como o `8` e a lista de mundos foram lidos no
  código, não executados.
- O caminho de "desligar" do `OnButtonPress` e o corpo de `GetDropDataForTime` não foram lidos.
