# Loja original ao vivo vs. reconstrução offline — evidência 2026-11-07

## Objetivo

Capturas diretas do app original `com.pazugames.avatarworld` (device, não emulação) lado a lado com
`com.c1c3ru.avatarworldoffline` (build atual pós-revert de `87f72dc76`), para orientar quem for refazer a
loja gráfica. O prototipo anterior (`StoreVisualAssets`/`StoreVisualView`) foi descartado; `StoreScreen.cs`
é a implementação atual e já reaproveita arte de `Resources/Store`, mas diverge do original nos pontos
abaixo.

Dispositivo: Xiaomi M2101K7BI, ADB USB, paisagem 2400x1080. Ambos os apps já estavam instalados.

## Achados principais

1. **Home bate pixel-a-pixel.** `original-home-ref.png` e a Home do build offline (capturada antes de
   abrir a loja) são idênticas: carro, logo, CTAs, badges. Não é a Home que está "fora"; é a Loja.

2. **A categoria "Todos" (casas/combos) também bate pixel-a-pixel.** `original-store-houses-all.png` e
   `offline-store-shop.png` são a mesma imagem: moldura roxa, trilho de categorias (Todos/Mansões/
   Modernas/Infantis), cartões BUNDLE com preço. Essa fatia foi bem reproduzida — não mexer sem motivo.

3. **"Criador de Avatar" é o maior gap.** No original (`original-store-avatar-creator.png`), esse ícone da
   barra lateral abre um catálogo próprio com subcategorias (Casas de Férias, Celebrações, Profissões, uma
   aba não rotulada) e bundles reais de roupa/avatar (ex.: "Estilista de Celebridades", 650 moedas). No
   build offline (`offline-store-avatar-creator.png`) o mesmo botão mostra só "Criador de Avatar / Em
   breve" — placeholder idêntico ao de "Veículos" (`original-store-vehicles.png`, que no original TAMBÉM é
   "Em breve" — isso está correto). Ou seja: a categoria de avatar/roupas, que é a mais importante de uma
   loja de customização, não tem conteúdo nenhum hoje.

4. **O botão "Itens" não existe no original.** Nas telas do original (`original-store-*.png`,
   `original-home-fresh-session.png`) não há botão "Itens" nenhum — provavelmente um atalho de debug
   herdado de alguma rodada anterior. No build offline esse botão abre um dump cru do catálogo
   (`offline-store-itens.png`): abas genéricas em inglês ("character/food/ugc/baby/toddler/c/wall/
   makeup"), nomes crus tipo "Character Accessories Body Bags 101", preço fixo "700 moedas" em tudo,
   paginação "1/344". Isso é claramente uma ferramenta de inspeção do catálogo bruto (store_catalog.json),
   não uma tela de jogo. Decidir: remover do build final ou manter só como ferramenta de dev fora do fluxo
   normal — mas não é referência de como a loja real deveria ficar.

5. **O catálogo é server-driven — não há um único "visual correto" fixo.** Duas sessões do original na
   mesma rodada mostraram lojas diferentes: uma com 58 moedas, loja "Todos" = casas (Gaixe Mansion 1200,
   Natural Chic 1400, Casinha de brincar 770); outra sessão nova (relogada, 0 moedas,
   `original-home-fresh-session.png` + `original-store-fresh.png`) com sidebar diferente (Moedas AW /
   Destaque / Veículos / Casas) e cartões diferentes ("Garagem Natural Chic" 900, "Carro da Família").
   Confirma a nota já registrada em `README.md`: preços/catálogo vêm do servidor
   (`StoreClaimItemCloudResponse`), não do APK. **Não perseguir paridade pixel de conteúdo** (nomes/preços
   exatos mudam por sessão); o alvo de paridade é a moldura/estrutura (fundo roxo, trilho de categorias,
   formato dos cartões BUNDLE, botão voltar rosa circular, contador de moedas, sidebar vertical com ícones
   + rótulo).

## Arquivos

- `out/original-home-ref.png` — Home do original, sessão com progresso salvo (58 moedas).
- `out/original-home-fresh-session.png` — Home do original, sessão nova/relogada (0 moedas, Avatar ID
  liberado em vez de "Coming soon").
- `out/original-store-houses-all.png` — Loja original, aba "Todos" (casas), sessão com progresso.
- `out/original-store-vehicles.png` — Loja original, aba "Veículos" = "Em breve" (placeholder correto).
- `out/original-store-avatar-creator.png` — Loja original, "Criador de Avatar" com subcategorias e bundle
  real ("Estilista de Celebridades").
- `out/original-store-tap1.png` — Modal de detalhe de item (ex.: "Faltam 712 moedas para Casinha de
  brincar", botões Ganhar moedas / Cancelar).
- `out/original-store-fresh.png` — Loja original, sessão nova: sidebar e cartões diferentes da sessão com
  progresso (prova de conteúdo server-driven).
- `out/offline-store-shop.png` — Loja do build offline, aba "Todos" — idêntica ao original.
- `out/offline-store-featured.png` — Loja do build offline, aba padrão ao abrir ("Palco/Luxo/Infantil/
  Urbano"), sem equivalente direto confirmado no original (nomenclatura própria do build).
- `out/offline-store-avatar-creator.png` — Loja do build offline, "Criador de Avatar" = placeholder "Em
  breve" (gap principal).
- `out/offline-store-itens.png` — Botão "Itens" do build offline: dump de debug do catálogo bruto, sem
  equivalente no original.

## Próximo passo sugerido

- Tratar "Criador de Avatar" como a prioridade de conteúdo (é onde o original tem mais produtos reais:
  roupas/avatares temáticos), reaproveitando o padrão de subcategorias por tema (Casas de Férias,
  Celebrações, Profissões) já visível em `original-store-avatar-creator.png`.
- Decidir o destino do botão/tela "Itens": não faz parte do original; se for mantido, isolar como
  ferramenta de dev fora da UI de jogador.
- Ao comparar visualmente com o original no futuro, preferir rodar duas sessões (uma com save existente,
  outra nova) para não confundir diferença de conteúdo server-driven com divergência real de layout.
