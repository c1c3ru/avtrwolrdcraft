using System.Collections.Generic;
using AvatarWorld.Core.Pointer;
using NUnit.Framework;

namespace AvatarWorld.Core.Tests
{
    /// <summary>Ordem de CompareConsumers (0x22c3fd4) e escolha de GetMostRelevantDropAreaUnderPosition.</summary>
    public class DropTargetOrderingTests
    {
        static DropCandidate NoEntity(int priority)
        {
            return new DropCandidate { HasEntity = false, SortPriority = priority };
        }

        static DropCandidate WithSorting(int priority, long order)
        {
            return new DropCandidate { HasEntity = true, HasSortingElement = true, SortPriority = priority, SortingOrderForY = order };
        }

        static DropCandidate EntityOnly(int priority)
        {
            return new DropCandidate { HasEntity = true, HasSortingElement = false, SortPriority = priority };
        }

        [Test]
        public void WithoutEntitiesHigherPriorityComesFirst()
        {
            Assert.Less(DropTargetOrdering.Compare(NoEntity(5), NoEntity(1)), 0);
            Assert.Greater(DropTargetOrdering.Compare(NoEntity(1), NoEntity(5)), 0);
            Assert.AreEqual(0, DropTargetOrdering.Compare(NoEntity(3), NoEntity(3)));
        }

        [Test]
        public void EntityComesBeforeNoEntityRegardlessOfPriority()
        {
            Assert.AreEqual(-1, DropTargetOrdering.Compare(EntityOnly(0), NoEntity(99)));
            Assert.AreEqual(1, DropTargetOrdering.Compare(NoEntity(99), EntityOnly(0)));
        }

        [Test]
        public void SortingElementComesBeforeMissingOneWhenBothHaveEntities()
        {
            Assert.AreEqual(-1, DropTargetOrdering.Compare(WithSorting(0, 0), EntityOnly(50)));
            Assert.AreEqual(1, DropTargetOrdering.Compare(EntityOnly(50), WithSorting(0, 0)));
            Assert.Less(DropTargetOrdering.Compare(EntityOnly(7), EntityOnly(2)), 0);
        }

        [Test]
        public void HigherSortingOrderForYComesFirstAndTiesFallBackToPriority()
        {
            Assert.Less(DropTargetOrdering.Compare(WithSorting(0, 200), WithSorting(9, 100)), 0);
            Assert.Greater(DropTargetOrdering.Compare(WithSorting(9, 100), WithSorting(0, 200)), 0);
            Assert.Less(DropTargetOrdering.Compare(WithSorting(8, 100), WithSorting(2, 100)), 0);
            Assert.AreEqual(0, DropTargetOrdering.Compare(WithSorting(4, 100), WithSorting(4, 100)));
        }

        [Test]
        public void PickReturnsFirstDroppableAfterSorting()
        {
            var names = new List<string> { "floor", "table", "shelf" };
            var data = new Dictionary<string, DropCandidate>
            {
                { "floor", WithSorting(0, 10) }, { "table", WithSorting(0, 300) }, { "shelf", WithSorting(0, 200) },
            };
            string picked;
            Assert.IsTrue(DropTargetOrdering.TryPickMostRelevant(names, n => data[n], n => true, out picked));
            Assert.AreEqual("table", picked);
            Assert.IsTrue(DropTargetOrdering.TryPickMostRelevant(names, n => data[n], n => n != "table", out picked));
            Assert.AreEqual("shelf", picked);
            Assert.IsFalse(DropTargetOrdering.TryPickMostRelevant(names, n => data[n], n => false, out picked));
        }
    }
}
