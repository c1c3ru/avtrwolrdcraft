using System;
using AvatarWorld.Core.World;

namespace AvatarWorld.Runtime
{
    /// <summary>Formato de Resources/WorldSlice/sky.json (tools/export_sky.py).</summary>
    [Serializable]
    public sealed class SkyFile
    {
        public SkyConfigData[] configs;

        /// <summary>Config do clima (WorldWeather.*) ou null.</summary>
        public SkyConfig For(int weather)
        {
            if (configs == null) return null;
            foreach (var c in configs) if (c.weather == weather) return c.ToCore();
            return null;
        }
    }

    [Serializable]
    public sealed class SkyConfigData
    {
        public int weather;
        public string name;
        public float smoothness, middle;
        public SkyPhaseData[] phases;

        public SkyConfig ToCore()
        {
            var config = new SkyConfig { Smoothness = smoothness, Middle = middle };
            for (int i = 0; i < 4 && phases != null && i < phases.Length; i++)
            {
                config.Top[i] = Convert(phases[i].top);
                config.Bottom[i] = Convert(phases[i].bottom);
            }
            return config;
        }

        static SkyColor[] Convert(SkyColorData[] colors)
        {
            var result = new SkyColor[colors.Length];
            for (int i = 0; i < colors.Length; i++) result[i] = new SkyColor(colors[i].r, colors[i].g, colors[i].b, colors[i].a);
            return result;
        }
    }

    [Serializable]
    public sealed class SkyPhaseData
    {
        public string name;
        public SkyColorData[] top, bottom;
    }

    [Serializable]
    public sealed class SkyColorData { public float r, g, b, a; }
}
