namespace TMPro;

public struct WordWrapState
{
	public int previous_WordBreak; //Field offset: 0x0
	public int total_CharacterCount; //Field offset: 0x4
	public int visible_CharacterCount; //Field offset: 0x8
	public int visible_SpriteCount; //Field offset: 0xC
	public int visible_LinkCount; //Field offset: 0x10
	public int firstCharacterIndex; //Field offset: 0x14
	public int firstVisibleCharacterIndex; //Field offset: 0x18
	public int lastCharacterIndex; //Field offset: 0x1C
	public int lastVisibleCharIndex; //Field offset: 0x20
	public int lineNumber; //Field offset: 0x24
	public float maxCapHeight; //Field offset: 0x28
	public float maxAscender; //Field offset: 0x2C
	public float maxDescender; //Field offset: 0x30
	public float startOfLineAscender; //Field offset: 0x34
	public float maxLineAscender; //Field offset: 0x38
	public float maxLineDescender; //Field offset: 0x3C
	public float pageAscender; //Field offset: 0x40
	public HorizontalAlignmentOptions horizontalAlignment; //Field offset: 0x44
	public float marginLeft; //Field offset: 0x48
	public float marginRight; //Field offset: 0x4C
	public float xAdvance; //Field offset: 0x50
	public float preferredWidth; //Field offset: 0x54
	public float preferredHeight; //Field offset: 0x58
	public float previousLineScale; //Field offset: 0x5C
	public int wordCount; //Field offset: 0x60
	public FontStyles fontStyle; //Field offset: 0x64
	public int italicAngle; //Field offset: 0x68
	public float fontScaleMultiplier; //Field offset: 0x6C
	public float currentFontSize; //Field offset: 0x70
	public float baselineOffset; //Field offset: 0x74
	public float lineOffset; //Field offset: 0x78
	public bool isDrivenLineSpacing; //Field offset: 0x7C
	public float glyphHorizontalAdvanceAdjustment; //Field offset: 0x80
	public float cSpace; //Field offset: 0x84
	public float mSpace; //Field offset: 0x88
	public TMP_TextInfo textInfo; //Field offset: 0x90
	public TMP_LineInfo lineInfo; //Field offset: 0x98
	public Color32 vertexColor; //Field offset: 0xF4
	public Color32 underlineColor; //Field offset: 0xF8
	public Color32 strikethroughColor; //Field offset: 0xFC
	public Color32 highlightColor; //Field offset: 0x100
	public TMP_FontStyleStack basicStyleStack; //Field offset: 0x104
	public TMP_TextProcessingStack<Int32> italicAngleStack; //Field offset: 0x110
	public TMP_TextProcessingStack<Color32> colorStack; //Field offset: 0x130
	public TMP_TextProcessingStack<Color32> underlineColorStack; //Field offset: 0x150
	public TMP_TextProcessingStack<Color32> strikethroughColorStack; //Field offset: 0x170
	public TMP_TextProcessingStack<Color32> highlightColorStack; //Field offset: 0x190
	public TMP_TextProcessingStack<HighlightState> highlightStateStack; //Field offset: 0x1B0
	public TMP_TextProcessingStack<TMP_ColorGradient> colorGradientStack; //Field offset: 0x1E0
	public TMP_TextProcessingStack<Single> sizeStack; //Field offset: 0x208
	public TMP_TextProcessingStack<Single> indentStack; //Field offset: 0x228
	public TMP_TextProcessingStack<FontWeight> fontWeightStack; //Field offset: 0x248
	public TMP_TextProcessingStack<Int32> styleStack; //Field offset: 0x268
	public TMP_TextProcessingStack<Single> baselineStack; //Field offset: 0x288
	public TMP_TextProcessingStack<Int32> actionStack; //Field offset: 0x2A8
	public TMP_TextProcessingStack<MaterialReference> materialReferenceStack; //Field offset: 0x2C8
	public TMP_TextProcessingStack<HorizontalAlignmentOptions> lineJustificationStack; //Field offset: 0x320
	public int spriteAnimationID; //Field offset: 0x340
	public TMP_FontAsset currentFontAsset; //Field offset: 0x348
	public TMP_SpriteAsset currentSpriteAsset; //Field offset: 0x350
	public Material currentMaterial; //Field offset: 0x358
	public int currentMaterialIndex; //Field offset: 0x360
	public Extents meshExtents; //Field offset: 0x364
	public bool tagNoParsing; //Field offset: 0x374
	public bool isNonBreakingSpace; //Field offset: 0x375

}

