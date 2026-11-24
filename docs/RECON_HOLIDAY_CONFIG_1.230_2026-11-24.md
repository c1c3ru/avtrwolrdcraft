# Modo feriado no 1.230: o que o `HolidayConfig` novo faz — 2026-11-24

Continuacao de `RECON_REBASELINE_1.230_2026-11-24.md`. Leitura estatica (Capstone) no build instalado, `out/recon/il2cpp_1.230`. Ferramenta nova: `tools/recon_type_fields.py`
(lista os campos de um tipo no metadata).

## O que mudou
- `Game.HolidayConfig` ganhou um campo estatico: **`IsHolidayEventActive`** (bool). Campos agora: `PLAYERPREFS_Exclude_Holidays`, `EXCLUDE_HOLIDAYS_DEFAULT_VALUE` (1), `IsHolidayEventActive`, `HolidayKeys`, `PackTypeMap`.
- `HolidayConfig.GetExcludeHolidaysValue()`:
  - antes: `PlayerPrefs.GetInt(PLAYERPREFS_Exclude_Holidays, 1)`;
  - agora: `if (!IsHolidayEventActive) return 1; return PlayerPrefs.GetInt(PLAYERPREFS_Exclude_Holidays, 1);`.
  "1" significa **feriados excluidos**: sem evento ativo, o jogo ignora a preferencia do jogador e trata feriado como desligado. O padrao da preferencia tambem e 1.
- Metodo novo, `WeatherManager.ReplaceDisabledHolidayWeather(int weather)` (`0x1dbeb24`):
  `if (weather == 8 /*Halloween*/ && HolidayConfig.GetExcludeHolidaysValue() != 0) weather = 0 /*Clear*/; return weather;`
  Ou seja: um clima Halloween salvo vira Clear quando feriados estao excluidos, para o jogador nao ficar preso no clima depois que o evento acaba. (`GetWeatherForWorld` e `LoadWeatherForWorld`
  mudaram por pouco no build novo, 1 instrucao no primeiro; presumo que chamem esse metodo, **nao li as chamadas**.)
- `HolidayGameModeButton.Awake` (50 -> 74 instrucoes): depois de `ButtonBase.Awake`, testa um bool estatico (provavelmente `IsHolidayEventActive`) e, se falso, desvia para um trecho que
  chama um getter de `Object` e termina sem registrar os eventos de multiplayer; se verdadeiro, registra `MPManager.OnEnter/ExitMultiplayerAction` como antes. Presumo que esse desvio esconda o botao
  (coerente com `MatchActiveStateIfHolidayIsAvaileable.OnEnable`, que chama `GetExcludeHolidaysValue`), **mas nao confirmei o que o desvio faz**.
- Identificadores ja existentes nos dois builds e ligados ao assunto: `isHolidayEnabled`, `isEnableHolidayPopup` (campos que parecem de config remota), `EnableHoliday`, `DisableHoliday`,
  `ActivateHolidayWhenEnabled`, `skipHiddenHolidayPacks`, `_expectedHolidayActiveState`. Quem escreve `IsHolidayEventActive` nao foi identificado (a classe do slot cai no bloco de entradas nao decodificaveis).

## O que isso significa para o nosso modo feriado
- O que implementamos (chave local, sempre disponivel, desligada por padrao) **continua coerente** com a regra "o botao so aparece com feriado ativo": no original quem decide e uma config remota
  (`isHolidayEnabled` -> `IsHolidayEventActive`), que offline nao existe.
- Novidade a considerar: no original o clima Halloween **volta a Clear** quando o evento nao esta ativo. No cliente, desligar o modo ja devolve o clima salvo; nao ha estado "Halloween salvo" que precise ser trocado.
- Nao reproduzido: caçadas de evento e o reset de pacote da loja (ver `RECON_HOME_BUTTONS_2026-11-23.md`).

## Limites
Leitura estatica; nada executado. As inferencias marcadas acima ("presumo") nao foram confirmadas.
