using System;
using System.Collections.Generic;

namespace AvatarWorld.Core.Literacy
{
    public enum ChallengeType
    {
        LetterRecognition,
        SyllableBuilding,
        ReadingComprehension,
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
    }
}
