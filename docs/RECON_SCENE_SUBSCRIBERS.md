# Assinantes de eventos de troca de cena — evidência estática de 2026-11-07

Foram identificadas **cinco ligações positivas entre registro e handler** nos bytes do par IL2CPP já conhecido. Quatro ligam componentes aos estágios de `GameSceneManager`; a quinta confirma que seu construtor estático registra `OnActiveSceneChanged` no evento Unity `SceneManager.activeSceneChanged`.

O trabalho complementa [o contrato de LoadScene](RECON_LOAD_SCENE_CONTRACT.md) e [o probe anterior do callback](RECON_CALLBACK_2026-11-03.md). O callback de 03/11 não foi refeito. Esta rodada não executou o jogo, não usou o alvo REA ativo, não alterou cliente/fila e não promoveu tarefa a concluída.

## Cinco ligações verificadas

| Registrador | Evento | Handler e token | Instrução que registra |
| --- | --- | --- | --- |
| `BackgroundPlanetSoundHandler.Awake`, token `0x060055ff` | Stage1 | `BackgroundPlanetSoundHandler.OnBeforeSceneLoadStage1`, `0x06005601`, VA `0x2069448` | `0x2069294`: `BL 0x20692dc`, bytes `12000094` |
| `PersistentDataManager.Awake`, token `0x06006e3e` | Stage2 | `PersistentDataManager.OnBeforeSceneLoadStage2`, `0x06006e44`, VA `0x21e09b0` | `0x21e0734`: `B 0x2071fec`, bytes `2e46fa17` |
| `LevelManager.Awake`, token `0x0600848e` | Stage2 | `LevelManager.OnBeforeSceneLoadStage2`, `0x0600849c`, VA `0x2313e64` | `0x2310d64`: `BL 0x2071fec`, bytes `a284f597` |
| `LevelManager.Awake`, token `0x0600848e` | Stage3 | `LevelManager.OnBeforeSceneLoadStage3`, `0x0600849d`, VA `0x2313e70` | `0x2310d8c`: `BL 0x20721a4`, bytes `0685f597` |
| `GameSceneManager..cctor`, token `0x060056fa` | Unity `activeSceneChanged` | `GameSceneManager.OnActiveSceneChanged`, `0x060056fc`, VA `0x2072644` | `0x2072568`: `B 0x3cdc02c`, bytes `b1a67114` |

Os destinos dos registros foram conferidos contra metadata e tabela codegen:

- Stage1 add: `GameSceneManager.add_OnBeforeSceneLoadStage1Action`, token `0x060056f0`, VA `0x20692dc`.
- Stage2 add: token `0x060056f2`, VA `0x2071fec`.
- Stage3 add: token `0x060056f4`, VA `0x20721a4`.
- Unity add: `UnityEngine.SceneManagement.SceneManager.add_activeSceneChanged`, imagem `UnityEngine.CoreModule.dll`, token `0x060009c6`, VA `0x3cdc02c`.

## Como o handler foi identificado

Não foi usada somente a proximidade de um nome de método. O verificador reconfirma owner, token, aridade, imagem, definição metadata e ponteiro codegen. Em seguida decodifica ADRP/LDR, GOT e o uso codificado MethodDef; confere o índice exato do handler; verifica os opcodes que carregam esse MethodInfo em `x2`, passam `this` ou nulo em `x1`, preservam o objeto construído e o enviam ao add correto.

| Slot GOT | Usage VA | Palavra codificada | Handler identificado |
| --- | --- | --- | --- |
| `0x41c8240` | `0x4319618` | `0x6000ac01` | BackgroundPlanetSoundHandler Stage1, MethodDef 22016 |
| `0x41d2938` | `0x4328c88` | `0x6000dc87` | PersistentDataManager Stage2, MethodDef 28227 |
| `0x41d9aa8` | `0x4325128` | `0x60010937` | LevelManager Stage2, MethodDef 33947 |
| `0x41d9ab0` | `0x4325130` | `0x60010939` | LevelManager Stage3, MethodDef 33948 |
| `0x41c85a8` | `0x4320ce8` | `0x6000adf7` | GameSceneManager OnActiveSceneChanged, MethodDef 22267 |

Os quatro registros de estágio constroem `System.Action` pelo VA `0x32cd13c`, confirmado como `.ctor`, token `0x06000379`, imagem `mscorlib.dll`. O registro Unity usa o helper `0x305a558`; sua identidade metadata genérica não foi recuperada. Seu fluxo de argumentos e o destino final do add estão guardados, mas não se afirma um contrato completo desse helper.

**Resultado permitido:** sob execução normal que alcance esses pontos, o delegate construído com o MethodDef indicado é passado ao add identificado. **Ainda não observado:** inscrição efetiva no aparelho, posterior execução do handler, efeitos internos, duração da inscrição ou desinscrição.

## Busca delimitada e o que continua aberto

Um scan dos encodings `B`/`BL` nos segmentos LOAD executáveis encontrou **13 candidatos diretos** para os três adds de estágio: oito Stage1, três Stage2 e dois Stage3. A atribuição inicial de caller usa o início metadata anterior e permanece apenas candidata até conferir o fluxo. Quatro desses 13 locais tiveram o encadeamento registro→handler validado nesta rodada; os nove demais são pistas sem expansão aqui. A quinta ligação positiva, `activeSceneChanged`, veio da inspeção dirigida do `.cctor`, fora desse conjunto de três adds.

Essa busca não enumera chamadas indiretas, delegates criados em outro lugar, reflexão, carregamento dinâmico ou todos os assinantes. Não autoriza concluir ausência de outros registros. A ordem Stage1→Stage2→Stage3 já apontada no contrato do emissor não estabelece a ordem de execução entre múltiplas instâncias/assinantes de um mesmo evento.

Não foi feita análise nova dos `OnDestroy` para provar os pares remove. A existência desses métodos ou de accessors `remove_*` não demonstra que estes cinco handlers sejam removidos corretamente. Desinscrição e lifetime permanecem desconhecidos neste lote.

Quatro janelas foram inspecionadas: três Awakes e o `.cctor`. Seus limites no próximo início metadata e hashes estão no relatório; isso não prova corpo inteiro, CFG completo, regiões não contíguas ou exceções. Os efeitos dos próprios handlers também ficam fora do recorte.

## Proveniência e reprodução

- Native SHA-256: `b63661fa60c23ebef1c2da4bb5288ad787eb3da36b22d4bdf285401f1643d728`.
- Metadata SHA-256: `1ea14cf5829d5c31e5e967b1608b5701020ab0d24bd4ab69d9f1e2b243467bc6`.
- Índice reutilizado: `out/recon/il2cpp/metadata_methods.jsonl`, hash registrado na saída.
- Produtor guardado: [recon_scene_subscribers.py](../tools/recon_scene_subscribers.py).
- Relatório: [scene_subscribers.json](../reports/recon/scene_subscribers.json).
- Assembly e comandos LLVM: `out/recon/scene-subscribers/*.asm.txt`, quatro arquivos gerados pelo produtor; o relatório registra comandos, retorno, duração e hash de cada saída.

```bash
python3 -m unittest discover -s tools -p test_recon_scene_subscribers.py -v
python3 tools/recon_scene_subscribers.py
```

LLVM objdump já existente no NDK do Unity foi utilizado, com janelas explícitas por VA. Nenhum provider REA foi aberto ou alterado. A tentativa inicial de reutilizar `recon_callers.py` encontrou NumPy ausente; o scan final usa somente biblioteca padrão e o parser ELF existente, sem instalar dependências.

**Nove testes passaram**, sem skipped, em 9,798 segundos. Os testes mutam apenas cópias em memória/índice temporário: alvo BL de registro, tail branch Unity, destino do construtor, MethodDef usage do handler, token metadata, registrador de argumento e cache com nome/token aparentando coincidência mas definição incorreta. As guardas de metadata prevalecem sobre o cache. O hash integral do par também rejeita bytes alterados; as mutações locais são testadas sem depender somente desse gate externo.

A entrega reduz os desconhecidos de origem dos callbacks. Próximos recortes possíveis: revisar estes cinco encadeamentos independentemente, rastrear efeitos dos handlers e verificar pares de remoção por evidência direta. Nenhum deles deve ser presumido a partir desta tabela de registros.

## Continuação: chamadas de remoção

A rodada seguinte confirmou quatro pares estáticos `Awake` → `OnDestroy`, com o mesmo alvo `this` e MethodDef, para os quatro registros de estágio. Detalhes e limites em [RECON_SCENE_LIFETIME_2026-11-07.md](RECON_SCENE_LIFETIME_2026-11-07.md). As afirmações anteriores sobre remoção desconhecida descrevem o limite da primeira rodada; execução Unity, remoção efetiva e lifetime do registro estático Unity seguem abertos.

## Continuação: os nove candidatos Stage restantes

Em 2026-11-08, o follow-up filho [T025](../out/recon/tasks/T025/METHOD/8e708ca7d06e0b52/stage_candidate_analysis.json) expandiu os nove candidatos diretos restantes: cada edge liga chamada ao accessor `add_OnBeforeSceneLoadStageNAction`, MethodDef do delegate passado ao construtor `Action` e fluxo do objeto/resultado até o argumento do accessor. Com os quatro edges Stage anteriores, os **13 candidatos B/BL** desta busca limitada têm edges positivos estáticos. Os nove novos sites cobrem `LevelDigHoleArea`, `LevelSpawnOnLevelPostInit`, `LevelSlideSwitcherHandler`, `LevelLockerSpawnOnPostInit`, `AvatarSpeechUIMenu`, `LevelKillArea`, `LevelScreenshotManager`, `LevelNewAvatarManager` e `LevelMakerSwitcher`.

O mesmo follow-up associa provisoriamente os três dispatches em `LoadScene` aos campos Stage1/2/3 pelos offsets `0`, `8` e `0x10`; os bytes mostram guardas nulas, sequência e chamada indireta em `BLR x9`. A checagem [stage_dispatch_review.json](../out/recon/tasks/T025/METHOD/8e708ca7d06e0b52/stage_dispatch_review.json) registra que o TypeInfo observado aponta ao tipo nested `<>c__DisplayClass28_0`, então a identidade da base estática precisa de reconciliação antes de tratar o vínculo como incondicional.

Os 13 são apenas os candidatos diretos `B/BL` encontrados no scan: não provam grafo global completo, execução, ordem de invocation lists, lifetime ou efeitos dos callbacks. Indiretos, reflection, carregamento dinâmico, exceções e corpos completos seguem abertos. Os testes de expansão (3), dispatch (4) e remoção (5) passaram nesta retomada.
