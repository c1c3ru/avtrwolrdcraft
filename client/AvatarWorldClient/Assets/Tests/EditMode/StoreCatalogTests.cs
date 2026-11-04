using System.Linq;
using AvatarWorld.Core.Economy;
using NUnit.Framework;
using UnityEngine;

namespace AvatarWorld.Core.Tests
{
    public class StoreCatalogTests
    {
        [Test]
        public void Catalog_HasUniqueIdsPricesInTheObservedRangeAndExistingArt()
        {
            Assert.AreEqual(22, StoreCatalog.All.Count);
            Assert.AreEqual(StoreCatalog.All.Count, StoreCatalog.All.Select(o => o.Id).Distinct().Count());
            foreach (var offer in StoreCatalog.All)
            {
                Assert.That(offer.Price, Is.InRange(300, 1400), offer.Id);
                Assert.IsNotNull(Resources.Load<Texture2D>("Store/packs/" + offer.Art), offer.Id + " cartao");
                Assert.IsNotNull(Resources.Load<Texture2D>("Store/covers/" + offer.Art), offer.Id + " capa");
            }
        }

        [Test]
        public void ObservedPrintPrices_AreKept()
        {
            Assert.AreEqual(1200, StoreCatalog.Find("bundle-PB22").Price); // Galxe Mansion
            Assert.AreEqual(1400, StoreCatalog.Find("bundle-PB7").Price);  // Natural Chic
            Assert.AreEqual(770, StoreCatalog.Find("bundle-PB26").Price);  // Casinha de brincar
            Assert.AreEqual(980, StoreCatalog.Find("bundle-PB23").Price);  // Show ao vivo
        }

        [Test]
        public void Categories_CoinsHasNoOffersAndCombosHasAll()
        {
            Assert.AreEqual(0, StoreCatalog.InCategory(StoreCatalog.CategoryCoins).Count);
            Assert.AreEqual(StoreCatalog.All.Count, StoreCatalog.InCategory(StoreCatalog.CategoryCombos).Count);
            Assert.Greater(StoreCatalog.InCategory(StoreCatalog.CategoryFeatured).Count, 0);
            foreach (var category in StoreCatalog.Categories.Where(c => c != StoreCatalog.CategoryCoins))
                Assert.Greater(StoreCatalog.InCategory(category).Count, 0, category);
        }

        [Test]
        public void Buy_SpendsCoinsOnceAndNeverGoesNegative()
        {
            var state = PlayerState.CreateNew(1000);
            var offer = StoreCatalog.Find("bundle-PB26"); // 770
            var first = StoreCatalog.Buy(state, offer);
            Assert.IsTrue(first.Success);
            Assert.AreEqual(230, state.PazuCurrency);
            Assert.IsTrue(StoreCatalog.IsOwned(state, offer));
            var again = StoreCatalog.Buy(state, offer);
            Assert.IsFalse(again.Success, "combo e de compra unica");
            Assert.AreEqual(230, state.PazuCurrency);

            var poor = PlayerState.CreateNew(100);
            var refused = StoreCatalog.Buy(poor, StoreCatalog.Find("bundle-PB7"));
            Assert.IsFalse(refused.Success);
            Assert.AreEqual(ClaimError.InsufficientFunds, refused.Error);
            Assert.AreEqual(100, poor.PazuCurrency);
            Assert.AreEqual(0, poor.Ledger.Count);
        }
    }
}
