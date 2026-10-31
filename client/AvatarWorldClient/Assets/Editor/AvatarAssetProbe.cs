using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Spine;
using UnityEngine;

namespace AvatarWorld.EditorTools
{
    /// <summary>Leitura do binario/atlas reais, sem carregar milhares de texturas ou executar o jogo original.</summary>
    public static class AvatarAssetProbe
    {
        sealed class MetadataTextureLoader : TextureLoader
        {
            public void Load(AtlasPage page, string path) { }
            public void Unload(object texture) { }
        }

        [Serializable] public class Inventory
        {
            public string version;
            public int bones, slots, pages, regions;
            public List<SkinInventory> skins = new List<SkinInventory>();
            public List<string> animations;
        }
        [Serializable] public class SkinInventory
        {
            public string name;
            public List<string> pages = new List<string>();
            public List<string> attachments = new List<string>();
        }

        public static void Inspect()
        {
            var root = Path.GetFullPath(Path.Combine(Application.dataPath, "../../.."));
            var inputs = Path.Combine(root, "assets/spine_textasset/TextAsset");
            var atlas = new Atlas(new StringReader(File.ReadAllText(Path.Combine(inputs, "Avatar_Spine.atlas_109005.txt"))), "", new MetadataTextureLoader());
            using (var stream = File.OpenRead(Path.Combine(inputs, "Avatar_Spine.skel_108595.txt")))
            {
                var data = new SkeletonBinary(atlas).ReadSkeletonData(stream);
                var result = new Inventory {
                    version = data.Version, bones = data.Bones.Count, slots = data.Slots.Count,
                    pages = atlas.Pages.Count, regions = atlas.Regions.Count,
                    animations = data.Animations.Select(a => a.Name).ToList()
                };
                foreach (var skin in data.Skins)
                {
                    var row = new SkinInventory { name = skin.Name };
                    foreach (var entry in skin.Attachments)
                    {
                        row.attachments.Add(data.Slots.Items[entry.SlotIndex].Name + ":" + entry.Name);
                        AtlasRegion region = null;
                        if (entry.Attachment is RegionAttachment r) region = r.Region as AtlasRegion;
                        if (entry.Attachment is MeshAttachment m) region = m.Region as AtlasRegion;
                        if (region != null && !row.pages.Contains(region.page.name)) row.pages.Add(region.page.name);
                    }
                    result.skins.Add(row);
                }
                Directory.CreateDirectory(Path.Combine(root, "out"));
                File.WriteAllText(Path.Combine(root, "out/avatar-spine-inventory.json"), JsonUtility.ToJson(result, true));
                Debug.Log($"AvatarAssetProbe: Spine {result.version}, {result.skins.Count} skins, {result.pages} pages, {result.animations.Count} animations");
            }
        }
    }
}
