# Evidências locais para avatares — 2026-10-31

Inspeção dos arquivos extraídos, do runtime Spine disponível e do inventário produzido pelo probe do projeto. Este relatório não equivale a avatar renderizado nem validação no aparelho. Nenhum asset foi alterado nesta investigação.

## Fontes concretas

| Fonte local | Observação |
| --- | --- |
| `assets/spine_textasset/TextAsset/Avatar_Spine.skel_108595.txt` | Binário de 21.759.995 bytes; cabeçalho Spine **4.2.43**. |
| `assets/spine_textasset/TextAsset/Avatar_Spine.atlas_109005.txt` | Atlas textual de 289.808 bytes, **2172 páginas**. |
| `assets/spine_textasset/TextAsset/PremadeCharactersJson_109356.txt` | JSON com **896 presets**; cada entrada registra ID, SpineType, SizeType e SkinsData com CategoryType, SkinName, ColorA/ColorB. |
| `assets/spine_textasset/TextAsset/Character_109424.txt` | Lista de **888 nomes** de opções; não prova que cada nome exista como Skin no esqueleto. |
| `out/mb/Spine.Unity.SkeletonDataAsset.jsonl.gz` | Registro `resources.assets`/724127: Avatar_Spine_SkeletonData, skel108595, atlas724126, escala 0.01. |
| `out/mb/Spine.Unity.SpineAtlasAsset.jsonl.gz` | Registro Avatar_Spine_Atlas contém as referências aos materiais de cada página, úteis para resolver texturas sem escolher por nome. |
| `out/avatar-spine-inventory.json` | Saída do probe Editor: versão 4.2.43, **1419 bones, 429 slots, 2414 regiões, 2120 skins, 3479 animações**. Leitura deste relatório, sem execução Unity pelo autor desta inspeção. |

O enum extraído `out/cpp2il/DiffableCs/Assembly-CSharp/PWC/AvatarSpine/SpineType.cs` confirma Character=1. Dos 896 presets, **827** são Character; os demais incluem Toddler, Baby e animais, portanto não devem ser todos procurados no Avatar_Spine de Character.

## O que o probe confirmou e o que refutou

As skins básicas abaixo existem no inventário e referenciam poucas páginas:

| Skin | Página(s) |
| --- | --- |
| `Body_Whites/Body_Whites` | `MultiPack__Body_Solid.png` |
| `Body_Shad/Body_Shad` | `MultiPack__Body_Shadow.png` |
| `Ear_Shad/Ear_Shad` | `MultiPack__Ear_Shadow.png` |
| `Body_Other/Body_Other` | `MultiPack__Body_Outline.png` |
| `Eyes/1_Color` | `Eyes_01_1_Color.png` |
| `Hair_Front/1_Color` | `Hair_Front_01_Color.png` |
| `Hair_Front/2_Color` | `Hair_Front_02_Color.png` |

O preset ID100000 **não é diretamente reconstruível apenas com FindSkin para cada SkinName**. Corpo, olhos, cabelo frontal e barba existem; `Shirt_Formal/1`, `Bottom_Special/6`, `Mouth/17`, `Legs_Socks/11`, `Legs_Shoes/41`, `Hat_A/32` e `Jacket_Special/2` não existem como skins com esses nomes. Entre os 827 presets Character, **7539 das 12770 ocorrências de SkinName** não são encontradas no inventário desse esqueleto. Isso não demonstra assets ausentes: o formato de montagem usa outros dados além de skins diretas.

Existem `Templates/Mouth_1`, `Templates/Mouth_2`, `Templates/Mouth_3`; templates de roupas incluem `Templates/T_Torso_1`, `T_Torso_2`, `T_Arm_L_1`, `T_Arm_R_1`, `L_Top_1`, `R_Top_1`, `L_Bot_1`, `R_Bot_1`, e `Templates/L_Shoe_1`/`R_Shoe_1`, com alternativas numeradas. São peças de geometria, não identificação confirmada de um look final. O inventário não tem skin cujo nome contenha Shirt ou Bottom; também não contém `Hair_Back/5_Color`, usado no preset ID100001.

Os stubs extraídos em `out/cpp2il/DiffableCs/Assembly-CSharp/PWC/AvatarSpine/CharacterSpineSkinsManager.cs` expõem TrySUTColorSkinInternal/GetSUTSystemCategoryKey; há tipos `PWC/SUTSystem` e `PWC/AvatarMaker/SUTSkinsDataMap.cs`. Isso, junto aos templates e nomes ausentes, sustenta a **inferência de montagem/remapeamento externo**, mas os corpos dos stubs não fornecem sua implementação.

## Resolução das texturas: colisões reais

Foi indexado `assets/textures_png/Texture2D/*.png`, retirando somente o sufixo numérico de extração e comparando dimensões com o atlas. As **2172 páginas** têm ao menos um candidato com dimensões corretas. Porém **1269 páginas** têm mais de um candidato do mesmo nome/dimensões e bytes PNG distintos. Comparação de RGBA em amostras confirmou pixels diferentes, por exemplo `Bike_Bell_Base_1`.

Logo, nome e tamanho não bastam para identificar materiais/roupas. O primeiro arquivo retornado pelo filesystem não é uma seleção válida. Há ainda placeholders 1x1 com os mesmos nomes, descartados pela comparação de dimensões.

Páginas úteis com correspondência única por nome e dimensões verificadas:

| Página | Arquivo em `assets/textures_png/Texture2D/` | Dimensões |
| --- | --- | --- |
| `MultiPack__Body_Outline.png` | `MultiPack__Body_Outline_31883.png` | 1333x253 |
| `MultiPack__Body_Shadow.png` | `MultiPack__Body_Shadow_87873.png` | 231x290 |
| `MultiPack__Body_Solid.png` | `MultiPack__Body_Solid_99707.png` | 474x235 |
| `MultiPack__Ear_Shadow.png` | `MultiPack__Ear_Shadow_76723.png` | 59x129 |
| `Eyes_01_1_Color.png` | `Eyes_01_1_Color_21563.png` | 198x102 |
| `Eyes_01_1_P.png` | `Eyes_01_1_P_18738.png` | 147x63 |
| `Hair_Front_01_Color.png` | `Hair_Front_01_Color_56300.png` | 309x187 |
| `Hair_Front_02_Color.png` | `Hair_Front_02_Color_21315.png` | 448x308 |

## Runtime disponível e estratégia do subset

Asmdefs: `spine-csharp` em Library/PackageCache e `spine-unity` em Packages/com.esotericsoftware.spine.spine-unity/Runtime. APIs locais confirmadas: SkeletonDataAsset.CreateRuntimeInstance, SpineAtlasAsset.CreateRuntimeInstance, SkeletonGraphic, Skin.AddSkin, Skeleton.SetSkin e Skeleton.SetSlotsToSetupPose.

Evitar criar 2172 materiais/texturas para provar um único avatar. Estratégia recomendada:

1. Ler o esqueleto com AttachmentLoader sem regiões, preservando geometria/skins/animations. Ler o atlas completo somente como metadados.
2. Compor a seleção mínima de skins e coletar os paths de RegionAttachment/MeshAttachment efetivamente usados.
3. Resolver apenas as páginas desses paths; carregar texturas/materiais desse subset.
4. Atribuir AtlasRegion às attachments e atualizar região/UVs; tratar linked meshes e sequências explicitamente. Testar que nenhuma attachment visível ficou sem região.
5. Aplicar SetSkin, SetSlotsToSetupPose e uma animação existente adequada, como `Idle_Stand_1`, e verificar desenho real.

ColorA/ColorB e os arquivos `AvatarSpineSkinsColoringConfigs_*` indicam coloração com operações distintas (Single/Multiply e outras). Tint uniforme por slot pode ser uma escolha inicial do cliente, mas não reproduz automaticamente o shader de duas cores original.

## Próximos probes e critérios

- Renderizar corpo, olhos e duas opções de cabelo com as correspondências únicas acima; capturar pixels reais e conferir mudança visível. Isso prova o pipeline visual, ainda não conclui roupas.
- Resolver os materiais do atlas através de `(resources.assets, material path_id)` e `Material.mainTexture`, preservando chaves compostas. O APK local `assets/split_UnityDataAssetPack.apk` contém os dados para extrair novamente o bundle se necessário; `x/` não existia durante esta inspeção.
- Localizar registros/configurações SUT que mapeiam uma camisa, parte inferior, par de sapatos e acessório a templates e texturas. Provar duas opções por categoria com comparação visual antes de ampliar o catálogo.
- Verificar mouth/eyebrows e Hair_Back via SUT, não substituir silenciosamente por templates aleatórios.
- Persistir IDs/cores do look e provar reabertura com aparência idêntica, sem regressão do saldo econômico.
- Só considerar a fatia jogável entregue depois de avatar visível, troca real de peças, persistência, navegação pela Home, testes Unity e APK validado no aparelho. Inventário, painel de texto e aviso de ausência não satisfazem esse critério.
