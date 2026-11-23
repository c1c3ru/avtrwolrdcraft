using System;
using System.Linq;
using AvatarWorld.Core.Avatar;
using AvatarWorld.Core.Localization;
using AvatarWorld.Runtime;
using NUnit.Framework;

namespace AvatarWorld.Core.Tests
{
    public class ClothesDropsTests
    {
        static ClothesDropStoreData Store(params (string date, string name, string[] items)[] drops) => new ClothesDropStoreData
        {
            key = "T",
            drops = drops.Select(d => new ClothesDrop { date = d.date, name = d.name, items = d.items }).ToArray(),
        };

        [Test] public void CurrentIsTheLatestDropNotInTheFutureThatHasPieces()
        {
            var store = Store(("2024-01-01", "Empty", new string[0]), ("2024-02-01", "A", new[] { "x_1" }),
                ("2024-03-01", "B", new[] { "x_2" }), ("2024-04-01", "C", new[] { "x_3" }), ("2024-05-01", "Vazio", new string[0]));
            Assert.AreEqual("B", ClothesDrops.Current(store, new DateTime(2024, 3, 15)).name);
            Assert.AreEqual("C", ClothesDrops.Current(store, new DateTime(2030, 1, 1)).name, "conjunto vazio mais novo e pulado");
            Assert.AreEqual("B", ClothesDrops.Current(store, new DateTime(2024, 3, 1)).name, "no proprio dia ja vale");
            Assert.IsNull(ClothesDrops.Current(store, new DateTime(2023, 12, 31)), "antes do primeiro: nada");
            Assert.IsNull(ClothesDrops.Current(null, DateTime.Now));
        }

        [Test] public void NewMeansTheCurrentDropIsNotTheLastSeenOne()
        {
            var store = Store(("2024-02-01", "A", new[] { "x_1" }), ("2024-03-01", "B", new[] { "x_2" }));
            var today = new DateTime(2024, 6, 1);
            Assert.IsTrue(ClothesDrops.IsNew(store, today, ""));
            Assert.IsTrue(ClothesDrops.IsNew(store, today, "2024-02-01"));
            Assert.IsFalse(ClothesDrops.IsNew(store, today, "2024-03-01"));
            Assert.IsFalse(ClothesDrops.IsNew(Store(), today, ""), "sem drop nao ha novidade");
        }

        [Test] public void AvailableKeepsOrderDropsMissingAndDuplicates()
        {
            var drop = new ClothesDrop { date = "2024-01-01", name = "A", items = new[] { "a", "b", "c", "a" } };
            CollectionAssert.AreEqual(new[] { "a", "c" }, ClothesDrops.Available(drop, id => id != "b"));
            Assert.AreEqual(0, ClothesDrops.Available(null, id => true).Count);
        }

        [Test] public void ExportedDataIsWellFormedAndMostlyUsableInTheEditor()
        {
            var file = ClothesDropStore.Load();
            Assert.AreEqual(6, file.stores.Length, "6 lojas do ClothesDropDataMap");
            int total = 0, usable = 0;
            foreach (var store in file.stores)
            {
                Assert.IsNotEmpty(store.key);
                Assert.IsNotNull(ClothesDrops.Current(store, new DateTime(2026, 11, 23)), store.key + " precisa de um drop vigente");
                foreach (var drop in store.drops)
                {
                    Assert.IsTrue(drop.TryGetDate(out _), store.key + " data " + drop.date);
                    foreach (var id in drop.items)
                    {
                        total++;
                        if (AvatarCatalog.OptionsByCategory.Any(p => AvatarCatalog.IsValidOption(AvatarKind.Adult, p.Key, id))) usable++;
                    }
                }
            }
            Assert.Greater(total, 300);
            Assert.Greater(usable, total / 3, "boa parte das pecas dos drops existe no editor");
        }

        [Test] public void DropTextsExistInEveryLanguage()
        {
            foreach (var key in new[] { "drops.title", "drops.none", "drops.line", "drops.wear", "drops.worn", "drops.noneavail" })
                foreach (Language l in Enum.GetValues(typeof(Language)))
                    Assert.IsFalse(string.IsNullOrWhiteSpace(Loc.Get(key, l)), key + " / " + l);
        }
    }
}
