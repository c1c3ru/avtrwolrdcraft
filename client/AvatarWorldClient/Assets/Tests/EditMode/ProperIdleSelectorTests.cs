using AvatarWorld.Core.Avatar;
using NUnit.Framework;

namespace AvatarWorld.Core.Tests
{
    /// <summary>Prioridade de LevelCharacterAnimator.PlayProperIdleAnimation (0x22a3a40).</summary>
    public class ProperIdleSelectorTests
    {
        [Test]
        public void LockedCAHandlerWinsOverEverything()
        {
            Assert.AreEqual(ProperIdleChoice.LockedCAHandlerIdle, ProperIdleSelector.Choose(true, true, RestAreaKind.Sleep));
        }

        [Test]
        public void OverrideBeatsRestAreas()
        {
            Assert.AreEqual(ProperIdleChoice.OverrideHandled, ProperIdleSelector.Choose(false, true, RestAreaKind.Sit));
        }

        [Test]
        public void SitAreaPlaysChairIdle()
        {
            var c = ProperIdleSelector.Choose(false, false, RestAreaKind.Sit);
            Assert.AreEqual(ProperIdleChoice.SitIdle, c);
            Assert.AreEqual("CA/Chair_Sitting/Sit_On_Chair_Idle", ProperIdleSelector.AnimationFor(c));
        }

        [Test]
        public void SleepAreaPlaysBedIdle()
        {
            var c = ProperIdleSelector.Choose(false, false, RestAreaKind.Sleep);
            Assert.AreEqual(ProperIdleChoice.SleepIdle, c);
            Assert.AreEqual("CA/Bed_Laying/Laying_Idle", ProperIdleSelector.AnimationFor(c));
        }

        [Test]
        public void NoAreaOrOtherAreaFallsBackToStandIdle()
        {
            Assert.AreEqual(ProperIdleChoice.StandIdle, ProperIdleSelector.Choose(false, false, RestAreaKind.None));
            var c = ProperIdleSelector.Choose(false, false, RestAreaKind.Other);
            Assert.AreEqual(ProperIdleChoice.StandIdle, c);
            Assert.AreEqual("Idle_Stand_1", ProperIdleSelector.AnimationFor(c));
        }

        [Test]
        public void ChoicesWithoutAFixedNameReturnNull()
        {
            Assert.IsNull(ProperIdleSelector.AnimationFor(ProperIdleChoice.LockedCAHandlerIdle));
            Assert.IsNull(ProperIdleSelector.AnimationFor(ProperIdleChoice.OverrideHandled));
        }

        [Test]
        public void StandIdleNameMatchesTheLocomotionContract()
        {
            Assert.AreEqual(LocomotionAnimations.NameFor(LocomotionFamily.Character, MovementKind.Stand, PostureKind.Standing),
                            ProperIdleSelector.StandIdleAnimation);
        }
    }
}
