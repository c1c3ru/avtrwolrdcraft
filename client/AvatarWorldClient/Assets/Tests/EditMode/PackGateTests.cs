using System.Linq;
using AvatarWorld.Core.Avatar;
using AvatarWorld.Core.Economy;
using NUnit.Framework;

namespace AvatarWorld.Core.Tests
{
    public class PackGateTests
    {
        [Test]
        public void PackItems_AreInTheEditorCatalogAndOffersExist()
        {
            Assert.Greater(StorePackContent.ItemsByOffer.Count, 0);
            foreach (var pair in StorePackContent.ItemsByOffer)
            {
                Assert.IsNotNull(StoreCatalog.Find(pair.Key), pair.Key);
                Assert.Greater(pair.Value.Length, 0, pair.Key);
                foreach (var item in pair.Value)
                    Assert.IsTrue(AvatarCatalog.OptionsByCategory.Values.Any(o => o.Contains(item)), item + " fora do catalogo do editor");
            }
        }

        [Test]
        public void PackItem_IsLockedUntilTheBundleIsBought_AndOtherItemsStayFree()
        {
            var offerId = StorePackContent.ItemsByOffer.Keys.First();
            var item = StorePackContent.ItemsByOffer[offerId][0];
            var state = PlayerState.CreateNew(5000);
            Assert.IsTrue(PackGate.IsLocked(state, item));
            Assert.IsFalse(PackGate.IsLocked(state, AvatarCatalog.DefaultOption(AvatarCatalog.CategoryShirt)));

            Assert.IsTrue(StoreCatalog.Buy(state, StoreCatalog.Find(offerId)).Success);
            Assert.IsFalse(PackGate.IsLocked(state, item));
        }
    }
}
