# T020 — causa-raiz das 126 classes com erro de dump de MonoBehaviour

`reports/recon/dump_coverage.json` registra 126 classes/tipos que falham ao ler o typetree com
`tools/mb_dump.py` (`TypeTreeGenerator` da `UnityPy`, que gera o layout de campos a partir do IL2CPP
dumpado - `il2cpp_in/libil2cpp.so` + `global-metadata.dat`). Até agora isso ficava registrado só como
contagem; este dossiê isola **por que** cada classe falha, sem reprocessar o bundle de 1,3 GB inteiro -
só a geração do typetree (leve, poucos minutos). Ferramenta: `tools/diagnose_dump_errors.py` (resolve o
assembly real de cada classe via `MonoScript`, igual `mb_dump.py` faz no dump completo - uma primeira
versão fixava `assembly="Assembly-CSharp"` e produzia 2 falso-positivos, corrigido). Resultado completo em
`out/recon/tasks/T020/error_class_diagnosis.json`.

## Resultado

| Status | Classes | O que significa |
|---|---|---|
| `ok` (gera typetree normalmente) | 76 | A falha real (vista no dump completo) é no **tamanho em bytes** declarado vs. lido, não na geração do typetree em si. |
| `python_exception` — tipo não encontrado na metadata IL2CPP | 20 | O gerador nem encontra o tipo. |
| `python_exception` — `Object reference not set to an instance of an object` (NullReferenceException dentro do próprio gerador) | 30 | O gerador encontra o tipo mas quebra ao montar os nós. |

### 1. Tipo não encontrado (20) — confirmadas irrecuperáveis

Todas do namespace `PWC.EditorApp.*` (`EASUTEManager`, `EAHierarchyPanel`, `EALevelEditorPanel`,
`EASearchPanel`, `EALoginPanel`, `EACAMenuInfo`, ... lista completa com `status=python_exception` e
`"not found in the IL2CPP metadata"` em `out/recon/tasks/T020/error_class_diagnosis.json`): a ferramenta
de editor de nível interna do estúdio original. O IL2CPP de um build de jogador faz *code stripping* de
qualquer coisa nunca referenciada em runtime; como o editor nunca roda no app publicado, essas classes
ficaram sem metadata de método/campo no binário, só como referência órfã nos dados serializados. **Isso
não é recuperável** sem o assembly original (não publicado) do editor - documentar e não tentar mais.

Numa primeira passada com o assembly fixo em `Assembly-CSharp`, `Spine.Unity.SkeletonAnimation` e
`Spine.Unity.SkeletonDataAsset` também caíam aqui - **falso-positivo do diagnóstico**, não do
`mb_dump.py` real: essas classes vivem no assembly `spine-unity`, não `Assembly-CSharp`. Resolvendo o
assembly por classe (via `MonoScript`, como a versão atual de `tools/diagnose_dump_errors.py` já faz) as
duas geram o typetree normalmente - consistente com `dump_coverage.json` mostrar a maioria das instâncias
de `SkeletonAnimation` já lida com sucesso (1737 ok / 226 erro): o tipo existe e resolve; a falha real
desses 226 tem outra causa (possivelmente o item 3 abaixo) e não foi isolada aqui.

### 2. NullReferenceException no gerador (30) — 27 com a mesma causa confirmada

Comparando o código fonte recuperado pelo Cpp2IL (`out/cpp2il/DiffableCs/`) das 30 classes, **27**
declaram um campo `[SerializeField] SerializableDictionaryBase<TKey, TValue> algumNome` (dicionário
serializável customizado, não suportado nativamente pelo Unity) - confirmado lendo o `.cs` de cada uma
(classes com status `python_exception` e mensagem "Object reference" em `error_class_diagnosis.json`; `grep -c SerializableDictionaryBase` bate 1 em 27
delas, 3 em `LevelSkinsRandomizer`). Dois exemplos diretos:

```csharp
// PWC/AvatarMaker/AvatarMakerDogColorsConfig.cs (14 classes AvatarMaker*ColorsConfig/*SubcategoriesConfig
// seguem este padrao: Baby/Car/Cat/Character/Dog/Horse/Toddler x Colors/Subcategories)
[SerializeField] private SerializableDictionaryBase<DogCategoryType, AWSpineColorsList> _colorsByCategoryType;

// PWC/LevelPhone/PhoneBackground.cs (cluster de 6: PhoneBackground, PhoneContentIcon, PhoneSeparator,
// ContactsContent, DeliveryContent, AchievementDetailThumb)
[SerializeField] private SerializableDictionaryBase<ApplicationType, ApplicationBackgroundData> _backgroundColors;
```

O `TypeTreeGenerator` da UnityPy não resolve essa instanciação genérica customizada e quebra com
`NullReferenceException` nativa (mensagem da própria lib: "Error generating tree nodes: Object reference
not set to an instance of an object."). **Um único root cause explica 27 das 126 falhas (21%)**. Corrigir
exigiria ensinar o gerador (ou um pós-processamento em `tools/mb_dump.py`) a tratar
`SerializableDictionaryBase<TKey,TValue>` como um par `List<TKey>`/`List<TValue>` (layout usual desse
padrão) - não tentado aqui: precisa primeiro achar e ler a definição de `SerializableDictionaryBase` nos
dumps (provavelmente em outro assembly/pacote) para confirmar o layout exato antes de hard-codar.

As outras 3 (`PazuCore.GameExtraSettings`, `PazuCore.LocalizationManager`, `PazuCore.WindowManager`) têm a
mesma mensagem de erro mas **não** usam `SerializableDictionaryBase` nos campos vistos no `.cs`
decompilado - causa raiz ainda não isolada para essas três. Hipótese não verificada: campos `Func<T>`/
delegate estáticos (`WindowManager` tem `public static Func<Boolean> OnBackButtonAction`) podem confundir
a enumeração de campos do gerador antes do filtro de estáticos, mas isso não foi testado contra as 27 já
explicadas nem descartado para elas.

### 3. Typetree gera ok, mas o dump real falha por tamanho (76) — hipótese não verificada

Não investigado a fundo aqui (exigiria reler trechos do bundle de 1,3 GB para comparar). Hipótese mais
provável, a partir dos exemplos em `dump_coverage.json` (ex.: `LevelStationaryPlant` "esperava 320 bytes,
leu 252"): jogo live-service com anos de atualização, então cenas antigas no `datapack.unity3d` podem
conter instâncias serializadas com uma versão **anterior e menor** da classe (menos campos) do que a
versão atual compilada no `libil2cpp.so` usado aqui - o typetree gerado reflete a classe atual e não bate
com dado serializado antigo. Não confirmado; precisa de uma amostra lida byte a byte para validar.

## O que isso muda para T020

- **20 classes `PWC.EditorApp.*`**: marcar como `unknown` permanente/não recuperável na fila formal (sem o
  assembly original do editor, não há como reconstruir), não como pendência de retrabalho.
- **2 classes Spine (`SkeletonAnimation`/`SkeletonDataAsset`)**: eram falso-positivo de uma primeira versão
  do diagnóstico (assembly fixo errado); já corrigido - resolvem normalmente, contam como `ok` acima. Não
  marcar como irrecuperável.
- **27 classes com `SerializableDictionaryBase<TKey,TValue>`**: uma única correção potencial (ensinar o pipeline sobre esse tipo)
  resolveria todas de uma vez; candidata a próximo passo de maior alavancagem, mas exige achar o layout
  real do tipo antes de implementar (não feito nesta rodada).
- **3 + 76 = 79 classes**: causa ainda não fechada; ficam como estavam, com hipóteses registradas acima
  para quem continuar.
- Nenhum dado de `out/mb/*.jsonl.gz` foi reprocessado nesta rodada; isto é só diagnóstico de causa, sem
  mudança de cobertura numérica em `reports/recon/dump_coverage.json`.
