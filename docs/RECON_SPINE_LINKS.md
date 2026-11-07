# Vínculos Spine (atlas → material → textura)

Extraídos por `tools/recon_spine_links.py` lendo `datapack.unity3d` um arquivo serializado por vez (só cabeçalhos/nomes; nenhuma imagem decodificada).

- Arquivos serializados varridos: **111 / 111**.
- Materiais resolvidos: **5158**, todos com `_MainTex` local (fileID 0); nenhum externo ou sem textura.
- TextAssets (skeleton/atlas) resolvidos: **1161**.
- Saída bruta: `out/recon/tasks/T032/spine-links.json` (não versionada).

Consumo: `tools/export_spine_original.py` → `tools/import_spine_original.py` copiam esqueletos/atlas/páginas para `Assets/Resources/Spine/<pasta>/` e geram `spine-index.json`; `SpineLibrary` carrega em runtime; testes em `SpineIndexTests` (EditMode) e `SpineLibraryPlayTests` (PlayMode, 19/19 na última execução).
Caso conhecido: `DOG_A_BROWS` referencia esqueleto inexistente no jogo original e não é importado.
