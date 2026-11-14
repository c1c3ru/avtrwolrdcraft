using System;
using AvatarWorld.Core.Avatar;
using AvatarWorld.Core.Economy;
using NUnit.Framework;
using UnityEngine;

namespace AvatarWorld.Core.Tests
{
    public class AvatarColorTests
    {
        [Serializable] class PaletteProbe { public System.Collections.Generic.List<Entry> skin; public System.Collections.Generic.List<Entry> eyes; public int defaultSkin; public int defaultEyes; }
        [Serializable] class Entry { public float[] display; }

        [Test]
        public void DefaultsMatchThePaletteFileAndCounts()
        {
            var probe = JsonUtility.FromJson<PaletteProbe>(Resources.Load<TextAsset>("AvatarSpine/palettes").text);
            Assert.AreEqual(AvatarPaletteData.SkinCount, probe.skin.Count);
            Assert.AreEqual(AvatarPaletteData.EyesCount, probe.eyes.Count);
            Assert.AreEqual(AvatarPaletteData.DefaultSkin, probe.defaultSkin);
            Assert.AreEqual(AvatarPaletteData.DefaultEyes, probe.defaultEyes);
        }

        [Test]
        public void ColorSelectionIsRangeCheckedAndCloned()
        {
            var a = AvatarAppearance.CreateDefault();
            Assert.IsTrue(a.TrySelectColor(AvatarCatalog.CategorySkin, 3));
            Assert.IsFalse(a.TrySelectColor(AvatarCatalog.CategorySkin, AvatarPaletteData.SkinCount));
            Assert.IsFalse(a.TrySelectColor(AvatarCatalog.CategoryEyes, -1));
            Assert.IsFalse(a.TrySelectColor(AvatarCatalog.CategoryShirt, 0), "categoria de item nao e de cor");
            Assert.AreEqual(3, a.GetColorIndex(AvatarCatalog.CategorySkin));
            var b = a.Clone();
            Assert.IsTrue(a.SameAs(b));
            b.TrySelectColor(AvatarCatalog.CategoryEyes, 7);
            Assert.IsFalse(a.SameAs(b));
        }

        [Test]
        public void OldSaveWithoutColorFieldsKeepsDefaultsAndBadIndicesAreSanitized()
        {
            var old = JsonUtility.FromJson<AvatarAppearance>("{\"HairId\":\"Hair_Front/2_Color\",\"ShirtId\":\"shirt_casual_1\"}");
            Assert.AreEqual(AvatarPaletteData.DefaultSkin, old.SkinIndex);
            Assert.AreEqual(AvatarPaletteData.DefaultEyes, old.EyesIndex);
            Assert.AreEqual("shirt_casual_1", old.ShirtId);
            old.SkinIndex = 999; old.EyesIndex = -4;
            Assert.IsFalse(old.IsFullyValid());
            old.SanitizeInPlace();
            Assert.IsTrue(old.IsFullyValid());
            Assert.AreEqual(AvatarPaletteData.DefaultSkin, old.SkinIndex);
        }

        [Test]
        public void HistoryTracksColorChanges()
        {
            var history = new AvatarEditHistory(AvatarAppearance.CreateDefault());
            var changed = AvatarAppearance.CreateDefault();
            changed.TrySelectColor(AvatarCatalog.CategorySkin, 0);
            history.Push(changed);
            Assert.IsTrue(history.CanUndo);
            Assert.AreEqual(AvatarPaletteData.DefaultSkin, history.Undo().SkinIndex);
            Assert.AreEqual(0, history.Redo().SkinIndex);
        }

        [Test]
        public void ItemColorsDefaultSelectAndCompare()
        {
            var a = AvatarAppearance.CreateDefault();
            Assert.AreEqual(AvatarPaletteData.DefaultItemColor, a.GetItemColor(AvatarCatalog.CategoryEyebrows));
            Assert.IsTrue(a.TrySelectItemColor(AvatarCatalog.CategoryEyebrows, 10));
            Assert.IsFalse(a.TrySelectItemColor(AvatarCatalog.CategoryEyebrows, AvatarPaletteData.GeneralCount));
            Assert.IsFalse(a.TrySelectItemColor("Inexistente", 0));
            Assert.AreEqual(10, a.GetItemColor(AvatarCatalog.CategoryEyebrows));
            var b = a.Clone();
            Assert.IsTrue(a.SameAs(b));
            b.TrySelectItemColor(AvatarCatalog.CategoryEyebrows, 11);
            Assert.IsFalse(a.SameAs(b));
            Assert.AreEqual(10, a.GetItemColor(AvatarCatalog.CategoryEyebrows), "clone nao compartilha a lista");
            // cor explicitamente igual ao padrao equivale a nao ter entrada
            var c = AvatarAppearance.CreateDefault();
            c.TrySelectItemColor(AvatarCatalog.CategoryEyebrows, AvatarPaletteData.DefaultItemColor);
            Assert.IsTrue(c.SameAs(AvatarAppearance.CreateDefault()));
        }

        [Test]
        public void EyebrowsAreColorItemsAndOldSavesKeepTheBuiltInDefault()
        {
            Assert.AreEqual(AvatarCatalog.EyebrowsDefault, AvatarCatalog.DefaultOption(AvatarCatalog.CategoryEyebrows));
            Assert.IsTrue(AvatarCatalog.IsBuiltIn(AvatarCatalog.EyebrowsDefault));
            Assert.IsFalse(AvatarCatalog.IsColorItem("shirt_formal_1"));
            Assert.IsTrue(AvatarCatalog.IsColorItem("eyebrows_10_color"));
            Assert.Greater(AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryEyebrows].Length, 50);
            var old = JsonUtility.FromJson<AvatarAppearance>("{\"HairId\":\"Hair_Front/1_Color\"}");
            Assert.AreEqual(AvatarCatalog.EyebrowsDefault, old.EyebrowsId);
            Assert.IsNotNull(old.ItemColors);
            old.ItemColors.Add(new CategoryColor { Category = "Nada", Index = 5 });
            old.SanitizeInPlace();
            Assert.AreEqual(0, old.ItemColors.Count);
        }

        [Test]
        public void ClothingCategoriesCanHaveRealColorItemsResolvedFromTheOriginalSut()
        {
            // Ciclo 6: Camisa/Calca/Sapato/Acessorio usam a mesma coluna de cores que sobrancelha/cabelo-atras.
            // A piece "_st" (sombra/template do jogo original) nunca tem pagina no atlas para item
            // nenhum (com ou sem cor); tools/avatar_catalog_build.py ignora essa peca em vez de
            // rejeitar o item inteiro por causa dela (ciclo 6 continuacao).
            foreach (var id in new[] { "shirt_special_1177_color", "bottom_special_1077_color", "bottom_special_1078_color", "bottom_special_1079_color", "accessories_body_neck_515_color", "legs_shoes_973_color" })
                Assert.IsTrue(AvatarCatalog.IsColorItem(id), id);
            Assert.Contains("shirt_special_1177_color", AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryShirt]);
            Assert.Contains("bottom_special_1077_color", AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryBottom]);
            Assert.Contains("accessories_body_neck_515_color", AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryAccessory]);
            Assert.Contains("legs_shoes_973_color", AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryShoes], "sapato so ganhou itens _color apos ignorar a peca _st");
            var a = AvatarAppearance.CreateDefault();
            Assert.IsTrue(a.TrySelect(AvatarCatalog.CategoryShirt, "shirt_special_1177_color"));
            Assert.IsTrue(a.TrySelectItemColor(AvatarCatalog.CategoryShirt, 20));
            Assert.AreEqual(20, a.GetItemColor(AvatarCatalog.CategoryShirt));
        }

        [Test]
        public void HairIsAnItemCategoryWithColorAndABackLayerSharingTheHairColor()
        {
            Assert.Greater(AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryHair].Length, 50);
            Assert.AreEqual("Hair_Front/1_Color", AvatarCatalog.DefaultOption(AvatarCatalog.CategoryHair));
            Assert.AreEqual(AvatarCatalog.HairBackNone, AvatarCatalog.DefaultOption(AvatarCatalog.CategoryHairBack));
            Assert.IsTrue(AvatarCatalog.IsColorItem("Hair_Front/3_Color"), "skins Hair_Front/N_Color aceitam tinta");
            Assert.AreEqual(AvatarCatalog.CategoryHair, AvatarCatalog.ColorKey(AvatarCatalog.CategoryHairBack));
            Assert.AreEqual(AvatarCatalog.CategoryShirt, AvatarCatalog.ColorKey(AvatarCatalog.CategoryShirt));
            var a = AvatarAppearance.CreateDefault();
            Assert.IsTrue(a.TrySelect(AvatarCatalog.CategoryHairBack, AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryHairBack][1]));
            Assert.IsFalse(a.SameAs(AvatarAppearance.CreateDefault()));
        }
    }
}
