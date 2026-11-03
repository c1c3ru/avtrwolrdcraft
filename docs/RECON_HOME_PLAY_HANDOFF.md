# Handoff — contrato Home → Play (T025), 2026-11-03

Para outra IA continuar. Tudo aqui é **candidato estático + 1 observação em aparelho**; nada está certificado.

## Estado
- Binário/metadata: `out/recon/il2cpp/{libil2cpp.so,global-metadata.dat}` (hashes em `docs/RECON_NAVIGATION_CONTRACT.md`). Método `Game.Home.HomePlayButton.LoadPlayScene`, token `0x060054ef`, VA `0x2057fa8..0x20581ec`.
- Verificador: `python3 tools/recon_home_play.py --craft-listing out/recon/tasks/T025/METHOD/5fe1bb4a25183678/craft-home-slice.json` (`craft-home-disassembly.json` é um erro `bad_input`, não usar). Testes: `python3 -m unittest discover -s tools -p "test_recon_*.py"` → 86 OK.
- Saídas: `out/recon/tasks/T025/METHOD/5fe1bb4a25183678/{method-contract,control-flow,result}.json`, `unknowns.jsonl`.

## Fluxo recuperado (candidato)
1. `InteractionHistoryManager.OnClickHomePlayButton()`.
2. `PlayerPrefs.HasKey("pazucore_pending_deep_link")` falso → `scene = GameSceneManager.GetCurrentWorldSceneName()`.
   - Getter (já verificado em `docs/RECON_NAVIGATION_CONTRACT.md`): `PlayerPrefs.GetString("GAME_CURRENT_WORLD", "World")`, usado se `IsSceneAvailable`, senão `"World"`.
3. Chave presente: `SoundManager.Stop(1001)`; lê a chave; vazia → level 2, senão `level = DeepLinkManager.Instance._mapLinkToLevel[valor]` (**inferido**: receptor = campo `+0x28` do singleton, chamada de interface em `0x2058174`); apaga a chave, `PlayerPrefs.Save()`, `WorldBuildingsDataManager.SaveBuildingData(0, level)`, `scene = CoreExtensions.GetSceneName(level)`.
4. Ambos os ramos terminam em `GameSceneManager.LoadScene(scene, true, null)`.

## Observação em aparelho (ramo sem deep link)
Xiaomi M2101K7BI, original 1.227. Home → toque em Play → tela de carregamento amarela → mapa do mundo (cidade com obras). Evidência: `out/recon/tasks/T025/DEVICE/{01-home,02-loading,03-world}.png` + `SHA256SUMS`. Consistente com cena `World` (candidata `level4`, 59 edifícios, `Main_Theme_Loop`, ver `docs/REA_NAVIGATION_MAPPING_2026-11-01.md`); o mapeamento `World`→`level4` é **inferido** por convenção de índice, não observado.

## Desconhecidos (ordem sugerida)
1. ~~Extrair `DeepLinkManager._mapLinkToLevel`~~ **Feito (candidato):** `out/recon/tasks/T025/DEVICE/deeplink_map_link_to_level.json` — 149 chaves → `LevelType` (ex.: `girlslivingroom`=1, `streetmain`=51, `gym`=162, `basketball`=163). Fonte: `datapack.unity3d`, `sharedassets1.assets`, MonoBehaviour path_id 265, script `DeepLinkManager` (MonoScript 5132 em `data.unity3d`). Layout parseado manualmente (cabeçalho de 44 bytes, depois lista de 149 strings, **uma segunda lista idêntica de 149 strings**, depois 149 ints; consome exatamente os 6028 bytes). O pareamento chave→valor é por ordem e assume que a 1ª lista é `_keys` e os ints são `_values`; a lista duplicada não foi explicada (verificar o layout de `SerializableDictionaryBase` no dump antes de confiar). Falta: mapear `LevelType`→nome de cena via `CoreExtensions.GetSceneName` (VA `0x206a798`) e confirmar com o enum `LevelType`.
2. Confirmar que `0x2058174` é `get_Item` (decodificar a busca em offsets de interface `0x2058114..0x2058148` e o slot do método) e o comportamento com chave ausente.
3. Valor salvo de `GAME_CURRENT_WORLD` no aparelho (não legível: app não depurável, sem root). Alternativa: observar após usar um mundo diferente.
4. Cobrir no aparelho os cenários chave ausente/vazia/não vazia (exige injetar a chave; avaliar risco ao save — **não** reinstalar/atualizar com assinatura diferente nem perder o save).
5. Efeito de `OnClickHomePlayButton` e dos argumentos de `SaveBuildingData`; callees de `LoadScene`/fade.
6. Revisão independente antes de marcar T025 como done (`docs/RECON_RESUME_SPEC.md`).

## Armadilhas
- O pseudocódigo do Craft Anything perdeu o valor da cena em um ramo; use o assembly (anchors no verificador).
- Craft não achou a função no ELF inteiro; só desmonta recortes com endereço conhecido.
- Disassembler ad hoc: `capstone` num venv fora do repo (`pip install capstone`); não nomear script `dis.py` (sombreia o stdlib).
- Clone: o Play do original abre o **mapa do mundo**, não a quadra; a quadra segue protótipo sem equivalência.
