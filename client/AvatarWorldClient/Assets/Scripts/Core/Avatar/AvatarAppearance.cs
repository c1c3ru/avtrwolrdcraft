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

    /// <summary>Peca solta (bochecha, meia, bolsa...) so de NPC: id do manifesto + tinta RGB opcional (vazio = sem tinta).</summary>
    [Serializable]
    public sealed class ExtraItem
    {
        public string Id;
        public float[] Tint = new float[0];
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
        public string HatId = AvatarCatalog.DefaultOption(AvatarCatalog.CategoryHat);
        public string JacketId = AvatarCatalog.DefaultOption(AvatarCatalog.CategoryJacket);
        public string OnepieceId = AvatarCatalog.DefaultOption(AvatarCatalog.CategoryOnepiece);
        public string LegsId = AvatarCatalog.DefaultOption(AvatarCatalog.CategoryLegs);
        public string BackAId = AvatarCatalog.DefaultOption(AvatarCatalog.CategoryBackA);
        public string FaceCheeksId = AvatarCatalog.DefaultOption(AvatarCatalog.CategoryFaceCheeks);
        /// <summary>Cor (paleta General) por categoria, so para itens _color; ausente = AvatarPaletteData.DefaultItemColor.</summary>
        public List<CategoryColor> ItemColors = new List<CategoryColor>();
        /// <summary>Indices nas paletas Skin/Eyes (palettes.json). Saves antigos sem estes campos ficam nos padroes.</summary>
        public int SkinIndex = AvatarPaletteData.DefaultSkin;
        public int EyesIndex = AvatarPaletteData.DefaultEyes;

        /// <summary>Tipo do avatar (adulto, crianca, bebe). Saves antigos sem o campo ficam Adult (0).</summary>
        public AvatarKind Kind = AvatarKind.Adult;

        /// <summary>Pecas extras so de NPC (sem categoria no editor). Nao entra em Clone/SameAs: o jogador nunca as tem.</summary>
        [NonSerialized] public List<ExtraItem> Extras;

        public static AvatarAppearance CreateDefault() => new AvatarAppearance();

        /// <summary>Aparencia padrao do tipo: primeiro item de cada categoria do catalogo do tipo.</summary>
        public static AvatarAppearance CreateDefault(AvatarKind kind)
        {
            var a = new AvatarAppearance { Kind = kind };
            foreach (var category in AvatarCatalog.OptionsByCategory.Keys) a.SetRaw(category, AvatarCatalog.DefaultOption(kind, category));
            return a;
        }

        /// <summary>
        /// Preset de referencia visual (C6, print "imagem13": chapeu de bombeiro, cabelo branco, jaqueta
        /// vermelha, saia rosa) - identificado por inspecao visual dos itens reais do catalogo (nao ha
        /// nome/metadado de cor nos IDs): hat_a_7 (capacete vermelho com emblema), jacket_formal_6
        /// (jaqueta vermelha solida), bottom_formal_9 (saia rosa pregueada), Hair_Front/1_Color com a cor
        /// 114 da paleta General (0.9647 RGB, a mais proxima do branco puro).
        /// </summary>
        public static AvatarAppearance CreateReferenceImagem13Preset()
        {
            var a = CreateDefault();
            a.TrySelect(AvatarCatalog.CategoryHat, "hat_a_7");
            a.TrySelect(AvatarCatalog.CategoryJacket, "jacket_formal_6");
            a.TrySelect(AvatarCatalog.CategoryBottom, "bottom_formal_9");
            a.TrySelect(AvatarCatalog.CategoryHair, "Hair_Front/1_Color");
            // Indice 114 da paleta General (palettes.json): RGB (0.9647, 0.9647, 0.9647), o mais proximo
            // do branco puro entre as 115 cores (nao ha indice exatamente 1,1,1 na paleta oficial).
            a.TrySelectItemColor(AvatarCatalog.CategoryHair, 114);
            return a;
        }

        /// <summary>Copia independente (usada pelo historico desfazer/refazer do editor).</summary>
        public AvatarAppearance Clone() => new AvatarAppearance
        {
            Kind = Kind, HairId = HairId, ShirtId = ShirtId, BottomId = BottomId, ShoesId = ShoesId, AccessoryId = AccessoryId, MouthId = MouthId, EyebrowsId = EyebrowsId, HairBackId = HairBackId, HatId = HatId, JacketId = JacketId,
            OnepieceId = OnepieceId, LegsId = LegsId, BackAId = BackAId, FaceCheeksId = FaceCheeksId,
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
            EyebrowsId == other.EyebrowsId && HairBackId == other.HairBackId && HatId == other.HatId && JacketId == other.JacketId &&
            OnepieceId == other.OnepieceId && LegsId == other.LegsId && BackAId == other.BackAId && FaceCheeksId == other.FaceCheeksId &&
            SkinIndex == other.SkinIndex && EyesIndex == other.EyesIndex && SameItemColors(other);

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
                case AvatarCatalog.CategoryHat: return HatId;
                case AvatarCatalog.CategoryJacket: return JacketId;
                case AvatarCatalog.CategoryOnepiece: return OnepieceId;
                case AvatarCatalog.CategoryLegs: return LegsId;
                case AvatarCatalog.CategoryBackA: return BackAId;
                case AvatarCatalog.CategoryFaceCheeks: return FaceCheeksId;
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
                case AvatarCatalog.CategoryHat: HatId = itemId; break;
                case AvatarCatalog.CategoryJacket: JacketId = itemId; break;
                case AvatarCatalog.CategoryOnepiece: OnepieceId = itemId; break;
                case AvatarCatalog.CategoryLegs: LegsId = itemId; break;
                case AvatarCatalog.CategoryBackA: BackAId = itemId; break;
                case AvatarCatalog.CategoryFaceCheeks: FaceCheeksId = itemId; break;
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
            AvatarCatalog.IsValidOption(Kind, AvatarCatalog.CategoryHat, HatId) &&
            AvatarCatalog.IsValidOption(Kind, AvatarCatalog.CategoryJacket, JacketId) &&
            AvatarCatalog.IsValidOption(Kind, AvatarCatalog.CategoryOnepiece, OnepieceId) &&
            AvatarCatalog.IsValidOption(Kind, AvatarCatalog.CategoryLegs, LegsId) &&
            AvatarCatalog.IsValidOption(Kind, AvatarCatalog.CategoryBackA, BackAId) &&
            AvatarCatalog.IsValidOption(Kind, AvatarCatalog.CategoryFaceCheeks, FaceCheeksId) &&
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
            if (!AvatarCatalog.IsValidOption(Kind, AvatarCatalog.CategoryHat, HatId)) HatId = AvatarCatalog.DefaultOption(Kind, AvatarCatalog.CategoryHat);
            if (!AvatarCatalog.IsValidOption(Kind, AvatarCatalog.CategoryJacket, JacketId)) JacketId = AvatarCatalog.DefaultOption(Kind, AvatarCatalog.CategoryJacket);
            if (!AvatarCatalog.IsValidOption(Kind, AvatarCatalog.CategoryOnepiece, OnepieceId)) OnepieceId = AvatarCatalog.DefaultOption(Kind, AvatarCatalog.CategoryOnepiece);
            if (!AvatarCatalog.IsValidOption(Kind, AvatarCatalog.CategoryLegs, LegsId)) LegsId = AvatarCatalog.DefaultOption(Kind, AvatarCatalog.CategoryLegs);
            if (!AvatarCatalog.IsValidOption(Kind, AvatarCatalog.CategoryBackA, BackAId)) BackAId = AvatarCatalog.DefaultOption(Kind, AvatarCatalog.CategoryBackA);
            if (!AvatarCatalog.IsValidOption(Kind, AvatarCatalog.CategoryFaceCheeks, FaceCheeksId)) FaceCheeksId = AvatarCatalog.DefaultOption(Kind, AvatarCatalog.CategoryFaceCheeks);
            if (ItemColors == null) ItemColors = new List<CategoryColor>();
            ItemColors.RemoveAll(c => c == null || !AvatarCatalog.OptionsByCategory.ContainsKey(c.Category) || c.Index < 0 || c.Index >= AvatarPaletteData.GeneralCount);
            if (SkinIndex < 0 || SkinIndex >= AvatarPaletteData.SkinCount) SkinIndex = AvatarPaletteData.DefaultSkin;
            if (EyesIndex < 0 || EyesIndex >= AvatarPaletteData.EyesCount) EyesIndex = AvatarPaletteData.DefaultEyes;
        }
    }
}
