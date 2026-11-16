# Achados do smoke no aparelho — 2026-11-16

Build testado: APK `.test` (`com.c1c3ru.avatarworldoffline.test`) gerado da branch `npc-drawing-and-extras`
(SHA256 `6a07c4e5a147c5cfd83ee06f0146e60511e2c3d2e31e01681af030e4df97db88`), Xiaomi M2101K7BI.
Scripts: `tools/device_smoke.py`, `tools/device_world_smoke.py`, `tools/device_visual_diff.py`.
Evidências (não versionadas): `out/device/tests/{test_build,world_smoke,visual_diff}/`.

## Cobertura
| Verificação | Resultado |
|---|---|
| Abrir, Play e mapa (Bairro) | 6/6 checagens, sem crash, PSS ~946 MB |
| Interiores do Bairro (65 prédios) | 59 tocados, 58 abriram e o app seguiu vivo |
| Não tocados (sem interior, "em obras") | 6: FG_Cinema_UC_Back, FG_Cinema_UC, UGC_Convenience_Store_UC, Gas_Station_UC, Car_Wash_UC, Burger_Restaurant_UC |
| Basketball | abre a quadra (outra tela), sem log `Interior:` — não conta como falha |
| Diff visual contra o original | 21 interiores comparados (7 casamentos por nome são incertos, marcados `?` no relatório) |
| Cidade (30 prédios) e Fazenda (4 prédios) | carregam (log `WorldMap: ... predios` bate com os dados), app vivo; sem interiores no catálogo, nenhum prédio foi tocado |
| Campus | **inconclusivo**: o toque no ícone não trocou de mundo (a captura repete o mapa anterior) |
| Resort e Montanha | **não testados** (ícones fora da faixa visível do seletor; falta rolar a faixa) |
| Prédios dos 5 mundos extras | 56 no total, nenhum com interior no `InteriorCatalog` (só o Bairro tem) |

## Defeitos encontrados
1. **NPCs quase nunca são desenhados.** 7 de 311 NPCs em 47 interiores com NPCs; 40 interiores com 0, 7 com só 1.
   Log: `Interior: NPC <id> falhou: Value cannot be null. Parameter name: key` (`InteriorRuntime.SpawnNpcs` → `AvatarGpuRuntime.CaptureLook`).
   Hipótese (não confirmada): `ToAppearance` copia ids nulos do JSON do NPC por cima dos padrões e algum lookup de dicionário recebe chave nula.
   No original esses NPCs aparecem (ex.: padaria com 2 atendentes, fórum com segurança).
2. **Retângulo claro no lugar do sol** no mapa (perto de x 180–350 da tela, altura variável). O sol é a camada Spine `Sun_Moon`
   (`MapSpineLayer.cs`, `Shader.Find("Spine/Skeleton")`). Hipótese: atlas com alfa pré-multiplicado renderizado com shader de alfa comum.
3. **Erros de atlas do Spine** no console de desenvolvimento: `Material with texture name "C_Scissors_13" not found for atlas asset`
   (também `Pendolum2`, `Pendolum3`). O painel "Development Console" cobre o canto inferior esquerdo em builds de desenvolvimento.
4. **Queda intermitente (não reproduzida):** na primeira passada o app morreu depois de abrir `CourtHouse_T1S4`; na repetição ficou vivo.
5. **Tela de carregamento longa:** 5 capturas iniciais caíram no carregamento (Office_Build (1), Hospital, CourtHouse, Pizza, FancyRestaurant);
   o script agora espera sair do carregamento e essas foram refeitas.

## Diff visual (aproximado)
Nota = melhor correlação normalizada por deslocamento horizontal (1,0 = idêntico). Notas altas: courthouse 0,65, yoga 0,67 (?), hospital 0,53,
police_station 0,53, fire_station 0,46. Notas baixas (0,08–0,27) acontecem sobretudo por posição de rolagem e NPCs/atendentes ausentes, e não por cenário diferente:
nos pares revisados (padaria, fórum) a arte do cenário bate com o original. Diferença visível constante: faltam NPCs. O nosso build também não tem elementos de UI do original
(por exemplo, o ícone de telefone no canto inferior direito dos interiores). A nota não substitui revisão humana: veja os pares em `visual_diff/*.png`.

## Limitações
- O diff cobre só os interiores com captura do original (levantamento com 27 cenas).
- Casamentos por nome marcados `?` podem estar errados.
- Foi usada a posição inicial do interior (câmera centrada no avatar), sem varrer a cena inteira.
