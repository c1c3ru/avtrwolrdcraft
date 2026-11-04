using System;
using System.Collections.Generic;
using UnityEngine;

namespace AvatarWorld.Runtime
{
    // Formato gerado por tools/export_world_map.py (level4 do original). Nomes batem com o JSON (JsonUtility).

    [Serializable]
    public sealed class WorldMapData
    {
        public WorldCameraData camera;
        public List<WorldRendererData> renderers = new List<WorldRendererData>();
        public List<WorldBuildingData> buildings = new List<WorldBuildingData>();

        /// <summary>Menor prédio cuja caixa contém o ponto (prédios menores ficam sobre os grandes).</summary>
        public WorldBuildingData HitTest(Vector2 point)
        {
            WorldBuildingData best = null;
            float bestArea = float.MaxValue;
            foreach (var b in buildings)
            {
                if (point.x < b.x0 || point.x > b.x1 || point.y < b.y0 || point.y > b.y1) continue;
                float area = (b.x1 - b.x0) * (b.y1 - b.y0);
                if (area < bestArea) { best = b; bestArea = area; }
            }
            return best;
        }
    }

    [Serializable]
    public sealed class WorldCameraData
    {
        public float orthoSize = 5.12f;
        public float startX, startY, minX, maxX;
    }

    [Serializable]
    public sealed class WorldRendererData
    {
        public string sprite, go;
        public float x, y, z, sx = 1f, sy = 1f, rot, pivotX = 0.5f, pivotY = 0.5f, ppu = 100f;
        public int rank;
        public float[] color = { 1f, 1f, 1f, 1f };
        public bool flipX, flipY;
        /// <summary>WeatherType em que o sprite aparece (LevelSpriteRendererVisibleByWeather); vazio = sempre.</summary>
        public int[] weathers;

        public bool VisibleIn(int weather)
        {
            if (weathers == null || weathers.Length == 0) return true;
            foreach (var w in weathers) if (w == weather) return true;
            return false;
        }
    }

    /// <summary>Valores de WeatherType do original usados no mapa (Halloween=8 e Snow_Xmas=7 nao entram).</summary>
    public static class WorldWeather
    {
        public const int Clear = 0, Rain = 1, Snow = 6;
        public const string PrefsKey = "PazuWorld_WeatherType"; // mesma chave do original

        public static bool IsSupported(int weather) => weather == Clear || weather == Rain || weather == Snow;
    }

    [Serializable]
    public sealed class WorldBuildingData
    {
        public string name;
        public float x0, y0, x1, y1;
        /// <summary>Valor de PWC.Game.LevelType (0 = prédio sem cena: em obras/não distribuído).</summary>
        public int defaultLevel;
        public int buildingType;

        /// <summary>LevelType.MiniBasketball_L1: a quadra de basquete do mapa original.</summary>
        public const int MiniBasketballLevel = 13;
        public bool IsBasketball => defaultLevel == MiniBasketballLevel;
    }
}
