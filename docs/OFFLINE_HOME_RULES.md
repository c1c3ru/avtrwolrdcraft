# Regras locais da Home

Autorizadas pelo usuário em 2026-11-01. Estes preços e prêmios são decisões do cliente offline; não reproduzem o servidor original. Sem dinheiro real.

- Loja: três composições dos itens de avatar já renderizados: Passeio (15 moedas), Escola (20) e Fim de semana (25). A compra registra propriedade e aplica a aparência no mesmo salvamento. Reaplicar uma composição adquirida é grátis. O editor continua livre; a loja vende a composição pronta, sem bloquear opções anteriormente disponíveis.
- Presente inicial: 25 moedas, uma única vez por save.
- Presente diário: 10 moedas por data UTC. Usa o relógio do aparelho; não há proteção de servidor contra alteração de data.
- Passe: 60 moedas, ativação única. Três prêmios de 25 moedas ao completar 4, 8 e 12 desafios diferentes (o banco atual contém 12). Cada prêmio é resgatável uma única vez; conclusões anteriores contam. Não expira.
- Evento/calendário: oferece a atividade pedagógica existente e acesso ao presente diário. É uma atividade offline, sem paridade com eventos sazonais originais.
- Starter Pack abre a loja local. Widgets de presentes abrem os resgates; widgets de roupas abrem o editor existente.
- Reset Mode pede confirmação e abre uma nova sessão da quadra, com bola/placar iniciais, preservando avatar e economia. É limitado ao ambiente implementado.
- Saldo, propriedade, prêmios e aparência usam o mesmo PlayerState. Toda operação é persistida imediatamente; falha de escrita restaura o estado em memória. SaveStore usa arquivo temporário e substituição atômica.
- Multiplayer, login/cloud, logout e serviços externos continuam fora do escopo offline. Não são substituídos por avisos apresentados como funcionalidades.

Validação automatizada cobre saldo insuficiente, duplicidade, datas, marcos do passe, rollback de save e integração da compra/presente com o salvamento real.
