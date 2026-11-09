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
            Assert.AreEqual(23, StoreCatalog.All.Count);
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
            Assert.AreEqual(1200, StoreCatalog.Find("bundle-PB25").Price); // Amiguinhos (1500 -> 1200); nao e o hamster de 500
            Assert.AreEqual(450, StoreCatalog.Find("bundle-PB27").Price);  // Festa a Fantasia (600 -> 450); arte confirma o card
        }

        [Test]
        public void Categories_CoinsHasNoOffersAndCombosHasAll()
        {
            Assert.AreEqual(0, StoreCatalog.InCategory(StoreCatalog.CategoryCoins).Count);
            Assert.AreEqual(StoreCatalog.All.Count, StoreCatalog.InCategory(StoreCatalog.CategoryCombos).Count);
            Assert.Greater(StoreCatalog.InCategory(StoreCatalog.CategoryFeatured).Count, 0);
            // CategoryAvatarMaker nunca tem ofertas de proposito: StoreScreen trata a selecao como navegacao
            // (abre AvatarSlotsScreen) em vez de listar cartoes, entao fica fora tanto do ComingSoon quanto
            // desta checagem de "toda categoria ativa tem pelo menos uma oferta".
            foreach (var category in StoreCatalog.Categories.Where(c => c != StoreCatalog.CategoryCoins && c != StoreCatalog.CategoryCombos && c != StoreCatalog.CategoryFeatured && c != StoreCatalog.CategoryAvatarMaker && !StoreCatalog.ComingSoon.Contains(c)))
                Assert.Greater(StoreCatalog.InCategory(category).Count, 0, category);
        }

        [Test]
        public void AvatarMaker_IsNavigationShortcutNotProductCategory()
        {
            Assert.AreEqual(0, StoreCatalog.InCategory(StoreCatalog.CategoryAvatarMaker).Count,
                "Criador de Avatar nao deve ter cartoes: StoreScreen.SelectCategory trata como atalho de navegacao.");
            CollectionAssert.DoesNotContain(StoreCatalog.ComingSoon, StoreCatalog.CategoryAvatarMaker,
                "nao e 'Em breve': a loja navega para o editor em vez de mostrar o aviso.");
            CollectionAssert.Contains(StoreCatalog.Categories, StoreCatalog.CategoryAvatarMaker,
                "continua no trilho, na mesma posicao do original.");
        }

        [Test]
        public void SubCategories_FilterOffersAndSkipSingleGroups()
        {
            var subs = StoreCatalog.SubCategories(StoreCatalog.CategoryHouses);
            Assert.GreaterOrEqual(subs.Count, 2);
            foreach (var sub in subs)
                foreach (var offer in StoreCatalog.InCategory(StoreCatalog.CategoryHouses, sub))
                    Assert.AreEqual(sub, offer.Sub);
            Assert.AreEqual(0, StoreCatalog.SubCategories(StoreCatalog.CategoryCelebrations).Count);
            // Volta as Aulas (PB3, arte real extraida de resources.assets) deu ao Profissoes seu 2o item e um sub-trilho.
            Assert.AreEqual(2, StoreCatalog.SubCategories(StoreCatalog.CategoryProfessions).Count);
            Assert.AreEqual(StoreCatalog.InCategory(StoreCatalog.CategoryHouses).Count,
                StoreCatalog.InCategory(StoreCatalog.CategoryHouses, null).Count);
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
