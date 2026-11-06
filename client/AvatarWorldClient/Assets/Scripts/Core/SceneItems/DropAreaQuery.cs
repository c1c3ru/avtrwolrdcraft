using System.Collections.Generic;

namespace AvatarWorld.Core.SceneItems
{
    /// <summary>O que a consulta precisa saber do item solto (LevelItem): base, largura da base e altura.</summary>
    public struct DropItem
    {
        public float X;          // centro X da base (GetBottomXWorldBounds)
        public float BottomY;    // y da base do item
        public float BottomWidth;// largura da base: _bottomWidth do item, ou a dos sprites
        public float Height;     // altura do item (bounds incluindo filhos)
    }

    /// <summary>
    /// Area de soltar (LevelDropArea e subclasses): poligono do PolygonCollider2D em espaco do mundo.
    /// Campos de LevelDropArea: _sortPriority, _maxItemsHeight, _maxItemsWidth.
    /// </summary>
    /// <summary>ILevelConsumer: o que CompareConsumers lê (GetSortPriority e GetEntity).</summary>
    public interface IConsumer
    {
        int Priority { get; }
        int EntityOrder { get; }
    }

    public sealed class DropArea : IConsumer
    {
        int IConsumer.Priority => Priority;
        int IConsumer.EntityOrder => EntityOrder;
        public float[] Poly;
        public int Priority;
        public string Name;
        public string Kind = "LevelDropArea";
        public float MaxItemsHeight, MaxItemsWidth;
        /// <summary>Ordem de desenho do LevelItem dono da area (ILevelConsumer.GetEntity); -1 = area do cenario, sem entidade.</summary>
        public int EntityOrder = -1;

        public float MinX, MaxX, MinY, MaxY;

        // Subclasses que aceitam um item generico. As demais (so personagens, so comida, matar, agua, cruzar nivel,
        // containers...) tem CanConsumeItem proprio, nao reproduzido: ficam de fora.
        static readonly HashSet<string> Generic = new HashSet<string>
        {
            "LevelDropArea", "LevelFloorArea", "LevelObjectFloorArea", "Level1DDropArea", "LevelAllowOverlap1DDropArea",
            "LevelFreeFormDropArea", "LevelFreePositionDropArea", "LevelDropAllowOverlappingItemsArea",
            "LevelSingleItemDropArea", "LevelSingleCenteredItemDropArea"
        };

        public DropArea(float[] poly, int priority, string name = "", string kind = "LevelDropArea",
                        float maxItemsHeight = 0f, float maxItemsWidth = 0f)
        {
            Poly = poly; Priority = priority; Name = name; Kind = kind;
            MaxItemsHeight = maxItemsHeight; MaxItemsWidth = maxItemsWidth;
            MinX = MinY = float.MaxValue; MaxX = MaxY = float.MinValue;
            for (int i = 0; i + 1 < poly.Length; i += 2)
            {
                if (poly[i] < MinX) MinX = poly[i];
                if (poly[i] > MaxX) MaxX = poly[i];
                if (poly[i + 1] < MinY) MinY = poly[i + 1];
                if (poly[i + 1] > MaxY) MaxY = poly[i + 1];
            }
        }

        public bool IsFloor => Kind == "LevelFloorArea" || Kind == "LevelObjectFloorArea";
        public bool AcceptsGenericItems => Generic.Contains(Kind);
        public float BoundsArea => (MaxX - MinX) * (MaxY - MinY);

        /// <summary>Ponto dentro do poligono (regra par-impar).</summary>
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

        /// <summary>Maior y em que a vertical x cruza o poligono; false se nao cruza.</summary>
        public bool TopAt(float x, out float top)
        {
            top = float.MinValue;
            bool hit = false;
            int n = Poly.Length / 2;
            for (int i = 0, j = n - 1; i < n; j = i++)
            {
                float xi = Poly[2 * i], yi = Poly[2 * i + 1], xj = Poly[2 * j], yj = Poly[2 * j + 1];
                if ((xi > x) == (xj > x)) continue;
                float y = yi + (x - xi) * (yj - yi) / (xj - xi);
                if (y > top) top = y;
                hit = true;
            }
            return hit;
        }

        /// <summary>
        /// Raio para baixo a partir de (x,y), como CShapeModel.Raycast em LevelDropAreaQuery.GetDropAreaToFallOn/TryGetPointToFallOn
        /// (alvo = origem + Vector2.down * 1000). Comecando fora, acerta a primeira aresta abaixo; comecando dentro so acerta
        /// (na propria origem) quando considerStartInside, que o original liga para LevelFloorArea.
        /// </summary>
        public bool RayDown(float x, float y, bool considerStartInside, out float hitY)
        {
            hitY = y;
            if (Contains(x, y)) return considerStartInside;
            float best = float.MinValue;
            bool hit = false;
            int n = Poly.Length / 2;
            for (int i = 0, j = n - 1; i < n; j = i++)
            {
                float xi = Poly[2 * i], yi = Poly[2 * i + 1], xj = Poly[2 * j], yj = Poly[2 * j + 1];
                if ((xi > x) == (xj > x)) continue;
                float cy = yi + (x - xi) * (yj - yi) / (xj - xi);
                if (cy <= y && y - cy <= 1000f && cy > best) { best = cy; hit = true; }
            }
            if (hit) hitY = best;
            return hit;
        }
    }

    /// <summary>
    /// Consulta de areas de soltar, recuperada do ARM64 (LevelDropAreaQuery 0x2354750..0x2355554, LevelItem.DropInLevel):
    /// - PerformBasicTests: Bounds1D.Intersects(X da area, X da base do item); CanConsumeItem; altura e largura cabem.
    /// - Altura (CanItemHeightFitInsideDropArea): _maxItemsHeight == 0 ou _maxItemsHeight &gt;= altura do item.
    /// - Largura (CanItemWidthFitInsideDropArea): largura da area (_maxItemsWidth, senao a largura X) &gt;= largura da base.
    /// - Sob o ponteiro (IsDroppableUnderItem): ponto dentro do poligono; a ordem vem de SortDropAreas (aqui: prioridade).
    /// - Queda (GetDropAreaToFallOn): entre as areas que passam, a de MENOR distancia vertical do raio para baixo
    ///   (position.y - hit.y &lt; melhor); nao usa prioridade.
    /// Areas nao-dropaveis: ver UndroppableAreaQuery. Nao reproduzido: bloqueio por entidade (IsEntityBlockingDropArea),
    /// orientacao do item, CanConsumeItem das subclasses.
    /// </summary>
    public static class DropAreaQuery
    {
        public static bool XOverlaps(DropArea a, DropItem item)
        {
            float half = item.BottomWidth * 0.5f;
            return item.X - half < a.MaxX && item.X + half > a.MinX;
        }

        public static bool HeightFits(DropArea a, DropItem item) => a.MaxItemsHeight == 0f || a.MaxItemsHeight >= item.Height;

        public static bool WidthFits(DropArea a, DropItem item)
        {
            float areaWidth = a.MaxItemsWidth != 0f ? a.MaxItemsWidth : a.MaxX - a.MinX;
            return areaWidth >= item.BottomWidth;
        }

        public static bool BasicTests(DropArea a, DropItem item) =>
            a.AcceptsGenericItems && XOverlaps(a, item) && HeightFits(a, item) && WidthFits(a, item);

        /// <summary>
        /// LevelConsumers.CompareConsumers (0x22c3fd4), o comparador de LevelDropArea.SortDropAreas: sem entidade nos dois,
        /// maior _sortPriority primeiro; so um com entidade, ele primeiro; os dois com entidade, maior ordem de desenho
        /// (SortingElement.GetSortingOrderForY) primeiro e, empatando, maior prioridade.
        /// </summary>
        public static int CompareConsumers(IConsumer a, IConsumer b)
        {
            bool ea = a.EntityOrder >= 0, eb = b.EntityOrder >= 0;
            if (!ea && !eb) return b.Priority.CompareTo(a.Priority);
            if (ea && !eb) return -1;
            if (!ea && eb) return 1;
            return a.EntityOrder == b.EntityOrder ? b.Priority.CompareTo(a.Priority) : b.EntityOrder.CompareTo(a.EntityOrder);
        }

        /// <summary>Ordena como SortDropAreas (Sort do original e instavel; aqui o desempate e a ordem de entrada).</summary>
        public static List<DropArea> Sorted(IList<DropArea> areas)
        {
            var indexed = new List<KeyValuePair<int, DropArea>>();
            for (int i = 0; i < areas.Count; i++) indexed.Add(new KeyValuePair<int, DropArea>(i, areas[i]));
            indexed.Sort((x, y) =>
            {
                int c = CompareConsumers(x.Value, y.Value);
                return c != 0 ? c : x.Key.CompareTo(y.Key);
            });
            var result = new List<DropArea>(indexed.Count);
            foreach (var kv in indexed) result.Add(kv.Value);
            return result;
        }

        /// <summary>
        /// Area sob (x,y) (LevelItem.GetMostRelevantDropAreaUnderPosition): percorre a lista ordenada e devolve a PRIMEIRA
        /// que passa em IsDroppableUnderItem (testes basicos e ponto dentro do poligono).
        /// </summary>
        public static DropArea Under(IList<DropArea> areas, DropItem item, float x, float y)
        {
            foreach (var a in Sorted(areas))
                if (BasicTests(a, item) && a.Contains(x, y)) return a;
            return null;
        }

        /// <summary>Area onde o item cai a partir de (x,y) (GetDropAreaToFallOn); hitY = y da superficie.</summary>
        public static DropArea FallOn(IList<DropArea> areas, DropItem item, float x, float y, out float hitY)
            => FallOn(areas, null, item, x, y, out hitY);

        /// <summary>
        /// Como FallOn, e CanItemFallOnDropArea (0x2354b5c): uma area com entidade nao recebe o item se o ponto de pouso
        /// esta dentro de uma area nao-dropavel que passa nos testes basicos, e' pelo menos tao alta quanto o item e
        /// vem antes da area em CompareConsumers.
        /// </summary>
        public static DropArea FallOn(IList<DropArea> areas, IList<UndroppableArea> undroppable, DropItem item, float x, float y, out float hitY)
        {
            DropArea best = null;
            float bestDist = float.MaxValue;
            hitY = y;
            foreach (var a in Sorted(areas))
            {
                if (!BasicTests(a, item)) continue;
                if (!a.RayDown(x, y, a.IsFloor, out float hy)) continue;
                float dist = y - hy;
                if (dist >= bestDist) continue;
                if (undroppable != null && !UndroppableAreaQuery.CanItemFallOn(a, undroppable, item, x, hy)) continue;
                bestDist = dist; best = a; hitY = hy;
            }
            return best;
        }
    }
}
