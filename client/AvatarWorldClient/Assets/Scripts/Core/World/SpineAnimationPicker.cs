using System;
using System.Collections.Generic;

namespace AvatarWorld.Core.World
{
    /// <summary>
    /// Escolhe a animacao Spine de uma camada do mapa. O original configura a animacao em tempo de execucao
    /// (Sun_Moon troca por hora do dia via LitSpineByTimeOfDay); aqui: a animacao serializada se existir, senao, para o
    /// Sun_Moon, a da fase do dia pelo nome (sunrise/day/sunset/moon-night), senao a primeira. Heuristica declarada.
    /// </summary>
    public static class SpineAnimationPicker
    {
        public static string Pick(IReadOnlyList<string> names, string skeleton, string preferred, int hour)
        {
            if (names == null || names.Count == 0) return null;
            if (!string.IsNullOrEmpty(preferred))
                foreach (var n in names) if (n == preferred) return n;
            if (string.Equals(skeleton, "Sun_Moon", StringComparison.OrdinalIgnoreCase))
            {
                string[] keys = PhaseKeywords(hour);
                foreach (var key in keys)
                    foreach (var n in names)
                        if (n != null && n.IndexOf(key, StringComparison.OrdinalIgnoreCase) >= 0) return n;
            }
            return names[0];
        }

        static string[] PhaseKeywords(int hour)
        {
            if (hour >= 5 && hour < 7) return new[] { "sunrise", "day" };
            if (hour >= 7 && hour < 17) return new[] { "day", "sun" };
            if (hour >= 17 && hour < 19) return new[] { "sunset", "day" };
            return new[] { "moon", "night" };
        }
    }
}
