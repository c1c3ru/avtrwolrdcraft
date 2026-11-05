namespace AvatarWorld.Core.Avatar
{
    /// <summary>Tipo da area de descanso do personagem (LevelCharacter.CurrentRestArea): LevelSitArea, LevelSleepArea ou outra/nenhuma.</summary>
    public enum RestAreaKind { None = 0, Sit = 1, Sleep = 2, Other = 3 }

    public enum ProperIdleChoice
    {
        LockedCAHandlerIdle = 0,   // LockedCAHandler != null: toca o idle que o proprio handler informa (virtual), em loop
        OverrideHandled = 1,       // OverridePlayProperIdleAnimationAction devolveu true: nada a tocar
        SitIdle = 2,
        SleepIdle = 3,
        StandIdle = 4
    }

    /// <summary>
    /// Escolha do idle em LevelCharacterAnimator.PlayProperIdleAnimation (0x22a3a40), lida do disassembly
    /// (docs/RECON_CHARACTER_CONTRACT.md, secao 13). A ordem de prioridade e a do original.
    /// </summary>
    public static class ProperIdleSelector
    {
        public const string SitIdleAnimation = "CA/Chair_Sitting/Sit_On_Chair_Idle";
        public const string SleepIdleAnimation = "CA/Bed_Laying/Laying_Idle";
        public const string StandIdleAnimation = "Idle_Stand_1";

        public static ProperIdleChoice Choose(bool hasLockedCAHandler, bool overrideHandled, RestAreaKind restArea)
        {
            if (hasLockedCAHandler) return ProperIdleChoice.LockedCAHandlerIdle;
            if (overrideHandled) return ProperIdleChoice.OverrideHandled;
            if (restArea == RestAreaKind.Sit) return ProperIdleChoice.SitIdle;
            if (restArea == RestAreaKind.Sleep) return ProperIdleChoice.SleepIdle;
            return ProperIdleChoice.StandIdle;
        }

        /// <summary>Nome da animacao quando a escolha e fixa; nulo para LockedCAHandlerIdle (vem do handler) e OverrideHandled (nada).</summary>
        public static string AnimationFor(ProperIdleChoice choice)
        {
            switch (choice)
            {
                case ProperIdleChoice.SitIdle: return SitIdleAnimation;
                case ProperIdleChoice.SleepIdle: return SleepIdleAnimation;
                case ProperIdleChoice.StandIdle: return StandIdleAnimation;
                default: return null;
            }
        }
    }
}
