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
Parcial. `docs/HOME_VALIDATION_2026-10-31.md` registra validação em aparelho real (Xiaomi M2101K7BI, Android 13)
com screenshots por ADB. Nesta sessão (2026-11-05) **nenhum aparelho está conectado** (`adb devices` vazio), então
nada foi revalidado visualmente. O Unity Editor 6000.6.6f1 **está instalado** (`~/Unity/Hub/Editor`, CLI `unity`);
uma versão anterior deste item dizia o contrário, e estava errada. O APK de desenvolvimento (`Builds/`, ignorado
pelo Git) precisa ser refeito para nova instalação.

## 7. Auditoria por contrato (2026-11-05): o que o replay encontrou
Ferramenta: `tools/recon_contract.py` + `tools/replay-core` (compila o `Core` sem Unity); contrato em
`contracts/store-claim.contract.json`. Reproduzir: `python3 tools/recon_contract.py replay
contracts/store-claim.contract.json -- tools/dotnet/dotnet <ReplayCore.dll>`.

- **§2 confirmado.** `store_catalog.json`: 37.230 linhas, 25.812 GUIDs únicos (6.412 GUIDs repetidos em mais de
  uma linha), **preço 0 em todas**. Os preços não estão no catálogo extraído.
- **§2 precisa de uma nota.** Preços em moedas *existem* como observação visual dos prints do app original
  (`assets/exemplo_jogo_original/`, pasta ignorada pelo Git). Não vêm do APK nem do servidor; são fonte
  `runtime-observed`, só vale o que está na tela.
- **Replay dos combos: 4 de 6 batem** — Galxe Mansion 1200, Natural Chic 1400, Casinha de brincar 770,
  Show ao vivo 980.
- **Divergência 1: `PB25` "Amiguinhos".** O print (`imagem11.jpeg`, também `imagem6.jpeg`) mostra
  1500 → **1200**. O cliente tem 500, valor do item vizinho "Meu primeiro hamster", que é outro item. E `PB25`
  está em `StoreCatalog.Observed`, ou seja, está marcado como "lido do print" e não bate com ele.
- **Divergência 2: `PB27` "Festa à Fantasia".** Print (`imagem6.jpeg`, nome truncado "…TASIA", 25% OFF) mostra
  **450**; o cliente tem 600 (que é o preço riscado). Associação confirmada pela arte (`Resources/Store/packs/PB27.png` é o mesmo card).
- `ObservedPrintPrices_AreKept` (StoreCatalogTests) não cobre `PB25` nem `PB27`, por isso não pegou isso.
- Itens vistos nos prints sem equivalente em `StoreCatalog.All`: Carro de aventura (700), Mini Eu (300),
  Festa de formatura (600), Essenciais de bebê (800), Estábulo da cabana (1200).
- **Não verificado:** a lógica de resgate (`LocalStoreService`) não tem vetor. O original faz isso no servidor,
  então qualquer vetor seria só a reimplementação comparada a si mesma.

**Corrigido** nesta branch (decisão do autor): `PB25` → 1200 e `PB27` → 450 (preço exibido, como nos demais combos), ambos agora em `ObservedPrintPrices_AreKept`. Replay: 6/6 idênticos. Testes Unity EditMode rodados em 2026-11-05 (Unity 6000.6.6f1, `unity test … --mode EditMode`): **144/144 aprovados**, incluindo `ObservedPrintPrices_AreKept` com PB25/PB27 (`out/test-results-pr4.xml`, ignorado no Git).
