# Entrada, arraste e câmera — contrato parcial (T031)

Data: 2026-11-04  
Escopo: leitura estática do IL2CPP ARM64 e composição serializada das cenas `level4` (mapa) e `level8` (quadra). Não inclui execução interativa.

## Artefatos e integridade

- `out/recon/tasks/T031/input-asm/report.json` indexa 72 janelas de métodos, sem alvos ausentes, a partir de `metadata_methods.jsonl` e `libil2cpp.so` (SHA256 `b63661fa60c23ebef1c2da4bb5288ad787eb3da36b22d4bdf285401f1643d728`). Janelas e arestas ficam em `out/recon/tasks/T031/input-asm/`.
- `tools/recon_input_scene.py` gera os relatórios compactos de cena. `level4-input-scene.json` referencia a cena SHA256 `d3e51b2e16a3319b3a0671973f2c1c12ca828040c7108148a3599a17a58e2e45`; inspeção SHA256 `e89ddaf8cc37982da9c7c09fc00c758b71d89962c8eb2b556c0b47bd90985e50`.
- `level8-input-scene.json` referencia a cena SHA256 `dff6d557630a579e05a48f65519b75c0aefb41c55623b4ad89078e9d290c38f5`; inspeção SHA256 `265566b90aa4d618a344473fe2212d3eda0275eb6eb862473ba0592df5e13022`.
- As janelas terminam no próximo endereço de método de metadata (máximo 16 KiB). Isso é limite de extração, não prova de corpo completo nem CFG recuperado. Chamadas virtuais/indiretas permanecem sem resolução.

## Fluxo que a evidência sustenta

1. A cena serializa `EventSystem`, `StandaloneInputModule` e `GraphicRaycaster`; assim, nas cenas-piloto o roteamento observado é do EventSystem padrão, mesmo havendo classes multiplayer `MPPointerInputModule` e `MPStandaloneInputModule` no assembly. Não se deve atribuir o módulo multiplayer às cenas sem prova adicional.
2. `DragDropItemBase` implementa os handlers de início, movimento, fim e clique; `InteractableItem` fornece pointer down/up. A classe guarda estado de ponteiro, posições inicial/início do drag, offsets, câmera e restrições de eixo. `MPPointerInputModule.ShouldStartDrag` compara a distância quadrática entre posições com o limiar quadrático fornecido; o valor concreto vem do chamador/configuração e não foi afirmado aqui.
3. `MPPointerInputModule.ProcessDrag` contém o caminho de atualização de drag; `MPStandaloneInputModule.ProcessTouchEvents` e `ProcessTouchPress` tratam o fluxo de toque. Este último tem 1.636 bytes de janela e chamadas diretas abundantes; `ProcessTouchEvents` tem cinco dispatches indiretos. A janela de `DragDropItemBase.OnBeginDrag` (568 bytes) e `OnEndDrag` (384 bytes) também contém quatro dispatches indiretos cada. Isso deixa ordem de callbacks, cancelamento e algumas ramificações ainda abertas.
4. `LevelItem.OnBeginDragInternal` (janela de 1.424 bytes) chama a base, interrompe tweens/atualiza relações com `CShape`, posição, parent/escala/rotação/orientação, ordenação e iluminação. Há cinco chamadas indiretas. `OnEndDragInternal` (572 bytes) libera relações e segue para lógica de queda/ajuste, com três chamadas indiretas. `GetMostRelevantDropAreaUnderPosition` consulta `LevelDropAreaQuery.IsDroppableUnderItem`; os critérios completos devem ser tratados no relatório de assembly.
5. `LevelConsumerAreaBase.TryLevelItemDropInteraction` tem janela curta (32 bytes) que limpa o resultado e retorna falso; isto só confirma esse método-base. Não prova a resposta de overrides/áreas concretas nem que todo drop seja recusado.
6. `LevelScrollCameraOnDrag` está serializado 68 vezes em `level4`. `OnBeginDrag` tem janela de 188 bytes; `OnDrag` e `OnEndDrag` aparecem como retorno imediato de 4 bytes. Não inferir pan contínuo dessa classe isoladamente: pode haver outro componente/caminho; o comportamento previamente observado no aparelho é evidência separada de arrasto no mapa.

## Comparação das cenas-piloto

| Cena | Evidência de entrada | Hitboxes serializados |
|---|---|---|
| `level4` mapa | 9.135 objetos (relatório de inspeção); 1 `EventSystem`, 1 `StandaloneInputModule`, 7 `GraphicRaycaster`, 68 `LevelScrollCameraOnDrag`, 162 `CShape` | 107 `PolygonCollider2D`; bounds/vertices locais e transform preservados no JSON |
| `level8` quadra | 2.403 objetos; 1 `EventSystem`, 1 `StandaloneInputModule`, 1 `GraphicRaycaster`, 14 `LevelItem`, 4 handlers `LevelBSBasketballItemHandler`, 2 `LevelBSHoop`, 4 `LevelDropArea`, 4 `LevelBouncyBall`, 1 placar | 18 `PolygonCollider2D`; inclui `Floor`, `BasketBallGate`, `ClickShape` e áreas de parede não-dropeáveis |

O export registra coordenadas e bounds dos polígonos no espaço local, offset e transform do GameObject. Não converte os polígonos em espaço mundial nem calcula a precedência entre raycasts/UI, colliders e formas `CShape`.

## Em aberto

- Resolver dispatches virtuais nas rotinas de drag, callbacks de override, interrupção/cancelamento e click versus drag.
- Extrair/configurar o limiar real de arraste, identidade/precedência do pointer, multi-touch e regras de safe area.
- Fechar `LevelDropAreaQuery`, áreas concretas e destino da cesta: aceitação, pontuação, colisões e física dependem de mais métodos e de observação dinâmica.
- Explicar o input real do mapa/câmera a partir da hierarquia e dos callbacks efetivamente ligados; o callback `OnDrag` desta classe está vazio na janela extraída.
- Comparar tap, drag, soltura válida/inválida, cancelamento, overlap e dois dedos em execução. Essa validação fica para quando o usuário quiser retomar os testes no aparelho.

T031 permanece parcial. Este documento registra evidência estática e evita tratar presença de componente ou chamadas indiretas como prova de comportamento completo.

## Recorte 2026-11-04: o que dispara OnBeginDragInternal, OnSyncPosition e OnEndDragInternal
Ferramenta: `tools/recon_callers.py` (chamadores `bl`/`b` por método; saída `out/recon/tasks/T031/drag-callers.json`) mais varredura de `ldr x,[x,#off]` com a fórmula de vtable IL2CPP `off = 0x138 + slot*16` (validada: `OnEndDrag` carrega `0x318` = slot 30 = `OnEndDragInternal`).

Slots de `DragDropItemBase` (campo `slot` do mapa de métodos): `OnBeginDrag` 20, `OnDrag` 22, `OnEndDrag` 23, `SyncPosition` (corrotina) 24, `OnSyncPosition` 27, `OnBeginDragInternal` 29, `OnEndDragInternal` 30, `OnPointerClickInternal` 31, `StopSyncPosition` 32.

Provado pelos bytes:
- `DragDropItemBase.OnBeginDrag` (`0x206b864`): carrega o slot 29 e chama `OnBeginDragInternal` (virtual), depois chama o slot 32 `StopSyncPosition`; também invoca o delegate `OnBeginDragAction` (campo `0xC0`).
- `DragDropItemBase.OnEndDrag` (`0x206bb40`): chama `StopSyncPosition` (slot 32) e `OnEndDragInternal` (slot 30); também invoca `OnEndDragAction`.
- `DragDropItemBase.OnDrag` (`0x206bb3c`) é só retorno: **o arraste contínuo não vem de `OnDrag`**.
- `StartSyncPosition` (`0x206baec`) chama `StopSyncPosition` (slot 32) e depois a corrotina virtual `SyncPosition` (slot 24). O `MoveNext` de `<SyncPosition>d__75` (`0x206c7d0`, 1.008 bytes) chama o slot 27, `OnSyncPosition`, em `0x206c85c` e `0x206cb78`, além dos slots 25 e 26 (não identificados). Logo `OnSyncPosition` é chamado **por quadro dentro da corrotina**, e não por evento de ponteiro.
- Quem inicia a corrotina: não foi localizado neste recorte (`StartSyncPosition` é virtual; os chamadores diretos não aparecem).
- Cadeia dos `*Internal`: `LevelItem.OnBeginDragInternal`/`OnEndDragInternal` são chamados por overrides diretos (Character, Toddler, Animal, Baby, itens de tarefa) que invocam a base; `LevelCharacter.OnBeginDrag`/`OnEndDrag` fazem salto de cauda para `DragDropItemBase.OnBeginDrag`/`OnEndDrag`.
- Fluxo sustentado: `EventSystem` (via `IBeginDragHandler`/`IEndDragHandler`) → `LevelCharacter.OnBeginDrag` → `DragDropItemBase.OnBeginDrag` → `OnBeginDragInternal` (Character → `LevelItem`) e `StartSyncPosition`; a cada quadro a corrotina chama `OnSyncPosition` (Character → `LevelCharacterAnimator.OnMovement`); no soltar, `OnEndDrag` → `StopSyncPosition` e `OnEndDragInternal` (Character → `OnEndMovement`).

Ligação com T032: `LevelCharacter.OnSyncPosition` salta para `LevelCharacterAnimator.OnMovement`, portanto a velocidade da histerese 0.06/0.006/6.0 é a do ponteiro arrastado, medida por quadro na corrotina. A unidade de `t` (deltaTime) continua inferida.

Limites: os slots 25/26 da corrotina e o chamador de `StartSyncPosition` ficam abertos; chamadas por delegate/interface e `MPPointerInputModule` não entram na varredura de `bl`/`b`; a janela de nomes duplicados (`<SyncPosition>d__5` é de outra classe) foi descartada por número `d__75` casar com o campo da classe.

## Recorte 2026-11-04 (2): limiar de arraste, clique contra arraste, corrotina de sincronização
Provado:
- **`MPPointerInputModule.ShouldStartDrag` (`0x20cb0ec`)**: `(useDragThreshold, posA, posB, threshold)`; se `useDragThreshold` é falso retorna verdadeiro; senão retorna `(Δx²+Δy²) >= threshold²`. É o algoritmo padrão do Unity, sem ajuste do jogo.
- **Valor do limiar**: o campo serializado `m_DragThreshold` do `EventSystem` vale **10** (pixels) nas 249 `EventSystem` decodificadas em `out/mb`, inclusive level4, level8, level233, level234 e level237. Inferido (não provado): é esse valor que o módulo passa como `threshold`; `ShouldStartDrag` não tem chamador direto (virtual/ponteiro).
- **`DragDropItemBase.OnPointerDown` (`0x206c1b0`)**: se o flag `0x38` está ativo trava o EventSystem na `CShape` atual (`LockEventSystemToCurrentCShape`); guarda o id do ponteiro (`eventData+0x100` → `this+0x78`), a posição do ponteiro (`GetPointerPositionForDrag`) em `this+0x80` e liga `this+0x7C` (ponteiro pressionado). `OnPointerUp` (`0x206c210`) destrava (se `0x38`) e zera `this+0x7C`.
- **Clique contra arraste** (`OnPointerClick`, `0x206c244`): retorna sem fazer nada se `eventData` é nulo, se `eventData+0x145` está ligado ou se `this+0x39` está ligado; caso contrário invoca o delegate `OnPointerClickAction` (`0xB8`) e o virtual `OnPointerClickInternal` (slot 31). Inferido: `eventData+0x145` é `PointerEventData.dragging` (o Unity o liga ao passar do limiar), então um toque que virou arraste não gera clique; o significado de `this+0x39` não foi determinado.
- **Slots 25 e 26 da corrotina**: `GetDragPositionForThisFramePreModifications` (25) e `GetDragPositionForThisFramePostModifications` (26, sobrescrito em `LevelItem`). Ordem no `MoveNext` de `<SyncPosition>d__75` (`0x206c7d0`): slot 27 em `0x206c85c`, Pre (25) em `0x206c958`, Post (26) em `0x206cb48` e `OnSyncPosition` (27) de novo em `0x206cb78`; a posição passada a `OnSyncPosition` passou por Pre e Post. O primeiro uso do slot 27 em `0x206c85c` fica sem explicação.
- **Quem inicia a corrotina**: a varredura de cargas do slot 21 (`StartSyncPosition`) na família de arraste só encontra `DragDropItemBase.OnBeginDrag` como chamador plausível (`ReleaseCurrentDropAreaIfExists` e `get_CurrentCandidateDropArea` são vizinhança de janela). Fecha a cadeia: `OnBeginDrag` → `StartSyncPosition` → corrotina `SyncPosition` por quadro; `OnEndDrag` → `StopSyncPosition`.

Consequência para a cópia e para T032: o Character só começa a se mover depois que o ponteiro percorre 10 px (ou imediatamente se `useDragThreshold` for falso, caso não verificado) e a partir daí `OnSyncPosition` roda por quadro; um toque que não passa de 10 px é clique, não arraste. Para T026: a corrotina de arraste está mapeada (slots 24→21/32, 25/26/27 no `MoveNext`).

Limites: a unidade/escala do limiar em dispositivos de densidades diferentes (o Unity usa pixels de tela, sem conversão por DPI neste código) e o caso `useDragThreshold = false` não foram verificados; multitoque, `MPPointerInputModule.ProcessDrag` e precedência UI contra CShape continuam abertos.

## Contrato C# do T031 (2026-11-04)
`Assets/Scripts/Core/Pointer/DragIntentDetector.cs` (namespace `AvatarWorld.Core.Pointer`, evitando sombrear `UnityEngine.Input`): `ShouldStartDrag` estático (`useDragThreshold` falso → sempre; senão `Δ² >= limiar²`), `PointerDown/PointerMove/PointerUp`, fases `Idle/Pressed/Dragging`, limiar padrão 10 px medido **desde o pressionar** (não desde o movimento anterior) e `ClickSuppressed` para o flag `this+0x39` (significado desconhecido). Soltar sem ter virado arraste → `Click`; depois de arrastar → `EndDrag`, mesmo voltando perto do início.
Testes: `Assets/Tests/EditMode/DragIntentDetectorTests.cs` (13 casos; limites 9.99/10, diagonal 7/7.1, flag desligado, clique suprimido, sem pressionar). Verificação: 24 testes (11 de locomoção + 13 deste) passam num harness .NET com shim de NUnit; **não** rodados no Unity Test Runner.
Fora do contrato (não provado): se o threshold real do módulo é o `m_DragThreshold` do `EventSystem`, a conversão por DPI, multitoque e o pipeline Pre→Post→`OnSyncPosition` por quadro.

Atualizacao 2026-11-05: os 28 testes (LocomotionStateMachineTests 11, DragIntentDetectorTests 13, DragPositionPipelineTests 4) passaram no Unity 6000.6.6f1 EditMode (28/28), em batchmode sem -quit (com -quit o Unity sai sem executar testes).

## Componente de Runtime (2026-11-05)
`Assets/Scripts/Runtime/CharacterDragController.cs` liga ponteiro -> `DragIntentDetector` -> `DragPositionPipeline` -> velocidade -> `LocomotionStateMachine` -> `LocomotionAnimations.NameFor`; expoe `Movement`, `CurrentAnimation` e eventos `DragStarted/DragEnded/Clicked/MovementChanged`, sem tocar em Spine. `Tick(pressed, screenPos, dt)` e testavel sem dispositivo; `Update` le `Pointer.current` (Input System). Velocidade em unidades de mundo por segundo (inferido). Achado: `None` -> `Stand` no `Next` (nos tres `OnMovement`, `cmp w8,#1; b.ne` cai no ramo de idle e grava 1); sem isso o personagem travava apos soltar. 39 testes (28 de contrato + 11 do componente) passam no Unity 6000.6.6f1 EditMode. Nao validado em cena real nem com Spine.

## Teste PlayMode com Avatar_Spine real (2026-11-05)
`Assets/Tests/PlayMode/CharacterSpineDragPlayTests.cs` (asmdef `AvatarWorld.PlayModeTests`): mouse virtual do Input System -> `CharacterDragController` -> `SkeletonAnimation` com o `Avatar_Spine` real (atlas com paginas 1x1 transparentes via `AvatarAtlasLoader`). 5 testes passam no Unity 6000.6.6f1 PlayMode batchmode: o esqueleto tem `Idle_Stand_1`, `Movement_Cycles/Walk`, `Movement_Cycles/Run` e `Lift_Idle`; comeca em `Idle_Stand_1`; arrastar >10 px toca `Movement_Cycles/Walk` e o personagem acompanha o ponteiro; soltar volta a `Idle_Stand_1`; parar com o dedo pressionado volta a idle e voltar a mover retoma o walk; toque <10 px e clique e mantem idle. Gotchas: em batchmode o Input System descarta eventos de ponteiro sem foco do Game View (o teste define `editorInputBehaviorInPlayMode=AllDeviceInputAlwaysGoesToGameView` e `backgroundBehavior=IgnoreFocus`); `-quit` impede a execucao dos testes. Nao coberto: Toddler/animais (sem esqueleto em Resources), renderizacao, camera real, multitoque.

## Toddler e animais no mesmo fluxo (2026-11-05)
`Assets/Tests/PlayMode/CharacterFamiliesPlayTests.cs` com esqueletos reais em `Assets/Tests/PlayMode/Fixtures/` (Toddler_Spine 4,4 MB, Pet_Dog 2,2 MB, Pet_Cat 1,3 MB; fora de `Resources`, logo fora do build; carregados via `AssetDatabase`). 4 testes PlayMode passam (9/9 com os do Character): Toddler em pe toca `Movement_Cycles/Walking_Loop`, sentado `Movement_Cycles/Crawling_Loop`, parado `General/Stand_Idle`, e nunca corre mesmo rapido; Dog anda (`General/Walking`) e corre (`General/Running`, >18 u/s com corrida) e volta a `General/Standing_Idle`; Cat sem corrida fica em `General/Walking`. `CharacterDragController` ganhou `DeltaTimeOverride` (velocidade deterministica em teste) e recalcula a animacao inicial no `Start` (Family/Posture sao configurados depois do AddComponent). Nao coberto: Horse, Baby (sem locomocao), renderizacao, camera real.

## Recorte 2026-11-08: dispatches indiretos de begin/end drag e mecanismo de prioridade de hitbox

Ferramenta: `tools/recon_t031_dispatch.py` (saída `out/recon/tasks/T031/dispatch-resolution.json`, testes de mutação em `tools/test_recon_t031_dispatch.py`, 7/7 OK). Ambiente sem Hopper/Ghidra/IDA utilizável (bridge do Hopper expirou por diálogo de licença/loader, igual a tentativas anteriores; `objdump` deste sandbox não tem suporte a AArch64; Ghidra/IDA não configurados) — leitura continua sendo ELF+metadata byte a byte, igual às demais ferramentas `recon_*`. Cada fato abaixo é re-derivado da tabela `fieldOffsets`/`Il2CppMethodDefinition.slot` do par atual e conferido contra o opcode exato do call site (sem confiar em cache `.jsonl`); ambos checados pelos testes de mutação.

**`DragDropItemBase.OnBeginDrag` (os "quatro dispatches indiretos" do recorte 2026-11-04, agora com identidade e efeito provados):**
1. Campo `0xE8` = `TryOverridePreBeginDragAction(this, eventData)`. Se presente e retornar `true`, a função retorna imediatamente — `StopSyncPosition`, `OnBeginDragInternal`, `OnBeginDragAction` e `StartSyncPosition` são todos pulados. É o gancho de cancelamento/override do início do arraste.
2. Slot 32 (offset `0x338`) = `StopSyncPosition(this)`.
3. Slot 29 (offset `0x308`) = `OnBeginDragInternal(this, eventData)`.
4. Campo `0xC0` = `OnBeginDragAction(this, eventData)` (evento, fire-and-forget), confirmando o offset já citado no recorte anterior.
5. Tail-branch, slot 21 (offset `0x288`) = `StartSyncPosition(this)` — chamada de cauda após o epílogo, só executada quando os passos acima não retornaram antes.

Resolvido também: `this+0x39` (citado como "significado não determinado" no recorte 2026-11-04(2)) é `<IsDragging>k__BackingField`; é por isso que `OnEndDrag` o zera antes de prosseguir e `OnPointerClick` o consulta para suprimir clique.

**`DragDropItemBase.OnEndDrag` (simétrico, mesmos "quatro dispatches"):**
1. Campo `0xF0` = `TryOverridePreEndDragAction(this, eventData)`. Se presente e `true`, retorna direto ao epílogo sem zerar `IsDragging`/`_dragPositionOffset` nem chamar `StopSyncPosition`/`OnEndDragInternal`/`OnEndDragAction`.
2. Slot 32 = `StopSyncPosition(this)`.
3. Campo `0xC8` = `OnPreEndDragAction(this, eventData)` (evento).
4. Slot 30 (offset `0x318`) = `OnEndDragInternal(this, eventData)`.
5. Campo `0xD0` = `OnEndDragAction(this, eventData)`, como tail-branch só alcançado quando o campo é não nulo (senão `cbz` retorna direto).

**`LevelItem.OnBeginDragInternal` (4 dos 5 dispatches indiretos resolvidos):** slot 58 `PlayPickUpSound(this)` (pulado quando `<IsPerformingBasicDrop>k__BackingField`, offset `0x231`, é verdadeiro), slot 61 `DetachFromParentIfExists(this, true)`, slot 63 `GetDefaultScaleForCurrentFlipState(this)`, slot 60 `CacheLevelItemsUnderSelfForNotifyEvents(this)`. Confirma por nome os campos já citados por inferência: `_orientationHandler` (`0x228`), `_sortingTransform` (`0x178`), `_movableLightSystemObject` (`0x170`). O quinto dispatch é um delegate estático (offset `0x10` de um bloco estático acessado via o mesmo GOT de guarda de inicialização de classe, `0x41b5000+0x5c0`) chamado só com `this`; o tipo declarante não foi identificado nesta passagem.

**`LevelItem.OnEndDragInternal` (2 dos 3 dispatches indiretos resolvidos, achado principal da passagem):** o campo `0x328` é **`OverrideOnDropBehaviorAction(this, eventData)`** — se presente e `true`, descarta por completo o pipeline padrão de queda/pouso/escala/orientação/som (`DropOnDropArea`/`FallOnDropArea`/`SnapToDropArea`/`TweenToProperPositionOnDropArea`, slots 66-69). É o ponto de extensão que itens de drop customizado (ex.: pontuação) usariam em vez do comportamento padrão. Também resolvido: slot 63 de novo `GetDefaultScaleForCurrentFlipState(this)`; `<ShouldCallFixPositionIfNeededOnEndDrag>k__BackingField` (`0x1b8`) controla uma chamada extra de ajuste de posição; `<LastFallDistance>k__BackingField` (`0x254`) é zerado antes do ramo de queda. O terceiro dispatch é o mesmo delegate estático do método anterior, offset `0x18` (simétrico ao `0x10`), mesmo tipo não identificado.

**Prioridade de hitbox (`SortDropAreas`/`GetMostRelevantDropAreaUnderPosition`):** nenhum dos dois métodos tem `blr` (confirmado por varredura negativa de opcode nas duas janelas). `SortDropAreas` ordena a lista estática de áreas candidatas com um `Array`/`List.Sort` direto usando um comparador estático (tipo/critério não identificado). `GetMostRelevantDropAreaUnderPosition` percorre essa lista já ordenada com um enumerador `List<T>` comum e retorna a **primeira** área para a qual o predicado em `0x23544e0` (consistente com `LevelDropAreaQuery.IsDroppableUnderItem`, já citado) retorna `true`. Ou seja: a prioridade entre hitboxes sobrepostas é inteiramente a ordem de `SortDropAreas`; não há pontuação de sobreposição calculada na própria seleção.

**Continua em aberto:** identidade do tipo por trás dos dois delegates estáticos de `LevelItem`; o comparador de `SortDropAreas`; os critérios de `IsDroppableUnderItem`; e física/pontuação completa (`LevelBSBasketballItemHandler.ScoreInternal`/`MissInternal`/`Shoot`, `LevelBSHoop`) — essas três últimas funções (≈2,7 KB) não foram abertas nesta passagem porque este sandbox não tem um disassembler AArch64 funcional nem provedor REA configurado; precisam de decodificação manual palavra a palavra ou de um ambiente com Ghidra/IDA/Hopper utilizável. Validação em aparelho continua adiada conforme combinado.
