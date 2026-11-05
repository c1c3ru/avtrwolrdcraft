using System.Collections.Generic;

namespace AvatarWorld.Core.World
{
    /// <summary>
    /// Quais predios do mapa tem interior exportado (Resources/Interiors/&lt;chave&gt;). A chave de entrada e o
    /// PWC.Game.LevelType padrao do predio (world.json, defaultLevel); a cadeia ate a cena do original esta em
    /// docs/PRD_WORLD_INTERIORS_2026-11-05.md (tools/recon_building_scenes.py).
    /// </summary>
    public static class InteriorCatalog
    {
        static readonly Dictionary<int, string> Keys = new Dictionary<int, string>
        {
            { 218, "dentist" }, // ZV_Dentist_T1 -> DentistOffice_L208 -> level206
        };

        public static bool TryGetKey(int defaultLevel, out string key) => Keys.TryGetValue(defaultLevel, out key);

        public static IReadOnlyCollection<string> AllKeys => Keys.Values;
    }
}
