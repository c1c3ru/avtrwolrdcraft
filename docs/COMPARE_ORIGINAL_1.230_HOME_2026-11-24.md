# Original 1.230 no aparelho x o que reimplementamos (Home e Configuracoes) — 2026-11-24

Capturas feitas por `adb exec-out screencap` no Xiaomi M2101K7BI (Android 13) com o app **1.230** instalado pela Play Store, aberto pelo launcher e usado so para olhar:
Home (`docs/img/original-1.230-home.jpg`) e Configuracoes (`docs/img/original-1.230-settings.jpg`, reduzidas; originais 2400x1080 em `out/device/captures-2026-11-24/`, nao versionadas).
Nada foi tocado em compras, nem em "Reset Mode"; ao fechar, a Home voltou identica (mesmo hash). Uma captura = um estado de uma conta, em um dia: nao e inventario completo.

## Configuracoes do original
Titulo "SETTINGS" e quatro itens:
1. **RESET MODE** (botao laranja grande)
2. **SOUND**: ON/OFF
3. **MUSIC**: ON/OFF
4. **CHAT**: seletor de idioma, mostrando "PORTUGUES"

## O que isso confirma e o que difere do nosso cliente
| Item | Original (visto) | Nosso cliente |
|---|---|---|
| Rotulo do botao de reset | "**Reset Mode**": nome de um modo, coerente com `WorldResetManager.IsGameInResetMode`/`ExitResetGameModeButton` lidos no binario (nao e "apagar progresso") | `WorldResetButton` abre "Reiniciar progresso" (apaga o save, com duas confirmacoes). **Semantica diferente**: decisao nossa, mas o rotulo e o comportamento nao sao os do original. |
| Idioma | O seletor se chama **CHAT** e mostra o idioma do chat (bate com a leitura de `ChatLanguageButton`) | O mesmo botao troca o idioma da **interface** (decisao do usuario, funcionalidade nossa). |
| Sound / Music | Dois interruptores ON/OFF com icone | Igual (SFX e Musica em `SettingsMenu`). |
| Textos | Em ingles (a interface do original esta em ingles; so o chat esta em Portugues) | Interface em portugues por padrao, com pt/en/es/id. |

## Home do original
Elementos visiveis: Avatar ID com "+" (canto superior esquerdo), banner "ON THE ROAD!" (tema do evento/combos de veiculo atuais), coracao "Rate Us", engrenagem (Settings), icone de pessoas
(conta), carrinho de compras com estrela (loja, com marca de novidade), botao Play grande, botao de globo com dois bonecos (multiplayer), "Pacote Inicial" (canto inferior esquerdo),
e um icone de presente misterioso com lupa (canto inferior direito).

**Nao aparecem nesta captura**: botao de feriado (coerente com `IsHolidayEventActive` falso, ver `RECON_HOLIDAY_CONFIG_1.230_2026-11-24.md`), botao do Passe de Avatar e os widgets de drop de roupa.
Nao sei se o passe e os drops estao ocultos por regra (conta sem assinatura, sem drop vigente) ou por estado desta conta; nao testei.

## Para decidir (nao mudei nada no cliente)
- Renomear/reposicionar o nosso "Reiniciar progresso" para nao se passar por "Reset Mode", ou implementar de fato um modo de reset por cena.
- Deixar claro na UI que o seletor de idioma e da interface (o original chama de Chat).
- O icone de presente com lupa (canto inferior direito) nao tem equivalente confirmado entre os botoes que ligamos; pode ser o `AchievementsAppWidget` (caçadas), mas nao verifiquei tocando nele.
