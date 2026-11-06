using System.Collections.Generic;

namespace AvatarWorld.Core.Economy
{
    /// <summary>
    /// Gate de pecas do editor de avatar: uma peca listada em <see cref="StorePackContent"/> so pode ser escolhida
    /// depois de comprar um combo da loja que a contenha. Pecas fora de qualquer combo sao livres.
    /// </summary>
    public static class PackGate
    {
        static Dictionary<string, List<string>> _offersByItem;

        static Dictionary<string, List<string>> Index()
        {
            if (_offersByItem != null) return _offersByItem;
            var map = new Dictionary<string, List<string>>();
            foreach (var pair in StorePackContent.ItemsByOffer)
                foreach (var item in pair.Value)
                {
                    if (!map.TryGetValue(item, out var list)) map[item] = list = new List<string>();
                    list.Add(pair.Key);
                }
            return _offersByItem = map;
        }

        /// <summary>Ids de combos que liberam a peca (vazio = peca livre).</summary>
        public static IReadOnlyList<string> OffersFor(string itemId) =>
            itemId != null && Index().TryGetValue(itemId, out var list) ? list : (IReadOnlyList<string>)new string[0];

        public static bool IsLocked(PlayerState state, string itemId)
        {
            var offers = OffersFor(itemId);
            if (offers.Count == 0) return false;
            if (state == null) return true;
            foreach (var offer in offers)
                if (state.GetClaimCount(offer) >= 1) return false;
            return true;
        }

        /// <summary>Titulo do primeiro combo que contem a peca, para a mensagem de bloqueio.</summary>
        public static string OfferTitleFor(string itemId)
        {
            var offers = OffersFor(itemId);
            var offer = offers.Count > 0 ? StoreCatalog.Find(offers[0]) : null;
            return offer?.Title;
        }
    }
}
