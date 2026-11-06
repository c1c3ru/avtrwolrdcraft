namespace AvatarWorld.Core.Avatar
{
    /// <summary>Tipo de avatar humano (SpineType do original): Character=adulto, Toddler=crianca, Baby=bebe.</summary>
    public enum AvatarKind
    {
        Adult = 0,
        Toddler = 1,
        Baby = 2,
    }

    public static class AvatarKinds
    {
        public static readonly AvatarKind[] All = { AvatarKind.Adult, AvatarKind.Toddler, AvatarKind.Baby };

        public static bool IsDefined(AvatarKind kind) => kind == AvatarKind.Adult || kind == AvatarKind.Toddler || kind == AvatarKind.Baby;

        public static string DisplayName(AvatarKind kind) =>
            kind == AvatarKind.Toddler ? "Criança" : kind == AvatarKind.Baby ? "Bebê" : "Adulto";

        /// <summary>Pasta em Resources/AvatarSpine com atlas, esqueleto e manifesto proprios (adulto usa a raiz).</summary>
        public static string ResourceFolder(AvatarKind kind) =>
            kind == AvatarKind.Toddler ? "AvatarSpine/Kinds/Toddler" : kind == AvatarKind.Baby ? "AvatarSpine/Kinds/Baby" : null;

        /// <summary>Animacao de repouso de cada esqueleto.</summary>
        public static string IdleAnimation(AvatarKind kind) =>
            kind == AvatarKind.Toddler ? "General/Stand_Idle" : kind == AvatarKind.Baby ? "General/Idle" : "Idle_Stand_1";
    }
}
