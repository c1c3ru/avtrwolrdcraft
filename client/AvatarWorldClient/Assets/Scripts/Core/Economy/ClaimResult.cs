namespace AvatarWorld.Core.Economy
{
    public enum ClaimError
    {
        None = 0,
        UnknownItem,
        InsufficientFunds,
        AlreadyClaimed,
        RequiresRealMoney,
        NotAvailable,
    }

    /// <summary>Substitui StoreClaimItemCloudResponse do original (saldo novo, transactionId, limite de resgates).</summary>
    public sealed class ClaimResult
    {
        public bool Success;
        public ClaimError Error;
        public string TransactionId;
        public string ItemGuid;
        public int PazuCurrencyBalance;
        public int LoyaltyPointsBalance;
        public bool HasReachedMaxClaims;
    }
}
