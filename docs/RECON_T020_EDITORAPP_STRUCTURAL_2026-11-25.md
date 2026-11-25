# PWC.EditorApp.* — decodificacao estrutural sem nomes de campo e contexto — 2026-11-25

As 20 classes `PWC.EditorApp.*` (24 instancias, 2.140 bytes) nao tem esquema: o tipo foi removido do IL2CPP (0 ocorrencias de `EditorApp`/`EASearchResult` no metadata; 0 arquivos no Cpp2IL; nenhuma referencia
a `EASUTEManager` no codigo decompilado). Sem o tipo nao ha nomes de campo; aqui esta o que **os bytes e o contexto** permitem. Ferramenta: `tools/resolve_editorapp_context.py` (usa `tools/lowmem_unitypy.py`).
Dados: `out/recon/editorapp/structural_decode.json` (por objeto: arquivo, `GameObject` dono, e itens `pptr`/`str`/`int`; cada `pptr` local resolvido para tipo + nome do objeto referenciado).
Estas classes **nao** foram levadas pela fila (as 20 tarefas seguem `blocked_external`).

## Onde ficam
- `resources.assets` (prefabs de `Resources`): `EALevelEditorPanel Canvas`, `EAHierarchyPanel Canvas`, `EASearchPanel Canvas`, `EAHierarchyResult`, `EASearchResult`, `EAResultPool` (`Content`), `EAItemPreviewPanel` + `EASpritePreview`,
  `EALoginPanel`, `EACAInfoManager`/`EACAItemInfo`/`EACAMenuInfo`, `EADelayedEventInputField` (2x `InputField (TMP)`), `EAEditorAssetsIndexer`, `EAEditorDirectoryIndexer` (3x).
- **Cena `level252`** (11 raizes: `EASUTEditorManager`, **`EASUTAvatarDisplay`**, `LevelCamera`, `LevelManagers`, `Canvas`, `CameraScrollArea`, `LevelCanvas`, `LevelDebugger`, `Background`, `BackgroundSky`, `EventSystem`) com `EASUTEManager`
  (2 `TMP_Dropdown`), `EASUTEMenuManager` e `EASUTEAddedSkinsScreen`; prefabs `EASUTEDirectoryButton` e `EASUTEThumbButton` em `sharedassets252.assets`.

## O que cada grupo e (por estrutura e nomes de objetos referenciados; os nomes das classes sao do original)
| Grupo | Evidencia nos dados | Funcao provavel |
|---|---|---|
| **EASUTE\*** (cena `level252`) | `EASUTEditorManager` -> `EASUTEMenuManager` + 2 dropdowns; raiz `EASUTAvatarDisplay`; botoes de diretorio e de miniatura; tela "AddedSkinsScreen" | editor/visualizador de **skins de avatar** (SUT = o sistema de skins/texturas do avatar, mesmo prefixo de `SUTSkinsDataMap`/`SUTUtils`): navegar diretorios, ver miniaturas, adicionar skins e ver o avatar com elas |
| **Editor de nivel** (`EALevelEditorPanel`, `EAHierarchyPanel/Result`, `EASearchPanel/Result/ResultPool`, `EAItemPreviewPanel`, `EADelayedEventInputField`) | paineis `Canvas`; hierarquia com `Expand Button`, `ParentResult`/`ChildResults`; busca com `InputField (TMP)` | editor de **fases/cenas dentro do jogo**: arvore de hierarquia, busca de itens, preview de item |
| **Indexadores** (`EAEditorAssetsIndexer`, `EAEditorDirectoryIndexer`) | o primeiro referencia 9 `Texture2D`, 11 `Sprite` e o prefab `Ceiling_Lamp_01_P98` | catalogo de assets para a busca do editor |
| **`EALoginPanel`** | 2 `InputField (Legacy)` + objeto `OTP` | login por **senha de uso unico (OTP)** do editor |
| **EACA\*** (`EACAInfoManager/ItemInfo/MenuInfo`) | menu com botao `Collapse`, imagem, `TMP_InputField` | painel de informacoes da **animacao contextual** (CA) de um item |

## Impacto para o jogador
Nenhum visivel. Nao ha referencia a essas classes no codigo decompilado, nao ha `EditorApp` nos 50 chamadores diretos de `GameSceneManager.LoadScene` nem na `sceneMap` de `GameExtraSettings`, e o painel de login exige OTP:
sao ferramentas internas do estudio que ficaram nos assets. Relacao com **avatar**: sim no conteudo (o editor SUTE visualiza skins de avatar), mas e ferramenta de *producao de conteudo*, **nao** o editor de avatar do jogador
(esse e o `PWC.AvatarMaker`/`AvatarMakerLobby`, ja decodificado). Para o cliente reimplementado: nada a implementar; o unico interesse e documental (como as skins sao indexadas/organizadas por diretorio).

## Limites
Nomes e tipos dos campos continuam desconhecidos (so estrutura); os ints "float-like" (ex. `1116471296`) sao floats reinterpretados que nao foram convertidos; a funcao de cada painel e inferida por nomes e vizinhanca, sem execucao nem codigo.
