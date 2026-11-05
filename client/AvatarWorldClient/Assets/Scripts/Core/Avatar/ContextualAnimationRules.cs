using System;

namespace AvatarWorld.Core.Avatar
{
    /// <summary>CAPlayType do original (PWC.Level.ContextualAnimation.CAPlayType).</summary>
    public enum CAPlayType
    {
        None = 0,
        PlayingNormalAnimation = 1,
        PlayingAlternateIdle = 2,
        PlayingPreAnimation = 3
    }

    public enum CAStartCheck { Ok = 0, TargetNull = 1, ConfigNameEmpty = 2 }

    /// <summary>
    /// Regras provadas do sistema de animacoes contextuais (docs/RECON_CHARACTER_CONTRACT.md, secao 15):
    /// validacao de CATargetExtensionMethods.PlayContextualAnimation (0x23ab96c) e a variante sentada de
    /// LevelCharacter.ICATarget.SetAnimation (0x22a3c00).
    /// </summary>
    public static class ContextualAnimationRules
    {
        public const string SittingSuffix = "__Sitting";
        public const string TargetNullMessage = "target is null!";
        public const string ConfigNameEmptyMessage = " animationConfig.name is null or empty!";

        /// <summary>Ordem do original: primeiro o alvo (null ou IsAlive falso), depois o nome da config.</summary>
        public static CAStartCheck ValidateStart(bool targetAlive, string configName)
        {
            if (!targetAlive) return CAStartCheck.TargetNull;
            if (string.IsNullOrEmpty(configName)) return CAStartCheck.ConfigNameEmpty;
            return CAStartCheck.Ok;
        }

        /// <summary>
        /// Character sentado numa LevelSitArea usa a variante "nome__Sitting". Quando o esqueleto nao tem a variante,
        /// mantem o nome base (fallback inferido: no Avatar_Spine so 11 animacoes tem variante, todas com base presente).
        /// </summary>
        public static string CharacterAnimationName(string name, bool onSitArea, Func<string, bool> skeletonHasAnimation)
        {
            if (!onSitArea || string.IsNullOrEmpty(name)) return name;
            string variant = name + SittingSuffix;
            return skeletonHasAnimation != null && skeletonHasAnimation(variant) ? variant : name;
        }

        /// <summary>
        /// SpineType do catalogo (PremadeCharactersJson/AvatarSpineDatas): 1 Character, 2 Baby, 3 Cat, 4 Dog, 13 Toddler, 14 Horse.
        /// Outros valores aparecem em configs de CA (5, 8, 11, 15, 16) mas seus esqueletos nao foram extraidos.
        /// </summary>
        public enum SpineKind { Character = 1, Baby = 2, Cat = 3, Dog = 4, Toddler = 13, Horse = 14 }

        /// <summary>
        /// SpineTypeExtensionMethods.HasCAPrefixForCAAnimations. Valores conhecidos vem de 2.876 configs que casaram com
        /// animacoes reais: Character, Baby e Toddler usam "CA/"; Cat, Dog e Horse nao. Tipos nao extraidos devolvem null.
        /// </summary>
        public static bool? HasCAPrefix(int spineType)
        {
            switch (spineType)
            {
                case (int)SpineKind.Character:
                case (int)SpineKind.Baby:
                case (int)SpineKind.Toddler: return true;
                case (int)SpineKind.Cat:
                case (int)SpineKind.Dog:
                case (int)SpineKind.Horse: return false;
                default: return null;
            }
        }

        /// <summary>
        /// LevelCAConfig.CreateAnimationName (0x212fe74): nome inteiro quando isNameFullAnimationName; senao
        /// [prefixo "CA/"] + pasta + "/" + nome, com a pasta vinda de folderNameOverride ou do FolderName do handler.
        /// </summary>
        public static string CreateAnimationName(bool isNameFullAnimationName, string name, string folderNameOverride,
                                                 string handlerFolderName, bool hasCAPrefix)
        {
            if (isNameFullAnimationName) return name;
            string folder = string.IsNullOrEmpty(folderNameOverride) ? handlerFolderName : folderNameOverride;
            return (hasCAPrefix ? "CA/" : "") + folder + "/" + name;
        }

        /// <summary>LevelCharacter.ICATarget.ShouldIncludeInEnsureCheck (0x22a3a18) devolve sempre verdadeiro.</summary>
        public static bool CharacterShouldIncludeInEnsureCheck() { return true; }
    }
}
