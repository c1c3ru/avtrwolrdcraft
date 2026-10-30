namespace Spine;

public interface AttachmentLoader
{

	public BoundingBoxAttachment NewBoundingBoxAttachment(Skin skin, string name) { }

	public ClippingAttachment NewClippingAttachment(Skin skin, string name) { }

	public MeshAttachment NewMeshAttachment(Skin skin, string name, string path, Sequence sequence) { }

	public PathAttachment NewPathAttachment(Skin skin, string name) { }

	public PointAttachment NewPointAttachment(Skin skin, string name) { }

	public RegionAttachment NewRegionAttachment(Skin skin, string name, string path, Sequence sequence) { }

}

