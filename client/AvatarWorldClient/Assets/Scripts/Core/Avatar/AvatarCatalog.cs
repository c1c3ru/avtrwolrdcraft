using System.Collections.Generic;
using System.Linq;

namespace AvatarWorld.Core.Avatar
{
    /// <summary>
    /// IDs estaveis das opcoes de aparencia validadas no Ciclo 2 (docs/AVATAR_GAMEPLAY_PLAN.md): cada
    /// ID e real (resolvido a partir de resources.assets do jogo original via SUT, ou skin direto do
    /// esqueleto para cabelo) e renderiza de verdade - nao ha placeholder nesta lista. Fonte unica
    /// usada tanto pela validacao de PlayerState.Appearance (fora da engine) quanto pelo runtime de
    /// renderizacao (AvatarGpuRuntime), pra nunca divergir.
    /// </summary>
    public static class AvatarCatalog
    {
        public const string CategoryHair = "Hair";
        public const string CategoryShirt = "Shirt";
        public const string CategoryBottom = "Bottom";
        public const string CategoryShoes = "Shoes";
        public const string CategoryAccessory = "Accessory";
        public const string CategoryMouth = "Mouth";
        public const string CategoryEyebrows = "Eyebrows";
        /// <summary>Cabelo traseiro (coques, rabos); o da frente e CategoryHair (skins Hair_Front/N_Color).</summary>
        public const string CategoryHairBack = "HairBack";
        public const string HairBackNone = "hair_back_none";

        /// <summary>Categoria cuja cor (ItemColors) vale para o item: o cabelo traseiro usa a cor do cabelo da frente.</summary>
        public static string ColorKey(string category) => category == CategoryHairBack ? CategoryHair : category;
        public const string EyebrowsDefault = "eyebrows_default";
        /// <summary>Id da boca embutida no esqueleto (Body_Outline/Mouth_Regular): nao e um item do SUT, nao tem textura propria.</summary>
        public const string MouthDefault = "mouth_default";

        /// <summary>"Sem item" das categorias que crianca/bebe nao tem ou em que o padrao e nao usar nada.</summary>
        public const string AccessoryNone = "accessory_none", BottomNone = "bottom_none", ShoesNone = "shoes_none";

        public static bool IsBuiltIn(string itemId) =>
            itemId == MouthDefault || itemId == EyebrowsDefault || itemId == HairBackNone ||
            itemId == AccessoryNone || itemId == BottomNone || itemId == ShoesNone;

        /// <summary>Itens _color recebem tinta (Multiply) escolhida na paleta General; os demais usam a textura como esta.</summary>
        public static bool IsColorItem(string itemId) => itemId != null && itemId.EndsWith("_color", System.StringComparison.OrdinalIgnoreCase);
        /// <summary>Categorias de cor (paletas oficiais): o valor e um indice em AvatarPalette, nao um item.</summary>
        public const string CategorySkin = "Skin";
        public const string CategoryEyes = "Eyes";

        public static bool IsColorCategory(string category) => category == CategorySkin || category == CategoryEyes;

        public static int ColorCount(string category) =>
            category == CategorySkin ? AvatarPaletteData.SkinCount :
            category == CategoryEyes ? AvatarPaletteData.EyesCount : 0;

        public static readonly IReadOnlyDictionary<string, string[]> OptionsByCategory = new Dictionary<string, string[]>
        {
            { CategoryHair, AvatarCatalogData.Hair },
            // Roupas: AvatarCatalogData e gerado por tools/avatar_catalog_build.py (itens reais do SUT).
            // Os dois primeiros de cada lista sao os ids originais; o primeiro e o padrao.
            { CategoryShirt, AvatarCatalogData.Shirt },
            { CategoryBottom, AvatarCatalogData.Bottom },
            { CategoryShoes, AvatarCatalogData.Shoes },
            { CategoryAccessory, AvatarCatalogData.Accessory },
            { CategoryMouth, AvatarCatalogData.Mouth },
            { CategoryEyebrows, AvatarCatalogData.Eyebrows },
            { CategoryHairBack, AvatarCatalogData.HairBack },
        };

        public static string DefaultOption(string category) => OptionsByCategory[category][0];

        static readonly Dictionary<AvatarKind, IReadOnlyDictionary<string, string[]>> KindOptions = BuildKindOptions();

        static Dictionary<AvatarKind, IReadOnlyDictionary<string, string[]>> BuildKindOptions()
        {
            string[] With(string first, string[] rest) => new[] { first }.Concat(rest).ToArray();
            string[] Or(string none, string[] list) => list.Length > 0 ? list : new[] { none };
            return new Dictionary<AvatarKind, IReadOnlyDictionary<string, string[]>>
            {
                { AvatarKind.Adult, OptionsByCategory },
                { AvatarKind.Toddler, new Dictionary<string, string[]>
                    {
                        { CategoryHair, AvatarKindCatalogData.Toddler.Hair },
                        { CategoryHairBack, new[] { HairBackNone } },
                        { CategoryShirt, AvatarKindCatalogData.Toddler.Shirt },
                        { CategoryBottom, Or(BottomNone, AvatarKindCatalogData.Toddler.Bottom) },
                        { CategoryShoes, Or(ShoesNone, AvatarKindCatalogData.Toddler.Shoes) },
                        { CategoryAccessory, With(AccessoryNone, AvatarKindCatalogData.Toddler.Accessory) },
                        { CategoryMouth, AvatarKindCatalogData.Toddler.Mouth },
                        { CategoryEyebrows, AvatarKindCatalogData.Toddler.Eyebrows },
                    } },
                { AvatarKind.Baby, new Dictionary<string, string[]>
                    {
                        { CategoryHair, AvatarKindCatalogData.Baby.Hair },
                        { CategoryHairBack, new[] { HairBackNone } },
                        { CategoryShirt, AvatarKindCatalogData.Baby.Shirt },
                        { CategoryBottom, Or(BottomNone, AvatarKindCatalogData.Baby.Bottom) },
                        { CategoryShoes, Or(ShoesNone, AvatarKindCatalogData.Baby.Shoes) },
                        { CategoryAccessory, With(AccessoryNone, AvatarKindCatalogData.Baby.Accessory) },
                        { CategoryMouth, AvatarKindCatalogData.Baby.Mouth },
                        { CategoryEyebrows, AvatarKindCatalogData.Baby.Eyebrows },
                    } },
            };
        }

        /// <summary>Opcoes por categoria do tipo (adulto = OptionsByCategory). Categorias sem itens reais trazem so o "sem item".</summary>
        public static IReadOnlyDictionary<string, string[]> Options(AvatarKind kind) =>
            KindOptions.TryGetValue(kind, out var options) ? options : OptionsByCategory;

        public static string DefaultOption(AvatarKind kind, string category) => Options(kind)[category][0];

        public static bool IsValidOption(AvatarKind kind, string category, string itemId) =>
            itemId != null && Options(kind).TryGetValue(category, out var options) && options.Contains(itemId);

        /// <summary>O menu do editor so mostra categorias com mais de uma opcao (ou de cor).</summary>
        public static bool IsEditable(AvatarKind kind, string category) =>
            IsColorCategory(category) || (Options(kind).TryGetValue(category, out var options) && options.Length > 1);

        public static bool IsValidOption(string category, string itemId) =>
            itemId != null && OptionsByCategory.TryGetValue(category, out var options) && options.Contains(itemId);
    }
}
