# T032 — movimento por família, revisão estática 2026-11-08

## Escopo e reprodução

Evidência local de `out/recon/il2cpp/libil2cpp.so` e metadata v31; hashes em `manifest.json`. Não houve execução de jogo nesta análise. A skill REA foi lida; o primeiro levantamento não tinha ferramentas REA conectadas, e a continuação usou o decoder ARM64 local com Capstone 5.0.9. Isto não é REA Evidence.

Reproduzir a partir da raiz:

```
tools/venv/bin/python out/recon/tasks/T032/families/collect.py
tools/venv/bin/python out/recon/tasks/T032/families/check.py
tools/venv/bin/python out/recon/tasks/T032/families/engine_calls.py
```

`collect.py` captura 16 métodos anotados. Limite: o disassembler usa a próxima entrada de método como fim da janela, não prova extensão do corpo por análise de CFG. Os métodos constantes têm corpo completo demonstrado por `ret` no segundo opcode. Anotações de string em cargas de objeto comuns podem ser ruído; aqui só as cargas GOT por `adrp` de início de método foram usadas como literais.

## Achados novos e correções

1. **Corrida animal não está habilitada no artefato.** `LevelAnimal.HasRunningAnimations` (`0x2265b28`, slot 147) é `mov w0,wzr; ret`. A busca de todas as definições em `assembly_csharp_methods.jsonl` encontra apenas essa definição do método. Portanto Cat, Dog, Horse e demais subclasses locais não sobrescrevem o retorno falso. O ramo `speed > 18` de `OnMovement` existe, mas seu gate é falso no programa recuperado. A presença de `General/Running` no skeleton não habilita corrida. `check.py` verifica os bytes, os slots e a cardinalidade de sete capabilities.
2. **Nome de caminhada animal:** `GetWalkingAnimationName` (`0x2266e08`, slot 158) retorna **`Track_Animations/Forced_To_Walk`**; `GetRunningAnimationName` (`0x2266e48`, slot 159) retorna `General/Running`. Em `OnMovement` (`0x226575c–0x2265770`), o ramo Walk desbloqueado chama slot 158. O mesmo slot fornece a faixa 1 quando há animação travada (`0x22658b0–0x22658f0`). Logo `General/Walking` é uma animação existente, mas não é o nome selecionado por este método.
3. **Gate por família de animal:** `HasWalkingAnimations`, slot 145, retorna true no LevelAnimal (`0x2265b18`); LevelTechBird/Cat/Dog/Rabbit/Robot devolvem false, todos com `mov w0,wzr; ret`. No início do arraste, slot 145 decide `OnBeginMovement` ou somente a animação de pickup; em `OnSyncPosition` decide se chama `OnMovement`. Assim os cinco techs se movem pela base física de item, sem alimentar esta máquina de caminhada. A família Animal não pode ser aplicada indistintamente a esses tipos.
4. **Velocidade com unidade recuperada:** `OnMovement` obtém `Component.transform` (`0x3cc84a8`), `Transform.position` (`0x3cd4584`) e usa `Time.deltaTime` (`0x3cd1b3c`) em `0x226567c`; calcula `sqrt(dx²+dy²)/deltaTime` em `0x2265668–0x2265684`. Os nomes foram resolvidos estruturalmente pela codegen module `UnityEngine.CoreModule.dll` em `engine_calls.json`. É deslocamento do objeto por tempo de frame, não leitura direta da posição do ponteiro. Os limiares são portanto unidades de mundo/segundo. A atribuição do deslocamento entre pointer e transform pertence à base de arraste.
5. **Swimming separado:** `LevelAnimal.HasSwimmingAnimations` (`0x2265b20`) retorna true; Horse (`0x1dc9c28`) retorna false. Não inferir a mesma capacidade só por herdar LevelAnimal.

## Fluxo por família

| Família | Início de arraste | Sincronização de posição | Fim do arraste | Locomoção |
|---|---|---|---|---|
| Character | wrapper já documentado delega ao animator | animator próprio | wrapper próprio | Stand/Walk; ramo Run não produzido pelo animator (evidência anterior) |
| Toddler | `LevelItem.OnBeginDragInternal` → `OnBeginMovement` | `LevelItem.OnSyncPosition` → `OnMovement` | se switcher consumir e campo `+0x230` falso: retorna; senão `OnEndMovement` → base | Walking_Loop em pé, Crawling_Loop em outras posturas, sem entrada em Run |
| Baby | base → delegate estático `(this,true)` | herda sync comum; nenhuma definição Baby de OnMovement nem OnSyncPosition no índice | se switcher consumir e `+0x230` falso: retorna; senão base | deslocamento físico da base; sem ciclos animados de locomoção no Baby_Spine (evidência anterior) |
| Animais comuns | base → delegate estático → gate walking → OnBeginMovement | base → gate walking → OnMovement | base → gate walking → OnEndMovement; sem área no `+0x1a0` e prestes a aterrissar no chão: PlayStandingIdle | Stand/Walk; corrida bloqueada pelo capability false |
| Cinco techs | base → delegate → animação de pickup, walking=false | apenas base | base; não chama OnEndMovement por walking=false | sem máquina de caminhada animada |

Baby `OnEndLand` (`0x229b898`) chama base, guarda resultado, invoca delegate estático `(this,false,true)`, verifica a área atual e o LockedCAHandler antes de retornar ao idle e devolve a área da base. Os nomes exatos dos delegates e o virtual da área estão no subtrabalho de dispatch; não foram inferidos aqui.

Busca de subclasses diretas em DiffableCs encontra 17: Bird, Fish, Hamster, Lizard, Turtle, Rabbit, Snake, Cow, Chicken; Cat, Dog, Horse; TechBird, TechCat, TechDog, TechRabbit, TechRobot. A busca de HasRunningAnimations em todas as definições encontra somente LevelAnimal. Esse é o limite da conclusão de corrida: programa Assembly-CSharp do binário fornecido, sem afirmar ausência de escrita externa, reflexão ou alteração em outra versão.

## Reconciliar no cliente

- `LocomotionConfig.Animal.CanEnterRun=true` descreve o ramo genérico, mas um cliente fiel precisa passar `HasRunningAnimations=false` para todos os animais recuperados ou explicitar essa capability como dado do artefato. O bool público de CharacterDragController permite comportamento que o original não produz.
- `LocomotionAnimations.NameFor(Animal,Walk,...)` retorna `General/Walking`; corrigir o caminho padrão de arraste para `Track_Animations/Forced_To_Walk`. Animação travada requer composição com faixa 1; trocar apenas o literal não cobre esse caso.
- O enum `LocomotionFamily` não inclui Baby e o default cai em Character. Não rotear Baby nem techs para esse default; precisam do movimento base e idle próprio.
- Não usar o retorno de Horse.HasSwimmingAnimations como igual ao da base.

Não foi alterado código compartilhado neste subtrabalho. Limiares e histerese já existentes não foram reimplementados aqui. Faltam validação dinâmica, integração de composição/locking de animações e aplicação dessas capacidades no cliente. A recuperação estática acima fecha nome de caminhada, gate de corrida, gate dos techs e unidade de velocidade; não fecha sozinha toda T032.

## Complemento — delegates do Baby e revisão independente

`delegates.py` / `delegates.json` registram o candidato **CATargetEvents**, único stub no corpus com campos estáticos `Action<ICATarget,bool>` em +0 e `Action<ICATarget,bool,bool>` em +8 (há ainda `Action<ICATarget>` em +0x10). Eles correspondem a `OnSelectedAction` e `OnUpdateCAListAction`.

- Baby BeginDrag carrega o campo estático +0 e invoca `(this,true)` em `0x229b800`.
- Baby EndLand carrega +8 e invoca `(this,false,true)` em `0x229b91c`.
- Corroboração independente: `CATargetExtensionMethods.AddCAHandlerAndUpdateGame` também carrega o **mesmo GOT 0x41bd548**, depois static_fields +8, e chama `(target,true,handlerFlag)` em `0x23aca3c`; arquivo ASM adicional preservado.

**Status da atribuição nominal: inferida com candidato único, não resolvida por join direto de metadata.** O usage obtido pelo GOT tem valor não canônico `0x710abf44f33b8a59`; interpretá-lo como índice de tipo seria incorreto. Assinaturas, offsets, argumentos e uso compartilhado no sistema de CA são recuperados; não inventam singleton ou destinatários dos eventos. Os subscribers permanecem fora deste recorte. A limitação precisa acompanhar a integração.

Revisão independente de NPC: `npc/validate.py` passou 16 checks; `review_npc.py` comparou os sete censos com **todos os registros originais gzip e seus hashes**, sem depender apenas das contagens do relatório. Os fluxos de caller e walkway foram conferidos nas instruções capturadas. `npc_review.json` registra o resultado. Nenhum problema impeditivo no relatório; a ausência de navegação está corretamente limitada aos managers examinados.
