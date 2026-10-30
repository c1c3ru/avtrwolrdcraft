namespace PWC.WorldMakerData;

public static class WorldMakerDataManager
{
	[CompilerGenerated]
	private static string <CurrentMakerHouseID>k__BackingField; //Field offset: 0x0
	public const string MAKER_HOUSE_DATA_PLAYER_PREFS_KEY_PREFIX = "WorldMakerHouseData_"; //Field offset: 0x0
	public const string MAKER_STREET_DATA_PLAYER_PREFS_KEY_PREFIX = "WorldMakerStreetData_"; //Field offset: 0x0
	[CompilerGenerated]
	private static WorldMakerStreetType <CurrentMakerStreetType>k__BackingField; //Field offset: 0x8
	[CompilerGenerated]
	private static WorldMakerBuildingType <CurrentMakerBuildingType>k__BackingField; //Field offset: 0xC
	[CompilerGenerated]
	private static int <CurrentMakerLevelID>k__BackingField; //Field offset: 0x10
	public static bool IsCurrentlyBuilding; //Field offset: 0x14

	public static WorldMakerBuildingType CurrentMakerBuildingType
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		 set { } //Length: 76
	}

	public private static string CurrentMakerHouseID
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public static int CurrentMakerLevelID
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		 set { } //Length: 76
	}

	public private static WorldMakerStreetType CurrentMakerStreetType
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 76
	}

	public static void DeleteAllMakerData() { }

	public static void DeleteMakerStreetData(WorldMakerStreetType streetType) { }

	[CompilerGenerated]
	public static WorldMakerBuildingType get_CurrentMakerBuildingType() { }

	[CompilerGenerated]
	public static string get_CurrentMakerHouseID() { }

	[CompilerGenerated]
	public static int get_CurrentMakerLevelID() { }

	[CompilerGenerated]
	public static WorldMakerStreetType get_CurrentMakerStreetType() { }

	public static string GetUniqueMakerLevelSceneID(LevelType levelType, string makerHouseID, int makerLevelID) { }

	public static string GetUniqueMakerLevelSceneIDSuffix(string houseID, int levelID) { }

	public static void SaveMakerHouseData(string makerHouseID, WorldMakerStreetType streetType, WorldMakerBuildingType buildingType, List<MakerLevelData> levelsData) { }

	private static void SaveMakerHouseIDToMakerStreetData(WorldMakerStreetType streetType, string makerHouseID) { }

	private static void SaveMakerStreetData(WorldMakerStreetType streetType, MakerStreetData makerStreetData) { }

	[CompilerGenerated]
	public static void set_CurrentMakerBuildingType(WorldMakerBuildingType value) { }

	[CompilerGenerated]
	private static void set_CurrentMakerHouseID(string value) { }

	[CompilerGenerated]
	public static void set_CurrentMakerLevelID(int value) { }

	[CompilerGenerated]
	private static void set_CurrentMakerStreetType(WorldMakerStreetType value) { }

	public static void SetCurrentMakerHouseData(string makerHouseID, WorldMakerStreetType streetType) { }

	public static bool TryDeleteMakerHouseData(WorldMakerStreetType streetType, string makerHouseID) { }

	public static bool TryLoadMakerHouseData(WorldMakerStreetType streetType, string makerHouseID, bool validateData, out MakerHouseData makerHouseData) { }

	public static bool TryLoadMakerStreetData(WorldMakerStreetType streetType, out MakerStreetData streetData) { }

}

