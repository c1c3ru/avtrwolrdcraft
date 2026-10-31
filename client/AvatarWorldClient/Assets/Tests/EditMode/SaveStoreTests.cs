using System.IO;
using AvatarWorld.Core.Avatar;
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

        // Ciclo 3 (docs/AVATAR_GAMEPLAY_PLAN.md): "Testes de roundtrip, IDs invalidos, campos
        // ausentes em saves antigos e reabertura do aplicativo mantendo aparencia."

        [Test]
        public void LoadOrCreate_WithoutFile_UsesDefaultAppearance()
        {
            var state = new SaveStore(_file).LoadOrCreate(0);
            Assert.IsNotNull(state.Appearance);
            Assert.IsTrue(state.Appearance.IsFullyValid());
        }

        [Test]
        public void SaveThenLoad_RoundtripsAppearanceChoices()
        {
            var store = new SaveStore(_file);
            var state = PlayerState.CreateNew(10);
            state.Appearance.TrySelect(AvatarCatalog.CategoryShirt, "shirt_casual_1");
            state.Appearance.TrySelect(AvatarCatalog.CategoryShoes, "legs_shoes_10");
            store.Save(state);

            // Simula reabrir o aplicativo: nova instancia de SaveStore lendo o mesmo arquivo.
            var reopened = new SaveStore(_file).LoadOrCreate(0);

            Assert.AreEqual("shirt_casual_1", reopened.Appearance.ShirtId);
            Assert.AreEqual("legs_shoes_10", reopened.Appearance.ShoesId);
            // Categorias nao trocadas mantem o default, nada foi perdido na volta.
            Assert.AreEqual(AvatarCatalog.DefaultOption(AvatarCatalog.CategoryBottom), reopened.Appearance.BottomId);
        }

        [Test]
        public void SaveThenLoad_AppearanceRoundtrip_DoesNotAffectCoinsOrChallenges()
        {
            var store = new SaveStore(_file);
            var state = PlayerState.CreateNew(50);
            new LocalStoreService(state).Claim(new StoreItem { ItemGuid = "x", PazuCurrencyPrice = 10, LoyaltyPointsReward = 1 });
            state.Appearance.TrySelect(AvatarCatalog.CategoryHair, "Hair_Front/2_Color");
            store.Save(state);

            var reopened = new SaveStore(_file).LoadOrCreate(0);

            Assert.AreEqual(40, reopened.PazuCurrency);
            Assert.AreEqual(1, reopened.LoyaltyPoints);
            Assert.AreEqual("Hair_Front/2_Color", reopened.Appearance.HairId);
        }

        [Test]
        public void LoadOrCreate_SaveWithoutAppearanceField_FallsBackToDefaultWithoutLosingBalance()
        {
            Directory.CreateDirectory(_dir);
            // Formato de um save gravado ANTES do Ciclo 3 existir (sem o campo "Appearance" nenhum).
            File.WriteAllText(_file, "{\"PazuCurrency\":77,\"LoyaltyPoints\":2}");

            var state = new SaveStore(_file).LoadOrCreate(0);

            Assert.AreEqual(77, state.PazuCurrency, "campo ausente de Appearance nao pode derrubar o resto do save");
            Assert.AreEqual(2, state.LoyaltyPoints);
            Assert.IsNotNull(state.Appearance);
            Assert.IsTrue(state.Appearance.IsFullyValid());
        }

        [Test]
        public void LoadOrCreate_SaveWithPartialAppearance_FillsMissingFieldsWithDefaults()
        {
            Directory.CreateDirectory(_dir);
            File.WriteAllText(_file, "{\"PazuCurrency\":5,\"LoyaltyPoints\":0,\"Appearance\":{\"ShirtId\":\"shirt_casual_1\"}}");

            var state = new SaveStore(_file).LoadOrCreate(0);

            Assert.AreEqual("shirt_casual_1", state.Appearance.ShirtId);
            Assert.AreEqual(AvatarCatalog.DefaultOption(AvatarCatalog.CategoryBottom), state.Appearance.BottomId);
            Assert.AreEqual(AvatarCatalog.DefaultOption(AvatarCatalog.CategoryShoes), state.Appearance.ShoesId);
        }

        [Test]
        public void LoadOrCreate_SaveWithInvalidAppearanceIds_SanitizesWithoutLosingBalance()
        {
            Directory.CreateDirectory(_dir);
            File.WriteAllText(_file,
                "{\"PazuCurrency\":30,\"LoyaltyPoints\":0,\"Appearance\":{\"ShirtId\":\"item_removido_do_catalogo\",\"BottomId\":\"bottom_special_10\"}}");

            var state = new SaveStore(_file).LoadOrCreate(0);

            Assert.AreEqual(30, state.PazuCurrency);
            Assert.AreEqual(AvatarCatalog.DefaultOption(AvatarCatalog.CategoryShirt), state.Appearance.ShirtId, "ID invalido some, so essa categoria volta ao default");
            Assert.AreEqual("bottom_special_10", state.Appearance.BottomId, "ID valido e preservado, nao e descartado junto");
        }
    }
}
