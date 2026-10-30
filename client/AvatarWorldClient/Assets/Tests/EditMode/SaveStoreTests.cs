using System.IO;
using AvatarWorld.Core.Economy;
using AvatarWorld.Runtime;
using NUnit.Framework;

namespace AvatarWorld.Core.Tests
{
    public class SaveStoreTests
    {
        string _dir;
        string _file;

        [SetUp]
        public void SetUp()
        {
            _dir = Path.Combine(Path.GetTempPath(), "aw_save_" + System.Guid.NewGuid().ToString("N"));
            _file = Path.Combine(_dir, "player_state.json");
        }

        [TearDown]
        public void TearDown()
        {
            if (Directory.Exists(_dir)) Directory.Delete(_dir, true);
        }

        [Test]
        public void LoadOrCreate_WithoutFile_UsesStartingBalance()
        {
            var s = new SaveStore(_file).LoadOrCreate(30);
            Assert.AreEqual(30, s.PazuCurrency);
            Assert.IsEmpty(s.Ledger);
        }

        [Test]
        public void SaveThenLoad_RestoresBalancesClaimsAndLedger()
        {
            var store = new SaveStore(_file);
            var state = PlayerState.CreateNew(100);
            var svc = new LocalStoreService(state);
            svc.Claim(new StoreItem { ItemGuid = "hat", PazuCurrencyPrice = 40, LoyaltyPointsReward = 3 });
            store.Save(state);

            var back = new SaveStore(_file).LoadOrCreate(0);

            Assert.AreEqual(60, back.PazuCurrency);
            Assert.AreEqual(3, back.LoyaltyPoints);
            Assert.AreEqual(1, back.GetClaimCount("hat"));
            Assert.AreEqual(1, back.Ledger.Count);
            Assert.AreEqual(-40, back.Ledger[0].PazuCurrencyDelta);
        }

        [Test]
        public void Save_Twice_OverwritesWithoutLeavingTempFile()
        {
            var store = new SaveStore(_file);
            store.Save(PlayerState.CreateNew(1));
            store.Save(PlayerState.CreateNew(2));

            Assert.AreEqual(2, new SaveStore(_file).LoadOrCreate(0).PazuCurrency);
            Assert.IsFalse(File.Exists(_file + ".tmp"));
        }

        [Test]
        public void LoadOrCreate_CorruptFile_IsPreservedAndStateStartsFresh()
        {
            Directory.CreateDirectory(_dir);
            File.WriteAllText(_file, "{ isto nao e json valido");
            UnityEngine.TestTools.LogAssert.Expect(UnityEngine.LogType.Warning, new System.Text.RegularExpressions.Regex("Save ilegivel"));

            var s = new SaveStore(_file).LoadOrCreate(15);

            Assert.AreEqual(15, s.PazuCurrency);
            Assert.IsTrue(File.Exists(_file + ".corrupt"));
            Assert.AreEqual("{ isto nao e json valido", File.ReadAllText(_file + ".corrupt"));
        }

        [Test]
        public void LoadOrCreate_NegativeBalanceInFile_IsTreatedAsCorrupt()
        {
            Directory.CreateDirectory(_dir);
            File.WriteAllText(_file, "{\"PazuCurrency\":-5,\"LoyaltyPoints\":0}");
            UnityEngine.TestTools.LogAssert.Expect(UnityEngine.LogType.Warning, new System.Text.RegularExpressions.Regex("Save ilegivel"));

            Assert.AreEqual(7, new SaveStore(_file).LoadOrCreate(7).PazuCurrency);
        }
    }
}
