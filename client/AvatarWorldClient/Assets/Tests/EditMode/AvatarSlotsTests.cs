using System;
using System.Collections.Generic;
using System.Linq;
using AvatarWorld.Core.Avatar;
using AvatarWorld.Core.Economy;
using NUnit.Framework;
using UnityEngine;

namespace AvatarWorld.Core.Tests
{
    public class AvatarSlotsTests
    {
        [Test]
        public void NewStateHasOnlyTheFirstSlot()
        {
            var state = PlayerState.CreateNew(0);
            Assert.IsTrue(state.HasHumanAvatar(0));
            Assert.IsFalse(state.HasHumanAvatar(1));
            Assert.IsFalse(state.HasHumanAvatar(2));
            Assert.IsNull(state.GetHumanAppearance(1));
        }

        [Test]
        public void SwitchingCreatesSlotsAndKeepsEachAvatar()
        {
            var state = PlayerState.CreateNew(0);
            state.Appearance.TrySelect(AvatarCatalog.CategoryShirt, AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryShirt][5]);
            string first = state.Appearance.ShirtId;
            Assert.IsTrue(state.SwitchHumanSlot(1));
            Assert.AreEqual(1, state.ActiveHumanSlot);
            Assert.AreEqual(AvatarCatalog.DefaultOption(AvatarCatalog.CategoryShirt), state.Appearance.ShirtId);
            state.Appearance.TrySelect(AvatarCatalog.CategoryShirt, AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryShirt][9]);
            string second = state.Appearance.ShirtId;
            Assert.IsFalse(state.SwitchHumanSlot(0));
            Assert.AreEqual(first, state.Appearance.ShirtId);
            Assert.AreEqual(second, state.GetHumanAppearance(1).ShirtId);
            Assert.IsTrue(state.SwitchHumanSlot(2));
            Assert.IsTrue(state.HasHumanAvatar(0) && state.HasHumanAvatar(1) && state.HasHumanAvatar(2));
            Assert.Throws<System.ArgumentOutOfRangeException>(() => state.SwitchHumanSlot(PlayerState.HumanSlotCount));
        }

        [Test]
        public void DiscardRestoresThePreviousAvatarAndEmptiesTheSlot()
        {
            var state = PlayerState.CreateNew(0);
            state.SwitchHumanSlot(2);
            state.DiscardHumanSlot(2, 0);
            Assert.AreEqual(0, state.ActiveHumanSlot);
            Assert.IsFalse(state.HasHumanAvatar(2));
            Assert.AreEqual(0, state.OtherAvatars.Count);
        }

        [Test]
        public void SlotsSurviveJsonRoundTripAndSanitizeBadData()
        {
            var state = PlayerState.CreateNew(0);
            state.SwitchHumanSlot(1);
            state.Appearance.TrySelect(AvatarCatalog.CategoryShoes, AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryShoes][7]);
            var back = JsonUtility.FromJson<PlayerState>(JsonUtility.ToJson(state));
            back.SanitizeAvatarSlots();
            Assert.AreEqual(1, back.ActiveHumanSlot);
            Assert.AreEqual(state.Appearance.ShoesId, back.Appearance.ShoesId);
            Assert.IsTrue(back.HasHumanAvatar(0));

            back.ActiveHumanSlot = 9;
            back.OtherAvatars.Add(new SavedAvatar { Slot = 9 });
            back.OtherAvatars.Add(new SavedAvatar { Slot = 0 });
            back.OtherAvatars.Add(new SavedAvatar { Slot = 0 });
            back.SanitizeAvatarSlots();
            Assert.AreEqual(0, back.ActiveHumanSlot);
            Assert.AreEqual(1, back.OtherAvatars.FindAll(o => o.Slot == 1).Count);
            Assert.IsTrue(back.OtherAvatars.TrueForAll(o => o.Slot != 0 && o.Appearance != null));
        }

        [Test]
        public void ExpandedCatalogExposesAllStrictlyResolvedClothing()
        {
            Assert.GreaterOrEqual(AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryShirt].Length, 1042);
            Assert.GreaterOrEqual(AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryBottom].Length, 970);
            Assert.GreaterOrEqual(AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryShoes].Length, 1171);
            Assert.GreaterOrEqual(AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryAccessory].Length, 833);
        }
        [Test]
        public void EveryKindHasAValidDefaultAppearance()
        {
            foreach (var kind in AvatarKinds.All)
            {
                var a = AvatarAppearance.CreateDefault(kind);
                Assert.AreEqual(kind, a.Kind);
                Assert.IsTrue(a.IsFullyValid(), kind.ToString());
                Assert.AreEqual(kind, a.Clone().Kind);
            }
        }

        [Test]
        public void KindCatalogsRejectIdsFromOtherKinds()
        {
            var toddler = AvatarAppearance.CreateDefault(AvatarKind.Toddler);
            Assert.IsFalse(toddler.TrySelect(AvatarCatalog.CategoryShirt, AvatarCatalog.DefaultOption(AvatarCatalog.CategoryShirt)));
            Assert.IsTrue(toddler.TrySelect(AvatarCatalog.CategoryShirt, AvatarCatalog.Options(AvatarKind.Toddler)[AvatarCatalog.CategoryShirt][3]));
            var adult = AvatarAppearance.CreateDefault();
            Assert.IsFalse(adult.TrySelect(AvatarCatalog.CategoryShirt, AvatarCatalog.Options(AvatarKind.Toddler)[AvatarCatalog.CategoryShirt][0]));
            Assert.IsTrue(AvatarCatalog.IsEditable(AvatarKind.Toddler, AvatarCatalog.CategoryShoes));
            Assert.IsFalse(AvatarCatalog.IsEditable(AvatarKind.Baby, AvatarCatalog.CategoryShoes));
            Assert.IsFalse(AvatarCatalog.IsEditable(AvatarKind.Baby, AvatarCatalog.CategoryHairBack));
        }

        [Test]
        public void OldSavesWithoutKindStayAdultAndKindSurvivesJson()
        {
            var old = JsonUtility.FromJson<AvatarAppearance>("{\"HairId\":\"" + AvatarCatalog.DefaultOption(AvatarCatalog.CategoryHair) + "\"}");
            old.SanitizeInPlace();
            Assert.AreEqual(AvatarKind.Adult, old.Kind);
            var baby = AvatarAppearance.CreateDefault(AvatarKind.Baby);
            var back = JsonUtility.FromJson<AvatarAppearance>(JsonUtility.ToJson(baby));
            back.SanitizeInPlace();
            Assert.AreEqual(AvatarKind.Baby, back.Kind);
            Assert.AreEqual(baby.ShirtId, back.ShirtId);
        }

        [Test]
        public void NewSlotsCanBeCreatedAsChildOrBaby()
        {
            var state = PlayerState.CreateNew(0);
            Assert.IsTrue(state.SwitchHumanSlot(1, AvatarKind.Toddler));
            Assert.AreEqual(AvatarKind.Toddler, state.Appearance.Kind);
            Assert.IsTrue(state.SwitchHumanSlot(2, AvatarKind.Baby));
            Assert.AreEqual(AvatarKind.Baby, state.GetHumanAppearance(2).Kind);
            Assert.AreEqual(AvatarKind.Toddler, state.GetHumanAppearance(1).Kind);
            Assert.AreEqual(AvatarKind.Adult, state.GetHumanAppearance(0).Kind);
            Assert.IsFalse(state.SwitchHumanSlot(1, AvatarKind.Baby)); // slot ja existe: mantem o tipo
            Assert.AreEqual(AvatarKind.Toddler, state.Appearance.Kind);
        }

        [Serializable] class Piece { public string template; public string file; public string skin; }
        [Serializable] class Item { public string id; public List<Piece> pieces; }
        [Serializable] class Manifest { public List<Item> items; }

        [Test]
        public void KindManifestsContainEveryCatalogIdAndTheBody()
        {
            foreach (var kind in new[] { AvatarKind.Toddler, AvatarKind.Baby })
            {
                var manifest = JsonUtility.FromJson<Manifest>(Resources.Load<TextAsset>(AvatarKinds.ResourceFolder(kind) + "/manifest").text);
                var ids = new HashSet<string>(manifest.items.ConvertAll(i => i.id));
                Assert.IsTrue(ids.Contains("__body"), kind + " sem corpo");
                foreach (var pair in AvatarCatalog.Options(kind))
                    foreach (var id in pair.Value)
                        Assert.IsTrue(AvatarCatalog.IsBuiltIn(id) || ids.Contains(id), kind + " " + pair.Key + " " + id);
                Assert.IsNotNull(Resources.Load<TextAsset>(AvatarKinds.ResourceFolder(kind) + "/Spine.atlas"));
                Assert.IsNotNull(Resources.Load<TextAsset>(AvatarKinds.ResourceFolder(kind) + "/Spine.skel"));
            }
        }
        [Test]
        public void PetsAreStoredPerSlotAndSurviveJson()
        {
            var state = PlayerState.CreateNew(0);
            Assert.IsNull(state.GetPet(0));
            var rabbit = PetAppearance.CreateDefault("Rabbit");
            Assert.IsTrue(rabbit.IsValid());
            Assert.IsTrue(state.SetPet(1, rabbit));
            rabbit.TrySelectSpecies("Bird");           // a copia guardada nao muda
            Assert.AreEqual("Rabbit", state.GetPet(1).Species);
            Assert.IsFalse(state.SetPet(PlayerState.PetSlotCount, rabbit));
            Assert.IsFalse(state.SetPet(0, new PetAppearance { Species = "Dragon", VariantId = "x" }));
            Assert.IsTrue(state.SetPet(1, rabbit));    // substitui o slot, sem duplicar
            Assert.AreEqual(1, state.Pets.Count);
            var back = JsonUtility.FromJson<PlayerState>(JsonUtility.ToJson(state));
            back.Pets.Add(new SavedPet { Slot = 1, Pet = PetAppearance.CreateDefault("Fish") });   // duplicado
            back.Pets.Add(new SavedPet { Slot = 7, Pet = PetAppearance.CreateDefault("Fish") });   // fora do intervalo
            back.Pets.Add(new SavedPet { Slot = 2, Pet = new PetAppearance { Species = "Bird", VariantId = "nope" } });
            back.SanitizePets();
            Assert.AreEqual(2, back.Pets.Count);
            Assert.AreEqual("Bird", back.GetPet(1).Species);
            Assert.IsTrue(back.GetPet(2).IsValid());
            state.RemovePet(1);
            Assert.IsNull(state.GetPet(1));
        }

        [Test]
        public void EveryPetSpeciesHasVariantsAndResources()
        {
            foreach (var species in PetCatalog.Species)
            {
                string folder = "AvatarSpine/Pets/" + species;
                Assert.IsNotNull(Resources.Load<TextAsset>(folder + "/Spine.atlas"), species);
                Assert.IsNotNull(Resources.Load<TextAsset>(folder + "/Spine.skel"), species);
                var file = Resources.Load<TextAsset>(folder + "/pet");
                Assert.IsNotNull(file, species);
                Assert.IsTrue(PetAppearance.CreateDefault(species).IsValid(), species);
                if (PetCatalog.IsLayered(species))
                {
                    var layers = PetCatalog.Layers(species);
                    foreach (var id in layers.Breeds.Concat(layers.Eyes).Concat(layers.Mouths))
                        StringAssert.Contains("\"" + id + "\"", file.text, species);
                    continue;
                }
                var variants = PetCatalog.Variants(species);
                Assert.Greater(variants.Length, 0, species);
                Assert.AreEqual(variants.Length, new HashSet<string>(variants).Count, species);
                foreach (var id in variants) StringAssert.Contains("\"" + id + "\"", file.text);
            }
        }

        [Test]
        public void DogAndCatAreLayeredWithTheirOwnPalettes()
        {
            Assert.IsTrue(PetCatalog.IsLayered("Dog") && PetCatalog.IsLayered("Cat") && !PetCatalog.IsLayered("Rabbit"));
            Assert.Greater(PetCatalog.ColorCount("Dog", PetColorRole.Body), 0);
            Assert.Greater(PetCatalog.ColorCount("Cat", PetColorRole.Eyes), 0);
            Assert.AreEqual(0, PetCatalog.ColorCount("Cat", PetColorRole.Eyebrows));   // gato nao tem sobrancelha
            Assert.AreEqual(0, PetCatalog.ColorCount("Rabbit", PetColorRole.Body));
        }

        [Test]
        public void LayeredPetSelectionsAreValidatedAgainstTheBreed()
        {
            var dog = PetAppearance.CreateDefault("Dog");
            Assert.IsTrue(dog.IsValid());
            var layers = PetCatalog.Layers("Dog");
            string breed = layers.Breeds[0], other = layers.Breeds[layers.Breeds.Length - 1];
            var pattern = PetCatalog.Patterns("Dog", breed)[0];
            Assert.IsTrue(dog.TrySelectPattern(pattern));
            Assert.IsFalse(dog.TrySelectPattern("pattern_999"));
            Assert.IsTrue(dog.TrySelectBreed(other));
            Assert.IsTrue(dog.IsValid());                                    // padrao invalido na nova raca volta a nenhum
            Assert.IsFalse(dog.TrySelectColor(PetColorRole.Body, PetCatalog.ColorCount("Dog", PetColorRole.Body)));
            Assert.IsTrue(dog.TrySelectColor(PetColorRole.Body, 5));
            Assert.AreEqual(5, dog.GetColor(PetColorRole.Body));
            Assert.IsFalse(dog.TrySelectVariant("rabbit_a_1"));
            var cat = PetAppearance.CreateDefault("Cat");
            Assert.IsFalse(cat.TrySelectEyebrow(PetCatalog.Eyebrows("Dog", layers.Breeds[0]).Length > 0 ? "eyebrows_1" : "x"));
            Assert.IsTrue(cat.TrySelectSpecies("Rabbit"));
            Assert.IsTrue(cat.IsValid());
            Assert.IsFalse(cat.TrySelectBreed("breed_a"));
        }

        [Test]
        public void LayeredPetSurvivesJsonAndSanitizesBadData()
        {
            var cat = PetAppearance.CreateDefault("Cat");
            cat.TrySelectColor(PetColorRole.Body, 7);
            cat.TrySelectEyes(PetCatalog.Layers("Cat").Eyes[3]);
            var back = JsonUtility.FromJson<PetAppearance>(JsonUtility.ToJson(cat));
            Assert.IsTrue(back.SameAs(cat));
            back.BreedId = "breed_zzz"; back.BodyColor = 9999; back.PatternId = "nope"; back.MouthId = null;
            back.SanitizeInPlace();
            Assert.IsTrue(back.IsValid());
            Assert.AreEqual(0, back.BodyColor);
        }

        [Test]
        public void HorseHasManeAndTailWithOwnPalettesAndCowIsASimpleSpecies()
        {
            Assert.IsTrue(PetCatalog.IsLayered("Horse"));
            Assert.IsFalse(PetCatalog.IsLayered("Cow"));
            Assert.IsTrue(PetCatalog.Variants("Cow").Length >= 1);
            var layers = PetCatalog.Layers("Horse");
            Assert.Greater(layers.Manes.Length, 1);
            Assert.Greater(layers.Tails.Length, 1);
            Assert.Greater(PetCatalog.ColorCount("Horse", PetColorRole.Mane), 0);
            Assert.Greater(PetCatalog.ColorCount("Horse", PetColorRole.Tail), 0);
            var horse = PetAppearance.CreateDefault("Horse");
            Assert.IsTrue(horse.IsValid());
            Assert.IsTrue(horse.TrySelectMane(layers.Manes[2]));
            Assert.IsTrue(horse.TrySelectTail(layers.Tails[1]));
            Assert.IsTrue(horse.TrySelectColor(PetColorRole.Mane, 3));
            Assert.IsFalse(horse.TrySelectMane("mane_999"));
            var dog = PetAppearance.CreateDefault("Dog");
            Assert.IsFalse(dog.TrySelectMane(layers.Manes[0]));       // cao nao tem crina
            Assert.AreEqual("", dog.ManeId);
            Assert.IsFalse(dog.TrySelectColor(PetColorRole.Tail, 0));
        }

        [Test]
        public void PetClothingIsPerSpeciesAndValidated()
        {
            var dog = PetAppearance.CreateDefault("Dog");
            var hats = PetCatalog.Clothing("Dog", PetClothingSlot.Hat);
            Assert.Greater(hats.Length, 0);
            Assert.IsTrue(dog.TrySelectClothing(PetClothingSlot.Hat, hats[0]));
            Assert.AreEqual(hats[0], dog.GetClothing(PetClothingSlot.Hat));
            Assert.IsFalse(dog.TrySelectClothing(PetClothingSlot.Hat, "hat_zzz"));
            Assert.IsFalse(dog.TrySelectClothing(PetClothingSlot.Outfit, hats[0]));   // id de outro slot
            Assert.IsTrue(dog.TrySelectClothing(PetClothingSlot.Hat, ""));
            Assert.AreEqual(0, PetCatalog.Clothing("Horse", PetClothingSlot.Shoes).Length);
            Assert.Greater(PetCatalog.Clothing("Horse", PetClothingSlot.Outfit).Length, 0);   // sela
            Assert.AreEqual(0, PetCatalog.Clothing("Rabbit", PetClothingSlot.Hat).Length);
            Assert.IsFalse(PetAppearance.CreateDefault("Rabbit").TrySelectClothing(PetClothingSlot.Hat, hats[0]));
            dog.HatId = "nope"; dog.SanitizeInPlace();
            Assert.AreEqual("", dog.HatId);
            Assert.IsTrue(dog.IsValid());
        }
    }
}
