namespace PazuCore.Analytics.Internal.ChangeTracking;

public static class ChangeTrackingManager
{
	internal static class KeychainKeys
	{
		public const string DEVICE_NEW = "PazuCore_Analytics_ChangeTracking_DeviceNew"; //Field offset: 0x0
		public const string INSTALL_NEW_PREFIX = "PazuCore_Analytics_ChangeTracking_InstallNew_"; //Field offset: 0x0

	}

	internal static class LocalKeys
	{
		public const string GAME_INFO = "PazuCore_Analytics_ChangeTracking_GameInfo"; //Field offset: 0x0

	}

	internal static class SharedKeys
	{
		public const string DEVICE_INFO = "PazuCore_Analytics_ChangeTracking_DeviceInfo"; //Field offset: 0x0

	}


	public static void AddEventsIfNeeded() { }

	public static void DeleteAllData() { }

	public static void DeleteGameInfoData() { }

	private static string GetInstallNewKey() { }

	private static string GetKey(string key) { }

	public static string GetLog() { }

	private static void SaveDeviceInfo() { }

	private static void SaveGameInfo() { }

}

