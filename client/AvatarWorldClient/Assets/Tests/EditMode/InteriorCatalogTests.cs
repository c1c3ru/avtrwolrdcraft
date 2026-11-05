using AvatarWorld.Core.World;
using NUnit.Framework;
using UnityEngine;

namespace AvatarWorld.Core.Tests
{
    public class InteriorCatalogTests
    {
        [Test]
        public void Dentist_IsKeyedByItsLevelType()
        {
            Assert.IsTrue(InteriorCatalog.TryGetKey(218, out var key));
            Assert.AreEqual("dentist", key);
        }

        [Test]
        public void UnderConstructionAndUnknownLevels_HaveNoInterior()
        {
            Assert.IsFalse(InteriorCatalog.TryGetKey(0, out _));
            Assert.IsFalse(InteriorCatalog.TryGetKey(13, out _)); // quadra: tem runtime proprio
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
