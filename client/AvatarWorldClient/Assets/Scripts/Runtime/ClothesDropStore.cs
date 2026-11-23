using System;
using AvatarWorld.Core.Avatar;
using UnityEngine;

namespace AvatarWorld.Runtime
{
    /// <summary>Carrega Resources/ClothesDrops/drops.json e guarda, por loja, a data do ultimo drop visto (preferencia local).</summary>
    public static class ClothesDropStore
    {
        const string SeenPrefix = "home.drops.seen.";
        static ClothesDropsFile _file;

        public static ClothesDropsFile Load()
        {
            if (_file != null) return _file;
            var asset = Resources.Load<TextAsset>("ClothesDrops/drops");
            try { _file = asset != null ? JsonUtility.FromJson<ClothesDropsFile>(asset.text) : null; }
            catch (ArgumentException) { _file = null; }
            return _file ?? (_file = new ClothesDropsFile());
        }

        public static string Seen(string storeKey)
        {
            try { return PlayerPrefs.GetString(SeenPrefix + storeKey, ""); } catch (Exception) { return ""; }
        }

        public static void MarkSeen(ClothesDropStoreData store, DateTime today)
        {
            var current = ClothesDrops.Current(store, today);
            if (current == null) return;
            try { PlayerPrefs.SetString(SeenPrefix + store.key, current.date); PlayerPrefs.Save(); } catch (Exception) { /* sem preferencia: continua "novo" */ }
        }

        public static bool AnyNew(DateTime today)
        {
            foreach (var store in Load().stores) if (ClothesDrops.IsNew(store, today, Seen(store.key))) return true;
            return false;
        }

        public static void MarkAllSeen(DateTime today)
        {
            foreach (var store in Load().stores) MarkSeen(store, today);
        }
    }
}
