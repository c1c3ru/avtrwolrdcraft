# Animações e sons: o que temos, o que é evidente e o que falta (T018/T036, 2026-11-05)

Ferramentas: `tools/recon_audio_coverage.py`, `tools/recon_audio_scan_all.py`, `tools/recon_animation_coverage.py` (saídas em `out/recon/tasks/T032/`), `tools/skel_dump` (agora com detalhes dos eventos Spine). Tudo estático.

## 1. Sons
**Disponível (concreto).** 2.781 clipes extraídos (WAV, 1,95 GB) e o registro oficial `PazuCore.AudioClipPaths` (ScriptableObject `name → path` em `Resources`): **2.781 entradas, 1:1 com os clipes** (uma só difere pela apóstrofe: `Avatar_Doesn't_Fit_And_Drop` ↔ arquivo `Avatar_Doesn_t_Fit_And_Drop`). Pastas do registro: `Sound/SFX` 2.513, `Sound/Music` 174, `Sound/Ambience` 80, `PazuCore/Sound` 13.
**Como o original toca som:** por **nome**. 43 classes de som e centenas de handlers guardam `_soundName` e a classe `GameSoundPlayer` (5.496 instâncias) resolve o nome pelo registro. As cenas amostradas (level4, level8, level237) não têm `AudioSource`, só `AudioListener`.
**Quem referencia cada clipe (evidência):**
| Canal | Clipes |
|---|---|
| Dados serializados em qualquer classe (251 classes, inclui `LevelDoor`, `LevelLight`, `LevelToggleableAudio`, handlers de som) | 1.498 |
| Literais de código, `audioPath` de eventos Spine, nomes compostos (`A^B`, `.wav`) | + até 1.740 no total com o canal anterior (**63%** por nome exato) |
| Prefixos montados em código (ex.: `Avatar_` 459 clipes, `Dog_` 50, `Cat_` 39, `Parrot_` 22) | +615 (cobertos só por prefixo) |
| **Total com alguma referência** | **2.355 (85%)** |
| Sem referência por nenhum canal | **426 (15%)**: SFX 420 e música 6 |
Por categoria: Ambience 80/80, Music 168/174, SFX 2.093/2.513, `PazuCore/Sound` 13/13.
**Leitura:** os 426 sem referência (aeroporto, âncora, TV de parede, bola de praia, `BWYW_Hiphop_*`...) são sons por item. Podem ser usados por objetos que o dump não decodificou (126 classes com erro, 2.813 objetos) ou por nomes montados em runtime; não há prova de que sejam mortos nem de que sejam usados.
**Eventos Spine:** 613 eventos nos esqueletos, 56 com `audioPath` (48 distintos, 40 casam com clipes). Que o jogo toque esses `audioPath` não está provado (o spine-unity não toca sozinho).
**No cliente hoje:** 10 arquivos em `Resources/Audio` (cliques, moeda, certo/errado e música de Home e quadra) = **0,4%** dos sons. Falta o importador, o registro no cliente e o `GameSoundPlayer` (volume, loop, distância, mute).

## 2. Animações
**Disponível (concreto).** 587 esqueletos Spine parseados sem erro (583 nomes de arquivo distintos), **5.067 nomes de animação distintos**, 7.206 pares esqueleto/animação (`RECON_ANIMATION_INVENTORY.md`). Também: 23 `AnimationClip`, 5 `AnimatorController`, 10 `Animator` e 55 `Animation` legados no `resources.assets`. Texturas dos atlas Spine: 5.116 páginas, só 3 sem textura extraída, ~**112 MB** de PNG (o Avatar usa 2.172 páginas, ~15 MB de templates; as roupas dele, 91 MB, já estão no cliente). Esqueletos e atlas em texto: ~87 MB.
**Quem referencia cada nome (evidência):** exato por catálogo de CA, literal de código ou dado serializado: **2.730 (54%)**; só por prefixo montado em código: 1.857 (37%); sem referência: **480 (9%)**.
| Esqueleto | Animações | Referência exata | Só prefixo |
|---|---|---|---|
| Avatar_Spine | 3.479 | 1.881 (catálogo 1.610, código 265, dados 260) | 1.500 |
| Toddler_Spine | 581 | 258 | 313 |
| Baby_Spine | 63 | 30 | 30 |
| Pet_Dog | 212 | 106 | 13 |
| Pet_Cat | 171 | 82 | 5 |
| Pet_Horse | 44 | 37 | 1 |
**No cliente hoje:** só o `Avatar_Spine` está em `Resources`; os outros 586 esqueletos só existem como fixtures de teste (Toddler, Dog, Cat). Comportamento implementado: locomoção das 3 famílias, idle apropriado, spawn, e a CA de item do Character (catálogo de 974 handlers, 3.150 configs). Faltam: CA de roupa, drop area, brinquedo etc., e todos os esqueletos de objetos, ambiente e pets restantes.

## 3. O que ainda é só "existe", não "comportamento provado"
- Seleção de som por contexto (quem toca o quê e quando): mapeada para os handlers de som por nome; o `GameSoundPlayer` (volume por distância, `_ignoreDistance`, `_distanceFactor`, `_ignorePD`, loop) não foi decodificado.
- Música por cena (`BackgroundMusic`, `BackgroundPlanetSoundHandler` dia/pôr do sol/noite) e mixer/mute: só inventariados.
- Eventos Spine com `string` (4 payloads: `Ceiling_Tube_Working`, `Shooting_Stars`, `Manta_Flying`, `cat treat`): sem consumidor identificado.

## 4. Custo para ter TUDO no cliente
| Item | Hoje | Estimativa |
|---|---|---|
| Sons: converter 2.781 WAV (1,95 GB) para Vorbis | 0,4% no cliente | **medido por amostra (25 por categoria, ffmpeg libvorbis): ~190 MB em q3, ~213 MB em q5** (SFX ~93/104 MB, Música ~81/91 MB, Ambiente ~17/18 MB); razão ~10% do WAV |
| Animações: 587 esqueletos + atlas (87 MB texto) + texturas de atlas (112 MB PNG) | só Avatar | ~200 MB brutos; menos com compressão de textura |
| Código: `GameSoundPlayer` por nome, registro, importador | ausente | médio |
O repositório já versiona 3.177 arquivos de `Resources` (114 MB) em git comum, sem LFS.

## 5. Total e estratégia de armazenamento (decisão pendente)
Tudo no cliente: ~190–213 MB de som + ~200 MB de animações (texto + texturas de atlas, antes da compressão de textura do Unity) = **~400 MB de binários novos**. Precedente do projeto: 114 MB de `Resources` versionados em git comum (sem LFS). Opções: (a) git comum, (b) Git LFS, (c) fora do git (pacotes no Drive que já existem em `out/pack`) com script de importação reprodutível (WAV→Vorbis, cópia de esqueletos/atlas/texturas) e só o código e os índices (registro de sons, nomes) versionados.
