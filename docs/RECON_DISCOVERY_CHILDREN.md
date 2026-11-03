# Descoberta delimitada de tarefas filhas — 2026-11-02

Esta rodada executa a expansão inicial de T010 do [plano mestre](AVATAR_WORLD_MASTER_PLAN.md), aproveitando os resultados existentes. Ela transforma evidência e lacunas em pacotes de trabalho distribuíveis; não executa os 387 pacotes, não recupera automaticamente sua lógica e não altera a fila viva.

## Entregas

- [Gerador](../tools/recon_children.py): biblioteca padrão Python, sem rede, instalação, build, execução do jogo ou edição do cliente.
- [Testes](../tools/test_recon_children.py): fixtures temporárias e guardas contra promoção/duplicação indevida.
- [Manifesto](../reports/recon/discovery_children.json): `schema_version=1`, `kind=child_planning_specs`, pronto para a importação revisada na fila.

| Pai | Escopo gerado | Filhos |
| --- | --- | ---: |
| T020 | Uma correção de decodificação por classe MB com erro | 126 |
| T015 | Uma varredura por ocorrência de cena em BuildSettings | 254 |
| T021 | Revisão estreita da identidade do par native/metadata | 1 |
| T022 | Revisão estreita dos cinco joins token/owner/endereço do piloto | 1 |
| T025 | Recuperação de corpo/contrato dos cinco métodos de navegação | 5 |
| Total | Planejamento inicial delimitado | **387** |

Todos os filhos nascem `pending`, com maturidade herdada `partial`, sem dono, lease, evidência produzida ou revisão. O fato de existirem dumps, ponteiros ou nomes de cenas não os torna `done`, `ready` nem semanticamente equivalentes. Cada filho tem perguntas, passos, paths exclusivos, outputs esperados, recursos e aceite observável.

## Reaproveitamento e identidade

Entradas efetivamente lidas e vinculadas por SHA-256 no manifesto:

1. `reports/recon/baseline.json`;
2. `reports/recon/dump_coverage.json`;
3. `out/navigation-map/scenes.json`;
4. `reports/recon/il2cpp_bootstrap.json`;
5. `out/recon/il2cpp/assembly_csharp_methods.jsonl`;
6. `assets/base.apk`;
7. `out/recon/il2cpp/libil2cpp.so`;
8. `out/recon/il2cpp/global-metadata.dat`.

Cada referência filha repete o path/hash exato necessário e, quando útil, um seletor por classe, cena ou token. O seletor é uma localização para investigação, não prova de correção do conteúdo selecionado. O gerador calcula cada hash uma vez por execução e verifica se o arquivo mudou durante a leitura.

O par IL2CPP exige coincidência entre bootstrap, membro APK inventariado pelo baseline e arquivo derivado atual:

- Native: `b63661fa60c23ebef1c2da4bb5288ad787eb3da36b22d4bdf285401f1643d728`.
- Metadata: `1ea14cf5829d5c31e5e967b1608b5701020ab0d24bd4ab69d9f1e2b243467bc6`.

Isso vincula as tarefas aos bytes certos; não substitui a revisão das registrations, genéricos, corpos, CFG ou comportamento. O baseline também precisa de aceite real na fila antes de liberar as tarefas dependentes.

## Filhos de classes: manter todas as falhas

O gerador conserva as **126 classes e os 2.813 objetos com erro declarado**, incluindo causa original, contadores `ok`/`err` quando disponíveis e presença de dump existente. Ele rejeita total divergente, contador inválido, causa conflitante ou classe duplicada com dados diferentes. Repetições idênticas não geram tarefas duplicadas nem somam falhas novamente.

As tarefas exigem localizar as identidades exatas dos objetos que falharam, obter exemplo mínimo, conferir schema/alinhamento/offsets e reprocessar somente os objetos afetados. O número original de falhas é preservado como limite inicial do recorte; o worker não pode apagar falhas do denominador para apresentar sucesso.

Exemplos de famílias com maior número de erros na fonte atual: SkeletonAnimation (226), várias classes de telefone (225 cada), LevelSimpleToggleableSpine (208). As contagens servem para planejar esforço, não para decidir que classes raras podem ser ignoradas.

## Filhos de cenas: não promover inferência

Os 254 registros conservam `scene_path`, índice de build, candidato serializado, status de vínculo, presença no diretório cached e quantidade de raízes existentes. O status `INFERRED_build_index_convention_not_independently_verified` permanece intacto onde estava na fonte.

Cada filho precisa verificar independentemente o vínculo cena↔arquivo, classificar gameplay/editor/auxiliar e inventariar hierarquia ativa/inativa, scripts, controles, prefabs e referências externas. Uma lista de sprites ou um índice/nome coincidente não satisfaz seu aceite.

O gerador não reinspeciona nem reextrai o datapack inteiro. Os workers devem reutilizar cenas extraídas e materializar apenas entradas ausentes, sempre sob seus paths exclusivos.

## Pré-requisitos estreitos do piloto IL2CPP

Para não depender do fechamento completo dos pacotes gigantes T021/T022 e nem fingir que eles já terminaram, foram criados dois filhos de revisão:

```text
T001 (baseline com aceite real)
  └─ T021/PAIR/b63661fa60c2-1ea14cf5829d
       └─ T022/PILOT_INDEX/b63661fa60c2
            └─ cinco filhos de T025/METHOD/...
```

O filho de par cobre somente identidade, versão e ABI dos dois inputs. O filho de índice cobre somente cinco tokens/owners/RIDs/relocations/endereços. Sua revisão não conclui T021/T022 inteiros e não certifica semântica.

Não há dependência filha→seu próprio pai, que criaria bloqueio circular pelo fechamento implícito do pai. As tarefas de método dependem de T001 e do filho exato de índice; o índice depende do par, e o par de T001.

### Cinco métodos escolhidos

| Classe/método | Token | VA de link já mapeado |
| --- | --- | --- |
| `Game.Home.HomePlayButton.LoadPlayScene` | `0x060054ef` | `0x2057fa8` |
| `PWC.GameSceneManager.GetCurrentWorldSceneName` | `0x06005708` | `0x2073238` |
| `PWC.GameSceneManager.LoadScene` | `0x060056fe` | `0x20728d4` |
| `PWC.GameSceneManager.LoadSceneImplement` | `0x060056ff` | `0x2072cc8` |
| `PWC.World.Buildings.WorldBuilding.ClickOnLevel` | `0x06006081` | `0x2108e90` |

A seleção é por token exato, owner, nome, imagem e aridade. Token ausente/duplicado ou overload divergente gera falha. O índice de 36.421 métodos é lido por streaming, mas somente esses cinco produzem tarefas de recuperação nesta expansão. Não foram criadas dezenas de milhares de tarefas sem um piloto validado.

Os estados originais de corpo/semântica desconhecidos permanecem na especificação. Janelas de assembly já disponíveis podem ser reaproveitadas após verificar input/perfil; tamanho da janela e próximo ponteiro não provam extensão completa do corpo. Chamadas indiretas, exceções, estado e efeitos relevantes ainda precisam de análise.

## IDs, outputs e concorrência

IDs são determinísticos, sem timestamp ou posição da linha no arquivo. Classes e cenas incluem namespace de hash do APK base; métodos incluem hashes do native/metadata, imagem, token e owner. Reordenar registros de origem preserva identidades; mudar a origem altera hashes de input e pode invalidar a evidência, em vez de sobrescrever silenciosamente um trabalho aceito.

Outputs ficam sob `out/recon/tasks/<child-id>/`. Cada filho tem lock `task-output:<child-id>`. Cenas também têm lock por candidato de extração. O piloto nativo usa o recurso compartilhado exato `native-analysis:avatar-arm64`; o coordenador deve usar esse mesmo nome para tarefas que disputem o mesmo banco, ou redefini-lo explicitamente de forma consistente antes dos claims. Nomes diferentes não fornecem exclusão entre si.

`allowed_paths` e recursos são contratos para o worker; quem impõe autorização e execução é o ambiente e a fila. O gerador não abre decompilador nem assume que o provedor nativo está disponível.

## Reprodução e importação

```bash
python3 -m unittest discover -s tools -p test_recon_children.py -v
python3 tools/recon_children.py

# Importar somente depois da revisão pelo coordenador:
python3 tools/recon_queue.py import-children \
  --manifest reports/recon/discovery_children.json \
  --actor coordenador --note 'Expansão inicial delimitada e revisada'
```

O último comando é uma instrução para o coordenador, não uma operação executada pelo gerador. Uma fila já importada deve rejeitar IDs repetidos, não duplicar as tarefas. Pais precisam estar inativos e incompletos para receber expansão de escopo.

## Validação desta entrega

**17 testes passaram**, cobrindo: escopo limitado, nenhum estado concluído, IDs estáveis, regeneração determinística, deduplicação idêntica, conflito de identidade, contadores/causas, preservação de falhas, cenas inferidas, tokens/overloads, índice inválido, par de bytes incompatível, dependências sem pai, outputs exclusivos e paths que escapem da raiz.

A execução real gerou os 387 filhos e preservou exatamente os 2.813 erros declarados, sem alterar a fila global. O manifesto tem aproximadamente 1,4 MB; os workers devem ler apenas a tarefa atribuída e seus seletores, não transportar o manifesto inteiro como contexto de cada agente.

Uma importação real foi verificada **somente em cópia temporária da fila**: 447 tarefas totais, 387 filhos, todos `pending`, referências e grafo aceitos. Essa verificação levou 38,632 segundos na implementação que relia referências repetidas por filho; o coordenador foi informado para reutilizar, apenas dentro da mesma operação, a verificação de cada path/hash único. Isso não permite um cache global que ignore alteração de input.

Gerar ou importar tarefas não executa a varredura nem recupera a lógica. Os marcos V/L/C permanecem abertos; a próxima ação é revisar o baseline e os dois pré-requisitos estreitos para liberar o piloto enquanto agentes independentes tratam cenas e falhas de decodificação.
