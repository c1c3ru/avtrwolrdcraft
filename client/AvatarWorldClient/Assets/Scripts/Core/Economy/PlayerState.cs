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

    /// <summary>Avatar humano guardado num slot que nao e o ativo (o ativo vive em PlayerState.Appearance).</summary>
    [Serializable]
    public sealed class SavedAvatar
    {
        public int Slot;
        public AvatarAppearance Appearance;
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
        /// <summary>Ultimos desafios sorteados (mais antigo primeiro); o ChallengeSelector evita repeti-los.</summary>
        public List<string> RecentChallenges = new List<string>();
        /// <summary>Selecao de aparencia do avatar (Ciclo 3). Inicializador proprio sobrevive a saves
        /// antigos sem este campo - ver AvatarAppearance e SaveStore.LoadOrCreate.</summary>
        public AvatarAppearance Appearance = AvatarAppearance.CreateDefault();

        /// <summary>Quantidade de slots de avatar humano da tela de slots (o original mostra 3).</summary>
        public const int HumanSlotCount = 3;
        /// <summary>Slot (0..HumanSlotCount-1) cujo avatar esta em Appearance - o que o mundo renderiza.</summary>
        public int ActiveHumanSlot;
        /// <summary>Avatares dos demais slots criados. Saves antigos sem o campo ficam so com o slot 0.</summary>
        public List<SavedAvatar> OtherAvatars = new List<SavedAvatar>();

        public bool HasHumanAvatar(int slot)
        {
            if (slot < 0 || slot >= HumanSlotCount) return false;
            if (slot == ActiveHumanSlot) return true;
            return FindOther(slot) != null;
        }

        /// <summary>Aparencia do slot (a ativa ou a guardada); null se o slot esta vazio.</summary>
        public AvatarAppearance GetHumanAppearance(int slot)
        {
            if (slot < 0 || slot >= HumanSlotCount) return null;
            if (slot == ActiveHumanSlot) return Appearance;
            return FindOther(slot)?.Appearance;
        }

        /// <summary>
        /// Torna o slot o avatar ativo (guarda o atual no seu slot). Slot vazio nasce com a aparencia padrao.
        /// Retorna true se o slot acabou de ser criado.
        /// </summary>
        public bool SwitchHumanSlot(int slot)
        {
            if (slot < 0 || slot >= HumanSlotCount) throw new ArgumentOutOfRangeException(nameof(slot));
            if (slot == ActiveHumanSlot) return false;
            var target = FindOther(slot);
            bool created = target == null;
            OtherAvatars.RemoveAll(o => o == null || o.Slot == slot);
            OtherAvatars.Add(new SavedAvatar { Slot = ActiveHumanSlot, Appearance = Appearance });
            Appearance = created ? AvatarAppearance.CreateDefault() : target.Appearance;
            ActiveHumanSlot = slot;
            return created;
        }

        /// <summary>Volta ao slot anterior e apaga o slot dado (usado ao cancelar a criacao de um avatar novo).</summary>
        public void DiscardHumanSlot(int slot, int returnTo)
        {
            if (slot == returnTo || slot < 0 || slot >= HumanSlotCount) return;
            if (slot == ActiveHumanSlot) SwitchHumanSlot(returnTo);
            OtherAvatars.RemoveAll(o => o == null || o.Slot == slot);
        }

        /// <summary>Corrige save invalido: slots fora do intervalo/duplicados e aparencias nulas ou invalidas.</summary>
        public void SanitizeAvatarSlots()
        {
            if (OtherAvatars == null) OtherAvatars = new List<SavedAvatar>();
            if (ActiveHumanSlot < 0 || ActiveHumanSlot >= HumanSlotCount) ActiveHumanSlot = 0;
            var seen = new HashSet<int> { ActiveHumanSlot };
            OtherAvatars.RemoveAll(o => o == null || o.Slot < 0 || o.Slot >= HumanSlotCount || !seen.Add(o.Slot));
            foreach (var o in OtherAvatars)
            {
                if (o.Appearance == null) o.Appearance = AvatarAppearance.CreateDefault();
                else o.Appearance.SanitizeInPlace();
            }
        }

        SavedAvatar FindOther(int slot)
        {
            foreach (var o in OtherAvatars) if (o != null && o.Slot == slot) return o;
            return null;
        }

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
