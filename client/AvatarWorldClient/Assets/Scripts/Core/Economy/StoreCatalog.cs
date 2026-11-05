using System.Collections.Generic;
using System.Linq;

namespace AvatarWorld.Core.Economy
{
    /// <summary>Combo (bundle) da loja: arte do cartao/capa do original, preco em moedas definido localmente.</summary>
    public sealed class StoreOffer
    {
        public string Id;
        public string Title;
        public string Category;
        public int Price;
        /// <summary>Resources/Store/packs/{Art}.png (cartao) e covers/{Art}.png (capa).</summary>
        public string Art;
        public bool Featured;

        public StoreItem ToStoreItem() => new StoreItem
        {
            ItemGuid = Id,
            Name = Title,
            PazuCurrencyPrice = Price,
            IsOneTimeClaim = true,
        };
    }

    /// <summary>
    /// Catalogo local da loja. A arte e os nomes de arquivo (PB2..PB27) vem do original; o original vende
    /// por dinheiro real e os precos em moedas so aparecem em prints (6 ids marcados em Observed). Os demais
    /// precos sao decisao local, dentro da faixa observada (300 a 1400 moedas).
    /// </summary>
    public static class StoreCatalog
    {
        public const string CategoryCoins = "Moedas AW";
        public const string CategoryFeatured = "Destaque";
        public const string CategoryHouses = "Casas";
        public const string CategoryFashion = "Moda";
        public const string CategoryPets = "Pets";
        public const string CategoryCombos = "Combos";

        public static readonly string[] Categories =
            { CategoryCoins, CategoryFeatured, CategoryHouses, CategoryFashion, CategoryPets, CategoryCombos };

        /// <summary>Ids cujo preco em moedas foi lido dos prints do original (docs/STORE_WORLD_UI_SPEC.md).</summary>
        public static readonly string[] Observed = { "PB22", "PB7", "PB26", "PB23", "PB25", "PB27" };

        static StoreOffer O(string id, string title, string category, int price, bool featured = false) =>
            new StoreOffer { Id = "bundle-" + id, Title = title, Category = category, Price = price, Art = id, Featured = featured };

        public static readonly IReadOnlyList<StoreOffer> All = new List<StoreOffer>
        {
            O("PB22", "Galxe Mansion", CategoryHouses, 1200, true),
            O("PB7", "Natural Chic", CategoryHouses, 1400, true),
            O("PB26", "Casinha de brincar", CategoryHouses, 770, true),
            O("PB23", "Show ao vivo", CategoryFashion, 980, true),
            O("PB25", "Amiguinhos", CategoryPets, 1200, true),
            O("PB2", "Mansão", CategoryHouses, 900),
            O("PB8", "Bubble Glam", CategoryHouses, 1100),
            O("PB9", "Casa Moderna", CategoryHouses, 1000),
            O("PB10", "Casa Kawaii", CategoryHouses, 800),
            O("PB11", "Casa de Praia", CategoryHouses, 950),
            O("PB12", "Cavalos", CategoryPets, 700),
            O("PB13", "Ricos e Famosos", CategoryFashion, 1200),
            O("PB14", "Vida em Família", CategoryHouses, 850),
            O("PB15", "Cachorrinho", CategoryPets, 600),
            O("PB16", "Crescendo", CategoryFashion, 750),
            O("PB17", "Estilista de Celebridades", CategoryFashion, 650),
            O("PB18", "Moda Drip", CategoryFashion, 600),
            O("PB19", "Gatinhos", CategoryPets, 550),
            O("PB20", "Pop Star", CategoryFashion, 900),
            O("PB21", "Moda Daisy", CategoryFashion, 500),
            O("PB24", "Férias de Primavera", CategoryFashion, 800),
            O("PB27", "Festa à Fantasia", CategoryFashion, 450),
        };

        /// <summary>Ofertas de uma categoria. "Moedas AW" nao tem ofertas: mostra atividades que pagam moedas.</summary>
        public static IReadOnlyList<StoreOffer> InCategory(string category)
        {
            if (category == CategoryCoins) return new List<StoreOffer>();
            if (category == CategoryCombos) return All;
            if (category == CategoryFeatured) return All.Where(o => o.Featured).ToList();
            return All.Where(o => o.Category == category).ToList();
        }

        public static StoreOffer Find(string id) => All.FirstOrDefault(o => o.Id == id);

        public static bool IsOwned(PlayerState state, StoreOffer offer) => state.GetClaimCount(offer.Id) >= 1;

        /// <summary>Compra com moedas; nunca dinheiro real. Resultado vem do LocalStoreService.</summary>
        public static ClaimResult Buy(PlayerState state, StoreOffer offer) =>
            new LocalStoreService(state).Claim(offer.ToStoreItem());
    }
}
