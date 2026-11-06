# O que NÃO foi reproduzido (e por quê)

Critério de conclusão #4 do `LOOP_STATE.md`. Cada item cita a evidência que sustenta a afirmação.

## 1. Backend/servidor online
Observado apenas passivamente (`/proc/net/tcp`, 15 amostras, uid do app): conexões TLS em 443
para 3.234.189.197 (AWS EC2 us-east-1, provável backend/websocket — o app embute
`unity-websocket-sharp`), 34.107.172.168 e 172.217.115.4 (Google), 108.139.119.9 (CloudFront/CDN).
Nomes de domínio (SNI) não capturados; conteúdo não inspecionado (TLS) — interceptar HTTPS está
fora do escopo definido para este projeto. **Não reproduzido**: autenticação de conta, matchmaking/
salas sociais, sincronização entre dispositivos, e qualquer lógica server-authoritative.

## 2. Preços e limites de resgate da loja
O catálogo local (`store_catalog.json`) tem 25.812 GUIDs únicos mas **preço = 0 em todos**: os
preços reais só existem na resposta do servidor (`Game.Store.StoreClaimItemCloudResponse`), nunca
no APK. Reproduzido na reimplementação apenas como "a definir" (decisão do usuário).

O código decompilado (`out/cpp2il/DiffableCs/Assembly-CSharp/Game/Store/StoreClaimItemCloudResponse.cs`)
expõe só o booleano final `hasReachedMaxClaims` — o **número** do limite de resgates nunca é
enviado ao cliente, é estado server-side. O campo `StoreItem.MaxClaims` (int) na reimplementação
(`client/.../Core/Economy/StoreItem.cs`) é portanto uma **aproximação inventada**, sem fonte no
binário decompilado.

O enum original `StoreClaimErrorType` (mesmo arquivo) só tem `None/NoItemGuid/PrefabNotFound` —
erros de resolução de GUID/prefab, não erros econômicos. O `ClaimError` da reimplementação
(`UnknownItem/RequiresRealMoney/NotAvailable/InsufficientFunds/AlreadyClaimed`,
`client/.../Core/Economy/LocalStoreService.cs`) é uma taxonomia nova, criada para a lógica
100% local — **não é uma reconstrução do enum original**, é uma invenção compatível com a
decisão "sem dinheiro real, saldo local".

## 3. Dinheiro real / Unity IAP / Google Play Billing
Confirmado no manifest do APK original (REA/JADX, evidence `ev_cfb37074585b813a2225b3cf70e4a94f8ba20ed1d98bc3ab04d7fbe180ae4e22`):
permissão `com.android.vending.BILLING`, `com.google.android.play.billingclient.version = 8.0.0`,
`ProxyBillingActivity`/`ProxyBillingActivityV2`. **Deliberadamente não reproduzido** — decisão do
usuário (2026-10-30): cliente offline compra só com `pazuCurrency`/`loyaltyPoints` locais.

## 4. PairIP (anti-adulteração)
Confirmado no manifest original (mesma evidência REA acima): `android:name="com.pairip.application.Application"`
envolve toda a `Application` do app, `com.pairip.licensecheck.LicenseActivity` declarada,
permissão `com.android.vending.CHECK_LICENSE`. `android:extractNativeLibs="true"` +
`android:requiredSplitTypes="base__abi"` explicam por que o payload nativo (`libpairipcore.so`,
junto com `libil2cpp.so`) não está no `base.apk` isolado — vive no split ABI-specific (arm64), que
não está presente neste ambiente de trabalho (só `apk/base.apk`, 28,9 MB, sem `lib/`).
**Não contornado, por decisão do projeto**: foco é análise estática e reimplementação, não burlar
a proteção do app original.

## 5. Assets reais (texturas, áudio, Spine)
121.648/121.679 texturas, 2.781 áudios e 2.313 Spine já extraídos e catalogados (Google Drive,
`AvatarWorld-RE/assets/`), mas **não** trazidos para o cliente novo além dos 57 PNGs já exportados
para a fatia Home (`Assets/Resources/HomeSlice/sprites/`). O restante permanece fora do
reimplementação por enquanto — decisão de escopo (fatia por fatia), não bloqueio técnico.

## 6. Verificação visual da tela Home
Ainda **não verificado**: nenhum dispositivo Android conectado via ADB nesta sessão
(`adb devices` retornou lista vazia) e nenhuma instalação do Unity Editor neste ambiente de
execução para gerar um screenshot via Editor/Play Mode como alternativa. O build Android relatado
como "Succeeded" em 2026-10-30 não está presente neste checkout (`client/.../Builds/` é ignorado
pelo git) e precisaria ser refeito antes de instalar/visualizar.

## Mapa World: partes móveis (2026-11-06)
- Implementado (`WorldMapMotion`, dados de `tools/export_world_motion.py` → `Resources/WorldSlice/motion.json`): 26 nuvens (`WorldCloud`) derivando e reaparecendo, trem (`WorldTrain`, tempos 3,5 s/5 s da cena), Spine `Sun_Moon` e `Water_Reflections`.
- Aproximações (o Cpp2IL não traz o corpo dos métodos): velocidade das nuvens, qual lista de sprites vale em cada clima (clear→sol, rain→neve, heavyRain→chuva), esperas e curva do trem, animação Spine escolhida (Day/Idle/primeira) sem ligação com a hora do dia.
- **Não implementado**: carros (`WorldCarsController`/`WorldCar`; grafo de 120 `WorldRoadPoint` já exportado em `motion.json`, mas o prefab do carro é `MonoBehaviour` em `resources.assets` e os sprites por direção/modelo não foram identificados); `WobbleEffect` (130 sprites, efeito de shader ao arrastar a câmera); `LevelVFXArea` (55); animações de personagens/NPCs do mapa. Nada disso verificado no aparelho.
- Atualização: ambientes agora também têm os 275 Spine de cenário (portas, fogão, chuveiro, fogo, sol; `animation` inicial vem da cena; ordem de desenho intercalada com os sprites) e o avatar salvo do jogador, posto no centro da cena (-2,7) com escala 0,55 como na quadra. Os pontos `LevelSpawn` são de itens (comida, talheres), não de avatares: o spawn original de personagens (`LevelAvatarOneTimeSpawner`/slots) segue não reproduzido. `Avatar_Spine` das cenas (34) não é desenhado (sem skins). `followCamera` (sol/lua) usa câmera+offset, semântica inferida.
- Itens arrastáveis (WIP, 2026-11-06): `tools/export_scene_items.py` exporta 2.821 `LevelItem` com sprites e 1.647 polígonos de `LevelDropArea` (`scene.json`: `items`, `dropAreas`, `renderer.item`); `SceneSliceRuntime` arrasta (limiar 10 px via `DragIntentDetector`), levanta a ordem de desenho e solta na área de maior prioridade (`DropAreaQuery`, testes EditMode). **Falhas conhecidas**: dois testes de Play Mode estão `[Ignore]`: soltar no vazio não volta ao início (áreas largas do cenário aceitam o item) e o apoio na superfície difere ~0,14 u da área escolhida. A regra real (`LevelDropAreaQuery`, aceitação por subclasse, itens gerados por spawners) não foi recuperada. Não visto no aparelho.
- LevelDropAreaQuery recuperada (2026-11-06, ARM64 via `tools/recon_disasm.py`; `DropAreaQuery.cs`): queda = área de **menor distância vertical** do raio para baixo (1000 u) entre as que passam em `PerformBasicTests` (X sobrepõe, altura `_maxItemsHeight`==0 ou ≥ altura do item, largura `_maxItemsWidth` ou largura X ≥ base do item, `CanItemFallOnSelf`), `LevelFloorArea` aceita o raio que começa dentro; sob o ponteiro = ponto dentro do polígono (`IsDroppableUnderItem`). Corrige o erro anterior (prioridade). Ainda **não** reproduzido: `LevelUndroppableArea`, `CanItemFallOnDropArea` com consumidor, bloqueio por entidade (`IsEntityBlockingDropArea`), orientação do item, `CanConsumeItem` das subclasses (só personagens/comida/matar/água ficam de fora), critério exato de `SortDropAreas` (comparador de Transform) e a ordem exata sob-ponteiro/queda dentro de `DropInLevel`. Exportação agora inclui as 64 subclasses de `LevelDropArea` (2.726 polígonos, 257 de chão).
