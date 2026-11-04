using System.Collections.Generic;
using System.Linq;
using AvatarWorld.Runtime;
using NUnit.Framework;
using UnityEngine;

namespace AvatarWorld.Core.Tests
{
    public class AvatarAtlasLoaderTests
    {
        [Test]
        public void RealAtlas_ResolvesEveryPageAndKeepsProvidedTexture()
        {
            var atlasText = Resources.Load<TextAsset>("AvatarSpine/Avatar_Spine.atlas");
            Assert.IsNotNull(atlasText);
            var pages = AvatarAtlasLoader.ParsePageNames(atlasText.text);
            Assert.AreEqual(AvatarAtlasLoader.ExpectedPageCount, pages.Length);
            Assert.AreEqual(pages.Length, pages.Distinct().Count());

            var shader = Shader.Find("Spine/Skeleton");
            Assert.IsNotNull(shader);
            var supplied = new Texture2D(2, 2, TextureFormat.RGBA32, false);
            var real = new Dictionary<string, Texture2D> { { pages[0], supplied } };

            var asset = AvatarAtlasLoader.Create(atlasText, shader, real, out var materials);
            try
            {
                var atlas = asset.GetAtlas();
                Assert.AreEqual(AvatarAtlasLoader.ExpectedPageCount, atlas.Pages.Count);
                Assert.AreEqual(AvatarAtlasLoader.ExpectedPageCount, materials.Count);
                Assert.AreSame(supplied, materials[pages[0]].mainTexture);
                Assert.AreEqual(pages[0], supplied.name);
                Assert.Zero(atlas.Pages.Count(page => page.rendererObject == null));
            }
            finally
            {
                foreach (var material in materials.Values)
                {
                    if (material.mainTexture != supplied) Object.DestroyImmediate(material.mainTexture);
                    Object.DestroyImmediate(material);
                }
                Object.DestroyImmediate(supplied);
                Object.DestroyImmediate(asset);
            }
        }
    }
}
