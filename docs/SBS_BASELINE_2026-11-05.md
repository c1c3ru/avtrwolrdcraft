# Baseline do app instalado (`com.c1c3ru.avatarworldoffline.sbs`) — 2026-11-05

Navegação por toque ADB, só leitura (nenhuma compra, nenhum "resgatar", nenhum desafio respondido). Capturas em `out/device/sbs-nav/` (ignorado no Git). APK de backup: `out/device/installed-sbs-base.apk`, SHA-256 `1d83c956c85bef1beb8199f1763616b8e08f123c2c251e7596024bee99c10e47`, instalado em 04/11 (atualizado 12:38).

## O que ele tem
- **Home** idêntica à do build `.test` do checkout atual.
- **Loja** com 22 combos (`StoreCatalog`), abas Moedas AW / Destaque / Casas / Moda / Pets / Combos, saldo exibido (150 na captura).
  - Moedas AW não vende moeda: mostra os desafios Fácil/Médio/Difícil (+10/+15/+20).
  - Preços batem com `StoreCatalog` **antes** da correção do PR #4: Amiguinhos aparece **500** (o print do original diz 1200). Isso confirma que o `.sbs` instalado é anterior à correção.
  - Não há loja por item: os 25.812 GUIDs do `store_catalog.json` não aparecem.
- **Play → mapa do mundo**: cena grande e rolável com prédios, trem, aeroporto, áreas coloridas. Botões: voltar, clima (abre chuva/neve), globo (**sem resposta ao toque**), avatar+ e editar casa (não tocados).
  - Prédios em construção (fita amarela) e o toque em um prédio ativo (ponto laranja) **não abriram nada**: o mapa é só visual, sem entrada em interiores.

## Lacunas observadas (candidatas a trabalho)
1. Entrada nos prédios / interiores (`level/sceneitems/*`): nenhuma.
2. Itens de cena por GUID na loja: nenhum.
3. Globo (troca de mundo): sem ação.
