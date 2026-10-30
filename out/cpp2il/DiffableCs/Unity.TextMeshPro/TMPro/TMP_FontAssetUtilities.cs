namespace TMPro;

public class TMP_FontAssetUtilities
{
	private static readonly TMP_FontAssetUtilities s_Instance; //Field offset: 0x0
	private static HashSet<Int32> k_SearchedAssets; //Field offset: 0x8
	private static bool k_IsFontEngineInitialized; //Field offset: 0x10

	public static TMP_FontAssetUtilities instance
	{
		 get { } //Length: 88
	}

	private static TMP_FontAssetUtilities() { }

	public TMP_FontAssetUtilities() { }

	public static TMP_FontAssetUtilities get_instance() { }

	public static TMP_Character GetCharacterFromFontAsset(uint unicode, TMP_FontAsset sourceFontAsset, bool includeFallbacks, FontStyles fontStyle, FontWeight fontWeight, out bool isAlternativeTypeface) { }

	private static TMP_Character GetCharacterFromFontAsset_Internal(uint unicode, TMP_FontAsset sourceFontAsset, bool includeFallbacks, FontStyles fontStyle, FontWeight fontWeight, out bool isAlternativeTypeface) { }

	public static TMP_Character GetCharacterFromFontAssets(uint unicode, TMP_FontAsset sourceFontAsset, List<TMP_FontAsset> fontAssets, bool includeFallbacks, FontStyles fontStyle, FontWeight fontWeight, out bool isAlternativeTypeface) { }

	public static TMP_SpriteCharacter GetSpriteCharacterFromSpriteAsset(uint unicode, TMP_SpriteAsset spriteAsset, bool includeFallbacks) { }

	private static TMP_SpriteCharacter GetSpriteCharacterFromSpriteAsset_Internal(uint unicode, TMP_SpriteAsset spriteAsset, bool includeFallbacks) { }

}

