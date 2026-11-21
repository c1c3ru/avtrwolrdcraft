using System;
using System.Collections.Generic;
using System.Linq;
using AvatarWorld.Core.Avatar;
using AvatarWorld.Core.World;
using NUnit.Framework;
using UnityEngine;

namespace AvatarWorld.Core.Tests
{
    /// <summary>Dados dos NPCs de interior (Resources/Interiors/*/*_npcs.json) e o modelo de pecas extras do AvatarAppearance.</summary>
    public class NpcLooksDataTests
    {
        [Serializable] class Color3 { public string Category; public int Index; }
        [Serializable] class Look
        {
            public string Hair, HairBack, Shirt, Bottom, Shoes, Accessory, Mouth, Eyebrows, Hat, Jacket;
            public int skinIndex, eyesIndex;
            public List<Color3> colors = new List<Color3>();
            public List<ExtraItem> extras = new List<ExtraItem>();
            public IEnumerable<string> Items => new[] { Hair, HairBack, Shirt, Bottom, Shoes, Accessory, Mouth, Eyebrows, Hat, Jacket };
        }
        [Serializable] class Npc { public int id; public float x, y; public Look look; }
        [Serializable] class NpcFile { public List<Npc> npcs = new List<Npc>(); }
        [Serializable] class Piece { public string template; public string file; public string skin; }
        [Serializable] class Item { public string id; public List<Piece> pieces; }
        [Serializable] class Manifest { public List<Item> items; }

        static readonly int[] PetIds = { 900005, 900009, 900017 };

        static Manifest _manifest;
        static Manifest LoadManifest() => _manifest ??= JsonUtility.FromJson<Manifest>(Resources.Load<TextAsset>("AvatarSpine/clothing-manifest").text);

        static IEnumerable<(string key, NpcFile file)> AllNpcFiles()
        {
            foreach (var key in InteriorCatalog.AllKeys.Distinct())
            {
                var asset = Resources.Load<TextAsset>("Interiors/" + key + "/" + key + "_npcs");
                if (asset == null) continue;
                yield return (key, JsonUtility.FromJson<NpcFile>(asset.text));
            }
        }

        [Test]
        public void NpcFiles_ExistForManyInteriorsAndHoldHundredsOfNpcs()
        {
            var files = AllNpcFiles().ToList();
            Assert.GreaterOrEqual(files.Count(f => f.file.npcs.Count > 0), 40, "interiores com NPCs");
            Assert.GreaterOrEqual(files.Sum(f => f.file.npcs.Count), 300, "total de NPCs");
        }

        [Test]
        public void EveryNpc_HasUniqueIdPerInteriorAFiniteSpotAndNoPets()
        {
            foreach (var (key, file) in AllNpcFiles())
            {
                var seen = new HashSet<(int, float, float)>();
                foreach (var n in file.npcs)
                {
                    // O mesmo avatar pode aparecer em dois pontos da cena; o mesmo id no mesmo ponto seria duplicata.
                    Assert.IsTrue(seen.Add((n.id, n.x, n.y)), key + ": NPC duplicado " + n.id);
                    Assert.IsFalse(float.IsNaN(n.x) || float.IsInfinity(n.x) || float.IsNaN(n.y) || float.IsInfinity(n.y), key + " NPC " + n.id);
                    CollectionAssert.DoesNotContain(PetIds, n.id, key + ": pet virou NPC");
                    Assert.IsNotNull(n.look, key + " NPC " + n.id + " sem look");
                }
            }
        }

        [Test]
        public void EveryLookItem_ExistsInTheManifestOrIsNone()
        {
            var ids = new HashSet<string>(LoadManifest().items.Select(i => i.id));
            foreach (var (key, file) in AllNpcFiles())
                foreach (var n in file.npcs)
                    foreach (var item in n.look.Items)
                    {
                        Assert.IsFalse(string.IsNullOrEmpty(item), key + " NPC " + n.id + " campo vazio");
                        if (item == "none") continue;
                        Assert.IsTrue(ids.Contains(item), key + " NPC " + n.id + ": item fora do manifesto " + item);
                    }
        }

        [Test]
        public void EveryExtra_ExistsInTheManifestWithItsTexturesAndAValidTint()
        {
            var byId = LoadManifest().items.ToDictionary(i => i.id);
            int total = 0;
            foreach (var (key, file) in AllNpcFiles())
                foreach (var n in file.npcs)
                    foreach (var ex in n.look.extras)
                    {
                        total++;
                        var where = key + " NPC " + n.id + " extra " + ex.Id;
                        Assert.IsTrue(byId.TryGetValue(ex.Id, out var item), where + ": fora do manifesto");
                        Assert.Greater(item.pieces.Count, 0, where + ": sem pecas");
                        foreach (var p in item.pieces)
                        {
                            var name = System.IO.Path.GetFileNameWithoutExtension(p.file);
                            Assert.IsNotNull(Resources.Load<Texture2D>("AvatarSpine/Clothing/" + name), where + ": textura " + p.file);
                        }
                        Assert.IsNotNull(ex.Tint, where);
                        Assert.IsTrue(ex.Tint.Length == 0 || ex.Tint.Length == 3, where + ": tinta com " + ex.Tint.Length + " canais");
                        foreach (var c in ex.Tint) Assert.IsTrue(c >= 0f && c <= 1f, where + ": canal fora de 0..1");
                    }
            Assert.Greater(total, 100, "deveria haver centenas de pecas extras nos NPCs");
        }

        [Test]
        public void Extras_DoNotDuplicateWithinOneNpcOrLeakIntoEditorCategories()
        {
            var editorIds = new HashSet<string>(AvatarCatalog.OptionsByCategory.Values.SelectMany(v => v));
            foreach (var (key, file) in AllNpcFiles())
                foreach (var n in file.npcs)
                {
                    var ids = n.look.extras.Select(e => e.Id).ToList();
                    Assert.AreEqual(ids.Count, ids.Distinct().Count(), key + " NPC " + n.id + ": extra repetido");
                    foreach (var id in ids) Assert.IsFalse(editorIds.Contains(id), id + " e extra de NPC mas esta nas listas do editor");
                }
        }

        [Test]
        public void NpcOnlyManifestItems_StayOutOfTheEditorLists()
        {
            var editorIds = new HashSet<string>(AvatarCatalog.OptionsByCategory.Values.SelectMany(v => v));
            var extraIds = AllNpcFiles().SelectMany(f => f.file.npcs).SelectMany(n => n.look.extras).Select(e => e.Id).Distinct().ToList();
            Assert.Greater(extraIds.Count, 0);
            Assert.IsEmpty(extraIds.Where(editorIds.Contains).ToList());
        }

        [Test]
        public void Colors_PointToExistingCategoriesWithValidPaletteIndexes()
        {
            foreach (var (key, file) in AllNpcFiles())
                foreach (var n in file.npcs)
                    foreach (var c in n.look.colors)
                    {
                        Assert.IsFalse(string.IsNullOrEmpty(c.Category), key + " NPC " + n.id);
                        Assert.GreaterOrEqual(c.Index, 0, key + " NPC " + n.id);
                    }
        }

        [Test]
        public void Appearance_ExtrasAreNotSerializedClonedOrCompared()
        {
            var a = new AvatarAppearance { Extras = new List<ExtraItem> { new ExtraItem { Id = "legs_socks_16", Tint = new float[0] } } };
            Assert.IsFalse(JsonUtility.ToJson(a).Contains("legs_socks_16"), "Extras nao pode ir para o save do jogador");
            Assert.IsNull(a.Clone().Extras);
            Assert.IsTrue(a.SameAs(new AvatarAppearance()), "extras nao entram em SameAs");
            Assert.IsNull(JsonUtility.FromJson<AvatarAppearance>(JsonUtility.ToJson(a)).Extras);
        }

        [Test]
        public void Appearance_DefaultHasNoExtras()
        {
            Assert.IsNull(AvatarAppearance.CreateDefault().Extras);
            Assert.IsNull(AvatarAppearance.CreateDefault(AvatarKind.Toddler).Extras);
        }

        [Test]
        public void ExtraItem_DefaultsToNoTint()
        {
            Assert.AreEqual(0, new ExtraItem().Tint.Length);
        }
    }
}
