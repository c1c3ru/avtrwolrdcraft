namespace TMPro;

public class TMP_GlyphPairAdjustmentRecord
{
	[SerializeField]
	internal TMP_GlyphAdjustmentRecord m_FirstAdjustmentRecord; //Field offset: 0x10
	[SerializeField]
	internal TMP_GlyphAdjustmentRecord m_SecondAdjustmentRecord; //Field offset: 0x24
	[SerializeField]
	internal FontFeatureLookupFlags m_FeatureLookupFlags; //Field offset: 0x38

	public FontFeatureLookupFlags featureLookupFlags
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public TMP_GlyphAdjustmentRecord firstAdjustmentRecord
	{
		 get { } //Length: 20
		 set { } //Length: 20
	}

	public TMP_GlyphAdjustmentRecord secondAdjustmentRecord
	{
		 get { } //Length: 20
		 set { } //Length: 20
	}

	public TMP_GlyphPairAdjustmentRecord(TMP_GlyphAdjustmentRecord firstAdjustmentRecord, TMP_GlyphAdjustmentRecord secondAdjustmentRecord) { }

	internal TMP_GlyphPairAdjustmentRecord(GlyphPairAdjustmentRecord glyphPairAdjustmentRecord) { }

	public FontFeatureLookupFlags get_featureLookupFlags() { }

	public TMP_GlyphAdjustmentRecord get_firstAdjustmentRecord() { }

	public TMP_GlyphAdjustmentRecord get_secondAdjustmentRecord() { }

	public void set_featureLookupFlags(FontFeatureLookupFlags value) { }

	public void set_firstAdjustmentRecord(TMP_GlyphAdjustmentRecord value) { }

	public void set_secondAdjustmentRecord(TMP_GlyphAdjustmentRecord value) { }

}

