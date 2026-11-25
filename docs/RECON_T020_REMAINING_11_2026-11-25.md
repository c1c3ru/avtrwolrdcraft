# T020: as 11 classes restantes — causa e correcao — 2026-11-25

Continuacao de `RECON_T020_STREAMING_1.230_2026-11-24.md`. Na primeira passada, 63 das 74 classes alvo decodificaram; **11 falharam**. Agora **as 74 decodificam: 4.255 de 4.255 instancias,
`check_read=True`, 0 erros de arvore** (build instalado 1.230; 46 s, pico ~1,25 GB). Das 4.255, 176 so leem pelo caminho novo de tipos referenciados.

## As 11 e o erro de cada uma (1a passada)
- `ValueError: Failed to get ref type node` (4): `LevelSecretAvatarAnimationSolvedListener`, `LevelSecretVehicleInWorldPositionListener`, `BWYW.DailyTasksData`, `BWYW.BWYWGiftData`.
- `EOFError: read_str out of bounds` ou "Expected to read X bytes, but only read Y" (7): `LevelOutfit`, `LevelOnSpecificPairAnimationBetweenSpecificAvatars`, `LevelStaticConditionsResolver`,
  `LevelStaticConditionsResolverWithDropAreas`, `LevelStaticConditionsResolverWithParkedVehicles`, `LevelRecipeSecret`, `LevelItemConditionsResolver`.
Todas usam `[SerializeReference]` (referencia polimorfica); a classificacao antiga que separava "mesmo bug do `List<String>`" de "`SerializeReference`" estava errada para `LevelSecretAvatarAnimationSolvedListener` e `LevelOutfit`.

## Causas (tres, em ordem de descoberta)
1. **O arquivo serializado nao traz `ref_types`.** Em `level112` (e nos demais), `SerializedFile.ref_types` tem 0 entradas (arvores de tipo removidas do release). O leitor do UnityPy resolve o tipo de cada
   objeto referenciado ali e, sem a tabela, falha com "Failed to get ref type node". Mas o proprio `ManagedReferencesRegistry` do objeto traz `class`, `ns` e `asm` de cada referencia.
2. **O leitor rapido (`UnityPyBoost`, em C) nao deixa trocar a resolucao.** Para essas instancias o extrator desliga o leitor em C (`TypeTreeHelper.read_typetree_boost = None`) e substitui
   `TypeTreeHelper.get_ref_type_node` por uma funcao que gera a arvore do tipo referenciado com o `TypeTreeGenerator` (por `(assembly, namespace, classe)` lidos do registro). So as instancias que falham
   passam por esse caminho mais lento; o resto continua no leitor em C.
3. **Dois defeitos do `TypeTreeGenerator`** na arvore dessas classes:
   - emite `references: ManagedReferencesRegistry` varias vezes (uma depois de cada classe da cadeia de heranca que tem campo `managedReference`, e uma no fim). No Unity o registro existe **uma vez, no fim**.
     Ex.: `LevelStaticConditionsResolverWithParkedVehicles` saia com 4 registros. Mantem-se so o ultimo.
   - para tipos **referenciados**, emite tambem o cabecalho de `MonoBehaviour` (`m_GameObject`, `m_Enabled`, `m_Script`, `m_Name`), que nao existe nos dados de um `ReferencedObject`. Foi o que desalinhava a leitura
     (por exemplo `CurrentVehicleIDCondition` aparecia com `m_Name` de lixo). Para tipos referenciados descartam-se esse cabecalho e qualquer registro.

Diagnostico decisivo: ler uma instancia com `check_read=False` e comparar com o tamanho do objeto (344 bytes lidos 376): o `data` da referencia trazia os quatro campos de cabecalho espurios.

## Mudancas no codigo
`tools/mb_stream_extract.py`: `dedupe_registry`, `drop_registry` (cabecalho + registro nos tipos referenciados) e `read_with_ref_types` (fallback so quando aparece "ref type node"). O resto da leitura nao mudou.

## Reconciliacao com os totais antigos (`out/mb/_stats.json`, build anterior)
7 das 11 batem exatamente (`ok + err` antigo = instancias novas), por exemplo `LevelSecretAvatarAnimationSolvedListener` 79, `DailyTasksData` 45, `BWYWGiftData` 4.
4 divergem para mais: `LevelStaticConditionsResolver` (2 -> 18), `LevelItemConditionsResolver` (6 -> 24), `LevelStaticConditionsResolverWithDropAreas` (12 -> 14) e `LevelSecretVehicleInWorldPositionListener` (3 -> 4).
Nao sei se e conteudo novo do 1.230 ou se o levantamento antigo subcontava (nao rodei o build antigo com este extrator).

## Limites
- `check_read=True` mostra que cada objeto decodifica sem sobra de byte; nao valida o significado dos campos. Os tipos referenciados foram lidos com a arvore gerada do IL2CPP do mesmo build, sem comparar com uma leitura de referencia.
- Nada foi registrado na fila formal; os 30 `typetreegeneratorapi_nullref_*` e os 20 `type_stripped_*` continuam como estavam (causa na ferramenta e no binario, nao em memoria nem em `SerializeReference`).
