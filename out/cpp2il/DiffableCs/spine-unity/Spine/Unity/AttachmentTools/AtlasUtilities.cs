namespace Spine.Unity.AttachmentTools;

[Extension]
public static class AtlasUtilities
{
	private struct IntAndAtlasRegionKey
	{
		private int i; //Field offset: 0x0
		private AtlasRegion region; //Field offset: 0x8

		public IntAndAtlasRegionKey(int i, AtlasRegion region) { }

		public virtual int GetHashCode() { }

	}

	internal const TextureFormat SpineTextureFormat = 4; //Field offset: 0x0
	internal const float DefaultMipmapBias = -0,5; //Field offset: 0x0
	internal const bool UseMipMaps = False; //Field offset: 0x0
	internal const float DefaultScale = 0,01; //Field offset: 0x0
	private const int NonrenderingRegion = -1; //Field offset: 0x0
	private static readonly Dictionary<AtlasRegion, Int32> existingRegions; //Field offset: 0x0
	private static readonly List<Int32> regionIndices; //Field offset: 0x8
	private static readonly List<AtlasRegion> originalRegions; //Field offset: 0x10
	private static readonly List<AtlasRegion> repackedRegions; //Field offset: 0x18
	private static List<Texture2D>[] texturesToPackAtParam; //Field offset: 0x20
	private static List<Attachment> inoutAttachments; //Field offset: 0x28
	private static Dictionary<IntAndAtlasRegionKey, Texture2D> CachedRegionTextures; //Field offset: 0x30
	private static List<Texture2D> CachedRegionTexturesList; //Field offset: 0x38

	private static AtlasUtilities() { }

	private static void AddRegionTexturesToPack(int numTextureParamsToRepack, AtlasRegion region, TextureFormat textureFormat, bool mipmaps, TextureFormat[] additionalTextureFormats, Int32[] additionalTexturePropertyIDsToCopy, Boolean[] additionalTextureIsLinear) { }

	public static void ClearCache() { }

	private static void CopyTexture(Texture2D source, Rect sourceRect, Texture2D destination) { }

	private static void CopyTextureApplyPMA(Texture2D source, Rect sourceRect, Texture2D destination) { }

	[Extension]
	private static void CopyTextureAttributesFrom(Texture2D destination, Texture2D source) { }

	[Extension]
	private static Texture2D GetClone(Texture2D t, TextureFormat textureFormat = 4, bool mipmaps = false, bool linear = false, bool applyPMA = false) { }

	[Extension]
	private static Texture2D GetMainTexture(AtlasRegion region) { }

	public static void GetRepackedAttachments(List<Attachment> sourceAttachments, List<Attachment> outputAttachments, Material materialPropertySource, out Material outputMaterial, out Texture2D outputTexture, int maxAtlasSize = 1024, int padding = 2, TextureFormat textureFormat = 4, bool mipmaps = false, string newAssetName = "Repacked Attachments", bool clearCache = false, bool useOriginalNonrenderables = true, Int32[] additionalTexturePropertyIDsToCopy = null, Texture2D[] additionalOutputTextures = null, TextureFormat[] additionalTextureFormats = null, Boolean[] additionalTextureIsLinear = null) { }

	public static void GetRepackedAttachments(List<Attachment> sourceAttachments, List<Attachment> outputAttachments, Shader shader, out Material outputMaterial, out Texture2D outputTexture, int maxAtlasSize = 1024, int padding = 2, TextureFormat textureFormat = 4, bool mipmaps = false, string newAssetName = "Repacked Attachments", Material materialPropertySource = null, bool clearCache = false, bool useOriginalNonrenderables = true, Int32[] additionalTexturePropertyIDsToCopy = null, Texture2D[] additionalOutputTextures = null, TextureFormat[] additionalTextureFormats = null, Boolean[] additionalTextureIsLinear = null) { }

	[Extension]
	public static Skin GetRepackedSkin(Skin o, string newName, Shader shader, out Material outputMaterial, out Texture2D outputTexture, int maxAtlasSize = 1024, int padding = 2, TextureFormat textureFormat = 4, bool mipmaps = false, Material materialPropertySource = null, bool clearCache = false, bool useOriginalNonrenderables = true, Int32[] additionalTexturePropertyIDsToCopy = null, Texture2D[] additionalOutputTextures = null, TextureFormat[] additionalTextureFormats = null, Boolean[] additionalTextureIsLinear = null) { }

	[Extension]
	public static Skin GetRepackedSkin(Skin o, string newName, Material materialPropertySource, out Material outputMaterial, out Texture2D outputTexture, int maxAtlasSize = 1024, int padding = 2, TextureFormat textureFormat = 4, bool mipmaps = false, bool useOriginalNonrenderables = true, bool clearCache = false, Int32[] additionalTexturePropertyIDsToCopy = null, Texture2D[] additionalOutputTextures = null, TextureFormat[] additionalTextureFormats = null, Boolean[] additionalTextureIsLinear = null) { }

	[Extension]
	private static Rect GetSpineAtlasRect(AtlasRegion region, bool includeRotate = true) { }

	[Extension]
	private static Texture2D GetTexture(AtlasRegion region, string texturePropertyName) { }

	[Extension]
	private static Texture2D GetTexture(AtlasRegion region, int texturePropertyId) { }

	[Extension]
	private static Rect GetUnityRect(AtlasRegion region, int textureHeight) { }

	[Extension]
	private static Rect GetUnityRect(AtlasRegion region) { }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::SubsystemRegistration (4))]
	private static void Init() { }

	private static float InverseLerp(float a, float b, float value) { }

	private static bool IsRenderable(Attachment a) { }

	[Extension]
	private static Rect SpineUnityFlipRect(Rect rect, int textureHeight) { }

	private static Rect TextureRectToUVRect(Rect textureRect, int texWidth, int texHeight) { }

	[Extension]
	public static AtlasRegion ToAtlasRegion(Texture2D t, Material materialPropertySource, float scale = 0,01) { }

	[Extension]
	internal static AtlasRegion ToAtlasRegion(Sprite s, bool isolatedTexture = false) { }

	[Extension]
	public static AtlasRegion ToAtlasRegion(Sprite s, Material material) { }

	[Extension]
	public static AtlasRegion ToAtlasRegion(Sprite s, AtlasPage page) { }

	[Extension]
	public static AtlasRegion ToAtlasRegion(Texture2D t, Shader shader, float scale = 0,01, Material materialPropertySource = null) { }

	[Extension]
	public static AtlasRegion ToAtlasRegionPMAClone(Sprite s, Shader shader, TextureFormat textureFormat = 4, bool mipmaps = false, Material materialPropertySource = null) { }

	[Extension]
	public static AtlasRegion ToAtlasRegionPMAClone(Sprite s, Material materialPropertySource, TextureFormat textureFormat = 4, bool mipmaps = false) { }

	[Extension]
	public static AtlasRegion ToAtlasRegionPMAClone(Texture2D t, Material materialPropertySource, TextureFormat textureFormat = 4, bool mipmaps = false) { }

	[Extension]
	public static AtlasRegion ToAtlasRegionPMAClone(Texture2D t, Shader shader, TextureFormat textureFormat = 4, bool mipmaps = false, Material materialPropertySource = null) { }

	[Extension]
	public static AtlasPage ToSpineAtlasPage(Material m) { }

	[Extension]
	public static Sprite ToSprite(AtlasRegion ar, float pixelsPerUnit = 100) { }

	[Extension]
	private static Texture2D ToTexture(Sprite s, TextureFormat textureFormat = 4, bool mipmaps = false, bool linear = false, bool applyPMA = false) { }

	[Extension]
	public static Texture2D ToTexture(AtlasRegion ar, TextureFormat textureFormat = 4, bool mipmaps = false, int texturePropertyId = 0, bool linear = false, bool applyPMA = false) { }

	private static AtlasRegion UVRectToAtlasRegion(Rect uvRect, AtlasRegion referenceRegion, AtlasPage page) { }

	private static Rect UVRectToTextureRect(Rect uvRect, int texWidth, int texHeight) { }

}

