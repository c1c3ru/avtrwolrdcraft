namespace PWC.Level.Maker;

public static class LevelMakerItemsMenuPresets
{
	internal class Data
	{
		public Dictionary<String, List`1<Dictionary`2<String, Object>>> items; //Field offset: 0x10

		public Data() { }

	}

	private const string FILE_NAME = "AW_LevelMakerItemsMenuPresets"; //Field offset: 0x0
	private static Data _data; //Field offset: 0x0

	private static void EnsureData() { }

	public static void SavePreset(string key, LevelMakerCustomizationObjectHandlerBase handler) { }

	public static bool TryLoadPreset(string key, LevelMakerCustomizationObjectHandlerBase handler) { }

}

