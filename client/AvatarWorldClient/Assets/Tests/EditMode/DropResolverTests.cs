using AvatarWorld.Core.SceneItems;
using NUnit.Framework;

namespace AvatarWorld.Core.Tests
{
    public class DropResolverTests
    {
        static float[] Rect(float x0, float y0, float x1, float y1) => new[] { x0, y0, x1, y0, x1, y1, x0, y1 };
        static DropItem Item(float x, float y) => new DropItem { X = x, BottomY = y, BottomWidth = 1f, Height = 1f };

        [Test]
        public void NoUndroppable_LandsOnNearestSurface()
        {
            var floor = new DropArea(Rect(0, 0, 10, 1), 0, "floor");
            var a = DropResolver.Resolve(new[] { floor }, new UndroppableArea[0], Item(5, 6), out float y);
            Assert.AreEqual("floor", a.Name);
            Assert.AreEqual(1f, y, 1e-5f);
        }

        [Test]
        public void UndroppableOnSurface_RedirectsFallBelowIt()
        {
            var shelf = new DropArea(Rect(0, 3, 10, 4), 0, "shelf");
            var floor = new DropArea(Rect(0, 0, 10, 1), 0, "floor");
            var block = new UndroppableArea(Rect(3, 2.5f, 7, 4.5f), 0, 0f, true);
            var a = DropResolver.Resolve(new[] { shelf, floor }, new[] { block }, Item(5, 6), out float y);
            Assert.IsNotNull(a);
            Assert.Less(y, 4f); // nao pousa na prateleira bloqueada
        }
    }
}
