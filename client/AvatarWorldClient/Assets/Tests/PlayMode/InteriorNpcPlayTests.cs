#if UNITY_EDITOR
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using AvatarWorld.Core.Avatar;
using AvatarWorld.Core.Economy;
using AvatarWorld.Runtime;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace AvatarWorld.PlayModeTests
{
    /// <summary>
    /// Interior real (Resources) com o avatar do jogador: SpawnNpcs desenha um sprite por NPC do *_npcs.json e CaptureLook
    /// aplica as pecas extras (bochechas, meias...) sem corromper o avatar do jogador. Precisa de GPU (RenderTexture).
    /// </summary>
    public class InteriorNpcPlayTests
    {
        const string Key = "family_house_t1s1"; // 2 NPCs, ambos com pecas extras
        [Serializable] class NpcEntry { public int id; public float x, y; }
        [Serializable] class NpcFile { public List<NpcEntry> npcs = new List<NpcEntry>(); }

        string _dir;
        GameObject _host;

        [SetUp]
        public void SetUp() => _dir = Path.Combine(Path.GetTempPath(), "aw-npc-play-" + Guid.NewGuid().ToString("N"));

        [TearDown]
        public void TearDown()
        {
            if (_host != null) UnityEngine.Object.Destroy(_host);
            try { if (Directory.Exists(_dir)) Directory.Delete(_dir, true); } catch (IOException) { }
        }

        IEnumerator OpenInterior(Action<InteriorRuntime, AvatarGpuRuntime> ready)
        {
            Directory.CreateDirectory(_dir);
            var saves = new SaveStore(Path.Combine(_dir, "save.json"));
            var state = saves.LoadOrCreate(30);
            _host = new GameObject("Interior_" + Key);
            var interior = _host.AddComponent<InteriorRuntime>();
            interior.Begin(Key, saves, state, () => { });
            AvatarGpuRuntime avatar = null;
            float t = 0f;
            while (t < 60f && (avatar == null || !avatar.IsReady)) { avatar = _host.GetComponentInChildren<AvatarGpuRuntime>(); t += Time.unscaledDeltaTime; yield return null; }
            Assert.IsNotNull(avatar, "avatar do jogador nao nasceu");
            Assert.IsTrue(avatar.IsReady, "avatar nao ficou pronto em 60 s");
            ready(interior, avatar);
        }

        static int ExpectedNpcCount() => JsonUtility.FromJson<NpcFile>(Resources.Load<TextAsset>("Interiors/" + Key + "/" + Key + "_npcs").text).npcs.Count;

        static int OpaquePixels(Sprite s)
        {
            int n = 0;
            foreach (var c in s.texture.GetPixels32()) if (c.a > 8) n++;
            return n;
        }

        static long Difference(Sprite a, Sprite b)
        {
            var pa = a.texture.GetPixels32(); var pb = b.texture.GetPixels32();
            Assert.AreEqual(pa.Length, pb.Length);
            long d = 0;
            for (int i = 0; i < pa.Length; i++) d += Mathf.Abs(pa[i].r - pb[i].r) + Mathf.Abs(pa[i].g - pb[i].g) + Mathf.Abs(pa[i].b - pb[i].b) + Mathf.Abs(pa[i].a - pb[i].a);
            return d;
        }

        [UnityTest]
        public IEnumerator SpawnNpcs_DrawsOneVisibleSpritePerNpcInTheSceneFile()
        {
            LogAssert.ignoreFailingMessages = true; // materiais Spine em batchmode geram avisos alheios ao teste
            yield return OpenInterior((_, __) => { });
            int expected = ExpectedNpcCount();
            Transform root = null;
            float t = 0f;
            while (t < 90f)
            {
                root = _host.transform.Find("NPCs");
                if (root != null && root.childCount >= expected) break;
                t += Time.unscaledDeltaTime; yield return null;
            }
            Assert.IsNotNull(root, "grupo NPCs nao foi criado");
            Assert.AreEqual(expected, root.childCount, "NPCs desenhados x NPCs do JSON");
            var file = JsonUtility.FromJson<NpcFile>(Resources.Load<TextAsset>("Interiors/" + Key + "/" + Key + "_npcs").text);
            foreach (var npc in file.npcs)
            {
                var go = root.Find("NPC_" + npc.id);
                Assert.IsNotNull(go, "NPC_" + npc.id);
                Assert.AreEqual(npc.x, go.position.x, 0.001f);
                Assert.AreEqual(npc.y, go.position.y, 0.001f);
                var sr = go.GetComponent<SpriteRenderer>();
                Assert.IsNotNull(sr.sprite);
                Assert.Greater(OpaquePixels(sr.sprite), 500, "NPC_" + npc.id + " saiu transparente");
            }
        }

        [UnityTest]
        public IEnumerator CaptureLook_ExtrasChangeTheImageAndLeavePlayerAvatarUntouched()
        {
            LogAssert.ignoreFailingMessages = true;
            AvatarGpuRuntime avatar = null;
            yield return OpenInterior((_, a) => avatar = a);
            yield return null;
            var before = avatar.CurrentAppearance.Clone();

            Func<List<ExtraItem>, AvatarAppearance> look = extras =>
            {
                var a = AvatarAppearance.CreateDefault();
                a.Extras = extras;
                return a;
            };
            var plain = avatar.CaptureLook(look(null));
            var withSocks = avatar.CaptureLook(look(new List<ExtraItem> { new ExtraItem { Id = "legs_socks_20", Tint = new float[0] } }));
            var unknown = avatar.CaptureLook(look(new List<ExtraItem> { new ExtraItem { Id = "nao_existe_xyz", Tint = new float[0] } }));
            var nullId = avatar.CaptureLook(look(new List<ExtraItem> { new ExtraItem { Id = null, Tint = new float[0] } }));

            Assert.IsNotNull(plain); Assert.IsNotNull(withSocks);
            Assert.Greater(OpaquePixels(plain), 500);
            Assert.Greater(Difference(plain, withSocks), 0, "meias extras nao alteraram a imagem");
            Assert.IsNotNull(unknown, "id de extra desconhecido nao pode derrubar a captura");
            Assert.AreEqual(0, Difference(plain, unknown), "extra desconhecido deveria ser ignorado");
            Assert.IsNotNull(nullId, "Id nulo nao pode derrubar a captura (regressao do bug Id/id)");
            Assert.IsTrue(avatar.CurrentAppearance.SameAs(before), "CaptureLook alterou a aparencia do jogador");
            Assert.IsNull(avatar.CurrentAppearance.Extras, "extras vazaram para o avatar do jogador");
        }

        [UnityTest]
        public IEnumerator CaptureLook_TintChangesTheExtraColor()
        {
            LogAssert.ignoreFailingMessages = true;
            AvatarGpuRuntime avatar = null;
            yield return OpenInterior((_, a) => avatar = a);
            yield return null;
            Func<float[], Sprite> shot = tint =>
            {
                var a = AvatarAppearance.CreateDefault();
                a.Extras = new List<ExtraItem> { new ExtraItem { Id = "legs_socks_20", Tint = tint } };
                return avatar.CaptureLook(a);
            };
            var red = shot(new[] { 1f, 0f, 0f });
            var blue = shot(new[] { 0f, 0f, 1f });
            Assert.Greater(Difference(red, blue), 0, "tintas diferentes deram a mesma imagem");
        }
    }
}
#endif
