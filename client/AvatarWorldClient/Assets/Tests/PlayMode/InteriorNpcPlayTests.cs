#if UNITY_EDITOR
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using AvatarWorld.Core.Avatar;
using AvatarWorld.Core.Economy;
using AvatarWorld.Runtime;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace AvatarWorld.PlayModeTests
{
    /// <summary>
    /// NPCs dos interiores: cada "look" exportado em Resources/Interiors/*/*_npcs.json precisa virar um sprite via o mesmo caminho do
    /// jogo (InteriorRuntime.ToAppearance -> AvatarGpuRuntime.CaptureLook). No aparelho quase todos falhavam com
    /// "ArgumentNullException: Value cannot be null. Parameter name: key".
    /// </summary>
    public class InteriorNpcPlayTests
    {
        static readonly string[] SampleInteriors = { "bakery_build_t1s3", "courthouse_t1s4", "hospital_t1s4" };

        [UnityTest, Timeout(600000)]
        public IEnumerator EveryNpcLookInSampleInteriorsCanBeCaptured()
        {
            var state = PlayerState.CreateNew(0);
            var saves = new SaveStore(Path.Combine(Application.temporaryCachePath, "interior_npc_playtest_save.json"));
            var host = new GameObject("NpcTestAvatar");
            var avatar = host.AddComponent<AvatarGpuRuntime>();
            avatar.ConfigureAsWorldAvatar(saves, state, Vector3.zero, 1f, 10);
            float waited = 0f;
            while (!avatar.IsReady && waited < 120f) { waited += Time.unscaledDeltaTime; yield return null; }
            Assert.IsTrue(avatar.IsReady, "avatar do jogador pronto");
            yield return null;

            var runtime = typeof(InteriorRuntime);
            var fileType = runtime.GetNestedType("NpcFile", BindingFlags.NonPublic);
            var toAppearance = runtime.GetMethod("ToAppearance", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.IsNotNull(fileType, "InteriorRuntime.NpcFile");
            Assert.IsNotNull(toAppearance, "InteriorRuntime.ToAppearance");

            var failures = new List<string>();
            int total = 0;
            foreach (var key in SampleInteriors)
            {
                var json = Resources.Load<TextAsset>("Interiors/" + key + "/" + key + "_npcs");
                Assert.IsNotNull(json, key + " _npcs.json");
                var file = JsonUtility.FromJson(json.text, fileType);
                var npcs = (IList)fileType.GetField("npcs").GetValue(file);
                foreach (var npc in npcs)
                {
                    total++;
                    var id = npc.GetType().GetField("id").GetValue(npc);
                    var look = npc.GetType().GetField("look").GetValue(npc);
                    try
                    {
                        var appearance = (AvatarAppearance)toAppearance.Invoke(null, new[] { look });
                        var sprite = avatar.CaptureLook(appearance);
                        if (sprite == null) failures.Add(key + " NPC " + id + ": CaptureLook devolveu null");
                    }
                    catch (TargetInvocationException e) { failures.Add(key + " NPC " + id + ": " + e.InnerException); }
                    catch (Exception e) { failures.Add(key + " NPC " + id + ": " + e); }
                    yield return null;
                }
            }
            UnityEngine.Object.Destroy(host);
            if (failures.Count > 0)
                File.WriteAllText(Path.Combine(Application.temporaryCachePath, "interior_npc_failures.txt"), string.Join("\n----\n", failures));
            Assert.IsEmpty(failures, failures.Count + " de " + total + " NPCs falharam. Primeira falha:\n" + (failures.Count > 0 ? failures[0] : ""));
        }
    }
}
#endif
