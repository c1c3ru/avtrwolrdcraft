namespace TMPro;

public struct TMP_GlyphAdjustmentRecord
{
	[SerializeField]
	internal uint m_GlyphIndex; //Field offset: 0x0
	[SerializeField]
	internal TMP_GlyphValueRecord m_GlyphValueRecord; //Field offset: 0x4

	public uint glyphIndex
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public TMP_GlyphValueRecord glyphValueRecord
	{
		 get { } //Length: 12
		 set { } //Length: 12
	}

	public TMP_GlyphAdjustmentRecord(uint glyphIndex, TMP_GlyphValueRecord glyphValueRecord) { }

	internal TMP_GlyphAdjustmentRecord(GlyphAdjustmentRecord adjustmentRecord) { }

	public uint get_glyphIndex() { }

	public TMP_GlyphValueRecord get_glyphValueRecord() { }

	public void set_glyphIndex(uint value) { }

	public void set_glyphValueRecord(TMP_GlyphValueRecord value) { }

}

