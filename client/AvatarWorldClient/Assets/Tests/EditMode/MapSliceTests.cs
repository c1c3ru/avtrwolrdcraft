using AvatarWorld.Runtime;
using NUnit.Framework;
using UnityEngine;

namespace AvatarWorld.Core.Tests
{
    /// <summary>Mapas do seletor do globo exportados do original (tools/export_interior.py --dest Maps).</summary>
    public class MapSliceTests
    {
        [TestCase("college", 4)]      // Campus   (College)
        [TestCase("stardust", 30)]    // Cidade   (StarDustCity)
        [TestCase("countryside", 4)]  // Fazenda  (Countryside)
        [TestCase("vacation", 10)]    // Resort   (Vacation)
        [TestCase("snowy", 8)]        // Montanha (SnowyMountain)
        public void Map_HasDataBuildingsAndEverySprite(string key, int buildings)
        {
            var json = Resources.Load<TextAsset>("Maps/" + key + "/" + key);
            Assert.IsNotNull(json, key + " json");
            var data = JsonUtility.FromJson<WorldMapData>(json.text);
            Assert.Greater(data.renderers.Count, 0, key);
            Assert.AreEqual(buildings, data.buildings.Count, key + " predios");
            Assert.Less(data.camera.minX, data.camera.maxX, key + " camera");
            foreach (var r in data.renderers)
                Assert.IsNotNull(Resources.Load<Texture2D>("Maps/" + key + "/sprites/" + r.sprite), key + "/" + r.sprite);
        }
    }
}
