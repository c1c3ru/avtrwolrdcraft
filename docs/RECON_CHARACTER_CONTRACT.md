# Avatares, NPCs, pets e movimento — T032 parcial

Data: 2026-11-04  
Escopo desta rodada: classificação de presets e tipos de cena, mais extração estática de métodos centrais de spawn, drag/movimento e dados do avatar. Sem execução no aparelho.

## Fontes e relatórios

- `out/assets/TextAsset/PremadeCharactersJson_109356.txt` — SHA256 `23285e9696a9a066d300d545dd074ae7fccc4183a0630bd79ba9e51c057be166`; 896 registros sob `AvatarSpineDatas`.
- `out/cpp2il/DiffableCs/Assembly-CSharp/PWC/AvatarSpine/SpineType.cs` — enum de famílias: Character=1, Baby=2, Cat=3, Dog=4, Bird=5, Fish=7, Hamster=8, Lizard=9, Turtle=10, Rabbit=11, Snake=12, Toddler=13, Horse=14, Cow=15, Chicken=16, além de None/Other/Car.
- `tools/recon_character_inventory.py` gera `out/recon/tasks/T032/character-inventory.json`, com hash do arquivo de presets e hash individual dos stubs que classificam classes de cena.
- `tools/recon_save_static.py --scope characters` gera 87 janelas ARM64 e arestas em `out/recon/tasks/T032/character-asm/report.json`; quatro nomes solicitados não aparecem como métodos declarados nesse tipo no índice (um método de idle explícito, um override de sync ausente no stub e `Init`/`DestroyAvatar` ausentes em `LevelAnimal`). Isso não é evidência de funcionalidade inexistente: pode ser implementação/interface herdada ou nome explícito; confirmar pela hierarquia concreta. SHA256 do binário: `b63661fa60c23ebef1c2da4bb5288ad787eb3da36b22d4bdf285401f1643d728`.

As janelas da extração ARM64 seguem limites por endereço de metadata e não provam corpo completo. Cpp2IL fornece assinaturas/campos e hierarquia declarada, não corpos executáveis. Chamadas indiretas ainda não resolvidas são indicadas no JSON.

## Famílias do catálogo de presets

| SpineType | Presets | Leitura confirmada |
|---|---:|---|
| Character | 827 | Família humana adulta; `PWC.Level.LevelCharacter` implementa `ILevelAvatar` |
| Toddler | 45 | `PWC.Level.LevelToddler` implementa `ILevelAvatar`; contém estado e callbacks próprios de movimento |
| Baby | 11 | `PWC.Level.LevelBaby` implementa `ILevelAvatar`; possui handlers e áreas específicas, sem a mesma API de movimento identificada no toddler |
| Dog | 7 | `Game.Level.LevelDog` herda `LevelAnimal`, implementa `ILevelAvatar`, e tem interação de boca |
| Cat | 3 | `Game.Level.LevelCat` herda `LevelAnimal` e implementa `ILevelAvatar` |
| Horse | 3 | `Game.Level.LevelHorse` herda `LevelAnimal`, implementa `ILevelAvatar` e mantém estado/rider separado |

Os demais SpineTypes constam no enum e em famílias de componentes/skins, mas têm zero entradas neste arquivo de presets. Isso não prova ausência de NPCs dessas famílias nas cenas ou em outros catálogos. A classificação das 21 classes de cena relacionadas a `LevelAnimal` e famílias primárias está em `character-inventory.json`. Parte dos tipos `LevelTech*` declara somente `LevelAnimal`, sem `ILevelAvatar`; não os tratar como avatares controláveis por inferência.

## Contratos sustentados pela evidência

- `ILevelAvatar` reúne identidade, ciclo `Init`/`DestroyAvatar`, animação idle, item associado, acessórios em osso, sentar e salvar dados. As classes Character, Toddler, Baby, Cat, Dog e Horse expõem implementações especializadas; o contrato compartilhado não significa que tenham a mesma lógica interna.
- `LevelCharacterAnimator` centraliza movimento humano: `OnBeginMovement` armazena posição e examina item comportamental segurado; `OnMovement` consulta `CShape.IsPointInsideShape`, ajusta ordenação e animações; `OnEndMovement` encerra eventos Spine, verifica estado do item/queda e escolhe retorno de animação. As janelas são 1.020, 2.212 e 320 bytes; `OnBeginMovement` contém um dispatch indireto, enquanto as outras duas não. `UpdateMovementOverrideHandler` procura itens nas mãos para substituir os ciclos de caminhada. Ainda faltam CFG completo, thresholds e o caller que traduz input/posição em chamadas repetidas.
- `LevelAvatarOneTimeSpawner` escolhe e posiciona avatares e delega criação para `LevelUtils.SpawnAvatar`; a janela `SpawnAvatar` é de 1.072 bytes e chama dois overloads/targets do helper. `PlaceAvatarInScene` mede 1.364 bytes e contém oito chamadas indiretas, logo seleção de slots, duplicidade e escolha concreta ainda requerem resolver callbacks/dispatch.
- `LevelAnimal` declara enum de movimento `None`, `Stand`, `Walk`, `Run`, além de posição de início do drag e última posição de movimento. `OnBeginDragInternal` chama a base, inicia movimento e instala animação; `OnSyncPosition` chama a base e `OnMovement`; `OnEndDragInternal` encerra movimento, verifica possível aterrissagem e restaura idle. `OnMovement` tem janela de 2.436 bytes com oito dispatches indiretos. Isso sustenta um ciclo drag→movimento/animação→soltura, sem recuperar todos os limites ou o comportamento de cada espécie.
- `LevelToddler` declara enum equivalente, `GetMovementType`, `OnBeginMovement`, `OnMovement`, `OnEndMovement` e estado de postura/ser carregado. `OnMovement` e a implementação de Animal têm janelas grandes (2.128 e 2.436 bytes respectivamente); a primeira não contém chamadas indiretas na janela extraída, a segunda tem oito. O fluxo chama `CShape.IsPointInsideShape`, altera sorting order e animações Spine. A transição exata de estado/velocidade ainda pede CFG/dispatch.
- `LevelBaby` é uma entidade `ILevelAvatar` separada, com área de boca, área de envolvimento e persistência própria. Sua classe não declara a rotina `OnMovement` encontrada para Toddler/Animal; isso não prova que um bebê não possa ser movido pela base comum de item.
- Horse expõe `UpdateRider`, métodos de animação para rider e estado `_currentRider`; suas rotinas relevantes contêm dispatch indireto. Dog declara `PutInMouth`. Esses são contratos especializados, não detalhes suficientes para implementar pareamento completo.
- `LevelAvatarData.SaveDataInternal` e `ApplyDataInternal` (3.236/3.560 bytes) gravam/reaplicam identidade `sceneGuid`, prefab e dados de cena; persistência de item/avatar precisa ser conciliada com T030 antes de afirmar ciclo completo.

## Lacunas e próximo recorte

1. Resolver chamadas indiretas nos métodos de maior impacto: `LevelAnimal.OnMovement`, `LevelCharacterAnimator.OnBeginMovement`, `LevelAvatarOneTimeSpawner.PlaceAvatarInScene`, `LevelAvatarData.SaveDataInternal` e `ApplyDataInternal`, além de callbacks de aterrissagem e criação.
2. Correlacionar classes e tipos com cenas reais para separar personagem principal selecionável, NPC decorativo, pet interativo e spawner; os arquivos de cena disponíveis devem ser contados por classe antes de afirmar cobertura.
3. Reconciliar T031: gesto, bloqueio/drag e disputa com o mundo condicionam o controle de locomoção. A fila canônica ainda aponta T018, T025–T027 e T031 como dependências pendentes de T032.
4. Diferenciar movimento por drag, caminhada contextual, movimento autônomo de NPC e transporte/posicionamento de bebê; buscar controladores que definem `MovementType`, curvas, threshold, animação e orientação.
5. Validar movimento, seleção e estado no runtime depois, em amostras de Character, Toddler, Baby, pet e NPC.

T032 fica parcial. O relatório classifica as famílias dos presets e indica contratos de alto nível, mas não demonstra paridade de locomoção, spawn, posição/orientação, interação, persistência ou comportamento no aparelho.

## Recorte 2026-11-04: spawns versus cenas locais
Ferramenta: `tools/recon_spawn_census.py` (lê relatórios do inspetor; saída `out/recon/tasks/T032/spawn-census.json`).

| Cena | Componentes de personagem serializados na cena |
|---|---|
| level4 (mapa) | nenhum `LevelCharacter`; só `WorldAvatarMakerButton`, `StoreAvatarPassButton` x2, spawners de UI/nuvens |
| level237 | nenhum |
| level8 (basquete) | nenhum `LevelCharacter`/`LevelCat`/`LevelDog`/`LevelHorse`; 11 `PWC.Level.LevelSpawn`, 4 `LevelItemInCharacterBoneTransformOverride`, 7 `LevelCAPlayFountainToddlerDropAreaHandler`, 4 `LevelReactionOfAvatarsOnCAAnimationHandler`, 1 `LevelAddCAOnAllCharactersHandlerByWeather` |

Conclusão sustentada: nas cenas locais disponíveis os personagens não vêm serializados; são criados em runtime a partir dos pontos `LevelSpawn` (11 em level8) via `LevelAvatarOneTimeSpawner`/`LevelUtils.SpawnAvatar`. Isso confirma que o preset (896: 827 Character, 45 Toddler, 11 Baby, 7 Dog, 3 Cat, 3 Horse) decide a família, e que não se deve usar o esqueleto Character para todos.

Limite: as chamadas `bl` dentro de `LevelCharacterAnimator.OnMovement` passam por stubs de resolução IL2CPP (`0x1b886e8`); os alvos não foram resolvidos, então o roteamento exato Character → Animator (Stand/Walk/Run, `GetWalkingAnimationName`) segue só pelas assinaturas e campos (`MovementType`, `_walkTrackStartTime`, `OnStepContact`). Cenas além de level4/8/233/234/237 não estão extraídas localmente.
