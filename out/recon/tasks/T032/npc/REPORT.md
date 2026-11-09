# T032 — posição e autonomia de NPC, recorte 2026-11-08

Evidência local estática do par IL2CPP original (hashes em `manifest.json`). Não é execução no aparelho nem Evidence de um servidor REA. Reproduzir a coleta: `tools/venv/bin/python out/recon/tasks/T032/npc/extract.py` (capstone 5.0.9). Os arquivos `*.asm.txt` preservam endereços e instruções. Anotações de strings derivadas de registradores reaproveitados devem ser ignoradas; as conclusões abaixo usam apenas campos, branches e alvos confirmados. Limites das janelas seguem o próximo método conhecido e não garantem corpo completo.

## 1. Posição inicial: mapa de cena não equivale a NPC no mundo

`census.json`: todos os 229 `PWC.Level.LevelSceneAvatarMap` estão em `resources.assets`; contêm 1.170 registros, 1.157 IDs distintos e **1.170 `isOnPhone=true`**. Campos por registro: `id`, `position{x,y}`, `sceneGuid`, `isOnPhone`. Logo não se pode apresentar essas posições como personagens já colocados na cena ou como evidência de autonomia. São posições/dados de uma configuração de avatares, todos marcados no telefone no corpus observado. O consumo operacional foi aprofundado no complemento abaixo: a posição é usada como ownerPosition na recuperação de roupas excluídas do editor, enquanto a flag filtra IDs padrão do telefone.

O índice de chamadas diretas encontra `TryGetAvatars` em `LevelManager.GetAllLevelDefaultAvatarsID` e `RestoreMakerExcludedSkinClothingIfNeeded`; `TryGetAvatar` em `LevelAvatarExtensionMethods.<AvatarAwake>g__TryOverrideGuidCreation|3_0`. Não há base para o antigo raciocínio de que esses registros por si provam NPCs de interiores. `direct-callers.json` registra PCs e a limitação da atribuição ao método anterior.

## 2. Fundo: animação acionada, sem navegação recuperada

Há 9 `BackgroundCharacterSpineManager` (level135:5, level195:3, resources.assets:1) e 5 `BackgroundToddlerSpineManager` (todos resources.assets). Isso conta componentes serializados, não instâncias simultaneamente ativas.

`BackgroundCharacterSpineManager.Start` (`0x1e01664`) chama `EnsureSpine`, `AvatarSpineSkinsManagerBase.Init(_backgroundCharacterID)`, aplica pares categoria/skin adicionais se as listas forem não nulas, de mesmo comprimento e não vazias, depois armazena `SkeletonAnimation.AnimationName` em `_defaultIdleAnimation`. Toddler (`0x1e01840`) faz a mesma inicialização básica e salva o nome em `+0xc8`, sem listas adicionais.

Ambos `SetAnimation` (`0x1e017c8` / `0x1e01888`) fazem `AnimationState.SetAnimation(trackIndex:0, newAnimation, loop:false)` e `AddAnimation(trackIndex:0, defaultIdleAnimation, loop:true, delay:0)`. As identidades Spine foram confirmadas por join estrutural em `external-methods.json`, não inferidas pelos nomes dos assets. Nenhum desses quatro corpos escreve Transform.position, agenda tween ou sorteia destino. Os tipos declaram apenas Start/SetAnimation/ctor; isso delimita a ausência de algoritmo próprio de navegação nesses managers, sem excluir animações Spine, scripts externos, UnityEvents ou movimento de ancestral da hierarquia.

## 3. Caller: convocação é reposicionamento instantâneo ou spawn

`LevelCharacterCaller.CallCharacter` (`0x22af074`), campos do stub e predicado em `0x22afcb8`:

1. Busca `LevelCharacter` existente cujo `Id (+0x3c8)` seja `_config.id (+0x18)`.
2. Ponto é `_callPoint.position` se o objeto Unity existe; caso contrário `this.transform.position` (`0x22af1bc–0x22af1e0`).
3. Se existe e `shouldCallOnlyIfOutOfCameraView` é true, consulta **Renderer.isVisible** (`0x22af230`). Isso é visibilidade do renderer Unity, não um teste geométrico recuperado da câmera principal.
4. Se visível, não o reposiciona. Se `LockedCAHandler` for nulo e `animationNameOnInCameraView` não for vazia, toca `Animator.PlayAnimationAndReturnToProperIdle(name,false,false)`. Se sentado, antes toca `Track_Animations/Forced_To_Sit` na faixa 2 em loop. Se bloqueado por CA ou nome vazio, retorna.
5. Se não existe, chama `LevelUtils.SpawnAvatar(id, point, …)` em `0x22af334` e aceita somente Character. Se existe e precisa ser convocado, chama virtual de classe `+0x508` com `true` e então **Transform.set_position(point.x, point.y, 0)** (`0x22af398`). O join de vtable do recorte irmão `callbacks` resolve esse slot 61 como `LevelCharacter.DetachFromParentIfExists` (method_definition_index 31448).
6. Se `_isBasicDrop`, chama `PerformBasicDrop(false,true)`; aplica `_config.isCharacterFlipped`, efeito de aparecimento, itens da configuração e animação de chegada se não vazia (`Animator.SetAnimation`, loop da flag). Salva o nome de chegada em Character `+0x420`.

Não há interpolação de caminhada entre o ponto anterior e o callPoint nesse método. Animar chegada não deve ser implementado como autonomia. Censo: 31 callers (level62:1, level70:11, level141:3, resources.assets:16), 21 configs e 11 `LevelButlerCaller` em level62/70. O botão de butler desabilita sua flag de interação, toca som e inicia SwitchSprite; a corrotina chama CallCharacter (`PC 0x1e812e8`).

## 4. Movimento automático contextual existe, mas é de área

`LevelAirportWalkwayDropAreaHandler` tem 1 instância serializada, level67. `SyncMovement` (`0x1e3c7f8`) decide direção comparando AnimationName com `Moving_Left`, cancela tween anterior se houver ou registra clique para cancelamento, chama `LeanTween.moveLocalX(gameObject, direction * 17, 1)` e em seguida `setSpeed(1)`, instala completion e registra ID por LevelItem. `CancelMovement` (`0x1e3cbc8`) cancela ID, remove registro e remove callback de clique.

Portanto existe transporte automático acionado por área para **LevelItem**, sem demonstrar NPC que escolhe destino. `setSpeed(1)` é parte essencial; o argumento inicial duration=1 não permite afirmar que toda travessia dura 1 segundo. Não se generaliza esse mecanismo para todos os personagens/animais.

## Estado do checklist

- Respondido: classificação de fundo versus avatar/caller e limites das posições do mapa; contratos Start/SetAnimation dos managers; decisão de posição/visibilidade/convocação do caller; distinção de transporte por área.
- Parcial: busca de autonomia global. Os managers examinados não implementam navegação própria; não foi provada a ausência de autonomia em todo o jogo.
- Não executado: runtime no original/aparelho e paridade de cópia. Nenhum resultado estático deve promover essa validação a concluída.


## Complemento: consumidores de position / isOnPhone / sceneGuid

Corpos adicionados a este diretório, com endereços originais:

- `LevelManager.GetAllLevelDefaultAvatarsID` (`0x2314150`) obtém nome da cena ativa, chama `TryGetAvatars` e percorre os registros. `0x23142ac` lê `AvatarData.isOnPhone (+0x28)`; se false, continua para o próximo; se true, lê ID em `+0x10` e adiciona à lista retornada. Portanto a flag tem consumo concreto na lista de IDs padrão disponibilizada pelo manager.
- `LevelManager.RestoreMakerExcludedSkinClothingIfNeeded` (`0x2312694`) obtém o mapa da cena, percorre seus registros, carrega AvatarSpineData pelo ID e restringe o primeiro fluxo a SpineType Character=1. Consulta `TryGetMakerExcludedSkinsForCharacter` e as roupas excluídas; para cada skin elegível, **`0x2312bfc` lê `ldp s9,s8,[x25,#0x14]`**, os dois floats de `AvatarData.position`. Passa-os a `LevelClothingUtils.SpawnClothingItem` em `0x2312c2c`. O fluxo marca o item retornado como roupa recuperada. Assim, neste consumidor, a posição é o `ownerPosition` fornecido ao spawn de roupa restaurada, não trajetória nem spawn de NPC. O utilitário declara `GetPositionForSpawnedClothingItem`, portanto este recorte não afirma que a posição final da roupa seja idêntica ao ownerPosition.
- `LevelAvatarExtensionMethods.<AvatarAwake>g__TryOverrideGuidCreation|3_0` (`0x2290940`) tenta obter ILevelAvatar no PDSceneObject, requer ID positivo, chama `TryGetAvatar` em `0x2290a34`. Se o registro tem `sceneGuid (+0x20)` não vazio, devolve esse GUID. Senão usa `LevelUtils.CreateSceneGuidForAvatar(id)`. Esse consumidor não lê position/isOnPhone.
- `LevelManager.Init` chama `LevelSceneAvatarMap.LoadDataIfNeeded` (`0x231199c`). Inicializar a tabela não representa instanciar todos os personagens nela.

Os consumidores diretos dos getters foram enumerados por BL/B em segmentos executáveis (`direct-callers.json`). Não exclui obtenção dos dados por reflexão, serialização ou chamadas indiretas; as afirmações operacionais acima ficam limitadas aos corpos enumerados.

## Complemento: universo exato da busca por autonomia

`scan_autonomy.py` → `autonomy-name-scan.json`: varre **36.421 linhas de métodos de Assembly-CSharp, 4.810 tipos declarantes distintos**, no índice estrutural hashado. Busca marcadores NPC/Npc e AI seguido de maiúscula ou fim de nome, inclusive dentro de nomes CamelCase e os conceitos Autonom, Wander, Patrol, NavMesh, Pathfind, BehaviourTree/BehaviorTree/DecisionTree. Resultado: **1 candidato lexical**, `PazuCore.PazuCloud.PazuCloudDuplicatedDeviceTracker.GetAID`, referente a identificação do dispositivo e fora do subsistema de personagens; **0 nomes NPC/autonomia explícita**. Esse falso positivo permanece no resultado bruto. Busca adicional de movimento/follow/random-position/destination/waypoint/steering em tipos/métodos relacionados a Character/Toddler/Baby/Animal/Cat/Dog/Horse/Avatar/Pet devolve **320 candidatos** e preserva a lista; é deliberadamente ampla e inclui falsos positivos de `Remove` e corrotinas `MoveNext`.

A busca ampla de outros tipos encontra sistemas contextuais como `LevelAirportWalkwayDropAreaHandler`, `LevelCameraFollowSking`, `LevelSpineObjectSymmetricMovement`, `LevelMovingFish`, `LevelRoomba` e `AFCItweenMoveToRandomPosition`, além de UI e QA. Nome não prova semântica: apenas walkway e os managers/caller descritos neste relatório tiveram corpos examinados nesta rodada. O resultado sustenta um **negativo de nomes explícitos no universo fornecido**, não ausência global de IA/autonomia. Código com nomes genéricos, animações, handlers de área e UnityEvents pode expressar comportamento automático sem esses marcadores. Não inventar wander/patrol para NPC com base no mapa de posições.
