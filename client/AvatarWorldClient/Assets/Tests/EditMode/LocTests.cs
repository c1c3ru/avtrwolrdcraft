using System;
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
    }
}
