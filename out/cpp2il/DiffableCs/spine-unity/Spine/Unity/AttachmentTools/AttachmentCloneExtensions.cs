namespace Spine.Unity.AttachmentTools;

[Extension]
public static class AttachmentCloneExtensions
{

	[Extension]
	public static Attachment GetRemappedClone(Attachment o, Sprite sprite, Material sourceMaterial, bool premultiplyAlpha = true, bool cloneMeshAsLinked = true, bool useOriginalRegionSize = false, bool pivotShiftsMeshUVCoords = true, bool useOriginalRegionScale = false, TextureFormat pmaCloneTextureFormat = 4, bool pmaCloneMipmaps = false) { }

	[Extension]
	public static Attachment GetRemappedClone(Attachment o, AtlasRegion atlasRegion, bool cloneMeshAsLinked = true, bool useOriginalRegionSize = false, float scale = 0,01) { }

}

