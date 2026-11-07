# T029 — prefab, destino virtual e ciclo do loading/fade

Rodada 2026-11-07. Complementa [navegação](RECON_NAVIGATION_CONTRACT.md), [LoadScene](RECON_LOAD_SCENE_CONTRACT.md) e [handoff Home→Play](RECON_HOME_PLAY_HANDOFF.md). Resultado estático parcial: não foi executado o jogo, o tween ou qualquer emulação. Nenhuma alteração foi feita no cliente nem no estado global de tarefas.

## Reprodução e fontes

```bash
python3 tools/recon_loading_fade.py
python3 -m unittest discover -s tools -p test_recon_loading_fade.py -v
```

O produtor verifica o par já extraído `out/recon/il2cpp/libil2cpp.so` SHA-256 `b63661fa60c23ebef1c2da4bb5288ad787eb3da36b22d4bdf285401f1643d728` e metadata SHA-256 `1ea14cf5829d5c31e5e967b1608b5701020ab0d24bd4ab69d9f1e2b243467bc6`. Reutiliza o índice metadata como lookup e revalida os símbolos usados por token, imagem, método e ponteiro codegen do par atual.

Para resolver o prefab, lê somente os blocos UnityFS sobrepostos a `sharedassets1.assets` diretamente do membro ZIP armazenado `assets/bin/Data/datapack.unity3d`. Não materializa nem redumpa todo o bundle. O APK de dados tem SHA-256 `66fd0e2732064ddfeaf2d4f596b8f25d81376a703e7b5878c2d9585c5e3ec792`; a base, `c7edf76ff14254ecab9dc4162962f5d49d8e13be6e2e74e38f7d992f8c77ca07`. Ambos são conferidos por streaming. O arquivo serializado selecionado tem 726.336 bytes, SHA-256 `26dfd17a8ee7fe41621de3feabed192f66f81343322eecf81e314d4d0c91d91c`.

O manifesto pequeno fica em `reports/recon/loading_fade_contract.json`. Raw bytes, vínculos e janelas LLVM ficam em `out/recon/loading-fade/`. A evidência vem de parser local, UnityPy e LLVM; não é Evidence produzida pelo REA. O bloqueio anterior do Hopper não foi repetido.

## Prefab efetivamente distribuído

Vínculos refeitos a partir dos bytes serializados originais, além dos dumps antigos:

| Objeto | Referência confirmada |
| --- | --- |
| Manager MonoBehaviour 259 | GameObject 86 `LoadingScreenCanvas`, MonoScript 1499, `_screenPrefab=(fileID0,path242)` |
| Screen MonoBehaviour 242 | GameObject 81 `LoadingScreenScreen`, MonoScript 4067 |
| Campos da screen | `_canvasGroup=210`, `_background=291`, horas=83, minutos=37, nariz=40, todos no mesmo arquivo |
| Background 291 | MonoScript 5535 → `UnityEngine.UI.Image` |
| CanvasGroup 210 | Alpha inicial 0.0; `blocksRaycasts=true`, `interactable=true` |

Os MonoScripts 1499/4067 foram relidos de `data.unity3d` na base e identificam `PWC.LoadingScreen.LoadingScreenManager/LoadingScreenScreen` em Assembly-CSharp. O script 5535 identifica Image em UnityEngine.UI. O envelope bruto do manager tem 44 bytes e o da screen 92; referências e tamanho são guardados.

Limite: essa associação descreve o prefab distribuído. Código que substitua `_screenPrefab`, adicione componentes ou altere o tipo em runtime exigiria nova observação. A instanciação genérica não foi executada.

## Dois despachos virtuais antes desconhecidos

1. **StartSceneTransition → LoadingScreenScreen.Fade**. A screen tem typedef 4259, vtableStart 84248 e cinco slots. Entrada 4 contém `0x6000bf91`, que decodifica methodDefinition 24520, token `0x06005fc9`, nome Fade, dois parâmetros, slot declarado 4. O índice codegen liga o método ao VA `0x20fe6ec`. O código de StartSceneTransition carrega o par de função/MethodInfo no offset `0x178/0x180` e termina em `BR x4` (`0x20fe4ac`), passando `true` e o Action original.
2. **Fade(true) → Graphic.set_raycastTarget(true)**. O objeto background original é Image. Seu slot 25 tem `0x60030b11` → methodDefinition 99720, `UnityEngine.UI.Graphic.set_raycastTarget`, um parâmetro e slot declarado 25. Isso corresponde aos offsets nativos `0x2c8/0x2d0`, com `BLR x9` em `0x20fe7d0` e argumento true.

Os offsets nativos concordam com uma base de vtable `0x138`, derivada dos slots 4 e 25. O layout Il2CppClass em memória não foi observado; portanto a resolução permanece condicionada ao tipo concreto do prefab distribuído e ao layout esperado da versão. A concordância metadata+asset+opcode é mais forte que inferir o alvo apenas pelo nome do método.

O segundo despacho muda **raycastTarget**, não a propriedade enabled da Image. Na saída por fade false não há escrita inversa de raycastTarget nesse método: o GameObject da screen é destruído quando o fade termina.

## Fluxo candidato recuperado

```text
StartSceneTransition(action):
    preservar os guards/efeitos já descritos no contrato de navegação
    screen = Instantiate(prefab, this.transform)
    currentScreen = screen
    screen.Fade(true, action)  # slot4 do tipo distribuído

LoadingScreenScreen.Fade(value, onComplete):
    closure = { this, value & 1, onComplete }
    if value:
        background.raycastTarget = true
        AnimateClock(true)
    LeanTween.cancel(canvasGroup.gameObject)
    from = canvasGroup.alpha
    target = value ? 1.0 : 0.0
    tween = LeanTween.value(this.gameObject, from, target, 0.25)
    tween.setOnUpdate(closure.<Fade>b__0)
    tween.setOnComplete(closure.<Fade>b__1)

closure.<Fade>b__0(alpha):
    this.canvasGroup.alpha = alpha

closure.<Fade>b__1():
    if value:
        if onComplete != null:
            onComplete()
        return
    this.AnimateClock(false)
    Destroy(this.gameObject)
    # neste ramo o Action não é chamado
```

O FMOV de `0x20fe878` fornece **0.25** no registrador s2; os caminhos usam FCSEL em `0x20fe858` para escolher 1.0 quando value=true e 0.0 quando false. É o parâmetro de duração codificado, não uma medição de 250 ms no aparelho: escala de tempo, interrupções e scheduling de LeanTween permanecem externos.

Os callbacks foram ligados pelos usos metadata de método: GOT `0x41cc838` → definição 24524 `<Fade>b__0`; GOT `0x41cc840` → definição 24525 `<Fade>b__1`. As chamadas `LeanTween.value`, `setOnUpdate`, `setOnComplete`, CanvasGroup.get/set_alpha e Destroy são revalidadas contra o índice metadata e módulo atual.

O callback true nulo sai com RET em `0x20feb88`. O ramo false chama AnimateClock(false) em `0x20feb38` e destrói o objeto via tail branch `0x20feb7c`. Preservar essas diferenças: destruir a tela antes de carregar, chamar o callback nos dois ramos ou invocar um callback nulo mudaria a lógica.

## Depois que a cena carrega

```text
LoadingScreenManager.OnSceneLoaded(scene, mode):
    if UnityObjectEqual(currentScreen, null):
        return
    capturedScreen = currentScreen
    Utils.ExecuteNextFrame(this, () => capturedScreen.Fade(false, null))
    currentScreen = null
```

O método chama ExecuteNextFrame em `0x20fe5b8` e zera o campo em `0x20fe5bc`, depois de capturar a tela na closure. A chamada virtual da closure `0x20fe6c4` passa false e callback nulo, usando novamente o slot 4 do tipo concreto.

A função Utils.ExecuteNextFrame inicia ExecuteNextFrameCoroutine. A construção inicializa state=0; MoveNext (`0x1cbed54`) na primeira passagem define Current=null, state=1 e retorna true. Na passagem state=1, muda state para -1, invoca o Action e retorna false. Portanto a intenção de adiar uma retomada de coroutine é sustentada pelo código. O momento exato do próximo frame depende de StartCoroutine/Unity; não foi medido.

`<OnSceneLoaded>b__0` é ligado pelo uso metadata GOT `0x41cc828` → definição 24519. Ainda falta confirmar quem registra o hook OnSceneLoaded e toda a ordem de eventos Unity/scene manager. Essa descoberta fecha a sequência local do callback da screen, não todos os assinantes globais.

## Clock e efeitos externos

Estão guardadas as chamadas reais de início/paro. O corpo observado chama rotateAroundLocal nas referências de horas/minutos com -360 e tempos 1.0/0.5, seguido de `setLoopType(1)`. Quando value=false, cancela tweens para horas, minutos e nariz. O produtor não transforma o valor 1 em uma promessa de loop infinito nem certifica a semântica interna de LeanTween; isso exigiria validar a biblioteca e sua atualização temporal.

## Verificação e conclusão

O produtor verifica **55 âncoras nativas**, 21 chamadas nomeadas, dois vínculos de slot virtual, os usos metadata das três closures e as referências serializadas originais. Gera dez janelas de métodos/callbacks/coroutine; o fim pelo próximo método é um limite operacional, não prova de corpo completo ou regiões de exceção.

**21 testes focados passaram** com os inputs reais e mutações de ponteiro do prefab, referências da screen, identidade de scripts, slot nativo, slot/token metadata, duração, target alpha, polaridade do ramo de completion, guard do Action nulo, target de Destroy, callback metadata, chamada de parar clock e máquina de estado da coroutine. Os testes verificam a evidência e os guardas; não executam os métodos originais.

O recorte continua parcial e não promove tarefa global. Restam o hook de OnSceneLoaded, efeitos de helpers/GC/exceções, restauração de input/EventSystem, binding da instanciação genérica, scheduling/cancelamento/tempo real do tween e comparação contra o original em aparelho. O cliente não recebeu essa tela nem teve seu loading alterado nesta rodada.
