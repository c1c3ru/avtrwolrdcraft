using AvatarWorld.Core.Avatar;
using AvatarWorld.Core.Pointer;
using AvatarWorld.Runtime;
using NUnit.Framework;
using UnityEngine;

namespace AvatarWorld.Core.Tests
{
    /// <summary>Integracao ponteiro -> DragIntentDetector -> LocomotionStateMachine no componente de Runtime (sem dispositivo de entrada).</summary>
    public class CharacterDragControllerTests
    {
        GameObject _go;
        CharacterDragController _c;
        int _clicks, _starts, _ends;

        [SetUp]
        public void SetUp()
        {
            _go = new GameObject("TestCharacter");
            _c = _go.AddComponent<CharacterDragController>();
            _c.ScreenToWorld = s => s / 100f;   // 100 px = 1 unidade de mundo
            _clicks = _starts = _ends = 0;
            _c.Clicked += () => _clicks++;
            _c.DragStarted += () => _starts++;
            _c.DragEnded += () => _ends++;
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(_go);
        }

        [Test]
        public void SmallMovementIsAClickAndDoesNotMoveTheCharacter()
        {
            _c.Tick(true, new Vector2(0f, 0f), 0.016f);
            _c.Tick(true, new Vector2(5f, 0f), 0.016f);
            _c.Tick(false, new Vector2(5f, 0f), 0.016f);
            Assert.AreEqual(1, _clicks);
            Assert.AreEqual(0, _starts);
            Assert.AreEqual(0f, _go.transform.position.x);
        }

        [Test]
        public void MovingTenPixelsStartsDragAndWalks()
        {
            _c.Tick(true, new Vector2(0f, 0f), 0.016f);
            _c.Tick(true, new Vector2(20f, 0f), 0.016f);
            Assert.AreEqual(1, _starts);
            Assert.AreEqual(0.2f, _go.transform.position.x, 0.0001f);
            Assert.AreEqual(MovementKind.Walk, _c.Movement);
            Assert.AreEqual("Movement_Cycles/Walk", _c.CurrentAnimation);
        }

        [Test]
        public void ReleaseAfterDragReturnsToStandIdleAndRaisesDragEnded()
        {
            _c.Tick(true, new Vector2(0f, 0f), 0.016f);
            _c.Tick(true, new Vector2(30f, 0f), 0.016f);
            _c.Tick(false, new Vector2(30f, 0f), 0.016f);
            Assert.AreEqual(1, _ends);
            Assert.AreEqual(0, _clicks);
            Assert.AreEqual(MovementKind.Stand, _c.Movement);
            Assert.AreEqual("Idle_Stand_1", _c.CurrentAnimation);
        }

        [Test]
        public void PressOutsideGrabRadiusIsIgnored()
        {
            _c.Tick(true, new Vector2(500f, 0f), 0.016f);   // 5 unidades de distancia
            _c.Tick(true, new Vector2(700f, 0f), 0.016f);
            _c.Tick(false, new Vector2(700f, 0f), 0.016f);
            Assert.AreEqual(0, _starts + _clicks + _ends);
            Assert.AreEqual(0f, _go.transform.position.x);
        }

        [Test]
        public void CharacterNeverRunsEvenWithRunningAnimationsAndHugeSpeed()
        {
            _c.Family = LocomotionFamily.Character;
            _c.HasRunningAnimations = true;
            _c.Tick(true, new Vector2(0f, 0f), 0.016f);
            for (int i = 1; i <= 5; i++) _c.Tick(true, new Vector2(100f * i, 0f), 0.016f);
            Assert.AreEqual(MovementKind.Walk, _c.Movement);
        }

        [Test]
        public void AnimalRunsOnlyWithRunningAnimations()
        {
            _c.Family = LocomotionFamily.Animal;
            _c.HasRunningAnimations = true;
            _c.Tick(true, new Vector2(0f, 0f), 0.016f);
            _c.Tick(true, new Vector2(50f, 0f), 0.016f);    // 0.5 u / 0.016 s = 31 u/s: Stand -> Walk
            Assert.AreEqual(MovementKind.Walk, _c.Movement);
            _c.Tick(true, new Vector2(100f, 0f), 0.016f);   // Walk -> Run (> 18)
            Assert.AreEqual(MovementKind.Run, _c.Movement);
            Assert.AreEqual("General/Running", _c.CurrentAnimation);
        }

        [Test]
        public void AnimalWithoutRunningAnimationsStaysWalking()
        {
            _c.Family = LocomotionFamily.Animal;
            _c.HasRunningAnimations = false;
            _c.Tick(true, new Vector2(0f, 0f), 0.016f);
            _c.Tick(true, new Vector2(50f, 0f), 0.016f);
            _c.Tick(true, new Vector2(100f, 0f), 0.016f);
            Assert.AreEqual(MovementKind.Walk, _c.Movement);
            Assert.AreEqual("General/Walking", _c.CurrentAnimation);
        }

        [Test]
        public void ToddlerCrawlsWhenNotStanding()
        {
            _c.Family = LocomotionFamily.Toddler;
            _c.Posture = PostureKind.Sitting;
            _c.Tick(true, new Vector2(0f, 0f), 0.016f);
            _c.Tick(true, new Vector2(30f, 0f), 0.016f);
            Assert.AreEqual("Movement_Cycles/Crawling_Loop", _c.CurrentAnimation);
        }

        [Test]
        public void ToddlerWalksWhenStanding()
        {
            _c.Family = LocomotionFamily.Toddler;
            _c.Posture = PostureKind.Standing;
            _c.Tick(true, new Vector2(0f, 0f), 0.016f);
            _c.Tick(true, new Vector2(30f, 0f), 0.016f);
            Assert.AreEqual("Movement_Cycles/Walking_Loop", _c.CurrentAnimation);
        }

        [Test]
        public void PostModificationsRunAfterPreAndShapeTheFinalPosition()
        {
            _c.PreModifications = p => new DragPoint(p.X + 1f, p.Y);
            _c.PostModifications = p => new DragPoint(Mathf.Min(p.X, 1.1f), p.Y);
            _c.Tick(true, new Vector2(0f, 0f), 0.016f);
            _c.Tick(true, new Vector2(50f, 0f), 0.016f);    // raw 0.5 -> pre 1.5 -> post 1.1
            Assert.AreEqual(1.1f, _go.transform.position.x, 0.0001f);
        }

        [Test]
        public void CharacterCanBeDraggedAgainAfterReleaseBecauseNoneBecomesStand()
        {
            _c.Tick(true, new Vector2(0f, 0f), 0.016f);
            _c.Tick(true, new Vector2(30f, 0f), 0.016f);
            _c.Tick(false, new Vector2(30f, 0f), 0.016f);
            _c.Tick(true, new Vector2(30f, 0f), 0.016f);    // novo pressionar sobre o personagem (agora em 0.3)
            _c.Tick(true, new Vector2(60f, 0f), 0.016f);
            Assert.AreEqual(2, _starts);
            Assert.AreEqual(MovementKind.Walk, _c.Movement);
        }
    }
}
