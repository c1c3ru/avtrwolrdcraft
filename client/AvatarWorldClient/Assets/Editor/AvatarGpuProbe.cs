using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
using UnityEngine;

namespace AvatarWorld.EditorTools
{
    /// <summary>
    /// Renderiza o MESMO composto corpo/olhos/cabelo que AvatarRenderProbe provou por CPU, desta vez
    /// pelo runtime spine-unity real (SkeletonAnimation, shader Spine/Skeleton, Mesh gerada pelo
    /// proprio spine-unity) capturado por uma Camera Unity de verdade - fecha a lacuna que o plano
    /// aponta ("um rasterizador de referencia nao substitui a validacao do material/canvas").
    ///
    /// SpineAtlasAsset.CreateRuntimeInstance(TextAsset, Texture2D[], ...) exige uma textura por
    /// PAGINA do atlas (2172 no arquivo completo) ou lança/loga erro por pagina sem par. Em vez de
    /// criar 2164 texturas/materiais de descarte, o texto do atlas e cortado antes para so as 8
    /// paginas usadas por este composto (formato confirmado: blocos separados por linha em branco,
    /// cabecalho = linha terminada em ".png").
    /// </summary>
    public static class AvatarGpuProbe
    {
        static readonly Dictionary<string, string> TextureFiles = new Dictionary<string, string> {
            { "MultiPack__Body_Outline.png", "MultiPack__Body_Outline_31883.png" },
            { "MultiPack__Body_Shadow.png", "MultiPack__Body_Shadow_87873.png" },
            { "MultiPack__Body_Solid.png", "MultiPack__Body_Solid_99707.png" },
            { "MultiPack__Ear_Shadow.png", "MultiPack__Ear_Shadow_76723.png" },
            { "Eyes_01_1_Color.png", "Eyes_01_1_Color_21563.png" },
            { "Eyes_01_1_P.png", "Eyes_01_1_P_18738.png" },
            { "Hair_Front_01_Color.png", "Hair_Front_01_Color_56300.png" },
            { "Hair_Front_02_Color.png", "Hair_Front_02_Color_21315.png" },
        };

        [Serializable]
        public class GpuProbeReport
        {
            public string renderer = "Spine.Unity.SkeletonAnimation (shader real, Mesh gerada pelo spine-unity), capturado por UnityEngine.Camera";
            public string shader;
            public string atlasPagesIncluded;
            public int meshTriangles;
            public int meshVertices;
            public string animation = "Idle_Stand_1";
            public string capturedTo;
        }

        public static void Render()
        {
            var root = Path.GetFullPath(Path.Combine(Application.dataPath, "../../.."));
            var inputs = Path.Combine(root, "assets/spine_textasset/TextAsset");
            Directory.CreateDirectory(Path.Combine(root, "out"));

            var rawAtlas = File.ReadAllText(Path.Combine(inputs, "Avatar_Spine.atlas_109005.txt"));

            var shader = Shader.Find("Spine/Skeleton");
            if (shader == null) throw new InvalidOperationException("Shader Spine/Skeleton nao encontrado no projeto");

            var createdTextures = new List<Texture2D>();
            GameObject cameraGo = null, avatarGo = null;
            Material[] createdMaterials = null;
            SkeletonDataAsset skeletonDataAsset = null;
            SpineAtlasAsset atlasAsset = null;
            RenderTexture renderTexture = null;

            try
            {
                // AtlasAttachmentLoader resolve os attachments de TODAS as 2120 skins no parse inicial
                // do esqueleto, nao so das 7 que este composto usa - cortar o atlas pra so 8 paginas
                // quebra a resolucao de regiao de outras skins (ex.: "General/Emotion_Droplet") e o
                // parse falha inteiro. O atlas tem que ficar completo (2172 paginas) para o parse
                // funcionar; a economia de memoria vem de dar Material/Textura REAL so as 8 paginas
                // que este composto desenha e um UNICO Material "dummy" compartilhado pras ~2164
                // restantes (MaterialsTextureLoader so usa o Material pra casar nome da textura, nao
                // depende de posicao no array).
                var dummyTexture = new Texture2D(2, 2, TextureFormat.RGBA32, false) { name = "__avatar_gpu_probe_unused__" };
                createdTextures.Add(dummyTexture);
                var dummyMaterial = new Material(shader) { mainTexture = dummyTexture };

                var materials = new List<Material> { dummyMaterial };
                foreach (var pair in TextureFiles)
                {
                    var texture = new Texture2D(2, 2, TextureFormat.RGBA32, false);
                    if (!texture.LoadImage(File.ReadAllBytes(Path.Combine(root, "assets/textures_png/Texture2D", pair.Value))))
                        throw new InvalidDataException("Cannot decode " + pair.Value);
                    // MaterialsTextureLoader casa pelo nome do arquivo do atlas (sem extensao) - o nome
                    // da textura TEM que bater exatamente com isso.
                    texture.name = Path.GetFileNameWithoutExtension(pair.Key);
                    // O shader Spine/Skeleton espera textura com alpha pre-multiplicado (padrao do
                    // pipeline de export real do Spine); os PNGs extraidos sao alpha reto. Sem isso,
                    // pixels semi-transparentes desenham manchas brancas translucidas por cima.
                    PremultiplyAlpha(texture);
                    createdTextures.Add(texture);
                    materials.Add(new Material(shader) { mainTexture = texture });
                }
                createdMaterials = materials.ToArray();

                var atlasTextAsset = new TextAsset(rawAtlas) { name = "Avatar_Spine_Atlas" };
                atlasAsset = SpineAtlasAsset.CreateRuntimeInstance(atlasTextAsset, createdMaterials, true);

                byte[] skeletonBytes = File.ReadAllBytes(Path.Combine(inputs, "Avatar_Spine.skel_108595.txt"));
                // SkeletonDataAsset.GetSkeletonData decide binario vs JSON pelo NOME do TextAsset conter
                // ".skel" (nao pelo conteudo) - sem isso ele tenta ler os bytes binarios como JSON e
                // falha silenciosamente (CreateRuntimeInstance chama GetSkeletonData em modo "quiet").
                var skeletonTextAsset = new TextAsset(skeletonBytes) { name = "Avatar_Spine.skel" };
                skeletonDataAsset = SkeletonDataAsset.CreateRuntimeInstance(skeletonTextAsset, atlasAsset, true, 0.01f);
                if (skeletonDataAsset.GetSkeletonData(false) == null)
                    throw new InvalidOperationException("SkeletonDataAsset nao carregou SkeletonData (subset de atlas incompativel?)");

                avatarGo = new GameObject("AvatarGpuProbe_Avatar");
                var skeletonAnimation = SkeletonAnimation.AddToGameObject(avatarGo, skeletonDataAsset);
                skeletonAnimation.Initialize(false);
                if (!skeletonAnimation.valid)
                    throw new InvalidOperationException("SkeletonAnimation nao inicializou (valid=false)");

                var skeletonData = skeletonDataAsset.GetSkeletonData(false);
                var skin = new Skin("probe-gpu-composite");
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
                // Aplica o tint por attachment igual ao probe CPU (o shader base nao tem dual-color).
                ApplyTints(skeletonAnimation.skeleton, tints);

                skeletonAnimation.AnimationName = null; // evita procurar a animacao antes de valid=true
                skeletonAnimation.state.SetAnimation(0, "Idle_Stand_1", false);
                skeletonAnimation.Update(0.1f);
                skeletonAnimation.LateUpdate(); // gera a Mesh de verdade (nao roda sozinho fora do Play Mode)

                var meshFilter = avatarGo.GetComponent<MeshFilter>();
                var meshRenderer = avatarGo.GetComponent<MeshRenderer>();
                if (meshFilter == null || meshFilter.sharedMesh == null || meshFilter.sharedMesh.vertexCount == 0)
                    throw new InvalidOperationException("SkeletonAnimation nao gerou nenhuma geometria (Mesh vazia)");

                var bounds = meshRenderer.bounds;
                cameraGo = new GameObject("AvatarGpuProbe_Camera");
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

                string outPath = Path.Combine(root, "out/avatar-gpu-preview.png");
                File.WriteAllBytes(outPath, output.EncodeToPNG());
                UnityEngine.Object.DestroyImmediate(output);

                var report = new GpuProbeReport
                {
                    shader = shader.name,
                    atlasPagesIncluded = string.Join(",", TextureFiles.Keys),
                    meshTriangles = meshFilter.sharedMesh.triangles.Length / 3,
                    meshVertices = meshFilter.sharedMesh.vertexCount,
                    capturedTo = outPath,
                };
                File.WriteAllText(Path.Combine(root, "out/avatar-gpu-probe-report.json"), JsonUtility.ToJson(report, true));
                Debug.Log($"AvatarGpuProbe: shader={report.shader}, {report.meshVertices} vertices, {report.meshTriangles} triangulos reais da Mesh do spine-unity; imagem em {outPath}");
            }
            finally
            {
                if (renderTexture != null) { renderTexture.Release(); UnityEngine.Object.DestroyImmediate(renderTexture); }
                if (cameraGo != null) UnityEngine.Object.DestroyImmediate(cameraGo);
                if (avatarGo != null) UnityEngine.Object.DestroyImmediate(avatarGo);
                if (skeletonDataAsset != null) UnityEngine.Object.DestroyImmediate(skeletonDataAsset);
                if (atlasAsset != null) UnityEngine.Object.DestroyImmediate(atlasAsset);
                if (createdMaterials != null) foreach (var m in createdMaterials) if (m != null) UnityEngine.Object.DestroyImmediate(m);
                foreach (var t in createdTextures) UnityEngine.Object.DestroyImmediate(t);
            }
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
            {
                if (slot.Attachment != null && tints.TryGetValue(slot.Attachment, out var color))
                {
                    slot.R = color.r; slot.G = color.g; slot.B = color.b;
                }
            }
        }
    }
}
