using System;

namespace AvatarWorld.Core.Economy
{
    /// <summary>
    /// Item da loja. Espelha os campos relevantes de Game.Store.StoreData.Item do jogo original:
    /// pazuCurrencyPrice, isFree, IsRequireRealMoneyPurchase() e entitlements.loyaltyPoints.
    /// </summary>
    [Serializable]
    public sealed class StoreItem
    {
        public string ItemGuid;
        public string Name;
        /// <summary>Preco em pazuCurrency (moeda do jogo). Nao ha preco em dinheiro real.</summary>
        public int PazuCurrencyPrice;
        public bool IsFree;
        /// <summary>Itens que no original exigem compra com dinheiro real. Sempre recusados aqui.</summary>
        public bool RequiresRealMoney;
        /// <summary>Equivale a isOneTimeClaim da resposta do servidor.</summary>
        public bool IsOneTimeClaim;
        /// <summary>Limite de resgates; 0 = sem limite.</summary>
        public int MaxClaims;
        /// <summary>Recompensa em pontos de fidelidade (entitlements.loyaltyPoints).</summary>
        public int LoyaltyPointsReward;
    }
}
