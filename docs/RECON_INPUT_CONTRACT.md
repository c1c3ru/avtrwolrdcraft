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
