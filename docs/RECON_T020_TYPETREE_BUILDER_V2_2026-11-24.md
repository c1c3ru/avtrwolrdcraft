# T020: +9 classes (LevelPhone e outras) com o construtor v2 — 2026-11-24

Continuacao de `RECON_T020_TYPETREE_BUILDER_2026-11-24.md` (que fica congelado: e evidencia hasheada das 18 tarefas aceitas).

## Causa da diferenca de 4 bytes: bug da v1
A v1 procurava atributos (`[SerializeField]`, `[NonSerialized]`) nas **4 linhas acima** de cada campo e acabava pegando o atributo do campo *anterior*, incluindo campos que o Unity nao serializa.
Exemplo, `PhoneSeparator` (116 bytes): `private int _tweenID;` nao tem atributo proprio, mas a janela incluia o `[SerializeField]` do campo acima; a v1 lia 4 bytes a mais.
Reorganizando os bytes crus o objeto fecha **exatamente** com: cabecalho (32) + `_image` PPtr (12) + base do dicionario (PPtr nulo, 12) + tres listas (`_keyValues`, `_keys`, `_values` com 2 `Color`) e **nenhum** byte para `_tweenID`.
Correcao: `tools/mb_typetree_builder_v2.py` usa so os atributos **contiguos** imediatamente acima do campo.

## Resultado
Rodando a v2 sobre os 1.383 objetos crus: **27 classes** leem exato com valores plausiveis (as 18 ja aceitas, identicas na v2 = regressao 18/18, mais **9 novas**), todas com o layout natural (`m_Name` presente, base do dicionario do Cpp2IL),
sem nenhuma variante forcada:
`PWC.LevelPhone.{ContactsContent, DeliveryApp.DeliveryContent, PhoneBackground, PhoneContentIcon, PhoneSeparator}` (225 instancias cada), `Game.Level.MovingTraingBackground.LevelStationButton` (12), `PWC.AvatarMakerLobby.AvatarMakerLobbyManager` (1),
`PWC.Level.LevelSkinsRandomizer` (3), `PWC.LevelPhone.AchievementsApp.AchievementDetailThumb` (1). Total 1.142 instancias, todas reconciliam com `declared_counts` da fila.
`PhoneContentIcon`, que a v1 lia errado (valores lixo), sai agora coerente: `_image` aponta para 213 objetos distintos (pathID 996..9427) e o dicionario tem uma referencia nula e outra para outro arquivo (`fileID 4`).
Dados em `out/mb/<Classe>.jsonl.gz`; estatisticas em `out/mb/_stats_addendum_2026-11-24b.json` (o `_stats.json` fica congelado: editar quebraria o `relocate` da fila, que revalida os hashes das tarefas `done`).

## Restam 34 classes
- 20 `PWC.EditorApp.*` (tipo removido do binario): irrecuperaveis sem o assembly original.
- 9 `serialize_reference` e 3 com `ConditionResolver` (`[SerializeReference]`, `ManagedReferenceRegistry`): o construtor nao cobre referencias polimorficas.
- `GameExtraSettings` (le 496 de 544 bytes) e `LocalizationManager`: ainda sem layout que feche; `LevelSecretAvatarAnimationSolvedListener` tem campo `Dictionary<int, List<string>>` (nao serializavel) alem do `ConditionResolver`.

## Fila
As 9 tarefas `T020/CLASS` correspondentes ficam `blocked_external`; levar pela fila (configure + submit/accept) exige autorizacao explicita.
