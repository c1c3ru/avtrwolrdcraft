namespace PWC.WorldReset;

public static class WorldResetManager
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<KeyValuePair`2<String, LevelSceneInfo>, Boolean> <>9__17_0; //Field offset: 0x8
		public static Func<KeyValuePair`2<String, LevelSceneInfo>, IEnumerable`1<PDTextBulkData>> <>9__17_1; //Field offset: 0x10
		public static Func<PDTextBulkData, IEnumerable`1<String>> <>9__17_2; //Field offset: 0x18
		public static Func<SceneObjectData, String> <>9__22_0; //Field offset: 0x20
		public static Predicate<String> <>9__26_0; //Field offset: 0x28
		public static Func<PDPrefab, String> <>9__26_1; //Field offset: 0x30
		public static Func<SceneObjectData, String> <>9__31_3; //Field offset: 0x38

		private static <>c() { }

		public <>c() { }

		internal string <FillPrefabsToKeepFromBulkData>b__22_0(SceneObjectData x) { }

		internal bool <GetPrefabGuidsInBulkDatasInScenes>b__17_0(KeyValuePair<String, LevelSceneInfo> x) { }

		internal IEnumerable<PDTextBulkData> <GetPrefabGuidsInBulkDatasInScenes>b__17_1(KeyValuePair<String, LevelSceneInfo> x) { }

		internal IEnumerable<String> <GetPrefabGuidsInBulkDatasInScenes>b__17_2(PDTextBulkData x) { }

		internal string <ResetScene_HandleAvatarsInScene>b__31_3(SceneObjectData x) { }

		internal bool <ResetStorePack>b__26_0(string iPrefabGuid) { }

		internal string <ResetStorePack>b__26_1(PDPrefab x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass31_0
	{
		public LevelAvatarData avatarData; //Field offset: 0x10

		public <>c__DisplayClass31_0() { }

		internal bool <ResetScene_HandleAvatarsInScene>b__1(AvatarSpineData spineData) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass31_1
	{
		public SkinData skinData; //Field offset: 0x10

		public <>c__DisplayClass31_1() { }

		internal bool <ResetScene_HandleAvatarsInScene>b__2(SkinData sd) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass32_0
	{
		public KeyValuePair<String, UserSceneData> userData; //Field offset: 0x10

		public <>c__DisplayClass32_0() { }

		internal bool <CreateClothingPrefabData>b__0(Item item) { }

	}

	[CompilerGenerated]
	private static Action OnResetWorldDataAction; //Field offset: 0x0
	[CompilerGenerated]
	private static Action OnEnterResetGameModeAction; //Field offset: 0x8
	[CompilerGenerated]
	private static Action OnExitResetGameModeAction; //Field offset: 0x10
	[CompilerGenerated]
	private static bool <IsGameInResetMode>k__BackingField; //Field offset: 0x18

	public static event Action OnEnterResetGameModeAction
	{
		[CompilerGenerated]
		 add { } //Length: 188
		[CompilerGenerated]
		 remove { } //Length: 188
	}

	public static event Action OnExitResetGameModeAction
	{
		[CompilerGenerated]
		 add { } //Length: 188
		[CompilerGenerated]
		 remove { } //Length: 188
	}

	public static event Action OnResetWorldDataAction
	{
		[CompilerGenerated]
		 add { } //Length: 184
		[CompilerGenerated]
		 remove { } //Length: 184
	}

	public private static bool IsGameInResetMode
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 80
	}

	[CompilerGenerated]
	internal static bool <ResetScene_HandleAvatarsInScene>g__EnsureNewUserSceneData|31_0(string sceneName, PDScene defaultDataPDScene, ref UserSceneData newLevelUserData, ref bool didCallEnsureNewUserSceneData) { }

	[CompilerGenerated]
	internal static void <ResetScene>g__ResetLevelWithItemDataIfNeeded|30_0(string prefabGuid) { }

	[CompilerGenerated]
	public static void add_OnEnterResetGameModeAction(Action value) { }

	[CompilerGenerated]
	public static void add_OnExitResetGameModeAction(Action value) { }

	[CompilerGenerated]
	public static void add_OnResetWorldDataAction(Action value) { }

	private static void AddPrefabGuidsLinkedToPrefabs(ICollection<String> prefabGuids) { }

	private static ValueTuple<SceneData, List`1<String>> CreateClothingPrefabData(SpineType spineType, SkinData skinData, Item dataItem, PDPrefab prefab) { }

	public static void DeletePrefabGuidsFromGame(HashSet<String> prefabGuids) { }

	public static void DeleteSceneGuidsFromGame(ICollection<String> sceneObjectGuids, HashSet<String> excludeLevels = null) { }

	public static void EnterResetGameMode() { }

	public static void ExitResetMode() { }

	private static void FillPrefabsToKeepFromBulkData(BulkData bulkData, Dictionary<String, PrefabData> prefabsToKeep, Dictionary<String, Dictionary`2<String, Object>> sceneObjectsToKeep) { }

	[CompilerGenerated]
	public static bool get_IsGameInResetMode() { }

	private static HashSet<String> GetPrefabGuidsInBulkDatasInScenes() { }

	public static string GetStorageUnitSceneName() { }

	public static void OnBeforeDeleteInstancedLevel(string sceneId) { }

	public static void OnBeforeDeleteUGCLevel(string sceneId) { }

	private static void ReleaseAvatarsInScene(UserSceneData userSceneData) { }

	[CompilerGenerated]
	public static void remove_OnEnterResetGameModeAction(Action value) { }

	[CompilerGenerated]
	public static void remove_OnExitResetGameModeAction(Action value) { }

	[CompilerGenerated]
	public static void remove_OnResetWorldDataAction(Action value) { }

	private static void RemoveUndeletablePrefabsFromList(HashSet<String> prefabGuids) { }

	public static void ResetScene(string sceneName, HashSet<String> alreadyResetScenes = null) { }

	private static void ResetScene_HandleAvatarsInScene(string sceneName, PDScene defaultDataPDScene, string sceneGuid, PremadeAvatarSpineDataList premadeAvatarSpineDataList, ref UserSceneData newLevelUserData, ref bool didCallEnsureNewUserSceneData) { }

	public static void ResetStorePack(StorePackType storePackType, string storeItemGuid) { }

	public static void ResetWorldData(bool deleteAvatarsData = true, bool keepPrefabs = true) { }

	[CompilerGenerated]
	private static void set_IsGameInResetMode(bool value) { }

	private static bool ShouldSendPDPrefabToStorageUnit(LevelPDPrefabFlags flags) { }

	public static void TryPushBulkDataToStorageUnits(BulkData bulkData, bool considerExistingData) { }

	private static void TryPushPDPrefabsToStorageUnits(Dictionary<String, PrefabData> prefabsToKeep, Dictionary<String, Dictionary`2<String, Object>> sceneObjectsToKeep, bool considerExistingData) { }

}

