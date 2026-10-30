namespace PazuCore.RemoteAssetsGC;

public static class RemoteAssetsGCManager
{
	internal enum AssetType
	{
		None = 0,
		Texture = 1,
		AudioClip = 2,
	}

	private static class Keys
	{
		public const string DATA = "PazuCore_RemoteAssetsGC_Data"; //Field offset: 0x0

	}

	private static RemoteAssetsGCData _data; //Field offset: 0x0

	private static void DeleteAsset(AssetType assetType, string assetName, bool isSharedAsset) { }

	private static int DeleteUnusedAssetsFrom(AssetType assetType, HashSet<String> assetNamesToTest, bool areSharedAssets) { }

	private static string GetKey(string key) { }

	public static void LoadData() { }

	public static void SetRequiredAduioClips(string key, HashSet<String> assetNames) { }

	public static void SetRequiredAssets(AssetType assetType, string key, HashSet<String> assetNames, bool areSharedAssets = true) { }

	public static void SetRequiredTextures(string key, HashSet<String> assetNames, bool areSharedAssets = true) { }

}

