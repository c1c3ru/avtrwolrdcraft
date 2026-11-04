using AvatarWorld.Core.Pointer;
using NUnit.Framework;

namespace AvatarWorld.Core.Tests
{
    /// <summary>Regras de ShouldStartDrag (0x20cb0ec) e OnPointerClick (0x206c244) do original.</summary>
    public class DragIntentDetectorTests
    {
        [Test]
        public void ThresholdIsTenPixels()
        {
            Assert.AreEqual(10f, DragIntentDetector.DefaultThresholdPixels);
        }

        [Test]
        public void ShouldStartDragComparesSquaredDistanceWithGreaterOrEqual()
        {
            Assert.IsFalse(DragIntentDetector.ShouldStartDrag(true, 9.99f, 0f, 0f, 0f, 10f));
            Assert.IsTrue(DragIntentDetector.ShouldStartDrag(true, 10f, 0f, 0f, 0f, 10f));
            Assert.IsTrue(DragIntentDetector.ShouldStartDrag(true, 6f, 8f, 0f, 0f, 10f));
        }

        [Test]
        public void ShouldStartDragIsDiagonalAware()
        {
            Assert.IsFalse(DragIntentDetector.ShouldStartDrag(true, 7f, 7f, 0f, 0f, 10f)); // 9.9 px
            Assert.IsTrue(DragIntentDetector.ShouldStartDrag(true, 7.1f, 7.1f, 0f, 0f, 10f));
        }

        [Test]
        public void WithoutThresholdFlagAnyMoveStartsDrag()
        {
            Assert.IsTrue(DragIntentDetector.ShouldStartDrag(false, 0f, 0f, 0f, 0f, 10f));
        }

        [Test]
        public void SmallMoveStaysPressedAndReleaseIsClick()
        {
            var d = new DragIntentDetector();
            d.PointerDown(100f, 100f);
            Assert.IsFalse(d.PointerMove(105f, 105f));
            Assert.AreEqual(DragPhase.Pressed, d.Phase);
            Assert.AreEqual(PointerReleaseResult.Click, d.PointerUp());
            Assert.AreEqual(DragPhase.Idle, d.Phase);
        }

        [Test]
        public void MovingTenPixelsStartsDragOnceAndReleaseIsEndDragNotClick()
        {
            var d = new DragIntentDetector();
            d.PointerDown(0f, 0f);
            Assert.IsTrue(d.PointerMove(10f, 0f));
            Assert.AreEqual(DragPhase.Dragging, d.Phase);
            Assert.IsFalse(d.PointerMove(50f, 0f)); // so sinaliza o inicio uma vez
            Assert.AreEqual(PointerReleaseResult.EndDrag, d.PointerUp());
        }

        [Test]
        public void ReturningNearTheStartAfterDragStillEndsAsDrag()
        {
            var d = new DragIntentDetector();
            d.PointerDown(0f, 0f);
            d.PointerMove(30f, 0f);
            d.PointerMove(1f, 0f);
            Assert.AreEqual(PointerReleaseResult.EndDrag, d.PointerUp());
        }

        [Test]
        public void ClickSuppressedFlagIgnoresClick()
        {
            var d = new DragIntentDetector { ClickSuppressed = true };
            d.PointerDown(0f, 0f);
            Assert.AreEqual(PointerReleaseResult.None, d.PointerUp());
        }

        [Test]
        public void ReleaseWithoutPressDoesNothing()
        {
            Assert.AreEqual(PointerReleaseResult.None, new DragIntentDetector().PointerUp());
        }

        [Test]
        public void MoveWithoutPressNeverStartsDrag()
        {
            Assert.IsFalse(new DragIntentDetector().PointerMove(500f, 500f));
        }

        [Test]
        public void StartPositionIsStoredOnPointerDown()
        {
            var d = new DragIntentDetector();
            d.PointerDown(12f, 34f);
            Assert.AreEqual(12f, d.StartX);
            Assert.AreEqual(34f, d.StartY);
        }

        [Test]
        public void ThresholdIsMeasuredFromPressNotFromPreviousMove()
        {
            var d = new DragIntentDetector();
            d.PointerDown(0f, 0f);
            Assert.IsFalse(d.PointerMove(6f, 0f));
            Assert.IsTrue(d.PointerMove(12f, 0f)); // 6 desde o ultimo, 12 desde o inicio
        }

        [Test]
        public void DisabledThresholdStartsOnFirstMove()
        {
            var d = new DragIntentDetector(10f, false);
            d.PointerDown(0f, 0f);
            Assert.IsTrue(d.PointerMove(0f, 0f));
        }
    }
}
