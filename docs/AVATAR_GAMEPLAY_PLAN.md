# Plano de ação — jogo visual e criação de avatares

## Objetivo verificável

Entregar uma fatia jogável offline: entrar pela Home, ver um avatar montado com os assets locais, mudar sua aparência por controles visuais, salvar, fechar/reabrir e recuperar a mesma aparência. Em seguida, colocar o avatar em uma sala com interação por toque/arraste. Menus textuais, logs, mockups e avisos não satisfazem nenhum desses critérios.

Preservar Home, áudio, economia, desafios pedagógicos e alterações de outras sessões. Base atual observada: `e837dd7b`, que já inclui a alteração de quiz publicada em paralelo. Não usar reset/checkout sobre trabalho local. Commit e push somente de ciclos verificáveis, conforme autorização anterior.

## Método de loop

Cada ciclo registra no LOOP_STATE: objetivo observável, evidências de entrada (arquivo + identificador/hash), hipótese, mudança limitada, comando de teste, resultado efetivo e próximo impedimento. Estados: **pendente**, **em investigação**, **implementado sem validação**, **validado no Unity**, **validado no Android**. Um teste de dados não valida renderização; renderização não valida troca de roupas; APK gerado não valida interação.

Se uma hipótese falhar, guardar o erro e mudar uma variável por tentativa. Após três falhas equivalentes, investigar a causa antes de repetir. Nunca substituir silenciosamente uma função por um aviso e marcar o ciclo como concluído. Não expandir o catálogo antes de uma combinação completa funcionar na tela.

## Ciclos e critérios de aceite

| Ciclo | Entrega | Evidência para concluir |
| --- | --- | --- |
| 0 — mapa dos dados | Identificar skeleton, atlas, páginas, skins/attachments, configuração de cores e um personagem completo. Usar chaves (arquivo serializado, path_id), nunca path_id isolado. | Manifesto gerado por parser, dependências resolvidas, dimensões/formatos conferidos; separar observado de inferido. |
| 1 — avatar renderizado | Cena de trabalho isolada, câmera e iluminação/material compatíveis; um avatar completo visível com proporção correta. | Execução Unity com imagem real e sem slots essenciais ausentes; validar versão do Spine antes de adaptar dados. |
| 2 — personalização visual | Categorias com miniaturas: cabelo, parte superior, parte inferior, calçados e acessórios disponíveis no conjunto inspecionado; cores quando suportadas. | Toques mudam pixels/attachments do MESMO avatar; pelo menos duas alternativas reais por categoria entregue, nenhuma peça invisível vendida como funcional. |
| 3 — aparência persistente | Modelo versionado de aparência com IDs estáveis, validação de combinações e gravação no save atual sem perder moedas/desafios. | Testes de roundtrip, IDs inválidos, campos ausentes em saves antigos e reabertura do aplicativo mantendo aparência. |
| 4 — acesso pela Home | Entrada visual para personalizar e retorno à Home; manter acesso explícito aos desafios existentes. | Fluxo completo por toque no Android, sem telas duplicadas, overlays presos ou perda de save. |
| 5 — primeira sala jogável | Uma sala pequena com cenário local e o avatar criado; mover por toque/arraste e uma interação concreta com objeto. | Avatar aparece com a aparência salva e interage de fato; captura no aparelho. Extração visual de cenário sem interação não conclui o ciclo. |
| 6 — integração e entrega | Ampliar apenas os conjuntos confirmados, regressões, build Android e relatório de cobertura. | EditMode + testes de integração/PlayMode relevantes aprovados, APK instalado, checklist físico, SHA256, limitações e instruções para reproduzir assets em clone limpo. |

## Estratégia técnica e limites

Prioridade: provar o pipeline Spine existente com um conjunto real antes de reconstruir todos os sistemas do original. Inspecionar binários e configurações extraídas, usar os dumps existentes e confirmar skins/attachments com o runtime. Não inferir compatibilidade apenas do nome do arquivo. Não achatar o avatar em uma única imagem se isso impedir trocar peças.

O catálogo inicial será uma seleção pequena de peças existentes e compatíveis. Sem inventar preços, desbloqueios, dependências de servidor ou compras reais. Loja é um ciclo posterior à criação visual; integrar inventário à economia local somente após confirmar itens e política de preços. Animais, bebês, carros, todos os mundos, multiplayer e fidelidade completa ao original não fazem parte do primeiro marco.

Salvamento da aparência deve conviver com PlayerState/SaveStore e não carregar uma cópia independente do saldo. Recursos necessários ao APK entram em um pacote mínimo com metadados; não copiar 120 mil texturas para Resources. Verificar transparência, filtros, materiais e consumo de memória no Android.

## Marco que o usuário poderá validar

**Home → editor visual → trocar cabelo/roupa/acessório → salvar → fechar/reabrir → mesma aparência → primeira sala com avatar e uma interação.**

Cada trecho só será declarado concluído com sua evidência. Até lá, o objetivo geral permanece aberto, mesmo com testes verdes ou APK gerado.

## Estado do primeiro loop

- **Ciclo 0 em investigação:** probe de leitura executado no Unity com sucesso; inventário real: Spine 4.2.43, 1419 bones, 429 slots, 2120 skins, 2172 páginas, 3479 animações. Ver `AVATAR_ASSET_FINDINGS.md`.
- **Hipótese refutada:** aplicar os presets apenas com FindSkin. Dos 827 presets Character, 7539/12770 referências não existem diretamente no esqueleto. Roupas exigem resolução de templates/SUT. Não escolher PNGs por ordem de diretório: 1269 páginas têm múltiplas imagens candidatas com pixels distintos.
- **Prova CPU concluída (2026-10-31):** `AvatarRenderProbe.cs` rasteriza corpo+olhos+2 opções de cabelo com vértices/UVs reais do Spine e as 8 texturas únicas resolvidas; `out/avatar-preview.png` e `out/avatar-preview-hair-2.png` mostram o avatar reconhecível. Confirma a composição, não o renderer real (CPU, sem shader/material).
- **Ciclo 1 em investigação, prova GPU concluída (2026-10-31):** `AvatarGpuProbe.cs` renderiza o MESMO composto pelo runtime spine-unity real (`SkeletonAnimation`, shader `Spine/Skeleton`, `Mesh` gerada pelo próprio spine-unity: 608 vértices/656 triângulos) capturado por uma `Camera` Unity de verdade (GPU via GLX/Mesa neste host, sem `-nographics`). Resultado em `out/avatar-gpu-preview.png`.
  - **Hipótese refutada:** cortar o `.atlas` para só as 8 páginas usadas quebra o parse do esqueleto inteiro - `AtlasAttachmentLoader` resolve os attachments de TODAS as 2120 skins no parse inicial (não só as usadas), e uma página ausente de OUTRA skin (`General/Emotion_Droplet`) derruba a leitura inteira com `SkeletonDataAsset.GetSkeletonData` retornando null silenciosamente (`CreateRuntimeInstance` chama em modo "quiet"). Corrigido: atlas completo (2172 páginas) + `Material[]` com textura real só nas 8 páginas usadas e um Material "dummy" único compartilhado pelas ~2164 restantes (a lib casa por nome de textura, não por índice, então o dummy não precisa ser distinto por página).
  - **Achado adicional:** `SkeletonDataAsset.GetSkeletonData` decide binário vs JSON pelo **nome** do `TextAsset` conter ".skel", não pelo conteúdo - um `TextAsset` construído de bytes binários sem esse nome é lido (errado) como JSON.
  - **Artefato encontrado e corrigido na mesma prova:** a primeira captura tinha manchas brancas translúcidas sobre partes do corpo/rosto. Causa: o shader `Spine/Skeleton` espera textura com alpha **pré-multiplicado** (padrão do export real do Spine); os PNGs extraídos são alpha reto. Corrigido pré-multiplicando RGB por A em código logo após carregar cada textura (`PremultiplyAlpha` em `AvatarGpuProbe.cs`). Recaptura em `out/avatar-gpu-preview.png` sem o artefato, visualmente limpa.
- **Ciclo 1 validado no Android (2026-10-31):** build isolado `com.c1c3ru.avatarvalidation` (cena própria `AvatarValidation.unity`, não toca Home/HomeBootstrap), instalado no aparelho físico (Xiaomi M2101K7BI). Capturas reais do device: `out/avatar_validation_android.png` e `out/avatar_validation_android2.png`. Resultado: avatar completo e reconhecível (corpo, olhos, cabelo com dois coques), mesma composição validada no Editor (CPU `AvatarRenderProbe` e GPU `AvatarGpuProbe`), 656 triângulos, animação `Idle_Stand_1` tocando — log `AvatarGpuRuntime: avatar valido, 656 triangulos reais, animacao Idle_Stand_1 tocando`, sem exceções fatais depois.
  - **Hipótese refutada:** copiar as 8 texturas para `Resources/AvatarSpine/Textures` bastaria sem mexer no import. Build Android: `Texture2D.GetPixels32: texture data is either not readable...` — tela preta (reportado pelo usuário como "erro tela preta com debug em vermelho"). Causa: import padrão do Unity marca `isReadable: 0`; `PremultipliedCopy` (pré-multiplicação de alpha) precisa ler pixels em CPU. Corrigido via `isReadable: 1` nos 8 `.meta` de `Assets/Resources/AvatarSpine/Textures/`.
  - **Achado adicional (não bloqueante):** com o atlas completo (2172 páginas) + 1 Material dummy compartilhado, `Spine.Atlas` loga um `Debug.LogError` ("Material with texture name ... not found for atlas asset") para CADA uma das ~2164 páginas não usadas (aparecem no Development Console on-screen do build de desenvolvimento). Não impede o parse nem o render — é ruído esperado da resolução por nome de textura, não uma falha. Mantido assim pois não compromete o Ciclo 1; se incomodar futuras capturas, considerar build sem `BuildOptions.Development` ou silenciar o overlay.
  - **Ajuste de câmera:** valores fixos de `orthographicSize`/posição (herdados do probe do Editor, outra resolução/aspect) enquadravam só quadril/pernas no aparelho (1080x2400). Corrigido em `AvatarGpuRuntime.cs` para enquadrar pelos bounds reais do `MeshRenderer` (`bounds.extents` + padding 15%), centralizado em `bounds.center`.
  - **Ciclo 1 agora satisfaz o critério de aceite integral:** "Execução Unity com imagem real e sem slots essenciais ausentes" com evidência de Editor (CPU+GPU) E Android (device físico).
- **Próxima prova:** templates/SUT de roupas (Ciclo 2) — resolver as ~7539/12770 referências de preset não encontradas diretamente no esqueleto, já que corpo/olhos/cabelo estão provados nos três contextos (CPU, GPU Editor, GPU Android).
- **Próximo rastreio:** `tools/avatar_bundle_inventory.py` consulta paths SUT do bundle local mantendo arquivo serializado e path_id; arquivos derivados permanecem em `out/assets` fora do Git.
- **Ciclos 2–6 pendentes.** Nenhum editor visual ou gameplay de avatar foi declarado pronto nesta etapa de planejamento/inventário.
