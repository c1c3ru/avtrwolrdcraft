using System.Collections.Generic;

namespace AvatarWorld.Core.Economy
{
    /// <summary>
    /// Passe de Avatar offline. No original e uma assinatura (game55.subscription.avatarpass): quem assina ganha os combos marcados
    /// como "incluidos no passe" (StoreData.isIncludedInAvatarPass) e uma recompensa periodica. Quais combos e quanto valem vem do
    /// servidor, entao este desenho e do cliente: compra unica com moedas dos desafios que libera um conjunto fixo de combos de moda.
    /// Nada de dinheiro real, assinatura, renovacao ou recompensa periodica.
    /// </summary>
    public static class AvatarPass
    {
        public const string Id = "avatar-pass";
        public const int Price = 1500;

        /// <summary>Combos de moda liberados pelo passe (escolha local; somam bem mais que o preco do passe).</summary>
        public static readonly IReadOnlyList<string> IncludedOfferIds = new[]
        {
            "bundle-PB13", // Ricos e Famosos
            "bundle-PB20", // Pop Star
            "bundle-PB23", // Show ao vivo
            "bundle-PB24", // Ferias de Primavera
        };

        /// <summary>Cartao do passe. Arte provisoria: reaproveita o cartao/capa do primeiro combo incluido (o APK nao traz arte propria extraida).</summary>
        public static readonly StoreOffer Offer = new StoreOffer
        {
            Id = Id,
            Title = "Passe de Avatar",
            Category = StoreCatalog.CategoryAvatarPass,
            Price = Price,
            Art = "PB13",
        };

        public static bool IsActive(PlayerState state) => state != null && state.GetClaimCount(Id) >= 1;

        /// <summary>
        /// Compra o passe com moedas. Em caso de sucesso concede (sem custo extra) cada combo incluido que o jogador ainda nao tem;
        /// quem ja tinha algum deles continua com 1 resgate, nao 2. Falha (saldo, ja comprado) nao altera nada.
        /// </summary>
        public static ClaimResult Buy(PlayerState state)
        {
            var result = new LocalStoreService(state).Claim(Offer.ToStoreItem());
            if (!result.Success) return result;
            foreach (var offerId in IncludedOfferIds)
                if (state.GetClaimCount(offerId) == 0) state.IncrementClaim(offerId);
            return result;
        }

        public static int IncludedCount => IncludedOfferIds.Count;
    }
}
