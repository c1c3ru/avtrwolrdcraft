namespace PWC;

public static class PWCSecuredDataUtils
{

	public static T LoadDataOrDefault(string fileName, string token, bool usePWCJson = false, bool isPrivateForAndroid = false) { }

	public static void SaveData(string fileName, string token, T data, bool usePWCJson = false, bool isPrivateForAndroid = false) { }

	public static bool TryLoadData(string fileName, string token, out T data, bool usePWCJson = false, bool isPrivateForAndroid = false) { }

}

