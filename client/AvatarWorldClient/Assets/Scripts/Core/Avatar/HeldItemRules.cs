namespace AvatarWorld.Core.Avatar
{
    public enum HandKind { None = 0, Left = 1, Right = 2 }   // AvatarHandType do original

    /// <summary>
    /// LevelCharacterAnimator.UpdateMovementOverrideHandler (0x22a5c10): o handler de override de movimento
    /// (LevelCharacterMovementOverrideHandler) vem do item na mao esquerda (1); se nao houver, da direita (2).
    /// </summary>
    public static class HeldItemRules
    {
        /// <summary>Primeiro nao nulo, esquerda antes de direita. O chamador resolve "nulo" (no Unity, Object destruido conta como nulo).</summary>
        public static T PickMovementOverride<T>(T leftHandItem, T rightHandItem) where T : class
        {
            return leftHandItem != null ? leftHandItem : rightHandItem;
        }

        /// <summary>Ordem de consulta das maos.</summary>
        public static readonly HandKind[] LookupOrder = { HandKind.Left, HandKind.Right };
    }
}
