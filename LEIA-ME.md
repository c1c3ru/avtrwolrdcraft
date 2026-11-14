# Como aplicar

1. Subagente (global):
   mkdir -p ~/.claude/agents && cp agents/inventario.md ~/.claude/agents/
2. Regras: copie CLAUDE.md para a raiz de cada projeto e preencha
   a seção "Comandos de verificação".
3. Dentro do Claude Code:
   /model sonnet
   /effort medium
   /advisor opus
   (o /advisor já persiste a escolha; só edite ~/.claude/settings.json
   à mão se confirmar o nome da chave na sua versão — rode /doctor
   ou /config. Faça merge, sem sobrescrever o arquivo existente.)
4. Meça com /usage e ajuste.
