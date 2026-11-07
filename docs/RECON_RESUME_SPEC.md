# Retomada portátil e navegação original

## Pesquisa
- A fila viva veio de `/home/c1c3ru/avtrwolrdcraft`; o workspace atual é `/home/deppi/avatarworld-re`. Claims falham antes de executar análise. Não alterar hashes ou aprovações para contornar o erro.
- Binário e metadata locais foram revalidados; índices foram reconstruídos. Relatórios aceitos permanecem intactos.
- HomePlayButton.LoadPlayScene tem endereço conhecido; os corpos e guards de navegação precisam de contratos verificáveis antes de substituir o protótipo de quadra.
- Craft Anything foi clonado em `/tmp/avatar-craft-anything` para piloto isolado. Seu parser declara suporte v31; execução real ainda pendente.

## Especificação
1. `tools/recon_queue.py`: adicionar `relocate --root --actor --note`. Recusar leases ativos ou expirados ainda não recuperados. Verificar plano e inputs/evidências de tarefas aceitas/em revisão na nova raiz, com confinamento de caminhos e hashes; preservar estados, autores, hashes e histórico. Pending continua revalidado no claim. Gravar atomicamente com histórico e revisão nova.
2. `tools/test_recon_queue.py`: verificar migração seguida de claim, rejeição de conteúdo alterado, symlink externo e lease; falhas não mudam o arquivo da fila.
3. Piloto externo: obter release oficial, conferir checksum publicado e executar consultas limitadas em arquivos locais; manter sessões e saídas em `/tmp`/`out/recon`, sem instalar globalmente.
4. Navegação: adquirir pacote HomePlayButton, recuperar ramos/callees e produzir verificador com mutações negativas. Contratos continuam candidatos e tarefas sem revisão independente não viram done.
5. Documentar resultados e limites reais. Nenhuma atualização Android com assinatura diferente ou perda de save.
