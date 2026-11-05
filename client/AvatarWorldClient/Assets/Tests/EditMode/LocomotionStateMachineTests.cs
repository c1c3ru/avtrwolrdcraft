using AvatarWorld.Core.Avatar;
using NUnit.Framework;

namespace AvatarWorld.Core.Tests
{
    /// <summary>Regras extraidas do asm de LevelCharacterAnimator/LevelToddler/LevelAnimal.OnMovement (docs/RECON_CHARACTER_CONTRACT.md).</summary>
    public class LocomotionStateMachineTests
    {
        [Test]
        public void StandStartsWalkingOnlyAboveStartSpeed()
        {
            var c = LocomotionConfig.Animal;
            Assert.AreEqual(MovementKind.Stand, LocomotionStateMachine.Next(c, MovementKind.Stand, 0.06f, true));
            Assert.AreEqual(MovementKind.Walk, LocomotionStateMachine.Next(c, MovementKind.Stand, 0.0601f, true));
        }

        [Test]
        public void StandNeverJumpsStraightToRun()
        {
            Assert.AreEqual(MovementKind.Walk, LocomotionStateMachine.Next(LocomotionConfig.Animal, MovementKind.Stand, 100f, true));
        }

        [Test]
        public void WalkStopsBelowStopSpeedAndKeepsWalkingAtOrAbove()
        {
            var c = LocomotionConfig.Toddler;
            Assert.AreEqual(MovementKind.Stand, LocomotionStateMachine.Next(c, MovementKind.Walk, 0.0059f, false));
            Assert.AreEqual(MovementKind.Walk, LocomotionStateMachine.Next(c, MovementKind.Walk, 0.006f, false));
        }

        [Test]
        public void HysteresisKeepsWalkingBetweenStopAndStartSpeed()
        {
            var c = LocomotionConfig.Animal;
            Assert.AreEqual(MovementKind.Stand, LocomotionStateMachine.Next(c, MovementKind.Stand, 0.03f, true));
            Assert.AreEqual(MovementKind.Walk, LocomotionStateMachine.Next(c, MovementKind.Walk, 0.03f, true));
        }

        [Test]
        public void AnimalRunsAboveEighteenOnlyWithRunningAnimations()
        {
            var c = LocomotionConfig.Animal;
            Assert.AreEqual(MovementKind.Run, LocomotionStateMachine.Next(c, MovementKind.Walk, 18.1f, true));
            Assert.AreEqual(MovementKind.Walk, LocomotionStateMachine.Next(c, MovementKind.Walk, 18f, true));
            Assert.AreEqual(MovementKind.Walk, LocomotionStateMachine.Next(c, MovementKind.Walk, 50f, false));
        }

        [Test]
        public void RunReturnsToWalkBelowSixAndStaysAtOrAbove()
        {
            var c = LocomotionConfig.Animal;
            Assert.AreEqual(MovementKind.Walk, LocomotionStateMachine.Next(c, MovementKind.Run, 5.99f, true));
            Assert.AreEqual(MovementKind.Run, LocomotionStateMachine.Next(c, MovementKind.Run, 6f, true));
        }

        [Test]
        public void RunNeverDropsStraightToStand()
        {
            Assert.AreEqual(MovementKind.Walk, LocomotionStateMachine.Next(LocomotionConfig.Animal, MovementKind.Run, 0f, true));
        }

        [Test]
        public void ToddlerAndCharacterNeverEnterRunFromWalk()
        {
            Assert.AreEqual(MovementKind.Walk, LocomotionStateMachine.Next(LocomotionConfig.Toddler, MovementKind.Walk, 1000f, true));
            Assert.AreEqual(MovementKind.Walk, LocomotionStateMachine.Next(LocomotionConfig.Character, MovementKind.Walk, 1000f, true));
        }

        [Test]
        public void ToddlerAndCharacterShareTheSameThresholds()
        {
            var t = LocomotionConfig.Toddler;
            var c = LocomotionConfig.Character;
            Assert.AreEqual(t.StartWalkSpeed, c.StartWalkSpeed);
            Assert.AreEqual(t.StopSpeed, c.StopSpeed);
            Assert.AreEqual(t.RunExitSpeed, c.RunExitSpeed);
        }

        [Test]
        public void NoneBecomesStandRegardlessOfSpeed()
        {
            Assert.AreEqual(MovementKind.Stand, LocomotionStateMachine.Next(LocomotionConfig.Animal, MovementKind.None, 10f, true));
            Assert.AreEqual(MovementKind.Stand, LocomotionStateMachine.Next(LocomotionConfig.Character, MovementKind.None, 0f, false));
        }

        [Test]
        public void ToddlerWalksStandingAndCrawlsOtherwise()
        {
            Assert.AreEqual("Movement_Cycles/Walking_Loop", LocomotionStateMachine.ToddlerMoveAnimation(PostureKind.Standing));
            Assert.AreEqual("Movement_Cycles/Crawling_Loop", LocomotionStateMachine.ToddlerMoveAnimation(PostureKind.Sitting));
            Assert.AreEqual("Movement_Cycles/Crawling_Loop", LocomotionStateMachine.ToddlerMoveAnimation(PostureKind.None));
        }
    }
}
