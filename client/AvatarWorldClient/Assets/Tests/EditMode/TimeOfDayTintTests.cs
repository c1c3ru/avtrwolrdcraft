using AvatarWorld.Core.World;
using NUnit.Framework;

namespace AvatarWorld.Core.Tests
{
    public class TimeOfDayTintTests
    {
        static readonly SkyColor Day = new SkyColor(1f, 1f, 1f), Sunset = new SkyColor(1f, 0.9f, 0.9f), Night = new SkyColor(0.5f, 0.55f, 0.7f);

        [TestCase(12f)] [TestCase(7f)] [TestCase(15.99f)]
        public void Daytime_IsTheDayColor(float hour) => Assert.AreEqual(1f, TimeOfDayTint.At(hour, Day, Sunset, Night).G, 1e-3f);

        [TestCase(22f)] [TestCase(2f)] [TestCase(20f)]
        public void Night_IsTheNightColor(float hour) => Assert.AreEqual(0.55f, TimeOfDayTint.At(hour, Day, Sunset, Night).G, 1e-3f);

        [Test]
        public void Evening_GoesDayToSunsetToNight()
        {
            Assert.AreEqual(Sunset.G, TimeOfDayTint.At(18f, Day, Sunset, Night).G, 1e-3f);
            Assert.AreEqual((1f + 0.9f) / 2f, TimeOfDayTint.At(17f, Day, Sunset, Night).G, 1e-3f);
            Assert.AreEqual((0.9f + 0.55f) / 2f, TimeOfDayTint.At(19f, Day, Sunset, Night).G, 1e-3f);
        }

        [Test]
        public void Sunrise_GoesNightToDay() =>
            Assert.AreEqual((0.55f + 1f) / 2f, TimeOfDayTint.At(6f, Day, Sunset, Night).G, 1e-3f);

        [Test]
        public void HoursWrapAround() =>
            Assert.AreEqual(TimeOfDayTint.At(2f, Day, Sunset, Night).G, TimeOfDayTint.At(26f, Day, Sunset, Night).G, 1e-4f);
    }
}
