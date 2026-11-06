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
        /// <summary>Animacoes da cena (nuvens e trem): pontos e tempos exportados; o movimento e do cliente.</summary>
        public WorldAnimationData animations = new WorldAnimationData();

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
        /// <summary>Id do WorldCloud dono do sprite (0 = nao e nuvem). cloudRain: variante de chuva da nuvem.</summary>
        public int cloud;
        public bool cloudRain;
        /// <summary>Id do WorldTrain dono do sprite (0 = nao e trem).</summary>
        public int train;

        public bool VisibleIn(int weather)
        {
            // A nuvem tem duas artes: a de ceu limpo some na chuva e a de chuva so aparece nela.
            if (cloud != 0 && cloudRain != (weather == WorldWeather.Rain)) return false;
            if (weathers == null || weathers.Length == 0) return true;
            foreach (var w in weathers) if (w == weather) return true;
            return false;
        }
    }

    [Serializable]
    public sealed class WorldAnimationData
    {
        public WorldCloudAnimData clouds = new WorldCloudAnimData();
        public List<WorldTrainAnimData> trains = new List<WorldTrainAnimData>();
        public List<WorldSpineData> spines = new List<WorldSpineData>();
    }

    /// <summary>Esqueleto Spine da cena (Resources/MapSpine/&lt;skeleton&gt;/). followCamera: filho da WorldCamera no original.</summary>
    [Serializable]
    public sealed class WorldSpineData
    {
        public string skeleton, animation;
        public float x, y, sx = 1f, sy = 1f, offsetX, offsetY;
        public int rank;
        public bool loop = true, followCamera;
    }

    [Serializable]
    public sealed class WorldCloudAnimData
    {
        public float startX, endX, minY, maxY;
        public bool Exists => !Mathf.Approximately(startX, endX);
    }

    [Serializable]
    public sealed class WorldTrainAnimData
    {
        public int id;
        public float startX, startY, goX, goY, toGoSeconds, toStartSeconds;
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
