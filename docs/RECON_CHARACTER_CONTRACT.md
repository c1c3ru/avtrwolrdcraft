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

## Recorte 2026-11-04 (2): Character → LevelCharacterAnimator resolvido
Ferramentas: `tools/recon_call_targets.py` (alvos `bl` -> método via mapa estrutural de VA) e varredura binária de `bl`/`b` em `libil2cpp.so` (resultados em `out/recon/tasks/T032/animator-calls.json` e `animator-callers.json`).

Correção: os `OnMovement` em `0x2265194` e `0x233f910` são de `LevelAnimal` e `LevelToddler`; o do animator humano é `0x22a1570`. Os stubs `0x1b886e8`/`0x1b8885c` são helpers de runtime IL2CPP e não carregam semântica de jogo.

Chamadores (instrução `b` de cauda, exceto onde indicado):
| Animator | Chamado por |
|---|---|
| `OnBeginMovement` (`0x22a1150`) | `LevelCharacter.OnBeginDragInternal`, `LevelCharacter.Multiplayer_PrepareForDrag`, `LevelWaterAreaItemHandler.GetOutOfWater` (`bl`) |
| `OnMovement` (`0x22a1570`) | `LevelCharacter.OnSyncPosition`, `LevelCharacter.IMultiplayer_TransformChange.Multiplayer_OnTransformChange` |
| `OnEndMovement` (`0x22a1fe0`) | `LevelCharacter.OnEndDragInternal`, `LevelCharacter.IMultiplayer_PrepareForDrop.Multiplayer_PrepareForDrop` |
| `OnEndLand` (`0x22a0b84`) | `LevelCharacter.OnEndLand` |
| `PlayIdleAnimationOnCharacterInit` | `LevelCharacter.Init` |
| `PlayProperIdleAnimation` | 14 chamadores, incl. `LevelItemOnCharacterBase.OnBeginDragInternal`, handlers de CA (Toddler/Baby/Pet/Crutches/SkiPoles), `LevelRunningAreaItemHandler.OnEndLand`, `LevelStageTheme.ThemeSetActive` |

Fluxo sustentado: arrastar (begin/end drag) e sincronização de posição (`OnSyncPosition`, também usada por multiplayer) movem o Character; o animator decide a animação a partir de `MovementType` (Stand/Walk/Run). Dentro do animator, `OnBeginMovement` usa `GetCurrentBehaviorItem` + `SetAddAnimationInternal`; `OnMovement` usa `CShape.IsPointInsideShape`, `LevelItem.SetSortingOrder`, `SetAddAnimationInternal`, `SetEmtyAnimation`; `OnEndMovement` usa `ShouldPlayFallHighAnimation` + `SetEmtyAnimation`.

Ainda aberto: constantes (limiares Stand/Walk/Run, nomes de animação via `GetWalkingAnimationName`) exigem leitura de literais do corpo de `OnMovement`/`SetAddAnimationInternal`, o que cabe em T025.

## Recorte 2026-11-04 (3): constantes de `LevelCharacterAnimator.OnMovement`
Fonte: `out/recon/tasks/T032/animator-onmovement-constants.json` (asm de `0x22a1570` + floats lidos de `.rodata` pelo mapa de segmentos do ELF).

Provado (instruções e valores literais): comparação com `3.0` contra `_positionOnBeginDrag` (campo `0x38`) que limpa `_canForceNormalDragging`; `SetEmtyAnimation(1, 0.2)` ao encerrar o movimento, zerando `_movementType` e `_lastMovementPosition`; `_forceNormalDragging = true` quando `|a| < 0.1` e `|b| > 0.05`; chamada com argumento inteiro `50` antes da seleção de animação.

Inferido (não provado): `a`/`b` são componentes do deslocamento por quadro e o `3.0` é distância horizontal desde o início do arraste; o `50` é ordem de sorting. Não implementar como paridade até T025/T027 confirmarem por corpo completo ou execução.

## Recorte 2026-11-04 (4): literais de string do animator
Ferramenta: `tools/recon_string_literals.py` (pares `adrp`+`ldr` -> GOT -> slot de metadata usage -> literal; reutiliza `Elf`/`Metadata` de `recon_il2cpp.py`). Saída: `out/recon/tasks/T032/animator-literals.json`.

Correção: `GetWalkingAnimationName` (`0x2266e08`) e `GetStandingIdleAnimationName` (`0x2266dc8`) são de `LevelAnimal`, não do Character. Seus literais (`Track_Animations/Forced_To_Walk`, `General/Standing_Idle`) valem para animais.

`LevelCharacterAnimator` (literais por método, ordem de aparição no código, não de uso):
| Método | Literais |
|---|---|
| `PlayStandIdleAnimation` | `Idle_Stand_1` |
| `OnBeginMovement` | `Idle_Stand_1`, `Lift_Idle`, `Legs_Shoes_119`, `<empty>` |
| `OnMovement` | `Idle_Stand_1`, `Lift_Idle`, `Movement_Cycles/Walk`, `Movement_Cycles/Run`, `Track_Animations/Forced_To_Walk`, `Glow_Loop`, erro `No case found for nextMovementType[...]` |
| `PlayProperIdleAnimation` | `CA/Chair_Sitting/Sit_On_Chair_Idle`, `CA/Bed_Laying/Laying_Idle` |
| `SetAddAnimationInternal` | erros `animationName is null or empty!` e `No animation found for animationName[...]` |

Sustentado: Walk e Run usam `Movement_Cycles/Walk|Run`; idle em pé é `Idle_Stand_1`; item erguido usa `Lift_Idle`; idle contextual escolhe animações de cadeira/cama. `SetAddAnimationInternal` falha com erro quando o nome é vazio ou inexistente no esqueleto (não é fallback silencioso).

Não verificado: a existência desses nomes nos esqueletos Spine extraídos (não estão em `out/assets/TextAsset`; precisa busca nos `.skel`/MonoBehaviours de Spine) e a condição exata de cada ramo (`Lift_Idle`, `Glow_Loop`, `Legs_Shoes_119`).

## Recorte 2026-11-04 (5): validação dos nomes contra os esqueletos Spine
Método: busca binária dos nomes (strings com prefixo de tamanho do formato `.skel` 4.2) em `out/assets/TextAsset/*skel*` (588 arquivos).

| Nome | Onde existe |
|---|---|
| `Idle_Stand_1` | `Avatar_Spine.skel` (só Character) |
| `Movement_Cycles/Walk` | `Avatar_Spine`, `Toddler_Spine`, `Treadmill_P151` |
| `Movement_Cycles/Run` | `Avatar_Spine`, `Treadmill_P151` (**não** em `Toddler_Spine`) |
| `Lift_Idle` | `Avatar_Spine`, `Toddler_Spine` |
| `Track_Animations/Forced_To_Walk` | `Avatar_Spine`, `Toddler_Spine` e todos os pets (Cat, Dog, Horse, Cow, Bird, Fish, Rabbit, Turtle, Snake, Lizard, Hamster, Chicken) |
| `CA/Chair_Sitting/Sit_On_Chair_Idle`, `CA/Bed_Laying/Laying_Idle` | `Avatar_Spine` |
| `Glow_Loop` | só `Star_Pass-Gift_Choice.skel`; **não** no esqueleto do avatar |
| `Legs_Shoes_119` | não é animação: aparece em packs de roupa (ex.: `CheerleaderIsLifeP204Pack`), é id de item de calçado |

Consequências sustentadas: Toddler não tem ciclo de corrida (o ramo Run do animator só vale para o esqueleto Character); `Forced_To_Walk` é a faixa comum a Character, Toddler e pets; Baby não foi verificado contra `Baby_*` skeleton neste recorte. `Glow_Loop` em `OnMovement` é executado em outro objeto/esqueleto (efeito de brilho), não no Character. `Legs_Shoes_119` em `OnBeginMovement` é comparação com id de item segurado/vestido, não animação.

Limite: busca por substring binária prova presença do nome no arquivo, não que seja animação (vs. skin/slot); para animações Character principais os nomes seguem o padrão de caminho de animação, mas a classificação exata exige parse do `.skel`.

## Recorte 2026-11-04 (6): parser real de `.skel` 4.2 (corrige o recorte 5)
Ferramentas: `tools/skel_dump/` (console .NET 8 que compila o `SkeletonBinary` do spine-csharp em `Library/PackageCache`; saída `out/recon/tasks/T032/skel-dump.jsonl`, 587 esqueletos, 0 erros) e `tools/recon_skel_check.py` (verifica nomes por tipo exato; sai com 0/1; passa com 9 checagens).
Execução: `dotnet build tools/skel_dump -c Release -o <tmp>` e `dotnet <tmp>/skel_dump.dll out/assets/TextAsset/*skel*`.

Tamanhos (animações/skins/slots): Avatar_Spine 3479/2120/429; Toddler_Spine 581/446/184; Baby_Spine 63/227/61; Pet_Dog 212/437/116; Pet_Cat 171/268/90; Pet_Horse 44/172/113.

Correção ao recorte 5 (a substring enganava): como animação exata, `Idle_Stand_1`, `Lift_Idle`, `Movement_Cycles/Walk`, `Movement_Cycles/Run`, `CA/Chair_Sitting/Sit_On_Chair_Idle` e `CA/Bed_Laying/Laying_Idle` existem só em `Avatar_Spine` (Walk e Run também em `Treadmill_P151`); Toddler **não** tem `Walk`, `Lift_Idle` nem `Run` com esses nomes. `Track_Animations/Forced_To_Walk` existe em Avatar_Spine, Toddler e pets, mas não em Baby. Baby (63 animações) não tem locomoção. Pets usam `General/Standing_Idle`, `General/Walking`, `General/Running`. `Glow_Loop` só em `Star_Pass-Gift_Choice`. `Legs_Shoes_119` não é animação, skin nem slot de esqueleto algum.

Consequência: os ciclos Idle/Walk/Run de `LevelCharacterAnimator` servem só ao esqueleto Avatar_Spine; Toddler, Baby e pets têm animadores próprios (`LevelToddler`, `LevelAnimal`) com outros literais, ainda por extrair com `tools/recon_string_literals.py`.

## Recorte 2026-11-04 (7): Toddler, Baby e animais classificados
Ferramentas: `tools/recon_method_literals.py` (decodifica `adrp`+`ldr` direto dos bytes, sem disassembler; saídas `out/recon/tasks/T032/baby-literals.json` e `toddler-animal-literals.json`) e `tools/recon_skel_check.py` estendido (15 checagens, todas passam).

| Família | Classe | Esqueleto | Animações (validadas como nome exato) |
|---|---|---|---|
| Character | `LevelCharacter` + `LevelCharacterAnimator` | `Avatar_Spine` | `Idle_Stand_1`, `Movement_Cycles/Walk`, `Movement_Cycles/Run`, `Lift_Idle`, `Track_Animations/Forced_To_Walk` |
| Toddler | `LevelToddler` | `Toddler_Spine` | `General/Stand_Idle`, `General/Lift_Idle`, `Movement_Cycles/Walking_Loop`, `Movement_Cycles/Crawling_Loop`, `Track_Animations/Forced_To_Walk`, `Track_Animations/Forced_To_Crawl` |
| Baby | `LevelBaby` (+ `LevelBabyAnimations`) | `Baby_Spine` | `General/Idle` (idle e retorno; sem locomoção; `SitOn` também usa `General/Idle`) |
| Animais (Cat/Dog/Horse e demais pets) | `LevelAnimal` | `Pet_*`, `Cow_Pet` | `General/Standing_Idle`, `General/Walking`, `General/Running`, `Track_Animations/Forced_To_Walk` |

Sustentado: Toddler tem andar **e engatinhar** (ramo próprio com `Forced_To_Crawl`), sem corrida; Baby não se locomove por animação (só idle/pose), coerente com não ter ciclos de movimento; animais lançam erro "animal doesn't have Running animations but tries to run" se faltar `Running`. `Glow_Loop` aparece nas três famílias de `OnMovement`, mas só existe em outro esqueleto (efeito).

Não confiável / ruído: o resolvedor lê pares `adrp`+`ldr` numa janela até o próximo método, então traz literais alheios (`_Tie`, `country`, `old_device_token`, `Level_DoctorOffice_L17`, `DeleteSharedAudioClip`, `PazuCore/Art/flags/`) e `Small_Box_Open/Close` (inexistentes em esqueleto algum). Tratar como não verificados; só valem os nomes confirmados no `.skel`. Ainda falta ligar cada literal à sua condição (ex.: quando usa crawl, quando animal corre).

## Recorte 2026-11-04 (8): condições de `LevelToddler.OnMovement` (`0x233f910`)
Fonte: asm de `OnMovement_000000000233f910` + slots de string resolvidos pelo join GOT→metadata; floats lidos de `.rodata`.

Provado (instruções e valores):
- **Walk contra crawl:** com movimento ativo e sem `_isLockedAnimationWhenWalking` (`0x398`), a animação é `Movement_Cycles/Walking_Loop` se `PostureType == Standing (1)` e `Movement_Cycles/Crawling_Loop` caso contrário (Sitting=2 ou None=0). `csel ... eq` seleciona o slot `0x41da688` (Walking) quando igual a 1 e `0x41da690` (Crawling) quando diferente. Com `_isLockedAnimationWhenWalking` ligado usa o nome travado em `0x3a0` e `MovementType=2`.
- **Parada:** o ramo sem movimento toca `General/Stand_Idle` (slot `0x41da668`) com `MovementType=1`.
- **Velocidade:** `speed = sqrt(a² + b²) / t`, onde `t` é o retorno de uma chamada sem argumentos (`0x3cd1b3c`).
- **Histerese por estado atual** (`_movementType`, `0x380`): Stand(1) → anda se `speed > 0.06`; Walk(2) → continua enquanto `speed >= 0.006`, senão para; Run(3) → `speed < 6.0` cai para o ramo de andar. Constantes: 0.06, 0.006, 6.0.
- Mantém o prólogo do animator de Character: limpa `_canForceNormalDragging` (`0x389`) se `|Δ| > 3.0`; ao encerrar chama o equivalente a `SetEmtyAnimation` com mix 0.2 e zera `_movementType`, `_lastMovementPosition`; força arraste normal com `|a| < 0.1` e `|b| > 0.05`.

Inferido (não provado): `a`, `b` são o deslocamento por quadro e `t` é `Time.deltaTime`; os limiares 0.06/0.006/6.0 então são unidades por segundo. Não há ramo de Run próprio para animação do Toddler (o esqueleto não tem Run), então o estado Run só alimenta a escolha de andar/engatinhar.

Consequência para a cópia: Toddler engatinha sempre que não está em pé (postura sentada ou indefinida) e anda quando `Standing`; ambos usam o mesmo limiar de velocidade.

## Recorte 2026-11-04 (9): `LevelAnimal.OnMovement` (`0x2265194`) e contrato C#
Provado (asm + floats de `.rodata` + slots de string):
- Mesma estrutura do Toddler: speed = `sqrt(a²+b²)/t`; mesmas constantes de arraste (3.0, 0.2, 0.1, 0.05) e limpeza de `_lastMovementPosition`.
- Histerese por `_movementType` (`0x360`): **Stand** → Walk se `speed > 0.06`. **Walk** → chama o virtual de slot `0xa68` (`HasRunningAnimations`, por consistência com o ramo Run) e então: `speed < 0.006` → Stand; `speed > 18.0` e há corrida → Run; senão continua Walk. **Run** → `speed < 6.0` volta a Walk. Não existe salto direto Stand→Run nem Run→Stand.
- Ao entrar em Walk usa o nome travado (`0x370`) se `_isLockedAnimationWhenWalking`, senão o virtual de slot `0xb18` (`GetWalkingAnimationName`, por padrão do ramo, não por símbolo); em Stand usa `General/Standing_Idle`.
- Ao pedir Run: se o virtual `0xa68` é falso, registra `"Error in LevelAnimal, animal doesn't have Running animations but tries to run"` (`0x2265a54`) e não troca de animação; se verdadeiro, usa o nome travado ou o do Run.
- Erro de enum: `"No case found for nextMovementType[...]"` no caso padrão.

Inferido: os virtuais `0xa68/0xb18` são `HasRunningAnimations`/`GetWalkingAnimationName` (os nomes existem em `LevelAnimal.cs`, mas o slot→símbolo não foi resolvido pela vtable); `Small_Box_Open/Close` do ramo Run é provável ruído de resolução (não existe em esqueleto).

Contrato C#: `client/AvatarWorldClient/Assets/Scripts/Core/Avatar/LocomotionStateMachine.cs` (branch `worktree-t032-locomotion-contract`): `LocomotionConfig.Toddler/Animal`, `LocomotionStateMachine.Next`, `ToddlerMoveAnimation`. **Não há preset de Character**: a histerese de `LevelCharacterAnimator` ainda não foi extraída. Testes ficam para depois, como combinado.

## Recorte 2026-11-04 (10): histerese de `LevelCharacterAnimator.OnMovement` (`0x22a1570`) e testes
Provado: Character usa a mesma histerese do Toddler: Stand→Walk se `speed > 0.06` (`0xb2fe40`); Walk continua se `speed >= 0.006` (`0xb2fdd8`), senão vai a Stand (nome travado ou `Idle_Stand_1`); Run→Walk se `speed < 6.0`. **Não há transição Walk→Run dentro de `OnMovement`** (de Walk só se compara com 0.006) nem limiar 18.0 (esse é só de `LevelAnimal`). Run só é mantido se já ativo; quem ativa Run no Character fica fora deste método e **não foi localizado** (o literal `Movement_Cycles/Run` só é alcançado com estado anterior 3).
Código: `LocomotionConfig.Character` (`CanEnterRun=false`) em `LocomotionStateMachine.cs`. Testes: `Assets/Tests/EditMode/LocomotionStateMachineTests.cs` (11 casos: limites 0.06/0.006/18/6, histerese, sem saltos Stand↔Run, Toddler/Character sem Run, postura→walk/crawl). Verificação: os 11 passam num harness .NET com shim de NUnit; **não** rodados no Unity Test Runner (worktree sem Library).

## Recorte 2026-11-04 (11): quem ativa Run no Character
Método: varredura binária de todos os métodos de `LevelCharacterAnimator` (janela até o próximo método, cap `0x1800`) por `str w,[x,#0x30]` (`_movementType`) e por `mov w,#3`. Script reproduzível: `/home/deppi/.claude/jobs/0979ab8d/tmp/scan_mt.py` (temporário; a lógica é `str` com imm12=12 e `mov w,#3`).

Provado: `_movementType` só é gravado em `OnMovement` (`0x22a1904` com `wzr`; `0x22a1cd0` com `w24`; `0x22a1d78` com `wzr`) e em `OnEndMovement` (`0x22a2024` com `wzr`). `w24` é carregado do próprio campo (`0x22a19ec`) ou fixado em 1 (`0x22a1ac8`) ou 2 (`0x22a1b28`). Nenhum método do animator contém `mov w,#3`. O campo é privado e o animator é o único que o grava.

Conclusão sustentada: **o Character nunca entra em Run no original**; o ramo `Movement_Cycles/Run` (`0x22a1cd8`) só seria alcançado com estado anterior 3, que nunca é produzido. `Movement_Cycles/Run` existe no esqueleto, mas não é usado pelo animator (só o `Treadmill_P151` e `LevelAnimal` o usam). A cópia deve manter `CanEnterRun = false` para Character, e isso agora é paridade provada, não lacuna.

Limite: não cobre escrita por reflexão/serialização nem por outra classe com layout idêntico; não foi verificada execução no aparelho.

Atualizacao 2026-11-05: os 11 testes de LocomotionStateMachineTests passaram no Unity 6000.6.6f1 EditMode (28/28 com os de arraste).

## Recorte 2026-11-05 (12): spawn de avatares (`LevelAvatarOneTimeSpawner`) e catálogo completo
Ferramentas: `tools/recon_spawner_census.py` (saída `out/recon/tasks/T032/spawner-census.json`) e `tools/recon_disasm.py` (disassembly anotado com capstone: chamadas resolvidas e literais). Requer `pip install capstone` num venv.

**`LevelSpawn` (`PWC.Level.LevelSpawn`)** é só um marcador: um campo `_spawner` atribuído em runtime, sem dados serializados. Marca itens criados a partir de dados persistentes (`TryGetSpawn(PDPrefabReference, out LevelSpawn)`), não avatares. As 11 instâncias de level8 não são personagens.

**Catálogo de avatares**: `SpineType` numérico → 1 Character, 2 Baby, 3 Cat, 4 Dog, 13 Toddler, 14 Horse (por contagem e faixas de id). Há **1.324** avatares: 896 de `PremadeCharactersJson` e **428** em arquivos `Level_*`/`LevelPhoneAvatars`/`College_Main_Characters` com o mesmo esquema `AvatarSpineDatas`. O catálogo completo é a união; só os presets deixam 10 ids de spawner sem resolver.

**Spawners em cenas** (`LevelAvatarOneTimeSpawner`, 39 instâncias em 23 cenas): 37 resolvem para Character e 2 para Cat (level35 id 101015, level84 id 100762); **nenhum Toddler, Baby, Dog ou Horse** é criado por esse spawner nas cenas. Flags: `_playAnimation` 17, `_allowSpawnWhenAlreadyInGame` 11, override de prefab 15, `_isFlipped` 2, sem ponto de spawn (`_spawnPoint` nulo) 7.

**Decisão em `OnLevelPrePostInit` (`0x2299144`), provada pelo disassembly:**
1. Sai se `!_isValid (0x42)` ou `_didSpawn (0x41)`.
2. Se `!_allowSpawnWhenAlreadyInGame (0x31)` e `LevelAvatarData.TryGetData(_avatarId)` acha dados: registra `"LevelAvatarOneTimeSpawner: Already in game! _avatarId[...] scene[...]"`, grava `_didSpawn = true` e sai.
3. Se já existe avatar com esse id no nível atual (predicado `<OnLevelPrePostInit>b__10_0`): registra `"...Already in current level! _avatarId["`, grava `_didSpawn = true` e sai. Esta checagem roda mesmo com `_allowSpawnWhenAlreadyInGame`.
4. Senão: `PlaceAvatarInScene(_spawnPoint, _avatarId)`; se `_playAnimation (0x30)` chama `HandleCAHandlers(avatar)`; se o avatar existe chama `LevelItem.SetFlipped(avatar, _isFlipped (0x40), true)` e grava `_didSpawn = true`.
`_didSpawn` é persistido (`GetPersistentData` devolve `BoolPD`, `SetPersistentData` restaura).
`SpawnAvatar` (`PDPrefabReference.IsValid` → override de prefab; `LevelUtils.SpawnAvatar`; `PDSceneObject.EnsureSceneGuid`; erro `"Expected PDPrefabPack!"`). `PlaceAvatarInScene` escolhe por tipo da área no ponto (ramos que chamam `LevelCharacterInteractionHandler.SleepOn` ou `LevelItem.PerformBasicDrop`; padrão `"No case found for area["`). `HandleCAHandlers`: `AddCAHandlers`, número aleatório em intervalo e `PlayContextualAnimation`.

Inferido (não provado): qual tipo concreto de área vai para `SleepOn` (provavelmente cama) e qual para `PerformBasicDrop`; o que acontece com `_spawnPoint` nulo (7 casos); o significado do intervalo aleatório de `HandleCAHandlers`.

Contrato C#: `Core/Avatar/AvatarSpawnRules.cs` (`Decide`, `SetsDidSpawn`, `LogsError`, mensagens originais) com `AvatarSpawnRulesTests` (9 casos).

## Recorte 2026-11-05 (13): idle apropriado, objeto segurado e animações contextuais do Character
Ferramenta: `tools/recon_disasm.py` agora resolve também slots de **tipo** (índice de uso → `byvalTypeIndex` → nome), o que identifica `isinst`/comparações de classe.

**`PlayProperIdleAnimation` (`0x22a3a40`), provado.** Campos de `LevelCharacter`: `+0x3E0` = `LockedCAHandler`, `+0x3B8` = `CurrentRestArea`. Prioridade:
1. `LockedCAHandler != null` (semântica Unity): toca em loop o idle que o próprio handler informa (chamada virtual, slot `0x2E8` do handler) via `SetAddAnimationInternal`.
2. Senão, se o delegate `OverridePlayProperIdleAnimationAction` (`+0x28`, `Func<bool>`) devolve verdadeiro, não toca nada.
3. Senão: `CurrentRestArea` é `LevelSitArea` → `CA/Chair_Sitting/Sit_On_Chair_Idle`; `LevelSleepArea` → `CA/Bed_Laying/Laying_Idle`; qualquer outro → `PlayStandIdleAnimation` (`Idle_Stand_1`).

**`UpdateMovementOverrideHandler` (`0x22a5c10`), provado.** `_movementOverrideHandler` (`+0x60`) vem de `GetHeldItem(mão 1 = LeftHand)`; se for nulo (Unity), `GetHeldItem(mão 2 = RightHand)`. `GetHeldItem` usa `LevelCharacterInteractionHandler.TryGetHandItem` e o componente `LevelCharacterMovementOverrideHandler`. É chamado ao fim de `OnBeginMovement` (salto de cauda). Inferido: `MovementCyclesWalkOverride` do handler substitui o ciclo de andar; o uso exato dentro de `OnMovement` não foi confirmado.

**`OnBeginMovement` (`0x22a1150`), parcial.** Provado: liga `_canForceNormalDragging`; lê `GetCurrentBehaviorItem`; testa se o handler é `LevelCAItemWithSkinHandlerBase`, `LevelCAItemSpineNoSkinHandlerBase` ou `LevelCAHandlerWithData` (checagem de tipo em cadeia); toca `Lift_Idle` via `SetAddAnimationInternal` em um ramo; compara uma string com `"Legs_Shoes_119"`; termina em `UpdateMovementOverrideHandler`. Não determinado: a condição exata que escolhe `Lift_Idle` e o que `"Legs_Shoes_119"` representa (não é skin, slot nem animação de `Avatar_Spine`; aparece só como prefixo de ids como `Character_Legs_Shoes_1194_Color` nos packs de roupa, ou seja, pode ser comparação por prefixo ou um id literal de calçado).

Contratos C#: `Core/Avatar/ProperIdleSelector.cs` (7 testes) e `Core/Avatar/HeldItemRules.cs` (4 testes).

## Recorte 2026-11-05 (14): animações contextuais (CA), entrada do sistema
`CAPlayType` (provado, enum do assembly): `None 0`, `PlayingNormalAnimation 1`, `PlayingAlternateIdle 2`, `PlayingPreAnimation 3`. `LevelCharacter` guarda `LockedCAHandler (0x3E0)`, `CurrentCAHandler (0x3E8)`, `CurrentCAConfig (0x3F0)`, `CurrentCAPlayType (0x3F8)`, `ContexualAnimationCounter (0x3FC)`, `AlternateIdleCAConfig (0x400)`, `AlternateIdleCAHandler (0x408)` e a lista `CAHandlers (0x410)`.
`CATargetExtensionMethods.PlayContextualAnimation` (`0x23ab96c` aprox., 3.336 bytes) provado: valida `target` (`"target is null!"`) e o nome da config (`" animationConfig.name is null or empty!"`); usa `IsAlive`, o gate `LevelManager.IsManagerPostInit`, `LevelCAConfig.CreateAnimationName` e um callback `TrackEntryDelegate` (fechamento `<>c__DisplayClass1_0`) para o fim da animação; despacha por `CAPlayType` com padrão `"No case found for playType["` e ramo `"Not supported!"`; quase todas as chamadas passam por `ICATarget` (interface), então a decodificação completa depende de identificar as implementações (Character, Toddler, Animal, Baby). Isso pertence ao T035 e ficou aberto. Várias strings (`Trolley`, `Heavy_Lifting`, `Stealing_Food`) que aparecem nos métodos vizinhos são ruído de janela, não prova de uso.

## Recorte 2026-11-05 (15): T035 — `ICATarget` e `PlayContextualAnimation`
Ferramenta: `tools/recon_disasm.py` agora anota **chamadas de interface** (`mov w2,#N` + `bl 0x1b7ba44` → `ICATarget.<método>`, índice na ordem de definição) e aceita `@0xENDEREÇO`. O rastreio do tipo se limita a interfaces (nome `I` + maiúscula) para não vazar para `UnityEngine.Object`.

**`ICATarget`** (20 métodos, índices de despacho 0–19): `get/set CurrentCAHandler`, `CurrentCAConfig`, `CurrentCAPlayType`, `ContexualAnimationCounter`, `LockedCAHandler`, `get CAHandlers`, `get/set IsMoving`, `GetTransform`, `ReturnToIdleAnimation`, `OnBeforePlayContextualAnimation`, `OnAddedCAHandlerWithLockedAnimation(handler)`, `ShouldIncludeInEnsureCheck(handler)`, `SetAnimation(name, loop, ensureRequiredTextures, trackIndex)`, `OnCARemoved`.
**Implementadores (5):** `LevelCharacter`, `LevelToddler`, `LevelBaby`, `LevelAnimal` (Cat/Dog/Horse herdam) e `LevelDynamicSignRobot`.

**`PlayContextualAnimation` (`0x23ab96c`, 3.336 bytes), ordem das chamadas provada** (por ordem de endereço):
1. `IsAlive(target)` falso → erro `"target is null!"`; depois nome da config vazio → `" animationConfig.name is null or empty!"`.
2. `target.GetTransform()` (2 sítios).
3. `target.OnBeforePlayContextualAnimation()` (4 sítios, ramos por tipo de reprodução).
4. `ContexualAnimationCounter`: `get` e `set` (incremento), mais um `get`.
5. `set CurrentCAPlayType`, `set CurrentCAHandler`, `set CurrentCAConfig`.
6. `LevelCAConfig.CreateAnimationName` e `get CurrentCAConfig`.
7. `target.SetAnimation(...)` em dois sítios (animação normal e a de fim/idle alternativo).
8. Callback de fim `TrackEntryDelegate` (fechamento `<>c__DisplayClass1_0`), com o gate `LevelManager.IsManagerPostInit` em dois sítios e `get CurrentCAConfig` ao concluir.
9. Padrão do `switch` por `CAPlayType`: `"No case found for playType["`; ramo `"Not supported!"`.

**Implementação do Character (provada, métodos curtos):** `ShouldIncludeInEnsureCheck` → sempre `true` (`0x22a3a18`); `GetTransform` → `transform` do próprio objeto; `ReturnToIdleAnimation` → `Animator.PlayProperIdleAnimation()` (`0x22a3a28`); `OnBeforePlayContextualAnimation` → `InteractionHandler.ReleaseCurrentBehaviorItemIfExists()` (`0x22a3be8`); `OnAddedCAHandlerWithLockedAnimation` → libera a mão (`FreeHand`) se houver outro item e chama `ReleaseCurrentBehaviorItemIfExists`; `SetAnimation` (`0x22a3c00`) testa `CurrentRestArea is LevelSitArea` e usa o literal `"__Sitting"` antes de `Animator.SetAddAnimationInternal`.
**Verificado no esqueleto:** `Avatar_Spine` tem 11 animações `*__Sitting` (ex.: `CA/Microscope/Look_And_Find_Nothing__Sitting`), todas com a versão base também presente; `Toddler_Spine` tem 0. Inferido: sem a variante, mantém o nome base (o fallback não foi confirmado instrução a instrução).

Contrato C#: `Core/Avatar/ContextualAnimationRules.cs` (`CAPlayType`, `ValidateStart`, `CharacterAnimationName`, mensagens originais) com 9 testes.

**Aberto:** o que cada um dos 4 sítios de `OnBeforePlayContextualAnimation` distingue; os parâmetros de `SetAnimation` (loop por tipo de reprodução); implementações de `LevelToddler`, `LevelBaby`, `LevelAnimal` e `LevelDynamicSignRobot` (não lidas); quais handlers de CA existem e em que cenas (`LevelCAConfig`, `LevelCAHandlerBase`).
