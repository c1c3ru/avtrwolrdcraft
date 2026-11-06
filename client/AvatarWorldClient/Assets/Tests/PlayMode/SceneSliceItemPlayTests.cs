using System.Collections;
using System.Linq;
using AvatarWorld.Runtime;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace AvatarWorld.PlayModeTests
{
    /// <summary>Itens arrastaveis dos ambientes: arrastar, soltar numa area, voltar quando solto fora de area.</summary>
    public class SceneSliceItemPlayTests
    {
        const int Room = 1; // GirlsLivingRoom_Z1B1L1

        static IEnumerator Build(System.Action<SceneSliceRuntime> got)
        {
            var host = new GameObject("SceneItemsTest");
            var scene = host.AddComponent<SceneSliceRuntime>();
            bool ready = false;
            Assert.IsTrue(scene.Begin(Room, () => { }, () => ready = true));
            for (int i = 0; i < 900 && !ready; i++) yield return null;
            Assert.IsTrue(ready);
            yield return null;
            got(scene);
        }

        static Vector2 Screen(SceneSliceRuntime s, Vector3 world) => s.SceneCamera.WorldToScreenPoint(world);

        static IEnumerator Drag(SceneSliceRuntime s, Vector3 fromWorld, Vector3 toWorld)
        {
            var a = Screen(s, fromWorld); var b = Screen(s, toWorld);
            s.Step(true, true, false, a); yield return null;
            for (int i = 1; i <= 6; i++) { s.Step(false, true, false, Vector2.Lerp(a, b, i / 6f)); yield return null; }
            s.Step(false, false, true, b);
            yield return new WaitForSecondsRealtime(0.4f);
        }

        // item cujo ponto central e o mais alto na ordem de desenho (o toque o escolhe) e com caixa util
        static int PickableItem(SceneSliceRuntime s, System.Func<Bounds, bool> accept, out Bounds bounds)
        {
            bounds = default;
            for (int i = 0; i < s.ItemRoots.Count; i++)
            {
                if (!s.TryGetItemBounds(i, out var b) || b.size.x < 0.3f || b.size.y < 0.3f || !accept(b)) continue;
                var cam = s.SceneCamera.transform;
                cam.position = new Vector3(b.center.x, 0f, -10f);
                // o ponto central deve resolver para este mesmo item (nao ser coberto por outro)
                var a = s.SceneCamera.WorldToScreenPoint(b.center);
                s.Step(true, true, false, a);
                int grabbed = s.GrabbedItem;
                s.Step(false, false, true, a);
                if (grabbed == i) { bounds = b; return i; }
            }
            return -1;
        }

        [UnityTest]
        public IEnumerator Items_AreBuiltAsRootsWithRenderers()
        {
            SceneSliceRuntime scene = null;
            yield return Build(s => scene = s);
            Assert.Greater(scene.Data.items.Count, 20);
            Assert.AreEqual(scene.Data.items.Count, scene.ItemRoots.Count);
            Assert.Greater(scene.DropAreas.Count, 10);
            Assert.AreEqual(scene.ItemRoots.Count, scene.ItemRoots.Count(t => t.childCount > 0), "todo item exportado tem sprites");
            Object.Destroy(scene.gameObject);
        }

        [UnityTest]
        public IEnumerator Drag_OutsideEveryAreaInX_ReturnsItemToStart()
        {
            SceneSliceRuntime scene = null;
            yield return Build(s => scene = s);
            int item = PickableItem(scene, b => true, out var b);
            Assert.GreaterOrEqual(item, 0);
            var start = scene.ItemRoots[item].position;
            // solta alem da borda direita de qualquer area: nenhuma sobrepoe a base em X, entao nada serve
            float far = scene.DropAreas.Max(a => a.MaxX) + 30f;
            scene.SceneCamera.transform.position = new Vector3(b.center.x, 0f, -10f);
            var to = new Vector3(far, b.center.y, 0f);
            // arrasto em passos de tela curtos para chegar la; usa o proprio mecanismo de Step
            var a0 = Screen(scene, b.center);
            scene.Step(true, true, false, a0); yield return null;
            scene.Step(false, true, false, a0 + new Vector2(40f, 0f)); yield return null; // passa do limiar
            Assert.AreEqual(item, scene.DraggingItem);
            scene.ItemRoots[item].position = start + new Vector3(far - b.center.x, 0f, 0f);
            scene.Step(false, false, true, a0 + new Vector2(40f, 0f));
            yield return new WaitForSecondsRealtime(0.4f);
            Assert.Less(Vector3.Distance(scene.ItemRoots[item].position, start), 0.05f, "volta ao ponto inicial");
            Object.Destroy(scene.gameObject);
        }

        [UnityTest]
        public IEnumerator Drag_AboveSurface_FallsToTheNearestSurfaceBelow()
        {
            SceneSliceRuntime scene = null;
            yield return Build(s => scene = s);
            int item = PickableItem(scene, b => b.size.x < 1.5f, out var b);
            Assert.GreaterOrEqual(item, 0);
            var a0 = Screen(scene, b.center);
            scene.Step(true, true, false, a0); yield return null;
            scene.Step(false, true, false, a0 + new Vector2(40f, 0f)); yield return null;
            Assert.AreEqual(item, scene.DraggingItem);
            // levanta o item 2 unidades e solta: deve assentar numa superficie, a mais proxima abaixo da base
            var root = scene.ItemRoots[item];
            root.position += new Vector3(0f, 2f, 0f);
            scene.TryGetItemBounds(item, out var raised);
            var info = new AvatarWorld.Core.SceneItems.DropItem { X = raised.center.x, BottomY = raised.min.y, BottomWidth = raised.size.x, Height = raised.size.y };
            var expected = AvatarWorld.Core.SceneItems.DropAreaQuery.FallOn(scene.DropAreas.ToList(), info, info.X, info.BottomY, out float hitY);
            var under = AvatarWorld.Core.SceneItems.DropAreaQuery.Under(scene.DropAreas.ToList(), info, info.X, info.BottomY);
            scene.Step(false, false, true, a0 + new Vector2(40f, 0f));
            yield return new WaitForSecondsRealtime(0.4f);
            scene.TryGetItemBounds(item, out var after);
            if (under != null) Assert.AreEqual(raised.min.y, after.min.y, 0.02f, "ja sobre uma area: fica onde esta");
            else if (expected != null) Assert.AreEqual(hitY, after.min.y, 0.02f, "assenta na superficie da area " + expected.Name);
            else Assert.AreEqual(b.min.y, after.min.y, 0.05f, "sem area: volta");
            Object.Destroy(scene.gameObject);
        }
    }
}
