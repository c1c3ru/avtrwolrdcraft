using AvatarWorld.Core.Avatar;
using AvatarWorld.Core.Economy;
using NUnit.Framework;
using UnityEngine;

namespace AvatarWorld.Core.Tests
{
    public class AvatarSlotsTests
    {
        [Test]
        public void NewStateHasOnlyTheFirstSlot()
        {
            var state = PlayerState.CreateNew(0);
            Assert.IsTrue(state.HasHumanAvatar(0));
            Assert.IsFalse(state.HasHumanAvatar(1));
            Assert.IsFalse(state.HasHumanAvatar(2));
            Assert.IsNull(state.GetHumanAppearance(1));
        }

        [Test]
        public void SwitchingCreatesSlotsAndKeepsEachAvatar()
        {
            var state = PlayerState.CreateNew(0);
            state.Appearance.TrySelect(AvatarCatalog.CategoryShirt, AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryShirt][5]);
            string first = state.Appearance.ShirtId;
            Assert.IsTrue(state.SwitchHumanSlot(1));
            Assert.AreEqual(1, state.ActiveHumanSlot);
            Assert.AreEqual(AvatarCatalog.DefaultOption(AvatarCatalog.CategoryShirt), state.Appearance.ShirtId);
            state.Appearance.TrySelect(AvatarCatalog.CategoryShirt, AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryShirt][9]);
            string second = state.Appearance.ShirtId;
            Assert.IsFalse(state.SwitchHumanSlot(0));
            Assert.AreEqual(first, state.Appearance.ShirtId);
            Assert.AreEqual(second, state.GetHumanAppearance(1).ShirtId);
            Assert.IsTrue(state.SwitchHumanSlot(2));
            Assert.IsTrue(state.HasHumanAvatar(0) && state.HasHumanAvatar(1) && state.HasHumanAvatar(2));
            Assert.Throws<System.ArgumentOutOfRangeException>(() => state.SwitchHumanSlot(PlayerState.HumanSlotCount));
        }

        [Test]
        public void DiscardRestoresThePreviousAvatarAndEmptiesTheSlot()
        {
            var state = PlayerState.CreateNew(0);
            state.SwitchHumanSlot(2);
            state.DiscardHumanSlot(2, 0);
            Assert.AreEqual(0, state.ActiveHumanSlot);
            Assert.IsFalse(state.HasHumanAvatar(2));
            Assert.AreEqual(0, state.OtherAvatars.Count);
        }

        [Test]
        public void SlotsSurviveJsonRoundTripAndSanitizeBadData()
        {
            var state = PlayerState.CreateNew(0);
            state.SwitchHumanSlot(1);
            state.Appearance.TrySelect(AvatarCatalog.CategoryShoes, AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryShoes][7]);
            var back = JsonUtility.FromJson<PlayerState>(JsonUtility.ToJson(state));
            back.SanitizeAvatarSlots();
            Assert.AreEqual(1, back.ActiveHumanSlot);
            Assert.AreEqual(state.Appearance.ShoesId, back.Appearance.ShoesId);
            Assert.IsTrue(back.HasHumanAvatar(0));

            back.ActiveHumanSlot = 9;
            back.OtherAvatars.Add(new SavedAvatar { Slot = 9 });
            back.OtherAvatars.Add(new SavedAvatar { Slot = 0 });
            back.OtherAvatars.Add(new SavedAvatar { Slot = 0 });
            back.SanitizeAvatarSlots();
            Assert.AreEqual(0, back.ActiveHumanSlot);
            Assert.AreEqual(1, back.OtherAvatars.FindAll(o => o.Slot == 1).Count);
            Assert.IsTrue(back.OtherAvatars.TrueForAll(o => o.Slot != 0 && o.Appearance != null));
        }

        [Test]
        public void ExpandedCatalogExposesAllStrictlyResolvedClothing()
        {
            Assert.GreaterOrEqual(AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryShirt].Length, 1042);
            Assert.GreaterOrEqual(AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryBottom].Length, 970);
            Assert.GreaterOrEqual(AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryShoes].Length, 1171);
            Assert.GreaterOrEqual(AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryAccessory].Length, 833);
        }
    }
}
