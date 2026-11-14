#!/usr/bin/env bash
# Serializa toda invocacao do Unity Editor (batch mode: test, build, -executeMethod) nesta maquina, entre o
# checkout principal e todos os worktrees. Motivo: a maquina (7,1 GB RAM) roda varios jobs Claude Code em
# paralelo; rodar mais de um Unity ao mesmo tempo ja causou OOM global do kernel repetidas vezes (matou o
# processo Unity de uma sessao, e em outra rodada matou um processo Python de um job totalmente diferente -
# "global_oom", confirmado via journalctl). Nao resolve o uso de memoria de UM Unity sozinho; resolve o
# problema de VARIOS ao mesmo tempo. Ver docs/UNITY_MEMORY_STRATEGY_2026-11-07.md.
#
# uso: tools/unity_locked.sh <mesmos argumentos que voce passaria para o comando "unity">
# ex.:  tools/unity_locked.sh test client/AvatarWorldClient --mode EditMode --output out/r.xml -- -nographics
#
# O lock e por maquina (arquivo fixo em $HOME, nao por worktree), entao dois worktrees chamando isto ao
# mesmo tempo esperam um pelo outro em vez de rodar simultaneamente. Timeout de espera: 40 min (mesmo um
# build/test mais pesado desta base de asset grande termina antes disso); se estourar, falha com erro
# claro em vez de travar para sempre.
set -euo pipefail
LOCK_DIR="$HOME/.cache/avatarworld-unity-lock"
mkdir -p "$LOCK_DIR"
LOCK_FILE="$LOCK_DIR/unity.lock"
WAIT_TIMEOUT_SECONDS=2400

exec 9>"$LOCK_FILE"
if ! flock -w "$WAIT_TIMEOUT_SECONDS" 9; then
  echo "unity_locked.sh: esperei $WAIT_TIMEOUT_SECONDS s por outra execucao do Unity liberar o lock ($LOCK_FILE) e nao liberou. Abortando sem rodar." >&2
  exit 75
fi
echo "unity_locked.sh: lock adquirido, chamando unity $*" >&2
unity "$@"
