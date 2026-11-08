# Estratégia de memória para o Unity nesta máquina

A máquina de desenvolvimento tem só 7,1 GB de RAM e roda, em paralelo, vários jobs Claude Code (cada um
podendo ter seu próprio worktree e seu próprio `unity test`/`unity build`). Nesta sessão, três tentativas
de `unity test --mode EditMode` morreram por `SIGKILL` do **OOM killer do kernel**, confirmado via
`journalctl` (`global_oom`): numa das vezes a vítima foi um processo Python de outro job, nada a ver com o
Unity - ou seja, o problema não é "este Unity específico usa memória demais", é "memória total da máquina
estourou com vários processos pesados simultâneos". Duas estratégias complementares, nenhuma sozinha
resolve tudo:

## 1. Serializar execuções do Unity entre worktrees — `tools/unity_locked.sh`

Em vez de chamar `unity test ...` / `unity build ...` / `unity run ... -- -executeMethod ...` diretamente,
chame `tools/unity_locked.sh` com os mesmos argumentos:

```bash
tools/unity_locked.sh test client/AvatarWorldClient --mode EditMode \
  --output "$PWD/out/test-results.xml" -- -nographics -logFile "$PWD/out/unity_tests.log"
```

O script usa `flock` num arquivo fixo em `~/.cache/avatarworld-unity-lock/unity.lock` (por máquina, não por
worktree) para garantir que só uma invocação do Unity rode por vez nesta máquina, entre o checkout
principal e todos os worktrees. Uma segunda chamada **espera** (até 40 min) em vez de rodar em paralelo e
arriscar o OOM global. Não reduz o pico de memória de **um** Unity sozinho - resolve o caso mais comum
desta sessão, que foi **vários ao mesmo tempo**. Se o lock não liberar em 40 min, falha com mensagem clara
(`exit 75`) em vez de travar para sempre.

**Decisão a tomar pelo usuário:** isto é só uma convenção de uso (chamar o wrapper em vez do `unity` direto)
- não há como o Claude Code impor isso automaticamente a todo agente futuro sem um CLAUDE.md ou hook
dedicado. Enquanto isso não existir, qualquer sessão/agente que rodar `unity` direto volta a correr o risco
de OOM concorrente.

## 2. Unity Cache Server — evita reimportar o projeto inteiro em cada worktree novo

A maior parte do tempo/memória de um `unity test` num worktree **novo** vem da reimportação completa dos
assets (texturas, >120 mil arquivos) porque cada worktree tem seu próprio `Library/` vazio. Nesta sessão,
isso foi contornado manualmente copiando o `Library/` de 45 GB do checkout principal via `rsync` a cada
worktree novo - funciona, mas é lento e não é automático.

A forma correta é um **cache de artefatos de importação compartilhado** (protocolo Cache Server do próprio
Unity, já suportado pelo projeto - `client/AvatarWorldClient/ProjectSettings/EditorSettings.asset` já tem
os campos `m_CacheServerMode`/`m_CacheServerEndpoint`, hoje desligados). Instalei o `unity-cache-server`
(implementação de referência da própria Unity Technologies, npm) em
`~/.local/share/unity-cache-server/` e escrevi um script de controle:

```bash
~/.local/share/unity-cache-server/cache_server_ctl.sh start   # inicia em background, porta 8126
~/.local/share/unity-cache-server/cache_server_ctl.sh status
~/.local/share/unity-cache-server/cache_server_ctl.sh stop
```

Dados do cache ficam em `~/.cache/unity-cache-server-data/` (limite configurado: 60 GiB), fora do repositório
e de qualquer worktree - sobrevive a worktrees sendo criados/apagados.

**Pendente de aprovação do usuário - não fiz sozinho:**
- **Iniciar o servidor** (`cache_server_ctl.sh start`): o modo automático do Claude Code bloqueou essa ação
  com o motivo "Expose Local Services", mesmo sendo bind só em localhost. Precisa ser rodado manualmente ou
  com permissão explícita.
- **Um serviço systemd `--user` que inicia sozinho no boot/login** (unidade não foi criada: bloqueado como
  "Unauthorized Persistence"). Sem isso, o cache server só roda enquanto alguém (usuário ou um agente já
  autorizado) chamar `start` manualmente; ele não sobrevive a reboot.
- Depois de rodando, falta apontar os projetos Unity (checkout principal + cada worktree, já que
  `ProjectSettings/EditorSettings.asset` é versionado por checkout) para `127.0.0.1:8126` e trocar
  `m_CacheServerMode` de `0` para o modo que usa o cache - não testado ainda nesta sessão porque o servidor
  não chegou a rodar.

**Nota sobre o pacote:** `unity-cache-server` está marcado como *deprecated* no npm ("Package no longer
supported") - a Unity Technologies descontinuou em favor do "Unity Accelerator" (binário próprio, não
open-source, não verificado como disponível/instalável neste ambiente). O protocolo de rede que o projeto
já fala (`EditorSettings.asset`) deveria ser compatível mesmo assim, mas isso **não foi validado** nesta
sessão - o servidor nunca chegou a subir. Primeiro teste real a fazer: iniciar o servidor, apontar um
worktree novo (sem `Library/` nenhum) para ele, e comparar tempo/memória do `unity test` contra uma
reimportação a frio.

## Resumo do que falta, em ordem

1. Usuário aprova e roda `~/.local/share/unity-cache-server/cache_server_ctl.sh start` (ou dá permissão
   para o Claude Code rodar).
2. Validar que Unity 6000.6.6f1 realmente fala com essa versão do Cache Server (teste real num worktree
   vazio).
3. Se funcionar: configurar `m_CacheServerMode`/`m_CacheServerEndpoint` em cada
   `ProjectSettings/EditorSettings.asset` (principal + worktrees) para `127.0.0.1:8126`.
4. Se o usuário quiser que o cache server sobreviva a reboot: aprovar a criação do serviço systemd
   `--user` (unidade já redigida nesta sessão, só não foi aplicada).
5. Adotar `tools/unity_locked.sh` como padrão em toda chamada futura ao Unity neste projeto, documentando
   isso onde os próximos agentes forem procurar (este arquivo + `LOOP_STATE.md`).
