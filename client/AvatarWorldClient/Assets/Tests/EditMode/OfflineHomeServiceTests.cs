using System;
using System.IO;
using AvatarWorld.Core.Economy;
using AvatarWorld.Core.Literacy;
using NUnit.Framework;

namespace AvatarWorld.Core.Tests
{
    public class OfflineHomeServiceTests
    {
        [Test] public void GiftsAreUniqueAndDailyGiftUsesUtcDate()
        {
            var state = PlayerState.CreateNew(0);
            var date = new DateTime(2026, 11, 1);
            var service = new OfflineHomeService(state, () => { }, () => date);
            service.StarterGift(); service.StarterGift();
            service.DailyGift(); service.DailyGift();
            Assert.AreEqual(35, state.PazuCurrency);
            date = date.AddDays(1);
            service.DailyGift();
            Assert.AreEqual(45, state.PazuCurrency);
            Assert.AreEqual(3, state.Ledger.Count);
        }

        [Test] public void FailedSaveRollsBackCurrencyOwnershipAndAppearance()
        {
            var state = PlayerState.CreateNew(75);
            string hair = state.Appearance.HairId;
            var service = new OfflineHomeService(state, () => { throw new IOException("disk full"); });
            Assert.Throws<IOException>(() => service.Outfit(0));
            Assert.AreEqual(75, state.PazuCurrency);
            Assert.IsFalse(service.OwnsOutfit(0));
            Assert.AreEqual(hair, state.Appearance.HairId);
            Assert.AreEqual(0, state.Ledger.Count);
            Assert.Throws<IOException>(() => service.StarterGift());
            Assert.IsFalse(service.HasStarterGift);
            Assert.AreEqual(75, state.PazuCurrency);
        }

        [Test] public void PassRewardsRequirePurchaseAndDistinctChallengeMilestones()
        {
            var state = PlayerState.CreateNew(75);
            var service = new OfflineHomeService(state, () => { });
            service.ClaimPassReward(1);
            Assert.AreEqual(75, state.PazuCurrency);
            service.BuyPass(); service.BuyPass();
            Assert.AreEqual(15, state.PazuCurrency);
            service.ClaimPassReward(1);
            Assert.AreEqual(15, state.PazuCurrency);
            for (int i = 0; i < 5; i++) state.CompletedChallenges.Add("challenge-" + i);
            service.ClaimPassReward(1); service.ClaimPassReward(1);
            Assert.AreEqual(40, state.PazuCurrency);
            service.ClaimPassReward(2);
            Assert.AreEqual(40, state.PazuCurrency);
        }

        [Test] public void InsufficientFundsCannotBuyOrApplyOutfit()
        {
            var state = PlayerState.CreateNew(0);
            var service = new OfflineHomeService(state, () => Assert.Fail("Não deve salvar uma compra recusada"));
            string hair = state.Appearance.HairId;
            service.Outfit(0); service.BuyPass();
            Assert.AreEqual(hair, state.Appearance.HairId);
            Assert.IsFalse(service.OwnsOutfit(0));
            Assert.IsFalse(service.HasPass);
            Assert.AreEqual(0, state.Ledger.Count);
        }

        [Test] public void AllPassRewardsAreReachableWithCurrentChallengeContent()
        {
            var state = PlayerState.CreateNew(60);
            var service = new OfflineHomeService(state, () => { });
            service.BuyPass();
            var content = LiteracyContent.LetterRecognition();
            content.AddRange(LiteracyContent.SyllableBuilding());
            content.AddRange(LiteracyContent.ReadingComprehension());
            foreach (var challenge in content) state.CompletedChallenges.Add(challenge.ChallengeId);
            for (int tier = 1; tier <= 3; tier++) service.ClaimPassReward(tier);
            Assert.AreEqual(75, state.PazuCurrency);
        }
    }
}
