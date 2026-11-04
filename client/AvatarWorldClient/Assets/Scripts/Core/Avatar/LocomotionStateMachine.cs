namespace AvatarWorld.Core.Avatar
{
    /// <summary>Estado de locomocao do original (enum MovementType de LevelToddler/LevelAnimal).</summary>
    public enum MovementKind { None = 0, Stand = 1, Walk = 2, Run = 3 }

    /// <summary>Postura do original (PostureType).</summary>
    public enum PostureKind { None = 0, Standing = 1, Sitting = 2 }

    /// <summary>
    /// Histerese de velocidade da locomocao. Valores lidos do asm do original (docs/RECON_CHARACTER_CONTRACT.md, secoes 8 e 9).
    /// A velocidade e sqrt(a^2 + b^2) / t; a unidade (provavelmente unidades/segundo) ainda e inferida.
    /// </summary>
    public sealed class LocomotionConfig
    {
        public float StartWalkSpeed;   // Stand -> Walk quando speed >  este valor
        public float StopSpeed;        // Walk  -> Stand quando speed <  este valor
        public float RunEnterSpeed;    // Walk  -> Run   quando speed >  este valor (e houver animacao de corrida)
        public float RunExitSpeed;     // Run   -> Walk  quando speed <  este valor
        public bool CanEnterRun;       // false: o ramo Walk -> Run nao existe (Toddler)

        /// <summary>LevelToddler.OnMovement (0x233f910): 0.06 / 0.006 / 6.0, sem entrada em Run.</summary>
        public static readonly LocomotionConfig Toddler = new LocomotionConfig
            { StartWalkSpeed = 0.06f, StopSpeed = 0.006f, RunEnterSpeed = float.PositiveInfinity, RunExitSpeed = 6f, CanEnterRun = false };

        /// <summary>LevelAnimal.OnMovement (0x2265194): 0.06 / 0.006 / 18.0 / 6.0; Run exige HasRunningAnimations.</summary>
        public static readonly LocomotionConfig Animal = new LocomotionConfig
            { StartWalkSpeed = 0.06f, StopSpeed = 0.006f, RunEnterSpeed = 18f, RunExitSpeed = 6f, CanEnterRun = true };

        // LevelCharacterAnimator (0x22a1570): histerese NAO extraida ainda; nao ha preset de Character de proposito.
    }

    public static class LocomotionStateMachine
    {
        /// <summary>
        /// Proximo estado de locomocao. Retorna o mesmo estado quando nenhuma condicao do original dispara.
        /// Nao ha salto Stand -> Run nem Run -> Stand: Run so sai para Walk, e Stand so entra em Walk.
        /// </summary>
        public static MovementKind Next(LocomotionConfig c, MovementKind current, float speed, bool hasRunningAnimations)
        {
            switch (current)
            {
                case MovementKind.Stand:
                    return speed > c.StartWalkSpeed ? MovementKind.Walk : MovementKind.Stand;
                case MovementKind.Walk:
                    if (speed < c.StopSpeed) return MovementKind.Stand;
                    if (c.CanEnterRun && hasRunningAnimations && speed > c.RunEnterSpeed) return MovementKind.Run;
                    return MovementKind.Walk;
                case MovementKind.Run:
                    return speed < c.RunExitSpeed ? MovementKind.Walk : MovementKind.Run;
                default:
                    return current;
            }
        }

        /// <summary>
        /// Animacao de deslocamento do Toddler: em pe anda, qualquer outra postura engatinha (csel do original em 0x233fe74).
        /// </summary>
        public static string ToddlerMoveAnimation(PostureKind posture)
        {
            return posture == PostureKind.Standing ? "Movement_Cycles/Walking_Loop" : "Movement_Cycles/Crawling_Loop";
        }

        public const string ToddlerStandAnimation = "General/Stand_Idle";
        public const string AnimalStandAnimation = "General/Standing_Idle";

        /// <summary>Mensagem de erro do original quando Run e pedido sem HasRunningAnimations (LevelAnimal, 0x2265a54).</summary>
        public const string AnimalRunWithoutAnimationsError =
            "Error in LevelAnimal, animal doesn't have Running animations but tries to run";
    }
}
