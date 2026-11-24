# Re-baseline no build instalado (1.230): o que mudou em relação ao que analisamos — 2026-11-24

O aparelho do usuário (Xiaomi M2101K7BI, Android 13, bootloader travado, sem root) tem o original **1.230** (versionCode 231, Play Store). Os APKs foram baixados com `adb pull`
(só leitura, nada alterado no app nem no aparelho) para `out/device/installed-1.230/` (não versionado). O que analisamos até aqui vinha de um build **mais antigo**.

| | analisado até aqui | instalado (1.230) |
|---|---|---|
| `libil2cpp.so` sha256 | `b63661fa60c2...` (74.680.624 bytes) | `7635d66d61a0...` (74.795.312 bytes) |
| `global-metadata.dat` | v31, 16.072.324 bytes | v31, 16.143.736 bytes (sha `f8208949...`) |
| Unity | 2022.3.70f1 | 2022.3.70f1 |
| Métodos de Assembly-CSharp | 36.421 | 36.648 (+227) |

Ferramentas novas (todas sobre uma pasta com o par `libil2cpp.so` + `global-metadata.dat`):
`tools/recon_il2cpp_pair.py` (gera as tabelas de métodos), `tools/recon_rebaseline.py` (compara dois builds método a método) e `tools/recon_static_array.py`
(lê um array estático de um `.cctor`; reproduz o `[1, 3, 4, 6]` do build antigo). Dados em `out/recon/il2cpp_1.230/`.

## Resultado geral
Chave do método = (tipo, nome, nº de parâmetros); corpo = sequência de instruções normalizada (endereços, páginas, alvos de desvio e deslocamentos de slot da `.got` mascarados).
- Comparados: **33.860** métodos em comum → **32.384 idênticos (95,6%)**, **1.476 diferentes (4,4%)**. Removidos: 177. Novos: 403.
- Observação: métodos sobrecarregados com o mesmo nome e nº de parâmetros colidem na chave, então os totais (34 mil) ficam abaixo dos 36 mil métodos.

## O que importa para o que já implementamos

| Assunto | Resultado em 1.230 |
|---|---|
| Lista de mundos do modo feriado | **Igual**: `[1, 3, 4, 6]` (World, StarDustCity, Countryside, College), lida do metadata novo; `.cctor` e `SetHolidayWeatherOnWorlds` idênticos. |
| `WeatherType` | **Igual**: Clear 0, Rain 1, Snow 6, Snow_Xmas 7, Halloween 8. |
| `HolidayGameModeButton.OnButtonPress` | Mesmo corpo; só mudaram 2 deslocamentos de campo (`+0x10` → `+0x18`, um campo foi reposicionado numa classe). Sem mudança de lógica. |
| `HolidayConfig.GetExcludeHolidaysValue` | **Mudou**: antes era `PlayerPrefs.GetInt(chave, 1)`. Agora, se um `static bool` novo (em `static_fields+8`) é falso, **retorna 1** sem ler a preferência; se verdadeiro, lê como antes. Não sei o que liga esse flag. `Awake` do botão cresceu (50 → 74 instr.) e não foi lido. |
| Drops de roupa | **Regras iguais**: `GetDropDataForTime`, `CheckIsAnyNewDropExist`, `OnLevelEnter`, `GetLastDropNameSeen`, `MarkLastSeen` e `GetUnixTimeFromDate` (14:00 UTC) idênticos. **Os dados (agenda) não foram comparados**: estão no `split_UnityDataAssetPack.apk` (1,5 GB), e a agenda do build antigo terminava em 2025-09. |
| `HomePlayButton.LoadPlayScene` | **Idêntico** (145 instr.). `GameSceneManager.LoadScene` perdeu 2 guardas de inicialização de classe (226 → 215 instr.); `WorldBuilding.ClickOnLevel` ganhou 1 instrução. |
| Botões de passe e presente de novo usuário | Idênticos (`StoreAvatarPassGiftsButton.OnClick`, `StoreNewUserGiftCurrencyButton.OnClick/Start`). |
| `WorldResetManager` (`ResetScene`, `ResetWorldData`, ...) | Mudaram com o mesmo nº de instruções; não li a diferença. |
| Bloco de 6.390 entradas da tabela de usos | **Presente de novo**, mesmo tamanho (6.390), agora em `0x4300c20`..`0x430d3c8`. Tamanho fixo entre builds, enquanto as demais categorias cresceram: indício de que não escala com o código do jogo. |

## Limites
- A normalização pode chamar de "idêntico" um método em que só mudou uma constante grande ou um slot de `.got`; e chamar de "diferente" algo trivial (como o deslocamento de campo acima).
- Só código foi comparado. Assets e dados serializados (agenda de drops, preços, `_mapLinkToLevel`) do 1.230 não foram lidos.
- Nada foi executado: o app instalado não foi aberto nem alterado. Sem root não há leitura da memória do processo, e destravar o bootloader não foi proposto nem feito.
