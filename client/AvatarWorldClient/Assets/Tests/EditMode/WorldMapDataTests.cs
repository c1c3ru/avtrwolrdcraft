using System.Linq;
using AvatarWorld.Runtime;
using NUnit.Framework;
using UnityEngine;

namespace AvatarWorld.Core.Tests
{
    public class WorldMapDataTests
    {
        static WorldMapData Load() =>
            JsonUtility.FromJson<WorldMapData>(Resources.Load<TextAsset>("WorldSlice/world").text);

        [Test]
        public void Data_HasRenderersWithUniqueDrawRanksAndExistingSprites()
        {
            var data = Load();
            Assert.AreEqual(311, data.renderers.Count);
            Assert.AreEqual(data.renderers.Count, data.renderers.Select(r => r.rank).Distinct().Count());
            foreach (var name in data.renderers.Select(r => r.sprite).Distinct())
                Assert.IsNotNull(Resources.Load<Texture2D>("WorldSlice/sprites/" + name), name);
            Assert.IsNotNull(Resources.Load<Texture2D>("WorldSlice/back_button"));
        }

        [Test]
        public void Data_CameraStartsInsideTheWorld()
        {
            var c = Load().camera;
            Assert.Greater(c.maxX, c.minX);
            Assert.GreaterOrEqual(c.startX, c.minX);
            Assert.LessOrEqual(c.startX, c.maxX);
        }

        [Test]
        public void Buildings_ContainTheBasketballCourtAndUnderConstructionPlaces()
        {
            var data = Load();
            var basketball = data.buildings.Where(b => b.IsBasketball).ToList();
            Assert.AreEqual(1, basketball.Count);
            Assert.AreEqual("Basketball_T1S2", basketball[0].name);
            Assert.GreaterOrEqual(data.buildings.Count(b => b.defaultLevel == 0), 3, "lava-jato, posto e hamburgueria em obras");
            foreach (var b in data.buildings)
            {
                Assert.Greater(b.x1, b.x0, b.name);
                Assert.Greater(b.y1, b.y0, b.name);
            }
        }

        [Test]
        public void HitTest_FindsBasketballAtItsCenterAndNothingInEmptySky()
        {
            var data = Load();
            var court = data.buildings.Single(b => b.IsBasketball);
            var center = new Vector2((court.x0 + court.x1) / 2f, (court.y0 + court.y1) / 2f);
            Assert.IsTrue(data.HitTest(center) != null && data.HitTest(center).IsBasketball);
            Assert.IsNull(data.HitTest(new Vector2(data.camera.minX - 50f, 100f)));
        }

        [Test]
        public void HitTest_PrefersTheSmallestOverlappingBuilding()
        {
            var data = new WorldMapData();
            data.buildings.Add(new WorldBuildingData { name = "big", x0 = 0, y0 = 0, x1 = 10, y1 = 10 });
            data.buildings.Add(new WorldBuildingData { name = "small", x0 = 4, y0 = 4, x1 = 6, y1 = 6 });
            Assert.AreEqual("small", data.HitTest(new Vector2(5, 5)).name);
            Assert.AreEqual("big", data.HitTest(new Vector2(1, 1)).name);
        }
    }
}
