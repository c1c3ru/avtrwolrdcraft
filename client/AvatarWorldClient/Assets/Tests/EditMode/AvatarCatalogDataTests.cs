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
        [Serializable] class Piece { public string template; public string file; }
        [Serializable] class Item { public string id; public List<Piece> pieces; }
        [Serializable] class Manifest { public List<Item> items; }

        static Manifest LoadManifest() => JsonUtility.FromJson<Manifest>(Resources.Load<TextAsset>("AvatarSpine/clothing-manifest").text);

        [Test]
        public void ClothingCategoriesOfferManyUniqueOptionsAndKeepTheOriginalDefaults()
        {
            foreach (var category in new[] { AvatarCatalog.CategoryShirt, AvatarCatalog.CategoryBottom, AvatarCatalog.CategoryShoes, AvatarCatalog.CategoryAccessory, AvatarCatalog.CategoryMouth })
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
            foreach (var category in AvatarCatalog.OptionsByCategory.Keys.Where(c => c != AvatarCatalog.CategoryHair))
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
