namespace PWC.Level.Maker.CustomizationConfig;

public static class LevelMakerCCCSVParser
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Action<LevelMakerCCColors, String> <>9__3_0; //Field offset: 0x8
		public static Action<LevelMakerCCGroup, String> <>9__6_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal void <ParseGroups>b__6_0(LevelMakerCCGroup data, string value) { }

		internal void <PraseColors>b__3_0(LevelMakerCCColors data, string value) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass4_0
	{
		public TextAsset textAsset; //Field offset: 0x10

		public <>c__DisplayClass4_0() { }

		internal void <PraseTiles>b__0(LevelMakerCCTiles data, string value) { }

	}

	private const string PALETTE_ROW = "PaletteRow"; //Field offset: 0x0

	private static void GetColumnsValues(String[][] tables, int index, List<String> resluts) { }

	private static String[][] GetTableFromText(string text) { }

	private static void ParseGeneric(TextAsset textAsset, string namePrefix, Dictionary<String, LevelMakerCCBase> results, Action<T, String> setValueAction) { }

	private static void ParseGroups(TextAsset textAsset, Dictionary<String, LevelMakerCCBase> results) { }

	private static InventoryFlagType ParseInventoryFlagType(string name) { }

	public static Dictionary<String, LevelMakerCCBase> Prase(string path) { }

	public static Dictionary<String, LevelMakerCCBase> Prase(TextAsset[] textAssets) { }

	private static void PraseColors(TextAsset textAsset, Dictionary<String, LevelMakerCCBase> results) { }

	private static void PraseTiles(TextAsset textAsset, Dictionary<String, LevelMakerCCBase> results) { }

	private static bool TryGetTableFromAsset(TextAsset textAsset, out String[][] table) { }

	public static bool TryGetText(string path, out string text) { }

}

