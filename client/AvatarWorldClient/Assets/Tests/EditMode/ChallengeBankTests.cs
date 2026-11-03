using System;
using System.Collections.Generic;
using System.Linq;
using AvatarWorld.Core.Economy;
using AvatarWorld.Core.Literacy;
using NUnit.Framework;

namespace AvatarWorld.Core.Tests
{
    public class ChallengeBankTests
    {
        [Test]
        public void Bank_HasHundredUniqueWellFormedChallengesInFourGroups()
        {
            var all = ChallengeBank.All();
            Assert.AreEqual(100, all.Count);
            Assert.AreEqual(100, all.Select(c => c.ChallengeId).Distinct().Count());
            foreach (var c in all)
            {
                Assert.GreaterOrEqual(c.Options.Count, 2, c.ChallengeId);
                Assert.LessOrEqual(c.Options.Count, 4, c.ChallengeId);
                Assert.AreEqual(c.Options.Count, c.Options.Distinct().Count(), c.ChallengeId + " tem opcoes repetidas");
                Assert.AreEqual(0, c.CorrectOptionIndex, c.ChallengeId + ": a certa e a primeira opcao no banco");
                Assert.IsFalse(string.IsNullOrWhiteSpace(c.Prompt), c.ChallengeId);
                Assert.IsTrue(c.Repeatable, c.ChallengeId);
                Assert.AreEqual(ChallengeDifficulty.RewardFor(c.Difficulty), c.CoinReward, c.ChallengeId);
            }
            foreach (var group in new[] { ChallengeBank.Portuguese68, ChallengeBank.Portuguese910, ChallengeBank.Math68, ChallengeBank.Math910 })
                Assert.AreEqual(25, all.Count(c => c.Group == group), group);
        }

        [Test]
        public void Bank_EveryDifficultyHasEnoughChallengesToAvoidRepeats()
        {
            foreach (int level in new[] { 1, 2, 3 })
                Assert.GreaterOrEqual(ChallengeBank.All().Count(c => c.Difficulty == level), 30, "nivel " + level);
        }

        [Test]
        public void Bank_MatchesPromptsFromTheAuthorsList()
        {
            Assert.IsTrue(ChallengeBank.All().Single(c => c.ChallengeId == "bank-077").Prompt.Contains("20 ÷ 4"));
            Assert.AreEqual("5", ChallengeBank.All().Single(c => c.ChallengeId == "bank-077").Options[0]);
            Assert.AreEqual("56", ChallengeBank.All().Single(c => c.ChallengeId == "bank-076").Options[0]);
            Assert.AreEqual("Mão", ChallengeBank.All().Single(c => c.ChallengeId == "bank-005").Options[0]);
        }

        [TestCase(300, 1)]
        [TestCase(500, 1)]
        [TestCase(501, 2)]
        [TestCase(700, 2)]
        [TestCase(899, 2)]
        [TestCase(900, 3)]
        [TestCase(1400, 3)]
        public void Difficulty_FollowsItemPrice(int price, int expected)
        {
            Assert.AreEqual(expected, ChallengeDifficulty.ForPrice(price));
        }

        [Test]
        public void Rewards_GrowWithDifficulty()
        {
            Assert.Less(ChallengeDifficulty.RewardFor(1), ChallengeDifficulty.RewardFor(2));
            Assert.Less(ChallengeDifficulty.RewardFor(2), ChallengeDifficulty.RewardFor(3));
        }

        [Test]
        public void StarterPack_UsesMediumDifficulty()
        {
            Assert.AreEqual(ChallengeDifficulty.Medium, ChallengeDifficulty.ForPrice(ChallengeDifficulty.StarterPackValue));
        }
    }

    public class ChallengeSelectorTests
    {
        static ChallengeSelector NewSelector(PlayerState state, int seed = 7) =>
            new ChallengeSelector(state, null, new Random(seed));

        [TestCase(300, 1)]
        [TestCase(700, 2)]
        [TestCase(1200, 3)]
        public void Next_OnlyDrawsChallengesOfThePriceDifficulty(int price, int level)
        {
            var selector = NewSelector(PlayerState.CreateNew(0));
            for (int i = 0; i < 40; i++) Assert.AreEqual(level, selector.Next(price).Difficulty);
        }

        [Test]
        public void Next_DoesNotRepeatWithinTheRecentWindow()
        {
            var state = PlayerState.CreateNew(0);
            var selector = NewSelector(state);
            int pool = selector.PoolSize(2);
            int window = pool * 2 / 3;
            var ids = new List<string>();
            for (int i = 0; i < 300; i++) ids.Add(selector.Next(700).ChallengeId);
            for (int i = 0; i < ids.Count; i++)
                for (int j = Math.Max(0, i - window); j < i; j++)
                    Assert.AreNotEqual(ids[j], ids[i], "repetiu " + ids[i] + " a " + (i - j) + " sorteios");
        }

        [Test]
        public void Next_UsesTheWholeLevelOverTime()
        {
            var selector = NewSelector(PlayerState.CreateNew(0), 11);
            var seen = new HashSet<string>();
            for (int i = 0; i < 400; i++) seen.Add(selector.Next(300).ChallengeId);
            Assert.AreEqual(selector.PoolSize(1), seen.Count);
        }

        [Test]
        public void Next_RemembersHistoryAcrossSelectorInstances()
        {
            var state = PlayerState.CreateNew(0);
            var first = NewSelector(state, 1).Next(300);
            // Mesmo seed = mesma sequencia: sem o historico salvo, o primeiro sorteio se repetiria.
            var second = NewSelector(state, 1).Next(300);
            Assert.AreNotEqual(first.ChallengeId, second.ChallengeId);
            Assert.AreEqual(2, state.RecentChallenges.Count);
        }

        [Test]
        public void Next_ShuffledOptionsKeepTheCorrectAnswer()
        {
            var selector = NewSelector(PlayerState.CreateNew(0), 3);
            bool movedAtLeastOnce = false;
            for (int i = 0; i < 60; i++)
            {
                var drawn = selector.Next(1000);
                var original = ChallengeBank.All().Single(c => c.ChallengeId == drawn.ChallengeId);
                Assert.AreEqual(original.Options[original.CorrectOptionIndex], drawn.Options[drawn.CorrectOptionIndex]);
                CollectionAssert.AreEquivalent(original.Options, drawn.Options);
                if (drawn.CorrectOptionIndex != 0) movedAtLeastOnce = true;
            }
            Assert.IsTrue(movedAtLeastOnce, "a resposta certa nunca saiu da primeira posicao");
        }

        [Test]
        public void Answer_RepeatableChallengePaysEveryCorrectAnswer()
        {
            var state = PlayerState.CreateNew(0);
            var economy = new LocalStoreService(state, () => Guid.NewGuid().ToString("N"));
            var service = new LiteracyChallengeService(state, economy);
            var challenge = NewSelector(state).Next(700);

            var first = service.Answer(challenge, challenge.CorrectOptionIndex);
            var again = service.Answer(challenge, challenge.CorrectOptionIndex);

            Assert.IsTrue(first.CoinsAwarded);
            Assert.IsTrue(again.CoinsAwarded);
            Assert.AreEqual(2 * ChallengeDifficulty.RewardFor(2), state.PazuCurrency);
            Assert.AreEqual(1, state.CompletedChallenges.Count(id => id == challenge.ChallengeId));
        }

        [Test]
        public void Answer_WrongAnswerPaysNothing()
        {
            var state = PlayerState.CreateNew(0);
            var service = new LiteracyChallengeService(state, new LocalStoreService(state, () => "tx"));
            var challenge = NewSelector(state).Next(300);
            int wrong = (challenge.CorrectOptionIndex + 1) % challenge.Options.Count;
            Assert.IsFalse(service.Answer(challenge, wrong).Correct);
            Assert.AreEqual(0, state.PazuCurrency);
        }
    }
}
