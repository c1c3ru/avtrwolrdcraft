# Primeira onda: baseline e reconciliação de evidências

Execução em 2026-11-01 por `tools/recon_baseline.py`, cobrindo o recorte inicial de T001, T003 e T005. Evidência `STATIC_local_tools`; nenhuma instalação, execução do jogo, build Unity ou modificação do cliente foi realizada por este coletor. Tarefas maiores continuam parciais até revisão e fechamento das lacunas abaixo.

## Artefatos identificados e verificados

Os três APKs de `assets/` declaram `com.pazugames.avatarworld`, versionCode **228**. A base declara versionName **1.227**. Os splits declaram `config.arm64_v8a` e `UnityDataAssetPack`; o versionName vazio nos splits não foi confundido com versão incompatível.

`aapt2 dump badging` e `apksigner verify --print-certs`, do Android SDK local, concluíram com código zero para os três arquivos. Os certificados SHA-256 dos signers coincidem. Isso comprova consistência estática de pacote/versão/assinatura dos inputs locais; não comprova origem oficial ou disponibilidade atual dos serviços.

| Input | SHA-256 |
| --- | --- |
| `assets/base.apk` | `c7edf76ff14254ecab9dc4162962f5d49d8e13be6e2e74e38f7d992f8c77ca07` |
| `assets/split_UnityDataAssetPack.apk` | `66fd0e2732064ddfeaf2d4f596b8f25d81376a703e7b5878c2d9585c5e3ec792` |
| `assets/split_config.arm64_v8a.apk` | `5c304f889fe02d6544071d5504a275be66c4235ff839b53022a746651cdc71d5` |
| Metadata, membro da base `assets/bin/Data/Managed/Metadata/global-metadata.dat` | `1ea14cf5829d5c31e5e967b1608b5701020ab0d24bd4ab69d9f1e2b243467bc6` |
| Código, membro do split ABI `lib/arm64-v8a/libil2cpp.so` | `b63661fa60c23ebef1c2da4bb5288ad787eb3da36b22d4bdf285401f1643d728` |

`apk/base.apk` é byte-idêntico à base em `assets/`. O inventário também identifica e faz hash dos membros nativos `lib_burst_generated.so`, `libmain.so`, `libpairipcore.so` e `libunity.so`. Nenhuma proteção foi contornada.

Os hashes de native/metadata são calculados diretamente do conteúdo descomprimido dos membros ZIP, sem materializar o binário. O datapack gigante recebe inventário de tamanho/CRC; este coletor não descomprime e verifica integralmente todos os seus membros. A recuperação das registrations e o vínculo método→endereço pertencem às próximas tarefas IL2CPP.

## MonoBehaviours: contagem realmente reconciliada

Foi recontado o conteúdo JSONL de todos os dumps declarados em `out/mb/_stats.json`, por streaming:

| Medida | Resultado |
| --- | ---: |
| Classes no `_stats.json` | 2.418 |
| Objetos declarados `ok` | 879.085 |
| Linhas JSONL efetivamente lidas | 879.085 |
| Objetos declarados `err` | 2.813 |
| Total declarado (`ok + err`) | 881.898 |
| Classes com mensagem de erro | 126 |
| Classes com divergência entre `ok` e linhas reais | 0 |
| Linhas sem `_file`/`_path_id` | 0 |
| Identidades duplicadas dentro da mesma classe | 0 |

As 126 falhas não foram descartadas nem resolvidas por essa contagem. O relatório contém causa e contadores por classe, incluindo `PazuCore.GameExtraSettings`, `PazuCore.GameSettings`, `PWC.Inventory.InventoryBuildData` e `PazuCore.WindowManager`.

Essa etapa verifica legibilidade, identidade e contagem dos dumps antigos. Não confirma layout correto dos campos, proveniência completa ao par atual de APKs, nem colisões de identidade entre classes diferentes. Corrigir cada parser/typetree e reextrair somente os objetos afetados continua necessário para T005/T020.

## Evidências existentes aproveitadas

- Navegação: preservado o relatório das 254 cenas e dos 115/101 destinos. O coletor registra hashes dos resultados e não o reinterpreta como recuperação dos corpos IL2CPP.
- Avatares: identificados os inventários/probes Spine, GPU, CPU e outfit existentes para reutilização. Eles mantêm seus escopos originais.
- Economia: preservadas as regras offline autorizadas, `OfflineHomeService`, testes e integração existentes. Não há motivo para recomeçar essa implementação.
- Testes: **30 XMLs históricos** foram identificados e analisados. `out/test-results-offline-home.xml` declara **71/71 Passed**, zero failed/skipped, execução de 2026-11-01 14:48:39Z a 14:48:42Z.
- O coletor encontrou fontes atuais posteriores a esse XML: `HomeActions.cs`, `StoreVisualView.cs` e `HomeActionsTests.cs`. Mtime é somente um alerta, não prova de alteração semântica. O XML não contém manifesto dos hashes do source/build: portanto não certifica a revisão corrente.
- Builds locais recebem hash e classificação `UNKNOWN_no_build_input_manifest`; existência de APK não vincula automaticamente source atual, teste e observação Android.

O manifesto de fontes registra hashes dos `.cs` em `Assets/Scripts` e `Assets/Tests`. A captura é sequencial, não um checkout atomicamente congelado; cada arquivo é conferido antes/depois da leitura. O git status capturado também preserva a indicação de alterações preexistentes, sem atribuí-las a esta onda.

## Saídas e reprodução

- [Coletor](../tools/recon_baseline.py).
- [Baseline](../reports/recon/baseline.json): hashes por input, pacote/splits, SDK, comandos, assinaturas e snapshot git.
- [Trabalho existente](../reports/recon/existing_work.json): source manifest, resultados históricos, probes e builds.
- [Cobertura de dumps](../reports/recon/dump_coverage.json): contagem por classe e fila de 126 falhas.

```bash
# Revalidação completa de hashes e contagens, sem confiar no atalho por stat.
python3 tools/recon_baseline.py --verify

# Reuso incremental; alteração de input invalida a parcela correspondente.
python3 tools/recon_baseline.py
```

O primeiro passe completo terminou com código zero em **60,616 s**, com **2.385 hashes por streaming**. Após endurecer o perfil de invalidação por hash do coletor e das ferramentas, a inspeção/recontagem afetada foi refeita. A execução incremental estável seguinte terminou em **0,524 s**, reaproveitando os 2.385 hashes por fingerprint inalterado e as inspeções do mesmo hash/perfil.

O atalho incremental usa device/inode/tamanho/mtime/ctime para decidir se reaproveita um SHA-256 previamente calculado. Isso economiza leitura, mas não é uma prova contra mudança adversarial que preserve todos esses atributos; `--verify` força leitura independente. Mudança no hash do coletor ou da ferramenta invalida a inspeção/recontagem correspondente.

Os JSONs são gravados atomicamente por arquivo. Não representam uma transação atômica conjunta dos três relatórios nem snapshot integral do cliente enquanto outro agente o edita. Rodar a coleta numa revisão congelada será necessário para aceite final.

## Verificações de comportamento do coletor

Uma fixture temporária independente, sem APK real nem Android, simulou os outputs do SDK apenas para exercitar gates:

1. identidade/assinatura reconhecidas e contagem exata;
2. execução repetida reaproveita cache somente sob mesmo hash/perfil;
3. identidade duplicada no gzip é detectada;
4. input alterado com menos linhas produz divergência de contagem;
5. gzip corrompido lança falha, sem sucesso fictício.

Esses testes do coletor não são evidência de funcionamento do Avatar World. Os resultados reais de pacote/assinatura acima vieram das ferramentas Android, não dessas simulações.

## Estado para o coordenador

- **T001:** pacote/splits/assinatura/hashes e cópia local identificados; falta consolidar baseline de execução/build e revisão independente antes de aceitar o pacote pai.
- **T003:** trabalho atual inventariado e evidências históricas separadas; faltam reconciliação completa de requisitos/artefatos e vínculo source↔build↔teste/replay.
- **T005:** números e identidades dentro de cada classe conferidos; as 126 falhas, layouts e proveniência permanecem pendentes.
- **Próximo passo:** usar hashes exatos do native/metadata para T021; criar filhos por classe com erro e investigar parsers críticos; conservar economia/editor já implementados.

Nenhum marco V/L/C está concluído por esta coleta. Não foi editada a fila global nem atribuída uma aprovação independente ao próprio resultado.
