# T032 — dispatch de callbacks (2026-11-08)

Evidência estática local, sem execução do jogo. REA MCP e CLI não estavam disponíveis nesta sessão; o relatório não contém REA Evidence IDs. `probe.py` usa os leitores existentes do projeto e valida o par SHA256 de `libil2cpp.so` e metadata v31 antes de produzir `dispatch.json`.

## Reprodução e integridade

```bash
python3 out/recon/tasks/T032/callbacks/probe.py
python3 -m py_compile out/recon/tasks/T032/callbacks/probe.py
```

Resultado: 21 chamadas virtuais, 9 chamadas ILevelAvatar, 2 chamadas IHasPersistentData, 3 closures completas de 32 bytes e tabelas por seis famílias. Todas as 4.691 instruções de 12 disassemblies históricos selecionados são comparadas byte a byte com o ELF atual. O JSON registra hashes de fontes de declaração, par nativo/metadata, closures, snapshots e offsets das tabelas. `metadata_methods.jsonl` é revalidado via `recon_navigation.load_index`, incluindo token, nome, dono e ponteiro nativo. Nenhuma dependência externa foi instalada.

## CB01 — movimento dos animais: slots resolvidos

Os slots antes inferidos em `LevelAnimal.OnMovement` estão unidos à vtable da metadata:

| Offset de Il2CppClass / slot | Método | Sítios BLR em OnMovement |
|---|---|---|
| 0xad8 / 154 | GetPickUpLoopAnimationName | 0x2265494, 0x226560c, 0x2265868 |
| 0xa68 / 147 | HasRunningAnimations | 0x22656c8, 0x2265974 |
| 0xb18 / 158 | GetWalkingAnimationName | 0x226576c, 0x22658c0 |
| 0xb28 / 159 | GetRunningAnimationName | 0x2265a78 |

Cat/Dog/Horse herdam esses métodos de LevelAnimal; a resolução não depende de inferir nomes a partir de strings de animação. `OnBeginMovement` também despacha `GetLockedAnimationName` do handler (0x2264de0) e `GetPickUpLoopAnimationName` do animal (0x2264fd0). CharacterAnimator.OnBeginMovement chama `LevelCAHandlerBase.GetLockedAnimationName` no sítio 0x22a1284, slot27/offset0x2e8.

## CB02 — closures de passo

`LevelAnimal.<OnMovement>b__88_0` (0x2267430), `LevelCharacterAnimator.<OnMovement>b__27_0` (0x22a66b4) e `LevelToddler.<OnMovement>b__109_0` (0x23442d4) têm 32 bytes cada, até o próximo início de metadata. O probe exige os oito opcodes exatos.

Cada closure lê `OnStepContact`, retorna quando nulo e despacha o delegate com `(entidade, spineEvent)`. O animator usa `_character` em vez de si próprio. `trackEntry` é ignorado. Não há comparação do nome do evento nessas closures; não se deve acrescentar um filtro de nome ao reconstruí-las. Isso não prova a cardinalidade de emissão do Spine nem a ausência de outros listeners.

Campos que ligam os opcodes às declarações: Animal.OnStepContact +0x3e8; CharacterAnimator.OnStepContact +0x68 e `_character` +0x18; Toddler.OnStepContact +0x448.

## CB03 — aterrissagem

Cat.OnEndLand (call0x1dc4c20), Dog.OnEndLand (0x1dc60fc), Horse.OnEndLand (0x1dc9150) e Baby.OnEndLand (0x229b960) chamam `LevelDropArea.OverrideAvatarEndDropAnimation(this)` pelo slot30/offset0x318. O retorno verdadeiro desvia do fallback de animação, preservando o override da área. A classe concreta da área pode substituir o virtual.

Baby também possui dois dispatches para delegates estáticos em BeginDrag/EndLand. A entrada GOT0x41bd548 aponta para um encoding não canônico (`0x710abf44f33b8a59`); esta rodada não atribui um nome de tipo a esse singleton. Essa limitação fica explícita e não contamina o slot de área já resolvido.

## CB04 — todos os oito indiretos de PlaceAvatarInScene

Os testes de tipo usam GOT canônicos unidos a LevelSitArea (0x41b8a00), LevelSleepArea (0x41bb970) e LevelDropArea (0x41b8908). Oito sítios:

| Sítio | Alvo resolvido |
|---|---|
| 0x2299798 | LevelSitArea.IsAvailableForAvatar (slot26) |
| 0x2299814 | LevelSleepArea.IsAvailableForAvatar (slot26) |
| 0x2299898 | LevelDropArea.IsAvailableForItems (slot40) |
| 0x2299920 | ILevelAvatar.GetLevelItem (índice7) |
| 0x2299980 | ILevelAvatar.SitAvatarOn (índice19), snap=true |
| 0x22999a0 | ILevelAvatar.GetLevelItem (índice7) |
| 0x22999bc | LevelDropArea.CanConsumeItem (slot14) |
| 0x22999e4 | LevelItem.SnapToDropArea (slot68) |

Os caminhos rápidos e lentos das interfaces têm o mesmo índice, conferido por opcode. A metadata fornece offsets concretos por família: ILevelAvatar inicia em slot130 para Character/Toddler/Baby e160 para Cat/Dog/Horse. Assim GetLevelItem é slot137 ou167, e SitAvatarOn é149 ou179. O JSON contém método, token e ponteiro nativo concretos, incluindo implementações herdadas/padrão.

Polaridade observada, sem corrigir por intenção presumida: o ramo Sit aborta quando IsAvailableForAvatar retorna falso; Sleep aborta quando retorna verdadeiro (TBNZ em0x2299818). O método distribuído deve ser preservado com essa polaridade até evidência adicional explicar a aparente assimetria.

## CB05 — SaveDataInternal e ApplyDataInternal

SaveDataInternal despacha ILevelAvatar.GetLevelItem, GetPDPrefab e get_ID; ApplyDataInternal despacha GetLevelItem e GetPDPrefab. A metadata usage canônica ILevelAvatar é GOT0x41acdb8 / encoding0x2000ab7f. A sequência de métodos da interface é obtida da declaração real, sem usar a ordem alfabética do stub.

Os componentes com dados persistentes usam outra interface: GOT0x41c9c38 / encoding0x2000aaf5 = PWC.PersistentData.IHasPersistentData. SaveDataInternal chama índice0/GetPersistentData em0x2294ae8; ApplyDataInternal chama índice1/SetPersistentData em0x2295db0. Este último não é ILevelAvatar.GetLevelItem. O restante dos indiretos nessas janelas usa slot3/offset0x168 em caminhos de formatação de erro (ToString virtual; receptor dinâmico não fechado aqui).

## CB06 — caller de NPC

CallCharacter chama slot61/offset0x508 de LevelCharacter em0x22af374. A metadata resolve `LevelCharacter.DetachFromParentIfExists`; o argumento w1 étrue. Isso antecede a mudança direta de posição no fluxo analisado pelo relatório de NPC.

## Limites

O relatório fecha os nomes e os joins indicados, não demonstra execução ou paridade do cliente. Base da vtable0x138 e stride16 são sustentados pelo caminho rápido de interface e correlação com metadata; memória de Il2CppClass em execução não foi lida. Um receptor derivado pode substituir um virtual. As closures completas não tornam completas as janelas grandes de movimento/spawn. Estado e ordem dinâmica de listeners precisam de evidência própria; a classificação de autonomia e as regras de animação por família são relatadas separadamente.
