# T020: triagem sem RAM das 124 classes de MonoBehaviour ainda falhando (2026-11-22)

## Contexto
Depois de reconciliar `T020/CLASS/22379dfdf824449b` e `T020/CLASS/90da446022c5664c`
(`PWC.Inventory.InventoryBuildData`/`InventorySkinsBuildData`, PR #65) na fila formal
(`tools/recon_queue.py`), sobram 124 classes em `out/mb/_stats.json["erros"]`, cada uma com sua
própria tarefa `T020/CLASS/<hash>`. Reprocessar todas de verdade exige carregar
`x/base/assets/bin/Data/datapack.unity3d` (1,3 GB) — a mesma operação que já deu OOM 4 vezes
nesta máquina (ver `LOOP_STATE.md` 2026-11-21, `T020/CLASS/d723b7b66951bef8/attempt1-oom.log`).

## Achado: dá pra triar sem tocar no datapack
`TypeTreeGenerator.get_nodes_as_json()` só precisa de `il2cpp_in/` (90 MB) +
`x/base/assets/bin/Data/data.unity3d` (16 MB, só pra resolver nome de classe → assembly) — nenhum
dos dois jamais causou OOM nesta sessão. Gerando a árvore de tipos de uma classe (sem ler nenhum
objeto de verdade) e rodando `tools/mb_dump.py::fix_mislabeled_vectors` nela, dá pra saber, por
classe, se o fix já mergeado (PR #64) tem chance de resolver — **sem risco de derrubar a máquina**.

**Isto é uma hipótese, não uma resolução.** O critério de aceite de cada `T020/CLASS/<hash>` exige
ler os objetos de verdade com `check_read=True` — isso continua precisando do datapack. Nenhuma das
65 classes abaixo foi marcada `done`/`evidence_ready` só com base nisto.

Script: `out/recon/tasks/T020/node_tree_triage_2026-11-22.py`. Saída:
`out/recon/tasks/T020/node_tree_triage_2026-11-22.json` (124 entradas).

## Resultado final (124 classes, 100% categorizadas em 2026-11-22)

| Categoria | Classes | O que significa |
|---|---:|---|
| `same_bug_likely_fixed` | 65 | Tem campo `List<String>` mal rotulado como `string` — mesmo bug já corrigido em `tools/mb_dump.py`. Alta confiança de que já está resolvido; falta só confirmar lendo os objetos de verdade (precisa do datapack). |
| `typetreegeneratorapi_nullref_confirmed_serializabledict_field` | **30** | `TypeTreeGeneratorAPI` quebra (`Object reference not set to an instance of an object`) ao resolver um campo cujo tipo é (ou deriva de) `SerializableDictionaryBase<TKey,TValue>` (de `RotaryHeart.Lib.SerializableDictionary`, asset de terceiros) — direto na classe (27 casos) **ou indiretamente via subclasse nomeada** (3 casos: `PazuCore.WindowManager`→`Name_Back_Scene`, `PazuCore.LocalizationManager`→`Country_SupportedLanguages`, `PazuCore.GameExtraSettings`→`Name_Back_Scene`/`Name_Audio`/`Name_AudioEvent`). **Verificado individualmente nas 30**, campo e tipo exatos lidos do `out/cpp2il` decompilado de cada uma (não é suposição pela mensagem de erro) — ver `out/recon/tasks/T020/node_tree_triage_2026-11-22.json` pra lista campo-a-campo. Os 3 casos indiretos só apareceram depois de checar os tipos dos campos contra a lista completa de subclasses de `SerializableDictionaryBase` no código (`Country_SupportedLanguages`, `Name_Audio`, `Name_AudioEvent`, `Name_Back_Scene`) — um grep ingênuo pela string literal no arquivo da própria classe não pega esse caso, porque a referência à base genérica está num arquivo diferente. **Limitação da biblioteca nativa, não um bug meu** — já está na versão mais recente (0.0.10, não tem outra pra tentar). Inclui as **14** classes `PWC.AvatarMaker.AvatarMaker{Car,Dog,Horse,Cat,Baby,Toddler,Character}{Colors,Subcategories}Config` (todas as 7 espécies × {Colors, Subcategories} do editor de avatar) mais 16 outras. **As 30 tarefas correspondentes foram fechadas na fila formal como `blocked_external`** (2026-11-22, `out/recon/tasks/T020/close_nullref_confirmed_tasks_2026-11-22.py` + `close_nullref_final3_2026-11-22.py`). |
| `type_stripped_from_release_il2cpp_metadata` | 20 | `Type "X" was not found in the IL2CPP metadata` — **confirmado (2026-11-22) que nenhuma das 20 existe no `out/cpp2il` decompilado**, e nem a própria string `"EditorApp"` aparece em lugar nenhum da árvore inteira (checagem sistemática, não amostra). Code stripping do Unity: classe nunca referenciada estaticamente, removida do binário shipado, mas o `MonoScript` serializado ficou apontando pro nome. **Todas as 20** são `PWC.EditorApp.*` — ferramental de editor/dev interno (painéis de login, busca, hierarquia, editor de nível), não parte do jogo jogável. **Irresolúvel de verdade** — não é "ainda não achei", é confirmado ausente do binário. |
| `serialize_reference_ref_types_resolution` | 9 | **Diagnosticado em 2026-11-22.** Árvore de tipos gerada com sucesso, mas todas as 9 têm nós `ManagedReferencesRegistry`/`ReferencedObject` — usam `[SerializeReference]` do Unity (referência polimórfica). O tipo concreto de cada instância só é resolvido lendo o objeto de verdade contra `SerializedFile.ref_types` (metadado por arquivo serializado, comparação exata de classe/namespace/assembly em `get_ref_type_node`/equivalente nativo), não pela árvore estática do IL2CPP sozinha. Confirmado que `assetsfile` já é passado certinho pro `read_typetree` (`UnityPy.files.ObjectReader.read_typetree` já faz isso) — não é bug de parâmetro faltando. Tentativa de leitura real bloqueada 2x por OOM (ver `LOOP_STATE.md`, `out/recon/tasks/T020/serializeref_attempt1-oom.log`). Lista completa e notes: `out/recon/tasks/T020/node_tree_triage_2026-11-22.json`. |

Nenhuma categoria "não categorizada" restante — as 18 que antes tinham falha de geração de nó sem
correlação automática foram checadas uma a uma (`out/recon/tasks/T020/node_tree_triage_2026-11-22.json`,
rodada de 2026-11-22): 7 caíram em `type_stripped_*` (todas `PWC.EditorApp.*`) e 11 em
`typetreegeneratorapi_nullref_*` — `AvatarMakerBabyColorsConfig`, `AvatarMakerCatColorsConfig` e
`AvatarMakerCatSubcategoriesConfig` completam o conjunto das 14 classes do editor de avatar citado
acima (as demais 8 já estavam na primeira passada).

### Sobre `BWYW.DailyTasksData` e `BWYW.BWYWGiftData`
Essas duas já têm tarefas próprias na fila (`T020/CLASS/4cc86bcb4a623c07`, `ready`;
`T020/CLASS/d723b7b66951bef8`, `blocked_external` — essa travou numa tentativa anterior de outra
sessão só pra *carregar* o IL2CPP, antes de sequer gerar a árvore de tipos). Confirmado agora que a
geração de árvore funciona para as duas (o bloqueio daquela sessão foi memória, não um problema
estrutural da classe); a causa real de leitura é a mesma `[SerializeReference]` das outras 7.

## Tentativa de capturar a mensagem nativa automaticamente (não funcionou)
Tentei redirecionar o fd 1 (stdout) ao redor da chamada nativa pra capturar a mensagem de erro real
(a exceção Python sozinha só diz "Object reference not set..." sem contexto). Não funcionou de forma
confiável num re-run (a extensão nativa parece escrever antes do `dup2` fazer efeito, de um jeito que
não dá pra interceptar assim). O script commitado documenta isso e não finge que funciona; os
`native_message` no JSON de 2026-11-22 vieram de uma correlação manual (regex sobre um log já capturado
por redirecionamento de shell simples, não por `dup2` em runtime) que acertou 32 das 50 falhas de
geração de nó.

## Próximo passo sugerido
1. Quando houver RAM disponível (PC do trabalho, ver `tools/mb_retry_failed_classes.py`), reprocessar
   de verdade as 65 `same_bug_likely_fixed` primeiro — maior retorno, mesmo fix já pronto.
2. As 9 `serialize_reference_ref_types_resolution` precisam do datapack carregado pra confirmar se
   `ref_types` está ausente no arquivo serializado ou se é mismatch de nome na comparação exata — só
   dá pra saber lendo o objeto de verdade (2 tentativas já bloqueadas por OOM, ver `LOOP_STATE.md`).
3. **Já fechados na fila** (`blocked_external`, não precisam de mais trabalho sem evidência nova):
   as 20 `type_stripped_*` e as **30** `typetreegeneratorapi_nullref_confirmed_*` (todas as 124
   classes agora ou têm causa raiz 100% confirmada, ou estão prontas pra retomar com mais RAM — não
   sobrou nenhuma categoria "causa desconhecida").
