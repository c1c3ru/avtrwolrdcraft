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
        /// <summary>Subgrupo dentro da categoria (sub-trilho da loja). Vazio = sem subgrupo.</summary>
        public string Sub;
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
        public const string CategoryVehicles = "Veículos";
        public const string CategoryHouses = "Casas";
        public const string CategoryStory = "Narrativa";
        /// <summary>
        /// Nao e uma categoria de produtos: no original (level237) e um atalho do trilho que abre a cena
        /// AvatarMakerLobby (aqui, AvatarSlotsScreen) em vez de listar cartoes - mesma relacao que ja existe
        /// no sentido inverso (botao de carrinho dos slots abre a loja). Por isso nunca tem ofertas em
        /// StoreCatalog.All; StoreScreen trata a selecao como navegacao, nao como filtro de cartoes.
        /// Ver docs/STORE_ORIGINAL_REFERENCE_2026-11-07.md.
        /// </summary>
        public const string CategoryAvatarMaker = "Criador de Avatar";
        public const string CategoryCombos = "Combos";
        public const string CategoryFashion = "Moda";
        public const string CategoryVacation = "Casas de Férias";
        public const string CategoryPets = "Pets";
        public const string CategoryCelebrations = "Celebrações";
        public const string CategoryProfessions = "Profissões";
        public const string CategorySports = "Esportes";

        /// <summary>Ordem do trilho lateral do original (rolavel; ha mais categorias que cabem na tela).</summary>
        public static readonly string[] Categories =
        {
            CategoryCoins, CategoryFeatured, CategoryVehicles, CategoryHouses, CategoryStory, CategoryAvatarMaker,
            CategoryCombos, CategoryFashion, CategoryVacation, CategoryPets, CategoryCelebrations, CategoryProfessions,
            CategorySports,
        };

        /// <summary>Categorias do original ainda sem combos locais: a loja mostra "Em breve".</summary>
        public static readonly string[] ComingSoon = { CategoryVehicles, CategoryStory, CategorySports };

        /// <summary>Ids cujo preco em moedas foi lido dos prints do original (docs/STORE_WORLD_UI_SPEC.md).</summary>
        public static readonly string[] Observed = { "PB22", "PB7", "PB26", "PB23", "PB25", "PB27" };

        static StoreOffer O(string id, string title, string category, string sub, int price, bool featured = false) =>
            new StoreOffer { Id = "bundle-" + id, Title = title, Category = category, Sub = sub, Price = price, Art = id, Featured = featured };

        public static readonly IReadOnlyList<StoreOffer> All = new List<StoreOffer>
        {
            O("PB22", "Galxe Mansion", CategoryHouses, "Mansões", 1200, true),
            O("PB7", "Natural Chic", CategoryHouses, "Modernas", 1400, true),
            O("PB26", "Casinha de brincar", CategoryHouses, "Infantis", 770, true),
            O("PB23", "Show ao vivo", CategoryFashion, "Palco", 980, true),
            O("PB25", "Amiguinhos", CategoryPets, "Variados", 1200, true),
            O("PB2", "Mansão", CategoryHouses, "Mansões", 900),
            O("PB8", "Bubble Glam", CategoryHouses, "Modernas", 1100),
            O("PB9", "Casa Moderna", CategoryHouses, "Modernas", 1000),
            O("PB10", "Casa Kawaii", CategoryHouses, "Infantis", 800),
            O("PB11", "Casa de Praia", CategoryVacation, "Praia", 950),
            O("PB12", "Cavalos", CategoryPets, "Cavalos", 700),
            O("PB13", "Ricos e Famosos", CategoryFashion, "Luxo", 1200),
            O("PB14", "Vida em Família", CategoryHouses, "Família", 850),
            O("PB15", "Cachorrinho", CategoryPets, "Cães", 600),
            O("PB16", "Crescendo", CategoryFashion, "Infantil", 750),
            O("PB17", "Estilista de Celebridades", CategoryProfessions, "Estilista", 650),
            O("PB18", "Moda Drip", CategoryFashion, "Urbano", 600),
            O("PB19", "Gatinhos", CategoryPets, "Gatos", 550),
            O("PB20", "Pop Star", CategoryFashion, "Palco", 900),
            O("PB21", "Moda Daisy", CategoryFashion, "Casual", 500),
            O("PB24", "Férias de Primavera", CategoryFashion, "Casual", 800),
            O("PB27", "Festa à Fantasia", CategoryCelebrations, "Festas", 450),
        };

        /// <summary>Subgrupos (sub-trilho) de uma categoria, na ordem de aparicao. Vazio se houver menos de 2.</summary>
        public static IReadOnlyList<string> SubCategories(string category)
        {
            var subs = InCategory(category).Select(o => o.Sub).Where(s => !string.IsNullOrEmpty(s)).Distinct().ToList();
            return subs.Count >= 2 ? subs : new List<string>();
        }

        /// <summary>Ofertas de uma categoria filtradas por subgrupo (null/vazio = todas).</summary>
        public static IReadOnlyList<StoreOffer> InCategory(string category, string sub)
        {
            var list = InCategory(category);
            return string.IsNullOrEmpty(sub) ? list : list.Where(o => o.Sub == sub).ToList();
        }

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
