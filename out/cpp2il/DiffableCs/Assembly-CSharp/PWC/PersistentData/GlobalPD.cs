namespace PWC.PersistentData;

public static class GlobalPD
{

	public static void DeleteData(string key, bool logErrorIfNotExist = true) { }

	private static void EnsureFolder() { }

	private static string GetDirectory() { }

	private static string GetKeyInFolder(string key) { }

	public static void SaveData(string key, string dataString) { }

	public static void SaveData(string key, T data, bool usePWCJson = false) { }

	public static bool TryLoadData(string key, out string dataString) { }

	public static bool TryLoadData(string key, out T data, bool usePWCJson = false) { }

}

