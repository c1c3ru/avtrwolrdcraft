namespace TMPro;

public class TMP_FontFeatureTable
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<TMP_GlyphPairAdjustmentRecord, UInt32> <>9__6_0; //Field offset: 0x8
		public static Func<TMP_GlyphPairAdjustmentRecord, UInt32> <>9__6_1; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal uint <SortGlyphPairAdjustmentRecords>b__6_0(TMP_GlyphPairAdjustmentRecord s) { }

		internal uint <SortGlyphPairAdjustmentRecords>b__6_1(TMP_GlyphPairAdjustmentRecord s) { }

	}

	[SerializeField]
	internal List<TMP_GlyphPairAdjustmentRecord> m_GlyphPairAdjustmentRecords; //Field offset: 0x10
	internal Dictionary<UInt32, TMP_GlyphPairAdjustmentRecord> m_GlyphPairAdjustmentRecordLookupDictionary; //Field offset: 0x18

	public List<TMP_GlyphPairAdjustmentRecord> glyphPairAdjustmentRecords
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public TMP_FontFeatureTable() { }

	public List<TMP_GlyphPairAdjustmentRecord> get_glyphPairAdjustmentRecords() { }

	public void set_glyphPairAdjustmentRecords(List<TMP_GlyphPairAdjustmentRecord> value) { }

	public void SortGlyphPairAdjustmentRecords() { }

}

