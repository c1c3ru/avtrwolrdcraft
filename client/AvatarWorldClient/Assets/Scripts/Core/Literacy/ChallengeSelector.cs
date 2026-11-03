using System;
using System.Collections.Generic;
using AvatarWorld.Core.Economy;

namespace AvatarWorld.Core.Literacy
{
    /// <summary>
    /// Sorteia desafios do banco para um item de dado valor: so do nivel de dificuldade do preco
    /// (ChallengeDifficulty.ForPrice), sem repetir os sorteados recentemente. A janela de "recentes"
    /// e 2/3 do nivel e fica salva no PlayerState, entao a protecao vale entre sessoes. A ordem das
    /// opcoes tambem e sorteada (a certa nao fica sempre na mesma posicao).
    /// </summary>
    public sealed class ChallengeSelector
    {
        const int MaxHistory = 400;
        readonly PlayerState _state;
        readonly IReadOnlyList<LiteracyChallenge> _bank;
        readonly Random _rng;

        public ChallengeSelector(PlayerState state, IReadOnlyList<LiteracyChallenge> bank = null, Random rng = null)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));
            _bank = bank ?? ChallengeBank.All();
            _rng = rng ?? new Random();
        }

        public int PoolSize(int difficulty) => Pool(difficulty).Count;

        /// <summary>Proximo desafio para um item de valor <paramref name="itemPrice"/>.</summary>
        public LiteracyChallenge Next(int itemPrice)
        {
            int difficulty = ChallengeDifficulty.ForPrice(itemPrice);
            var pool = Pool(difficulty);
            if (pool.Count == 0) throw new InvalidOperationException("Sem desafios para a dificuldade " + difficulty);

            int window = Math.Max(1, pool.Count * 2 / 3);
            var recentInLevel = new HashSet<string>();
            for (int i = _state.RecentChallenges.Count - 1; i >= 0 && recentInLevel.Count < window; i--)
            {
                string id = _state.RecentChallenges[i];
                if (pool.Exists(c => c.ChallengeId == id)) recentInLevel.Add(id);
            }
            var candidates = pool.FindAll(c => !recentInLevel.Contains(c.ChallengeId));
            if (candidates.Count == 0) candidates = pool; // janela nunca cobre o nivel todo; defesa extra
            var chosen = candidates[_rng.Next(candidates.Count)];

            _state.RecentChallenges.Add(chosen.ChallengeId);
            if (_state.RecentChallenges.Count > MaxHistory)
                _state.RecentChallenges.RemoveRange(0, _state.RecentChallenges.Count - MaxHistory);
            return ShuffledCopy(chosen);
        }

        List<LiteracyChallenge> Pool(int difficulty) => new List<LiteracyChallenge>(_bank).FindAll(c => c.Difficulty == difficulty);

        LiteracyChallenge ShuffledCopy(LiteracyChallenge source)
        {
            var order = new List<int>();
            for (int i = 0; i < source.Options.Count; i++) order.Add(i);
            for (int i = order.Count - 1; i > 0; i--)
            {
                int j = _rng.Next(i + 1);
                (order[i], order[j]) = (order[j], order[i]);
            }
            var copy = new LiteracyChallenge
            {
                ChallengeId = source.ChallengeId, Type = source.Type, Prompt = source.Prompt,
                CoinReward = source.CoinReward, Group = source.Group, Difficulty = source.Difficulty,
                Repeatable = source.Repeatable,
            };
            for (int i = 0; i < order.Count; i++)
            {
                copy.Options.Add(source.Options[order[i]]);
                if (order[i] == source.CorrectOptionIndex) copy.CorrectOptionIndex = i;
            }
            return copy;
        }
    }
}
