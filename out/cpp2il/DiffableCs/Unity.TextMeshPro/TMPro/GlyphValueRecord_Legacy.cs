namespace TMPro;

public struct GlyphValueRecord_Legacy
{
	public float xPlacement; //Field offset: 0x0
	public float yPlacement; //Field offset: 0x4
	public float xAdvance; //Field offset: 0x8
	public float yAdvance; //Field offset: 0xC

	internal GlyphValueRecord_Legacy(GlyphValueRecord valueRecord) { }

	public static GlyphValueRecord_Legacy op_Addition(GlyphValueRecord_Legacy a, GlyphValueRecord_Legacy b) { }

}

