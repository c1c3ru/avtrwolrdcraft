using System.Collections;
using System.Linq;
using AvatarWorld.Core.Spine;
using AvatarWorld.Runtime;
using NUnit.Framework;
using Spine.Unity;
using UnityEngine;
using UnityEngine.TestTools;

namespace AvatarWorld.PlayModeTests
{
    /// <summary>Esqueletos reais do original carregados pelo Unity (esqueleto + atlas + texturas exatas).</summary>
    public class SpineLibraryPlayTests
    {
        [UnityTest]
        public IEnumerator SampledSkeletonsLoadAndMatchTheIndependentParse()
        {
            yield return null;
            var index = SpineLibrary.Index;
            Assert.IsNotNull(index);
            var all = index.All.Where(e => e.renderable).OrderBy(e => e.name, System.StringComparer.OrdinalIgnoreCase).ToList();
            var sample = all.Where((e, i) => i % 6 == 0).ToList();
            Assert.Greater(sample.Count, 80);
            int compared = 0;
            for (int n = 0; n < sample.Count; n++)
            {
                var e = sample[n];
                var asset = SpineLibrary.Load(e.name);
                Assert.IsNotNull(asset, e.name);
                var data = asset.GetSkeletonData(false);
                Assert.IsNotNull(data, e.name + " SkeletonData");
                if (e.animations >= 0)
                {
                    Assert.AreEqual(e.animations, data.Animations.Count, e.name + " animacoes (parse independente x Unity)");
                    Assert.AreEqual(e.bones, data.Bones.Count, e.name + " ossos");
                    compared++;
                }
                if (n % 15 == 0) yield return null;
            }
            Assert.Greater(compared, 70);
        }

        [UnityTest]
        public IEnumerator LoadedSkeletonPlaysItsAnimationsOnARealSkeletonAnimation()
        {
            yield return null;
            var asset = SpineLibrary.Load("Pet_Dog_Spine");
            Assert.IsNotNull(asset);
            var go = new GameObject("DogTest");
            var anim = SkeletonAnimation.AddToGameObject(go, asset);
            anim.Initialize(false);
            Assert.IsTrue(anim.valid);
            Assert.IsNotNull(anim.Skeleton.Data.FindAnimation("General/Standing_Idle"));
            anim.AnimationState.SetAnimation(0, "General/Walking", true);
            anim.Update(0.1f);
            Assert.AreEqual("General/Walking", anim.AnimationState.GetCurrent(0).Animation.Name);
            Object.Destroy(go);
        }

        [UnityTest]
        public IEnumerator UnknownAndLogicOnlySkeletonsAreRejected()
        {
            yield return null;
            LogAssert.Expect(LogType.Error, "SpineLibrary: esqueleto desconhecido: NaoExiste");
            Assert.IsNull(SpineLibrary.Load("NaoExiste"));
            LogAssert.Expect(LogType.Error, "SpineLibrary: esqueleto sem atlas (so logica): Hoop_L155");
            Assert.IsNull(SpineLibrary.Load("Hoop_L155"));
        }

        [UnityTest]
        public IEnumerator NameWithSpacesLoadsItsPage()
        {
            yield return null;
            var asset = SpineLibrary.Load("PE34 - Electric Scooter");
            Assert.IsNotNull(asset);
            Assert.IsNotNull(asset.GetSkeletonData(false));
        }
    }
}
