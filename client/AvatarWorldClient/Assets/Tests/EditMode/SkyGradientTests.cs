using AvatarWorld.Core.World;
using AvatarWorld.Runtime;
using NUnit.Framework;
using UnityEngine;

namespace AvatarWorld.Core.Tests
{
    public class SkyGradientTests
    {
        static SkyConfig Config()
        {
            var c = new SkyConfig();
            for (int p = 0; p < 4; p++)
            {
                // topo de cada fase: 4 tons de cinza crescentes em p (0.1 .. 0.4), base = topo / 2
                c.Top[p] = new SkyColor[4]; c.Bottom[p] = new SkyColor[4];
                for (int k = 0; k < 4; k++)
                {
                    float v = (p + 1) * 0.1f + k * 0.01f;
                    c.Top[p][k] = new SkyColor(v, v, v); c.Bottom[p][k] = new SkyColor(v / 2, v / 2, v / 2);
                }
            }
            return c;
        }

        [Test]
        public void Blend_GoesFromZeroToOneAndIsMonotonic()
        {
            Assert.AreEqual(0f, SkyGradient.Blend(0f, 5.5f, 0.4f), 1e-5f);
            Assert.AreEqual(1f, SkyGradient.Blend(1f, 5.5f, 0.4f), 1e-5f);
            float last = -1f;
            for (int i = 0; i <= 20; i++)
            {
                float w = SkyGradient.Blend(i / 20f, 7.9f, 0.5f);
                Assert.GreaterOrEqual(w, last); last = w;
            }
        }

        [Test]
        public void Day_HoldsTheLastColorOfSunriseToDay()
        {
            SkyGradient.ColorsAt(Config(), 12f, out var top, out var bottom);
            Assert.AreEqual(0.23f, top.R, 1e-4f); // fase 1: (1+1)*0.1 + 3*0.01
            Assert.AreEqual(0.115f, bottom.R, 1e-4f);
        }

        [Test]
        public void Night_HoldsTheLastColorOfSunsetToNight()
        {
            SkyGradient.ColorsAt(Config(), 2f, out var top, out _);
            Assert.AreEqual(0.43f, top.R, 1e-4f); // fase 3
            SkyGradient.ColorsAt(Config(), 22f, out var top2, out _);
            Assert.AreEqual(0.43f, top2.R, 1e-4f);
        }

        [Test]
        public void TransitionStart_IsTheFirstKeyframeAndHoursWrap()
        {
            SkyGradient.ColorsAt(Config(), 5f, out var top, out _);
            Assert.AreEqual(0.1f, top.R, 1e-4f); // inicio de nightToSunrise = chave 0 da fase 0
            SkyGradient.ColorsAt(Config(), 29f, out var wrapped, out _);
            Assert.AreEqual(top.R, wrapped.R, 1e-4f);
        }

        [Test]
        public void ShippedSky_HasThreeWeathersWithFourPhasesOfFourColors()
        {
            var json = Resources.Load<TextAsset>("WorldSlice/sky");
            Assert.IsNotNull(json);
            var file = JsonUtility.FromJson<SkyFile>(json.text);
            foreach (int weather in new[] { WorldWeather.Clear, WorldWeather.Rain, WorldWeather.Snow })
            {
                var c = file.For(weather);
                Assert.IsNotNull(c, "clima " + weather);
                for (int p = 0; p < 4; p++) { Assert.AreEqual(4, c.Top[p].Length); Assert.AreEqual(4, c.Bottom[p].Length); }
            }
        }
    }
}
