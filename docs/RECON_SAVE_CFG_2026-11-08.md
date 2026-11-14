# T030 — basic-block CFGs and extended indirect-dispatch contract

Data: 2026-11-08. Escopo: fechar a lacuna registrada em `docs/RECON_SAVE_CONTRACT.md` ("Próxima extração delimitada", itens 1–2) sem repetir trabalho já comitado em `save-dispatch-contract.json`/`runtime-save-summary.json`.

## O que mudou em relação à rodada de 2026-11-04

`tools/recon_save_static.py` só registrava alvos de `bl` (chamada) e `b` incondicional; nunca parseava `b.cond`, `cbz`, `cbnz`, `tbz` ou `tbnz`, nem distinguia `blr` (chamada indireta) de `br` (salto indireto). Isso significava que nenhum dos 58 métodos já extraídos tinha, de fato, um CFG — apenas uma lista plana de chamadas sobre uma janela de desmontagem linear.

Ferramenta nova: `tools/recon_save_cfg.py`. Reusa os `.asm.txt` já extraídos (mesmo SHA256 de `libil2cpp.so` registrado em `persistence-asm/report.json`: `b63661fa60c23ebef1c2da4bb5288ad787eb3da36b22d4bdf285401f1643d728`), parseia **todos** os tipos de desvio e constrói blocos básicos e arestas reais. Saída: `out/recon/tasks/T030/persistence-asm/cfg-report.json`.

Dois bugs de parsing corrigidos durante a extração (cobertos por `tools/test_recon_save_cfg.py`):
1. `tbz`/`tbnz`/`cbz`/`cbnz` listam um registrador/posição de bit antes do endereço-alvo (`w8, #0x0, 0x21e24f8`); pegar o primeiro literal hex pegava a posição de bit, não o alvo.
2. O alvo real de um desvio aparece antes da anotação simbólica do `llvm-objdump` (`0x21e24f8 <__start_il2cpp+0x5912e8>`); essa anotação tem seu próprio `+0x...`, que não pode ser confundido com o alvo. A correção descarta tudo a partir de `<` antes de extrair o último literal hex.

## Resultado: "bounded_within_window" como sinal de completude

Para cada método, `cfg-report.json` verifica se **todo** desvio intra-função (`b`, `b.cond`, `cbz`, `cbnz`, `tbz`, `tbnz` — não `bl`, que é uma chamada e espera-se que aponte para fora da janela) permanece dentro da janela já extraída. É uma condição necessária, não suficiente, para um CFG completo.

- **42/58 métodos têm todo desvio intra-função dentro da janela**, incluindo os quatro nomeados no gap original: `GetDataFromRootGameObjects`, `LoadDataInternal`, `GetFilePath` e `SaveDataInternal` (mais `SetPersistentData`, parte da mesma cadeia).
- Desses 42, a maioria **não termina em `ret`** — termina em `bl` para um de três endereços convergentes (`0x1b88980`: 30 ocorrências; `0x1914dc0`: 12; `0x1b88988`: 4) ou em `b` para o mesmo pequeno grupo de alvos. Essa convergência (dezenas de métodos não relacionados terminando no mesmo punhado de endereços) é evidência consistente com stubs padrão do IL2CPP (liberação de referência / relançamento de exceção `noreturn` no fim de um landing pad), não com truncamento: se fosse truncamento eu esperaria o limite caindo em pontos arbitrários diferentes por método, não convergindo. Nenhum símbolo foi resolvido para esses três endereços (ver limite abaixo); a interpretação fica como candidata, não como fato confirmado.
- **16/58 ainda têm desvio escapando da janela**, incluindo `GetFolder`, `LoadProgress`, `GetSceneData`, `SaveDataForScene`, `SaveSceneObjectsToKeepOnLoad`, `EnsureFolder`, `GetFolderWithoutOverrides`, `GetLevelDefaultDataString`, `GetActiveSceneFilePath`, `DeleteDataForActiveScene`, `LevelUserData.SetLevelData`/`DeleteSceneData`, `PDScene.AddSceneObject`/`TryRemoveSceneGuid`/`TryGetPrefabDataForSceneGuid`, `PDPrefab.GetSceneObjectsData`. Essas janelas precisam ser reextraídas com limite maior (ou um provider real de CFG) antes de qualquer alegação de corpo completo; a lista completa está em `cfg-report.json`.

**Limite explícito:** nem o caso bounded prova corpo completo (um jump table via `br` com alvos não lineares, ou uma cauda após o `ret` nunca alcançada por nenhum desvio observado, não apareceriam como estouro) nem o caso not-bounded prova truncamento (pode ser salto para stub legítimo fora da janela). Isso ainda não é o CFG de um decompilador real.

## Hopper/Ghidra continuam indisponíveis nesta sandbox

Tentei abrir `libil2cpp.so` via REA/Hopper para obter um CFG decompilado de verdade. `open_binary` teve sucesso (metadados/SHA256), mas qualquer chamada de análise profunda (`procedure_info`) trava aguardando o bridge do Hopper por mais de 120s ("Hopper may be waiting for a loader or license dialog"), mesmo com um Xvfb ativo — o mesmo bloqueio já registrado em `LOOP_STATE.md` em 2026-11-07 durante T025. Ghidra e IDA não estão configurados (`GHIDRA_INSTALL_DIR` ausente; sem registro IDA MCP). `llvm-objdump` (usado por `recon_save_static.py`) também não está instalado nesta sessão; o GNU `objdump` do sistema não tem suporte a AArch64. Por isso este lote reusa exclusivamente os `.asm.txt` já comitados — nenhum arquivo novo foi desmontado.

## Despachos indiretos: de 4 para 18 sites cobertos

`tools/recon_save_dispatch.py` tinha 4 contratos verificados (`GetFilePath`, `GetDataFromRootGameObjects`, `SetPersistentData`, `LoadDataInternal`). `cfg-report.json` expôs **18 transferências de controle indiretas** no total nas 58 janelas (17 `blr` + 1 `br` — esse `br` é um tail call que o scanner antigo, que só procurava `blr`, nunca via). As 14 novas entradas:

| Método | Site | Alvo | Confiança |
|---|---|---|---|
| `SaveProgress` | `0x21e0ab8` | `OnPreSaveProgressAction.Invoke(Scene)` | alta |
| `SaveProgress` | `0x21e0b10` (`br x3`, tail call) | `OnPostSaveProgressAction.Invoke(Scene)` | alta |
| `SaveDataInternal` | `0x21e2644` | `TryOverrideFileNameAction.Invoke(Scene, out string)` | alta |
| `GetFolder` | `0x21e2814` | `OverrideGetFolderNameAction.Invoke()` | alta |
| `GetLevelDefaultDataFileName` | `0x21e28f8` | `TryOverrideSceneDefaultDataFileNameAction.Invoke(Scene, out string)` | alta |
| `DestroySceneObjectsThatAreNotInTheSavedData` | `0x21e3eec` | `PDPrefab.OnBeforeDestroyOnSceneLoadAction.Invoke()` | média |
| `SetDefaltLevelDataForSceneObjects` | `0x21e58a4`, `0x21e59a4` | `IHasPersistentData.SetPersistentData(allData, sceneObjects)` (2×) | alta |
| `PDScene.AddSceneObject` | `0x21dd220` | não resolvido (candidato: `Exception.ToString()` em bloco catch) | baixa |
| `PDScene.TryAddPrefabData` | `0x21dd688`, `0x21dd720` | não resolvido (ver abaixo) | baixa |
| `LevelItem.GetPersistentData` | `0x22f12e0` | não resolvido (campo delegate de instância em `+0x318`) | baixa |
| `LevelItem.SetPersistentData` | `0x22f17c0`, `0x22f1888` | não resolvido (chamadas virtuais via vtable própria, slots `+0x6c8/+0x6d0` e `+0x6b8/+0x6c0`) | baixa |

As seis entradas de alta confiança novas usam o mesmo truque de evidência das quatro originais: o bloco de campos estáticos de `PersistentDataManager` é lido via `ldr x8, [x8, #0xb8]` e depois `ldr x8, [x8, #<offset>]`, onde `<offset>` bate **exatamente** com o offset de campo que `PersistentDataManager.cs` declara para aquele delegate (`0x10`=`OverrideGetFolderNameAction`, `0x18`=`TryOverrideSceneDefaultDataFileNameAction`, `0x20`=`TryOverrideFileNameAction`, `0x28`=`OnPreSaveProgressAction`, `0x30`=`OnPostSaveProgressAction`); o número e a forma dos argumentos explícitos batem com o tipo declarado do delegate em cada caso. `DestroySceneObjectsThatAreNotInTheSavedData` segue o mesmo padrão de campos do objeto delegate (`+0x18`/`+0x40`/`+0x28`), mas a partir de um campo de **instância** (`PDPrefab`, offset `0x40`) em vez do bloco estático — por isso confiança média, não alta.

**Por que `TryAddPrefabData` ficou sem alvo:** os dois sites passam pelo mecanismo completo de cache de chamada de interface do IL2CPP (sondagem de slot de cache antes do `add x0, x8, #0x138`), diferente da forma direta já confirmada em `GetDataFromRootGameObjects`/`SetPersistentData`. A própria assinatura de `TryAddPrefabData(string, SceneData)` em `PDScene.cs` não sugere um receptor `IHasPersistentData`, e a contagem de argumentos do segundo site (1 explícito) não bate nem com `GetPersistentData()` (0) nem com `SetPersistentData` (2). Descartar essa hipótese é registrado explicitamente em vez de forçar uma correspondência pela coincidência do deslocamento `+0x138`.

Testes: `python3 -m unittest discover -s tools -p 'test_recon_save_dispatch.py'` (4 OK, cobre as 18 entradas e a contagem de 6 alvos `UNRESOLVED`) e `test_recon_save_cfg.py` (5 OK).

## Lacuna de save real/captura runtime para `level8`

Não resolvida nesta rodada. Um aparelho Android (Xiaomi M2101K7BI) está conectado via ADB, mas a tela está bloqueada com o PIN/padrão pessoal do usuário — não há como desbloquear, jogar até a quadra original e forçar um save sem interação física. O app original não é debuggable (`run-as` recusa) e não há root, então um `PersistantData` de `level8` não pode ser extraído via `run-as` nem leitura direta; `adb backup` exige confirmação manual na tela do aparelho (testado: ficou pendurado esperando o toque em "Fazer backup dos meus dados"). A rodada de 2026-11-04 já havia documentado essa mesma lacuna em `docs/RECON_RUNTIME_SAVE_2026-11-04.md` ("Lacuna restante"); meta aqui é nomear o bloqueio atual com precisão, não repeti-lo como novidade.

## Critério de fechamento (sem mudança)

T030 continua parcial. O que avançou: CFG real (não apenas lista de chamadas) para 42/58 janelas com verificação explícita de limite, e cobertura de despacho indireto de 4 para 18 sites (12 com alvo de alta/média confiança, 6 documentados como indeterminados em vez de adivinhados). O que falta: estender as 16 janelas ainda não limitadas, nomear os três endereços de convergência `0x1b88980`/`0x1914dc0`/`0x1b88988`, resolver os 6 sites `UNRESOLVED`, e obter o save real ou captura runtime de `level8` quando o aparelho estiver desbloqueado.
