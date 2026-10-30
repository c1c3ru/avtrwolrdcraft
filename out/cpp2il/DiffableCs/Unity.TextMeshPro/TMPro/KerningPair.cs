namespace TMPro;

public class KerningPair
{
	internal static KerningPair empty; //Field offset: 0x0
	[FormerlySerializedAs("AscII_Left")]
	[SerializeField]
	private uint m_FirstGlyph; //Field offset: 0x10
	[SerializeField]
	private GlyphValueRecord_Legacy m_FirstGlyphAdjustments; //Field offset: 0x14
	[FormerlySerializedAs("AscII_Right")]
	[SerializeField]
	private uint m_SecondGlyph; //Field offset: 0x24
	[SerializeField]
	private GlyphValueRecord_Legacy m_SecondGlyphAdjustments; //Field offset: 0x28
	[FormerlySerializedAs("XadvanceOffset")]
	public float xOffset; //Field offset: 0x38
	[SerializeField]
	private bool m_IgnoreSpacingAdjustments; //Field offset: 0x3C

	public uint firstGlyph
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public GlyphValueRecord_Legacy firstGlyphAdjustments
	{
		 get { } //Length: 12
	}

	public bool ignoreSpacingAdjustments
	{
		 get { } //Length: 8
	}

	public uint secondGlyph
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public GlyphValueRecord_Legacy secondGlyphAdjustments
	{
		 get { } //Length: 12
	}

	private static KerningPair() { }

	public KerningPair() { }

	public KerningPair(uint left, uint right, float offset) { }

	public KerningPair(uint firstGlyph, GlyphValueRecord_Legacy firstGlyphAdjustments, uint secondGlyph, GlyphValueRecord_Legacy secondGlyphAdjustments) { }

	internal void ConvertLegacyKerningData() { }

	public uint get_firstGlyph() { }

	public GlyphValueRecord_Legacy get_firstGlyphAdjustments() { }

	public bool get_ignoreSpacingAdjustments() { }

	public uint get_secondGlyph() { }

	public GlyphValueRecord_Legacy get_secondGlyphAdjustments() { }

	public void set_firstGlyph(uint value) { }

	public void set_secondGlyph(uint value) { }

}

