using System;
using System.Collections.Generic;
using System.Linq;
using AvatarWorld.Core.Avatar;
using NUnit.Framework;
using UnityEngine;

namespace AvatarWorld.Core.Tests
{
    public class AvatarCatalogDataTests
    {
        [Serializable] class Piece { public string template; public string file; public string skin; }
        [Serializable] class Item { public string id; public List<Piece> pieces; }
        [Serializable] class Manifest { public List<Item> items; }

        static Manifest LoadManifest() => JsonUtility.FromJson<Manifest>(Resources.Load<TextAsset>("AvatarSpine/clothing-manifest").text);

        [Test]
        public void ClothingCategoriesOfferManyUniqueOptionsAndKeepTheOriginalDefaults()
        {
            foreach (var category in new[] { AvatarCatalog.CategoryShirt, AvatarCatalog.CategoryBottom, AvatarCatalog.CategoryShoes, AvatarCatalog.CategoryAccessory, AvatarCatalog.CategoryMouth, AvatarCatalog.CategoryHair, AvatarCatalog.CategoryHairBack, AvatarCatalog.CategoryOnepiece, AvatarCatalog.CategoryLegs, AvatarCatalog.CategoryFaceCheeks })
            {
                var ids = AvatarCatalog.OptionsByCategory[category];
                Assert.GreaterOrEqual(ids.Length, 100, category);
                Assert.AreEqual(ids.Length, ids.Distinct().Count(), category + " tem ids repetidos");
            }
            Assert.AreEqual("shirt_formal_1", AvatarCatalog.DefaultOption(AvatarCatalog.CategoryShirt));
            Assert.AreEqual("bottom_special_1", AvatarCatalog.DefaultOption(AvatarCatalog.CategoryBottom));
            Assert.AreEqual("legs_shoes_1", AvatarCatalog.DefaultOption(AvatarCatalog.CategoryShoes));
            Assert.AreEqual("accessories_face_glasses_1", AvatarCatalog.DefaultOption(AvatarCatalog.CategoryAccessory));
            Assert.AreEqual(AvatarCatalog.MouthDefault, AvatarCatalog.DefaultOption(AvatarCatalog.CategoryMouth));
            Assert.AreEqual(AvatarCatalog.HatNone, AvatarCatalog.DefaultOption(AvatarCatalog.CategoryHat));
            Assert.AreEqual(AvatarCatalog.JacketNone, AvatarCatalog.DefaultOption(AvatarCatalog.CategoryJacket));
            Assert.Greater(AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryHat].Length, 50);
            Assert.Greater(AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryJacket].Length, 50);
            // BackA (acessorio de costas) teve so 28 pecas reais extraidas (unica pasta "back_c"): sem a cota de 100.
            var backA = AvatarCatalog.OptionsByCategory[AvatarCatalog.CategoryBackA];
            Assert.GreaterOrEqual(backA.Length, 20, AvatarCatalog.CategoryBackA);
            Assert.AreEqual(backA.Length, backA.Distinct().Count(), AvatarCatalog.CategoryBackA + " tem ids repetidos");
        }

        [Test]
        public void NewCharacterCategoryTypeCategoriesAreHiddenForChildAndBaby()
        {
            // Onepiece/Legs/BackA/FaceCheeks sao "so adultos" (RECON_CHARACTER_CONTRACT.md): crianca/bebe
            // recebem so o placeholder "sem peca" e a categoria fica oculta no menu desses tipos.
            foreach (var kind in new[] { AvatarKind.Toddler, AvatarKind.Baby })
                foreach (var category in new[] { AvatarCatalog.CategoryOnepiece, AvatarCatalog.CategoryLegs, AvatarCatalog.CategoryBackA, AvatarCatalog.CategoryFaceCheeks })
                {
                    Assert.AreEqual(1, AvatarCatalog.Options(kind)[category].Length, kind + "/" + category);
                    Assert.IsFalse(AvatarCatalog.IsEditable(kind, category), kind + "/" + category);
                }
        }

        [Test]
        public void ClothingTexturesAreReadableAtRuntime()
        {
            // O runtime copia cada textura com GetPixels32; sem isReadable o aparelho falha (o editor nao).
#if UNITY_EDITOR
            foreach (var guid in UnityEditor.AssetDatabase.FindAssets("t:Texture2D", new[] { "Assets/Resources/AvatarSpine/Clothing", "Assets/Resources/AvatarSpine/Textures" }))
            {
                string path = UnityEditor.AssetDatabase.GUIDToAssetPath(guid);
                var importer = (UnityEditor.TextureImporter)UnityEditor.AssetImporter.GetAtPath(path);
                Assert.IsTrue(importer.isReadable, path + " sem Read/Write");
            }
#endif
        }

        [Test]
        public void EveryCatalogIdHasAManifestItemWhoseTexturesExist()
        {
            var manifest = LoadManifest();
            var byId = manifest.items.ToDictionary(i => i.id);
            foreach (var category in AvatarCatalog.OptionsByCategory.Keys)
                foreach (var id in AvatarCatalog.OptionsByCategory[category].Where(i => !AvatarCatalog.IsBuiltIn(i)))
                {
                    Assert.IsTrue(byId.TryGetValue(id, out var item), id + " ausente do manifesto");
                    Assert.Greater(item.pieces.Count, 0, id);
                    foreach (var piece in item.pieces)
                    {
                        Assert.IsTrue(piece.template.StartsWith("Templates/"), id);
                        string resource = System.IO.Path.GetFileNameWithoutExtension(piece.file);
                        Assert.IsNotNull(Resources.Load<Texture2D>("AvatarSpine/Clothing/" + resource), id + ": " + resource);
                    }
                }
        }
    }
}
