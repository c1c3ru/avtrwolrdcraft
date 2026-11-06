using System.Collections.Generic;

namespace AvatarWorld.Core.SceneItems
{
    /// <summary>Area de soltar: poligono (x,y,x,y,...) em espaco do mundo do PolygonCollider2D de um LevelDropArea.</summary>
    public sealed class DropArea
    {
        public float[] Poly;
        public int Priority;
        public string Name;

        public float MinX, MaxX, MinY, MaxY;

        public DropArea(float[] poly, int priority, string name = "")
        {
            Poly = poly; Priority = priority; Name = name;
            MinX = MinY = float.MaxValue; MaxX = MaxY = float.MinValue;
            for (int i = 0; i + 1 < poly.Length; i += 2)
            {
                if (poly[i] < MinX) MinX = poly[i];
                if (poly[i] > MaxX) MaxX = poly[i];
                if (poly[i + 1] < MinY) MinY = poly[i + 1];
                if (poly[i + 1] > MaxY) MaxY = poly[i + 1];
            }
        }

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

        /// <summary>Maior y em que a vertical x cruza o poligono (a superficie onde o item apoia); false se nao cruza.</summary>
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
    }

    /// <summary>
    /// Escolha da area de soltar sob o ponto de apoio de um item. O original usa LevelDropAreaQuery
    /// (nao recuperado); aqui: maior _sortPriority entre as areas que contem o ponto, empate pela menor caixa.
    /// </summary>
    public static class DropAreaQuery
    {
        public static DropArea Best(IList<DropArea> areas, float x, float y)
        {
            DropArea best = null;
            foreach (var a in areas)
            {
                if (!a.Contains(x, y)) continue;
                if (best == null || a.Priority > best.Priority ||
                    (a.Priority == best.Priority && a.BoundsArea < best.BoundsArea)) best = a;
            }
            return best;
        }
    }
}
