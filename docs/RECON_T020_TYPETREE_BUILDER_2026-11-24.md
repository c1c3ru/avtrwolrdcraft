# T020: +18 classes com type tree construido a partir do Cpp2IL — 2026-11-24

Continuacao de `RECON_T020_LOWMEM_2026-11-24.md`. Das 61 classes restantes, 30 falhavam porque o `TypeTreeGeneratorAPI` quebra (NRE) em campos `SerializableDictionaryBase<K,V>`.

## Diagnostico
O gerador funciona para o valor do dicionario (`BackSceneLoadConfig`) e para a base `DrawableDictionary`, mas **nao** para o dicionario generico nem para a classe que o contem.
Layout provado do dicionario RotaryHeart: campos da base `DrawableDictionary` (`reorderableList` sem campos + `reqReferences` PPtr, 12 bytes) e depois `_keyValues` `List<K>`, `_keys` `K[]`, `_values` `V[]`.

## Ferramenta: `tools/mb_typetree_builder.py`
Monta os nos `{m_Level, m_Type, m_Name, m_MetaFlag}` por fora: le os campos serializados no Cpp2IL (base primeiro; publicos ou `[SerializeField]`, sem `static/const/readonly/[NonSerialized]`), classifica cada tipo
(primitivos, enums int32, `Vector*`/`Color`/`Rect`, listas/arrays, classes aninhadas, `UnityEvent`, dicionario, referencia a objeto Unity = `PPtr`) e le os bytes crus com o `TypeTreeHelper` do UnityPy.
**Trava forte**: a leitura so e aceita se consumir *exatamente* `byte_size` bytes; um palpite errado falha em vez de gerar dados falsos. Bytes crus extraidos com o passe de baixa memoria (1.383 objetos, 5,6 MB).

## Resultado
18 classes (todas as instancias de cada uma leem exato) integradas em `out/mb`, `_stats.json` erros 61 -> 43:
- 14 configs do editor de avatar: `AvatarMaker{Baby,Car,Cat,Character,Dog,Horse,Toddler}{Colors,Subcategories}Config`;
- `PazuCore.DeepLink.DeepLinkManager`, `PazuCore.WindowManager`, `AFCChangePositionWIthLanguageCode`, `AFCTMPTextLineSpaceWIthLanguageCode`.
Cada uma reconcilia com `declared_counts` da fila (linhas = ok + err).
**Validacao cruzada**: `DeepLinkManager` construido = os 149 pares `link -> LevelType` da decodificacao manual independente (`tools/decode_deeplink_map.py`), identico.

## O que continua sem solucao (43 classes)
- 20 `type_stripped` (`PWC.EditorApp.*`): irrecuperaveis sem o assembly original.
- 9 `serialize_reference` (`Failed to get ref type node` / `Negative length`): exigem `ManagedReferenceRegistry`; o construtor ainda nao cobre `[SerializeReference]`.
- 12 do grupo `nullref` que o construtor ainda nao le: os 5 do `LevelPhone` (`ContactsContent`, `DeliveryContent`, `PhoneBackground`, `PhoneContentIcon`, `PhoneSeparator`, 225 instancias cada) diferem por **4 bytes**
  (ex. `PhoneSeparator`: lê 4 bytes a menos do que o objeto traz; provavel campo/tipo mal mapeado), `GameExtraSettings` (le 496 de 544), `LocalizationManager`, `AvatarMakerLobbyManager`, `LevelSkinsRandomizer`,
  `AchievementDetailThumb`, `LevelCatTunnel`, `LevelStationButton`. Nao investigados alem do primeiro erro.
- 2 `same_bug_likely_fixed` (`LevelOutfit`: le 96 de 104; `LevelSecretAvatarAnimationSolvedListener`: campo `Dictionary<int, List<string>>` nao serializavel, deveria ser pulado; os dois dependem de `ConditionResolver` (provavel `[SerializeReference]`)).

## Fila
As 18 tarefas `T020/CLASS` correspondentes continuam `pending`: submeter/aprovar exige nova autorizacao explicita.
