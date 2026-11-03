# Retomada e callback de LoadScene — 2026-11-03

Checkout atualizado por fast-forward de `b3bd9a3` para `33d592e` após localizar no remoto os avanços de 02/11. A fila permaneceu na revisão 16 (3 done, 444 pending); nenhuma tarefa foi promovida por esta investigação.

## Recuperação do ambiente

O cache ignorado `out/recon/il2cpp` não estava neste checkout. Criados links locais `assets/base.apk` e `assets/split_config.arm64_v8a.apk` para os APKs correspondentes em `apk/`. O bootstrap reconstruiu os índices e confirmou os hashes já documentados do binário e metadata. Relatórios aceitos foram preservados; novas saídas estão em `out/recon/resume-2026-11-03/`.

Comandos executados:

```bash
python3 tools/recon_il2cpp.py --report out/recon/resume-2026-11-03/bootstrap.json
python3 -m unittest discover -s tools -p 'test_recon_*.py'
python3 tools/recon_navigation.py --output out/recon/resume-2026-11-03/navigation --report out/recon/resume-2026-11-03/navigation_contract.json
python3 tools/recon_callback_probe.py
python3 -m unittest discover -s tools -p 'test_recon_callback_probe.py' -v
```

Resultado: 73 testes existentes passaram; depois, os dois testes novos do callback passaram, incluindo rejeição de índice adulterado para o callee local. São verificações estáticas, não execução do original. O LLVM objdump disponível está no NDK do Unity, em `~/Unity/Hub/Editor/6000.6.6f1/Editor/Data/PlaybackEngines/AndroidPlayer/NDK/toolchains/llvm/prebuilt/linux-x86_64/bin/llvm-objdump`.

## Nova evidência estática

`<LoadScene>b__0`, token `0x0600570f`, VA `0x2073488`, offset `0x206f488`. Janela delimitada pelo próximo método metadata em `0x207378c`; esse limite não comprova corpo/CFG completo. O probe verifica o par por SHA-256 e reconfere nomes, tokens e ponteiros dos callees contra metadata e módulo codegen.

- `0x20734f8`: chamada confirmada a `System.String.op_Inequality`; o segundo argumento vem do literal **Home**, recuperado pelo GOT `0x41b0f60` e metadata usage.
- Se a comparação retorna bit zero, `0x20734fc` desvia ao caminho local em `0x2073578`. A leitura de `this+0x18` em `0x2073500` seguida de CBZ também leva a esse caminho. O campo corresponde a `considerMultiplayer` na declaração Cpp2IL.
- O caminho local lê `this+0x10` (declarado `sceneName`) e chama `GameSceneManager.LoadSceneImplement` em `0x2073590`, retornando em `0x20735a8`.
- Há outro guard em um campo estático ainda sem identidade semântica fechada. `MPManager.IsHostAndOnlyPlayer` é chamado em `0x2073570`: resultado com bit 0 ligado segue também o caminho local.
- O caminho multiplayer inclui chamadas confirmadas a `Guid.NewGuid`, `Guid.ToString`, `MPManager.IsHost`, construtor de `MPData_SceneChangeRequest`, `GetActiveSceneId`, `SendWaitForPlayerForSceneChangeRequest` ou `TrySendEvent`, `DestroyAllGameObjectsInLoadedScenes`, `GetPlayerUID` e `ClearPlayerFromScenes`.
- Em `0x2073654..0x207365c` e `0x20736c4..0x20736cc`, o código usa `mp_nextSceneId` (`this+0x20`) se não nulo, senão `sceneName`. String vazia não equivale a nulo nesse teste.

Isso reduz a lacuna do callback; não fecha genéricos de IsSceneAvailable, destino virtual do fade, efeitos dos helpers, exceções, subscritores ou ciclo completo de loading. Não houve envio de eventos multiplayer, alteração do cliente nem revisão independente deste lote. Saída reproduzível: `out/recon/load_scene_callback.json`.

## Aparelho

Cliente `com.c1c3ru.avatarworldoffline` instalado em 02/11 abre e mostra a Home. A tentativa de atualizar com o APK antigo de 30/10 foi recusada por `INSTALL_FAILED_UPDATE_INCOMPATIBLE`; nenhum app foi removido. Captura e logs em `out/validation/2026-11-03/`. A captura não valida o checkout atualizado: ainda falta ligar fonte, build e assinatura ao APK do aparelho. Logs incluem classe Play Asset Delivery ausente e avisos de shaders URP; não foram resolvidos nesta rodada.

Próximo passo: integrar este callback ao contrato guardado de navegação, fechar o guard estático e a ligação do delegate, depois investigar os callees genéricos/dispatch virtual pendentes. Preservar relatórios aceitos e exigir revisão antes de promover tarefas.
