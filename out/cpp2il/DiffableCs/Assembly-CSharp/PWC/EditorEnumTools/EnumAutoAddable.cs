namespace PWC.EditorEnumTools;

public static class EnumAutoAddable
{
	private const string GREENCOLOR = "#00FF00"; //Field offset: 0x0
	private const string YELLOWCOLOR = "#FFFF00"; //Field offset: 0x0
	private const string LINEBEGINSPACER = "        "; //Field offset: 0x0
	private static int _enumIndexTemp; //Field offset: 0x0

	public static void AddInventoryFlagType(string enumType) { }

	public static void AddLevelType(string enumType, string worldType = "") { }

	public static void AddWorldBuildingType(string enumType) { }

	private static void AssetDatabaseRefresh() { }

	private static string EndColor() { }

	public static int GetEnumSavedIndex() { }

	private static string GetFolderPath(string scriptName) { }

	private static string GetFullScriptPath(string scriptName) { }

	public static int GetLevelTypeIndex(string levelTypeName) { }

	private static String[] GetScriptLines(string scriptName) { }

	public static void ResetSavedIndex() { }

	private static string SetNewEnum(string levelName, int index) { }

	private static string StartColor(string color) { }

}

