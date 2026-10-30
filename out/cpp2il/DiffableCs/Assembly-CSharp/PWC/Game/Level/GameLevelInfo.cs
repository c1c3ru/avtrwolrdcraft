namespace PWC.Game.Level;

public static class GameLevelInfo
{
	private const string LEVEL_TO_WORLD_MAP_PATH = "Level/WorldViews/LevelTypeToWorldTypeMap"; //Field offset: 0x0
	private static LevelTypeToWorldTypeMap _levelTypeToWorldTypeMap; //Field offset: 0x0
	public const string SNOWY_MOUNTAIN_SEEN_KEY = "SNOWY_MOUNTAIN_SEEN"; //Field offset: 0x0
	public const string STARDUST_CITY_SEEN_KEY = "STARDUST_CITY_SEEN"; //Field offset: 0x0
	public const string STARDUST_CITY_FOCUS_PREMIER_KEY = "STARDUST_CITY_FOCUS_PREMIER"; //Field offset: 0x0
	public const string WORLD_CITY_SEEN_KEY = "WORLD_SEEN"; //Field offset: 0x0
	public const string WORLD_CITY_FOCUS_COUNTRY_CLUB_KEY = "WORLD_FOCUS_COUNTRY_CLUB"; //Field offset: 0x0

	private static void EnsureLevelTypeToWorldTypeMap() { }

	public static string GetSceneNameForNewAvatar(SpineType spineType, out bool isLevel) { }

	public static string GetWorldSceneNameByLevelSceneName(string sceneName) { }

	public static string GetWorldSceneNameByLevelType(LevelType levelType) { }

}

