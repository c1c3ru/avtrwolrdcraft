namespace PWC.Level.Maker.CustomizationConfig;

public static class LevelMakerCCMap
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<String, String> <>9__9_0; //Field offset: 0x8
		public static Func<String, Boolean> <>9__9_1; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal string <ParseSharedItems>b__9_0(string x) { }

		internal bool <ParseSharedItems>b__9_1(string x) { }

	}

	private static Dictionary<String, LevelMakerCCBase> _data; //Field offset: 0x0
	private static readonly Dictionary<String, LevelMakerCCMainGroup> _configs; //Field offset: 0x8
	private static readonly Dictionary<CustomizationCategoryType, List`1<String>> _premiumGroups; //Field offset: 0x10
	private static Dictionary<CustomizationCategoryType, List`1<String>> _sharedItems; //Field offset: 0x18

	private static LevelMakerCCMap() { }

	private static void EnsureMap() { }

	public static Dictionary<String, LevelMakerCCBase> GetMap() { }

	private static void GetPremiumPacksByCategoryName(CustomizationCategoryType categoryType, ref List<String>& listToFill) { }

	private static void GetSharedByCategoryName(CustomizationCategoryType categoryType, ref List<String>& listToFill) { }

	private static Dictionary<CustomizationCategoryType, List`1<String>> ParseSharedItems() { }

	public static bool TryGetConfig(string name, out LevelMakerCCMainGroup item) { }

	public static bool TryGetData(string name, out LevelMakerCCBase item) { }

}

