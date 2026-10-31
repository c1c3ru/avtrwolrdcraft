using System;
using System.Collections.Generic;
using System.Linq;
using Spine;
using Spine.Unity;
using UnityEngine;

namespace AvatarWorld.Runtime
{
    /// <summary>
    /// Validacao no Android do Ciclo 1 (docs/AVATAR_GAMEPLAY_PLAN.md): o mesmo composto corpo/olhos/
    /// cabelo provado no Editor por Assets/Editor/AvatarGpuProbe.cs, agora pelo runtime real em
    /// build de player (sem UnityEditor), carregando os assets de Resources/AvatarSpine em vez de
    /// ler arquivos soltos do disco (que nao existem dentro do APK). Mantido fora da Home/HomeBootstrap
    /// de proposito - isto e so a prova do Ciclo 1, acesso pela Home e um ciclo posterior (4).
    /// </summary>
    public sealed class AvatarGpuRuntime : MonoBehaviour
    {
        static readonly string[] TextureNames = {
            "MultiPack__Body_Outline_31883", "MultiPack__Body_Shadow_87873", "MultiPack__Body_Solid_99707",
            "MultiPack__Ear_Shadow_76723", "Eyes_01_1_Color_21563", "Eyes_01_1_P_18738",
            "Hair_Front_01_Color_56300", "Hair_Front_02_Color_21315",
        };
        // Nome do arquivo do atlas (sem extensao) -> nome do recurso correspondente em TextureNames.
        static readonly Dictionary<string, string> PageToResource = new Dictionary<string, string> {
            { "MultiPack__Body_Outline", "MultiPack__Body_Outline_31883" },
            { "MultiPack__Body_Shadow", "MultiPack__Body_Shadow_87873" },
            { "MultiPack__Body_Solid", "MultiPack__Body_Solid_99707" },
            { "MultiPack__Ear_Shadow", "MultiPack__Ear_Shadow_76723" },
            { "Eyes_01_1_Color", "Eyes_01_1_Color_21563" },
            { "Eyes_01_1_P", "Eyes_01_1_P_18738" },
            { "Hair_Front_01_Color", "Hair_Front_01_Color_56300" },
            { "Hair_Front_02_Color", "Hair_Front_02_Color_21315" },
        };

        void Start()
        {
            Application.SetStackTraceLogType(LogType.Exception, StackTraceLogType.Full);

            var shader = Shader.Find("Spine/Skeleton");
            if (shader == null) { Debug.LogError("AvatarGpuRuntime: shader Spine/Skeleton nao encontrado"); return; }

            var dummyTexture = new Texture2D(2, 2, TextureFormat.RGBA32, false) { name = "__avatar_runtime_unused__" };
            var dummyMaterial = new Material(shader) { mainTexture = dummyTexture };
            var materials = new List<Material> { dummyMaterial };

            foreach (var resourceName in TextureNames)
            {
                var source = Resources.Load<Texture2D>("AvatarSpine/Textures/" + resourceName);
                if (source == null) { Debug.LogError("AvatarGpuRuntime: textura ausente " + resourceName); return; }
                var texture = PremultipliedCopy(source);
                texture.name = PageToResource.First(p => p.Value == resourceName).Key;
                materials.Add(new Material(shader) { mainTexture = texture });
            }

            var atlasText = Resources.Load<TextAsset>("AvatarSpine/Avatar_Spine.atlas");
            var skeletonBinary = Resources.Load<TextAsset>("AvatarSpine/Avatar_Spine.skel");
            if (atlasText == null || skeletonBinary == null)
            {
                Debug.LogError("AvatarGpuRuntime: atlas ou skeleton nao encontrados em Resources/AvatarSpine");
                return;
            }

            var atlasAsset = SpineAtlasAsset.CreateRuntimeInstance(atlasText, materials.ToArray(), true);
            var skeletonDataAsset = SkeletonDataAsset.CreateRuntimeInstance(skeletonBinary, atlasAsset, true, 0.01f);
            var skeletonData = skeletonDataAsset.GetSkeletonData(false);
            if (skeletonData == null) { Debug.LogError("AvatarGpuRuntime: SkeletonData nao carregou"); return; }

            var avatarGo = new GameObject("Avatar");
            avatarGo.transform.SetParent(transform, false);
            var skeletonAnimation = SkeletonAnimation.AddToGameObject(avatarGo, skeletonDataAsset);
            skeletonAnimation.Initialize(false);
            if (!skeletonAnimation.valid) { Debug.LogError("AvatarGpuRuntime: SkeletonAnimation.valid == false"); return; }

            var skin = new Skin("avatar-runtime-composite");
            var tints = new Dictionary<Attachment, Color>();
            AddSkin(skeletonData, skin, tints, "Body_Whites/Body_Whites", new Color(1f, 0.824f, 0.675f));
            AddSkin(skeletonData, skin, tints, "Body_Shad/Body_Shad", new Color(0.824f, 0.569f, 0.435f));
            AddSkin(skeletonData, skin, tints, "Ear_Shad/Ear_Shad", new Color(0.667f, 0.376f, 0.271f));
            AddSkin(skeletonData, skin, tints, "Body_Other/Body_Other", Color.white);
            AddSkin(skeletonData, skin, tints, "Eyes/1_Color", new Color(0.22f, 0.44f, 0.57f));
            AddSkin(skeletonData, skin, tints, "Eyes/1_Color-p", Color.white);
            AddSkin(skeletonData, skin, tints, "Hair_Front/1_Color", new Color(0.31f, 0.16f, 0.12f));
            skeletonAnimation.skeleton.SetSkin(skin);
            skeletonAnimation.skeleton.SetSlotsToSetupPose();
            skeletonAnimation.skeleton.SetAttachment("Mouths", "Body_Outline/Mouth_Regular");
            foreach (var slot in skeletonAnimation.skeleton.Slots)
                if (slot.Attachment != null && tints.TryGetValue(slot.Attachment, out var color))
                { slot.R = color.r; slot.G = color.g; slot.B = color.b; }

            skeletonAnimation.AnimationName = null;
            skeletonAnimation.state.SetAnimation(0, "Idle_Stand_1", true);
            skeletonAnimation.Update(0.1f);
            skeletonAnimation.LateUpdate();

            var meshFilter = avatarGo.GetComponent<MeshFilter>();
            int tris = meshFilter != null && meshFilter.sharedMesh != null ? meshFilter.sharedMesh.triangles.Length / 3 : 0;
            Debug.Log("AvatarGpuRuntime: avatar valido, " + tris + " triangulos reais, animacao Idle_Stand_1 tocando");

            var cam = new GameObject("AvatarCamera", typeof(Camera));
            cam.tag = "MainCamera";
            var camera = cam.GetComponent<Camera>();
            camera.orthographic = true;
            camera.clearFlags = CameraClearFlags.SolidColor;
            camera.backgroundColor = new Color(0.922f, 0.914f, 0.953f, 1f);

            // Enquadra pelos bounds reais do mesh (nao valores fixos no escuro): o skeleton usa
            // escala 0.01, cujo tamanho mundial final depende dos dados reais, nao de suposicao.
            var meshRenderer = avatarGo.GetComponent<MeshRenderer>();
            Bounds bounds = meshRenderer != null ? meshRenderer.bounds : new Bounds(Vector3.zero, Vector3.one);
            float verticalHalf = bounds.extents.y * 1.15f;
            float horizontalHalf = bounds.extents.x * 1.15f / Mathf.Max(camera.aspect, 0.01f);
            camera.orthographicSize = Mathf.Max(verticalHalf, horizontalHalf, 0.01f);
            cam.transform.position = new Vector3(bounds.center.x, bounds.center.y, -10f);
        }

        static Texture2D PremultipliedCopy(Texture2D source)
        {
            var pixels = source.GetPixels32();
            for (int i = 0; i < pixels.Length; i++)
            {
                var p = pixels[i];
                float a = p.a / 255f;
                pixels[i] = new Color32((byte)(p.r * a), (byte)(p.g * a), (byte)(p.b * a), p.a);
            }
            var copy = new Texture2D(source.width, source.height, TextureFormat.RGBA32, false);
            copy.SetPixels32(pixels);
            copy.Apply();
            return copy;
        }

        static void AddSkin(SkeletonData data, Skin composite, Dictionary<Attachment, Color> tints, string name, Color color)
        {
            var source = data.FindSkin(name);
            if (source == null) { Debug.LogError("AvatarGpuRuntime: skin ausente " + name); return; }
            composite.AddSkin(source);
            foreach (var item in source.Attachments) tints[item.Attachment] = color;
        }
    }
}
