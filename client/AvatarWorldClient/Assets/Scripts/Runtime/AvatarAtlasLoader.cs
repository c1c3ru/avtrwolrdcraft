using System;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

namespace AvatarWorld.Runtime
{
    /// <summary>Cria o atlas Spine completo, com um Material resolvido para cada pagina.</summary>
    public static class AvatarAtlasLoader
    {
        public const int ExpectedPageCount = 2172;

        public static string[] ParsePageNames(string atlasText)
        {
            if (string.IsNullOrEmpty(atlasText)) throw new ArgumentException("Atlas vazio", nameof(atlasText));
            var pages = new List<string>();
            var unique = new HashSet<string>(StringComparer.Ordinal);
            var lines = atlasText.Replace("\r", "").Split('\n');
            foreach (var rawLine in lines)
            {
                var line = rawLine.Trim();
                if (!line.EndsWith(".png", StringComparison.OrdinalIgnoreCase)) continue;
                var page = line.Substring(0, line.Length - 4);
                if (!unique.Add(page)) throw new InvalidOperationException("Pagina duplicada no atlas: " + page);
                pages.Add(page);
            }
            return pages.ToArray();
        }

        public static SpineAtlasAsset Create(TextAsset atlasText, Shader shader,
            IReadOnlyDictionary<string, Texture2D> realTextures,
            out Dictionary<string, Material> materialByPage, int expectedPageCount = ExpectedPageCount)
        {
            if (atlasText == null) throw new ArgumentNullException(nameof(atlasText));
            if (shader == null) throw new ArgumentNullException(nameof(shader));
            var pages = ParsePageNames(atlasText.text);
            if (expectedPageCount >= 0 && pages.Length != expectedPageCount)
                throw new InvalidOperationException($"Atlas tem {pages.Length} paginas; esperado: {expectedPageCount}");

            var materials = new Material[pages.Length];
            materialByPage = new Dictionary<string, Material>(pages.Length, StringComparer.Ordinal);
            for (int i = 0; i < pages.Length; i++)
            {
                var page = pages[i];
                Texture2D texture;
                if (realTextures == null || !realTextures.TryGetValue(page, out texture) || texture == null)
                {
                    texture = new Texture2D(1, 1, TextureFormat.RGBA32, false) { name = page };
                    texture.SetPixel(0, 0, Color.clear);
                    texture.Apply(false, true);
                }
                else texture.name = page;

                var material = new Material(shader) { name = page, mainTexture = texture };
                materials[i] = material;
                materialByPage.Add(page, material);
            }

            var asset = SpineAtlasAsset.CreateRuntimeInstance(atlasText, materials, true);
            var atlas = asset.GetAtlas();
            if (atlas == null || atlas.Pages.Count != pages.Length)
                throw new InvalidOperationException("Spine nao criou todas as paginas do atlas");
            for (int i = 0; i < atlas.Pages.Count; i++)
                if (atlas.Pages[i].rendererObject == null)
                    throw new InvalidOperationException("Pagina sem Material: " + atlas.Pages[i].name);
            return asset;
        }
    }
}
