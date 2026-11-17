using System.IO;
using AvatarWorld.Runtime;
using NUnit.Framework;
using UnityEngine;

namespace AvatarWorld.Core.Tests
{
    /// <summary>
    /// Atlases Spine dos mapas/interiores com mais de uma pagina (Pendolum 3, C_Scissors 20, Scissors_Z1B5L1 2, Skeleton_L11 2).
    /// Com um Material so, as paginas extras geravam no aparelho "Material with texture name ... not found for atlas asset".
    /// </summary>
    public class MapSpineAtlasPagesTests
    {
        static readonly (string skeleton, int pages)[] MultiPage =
        {
            ("Pendolum", 3), ("C_Scissors", 20), ("Scissors_Z1B5L1", 2), ("Skeleton_L11", 2),
        };

        [Test]
        public void MultiPageAtlasGetsOneStraightAlphaMaterialPerPageWithTheRealTexture()
        {
            var shader = Shader.Find("Spine/Skeleton");
            Assert.IsNotNull(shader, "shader Spine/Skeleton");
            foreach (var (skeleton, pageCount) in MultiPage)
            {
                var atlas = Resources.Load<TextAsset>("MapSpine/" + skeleton + "/" + skeleton + ".atlas");
                Assert.IsNotNull(atlas, skeleton + " atlas");
                var pages = AvatarAtlasLoader.ParsePageNames(atlas.text);
                Assert.AreEqual(pageCount, pages.Length, skeleton + ": paginas no atlas");

                var materials = MapSpineLayer.CreateMaterials(shader, skeleton, atlas.text);

                Assert.AreEqual(pageCount, materials.Length, skeleton + ": um material por pagina");
                for (int i = 0; i < materials.Length; i++)
                {
                    Assert.AreEqual(pages[i], materials[i].mainTexture.name, skeleton + ": o Spine liga a pagina pelo nome da textura");
                    Assert.Greater(materials[i].mainTexture.width, 1, skeleton + "/" + pages[i] + ": textura real, nao o pixel de reserva");
                    Assert.AreEqual(1f, materials[i].GetFloat("_StraightAlphaInput"), pages[i] + ": alfa direto");
                    Object.DestroyImmediate(materials[i]);
                }
            }
        }

        [Test]
        public void EveryPageOfEveryMapSpineAtlasExistsInMapSpineOrSpineFolder()
        {
            var resources = Path.Combine(Application.dataPath, "Resources");
            var missing = new System.Collections.Generic.List<string>();
            int atlases = 0;
            foreach (var atlasPath in Directory.GetFiles(Path.Combine(resources, "MapSpine"), "*.atlas.txt", SearchOption.AllDirectories))
            {
                atlases++;
                var skeleton = Path.GetFileName(Path.GetDirectoryName(atlasPath));
                foreach (var page in AvatarAtlasLoader.ParsePageNames(File.ReadAllText(atlasPath)))
                {
                    bool inMap = File.Exists(Path.Combine(resources, "MapSpine", skeleton, page + ".png"));
                    bool inSpine = File.Exists(Path.Combine(resources, "Spine", skeleton, page + ".png"));
                    if (!inMap && !inSpine) missing.Add(skeleton + "/" + page);
                }
            }
            Assert.Greater(atlases, 100, "esperava os atlases de MapSpine (130 na exportacao atual)");
            Assert.IsEmpty(missing, "paginas de atlas sem textura: " + string.Join(", ", missing));
        }
    }
}
