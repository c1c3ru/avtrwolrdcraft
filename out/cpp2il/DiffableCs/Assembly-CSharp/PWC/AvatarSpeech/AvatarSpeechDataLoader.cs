namespace PWC.AvatarSpeech;

public static class AvatarSpeechDataLoader
{
	internal class Data
	{
		internal class Item
		{
			public string id; //Field offset: 0x10
			public Dictionary<String, String> texts; //Field offset: 0x18
			public string animationName; //Field offset: 0x20
			private string _key; //Field offset: 0x28

			public Item() { }

			public string GetDataKey() { }

			public string GetTextForCurrentLangauge() { }

		}

		public string key; //Field offset: 0x10
		public Dictionary<String, Dictionary`2<String, List`1<Item>>> categories; //Field offset: 0x18
		public Dictionary<String, Item> itemsById; //Field offset: 0x20
		public Dictionary<String, String> availableLangauges; //Field offset: 0x28

		public Data() { }

	}

	private static readonly Dictionary<String, Data> _data; //Field offset: 0x0

	private static AvatarSpeechDataLoader() { }

	[CompilerGenerated]
	internal static bool <TryParseData>g__TryGetLanguageData|3_0(string value, out string languageCode, out string langaugeName) { }

	public static bool TryGetData(string key, out Data data) { }

	private static bool TryParseData(string key, string text, out Data data) { }

}

