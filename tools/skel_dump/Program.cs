using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using Spine;

// Usage: skel_dump <file.skel>... ; prints one JSON object per skeleton (names only, no semantics).
class Program {
    static int Main(string[] args) {
        var opts = new JsonSerializerOptions { WriteIndented = false };
        foreach (var path in args) {
            try {
                var atlas = new Atlas(new System.Collections.Generic.List<AtlasPage>(), new System.Collections.Generic.List<AtlasRegion>());
                var loader = new AtlasAttachmentLoader(atlas);
                var bin = new SkeletonBinary(new NullLoader());
                SkeletonData d;
                using (var fs = File.OpenRead(path)) d = bin.ReadSkeletonData(fs);
                Console.WriteLine(JsonSerializer.Serialize(new {
                    file = Path.GetFileName(path), version = d.Version,
                    animations = d.Animations.Select(a => new { a.Name, a.Duration }).ToArray(),
                    skins = d.Skins.Select(s => s.Name).ToArray(),
                    slots = d.Slots.Select(s => s.Name).ToArray(),
                    bones = d.Bones.Count, events = d.Events.Select(e => e.Name).ToArray()
                }, opts));
            } catch (Exception e) {
                Console.WriteLine(JsonSerializer.Serialize(new { file = Path.GetFileName(path), error = e.GetType().Name + ": " + e.Message }, opts));
            }
        }
        return 0;
    }
}
class NullLoader : AttachmentLoader {
    public RegionAttachment NewRegionAttachment(Skin skin, string name, string path, Sequence sequence) => new RegionAttachment(name);
    public MeshAttachment NewMeshAttachment(Skin skin, string name, string path, Sequence sequence) => new MeshAttachment(name);
    public BoundingBoxAttachment NewBoundingBoxAttachment(Skin skin, string name) => new BoundingBoxAttachment(name);
    public PathAttachment NewPathAttachment(Skin skin, string name) => new PathAttachment(name);
    public PointAttachment NewPointAttachment(Skin skin, string name) => new PointAttachment(name);
    public ClippingAttachment NewClippingAttachment(Skin skin, string name) => new ClippingAttachment(name);
}
