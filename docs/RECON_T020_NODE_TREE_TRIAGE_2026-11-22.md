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

## Resultado (124 classes)

| Categoria | Classes | O que significa |
|---|---:|---|
| `same_bug_likely_fixed` | 65 | Tem campo `List<String>` mal rotulado como `string` — mesmo bug já corrigido em `tools/mb_dump.py`. Alta confiança de que já está resolvido; falta só confirmar lendo os objetos de verdade (precisa do datapack). |
| `typetreegeneratorapi_nullref_on_raw_generic_type_field` | 19 (pelo menos; ver nota abaixo) | `TypeTreeGeneratorAPI` quebra (`Object reference not set to an instance of an object`) ao resolver um campo declarado como instanciação genérica crua (ex.: `SerializableDictionaryBase<CarCategoryType, AWSpineColorsList>` direto, sem subclasse nomeada — confirmado lendo `AvatarMakerCarColorsConfig.cs`/`AvatarMakerDogColorsConfig.cs` decompilados). **Limitação da biblioteca nativa, não um bug meu** — já está na versão mais recente (0.0.10, não tem outra pra tentar). Afeta sobretudo as classes `PWC.AvatarMaker.AvatarMaker*ColorsConfig`/`*SubcategoriesConfig` (12 das 19), relevantes pro trabalho paralelo do editor de avatar. |
| `type_stripped_from_release_il2cpp_metadata` | 13 (pelo menos) | `Type "X" was not found in the IL2CPP metadata` — classe não existe nem no `out/cpp2il` decompilado (conferido em 2 exemplos: `EALoginPanel`, `EACAMenuInfo`). Provável code stripping do Unity (classe nunca referenciada estaticamente, removida do binário, mas o `MonoScript` serializado ficou). Maioria é `PWC.EditorApp.*` — ferramental de editor/dev, não parte do jogo jogável. Provavelmente **irresolúvel de verdade**, não só "ainda não achei". |
| `node_generation_failed_uncategorized_by_regex` | 18 | Mesma falha de geração de nó das duas categorias acima, mas a correlação automática (regex sobre stdout capturado numa rodada manual) não bateu o nome da classe com a mensagem nativa certa. Provavelmente se dividem entre as duas categorias acima; não investigado individualmente por falta de tempo/valor nesta sessão. |
| `different_root_cause_node_gen_succeeded` | 9 | Árvore de tipos gerada com sucesso, mas **nenhum** campo `List<String>` mal rotulado encontrado — bug diferente, ainda não diagnosticado. |

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
2. As 19+ `typetreegeneratorapi_nullref_*` precisam de outra ferramenta de extração (esta biblioteca
   não dá conta) — ou aceitar como `blocked_external`, igual já está registrado pra
   `T020/CLASS/d723b7b66951bef8` (BWYWGiftData).
3. As 13+ `type_stripped_*` são candidatas fortes a fechar como "não resolvível, tipo removido do
   binário shipado" — não vale reabrir sem nova evidência.
4. As 9 `different_root_cause` + 18 não categorizadas precisam de investigação individual (rodar cada
   uma isolada, ler o stdout direto no terminal).
