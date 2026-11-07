using System;
using System.Collections.Generic;

namespace AvatarWorld.Core.Literacy
{
    public enum ChallengeType
    {
        LetterRecognition,
        SyllableBuilding,
        ReadingComprehension,
        /// <summary>Banco de 100 desafios (ChallengeBank): portugues.</summary>
        LanguageArts,
        /// <summary>Banco de 100 desafios (ChallengeBank): matematica.</summary>
        Mathematics,
    }

    /// <summary>
    /// Pergunta de multipla escolha para alfabetizacao (6-8 anos). Os tres tipos pedagogicos
    /// (letra/fonema, montar palavra por silabas, leitura e compreensao) usam a mesma forma:
    /// um enunciado e opcoes, uma delas certa. So o conteudo muda por tipo.
    /// </summary>
    [Serializable]
    public sealed class LiteracyChallenge
    {
        /// <summary>Estavel entre sessoes: usado para nao pagar a mesma moeda duas vezes.</summary>
        public string ChallengeId;
        public ChallengeType Type;
        public string Prompt;
        public List<string> Options = new List<string>();
        public int CorrectOptionIndex;
        public int CoinReward = 5;
        /// <summary>Grupo do banco de desafios (ex.: "Matematica 6-8"); vazio nos desafios iniciais.</summary>
        public string Group;
        /// <summary>1 = facil, 2 = intermediario, 3 = dificil (ChallengeDifficulty); 0 = sem nivel.</summary>
        public int Difficulty;
        /// <summary>Paga moeda a cada acerto, nao so no primeiro. O sorteio sem repeticao excessiva
        /// (ChallengeSelector) e que impede o farm do mesmo desafio em sequencia.</summary>
        public bool Repeatable;
    }
}
