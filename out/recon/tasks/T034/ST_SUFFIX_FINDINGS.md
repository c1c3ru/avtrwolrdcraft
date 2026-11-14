# Hipótese revisada: sufixo `_st` em nomes de skin — 2026-11-14

## Hipótese original (descartada)
Inferida só pelo padrão do nome (`_st`) e pelo fato de só aparecer dentro de pastas
`_color`: "camada auxiliar de sombra/template, não renderizada no jogo original".
Nunca foi checada contra o atlas original nem contra o código decompilado — só
suposição por convenção de nome.

## Escopo real do padrão
No catálogo inteiro extraído em `other-skins.json`/`Baby.skins.json`/`Toddler.skins.json`
(8447 entradas), só existem **duas** skins com sufixo `_st`, cada uma com 2 `path_id`
(provavelmente duas páginas/resoluções de atlas do mesmo sprite):

- `sutsystem/skins/baby/hat/hat_a/hat_a_207_color/hat_3_st` — `resources.assets` path_id 67405, 176267
- `sutsystem/skins/toddler/jacket/jacket_91_color/j_arm_r_2_st` — `resources.assets` path_id 56679, 165374

Não é um padrão disseminado por toda a categoria de chapéus/jaquetas — só esses dois itens no universo capturado.

## Evidência 1 — atlas original (`out/assets/resources.assets`, extraído de `apk/base.apk`)
Carregado com UnityPy (`tools/venv/bin/python`, UnityPy 1.25.4) e consultado pelos
`path_id` exatos acima (script usado, reproduzível):

```python
import UnityPy
env = UnityPy.load("out/assets/resources.assets")
for obj in env.objects:
    if obj.path_id in {103274, 212761, 67405, 176267}:  # hat_3 / hat_3_st
        data = obj.read()
        print(obj.path_id, obj.type.name, data.m_Name)
```

Resultado:

| Nome | Tipo | Tamanho |
|---|---|---|
| `Hat_3` | Texture2D + Sprite | 159×185 |
| `Hat_3_ST` | Texture2D + Sprite | 159×185 |
| `J_Arm_R_2` | Texture2D + Sprite | 35×59 |
| `J_Arm_R_2_ST` | Texture2D + Sprite | 35×59 |

As quatro entradas existem como objetos reais no atlas **original** (não no clone), com o
mesmo tamanho de canvas da versão sem `_st`. A extração do clone não pulou nenhuma página —
os dados estavam lá desde a origem.

## Evidência 2 — conteúdo de pixel decodificado
Decodificando a imagem de cada Texture2D (`data.image.save(...)`):

- `Hat_3`: gorro vermelho com laço verde, arte completa (30,2% de pixels opacos).
- `Hat_3_ST`: **rosto de urso de pelúcia**, pequeno e localizado num canto do canvas
  (3,9% de pixels opacos). Paleta de cor diferente (tons de laranja/marrom vs. vermelho).
- `J_Arm_R_2`: manga/braço vermelho sólido (forma cápsula).
- `J_Arm_R_2_ST`: **emblema circular pequeno**, não relacionado à forma da manga.

Em nenhum dos dois casos `_st` é uma silhueta/sombra do item base — são ilustrações
completamente diferentes e bem menores. Isso refuta a hipótese de "camada de sombra/template
não visível": uma sombra real replicaria a silhueta do item base; aqui não há nenhuma
relação de forma entre a versão `_st` e a versão normal.

## Evidência 3 — sistema de "sticker" ativo no código original
Busca de strings em `il2cpp_in/global-metadata.dat` e `il2cpp_in/libil2cpp.so` (binário
original, não o clone) encontrou um subsistema de **stickers (adesivos/decalques)** não
trivial e claramente em uso:

- Classe `Game.Level.ContextualAnimation.LevelCAStickerItemHandler`
  (`Assets/Game/General/Scripts/Level/ContextualAnimation/Character/Items/LevelCAStickerItemHandler.cs`)
- `PWC.CarsMaker.CarStickerDecal`, `CarStickerMapping`, `CarStickerSlotExclusion`, `CarFullStickerCoverage`, `ClearSticker`
- Métodos `TryGetStickerForTarget`, `GetStickerSpanAcross`, `GetStickerSpanUp`, `GetStickerScaleOffset` (todos em `CarStickerDecal`)
- Strings de validação em runtime: `"sticker area has no size - check its scale."`,
  `"no CarView beside this - there is nothing to say where a sticker goes!"`,
  `"stickers, and a part can only wear one - keep one of them off it with a slot exclusion."`
- Dezenas de assets de sticker nomeados em outras partes do catálogo (não relacionados a
  `_st`): `Beauty_FaceStickers_01..08`, `Cat_Sticker_P147`, `Bird_Sticker_P147`,
  `Burger_Sticker_01..04`, `Box_Sticker_Z1B4L1__Front/Top`, `Cheer_Sticker_P204`.

Isso é evidência forte de que "sticker" é um conceito real e ativo no jogo original —
não lixo/placeholder morto. `_st` muito provavelmente abrevia "sticker": uma variante de
decalque pequeno associado a uma skin específica.

## Hipótese revisada
`_st` = variante **sticker** da skin (um decalque/ícone pequeno associado àquele item
específico), não uma camada de sombra/template invisível. Confiança: **inferida**, apoiada
por conteúdo visual decodificado + existência comprovada de um sistema de sticker ativo —
ainda **não observada** diretamente no call-path de código que consome essas skins.

## Pendência — decompilação do call-path não concluída
Tentativa feita em 2026-11-14 via REA (`open_binary` em `il2cpp_in/libil2cpp.so`, ELF
arm64, sha256 `b63661fa60c23ebef1c2da4bb5288ad787eb3da36b22d4bdf285401f1643d728`), mirando
os vaddrs abaixo (extraídos de `out/recon/il2cpp/assembly_csharp_methods.jsonl`):

| Método | vaddr |
|---|---|
| `PWC.Level.LevelSkinCATargetHandler.TryAddCAHandlerFromSkinName` | `0x22c62d0` |
| `PWC.Level.LevelSkinCATargetHandler.OnPutClothing` | `0x22c634c` |
| `Game.Level.ContextualAnimation.LevelCAStickerItemHandler.OnAddedToTarget` | `0x1fd4008` |
| `Game.Level.ContextualAnimation.LevelCAStickerItemHandler.GetFolderName` | `0x1fd40a8` |
| `PWC.Level.LevelClothingItemHandler.GetSkinName` | `0x22f3f98` |

Nenhum pseudocódigo foi obtido, em duas rodadas de tentativas com causas raiz diferentes:

- **Rodada 1** (via subagente): a ponte de análise do provider (Hopper — único disponível;
  Ghidra não está configurado nesta máquina, falta `GHIDRA_INSTALL_DIR`) foi morta pelo OOM
  killer do kernel repetidas vezes (confirmado via `dmesg`/`journalctl -k`), porque a máquina
  de desenvolvimento (7,1 GiB RAM) estava saturada por um teste Unity EditMode
  (`-batchmode -runTests`) rodando em paralelo em outro worktree
  (`avatar-clothing-color-review`) mais compiladores Roslyn/Burst e múltiplas sessões
  Claude/Codex.
- **Rodada 2** (retomada após o teste Unity concorrente terminar, com 3,3 GiB livres
  confirmados): memória deixou de ser o fator — duas chamadas consecutivas de
  `mcp__rea__list_documents` falharam com `provider_timeout` idêntico ("REA timed out
  waiting for Hopper bridge readiness"), travadas em `QDialog::WaitDialog` do Hopper, sem
  processo Hopper sobrevivendo para inspecionar. `~/.config/hopper/Hopper.plist` mostra
  `FirstLaunch=false` (não é diálogo de EULA de primeiro uso) e não existe nenhum banco de
  análise Hopper (`.hop`) pré-existente para este binário — ou seja, cada tentativa reinicia
  a análise completa do zero e não termina dentro da janela de prontidão de 120s do bridge,
  mesmo com memória disponível. Sem Ghidra instalado no sistema como alternativa headless.

- **Rodada 3** (2026-11-14, depois de instalar Ghidra 12.1.4 em
  `~/.local/share/ghidra/ghidra_12.1.4_PUBLIC` e configurar `GHIDRA_INSTALL_DIR` no servidor
  MCP `rea`, exigindo reiniciar o job para o processo pegar a variável nova): `open_binary`
  com `provider_id: "ghidra"` funcionou (bind confirmado, Ghidra 12.1.4), mas
  `procedure_pseudo_code` no primeiro endereço (`0x22c62d0`) matou o processo Java com
  **SIGKILL** depois que o Ghidra headless entrou na fase "ANALYZING all memory and code"
  (análise completa do binário, não só da função pedida). Confirmado via
  `journalctl -k`: `Out of memory: Killed process 97231 (java) total-vm:5852876kB,
  anon-rss:1759520kB` — o processo nem chegou a estourar seu próprio teto de heap (`-Xmx2G`),
  foi a pressão de memória do sistema inteiro (7,1 GiB RAM, terminal, outras sessões
  Claude/Chrome) que faltou.

Conclusão: três tentativas, duas ferramentas de análise diferentes (Hopper e Ghidra), três
causas de falha relacionadas a recurso/ambiente (OOM, diálogo GUI travado, OOM de novo) — o
padrão aponta para uma limitação estrutural real da máquina, não do binário nem da
abordagem: **7,1 GiB RAM (+4 GiB swap) não é suficiente para rodar a análise completa de um
binário IL2CPP de ~75MB com nenhum dos dois providers disponíveis, enquanto a máquina tem
as outras sessões/apps normais abertas.** Repetir a mesma tentativa sem mudar esse recurso
não deve dar resultado diferente. **Candidato a `static_candidate_not_runtime_validated`**:
para fechar essa pendência é preciso (a) mais memória/swap disponível no momento da análise
(fechar outras sessões/apps pesados, ou aumentar o swap do sistema — ação que precisa de
decisão e permissão explícita do usuário, não foi feita), ou (b) rodar essa análise específica
numa máquina com mais RAM. Vaddrs continuam válidos para quando isso for viável.
