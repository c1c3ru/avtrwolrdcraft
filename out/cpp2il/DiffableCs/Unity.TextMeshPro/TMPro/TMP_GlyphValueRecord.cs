namespace TMPro;

public struct TMP_GlyphValueRecord
{
	[SerializeField]
	internal float m_XPlacement; //Field offset: 0x0
	[SerializeField]
	internal float m_YPlacement; //Field offset: 0x4
	[SerializeField]
	internal float m_XAdvance; //Field offset: 0x8
	[SerializeField]
	internal float m_YAdvance; //Field offset: 0xC

	public float xAdvance
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float xPlacement
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float yAdvance
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public float yPlacement
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public TMP_GlyphValueRecord(float xPlacement, float yPlacement, float xAdvance, float yAdvance) { }

	internal TMP_GlyphValueRecord(GlyphValueRecord_Legacy valueRecord) { }

	internal TMP_GlyphValueRecord(GlyphValueRecord valueRecord) { }

	public float get_xAdvance() { }

	public float get_xPlacement() { }

	public float get_yAdvance() { }

	public float get_yPlacement() { }

	public static TMP_GlyphValueRecord op_Addition(TMP_GlyphValueRecord a, TMP_GlyphValueRecord b) { }

	public void set_xAdvance(float value) { }

	public void set_xPlacement(float value) { }

	public void set_yAdvance(float value) { }

	public void set_yPlacement(float value) { }

}

