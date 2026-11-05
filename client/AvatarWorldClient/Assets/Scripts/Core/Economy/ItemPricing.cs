using System;

namespace AvatarWorld.Core.Economy
{
    /// <summary>
    /// Preco local de um item de cena por categoria, em 3 faixas (decisao do autor, 2026-11-05): ate 500 / 501-899 / 900+.
    /// O store_catalog.json tem preco 0 em todos os itens (o preco real e do servidor), entao esta regra e invencao
    /// local; deve constar como "invented" em contracts/store-claim.contract.json (PR #4). Nunca ha preco em dinheiro real.
    /// </summary>
    public static class ItemPricing
    {
        public const int Small = 400, Medium = 700, Large = 1200;

        static readonly string[] LargeWords = { "ugc", "house", "home", "pool", "mansion", "building", "vehicle", "pack" };
        static readonly string[] MediumWords =
        {
            "character", "baby", "toddler", "wall", "ceiling", "carpet", "table", "chair", "bed", "sofa", "couch",
            "shirt", "bottom", "legs", "onepiece", "hair", "dress", "curtain", "window", "door", "floor", "cabinet",
        };

        public static int PriceFor(string category)
        {
            string c = (category ?? "").ToLowerInvariant();
            if (c.Length > 6 && c.EndsWith("box", StringComparison.Ordinal)) return Large; // pacotes (ex.: poolboxpack, ...p33box)
            foreach (var w in LargeWords) if (c.Contains(w)) return Large;
            foreach (var w in MediumWords) if (c.Contains(w)) return Medium;
            return Small;
        }
    }
}
