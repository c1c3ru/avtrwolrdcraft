using AvatarWorld.Core.Avatar;
using NUnit.Framework;

namespace AvatarWorld.Core.Tests
{
    public class AvatarAppearanceTests
    {
        [Test]
        public void CreateDefault_IsFullyValid()
        {
            var appearance = AvatarAppearance.CreateDefault();
            Assert.IsTrue(appearance.IsFullyValid());
        }

        [Test]
        public void TrySelect_ValidId_ChangesCategoryAndReturnsTrue()
        {
            var appearance = AvatarAppearance.CreateDefault();
            bool ok = appearance.TrySelect(AvatarCatalog.CategoryShirt, "shirt_casual_1");
            Assert.IsTrue(ok);
            Assert.AreEqual("shirt_casual_1", appearance.ShirtId);
        }

        [Test]
        public void TrySelect_UnknownIdForCategory_ReturnsFalseAndKeepsPreviousValue()
        {
            var appearance = AvatarAppearance.CreateDefault();
            string before = appearance.ShirtId;
            bool ok = appearance.TrySelect(AvatarCatalog.CategoryShirt, "shirt_does_not_exist");
            Assert.IsFalse(ok);
            Assert.AreEqual(before, appearance.ShirtId);
        }

        [Test]
        public void TrySelect_IdFromAnotherCategory_IsRejected()
        {
            var appearance = AvatarAppearance.CreateDefault();
            // "bottom_special_1" e valido para Bottom, nao para Shirt.
            bool ok = appearance.TrySelect(AvatarCatalog.CategoryShirt, "bottom_special_1");
            Assert.IsFalse(ok);
        }

        [Test]
        public void TrySelect_UnknownCategory_ReturnsFalse()
        {
            var appearance = AvatarAppearance.CreateDefault();
            Assert.IsFalse(appearance.TrySelect("NaoExiste", "qualquer"));
        }

        [Test]
        public void SanitizeInPlace_InvalidFields_ResetOnlyThoseToDefault()
        {
            var appearance = AvatarAppearance.CreateDefault();
            appearance.ShirtId = "item_de_catalogo_antigo_removido";
            appearance.BottomId = "bottom_special_10"; // valido, deve permanecer

            appearance.SanitizeInPlace();

            Assert.AreEqual(AvatarCatalog.DefaultOption(AvatarCatalog.CategoryShirt), appearance.ShirtId);
            Assert.AreEqual("bottom_special_10", appearance.BottomId);
            Assert.IsTrue(appearance.IsFullyValid());
        }

        [Test]
        public void SanitizeInPlace_NullFields_FallBackToDefault()
        {
            var appearance = AvatarAppearance.CreateDefault();
            appearance.AccessoryId = null;

            appearance.SanitizeInPlace();

            Assert.AreEqual(AvatarCatalog.DefaultOption(AvatarCatalog.CategoryAccessory), appearance.AccessoryId);
        }

        [Test]
        public void Get_ReturnsCurrentSelectionPerCategory()
        {
            var appearance = AvatarAppearance.CreateDefault();
            appearance.TrySelect(AvatarCatalog.CategoryShoes, "legs_shoes_10");
            Assert.AreEqual("legs_shoes_10", appearance.Get(AvatarCatalog.CategoryShoes));
        }
    }
}
