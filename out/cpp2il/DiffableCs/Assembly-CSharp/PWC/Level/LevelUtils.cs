namespace PWC.Level;

public static class LevelUtils
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass18_0
	{
		public ILevelAvatar iAvatar; //Field offset: 0x10

		public <>c__DisplayClass18_0() { }

		internal bool <SpawnAvatar>b__0(ILevelAvatar x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass26_0
	{
		public string vehicleGuid; //Field offset: 0x10

		public <>c__DisplayClass26_0() { }

		internal bool <CallVehicle>b__0(LevelPlayerVehicle x) { }

		internal bool <CallVehicle>b__1(PDPrefab x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass29_0
	{
		public string carSceneGuid; //Field offset: 0x10

		public <>c__DisplayClass29_0() { }

		internal bool <CallCar>b__0(PDPrefab x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass37_0
	{
		public ILevelAvatar newAvatar; //Field offset: 0x10

		public <>c__DisplayClass37_0() { }

		internal bool <UpdateAvatarsOnSpawnedBulkData>b__0(ILevelAvatar x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass37_1
	{
		public ILevelAvatar childAvatar; //Field offset: 0x10

		public <>c__DisplayClass37_1() { }

		internal bool <UpdateAvatarsOnSpawnedBulkData>b__1(ILevelAvatar x) { }

	}

	[CompilerGenerated]
	private static Action<LevelItem> OnSpawnLevelItemDuringGameplayAction; //Field offset: 0x0
	[CompilerGenerated]
	private static Action<LevelItem> OnBeforeDestroyLevelItemAction; //Field offset: 0x8
	[CompilerGenerated]
	private static Action<ILevelAvatar> OnAfterAvatarSpawnAction; //Field offset: 0x10

	public static event Action<ILevelAvatar> OnAfterAvatarSpawnAction
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	public static event Action<LevelItem> OnBeforeDestroyLevelItemAction
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	public static event Action<LevelItem> OnSpawnLevelItemDuringGameplayAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	[CompilerGenerated]
	public static void add_OnAfterAvatarSpawnAction(Action<ILevelAvatar> value) { }

	[CompilerGenerated]
	public static void add_OnBeforeDestroyLevelItemAction(Action<LevelItem> value) { }

	[CompilerGenerated]
	public static void add_OnSpawnLevelItemDuringGameplayAction(Action<LevelItem> value) { }

	public static Vector2 CalculateItemPositionFromPivot(LevelItem levelItem, Vector2 pivot) { }

	public static LevelPlayerVehicle CallCar(int carId) { }

	public static void CallSpawnDuringGameplay(GameObject gameObject) { }

	public static LevelPlayerVehicle CallVehicle(VehicleData vehicleData) { }

	public static bool CanItemInteractWithCharacterArea(LevelItem levelItem, GameShape actionHandlerGameShape, LevelCharacter character, AreaType areaType) { }

	public static bool CanItemInteractWithConsumer(LevelItem levelItem, ILevelConsumer consumer, bool isStrict = true, bool isPointOnly = false) { }

	private static void ClearLevelAvatarDataFromBulkData(string bulkDataName, ILevelAvatar avatar) { }

	public static string CreateSceneGuidForAvatar(int avatarId) { }

	public static string CreateSceneGuidForCar(int carId) { }

	public static void DeleteCarFromGame(int carId) { }

	public static void DestroyLevelItem(LevelItem levelItem, bool shouldAddRestoreData = true) { }

	public static PDPrefab GetAvatarPrefab(SpineType spineType) { }

	public static string GetResourcesPathForClothing(SpineType spineType, int categoryType, string skinName) { }

	public static string GetResourcesPathForClothingFolder(SpineType spineType, int categoryType) { }

	public static LevelDropArea GetTopmostDropArea(LevelDropArea dropArea) { }

	private static void GetTouchingPoints(Vector2[] touchTestLocalPoints, CShapeModel targetCShapeModel, CShapeModel consumerCShapeModel, List<Vector2> outTouchingPoints) { }

	public static bool IsCarBuiltFromBreed(GameObject carGameObject, string breed) { }

	private static bool IsCarBuiltFromBreedPrefab(GameObject carGameObject, PDPrefab breedPrefab) { }

	private static bool IsDeletedAvatar(int id, List<Int32> makerIds) { }

	public static bool IsItemTopAboveArea(LevelItem levelItem, LevelAreaBase area) { }

	public static bool IsTouchingGameShapeAreaVisibleToUser(Transform target, GameShapeBase targetGameShape, ILevelConsumer consumer, CShapeModel consumerCShapeModel = null) { }

	public static bool IsTouchingPointVisibleToUser(Transform target, Vector2 point, ILevelConsumer consumer) { }

	private static void Multiplayer_TrySpawnAvatar(int avatarId, Vector2 position, Transform parent, PDPrefabReference prefabOverride, MPOneCallGeneratorData oneCallData, bool ignoreIsAvatarInPhoneTest = false) { }

	public static void PutItemsInDropAreaInRandomPositions(LevelDropArea dropArea, IList<LevelItem> items) { }

	[CompilerGenerated]
	public static void remove_OnAfterAvatarSpawnAction(Action<ILevelAvatar> value) { }

	[CompilerGenerated]
	public static void remove_OnBeforeDestroyLevelItemAction(Action<LevelItem> value) { }

	[CompilerGenerated]
	public static void remove_OnSpawnLevelItemDuringGameplayAction(Action<LevelItem> value) { }

	public static bool SendCarHome(int carId) { }

	public static ILevelAvatar SpawnAvatar(int avatarId, Vector2 position, Transform parent = null, PDPrefabReference prefabOverride = null, Action<PDPrefab> onSpawnAction = null, bool allowMultiplayerEvent = true, MPOneCallGeneratorData multiplayer_oneCallData = null, bool multiplayer_ignoreIsAvatarInPhoneTest = false) { }

	private static PDPrefab SpawnCarFromBreedPrefab(PDPrefab breedPrefab) { }

	private static bool TryApplyCarAppearance(GameObject carGameObject, int carId) { }

	public static bool TryGetCarInLevel(int carId, out LevelPlayerVehicle car) { }

	public static bool TryGetSpineTypeFromID(int id, out SpineType spineType) { }

	public static void UpdateAvatarsOnSpawnedBulkData(List<PDPrefab> pdPrefabs, Transform parent) { }

}

