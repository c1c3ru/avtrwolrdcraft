namespace PWC.AvatarSpine;

public static class AvatarSpineDataManager
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<SkinData> <>9__22_2; //Field offset: 0x8
		public static Predicate<SkinData> <>9__22_3; //Field offset: 0x10
		public static Func<Int32, Int32> <>9__24_0; //Field offset: 0x18
		public static Predicate<Int32> <>9__24_1; //Field offset: 0x20
		public static Predicate<Int32> <>9__25_0; //Field offset: 0x28
		public static Predicate<Int32> <>9__26_0; //Field offset: 0x30

		private static <>c() { }

		public <>c() { }

		internal bool <TryLoadAvatarSpineData>b__22_2(SkinData skinData) { }

		internal bool <TryLoadAvatarSpineData>b__22_3(SkinData skinData) { }

		internal int <TryLoadIDListFromCollection>b__24_0(int id) { }

		internal bool <TryLoadIDListFromCollection>b__24_1(int id) { }

		internal bool <TryLoadMakerOnlyIDList>b__25_0(int id) { }

		internal bool <TryLoadPremadeOnlyIDList>b__26_0(int id) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass53_0
	{
		public int characterID; //Field offset: 0x10

		public <>c__DisplayClass53_0() { }

		internal bool <TryLoadPremadeFromResources>b__0(AvatarSpineData data) { }

	}

	public const int PREMADE_CHARACTERS_ID_GAP = 100000; //Field offset: 0x0
	public const int TEMP_ID_BASE = 900000; //Field offset: 0x0
	public const string AVATAR_SPINE_DATA_PLAYER_PREFS_KEY_PEFIX = "AvatarSpineData_"; //Field offset: 0x0
	public const string AVATAR_SPINE_DATA_ID_LIST_PLAYER_PREFS_KEY = "AvatarSpineDataIDList"; //Field offset: 0x0
	public const string MAKER_EXCLUDED_RESTORE_DATA_KEY = "AvatarSpineDataMakerExcludedDataToRestore"; //Field offset: 0x0
	private static readonly Dictionary<Int32, AvatarSpineData> _dataCache; //Field offset: 0x0
	public const string MAKER_INCLUDED_SKINS_RESOURCES_PATH = "AvatarMaker/MakerIncludedSkinsJson/"; //Field offset: 0x0
	public const string PREMADE_CHARACTERS_RESOURCES_PATH = "PremadeData/"; //Field offset: 0x0
	private static Dictionary<SpineType, HashSet`1<String>> _makerIncludedSkinsDataBySpineType; //Field offset: 0x8
	private static Dictionary<SpineType, Dictionary`2<Int32, HashSet`1<String>>> _makerSkinsDataByCategoryType; //Field offset: 0x10
	private static MakerExcludedRestoreData _makerExcludedRestoreData; //Field offset: 0x18
	private static PremadeAvatarSpineDataList _premadeAvatarSpineDataList; //Field offset: 0x20
	private static Dictionary<Int32, AvatarSpineData> _hashedPremadeAvatarSpineData; //Field offset: 0x28
	private static Dictionary<Int32, HashSet`1<String>> _charactersWithMakerExcludedSkins; //Field offset: 0x30
	public static Func<Int32, SpineType, String, Boolean> TryOverrideHandleMakerExcludedRemovedSkinAction; //Field offset: 0x38

	private static AvatarSpineDataManager() { }

	[CompilerGenerated]
	internal static void <TryLoadAvatarSpineData>g__PerformAvatarSpineDataMigration|22_0(AvatarSpineData data) { }

	[CompilerGenerated]
	internal static void <TryLoadAvatarSpineData>g__PerformAvatarSpineSkinDataMigration|22_1(SpineType spineType, List<SkinData> skinsData) { }

	private static void AddIDToListIfNeeded(int id) { }

	public static void ClearCache() { }

	public static void DeleteAllData() { }

	public static bool DeleteAllMakerData() { }

	public static bool DeleteAllPremadeData() { }

	public static void DeleteCharacter(int id) { }

	private static void DeleteIDFromList(int id) { }

	public static MakerExcludedRestoreData GetMakerExcludedRestoreData() { }

	public static HashSet<String> GetMakerIncludedSkinsByCategoryTypeData(SpineType spineType, int categoryType) { }

	public static int GetNewMakerID() { }

	public static void HandleMakerExcludedRemovedSkin(int avatarId, SpineType spineType, string skinName) { }

	public static void Init() { }

	private static bool IsFaultyToddler(AvatarSpineData data) { }

	public static bool IsMakerExcludedSkin(SpineType spineType, string skinName) { }

	public static bool IsMakerID(int id) { }

	private static bool IsMakerIncludedSkin(SpineType spineType, string skinName) { }

	public static bool IsOldPremadePet(AvatarSpineData data) { }

	public static bool IsPremadeID(int id) { }

	public static bool IsTempID(int id) { }

	private static void LoadMakerExcludedDataToRestore() { }

	public static void LoadMakerIncludedSkinsDataFromResources() { }

	private static void LoadMakerSkinsDataByCategoryType() { }

	private static void LoadPremadeCharactersFromResources() { }

	public static void Multiplayer_AddPlayerUIDToIDs(int playerUID, HashSet<Int32> ids) { }

	public static IReadOnlyCollection<AvatarSpineData> Multiplayer_GetCache() { }

	public static List<AvatarSpineData> Multiplayer_GetCarsData(int ownerPlayerUID = 0) { }

	public static void Multiplayer_LoadPremadeCharactersForClientWithProperIDs(HashSet<Int32> hostAvatarIds) { }

	public static void Multiplayer_RemovePlayer(int playerUID) { }

	public static void Multiplayer_SetCarsData(List<AvatarSpineData> carsData) { }

	private static void RemoveFaultyIDsIfNeeded() { }

	public static void ResetPremadeCharacter(int characterId) { }

	public static void SaveCharacter(AvatarSpineData avatarSpineData) { }

	public static void SaveCharacter(int id, List<SkinData> skinsData, AvatarSizeType sizeType, AvatarSpineConfig config, SpineType spineType) { }

	public static void SaveIDList(List<Int32> ids) { }

	public static void SaveMakerExcludedRestoreDataCurrentState() { }

	public static bool TryGetMakerExcludedSkinsForCharacter(int characterId, out HashSet<String>& makerExcludedSkins) { }

	public static bool TryLoadAvatarSpineData(int id, out AvatarSpineData data) { }

	public static bool TryLoadIDList(out List<Int32>& ids, bool excludeSpecial = true) { }

	private static bool TryLoadIDListFromCollection(ICollection<Int32> sourceIds, out List<Int32>& ids, bool excludeSpecial = true) { }

	public static bool TryLoadMakerOnlyIDList(out List<Int32>& makerIDs) { }

	public static bool TryLoadPremadeCharacterFromResources(int characterId, out AvatarSpineData spineData) { }

	public static bool TryLoadPremadeFromResources(int characterID, out AvatarSpineData avatarSpineData) { }

	public static bool TryLoadPremadeListFromResources(out PremadeAvatarSpineDataList premadeAvatarSpineDataList, bool useCache = true) { }

	public static bool TryLoadPremadeListFromResourcesFromASingleJson(string jsonAssetName, out PremadeAvatarSpineDataList premadeAvatarSpineDataList) { }

	public static bool TryLoadPremadeOnlyIDList(out List<Int32>& premadeIDs) { }

}

