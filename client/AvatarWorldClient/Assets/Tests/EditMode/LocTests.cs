using System;
using System.Linq;
using AvatarWorld.Core.Avatar;
using AvatarWorld.Core.Economy;
using AvatarWorld.Core.Localization;
using NUnit.Framework;

namespace AvatarWorld.Core.Tests
{
    public class LocTests
    {
        [Test] public void EveryKeyHasAllFourTranslations()
        {
            foreach (var key in Loc.Keys)
                foreach (Language l in Enum.GetValues(typeof(Language)))
                    Assert.IsFalse(string.IsNullOrWhiteSpace(Loc.Get(key, l)), key + " / " + l);
        }

        [Test] public void FormatPlaceholdersMatchAcrossLanguages()
        {
            foreach (var key in Loc.Keys)
            {
                int expected = Count(Loc.Get(key, Language.Pt));
                foreach (Language l in Enum.GetValues(typeof(Language)))
                    Assert.AreEqual(expected, Count(Loc.Get(key, l)), key + " / " + l + ": mesmos {n} do portugues");
            }
        }

        static int Count(string s)
        {
            int n = 0;
            for (int i = 0; i < 6; i++) if (s.Contains("{" + i + "}")) n++;
            return n;
        }

        [Test] public void UnknownKeyReturnsTheKeyInsteadOfBlank()
        {
            Assert.AreEqual("nao.existe", Loc.Get("nao.existe", Language.En));
        }

        [Test] public void ParsesTheCodesOfTheOriginalLanguageButtons()
        {
            Assert.IsTrue(Loc.TryParse("EN", out var l)); Assert.AreEqual(Language.En, l);
            Assert.IsTrue(Loc.TryParse("id", out l)); Assert.AreEqual(Language.Id, l);
            Assert.IsTrue(Loc.TryParse(" es ", out l)); Assert.AreEqual(Language.Es, l);
            Assert.IsTrue(Loc.TryParse("pt", out l)); Assert.AreEqual(Language.Pt, l);
            Assert.IsFalse(Loc.TryParse("fr", out _));
            Assert.IsFalse(Loc.TryParse(null, out _));
            foreach (Language each in Enum.GetValues(typeof(Language)))
            { Assert.IsTrue(Loc.TryParse(Loc.Code(each), out var back)); Assert.AreEqual(each, back); }
        }

        [Test] public void EveryStoreCategorySubgroupAndOfferHasADisplayTranslation()
        {
            foreach (var cat in StoreCatalog.Categories) Assert.IsTrue(Loc.Has("cat." + cat), "categoria " + cat);
            foreach (var cat in StoreCatalog.Categories)
                foreach (var sub in StoreCatalog.SubCategories(cat)) Assert.IsTrue(Loc.Has("sub." + sub), "subgrupo " + sub);
            foreach (var offer in StoreCatalog.All) Assert.IsTrue(Loc.Has("offer." + offer.Id), "oferta " + offer.Id);
            Assert.IsTrue(Loc.Has("offer." + VehicleSlotCatalog.StandardId));
            Assert.IsTrue(Loc.Has("offer." + VehicleSlotCatalog.PremiumId));
        }

        [Test] public void AvatarKindAndPetNamesFollowTheLanguageWithoutChangingIdentifiers()
        {
            var before = Loc.Current;
            try
            {
                Loc.Current = Language.Pt;
                Assert.AreEqual("Criança", AvatarKinds.DisplayName(AvatarKind.Toddler));
                Assert.AreEqual("Cão", PetCatalog.DisplayName("Dog"));
                Loc.Current = Language.En;
                Assert.AreEqual("Child", AvatarKinds.DisplayName(AvatarKind.Toddler));
                Assert.AreEqual("Baby", AvatarKinds.DisplayName(AvatarKind.Baby));
                Assert.AreEqual("Dog", PetCatalog.DisplayName("Dog"));
                foreach (var species in PetCatalog.Species) Assert.IsTrue(Loc.Has("pet." + species), species);
                Assert.AreEqual("Vehicles", Loc.Name("cat.", StoreCatalog.CategoryVehicles));
                Assert.AreEqual(StoreCatalog.CategoryVehicles, "Veículos", "o identificador da logica nao muda com o idioma");
                Assert.AreEqual("Desconhecida", Loc.Name("cat.", "Desconhecida"), "sem traducao mostra o proprio valor");
            }
            finally { Loc.Current = before; }
        }

        [Test] public void ScreenKeysUsedByTheRuntimeScreensExist()
        {
            // Chaves referenciadas por editor de avatar/pet, navegador de itens, mapa e quadra (strings no codigo as citam por nome).
            var keys = new[]
            {
                "item.close", "item.have", "item.bought", "item.price",
                "editor.front", "editor.back", "editor.shirt", "editor.jacket", "editor.accessory", "editor.hat", "editor.inshop", "editor.packpiece", "editor.savefail",
                "pet.variant", "pet.invalid", "pet.savefail",
                "pet.tab.breed", "pet.tab.pattern", "pet.tab.bodycolor", "pet.tab.patterncolor", "pet.tab.eyebrow", "pet.tab.eyebrowcolor",
                "pet.tab.hat", "pet.tab.bridle", "pet.tab.outfit", "pet.tab.saddle", "pet.tab.shoes", "pet.tab.accessory", "pet.tab.mane",
                "pet.tab.manecolor", "pet.tab.tail", "pet.tab.tailcolor", "pet.tab.eyes", "pet.tab.eyescolor", "pet.tab.mouth",
                "map.noavatars", "map.nohouse", "map.construction", "map.unavailable",
                "court.hint", "court.pull", "court.scored", "court.throwing", "court.score", "court.back",
            };
            foreach (var key in keys) Assert.IsTrue(Loc.Has(key), key);
            Assert.AreEqual("BASKETS  3", string.Format(Loc.Get("court.score", Language.En), 3));
        }
    }
}
