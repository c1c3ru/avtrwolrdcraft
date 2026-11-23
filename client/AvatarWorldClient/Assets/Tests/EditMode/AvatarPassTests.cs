using System.Linq;
using AvatarWorld.Core.Economy;
using AvatarWorld.Core.Localization;
using NUnit.Framework;

namespace AvatarWorld.Core.Tests
{
    public class AvatarPassTests
    {
        [Test] public void PassIsItsOwnCategoryAndStaysOutOfTheNormalCombos()
        {
            Assert.AreEqual(1, StoreCatalog.InCategory(StoreCatalog.CategoryAvatarPass).Count);
            Assert.AreSame(AvatarPass.Offer, StoreCatalog.Find(AvatarPass.Id));
            Assert.IsFalse(StoreCatalog.All.Any(o => o.Id == AvatarPass.Id), "o passe nao entra em Combos/Destaque");
            CollectionAssert.Contains(StoreCatalog.Categories, StoreCatalog.CategoryAvatarPass);
            Assert.Greater(AvatarPass.Price, StoreCatalog.All.Max(o => o.Price), "o passe custa mais que qualquer combo comum");
        }

        [Test] public void IncludedCombosExistAndAreWorthMoreThanThePass()
        {
            int total = 0;
            foreach (var id in AvatarPass.IncludedOfferIds)
            {
                var offer = StoreCatalog.Find(id);
                Assert.IsNotNull(offer, id);
                total += offer.Price;
            }
            Assert.Greater(total, AvatarPass.Price);
            Assert.AreEqual(AvatarPass.IncludedOfferIds.Count, AvatarPass.IncludedOfferIds.Distinct().Count());
        }

        [Test] public void BuyingWithoutEnoughCoinsChangesNothing()
        {
            var state = PlayerState.CreateNew(AvatarPass.Price - 1);
            var result = StoreCatalog.Buy(state, AvatarPass.Offer);
            Assert.IsFalse(result.Success);
            Assert.AreEqual(ClaimError.InsufficientFunds, result.Error);
            Assert.IsFalse(AvatarPass.IsActive(state));
            Assert.AreEqual(AvatarPass.Price - 1, state.PazuCurrency);
            foreach (var id in AvatarPass.IncludedOfferIds) Assert.AreEqual(0, state.GetClaimCount(id), id);
        }

        [Test] public void BuyingChargesOnceAndUnlocksTheIncludedCombos()
        {
            var state = PlayerState.CreateNew(AvatarPass.Price + 100);
            var result = StoreCatalog.Buy(state, AvatarPass.Offer);
            Assert.IsTrue(result.Success);
            Assert.AreEqual(100, state.PazuCurrency);
            Assert.IsTrue(AvatarPass.IsActive(state));
            Assert.IsTrue(StoreCatalog.IsOwned(state, AvatarPass.Offer));
            foreach (var id in AvatarPass.IncludedOfferIds)
            {
                Assert.AreEqual(1, state.GetClaimCount(id), id);
                Assert.IsTrue(StoreCatalog.IsOwned(state, StoreCatalog.Find(id)), id);
            }
            Assert.IsFalse(StoreCatalog.IsOwned(state, StoreCatalog.Find("bundle-PB22")), "combos fora do passe seguem a venda");

            var again = StoreCatalog.Buy(state, AvatarPass.Offer);
            Assert.IsFalse(again.Success);
            Assert.AreEqual(ClaimError.AlreadyClaimed, again.Error);
            Assert.AreEqual(100, state.PazuCurrency, "segunda compra nao cobra");
        }

        [Test] public void ComboAlreadyOwnedBeforeThePassKeepsASingleClaim()
        {
            var state = PlayerState.CreateNew(5000);
            string owned = AvatarPass.IncludedOfferIds[0];
            Assert.IsTrue(StoreCatalog.Buy(state, StoreCatalog.Find(owned)).Success);
            Assert.IsTrue(StoreCatalog.Buy(state, AvatarPass.Offer).Success);
            Assert.AreEqual(1, state.GetClaimCount(owned));
        }

        [Test] public void PackGateUnlocksPiecesOfTheIncludedCombos()
        {
            var state = PlayerState.CreateNew(AvatarPass.Price);
            // pega uma peca que so um combo do passe libera
            string piece = null;
            foreach (var offerId in AvatarPass.IncludedOfferIds)
            {
                piece = AllPiecesOf(offerId).FirstOrDefault(p => PackGate.OffersFor(p).Count == 1);
                if (piece != null) break;
            }
            if (piece == null) Assert.Inconclusive("nenhuma peca exclusiva dos combos do passe no indice atual");
            Assert.IsTrue(PackGate.IsLocked(state, piece));
            Assert.IsTrue(AvatarPass.Buy(state).Success);
            Assert.IsFalse(PackGate.IsLocked(state, piece));
        }

        static System.Collections.Generic.IEnumerable<string> AllPiecesOf(string offerId) =>
            StorePackContent.ItemsByOffer.TryGetValue(offerId, out var items) ? items : (System.Collections.Generic.IEnumerable<string>)new string[0];

        [Test] public void PassTextsExistInEveryLanguage()
        {
            foreach (var key in new[] { "cat.Passe de Avatar", "offer.avatar-pass", "pass.bought" })
                foreach (Language l in System.Enum.GetValues(typeof(Language)))
                    Assert.IsFalse(string.IsNullOrWhiteSpace(Loc.Get(key, l)), key + " / " + l);
        }
    }
}
