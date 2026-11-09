using System;
using AvatarWorld.Core.Economy;

namespace AvatarWorld.Core.Literacy
{
    /// <summary>
    /// Avalia respostas de LiteracyChallenge e paga moedas pelo LocalStoreService.
    /// Resposta certa repetida nao paga moeda de novo (evita farm respondendo o mesmo desafio em loop),
    /// mas pode ser respondida de novo livremente para pratica - so nao gera moeda extra.
    /// </summary>
    public sealed class LiteracyChallengeService
    {
        readonly PlayerState _state;
        readonly LocalStoreService _economy;

        public LiteracyChallengeService(PlayerState state, LocalStoreService economy)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));
            _economy = economy ?? throw new ArgumentNullException(nameof(economy));
        }

        public int PazuCurrencyBalance => _state.PazuCurrency;

        /// <param name="attemptNumber">1a tentativa no desafio atual = 1. Chutar varias opcoes ate
        /// acertar reduz a recompensa (2a tentativa paga metade, da 3a em diante nao paga nada) sem
        /// descontar moedas ja ganhas - desincentiva brute-force sem punir quem errou de verdade.</param>
        public AnswerResult Answer(LiteracyChallenge challenge, int selectedOptionIndex, int attemptNumber = 1)
        {
            if (challenge == null) throw new ArgumentNullException(nameof(challenge));
            if (string.IsNullOrEmpty(challenge.ChallengeId)) throw new ArgumentException("ChallengeId vazio", nameof(challenge));

            bool correct = selectedOptionIndex == challenge.CorrectOptionIndex;
            if (!correct)
                return new AnswerResult { Correct = false, PazuCurrencyBalance = _state.PazuCurrency };

            bool alreadyDone = _state.IsChallengeCompleted(challenge.ChallengeId);
            if (!alreadyDone) _state.MarkChallengeCompleted(challenge.ChallengeId);
            int reward = RewardForAttempt(challenge.CoinReward, attemptNumber);
            // Desafios repetiveis (banco de 100) pagam a cada acerto; o seletor evita a repeticao.
            bool pays = (!alreadyDone || challenge.Repeatable) && reward > 0;
            if (pays) _economy.Earn(reward, "desafio:" + challenge.ChallengeId);

            return new AnswerResult
            {
                Correct = true,
                CoinsAwarded = pays,
                CoinsEarned = pays ? reward : 0,
                PazuCurrencyBalance = _state.PazuCurrency,
            };
        }

        static int RewardForAttempt(int baseReward, int attemptNumber)
        {
            if (baseReward <= 0 || attemptNumber <= 1) return baseReward;
            if (attemptNumber == 2) return Math.Max(1, baseReward / 2);
            return 0;
        }
    }
}
