# Remoção dos assinantes de cena — 2026-11-07

Continuação da investigação de [assinantes](RECON_SCENE_SUBSCRIBERS.md). O recorte confirma quatro chamadas estáticas de remoção nos três `OnDestroy` correspondentes. Não demonstra execução de `OnDestroy` no aparelho nem remoção efetiva da lista de delegates.

## Perguntas e resultado

| Pergunta | Estado | Evidência |
| --- | --- | --- |
| Os quatro registros de estágio possuem chamadas de remove com o mesmo handler e `this`? | Respondida estaticamente, sob alcance normal dos pontos guardados | Quatro encadeamentos abaixo; inscrições revalidadas no mesmo par de bytes |
| O remove realmente elimina o delegate em runtime? | Aberta | Internos dos accessors, igualdade de delegates, exceções e execução Unity fora deste recorte |
| Qual o lifetime da inscrição estática Unity `activeSceneChanged`? | Aberta | Não investigada nesta rodada; não há afirmação de ausência de remove |
| Foram resolvidos os nove candidatos de inscrição restantes? | Aberta | Nenhuma expansão desse conjunto nesta rodada |

## Encadeamentos STATIC

| OnDestroy / token / VA | Handler revalidado | Chamada remove | Destino |
| --- | --- | --- | --- |
| `BackgroundPlanetSoundHandler`, `0x06005602`, `0x20694d4` | Stage1, `0x06005601` | `BL` em `0x206959c` | `remove_OnBeforeSceneLoadStage1Action`, `0x060056f1`, `0x2069640` |
| `PersistentDataManager`, `0x06006e3f`, `0x21e0738` | Stage2, `0x06006e44` | `BL` em `0x21e0828` | `remove_OnBeforeSceneLoadStage2Action`, `0x060056f3`, `0x20720c8` |
| `LevelManager`, `0x06008490`, `0x2310ee4` | Stage2, `0x0600849c` | `BL` em `0x2311204` | `remove_OnBeforeSceneLoadStage2Action`, `0x060056f3`, `0x20720c8` |
| Mesmo `LevelManager.OnDestroy` | Stage3, `0x0600849d` | `BL` em `0x231122c` | `remove_OnBeforeSceneLoadStage3Action`, `0x060056f5`, `0x2072280` |

Em cada caso, a entrada `this` é preservada em `x19` e passada como alvo ao construtor `System.Action..ctor` (`0x32cd13c`). O MethodInfo carregado em `x2` resolve, via GOT e MethodDef usage, ao mesmo handler da inscrição. O delegate construído é preservado em `x20` e passado em `x0` ao accessor remove correto. Não se afirma que seja a mesma alocação de delegate: o destrutor constrói outro delegate com o mesmo alvo e método.

Os slots GOT conferidos são `0x41c8240`, `0x41d2938`, `0x41d9aa8` e `0x41d9ab0`; os índices MethodDef são respectivamente 22016, 28227, 33947 e 33948. Owner, token, aridade, imagem e ponteiro codegen são reconfirmados nos metadados originais, sem confiar apenas nos nomes do índice em cache.

## Limites e implicação para reconstrução

**INFERRED:** há uma intenção de parear as inscrições de `Awake` com limpeza em `OnDestroy`. Uma reconstrução poderá usar esse pareamento quando implementar o lifetime desses componentes. Este recorte não certifica ausência de vazamentos, duplicidade ou callbacks posteriores à destruição.

**UNKNOWN:** alcance real, exceções dos helpers, ordem entre instâncias, corpos dos handlers, semântica integral dos accessors e igualdade de delegates. As janelas terminam no próximo início metadata; isso não prova CFG completo nem corpos não contíguos. Os caminhos adicionais de limpeza existentes nesses destrutores não foram reconstruídos aqui.

A consulta REA confirmou sessão sem alvo aberto. Reutilizados o parser ELF/metadata e LLVM locais já empregados no lote anterior; não foi aberto provider, executado o original, alterado o cliente ou promovida tarefa na fila.

## Proveniência e reprodução

- Native SHA-256: `b63661fa60c23ebef1c2da4bb5288ad787eb3da36b22d4bdf285401f1643d728`.
- Metadata SHA-256: `1ea14cf5829d5c31e5e967b1608b5701020ab0d24bd4ab69d9f1e2b243467bc6`.
- Produtor: [recon_scene_unsubscribers.py](../tools/recon_scene_unsubscribers.py).
- Relatório completo com bytes, offsets, hashes, comandos LLVM, durações e códigos de retorno: [scene_unsubscribers.json](../reports/recon/scene_unsubscribers.json).
- Assembly local: `out/recon/scene-unsubscribers/PWC.*.OnDestroy.asm.txt`.
- Testes: [test_recon_scene_unsubscribers.py](../tools/test_recon_scene_unsubscribers.py). Mutações alteram destinos remove, alvo `this`, referência GOT do handler e construtor; a validação ocorre sem depender apenas do hash integral externo.

```bash
python3 tools/recon_scene_unsubscribers.py
python3 -m unittest discover -s tools -p test_recon_scene_unsubscribers.py -v
```

Verificação desta rodada: **5 testes passaram**, zero falhas, em 16,317 s. O produtor terminou com código zero e confirmou quatro pares em três janelas.

Próximo recorte: recuperar os efeitos dos handlers Stage1/2/3 e os internos de remove/igualdade de delegates antes de afirmar a semântica completa da limpeza. O projeto geral continua aberto.
