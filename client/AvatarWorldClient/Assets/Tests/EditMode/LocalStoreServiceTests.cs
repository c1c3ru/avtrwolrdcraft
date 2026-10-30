using System;
using System.Linq;
using AvatarWorld.Core.Economy;
using NUnit.Framework;

namespace AvatarWorld.Core.Tests
{
    public class LocalStoreServiceTests
    {
        static StoreItem Hat(int price = 50) => new StoreItem { ItemGuid = "hat-1", Name = "Hat", PazuCurrencyPrice = price };

        static LocalStoreService NewService(int startingCoins, out PlayerState state)
        {
            state = PlayerState.CreateNew(startingCoins);
            int n = 0;
            return new LocalStoreService(state, () => "tx" + (++n));
        }

        [Test]
        public void Claim_DeductsPriceAndRecordsTransaction()
        {
            var svc = NewService(100, out var state);
            var r = svc.Claim(Hat(40));

            Assert.IsTrue(r.Success);
            Assert.AreEqual(ClaimError.None, r.Error);
            Assert.AreEqual(60, r.PazuCurrencyBalance);
            Assert.AreEqual(60, state.PazuCurrency);
            Assert.AreEqual("tx1", r.TransactionId);
            Assert.AreEqual(1, state.GetClaimCount("hat-1"));
            Assert.AreEqual(-40, state.Ledger.Single().PazuCurrencyDelta);
        }

        [Test]
        public void Claim_InsufficientFunds_ChangesNothing()
        {
            var svc = NewService(10, out var state);
            var r = svc.Claim(Hat(50));

            Assert.IsFalse(r.Success);
            Assert.AreEqual(ClaimError.InsufficientFunds, r.Error);
            Assert.AreEqual(10, state.PazuCurrency);
            Assert.AreEqual(0, state.GetClaimCount("hat-1"));
            Assert.IsEmpty(state.Ledger);
        }

        [Test]
        public void Claim_ExactBalance_Succeeds()
        {
            var svc = NewService(50, out var state);
            Assert.IsTrue(svc.Claim(Hat(50)).Success);
            Assert.AreEqual(0, state.PazuCurrency);
        }

        [Test]
        public void Claim_OneTime_SecondAttemptIsRefusedAndFlagsMaxClaims()
        {
            var svc = NewService(500, out var state);
            var item = Hat(10);
            item.IsOneTimeClaim = true;

            var first = svc.Claim(item);
            var second = svc.Claim(item);

            Assert.IsTrue(first.Success);
            Assert.IsTrue(first.HasReachedMaxClaims);
            Assert.IsFalse(second.Success);
            Assert.AreEqual(ClaimError.AlreadyClaimed, second.Error);
            Assert.IsTrue(second.HasReachedMaxClaims);
            Assert.AreEqual(490, state.PazuCurrency);
            Assert.AreEqual(1, state.Ledger.Count);
        }

        [Test]
        public void Claim_MaxClaims_AllowsExactlyThatMany()
        {
            var svc = NewService(1000, out var state);
            var item = Hat(10);
            item.MaxClaims = 3;

            for (int i = 0; i < 3; i++) Assert.IsTrue(svc.Claim(item).Success, "resgate " + (i + 1));
            var fourth = svc.Claim(item);

            Assert.AreEqual(ClaimError.AlreadyClaimed, fourth.Error);
            Assert.AreEqual(970, state.PazuCurrency);
            Assert.AreEqual(3, state.GetClaimCount("hat-1"));
        }

        [Test]
        public void Claim_RealMoneyItem_IsAlwaysRefused()
        {
            var svc = NewService(1000000, out var state);
            var item = Hat(0);
            item.RequiresRealMoney = true;
            item.IsFree = true; // mesmo marcado como gratis

            var r = svc.Claim(item);

            Assert.AreEqual(ClaimError.RequiresRealMoney, r.Error);
            Assert.AreEqual(1000000, state.PazuCurrency);
            Assert.IsEmpty(state.Ledger);
        }

        [Test]
        public void Claim_FreeItem_CostsNothingAndGrantsOnlyLoyaltyPoints()
        {
            var svc = NewService(5, out var state);
            var item = Hat(999);
            item.IsFree = true;
            item.LoyaltyPointsReward = 7;

            var r = svc.Claim(item);

            Assert.IsTrue(r.Success);
            Assert.AreEqual(5, state.PazuCurrency, "item gratis nao pode criar nem gastar pazuCurrency");
            Assert.AreEqual(7, state.LoyaltyPoints);
            Assert.AreEqual(7, r.LoyaltyPointsBalance);
        }

        [Test]
        public void Claim_NegativePrice_IsNotAvailable()
        {
            var svc = NewService(10, out var state);
            var r = svc.Claim(Hat(-100));

            Assert.AreEqual(ClaimError.NotAvailable, r.Error);
            Assert.AreEqual(10, state.PazuCurrency);
        }

        [Test]
        public void Claim_NullOrNoGuid_IsUnknownItem()
        {
            var svc = NewService(10, out _);
            Assert.AreEqual(ClaimError.UnknownItem, svc.Claim(null).Error);
            Assert.AreEqual(ClaimError.UnknownItem, svc.Claim(new StoreItem()).Error);
        }

        [Test]
        public void Earn_AddsCoinsAndRecordsTransaction()
        {
            var svc = NewService(0, out var state);
            svc.Earn(25, "diamond");

            Assert.AreEqual(25, state.PazuCurrency);
            Assert.AreEqual("diamond", state.Ledger.Single().Reason);
        }

        [TestCase(0)]
        [TestCase(-5)]
        public void Earn_NonPositive_Throws(int amount)
        {
            var svc = NewService(0, out _);
            Assert.Throws<ArgumentOutOfRangeException>(() => svc.Earn(amount, "x"));
        }

        [Test]
        public void TransactionIds_AreUniqueAcrossOperations()
        {
            var svc = NewService(100, out var state);
            svc.Earn(10, "a");
            svc.Claim(Hat(5));
            svc.Earn(10, "b");

            Assert.AreEqual(3, state.Ledger.Select(t => t.TransactionId).Distinct().Count());
        }

        [Test]
        public void CreateNew_NegativeStartingBalance_Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => PlayerState.CreateNew(-1));
        }
    }
}
