using System;
using System.Collections.Generic;
using System.Linq;
using AvatarWorld.Core.Economy;
using AvatarWorld.Core.Literacy;
using NUnit.Framework;

namespace AvatarWorld.Core.Tests
{
    public class ItemPricingTests
    {
        [Test]
        public void NullOrUnknownCategoryIsSmall()
        {
            Assert.AreEqual(ItemPricing.Small, ItemPricing.PriceFor(null));
            Assert.AreEqual(ItemPricing.Small, ItemPricing.PriceFor(""));
            Assert.AreEqual(ItemPricing.Small, ItemPricing.PriceFor("lamp"));
        }

        [Test]
        public void MatchIsCaseInsensitiveAndByWord()
        {
            Assert.AreEqual(ItemPricing.Medium, ItemPricing.PriceFor("Sofa"));
            Assert.AreEqual(ItemPricing.Medium, ItemPricing.PriceFor("LEGS_SHOES"));
            Assert.AreEqual(ItemPricing.Large, ItemPricing.PriceFor("Pool_Party"));
            Assert.AreEqual(ItemPricing.Large, ItemPricing.PriceFor("ugc_chair")); // Large vence Medium
        }

        [Test]
        public void LongCategoriesEndingInBoxArePacks_ButShortOnesAreNot()
        {
            Assert.AreEqual(ItemPricing.Large, ItemPricing.PriceFor("mysterybox"));
            Assert.AreEqual(ItemPricing.Small, ItemPricing.PriceFor("toybox")); // 6 letras: abaixo do limite da regra
        }

        [Test]
        public void TiersAreOrderedAndStayInsideTheAuthorBands()
        {
            Assert.Less(ItemPricing.Small, ItemPricing.Medium);
            Assert.Less(ItemPricing.Medium, ItemPricing.Large);
            Assert.LessOrEqual(ItemPricing.Small, ChallengeDifficulty.EasyMaxPrice);
            Assert.Greater(ItemPricing.Medium, ChallengeDifficulty.EasyMaxPrice);
            Assert.LessOrEqual(ItemPricing.Medium, ChallengeDifficulty.MediumMaxPrice);
            Assert.Greater(ItemPricing.Large, ChallengeDifficulty.MediumMaxPrice);
        }
    }

    public class ItemCatalogIndexTests
    {
        static CatalogItem Item(string guid, string name, string category) => new CatalogItem { Guid = guid, Name = name, Category = category };

        static ItemCatalogIndex Sample() => new ItemCatalogIndex(new[]
        {
            Item("g1", "b_lamp", "lamps"), Item("g2", "a_lamp", "lamps"), Item("g3", "c_lamp", "lamps"),
            Item("g4", "sofa_1", "sofas"), Item("g5", "sofa_2", "sofas"), Item("g6", "bed_1", "beds"),
        });

        [Test]
        public void DuplicateAndEmptyGuidsAreIgnored_FirstWins()
        {
            var index = new ItemCatalogIndex(new[] { Item("g1", "first", "x"), Item("g1", "second", "x"), Item("", "no_guid", "x"), Item(null, "null_guid", "x") });
            Assert.AreEqual(1, index.Count);
            Assert.AreEqual("first", index.Find("g1").Name);
        }

        [Test]
        public void CategoriesAreOrderedByCountDescendingThenName()
        {
            CollectionAssert.AreEqual(new[] { "lamps", "sofas", "beds" }, Sample().Categories().ToArray());
            CollectionAssert.AreEqual(new[] { "lamps" }, Sample().Categories(1).ToArray());
        }

        [Test]
        public void ItemsInACategoryAreSortedByName_AndPagedWithoutGapsOrOverlap()
        {
            var index = Sample();
            Assert.AreEqual(3, index.CountIn("lamps"));
            Assert.AreEqual(2, index.PageCount("lamps", 2));
            CollectionAssert.AreEqual(new[] { "a_lamp", "b_lamp" }, index.Page("lamps", 0, 2).Select(i => i.Name).ToArray());
            CollectionAssert.AreEqual(new[] { "c_lamp" }, index.Page("lamps", 1, 2).Select(i => i.Name).ToArray());
            Assert.IsEmpty(index.Page("lamps", 2, 2));
        }

        [Test]
        public void UnknownCategoryNegativePageAndMissingGuidAreSafe()
        {
            var index = Sample();
            Assert.AreEqual(0, index.CountIn("nope"));
            Assert.AreEqual(0, index.PageCount("nope", 5));
            Assert.IsEmpty(index.Page("nope", 0, 5));
            Assert.IsEmpty(index.Page("lamps", -1, 5));
            Assert.IsNull(index.Find("missing"));
            Assert.IsNull(index.Find(null));
            Assert.Throws<ArgumentOutOfRangeException>(() => index.Page("lamps", 0, 0));
            Assert.Throws<ArgumentNullException>(() => new ItemCatalogIndex(null));
        }

        [Test]
        public void CatalogItemPriceFollowsItsCategory()
        {
            Assert.AreEqual(ItemPricing.PriceFor("sofa"), Item("g", "n", "sofa").Price);
            var store = Item("g", "n", "sofa").ToStoreItem();
            Assert.AreEqual(ItemPricing.Medium, store.PazuCurrencyPrice);
            Assert.IsTrue(store.IsOneTimeClaim);
        }
    }

    /// <summary>Bordas do sorteio que ChallengeBankTests.ChallengeSelectorTests nao cobre.</summary>
    public class ChallengeSelectorEdgeCaseTests
    {
        static LiteracyChallenge Challenge(string id, int difficulty) => new LiteracyChallenge
        {
            ChallengeId = id, Difficulty = difficulty, Prompt = id,
            Options = new List<string> { "a", "b", "c", "d" }, CorrectOptionIndex = 2,
        };

        static List<LiteracyChallenge> Bank(int perLevel)
        {
            var list = new List<LiteracyChallenge>();
            for (int d = 1; d <= 3; d++)
                for (int i = 0; i < perLevel; i++) list.Add(Challenge("d" + d + "_" + i, d));
            return list;
        }

        [Test]
        public void SingleChallengeLevelStillWorksAndEmptyLevelThrows()
        {
            var selector = new ChallengeSelector(PlayerState.CreateNew(0), new[] { Challenge("only", 1) }, new Random(1));
            Assert.AreEqual("only", selector.Next(100).ChallengeId);
            Assert.AreEqual("only", selector.Next(100).ChallengeId);
            Assert.Throws<InvalidOperationException>(() => selector.Next(1200));
            Assert.AreEqual(1, selector.PoolSize(ChallengeDifficulty.Easy));
            Assert.AreEqual(0, selector.PoolSize(ChallengeDifficulty.Hard));
        }

        [Test]
        public void HistoryIsCappedAndNullStateIsRejected()
        {
            var state = PlayerState.CreateNew(0);
            var selector = new ChallengeSelector(state, Bank(6), new Random(2));
            for (int i = 0; i < 450; i++) selector.Next(400);
            Assert.AreEqual(400, state.RecentChallenges.Count);
            Assert.Throws<ArgumentNullException>(() => new ChallengeSelector(null));
        }
    }
}
