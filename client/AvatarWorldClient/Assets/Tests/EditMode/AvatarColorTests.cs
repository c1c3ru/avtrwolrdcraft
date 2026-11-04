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
    }
}
