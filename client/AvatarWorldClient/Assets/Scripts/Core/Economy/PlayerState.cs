using System;
using System.Collections.Generic;
using AvatarWorld.Core.Avatar;

namespace AvatarWorld.Core.Economy
{
    [Serializable]
    public sealed class ClaimCount
    {
        public string ItemGuid;
        public int Count;
    }

    [Serializable]
    public sealed class TransactionRecord
    {
        public string TransactionId;
        public string ItemGuid;
        public int PazuCurrencyDelta;
        public int LoyaltyPointsDelta;
        public string Reason;
    }

    /// <summary>
    /// Estado persistente do jogador. Usa so campos publicos, listas e tipos simples
    /// para ser serializavel com JsonUtility pela camada Unity (este assembly nao depende da engine).
    /// </summary>
    [Serializable]
    public sealed class PlayerState
    {
        public int PazuCurrency;
        public int LoyaltyPoints;
        public List<ClaimCount> Claims = new List<ClaimCount>();
        public List<TransactionRecord> Ledger = new List<TransactionRecord>();
        /// <summary>IDs de AvatarWorld.Core.Literacy.LiteracyChallenge ja respondidos corretamente ao menos uma vez.</summary>
        public List<string> CompletedChallenges = new List<string>();
        /// <summary>Selecao de aparencia do avatar (Ciclo 3). Inicializador proprio sobrevive a saves
        /// antigos sem este campo - ver AvatarAppearance e SaveStore.LoadOrCreate.</summary>
        public AvatarAppearance Appearance = AvatarAppearance.CreateDefault();

        public static PlayerState CreateNew(int startingPazuCurrency)
        {
            if (startingPazuCurrency < 0) throw new ArgumentOutOfRangeException(nameof(startingPazuCurrency));
            return new PlayerState { PazuCurrency = startingPazuCurrency };
        }

        public int GetClaimCount(string itemGuid)
        {
            foreach (var c in Claims)
                if (c.ItemGuid == itemGuid) return c.Count;
            return 0;
        }

        internal void IncrementClaim(string itemGuid)
        {
            foreach (var c in Claims)
            {
                if (c.ItemGuid != itemGuid) continue;
                c.Count++;
                return;
            }
            Claims.Add(new ClaimCount { ItemGuid = itemGuid, Count = 1 });
        }

        public bool IsChallengeCompleted(string challengeId) => CompletedChallenges.Contains(challengeId);

        internal void MarkChallengeCompleted(string challengeId)
        {
            if (!CompletedChallenges.Contains(challengeId)) CompletedChallenges.Add(challengeId);
        }
    }
}
