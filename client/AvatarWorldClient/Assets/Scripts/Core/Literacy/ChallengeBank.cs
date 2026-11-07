using System.Collections.Generic;

namespace AvatarWorld.Core.Literacy
{
    /// <summary>
    /// Banco de 100 desafios do autor do projeto (alfabetizacao e matematica, PT-BR), em quatro
    /// grupos de 25: Portugues 6-8 anos (1-25), Portugues 9-10 (26-50), Matematica 6-8 (51-75) e
    /// Matematica 9-10 (76-100). A numeracao segue a lista original; o id estavel e "bank-NNN".
    /// Em cada Q(...) a PRIMEIRA opcao e a certa; a ordem e embaralhada ao sortear (ChallengeSelector).
    /// Adaptacoes: perguntas que dependiam de imagem, emoji ou resposta digitada viraram texto de
    /// multipla escolha (o cliente nao tem esses recursos); o sentido pedagogico foi preservado.
    /// Dificuldade: 1 = facil (6-8 anos), 2 = intermediaria, 3 = dificil (9-10 anos); ver ChallengeDifficulty.
    /// </summary>
    public static class ChallengeBank
    {
        public const string Portuguese68 = "Portugues 6-8";
        public const string Portuguese910 = "Portugues 9-10";
        public const string Math68 = "Matematica 6-8";
        public const string Math910 = "Matematica 9-10";

        static List<LiteracyChallenge> _all;

        public static IReadOnlyList<LiteracyChallenge> All() => _all ?? (_all = Build());

        static LiteracyChallenge Q(int n, string group, int level, string prompt, params string[] options) =>
            new LiteracyChallenge
            {
                ChallengeId = "bank-" + n.ToString("000"),
                Type = group == Math68 || group == Math910 ? ChallengeType.Mathematics : ChallengeType.LanguageArts,
                Group = group,
                Difficulty = level,
                Prompt = prompt,
                Options = new List<string>(options),
                CorrectOptionIndex = 0,
                CoinReward = ChallengeDifficulty.RewardFor(level),
                Repeatable = true,
            };

        static List<LiteracyChallenge> Build()
        {
            const string P1 = Portuguese68, P2 = Portuguese910, M1 = Math68, M2 = Math910;
            return new List<LiteracyChallenge>
            {
                // Portugues e leitura, 6 a 8 anos: consciencia fonologica, silabas, rimas, leitura basica.
                Q(1, P1, 1, "Qual é a primeira letra da palavra ABELHA?", "A", "B", "E", "L"),
                Q(2, P1, 1, "Qual é a última letra da palavra GATO?", "O", "G", "A", "T"),
                Q(3, P1, 1, "Quantas vezes abrimos a boca para falar BOLA?", "2", "1", "3", "4"),
                Q(4, P1, 1, "Complete a palavra: CA – __ – LO", "VA", "BA", "TA"),
                Q(5, P1, 1, "Qual palavra rima com PÃO?", "Mão", "Gato", "Casa"),
                Q(6, P1, 1, "Complete as vogais que sumiram: B __ L __", "O e A", "A e A", "I e E"),
                Q(7, P1, 1, "Caça ao intruso: qual destas palavras NÃO começa com B?", "Dado", "Bola", "Biscoito"),
                Q(8, P1, 1, "Desembaralhe as letras para formar uma palavra: L – S – O", "SOL", "LOS", "OSL"),
                Q(9, P1, 1, "Junte as sílabas MA + CA + CO e forme uma palavra:", "MACACO", "CAMACO", "COMACA"),
                Q(10, P1, 1, "Se eu tenho mais de um gato, eu tenho muitos...?", "gatos", "gato", "gatas"),
                Q(11, P1, 1, "Qual animal faz “Miau”?", "Gato", "Cachorro", "Pato"),
                Q(12, P1, 1, "Qual é a letra A minúscula?", "a", "e", "i"),
                Q(13, P1, 1, "Família do B: qual sílaba vem depois de BA, BE, BI...?", "BO", "BU", "BA"),
                Q(14, P1, 1, "Qual palavra está escondida no começo de MELANCIA?", "MEL", "LAN", "CIA"),
                Q(15, P1, 1, "Qual é o contrário de DIA?", "Noite", "Tarde", "Manhã"),
                Q(16, P1, 2, "Leitura relâmpago: a palavra PATO se refere a qual animal?", "Pato", "Gato", "Rato"),
                Q(17, P1, 2, "Organize a frase: gosta / O / banana / macaco / de", "O macaco gosta de banana.", "Banana gosta de O macaco.", "De macaco o banana gosta."),
                Q(18, P1, 2, "Mude “O menino” para o feminino:", "A menina", "O menina", "A menino"),
                Q(19, P1, 2, "Qual letra vem antes do C no alfabeto?", "B", "D", "A"),
                Q(20, P1, 2, "Um cachorro pequeno é um...?", "cachorrinho", "cachorrão", "cachorro"),
                Q(21, P1, 2, "Um peixe grande é um...?", "peixão", "peixinho", "peixe"),
                Q(22, P1, 2, "Quantas consoantes tem a palavra LUA?", "1", "2", "3"),
                Q(23, P1, 2, "O que rima com LEÃO?", "Coração", "Cama", "Pato"),
                Q(24, P1, 2, "Qual frase combina com a cena de um menino com um livro nas mãos?", "O menino lê um livro.", "O menino dorme na rua.", "O menino pula no mar."),
                Q(25, P1, 2, "Como se separa a palavra SAPATO em sílabas?", "SA-PA-TO", "SAP-A-TO", "S-APA-TO"),

                // Portugues e leitura avancada, 9 a 10 anos: gramatica, ortografia, interpretacao, vocabulario.
                Q(26, P2, 2, "Qual palavra tem o mesmo significado de ALEGRE?", "Feliz", "Triste", "Bravo"),
                Q(27, P2, 2, "Qual é o contrário de CORAJOSO?", "Medroso", "Forte", "Bravo"),
                Q(28, P2, 2, "Complete: BO__ (como em “BOM”). Qual letra falta?", "M", "N"),
                Q(29, P2, 3, "A palavra ÁRVORE é oxítona, paroxítona ou proparoxítona?", "Proparoxítona", "Paroxítona", "Oxítona"),
                Q(30, P2, 2, "Qual ponto usamos para fazer uma pergunta?", "?", "!", "."),
                Q(31, P2, 2, "“Eu comi a maçã” está no passado, presente ou futuro?", "Passado", "Presente", "Futuro"),
                Q(32, P2, 2, "Qual é a ação (verbo) na frase: “O cachorro correu rápido”?", "correu", "cachorro", "rápido"),
                Q(33, P2, 2, "Qual é a característica (adjetivo) em: “O carro vermelho quebrou”?", "vermelho", "carro", "quebrou"),
                Q(34, P2, 2, "Qual palavra deve ser escrita com letra maiúscula?", "brasil", "casa", "mesa"),
                Q(35, P2, 3, "Como se escreve: FELI__ ? (S ou Z)", "Z", "S"),
                Q(36, P2, 3, "Como se escreve: __ÍCARA ? (X ou CH)", "X", "CH"),
                Q(37, P2, 3, "Como se escreve: __IRASSOL ? (G ou J)", "G", "J"),
                Q(38, P2, 3, "Troque o nome por um pronome: “Maria é legal” → “__ é legal”.", "Ela", "Ele", "Nós"),
                Q(39, P2, 3, "Qual é a sílaba mais forte (tônica) da palavra FUTEBOL?", "BOL", "FU", "TE"),
                Q(40, P2, 3, "Pedro usava um chapéu azul e foi ao parque. Qual era a cor do chapéu?", "Azul", "Verde", "Vermelho"),
                Q(41, P2, 3, "Ditado: como se escreve o inseto de asas coloridas?", "Borboleta", "Borbuleta", "Borboletta"),
                Q(42, P2, 3, "Complete: “Queria brincar, ___ começou a chover.”", "mas", "porque", "então"),
                Q(43, P2, 3, "Um conjunto de lobos é uma...?", "alcateia", "manada", "cardume"),
                Q(44, P2, 3, "Na palavra SAÚDE, quais letras formam o hiato (vogais em sílabas separadas)?", "A e Ú", "S e A", "D e E"),
                Q(45, P2, 3, "Complete: FO__ETE", "GU", "G", "QU"),
                Q(46, P2, 3, "“__ você não veio?” (uma pergunta)", "Por que", "Porque", "Por quê"),
                Q(47, P2, 3, "“O gato bebeu leite.” Quem bebeu o leite?", "O gato", "O leite", "A casa"),
                Q(48, P2, 3, "A palavra PARALELEPÍPEDO é polissílaba (tem mais de três sílabas)?", "Verdadeiro", "Falso"),
                Q(49, P2, 3, "“Era uma vez...” costuma ser o começo de um...?", "Conto", "Receita", "Notícia"),
                Q(50, P2, 3, "O que significa “chorar sobre o leite derramado”?", "Lamentar algo que já não tem remédio", "Derramar leite no chão de propósito", "Ficar com muita sede"),

                // Matematica basica, 6 a 8 anos: contagem, adicao, subtracao, formas, nocoes espaciais.
                Q(51, M1, 1, "Quantas bolinhas há aqui?  O O O O O", "5", "4", "6", "3"),
                Q(52, M1, 1, "Qual número é maior: 7 ou 4?", "7", "4"),
                Q(53, M1, 1, "O que vem depois do 15?", "16", "14", "17"),
                Q(54, M1, 1, "Quanto é 3 + 2?", "5", "4", "6"),
                Q(55, M1, 1, "Soma visual: 2 maçãs + 1 maçã = ?", "3 maçãs", "2 maçãs", "4 maçãs"),
                Q(56, M1, 1, "Quanto é 5 − 1?", "4", "3", "6"),
                Q(57, M1, 1, "Qual figura tem 3 lados?", "Triângulo", "Quadrado", "Círculo"),
                Q(58, M1, 1, "O número 4 é par ou ímpar?", "Par", "Ímpar"),
                Q(59, M1, 1, "Quantas unidades formam 1 dezena?", "10", "5", "100"),
                Q(60, M1, 1, "Um doce custa 2 moedas e você tem 5. Quantas moedas sobram?", "3", "2", "7"),
                Q(61, M1, 1, "O ponteiro pequeno está no 3 e o grande no 12. Que horas são?", "3 horas", "12 horas", "6 horas"),
                Q(62, M1, 1, "O gato está sobre a mesa. Qual expressão significa “sobre”?", "Em cima", "Embaixo", "Dentro"),
                Q(63, M1, 1, "O que é mais pesado: uma pena ou um tijolo?", "Um tijolo", "Uma pena"),
                Q(64, M1, 1, "Qual é a metade de 4?", "2", "1", "4"),
                Q(65, M1, 1, "Qual é o dobro de 3?", "6", "5", "9"),
                Q(66, M1, 2, "Organize do menor para o maior: 5, 2, 8, 1", "1, 2, 5, 8", "8, 5, 2, 1", "2, 1, 5, 8"),
                Q(67, M1, 2, "Organize do maior para o menor: 10, 7, 9", "10, 9, 7", "7, 9, 10", "9, 10, 7"),
                Q(68, M1, 2, "Contando de 2 em 2, complete: 2, 4, 6, __", "8", "7", "9"),
                Q(69, M1, 2, "João tinha 3 balas e ganhou mais 4. Com quantas ficou?", "7", "6", "8"),
                Q(70, M1, 2, "Maria tinha 5 bonecas e deu 2 para a amiga. Quantas restaram?", "3", "2", "4"),
                Q(71, M1, 2, "Padrão: Coração, Estrela, Coração, ___ ?", "Estrela", "Coração", "Lua"),
                Q(72, M1, 2, "Quanto é 8 + 0?", "8", "0", "80"),
                Q(73, M1, 2, "Que dia vem depois de terça-feira?", "Quarta-feira", "Segunda-feira", "Quinta-feira"),
                Q(74, M1, 2, "Quantos meses tem 1 ano?", "12", "10", "24"),
                Q(75, M1, 2, "Como se escreve o número 12?", "Doze", "Dez", "Treze"),

                // Matematica avancada, 9 a 10 anos: multiplicacao, divisao, fracoes, logica, geometria.
                Q(76, M2, 2, "Quanto é 7 × 8?", "56", "54", "63"),
                Q(77, M2, 2, "Quanto é 20 ÷ 4?", "5", "4", "6"),
                Q(78, M2, 2, "Se eu dividir 10 balas entre 3 crianças, quantas sobram?", "1", "0", "2"),
                Q(79, M2, 2, "Qual é o triplo de 15?", "45", "30", "18"),
                Q(80, M2, 2, "Qual fração representa metade de uma pizza?", "1/2", "1/4", "2/3"),
                Q(81, M2, 2, "Quanto é 45 + 23?", "68", "58", "78"),
                Q(82, M2, 2, "Quanto é 52 − 19?", "33", "43", "37"),
                Q(83, M2, 2, "Um trem saiu às 14h e viajou por 3 horas. A que horas chegou?", "17h", "16h", "18h"),
                Q(84, M2, 3, "Quantos lados tem um hexágono?", "6", "5", "8"),
                Q(85, M2, 3, "Uma bola de futebol lembra qual sólido geométrico?", "Esfera", "Cubo", "Cilindro"),
                Q(86, M2, 3, "Se um quadrado tem 4 cm de lado, qual é o seu perímetro?", "16 cm", "8 cm", "12 cm"),
                Q(87, M2, 3, "Quantos quadradinhos de 1 cm cabem num retângulo de 2 cm × 3 cm?", "6", "5", "8"),
                Q(88, M2, 3, "Quanto recebo de troco ao pagar R$ 20,00 por um lanche de R$ 13,50?", "R$ 6,50", "R$ 7,50", "R$ 6,00"),
                Q(89, M2, 3, "Como se lê o número ordinal 15º?", "Décimo quinto", "Quinto décimo", "Quinze"),
                Q(90, M2, 3, "Qual é maior: 0,5 ou 0,25?", "0,5", "0,25"),
                Q(91, M2, 3, "Quanto é 1/3 de 30 figurinhas?", "10", "15", "20"),
                Q(92, M2, 3, "O que significa 50% de um prêmio?", "A metade", "O dobro", "Um quarto"),
                Q(93, M2, 3, "Que número tem 3 centenas, 4 dezenas e 2 unidades?", "342", "432", "324"),
                Q(94, M2, 3, "Qual número falta: 10 + ___ = 25?", "15", "35", "5"),
                Q(95, M2, 3, "Quantos centímetros tem 1 metro?", "100", "10", "1000"),
                Q(96, M2, 3, "Quantas gramas tem 1 quilograma?", "1000", "100", "10"),
                Q(97, M2, 3, "Num gráfico de barras: banana 5 votos, maçã 8 votos, uva 3 votos. Qual fruta foi a mais votada?", "Maçã", "Banana", "Uva"),
                Q(98, M2, 3, "Complete a sequência: 5, 10, 20, 40, ___", "80", "60", "50"),
                Q(99, M2, 3, "Num saco há 3 bolas vermelhas e 1 azul. Qual cor é mais fácil de sortear?", "Vermelha", "Azul", "As duas igual"),
                Q(100, M2, 3, "Pense num número, multiplique por 2, some 10, divida por 2 e subtraia o número que pensou. O resultado é sempre 5?", "Verdadeiro", "Falso"),
            };
        }
    }
}
