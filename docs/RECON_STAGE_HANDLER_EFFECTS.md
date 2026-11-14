# T025 — efeitos dos cinco handlers de troca de cena já identificados

Rodada 2026-11-08. Recupera os efeitos concretos dos **cinco handlers** já ligados a
registros de evento em [RECON_SCENE_SUBSCRIBERS.md](RECON_SCENE_SUBSCRIBERS.md)
("Cinco ligações verificadas"): `BackgroundPlanetSoundHandler.OnBeforeSceneLoadStage1`,
`PersistentDataManager.OnBeforeSceneLoadStage2`, `LevelManager.OnBeforeSceneLoadStage2`,
`LevelManager.OnBeforeSceneLoadStage3` e `GameSceneManager.OnActiveSceneChanged`. Esta
lacuna estava registrada como `T029/handler_effects_lifetime` em
[out/recon/tasks/T025/METHOD/8e708ca7d06e0b52/unknowns.jsonl](../out/recon/tasks/T025/METHOD/8e708ca7d06e0b52/unknowns.jsonl).
Nenhum alvo foi executado, emulado ou observado no aparelho; tudo aqui permanece
`static_candidate_not_runtime_validated`.

## Reprodução

```bash
python3 tools/recon_stage_handler_effects.py
python3 -m unittest tools.test_recon_stage_handler_effects -v
```

Entradas: par `out/recon/il2cpp/libil2cpp.so` (SHA-256
`b63661fa60c23ebef1c2da4bb5288ad787eb3da36b22d4bdf285401f1643d728`) e
`global-metadata.dat` (SHA-256 `1ea14cf5829d5c31e5e967b1608b5701020ab0d24bd4ab69d9f1e2b243467bc6`),
o mesmo par pinado em toda a cadeia T025/T029. Saída: `reports/recon/stage_handler_effects_2026-11-08.json`
e cinco diretórios-filho `out/recon/tasks/T025/HANDLER/<rid-hex>/` com
`method-contract.json`, `control-flow.json`, `unknowns.jsonl` e `result.json`.

## Resultado por handler

Cada janela é limitada ao próximo início de método no índice metadata (não prova
corpo/regiões de exceção completos). Opcodes decisivos foram fixados (`expect`) e
qualquer mutação local falha o produtor — verificado por sete testes focados.

### `BackgroundPlanetSoundHandler.OnBeforeSceneLoadStage1`

```text
if (this._tweenId >= 1):            // campo offset 0x58, confirmado no stub extraído
    LeanTween.cancel(this.gameObject, this._tweenId, false)
this._tweenId = 0                   // escrita incondicional no retorno
```

`Component.get_gameObject()` e `LeanTween.cancel` são revalidados por nome contra o
índice metadata atual (não apenas por endereço cacheado). Cancela qualquer tween de
som ambiente do planeta de fundo pendente antes da transição de cena.

### `PersistentDataManager.OnBeforeSceneLoadStage2`

Não tem corpo próprio: é um *tail-jump* de 4 bytes (`B`) direto para
`SaveProgressInAllScenes`, cujo MethodDef é revalidado pelo join metadata/codegen.

```text
for i in range(SceneManager.sceneCount):
    scene = SceneManager.GetSceneAt(i)
    this.SaveProgress(scene)
```

`SceneManager.get_sceneCount`, `SceneManager.GetSceneAt` e o alvo de loop
`PersistentDataManager.SaveProgress(Scene)` são nomeados e revalidados; o corpo de
`SaveProgress` fica como dependência externa não recuperada nesta rodada.

### `LevelManager.OnBeforeSceneLoadStage2`

```text
this.IsAboutToLoadScene = true   // campo de instância offset 0x3A, confirmado no stub
```

Três instruções, sem chamadas: grava o booleano e retorna.

### `LevelManager.OnBeforeSceneLoadStage3`

```text
GameSceneManager.CurrentSceneSuffix = ""   // campo estático offset 0x18, confirmado no stub
```

O `this` (instância de `LevelManager`) não é lido nem escrito nesta janela; o método
só limpa um campo estático de `GameSceneManager`. O valor vem de um slot de uso de
metadata (kind 5 = literal string, índice 0) que decodifica para a string vazia — a
mesma técnica de decodificação usada no getter `GetCurrentWorldSceneName`
([RECON_NAVIGATION_CONTRACT.md](RECON_NAVIGATION_CONTRACT.md)). A escrita usa barreira
de GC (tail branch para o helper compartilhado `0x1b88694`, já visto em outras janelas
desta cadeia).

### `GameSceneManager.OnActiveSceneChanged`

```text
GameSceneManager.IsSceneChangingInProgress = false                    // offset 0x30
GameSceneManager.Multiplayer_LoadingSceneNameInProgress = null         // offset 0x40, com GC write barrier
GameSceneManager.CurrentlyLoadingSceneName = null                      // offset 0x28, com GC write barrier
```

**Fecha uma pendência histórica:** [RECON_NAVIGATION_CONTRACT.md](RECON_NAVIGATION_CONTRACT.md)
(2026-11-04) registrava "Próximo: quem zera `IsSceneChangingInProgress`
(`OnActiveSceneChanged` `0x2072644`)" como aberto. Esta rodada confirma, por opcode
fixado e nome de campo do stub extraído, que é exatamente este handler que zera o
flag, junto com a limpeza dos dois campos de nome de cena. Os parâmetros Unity
`(Scene, LoadSceneMode)` do próprio evento não são lidos nesta janela.

## O que continua aberto

- Os corpos dos callees nomeados (`LeanTween.cancel`, `PersistentDataManager.SaveProgress`,
  `SceneManager.GetSceneAt`/`get_sceneCount`) não foram recuperados; efeitos, exceções e
  I/O desses métodos ficam como dependências externas.
- O timing exato de resolução/self-patch do slot de uso de metadata lido por
  `LevelManager.OnBeforeSceneLoadStage3` (token bruto no binário vs. ponteiro `String*`
  resolvido em runtime) não foi observado.
- Inscrição efetiva, ordem global de disparo entre múltiplos assinantes do mesmo
  evento, remoção/lifetime no aparelho e comparação com o jogo original continuam
  fora do escopo desta rodada — nada aqui foi executado, emulado ou validado no
  Xiaomi de referência.
- Os outros sete MethodDefs de handler (dos doze únicos cobertos pelo escaneamento de
  13 registros Stage1-3) permanecem com efeitos não recuperados; este recorte cobriu
  especificamente os cinco já citados em RECON_SCENE_SUBSCRIBERS.md.

## Verificação

**Sete testes focados passaram**, cobrindo: cada um dos cinco analisadores contra o
par real, e cinco mutações negativas (guarda do tween-id, tail-jump do
`PersistentDataManager`, escrita de `IsAboutToLoadScene`, barreira de GC em
`CurrentSceneSuffix`, escrita de `IsSceneChangingInProgress`) mais a verificação de
que os quatro arquivos de saída existem para cada um dos cinco diretórios-filho. Os
testes exercitam o verificador de evidência estática; não executam os métodos
originais nem comparam com o jogo real.
