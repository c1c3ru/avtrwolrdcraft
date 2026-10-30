namespace TMPro;

public class KerningTable
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<KerningPair, UInt32> <>9__7_0; //Field offset: 0x8
		public static Func<KerningPair, UInt32> <>9__7_1; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal uint <SortKerningPairs>b__7_0(KerningPair s) { }

		internal uint <SortKerningPairs>b__7_1(KerningPair s) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass3_0
	{
		public uint first; //Field offset: 0x10
		public uint second; //Field offset: 0x14

		public <>c__DisplayClass3_0() { }

		internal bool <AddKerningPair>b__0(KerningPair item) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass4_0
	{
		public uint first; //Field offset: 0x10
		public uint second; //Field offset: 0x14

		public <>c__DisplayClass4_0() { }

		internal bool <AddGlyphPairAdjustmentRecord>b__0(KerningPair item) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass5_0
	{
		public int left; //Field offset: 0x10
		public int right; //Field offset: 0x14

		public <>c__DisplayClass5_0() { }

		internal bool <RemoveKerningPair>b__0(KerningPair item) { }

	}

	public List<KerningPair> kerningPairs; //Field offset: 0x10

	public KerningTable() { }

	public int AddGlyphPairAdjustmentRecord(uint first, GlyphValueRecord_Legacy firstAdjustments, uint second, GlyphValueRecord_Legacy secondAdjustments) { }

	public void AddKerningPair() { }

	public int AddKerningPair(uint first, uint second, float offset) { }

	public void RemoveKerningPair(int left, int right) { }

	public void RemoveKerningPair(int index) { }

	public void SortKerningPairs() { }

}

