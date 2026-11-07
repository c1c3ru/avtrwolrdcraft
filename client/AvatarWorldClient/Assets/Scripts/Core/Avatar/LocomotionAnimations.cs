namespace AvatarWorld.Core.Avatar
{
    public enum LocomotionFamily { Character = 0, Toddler = 1, Animal = 2 }

    /// <summary>
    /// Nome de animacao por familia e estado, validado contra os esqueletos Spine (tools/recon_skel_check.py,
    /// docs/RECON_CHARACTER_CONTRACT.md secoes 6 a 8). Baby nao locomove (so General/Idle) e nao entra aqui.
    /// </summary>
    public static class LocomotionAnimations
    {
        public static LocomotionConfig ConfigFor(LocomotionFamily family)
        {
            switch (family)
            {
                case LocomotionFamily.Toddler: return LocomotionConfig.Toddler;
                case LocomotionFamily.Animal: return LocomotionConfig.Animal;
                default: return LocomotionConfig.Character;
            }
        }

        public static string NameFor(LocomotionFamily family, MovementKind movement, PostureKind posture)
        {
            switch (family)
            {
                case LocomotionFamily.Toddler:
                    return movement == MovementKind.Walk || movement == MovementKind.Run
                        ? LocomotionStateMachine.ToddlerMoveAnimation(posture)
                        : LocomotionStateMachine.ToddlerStandAnimation;
                case LocomotionFamily.Animal:
                    if (movement == MovementKind.Run) return "General/Running";
                    if (movement == MovementKind.Walk) return "General/Walking";
                    return LocomotionStateMachine.AnimalStandAnimation;
                default:
                    // Character nunca entra em Run (provado); se chegar, usa o ciclo de andar.
                    if (movement == MovementKind.Walk || movement == MovementKind.Run) return "Movement_Cycles/Walk";
                    return "Idle_Stand_1";
            }
        }
    }
}
