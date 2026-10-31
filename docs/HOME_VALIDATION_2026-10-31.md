# Revisão e validação da Home — 2026-10-31

## Estado preservado e inventário

Base local: `9dbe1b52`, branch `main`, inicialmente sem diferenças no Git. Não houve checkout, merge ou reset. Mantidos os ajustes locais de layout EnvelopeParent, TMP, raycast, orientação, desafios com saída/conclusão, efeitos de moeda e áudio.

Inspeção também dos arquivos ignorados: `assets/textures_png` (121647 arquivos), `assets/audio_wav` (2781), `assets/spine_textasset` (2313), APKs/splits e arquivos compactados; os arquivos extraídos não são automaticamente salas executáveis. Busca por `.unity`, excluindo caches: Home, SampleScene e URP2DSceneTemplate; cópias iguais de nomes na worktree antiga `.claude/worktrees/agent-a57b3db23a807ebd4`. Não há salas do cliente em `Assets/Scenes/Worlds`. Catálogo local existe na raiz (`store_catalog.json`), mas não há interface de loja nem preços reais confirmados. Não tratamos isso como catálogo ausente do disco.

Durante a execução apareceram `Resources/Icons/quiz_panel.png` e `.meta`, produzidos fora desta alteração. Preservados, não incluídos no commit desta correção.

## Revisão do PR #1

URL informada `c1c3ru/avtrworldcraft` retornou 404. Revisado o [PR do origin](https://github.com/c1c3ru/avtrwolrdcraft/pull/1), head `f1af061d1b47a56a1fcceef8ac9b41d5b062ae7c`, base `b3bd9a33`, em rascunho.

Achados:

- Aplicar HomeBootstrap do PR substituiria o Play funcional por uma lista vazia de salas. Integração mantém os desafios existentes.
- HomeActions do PR carregava outro PlayerState. Integrado com referência ao mesmo estado usado pelo serviço de alfabetização, evitando salvar saldo antigo sobre recompensas novas. Recarregar uma cópia isolada foi removido.
- `RemoveAllListeners` removeria o clique sonoro já existente; integração preserva listeners.
- A adição indiscriminada de Image a botão com texto reintroduziria o conflito TMP já corrigido localmente. UiSceneBuilder local preservado.
- Avisos de indisponibilidade e testes que apenas comprovam a abertura desses avisos não demonstram implementação das funcionalidades.
- Código novo do PR consultava `SaveStore.Exists`, inexistente na base local. Não importado.

Aproveitados o painel com rolagem/voltar, tratamento de Escape, perfil local e preferência persistente de som, adaptados ao estado atual. Nenhuma alteração remota no PR nem merge realizado.

## Funcionalidades e pendências

- Play: abre a alfabetização existente, sem permitir duas telas simultâneas.
- Conta: saldo/pontos atuais e salvamento real do estado compartilhado.
- Configurações: mute global persistente e reversível.
- Ícone de conquistas: consulta progresso local dos desafios; não reproduz conquistas do original.
- Demais 35 Button exportados: explicitamente desabilitados e listados em `HomeActions.PendingButtons`. Incluem botões internos de menus ocultos, não 35 recursos visíveis. Sem modal de aviso contado como implementação.
- Pendentes: loja e inventário visual, preços/configuração dos itens, presentes, roupas, passes/promoções, salas jogáveis, multiplayer, nuvem/login, idiomas e reset. Os serviços econômicos existentes estão testados, mas não equivalem a uma loja completa. Não foram criados preços fictícios para conectar compras.
- AFC, safe area e fidelidade visual de todos os estados continuam pendentes. Layout proporcional aprovado anteriormente pelo usuário foi preservado.

## Testes e build

Unity 6000.6.6f1, EditMode: **47 testes aprovados, zero falhas, zero ignorados**. Inclui cinco novos testes: Play chama gameplay, salvar após recompensa usa saldo atual, recursos sem implementação ficam pendentes/desabilitados, mute persiste e reverte, progresso reflete o estado compartilhado.

Evidências locais ignoradas no Git: `out/test-results-home.xml`, `out/unity_home_tests.log`. O log contém avisos de inicialização gráfica/tutorial em `-nographics`; a suíte terminou com resultado Passed. Primeira tentativa foi bloqueada pelo sandbox (licença/sockets); execução fora do sandbox concluiu. Testes EditMode não comprovam toque físico, rolagem nem qualidade visual no Android.

Comandos usados (a partir da raiz):

```sh
unity test client/AvatarWorldClient --mode EditMode --output "$PWD/out/test-results-home.xml" -- -nographics -logFile "$PWD/out/unity_home_tests.log"
unity run client/AvatarWorldClient --no-tail --log-file "$PWD/out/unity_home_build.log" -- -nographics -executeMethod AvatarWorld.EditorTools.ProjectSetup.BuildAndroidDevelopment
```

### APK e validação no aparelho

BuildPipeline: **Succeeded**; CLI terminou com código 0. APK `client/AvatarWorldClient/Builds/AvatarWorldOffline-dev.apk`, 59.473.626 bytes, SHA-256 `a682e936fb4f59e0c68864feeaf952efa65047a896539a3495f5ba63e3b14b08`. O APK permanece ignorado no Git. Pacote `com.c1c3ru.avatarworldoffline`, IL2CPP/ARM64; o runtime reporta min API **26**, embora ProjectSetup solicite 24 (compatibilidade Android 24/25 não comprovada).

Instalação `adb install -r`: Success, sem limpar dados. Aberto em Xiaomi M2101K7BI, Android 13/API33, 2400x1080 em paisagem. Conferidos por toque ADB e screenshots reais:

- Home com fundo cobrindo o viewport e controles visíveis.
- Engrenagem abre configurações; mute muda o rótulo e persiste `home.sound.enabled=0` no PlayerPrefs. Restaurado para ligado ao final. A saída sonora física não foi medida nesta sessão.
- Voltar Android fecha o painel.
- Conta abre perfil com 55 moedas e 0 pontos; Salvar grava estado com as mesmas 55 moedas e mantém histórico/desafio `letter-B`.
- Play abre o desafio existente e X retorna à Home.
- Widget inferior direito (`AchievementsAppWidget`) abre progresso: 1 desafio concluído, 55 moedas, `letter-B`. Retorno à Home confirmado.

Evidências locais: `out/home-settings-validation.png`, `out/home-profile-validation.png`, `out/home-play-validation.png`, `out/home-progress-validation.png`, `out/home-device-validation.log`.

Pendência observada no log do processo: `java.lang.ClassNotFoundException` para `com.google.android.play.core.assetpacks.AssetPackManager` na inicialização. O aplicativo prosseguiu e os fluxos acima funcionaram; causa/correção ainda não investigada. Não alegamos zero exceções. Também há mensagens do driver gráfico/MIUI. Não encontrados NullReferenceException nem erros de montagem UiSceneBuilder no log capturado. Rolagem longa, outras proporções/safe areas, falhas físicas de armazenamento e conclusão de uma rodada inteira não foram revalidadas neste aparelho nesta sessão.

A compilação do assembly Android terminou às 15:46:13 (-03). A edição simultânea de `LiteracyChallengeScreen.cs` foi gravada depois (15:46:46), portanto essas alterações posteriores de alfabetização não são validadas por este APK nem pelos 47 testes anteriores. Preservadas no diretório de trabalho e excluídas do commit desta correção, junto com `quiz_panel.png`/`.meta`. O APK corresponde ao estado local no momento do build, não a um clone limpo garantido; reproduzir integralmente esses assets ainda requer os arquivos locais documentados.
