namespace AvatarWorld.Core.Economy
{
    /// <summary>
    /// Vaga extra de veiculo (aba "car" da tela de slots, 2º slot): duas faixas de compra, nao listadas na
    /// loja geral (sem esqueleto de "carro do avatar" extraido ainda - ver docs/AVATAR_PETS_VEHICLES_PLAN.md).
    /// Padrao so reserva o slot; Premium reserva e devolve um bonus de moedas - a diferenca entre as faixas.
    /// </summary>
    public static class VehicleSlotCatalog
    {
        public const string StandardId = "vehicle-slot-standard";
        public const string PremiumId = "vehicle-slot-premium";
        public const int StandardPrice = 100;
        public const int PremiumPrice = 300;
        public const int PremiumBonus = 50;

        public static readonly StoreOffer Standard = new StoreOffer
        {
            Id = StandardId,
            Title = "Vaga de Veículo",
            Category = StoreCatalog.CategoryVehicles,
            Price = StandardPrice,
            Art = "Slots/banner_vehicle",
        };

        public static readonly StoreOffer Premium = new StoreOffer
        {
            Id = PremiumId,
            Title = "Vaga de Veículo Premium",
            Category = StoreCatalog.CategoryVehicles,
            Price = PremiumPrice,
            Art = "Slots/banner_vehicle",
        };

        public static bool IsUnlocked(PlayerState state) =>
            state.GetClaimCount(StandardId) > 0 || state.GetClaimCount(PremiumId) > 0;

        public static bool IsPremium(PlayerState state) => state.GetClaimCount(PremiumId) > 0;

        /// <summary>Compra uma das duas faixas; a premium soma o bonus de moedas apos a cobranca.</summary>
        public static ClaimResult Buy(PlayerState state, StoreOffer tier)
        {
            var service = new LocalStoreService(state);
            var result = service.Claim(tier.ToStoreItem());
            if (result.Success && tier.Id == PremiumId)
            {
                service.Earn(PremiumBonus, "vehicle_slot_premium_bonus");
                result.PazuCurrencyBalance = state.PazuCurrency;
            }
            return result;
        }
    }
}
