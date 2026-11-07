using System;
using System.Collections.Generic;
using AvatarWorld.Core.Avatar;

namespace AvatarWorld.Core.Economy
{
    /// <summary>Regras locais deliberadas; não são preços ou recompensas do servidor original.</summary>
    public sealed class OfflineHomeService
    {
        public static readonly string[] OutfitNames = { "Passeio", "Escola", "Fim de semana" };
        public static readonly int[] OutfitPrices = { 15, 20, 25 };
        public const int ChallengesPerTier = 4;
        static readonly string[] OutfitCategories = {
            AvatarCatalog.CategoryHair, AvatarCatalog.CategoryShirt, AvatarCatalog.CategoryBottom,
            AvatarCatalog.CategoryShoes, AvatarCatalog.CategoryAccessory };
        readonly PlayerState state;
        readonly Action persist;
        readonly Func<DateTime> today;

        public OfflineHomeService(PlayerState state, Action persist, Func<DateTime> today = null)
        {
            this.state = state;
            this.persist = persist;
            this.today = today ?? (() => DateTime.UtcNow.Date);
        }

        public bool OwnsOutfit(int index) => state.GetClaimCount("offline.outfit." + index) > 0;
        public bool HasPass => state.GetClaimCount("offline.pass") > 0;
        public bool HasStarterGift => state.GetClaimCount("offline.starter") > 0;
        public bool HasDailyGift => state.GetClaimCount(DailyKey) > 0;
        string DailyKey => "offline.daily." + today().ToString("yyyy-MM-dd");

        public string Outfit(int index)
        {
            if (index < 0 || index >= OutfitPrices.Length) throw new ArgumentOutOfRangeException(nameof(index));
            if (!OwnsOutfit(index) && state.PazuCurrency < OutfitPrices[index]) return "Moedas insuficientes.";
            return Commit(() =>
            {
                if (!OwnsOutfit(index))
                    new LocalStoreService(state).Claim(new StoreItem {
                        ItemGuid = "offline.outfit." + index, PazuCurrencyPrice = OutfitPrices[index], IsOneTimeClaim = true });
                int categoryIndex = 0;
                foreach (var category in OutfitCategories)
                {
                    int option = ((index + 1) >> (categoryIndex++ % 2)) & 1;
                    state.Appearance.TrySelect(category, AvatarCatalog.OptionsByCategory[category][option]);
                }
            }, "Visual aplicado e salvo. Você pode vê-lo no editor ou na quadra.");
        }

        public string StarterGift() => Reward("offline.starter", 25, "Presente inicial: +25 moedas.");
        public string DailyGift() => Reward(DailyKey, 10, "Presente do dia: +10 moedas.");

        public string BuyPass()
        {
            if (HasPass) return "Passe local já ativado.";
            if (state.PazuCurrency < 60) return "Moedas insuficientes: o passe custa 60 moedas.";
            return Commit(() => new LocalStoreService(state).Claim(new StoreItem {
                ItemGuid = "offline.pass", PazuCurrencyPrice = 60, IsOneTimeClaim = true }), "Passe local ativado.");
        }

        public string ClaimPassReward(int tier)
        {
            if (tier < 1 || tier > 3) throw new ArgumentOutOfRangeException(nameof(tier));
            if (!HasPass) return "Ative o passe local primeiro.";
            if (new HashSet<string>(state.CompletedChallenges).Count < tier * ChallengesPerTier) return "Complete " + tier * ChallengesPerTier + " desafios diferentes para este prêmio.";
            return Reward("offline.pass.reward." + tier, 25, "Prêmio do passe: +25 moedas.");
        }

        string Reward(string key, int coins, string message)
        {
            if (state.GetClaimCount(key) > 0) return "Você já resgatou este prêmio.";
            return Commit(() =>
            {
                state.IncrementClaim(key);
                new LocalStoreService(state).Earn(coins, key);
            }, message);
        }

        string Commit(Action mutation, string message)
        {
            int coins = state.PazuCurrency, points = state.LoyaltyPoints;
            var claims = new List<ClaimCount>();
            foreach (var c in state.Claims) claims.Add(new ClaimCount { ItemGuid = c.ItemGuid, Count = c.Count });
            var ledger = new List<TransactionRecord>(state.Ledger);
            var appearance = new AvatarAppearance();
            foreach (var pair in AvatarCatalog.OptionsByCategory) appearance.TrySelect(pair.Key, state.Appearance.Get(pair.Key));
            try { mutation(); persist(); return message; }
            catch
            {
                state.PazuCurrency = coins;
                state.LoyaltyPoints = points;
                state.Claims = claims;
                state.Ledger = ledger;
                state.Appearance = appearance;
                throw;
            }
        }
    }
}
