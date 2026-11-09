using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using AvatarWorld.Core.Spine;
using NUnit.Framework;
using UnityEngine;

namespace AvatarWorld.Core.Tests
{
    /// <summary>Indice dos esqueletos do original (Resources/Spine/spine-index.json, tools/import_spine_original.py).</summary>
    public class SpineIndexTests
    {
        static SpineIndex _index;
        static string SpineDir { get { return Path.Combine(Application.dataPath, "Resources/Spine"); } }

        static SpineIndex Index
        {
            get
            {
                if (_index == null)
                {
                    string path = Path.Combine(SpineDir, "spine-index.json");
                    Assert.IsTrue(File.Exists(path), path);
                    _index = new SpineIndex(JsonUtility.FromJson<SpineIndexData>(File.ReadAllText(path)));
                }
                return _index;
            }
        }

        [Test]
        public void IndexHasEverySkeletonThatShipsWithData()
        {
            Assert.AreEqual(584, Index.Count);
            Assert.AreEqual(576, Index.All.Count(e => e.renderable));
            Assert.AreEqual(8, Index.All.Count(e => !e.renderable));
            Assert.AreEqual(2945, Index.All.Sum(e => e.pages));
        }

        [Test]
        public void LogicOnlySkeletonsAreTheOnesWithoutAtlas()
        {
            foreach (var n in new[] { "Hoop_L155", "Ramp_L155", "Stepping_Stones_L154", "Shoe_Display_Base_P163", "Tackle_Dummy_P205",
                                      "Vehicle_Empty", "Rocking_Chair_L209", "Hopscotch_L210_Avatar_Mover" })
            {
                SpineEntry e;
                Assert.IsTrue(Index.TryGet(n, out e), n);
                Assert.IsFalse(e.renderable, n);
            }
        }

        [Test]
        public void EverySkeletonHasItsFilesAndEveryAtlasPageHasItsTexture()
        {
            foreach (var e in Index.All)
            {
                string dir = Path.Combine(SpineDir, e.folder);
                string skel = Path.Combine(dir, e.folder + ".skel.bytes");
                Assert.IsTrue(File.Exists(skel), e.name + " skel");
                Assert.Greater(new FileInfo(skel).Length, 0L, e.name);
                if (!e.renderable) continue;
                string atlas = Path.Combine(dir, e.folder + ".atlas.txt");
                Assert.IsTrue(File.Exists(atlas), e.name + " atlas");
                var pages = File.ReadAllLines(atlas).Select(l => l.Trim()).Where(l => l.EndsWith(".png", System.StringComparison.OrdinalIgnoreCase)).ToArray();
                Assert.AreEqual(e.pages, pages.Length, e.name + " paginas");
                foreach (var p in pages) Assert.IsTrue(File.Exists(Path.Combine(dir, p)), e.name + " pagina " + p);
            }
        }

        [Test]
        public void ScaleAndMixComeFromTheOriginalAssets()
        {
            SpineEntry e;
            Assert.IsTrue(Index.TryGet("Pet_Dog_Spine", out e));
            Assert.AreEqual(0.01f, e.scale, 1e-6f);
            Assert.Greater(e.animations, 100);
        }

        [Test]
        public void DuplicatedNamesKeepBothVariantsAndThePlainNameIsTheMostUsed()
        {
            SpineEntry plain, other;
            Assert.IsTrue(Index.TryGet("Balloons_Birthday", out plain));
            Assert.IsTrue(Index.All.Any(e => e.name.StartsWith("Balloons_Birthday__")));
            other = Index.All.First(e => e.name.StartsWith("Balloons_Birthday__"));
            Assert.Greater(plain.sceneInstances, other.sceneInstances);
        }

        [Test]
        public void NamesWithSpacesKeepTheExactAtlasPageFileName()
        {
            SpineEntry e;
            Assert.IsTrue(Index.TryGet("PE34 - Electric Scooter", out e));
            Assert.IsTrue(File.Exists(Path.Combine(SpineDir, e.folder, "PE34 - Electric Scooter.png")));
        }
    }
}
