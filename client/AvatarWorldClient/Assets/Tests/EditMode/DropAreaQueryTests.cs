using AvatarWorld.Core.SceneItems;
using NUnit.Framework;

namespace AvatarWorld.Core.Tests
{
    public class DropAreaQueryTests
    {
        // quadrado 0..4 x 0..2 (prateleira)
        static readonly float[] Box = { 0, 0, 4, 0, 4, 2, 0, 2 };
        // triangulo (rampa) com topo inclinado: (0,0) (4,0) (4,3)
        static readonly float[] Ramp = { 0, 0, 4, 0, 4, 3 };

        [Test]
        public void Contains_UsesEvenOddAndBounds()
        {
            var a = new DropArea(Box, 0);
            Assert.IsTrue(a.Contains(2, 1));
            Assert.IsFalse(a.Contains(5, 1));
            Assert.IsFalse(a.Contains(2, 3));
        }

        [Test]
        public void TopAt_ReturnsSurfaceHeightAndMissesOutside()
        {
            float top;
            Assert.IsTrue(new DropArea(Box, 0).TopAt(1, out top));
            Assert.AreEqual(2f, top, 1e-5f);
            Assert.IsTrue(new DropArea(Ramp, 0).TopAt(2, out top));
            Assert.AreEqual(1.5f, top, 1e-5f);
            Assert.IsFalse(new DropArea(Box, 0).TopAt(9, out top));
        }

        [Test]
        public void Best_PrefersPriorityThenSmallerArea()
        {
            var big = new DropArea(new float[] { 0, 0, 10, 0, 10, 10, 0, 10 }, 0, "big");
            var small = new DropArea(Box, 0, "small");
            var high = new DropArea(new float[] { 0, 0, 10, 0, 10, 10, 0, 10 }, 5, "high");
            Assert.AreEqual("small", DropAreaQuery.Best(new[] { big, small }, 1, 1).Name);
            Assert.AreEqual("high", DropAreaQuery.Best(new[] { big, small, high }, 1, 1).Name);
            Assert.IsNull(DropAreaQuery.Best(new[] { small }, 8, 8));
        }
    }
}
