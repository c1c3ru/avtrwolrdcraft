namespace TMPro;

public class MaterialReferenceManager
{
	private static MaterialReferenceManager s_Instance; //Field offset: 0x0
	private Dictionary<Int32, Material> m_FontMaterialReferenceLookup; //Field offset: 0x10
	private Dictionary<Int32, TMP_FontAsset> m_FontAssetReferenceLookup; //Field offset: 0x18
	private Dictionary<Int32, TMP_SpriteAsset> m_SpriteAssetReferenceLookup; //Field offset: 0x20
	private Dictionary<Int32, TMP_ColorGradient> m_ColorGradientReferenceLookup; //Field offset: 0x28

	public static MaterialReferenceManager instance
	{
		 get { } //Length: 132
	}

	public MaterialReferenceManager() { }

	public static void AddColorGradientPreset(int hashCode, TMP_ColorGradient spriteAsset) { }

	private void AddColorGradientPreset_Internal(int hashCode, TMP_ColorGradient spriteAsset) { }

	public static void AddFontAsset(TMP_FontAsset fontAsset) { }

	private void AddFontAssetInternal(TMP_FontAsset fontAsset) { }

	public static void AddFontMaterial(int hashCode, Material material) { }

	private void AddFontMaterialInternal(int hashCode, Material material) { }

	public static void AddSpriteAsset(TMP_SpriteAsset spriteAsset) { }

	public static void AddSpriteAsset(int hashCode, TMP_SpriteAsset spriteAsset) { }

	private void AddSpriteAssetInternal(TMP_SpriteAsset spriteAsset) { }

	private void AddSpriteAssetInternal(int hashCode, TMP_SpriteAsset spriteAsset) { }

	public bool Contains(TMP_SpriteAsset sprite) { }

	public bool Contains(TMP_FontAsset font) { }

	public static MaterialReferenceManager get_instance() { }

	public static bool TryGetColorGradientPreset(int hashCode, out TMP_ColorGradient gradientPreset) { }

	private bool TryGetColorGradientPresetInternal(int hashCode, out TMP_ColorGradient gradientPreset) { }

	public static bool TryGetFontAsset(int hashCode, out TMP_FontAsset fontAsset) { }

	private bool TryGetFontAssetInternal(int hashCode, out TMP_FontAsset fontAsset) { }

	public static bool TryGetMaterial(int hashCode, out Material material) { }

	private bool TryGetMaterialInternal(int hashCode, out Material material) { }

	public static bool TryGetSpriteAsset(int hashCode, out TMP_SpriteAsset spriteAsset) { }

	private bool TryGetSpriteAssetInternal(int hashCode, out TMP_SpriteAsset spriteAsset) { }

}

