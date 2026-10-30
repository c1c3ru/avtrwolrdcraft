namespace PWC.Level;

public class ClothesDropUtils
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass10_0
	{
		public LevelType type; //Field offset: 0x10

		public <>c__DisplayClass10_0() { }

		internal bool <SetIsNotificationSeen>b__0(LevelTypeToLastClothesDropName x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass12_0
	{
		public LevelType type; //Field offset: 0x10

		public <>c__DisplayClass12_0() { }

		internal bool <MarkLastSeen>b__0(LevelTypeToLastClothesDropName x) { }

	}

	internal class LevelTypeToLastClothesDropName
	{
		public LevelType levelType; //Field offset: 0x10
		public string lastDropName; //Field offset: 0x18
		public bool isNotificationSeen; //Field offset: 0x20

		public LevelTypeToLastClothesDropName() { }

	}

	internal class ShopDropInteractionTable
	{
		public List<LevelTypeToLastClothesDropName> lastDropNameInteractionHistory; //Field offset: 0x10

		public ShopDropInteractionTable() { }

	}

	private static Dictionary<LevelType, ClothesDropDataMap> levelToClothesDropMapDictionary; //Field offset: 0x0
	private const string CLOTHES_DROP_MAP_PATH = "Level/ClothesDropSystemMap/ClothesDropMap_"; //Field offset: 0x0
	private const string SHOP_DROP_INTERACTION_DATA_KEY = "PWC_World_ShopDropInteractionHistory"; //Field offset: 0x0
	private const int LAST_CHANCE_DURATION_HOURS = 24; //Field offset: 0x0
	public const int LAST_CHANCE_DURATION = 86400000; //Field offset: 0x0
	public const int HOUR_OF_UPDATE = 14; //Field offset: 0x0

	public ClothesDropUtils() { }

	public static bool CheckIsAnyLastChanceDropExist() { }

	public static bool CheckIsAnyNewDropExist(long currentTime, out LevelType levelType) { }

	private static void EnsureData() { }

	private static string GetCurrentDropName(LevelType levelType, long currentTime) { }

	public static ClothesDropDataMap GetDataMapByLevelType(LevelType type) { }

	public static bool GetIsNotificationSeen(LevelType type) { }

	public static string GetLastDropNameSeen(LevelType type) { }

	public static Sprite GetWidgetIconByLevelType(LevelType type) { }

	public static void MarkLastSeen(LevelType type, string dropName) { }

	public static void OnLevelEnter(LevelType type, long currentTime) { }

	public static void SetIsNotificationSeen(LevelType type, bool value) { }

}

