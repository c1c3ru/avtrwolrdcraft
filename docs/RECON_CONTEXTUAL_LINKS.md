# Configurações e nomes de animação contextual — T035

Atualizado em 2026-11-05. O extrator `tools/recon_contextual_links.py` conecta componentes serializados às configurações e reações contextuais, preservando a identidade `(arquivo, path_id)` de cada objeto. A presença de um nome no rig é evidência estática; seleção, cancelamento e efeitos em jogo seguem abertos.

## Dados e ligações recuperadas

A varredura de 2.305 inventários MonoBehaviour examinou 878.040 registros, além dos dois inventários de dados contextualizados. Há 974 assets `LevelCAItemHandlerData` com 3.150 configurações e 71 assets `LevelCAReactionsData` com 114 reações.

Foram resolvidas 5.704 referências para esses assets, provenientes de 5.678 componentes. Elas alcançam 894 assets de configuração e 66 de reação. Os 85 assets restantes não têm referência direta encontrada nesses dumps; podem exigir carregamento por nome ou outras fontes. Não houve referência declarada `Data` de `LevelCA*` sem resolução neste recorte.

O extrator lê as tabelas de referências externas de 239 arquivos serializados, diretamente dos intervalos necessários do UnityFS. O cache depende do SHA256 integral do bundle e registra o hash de cada prefixo de metadados. Uma retomada com o mesmo conteúdo reutilizou as 239 tabelas sem descomprimir blocos. Uma segunda reconstrução das identidades verificou todas as 5.704 ligações.

## Construção do nome

A janela nativa de `LevelCAConfig.CreateAnimationName` em `0x212fe74`, os campos recuperados e os getters com dados sustentam esta regra:

1. Se `isNameFullAnimationName` estiver ativo, retornar `config.name` diretamente.
2. Caso contrário, concatenar o prefixo, a pasta, `/`, o nome e o sufixo do handler.
3. `HasCAPrefixForCAAnimations` em `0x2187938` retorna verdadeiro para SpineType 1 (Character), 2 (Baby) e 13 (Toddler); nesses casos o prefixo é `CA/`.
4. A pasta usa `folderNameOverride` quando preenchida; nos handlers com dados, o getter básico usa `Data.FolderName`.

As 3.150 configurações têm o nome-base presente no rig correspondente, incluindo aves, peixes, roedores e outros animais. Isso confere o conteúdo disponível, mas uma classe pode alterar a pasta, trocar os dados ou acrescentar um sufixo em execução.

## Treze regras de sufixo

As 13 declarações de override encontradas foram cobertas por janelas nativas e literais:

- Nove handlers de toddler retornam `"_" + toddler.PostureType.ToString()`. O campo é lido em `LevelToddler + 0x440`; os valores declarados são `None=0`, `Standing=1`, `Sitting=2`.
- `LevelCACatOnToddlerHandler`, `LevelCADogOnToddlerHandler` e `LevelCASmallPetOnToddlerHandler` retornam `_Standing`.
- `LevelCAToddlerDancingClothingSpineSkinHandler` retorna `_Sitting` se a postura for Sitting e uma string vazia nos outros casos.
- O getter básico de `LevelCAHandlerBase` retorna uma string vazia.

As fórmulas e evidências por classe estão em `suffix_rules` no relatório. O extrator confere os literais e os acessos nativos esperados antes de aceitar essas classificações.

## Reações e diferenças de nomes

O predicado nativo de `FindReactionIfExist` em `0x1ee91b0` compara o nome da animação iniciadora usando `String.op_Equality`. `GetResolvedReactionAnimationName` em `0x22483d0` escolhe uma alternativa aleatória quando a lista está preenchida; caso contrário devolve `reactionAnimationName` sem alterar o nome.

Das 114 entradas, 113 nomes iniciadores existem em pelo menos um dos rigs mapeados e 111 nomes de reação existem no rig do ator que reage. O SpineType da reação identifica o ator que reage; ele não identifica necessariamente o ator iniciador.

Quatro entradas em dois assets precisam de reconciliação:

- `Bubble_Blower_Tube_L209_Baby_ReactionData` contém três reações com `CA/General/Look_Around_Amazed`, ausente no rig Baby. Esse rig contém `General/Look_Around_Amazed`.
- `ToddlerBookReadingAnimationsReactionsData2` usa o iniciador `CA/Infant_Book/Reading_Aloud_Hand_Motions`, não encontrado nos rigs mapeados. O rig Character contém `CA/Reading/Reading_Aloud_Hand_Motions`.

Essas alternativas são candidatas sustentadas pelos arquivos, sem alteração dos dados originais nem conclusão de defeito em runtime. Os campos e fontes completos estão em `followups`.

## Reprodução e continuidade

Executar a preparação canônica de T035 e, então:

```sh
python3 tools/recon_save_static.py --scope contextual
python3 tools/recon_string_literals.py out/recon/tasks/T035/contextual-asm/GetAnimationSuffix_*.asm.txt --output out/recon/tasks/T035/contextual-suffix-literals.json
tools/venv/bin/python tools/recon_contextual_links.py
```

O relatório completo fica em `out/recon/tasks/T035/contextual-links.json`; o cache em `contextual-metadata-cache.json`; as 33 janelas ARM64 em `contextual-asm/`. O estado canônico de T035 permanece parcial, com dependências pendentes. O próximo recorte é recuperar o ciclo de adicionar/remover/cancelar/concluir dos handlers básicos e reconciliar os dois assets de reação e os carregamentos indiretos. A validação no aparelho continua adiada conforme combinado.

## Ciclo adicionar/remover/cancelar/concluir (2026-11-08)

O orquestrador é `PWC.Level.ContextualAnimation.CATargetExtensionMethods`, métodos de extensão sobre `ICATarget`. `AddCAHandler` (`0x23aca54`) só faz `target.CAHandlers.Add(handler)`; o orquestrador real é `AddCAHandlerAndUpdateGame` (`0x23ac654`).

**Adicionar**, ordem confirmada por desmontagem anotada (`tools/recon_disasm.py`, chamadas `bl` resolvidas por endereço) mais leitura manual das chamadas virtuais indiretas (`blr` em slots da vtable do próprio handler, não da tabela de interface, por isso sem nome automático — identificações marcadas como inferidas):
1. gate de compatibilidade (slot vtable +0x198, inferido `IsValidForTarget`);
2. `target.CAHandlers` + `List.Contains(handler)` — evita duplicata;
3. `AddCAHandler` (acrescenta à lista);
4. um segundo bool do handler (slot ~+0x338, não identificado com certeza);
5. `SetLockedCAHandler`/`OnAddedCAHandlerWithLockedAnimation`/`get_LockedCAHandler` (resolvidos por interface);
6. `SetAnimation` (interface);
7. `SetForceSitIfNeeded`;
8. slot vtable +0x1f8, inferido **`OnAddedToTarget(target)`** — chamado **por último**, depois que o estado de animação/lock do alvo já foi montado;
9. slot vtable +0x3a8 (bool, inferido um `TryForceToSit`-like), que em caso verdadeiro dispara uma corrotina cujo tipo gerado se chama literalmente `<MakeFishEatFood>d__16` — ou seja, há pelo menos um caso especial específico de handler embutido no orquestrador genérico.

**Remover** (`RemoveCAHandlerAndUpdateGame`, `0x23acdb0`): `target.CAHandlers` → `List.Remove(handler)` (aborta se não estava na lista) → slot vtable +0x208, inferido **`OnRemovedFromTarget(target)`**, chamado **imediatamente após a remoção**, antes de qualquer limpeza do lado do alvo → `get/set_LockedCAHandler`, `get_IsMoving` (×2), `ReturnToIdleAnimation`, `OnCARemoved` (todas por interface, resolvidas). A ordem é o inverso do adicionar: lá o hook do handler é o último passo; aqui é o primeiro depois da remoção da lista.

**Cancelar/Concluir**: `PlayContextualAnimation` registra três funções locais como delegates do Spine `TrackEntry` mais uma rotina de limpeza compartilhada:
- `g__EndAnimation|0`: zera `CurrentCAPlayType`/`CurrentCAConfig`/`CurrentCAHandler` do alvo (três setters de interface resolvidos) antes de um tail call.
- `g__OnInterruptOrEnd|1` (**cancelar**): lê `target.ContexualAnimationCounter` e compara com o contador capturado no closure quando a animação começou; se diferente, é um callback **obsoleto** (uma animação mais nova já começou) e a função retorna sem fazer nada — um guarda por contador de geração contra corridas entre pedidos de animação sobrepostos. Só chama `EndAnimation` se o contador ainda bate.
- `g__OnCompleteFullCycle|2` (**concluir, ciclo completo**): busca o handler atual do alvo duas vezes em sequência (padrão de cache de interface, checagem de nulo entre as duas) antes de um tail call para um slot da vtable do PRÓPRIO handler (+0x298), inferido **`OnAnimationFullCycleEnd(target, config)`** pelo nome e assinatura.
- `g__OnCompleteNotLooped|3` (**concluir, sem loop**): mesmo guarda de contador; dependendo do `CurrentCAPlayType`, chama `OnCompleteFullCycle` ou `EndAnimation`; pode **rechamar `PlayContextualAnimation`** (mecanismo de "repetir até outra coisa acontecer"); termina com `get_LockedCAHandler`/`ReturnToIdleAnimation`/`SetAnimation`/`SetForceSitIfNeeded` e um tail call ainda não identificado.

As identificações de slot de vtable do handler (+0x198, +0x1f8, +0x208, +0x298, +0x3a8, +0x338) são inferidas por posição/assinatura, não resolvidas por nome como as chamadas de interface; não foram confirmadas por uma segunda passada ou teste de mutação. Evidência completa em `out/recon/tasks/T035/ca-handler-lifecycle.json` e `out/recon/tasks/T035/lifecycle-asm/`.

### Reações — reconciliação proposta

As duas discrepâncias já registradas (`Bubble_Blower_Tube_L209_Baby_ReactionData`, `ToddlerBookReadingAnimationsReactionsData2`) têm o mesmo formato: o dado de reação grava o nome já com o prefixo `CA/` embutido como literal, mas o inventário do rig (construído a partir dos dados brutos do Spine) lista o nome **sem** esse prefixo. Como o prefixo `CA/` é adicionado em runtime por `CreateAnimationName` (já documentado acima), e essas duas entradas armazenam a string final diretamente, a comparação correta deveria remover um `CA/<pasta>/` inicial antes de comparar com o rig — exatamente a alternativa que a auditoria original já tinha encontrado presente no rig. Isso eleva essas alternativas de "candidatas" para "interpretação mais sustentada", mas o verificador (`tools/recon_contextual_links.py`) não foi alterado para aplicar essa regra.

### Carregamentos indiretos — checagem negativa

`PWC.PSDToLevel.LevelContextualAnimation.LevelCAItemHandlerWithData.GetData()` (a família `*WithData`, que detém a maior parte dos 974 assets `LevelCAItemHandlerData`) só devolve o campo `Data`, uma referência serializada direta — sem `Resources.Load` por nome nem busca por string. Isso descarta essa classe como fonte dos 85 assets órfãos, mas não identifica o mecanismo real; `LevelCAReactionsData` e as famílias `LevelCAParentHandlerBase`/`LevelCAItemOnBoneHandlerBase` ainda não foram checadas.

T035 continua parcial.

## Atualização L04 (2026-11-09): slots de vtable resolvidos por nome
Os slots que este documento inferia por posição foram resolvidos pelo metadata e provados por `tools/recon_ca_lifecycle.py`: +0x198 `IsValidForTarget`, +0x1f8 `OnAddedToTarget`, +0x208 `OnRemovedFromTarget`, +0x298 `OnAnimationFullCycleEnd`. Correções: +0x338 é `IsLockedToTarget` (não "bool não identificado") e +0x3a8 é `IsRelevantForTarget` (não "TryForceToSit-like"). Regra de nome, gatilhos e eventos em `docs/loops/results/L04.md`.
