namespace PWC.AvatarSpine;

public static class AvatarSpineSkinsDefaultColors
{
	private class TextAssetData
	{
		public string spineType; //Field offset: 0x10
		public Dictionary<String, List`1<String>> colors; //Field offset: 0x18

		public TextAssetData() { }

	}

	private const string FOLDER_PATH = "AvatarSpineSkinsDefaultColors"; //Field offset: 0x0
	private static Dictionary<SpineType, Dictionary`2<String, Color[]>> _colors; //Field offset: 0x0

	private static void EnsureData() { }

	public static bool TryGetDefaultColors(SpineType spineType, string skinName, out Color[] colors) { }

}

