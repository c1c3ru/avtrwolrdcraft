using AvatarWorld.Core.SceneItems;
using NUnit.Framework;

namespace AvatarWorld.Core.Tests
{
    /// <summary>Regra de LevelDropAreaQuery recuperada do ARM64 (ver comentario de DropAreaQuery).</summary>
    public class DropAreaQueryTests
    {
        static float[] Rect(float x0, float y0, float x1, float y1) => new[] { x0, y0, x1, y0, x1, y1, x0, y1 };
        static DropItem Item(float x, float bottomY, float w = 1f, float h = 1f) =>
            new DropItem { X = x, BottomY = bottomY, BottomWidth = w, Height = h };

        [Test]
        public void Contains_And_TopAt_And_RayDown_Geometry()
        {
            var a = new DropArea(Rect(0, 0, 4, 2), 0);
            Assert.IsTrue(a.Contains(2, 1));
            Assert.IsFalse(a.Contains(5, 1));
            float y;
            Assert.IsTrue(a.TopAt(1, out y)); Assert.AreEqual(2f, y, 1e-5f);
            // de fora, acima: acerta o topo; de dentro: so com considerStartInside, na propria origem
            Assert.IsTrue(a.RayDown(1, 5, false, out y)); Assert.AreEqual(2f, y, 1e-5f);
            Assert.IsFalse(a.RayDown(1, 1, false, out y));
            Assert.IsTrue(a.RayDown(1, 1, true, out y)); Assert.AreEqual(1f, y, 1e-5f);
            // abaixo do poligono: nada a acertar
            Assert.IsFalse(a.RayDown(1, -1, false, out y));
        }

        [Test]
        public void FallOn_PicksNearestSurfaceBelow_NotHighestPriority()
        {
            var far = new DropArea(Rect(0, 0, 10, 1), 9, "far");     // prioridade alta, superficie em y=1
            var near = new DropArea(Rect(0, 3, 10, 4), 0, "near");   // prioridade baixa, superficie em y=4
            var area = DropAreaQuery.FallOn(new[] { far, near }, Item(5, 6), 5, 6, out float hit);
            Assert.AreEqual("near", area.Name);
            Assert.AreEqual(4f, hit, 1e-5f);
        }

        [Test]
        public void FallOn_FloorAcceptsStartInside()
        {
            var floor = new DropArea(Rect(0, -2, 10, 0), 0, "floor", "LevelFloorArea");
            var plain = new DropArea(Rect(0, -2, 10, 0), 0, "plain");
            Assert.AreEqual("floor", DropAreaQuery.FallOn(new[] { floor }, Item(5, -1), 5, -1, out float y).Name);
            Assert.AreEqual(-1f, y, 1e-5f);
            Assert.IsNull(DropAreaQuery.FallOn(new[] { plain }, Item(5, -1), 5, -1, out y));
        }

        [Test]
        public void BasicTests_HeightWidthAndXOverlap()
        {
            var shelf = new DropArea(Rect(0, 0, 4, 1), 0, "shelf", "LevelDropArea", maxItemsHeight: 2f);
            Assert.IsTrue(DropAreaQuery.BasicTests(shelf, Item(2, 5, 1f, 2f)));    // altura 2 cabe em 2
            Assert.IsFalse(DropAreaQuery.BasicTests(shelf, Item(2, 5, 1f, 2.1f))); // alto demais
            Assert.IsFalse(DropAreaQuery.BasicTests(shelf, Item(2, 5, 5f, 1f)));   // base mais larga que a area (4)
            Assert.IsFalse(DropAreaQuery.BasicTests(shelf, Item(9, 5, 1f, 1f)));   // sem sobreposicao em X
            var narrow = new DropArea(Rect(0, 0, 4, 1), 0, "n", "LevelDropArea", 0f, maxItemsWidth: 0.5f);
            Assert.IsFalse(DropAreaQuery.BasicTests(narrow, Item(2, 5, 1f, 1f)));  // _maxItemsWidth manda sobre a largura X
        }

        [Test]
        public void SpecialKinds_AreNotGenericTargets()
        {
            var kill = new DropArea(Rect(0, 0, 4, 1), 0, "k", "LevelKillArea");
            var chars = new DropArea(Rect(0, 0, 4, 1), 0, "c", "LevelCharactersOnlyDropArea");
            Assert.IsNull(DropAreaQuery.Under(new[] { kill, chars }, Item(2, 0.5f), 2, 0.5f));
        }

        [Test]
        public void Under_PrefersPriorityThenSmallerBox()
        {
            var big = new DropArea(Rect(0, 0, 10, 10), 0, "big");
            var small = new DropArea(Rect(0, 0, 4, 2), 0, "small");
            var high = new DropArea(Rect(0, 0, 10, 10), 5, "high");
            Assert.AreEqual("small", DropAreaQuery.Under(new[] { big, small }, Item(1, 1), 1, 1).Name);
            Assert.AreEqual("high", DropAreaQuery.Under(new[] { big, small, high }, Item(1, 1), 1, 1).Name);
        }
    }
}
