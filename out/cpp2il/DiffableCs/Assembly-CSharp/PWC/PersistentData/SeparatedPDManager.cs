namespace PWC.PersistentData;

public static class SeparatedPDManager
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<ObjectData> <>9__15_0; //Field offset: 0x8
		public static Predicate<ObjectData> <>9__16_0; //Field offset: 0x10
		public static Predicate<PDPrefab> <>9__28_0; //Field offset: 0x18

		private static <>c() { }

		public <>c() { }

		internal bool <DeletePrefabGuidsFromBulkData>b__16_0(ObjectData item) { }

		internal bool <DeleteSceneGuidsFromBulkData>b__15_0(ObjectData item) { }

		internal bool <TrySpawnObjectsFromBulkDataObject>b__28_0(PDPrefab x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass11_0
	{
		public string prefabGuid; //Field offset: 0x10
		public int count; //Field offset: 0x18

		public <>c__DisplayClass11_0() { }

		internal void <GetPrefabGuidCountInAnyFile>b__0(string key, BulkData bulkData) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass12_0
	{
		public bool result; //Field offset: 0x10
		public string prefabGuid; //Field offset: 0x18

		public <>c__DisplayClass12_0() { }

		internal void <IsPrefabGuidExistInAnyFile>b__0(string key, BulkData bulkData) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass13_0
	{
		public HashSet<String> sceneGuids; //Field offset: 0x10

		public <>c__DisplayClass13_0() { }

		internal void <DeleteSceneGuidsFromAllFiles>b__0(string key, BulkData bulkData) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass14_0
	{
		public HashSet<String> prefabGuids; //Field offset: 0x10

		public <>c__DisplayClass14_0() { }

		internal void <DeletePrefabGuidsFromAllFiles>b__0(string key, BulkData bulkData) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass15_0
	{
		public HashSet<String> sceneGuids; //Field offset: 0x10
		public Predicate<ItemData> <>9__1; //Field offset: 0x18

		public <>c__DisplayClass15_0() { }

		internal bool <DeleteSceneGuidsFromBulkData>b__1(ItemData item) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass16_0
	{
		public HashSet<String> prefabGuids; //Field offset: 0x10
		public Predicate<ItemData> <>9__1; //Field offset: 0x18

		public <>c__DisplayClass16_0() { }

		internal bool <DeletePrefabGuidsFromBulkData>b__1(ItemData item) { }

	}

	internal class BulkData
	{
		public bool isDirty; //Field offset: 0x10
		public string extraData; //Field offset: 0x18
		public List<ObjectData> items; //Field offset: 0x20

		public BulkData() { }

	}

	internal class ObjectData
	{
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

		public string prefabGuid; //Field offset: 0x10
		public string sceneGuid; //Field offset: 0x18
		public List<ItemData> items; //Field offset: 0x20

		public ObjectData() { }

	}

	private static readonly Dictionary<String, BulkData> _data; //Field offset: 0x0
	private const string FILE_PREFIX = "PazuWorld_SeparatedPD_"; //Field offset: 0x0
	[CompilerGenerated]
	private static Action<List`1<PDPrefab>> OnSpawnObjectsFromBulkDataAction; //Field offset: 0x8

	public static event Action<List`1<PDPrefab>> OnSpawnObjectsFromBulkDataAction
	{
		[CompilerGenerated]
		 add { } //Length: 244
		[CompilerGenerated]
		 remove { } //Length: 244
	}

	private static SeparatedPDManager() { }

	[CompilerGenerated]
	public static void add_OnSpawnObjectsFromBulkDataAction(Action<List`1<PDPrefab>> value) { }

	public static BulkData AddToBulkData(string key, PDPrefab pdPrefab) { }

	public static void DeleteAllData() { }

	public static void DeleteKey(string key, bool makeDeleteFileCommand = true) { }

	public static void DeletePrefabGuidsFromAllFiles(HashSet<String> prefabGuids) { }

	private static void DeletePrefabGuidsFromBulkData(BulkData bulkData, HashSet<String> prefabGuids) { }

	public static void DeleteSceneGuidsFromAllFiles(HashSet<String> sceneGuids) { }

	public static void DeleteSceneGuidsFromBulkData(BulkData bulkData, HashSet<String> sceneGuids) { }

	public static void EnsureFolder() { }

	private static string GetFileKey(string key) { }

	private static string GetFolder() { }

	public static int GetPrefabGuidCountInAnyFile(string prefabGuid) { }

	public static bool IsPrefabGuidExistInAnyFile(string prefabGuid) { }

	public static void OnSavePersistentData() { }

	[CompilerGenerated]
	public static void remove_OnSpawnObjectsFromBulkDataAction(Action<List`1<PDPrefab>> value) { }

	private static void RunOnAllDataBulkData(Action<String, BulkData> action) { }

	public static void SaveDataIfDirty() { }

	private static PDPrefab SpawnObjectFromData(ObjectData objectData) { }

	public static bool TryCreateObjectDataFromPDPrefab(PDPrefab pdPrefab, out ObjectData objectData) { }

	public static bool TryCreateObjectDataWithoutPDPrefab(GameObject root, out ObjectData objectData) { }

	public static bool TryLoadBulkData(string key, out BulkData bulkData) { }

	private static void TryLoadPDForObjectData(ObjectData objectData, out List<GameObject>& sceneElementList) { }

	private static void TryLoadPDForObjectData(ObjectData objectData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public static bool TryLoadSceneElementsPDFromBulkDataObject(BulkData bulkData, out List<GameObject>& sceneElementList) { }

	public static bool TrySpawnObjectsFromBulkData(string key, out List<PDPrefab>& list, bool shouldDeleteData = true, bool allowMultiplayerEvent = true) { }

	public static bool TrySpawnObjectsFromBulkDataFromText(string text, out List<PDPrefab>& list) { }

	public static bool TrySpawnObjectsFromBulkDataObject(BulkData bulkData, out List<PDPrefab>& list, bool allowMultiplayerEvent = true) { }

}

