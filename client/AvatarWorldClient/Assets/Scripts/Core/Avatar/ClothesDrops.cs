using System;
using System.Collections.Generic;
using System.Globalization;

namespace AvatarWorld.Core.Avatar
{
    [Serializable]
    public sealed class ClothesDrop
    {
        /// <summary>yyyy-MM-dd: dia em que o conjunto entra em vigor.</summary>
        public string date;
        /// <summary>Tema do conjunto ("Daizy", "Kawaii_Collection"...). "Empty" = sem drop nessa data.</summary>
        public string name;
        /// <summary>Ids de roupa do editor (skin "Shirt_Special/643" vira "shirt_special_643").</summary>
        public string[] items = new string[0];

        /// <summary>Hora (UTC) em que todo drop entra em vigor: o original monta `new DateTime(ano, mes, dia, 14, 0, 0, Utc)` em
        /// TimeToClothesDropData.GetUnixTimeFromDate (lido no binario, 0x2248a30).</summary>
        public const int StartHourUtc = 14;

        public bool TryGetDate(out DateTime day) =>
            DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out day);

        /// <summary>Instante UTC de inicio do drop (data as 14:00 UTC).</summary>
        public bool TryGetStartUtc(out DateTime startUtc)
        {
            if (!TryGetDate(out var day)) { startUtc = default; return false; }
            startUtc = DateTime.SpecifyKind(day.Date.AddHours(StartHourUtc), DateTimeKind.Utc);
            return true;
        }
    }

    [Serializable]
    public sealed class ClothesDropStoreData
    {
        /// <summary>Loja do original (ClothesDropMap_&lt;key&gt;_L&lt;level&gt;): "Fashionshop", "Kawaiishop", "KPopStore"...</summary>
        public string key;
        public int levelType;
        public ClothesDrop[] drops = new ClothesDrop[0];
    }

    [Serializable]
    public sealed class ClothesDropsFile
    {
        public ClothesDropStoreData[] stores = new ClothesDropStoreData[0];
    }

    /// <summary>
    /// Drops de roupa do original (PWC.Level.ClothesDropDataMap, exportado por tools/export_clothes_drops.py). No original cada loja tem uma
    /// agenda de conjuntos por data e o botao da Home mostra uma bolinha de "novo" quando o drop vigente e diferente do ultimo visto
    /// (ClothesDropUtils.CheckIsAnyNewDropExist). Toda a agenda do APK termina em 2025, entao offline o "vigente" e o mais recente que
    /// tem pecas (o original trata "Empty" como sem drop; aqui um conjunto vazio so e pulado).
    /// </summary>
    public static class ClothesDrops
    {
        /// <summary>
        /// Drop vigente no instante `now` (UTC; Local e convertido, Unspecified conta como UTC): o mais recente cujo inicio (data as 14:00 UTC)
        /// ja passou (&lt;=, como `GetDropDataForTime`, que devolve a ultima entrada com unixTime &lt;= agora ou null se todas sao futuras)
        /// e que tem pelo menos uma peca. O original devolve tambem conjuntos "Empty"; pular os vazios e decisao do cliente.
        /// </summary>
        public static ClothesDrop Current(ClothesDropStoreData store, DateTime now)
        {
            if (store?.drops == null) return null;
            var nowUtc = now.Kind == DateTimeKind.Local ? now.ToUniversalTime() : now;
            ClothesDrop best = null;
            DateTime bestStart = DateTime.MinValue;
            foreach (var drop in store.drops)
            {
                if (drop == null || drop.items == null || drop.items.Length == 0 || !drop.TryGetStartUtc(out var start)) continue;
                if (start > nowUtc) continue;
                if (best == null || start >= bestStart) { best = drop; bestStart = start; }
            }
            return best;
        }

        /// <summary>Ha drop vigente que o jogador ainda nao viu? "Visto" e a data do ultimo drop visto daquela loja (vazio = nunca).</summary>
        public static bool IsNew(ClothesDropStoreData store, DateTime today, string seenDate)
        {
            var current = Current(store, today);
            return current != null && current.date != seenDate;
        }

        /// <summary>Pecas do drop que existem no editor para o tipo de avatar, na ordem do drop.</summary>
        public static List<string> Available(ClothesDrop drop, Func<string, bool> existsInEditor)
        {
            var list = new List<string>();
            if (drop?.items == null) return list;
            foreach (var id in drop.items) if (existsInEditor(id) && !list.Contains(id)) list.Add(id);
            return list;
        }
    }
}
