using System;
using AvatarWorld.Core.Economy;
using AvatarWorld.Core.Literacy;
using NUnit.Framework;

namespace AvatarWorld.Core.Tests
{
    public class LiteracyChallengeServiceTests
    {
        static LiteracyChallenge Challenge(int reward = 5) => new LiteracyChallenge
        {
            ChallengeId = "letter-B",
            Type = ChallengeType.LetterRecognition,
            Prompt = "Qual destas e a letra \"B\"?",
            Options = new System.Collections.Generic.List<string> { "A", "B", "C", "D" },
            CorrectOptionIndex = 1,
            CoinReward = reward,
        };

        static LiteracyChallengeService NewService(out PlayerState state)
        {
            state = PlayerState.CreateNew(0);
            var economy = new LocalStoreService(state, () => "tx");
            return new LiteracyChallengeService(state, economy);
        }

        [Test]
        public void CorrectAnswer_AwardsCoinsAndMarksCompleted()
        {
            var svc = NewService(out var state);
            var r = svc.Answer(Challenge(), 1);

            Assert.IsTrue(r.Correct);
            Assert.IsTrue(r.CoinsAwarded);
            Assert.AreEqual(5, r.CoinsEarned);
            Assert.AreEqual(5, state.PazuCurrency);
            Assert.IsTrue(state.IsChallengeCompleted("letter-B"));
        }

        [Test]
        public void WrongAnswer_NoCoinsNoCompletion()
        {
            var svc = NewService(out var state);
            var r = svc.Answer(Challenge(), 0);

            Assert.IsFalse(r.Correct);
            Assert.IsFalse(r.CoinsAwarded);
            Assert.AreEqual(0, state.PazuCurrency);
            Assert.IsFalse(state.IsChallengeCompleted("letter-B"));
        }

        [Test]
        public void RepeatedCorrectAnswer_DoesNotPayCoinsTwice()
        {
            var svc = NewService(out var state);
            svc.Answer(Challenge(), 1);
            var second = svc.Answer(Challenge(), 1);

            Assert.IsTrue(second.Correct);
            Assert.IsFalse(second.CoinsAwarded, "resposta certa repetida nao deve pagar moeda de novo");
            Assert.AreEqual(0, second.CoinsEarned);
            Assert.AreEqual(5, state.PazuCurrency, "saldo nao deve dobrar ao responder de novo");
        }

        [Test]
        public void ZeroRewardChallenge_CompletesWithoutCallingEarn()
        {
            var svc = NewService(out var state);
            var r = svc.Answer(Challenge(reward: 0), 1);

            Assert.IsTrue(r.Correct);
            Assert.IsFalse(r.CoinsAwarded);
            Assert.AreEqual(0, state.PazuCurrency);
            Assert.IsTrue(state.IsChallengeCompleted("letter-B"));
        }

        [Test]
        public void NullChallenge_Throws()
        {
            var svc = NewService(out _);
            Assert.Throws<ArgumentNullException>(() => svc.Answer(null, 0));
        }

        [Test]
        public void EmptyChallengeId_Throws()
        {
            var svc = NewService(out _);
            var c = Challenge();
            c.ChallengeId = "";
            Assert.Throws<ArgumentException>(() => svc.Answer(c, 1));
        }

        [Test]
        public void StarterContent_AllThreeTypesHaveValidCorrectIndexes()
        {
            foreach (var c in LiteracyContent.LetterRecognition())
                Assert.That(c.CorrectOptionIndex, Is.InRange(0, c.Options.Count - 1), c.ChallengeId);
            foreach (var c in LiteracyContent.SyllableBuilding())
                Assert.That(c.CorrectOptionIndex, Is.InRange(0, c.Options.Count - 1), c.ChallengeId);
            foreach (var c in LiteracyContent.ReadingComprehension())
                Assert.That(c.CorrectOptionIndex, Is.InRange(0, c.Options.Count - 1), c.ChallengeId);
        }

        [Test]
        public void StarterContent_ChallengeIdsAreUnique()
        {
            var all = new System.Collections.Generic.List<string>();
            foreach (var c in LiteracyContent.LetterRecognition()) all.Add(c.ChallengeId);
            foreach (var c in LiteracyContent.SyllableBuilding()) all.Add(c.ChallengeId);
            foreach (var c in LiteracyContent.ReadingComprehension()) all.Add(c.ChallengeId);

            CollectionAssert.AllItemsAreUnique(all);
        }

        [Test]
        public void FullSession_EarningAcrossTypes_AccumulatesInSameWallet()
        {
            var svc = NewService(out var state);
            svc.Answer(LiteracyContent.LetterRecognition()[0], LiteracyContent.LetterRecognition()[0].CorrectOptionIndex);
            svc.Answer(LiteracyContent.SyllableBuilding()[0], LiteracyContent.SyllableBuilding()[0].CorrectOptionIndex);
            svc.Answer(LiteracyContent.ReadingComprehension()[0], LiteracyContent.ReadingComprehension()[0].CorrectOptionIndex);

            Assert.AreEqual(5 + 8 + 12, state.PazuCurrency);
            Assert.AreEqual(3, state.Ledger.Count);
        }
    }
}
