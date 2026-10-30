namespace Spine.Unity.AttachmentTools;

[Extension]
public static class AttachmentRegionExtensions
{

	[Extension]
	public static void SetPositionOffset(RegionAttachment regionAttachment, Vector2 offset) { }

	[Extension]
	public static void SetPositionOffset(RegionAttachment regionAttachment, float x, float y) { }

	[Extension]
	public static void SetRotation(RegionAttachment regionAttachment, float rotation) { }

	[Extension]
	public static void SetScale(RegionAttachment regionAttachment, Vector2 scale) { }

	[Extension]
	public static void SetScale(RegionAttachment regionAttachment, float x, float y) { }

	[Extension]
	public static RegionAttachment ToRegionAttachment(Sprite sprite, Material material, float rotation = 0) { }

	[Extension]
	public static RegionAttachment ToRegionAttachment(Sprite sprite, AtlasPage page, float rotation = 0) { }

	[Extension]
	public static RegionAttachment ToRegionAttachment(AtlasRegion region, string attachmentName, float scale = 0,01, float rotation = 0) { }

	[Extension]
	public static RegionAttachment ToRegionAttachmentPMAClone(Sprite sprite, Shader shader, TextureFormat textureFormat = 4, bool mipmaps = false, Material materialPropertySource = null, float rotation = 0) { }

	[Extension]
	public static RegionAttachment ToRegionAttachmentPMAClone(Sprite sprite, Material materialPropertySource, TextureFormat textureFormat = 4, bool mipmaps = false, float rotation = 0) { }

}

