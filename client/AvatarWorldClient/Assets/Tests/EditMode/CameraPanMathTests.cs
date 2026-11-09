using AvatarWorld.Core.Pointer;
using NUnit.Framework;

namespace AvatarWorld.Core.Tests
{
    /// <summary>Constantes e formulas de GameCameraBase.Awake/OnDrag/Update recuperadas do original.</summary>
    public class CameraPanMathTests
    {
        const float Eps = 1e-5f;

        [Test]
        public void DragFactorIsHeightOverScreenHeight()
        {
            Assert.AreEqual(10.24f, CameraPanMath.Height, Eps);
            Assert.AreEqual(10.24f / 1080f, CameraPanMath.DragFactor(1080f), Eps);
            Assert.AreEqual(0.01f, CameraPanMath.BeginDragThreshold, Eps);
        }

        [Test]
        public void DraggingRightMovesCameraLeftAndUpMovesItDown()
        {
            var step = CameraPanMath.Step(0f, 0f, 100f, 100f, 200f, 150f, 0.01f, -50f, 50f, true);
            Assert.AreEqual(-1f, step.X, Eps);
            Assert.AreEqual(-0.5f, step.Y, Eps);
        }

        [Test]
        public void HorizontalMoveIsClampedToBounds()
        {
            var right = CameraPanMath.Step(0f, 0f, 0f, 0f, -1000f, 0f, 0.01f, -2f, 3f, true);
            Assert.AreEqual(3f, right.X, Eps);
            var left = CameraPanMath.Step(0f, 0f, 0f, 0f, 1000f, 0f, 0.01f, -2f, 3f, true);
            Assert.AreEqual(-2f, left.X, Eps);
        }

        [Test]
        public void BeginDragNeedsMoreThanThresholdAndOnlyWhenNotAlreadyDragging()
        {
            // fator 0.001: 9 px -> 0.009 (nao inicia); 11 px -> 0.011 (inicia).
            Assert.IsFalse(CameraPanMath.Step(0f, 0f, 0f, 0f, 9f, 0f, 0.001f, -5f, 5f, false).BeginDrag);
            Assert.IsTrue(CameraPanMath.Step(0f, 0f, 0f, 0f, 11f, 0f, 0.001f, -5f, 5f, false).BeginDrag);
            Assert.IsFalse(CameraPanMath.Step(0f, 0f, 0f, 0f, 11f, 0f, 0.001f, -5f, 5f, true).BeginDrag);
        }

        [Test]
        public void VerticalMoveAloneNeverStartsTheDragButStillMovesTheCamera()
        {
            var step = CameraPanMath.Step(0f, 0f, 0f, 0f, 0f, 500f, 0.01f, -5f, 5f, false);
            Assert.IsFalse(step.BeginDrag);
            Assert.AreEqual(-5f, step.Y, Eps);
        }

        [Test]
        public void MovementGateAndShapeBlock()
        {
            Assert.IsFalse(CameraPanMath.MovementAllowed(false, true, false));
            Assert.IsTrue(CameraPanMath.MovementAllowed(true, false, false));
            Assert.IsFalse(CameraPanMath.MovementAllowed(true, false, true));
            Assert.IsTrue(CameraPanMath.MovementAllowed(true, true, true));
            Assert.IsTrue(CameraPanMath.PanBlockedByShape(true, 1));
            Assert.IsFalse(CameraPanMath.PanBlockedByShape(true, 0));
            Assert.IsFalse(CameraPanMath.PanBlockedByShape(false, 5));
        }
    }
}
