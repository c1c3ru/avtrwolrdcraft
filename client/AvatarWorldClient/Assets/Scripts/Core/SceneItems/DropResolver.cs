using System.Collections.Generic;

namespace AvatarWorld.Core.SceneItems
{
    /// <summary>
    /// Fim de LevelItem.DropInLevel (0x22fce00): depois de achar a area onde o item pousa, procura a area nao-dropavel mais
    /// baixa que o afeta (GetDownmostUndroppableArea + CanAreaAffectItemStrict); se houver, FallFromUndroppableArea o move
    /// para GetDroppableY da area e a queda recomeca dali. Aproximacao: o original anima com LeanTween e pode rodar
    /// DropAwayFromUndroppableArea (nao reproduzido); aqui so se repete a queda, no maximo MaxRetries vezes.
    /// </summary>
    public static class DropResolver
    {
        public const int MaxRetries = 4;

        /// <summary>Onde o item termina: area sob a base, senao queda (com desvio por area nao-dropavel). null = sem pouso.</summary>
        public static DropArea Resolve(IList<DropArea> areas, IList<UndroppableArea> undroppable, DropItem item,
                                       out float landY)
        {
            landY = item.BottomY;
            var under = DropAreaQuery.Under(areas, item, item.X, item.BottomY);
            if (under != null) return under;
            float y = item.BottomY;
            for (int i = 0; i <= MaxRetries; i++)
            {
                var area = DropAreaQuery.FallOn(areas, undroppable, item, item.X, y, out float hit);
                if (area == null) return null;
                var probe = item; probe.BottomY = hit;
                var und = undroppable == null ? null : UndroppableAreaQuery.Downmost(undroppable, probe, hit);
                if (und == null || !UndroppableAreaQuery.CanAreaAffectItemStrict(und, probe, hit))
                {
                    landY = hit;
                    return area;
                }
                float half = item.BottomWidth * 0.5f;
                float next = UndroppableAreaQuery.GetDroppableY(und, item.X - half, item.X + half);
                if (next >= y) { landY = hit; return area; } // sem progresso: aceita para nao ciclar
                y = next;
            }
            return null;
        }
    }
}
