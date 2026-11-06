using System.Collections;
using AvatarWorld.Runtime;
using NUnit.Framework;
using Spine.Unity;
using UnityEngine;
using UnityEngine.TestTools;

namespace AvatarWorld.PlayModeTests
{
    /// <summary>Ambientes do original montados em runtime: sprites, Spine, camera.</summary>
    public class SceneSlicePlayTests
    {
        [UnityTest]
        public IEnumerator Scene_BuildsSpritesAndSpinesAndKeepsCameraInsideBounds()
        {
            const int levelType = 1; // GirlsLivingRoom_Z1B1L1: portas/fogao/chuveiro em Spine
            var host = new GameObject("SceneSliceTest");
            var scene = host.AddComponent<SceneSliceRuntime>();
            bool ready = false;
            Assert.IsTrue(scene.Begin(levelType, () => { }, () => ready = true));
            for (int i = 0; i < 600 && !ready; i++) yield return null;
            Assert.IsTrue(ready, "cena nao ficou pronta");
            yield return null;

            int sprites = host.GetComponentsInChildren<SpriteRenderer>().Length;
            int spines = host.GetComponentsInChildren<SkeletonAnimation>().Length;
            Assert.AreEqual(scene.Data.renderers.Count, sprites);
            Assert.Greater(spines, 20, "esqueletos Spine da cena");
            var cam = scene.SceneCamera.transform.position;
            Assert.GreaterOrEqual(cam.x, scene.Data.minX);
            Assert.LessOrEqual(cam.x, scene.Data.maxX);
            Object.Destroy(host);
        }

        [Test]
        public void Begin_ReturnsFalseForLevelWithoutScene()
        {
            var host = new GameObject("SceneSliceNone");
            Assert.IsFalse(host.AddComponent<SceneSliceRuntime>().Begin(999999, () => { }));
            Object.DestroyImmediate(host);
        }
    }
}
