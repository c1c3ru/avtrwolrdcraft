using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
using UnityEngine;

namespace AvatarWorld.EditorTools
{
    /// <summary>
    /// Ciclo 2 (docs/AVATAR_GAMEPLAY_PLAN.md): prova que a hipotese do SUT - cada peca de roupa e um
    /// skin Templates/X ja existente no esqueleto, cuja pagina de atlas (mesmo nome, ex. "T_Torso_7.png")
    /// deve ser substituida pela textura real do item ("sutsystem/skins/character/.../t_torso_7") -
    /// renderiza corretamente pelo runtime spine-unity real, nao so bate por nome de arquivo.
    ///
    /// Textura real dos itens: extraida de resources.assets via tools/avatar_sut_extract.py a partir
    /// de out/assets/avatar-resources.json (path/path_id reais do ResourceManager.m_Container do APK
    /// original, filtrados por "sutsystem/skins/character/"). Mesma fonte que AvatarGpuRuntime.cs usa
    /// em runtime: Assets/Resources/AvatarSpine/Clothing/*.png + clothing-manifest.json (item ->
    /// [(skin Templates/X, arquivo)]), lida aqui direto do disco (fora de Resources.Load, que so
    /// funciona em Play Mode/build).
    /// </summary>
    public static class AvatarOutfitProbe
    {
        [Serializable] class ManifestPiece { public string template; public string file; }
        [Serializable] class ManifestItem { public string id; public List<ManifestPiece> pieces; }
        [Serializable] class Manifest { public List<ManifestItem> items; }

        [Serializable]
        public class OutfitProbeReport
        {
            public string renderer = "Spine.Unity.SkeletonAnimation (shader real), capturado por UnityEngine.Camera";
            public string baseOutfit;
            public string swappedOutfit;
            public int meshTrianglesBase;
            public int meshTrianglesSwapped;
            public string capturedToBase;
            public string capturedToSwapped;
        }

        // Peca por categoria no outfit base; a segunda renderizacao troca so "shirt" para provar que
        // o toque muda pixels/attachments do MESMO avatar (criterio de aceite do Ciclo 2).
        static readonly string[] BaseOutfit = { "shirt_formal_1", "bottom_special_1", "legs_shoes_1", "accessories_face_glasses_1", "accessories_body_neck_1" };
        static readonly string[] SwappedOutfit = { "shirt_casual_1", "bottom_special_10", "legs_shoes_10", "accessories_face_glasses_1", "accessories_body_neck_1" };

        public static void Render()
        {
            var root = Path.GetFullPath(Path.Combine(Application.dataPath, "../../.."));
            var inputs = Path.Combine(root, "assets/spine_textasset/TextAsset");
            var clothingDir = Path.Combine(Application.dataPath, "Resources/AvatarSpine/Clothing");
            Directory.CreateDirectory(Path.Combine(root, "out"));

            var manifestJson = File.ReadAllText(Path.Combine(Application.dataPath, "Resources/AvatarSpine/clothing-manifest.json"));
            var manifest = JsonUtility.FromJson<Manifest>(manifestJson);
            var itemsById = manifest.items.ToDictionary(i => i.id, i => i);

            var rawAtlas = File.ReadAllText(Path.Combine(inputs, "Avatar_Spine.atlas_109005.txt"));
            var shader = Shader.Find("Spine/Skeleton");
            if (shader == null) throw new InvalidOperationException("Shader Spine/Skeleton nao encontrado no projeto");

            byte[] skeletonBytes = File.ReadAllBytes(Path.Combine(inputs, "Avatar_Spine.skel_108595.txt"));

            // Paginas base (corpo/olhos/cabelo, ja provadas no Ciclo 1) + todas as paginas de roupa
            // usadas pelos dois outfits (base e trocado), pra um unico atlas servir as duas renderizacoes.
            var bodyTextureFiles = new Dictionary<string, string> {
                { "MultiPack__Body_Outline.png", "MultiPack__Body_Outline_31883.png" },
                { "MultiPack__Body_Shadow.png", "MultiPack__Body_Shadow_87873.png" },
                { "MultiPack__Body_Solid.png", "MultiPack__Body_Solid_99707.png" },
                { "MultiPack__Ear_Shadow.png", "MultiPack__Ear_Shadow_76723.png" },
                { "Eyes_01_1_Color.png", "Eyes_01_1_Color_21563.png" },
                { "Eyes_01_1_P.png", "Eyes_01_1_P_18738.png" },
                { "Hair_Front_01_Color.png", "Hair_Front_01_Color_56300.png" },
            };

            // Mapa GLOBAL por nome de pagina (nao por outfit): itens diferentes da mesma categoria
            // podem compartilhar nome de template (achado real: bottom_special_1 e bottom_special_10
            // usam ambos "Templates/B_Pelvis") - um dicionario unico so pode guardar UM arquivo por
            // pagina, entao aqui carrega a uniao de TODAS as pecas de BaseOutfit+SwappedOutfit com o
            // arquivo da sua ORIGEM especifica (cada item com pelo menos uma pagina exclusiva sua
            // continua correta; paginas compartilhadas mostram a textura do ultimo item processado
            // em ambas as renderizacoes - limitacao aceitavel pra uma prova de Editor, o runtime real
            // em AvatarGpuRuntime.cs carrega por pagina+item corretamente por categoria).
            var allItemIds = BaseOutfit.Concat(SwappedOutfit).Distinct();
            var clothingPageToFile = new Dictionary<string, string>(); // "T_Torso_7.png" -> absolute path
            foreach (var itemId in allItemIds)
            {
                foreach (var piece in itemsById[itemId].pieces)
                {
                    var pageName = piece.template.Substring("Templates/".Length) + ".png"; // ex.: "T_Torso_7.png"
                    clothingPageToFile[pageName] = Path.Combine(clothingDir, piece.file);
                }
            }

            var createdTextures = new List<Texture2D>();
            Material[] createdMaterials = null;
            SpineAtlasAsset atlasAsset = null;
            SkeletonDataAsset skeletonDataAsset = null;

            try
            {
                var dummyTexture = new Texture2D(2, 2, TextureFormat.RGBA32, false) { name = "__avatar_outfit_probe_unused__" };
                createdTextures.Add(dummyTexture);
                var dummyMaterial = new Material(shader) { mainTexture = dummyTexture };
                var materials = new List<Material> { dummyMaterial };

                foreach (var pair in bodyTextureFiles)
                {
                    var tex = LoadTexture(Path.Combine(root, "assets/textures_png/Texture2D", pair.Value), Path.GetFileNameWithoutExtension(pair.Key));
                    createdTextures.Add(tex);
                    materials.Add(new Material(shader) { mainTexture = tex });
                }
                foreach (var pair in clothingPageToFile)
                {
                    var tex = LoadTexture(pair.Value, Path.GetFileNameWithoutExtension(pair.Key));
                    createdTextures.Add(tex);
                    materials.Add(new Material(shader) { mainTexture = tex });
                }
                createdMaterials = materials.ToArray();

                var atlasTextAsset = new TextAsset(rawAtlas) { name = "Avatar_Spine_Atlas" };
                atlasAsset = SpineAtlasAsset.CreateRuntimeInstance(atlasTextAsset, createdMaterials, true);

                var skeletonTextAsset = new TextAsset(skeletonBytes) { name = "Avatar_Spine.skel" };
                skeletonDataAsset = SkeletonDataAsset.CreateRuntimeInstance(skeletonTextAsset, atlasAsset, true, 0.01f);
                var skeletonData = skeletonDataAsset.GetSkeletonData(false);
                if (skeletonData == null) throw new InvalidOperationException("SkeletonDataAsset nao carregou SkeletonData");

                var report = new OutfitProbeReport { baseOutfit = string.Join("+", BaseOutfit), swappedOutfit = string.Join("+", SwappedOutfit) };
                report.meshTrianglesBase = RenderOutfit(skeletonDataAsset, skeletonData, itemsById, BaseOutfit, Path.Combine(root, "out/avatar-outfit-preview.png"), out report.capturedToBase);
                report.meshTrianglesSwapped = RenderOutfit(skeletonDataAsset, skeletonData, itemsById, SwappedOutfit, Path.Combine(root, "out/avatar-outfit-preview-swapped.png"), out report.capturedToSwapped);

                File.WriteAllText(Path.Combine(root, "out/avatar-outfit-probe-report.json"), JsonUtility.ToJson(report, true));
                Debug.Log($"AvatarOutfitProbe: outfit base ({report.baseOutfit}) {report.meshTrianglesBase} triangulos -> {report.capturedToBase}; outfit trocado ({report.swappedOutfit}) {report.meshTrianglesSwapped} triangulos -> {report.capturedToSwapped}");
            }
            finally
            {
                if (skeletonDataAsset != null) UnityEngine.Object.DestroyImmediate(skeletonDataAsset);
                if (atlasAsset != null) UnityEngine.Object.DestroyImmediate(atlasAsset);
                if (createdMaterials != null) foreach (var m in createdMaterials) if (m != null) UnityEngine.Object.DestroyImmediate(m);
                foreach (var t in createdTextures) UnityEngine.Object.DestroyImmediate(t);
            }
        }

        static int RenderOutfit(SkeletonDataAsset skeletonDataAsset, SkeletonData skeletonData, Dictionary<string, ManifestItem> itemsById, string[] outfit, string outPath, out string capturedTo)
        {
            GameObject avatarGo = null, cameraGo = null;
            RenderTexture renderTexture = null;
            try
            {
                avatarGo = new GameObject("AvatarOutfitProbe_Avatar");
                var skeletonAnimation = SkeletonAnimation.AddToGameObject(avatarGo, skeletonDataAsset);
                skeletonAnimation.Initialize(false);
                if (!skeletonAnimation.valid) throw new InvalidOperationException("SkeletonAnimation nao inicializou (valid=false)");

                var skin = new Skin("outfit-probe-composite");
                var tints = new Dictionary<Attachment, Color>();
                AddSkin(skeletonData, skin, tints, "Body_Whites/Body_Whites", new Color(1f, 0.824f, 0.675f));
                AddSkin(skeletonData, skin, tints, "Body_Shad/Body_Shad", new Color(0.824f, 0.569f, 0.435f));
                AddSkin(skeletonData, skin, tints, "Ear_Shad/Ear_Shad", new Color(0.667f, 0.376f, 0.271f));
                AddSkin(skeletonData, skin, tints, "Body_Other/Body_Other", Color.white);
                AddSkin(skeletonData, skin, tints, "Eyes/1_Color", new Color(0.22f, 0.44f, 0.57f));
                AddSkin(skeletonData, skin, tints, "Eyes/1_Color-p", Color.white);
                AddSkin(skeletonData, skin, tints, "Hair_Front/1_Color", new Color(0.31f, 0.16f, 0.12f));
                foreach (var itemId in outfit)
                    foreach (var piece in itemsById[itemId].pieces)
                        AddSkin(skeletonData, skin, tints, piece.template, Color.white);

                skeletonAnimation.skeleton.SetSkin(skin);
                skeletonAnimation.skeleton.SetSlotsToSetupPose();
                skeletonAnimation.skeleton.SetAttachment("Mouths", "Body_Outline/Mouth_Regular");
                ApplyTints(skeletonAnimation.skeleton, tints);

                skeletonAnimation.AnimationName = null;
                skeletonAnimation.state.SetAnimation(0, "Idle_Stand_1", false);
                skeletonAnimation.Update(0.1f);
                skeletonAnimation.LateUpdate();

                var meshFilter = avatarGo.GetComponent<MeshFilter>();
                var meshRenderer = avatarGo.GetComponent<MeshRenderer>();
                if (meshFilter == null || meshFilter.sharedMesh == null || meshFilter.sharedMesh.vertexCount == 0)
                    throw new InvalidOperationException("SkeletonAnimation nao gerou geometria (Mesh vazia) para outfit " + string.Join("+", outfit));

                var bounds = meshRenderer.bounds;
                Debug.Log($"AvatarOutfitProbe: outfit={string.Join("+", outfit)} submeshes={meshFilter.sharedMesh.subMeshCount} materials={meshRenderer.sharedMaterials.Length} bounds.center={bounds.center} bounds.extents={bounds.extents} enabled={meshRenderer.enabled}");
                cameraGo = new GameObject("AvatarOutfitProbe_Camera");
                var camera = cameraGo.AddComponent<Camera>();
                camera.orthographic = true;
                camera.clearFlags = CameraClearFlags.SolidColor;
                camera.backgroundColor = new Color(0.922f, 0.914f, 0.953f, 1f);
                camera.cullingMask = ~0;
                float margin = 1.15f;
                camera.orthographicSize = Mathf.Max(bounds.extents.y, bounds.extents.x * (1024f / 768f)) * margin;
                cameraGo.transform.position = new Vector3(bounds.center.x, bounds.center.y, bounds.center.z - 10f);
                cameraGo.transform.LookAt(bounds.center);
                camera.nearClipPlane = 0.01f;
                camera.farClipPlane = 50f;

                renderTexture = new RenderTexture(768, 1024, 24, RenderTextureFormat.ARGB32);
                camera.targetTexture = renderTexture;
                camera.Render();

                var previous = RenderTexture.active;
                RenderTexture.active = renderTexture;
                var output = new Texture2D(768, 1024, TextureFormat.RGBA32, false);
                output.ReadPixels(new Rect(0, 0, 768, 1024), 0, 0);
                output.Apply();
                RenderTexture.active = previous;

                File.WriteAllBytes(outPath, output.EncodeToPNG());
                UnityEngine.Object.DestroyImmediate(output);
                capturedTo = outPath;
                return meshFilter.sharedMesh.triangles.Length / 3;
            }
            finally
            {
                // cameraGo e destruido ja em seguida, mas liberar o RenderTexture enquanto ele ainda
                // e o targetTexture da Camera dispara um aviso benigno - zera a referencia antes.
                if (cameraGo != null)
                {
                    var cam = cameraGo.GetComponent<Camera>();
                    if (cam != null) cam.targetTexture = null;
                }
                if (renderTexture != null) { renderTexture.Release(); UnityEngine.Object.DestroyImmediate(renderTexture); }
                if (cameraGo != null) UnityEngine.Object.DestroyImmediate(cameraGo);
                if (avatarGo != null) UnityEngine.Object.DestroyImmediate(avatarGo);
            }
        }

        static Texture2D LoadTexture(string path, string pageName)
        {
            var texture = new Texture2D(2, 2, TextureFormat.RGBA32, false);
            if (!texture.LoadImage(File.ReadAllBytes(path)))
                throw new InvalidDataException("Cannot decode " + path);
            texture.name = pageName;
            PremultiplyAlpha(texture);
            return texture;
        }

        static void PremultiplyAlpha(Texture2D texture)
        {
            var pixels = texture.GetPixels32();
            for (int i = 0; i < pixels.Length; i++)
            {
                var p = pixels[i];
                float a = p.a / 255f;
                pixels[i] = new Color32((byte)(p.r * a), (byte)(p.g * a), (byte)(p.b * a), p.a);
            }
            texture.SetPixels32(pixels);
            texture.Apply();
        }

        static void AddSkin(SkeletonData data, Skin composite, Dictionary<Attachment, Color> tints, string name, Color color)
        {
            var source = data.FindSkin(name) ?? throw new InvalidDataException("Missing real skin " + name);
            composite.AddSkin(source);
            foreach (var item in source.Attachments) tints[item.Attachment] = color;
        }

        static void ApplyTints(Skeleton skeleton, Dictionary<Attachment, Color> tints)
        {
            foreach (var slot in skeleton.Slots)
                if (slot.Attachment != null && tints.TryGetValue(slot.Attachment, out var color))
                { slot.R = color.r; slot.G = color.g; slot.B = color.b; }
        }
    }
}
