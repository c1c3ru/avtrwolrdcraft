# T025 — auditoria de conclusão e recuperação dos pilotos

**T025 continua aberta.** Esta rodada recuperou registros genéricos e offsets originais, atualizou dois dossiês e corrigiu uma afirmação de completude sem suporte. O fechamento do pacote exige mais que os cinco pilotos de navegação.

## Escopo reconciliado

O índice existente de `Assembly-CSharp.dll` contém 36.421 MethodDefs: 35.831 têm ponteiro não nulo, todos distintos nesse índice; 590 têm ponteiro nulo. A fila possui cinco filhos T025, sem filhos concluídos. Os outros 36.416 registros ainda precisam de filhos ou de uma disposição de escopo explicitamente revisada. Ponteiro nulo não significa automaticamente método abstrato ou irrelevante.

Esse universo é uma base estrutural: não inclui todas as instanciações genéricas ou funções nativas sem metadata. Não representa percentual de lógica recuperada. As dependências do pai T025 — T022, T023 e T024 — permanecem pendentes.

A ferramenta [recon_t025_readiness.py](../tools/recon_t025_readiness.py) publica uma geração imutável do registro de métodos e [t025_readiness.json](../reports/recon/t025_readiness.json), com os hashes do índice/fila e bloqueios de aceite. Não modifica a fila nem aprova métodos. Captura e valida snapshots sob lock compartilhado; o relatório atômico aponta a geração por hash.

## Novas evidências STATIC

| Questão | Resultado sustentado |
| --- | --- |
| Registros IL2CPP | CodeRegistration `0x3f9a2d0` e MetadataRegistration `0x40d10c0`, corroborados pelo loader de argumentos `0x198c8d0` e armazenamento posterior. |
| HashSet de `IsSceneAvailable` | MethodRefs → MethodSpecs → MethodDefs identificam `.ctor`, `Add` e `Contains` solicitados para `HashSet<string>`. |
| Generic sharing | Os alvos dos calls correspondem a ponteiros de entradas canônicas `HashSet<object>` dos mesmos MethodDefs. Não implica execução observada nem prova dos corpos. |
| `MPOwnership.Clear` | Duas chamadas a `Dictionary<GameObject,int>.Clear` e uma a `Dictionary<GameObject,object>.Clear` vinculadas aos MethodSpecs e ponteiros canônicos. |
| Campo multiplayer | `<IsMultiplayerGame>k__BackingField`, token `0x04003fe9`, Boolean estático, offset **0**, confirmado por metadata e `fieldOffsets`. |
| Cache de cenas | `_availableSceneNames`, token `0x04003ba7`, offset estático **0x48**, confirmado pela mesma cadeia. |

Os nomes das 96 imagens e os limites das 75.923 linhas da tabela de funções genéricas foram conferidos. Essas verificações não equivalem a recuperar os corpos dessas funções. O produtor é específico do par v31/AArch64 conhecido.

Produtor: [recon_t025_generics.py](../tools/recon_t025_generics.py). Evidência: [t025_generic_bindings_investigation.json](../reports/recon/t025_generic_bindings_investigation.json). Revisão independente: [t025_generics_review.json](../reports/recon/t025_generics_review.json).

## Dossiês T025 atualizados

### `LoadSceneImplement` — filho `e579655ba8e57adf`

Produtor: [recon_t025_implement.py](../tools/recon_t025_implement.py).

A janela `0x2072cc8..0x2072d84` contém 47 instruções alcançáveis no CFG local sob retorno normal das chamadas. As guardas, o campo multiplayer, os tipos envolvidos, os overloads e a passagem da string são verificados nos bytes/metadata. O fluxo local chama `MPOwnership.Clear()` quando o byte multiplayer é diferente de zero e termina por tailcall a `SceneManager.LoadSceneAsync(string)` com a string original.

A assinatura do wrapper é `void`; o wrapper restaura LR/SP e não consome o retorno nativo do método Unity. Isso não converte sua assinatura managed em `AsyncOperation`.

O dossiê inclui ABI, memória, offsets, registradores, efeitos locais, chamadas, CFG e dependências abertas. A identidade dos `Dictionary.Clear` foi resolvida; seus corpos e exceções continuam fora do aceite. Existem chamadas adicionais de inicialização e efeitos posteriores do engine que não foram certificados.

### `GetCurrentWorldSceneName` — filho `d417091ede9f01e0`

Produtor: [recon_t025_getter.py](../tools/recon_t025_getter.py).

A janela `0x2073238..0x207330c` tem 53 instruções alcançáveis no CFG local e um RET em `0x2073308`. Verificados o literal `GAME_CURRENT_WORLD`, enum World=1, overloads e seleção do retorno. O anexo de genéricos agora resolve a identidade solicitada de `.ctor/Add/Contains` da dependência `IsSceneAvailable`.

**Errata:** o resultado anterior declarava `method_body_fully_bounded=true` apesar de o CFG limitar a análise ao próximo início metadata. O novo resultado usa `false`: cobertura local e RET não provam todas as regiões de corpo/exceção. A correção está no produtor para não depender de edição manual do JSON.

Os contratos/CFGs/resultados ficam em `out/recon/tasks/T025/METHOD/<id>/`; suas referências e hashes foram registrados por checkpoint na fila, sem aprovação semântica.

## Verificação e limites

A suíte focada `test_recon_t025_*.py` passou **25 testes**, sem falhas, em **10,588 s**. Inclui mutações de MethodSpec, instanciação, ponteiro, metadata token, offset de campo, alvo de chamada, condição multiplayer, preservação do argumento e seleção do retorno; também impede a promoção de contagens/estados a certificação semântica. As revisões independentes usam relatórios próprios, com fontes e hashes.

O REA abriu a identidade do ELF, mas `analyze_function` expirou após 120 s esperando a bridge do Hopper. Não retornou pseudocódigo ou CFG de decompilador. A sessão foi fechada. Ghidra consta não configurado. Recibo: [t025_provider_attempt.json](../reports/recon/t025_provider_attempt.json). LLVM e os parsers locais forneceram as evidências estáticas desta rodada; não são REA Evidence de decompilação.

Sem execução Android, build Unity, alteração do cliente ou observação de efeitos em runtime.

## O que impede concluir T025

1. Reconciliar o universo de funções obrigatórias e seus filhos, incluindo ponteiros nulos, código compartilhado e entradas fora desse índice.
2. Fechar T022–T024 com aceites correspondentes; os filhos piloto aceitos não encerram esses pais.
3. Recuperar/justificar regiões completas de corpo, CFG e efeitos, com memória, ABI, callbacks, erros e término para cada método obrigatório.
4. Fechar os desconhecidos relevantes dos pilotos: helpers/init, corpos canônicos necessários, exceções e contratos externos Unity.
5. Obter referência independente adequada e revisar cada entrega antes de `done`.

O decompilador indisponível limita a recuperação ampla, mas não apaga o avanço estático. Nenhum critério foi reduzido para marcar o pai como concluído.

## Reprodução

```bash
python3 tools/recon_t025_generics.py
python3 tools/recon_t025_implement.py
python3 tools/recon_t025_getter.py
python3 -m unittest discover -s tools -p 'test_recon_t025_*.py' -v
python3 tools/recon_t025_readiness.py
```

Os produtores de dossiê devem ser executados sob o lease do respectivo filho quando publicarem nos caminhos oficiais. Para revisão isolada, passar `--output` apontando uma pasta temporária. O auditor de escopo é somente leitura sobre a fila.

## Atualização de 2026-11-08 — dispatch e candidatos Stage

O checkpoint parcial de `LoadScene` foi retomado após a lease expirar. A varredura limitada de instruções `B/BL` encontrou nove candidatos adicionais para os accessors de eventos Stage. O follow-up [followup_stage_candidates.py](../out/recon/tasks/T025/METHOD/8e708ca7d06e0b52/followup_stage_candidates.py) resolveu, para cada um, o MethodDef usado na construção `Action`, o accessor add exato, o receptor/compatibilidade de tipo e o fluxo do delegate até o argumento do accessor. Somados aos quatro edges Stage anteriores, **13/13 candidatos diretos deste scan** são agora edges estáticos positivos. Isso não cobre chamadas indiretas, reflection, código carregado dinamicamente ou todos os assinantes.

No próprio `LoadScene`, [stage_dispatch_review.json](../out/recon/tasks/T025/METHOD/8e708ca7d06e0b52/stage_dispatch_review.json) registra três chamadas indiretas sequenciais com guarda nula, os registradores carregados e os sites de `BLR`. Os offsets de campo `0/8/0x10` coincidem com os três campos Stage do layout metadata/C++2IL e com os slots lidos. **Há uma ressalva ainda aberta:** o TypeInfo lido na janela aponta ao `<>c__DisplayClass28_0`; a relação desse TypeInfo com a base usada para os três valores estáticos não foi fechada. Assim, a associação exata desses três slots aos nomes Stage continua condicional, e os alvos reais dependem dos delegates em runtime.

Testes focados nesta retomada: **7** para expansão/dispatch Stage, **5** para os pares de remoção e **25** para os produtores/auditor T025; todos passaram. O filho `T025/METHOD/8e708ca7d06e0b52` permanece `ready`, com `semantic_completion=false`. Extents completos e não contíguos, exceções, efeitos dos handlers, resolução do TypeInfo, contratos Unity e revisão independente continuam pendentes; nem o filho nem o pai foram marcados `done`.
