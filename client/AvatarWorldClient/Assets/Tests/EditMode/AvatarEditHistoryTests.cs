using AvatarWorld.Core.Avatar;
using NUnit.Framework;

namespace AvatarWorld.Core.Tests
{
    public class AvatarEditHistoryTests
    {
        static AvatarAppearance With(string shirt)
        {
            var a = AvatarAppearance.CreateDefault();
            Assert.IsTrue(a.TrySelect(AvatarCatalog.CategoryShirt, shirt));
            return a;
        }

        [Test]
        public void StartsWithoutUndoRedoOrChanges()
        {
            var history = new AvatarEditHistory(AvatarAppearance.CreateDefault());
            Assert.IsFalse(history.CanUndo);
            Assert.IsFalse(history.CanRedo);
            Assert.IsFalse(history.HasChanges);
        }

        [Test]
        public void UndoAndRedoWalkThroughTheStates()
        {
            var history = new AvatarEditHistory(AvatarAppearance.CreateDefault());
            string other = AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryShirt][1];
            history.Push(With(other));
            Assert.IsTrue(history.CanUndo);
            Assert.AreEqual(AvatarCatalog.DefaultOption(AvatarCatalog.CategoryShirt), history.Undo().ShirtId);
            Assert.IsTrue(history.CanRedo);
            Assert.AreEqual(other, history.Redo().ShirtId);
            Assert.IsFalse(history.CanRedo);
        }

        [Test]
        public void PushingAfterUndoDropsTheRedoBranchAndIgnoresDuplicates()
        {
            var history = new AvatarEditHistory(AvatarAppearance.CreateDefault());
            string other = AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryShirt][1];
            history.Push(With(other));
            history.Undo();
            var bottom = AvatarAppearance.CreateDefault();
            bottom.TrySelect(AvatarCatalog.CategoryBottom, AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryBottom][1]);
            history.Push(bottom);
            Assert.IsFalse(history.CanRedo);
            history.Push(bottom);
            Assert.AreEqual(bottom.BottomId, history.Current.BottomId);
            Assert.IsTrue(history.Undo().SameAs(history.Initial));
            Assert.IsFalse(history.CanUndo, "duplicado nao cria passo extra");
        }

        [Test]
        public void ReturnedAppearancesAreCopies()
        {
            var history = new AvatarEditHistory(AvatarAppearance.CreateDefault());
            var current = history.Current;
            current.TrySelect(AvatarCatalog.CategoryShirt, AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryShirt][1]);
            Assert.AreEqual(AvatarCatalog.DefaultOption(AvatarCatalog.CategoryShirt), history.Current.ShirtId);
        }
    }
}
