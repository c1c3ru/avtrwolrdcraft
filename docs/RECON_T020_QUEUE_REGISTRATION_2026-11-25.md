# T020: evidencia das 74 classes pronta; registro na fila formal bloqueado nesta maquina — 2026-11-25

## O que esta pronto
- `tools/mb_stream_extract.py` ganhou duas ablacoes (`--no-fix-vectors`, `--no-fix-registry`) e `tools/recon_t020_register.py` monta, para cada uma das **74** tarefas `T020/CLASS/<hash>`,
  os tres arquivos que a tarefa declara (`class-contract.json`, `recount.json`, `result.json`) em `out/recon/tasks/T020/CLASS/<hash>/` (nao versionado, como as evidencias anteriores).
- **A causa de cada classe foi verificada por ablacao**, nao assumida (rodando as 74 sem cada correcao, 46 s a 10 min por rodada):

| Depende de | Classes | Evidencia |
|---|---:|---|
| so da correcao `List<String>` (`fix_mislabeled_vectors`) | 63 | sem ela nenhuma decodifica; sem a do registro continuam decodificando |
| so da correcao do registro `[SerializeReference]` | 7 | `LevelOnSpecificPairAnimationBetweenSpecificAvatars`, `LevelStaticConditionsResolver`, `LevelSecretVehicleInWorldPositionListener`, `LevelStaticConditionsResolverWithParkedVehicles`, `BWYWGiftData`, `LevelRecipeSecret`, `LevelItemConditionsResolver` |
| das duas | 4 | `LevelSecretAvatarAnimationSolvedListener`, `LevelOutfit`, `LevelStaticConditionsResolverWithDropAreas` (1 das 14 so precisa da primeira), `DailyTasksData` |
Isso corrige a classificacao antiga (por exemplo `LevelSecretAvatarAnimationSolvedListener` e `LevelOutfit` eram "mesmo bug" mas dependem tambem do registro).
- Em cada `recount.json`: contagem antes (declarada na tarefa, build anterior), depois (1.230), identidade de cada objeto (`path_id` + arquivo) e a reconciliacao. 70 das 74 batem com a contagem antiga ou a superam por conteudo
  novo; **4 divergem para mais** sem que eu saiba se e conteudo do 1.230 ou subcontagem antiga (declarado como desconhecido em cada `result.json`).

## O que NAO consegui fazer: registrar na fila
`reports/recon/tasks.json` tem `root: /home/c1c3ru/avtrwolrdcraft`, que nao existe aqui; toda operacao resolve os arquivos de evidencia a partir desse root. O caminho previsto para mudar de maquina, `Queue.relocate`,
**recusa**: `QueueError: stale reference: out/recon/tasks/T025/METHOD/5fe1bb4a25183678/method-contract.json`. Essa tarefa (`T025/METHOD/HomePlayButton.LoadPlayScene`) esta em `review` e 3 de 4 hashes de evidencia nao batem com os arquivos
(foram regerados depois do checkpoint). Contornar isso seria forjar o root ou editar a fila a mao; nao fiz. A fila real continua na revisao 235, intacta.

### Fluxo validado numa copia
Numa copia de `tasks.json` com o `root` ajustado so na copia, `--apply-queue` levou as 74 tarefas a `review` (a 1 que estava `blocked_external`, `BWYWGiftData`, passou por `configure` antes do `claim`), 223 mutacoes, sem erro;
o modo `--apply-queue --no-write` (usa a evidencia ja escrita) foi testado em 2 tarefas. Nada disso tocou a fila real.

### Como terminar (duas saidas, decisao do usuario)
1. **Na maquina cujo root existe** (`/home/c1c3ru/avtrwolrdcraft`): copiar `out/recon/tasks/T020/CLASS/<hash>/` das 74 tarefas e rodar
   `tools/venv/bin/python tools/recon_t020_register.py --apply-queue --no-write`. Fica `review`, aguardando revisor independente.
2. **Aqui**, depois de resolver `T025/METHOD/5fe1bb4a25183678` (reenviar com hashes atuais ou rejeitar por evidencia desatualizada; decisao de revisor), rodar `Queue.relocate` para este diretorio e entao `--apply-queue`.

## Limites
- Evidencia e do build **1.230**; a contagem declarada nas tarefas e do build anterior (`BUILD_NOTE` em cada arquivo).
- `check_read=True` valida bytes consumidos, nao o significado dos campos. Nenhuma tarefa foi marcada `done`; a revisao e independente.
