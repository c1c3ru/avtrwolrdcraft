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
            Assert.AreEqual(643, data.renderers.Count); // 591 de cena + 52 sprites de nuvem (26 nuvens, arte clara e de chuva)
            Assert.AreEqual(data.renderers.Count, data.renderers.Select(r => r.rank).Distinct().Count());
            foreach (var name in data.renderers.Select(r => r.sprite).Distinct())
                Assert.IsNotNull(Resources.Load<Texture2D>("WorldSlice/sprites/" + name), name);
            Assert.IsNotNull(Resources.Load<Texture2D>("WorldSlice/back_button"));
        }

        [Test]
        public void Motion_CloudsAndTrainMatchStaticRenderersByNameAndPosition()
        {
            var world = Load();
            var motion = JsonUtility.FromJson<WorldMotionData>(Resources.Load<TextAsset>("WorldSlice/motion").text);
            Assert.AreEqual(26, motion.clouds.Count);
            Assert.AreEqual(1, motion.trains.Count);
            Assert.AreEqual(2, motion.spines.Count);
            bool Has(string go, float x, float y) =>
                world.renderers.Any(r => r.go == go && Mathf.Abs(r.x - x) + Mathf.Abs(r.y - y) < 0.05f);
            // nuvens nascem sem sprite no level4: o spawner sorteia das listas (12 sprites exportados a parte)
            foreach (var m in motion.cloudSprites.clear.Concat(motion.cloudSprites.rain).Concat(motion.cloudSprites.heavy))
                Assert.IsNotNull(Resources.Load<Texture2D>("WorldSlice/sprites/" + m.file), m.file);
            Assert.AreEqual(4, motion.cloudSprites.clear.Count);
            Assert.AreEqual(4, motion.cloudSprites.rain.Count);
            Assert.AreEqual(4, motion.cloudSprites.heavy.Count);
            var t = motion.trains[0];
            Assert.IsTrue(Has(t.go, t.x, t.y), "trem " + t.go);
            Assert.Less(t.start.x, t.x);
            Assert.Greater(t.goTo.x, t.x);
            Assert.AreEqual(3.5f, t.toInitialSeconds);
            Assert.AreEqual(5f, t.toGoToSeconds);
        }

        [Test]
        public void Weather_VisibilityFollowsTheOriginalSupportedWeatherList()
        {
            var always = new WorldRendererData();
            Assert.IsTrue(always.VisibleIn(WorldWeather.Clear) && always.VisibleIn(WorldWeather.Snow));
            var snowOnly = new WorldRendererData { weathers = new[] { WorldWeather.Snow } };
            Assert.IsTrue(snowOnly.VisibleIn(WorldWeather.Snow));
            Assert.IsFalse(snowOnly.VisibleIn(WorldWeather.Clear));
            Assert.IsFalse(snowOnly.VisibleIn(WorldWeather.Rain));
            Assert.IsTrue(WorldWeather.IsSupported(WorldWeather.Rain));
            Assert.IsFalse(WorldWeather.IsSupported(8), "Halloween e evento, fora do mapa");
        }

        [Test]
        public void Data_HasRainAndSnowVariantsAndTheTopBarArt()
        {
            var data = Load();
            Assert.Greater(data.renderers.Count(r => r.weathers != null && r.weathers.Contains(WorldWeather.Rain)), 0);
            Assert.Greater(data.renderers.Count(r => r.weathers != null && r.weathers.Contains(WorldWeather.Snow)), 0);
            Assert.Greater(data.renderers.Count(r => r.VisibleIn(WorldWeather.Clear)), 300, "mapa de tempo limpo completo");
            foreach (var art in new[] { "weather_toggle", "weather_pill", "weather_clear", "weather_rain", "weather_snow", "globe", "add_avatar", "edit_house" })
                Assert.IsNotNull(Resources.Load<Texture2D>("WorldSlice/ui/" + art), art);
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
