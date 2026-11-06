using AvatarWorld.Core.World;
using AvatarWorld.Runtime;
using NUnit.Framework;

namespace AvatarWorld.Core.Tests
{
    public class WorldAnimationTests
    {
        [Test]
        public void CloudSpeed_IsStableAndInRange()
        {
            for (int id = 1; id < 500; id++)
            {
                float s = WorldAnimation.CloudSpeed(id);
                Assert.That(s, Is.InRange(WorldAnimation.CloudMinSpeed, WorldAnimation.CloudMaxSpeed));
                Assert.AreEqual(s, WorldAnimation.CloudSpeed(id));
            }
        }

        [Test]
        public void Cloud_DriftsRightAndWrapsToTheStartPastTheEnd()
        {
            Assert.AreEqual(10.5f, WorldAnimation.AdvanceCloud(10f, 1f, 0.5f, -20f, 40f), 1e-4f);
            Assert.AreEqual(-20f + 0.25f, WorldAnimation.AdvanceCloud(39.75f, 1f, 0.5f, -20f, 40f), 1e-4f);
        }

        [Test]
        public void Cloud_DriftsLeftWhenTheEndIsToTheLeft()
        {
            Assert.AreEqual(9.5f, WorldAnimation.AdvanceCloud(10f, 1f, 0.5f, 40f, -20f), 1e-4f);
        }

        [Test]
        public void Train_ArrivesStopsLeavesAndRepeats()
        {
            float start = 15.9f, station = 31.7f, go = 86.9f, toStart = 3.5f, toGo = 5f;
            Assert.AreEqual(start, WorldAnimation.TrainX(0f, start, station, go, toStart, toGo), 1e-3f);
            Assert.AreEqual(station, WorldAnimation.TrainX(toStart, start, station, go, toStart, toGo), 1e-3f);
            Assert.AreEqual(station, WorldAnimation.TrainX(toStart + 3f, start, station, go, toStart, toGo), 1e-3f);
            Assert.AreEqual(go, WorldAnimation.TrainX(toStart + WorldAnimation.TrainDwellSeconds + toGo, start, station, go, toStart, toGo), 1e-3f);
            float period = WorldAnimation.TrainPeriod(toStart, toGo);
            Assert.AreEqual(WorldAnimation.TrainX(1f, start, station, go, toStart, toGo),
                WorldAnimation.TrainX(1f + period, start, station, go, toStart, toGo), 1e-3f);
        }

        [Test]
        public void CloudArt_ClearHidesInRain_RainShowsOnlyInRain()
        {
            var clear = new WorldRendererData { cloud = 7, cloudRain = false };
            var rain = new WorldRendererData { cloud = 7, cloudRain = true };
            Assert.IsTrue(clear.VisibleIn(WorldWeather.Clear));
            Assert.IsTrue(clear.VisibleIn(WorldWeather.Snow));
            Assert.IsFalse(clear.VisibleIn(WorldWeather.Rain));
            Assert.IsTrue(rain.VisibleIn(WorldWeather.Rain));
            Assert.IsFalse(rain.VisibleIn(WorldWeather.Clear));
        }

        [Test]
        public void NonCloudSprites_AreUnaffected()
        {
            Assert.IsTrue(new WorldRendererData().VisibleIn(WorldWeather.Rain));
        }
    }
}
