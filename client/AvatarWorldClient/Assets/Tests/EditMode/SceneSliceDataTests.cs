using AvatarWorld.Core.Spine;
using System.Linq;
using AvatarWorld.Runtime;
using NUnit.Framework;
using UnityEngine;

namespace AvatarWorld.Core.Tests
{
    public class SceneSliceDataTests
    {
        [Test]
        public void Index_CoversEveryMapBuildingWithAScene()
        {
            var world = JsonUtility.FromJson<WorldMapData>(Resources.Load<TextAsset>("WorldSlice/world").text);
            foreach (var level in world.buildings.Select(b => b.defaultLevel).Where(l => l != 0).Distinct())
                Assert.IsTrue(SceneSliceRuntime.Has(level), "LevelType " + level + " sem ambiente importado");
        }

        [Test]
        public void Scenes_HaveUniqueRanksAndLoadableSprites()
        {
            foreach (var entry in SceneSliceRuntime.Index.scenes)
            {
                var data = JsonUtility.FromJson<SceneSliceData>(Resources.Load<TextAsset>("Scenes/" + entry.name + "/scene").text);
                Assert.AreEqual(entry.renderers, data.renderers.Count, entry.name);
                Assert.AreEqual(data.renderers.Count, data.renderers.Select(r => r.rank).Distinct().Count(), entry.name);
                Assert.Less(data.minX, data.maxX, entry.name);
                // amostra: primeiro, meio e ultimo sprite de cada cena
                foreach (var r in new[] { data.renderers[0], data.renderers[data.renderers.Count / 2], data.renderers.Last() })
                    Assert.IsNotNull(Resources.Load<Texture2D>("Scenes/" + entry.name + "/sprites/" + r.sprite), entry.name + "/" + r.sprite);
            }
        }

        [Test]
        public void Scenes_SpinesReferenceRenderableSkeletonsWithUniqueRanks()
        {
            int total = 0;
            foreach (var entry in SceneSliceRuntime.Index.scenes)
            {
                var data = JsonUtility.FromJson<SceneSliceData>(Resources.Load<TextAsset>("Scenes/" + entry.name + "/scene").text);
                var ranks = data.renderers.Select(r => r.rank).Concat(data.spines.Select(s => s.rank)).ToList();
                Assert.AreEqual(ranks.Count, ranks.Distinct().Count(), entry.name + ": rank repetido entre sprites e spines");
                foreach (var sp in data.spines)
                {
                    SpineEntry e;
                    Assert.IsTrue(SpineLibrary.Index.TryGet(sp.skeleton, out e), entry.name + ": " + sp.skeleton);
                    Assert.IsTrue(e.renderable, entry.name + ": " + sp.skeleton + " sem atlas");
                    total++;
                }
            }
            Assert.AreEqual(275, total);
        }
    }
}
