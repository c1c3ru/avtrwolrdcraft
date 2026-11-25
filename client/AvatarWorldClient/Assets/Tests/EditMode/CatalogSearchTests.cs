using System.Collections.Generic;
using System.Linq;
using AvatarWorld.Core.Avatar;
using AvatarWorld.Core.Economy;
using NUnit.Framework;

namespace AvatarWorld.Core.Tests
{
    public class CatalogSearchTests
    {
        static List<CatalogEntry> Sample() => new List<CatalogEntry>
        {
            new CatalogEntry("g1", "Pézinho Azul", "Shoes"),
            new CatalogEntry("g2", "Camisa Listrada", "Shirt"),
            new CatalogEntry("g3", "Shirt_Special_869_Color", "Shirt"),
            new CatalogEntry("g4", "Chapéu de Palha", "Hat"),
            new CatalogEntry("g5", "Tênis Azul", "Shoes"),
        };

        [Test]
        public void NormalizeLowersCaseRemovesAccentsAndTreatsUnderscoreAsSpace()
        {
            Assert.AreEqual("pezinho azul", CatalogSearch.Normalize("Pézinho_Azul"));
            Assert.AreEqual("chapeu de palha", CatalogSearch.Normalize("  Chapéu de PALHA "));
            Assert.AreEqual("", CatalogSearch.Normalize(null));
            Assert.AreEqual("", CatalogSearch.Normalize("   "));
        }

        [Test]
        public void MatchesNeedsEveryTermInAnyOrderIgnoringAccents()
        {
            Assert.IsTrue(CatalogSearch.Matches("Shirt_Special_869_Color", "special 869"));
            Assert.IsTrue(CatalogSearch.Matches("Shirt_Special_869_Color", "869 SHIRT"));
            Assert.IsTrue(CatalogSearch.Matches("Pézinho Azul", "pezinho"));
            Assert.IsFalse(CatalogSearch.Matches("Camisa Listrada", "camisa azul"));
            Assert.IsTrue(CatalogSearch.Matches("qualquer coisa", ""), "consulta vazia aceita tudo");
        }

        [Test]
        public void ViewFiltersByQueryAndCategoryAndResetsThePage()
        {
            var view = new CatalogView(Sample(), 2);
            Assert.AreEqual(5, view.Count);
            Assert.AreEqual(3, view.PageCount);
            view.SetPage(2);
            Assert.AreEqual(2, view.Page);

            view.SetQuery("azul");
            Assert.AreEqual(0, view.Page, "mudar a consulta volta para a pagina 0");
            Assert.AreEqual(2, view.Count);
            CollectionAssert.AreEquivalent(new[] { "g1", "g5" }, view.CurrentPage.Select(e => e.Id));

            view.SetCategory("Shirt");
            Assert.AreEqual(0, view.Count, "azul + Shirt nao tem resultado");
            Assert.AreEqual(1, view.PageCount, "sem resultado ainda ha 1 pagina vazia");
            view.SetQuery("");
            Assert.AreEqual(2, view.Count);
        }

        [Test]
        public void SearchAlsoMatchesTheCategoryAndTheId()
        {
            var view = new CatalogView(Sample(), 10);
            view.SetQuery("shoes");
            Assert.AreEqual(2, view.Count);
            view.SetQuery("g4");
            Assert.AreEqual("Chapéu de Palha", view.CurrentPage.Single().Title);
        }

        [Test]
        public void MoveWrapsAroundAndSetPageClamps()
        {
            var view = new CatalogView(Sample(), 2);
            view.Move(-1);
            Assert.AreEqual(2, view.Page);
            view.Move(+1);
            Assert.AreEqual(0, view.Page);
            view.SetPage(99);
            Assert.AreEqual(2, view.Page);
            view.SetPage(-5);
            Assert.AreEqual(0, view.Page);
            Assert.AreEqual(2, view.CurrentPage.Count, "pagina 0 de 5 itens com 2 por pagina");
        }

        [Test]
        public void TopCategoriesOrdersByCountThenName()
        {
            var view = new CatalogView(Sample(), 10);
            CollectionAssert.AreEqual(new[] { "Shirt", "Shoes", "Hat" }, view.TopCategories(3));
            CollectionAssert.AreEqual(new[] { "Shirt" }, view.TopCategories(1));
        }

        [Test]
        public void RealAvatarCatalogIsSearchableByCategoryAndTerm()
        {
            var entries = AvatarCatalog.OptionsByCategory
                .SelectMany(p => p.Value.Select(id => new CatalogEntry(id, id.Replace('_', ' '), p.Key))).ToList();
            var view = new CatalogView(entries, 12);
            Assert.Greater(view.Total, 1000);
            view.SetCategory(AvatarCatalog.CategoryShirt);
            Assert.Greater(view.Count, 100);
            view.SetQuery("869");
            Assert.Greater(view.Count, 0, "ha camisa com 869 no id");
            Assert.IsTrue(view.CurrentPage.All(e => e.Category == AvatarCatalog.CategoryShirt && e.Search.Contains("869")));
        }
    }
}
