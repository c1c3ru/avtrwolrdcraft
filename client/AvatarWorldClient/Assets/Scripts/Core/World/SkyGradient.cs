using System;

namespace AvatarWorld.Core.World
{
    public struct SkyColor
    {
        public float R, G, B, A;
        public SkyColor(float r, float g, float b, float a = 1f) { R = r; G = g; B = b; A = a; }

        public static SkyColor Lerp(SkyColor a, SkyColor b, float t) =>
            new SkyColor(a.R + (b.R - a.R) * t, a.G + (b.G - a.G) * t, a.B + (b.B - a.B) * t, a.A + (b.A - a.A) * t);
    }

    /// <summary>Config de ceu de um clima (BackgroundSkyConfig): 4 transicoes de horario com 4 cores de topo e 4 de base.</summary>
    public sealed class SkyConfig
    {
        public const int NightToSunrise = 0, SunriseToDay = 1, DayToSunset = 2, SunsetToNight = 3;
        public float Smoothness = 5.5f, Middle = 0.4f;
        public SkyColor[][] Top = new SkyColor[4][];
        public SkyColor[][] Bottom = new SkyColor[4][];
    }

    /// <summary>
    /// Gradiente do ceu do mapa (PWC.BackgroundSky do original). As CORES e os parametros smoothness/middle sao os
    /// exportados. APROXIMADO: os horarios das transicoes (o original segue o TimeOfDayManager) e a curva do gradiente
    /// (o shader nao foi recuperado; usa-se uma logistica de inclinacao smoothness centrada em middle).
    /// </summary>
    public static class SkyGradient
    {
        // Linha do tempo (hora local): [inicio, fim) de cada transicao; fora delas o ceu fica na cor final da anterior.
        static readonly (float from, float to, int phase)[] Timeline =
        {
            (5f, 7f, SkyConfig.NightToSunrise), (7f, 10f, SkyConfig.SunriseToDay),
            (16f, 18f, SkyConfig.DayToSunset), (18f, 20f, SkyConfig.SunsetToNight),
        };

        /// <summary>Cores de topo e base na hora dada (0-24, fracionaria).</summary>
        public static void ColorsAt(SkyConfig config, float hour, out SkyColor top, out SkyColor bottom)
        {
            if (config == null) throw new ArgumentNullException(nameof(config));
            hour = ((hour % 24f) + 24f) % 24f;
            foreach (var (from, to, phase) in Timeline)
            {
                if (hour < from || hour >= to) continue;
                float t = (hour - from) / (to - from);
                top = Sample(config.Top[phase], t);
                bottom = Sample(config.Bottom[phase], t);
                return;
            }
            // Entre transicoes: dia (10-16) e noite (20-5) seguram a cor final da ultima transicao.
            int hold = hour >= 10f && hour < 16f ? SkyConfig.SunriseToDay
                     : hour >= 16f ? SkyConfig.SunsetToNight : SkyConfig.SunsetToNight;
            top = config.Top[hold][config.Top[hold].Length - 1];
            bottom = config.Bottom[hold][config.Bottom[hold].Length - 1];
        }

        /// <summary>Interpola t (0..1) pelos quadros-chave igualmente espacados.</summary>
        static SkyColor Sample(SkyColor[] keys, float t)
        {
            if (keys.Length == 1) return keys[0];
            float x = Math.Min(Math.Max(t, 0f), 1f) * (keys.Length - 1);
            int i = Math.Min((int)x, keys.Length - 2);
            return SkyColor.Lerp(keys[i], keys[i + 1], x - i);
        }

        /// <summary>Peso do topo na altura t (0 = base, 1 = topo): logistica normalizada para ir exatamente de 0 a 1.</summary>
        public static float Blend(float t, float smoothness, float middle)
        {
            float w = Logistic(t, smoothness, middle), w0 = Logistic(0f, smoothness, middle), w1 = Logistic(1f, smoothness, middle);
            return Math.Min(Math.Max((w - w0) / (w1 - w0), 0f), 1f);
        }

        static float Logistic(float t, float smoothness, float middle) => 1f / (1f + (float)Math.Exp(-smoothness * (t - middle)));

        public static SkyColor Mix(SkyColor top, SkyColor bottom, float t, float smoothness, float middle) =>
            SkyColor.Lerp(bottom, top, Blend(t, smoothness, middle));
    }
}
