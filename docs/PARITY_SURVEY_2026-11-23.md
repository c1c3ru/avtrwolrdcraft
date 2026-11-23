# Levantamento de paridade — 2026-11-23

Atualiza `PARITY_SURVEY_2026-11-09.md`. Medido no `main` (commit `fbc569af9`). Contagens vêm de `tools/parity_report.py` → `out/parity.json`
(tendência em `out/parity_history.jsonl`); os percentuais por área são **estimativas de julgamento**, não métrica oficial.

## Contagens (09/11 → 23/11)

| Medida | 09/11 | 23/11 |
|---|---|---|
| Interiores exportados | 0 medido* | 58 de 254 cenas (22,8%); 58 de 59 prédios com cena |
| Prédios mapeados | — | 65 (6 sem cena: 5 `*_UC_*` "em obras" + cinema; é o estado do original) |
| Itens da loja no cliente | 0 medido* | 25.812 de 25.812; 32 combos/ofertas (23 de moda/casas/pets + 9 de veículos) |
| Mapas em `Resources/Maps` | 0 medido* | 5 (college, countryside, snowy, stardust, vacation) + o Bairro (`World`) |
| Arquivos `.cs` / linhas no cliente | 39 / 8.191 | 85 / 19.493 |
| Testes EditMode | 144 | 391 métodos (última rodada: 366 casos EditMode e 25 PlayMode, todos passando) |
| Botões da Home ligados | 4 de 39 | 12 de 39 (27 pendentes) |

\* a medição de 09/11 foi feita em outra branch; os números de hoje vêm do `main`.

## Cópia por área (estimativa)

| Área | 09/11 | 23/11 | O que mudou |
|---|---|---|---|
| Home / menus | ~60% | ~70% | Reset de progresso, seletor de idioma, Configurações. Dos 27 botões pendentes, 11 são online/conta (fora do escopo) e vários são compra com dinheiro real (passe, kit, presente de novo usuário). |
| Avatar | ~55% | ~65% | Slots (humano/pet/carro), editor de pet, categorias vestido/meias/costas/bochechas, extras dos NPCs. |
| Loja | ~50% | ~55% | 32 ofertas, vagas de veículo, idioma. **Preços continuam sendo de servidor**: 14 dos 32 foram lidos de prints do original; os demais são decisão local (ver `NOT_REPRODUCED.md`). |
| Mapas | ~40% | ~40% | Sem mudança de cobertura: os prédios entráveis vêm do mapa do Bairro; as outras cenas ainda não têm interior exportado. |
| Interiores | ~25% | ~25% | 58/254 cenas; todos os prédios com cena já exportados, o resto das cenas não é prédio. |
| Gameplay real (minijogos/missões) | ~5% | ~5% | Só quadra (protótipo) e quiz (invenção própria). |
| Idioma da interface | — | novo | pt/en/es/id em Home, loja, slots, editores, itens, mapa e quadra. Funcionalidade nossa: o seletor do original é do chat. |

## Marcos

- **V – Varredura (~70%)**: sem mudança. Ainda faltam 126 classes MonoBehaviour com erro; 124 delas já têm causa raiz (T020), mas só 65+9 se resolvem com mais RAM.
- **L – Lógica recuperada (~15–20%)**: sem mudança. O dump IL2CPP só tem assinaturas; Hopper, Ghidra e UnityPy seguem inviáveis neste ambiente (`LOOP_STATE.md`, T004/T025).
- **C – Cópia funcional (~25–30%)**: subiu das áreas de cliente acima; o que falta depende de lógica que só existe no servidor ou no binário.

## O que ainda não anda, e por quê

1. Botões da Home de presentes, feriado, passe e `World_ShopButton`: no binário só há assinaturas (por exemplo `AvatarPassChangeWidget`) e as respostas vêm do servidor (`StoreAvatarPassNextRewardStatusCloudResponse`). Fazer exige recuperar corpos de método.
2. Ledger `AVATAR_WORLD_TASKS.json`: continua 60/60 `pending`, embora 13 tarefas tenham evidência em `out/recon/tasks/`. A fila formal de recon (`reports/recon/tasks.json`) é a que reflete o estado real; nunca marcar `done` sem revisão.
3. Sem diff visual contra o original (capturas ADB em `out/device/sbs-nav` podem servir de referência).
4. Sem validação em aparelho do build Android desde as mudanças de Home/loja/idioma.
