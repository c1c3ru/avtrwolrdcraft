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
        public const string EyebrowsDefault = "eyebrows_default";
        /// <summary>Id da boca embutida no esqueleto (Body_Outline/Mouth_Regular): nao e um item do SUT, nao tem textura propria.</summary>
        public const string MouthDefault = "mouth_default";

        public static bool IsBuiltIn(string itemId) => itemId == MouthDefault || itemId == EyebrowsDefault;

        /// <summary>Itens _color recebem tinta (Multiply) escolhida na paleta General; os demais usam a textura como esta.</summary>
        public static bool IsColorItem(string itemId) => itemId != null && itemId.EndsWith("_color", System.StringComparison.Ordinal);
        /// <summary>Categorias de cor (paletas oficiais): o valor e um indice em AvatarPalette, nao um item.</summary>
        public const string CategorySkin = "Skin";
        public const string CategoryEyes = "Eyes";

        public static bool IsColorCategory(string category) => category == CategorySkin || category == CategoryEyes;

        public static int ColorCount(string category) =>
            category == CategorySkin ? AvatarPaletteData.SkinCount :
            category == CategoryEyes ? AvatarPaletteData.EyesCount : 0;

        public static readonly IReadOnlyDictionary<string, string[]> OptionsByCategory = new Dictionary<string, string[]>
        {
            { CategoryHair, new[] { "Hair_Front/1_Color", "Hair_Front/2_Color" } },
            // Roupas: AvatarCatalogData e gerado por tools/avatar_catalog_build.py (itens reais do SUT).
            // Os dois primeiros de cada lista sao os ids originais; o primeiro e o padrao.
            { CategoryShirt, AvatarCatalogData.Shirt },
            { CategoryBottom, AvatarCatalogData.Bottom },
            { CategoryShoes, AvatarCatalogData.Shoes },
            { CategoryAccessory, AvatarCatalogData.Accessory },
            { CategoryMouth, AvatarCatalogData.Mouth },
            { CategoryEyebrows, AvatarCatalogData.Eyebrows },
        };

        public static string DefaultOption(string category) => OptionsByCategory[category][0];

        public static bool IsValidOption(string category, string itemId) =>
            itemId != null && OptionsByCategory.TryGetValue(category, out var options) && options.Contains(itemId);
    }
}
