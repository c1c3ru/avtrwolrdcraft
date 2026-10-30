namespace TMPro;

public struct TMP_LineInfo
{
	internal int controlCharacterCount; //Field offset: 0x0
	public int characterCount; //Field offset: 0x4
	public int visibleCharacterCount; //Field offset: 0x8
	public int spaceCount; //Field offset: 0xC
	public int wordCount; //Field offset: 0x10
	public int firstCharacterIndex; //Field offset: 0x14
	public int firstVisibleCharacterIndex; //Field offset: 0x18
	public int lastCharacterIndex; //Field offset: 0x1C
	public int lastVisibleCharacterIndex; //Field offset: 0x20
	public float length; //Field offset: 0x24
	public float lineHeight; //Field offset: 0x28
	public float ascender; //Field offset: 0x2C
	public float baseline; //Field offset: 0x30
	public float descender; //Field offset: 0x34
	public float maxAdvance; //Field offset: 0x38
	public float width; //Field offset: 0x3C
	public float marginLeft; //Field offset: 0x40
	public float marginRight; //Field offset: 0x44
	public HorizontalAlignmentOptions alignment; //Field offset: 0x48
	public Extents lineExtents; //Field offset: 0x4C

}

