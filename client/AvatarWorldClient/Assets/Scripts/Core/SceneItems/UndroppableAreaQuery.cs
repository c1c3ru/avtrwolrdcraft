using System.Collections.Generic;

namespace AvatarWorld.Core.SceneItems
{
    /// <summary>
    /// LevelUndroppableArea (e LevelNonCharacterUndroppableArea): regiao onde um item solto nao pode ficar.
    /// Campos serializados: _sortPriority, _minItemsHeight (+0x54), _dontAllowForgivingTest (+0x58),
    /// _dontAffectIfItemIsHigher (+0x59).
    /// </summary>
    public sealed class UndroppableArea : IConsumer
    {
        public float[] Poly;
        public int Priority { get; set; }
        public int EntityOrder { get; set; } = -1;
        public float MinItemsHeight;
        public bool DontAllowForgivingTest, DontAffectIfItemIsHigher;
        public string Name, Kind;
        public float MinX = float.MaxValue, MaxX = float.MinValue, MinY = float.MaxValue, MaxY = float.MinValue;

        public UndroppableArea(float[] poly, int priority = 0, float minItemsHeight = 0f, bool dontAllowForgivingTest = false,
                               bool dontAffectIfItemIsHigher = false, string name = "", string kind = "LevelUndroppableArea")
        {
            Poly = poly; Priority = priority; MinItemsHeight = minItemsHeight;
            DontAllowForgivingTest = dontAllowForgivingTest; DontAffectIfItemIsHigher = dontAffectIfItemIsHigher;
            Name = name; Kind = kind;
            for (int i = 0; i + 1 < poly.Length; i += 2)
            {
                if (poly[i] < MinX) MinX = poly[i];
                if (poly[i] > MaxX) MaxX = poly[i];
                if (poly[i + 1] < MinY) MinY = poly[i + 1];
                if (poly[i + 1] > MaxY) MaxY = poly[i + 1];
            }
        }

        public float Height => MaxY - MinY;

        public bool Contains(float x, float y)
        {
            if (x < MinX || x > MaxX || y < MinY || y > MaxY) return false;
            bool inside = false;
            int n = Poly.Length / 2;
            for (int i = 0, j = n - 1; i < n; j = i++)
            {
                float xi = Poly[2 * i], yi = Poly[2 * i + 1], xj = Poly[2 * j], yj = Poly[2 * j + 1];
                if ((yi > y) != (yj > y) && x < (xj - xi) * (y - yi) / (yj - yi) + xi) inside = !inside;
            }
            return inside;
        }

        /// <summary>
        /// IsXBoundsTouching: CShapeModel.Raycast horizontal de (xMin,y) a (xMax,y) com considerStartInside ligado:
        /// toca se a origem esta dentro ou se algum segmento do poligono cruza esse trecho.
        /// </summary>
        public bool TouchesHorizontal(float xMin, float xMax, float y)
        {
            if (Contains(xMin, y)) return true;
            int n = Poly.Length / 2;
            for (int i = 0, j = n - 1; i < n; j = i++)
            {
                float xi = Poly[2 * i], yi = Poly[2 * i + 1], xj = Poly[2 * j], yj = Poly[2 * j + 1];
                if ((yi > y) == (yj > y)) continue;
                float cx = xi + (y - yi) * (xj - xi) / (yj - yi);
                if (cx >= xMin && cx <= xMax) return true;
            }
            return false;
        }

        /// <summary>Menor y em que a vertical x cruza o poligono (raio de baixo para cima, de -1000 a 1000); false se nao cruza.</summary>
        public bool LowestCrossing(float x, out float y)
        {
            y = float.MaxValue;
            bool hit = false;
            int n = Poly.Length / 2;
            for (int i = 0, j = n - 1; i < n; j = i++)
            {
                float xi = Poly[2 * i], yi = Poly[2 * i + 1], xj = Poly[2 * j], yj = Poly[2 * j + 1];
                if ((xi > x) == (xj > x)) continue;
                float cy = yi + (x - xi) * (yj - yi) / (xj - xi);
                if (cy < y) { y = cy; hit = true; }
            }
            return hit;
        }
    }

    /// <summary>
    /// LevelUndroppableAreaQuery (0x23550cc..0x2355944), LevelUndroppableArea.GetDroppableY (0x228e820) e
    /// LevelUtils.IsItemTopAboveArea (0x23331e4), recuperados do ARM64.
    /// Nao reproduzido: CanConsumeItem das subclasses, o teste "item filho da area", o ramo de personagem de GetDroppableY,
    /// a ordem exata dentro de LevelItem.DropInLevel (GetDownmostUndroppableArea / FallFromUndroppableArea).
    /// </summary>
    public static class UndroppableAreaQuery
    {
        /// <summary>Constantes lidas de libil2cpp.so: tolerancia do teste perdoador, margem de GetDroppableY, corte de IsItemTopAboveArea.</summary>
        public const float ForgivingShrink = 0.3f, DroppableYMargin = -0.1f, TopAboveMinDelta = 0.5f;

        /// <summary>IsItemHeightFitAreaNeeds: _minItemsHeight == 0 ou a altura do item e' pelo menos esse valor.</summary>
        public static bool HeightFitsAreaNeeds(UndroppableArea a, DropItem item) => a.MinItemsHeight == 0f || a.MinItemsHeight <= item.Height;

        /// <summary>PerformBasicTests: X sobrepoe a base do item e a altura atende _minItemsHeight.</summary>
        public static bool BasicTests(UndroppableArea a, DropItem item)
        {
            float half = item.BottomWidth * 0.5f;
            bool xOverlap = item.X - half < a.MaxX && item.X + half > a.MinX;
            return xOverlap && HeightFitsAreaNeeds(a, item);
        }

        /// <summary>LevelUtils.IsItemTopAboveArea: topo do item acima do topo da area por mais de 0,5.</summary>
        public static bool IsItemTopAboveArea(float itemTop, float areaTop) =>
            itemTop > areaTop && itemTop - areaTop > TopAboveMinDelta;

        /// <summary>CanAreaAffectItemStrict: testes basicos e raio horizontal pela base do item na altura y.</summary>
        public static bool CanAreaAffectItemStrict(UndroppableArea a, DropItem item, float y) =>
            BasicTests(a, item) && a.TouchesHorizontal(item.X - item.BottomWidth * 0.5f, item.X + item.BottomWidth * 0.5f, y);

        /// <summary>
        /// CanAffectItemOnDrop(item, area, worldXBounds, y). Passos do original: testes basicos; _dontAffectIfItemIsHigher
        /// com o topo do item acima da area -> nao afeta; _dontAllowForgivingTest -> raio horizontal estrito; senao teste
        /// perdoador: base estreita (&lt;= 1) com o centro dentro afeta; do contrario encolhe a base para 30% e exige borda
        /// esquerda, centro e borda direita dentro da area.
        /// </summary>
        public static bool CanAffectItemOnDrop(UndroppableArea a, DropItem item, float y)
        {
            if (!BasicTests(a, item)) return false;
            float half = item.BottomWidth * 0.5f;
            if (a.DontAffectIfItemIsHigher && IsItemTopAboveArea(item.BottomY + item.Height, a.MaxY)) return false;
            if (a.DontAllowForgivingTest) return a.TouchesHorizontal(item.X - half, item.X + half, y);
            if (item.BottomWidth <= 1f && a.Contains(item.X, y)) return true;
            float shrunk = item.BottomWidth * ForgivingShrink * 0.5f;
            return a.Contains(item.X - shrunk, y) && a.Contains(item.X, y) && a.Contains(item.X + shrunk, y);
        }

        /// <summary>
        /// GetDroppableY(fromXBounds) para itens: 11 raios verticais (x = min + i/10 * largura, i = 0..10); fica com o menor
        /// y de cruzamento e recua 0,1. Sem cruzamento (ou cruzamento abaixo da base da caixa): base da caixa - 0,1.
        /// </summary>
        public static float GetDroppableY(UndroppableArea a, float xMin, float xMax)
        {
            float bottom = a.MinY, lowest = float.MaxValue;
            bool hit = false;
            float size = xMax - xMin;
            for (int i = 0; i <= 10; i++)
                if (a.LowestCrossing(xMin + size * i / 10f, out float y) && y < lowest) { lowest = y; hit = true; }
            if (!hit) return bottom + DroppableYMargin;
            float v = lowest + DroppableYMargin;
            return v >= bottom ? v : bottom + DroppableYMargin;
        }

        /// <summary>
        /// Trecho de CanItemFallOnDropArea: area sem entidade aceita sempre; com entidade, e' bloqueada por uma area
        /// nao-dropavel que passa nos testes basicos, e' tao alta quanto o item, vem antes dela em CompareConsumers e
        /// contem o ponto de pouso.
        /// </summary>
        public static bool CanItemFallOn(DropArea dropArea, IList<UndroppableArea> undroppable, DropItem item, float landX, float landY)
        {
            if (dropArea.EntityOrder < 0) return true;
            foreach (var u in undroppable)
            {
                if (!BasicTests(u, item)) continue;
                if (u.Height < item.Height) continue;
                if (DropAreaQuery.CompareConsumers(u, dropArea) != -1) continue;
                if (u.Contains(landX, landY)) return false;
            }
            return true;
        }

        /// <summary>Entre as areas que afetam o item na altura y, a mais baixa (GetDownmostUndroppableArea, aproximado pela base).</summary>
        public static UndroppableArea Downmost(IList<UndroppableArea> undroppable, DropItem item, float y)
        {
            UndroppableArea best = null;
            foreach (var u in undroppable)
                if (CanAffectItemOnDrop(u, item, y) && (best == null || u.MinY < best.MinY)) best = u;
            return best;
        }
    }
}
