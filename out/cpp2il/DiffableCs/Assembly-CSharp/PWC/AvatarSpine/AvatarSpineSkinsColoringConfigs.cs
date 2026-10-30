namespace PWC.AvatarSpine;

public static class AvatarSpineSkinsColoringConfigs
{
	private class TextAssetData
	{
		internal class Config
		{
			public string type; //Field offset: 0x10
			public AvatarSpineRotationConfig rotation; //Field offset: 0x18
			public string opType; //Field offset: 0x20
			public int multiColorCount; //Field offset: 0x28

			public Config() { }

		}

		public string spineType; //Field offset: 0x10
		public Dictionary<String, Config> configs; //Field offset: 0x18

		public TextAssetData() { }

	}

	private const string FOLDER_PATH = "AvatarSpineSkinsColoringConfigs"; //Field offset: 0x0
	private const int MAX_MULTI_COLOR_COUNT = 3; //Field offset: 0x0
	private static Dictionary<SpineType, Dictionary`2<String, AvatarSpineColoringConfig>> _configs; //Field offset: 0x0

	private static void EnsureData() { }

	public static bool TryGetConfig(SpineType spineType, string skinName, out AvatarSpineColoringConfig config) { }

}

