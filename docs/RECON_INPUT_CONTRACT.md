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
