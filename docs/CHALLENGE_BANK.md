# Banco de desafios para ganhar moedas, 2026-11-03

Origem: lista de 100 desafios do autor do projeto (alfabetização e matemática, PT-BR). Código: `Scripts/Core/Literacy/{ChallengeBank,ChallengeDifficulty,ChallengeSelector}.cs`; diálogo: `Scripts/Runtime/LiteracyChallengeScreen.cs` (`BeginRandom`); testes: `Tests/EditMode/ChallengeBankTests.cs`.

## Conteúdo
Quatro grupos de 25, ids estáveis `bank-001`…`bank-100` na ordem da lista original: Português 6–8 anos (1–25), Português 9–10 (26–50), Matemática 6–8 (51–75), Matemática 9–10 (76–100). Em cada pergunta a primeira opção é a certa no banco; a ordem é sorteada ao exibir.

**Adaptações (o cliente não tem imagens/emoji nem resposta digitada):** perguntas que dependiam de figura ou de escrever a resposta viraram texto de múltipla escolha com 2 a 4 opções, mantendo o objetivo pedagógico (ex.: nº 1 usa ABELHA em vez da figura de maçã; nº 51 conta "O O O O O"; nº 97 descreve o gráfico em texto; nº 41 pergunta a grafia correta do inseto). Revisar o texto final com o autor/pedagogo.

## Dificuldade ligada ao valor do item
| Preço do item (moedas) | Nível | Recompensa por acerto |
| --- | --- | --- |
| até 500 | 1 fácil (6–8 anos) | 10 |
| 501 a 899 | 2 intermediário | 15 |
| 900 ou mais | 3 difícil (9–10 anos) | 20 |

Níveis: 1 = 30 desafios (itens 1–15 de Português e 51–65 de Matemática 6–8), 2 = 36 (16–25, 66–75, mais os mais simples de 9–10: 26–28, 30–34, 76–83), 3 = 34 (o restante de 9–10). Preços da loja original vão de 300 a 1400. Os limiares são decisão de produto e ficam em `ChallengeDifficulty`.

## Aleatoriedade sem repetição excessiva
`ChallengeSelector.Next(preço)` sorteia só do nível do preço e exclui os sorteados recentemente (janela = 2/3 do nível, ≈ 20–24 desafios), com histórico salvo no save (`PlayerState.RecentChallenges`, até 400 ids), então vale entre sessões. Todo o nível acaba sendo usado ao longo do tempo. Como a repetição é controlada pelo sorteio, o desafio do banco (`Repeatable`) paga moeda **a cada acerto** (os 12 desafios antigos continuam pagando só uma vez).

## Pacote Inicial
No original o botão leva à compra com dinheiro real (tela de pagamento do Google). Aqui `World_ShopButton StarterPack` abre o diálogo de desafios (`HomeBootstrap.OpenStarterPackChallenges`) com valor de referência `ChallengeDifficulty.StarterPackValue = 700` (nível médio, ajustável). Os desafios continuam até o jogador fechar. A loja (fatia 4 de `docs/STORE_WORLD_UI_SPEC.md`) deve chamar o mesmo seletor com o preço do item que o jogador quer.

## Caixa de diálogo
Referência do autor: `assets/exemplo_jogo_original/balao de texto.jpeg` (painel "Perfil local": balão claro com contorno preto grosso, cauda no canto superior direito, botões em pílula verde com contorno preto, texto escuro, Home visível atrás).
Implementação: sprite `Bubble` da Home original (513×206) recortado em `Resources/Icons/text_bubble_panel.png` (9-slice, virado para a cauda subir) e `text_bubble_tail.png`; opções em `pill_green.png` (gerada, gradiente ciano→verde). Bordas 2× (`pixelsPerUnitMultiplier = 1/2`: no `Image` do Unity valores MAIORES deixam as bordas mais finas). Título com pacote, nível e recompensa; X fecha; as entradas "Meu avatar"/"Desafio" da Home ficam escondidas enquanto o balão está aberto.

## Validação
- EditMode: 83/83 (21 novos: banco, dificuldade por preço, janela sem repetição, histórico entre sessões, opções embaralhadas, pagamento a cada acerto).
- Aparelho (Xiaomi M2101K7BI): build **lado a lado** (`ProjectSetup.BuildAndroidSideBySide`, id `com.c1c3ru.avatarworldoffline.sbs`, save próprio). Pacote Inicial abre o balão; acentos renderizam; acerto +15 moedas (80→95), opções travam e vem outra pergunta; capturas feitas na sessão (não versionadas).
- O app principal instalado no aparelho tem outra assinatura (build da outra máquina): `adb install -r` do build desta máquina é recusado (`INSTALL_FAILED_UPDATE_INCOMPATIBLE`). Não foi desinstalado (apagaria o save).
- Não testado: dificuldade fácil/difícil na tela (cobertos por testes), perguntas com 4 opções e com 2 opções na tela, feedback "Certo!" visível.
