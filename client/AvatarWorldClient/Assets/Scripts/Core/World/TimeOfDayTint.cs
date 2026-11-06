namespace AvatarWorld.Core.World
{
    /// <summary>
    /// Tonalidade de um sprite por hora do dia (ColorByTimeOfDay do original: DayColor / SunsetColor / NightColor).
    /// As CORES sao as exportadas; os HORARIOS das transicoes sao aproximados e iguais aos do ceu (SkyGradient):
    /// nascer 05-07 (noite -> dia), dia 07-16, entardecer 16-18 (dia -> por do sol), anoitecer 18-20 (por do sol -> noite).
    /// </summary>
    public static class TimeOfDayTint
    {
        public static SkyColor At(float hour, SkyColor day, SkyColor sunset, SkyColor night)
        {
            hour = ((hour % 24f) + 24f) % 24f;
            if (hour >= 5f && hour < 7f) return SkyColor.Lerp(night, day, (hour - 5f) / 2f);
            if (hour >= 7f && hour < 16f) return day;
            if (hour >= 16f && hour < 18f) return SkyColor.Lerp(day, sunset, (hour - 16f) / 2f);
            if (hour >= 18f && hour < 20f) return SkyColor.Lerp(sunset, night, (hour - 18f) / 2f);
            return night;
        }
    }
}
