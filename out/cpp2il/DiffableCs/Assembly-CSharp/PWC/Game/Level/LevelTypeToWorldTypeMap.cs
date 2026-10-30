namespace PWC.Game.Level;

public class LevelTypeToWorldTypeMap : ScriptableObject
{
	internal class LevelTypeToWorldTypeEntry
	{
		public LevelWorldType world; //Field offset: 0x10
		public LevelType levelType; //Field offset: 0x14

		public LevelTypeToWorldTypeEntry(LevelType levelType, LevelWorldType world) { }

	}

	private const string SUMMER_CAMP_SCENE_FOLDER_PATH = "Assets/Game/Towns/SummerCamp/Scenes/"; //Field offset: 0x0
	private const string SUNRISE_HILLS_SCENE_FOLDER_PATH = "Assets/Game/Towns/SunriseHills/Scenes/"; //Field offset: 0x0
	private const string VACATION_SCENE_FOLDER_PATH = "Assets/Game/Towns/Vacation/Scenes/"; //Field offset: 0x0
	private const string STARDUST_CITY_SCENE_FOLDER_PATH = "Assets/Game/Towns/StarDustCity/Scenes/"; //Field offset: 0x0
	private const string COUNTRYSIDE_SCENE_FOLDER_PATH = "Assets/Game/Towns/Countryside/Scenes/"; //Field offset: 0x0
	private const string SNOWYMOUNTAIN_SCENE_FOLDER_PATH = "Assets/Game/Towns/SnowyMountain/Scenes/"; //Field offset: 0x0
	private const string COLLEGE_SCENE_FOLDER_PATH = "Assets/Game/Towns/College/Scenes/"; //Field offset: 0x0
	private const string UGC_SCENE_FOLDER_PATH = "Assets/Game/Towns/UGC/Scenes/"; //Field offset: 0x0
	private static Dictionary<LevelType, LevelWorldType> dictionary; //Field offset: 0x0
	[SerializeField]
	public List<LevelTypeToWorldTypeEntry> levelToWorldList; //Field offset: 0x18

	public LevelTypeToWorldTypeMap() { }

	public Dictionary<LevelType, LevelWorldType> GetDictionary() { }

}

