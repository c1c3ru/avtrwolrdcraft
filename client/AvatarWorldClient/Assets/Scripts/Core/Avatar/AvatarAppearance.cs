using System;
using System.Collections.Generic;

namespace AvatarWorld.Core.Avatar
{
    /// <summary>
    /// Selecao atual de aparencia do avatar, gravada dentro de PlayerState (Ciclo 3). Campos publicos
    /// simples com valor padrao no proprio inicializador para sobreviver a JsonUtility: um save antigo
    /// sem o campo "Appearance" (ou com campos individuais ausentes) mantem os defaults abaixo em vez
    /// de ficar nulo - JsonUtility.FromJson sobrescreve so os campos presentes no JSON.
    /// </summary>
    /// <summary>Indice na paleta General escolhido para os itens _color de uma categoria.</summary>
    [Serializable]
    public sealed class CategoryColor
    {
        public string Category;
        public int Index;
    }

    [Serializable]
    public sealed class AvatarAppearance
    {
        public string HairId = AvatarCatalog.DefaultOption(AvatarCatalog.CategoryHair);
        public string ShirtId = AvatarCatalog.DefaultOption(AvatarCatalog.CategoryShirt);
        public string BottomId = AvatarCatalog.DefaultOption(AvatarCatalog.CategoryBottom);
        public string ShoesId = AvatarCatalog.DefaultOption(AvatarCatalog.CategoryShoes);
        public string AccessoryId = AvatarCatalog.DefaultOption(AvatarCatalog.CategoryAccessory);
        public string MouthId = AvatarCatalog.DefaultOption(AvatarCatalog.CategoryMouth);
        public string EyebrowsId = AvatarCatalog.DefaultOption(AvatarCatalog.CategoryEyebrows);
        public string HairBackId = AvatarCatalog.DefaultOption(AvatarCatalog.CategoryHairBack);
        /// <summary>Cor (paleta General) por categoria, so para itens _color; ausente = AvatarPaletteData.DefaultItemColor.</summary>
        public List<CategoryColor> ItemColors = new List<CategoryColor>();
        /// <summary>Indices nas paletas Skin/Eyes (palettes.json). Saves antigos sem estes campos ficam nos padroes.</summary>
        public int SkinIndex = AvatarPaletteData.DefaultSkin;
        public int EyesIndex = AvatarPaletteData.DefaultEyes;

        /// <summary>Tipo do avatar (adulto, crianca, bebe). Saves antigos sem o campo ficam Adult (0).</summary>
        public AvatarKind Kind = AvatarKind.Adult;

        public static AvatarAppearance CreateDefault() => new AvatarAppearance();

        /// <summary>Aparencia padrao do tipo: primeiro item de cada categoria do catalogo do tipo.</summary>
        public static AvatarAppearance CreateDefault(AvatarKind kind)
        {
            var a = new AvatarAppearance { Kind = kind };
            foreach (var category in AvatarCatalog.OptionsByCategory.Keys) a.SetRaw(category, AvatarCatalog.DefaultOption(kind, category));
            return a;
        }

        /// <summary>Copia independente (usada pelo historico desfazer/refazer do editor).</summary>
        public AvatarAppearance Clone() => new AvatarAppearance
        {
            Kind = Kind, HairId = HairId, ShirtId = ShirtId, BottomId = BottomId, ShoesId = ShoesId, AccessoryId = AccessoryId, MouthId = MouthId, EyebrowsId = EyebrowsId, HairBackId = HairBackId,
            SkinIndex = SkinIndex, EyesIndex = EyesIndex,
            ItemColors = ItemColors.ConvertAll(c => new CategoryColor { Category = c.Category, Index = c.Index }),
        };

        public int GetItemColor(string category)
        {
            foreach (var c in ItemColors) if (c.Category == category) return c.Index;
            return AvatarPaletteData.DefaultItemColor;
        }

        /// <summary>Troca a cor dos itens _color da categoria; retorna false (sem alterar) se o indice sair da paleta General.</summary>
        public bool TrySelectItemColor(string category, int index)
        {
            if (!AvatarCatalog.OptionsByCategory.ContainsKey(category) || index < 0 || index >= AvatarPaletteData.GeneralCount) return false;
            foreach (var c in ItemColors) if (c.Category == category) { c.Index = index; return true; }
            ItemColors.Add(new CategoryColor { Category = category, Index = index });
            return true;
        }

        public bool SameAs(AvatarAppearance other) => other != null && Kind == other.Kind &&
            HairId == other.HairId && ShirtId == other.ShirtId && BottomId == other.BottomId &&
            ShoesId == other.ShoesId && AccessoryId == other.AccessoryId && MouthId == other.MouthId &&
            EyebrowsId == other.EyebrowsId && HairBackId == other.HairBackId && SkinIndex == other.SkinIndex && EyesIndex == other.EyesIndex && SameItemColors(other);

        bool SameItemColors(AvatarAppearance other)
        {
            foreach (var c in ItemColors) if (other.GetItemColor(c.Category) != c.Index) return false;
            foreach (var c in other.ItemColors) if (GetItemColor(c.Category) != c.Index) return false;
            return true;
        }

        public int GetColorIndex(string category)
        {
            switch (category)
            {
                case AvatarCatalog.CategorySkin: return SkinIndex;
                case AvatarCatalog.CategoryEyes: return EyesIndex;
                default: throw new ArgumentOutOfRangeException(nameof(category), category, "categoria de cor desconhecida");
            }
        }

        /// <summary>Troca o indice de cor se estiver dentro da paleta; retorna false (sem alterar) caso contrario.</summary>
        public bool TrySelectColor(string category, int index)
        {
            if (!AvatarCatalog.IsColorCategory(category) || index < 0 || index >= AvatarCatalog.ColorCount(category)) return false;
            if (category == AvatarCatalog.CategorySkin) SkinIndex = index; else EyesIndex = index;
            return true;
        }

        public string Get(string category)
        {
            switch (category)
            {
                case AvatarCatalog.CategoryHair: return HairId;
                case AvatarCatalog.CategoryShirt: return ShirtId;
                case AvatarCatalog.CategoryBottom: return BottomId;
                case AvatarCatalog.CategoryShoes: return ShoesId;
                case AvatarCatalog.CategoryAccessory: return AccessoryId;
                case AvatarCatalog.CategoryMouth: return MouthId;
                case AvatarCatalog.CategoryEyebrows: return EyebrowsId;
                case AvatarCatalog.CategoryHairBack: return HairBackId;
                default: throw new ArgumentOutOfRangeException(nameof(category), category, "categoria desconhecida");
            }
        }

        /// <summary>Troca uma categoria se o ID for valido no catalogo do tipo; retorna false (sem alterar nada) caso contrario.</summary>
        public bool TrySelect(string category, string itemId)
        {
            if (!AvatarCatalog.IsValidOption(Kind, category, itemId)) return false;
            return SetRaw(category, itemId);
        }

        bool SetRaw(string category, string itemId)
        {
            switch (category)
            {
                case AvatarCatalog.CategoryHair: HairId = itemId; break;
                case AvatarCatalog.CategoryShirt: ShirtId = itemId; break;
                case AvatarCatalog.CategoryBottom: BottomId = itemId; break;
                case AvatarCatalog.CategoryShoes: ShoesId = itemId; break;
                case AvatarCatalog.CategoryAccessory: AccessoryId = itemId; break;
                case AvatarCatalog.CategoryMouth: MouthId = itemId; break;
                case AvatarCatalog.CategoryEyebrows: EyebrowsId = itemId; break;
                case AvatarCatalog.CategoryHairBack: HairBackId = itemId; break;
                default: return false;
            }
            return true;
        }

        public bool IsFullyValid() =>
            AvatarKinds.IsDefined(Kind) &&
            AvatarCatalog.IsValidOption(Kind, AvatarCatalog.CategoryHair, HairId) &&
            AvatarCatalog.IsValidOption(Kind, AvatarCatalog.CategoryShirt, ShirtId) &&
            AvatarCatalog.IsValidOption(Kind, AvatarCatalog.CategoryBottom, BottomId) &&
            AvatarCatalog.IsValidOption(Kind, AvatarCatalog.CategoryShoes, ShoesId) &&
            AvatarCatalog.IsValidOption(Kind, AvatarCatalog.CategoryAccessory, AccessoryId) &&
            AvatarCatalog.IsValidOption(Kind, AvatarCatalog.CategoryMouth, MouthId) &&
            AvatarCatalog.IsValidOption(Kind, AvatarCatalog.CategoryEyebrows, EyebrowsId) &&
            AvatarCatalog.IsValidOption(Kind, AvatarCatalog.CategoryHairBack, HairBackId) &&
            ItemColors.TrueForAll(c => c != null && AvatarCatalog.OptionsByCategory.ContainsKey(c.Category) && c.Index >= 0 && c.Index < AvatarPaletteData.GeneralCount) &&
            SkinIndex >= 0 && SkinIndex < AvatarPaletteData.SkinCount && EyesIndex >= 0 && EyesIndex < AvatarPaletteData.EyesCount;

        /// <summary>Troca so os campos invalidos (ex.: salvos por uma versao com catalogo diferente) pelo default; preserva os validos.</summary>
        public void SanitizeInPlace()
        {
            if (!AvatarKinds.IsDefined(Kind)) Kind = AvatarKind.Adult;
            if (!AvatarCatalog.IsValidOption(Kind, AvatarCatalog.CategoryHair, HairId)) HairId = AvatarCatalog.DefaultOption(Kind, AvatarCatalog.CategoryHair);
            if (!AvatarCatalog.IsValidOption(Kind, AvatarCatalog.CategoryShirt, ShirtId)) ShirtId = AvatarCatalog.DefaultOption(Kind, AvatarCatalog.CategoryShirt);
            if (!AvatarCatalog.IsValidOption(Kind, AvatarCatalog.CategoryBottom, BottomId)) BottomId = AvatarCatalog.DefaultOption(Kind, AvatarCatalog.CategoryBottom);
            if (!AvatarCatalog.IsValidOption(Kind, AvatarCatalog.CategoryShoes, ShoesId)) ShoesId = AvatarCatalog.DefaultOption(Kind, AvatarCatalog.CategoryShoes);
            if (!AvatarCatalog.IsValidOption(Kind, AvatarCatalog.CategoryAccessory, AccessoryId)) AccessoryId = AvatarCatalog.DefaultOption(Kind, AvatarCatalog.CategoryAccessory);
            if (!AvatarCatalog.IsValidOption(Kind, AvatarCatalog.CategoryMouth, MouthId)) MouthId = AvatarCatalog.DefaultOption(Kind, AvatarCatalog.CategoryMouth);
            if (!AvatarCatalog.IsValidOption(Kind, AvatarCatalog.CategoryEyebrows, EyebrowsId)) EyebrowsId = AvatarCatalog.DefaultOption(Kind, AvatarCatalog.CategoryEyebrows);
            if (!AvatarCatalog.IsValidOption(Kind, AvatarCatalog.CategoryHairBack, HairBackId)) HairBackId = AvatarCatalog.DefaultOption(Kind, AvatarCatalog.CategoryHairBack);
            if (ItemColors == null) ItemColors = new List<CategoryColor>();
            ItemColors.RemoveAll(c => c == null || !AvatarCatalog.OptionsByCategory.ContainsKey(c.Category) || c.Index < 0 || c.Index >= AvatarPaletteData.GeneralCount);
            if (SkinIndex < 0 || SkinIndex >= AvatarPaletteData.SkinCount) SkinIndex = AvatarPaletteData.DefaultSkin;
            if (EyesIndex < 0 || EyesIndex >= AvatarPaletteData.EyesCount) EyesIndex = AvatarPaletteData.DefaultEyes;
        }
    }
}
