# T029 — contrato estático de navegação, rodada de 2026-11-02

Esta rodada estende o [bootstrap IL2CPP](RECON_IL2CPP_BOOTSTRAP.md), reaproveitando os binários e índices existentes. Não houve extração completa, instalação de ferramentas, rede, alteração do cliente, execução do original, emulação ou uso de um alvo REA compartilhado. O resultado é um conjunto de **contratos estáticos candidatos**, não equivalência certificada.

## Artefatos e reprodução

```bash
python3 tools/recon_navigation.py
python3 -m unittest discover -s tools -p test_recon_navigation.py -v
```

Entradas obrigatórias:

- `out/recon/il2cpp/libil2cpp.so`, SHA-256 `b63661fa60c23ebef1c2da4bb5288ad787eb3da36b22d4bdf285401f1643d728`.
- `out/recon/il2cpp/global-metadata.dat`, SHA-256 `1ea14cf5829d5c31e5e967b1608b5701020ab0d24bd4ab69d9f1e2b243467bc6`.
- `out/recon/il2cpp/metadata_methods.jsonl`, usado como acelerador de lookup, com hash registrado. As atribuições de símbolos efetivamente usadas são reconferidas contra os registros metadata, imagem, token e ponteiro do módulo codegen atual; índice antigo não é aceito como autoridade sozinho.

Saídas novas:

- `reports/recon/navigation_contract.json`: identidade, contratos, janelas, verificações, pseudocódigo candidato e desconhecidos.
- `out/recon/navigation/getter_guard.json`: operandos do getter, literal e enum recuperados dos dados reais.
- Cinco `out/recon/navigation/*.asm.txt`: disassembly LLVM limitado por janela.

O parser pequeno reutiliza a interpretação v31/AArch64 validada pelo bootstrap. Só decodifica instruções/operandos e controles necessários ao recorte; não é um decompilador geral. As seções, relocations e VAs são estáticos; base de carregamento runtime permanece desconhecida.

## Evidência do getter GetCurrentWorldSceneName

Método `PWC.GameSceneManager.GetCurrentWorldSceneName`, token `0x06005708`, VA `0x2073238`, offset `0x206f238`. Janela candidata `0x2073238..0x207330c`, com RET observado em `0x2073308`.

O programa verifica os hashes do par, depois verifica os operandos e os fluxos decisivos independentemente do hash geral. Assim, os testes podem demonstrar que uma inversão do retorno ou troca de literal é detectada pelo verificador sem depender apenas da identidade do arquivo.

| Fato estático | Localização / verificação |
| --- | --- |
| Ponteiro do literal da chave | ADRP `0x2073250` e LDR `0x2073260` decodificam GOT `0x41c85b8`; destino é x19 |
| Chave | GOT → usage `0x43498a0`, encoded `0xa0003319`, tag 5, índice 6540; bytes metadata: `GAME_CURRENT_WORLD` |
| Tipo do enum | ADRP `0x207324c` e LDR `0x207325c` → GOT `0x41b7d08` → usage `0x42f4268`, encoded `0x2000ce33`, tag 1, type index 26393 → `PWC.Game.LevelWorldType` |
| Valor default | MOV w10,#1 em `0x20732a0`; campo metadata `World` índice 40525 tem default comprimido de um byte `0x02`, decodificado como 1 |
| Construção do temporário enum | Acessos e stores em `0x2073298..0x20732b0`, com argumento x0 apontando para stack+8 |
| Conversão para nome | BL `0x20732b4` → `System.Enum.ToString` `0x338d9a0`; retorno salvo em x19 |
| Leitura do mundo salvo | BL `0x20732cc` → `UnityEngine.PlayerPrefs.GetString` `0x3cc5a70`; chave em x0, default em x1, metadata implícita nula em x2; retorno salvo em x20 |
| Validação do nome | BL `0x20732ec` → `IsSceneAvailable` `0x207305c`; candidato em x0 |
| Seleção de retorno | TST w0,#1 `0x20732f0`; CSEL x0,x20,x19,NE `0x20732f4`: candidato se bit 0 não zero, default caso contrário |
| Inicialização | TBNZ `0x2073268` → `0x2073298` e CBNZ `0x20732dc` → `0x20732e8` preservados; helpers não removidos do contrato |

A decodificação de defaults é restrita aos pequenos inteiros comprimidos não negativos desse enum, não um leitor universal de constantes v31. Não interpretar os bytes de defaults como int32 fixo: neste caso, isso produziria valores incorretos.

Contrato candidato do caminho normal:

```text
GetCurrentWorldSceneName() -> string:
    garantir inicialização de metadata/classes conforme os guards
    fallback = LevelWorldType.World.ToString()
    candidate = PlayerPrefs.GetString("GAME_CURRENT_WORLD", fallback)
    available = IsSceneAvailable(candidate)
    return (available & 1) != 0 ? candidate : fallback
```

Pré-condições do candidato: binário/metadata exatos, contexto managed válido, helpers e bibliotecas com seus contratos usuais, término normal das chamadas. Não se afirma que os helpers sejam puros ou incapazes de lançar exceção. Efeitos conhecidos: leitura de PlayerPrefs via API, temporário de stack e flag de inicialização; o callee de disponibilidade pode construir um cache estático. Nenhuma execução real desses efeitos ocorreu nesta rodada.

## IsSceneAvailable: regra local de disponibilidade

VA `0x207305c`, janela candidata até `0x2073238`. O assembly consulta um ponteiro no slot estático `+0x48`; quando inicialmente nulo, aloca/constrói uma coleção e a preenche com nomes derivados da lista de cenas de build.

Âncoras conferidas:

- Leitura/cache: `0x20730f8`; store no slot `+0x48`: `0x2073140`.
- Contador começa em zero; BL `0x2073178` chama `SceneManager.get_sceneCountInBuildSettings`.
- CMP e B.GE `0x2073180` encerram o loop quando `i >= count`, com comparação signed.
- BL `0x207318c`: `SceneUtility.GetScenePathByBuildIndex(i)`.
- BL `0x20731b0`: `System.IO.Path.GetFileNameWithoutExtension(path)`.
- Adição à coleção candidata em `0x20731e4`; incremento em `0x20731e8`; backedge em `0x20731ec`.
- Tail branch `0x2073230` para a operação genérica candidata de consulta, recebendo a coleção e `sceneName`.

```text
IsSceneAvailable(sceneName:string) -> bool:
    garantir inicialização
    if cachedNames == null:
        cachedNames = construct_collection()        # generic binding pendente
        for i = 0; i < SceneManager.sceneCountInBuildSettings; i++:
            path = SceneUtility.GetScenePathByBuildIndex(i)
            name = Path.GetFileNameWithoutExtension(path)
            add_to_collection(cachedNames, name)    # generic binding pendente
    return lookup_in_collection(cachedNames, sceneName)  # generic binding pendente
```

A coleção é identificada como `HashSet<string>` na declaração extraída `_availableSceneNames`; as funções genéricas concretas de construção/Add/Contains ainda não foram vinculadas por MethodSpec/registration nesta rodada. Portanto, os nomes semânticos das três operações são **inferência sustentada pelo contexto**, não certificação do callee genérico. Os alvos nativos continuam registrados sem um nome falsamente confirmado.

Esse recorte indica disponibilidade local por nome na lista de build. **Não comprova posse, preço, gratuidade, servidor ou entitlement do ambiente.** Outros pontos de acesso podem impor guards adicionais. Invalidação do cache, concorrência e comportamento de null/erro também permanecem abertos.

## Transição e carregamento

Os nomes dos campos abaixo combinam acessos reais de código com as declarações extraídas GameSceneManager/LoadingScreenManager; seus arquivos/hashes são registrados. Os corpos desses C# continuam vazios. A associação de nomes não certifica efeitos arbitrários dos callees.

### LoadScene

VA `0x20728d4`, janela candidata até `0x2072c5c`; assinatura declarada: `LoadScene(string sceneName, bool considerMultiplayer, string mp_nextSceneId)`.

```text
closure = alocar e guardar sceneName, considerMultiplayer&1, mp_nextSceneId
if IsSceneChangingInProgress:
    tailcall Debug.LogError(message)
    # caminho não despacha a transição
limpar caches por chamadas nomeadas de avatar, SUT e peças/ícones CarMaker
IsSceneChangingInProgress = true
CurrentlyLoadingSceneName = sceneName
PreviousSceneName = GetActiveSceneName()
invocar callbacks opcionais de estágio 1, 2 e 3, nessa ordem de call sites
action = construir Action ligada à closure
tailcall LoadingScreenManager.Instance.StartSceneTransition(action)
```

Guard em `0x2072a1c`, erro via tail branch `0x2072a58`; flag `+0x30` escrita em `0x2072b28`; nome carregando `+0x28` em `0x2072b30`; anterior `+0x20` em `0x2072b48`. As três chamadas indiretas são `BLR x9` em `0x2072b70`, `0x2072ba0`, `0x2072bd0`. O tail branch para loading está em `0x2072c54`.

Os endereços de invocação e sua ordem são estáticos. Os subscribers, seus efeitos, o callback da closure e os caminhos de exceção/alocação ainda precisam ser recuperados. Não assumir que retorno dessa função significa cena carregada.

### LoadSceneImplement

VA `0x2072cc8`, janela candidata até `0x2072d84`:

```text
garantir inicialização
if flag estática multiplayer observada:
    MPOwnership.Clear()
tailcall SceneManager.LoadSceneAsync(sceneName)
```

BL para `MPOwnership.Clear` em `0x2072d5c`; tail branch para a sobrecarga mapeada de um parâmetro `LoadSceneAsync(string)` em `0x2072d80`. A identidade do flag e seu default, runtime Unity, lifecycle, erros e conclusão async não estão certificados.

### LoadingScreenManager.StartSceneTransition

VA `0x20fe2d8`, janela candidata até `0x20fe4b4`, sem incluir o método seguinte. Recebe `this` e `Action onFadeComplete`.

```text
desabilitar Behaviour selecionado se não nulo conforme Unity Object checks
desabilitar EventSystem.current quando não nulo
instanciar o prefab de screen sob this.transform  # binding genérico pendente
guardar retorno em _currentScreen, com write barrier
tail-dispatch virtual com argumentos true e onFadeComplete
```

O prefab é lido de `this+0x20` em `0x20fe438`, a tela é escrita em `+0x28` em `0x20fe474`; o destino final é **BR x4** em `0x20fe4ac`, proveniente de slot virtual, e permanece desconhecido. Isso impede afirmar duração do fade, sequência do callback, destruição da tela e desbloqueio do EventSystem apenas a partir deste método.

## Verificação executada

- O comando real de geração passou os hashes exatos do par, hashes das cinco janelas e revalidação dos símbolos nomeados contra metadata e módulo atual.
- Verificou operandos, guards, argumentos, calls e seleção do getter; além de 21 call sites e âncoras de fields/loop/dispatch dos métodos adjacentes.
- **25 testes passaram, zero falhas/skips**, incluindo mutações de hash, literal, inteiro comprimido, default imediato, alvo BL, condição/register CSEL, guarda de inicialização, registrador/base LDR, movimento do candidato, retorno, cache store, condição de loop e destino indireto virtual.
- Os testes exercitam o **verificador de evidência**, não executam os métodos originais nem comparam o jogo com o clone. Um teste de simulação desses ramos sem CPU original também não seria prova de execução.

Nenhum resultado está rotulado como certificado. Em particular, hashes e janelas comprovam identidade de bytes, mas não completude do corpo: intervalos não contíguos, exceções e callees externos não foram fechados. O decoder de controle é limitado e suas saídas são encodings estáticos, não rastros de execução.

## Fila residual concreta

1. Resolver MethodSpec/rgctx e corpos das operações de coleção no cache de cenas; fechar null, comparação de strings e concorrência/invalidação.
2. Recuperar os três delegates de estágio e o callback `<LoadScene>b__0`, inclusive guards de multiplayer e passagem de `mp_nextSceneId`.
3. Resolver a instância `_currentScreen`, o slot virtual final da transição e a sequência de fade/carregamento/retorno.
4. Recuperar o reset de `IsSceneChangingInProgress`, atualizações de mundo salvo e limpeza de caches após sucesso/erro.
5. Criar contratos de corpo/CFG e efeitos dos helpers runtime ou mantê-los como dependência explícita revisada.
6. Rodar cenários do original com chave ausente, mundo válido, mundo inválido e transição em andamento; comparar com a implementação candidata antes de modificar o cliente para usar essa regra.

T029 permanece parcial. Esta rodada reduziu a incerteza do getter e expandiu a cadeia de disponibilidade/loading com evidência guardada e reproduzível; não concluiu a navegação de todos os ambientes.
