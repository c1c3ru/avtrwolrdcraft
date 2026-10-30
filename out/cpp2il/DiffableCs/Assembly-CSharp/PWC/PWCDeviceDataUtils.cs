namespace PWC;

public static class PWCDeviceDataUtils
{

	private static string GetToken() { }

	public static T LoadDataOrDefault(string fileName, bool usePWCJson = false, bool isPrivateForAndroid = false) { }

	public static void SaveData(string fileName, T data, bool usePWCJson = false, bool isPrivateForAndroid = false) { }

	public static bool TryLoadData(string fileName, out T data, bool usePWCJson = false, bool isPrivateForAndroid = false) { }

}

