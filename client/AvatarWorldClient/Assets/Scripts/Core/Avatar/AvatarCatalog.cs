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

        public static readonly IReadOnlyDictionary<string, string[]> OptionsByCategory = new Dictionary<string, string[]>
        {
            { CategoryHair, new[] { "Hair_Front/1_Color", "Hair_Front/2_Color" } },
            { CategoryShirt, new[] { "shirt_formal_1", "shirt_casual_1" } },
            { CategoryBottom, new[] { "bottom_special_1", "bottom_special_10" } },
            { CategoryShoes, new[] { "legs_shoes_1", "legs_shoes_10" } },
            { CategoryAccessory, new[] { "accessories_face_glasses_1", "accessories_body_neck_1" } },
        };

        public static string DefaultOption(string category) => OptionsByCategory[category][0];

        public static bool IsValidOption(string category, string itemId) =>
            itemId != null && OptionsByCategory.TryGetValue(category, out var options) && options.Contains(itemId);
    }
}
