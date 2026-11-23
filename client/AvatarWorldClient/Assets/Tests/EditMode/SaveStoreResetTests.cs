using System;
using System.IO;
using AvatarWorld.Core.Economy;
using AvatarWorld.Runtime;
using NUnit.Framework;

namespace AvatarWorld.Core.Tests
{
    public class SaveStoreResetTests
    {
        string path;
        [SetUp] public void Setup() => path = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".json");
        [TearDown] public void Cleanup()
        {
            foreach (var f in new[] { path, path + ".before-reset", path + ".tmp" }) if (File.Exists(f)) File.Delete(f);
        }

        [Test] public void ResetWithoutSaveDoesNothing()
        {
            Assert.DoesNotThrow(() => new SaveStore(path).ResetToNew());
            Assert.IsFalse(File.Exists(path + ".before-reset"));
        }

        [Test] public void ResetMovesTheSaveToTheBackup()
        {
            var store = new SaveStore(path);
            store.Save(PlayerState.CreateNew(123));
            store.ResetToNew();
            Assert.IsFalse(File.Exists(path));
            Assert.AreEqual(123, new SaveStore(path + ".before-reset").LoadOrCreate(0).PazuCurrency);
        }

        [Test] public void ResetInPlaceKeepsTheInstanceAndClearsProgress()
        {
            var state = PlayerState.CreateNew(500);
            state.CompletedChallenges.Add("a");
            state.LoyaltyPoints = 9;
            state.SwitchHumanSlot(1);
            var same = state;
            SaveStore.ResetInPlace(state, 50);
            Assert.AreSame(same, state);
            Assert.AreEqual(50, state.PazuCurrency);
            Assert.AreEqual(0, state.LoyaltyPoints);
            Assert.AreEqual(0, state.CompletedChallenges.Count);
            Assert.AreEqual(0, state.ActiveHumanSlot);
            Assert.AreEqual(0, state.OtherAvatars.Count);
            Assert.IsNotNull(state.Appearance);
        }
    }
}
