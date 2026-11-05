using System;
using System.Collections.Generic;
using System.Linq;

namespace AvatarWorld.Core.Economy
{
    /// <summary>Item de cena do catalogo extraido (store_catalog.json): um por GUID.</summary>
    public sealed class CatalogItem
    {
        public string Guid, Name, Category;
        public int Price => ItemPricing.PriceFor(Category);

        public StoreItem ToStoreItem() => new StoreItem
        {
            ItemGuid = Guid, Name = Name, PazuCurrencyPrice = Price, IsOneTimeClaim = true,
        };
    }

    /// <summary>Indice em memoria por categoria, com paginacao para a tela de itens. Sem dependencia da engine.</summary>
    public sealed class ItemCatalogIndex
    {
        readonly Dictionary<string, List<CatalogItem>> _byCategory = new Dictionary<string, List<CatalogItem>>();
        readonly Dictionary<string, CatalogItem> _byGuid = new Dictionary<string, CatalogItem>();

        public ItemCatalogIndex(IEnumerable<CatalogItem> items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            foreach (var item in items)
            {
                if (string.IsNullOrEmpty(item.Guid) || _byGuid.ContainsKey(item.Guid)) continue; // primeiro vence
                _byGuid[item.Guid] = item;
                if (!_byCategory.TryGetValue(item.Category, out var list)) _byCategory[item.Category] = list = new List<CatalogItem>();
                list.Add(item);
            }
            foreach (var list in _byCategory.Values) list.Sort((a, b) => string.CompareOrdinal(a.Name, b.Name));
        }

        public int Count => _byGuid.Count;

        /// <summary>Categorias da maior para a menor; empate por nome.</summary>
        public IReadOnlyList<string> Categories(int max = int.MaxValue) => _byCategory
            .OrderByDescending(p => p.Value.Count).ThenBy(p => p.Key, StringComparer.Ordinal)
            .Select(p => p.Key).Take(max).ToList();

        public int CountIn(string category) => _byCategory.TryGetValue(category, out var l) ? l.Count : 0;

        public int PageCount(string category, int pageSize) => (CountIn(category) + pageSize - 1) / pageSize;

        public IReadOnlyList<CatalogItem> Page(string category, int page, int pageSize)
        {
            if (pageSize <= 0) throw new ArgumentOutOfRangeException(nameof(pageSize));
            if (!_byCategory.TryGetValue(category, out var list) || page < 0) return Array.Empty<CatalogItem>();
            return list.Skip(page * pageSize).Take(pageSize).ToList();
        }

        public CatalogItem Find(string guid) => _byGuid.TryGetValue(guid ?? "", out var i) ? i : null;
    }
}
