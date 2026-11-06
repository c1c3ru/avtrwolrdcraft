using AvatarWorld.Core.World;
using NUnit.Framework;
using UnityEngine;

namespace AvatarWorld.Core.Tests
{
    public class InteriorCatalogTests
    {
        [TestCase(218, "dentist")]
        [TestCase(32, "ballet")]
        [TestCase(7, "cabin")]
        public void Interior_IsKeyedByItsLevelType(int level, string expected)
        {
            Assert.IsTrue(InteriorCatalog.TryGetKey(level, out var key));
            Assert.AreEqual(expected, key);
        }

        [Test]
        public void UnderConstructionAndUnknownLevels_HaveNoInterior()
        {
            Assert.IsFalse(InteriorCatalog.TryGetKey(0, out _));
            Assert.IsFalse(InteriorCatalog.TryGetKey(999999, out _));
        }

        [Test]
        public void EveryKey_HasJsonAndAllItsSprites()
        {
            foreach (var key in InteriorCatalog.AllKeys)
            {
                var json = Resources.Load<TextAsset>("Interiors/" + key + "/" + key);
                Assert.IsNotNull(json, key + " json");
                var data = JsonUtility.FromJson<Runtime.WorldMapData>(json.text);
                Assert.Greater(data.renderers.Count, 0, key);
                foreach (var r in data.renderers)
                    Assert.IsNotNull(Resources.Load<Texture2D>("Interiors/" + key + "/sprites/" + r.sprite), key + "/" + r.sprite);
            }
        }
    }
}
