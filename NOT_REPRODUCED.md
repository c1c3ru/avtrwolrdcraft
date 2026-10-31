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
