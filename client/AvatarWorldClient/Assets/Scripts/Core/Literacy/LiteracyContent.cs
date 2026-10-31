using System.Collections.Generic;

namespace AvatarWorld.Core.Literacy
{
    /// <summary>
    /// Conteudo inicial (6-8 anos, PT-BR). Um ponto de partida pequeno para validar a engine de
    /// desafios ponta a ponta; a curadoria pedagogica completa (progressao, mais palavras,
    /// textos) e trabalho de conteudo, nao de engine, e deve crescer aqui.
    /// </summary>
    public static class LiteracyContent
    {
        public static List<LiteracyChallenge> LetterRecognition() => new List<LiteracyChallenge>
        {
            Letter("B", new[] { "A", "B", "C", "D" }, 1),
            Letter("M", new[] { "N", "M", "H", "W" }, 1),
            Letter("S", new[] { "Z", "E", "S", "C" }, 2),
            Letter("O", new[] { "O", "Q", "D", "C" }, 0),
            Letter("T", new[] { "F", "T", "L", "J" }, 1),
        };

        public static List<LiteracyChallenge> SyllableBuilding() => new List<LiteracyChallenge>
        {
            Word("BOLA", new[] { "BO-LA", "LA-BO", "BO-LO" }, 0),
            Word("GATO", new[] { "TO-GA", "GA-TO", "GA-TA" }, 1),
            Word("CASA", new[] { "SA-CA", "CA-SO", "CA-SA" }, 2),
            Word("SAPO", new[] { "SA-PO", "PO-SA", "SA-PA" }, 0),
        };

        public static List<LiteracyChallenge> ReadingComprehension() => new List<LiteracyChallenge>
        {
            Reading(
                "reading-gato-telhado",
                "O gato subiu no telhado para ver o sol.\nOnde o gato subiu?",
                new[] { "No telhado", "Na cama", "No carro" }, 0),
            Reading(
                "reading-ana-bola",
                "Ana levou a bola vermelha para o parque.\nDe que cor era a bola?",
                new[] { "Azul", "Vermelha", "Verde" }, 1),
            Reading(
                "reading-chuva",
                "Comecou a chover e todos correram para casa.\nPor que todos correram?",
                new[] { "Porque estava chovendo", "Porque estava com fome", "Porque era hora de dormir" }, 0),
        };

        static LiteracyChallenge Letter(string target, string[] options, int correctIndex) => new LiteracyChallenge
        {
            ChallengeId = "letter-" + target,
            Type = ChallengeType.LetterRecognition,
            Prompt = "Qual destas e a letra \"" + target + "\"?",
            Options = new List<string>(options),
            CorrectOptionIndex = correctIndex,
            CoinReward = 5,
        };

        static LiteracyChallenge Word(string target, string[] options, int correctIndex) => new LiteracyChallenge
        {
            ChallengeId = "syllable-" + target,
            Type = ChallengeType.SyllableBuilding,
            Prompt = "Qual sequencia de silabas forma a palavra \"" + target + "\"?",
            Options = new List<string>(options),
            CorrectOptionIndex = correctIndex,
            CoinReward = 8,
        };

        static LiteracyChallenge Reading(string id, string prompt, string[] options, int correctIndex) => new LiteracyChallenge
        {
            ChallengeId = id,
            Type = ChallengeType.ReadingComprehension,
            Prompt = prompt,
            Options = new List<string>(options),
            CorrectOptionIndex = correctIndex,
            CoinReward = 12,
        };
    }
}
