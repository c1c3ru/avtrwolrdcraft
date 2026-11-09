using AvatarWorld.Core.SceneItems;
using NUnit.Framework;

namespace AvatarWorld.Core.Tests
{
    /// <summary>LevelUndroppableAreaQuery recuperada do ARM64 (constantes lidas de libil2cpp.so: 0,3 / -0,1 / 0,5).</summary>
    public class UndroppableAreaQueryTests
    {
        static float[] Rect(float x0, float y0, float x1, float y1) => new[] { x0, y0, x1, y0, x1, y1, x0, y1 };
        static DropItem Item(float x, float bottomY, float w = 1f, float h = 1f) =>
            new DropItem { X = x, BottomY = bottomY, BottomWidth = w, Height = h };

        [Test]
        public void BasicTests_XOverlapAndMinItemsHeight()
        {
            var a = new UndroppableArea(Rect(0, 0, 4, 2), minItemsHeight: 1.5f);
            Assert.IsTrue(UndroppableAreaQuery.BasicTests(a, Item(2, 0, 1f, 1.5f)));
            Assert.IsFalse(UndroppableAreaQuery.BasicTests(a, Item(2, 0, 1f, 1.4f)), "item mais baixo que _minItemsHeight");
            Assert.IsFalse(UndroppableAreaQuery.BasicTests(a, Item(9, 0)), "sem sobreposicao em X");
        }

        [Test]
        public void IsItemTopAboveArea_NeedsMoreThanHalfAUnit()
        {
            Assert.IsTrue(UndroppableAreaQuery.IsItemTopAboveArea(3.6f, 3f));
            Assert.IsFalse(UndroppableAreaQuery.IsItemTopAboveArea(3.4f, 3f));
            Assert.IsFalse(UndroppableAreaQuery.IsItemTopAboveArea(2f, 3f));
        }

        [Test]
        public void CanAffectItemOnDrop_Strict_UsesHorizontalRaycastAcrossTheBase()
        {
            var a = new UndroppableArea(Rect(0, 0, 4, 2), dontAllowForgivingTest: true);
            Assert.IsTrue(UndroppableAreaQuery.CanAffectItemOnDrop(a, Item(2, 0), 1f));      // y dentro
            Assert.IsFalse(UndroppableAreaQuery.CanAffectItemOnDrop(a, Item(2, 0), 3f));     // y acima da area
            // base que comeca fora a esquerda e cruza a borda: o raio horizontal toca
            Assert.IsTrue(UndroppableAreaQuery.CanAffectItemOnDrop(a, Item(-0.2f, 0, 1f), 1f));
        }

        [Test]
        public void CanAffectItemOnDrop_Forgiving_NarrowUsesCenter_WideShrinksTo30Percent()
        {
            var a = new UndroppableArea(Rect(0, 0, 4, 2));
            Assert.IsTrue(UndroppableAreaQuery.CanAffectItemOnDrop(a, Item(2, 0, 1f), 1f));       // estreito, centro dentro
            // base larga (3): encolhe para 30% (0,9) e exige bordas em centro +-0,45 dentro da area
            Assert.IsTrue(UndroppableAreaQuery.CanAffectItemOnDrop(new UndroppableArea(Rect(1.5f, 0, 2.5f, 2)), Item(2, 0, 3f), 1f));
            Assert.IsFalse(UndroppableAreaQuery.CanAffectItemOnDrop(new UndroppableArea(Rect(1.8f, 0, 2.2f, 2)), Item(2, 0, 3f), 1f));
        }

        [Test]
        public void CanAffectItemOnDrop_DontAffectIfItemIsHigher()
        {
            var a = new UndroppableArea(Rect(0, 0, 4, 2), dontAffectIfItemIsHigher: true);
            Assert.IsTrue(UndroppableAreaQuery.CanAffectItemOnDrop(a, Item(2, 1f, 1f, 0.5f), 1.2f));   // topo 1,5 dentro
            Assert.IsFalse(UndroppableAreaQuery.CanAffectItemOnDrop(a, Item(2, 2.6f, 1f, 0.5f), 2.6f)); // topo 3,1 > 2 + 0,5
        }

        [Test]
        public void GetDroppableY_IsLowestCrossingMinusTenth()
        {
            var a = new UndroppableArea(Rect(0, 1, 4, 3));
            Assert.AreEqual(0.9f, UndroppableAreaQuery.GetDroppableY(a, 1f, 3f), 1e-5f);
            var ramp = new UndroppableArea(new float[] { 0, 0, 4, 2, 4, 3, 0, 3 }); // base sobe de 0 a 2 em x
            Assert.AreEqual(1f - 0.1f, UndroppableAreaQuery.GetDroppableY(ramp, 2f, 4f), 1e-5f, "menor cruzamento esta em x=2");
            Assert.AreEqual(-0.1f, UndroppableAreaQuery.GetDroppableY(a, 10f, 12f) - 1f, 1e-5f, "sem cruzamento: base da caixa - 0,1");
        }

        [Test]
        public void CanItemFallOn_OnlyBlocksAreasWithEntity()
        {
            var und = new UndroppableArea(Rect(0, 0, 10, 5), priority: 1) { EntityOrder = 5 }; // com entidade a frente (5 > 3)
            var sceneArea = new DropArea(Rect(0, 0, 10, 1), 0, "scene");
            var onItem = new DropArea(Rect(0, 0, 10, 1), 0, "onItem") { EntityOrder = 3 };
            var list = new[] { und };
            Assert.IsTrue(UndroppableAreaQuery.CanItemFallOn(sceneArea, list, Item(5, 0, 1f, 1f), 5, 1), "sem entidade: aceita sempre");
            Assert.IsFalse(UndroppableAreaQuery.CanItemFallOn(onItem, list, Item(5, 0, 1f, 1f), 5, 1), "area de item dentro de area nao-dropavel mais alta que o item e antes dela");
            Assert.IsTrue(UndroppableAreaQuery.CanItemFallOn(onItem, list, Item(5, 0, 1f, 9f), 5, 1), "area mais baixa que o item nao bloqueia");
            Assert.IsTrue(UndroppableAreaQuery.CanItemFallOn(onItem, list, Item(5, 0, 1f, 1f), 50, 1), "ponto de pouso fora");
            // nao-dropavel do cenario (sem entidade) vem DEPOIS de uma area com entidade em CompareConsumers: nao bloqueia
            var sceneUnd = new UndroppableArea(Rect(0, 0, 10, 5), priority: 9);
            Assert.IsTrue(UndroppableAreaQuery.CanItemFallOn(onItem, new[] { sceneUnd }, Item(5, 0, 1f, 1f), 5, 1));
        }

        [Test]
        public void FallOn_WithUndroppable_SkipsBlockedEntityAreaAndUsesTheNextOne()
        {
            var und = new UndroppableArea(Rect(0, 2, 10, 6), priority: 1) { EntityOrder = 5 };
            var onItem = new DropArea(Rect(0, 0, 10, 4), 0, "onItem") { EntityOrder = 3 }; // superficie y=4, dentro da nao-dropavel
            var floor = new DropArea(Rect(0, -2, 10, 0), 0, "floor", "LevelFloorArea");     // superficie y=0
            var item = Item(5, 7f, 1f, 1f);
            Assert.AreEqual("onItem", DropAreaQuery.FallOn(new[] { onItem, floor }, item, 5, 7f, out float y).Name);
            Assert.AreEqual(4f, y, 1e-5f);
            var blocked = DropAreaQuery.FallOn(new[] { onItem, floor }, new[] { und }, item, 5, 7f, out y);
            Assert.AreEqual("floor", blocked.Name);
            Assert.AreEqual(0f, y, 1e-5f);
        }
    }
}
