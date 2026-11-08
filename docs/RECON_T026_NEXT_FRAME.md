# T026 — ciclo da coroutine e hook de sceneLoaded

Rodada 2026-11-07. Recorte estático da coroutine `PazuCore.Utils.ExecuteNextFrameCoroutine`, usada no fade de saída do loading, e dos pontos que inscrevem/removem `LoadingScreenManager.OnSceneLoaded`. A análise reutiliza o par IL2CPP/metadata conhecido e os registros recuperados em T025. Não executa Unity, o original ou um emulador.

T026 pai continua pendente das T024/T025. Foi criado o filho delimitado `T026/STATE_MACHINE/execute-next-frame`, com inputs por hash e aceite próprio. A investigação desse filho não depende de fingir que os pais ou todas as funções anteriores estão concluídos; seus resultados continuam parciais enquanto houver contratos externos relevantes desconhecidos.

## Máquina e campos originais

Tipo nested metadata **629**, `<ExecuteNextFrameCoroutine>d__38`, com owner `PazuCore.Utils` revalidado pelo índice do tipo declarante. Campos conferidos por metadata e tabela nativa `fieldOffsets`, sem confiar somente nas anotações do Cpp2IL:

| Campo | Offset no objeto |
| --- | ---: |
| `<>1__state` | `0x10` |
| `<>2__current` | `0x18` |
| `action` | `0x20` |

O produtor verifica oito identidades de método por imagem/owner/token/codegen: factory, entrada `ExecuteNextFrame`, construtor, `MoveNext`, `Dispose`, os dois getters `Current` e `Reset`. As oito janelas terminam no próximo início metadata; isso não comprova todas as regiões de corpo ou exceção.

## Transições STATIC

| Operação/entrada | Caminho local observado nos bytes | Resultado sob retorno normal dos callees |
| --- | --- | --- |
| Factory | Aloca o tipo da máquina, chama `.ctor(0)`, guarda Action em `+0x20` com barreira de referência | Novo enumerador em estado 0 |
| Entrada `ExecuteNextFrame(host,action)` | Constrói o enumerador; host não nulo → tailcall `MonoBehaviour.StartCoroutine(IEnumerator)`; host nulo → helper `0x1b88980` | Agendamento externo; falha do helper não reconstruída |
| `MoveNext`, estado 0 | Current=null; state=-1; barreira de referência; state=1 | Retorna true: `yield null` |
| `MoveNext`, estado 1, Action presente | Grava state=-1 **antes** de invocar o delegate | Retorna false se o Action retornar normalmente |
| `MoveNext`, estado 1, Action nulo | Grava state=-1 antes do teste; desvia ao helper `0x1b88980` | Caminho de falha; efeito exato do helper desconhecido |
| `MoveNext`, qualquer outro int32 | Não invoca Action nem muda estado | Retorna false |
| `Dispose`, qualquer estado | Uma instrução RET; nenhuma escrita local | Não altera state, Current ou Action |
| `Current`, ambos os getters | Lê `+0x18` | Retorna a referência guardada |
| `Reset` | Constrói `System.NotSupportedException` e passa objeto + MethodInfo do próprio Reset ao helper `0x1b8884c` | **INFERRED:** lança exceção; helper e regiões de exceção não certificados |

Detalhe de endereçamento: `STR xzr,[x19,#0x18]!` em `0x1cbed6c` é **pré-indexado** e passa a manter `x19=object+0x18`. Os `STUR [...,#-8]` subsequentes escrevem state em `object+0x10`; não escrevem no Current. A retomada do estado 1 grava -1 em `0x1cbed98`, antes do `BLR` em `0x1cbedac`.

A escrita anterior ao callback permite afirmar a ordem local, inclusive se o callback depois lançar uma exceção. Não houve experimento de exceção/reentrância, nem análise do tratamento posterior pelo scheduler. O Action e Current não são limpos pelo Dispose. Na sequência normal, Current é null após o primeiro yield; o construtor em si apenas inicializa state, portanto não atribuímos a ele uma escrita de referências que não existe no código.

**Cancelamento:** Dispose sozinho não marca a máquina como cancelada. Depois de Dispose em estado 1, uma chamada manual subsequente a MoveNext ainda pode alcançar o Action, sob os mesmos guards. Isso é consequência estática do RET vazio; não prova como Unity chama Dispose/MoveNext ao executar StopCoroutine ou destruir o host.

**Tempo:** yield null é sustentado pela escrita de Current e retorno true; não é uma duração em segundos ou uma medição de “exatamente um frame”. O agendamento e a retomada são contratos externos Unity.

## Hook de loading

A investigação complementar confirmou chamadas ao accessor Unity:

| Registrador | Site | Destino |
| --- | --- | --- |
| `LoadingScreenManager.Awake`, token `0x06005fc2` | `BL` em `0x20fe294` | `SceneManager.add_sceneLoaded`, token `0x060009c2`, VA `0x3cdbc5c` |
| `LoadingScreenManager.OnDestroy`, token `0x06005fc5` | `B` em `0x20fe6b4` | `SceneManager.remove_sceneLoaded`, token `0x060009c3`, VA `0x3cdbd50` |

Nos dois casos o delegate é construído com alvo `this` e MethodInfo vindo de `[this.klass+0x180]`. Não é um uso direto de MethodDef. Sob a base vtable `0x138`, pares de 16 bytes e receptor concreto esperado, esse é o MethodInfo do slot 4, cujo metadata aponta a `OnSceneLoaded`, definição 24515/token `0x06005fc4`.

Um override em outro tipo concreto poderia mudar essa resolução. A análise não observou a classe nativa em runtime. O construtor canônico foi vinculado por MethodSpec/registration a `UnityAction<Scene,Int32Enum>..ctor`; essa canonicalização não prova, sozinha, o MethodSpec solicitado `Scene/LoadSceneMode`. Inscrição efetiva, igualdade de delegates e remoção efetiva continuam desconhecidas.

O corpo de OnSceneLoaded e sua closure já foram analisados no [contrato de loading](RECON_LOADING_FADE_CONTRACT.md): capturam a screen, chamam ExecuteNextFrame e depois o callback faz Fade(false,null). O novo recorte reduz a lacuna da origem do hook, sob as precondições acima; não prova a ordem global dos eventos Unity.

## Evidências e reprodução

- [Produtor do ciclo](../tools/recon_t026_next_frame.py), [relatório](../reports/recon/t026_next_frame.json) e [revisão independente](../reports/recon/t026_next_frame_review.json).
- [Produtor do hook](../tools/recon_t026_scene_hook.py), [relatório](../reports/recon/t026_scene_hook.json) e [revisão](../reports/recon/t026_scene_hook_review.json).
- Manifesto do filho: [t026_next_frame_children.json](../reports/recon/t026_next_frame_children.json).
- Assembly, comandos LLVM, códigos de retorno, durações, offsets e hashes constam dos relatórios. A origem é parser local/LLVM, não decompilação REA bem-sucedida.
- Native SHA-256: `b63661fa60c23ebef1c2da4bb5288ad787eb3da36b22d4bdf285401f1643d728`.
- Metadata SHA-256: `1ea14cf5829d5c31e5e967b1608b5701020ab0d24bd4ab69d9f1e2b243467bc6`.

**16 testes passaram**, zero falhas, em **19,580 s**. Mutações verificam state/Current, guarda de callback, Dispose, estado inicial, construtor da exceção, fieldOffsets, slot virtual, preservação de this, destinos add/remove e join canônico. Não equivalem a execução do jogo ou comparação diferencial.

```bash
python3 tools/recon_t026_next_frame.py
python3 tools/recon_t026_scene_hook.py
python3 -m unittest discover -s tools -p 'test_recon_t026_*.py' -v
```

Publicar o resultado no caminho oficial do filho requer seu lease; para reprodução isolada usar `--output` e `--report` em uma pasta temporária. Nenhuma mudança no cliente integra esta rodada.

## Pendências

- Semântica do scheduler/StopCoroutine/destruição do host e observação da ordem/tempo em Unity.
- Helpers, erro nulo e exceções; regiões completas dos métodos não recuperadas.
- Instanciação solicitada do delegate do hook e tipo concreto em runtime.
- Demais máquinas, callbacks/eventos e async obrigatórios da T026.

O inventário histórico de 437 entradas é ponto de descoberta, não 437 contratos recuperados. Ausência de chamadas a builders em uma janela/índice restrito não prova ausência global de async. As exclusões QA/lobby já autorizadas continuam preservadas; este helper de PazuCore entra por ser dependência concreta do loading, sem reabrir todo o SDK.
