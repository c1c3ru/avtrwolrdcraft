using System;
using System.Linq;

namespace AvatarWorld.Core.Avatar
{
    /// <summary>Pets simples (variantes prontas) do slot de pets: especies e variantes vem de PetCatalogData.</summary>
    public static class PetCatalog
    {
        public static string[] Species => PetCatalogData.Species;

        public static string DisplayName(string species)
        {
            switch (species)
            {
                case "Rabbit": return "Coelho";
                case "Hamster": return "Hamster";
                case "Bird": return "Pássaro";
                case "Chicken": return "Galinha";
                case "Turtle": return "Tartaruga";
                case "Lizard": return "Lagarto";
                case "Snake": return "Cobra";
                case "Fish": return "Peixe";
                default: return species;
            }
        }

        public static string[] Variants(string species) =>
            species != null && PetCatalogData.Variants.TryGetValue(species, out var list) ? list : new string[0];

        public static bool IsValid(string species, string variantId) => Variants(species).Contains(variantId);

        public static string DefaultVariant(string species) => Variants(species)[0];
    }

    /// <summary>Selecao de um pet (especie + variante). Campos publicos simples para JsonUtility.</summary>
    [Serializable]
    public sealed class PetAppearance
    {
        public string Species;
        public string VariantId;

        public static PetAppearance CreateDefault(string species = null)
        {
            species = species != null && PetCatalog.Variants(species).Length > 0 ? species : PetCatalog.Species[0];
            return new PetAppearance { Species = species, VariantId = PetCatalog.DefaultVariant(species) };
        }

        public PetAppearance Clone() => new PetAppearance { Species = Species, VariantId = VariantId };

        public bool IsValid() => PetCatalog.IsValid(Species, VariantId);

        public bool SameAs(PetAppearance other) => other != null && Species == other.Species && VariantId == other.VariantId;

        /// <summary>Troca de especie: a variante volta para a primeira da nova especie. False (sem alterar) se a especie nao existe.</summary>
        public bool TrySelectSpecies(string species)
        {
            if (PetCatalog.Variants(species).Length == 0) return false;
            Species = species;
            VariantId = PetCatalog.DefaultVariant(species);
            return true;
        }

        public bool TrySelectVariant(string variantId)
        {
            if (!PetCatalog.IsValid(Species, variantId)) return false;
            VariantId = variantId;
            return true;
        }

        public void SanitizeInPlace()
        {
            if (PetCatalog.Variants(Species).Length == 0) Species = PetCatalog.Species[0];
            if (!PetCatalog.IsValid(Species, VariantId)) VariantId = PetCatalog.DefaultVariant(Species);
        }
    }

    /// <summary>Pet guardado num slot de pet.</summary>
    [Serializable]
    public sealed class SavedPet
    {
        public int Slot;
        public PetAppearance Pet;
    }
}
