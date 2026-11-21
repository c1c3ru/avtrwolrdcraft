# Decodificação dos 3 despachos indiretos Stage1-3 dentro de LoadScene — 2026-11-08

Candidato estático, **não validado em runtime**. Verificador: `python3 tools/recon_stage_dispatch.py` (relatório em `reports/recon/stage_dispatch.json`); testes: `python3 -m unittest discover -s tools -p test_recon_stage_dispatch.py`. Nenhum alvo REA ativo, nenhuma execução do jogo, nenhuma alteração de fila.

Fecha o unknown `T025/complete_body_and_cfg` ("3 Stage1-3 delegate targets ... inferred from position, not decoded from a vtable or delegate target") até o ponto estaticamente alcançável: os três `BLR x9` em `0x2072b70`/`0x2072ba0`/`0x2072bd0`, já anotados como opacos em `recon_navigation.verify_transition_anchors`, agora têm as instruções anterior e o mecanismo de despacho totalmente decodificados. Complementa [o contrato de LoadScene](RECON_LOAD_SCENE_CONTRACT.md) e [os assinantes dos eventos](RECON_SCENE_SUBSCRIBERS.md).

## O que cada estágio faz (três cópias quase idênticas, confirmado byte a byte)

Para Stage*N* ∈ {1,2,3}, com offset de campo `0x0`/`0x8`/`0x10` (os mesmos já documentados):

```
ldr x0, [x23]              ; recarrega o ponteiro cacheado do GameSceneManager (não reusa registrador entre estágios)
ldr x8, [x0, #0xb8]        ; ponteiro dos campos estáticos
ldr x8, [x8, #offset]      ; campo do evento OnBeforeSceneLoadStage{N}Action -> objeto delegate ou null
cbz x8, <resume>           ; evento vazio (delegate null) -> pula a chamada
ldr x9, [x8, #0x18]        ; <-- NOVO: lido do próprio OBJETO delegate, não do GameSceneManager
ldr x0, [x8, #0x40]        ; <-- NOVO: idem
ldr x1, [x8, #0x28]        ; <-- NOVO: idem
blr x9                      ; despacho indireto: alvo = ponteiro de função específico desta instância
```

**Antes desta rodada:** só o `blr x9` final era conhecido, com o alvo marcado `UNKNOWN_indirect_call_target`/"inferred from position". **Agora:** as três cargas que preparam esse `blr` são decodificadas, âncoras de opcode guardam cada uma, e sabe-se exatamente de onde vêm o alvo da chamada (`x9`) e seus dois primeiros argumentos (`x0`, `x1`).

## Por que isso NÃO é "o alvo do handler", e o que de fato ficou provado

O `x9` carregado não é o endereço de `BackgroundPlanetSoundHandler.OnBeforeSceneLoadStage1` nem de qualquer handler nomeado — é lido do offset `+0x18` do **objeto delegate em si** (o valor do campo do evento), isto é, um ponteiro de função específico da instância do delegate, resolvido em runtime quando esse delegate foi construído (pelos `add_OnBeforeSceneLoadStage*Action` já documentados). Byte estático nenhum em `LoadScene` pode revelar esse valor — e não deveria, já que o mesmo código precisa funcionar tanto para zero quanto para N assinantes (Stage2 tem dois: `PersistentDataManager` e `LevelManager`).

O que ficou provado estaticamente:
1. O guard de null (`cbz x8`) reproduz exatamente "invocar só se o evento tiver assinante" — delegate C# vazio é `null`.
2. O despacho é sempre indireto através de um campo da instância do delegate (offset `+0x18`), nunca um branch direto a um handler fixo — consistente para os três estágios.
3. Os dois primeiros argumentos inteiros da ABI AArch64 (`x0`, `x1`) vêm de outros dois campos fixos do mesmo objeto delegate (`+0x40`, `+0x28`).
4. Os três estágios usam a *mesma* sequência de 4 instruções (`ldr x9,[x,#0x18]`; `ldr x0,[x,#0x40]`; `ldr x1,[x,#0x28]`; `blr x9`), e essa sequência exata ocorre **467 vezes** nos segmentos executáveis de todo o `.so` — em classes completamente não relacionadas (`UnityEngine.UIElements.Panel`, `UnityEngine.UIElements.DragAndDropUtility`, `WebSocketSharp.WebSocket.releaseServerResources`, closures `<>c__DisplayClass*`). Isso é evidência corroborante forte de que é o idioma genérico do IL2CPP para invocar diretamente um delegate de 0 argumentos/retorno void sempre que a instância já está em mãos — não algo específico destes três eventos.

## O que continua candidato, não provado

- Rotular offset `+0x18` como `invoke_impl`, `+0x40` como `m_target` e `+0x28` como `method` segue a forma pública conhecida do ABI `Il2CppDelegate`, mas **não foi confirmado** contra o header exato desta build de IL2CPP/Unity — só os offsets, registradores e papéis de argumento são fatos binários verificados.
- Qual(is) handler(s) de fato executam através desse `blr`, e em que ordem para os dois assinantes do Stage2, é propriedade do objeto delegate construído pelos `add_*` (ver `RECON_SCENE_SUBSCRIBERS.md`) — não algo que estes três pontos de chamada fixem por si.
- Reflexão, delegates reconstruídos dinamicamente ou qualquer coisa fora do padrão Action single/multicast já descrito não são descartados.
- Nenhuma observação em runtime/aparelho foi feita.

## Proveniência e reprodução

- Native/metadata SHA-256: mesmos do par já fixado em `recon_navigation.py` (`b63661fa...`/`1ea14cf5...`).
- Produtor guardado: [recon_stage_dispatch.py](../tools/recon_stage_dispatch.py); testes: [test_recon_stage_dispatch.py](../tools/test_recon_stage_dispatch.py) (8 testes, mutam offset do campo do evento, offset do alvo indireto, offsets dos argumentos, polaridade do guard de null e registrador do `blr`).
- Relatório completo: [stage_dispatch.json](../reports/recon/stage_dispatch.json).

```bash
python3 tools/recon_stage_dispatch.py
python3 -m unittest discover -s tools -p test_recon_stage_dispatch.py -v
```
