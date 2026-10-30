namespace ExtraAnimations;

public static class CAAnimationsExtensionsUtils
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass10_0
	{
		public string className; //Field offset: 0x10

		public <>c__DisplayClass10_0() { }

		internal bool <GetAnimationsFolderFromClassName>b__0(LevelCAItemHandlerData x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass11_0
	{
		public string className; //Field offset: 0x10

		public <>c__DisplayClass11_0() { }

		internal bool <TryGetCAItemHandlerFromClassName>b__0(LevelCAItemHandlerData x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass14_0
	{
		public string handlerClassName; //Field offset: 0x10

		public <>c__DisplayClass14_0() { }

		internal bool <IsCAHandlerInMap>b__0(LevelCAItemHandlerData x) { }

		internal bool <IsCAHandlerInMap>b__1(CAAnimationsExtensions x) { }

		internal bool <IsCAHandlerInMap>b__2(CAAnimationsExtensions x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass17_0
	{
		public string className; //Field offset: 0x10

		public <>c__DisplayClass17_0() { }

		internal bool <GetExtendedAnimationDataIfExist>b__0(ExtraAnimationsClassNameAndLevels x) { }

		internal bool <GetExtendedAnimationDataIfExist>b__1(CAAnimationsExtensions x) { }

	}

	public const string FILE_NAME_PREFIX = "CAExtensions_"; //Field offset: 0x0
	public const string CA_EXTENSIONS_PATH = "Level/CAExtensions/"; //Field offset: 0x0
	public const string EXTRA_ANIMATIONS_DATA_KEY = "Extra_Animations_Data"; //Field offset: 0x0
	private const string CA_EXTENSIONS_MAP_PATH = "Level/CAExtensions/ExtendedAnimationsMap"; //Field offset: 0x0
	private static ExtendedAnimationsMap _map; //Field offset: 0x0

	public static void AddAnimationGroup(string name, int level) { }

	public static void DeleteData() { }

	public static void DeleteUsedAnimations() { }

	private static void EnsureMap() { }

	public static List<LevelCAConfig> GetAllRelevantConfigs(List<LevelCAConfig> levelCAConfigs, string name) { }

	public static string GetAnimationsFolderFromClassName(string className) { }

	public static bool GetCAHandlerIndicationState(LevelCAHandlerBase handler) { }

	public static bool GetCAHudIndicationState(LevelCAHandlerBase handler, LevelCAConfig animationConfig) { }

	public static List<LevelCAConfig> GetExtendedAnimationDataIfExist(string className) { }

	public static List<LevelCAItemHandlerData> GetExtraAnimationsCAWithData() { }

	public static ExtraAnimationsData GetExtraAnimationUserData() { }

	private static bool IsCAHandlerInMap(LevelCAHandlerBase handler, out string className) { }

	public static void MigrateExtraAnimationsFileLocationIfNeeded() { }

	private static void SaveData(ExtraAnimationsData extraAnimationsData) { }

	public static void SetCAHandlerIndicationStateOff(LevelCAHandlerBase handler) { }

	public static void SetCAHudIndicationStateOff(LevelCAHandlerBase handler, LevelCAConfig animationConfig) { }

	public static bool TryGetCAItemHandlerFromClassName(string className, out LevelCAItemHandlerData handler) { }

}

