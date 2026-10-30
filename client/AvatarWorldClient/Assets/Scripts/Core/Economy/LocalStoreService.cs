using System;

namespace AvatarWorld.Core.Economy
{
    /// <summary>
    /// Servidor de loja local (offline). Compra apenas com moedas do jogo; recusa itens de dinheiro real.
    /// Uma compra recusada nao altera saldo, contagem de resgates nem o historico.
    /// </summary>
    public sealed class LocalStoreService
    {
        readonly PlayerState _state;
        readonly Func<string> _newTransactionId;

        public LocalStoreService(PlayerState state, Func<string> newTransactionId = null)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));
            _newTransactionId = newTransactionId ?? (() => Guid.NewGuid().ToString("N"));
        }

        public PlayerState State => _state;

        public ClaimResult Claim(StoreItem item)
        {
            if (item == null || string.IsNullOrEmpty(item.ItemGuid))
                return Fail(ClaimError.UnknownItem, item);

            if (item.RequiresRealMoney)
                return Fail(ClaimError.RequiresRealMoney, item);

            int price = item.IsFree ? 0 : item.PazuCurrencyPrice;
            if (price < 0 || item.LoyaltyPointsReward < 0)
                return Fail(ClaimError.NotAvailable, item);

            int claims = _state.GetClaimCount(item.ItemGuid);
            bool oneTimeDone = item.IsOneTimeClaim && claims >= 1;
            bool limitDone = item.MaxClaims > 0 && claims >= item.MaxClaims;
            if (oneTimeDone || limitDone)
                return Fail(ClaimError.AlreadyClaimed, item, hasReachedMaxClaims: true);

            if (_state.PazuCurrency < price)
                return Fail(ClaimError.InsufficientFunds, item);

            _state.PazuCurrency -= price;
            _state.LoyaltyPoints += item.LoyaltyPointsReward;
            _state.IncrementClaim(item.ItemGuid);

            string tx = _newTransactionId();
            _state.Ledger.Add(new TransactionRecord
            {
                TransactionId = tx,
                ItemGuid = item.ItemGuid,
                PazuCurrencyDelta = -price,
                LoyaltyPointsDelta = item.LoyaltyPointsReward,
                Reason = "claim",
            });

            int after = claims + 1;
            bool reached = (item.IsOneTimeClaim && after >= 1) || (item.MaxClaims > 0 && after >= item.MaxClaims);
            return new ClaimResult
            {
                Success = true,
                Error = ClaimError.None,
                TransactionId = tx,
                ItemGuid = item.ItemGuid,
                PazuCurrencyBalance = _state.PazuCurrency,
                LoyaltyPointsBalance = _state.LoyaltyPoints,
                HasReachedMaxClaims = reached,
            };
        }

        /// <summary>Moedas ganhas jogando (mecanicas do nivel). Nao existe caminho de compra de moeda aqui.</summary>
        public void Earn(int pazuCurrency, string reason)
        {
            if (pazuCurrency <= 0) throw new ArgumentOutOfRangeException(nameof(pazuCurrency));
            _state.PazuCurrency += pazuCurrency;
            _state.Ledger.Add(new TransactionRecord
            {
                TransactionId = _newTransactionId(),
                PazuCurrencyDelta = pazuCurrency,
                Reason = reason ?? "earn",
            });
        }

        ClaimResult Fail(ClaimError error, StoreItem item, bool hasReachedMaxClaims = false) => new ClaimResult
        {
            Success = false,
            Error = error,
            ItemGuid = item?.ItemGuid,
            PazuCurrencyBalance = _state.PazuCurrency,
            LoyaltyPointsBalance = _state.LoyaltyPoints,
            HasReachedMaxClaims = hasReachedMaxClaims,
        };
    }
}
