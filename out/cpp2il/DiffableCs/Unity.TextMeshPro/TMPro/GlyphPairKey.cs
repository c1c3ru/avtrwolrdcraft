namespace TMPro;

public struct GlyphPairKey
{
	public uint firstGlyphIndex; //Field offset: 0x0
	public uint secondGlyphIndex; //Field offset: 0x4
	public uint key; //Field offset: 0x8

	public GlyphPairKey(uint firstGlyphIndex, uint secondGlyphIndex) { }

	internal GlyphPairKey(TMP_GlyphPairAdjustmentRecord record) { }

}

