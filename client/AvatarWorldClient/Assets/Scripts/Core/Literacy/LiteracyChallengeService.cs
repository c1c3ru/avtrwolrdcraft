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

        public AnswerResult Answer(LiteracyChallenge challenge, int selectedOptionIndex)
        {
            if (challenge == null) throw new ArgumentNullException(nameof(challenge));
            if (string.IsNullOrEmpty(challenge.ChallengeId)) throw new ArgumentException("ChallengeId vazio", nameof(challenge));

            bool correct = selectedOptionIndex == challenge.CorrectOptionIndex;
            if (!correct)
                return new AnswerResult { Correct = false, PazuCurrencyBalance = _state.PazuCurrency };

            bool alreadyDone = _state.IsChallengeCompleted(challenge.ChallengeId);
            if (!alreadyDone) _state.MarkChallengeCompleted(challenge.ChallengeId);
            // Desafios repetiveis (banco de 100) pagam a cada acerto; o seletor evita a repeticao.
            bool pays = (!alreadyDone || challenge.Repeatable) && challenge.CoinReward > 0;
            if (pays) _economy.Earn(challenge.CoinReward, "desafio:" + challenge.ChallengeId);

            return new AnswerResult
            {
                Correct = true,
                CoinsAwarded = pays,
                CoinsEarned = pays ? challenge.CoinReward : 0,
                PazuCurrencyBalance = _state.PazuCurrency,
            };
        }
    }
}
