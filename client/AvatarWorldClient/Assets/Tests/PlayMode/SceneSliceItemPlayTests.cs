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
        [Ignore("WIP: areas largas do cenario aceitam o item; regra de LevelDropAreaQuery ainda nao reproduzida")]
        public IEnumerator Drag_IntoVoid_ReturnsItemToStart()
        {
            SceneSliceRuntime scene = null;
            yield return Build(s => scene = s);
            int item = PickableItem(scene, b => true, out var b);
            Assert.GreaterOrEqual(item, 0);
            yield return null;
            var start = scene.ItemRoots[item].position;
            // solta 4,2 unidades acima, longe de qualquer superficie de apoio
            yield return Drag(scene, b.center, b.center + new Vector3(0f, 4.2f, 0f));
            Assert.AreEqual(-1, scene.DraggingItem);
            Assert.Less(Vector3.Distance(scene.ItemRoots[item].position, start), 0.05f, "volta ao ponto inicial");
            Object.Destroy(scene.gameObject);
        }

        [UnityTest]
        [Ignore("WIP: areas largas do cenario aceitam o item; regra de LevelDropAreaQuery ainda nao reproduzida")]
        public IEnumerator Drag_OntoDropArea_RestsOnItsSurface()
        {
            SceneSliceRuntime scene = null;
            yield return Build(s => scene = s);
            var area = scene.DropAreas.Where(a => a.MaxX - a.MinX > 1.5f && a.MaxY - a.MinY > 0.2f).OrderByDescending(a => a.Priority).First();
            int item = PickableItem(scene, bb => bb.size.x < 1.5f && !area.Contains(bb.center.x, bb.min.y), out var b);
            Assert.GreaterOrEqual(item, 0);
            float tx = (area.MinX + area.MaxX) * 0.5f;
            Assert.IsTrue(area.TopAt(tx, out float top));
            yield return null;
            scene.TryGetItemBounds(item, out b);
            var to = new Vector3(tx, top + b.extents.y + 0.1f, 0f);
            yield return Drag(scene, b.center, to);
            scene.TryGetItemBounds(item, out var after);
            Assert.AreEqual(top, after.min.y, 0.06f, "apoiado na superficie da area");
            Assert.AreEqual(tx, after.center.x, 0.2f);
            Object.Destroy(scene.gameObject);
        }
    }
}
