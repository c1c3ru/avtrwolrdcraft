namespace PWC.LevelPhone.AchievementsApp;

public static class HuntsAchievementData
{
	private static Dictionary<String, HuntData> _achievementHuntDictionary; //Field offset: 0x0
	private const string HUNT_DATA_RESOURCES_PATH = "Achievements/BuildHunts"; //Field offset: 0x0
	private const string SERVER_HUNT_DATA_RESOURCES_PATH = "Achievements/SeverDependentHunts"; //Field offset: 0x0
	private const string SERVER_HUNT_DATA_KEY = "activeServerHuntGUIDs"; //Field offset: 0x0
	private const string EVENT_HUNT_DATA_RESOURCES_PATH = "Achievements/EventHunts"; //Field offset: 0x0
	private const string EVENT_HUNT_DATA_KEY = "enabledEventHuntGUIDs"; //Field offset: 0x0
	private static Dictionary<ValueTuple`2<LevelType, Int32>, HuntData> _secretIDToHuntDictionary; //Field offset: 0x8
	private static Dictionary<LevelType, HuntData[]> _huntsByLevelType; //Field offset: 0x10
	private static HashSet<String> _activeServerHuntGUIDs; //Field offset: 0x18
	private static HashSet<String> _newHuntsFromServer; //Field offset: 0x20
	[CompilerGenerated]
	private static Action OnNewServerHuntRequiresReloadAction; //Field offset: 0x28

	public static event Action OnNewServerHuntRequiresReloadAction
	{
		[CompilerGenerated]
		 add { } //Length: 188
		[CompilerGenerated]
		 remove { } //Length: 188
	}

	[CompilerGenerated]
	public static void add_OnNewServerHuntRequiresReloadAction(Action value) { }

	private static void AddEnabledEventHuntsToDictionary() { }

	private static void AddServerActiveHuntsToDictionary() { }

	private static void BuildHuntsByLevelTypeCache() { }

	public static void EnsureServerHuntsLoaded() { }

	private static HuntData FindEventHunt(string huntGUID) { }

	public static HuntData GetHuntBySecretID(LevelType levelType, int secretID) { }

	public static HuntData[] GetHuntsByLevelType(LevelType levelType) { }

	public static Dictionary<String, HuntData> GetHuntsDictionary() { }

	private static Dictionary<ValueTuple`2<LevelType, Int32>, HuntData> GetSecretIDToHuntDictionary() { }

	public static bool IsEventHuntEnabled(string huntGUID) { }

	private static HashSet<String> LoadEnabledEventHuntGUIDs() { }

	private static void RegisterEnabledEventHunt(HuntData hunt) { }

	[CompilerGenerated]
	public static void remove_OnNewServerHuntRequiresReloadAction(Action value) { }

	public static bool TryEnableEventHunt(string huntGUID) { }

}

