# T030 — persistência runtime do original

## Escopo

Esta rodada comparou o contrato estático de persistência com arquivos reais do Avatar World 1.227 (build 228) em um aparelho conectado. A coleta foi somente leitura. Os 81 arquivos de `PersistantData` foram copiados para `/tmp`; nenhum save bruto foi adicionado ao repositório.

O relatório sanitizado e reproduzível está em `out/recon/tasks/T030/runtime-save-summary.json`. Ele conserva hashes, schemas, contagens e faixas agregadas, mas omite GUIDs, nomes de instâncias e valores individuais. A ferramenta é `tools/recon_runtime_save.py`.

## Formato observado

Foram encontrados cinco saves JSON de cena: três níveis regulares e os mapas `World` e `College`. Todos usam as mesmas quatro chaves raiz:

- `Prefabs`: objeto que associa GUID de prefab a uma lista de instâncias serializadas;
- `SceneObjects`: objeto indexado por GUID ou nome estável da cena;
- `NewAndSyncedSceneObjects`: lista de objetos novos/sincronizados;
- `BuildNumber`: número da build, observado como `228` nos cinco arquivos.

Cada entrada de `SceneObjects` contém um ou mais payloads nomeados. O valor de cada payload é outra string JSON, por exemplo `TransformPD`, `LevelItemPD`, `GameCameraPD`, `LevelCharacterPD` ou handlers específicos. Os cinco arquivos foram decodificados sem payload inválido.

## Contagens observadas

| Save | Prefabs | Instâncias | SceneObjects | New/synced |
|---|---:|---:|---:|---:|
| `Level_Garage_L232` | 60 | 153 | 279 | 0 |
| `Level_MainCampusHallways_F1_L198` | 113 | 149 | 213 | 0 |
| `Level_TalentShow_Z2B4L1` | 13 | 21 | 199 | 5 |
| `College` | 0 | 0 | 1 | 0 |
| `World` | 118 | 133 | 496 | 0 |

`World` contém 133 `TransformPD`; todos têm parent e posição decodificáveis. As posições agregadas ficam em x `[-0,00000449; 4,51683]` e y `[-0,000000238; 1,45580]`. Isso comprova persistência de objetos adicionados às grades do mapa, sem publicar suas posições individuais.

## Comparação World ↔ level4

O piloto estático `out/recon/tasks/T030/scene-pilot.json` contém 41 `PDSceneObject` da cena `level4`. O save runtime `World` tem 496 chaves; 13 coincidem com as chaves estáticas, 28 chaves estáticas não aparecem no arquivo e 483 chaves existem apenas no save.

Essa distribuição é coerente com um arquivo de estado seletivo mais objetos instanciados em runtime. Portanto, ausência de um GUID estático no save não permite concluir que o objeto não existe na cena, e `runtime_only` não significa divergência: prefabs geram novos GUIDs legitimamente.

## Despachos indiretos verificados

`tools/recon_save_dispatch.py` verifica quatro call sites contra as janelas AArch64 e as declarações Cpp2IL. O resultado está em `out/recon/tasks/T030/save-dispatch-contract.json`:

| Call site | Contrato | Estado |
|---|---|---|
| `0x21e2520` | `TryOverrideFileNameAction.Invoke(Scene, out string)` | shape de delegate verificado |
| `0x21e1654` | `IHasPersistentData.GetPersistentData()` | shape de interface verificado |
| `0x21e54f8` | `IHasPersistentData.SetPersistentData(allData, sceneObjects)` | shape de interface verificado |
| `0x21e2eac` | `OnDataLoadedAction.Invoke(Scene)` | shape de delegate verificado; alvo semântico com confiança média |

Os despachos de interface comprovam a chamada do contrato, não enumeram todas as implementações concretas presentes em runtime. Os delegates comprovam a assinatura/campo, não os subscribers instalados naquela sessão.

## Validação

```text
python3 -m unittest discover -s tools -p 'test_recon_runtime_save.py' -v  # 3 OK
python3 -m unittest discover -s tools -p 'test_recon_save_dispatch.py' -v # 3 OK
```

## Lacuna restante

Não havia save da quadra/`level8` no aparelho. Logo, esta rodada não compara placar, bolas e posições dessa cena específica. O próximo teste dinâmico delimitado é abrir a quadra no app original, alterar um único estado observável, sair para forçar save e comparar antes/depois de modo sanitizado. Até isso ocorrer, T030 permanece parcial e nenhuma implementação offline deve alegar equivalência completa.
