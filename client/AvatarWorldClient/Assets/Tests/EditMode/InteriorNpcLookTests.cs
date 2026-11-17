using System.Collections;
using System.Reflection;
using AvatarWorld.Core.Avatar;
using AvatarWorld.Runtime;
using NUnit.Framework;
using UnityEngine;

namespace AvatarWorld.Core.Tests
{
    /// <summary>
    /// Os looks de NPC exportados (Resources/Interiors/*/*_npcs.json, gerados por tools/build_npc_looks.py) viram AvatarAppearance em
    /// InteriorRuntime.ToAppearance. O exportador grava os extras como {id, tint} (minusculas); um tipo com Id/Tint deixava todos os ids
    /// nulos e, no aparelho, RebuildSkin estourava (Parameter name: key) e quase nenhum NPC era desenhado.
    /// </summary>
    public class InteriorNpcLookTests
    {
        static readonly BindingFlags NonPublic = BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public;

        [Test]
        public void EveryNpcExtraKeepsItsIdAndTintAfterConversion()
        {
            var runtime = typeof(InteriorRuntime);
            var fileType = runtime.GetNestedType("NpcFile", NonPublic);
            var toAppearance = runtime.GetMethod("ToAppearance", NonPublic);
            Assert.IsNotNull(fileType, "InteriorRuntime.NpcFile");
            Assert.IsNotNull(toAppearance, "InteriorRuntime.ToAppearance");

            int npcs = 0, extras = 0;
            foreach (var asset in Resources.LoadAll<TextAsset>("Interiors"))
            {
                if (!asset.name.EndsWith("_npcs")) continue;
                var file = JsonUtility.FromJson(asset.text, fileType);
                foreach (var npc in (IList)fileType.GetField("npcs").GetValue(file))
                {
                    var look = npc.GetType().GetField("look").GetValue(npc);
                    var expected = (IList)look.GetType().GetField("extras").GetValue(look);
                    var appearance = (AvatarAppearance)toAppearance.Invoke(null, new[] { look });
                    npcs++;
                    Assert.IsNotNull(appearance.Extras, asset.name + ": Extras");
                    Assert.AreEqual(expected.Count, appearance.Extras.Count, asset.name + ": todo extra do JSON deve chegar ao NPC");
                    foreach (var extra in appearance.Extras)
                    {
                        extras++;
                        Assert.IsFalse(string.IsNullOrEmpty(extra.Id), asset.name + ": extra sem Id");
                        Assert.IsNotNull(extra.Tint, asset.name + ": extra sem Tint");
                    }
                }
            }
            Assert.Greater(npcs, 300, "esperava os NPCs de todos os interiores exportados");
            Assert.Greater(extras, 500, "esperava os extras (bochechas, meias, bolsas...) dos NPCs");
        }

        [Test]
        public void ConversionDropsAnExtraWithoutIdInsteadOfCrashingTheNpc()
        {
            var runtime = typeof(InteriorRuntime);
            var lookType = runtime.GetNestedType("NpcLook", NonPublic);
            var extraType = runtime.GetNestedType("NpcExtra", NonPublic);
            var toAppearance = runtime.GetMethod("ToAppearance", NonPublic);
            var look = System.Activator.CreateInstance(lookType);
            var list = (IList)lookType.GetField("extras").GetValue(look);
            list.Add(System.Activator.CreateInstance(extraType)); // id nulo
            var good = System.Activator.CreateInstance(extraType);
            extraType.GetField("id").SetValue(good, "face_cheeks_25_color");
            list.Add(good);

            var appearance = (AvatarAppearance)toAppearance.Invoke(null, new[] { look });

            Assert.AreEqual(1, appearance.Extras.Count);
            Assert.AreEqual("face_cheeks_25_color", appearance.Extras[0].Id);
        }
    }
}
