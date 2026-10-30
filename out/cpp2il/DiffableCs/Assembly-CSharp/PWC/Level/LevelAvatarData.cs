namespace PWC.Level;

public class LevelAvatarData
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass20_0
	{
		public HashSet<Int32> excludeIds; //Field offset: 0x10
		public string prefabGuid; //Field offset: 0x18
		public int count; //Field offset: 0x20

		public <>c__DisplayClass20_0() { }

		internal void <GetPrefabCountInAllAvatars>b__0(LevelAvatarData data) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass21_0
	{
		public SpineType spineType; //Field offset: 0x10
		public string skinName; //Field offset: 0x18
		public int count; //Field offset: 0x20
		public Predicate<SkinData> <>9__1; //Field offset: 0x28

		public <>c__DisplayClass21_0() { }

		internal void <GetClothingCountInAllAvatars>b__0(LevelAvatarData data) { }

		internal bool <GetClothingCountInAllAvatars>b__1(SkinData skinData) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass22_0
	{
		public bool result; //Field offset: 0x10
		public string prefabGuid; //Field offset: 0x18

		public <>c__DisplayClass22_0() { }

		internal void <IsPrefabGuidExistInAnyAvatar>b__0(LevelAvatarData data) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass23_0
	{
		public HashSet<String> sceneGuids; //Field offset: 0x10
		public HashSet<Int32> idsToRemove; //Field offset: 0x18

		public <>c__DisplayClass23_0() { }

		internal void <DeleteSceneGuidsFromAllAvatars>b__0(LevelAvatarData data) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass24_0
	{
		public HashSet<String> prefabGuids; //Field offset: 0x10

		public <>c__DisplayClass24_0() { }

		internal void <DeletePrefabGuidsFromAllAvatars>b__0(LevelAvatarData data) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass25_0
	{
		public HashSet<String> sceneGuids; //Field offset: 0x10

		public <>c__DisplayClass25_0() { }

		internal bool <DeleteSceneGuidsInternal>b__0(ItemData item) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass26_0
	{
		public HashSet<String> prefabGuids; //Field offset: 0x10

		public <>c__DisplayClass26_0() { }

		internal bool <DeletePrefabGuidsInternal>b__0(ItemData item) { }

	}

	internal class ItemData
	{
		internal class SceneObjectData
		{
			public string sceneGuid; //Field offset: 0x10
			public List<String> persistentDataList; //Field offset: 0x18

			public SceneObjectData() { }

		}

		public string prefabGuid; //Field offset: 0x10
		public List<SceneObjectData> sceneObjectsData; //Field offset: 0x18

		public ItemData() { }

	}

	internal class ListOfIds
	{
		public List<Int32> ids; //Field offset: 0x10

		public ListOfIds() { }

	}

	private const string KEY_PREFIX = "LevelCharacterData_"; //Field offset: 0x0
	private const string LIST_KEY = "LevelCharacterData_List"; //Field offset: 0x0
	private static readonly Dictionary<Int32, LevelAvatarData> _cache; //Field offset: 0x0
	private static ListOfIds _listOfIds; //Field offset: 0x8
	public int characterId; //Field offset: 0x10
	public string sceneGuid; //Field offset: 0x18
	public string gameSceneId; //Field offset: 0x20
	public List<String> extraScenesId; //Field offset: 0x28
	public List<ItemData> items; //Field offset: 0x30

	private static LevelAvatarData() { }

	public LevelAvatarData() { }

	private static void AddToSavedListIfNeeded(int avatarId) { }

	public static void ApplyDataIfExists(ILevelAvatar avatar) { }

	public void ApplyDataInternal(ILevelAvatar avatar, bool setItemsData = true) { }

	public static void ClearCache() { }

	public static bool DeleteAllData() { }

	public static bool DeleteData(int id) { }

	public static void DeletePrefabGuidsFromAllAvatars(HashSet<String> prefabGuids) { }

	private void DeletePrefabGuidsInternal(HashSet<String> prefabGuids) { }

	public static void DeleteSceneGuidsFromAllAvatars(HashSet<String> sceneGuids) { }

	private void DeleteSceneGuidsInternal(HashSet<String> sceneGuids) { }

	private static void EnsureListOfIds() { }

	public static int GetClothingCountInAllAvatars(string skinName, SpineType spineType) { }

	private static string GetKeyForAvatar(int avatarId) { }

	public static int GetPrefabCountInAllAvatars(string prefabGuid, HashSet<Int32> excludeIds = null) { }

	public static bool IsPrefabGuidExistInAnyAvatar(string prefabGuid) { }

	public static bool LogData() { }

	public static void Multiplayer_AddPlayerUIDToIDs(int playerUID, HashSet<Int32> ids) { }

	public static IReadOnlyCollection<LevelAvatarData> Multiplayer_GetCache() { }

	public static void Multiplayer_RemovePlayer(int playerUID) { }

	public static void Multiplayer_SetData(LevelAvatarData data) { }

	public static void RestoreData(LevelAvatarData data) { }

	private static void RunOnAllData(Action<LevelAvatarData> action) { }

	public void Save() { }

	public static LevelAvatarData SaveData(ILevelAvatar avatar, bool isInsideScene = true, List<String> newExtraScenesId = null) { }

	private void SaveDataInternal(ILevelAvatar avatar, bool isInsideScene, List<String> extraSceneIds) { }

	public static void SetIDsList(List<Int32> idsList) { }

	public static bool ShouldAvatarBeInGameObjectScene(GameObject gameObject, int id) { }

	public static bool TryGetData(int avatarId, out LevelAvatarData data) { }

	public static bool TryGetDataBySceneGuid(string sceneGuid, out LevelAvatarData data) { }

	public static bool TryGetListOfIds(out List<Int32>& ids) { }

}

