namespace Spine.Unity;

public class RegionlessAttachmentLoader : AttachmentLoader
{
	private static AtlasRegion emptyRegion; //Field offset: 0x0

	private static AtlasRegion EmptyRegion
	{
		private get { } //Length: 568
	}

	public RegionlessAttachmentLoader() { }

	private static AtlasRegion get_EmptyRegion() { }

	public override BoundingBoxAttachment NewBoundingBoxAttachment(Skin skin, string name) { }

	public override ClippingAttachment NewClippingAttachment(Skin skin, string name) { }

	public override MeshAttachment NewMeshAttachment(Skin skin, string name, string path, Sequence sequence) { }

	public override PathAttachment NewPathAttachment(Skin skin, string name) { }

	public override PointAttachment NewPointAttachment(Skin skin, string name) { }

	public override RegionAttachment NewRegionAttachment(Skin skin, string name, string path, Sequence sequence) { }

}

