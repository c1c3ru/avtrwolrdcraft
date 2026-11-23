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

        public bool TryGetDate(out DateTime day) =>
            DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out day);
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
        /// <summary>Drop vigente na data: o mais recente com data &lt;= hoje e pelo menos uma peca; null se nao ha.</summary>
        public static ClothesDrop Current(ClothesDropStoreData store, DateTime today)
        {
            if (store?.drops == null) return null;
            ClothesDrop best = null;
            DateTime bestDay = DateTime.MinValue;
            foreach (var drop in store.drops)
            {
                if (drop == null || drop.items == null || drop.items.Length == 0 || !drop.TryGetDate(out var day)) continue;
                if (day.Date > today.Date) continue;
                if (best == null || day >= bestDay) { best = drop; bestDay = day; }
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
