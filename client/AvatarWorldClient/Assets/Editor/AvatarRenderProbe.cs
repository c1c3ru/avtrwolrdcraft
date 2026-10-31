using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Spine;
using UnityEngine;

namespace AvatarWorld.EditorTools
{
    /// <summary>
    /// CPU reference rasterization of actual Spine world vertices, atlas UVs and uniquely resolved
    /// local PNGs. This diagnoses composition without a GPU; it is not gameplay/GPU validation.
    /// </summary>
    public static class AvatarRenderProbe
    {
        sealed class MetadataLoader : TextureLoader
        {
            public void Load(AtlasPage page, string path) { }
            public void Unload(object texture) { }
        }
        sealed class SourceTexture
        {
            public Texture2D texture;
            public Color32[] pixels;
        }
        sealed class DrawPart
        {
            public float[] vertices, uvs;
            public int[] triangles;
            public SourceTexture source;
            public Color tint;
            public string slot;
        }
        [Serializable] public class ProbeReport
        {
            public string renderer = "CPU rasterizer of Spine ComputeWorldVertices; no GPU, clipping or dual-color shader validation";
            public string animation = "Idle_Stand_1";
            public string[] hairSkins;
            public string[] renderedSlots;
            public string[] unresolvedVisiblePages;
            public int triangleCount;
        }

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

        public static void Render()
        {
            var root = Path.GetFullPath(Path.Combine(Application.dataPath, "../../.."));
            var inputs = Path.Combine(root, "assets/spine_textasset/TextAsset");
            var textures = new Dictionary<string, SourceTexture>();
            try
            {
                foreach (var pair in TextureFiles)
                {
                    var texture = new Texture2D(2, 2, TextureFormat.RGBA32, false);
                    if (!texture.LoadImage(File.ReadAllBytes(Path.Combine(root, "assets/textures_png/Texture2D", pair.Value))))
                        throw new InvalidDataException("Cannot decode " + pair.Value);
                    textures.Add(pair.Key, new SourceTexture { texture = texture, pixels = texture.GetPixels32() });
                }
                var atlas = new Atlas(new StringReader(File.ReadAllText(Path.Combine(inputs, "Avatar_Spine.atlas_109005.txt"))), "", new MetadataLoader());
                // Same UV convention used by SpineAtlasAsset.GetAtlas in the shipped Unity runtime.
                atlas.FlipV();
                foreach (var page in atlas.Pages)
                    if (textures.TryGetValue(page.name, out var resolved) &&
                        (resolved.texture.width != page.width || resolved.texture.height != page.height))
                        throw new InvalidDataException("Atlas page dimensions differ for " + page.name);
                SkeletonData data;
                using (var stream = File.OpenRead(Path.Combine(inputs, "Avatar_Spine.skel_108595.txt")))
                    data = new SkeletonBinary(atlas) { Scale = 0.01f }.ReadSkeletonData(stream);
                var report = new ProbeReport { hairSkins = new[] { "Hair_Front/1_Color", "Hair_Front/2_Color" } };
                Directory.CreateDirectory(Path.Combine(root, "out"));
                var allSlots = new HashSet<string>();
                var unresolved = new HashSet<string>();
                for (int option = 0; option < report.hairSkins.Length; option++)
                {
                    var skin = new Skin("probe-composite");
                    var tints = new Dictionary<Attachment, Color>();
                    AddSkin(data, skin, tints, "Body_Whites/Body_Whites", new Color(1f, 0.824f, 0.675f));
                    AddSkin(data, skin, tints, "Body_Shad/Body_Shad", new Color(0.824f, 0.569f, 0.435f));
                    AddSkin(data, skin, tints, "Ear_Shad/Ear_Shad", new Color(0.667f, 0.376f, 0.271f));
                    AddSkin(data, skin, tints, "Body_Other/Body_Other", Color.white);
                    AddSkin(data, skin, tints, "Eyes/1_Color", new Color(0.22f, 0.44f, 0.57f));
                    AddSkin(data, skin, tints, "Eyes/1_Color-p", Color.white);
                    AddSkin(data, skin, tints, report.hairSkins[option], new Color(0.31f, 0.16f, 0.12f));
                    var skeleton = new Skeleton(data);
                    skeleton.SetSkin(skin);
                    skeleton.SetToSetupPose();
                    var idle = data.FindAnimation(report.animation) ?? throw new InvalidDataException("Idle animation absent");
                    idle.Apply(skeleton, 0, 0.1f, false, null, 1, MixBlend.Replace, MixDirection.In);
                    // This actual mouth exists in default skin and uses the uniquely resolved outline atlas.
                    skeleton.SetAttachment("Mouths", "Body_Outline/Mouth_Regular");
                    skeleton.UpdateWorldTransform(Skeleton.Physics.Reset);
                    var parts = GetParts(skeleton, textures, tints, unresolved);
                    if (parts.Count == 0) throw new InvalidDataException("No renderable avatar geometry");
                    foreach (var part in parts) allSlots.Add(part.slot);
                    report.triangleCount += parts.Sum(p => p.triangles.Length / 3);
                    var file = option == 0 ? "avatar-preview.png" : "avatar-preview-hair-2.png";
                    Rasterize(parts, Path.Combine(root, "out", file));
                }
                report.renderedSlots = allSlots.OrderBy(x => x).ToArray();
                report.unresolvedVisiblePages = unresolved.OrderBy(x => x).ToArray();
                File.WriteAllText(Path.Combine(root, "out/avatar-render-probe.json"), JsonUtility.ToJson(report, true));
                Debug.Log($"AvatarRenderProbe: {report.renderedSlots.Length} rendered slots, {report.triangleCount} triangles, {report.unresolvedVisiblePages.Length} unresolved visible pages; CPU references written to out/");
            }
            finally
            {
                foreach (var source in textures.Values) UnityEngine.Object.DestroyImmediate(source.texture);
            }
        }

        static void AddSkin(SkeletonData data, Skin composite, Dictionary<Attachment, Color> tints, string name, Color color)
        {
            var source = data.FindSkin(name) ?? throw new InvalidDataException("Missing real skin " + name);
            composite.AddSkin(source);
            foreach (var item in source.Attachments) tints[item.Attachment] = color;
        }

        static List<DrawPart> GetParts(Skeleton skeleton, Dictionary<string, SourceTexture> textures,
            Dictionary<Attachment, Color> tints, HashSet<string> unresolved)
        {
            var result = new List<DrawPart>();
            foreach (var slot in skeleton.DrawOrder)
            {
                if (slot.A <= 0 || !slot.Bone.Active) continue;
                AtlasRegion region;
                float[] vertices, uvs;
                int[] triangles;
                Color attachmentTint;
                if (slot.Attachment is RegionAttachment r)
                {
                    region = r.Region as AtlasRegion;
                    vertices = new float[8];
                    r.ComputeWorldVertices(slot, vertices, 0, 2);
                    uvs = r.UVs;
                    triangles = new[] { 0, 1, 2, 2, 3, 0 };
                    attachmentTint = new Color(r.R, r.G, r.B, r.A);
                }
                else if (slot.Attachment is MeshAttachment m)
                {
                    region = m.Region as AtlasRegion;
                    vertices = new float[m.WorldVerticesLength];
                    m.ComputeWorldVertices(slot, 0, m.WorldVerticesLength, vertices, 0, 2);
                    uvs = m.UVs;
                    triangles = m.Triangles;
                    attachmentTint = new Color(m.R, m.G, m.B, m.A);
                }
                else continue;
                if (region == null) continue;
                if (!textures.TryGetValue(region.page.name, out var texture))
                {
                    unresolved.Add(region.page.name);
                    continue;
                }
                var tint = new Color(slot.R, slot.G, slot.B, slot.A) * attachmentTint;
                if (tints.TryGetValue(slot.Attachment, out var chosenTint)) tint *= chosenTint;
                result.Add(new DrawPart { vertices = vertices, uvs = uvs, triangles = triangles,
                    source = texture, tint = tint, slot = slot.Data.Name });
            }
            return result;
        }

        static void Rasterize(List<DrawPart> parts, string path)
        {
            const int width = 768, height = 1024;
            var minimum = new Vector2(float.PositiveInfinity, float.PositiveInfinity);
            var maximum = new Vector2(float.NegativeInfinity, float.NegativeInfinity);
            foreach (var part in parts)
                for (int i = 0; i < part.vertices.Length; i += 2)
                {
                    var v = new Vector2(part.vertices[i], part.vertices[i + 1]);
                    minimum = Vector2.Min(minimum, v); maximum = Vector2.Max(maximum, v);
                }
            var size = maximum - minimum;
            float scale = Mathf.Min((width - 100) / size.x, (height - 100) / size.y);
            var offset = new Vector2(width * 0.5f, height * 0.5f) - (minimum + maximum) * (scale * 0.5f);
            var buffer = new Color32[width * height];
            for (int i = 0; i < buffer.Length; i++) buffer[i] = new Color32(235, 233, 243, 255);
            foreach (var part in parts)
            {
                var points = new Vector2[part.vertices.Length / 2];
                for (int i = 0; i < points.Length; i++) points[i] = new Vector2(part.vertices[i * 2], part.vertices[i * 2 + 1]) * scale + offset;
                for (int i = 0; i < part.triangles.Length; i += 3)
                {
                    int ia = part.triangles[i], ib = part.triangles[i + 1], ic = part.triangles[i + 2];
                    var a = points[ia]; var b = points[ib]; var c = points[ic];
                    float area = Cross(b - a, c - a);
                    if (Mathf.Abs(area) < 0.0001f) continue;
                    int x0 = Mathf.Clamp(Mathf.FloorToInt(Mathf.Min(a.x, Mathf.Min(b.x, c.x))), 0, width - 1);
                    int x1 = Mathf.Clamp(Mathf.CeilToInt(Mathf.Max(a.x, Mathf.Max(b.x, c.x))), 0, width - 1);
                    int y0 = Mathf.Clamp(Mathf.FloorToInt(Mathf.Min(a.y, Mathf.Min(b.y, c.y))), 0, height - 1);
                    int y1 = Mathf.Clamp(Mathf.CeilToInt(Mathf.Max(a.y, Mathf.Max(b.y, c.y))), 0, height - 1);
                    for (int y = y0; y <= y1; y++) for (int x = x0; x <= x1; x++)
                    {
                        var p = new Vector2(x + 0.5f, y + 0.5f);
                        float wb = Cross(p - a, c - a) / area, wc = Cross(b - a, p - a) / area, wa = 1 - wb - wc;
                        if (wa < 0 || wb < 0 || wc < 0) continue;
                        float u = part.uvs[ia * 2] * wa + part.uvs[ib * 2] * wb + part.uvs[ic * 2] * wc;
                        float v = part.uvs[ia * 2 + 1] * wa + part.uvs[ib * 2 + 1] * wb + part.uvs[ic * 2 + 1] * wc;
                        int tx = Mathf.Clamp((int)(u * part.source.texture.width), 0, part.source.texture.width - 1);
                        int ty = Mathf.Clamp((int)(v * part.source.texture.height), 0, part.source.texture.height - 1);
                        Color source = (Color)part.source.pixels[ty * part.source.texture.width + tx] * part.tint;
                        if (source.a <= 0) continue;
                        Color destination = buffer[y * width + x];
                        buffer[y * width + x] = new Color(source.r * source.a + destination.r * (1 - source.a),
                            source.g * source.a + destination.g * (1 - source.a), source.b * source.a + destination.b * (1 - source.a), 1);
                    }
                }
            }
            var output = new Texture2D(width, height, TextureFormat.RGBA32, false);
            try { output.SetPixels32(buffer); output.Apply(); File.WriteAllBytes(path, output.EncodeToPNG()); }
            finally { UnityEngine.Object.DestroyImmediate(output); }
        }
        static float Cross(Vector2 a, Vector2 b) => a.x * b.y - a.y * b.x;
    }
}
