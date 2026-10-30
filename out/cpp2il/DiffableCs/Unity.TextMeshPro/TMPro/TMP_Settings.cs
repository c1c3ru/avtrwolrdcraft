namespace TMPro;

[ExcludeFromPreset]
public class TMP_Settings : ScriptableObject
{
	internal class LineBreakingTable
	{
		public Dictionary<Int32, Char> leadingCharacters; //Field offset: 0x10
		public Dictionary<Int32, Char> followingCharacters; //Field offset: 0x18

		public LineBreakingTable() { }

	}

	private static TMP_Settings s_Instance; //Field offset: 0x0
	[SerializeField]
	private bool m_enableWordWrapping; //Field offset: 0x18
	[SerializeField]
	private bool m_enableKerning; //Field offset: 0x19
	[SerializeField]
	private bool m_enableExtraPadding; //Field offset: 0x1A
	[SerializeField]
	private bool m_enableTintAllSprites; //Field offset: 0x1B
	[SerializeField]
	private bool m_enableParseEscapeCharacters; //Field offset: 0x1C
	[SerializeField]
	private bool m_EnableRaycastTarget; //Field offset: 0x1D
	[SerializeField]
	private bool m_GetFontFeaturesAtRuntime; //Field offset: 0x1E
	[SerializeField]
	private int m_missingGlyphCharacter; //Field offset: 0x20
	[SerializeField]
	private bool m_warningsDisabled; //Field offset: 0x24
	[SerializeField]
	private TMP_FontAsset m_defaultFontAsset; //Field offset: 0x28
	[SerializeField]
	private string m_defaultFontAssetPath; //Field offset: 0x30
	[SerializeField]
	private float m_defaultFontSize; //Field offset: 0x38
	[SerializeField]
	private float m_defaultAutoSizeMinRatio; //Field offset: 0x3C
	[SerializeField]
	private float m_defaultAutoSizeMaxRatio; //Field offset: 0x40
	[SerializeField]
	private Vector2 m_defaultTextMeshProTextContainerSize; //Field offset: 0x44
	[SerializeField]
	private Vector2 m_defaultTextMeshProUITextContainerSize; //Field offset: 0x4C
	[SerializeField]
	private bool m_autoSizeTextContainer; //Field offset: 0x54
	[SerializeField]
	private bool m_IsTextObjectScaleStatic; //Field offset: 0x55
	[SerializeField]
	private List<TMP_FontAsset> m_fallbackFontAssets; //Field offset: 0x58
	[SerializeField]
	private bool m_matchMaterialPreset; //Field offset: 0x60
	[SerializeField]
	private TMP_SpriteAsset m_defaultSpriteAsset; //Field offset: 0x68
	[SerializeField]
	private string m_defaultSpriteAssetPath; //Field offset: 0x70
	[SerializeField]
	private bool m_enableEmojiSupport; //Field offset: 0x78
	[SerializeField]
	private uint m_MissingCharacterSpriteUnicode; //Field offset: 0x7C
	[SerializeField]
	private string m_defaultColorGradientPresetsPath; //Field offset: 0x80
	[SerializeField]
	private TMP_StyleSheet m_defaultStyleSheet; //Field offset: 0x88
	[SerializeField]
	private string m_StyleSheetsResourcePath; //Field offset: 0x90
	[SerializeField]
	private TextAsset m_leadingCharacters; //Field offset: 0x98
	[SerializeField]
	private TextAsset m_followingCharacters; //Field offset: 0xA0
	[SerializeField]
	private LineBreakingTable m_linebreakingRules; //Field offset: 0xA8
	[SerializeField]
	private bool m_UseModernHangulLineBreakingRules; //Field offset: 0xB0

	public static bool autoSizeTextContainer
	{
		 get { } //Length: 28
	}

	public static string defaultColorGradientPresetsPath
	{
		 get { } //Length: 28
	}

	public static TMP_FontAsset defaultFontAsset
	{
		 get { } //Length: 28
	}

	public static string defaultFontAssetPath
	{
		 get { } //Length: 28
	}

	public static float defaultFontSize
	{
		 get { } //Length: 28
	}

	public static TMP_SpriteAsset defaultSpriteAsset
	{
		 get { } //Length: 28
	}

	public static string defaultSpriteAssetPath
	{
		 get { } //Length: 28
	}

	public static TMP_StyleSheet defaultStyleSheet
	{
		 get { } //Length: 28
	}

	public static float defaultTextAutoSizingMaxRatio
	{
		 get { } //Length: 28
	}

	public static float defaultTextAutoSizingMinRatio
	{
		 get { } //Length: 28
	}

	public static Vector2 defaultTextMeshProTextContainerSize
	{
		 get { } //Length: 28
	}

	public static Vector2 defaultTextMeshProUITextContainerSize
	{
		 get { } //Length: 28
	}

	public static bool enableEmojiSupport
	{
		 get { } //Length: 28
		 set { } //Length: 36
	}

	public static bool enableExtraPadding
	{
		 get { } //Length: 28
	}

	public static bool enableKerning
	{
		 get { } //Length: 28
	}

	public static bool enableParseEscapeCharacters
	{
		 get { } //Length: 28
	}

	public static bool enableRaycastTarget
	{
		 get { } //Length: 28
	}

	public static bool enableTintAllSprites
	{
		 get { } //Length: 28
	}

	public static bool enableWordWrapping
	{
		 get { } //Length: 28
	}

	public static List<TMP_FontAsset> fallbackFontAssets
	{
		 get { } //Length: 28
	}

	public static TextAsset followingCharacters
	{
		 get { } //Length: 28
	}

	public static bool getFontFeaturesAtRuntime
	{
		 get { } //Length: 28
	}

	public static TMP_Settings instance
	{
		 get { } //Length: 220
	}

	public static bool isTextObjectScaleStatic
	{
		 get { } //Length: 28
		 set { } //Length: 36
	}

	public static TextAsset leadingCharacters
	{
		 get { } //Length: 28
	}

	public static LineBreakingTable linebreakingRules
	{
		 get { } //Length: 48
	}

	public static bool matchMaterialPreset
	{
		 get { } //Length: 28
	}

	public static uint missingCharacterSpriteUnicode
	{
		 get { } //Length: 28
		 set { } //Length: 32
	}

	public static int missingGlyphCharacter
	{
		 get { } //Length: 28
		 set { } //Length: 32
	}

	public static string styleSheetsResourcePath
	{
		 get { } //Length: 28
	}

	public static bool useModernHangulLineBreakingRules
	{
		 get { } //Length: 28
		 set { } //Length: 36
	}

	public static string version
	{
		 get { } //Length: 64
	}

	public static bool warningsDisabled
	{
		 get { } //Length: 28
	}

	public TMP_Settings() { }

	public static bool get_autoSizeTextContainer() { }

	public static string get_defaultColorGradientPresetsPath() { }

	public static TMP_FontAsset get_defaultFontAsset() { }

	public static string get_defaultFontAssetPath() { }

	public static float get_defaultFontSize() { }

	public static TMP_SpriteAsset get_defaultSpriteAsset() { }

	public static string get_defaultSpriteAssetPath() { }

	public static TMP_StyleSheet get_defaultStyleSheet() { }

	public static float get_defaultTextAutoSizingMaxRatio() { }

	public static float get_defaultTextAutoSizingMinRatio() { }

	public static Vector2 get_defaultTextMeshProTextContainerSize() { }

	public static Vector2 get_defaultTextMeshProUITextContainerSize() { }

	public static bool get_enableEmojiSupport() { }

	public static bool get_enableExtraPadding() { }

	public static bool get_enableKerning() { }

	public static bool get_enableParseEscapeCharacters() { }

	public static bool get_enableRaycastTarget() { }

	public static bool get_enableTintAllSprites() { }

	public static bool get_enableWordWrapping() { }

	public static List<TMP_FontAsset> get_fallbackFontAssets() { }

	public static TextAsset get_followingCharacters() { }

	public static bool get_getFontFeaturesAtRuntime() { }

	public static TMP_Settings get_instance() { }

	public static bool get_isTextObjectScaleStatic() { }

	public static TextAsset get_leadingCharacters() { }

	public static LineBreakingTable get_linebreakingRules() { }

	public static bool get_matchMaterialPreset() { }

	public static uint get_missingCharacterSpriteUnicode() { }

	public static int get_missingGlyphCharacter() { }

	public static string get_styleSheetsResourcePath() { }

	public static bool get_useModernHangulLineBreakingRules() { }

	public static string get_version() { }

	public static bool get_warningsDisabled() { }

	private static Dictionary<Int32, Char> GetCharacters(TextAsset file) { }

	public static TMP_FontAsset GetFontAsset() { }

	public static TMP_Settings GetSettings() { }

	public static TMP_SpriteAsset GetSpriteAsset() { }

	public static TMP_StyleSheet GetStyleSheet() { }

	public static TMP_Settings LoadDefaultSettings() { }

	public static void LoadLinebreakingRules() { }

	public static void set_enableEmojiSupport(bool value) { }

	public static void set_isTextObjectScaleStatic(bool value) { }

	public static void set_missingCharacterSpriteUnicode(uint value) { }

	public static void set_missingGlyphCharacter(int value) { }

	public static void set_useModernHangulLineBreakingRules(bool value) { }

}

