using System.Collections.Generic;

namespace AvatarWorld.Core.World
{
    /// <summary>
    /// Regras do "modo feriado" lidas do binario original (Game.World.HolidayGameModeButton, 2026-11-23): ao ligar, o botao grava o clima
    /// Halloween (WeatherType 8) nos mundos de uma lista estatica de 4 (World, StarDustCity, Countryside, College), lida no
    /// global-metadata como o array [1, 3, 4, 6] de PWC.Game.LevelWorldType. Vacation e SnowyMountain ficam de fora.
    /// Aqui o modo e uma chave local que sobrepoe o clima salvo nesses mundos; o original tambem liga caçadas de evento e reseta um
    /// pacote da loja, e so mostra o botao quando ha feriado ativo (config remota), nada disso foi reproduzido.
    /// </summary>
    public static class HolidayMode
    {
        /// <summary>WeatherType.Halloween (enum original: Clear 0, Rain 1, Snow 6, Snow_Xmas 7, Halloween 8).</summary>
        public const int HalloweenWeather = 8;

        // PWC.Game.LevelWorldType
        public const int World = 1, Vacation = 2, StarDustCity = 3, Countryside = 4, SnowyMountain = 5, College = 6;

        public static readonly IReadOnlyList<int> Worlds = new[] { World, StarDustCity, Countryside, College };

        public static bool AppliesTo(int worldType)
        {
            foreach (var w in Worlds) if (w == worldType) return true;
            return false;
        }

        /// <summary>Clima efetivo de um mundo: Halloween nos mundos do feriado quando o modo esta ligado; senao o clima salvo.</summary>
        public static int WeatherFor(int worldType, int savedWeather, bool holidayOn) =>
            holidayOn && AppliesTo(worldType) ? HalloweenWeather : savedWeather;
    }
}
