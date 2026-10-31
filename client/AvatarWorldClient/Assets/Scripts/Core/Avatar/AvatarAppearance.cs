using System;

namespace AvatarWorld.Core.Avatar
{
    /// <summary>
    /// Selecao atual de aparencia do avatar, gravada dentro de PlayerState (Ciclo 3). Campos publicos
    /// simples com valor padrao no proprio inicializador para sobreviver a JsonUtility: um save antigo
    /// sem o campo "Appearance" (ou com campos individuais ausentes) mantem os defaults abaixo em vez
    /// de ficar nulo - JsonUtility.FromJson sobrescreve so os campos presentes no JSON.
    /// </summary>
    [Serializable]
    public sealed class AvatarAppearance
    {
        public string HairId = AvatarCatalog.DefaultOption(AvatarCatalog.CategoryHair);
        public string ShirtId = AvatarCatalog.DefaultOption(AvatarCatalog.CategoryShirt);
        public string BottomId = AvatarCatalog.DefaultOption(AvatarCatalog.CategoryBottom);
        public string ShoesId = AvatarCatalog.DefaultOption(AvatarCatalog.CategoryShoes);
        public string AccessoryId = AvatarCatalog.DefaultOption(AvatarCatalog.CategoryAccessory);

        public static AvatarAppearance CreateDefault() => new AvatarAppearance();

        public string Get(string category)
        {
            switch (category)
            {
                case AvatarCatalog.CategoryHair: return HairId;
                case AvatarCatalog.CategoryShirt: return ShirtId;
                case AvatarCatalog.CategoryBottom: return BottomId;
                case AvatarCatalog.CategoryShoes: return ShoesId;
                case AvatarCatalog.CategoryAccessory: return AccessoryId;
                default: throw new ArgumentOutOfRangeException(nameof(category), category, "categoria desconhecida");
            }
        }

        /// <summary>Troca uma categoria se o ID for valido no catalogo; retorna false (sem alterar nada) caso contrario.</summary>
        public bool TrySelect(string category, string itemId)
        {
            if (!AvatarCatalog.IsValidOption(category, itemId)) return false;
            switch (category)
            {
                case AvatarCatalog.CategoryHair: HairId = itemId; break;
                case AvatarCatalog.CategoryShirt: ShirtId = itemId; break;
                case AvatarCatalog.CategoryBottom: BottomId = itemId; break;
                case AvatarCatalog.CategoryShoes: ShoesId = itemId; break;
                case AvatarCatalog.CategoryAccessory: AccessoryId = itemId; break;
                default: return false;
            }
            return true;
        }

        public bool IsFullyValid() =>
            AvatarCatalog.IsValidOption(AvatarCatalog.CategoryHair, HairId) &&
            AvatarCatalog.IsValidOption(AvatarCatalog.CategoryShirt, ShirtId) &&
            AvatarCatalog.IsValidOption(AvatarCatalog.CategoryBottom, BottomId) &&
            AvatarCatalog.IsValidOption(AvatarCatalog.CategoryShoes, ShoesId) &&
            AvatarCatalog.IsValidOption(AvatarCatalog.CategoryAccessory, AccessoryId);

        /// <summary>Troca so os campos invalidos (ex.: salvos por uma versao com catalogo diferente) pelo default; preserva os validos.</summary>
        public void SanitizeInPlace()
        {
            if (!AvatarCatalog.IsValidOption(AvatarCatalog.CategoryHair, HairId)) HairId = AvatarCatalog.DefaultOption(AvatarCatalog.CategoryHair);
            if (!AvatarCatalog.IsValidOption(AvatarCatalog.CategoryShirt, ShirtId)) ShirtId = AvatarCatalog.DefaultOption(AvatarCatalog.CategoryShirt);
            if (!AvatarCatalog.IsValidOption(AvatarCatalog.CategoryBottom, BottomId)) BottomId = AvatarCatalog.DefaultOption(AvatarCatalog.CategoryBottom);
            if (!AvatarCatalog.IsValidOption(AvatarCatalog.CategoryShoes, ShoesId)) ShoesId = AvatarCatalog.DefaultOption(AvatarCatalog.CategoryShoes);
            if (!AvatarCatalog.IsValidOption(AvatarCatalog.CategoryAccessory, AccessoryId)) AccessoryId = AvatarCatalog.DefaultOption(AvatarCatalog.CategoryAccessory);
        }
    }
}
