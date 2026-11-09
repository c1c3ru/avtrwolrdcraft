using System;
using System.Linq;

namespace AvatarWorld.Core.Avatar
{
    /// <summary>Roupas do pet em camadas (cavalo: Hat = redea, Outfit = sela). "" = nada.</summary>
    public enum PetClothingSlot { Hat, Outfit, Shoes, Accessory }

    /// <summary>Cores editaveis de um pet em camadas (cada uma e um indice numa paleta propria da especie).</summary>
    public enum PetColorRole { Body, Pattern, Eyes, Eyebrows, Mane, Tail }

    /// <summary>
    /// Pets do slot de pets. Especies simples (variantes prontas) vem de PetCatalogData; cao e gato sao em camadas
    /// (raca, padrao, cores, olhos, boca, sobrancelha) e vem de PetLayerCatalogData + PetPaletteData.
    /// </summary>
    public static class PetCatalog
    {
        static readonly string[] Layered = { "Dog", "Cat", "Horse" };

        public static string[] Species { get; } = Layered.Concat(PetCatalogData.Species).ToArray();

        public static string DisplayName(string species)
        {
            switch (species)
            {
                case "Dog": return "Cão";
                case "Cat": return "Gato";
                case "Horse": return "Cavalo";
                case "Cow": return "Vaca";
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

        public static string[] Clothing(string species, PetClothingSlot slot)
        {
            var layers = Layers(species);
            if (layers == null) return new string[0];
            switch (slot)
            {
                case PetClothingSlot.Hat: return layers.Hats;
                case PetClothingSlot.Outfit: return layers.Outfits;
                case PetClothingSlot.Shoes: return layers.Shoes;
                default: return layers.Accessories;
            }
        }

        public static string[] Patterns(string species, string breed) =>
            Layers(species)?.Patterns.TryGetValue(breed ?? "", out var p) == true ? p : new string[0];

        public static string[] Eyebrows(string species, string breed) =>
            Layers(species)?.Eyebrows.TryGetValue(breed ?? "", out var p) == true ? p : new string[0];

        /// <summary>Nome da paleta do papel de cor para a especie em camadas (ex.: Dog_Body); null se a especie nao tem esse papel.</summary>
        public static string PaletteName(string species, PetColorRole role)
        {
            if (!IsLayered(species)) return null;
            string suffix;
            switch (role)
            {
                case PetColorRole.Body: suffix = "_Body"; break;
                case PetColorRole.Pattern: suffix = "_Patterns"; break;
                case PetColorRole.Eyes: suffix = "_Eyes"; break;
                case PetColorRole.Eyebrows: suffix = "_Eyebrows"; break;
                case PetColorRole.Mane: suffix = "_Hair"; break;
                default: suffix = "_Tail"; break;
            }
            string name = species + suffix;
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
        public string HatId = "", OutfitId = "", ShoesId = "", AccessoryId = "";
        public string ManeId = "";
        public string TailId = "";
        public string EyesId = "";
        public string MouthId = "";
        public int BodyColor, PatternColor, EyesColor, EyebrowColor, ManeColor, TailColor;

        public static PetAppearance CreateDefault(string species = null)
        {
            species = species != null && PetCatalog.IsKnown(species) ? species : PetCatalog.Species[0];
            var pet = new PetAppearance { Species = species };
            pet.ResetForSpecies();
            return pet;
        }

        void ResetForSpecies()
        {
            VariantId = ""; BreedId = ""; PatternId = ""; EyebrowId = ""; ManeId = ""; TailId = ""; EyesId = ""; MouthId = ""; HatId = ""; OutfitId = ""; ShoesId = ""; AccessoryId = "";
            BodyColor = PatternColor = EyesColor = EyebrowColor = ManeColor = TailColor = 0;
            if (PetCatalog.IsLayered(Species))
            {
                var layers = PetCatalog.Layers(Species);
                BreedId = layers.Breeds[0];
                EyesId = layers.Eyes[0];
                MouthId = layers.Mouths[0];
                if (layers.Manes.Length > 0) ManeId = layers.Manes[0];
                if (layers.Tails.Length > 0) TailId = layers.Tails[0];
            }
            else VariantId = PetCatalog.DefaultVariant(Species);
        }

        public PetAppearance Clone() => new PetAppearance
        {
            Species = Species, VariantId = VariantId, BreedId = BreedId, PatternId = PatternId, EyebrowId = EyebrowId, ManeId = ManeId, TailId = TailId, EyesId = EyesId, MouthId = MouthId,
            HatId = HatId, OutfitId = OutfitId, ShoesId = ShoesId, AccessoryId = AccessoryId,
            BodyColor = BodyColor, PatternColor = PatternColor, EyesColor = EyesColor, EyebrowColor = EyebrowColor, ManeColor = ManeColor, TailColor = TailColor,
        };

        public bool IsValid()
        {
            if (!PetCatalog.IsKnown(Species)) return false;
            if (!PetCatalog.IsLayered(Species)) return PetCatalog.IsValid(Species, VariantId);
            var layers = PetCatalog.Layers(Species);
            return layers.Breeds.Contains(BreedId) && layers.Eyes.Contains(EyesId) && layers.Mouths.Contains(MouthId) &&
                   (string.IsNullOrEmpty(PatternId) || PetCatalog.Patterns(Species, BreedId).Contains(PatternId)) &&
                   (string.IsNullOrEmpty(EyebrowId) || PetCatalog.Eyebrows(Species, BreedId).Contains(EyebrowId)) &&
                   ClothingValid(PetClothingSlot.Hat, HatId) && ClothingValid(PetClothingSlot.Outfit, OutfitId) &&
                   ClothingValid(PetClothingSlot.Shoes, ShoesId) && ClothingValid(PetClothingSlot.Accessory, AccessoryId) &&
                   (layers.Manes.Length == 0 ? string.IsNullOrEmpty(ManeId) : layers.Manes.Contains(ManeId)) &&
                   (layers.Tails.Length == 0 ? string.IsNullOrEmpty(TailId) : layers.Tails.Contains(TailId)) &&
                   ColorsInRange();
        }

        bool ClothingValid(PetClothingSlot slot, string id) => string.IsNullOrEmpty(id) || PetCatalog.Clothing(Species, slot).Contains(id);

        public string GetClothing(PetClothingSlot slot)
        {
            switch (slot)
            {
                case PetClothingSlot.Hat: return HatId;
                case PetClothingSlot.Outfit: return OutfitId;
                case PetClothingSlot.Shoes: return ShoesId;
                default: return AccessoryId;
            }
        }

        /// <summary>Veste (ou, com "", tira) o item do slot; false se o item nao existe nessa especie.</summary>
        public bool TrySelectClothing(PetClothingSlot slot, string id)
        {
            if (!PetCatalog.IsLayered(Species) || !ClothingValid(slot, id)) return false;
            id = id ?? "";
            switch (slot)
            {
                case PetClothingSlot.Hat: HatId = id; break;
                case PetClothingSlot.Outfit: OutfitId = id; break;
                case PetClothingSlot.Shoes: ShoesId = id; break;
                default: AccessoryId = id; break;
            }
            return true;
        }

        bool ColorsInRange() =>
            InRange(BodyColor, PetColorRole.Body) && InRange(PatternColor, PetColorRole.Pattern) &&
            InRange(EyesColor, PetColorRole.Eyes) && InRange(EyebrowColor, PetColorRole.Eyebrows) &&
            InRange(ManeColor, PetColorRole.Mane) && InRange(TailColor, PetColorRole.Tail);

        bool InRange(int index, PetColorRole role) => index >= 0 && index < Math.Max(1, PetCatalog.ColorCount(Species, role));

        public bool SameAs(PetAppearance o) => o != null && Species == o.Species && VariantId == o.VariantId && BreedId == o.BreedId &&
            PatternId == o.PatternId && EyebrowId == o.EyebrowId && HatId == o.HatId && OutfitId == o.OutfitId && ShoesId == o.ShoesId && AccessoryId == o.AccessoryId && ManeId == o.ManeId && TailId == o.TailId && EyesId == o.EyesId && MouthId == o.MouthId &&
            BodyColor == o.BodyColor && PatternColor == o.PatternColor && EyesColor == o.EyesColor && EyebrowColor == o.EyebrowColor &&
            ManeColor == o.ManeColor && TailColor == o.TailColor;

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

        public bool TrySelectMane(string maneId)
        {
            var layers = PetCatalog.Layers(Species);
            if (layers == null || !layers.Manes.Contains(maneId)) return false;
            ManeId = maneId;
            return true;
        }

        public bool TrySelectTail(string tailId)
        {
            var layers = PetCatalog.Layers(Species);
            if (layers == null || !layers.Tails.Contains(tailId)) return false;
            TailId = tailId;
            return true;
        }

        public int GetColor(PetColorRole role)
        {
            switch (role)
            {
                case PetColorRole.Body: return BodyColor;
                case PetColorRole.Pattern: return PatternColor;
                case PetColorRole.Eyes: return EyesColor;
                case PetColorRole.Eyebrows: return EyebrowColor;
                case PetColorRole.Mane: return ManeColor;
                default: return TailColor;
            }
        }

        public bool TrySelectColor(PetColorRole role, int index)
        {
            if (!PetCatalog.IsLayered(Species) || index < 0 || index >= PetCatalog.ColorCount(Species, role)) return false;
            switch (role)
            {
                case PetColorRole.Body: BodyColor = index; break;
                case PetColorRole.Pattern: PatternColor = index; break;
                case PetColorRole.Eyes: EyesColor = index; break;
                case PetColorRole.Eyebrows: EyebrowColor = index; break;
                case PetColorRole.Mane: ManeColor = index; break;
                default: TailColor = index; break;
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
            foreach (PetClothingSlot slot in Enum.GetValues(typeof(PetClothingSlot)))
                if (!ClothingValid(slot, GetClothing(slot))) TrySelectClothing(slot, "");
            if (layers.Manes.Length == 0) ManeId = ""; else if (!layers.Manes.Contains(ManeId)) ManeId = layers.Manes[0];
            if (layers.Tails.Length == 0) TailId = ""; else if (!layers.Tails.Contains(TailId)) TailId = layers.Tails[0];
            if (!InRange(ManeColor, PetColorRole.Mane)) ManeColor = 0;
            if (!InRange(TailColor, PetColorRole.Tail)) TailColor = 0;
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
