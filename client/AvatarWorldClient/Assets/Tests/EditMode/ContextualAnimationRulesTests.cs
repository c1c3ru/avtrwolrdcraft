using System.Collections.Generic;
using AvatarWorld.Core.Avatar;
using NUnit.Framework;

namespace AvatarWorld.Core.Tests
{
    public class ContextualAnimationRulesTests
    {
        [Test]
        public void PlayTypeValuesMatchTheOriginalEnum()
        {
            Assert.AreEqual(0, (int)CAPlayType.None);
            Assert.AreEqual(1, (int)CAPlayType.PlayingNormalAnimation);
            Assert.AreEqual(2, (int)CAPlayType.PlayingAlternateIdle);
            Assert.AreEqual(3, (int)CAPlayType.PlayingPreAnimation);
        }

        [Test]
        public void DeadOrNullTargetFailsBeforeTheNameIsChecked()
        {
            Assert.AreEqual(CAStartCheck.TargetNull, ContextualAnimationRules.ValidateStart(false, ""));
        }

        [Test]
        public void EmptyConfigNameFailsWhenTheTargetIsAlive()
        {
            Assert.AreEqual(CAStartCheck.ConfigNameEmpty, ContextualAnimationRules.ValidateStart(true, null));
            Assert.AreEqual(CAStartCheck.ConfigNameEmpty, ContextualAnimationRules.ValidateStart(true, ""));
        }

        [Test]
        public void ValidInputPasses()
        {
            Assert.AreEqual(CAStartCheck.Ok, ContextualAnimationRules.ValidateStart(true, "CA/Microscope/Look_And_Find_Something"));
        }

        [Test]
        public void MessagesMatchTheOriginalLiterals()
        {
            Assert.AreEqual("target is null!", ContextualAnimationRules.TargetNullMessage);
            Assert.AreEqual(" animationConfig.name is null or empty!", ContextualAnimationRules.ConfigNameEmptyMessage);
        }

        [Test]
        public void SittingCharacterUsesTheSittingVariantWhenTheSkeletonHasIt()
        {
            var has = new HashSet<string> { "CA/Microscope/Look_And_Find_Nothing__Sitting" };
            Assert.AreEqual("CA/Microscope/Look_And_Find_Nothing__Sitting",
                ContextualAnimationRules.CharacterAnimationName("CA/Microscope/Look_And_Find_Nothing", true, has.Contains));
        }

        [Test]
        public void SittingCharacterKeepsTheBaseNameWithoutAVariant()
        {
            var has = new HashSet<string>();
            Assert.AreEqual("CA/Bed_Laying/Laying_Idle", ContextualAnimationRules.CharacterAnimationName("CA/Bed_Laying/Laying_Idle", true, has.Contains));
        }

        [Test]
        public void StandingCharacterNeverUsesTheVariant()
        {
            var has = new HashSet<string> { "A__Sitting" };
            Assert.AreEqual("A", ContextualAnimationRules.CharacterAnimationName("A", false, has.Contains));
        }

        [Test]
        public void CharacterAlwaysIncludesHandlersInTheEnsureCheck()
        {
            Assert.IsTrue(ContextualAnimationRules.CharacterShouldIncludeInEnsureCheck());
        }
    }
}
