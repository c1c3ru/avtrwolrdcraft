using System.Linq;
using AvatarWorld.Core.Economy;
using NUnit.Framework;
using UnityEngine;

namespace AvatarWorld.Core.Tests
{
    public class ItemCatalogTests
    {
        [TestCase("food", ItemPricing.Small)]
        [TestCase("makeup", ItemPricing.Small)]
        [TestCase("character", ItemPricing.Medium)]
        [TestCase("Wall", ItemPricing.Medium)]
        [TestCase("ugc", ItemPricing.Large)]
        [TestCase("poolboxpack", ItemPricing.Large)]
        [TestCase("dreamybabypf33box", ItemPricing.Large)]
        [TestCase("", ItemPricing.Small)]
        [TestCase(null, ItemPricing.Small)]
        public void PriceFor_FollowsTheThreeBands(string category, int expected) =>
            Assert.AreEqual(expected, ItemPricing.PriceFor(category));

        [Test]
        public void Bands_MatchTheDecidedRanges()
        {
            Assert.LessOrEqual(ItemPricing.Small, 500);
            Assert.That(ItemPricing.Medium, Is.InRange(501, 899));
            Assert.GreaterOrEqual(ItemPricing.Large, 900);
        }

        [TestCase("Food_01_ChocoSnackbar_Box_P134", "Food 01 Choco Snackbar Box")]
        [TestCase("Character_Accessories_Body_Bags_101", "Character Accessories Body Bags 101")]
        [TestCase("Cushion_04_Z1B1L1", "Cushion 04")]
        [TestCase("Flag_Z1B1L1", "Flag")]
        [TestCase("Pizza_Shop_T1S4", "Pizza Shop")]
        [TestCase("P134", "P134")]
        [TestCase("", "")]
        public void Display_StripsCodesAndSplitsWords(string raw, string expected) =>
            Assert.AreEqual(expected, ItemNames.Display(raw));

        static CatalogItem I(string g, string n, string c) => new CatalogItem { Guid = g, Name = n, Category = c };

        [Test]
        public void Index_DedupsByGuid_GroupsAndPages()
        {
            var idx = new ItemCatalogIndex(new[] { I("a", "Bolo", "food"), I("a", "Outro", "toy"), I("b", "Anel", "food"), I("c", "Bola", "toy"), I("d", "Pao", "food") });
            Assert.AreEqual(4, idx.Count);
            CollectionAssert.AreEqual(new[] { "food", "toy" }, idx.Categories());
            Assert.AreEqual(2, idx.PageCount("food", 2));
            CollectionAssert.AreEqual(new[] { "Anel", "Bolo" }, idx.Page("food", 0, 2).Select(i => i.Name));
            CollectionAssert.AreEqual(new[] { "Pao" }, idx.Page("food", 1, 2).Select(i => i.Name));
            Assert.IsEmpty(idx.Page("nada", 0, 2));
        }

        [Test]
        public void ClaimingAnItem_SpendsOnceAndIsOneTime()
        {
            var item = I("g1", "Cadeira", "chair");
            var state = PlayerState.CreateNew(1000);
            var svc = new LocalStoreService(state);
            var first = svc.Claim(item.ToStoreItem());
            Assert.IsTrue(first.Success);
            Assert.AreEqual(1000 - ItemPricing.Medium, state.PazuCurrency);
            var again = svc.Claim(item.ToStoreItem());
            Assert.IsFalse(again.Success);
            Assert.AreEqual(ClaimError.AlreadyClaimed, again.Error);
        }

        [Test]
        public void ShippedCatalog_LoadsWithEveryItemPriced()
        {
            var json = Resources.Load<TextAsset>("Store/items");
            Assert.IsNotNull(json);
            var data = JsonUtility.FromJson<Runtime.ItemCatalogFile>(json.text);
            var idx = new ItemCatalogIndex(data.items.Select(e => new CatalogItem { Guid = e.g, Name = e.n, Category = e.c }));
            Assert.AreEqual(25812 - 0, idx.Count, 100); // um por GUID unico (algumas linhas sem nome sao descartadas)
            Assert.IsTrue(idx.Categories().All(c => ItemPricing.PriceFor(c) >= ItemPricing.Small));
        }

        [Test]
        public void ShippedCatalog_HasNoOneLetterCategories()
        {
            // "c" (417 itens como "C_Scissors") e "x" (4 itens como "X_Obstacle_L150") eram artefato do
            // extrator (primeiro token antes de "_"), nao categoria real; viravam chip sem sentido no
            // trilho da loja por item. tools/build_item_catalog.py agora funde categoria de 1 caractere
            // em "outros". Ver docs/STORE_ORIGINAL_REFERENCE_2026-11-07.md.
            var json = Resources.Load<TextAsset>("Store/items");
            var data = JsonUtility.FromJson<Runtime.ItemCatalogFile>(json.text);
            var idx = new ItemCatalogIndex(data.items.Select(e => new CatalogItem { Guid = e.g, Name = e.n, Category = e.c }));
            CollectionAssert.DoesNotContain(idx.Categories().Select(c => c.Length), 1);
        }
    }
}
