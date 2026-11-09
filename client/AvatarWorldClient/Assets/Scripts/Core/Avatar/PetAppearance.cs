using System;
using System.Linq;

namespace AvatarWorld.Core.Avatar
{
    /// <summary>Cores editaveis de um pet em camadas (cada uma e um indice numa paleta propria da especie).</summary>
    public enum PetColorRole { Body, Pattern, Eyes, Eyebrows }

    /// <summary>
    /// Pets do slot de pets. Especies simples (variantes prontas) vem de PetCatalogData; cao e gato sao em camadas
    /// (raca, padrao, cores, olhos, boca, sobrancelha) e vem de PetLayerCatalogData + PetPaletteData.
    /// </summary>
    public static class PetCatalog
    {
        static readonly string[] Layered = { "Dog", "Cat" };

        public static string[] Species { get; } = Layered.Concat(PetCatalogData.Species).ToArray();

        public static string DisplayName(string species)
        {
            switch (species)
            {
                case "Dog": return "Cão";
                case "Cat": return "Gato";
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

        public static bool IsLayered(string species) => species != null && PetLayerCatalogData.Species.ContainsKey(species);

        public static PetLayerCatalogData.Layered Layers(string species) => IsLayered(species) ? PetLayerCatalogData.Species[species] : null;

        public static string[] Variants(string species) =>
            species != null && PetCatalogData.Variants.TryGetValue(species, out var list) ? list : new string[0];

        public static bool IsKnown(string species) => IsLayered(species) || Variants(species).Length > 0;

        public static bool IsValid(string species, string variantId) => Variants(species).Contains(variantId);

        public static string DefaultVariant(string species) => Variants(species)[0];

        public static string[] Patterns(string species, string breed) =>
            Layers(species)?.Patterns.TryGetValue(breed ?? "", out var p) == true ? p : new string[0];

        public static string[] Eyebrows(string species, string breed) =>
            Layers(species)?.Eyebrows.TryGetValue(breed ?? "", out var p) == true ? p : new string[0];

        /// <summary>Nome da paleta do papel de cor para a especie em camadas (ex.: Dog_Body); null se a especie nao tem esse papel.</summary>
        public static string PaletteName(string species, PetColorRole role)
        {
            if (!IsLayered(species)) return null;
            string name = species + (role == PetColorRole.Body ? "_Body" : role == PetColorRole.Pattern ? "_Patterns" : role == PetColorRole.Eyes ? "_Eyes" : "_Eyebrows");
            return PetPaletteData.Counts.ContainsKey(name) ? name : null;
        }

        public static int ColorCount(string species, PetColorRole role)
        {
            var name = PaletteName(species, role);
            return name != null ? PetPaletteData.Counts[name] : 0;
        }
    }

    /// <summary>Selecao de um pet. Campos publicos simples (JsonUtility). Simples: VariantId. Em camadas: os demais.</summary>
    [Serializable]
    public sealed class PetAppearance
    {
        public string Species;
        public string VariantId;
        // Em camadas (cao/gato). "" em padrao/sobrancelha = nenhum.
        public string BreedId = "";
        public string PatternId = "";
        public string EyebrowId = "";
        public string EyesId = "";
        public string MouthId = "";
        public int BodyColor, PatternColor, EyesColor, EyebrowColor;

        public static PetAppearance CreateDefault(string species = null)
        {
            species = species != null && PetCatalog.IsKnown(species) ? species : PetCatalog.Species[0];
            var pet = new PetAppearance { Species = species };
            pet.ResetForSpecies();
            return pet;
        }

        void ResetForSpecies()
        {
            VariantId = ""; BreedId = ""; PatternId = ""; EyebrowId = ""; EyesId = ""; MouthId = "";
            BodyColor = PatternColor = EyesColor = EyebrowColor = 0;
            if (PetCatalog.IsLayered(Species))
            {
                var layers = PetCatalog.Layers(Species);
                BreedId = layers.Breeds[0];
                EyesId = layers.Eyes[0];
                MouthId = layers.Mouths[0];
            }
            else VariantId = PetCatalog.DefaultVariant(Species);
        }

        public PetAppearance Clone() => new PetAppearance
        {
            Species = Species, VariantId = VariantId, BreedId = BreedId, PatternId = PatternId, EyebrowId = EyebrowId, EyesId = EyesId, MouthId = MouthId,
            BodyColor = BodyColor, PatternColor = PatternColor, EyesColor = EyesColor, EyebrowColor = EyebrowColor,
        };

        public bool IsValid()
        {
            if (!PetCatalog.IsKnown(Species)) return false;
            if (!PetCatalog.IsLayered(Species)) return PetCatalog.IsValid(Species, VariantId);
            var layers = PetCatalog.Layers(Species);
            return layers.Breeds.Contains(BreedId) && layers.Eyes.Contains(EyesId) && layers.Mouths.Contains(MouthId) &&
                   (string.IsNullOrEmpty(PatternId) || PetCatalog.Patterns(Species, BreedId).Contains(PatternId)) &&
                   (string.IsNullOrEmpty(EyebrowId) || PetCatalog.Eyebrows(Species, BreedId).Contains(EyebrowId)) &&
                   ColorsInRange();
        }

        bool ColorsInRange() =>
            InRange(BodyColor, PetColorRole.Body) && InRange(PatternColor, PetColorRole.Pattern) &&
            InRange(EyesColor, PetColorRole.Eyes) && InRange(EyebrowColor, PetColorRole.Eyebrows);

        bool InRange(int index, PetColorRole role) => index >= 0 && index < Math.Max(1, PetCatalog.ColorCount(Species, role));

        public bool SameAs(PetAppearance o) => o != null && Species == o.Species && VariantId == o.VariantId && BreedId == o.BreedId &&
            PatternId == o.PatternId && EyebrowId == o.EyebrowId && EyesId == o.EyesId && MouthId == o.MouthId &&
            BodyColor == o.BodyColor && PatternColor == o.PatternColor && EyesColor == o.EyesColor && EyebrowColor == o.EyebrowColor;

        /// <summary>Troca de especie: tudo volta ao padrao da nova especie. False (sem alterar) se a especie nao existe.</summary>
        public bool TrySelectSpecies(string species)
        {
            if (!PetCatalog.IsKnown(species)) return false;
            Species = species;
            ResetForSpecies();
            return true;
        }

        public bool TrySelectVariant(string variantId)
        {
            if (PetCatalog.IsLayered(Species) || !PetCatalog.IsValid(Species, variantId)) return false;
            VariantId = variantId;
            return true;
        }

        /// <summary>Troca a raca; padrao e sobrancelha que a nova raca nao tem voltam a "nenhum".</summary>
        public bool TrySelectBreed(string breedId)
        {
            var layers = PetCatalog.Layers(Species);
            if (layers == null || !layers.Breeds.Contains(breedId)) return false;
            BreedId = breedId;
            if (!string.IsNullOrEmpty(PatternId) && !PetCatalog.Patterns(Species, breedId).Contains(PatternId)) PatternId = "";
            if (!string.IsNullOrEmpty(EyebrowId) && !PetCatalog.Eyebrows(Species, breedId).Contains(EyebrowId)) EyebrowId = "";
            return true;
        }

        public bool TrySelectPattern(string patternId)
        {
            if (!PetCatalog.IsLayered(Species) || (!string.IsNullOrEmpty(patternId) && !PetCatalog.Patterns(Species, BreedId).Contains(patternId))) return false;
            PatternId = patternId ?? "";
            return true;
        }

        public bool TrySelectEyebrow(string eyebrowId)
        {
            if (!PetCatalog.IsLayered(Species) || (!string.IsNullOrEmpty(eyebrowId) && !PetCatalog.Eyebrows(Species, BreedId).Contains(eyebrowId))) return false;
            EyebrowId = eyebrowId ?? "";
            return true;
        }

        public bool TrySelectEyes(string eyesId)
        {
            var layers = PetCatalog.Layers(Species);
            if (layers == null || !layers.Eyes.Contains(eyesId)) return false;
            EyesId = eyesId;
            return true;
        }

        public bool TrySelectMouth(string mouthId)
        {
            var layers = PetCatalog.Layers(Species);
            if (layers == null || !layers.Mouths.Contains(mouthId)) return false;
            MouthId = mouthId;
            return true;
        }

        public int GetColor(PetColorRole role) =>
            role == PetColorRole.Body ? BodyColor : role == PetColorRole.Pattern ? PatternColor : role == PetColorRole.Eyes ? EyesColor : EyebrowColor;

        public bool TrySelectColor(PetColorRole role, int index)
        {
            if (!PetCatalog.IsLayered(Species) || index < 0 || index >= PetCatalog.ColorCount(Species, role)) return false;
            switch (role)
            {
                case PetColorRole.Body: BodyColor = index; break;
                case PetColorRole.Pattern: PatternColor = index; break;
                case PetColorRole.Eyes: EyesColor = index; break;
                default: EyebrowColor = index; break;
            }
            return true;
        }

        public void SanitizeInPlace()
        {
            if (!PetCatalog.IsKnown(Species)) { Species = PetCatalog.Species[0]; ResetForSpecies(); return; }
            if (!PetCatalog.IsLayered(Species))
            {
                if (!PetCatalog.IsValid(Species, VariantId)) VariantId = PetCatalog.DefaultVariant(Species);
                return;
            }
            var layers = PetCatalog.Layers(Species);
            if (!layers.Breeds.Contains(BreedId)) BreedId = layers.Breeds[0];
            if (!layers.Eyes.Contains(EyesId)) EyesId = layers.Eyes[0];
            if (!layers.Mouths.Contains(MouthId)) MouthId = layers.Mouths[0];
            if (PatternId == null || (PatternId != "" && !PetCatalog.Patterns(Species, BreedId).Contains(PatternId))) PatternId = "";
            if (EyebrowId == null || (EyebrowId != "" && !PetCatalog.Eyebrows(Species, BreedId).Contains(EyebrowId))) EyebrowId = "";
            if (!InRange(BodyColor, PetColorRole.Body)) BodyColor = 0;
            if (!InRange(PatternColor, PetColorRole.Pattern)) PatternColor = 0;
            if (!InRange(EyesColor, PetColorRole.Eyes)) EyesColor = 0;
            if (!InRange(EyebrowColor, PetColorRole.Eyebrows)) EyebrowColor = 0;
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
