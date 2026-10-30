namespace PazuCore;

public static class KeychainManager
{
	private static string _editorDataFilePath; //Field offset: 0x0
	private static readonly Dictionary<String, String> _cache; //Field offset: 0x8

	private static KeychainManager() { }

	public static void ClearCache() { }

	public static bool DeleteKey(string key) { }

	public static void EditorDeleteAllData() { }

	private static bool EditorDeleteKey(string key) { }

	private static string EditorGetString(string key) { }

	private static void EditorInitIfNeeded() { }

	private static Dictionary<String, Object> EditorLoadData() { }

	private static void EditorSaveData(Dictionary<String, Object> data) { }

	private static bool EditorSetString(string key, string value) { }

	private static string GetDeviceUniqueIdentifier() { }

	public static float GetFloat(string key) { }

	public static int GetInt(string key) { }

	private static string GetKeyForEnvironment(string key) { }

	public static string GetString(string key) { }

	public static bool IsReady() { }

	public static void OnGameResume() { }

	public static bool SetFloat(string key, float value) { }

	public static bool SetInt(string key, int value) { }

	public static bool SetString(string key, string value) { }

}

