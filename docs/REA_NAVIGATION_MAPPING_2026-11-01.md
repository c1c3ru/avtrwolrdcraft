# Mapeamento REA: Home, mapas e destinos de ambientes

Rodada de 2026-11-01. Escopo: continuar o mapeamento do Avatar World v1.227 usando os artefatos locais e reaproveitando a extração anterior. Não houve alteração do cliente Unity, instalação, execução do jogo ou implementação de uma tela nesta rodada.

## Trabalho anterior aproveitado

| Material existente | Como foi aproveitado | Estado nesta rodada |
| --- | --- | --- |
| APK base e splits locais | Base aberta e inventariada com REA | Identidade da base confirmada |
| Dumps `out/mb/*.jsonl.gz` | Campos de Home, mapas, edifícios e entradas | Reutilizados; hashes registrados, sem repetir dump completo |
| Cpp2IL `DiffableCs` | Enums e assinaturas de navegação | Reutilizados; corpos consultados estão vazios |
| Diretório UnityFS e `scene_roots.json` | Localização e contexto das cenas | Reutilizados com limite de proveniência explícito |
| Extrator UnityFS por blocos | Extração seletiva de oito cenas com WorldManager | Executado sem carregar o datapack inteiro |
| Quadra `level8` e cliente offline | Referência do protótipo anterior | Preservados, sem nova alegação de equivalência |

## Evidência REA desta rodada

- Alvo: `assets/base.apk`.
- SHA-256: `c7edf76ff14254ecab9dc4162962f5d49d8e13be6e2e74e38f7d992f8c77ca07`.
- `open_binary` confirmou APK; `inspect_artifact` produziu Evidence `ev_59f2fb408e65629c6506afe1cbb3ea9865562b1f055b4a5f112bb7d9222ef8a0`.
- Inventário interno: Evidence `ev_82f8592c0c85aff79c733de588b1a33f9ec37b798b88e9805ca1bcafed9755cb`.
- Bundle exportado em `out/rea-avatar-base-20261101.json`: 416.075 bytes, dois registros. A sessão foi fechada.
- O inventário REA é estático e baseado no diretório ZIP. Não demonstra lógica IL2CPP nem execução Android.

As contagens, joins de dados e hierarquias abaixo foram produzidos por ferramentas Python/UnityPy, **não pelo decompilador REA**. A evidência REA vincula o inventário do APK base; não autentica automaticamente a proveniência de todos os dumps antigos.

## Resultado novo: lista de cenas e destinos

`BuildSettings`, lido diretamente de `assets/bin/Data/data.unity3d` dentro do APK base, contém **254 cenas**. O `PlayerSettings` consultado informa produto Avatar World e versão 1.227.

O cruzamento dos dumps existentes encontrou:

- 230 valores explícitos no enum `LevelType`, incluindo `None`.
- 8 registros de `WorldManager`, 14 de `WorldZone`.
- 115 registros de `WorldBuilding` e 101 de `WorldBuildingLevel`.
- 226 registros de `LevelSceneInfo`; isso não deve ser somado às cenas como conteúdo adicional.
- Todos os 115 destinos padrão de edifícios e as 101 entradas de níveis tiveram correspondência única por nome exato com `Level_<LevelType>` na lista de cenas.

**Correspondência por nome é um vínculo estático, não uma aresta de navegação observada em runtime.** O script conserva essa classificação em cada destino. Cenas alternativas, retornos, condições de acesso e listeners dinâmicos ainda exigem rastreamento.

### Mapas e bases de editor

Os nomes abaixo vêm do cruzamento do índice de BuildSettings com a convenção `level<índice>`. Essa associação está rotulada como **inferida** no JSON, pois não foi validada independentemente para cada cena. Os componentes e hierarquias dos arquivos serializados foram efetivamente lidos.

| Arquivo serializado | Cena candidata | Edifícios | Entradas de nível | Música serializada |
| --- | --- | ---: | ---: | --- |
| `level4` | `World` | 59 | 52 | `Main_Theme_Loop` |
| `level69` | `Vacation` | 10 | 3 | `Vacation_Theme_Loop` |
| `level103` | `StarDustCity` | 30 | 31 | `LA_Theme_Loop` |
| `level229` | `Countryside` | 4 | 3 | `Countryside_Theme_Loop` |
| `level230` | `SnowyMountain` | 8 | 7 | `Snowy_Mountain_Theme_Loop` |
| `level231` | `College` | 4 | 5 | `College_Theme_Loop` |
| `level249` | `LevelEditor_ZoneView_EmptyBase_Scene` | 0 | 0 | `Main_Theme_Loop` |
| `level251` | `LevelEditor_UGC_EmptyBase_Scene` | 0 | 0 | `Main_Theme_Loop` |

Portanto, oito registros de manager não devem ser anunciados como oito mundos jogáveis: dois estão associados a bases de editor nessa correspondência.

### Hierarquias e referências verificadas

As oito cenas foram extraídas seletivamente do bundle local existente. Para os **115 edifícios**, a referência `MonoBehaviour → GameObject` do dump foi conferida contra o arquivo serializado extraído. Todas coincidiram. O script recuperou a cadeia de Transform dos 115 edifícios e rejeita referências conflitantes ou ciclos.

As 14 referências de zona dos managers resolvem no mesmo arquivo entre os registros de zona existentes. Entretanto, nenhuma cadeia de ancestrais de edifício passou por um GameObject de zona. Isso impede usar ancestralidade simples para distribuir edifícios por zona: será necessário investigar geometria, componentes ou relação lógica própria. O mapeador deixa a lista de zonas ancestrais vazia; não escolhe a zona mais próxima.

Exemplo concreto:

- Arquivo `level4`, hierarquia `Basketball_T1S2 / View`.
- `WorldBuilding._defaultLevelType = 13`, enum `MiniBasketball_L1`.
- Cena por nome exato: `Assets/Game/Towns/SunriseHills/Scenes/Level_MiniBasketball_L1.unity`, índice de build 8.
- Isso localiza a quadra dentro do catálogo do mapa; não comprova que Home Play deva ir diretamente a ela.

## Fluxo de navegação: o que está resolvido e o que falta

| Trecho | Evidência disponível | Estado |
| --- | --- | --- |
| Home possui `HomePlayButton` | Dump `level3`, componente path_id 453, GameObject 12 | Mapeado estaticamente |
| Handler `HomePlayButton.LoadPlayScene()` | Assinatura Cpp2IL; corpo vazio | Lógica ainda desconhecida nesta rodada |
| Seleção e persistência do mundo | `GameSceneManager` declara `GAME_CURRENT_WORLD`, `GetCurrentWorldSceneName`, `SetCurrentWorldSceneName` | Interface conhecida; implementação não recuperada |
| Carregamento e override | Assinaturas `LoadScene`, `LoadSceneAndUpdateZoneScene`, `TryOverrideSceneNameAction`, hooks de três estágios | Contrato e ordem real pendentes |
| Mapa → destino padrão de edifício | Campos serializados, enum e cena com nome correspondente | 115 destinos catalogados; transição em runtime pendente |
| Entrada de nível → destino | `_levelType`, enum e cena com nome correspondente | 101 entradas catalogadas; transição em runtime pendente |
| Edifício → zona | Referências e hierarquias lidas | Associação espacial/lógica pendente |
| Cena → retorno/mapa anterior | Assinaturas de scene manager | Rota efetiva e persistência pendentes |

O enum `SceneType` recuperado distingue Home, World, Level, AvatarMakerLobby, AvatarMaker, Street, Store, BWYWMenu, StoreAvatarPass, AWCloud, StoreBundle, StarsPass e CarMaker. Isso orienta o próximo catálogo, mas não prova que todos os modos estejam habilitados no usuário/dispositivo.

## Cuidados que os dados exigem

1. Os 115 `_isFree` serializados são zero. O código declarado possui `_isFreeFromRemoteConfig` e `IsCurrentlyFree()`. Logo, zero no asset não comprova bloqueio de todos os edifícios, preço, assinatura ou disponibilidade em runtime.
2. Os 115 `OnClickAction.m_PersistentCalls.m_Calls` estão vazios. Isso não significa ausência de ação: listeners podem ser registrados por código. A classe também declara `OnClickBuildingAction`, `ClickOnLevel` e `OnPointerClickInternal`.
3. Os C# inspecionados de HomePlayButton, GameSceneManager e WorldManager não contêm lógica de método recuperada. Não implementar seus corpos a partir apenas do nome e chamar isso de comportamento original.
4. A proveniência completa dos dumps antigos em relação aos splits atuais ainda precisa ser revalidada. Os hashes de todos os inputs do mapeador estão no JSON; somente o vínculo estrutural dos 115 componentes com GameObjects foi rechecado nesta rodada.
5. Nenhuma captura ou observação antiga foi promovida a novo teste em dispositivo. Não houve runtime nesta rodada.

## Ferramenta e reprodução

Ferramenta nova: [`tools/map_world_navigation.py`](../tools/map_world_navigation.py).

```bash
tools/venv/bin/python tools/map_world_navigation.py
```

Saídas derivadas:

- `out/navigation-map/navigation.json`: hashes de entrada, contagens, mundos, destinos, hierarquias, referências e desconhecidos.
- `out/navigation-map/scenes.json`: lista das 254 cenas, índices, candidatos de arquivo serializado e raízes antigas quando disponíveis.

O comando não reextrai APKs ou o datapack. Lê o membro pequeno do APK base, dumps compactados e as cenas já extraídas. Se uma cena não estiver localmente disponível, não inventa a hierarquia: essa parte permanece ausente no resultado.

Extração seletiva usada nesta rodada: `tools/unityfs_extract_entry.py`, arquivos `level4`, `level69`, `level103`, `level229`, `level230`, `level231`, `level249` e `level251`. Total aproximado: 2,9 MB de cenas. O bundle de origem permanece intacto.

Validação real: execução do mapeador concluiu sem erro; todos os destinos padrão e entradas tiveram join único; 115/115 referências de componente/GameObject coincidiram e suas cadeias foram lidas; 14/14 referências de zona resolveram no conjunto existente. Isso valida o recorte estático declarado, não o jogo completo.

## Próximo lote de mapeamento

- [ ] Recuperar endereços IL2CPP e corpos de `HomePlayButton.LoadPlayScene`, `GameSceneManager.GetCurrentWorldSceneName`, `LoadScene`, `LoadSceneImplement` e `WorldBuilding.ClickOnLevel`; usar o binário arm64 e metadata correspondentes, sem confundir os C# vazios com implementação.
- [ ] Vincular independentemente scene path ↔ arquivo serializado e revalidar proveniência dos dumps relevantes contra os splits atuais.
- [ ] Mapear a relação real zona/edifício, hitboxes, câmera e seleção dos seis mapas; ancestralidade não resolveu essa relação.
- [ ] Mapear portas/saídas de cenas, andares e retornos, incluindo estado persistido e condições de transição.
- [ ] Reproduzir no app original uma rota Home → mapa → edifício → ambiente → retorno e registrar tela, gesto, estado, logs e limites de rede. Não executar login, transação ou contorno de proteção.
- [ ] Só depois implementar a navegação local dessa fatia, aproveitando o cliente existente e mantendo divergências offline explícitas.

Essa fila complementa o trabalho já existente; não reinicia editor, tradução de assets, extração completa ou testes do cliente.
