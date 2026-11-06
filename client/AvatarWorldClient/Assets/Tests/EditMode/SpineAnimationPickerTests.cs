using AvatarWorld.Core.World;
using NUnit.Framework;

namespace AvatarWorld.Core.Tests
{
    public class SpineAnimationPickerTests
    {
        static readonly string[] SunNames = { "Idle", "Sun_Day", "Sun_Sunrise", "Sun_Sunset", "Moon_Night" };

        [Test] public void Preferred_WinsWhenItExists() =>
            Assert.AreEqual("Idle", SpineAnimationPicker.Pick(SunNames, "Sun_Moon", "Idle", 12));

        [TestCase(6, "Sun_Sunrise")]
        [TestCase(12, "Sun_Day")]
        [TestCase(18, "Sun_Sunset")]
        [TestCase(23, "Moon_Night")]
        [TestCase(2, "Moon_Night")]
        public void SunMoon_FollowsTheTimeOfDay(int hour, string expected) =>
            Assert.AreEqual(expected, SpineAnimationPicker.Pick(SunNames, "Sun_Moon", "", hour));

        [Test] public void OtherSkeletons_UseTheFirstAnimation() =>
            Assert.AreEqual("A", SpineAnimationPicker.Pick(new[] { "A", "B" }, "Water_Reflections", "", 12));

        [Test] public void UnknownPreferred_FallsBack() =>
            Assert.AreEqual("A", SpineAnimationPicker.Pick(new[] { "A", "B" }, "Water_Reflections", "Nope", 12));

        [Test] public void NoAnimations_ReturnsNull() =>
            Assert.IsNull(SpineAnimationPicker.Pick(new string[0], "Sun_Moon", "", 12));
    }
}
