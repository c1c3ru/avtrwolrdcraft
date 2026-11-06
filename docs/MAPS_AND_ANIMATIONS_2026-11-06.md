# Mapas e animações — estado em 2026-11-06

Validação: só testes EditMode (205/205). **Nenhuma destas camadas foi vista no aparelho nesta rodada** (decisão do autor: seguir montando; o build do `.test` foi morto por falta de memória e depois dispensado).

## Os 6 mapas do seletor são cenas separadas do original
| Ícone | Cena (BuildSettings) | Arquivo | Prédios | No cliente |
|---|---|---|---|---|
| Campus | `College` | `level231` | 4 | `Resources/Maps/college` |
| Bairro | `World` | `level4` | 59 (+6 em obras) | `Resources/WorldSlice` (câmera ajustada à mão) |
| Cidade | `StarDustCity` | `level103` | 30 | `Resources/Maps/stardust` |
| Fazenda | `Countryside` | `level229` | 4 | `Resources/Maps/countryside` |
| Resort | `Vacation` | `level69` | 10 | `Resources/Maps/vacation` |
| Montanha | `SnowyMountain` | `level230` | 8 | `Resources/Maps/snowy` |

O globo troca de mapa (`WorldMapRuntime.SwitchMapRoutine`). Prédios de cada mapa só abrem se `InteriorCatalog` tiver o `defaultLevel`.

## Animações
| Animação (original) | Estado | Fidelidade |
|---|---|---|
| Nuvens `WorldCloud` + `WorldCloudsSpawner` | feita | **Dados reais**: sprites das listas do spawner (4 clara + 4 chuva), y mín/máx, ponto final. **Aproximado**: velocidade (0,25–0,55 u/s; não serializada) e reaparecimento (volta ao início). Arte de chuva só aparece na chuva. |
| Trem `WorldTrain` (Bairro) | feita | **Dados reais**: ponto inicial, estação, destino, 3,5 s e 5 s. **Aproximado**: pausa na estação (6 s) e ausência (8 s). |
| Spine `Sun_Moon`, `Water_Reflections` | feita | Esqueleto, atlas, posição, escala e ordem reais; seguem a câmera como no original (filhos da `WorldCamera`). **Aproximado**: animação do Sol/Lua escolhida pela hora por nome (o original usa `LitSpineByTimeOfDay`). Material `Spine/Skeleton` padrão: mistura/PMA não confirmados. |
| Spine de interiores (esteiras, telas, algas…) | feita | Mesmo carregador (`MapSpineLayer`); avatares (`Avatar_Spine`) são omitidos de propósito. |
| Carros `WorldCarsController` | feita | **Dados reais**: rede de pontos de estrada (`WorldRoadPoint`, 7–60 por controlador), quais carros (`cars/car<N>`, 14 no total; a Montanha usa o guindaste `car14`), quantos por controlador (4–20) e as artes up/down/sideways. **Aproximado**: velocidade (1,6 u/s; o original guarda 0 = constante do código) e a escolha da bifurcação (sorteio sem voltar). Sem faróis (`*_light`) nem tonalidade por hora do dia. |
| Gradiente do céu `BackgroundSky` (por clima) | feita | **Dados reais**: as 3 configs (limpo, chuva, neve; as mesmas nos 6 mapas), 4 transições de horário × 4 cores de topo e de base, `smoothness` e `middle`. **Aproximado**: horários das transições (05–07, 07–10, 16–18, 18–20 h; o original segue o `TimeOfDayManager`) e a curva do gradiente (logística; o shader não foi recuperado). O pôr do sol (salmão) lembra o rosa liso que o cliente usava. Segue a hora do aparelho. |
| Tonalidade por hora do dia (`LitSpriteByTimeOfDayRenderer`, 473 sprites no Bairro) | **não feita** | Sem ciclo dia/noite. |

## Como reproduzir
- `tools/recon_building_scenes.py` → prédio → cena.
- `tools/export_interior.py <levelN> <chave> [--dest <pasta>]` → um mapa ou interior (com animações e Spine).
- `tools/export_all_interiors.py` → todos os interiores com cena (log em `out/recon/interiors_export.json`).
