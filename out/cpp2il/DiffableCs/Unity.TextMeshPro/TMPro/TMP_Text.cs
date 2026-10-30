namespace TMPro;

public abstract class TMP_Text : MaskableGraphic
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<TMP_TextInfo> <>9__622_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal void <.ctor>b__622_0(TMP_TextInfo <p0>) { }

	}

	internal struct CharacterSubstitution
	{
		public int index; //Field offset: 0x0
		public uint unicode; //Field offset: 0x4

		public CharacterSubstitution(int index, uint unicode) { }

	}

	internal struct SpecialCharacter
	{
		public TMP_Character character; //Field offset: 0x0
		public TMP_FontAsset fontAsset; //Field offset: 0x8
		public Material material; //Field offset: 0x10
		public int materialIndex; //Field offset: 0x18

		public SpecialCharacter(TMP_Character character, int materialIndex) { }

	}

	[DefaultMember("Item")]
	private struct TextBackingContainer
	{
		private UInt32[] m_Array; //Field offset: 0x0
		private int m_Count; //Field offset: 0x8

		public int Capacity
		{
			 get { } //Length: 28
		}

		public int Count
		{
			 get { } //Length: 8
			 set { } //Length: 8
		}

		public uint Item
		{
			 get { } //Length: 48
			 set { } //Length: 96
		}

		public TextBackingContainer(int size) { }

		public int get_Capacity() { }

		public int get_Count() { }

		public uint get_Item(int index) { }

		public void Resize(int size) { }

		public void set_Count(int value) { }

		public void set_Item(int index, uint value) { }

	}

	public enum TextInputSources
	{
		TextInputBox = 0,
		SetText = 1,
		SetTextArray = 2,
		TextString = 3,
	}

	[DebuggerDisplay("Unicode ({unicode})  '{(char)unicode}'")]
	public struct UnicodeChar
	{
		public int unicode; //Field offset: 0x0
		public int stringIndex; //Field offset: 0x4
		public int length; //Field offset: 0x8

	}

	protected static MaterialReference[] m_materialReferences; //Field offset: 0x0
	protected static Dictionary<Int32, Int32> m_materialReferenceIndexLookup; //Field offset: 0x8
	protected static TMP_TextProcessingStack<MaterialReference> m_materialReferenceStack; //Field offset: 0x10
	protected static Color32 s_colorWhite; //Field offset: 0x68
	[CompilerGenerated]
	private static Func<Int32, String, TMP_FontAsset> OnFontAssetRequest; //Field offset: 0x70
	[CompilerGenerated]
	private static Func<Int32, String, TMP_SpriteAsset> OnSpriteAssetRequest; //Field offset: 0x78
	private static Char[] m_htmlTag; //Field offset: 0x80
	private static RichTextTagAttribute[] m_xmlAttribute; //Field offset: 0x88
	private static Single[] m_attributeParameterValues; //Field offset: 0x90
	protected static WordWrapState m_SavedWordWrapState; //Field offset: 0x98
	protected static WordWrapState m_SavedLineState; //Field offset: 0x410
	protected static WordWrapState m_SavedEllipsisState; //Field offset: 0x788
	protected static WordWrapState m_SavedLastValidState; //Field offset: 0xB00
	protected static WordWrapState m_SavedSoftLineBreakState; //Field offset: 0xE78
	[SerializeField]
	[TextArea(5, 10)]
	protected string m_text; //Field offset: 0xD8
	private bool m_IsTextBackingStringDirty; //Field offset: 0xE0
	[SerializeField]
	protected ITextPreprocessor m_TextPreprocessor; //Field offset: 0xE8
	[SerializeField]
	protected bool m_isRightToLeft; //Field offset: 0xF0
	[SerializeField]
	protected TMP_FontAsset m_fontAsset; //Field offset: 0xF8
	protected TMP_FontAsset m_currentFontAsset; //Field offset: 0x100
	protected bool m_isSDFShader; //Field offset: 0x108
	[SerializeField]
	protected Material m_sharedMaterial; //Field offset: 0x110
	protected Material m_currentMaterial; //Field offset: 0x118
	protected int m_currentMaterialIndex; //Field offset: 0x120
	[SerializeField]
	protected Material[] m_fontSharedMaterials; //Field offset: 0x128
	[SerializeField]
	protected Material m_fontMaterial; //Field offset: 0x130
	[SerializeField]
	protected Material[] m_fontMaterials; //Field offset: 0x138
	protected bool m_isMaterialDirty; //Field offset: 0x140
	[SerializeField]
	protected Color32 m_fontColor32; //Field offset: 0x144
	[SerializeField]
	protected Color m_fontColor; //Field offset: 0x148
	protected Color32 m_underlineColor; //Field offset: 0x158
	protected Color32 m_strikethroughColor; //Field offset: 0x15C
	[SerializeField]
	protected bool m_enableVertexGradient; //Field offset: 0x160
	[SerializeField]
	protected ColorMode m_colorMode; //Field offset: 0x164
	[SerializeField]
	protected VertexGradient m_fontColorGradient; //Field offset: 0x168
	[SerializeField]
	protected TMP_ColorGradient m_fontColorGradientPreset; //Field offset: 0x1A8
	[SerializeField]
	protected TMP_SpriteAsset m_spriteAsset; //Field offset: 0x1B0
	[SerializeField]
	protected bool m_tintAllSprites; //Field offset: 0x1B8
	protected bool m_tintSprite; //Field offset: 0x1B9
	protected Color32 m_spriteColor; //Field offset: 0x1BC
	[SerializeField]
	protected TMP_StyleSheet m_StyleSheet; //Field offset: 0x1C0
	internal TMP_Style m_TextStyle; //Field offset: 0x1C8
	[SerializeField]
	protected int m_TextStyleHashCode; //Field offset: 0x1D0
	[SerializeField]
	protected bool m_overrideHtmlColors; //Field offset: 0x1D4
	[SerializeField]
	protected Color32 m_faceColor; //Field offset: 0x1D8
	protected Color32 m_outlineColor; //Field offset: 0x1DC
	protected float m_outlineWidth; //Field offset: 0x1E0
	[SerializeField]
	protected float m_fontSize; //Field offset: 0x1E4
	protected float m_currentFontSize; //Field offset: 0x1E8
	[SerializeField]
	protected float m_fontSizeBase; //Field offset: 0x1EC
	internal static TMP_TextProcessingStack<WordWrapState> m_EllipsisInsertionCandidateStack; //Field offset: 0x11F0
	protected TMP_TextProcessingStack<Single> m_sizeStack; //Field offset: 0x1F0
	[SerializeField]
	protected FontWeight m_fontWeight; //Field offset: 0x210
	protected FontWeight m_FontWeightInternal; //Field offset: 0x214
	protected TMP_TextProcessingStack<FontWeight> m_FontWeightStack; //Field offset: 0x218
	[SerializeField]
	protected bool m_enableAutoSizing; //Field offset: 0x238
	protected float m_maxFontSize; //Field offset: 0x23C
	protected float m_minFontSize; //Field offset: 0x240
	protected int m_AutoSizeIterationCount; //Field offset: 0x244
	protected int m_AutoSizeMaxIterationCount; //Field offset: 0x248
	protected bool m_IsAutoSizePointSizeSet; //Field offset: 0x24C
	[SerializeField]
	protected float m_fontSizeMin; //Field offset: 0x250
	[SerializeField]
	protected float m_fontSizeMax; //Field offset: 0x254
	[SerializeField]
	protected FontStyles m_fontStyle; //Field offset: 0x258
	protected FontStyles m_FontStyleInternal; //Field offset: 0x25C
	protected TMP_FontStyleStack m_fontStyleStack; //Field offset: 0x260
	protected bool m_isUsingBold; //Field offset: 0x26A
	[SerializeField]
	protected HorizontalAlignmentOptions m_HorizontalAlignment; //Field offset: 0x26C
	[SerializeField]
	protected VerticalAlignmentOptions m_VerticalAlignment; //Field offset: 0x270
	[FormerlySerializedAs("m_lineJustification")]
	[SerializeField]
	protected TextAlignmentOptions m_textAlignment; //Field offset: 0x274
	protected HorizontalAlignmentOptions m_lineJustification; //Field offset: 0x278
	protected TMP_TextProcessingStack<HorizontalAlignmentOptions> m_lineJustificationStack; //Field offset: 0x280
	protected Vector3[] m_textContainerLocalCorners; //Field offset: 0x2A0
	[SerializeField]
	protected float m_characterSpacing; //Field offset: 0x2A8
	protected float m_cSpacing; //Field offset: 0x2AC
	protected float m_monoSpacing; //Field offset: 0x2B0
	[SerializeField]
	protected float m_wordSpacing; //Field offset: 0x2B4
	[SerializeField]
	protected float m_lineSpacing; //Field offset: 0x2B8
	protected float m_lineSpacingDelta; //Field offset: 0x2BC
	protected float m_lineHeight; //Field offset: 0x2C0
	protected bool m_IsDrivenLineSpacing; //Field offset: 0x2C4
	[SerializeField]
	protected float m_lineSpacingMax; //Field offset: 0x2C8
	[SerializeField]
	protected float m_paragraphSpacing; //Field offset: 0x2CC
	[SerializeField]
	protected float m_charWidthMaxAdj; //Field offset: 0x2D0
	protected float m_charWidthAdjDelta; //Field offset: 0x2D4
	[SerializeField]
	protected bool m_enableWordWrapping; //Field offset: 0x2D8
	protected bool m_isCharacterWrappingEnabled; //Field offset: 0x2D9
	protected bool m_isNonBreakingSpace; //Field offset: 0x2DA
	protected bool m_isIgnoringAlignment; //Field offset: 0x2DB
	[SerializeField]
	protected float m_wordWrappingRatios; //Field offset: 0x2DC
	[SerializeField]
	protected TextOverflowModes m_overflowMode; //Field offset: 0x2E0
	protected int m_firstOverflowCharacterIndex; //Field offset: 0x2E4
	[SerializeField]
	protected TMP_Text m_linkedTextComponent; //Field offset: 0x2E8
	[SerializeField]
	internal TMP_Text parentLinkedComponent; //Field offset: 0x2F0
	protected bool m_isTextTruncated; //Field offset: 0x2F8
	[SerializeField]
	protected bool m_enableKerning; //Field offset: 0x2F9
	protected float m_GlyphHorizontalAdvanceAdjustment; //Field offset: 0x2FC
	[SerializeField]
	protected bool m_enableExtraPadding; //Field offset: 0x300
	[SerializeField]
	protected bool checkPaddingRequired; //Field offset: 0x301
	[SerializeField]
	protected bool m_isRichText; //Field offset: 0x302
	[SerializeField]
	protected bool m_parseCtrlCharacters; //Field offset: 0x303
	protected bool m_isOverlay; //Field offset: 0x304
	[SerializeField]
	protected bool m_isOrthographic; //Field offset: 0x305
	[SerializeField]
	protected bool m_isCullingEnabled; //Field offset: 0x306
	protected bool m_isMaskingEnabled; //Field offset: 0x307
	protected bool isMaskUpdateRequired; //Field offset: 0x308
	protected bool m_ignoreCulling; //Field offset: 0x309
	[SerializeField]
	protected TextureMappingOptions m_horizontalMapping; //Field offset: 0x30C
	[SerializeField]
	protected TextureMappingOptions m_verticalMapping; //Field offset: 0x310
	[SerializeField]
	protected float m_uvLineOffset; //Field offset: 0x314
	protected TextRenderFlags m_renderMode; //Field offset: 0x318
	[SerializeField]
	protected VertexSortingOrder m_geometrySortingOrder; //Field offset: 0x31C
	[SerializeField]
	protected bool m_IsTextObjectScaleStatic; //Field offset: 0x320
	[SerializeField]
	protected bool m_VertexBufferAutoSizeReduction; //Field offset: 0x321
	protected int m_firstVisibleCharacter; //Field offset: 0x324
	protected int m_maxVisibleCharacters; //Field offset: 0x328
	protected int m_maxVisibleWords; //Field offset: 0x32C
	protected int m_maxVisibleLines; //Field offset: 0x330
	[SerializeField]
	protected bool m_useMaxVisibleDescender; //Field offset: 0x334
	[SerializeField]
	protected int m_pageToDisplay; //Field offset: 0x338
	protected bool m_isNewPage; //Field offset: 0x33C
	[SerializeField]
	protected Vector4 m_margin; //Field offset: 0x340
	protected float m_marginLeft; //Field offset: 0x350
	protected float m_marginRight; //Field offset: 0x354
	protected float m_marginWidth; //Field offset: 0x358
	protected float m_marginHeight; //Field offset: 0x35C
	protected float m_width; //Field offset: 0x360
	protected TMP_TextInfo m_textInfo; //Field offset: 0x368
	protected bool m_havePropertiesChanged; //Field offset: 0x370
	[SerializeField]
	protected bool m_isUsingLegacyAnimationComponent; //Field offset: 0x371
	protected Transform m_transform; //Field offset: 0x378
	protected RectTransform m_rectTransform; //Field offset: 0x380
	protected Vector2 m_PreviousRectTransformSize; //Field offset: 0x388
	protected Vector2 m_PreviousPivotPosition; //Field offset: 0x390
	[CompilerGenerated]
	private bool <autoSizeTextContainer>k__BackingField; //Field offset: 0x398
	protected bool m_autoSizeTextContainer; //Field offset: 0x399
	protected Mesh m_mesh; //Field offset: 0x3A0
	[SerializeField]
	protected bool m_isVolumetricText; //Field offset: 0x3A8
	[CompilerGenerated]
	private Action<TMP_TextInfo> OnPreRenderText; //Field offset: 0x3B0
	protected TMP_SpriteAnimator m_spriteAnimator; //Field offset: 0x3B8
	protected float m_flexibleHeight; //Field offset: 0x3C0
	protected float m_flexibleWidth; //Field offset: 0x3C4
	protected float m_minWidth; //Field offset: 0x3C8
	protected float m_minHeight; //Field offset: 0x3CC
	protected float m_maxWidth; //Field offset: 0x3D0
	protected float m_maxHeight; //Field offset: 0x3D4
	protected LayoutElement m_LayoutElement; //Field offset: 0x3D8
	protected float m_preferredWidth; //Field offset: 0x3E0
	protected float m_renderedWidth; //Field offset: 0x3E4
	protected bool m_isPreferredWidthDirty; //Field offset: 0x3E8
	protected float m_preferredHeight; //Field offset: 0x3EC
	protected float m_renderedHeight; //Field offset: 0x3F0
	protected bool m_isPreferredHeightDirty; //Field offset: 0x3F4
	protected bool m_isCalculatingPreferredValues; //Field offset: 0x3F5
	protected int m_layoutPriority; //Field offset: 0x3F8
	protected bool m_isLayoutDirty; //Field offset: 0x3FC
	protected bool m_isAwake; //Field offset: 0x3FD
	internal bool m_isWaitingOnResourceLoad; //Field offset: 0x3FE
	internal TextInputSources m_inputSource; //Field offset: 0x400
	protected float m_fontScaleMultiplier; //Field offset: 0x404
	protected float tag_LineIndent; //Field offset: 0x408
	protected float tag_Indent; //Field offset: 0x40C
	protected TMP_TextProcessingStack<Single> m_indentStack; //Field offset: 0x410
	protected bool tag_NoParsing; //Field offset: 0x430
	protected bool m_isParsingText; //Field offset: 0x431
	protected Matrix4x4 m_FXMatrix; //Field offset: 0x434
	protected bool m_isFXMatrixSet; //Field offset: 0x474
	internal UnicodeChar[] m_TextProcessingArray; //Field offset: 0x478
	internal int m_InternalTextProcessingArraySize; //Field offset: 0x480
	private TMP_CharacterInfo[] m_internalCharacterInfo; //Field offset: 0x488
	protected int m_totalCharacterCount; //Field offset: 0x490
	protected int m_characterCount; //Field offset: 0x494
	protected int m_firstCharacterOfLine; //Field offset: 0x498
	protected int m_firstVisibleCharacterOfLine; //Field offset: 0x49C
	protected int m_lastCharacterOfLine; //Field offset: 0x4A0
	protected int m_lastVisibleCharacterOfLine; //Field offset: 0x4A4
	protected int m_lineNumber; //Field offset: 0x4A8
	protected int m_lineVisibleCharacterCount; //Field offset: 0x4AC
	protected int m_pageNumber; //Field offset: 0x4B0
	protected float m_PageAscender; //Field offset: 0x4B4
	protected float m_maxTextAscender; //Field offset: 0x4B8
	protected float m_maxCapHeight; //Field offset: 0x4BC
	protected float m_ElementAscender; //Field offset: 0x4C0
	protected float m_ElementDescender; //Field offset: 0x4C4
	protected float m_maxLineAscender; //Field offset: 0x4C8
	protected float m_maxLineDescender; //Field offset: 0x4CC
	protected float m_startOfLineAscender; //Field offset: 0x4D0
	protected float m_startOfLineDescender; //Field offset: 0x4D4
	protected float m_lineOffset; //Field offset: 0x4D8
	protected Extents m_meshExtents; //Field offset: 0x4DC
	protected Color32 m_htmlColor; //Field offset: 0x4EC
	protected TMP_TextProcessingStack<Color32> m_colorStack; //Field offset: 0x4F0
	protected TMP_TextProcessingStack<Color32> m_underlineColorStack; //Field offset: 0x510
	protected TMP_TextProcessingStack<Color32> m_strikethroughColorStack; //Field offset: 0x530
	protected TMP_TextProcessingStack<HighlightState> m_HighlightStateStack; //Field offset: 0x550
	protected TMP_ColorGradient m_colorGradientPreset; //Field offset: 0x580
	protected TMP_TextProcessingStack<TMP_ColorGradient> m_colorGradientStack; //Field offset: 0x588
	private static ProfilerMarker k_ParseTextMarker; //Field offset: 0x1588
	private static ProfilerMarker k_InsertNewLineMarker; //Field offset: 0x1590
	protected static Vector2 k_LargePositiveVector2; //Field offset: 0x1598
	protected static Vector2 k_LargeNegativeVector2; //Field offset: 0x15A0
	protected static float k_LargePositiveFloat; //Field offset: 0x15A8
	protected static float k_LargeNegativeFloat; //Field offset: 0x15AC
	protected bool m_colorGradientPresetIsTinted; //Field offset: 0x5B0
	protected static int k_LargePositiveInt; //Field offset: 0x15B0
	protected static int k_LargeNegativeInt; //Field offset: 0x15B4
	protected float m_tabSpacing; //Field offset: 0x5B4
	protected float m_spacing; //Field offset: 0x5B8
	protected TMP_TextProcessingStack<Int32>[] m_TextStyleStacks; //Field offset: 0x5C0
	protected int m_TextStyleStackDepth; //Field offset: 0x5C8
	protected TMP_TextProcessingStack<Int32> m_ItalicAngleStack; //Field offset: 0x5D0
	protected int m_ItalicAngle; //Field offset: 0x5F0
	protected TMP_TextProcessingStack<Int32> m_actionStack; //Field offset: 0x5F8
	protected float m_padding; //Field offset: 0x618
	protected float m_baselineOffset; //Field offset: 0x61C
	protected TMP_TextProcessingStack<Single> m_baselineOffsetStack; //Field offset: 0x620
	protected float m_xAdvance; //Field offset: 0x640
	protected TMP_TextElementType m_textElementType; //Field offset: 0x644
	protected TMP_TextElement m_cached_TextElement; //Field offset: 0x648
	protected SpecialCharacter m_Ellipsis; //Field offset: 0x650
	protected SpecialCharacter m_Underline; //Field offset: 0x670
	protected TMP_SpriteAsset m_defaultSpriteAsset; //Field offset: 0x690
	protected TMP_SpriteAsset m_currentSpriteAsset; //Field offset: 0x698
	protected int m_spriteCount; //Field offset: 0x6A0
	protected int m_spriteIndex; //Field offset: 0x6A4
	protected int m_spriteAnimationID; //Field offset: 0x6A8
	protected bool m_ignoreActiveState; //Field offset: 0x6AC
	private TextBackingContainer m_TextBackingArray; //Field offset: 0x6B0
	private readonly Decimal[] k_Power; //Field offset: 0x6C0

	public static event Func<Int32, String, TMP_FontAsset> OnFontAssetRequest
	{
		[CompilerGenerated]
		 add { } //Length: 244
		[CompilerGenerated]
		 remove { } //Length: 244
	}

	public override event Action<TMP_TextInfo> OnPreRenderText
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public static event Func<Int32, String, TMP_SpriteAsset> OnSpriteAssetRequest
	{
		[CompilerGenerated]
		 add { } //Length: 244
		[CompilerGenerated]
		 remove { } //Length: 244
	}

	public TextAlignmentOptions alignment
	{
		 get { } //Length: 16
		 set { } //Length: 68
	}

	public float alpha
	{
		 get { } //Length: 8
		 set { } //Length: 44
	}

	public override bool autoSizeTextContainer
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public Bounds bounds
	{
		 get { } //Length: 176
	}

	public float characterSpacing
	{
		 get { } //Length: 8
		 set { } //Length: 80
	}

	public float characterWidthAdjustment
	{
		 get { } //Length: 8
		 set { } //Length: 80
	}

	public virtual Color color
	{
		 get { } //Length: 20
		 set { } //Length: 120
	}

	public VertexGradient colorGradient
	{
		 get { } //Length: 24
		 set { } //Length: 44
	}

	public TMP_ColorGradient colorGradientPreset
	{
		 get { } //Length: 8
		 set { } //Length: 52
	}

	public bool enableAutoSizing
	{
		 get { } //Length: 8
		 set { } //Length: 76
	}

	public bool enableCulling
	{
		 get { } //Length: 8
		 set { } //Length: 60
	}

	public bool enableKerning
	{
		 get { } //Length: 8
		 set { } //Length: 84
	}

	public bool enableVertexGradient
	{
		 get { } //Length: 8
		 set { } //Length: 48
	}

	public bool enableWordWrapping
	{
		 get { } //Length: 8
		 set { } //Length: 84
	}

	public bool extraPadding
	{
		 get { } //Length: 8
		 set { } //Length: 84
	}

	public Color32 faceColor
	{
		 get { } //Length: 200
		 set { } //Length: 136
	}

	public int firstOverflowCharacterIndex
	{
		 get { } //Length: 8
	}

	public int firstVisibleCharacter
	{
		 get { } //Length: 8
		 set { } //Length: 44
	}

	public override float flexibleHeight
	{
		 get { } //Length: 8
	}

	public override float flexibleWidth
	{
		 get { } //Length: 8
	}

	public TMP_FontAsset font
	{
		 get { } //Length: 8
		 set { } //Length: 216
	}

	public Material fontMaterial
	{
		 get { } //Length: 20
		 set { } //Length: 268
	}

	public override Material[] fontMaterials
	{
		 get { } //Length: 20
		 set { } //Length: 76
	}

	public override Material fontSharedMaterial
	{
		 get { } //Length: 8
		 set { } //Length: 200
	}

	public override Material[] fontSharedMaterials
	{
		 get { } //Length: 16
		 set { } //Length: 76
	}

	public float fontSize
	{
		 get { } //Length: 8
		 set { } //Length: 96
	}

	public float fontSizeMax
	{
		 get { } //Length: 8
		 set { } //Length: 72
	}

	public float fontSizeMin
	{
		 get { } //Length: 8
		 set { } //Length: 72
	}

	public FontStyles fontStyle
	{
		 get { } //Length: 8
		 set { } //Length: 80
	}

	public FontWeight fontWeight
	{
		 get { } //Length: 8
		 set { } //Length: 80
	}

	public VertexSortingOrder geometrySortingOrder
	{
		 get { } //Length: 8
		 set { } //Length: 28
	}

	public bool havePropertiesChanged
	{
		 get { } //Length: 8
		 set { } //Length: 40
	}

	public HorizontalAlignmentOptions horizontalAlignment
	{
		 get { } //Length: 8
		 set { } //Length: 44
	}

	public TextureMappingOptions horizontalMapping
	{
		 get { } //Length: 8
		 set { } //Length: 44
	}

	public bool ignoreVisibility
	{
		 get { } //Length: 8
		 set { } //Length: 32
	}

	public bool isOrthographic
	{
		 get { } //Length: 8
		 set { } //Length: 48
	}

	public bool isOverlay
	{
		 get { } //Length: 8
		 set { } //Length: 84
	}

	public bool isRightToLeftText
	{
		 get { } //Length: 8
		 set { } //Length: 84
	}

	public bool isTextObjectScaleStatic
	{
		 get { } //Length: 8
		 set { } //Length: 128
	}

	public bool isTextOverflowing
	{
		 get { } //Length: 16
	}

	public bool isTextTruncated
	{
		 get { } //Length: 8
	}

	public bool isUsingBold
	{
		 get { } //Length: 8
	}

	public bool isUsingLegacyAnimationComponent
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public bool isVolumetricText
	{
		 get { } //Length: 8
		 set { } //Length: 104
	}

	protected LayoutElement layoutElement
	{
		 get { } //Length: 160
	}

	public override int layoutPriority
	{
		 get { } //Length: 8
	}

	public float lineSpacing
	{
		 get { } //Length: 8
		 set { } //Length: 80
	}

	public float lineSpacingAdjustment
	{
		 get { } //Length: 8
		 set { } //Length: 80
	}

	public TMP_Text linkedTextComponent
	{
		 get { } //Length: 8
		 set { } //Length: 280
	}

	public float mappingUvLineOffset
	{
		 get { } //Length: 8
		 set { } //Length: 44
	}

	public override Vector4 margin
	{
		 get { } //Length: 20
		 set { } //Length: 156
	}

	public float maxHeight
	{
		 get { } //Length: 8
	}

	public int maxVisibleCharacters
	{
		 get { } //Length: 8
		 set { } //Length: 44
	}

	public int maxVisibleLines
	{
		 get { } //Length: 8
		 set { } //Length: 44
	}

	public int maxVisibleWords
	{
		 get { } //Length: 8
		 set { } //Length: 44
	}

	public float maxWidth
	{
		 get { } //Length: 8
	}

	public override Mesh mesh
	{
		 get { } //Length: 8
	}

	public override float minHeight
	{
		 get { } //Length: 8
	}

	public override float minWidth
	{
		 get { } //Length: 8
	}

	public Color32 outlineColor
	{
		 get { } //Length: 200
		 set { } //Length: 116
	}

	public float outlineWidth
	{
		 get { } //Length: 188
		 set { } //Length: 96
	}

	public TextOverflowModes overflowMode
	{
		 get { } //Length: 8
		 set { } //Length: 80
	}

	public bool overrideColorTags
	{
		 get { } //Length: 8
		 set { } //Length: 48
	}

	public int pageToDisplay
	{
		 get { } //Length: 8
		 set { } //Length: 44
	}

	public float paragraphSpacing
	{
		 get { } //Length: 8
		 set { } //Length: 80
	}

	public bool parseCtrlCharacters
	{
		 get { } //Length: 8
		 set { } //Length: 84
	}

	public float pixelsPerUnit
	{
		 get { } //Length: 368
	}

	public override float preferredHeight
	{
		 get { } //Length: 24
	}

	public override float preferredWidth
	{
		 get { } //Length: 24
	}

	public RectTransform rectTransform
	{
		 get { } //Length: 160
	}

	public override float renderedHeight
	{
		 get { } //Length: 36
	}

	public override float renderedWidth
	{
		 get { } //Length: 36
	}

	public TextRenderFlags renderMode
	{
		 get { } //Length: 8
		 set { } //Length: 28
	}

	public bool richText
	{
		 get { } //Length: 8
		 set { } //Length: 84
	}

	protected TMP_SpriteAnimator spriteAnimator
	{
		 get { } //Length: 272
	}

	public TMP_SpriteAsset spriteAsset
	{
		 get { } //Length: 8
		 set { } //Length: 72
	}

	public TMP_StyleSheet styleSheet
	{
		 get { } //Length: 8
		 set { } //Length: 72
	}

	public override string text
	{
		 get { } //Length: 20
		 set { } //Length: 164
	}

	public Bounds textBounds
	{
		 get { } //Length: 68
	}

	public TMP_TextInfo textInfo
	{
		 get { } //Length: 8
	}

	public ITextPreprocessor textPreprocessor
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public TMP_Style textStyle
	{
		 get { } //Length: 100
		 set { } //Length: 92
	}

	public bool tintAllSprites
	{
		 get { } //Length: 8
		 set { } //Length: 48
	}

	public Transform transform
	{
		 get { } //Length: 160
	}

	public bool useMaxVisibleDescender
	{
		 get { } //Length: 8
		 set { } //Length: 48
	}

	public bool vertexBufferAutoSizeReduction
	{
		 get { } //Length: 8
		 set { } //Length: 32
	}

	public VerticalAlignmentOptions verticalAlignment
	{
		 get { } //Length: 8
		 set { } //Length: 44
	}

	public TextureMappingOptions verticalMapping
	{
		 get { } //Length: 8
		 set { } //Length: 44
	}

	public float wordSpacing
	{
		 get { } //Length: 8
		 set { } //Length: 80
	}

	public float wordWrappingRatios
	{
		 get { } //Length: 8
		 set { } //Length: 80
	}

	private static TMP_Text() { }

	protected TMP_Text() { }

	[CompilerGenerated]
	public static void add_OnFontAssetRequest(Func<Int32, String, TMP_FontAsset> value) { }

	[CompilerGenerated]
	public override void add_OnPreRenderText(Action<TMP_TextInfo> value) { }

	[CompilerGenerated]
	public static void add_OnSpriteAssetRequest(Func<Int32, String, TMP_SpriteAsset> value) { }

	private void AddFloatToInternalTextBackingArray(float value, int padding, int precision, ref int writeIndex) { }

	private void AddIntegerToInternalTextBackingArray(double number, int padding, ref int writeIndex) { }

	protected void AdjustLineOffset(int startIndex, int endIndex, float offset) { }

	protected override Vector2 CalculatePreferredValues(ref float fontSize, Vector2 marginSize, bool isTextAutoSizingEnabled, bool isWordWrappingEnabled) { }

	public override void ClearMesh(bool uploadGeometry) { }

	public override void ClearMesh() { }

	public override void ComputeMarginSize() { }

	protected float ConvertToFloat(Char[] chars, int startIndex, int length) { }

	protected float ConvertToFloat(Char[] chars, int startIndex, int length, out int lastIndex) { }

	protected override Material CreateMaterialInstance(Material source) { }

	public virtual void CrossFadeAlpha(float alpha, float duration, bool ignoreTimeScale) { }

	public virtual void CrossFadeColor(Color targetColor, float duration, bool ignoreTimeScale, bool useAlpha) { }

	protected override void DestroySubMeshObjects() { }

	protected override void DrawTextHighlight(Vector3 start, Vector3 end, ref int index, Color32 highlightColor) { }

	protected override void DrawUnderlineMesh(Vector3 start, Vector3 end, ref int index, float startScale, float endScale, float maxScale, float sdfScale, Color32 underlineColor) { }

	protected override void FillCharacterVertexBuffers(int i, int index_X4, bool isVolumetric) { }

	protected override void FillCharacterVertexBuffers(int i, int index_X4) { }

	protected override void FillSpriteVertexBuffers(int i, int index_X4) { }

	public override void ForceMeshUpdate(bool ignoreActiveState = false, bool forceTextReparsing = false) { }

	public TextAlignmentOptions get_alignment() { }

	public float get_alpha() { }

	[CompilerGenerated]
	public override bool get_autoSizeTextContainer() { }

	public Bounds get_bounds() { }

	public float get_characterSpacing() { }

	public float get_characterWidthAdjustment() { }

	public virtual Color get_color() { }

	public VertexGradient get_colorGradient() { }

	public TMP_ColorGradient get_colorGradientPreset() { }

	public bool get_enableAutoSizing() { }

	public bool get_enableCulling() { }

	public bool get_enableKerning() { }

	public bool get_enableVertexGradient() { }

	public bool get_enableWordWrapping() { }

	public bool get_extraPadding() { }

	public Color32 get_faceColor() { }

	public int get_firstOverflowCharacterIndex() { }

	public int get_firstVisibleCharacter() { }

	public override float get_flexibleHeight() { }

	public override float get_flexibleWidth() { }

	public TMP_FontAsset get_font() { }

	public Material get_fontMaterial() { }

	public override Material[] get_fontMaterials() { }

	public override Material get_fontSharedMaterial() { }

	public override Material[] get_fontSharedMaterials() { }

	public float get_fontSize() { }

	public float get_fontSizeMax() { }

	public float get_fontSizeMin() { }

	public FontStyles get_fontStyle() { }

	public FontWeight get_fontWeight() { }

	public VertexSortingOrder get_geometrySortingOrder() { }

	public bool get_havePropertiesChanged() { }

	public HorizontalAlignmentOptions get_horizontalAlignment() { }

	public TextureMappingOptions get_horizontalMapping() { }

	public bool get_ignoreVisibility() { }

	public bool get_isOrthographic() { }

	public bool get_isOverlay() { }

	public bool get_isRightToLeftText() { }

	public bool get_isTextObjectScaleStatic() { }

	public bool get_isTextOverflowing() { }

	public bool get_isTextTruncated() { }

	public bool get_isUsingBold() { }

	public bool get_isUsingLegacyAnimationComponent() { }

	public bool get_isVolumetricText() { }

	protected LayoutElement get_layoutElement() { }

	public override int get_layoutPriority() { }

	public float get_lineSpacing() { }

	public float get_lineSpacingAdjustment() { }

	public TMP_Text get_linkedTextComponent() { }

	public float get_mappingUvLineOffset() { }

	public override Vector4 get_margin() { }

	public float get_maxHeight() { }

	public int get_maxVisibleCharacters() { }

	public int get_maxVisibleLines() { }

	public int get_maxVisibleWords() { }

	public float get_maxWidth() { }

	public override Mesh get_mesh() { }

	public override float get_minHeight() { }

	public override float get_minWidth() { }

	public Color32 get_outlineColor() { }

	public float get_outlineWidth() { }

	public TextOverflowModes get_overflowMode() { }

	public bool get_overrideColorTags() { }

	public int get_pageToDisplay() { }

	public float get_paragraphSpacing() { }

	public bool get_parseCtrlCharacters() { }

	public float get_pixelsPerUnit() { }

	public override float get_preferredHeight() { }

	public override float get_preferredWidth() { }

	public RectTransform get_rectTransform() { }

	public override float get_renderedHeight() { }

	public override float get_renderedWidth() { }

	public TextRenderFlags get_renderMode() { }

	public bool get_richText() { }

	protected TMP_SpriteAnimator get_spriteAnimator() { }

	public TMP_SpriteAsset get_spriteAsset() { }

	public TMP_StyleSheet get_styleSheet() { }

	public override string get_text() { }

	public Bounds get_textBounds() { }

	public TMP_TextInfo get_textInfo() { }

	public ITextPreprocessor get_textPreprocessor() { }

	public TMP_Style get_textStyle() { }

	public bool get_tintAllSprites() { }

	public Transform get_transform() { }

	public bool get_useMaxVisibleDescender() { }

	public bool get_vertexBufferAutoSizeReduction() { }

	public VerticalAlignmentOptions get_verticalAlignment() { }

	public TextureMappingOptions get_verticalMapping() { }

	public float get_wordSpacing() { }

	public float get_wordWrappingRatios() { }

	private int GetAttributeParameters(Char[] chars, int startIndex, int length, ref Single[] parameters) { }

	internal override Rect GetCanvasSpaceClippingRect() { }

	protected override Bounds GetCompoundBounds() { }

	protected void GetEllipsisSpecialCharacter(TMP_FontAsset fontAsset) { }

	protected TMP_FontAsset GetFontAssetForWeight(int fontWeight) { }

	private int GetMarkupTagHashCode(TextBackingContainer tagDefinition, int readIndex) { }

	private int GetMarkupTagHashCode(Int32[] tagDefinition, int readIndex) { }

	protected override Material GetMaterial(Material mat) { }

	protected override Material[] GetMaterials(Material[] mats) { }

	protected override float GetPaddingForMaterial() { }

	protected override float GetPaddingForMaterial(Material mat) { }

	public override string GetParsedText() { }

	private float GetPreferredHeight(Vector2 margin) { }

	protected float GetPreferredHeight() { }

	public Vector2 GetPreferredValues(string text) { }

	public Vector2 GetPreferredValues(float width, float height) { }

	public Vector2 GetPreferredValues(string text, float width, float height) { }

	public Vector2 GetPreferredValues() { }

	protected float GetPreferredWidth() { }

	private float GetPreferredWidth(Vector2 margin) { }

	protected float GetRenderedHeight(bool onlyVisibleCharacters) { }

	private float GetRenderedHeight() { }

	public Vector2 GetRenderedValues(bool onlyVisibleCharacters) { }

	public Vector2 GetRenderedValues() { }

	private float GetRenderedWidth() { }

	protected float GetRenderedWidth(bool onlyVisibleCharacters) { }

	protected override Material[] GetSharedMaterials() { }

	protected void GetSpecialCharacters(TMP_FontAsset fontAsset) { }

	private TMP_Style GetStyle(int hashCode) { }

	private int GetStyleHashCode(ref TextBackingContainer text, int index, out int closeIndex) { }

	private int GetStyleHashCode(ref Int32[] text, int index, out int closeIndex) { }

	protected Bounds GetTextBounds(bool onlyVisibleCharacters) { }

	protected Bounds GetTextBounds() { }

	protected override Vector3[] GetTextContainerLocalCorners() { }

	internal TMP_TextElement GetTextElement(uint unicode, TMP_FontAsset fontAsset, FontStyles fontStyle, FontWeight fontWeight, out bool isUsingAlternativeTypeface) { }

	public override TMP_TextInfo GetTextInfo(string text) { }

	protected void GetUnderlineSpecialCharacter(TMP_FontAsset fontAsset) { }

	protected int GetUTF16(string text, int i) { }

	protected int GetUTF16(StringBuilder text, int i) { }

	protected int GetUTF16(Int32[] text, int i) { }

	internal int GetUTF16(UInt32[] text, int i) { }

	private int GetUTF16(TextBackingContainer text, int i) { }

	private int GetUTF32(TextBackingContainer text, int i) { }

	protected int GetUTF32(string text, int i) { }

	protected int GetUTF32(Int32[] text, int i) { }

	protected int GetUTF32(StringBuilder text, int i) { }

	internal int GetUTF32(UInt32[] text, int i) { }

	protected Color32 HexCharsToColor(Char[] hexChars, int tagCount) { }

	protected Color32 HexCharsToColor(Char[] hexChars, int startIndex, int length) { }

	protected int HexToInt(char hex) { }

	private void InsertClosingStyleTag(ref UnicodeChar[] charBuffer, ref int writeIndex) { }

	protected void InsertNewLine(int i, float baseScale, float currentElementScale, float currentEmScale, float glyphAdjustment, float boldSpacingAdjustment, float characterSpacingAdjustment, float width, float lineGap, ref bool isMaxVisibleDescenderSet, ref float maxVisibleDescender) { }

	private bool InsertOpeningStyleTag(TMP_Style style, int srcIndex, ref UnicodeChar[] charBuffer, ref int writeIndex) { }

	protected override void InternalCrossFadeAlpha(float alpha, float duration, bool ignoreTimeScale) { }

	protected override void InternalCrossFadeColor(Color targetColor, float duration, bool ignoreTimeScale, bool useAlpha) { }

	private string InternalTextBackingArrayToString() { }

	internal override void InternalUpdate() { }

	internal bool IsSelfOrLinkedAncestor(TMP_Text targetTextComponent) { }

	protected void LoadDefaultSettings() { }

	protected override void LoadFontAsset() { }

	protected float PackUV(float x, float y) { }

	protected Vector2 PackUV(float x, float y, float scale) { }

	protected void ParseInputText() { }

	private void PopulateTextBackingArray(string sourceText) { }

	private void PopulateTextBackingArray(string sourceText, int start, int length) { }

	private void PopulateTextBackingArray(StringBuilder sourceText, int start, int length) { }

	private void PopulateTextBackingArray(Char[] sourceText, int start, int length) { }

	private void PopulateTextProcessingArray() { }

	internal void ReleaseLinkedTextComponent(TMP_Text targetTextComponent) { }

	[CompilerGenerated]
	public static void remove_OnFontAssetRequest(Func<Int32, String, TMP_FontAsset> value) { }

	[CompilerGenerated]
	public override void remove_OnPreRenderText(Action<TMP_TextInfo> value) { }

	[CompilerGenerated]
	public static void remove_OnSpriteAssetRequest(Func<Int32, String, TMP_SpriteAsset> value) { }

	private void ReplaceClosingStyleTag(ref Int32[] sourceText, int srcIndex, ref UnicodeChar[] charBuffer, ref int writeIndex) { }

	private void ReplaceClosingStyleTag(ref TextBackingContainer sourceText, int srcIndex, ref UnicodeChar[] charBuffer, ref int writeIndex) { }

	private bool ReplaceOpeningStyleTag(ref TextBackingContainer sourceText, int srcIndex, out int srcOffset, ref UnicodeChar[] charBuffer, ref int writeIndex) { }

	private bool ReplaceOpeningStyleTag(ref Int32[] sourceText, int srcIndex, out int srcOffset, ref UnicodeChar[] charBuffer, ref int writeIndex) { }

	protected void ReplaceTagWithCharacter(Int32[] chars, int insertionIndex, int tagLength, char c) { }

	private void ResizeInternalArray(ref T[] array) { }

	private void ResizeInternalArray(ref T[] array, int size) { }

	protected void ResizeLineExtents(int size) { }

	protected int RestoreWordWrappingState(ref WordWrapState state) { }

	protected override void SaveGlyphVertexInfo(float padding, float style_padding, Color32 vertexColor) { }

	protected override void SaveSpriteVertexInfo(Color32 vertexColor) { }

	protected void SaveWordWrappingState(ref WordWrapState state, int index, int count) { }

	public void set_alignment(TextAlignmentOptions value) { }

	public void set_alpha(float value) { }

	[CompilerGenerated]
	public override void set_autoSizeTextContainer(bool value) { }

	public void set_characterSpacing(float value) { }

	public void set_characterWidthAdjustment(float value) { }

	public virtual void set_color(Color value) { }

	public void set_colorGradient(VertexGradient value) { }

	public void set_colorGradientPreset(TMP_ColorGradient value) { }

	public void set_enableAutoSizing(bool value) { }

	public void set_enableCulling(bool value) { }

	public void set_enableKerning(bool value) { }

	public void set_enableVertexGradient(bool value) { }

	public void set_enableWordWrapping(bool value) { }

	public void set_extraPadding(bool value) { }

	public void set_faceColor(Color32 value) { }

	public void set_firstVisibleCharacter(int value) { }

	public void set_font(TMP_FontAsset value) { }

	public void set_fontMaterial(Material value) { }

	public override void set_fontMaterials(Material[] value) { }

	public override void set_fontSharedMaterial(Material value) { }

	public override void set_fontSharedMaterials(Material[] value) { }

	public void set_fontSize(float value) { }

	public void set_fontSizeMax(float value) { }

	public void set_fontSizeMin(float value) { }

	public void set_fontStyle(FontStyles value) { }

	public void set_fontWeight(FontWeight value) { }

	public void set_geometrySortingOrder(VertexSortingOrder value) { }

	public void set_havePropertiesChanged(bool value) { }

	public void set_horizontalAlignment(HorizontalAlignmentOptions value) { }

	public void set_horizontalMapping(TextureMappingOptions value) { }

	public void set_ignoreVisibility(bool value) { }

	public void set_isOrthographic(bool value) { }

	public void set_isOverlay(bool value) { }

	public void set_isRightToLeftText(bool value) { }

	public void set_isTextObjectScaleStatic(bool value) { }

	public void set_isUsingLegacyAnimationComponent(bool value) { }

	public void set_isVolumetricText(bool value) { }

	public void set_lineSpacing(float value) { }

	public void set_lineSpacingAdjustment(float value) { }

	public void set_linkedTextComponent(TMP_Text value) { }

	public void set_mappingUvLineOffset(float value) { }

	public override void set_margin(Vector4 value) { }

	public void set_maxVisibleCharacters(int value) { }

	public void set_maxVisibleLines(int value) { }

	public void set_maxVisibleWords(int value) { }

	public void set_outlineColor(Color32 value) { }

	public void set_outlineWidth(float value) { }

	public void set_overflowMode(TextOverflowModes value) { }

	public void set_overrideColorTags(bool value) { }

	public void set_pageToDisplay(int value) { }

	public void set_paragraphSpacing(float value) { }

	public void set_parseCtrlCharacters(bool value) { }

	public void set_renderMode(TextRenderFlags value) { }

	public void set_richText(bool value) { }

	public void set_spriteAsset(TMP_SpriteAsset value) { }

	public void set_styleSheet(TMP_StyleSheet value) { }

	public override void set_text(string value) { }

	public void set_textPreprocessor(ITextPreprocessor value) { }

	public void set_textStyle(TMP_Style value) { }

	public void set_tintAllSprites(bool value) { }

	public void set_useMaxVisibleDescender(bool value) { }

	public void set_vertexBufferAutoSizeReduction(bool value) { }

	public void set_verticalAlignment(VerticalAlignmentOptions value) { }

	public void set_verticalMapping(TextureMappingOptions value) { }

	public void set_wordSpacing(float value) { }

	public void set_wordWrappingRatios(float value) { }

	protected override void SetActiveSubMeshes(bool state) { }

	internal override int SetArraySizes(UnicodeChar[] unicodeChars) { }

	public void SetCharArray(Char[] sourceText, int start, int length) { }

	public void SetCharArray(Char[] sourceText) { }

	protected override void SetCulling() { }

	protected override void SetFaceColor(Color32 color) { }

	protected override void SetFontBaseMaterial(Material mat) { }

	protected override void SetOutlineColor(Color32 color) { }

	protected override void SetOutlineThickness(float thickness) { }

	protected override void SetShaderDepth() { }

	protected override void SetSharedMaterial(Material mat) { }

	protected override void SetSharedMaterials(Material[] materials) { }

	public void SetText(string sourceText, float arg0, float arg1, float arg2, float arg3) { }

	public void SetText(Char[] sourceText, int start, int length) { }

	private void SetText(StringBuilder sourceText, int start, int length) { }

	public void SetText(StringBuilder sourceText) { }

	public void SetText(string sourceText, float arg0, float arg1, float arg2, float arg3, float arg4, float arg5, float arg6, float arg7) { }

	public void SetText(string sourceText, float arg0, float arg1, float arg2, float arg3, float arg4, float arg5, float arg6) { }

	public void SetText(string sourceText, float arg0, float arg1, float arg2, float arg3, float arg4, float arg5) { }

	public void SetText(string sourceText, float arg0, float arg1, float arg2, float arg3, float arg4) { }

	public void SetText(Char[] sourceText) { }

	public void SetText(string sourceText, float arg0, float arg1, float arg2) { }

	public void SetText(string sourceText, bool syncTextInputBox = true) { }

	public void SetText(string sourceText, float arg0) { }

	public void SetText(string sourceText, float arg0, float arg1) { }

	private void SetTextInternal(string sourceText) { }

	protected void SetTextSortingOrder(Int32[] order) { }

	protected void SetTextSortingOrder(VertexSortingOrder order) { }

	protected void SetVertexColorGradient(TMP_ColorGradient gradient) { }

	public override void SetVertices(Vector3[] vertices) { }

	internal override void UpdateCulling() { }

	public override void UpdateGeometry(Mesh mesh, int index) { }

	public override void UpdateMeshPadding() { }

	public override void UpdateVertexData() { }

	public override void UpdateVertexData(TMP_VertexDataUpdateFlags flags) { }

	internal bool ValidateHtmlTag(UnicodeChar[] chars, int startIndex, out int endIndex) { }

}

