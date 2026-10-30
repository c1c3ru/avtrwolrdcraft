namespace PWC.PersistentData;

public class PersistentDataManager : MonoBehaviour
{
	internal sealed class SceneDataDelegate : MulticastDelegate
	{

		public SceneDataDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(Scene scene, out string arg, AsyncCallback callback, object object) { }

		public override bool EndInvoke(out string arg, IAsyncResult result) { }

		public override bool Invoke(Scene scene, out string arg) { }

	}

	internal class StringList
	{
		public List<String> list; //Field offset: 0x10

		public StringList() { }

	}

	private const string NEW_AND_SYNCED_SCENE_GUIDS_KEY = "NewAndSyncedSceneObjects"; //Field offset: 0x0
	public const string ROOT_FOLDER = "/PersistantData/"; //Field offset: 0x0
	public const string REGULR_FOLDER = "Regular"; //Field offset: 0x0
	public const string KEEP_OBJECTS_ON_LOAD_LIST_PLAYERPREFS_KEY = "PazuWorld_PersistantData_KeepObjectsOnLoad"; //Field offset: 0x0
	private const string BUILD_NUMBER_KEY = "BuildNumber"; //Field offset: 0x0
	public const string PREFABS_KEY = "Prefabs"; //Field offset: 0x0
	public const string SCENE_OBJECTS_KEY = "SceneObjects"; //Field offset: 0x0
	public const string DEFAULT_DATA_ROOT = "Level/DefaultData/"; //Field offset: 0x0
	[CompilerGenerated]
	private static Action<Scene> OnDataLoadedAction; //Field offset: 0x0
	private static HashSet<String> _keepSceneObjectsOnLoad; //Field offset: 0x8
	public static Func<String> OverrideGetFolderNameAction; //Field offset: 0x10
	public static SceneDataDelegate TryOverrideSceneDefaultDataFileNameAction; //Field offset: 0x18
	public static SceneDataDelegate TryOverrideFileNameAction; //Field offset: 0x20
	[CompilerGenerated]
	private static Action<Scene> OnPreSaveProgressAction; //Field offset: 0x28
	[CompilerGenerated]
	private static Action<Scene> OnPostSaveProgressAction; //Field offset: 0x30
	[CompilerGenerated]
	private static PersistentDataManager <Instance>k__BackingField; //Field offset: 0x38
	private readonly Dictionary<String, HashSet`1<String>> _newAndSyncedSceneGuidsPerScene; //Field offset: 0x20
	[CompilerGenerated]
	private int <LastLoadedDataBuildNumber>k__BackingField; //Field offset: 0x28
	private readonly HashSet<Scene> _loadedDataScenes; //Field offset: 0x30

	public static event Action<Scene> OnDataLoadedAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public static event Action<Scene> OnPostSaveProgressAction
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	public static event Action<Scene> OnPreSaveProgressAction
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	public private static PersistentDataManager Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 80
	}

	public private int LastLoadedDataBuildNumber
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public PersistentDataManager() { }

	[CompilerGenerated]
	public static void add_OnDataLoadedAction(Action<Scene> value) { }

	[CompilerGenerated]
	public static void add_OnPostSaveProgressAction(Action<Scene> value) { }

	[CompilerGenerated]
	public static void add_OnPreSaveProgressAction(Action<Scene> value) { }

	public static void AddSceneObjectGuidToKeepOnLoad(string sceneGuid) { }

	private void Awake() { }

	private bool CanSaveScene() { }

	public static string Const_GetFolderBase() { }

	public static string Const_GetRootFolder() { }

	public void DeleteDataForActiveScene() { }

	private void DestroySceneObjectsThatAreNotInTheSavedData(Dictionary<String, Dictionary`2<String, Object>> sceneDataDict, Dictionary<String, PDSceneObject> allSceneObjects, HashSet<String> sceneObjectsToKeepOnLoad, HashSet<String> defaultDataItemsToRestore, HashSet<String> newAndSyncedSceneGuids, List<String> sceneObjectsToSetDefaultDataTo) { }

	private void EnsureFolder() { }

	[CompilerGenerated]
	public static PersistentDataManager get_Instance() { }

	[CompilerGenerated]
	public int get_LastLoadedDataBuildNumber() { }

	public static string GetActiveSceneFilePath() { }

	private Dictionary<String, Object> GetDataFromRootGameObjects(Scene scene, List<GameObject> rootGameObjects) { }

	public string GetFilePath(Scene scene) { }

	public static string GetFolder() { }

	public static string GetFolderWithoutOverrides() { }

	private string GetLevelDefaultDataFileName(Scene scene) { }

	private string GetLevelDefaultDataString(Scene scene) { }

	private HashSet<String> GetNewAndSyncedSceneGuids(Dictionary<String, Object> savedData) { }

	public static string GetPathForDataFile(string fileName) { }

	public static string GetPrefabPath(string prefabGuid, bool logIfError = true) { }

	private Dictionary<String, List`1<PDPrefab>> GetPrefabRuntimeSpawns(List<GameObject> rootGameObjects) { }

	public List<GameObject> GetRelevantRootGameObjects(Scene scene) { }

	private Dictionary<String, Object> GetSceneData(Scene scene) { }

	private Dictionary<String, Dictionary`2<String, Object>> GetSceneDataDict(Dictionary<String, Object> savedData) { }

	private Dictionary<String, PDSceneObject> GetSceneObjects(List<GameObject> rootGameObjects) { }

	private static HashSet<String> GetSceneObjectsToKeepOnLoad() { }

	public bool IsSceneDataLoaded(Scene scene) { }

	private Dictionary<String, PDSceneObject> LoadData(Scene scene) { }

	private Dictionary<String, PDSceneObject> LoadDataInternal(Scene scene, string filePath, List<GameObject> rootGameObjects) { }

	public Dictionary<String, PDSceneObject> LoadProgress(Scene scene) { }

	public static string Multiplayer_Const_GetRootFolder() { }

	private void OnApplicationPause(bool pause) { }

	private void OnBeforeSceneLoadStage2() { }

	private void OnDestroy() { }

	private void RefreshSceneObjectsSorting(Dictionary<String, PDSceneObject> allSceneObjects) { }

	[CompilerGenerated]
	public static void remove_OnDataLoadedAction(Action<Scene> value) { }

	[CompilerGenerated]
	public static void remove_OnPostSaveProgressAction(Action<Scene> value) { }

	[CompilerGenerated]
	public static void remove_OnPreSaveProgressAction(Action<Scene> value) { }

	private void SaveDataForScene(Scene scene) { }

	private void SaveDataInternal(Scene scene, string filePath, List<GameObject> rootGameObjects) { }

	public void SaveProgress(Scene scene) { }

	private void SaveProgressInAllScenes() { }

	private void SaveSceneObjectsToKeepOnLoad() { }

	[CompilerGenerated]
	private static void set_Instance(PersistentDataManager value) { }

	[CompilerGenerated]
	private void set_LastLoadedDataBuildNumber(int value) { }

	private void SetDefaltLevelDataForSceneObjects(Scene scene, Dictionary<String, PDSceneObject> allSceneObjects, List<String> sceneObjectsToAssignDataTo) { }

	private void SetPersistentData(Dictionary<String, Dictionary`2<String, Object>> sceneDataDict, Dictionary<String, PDSceneObject> allSceneObjects) { }

	private void SpawnPrefabsFromDefaultData(Scene scene, Dictionary<String, PDSceneObject> allSceneObjects, List<String> sceneObjectsToAssignDataTo, HashSet<String> defaultDataItemsToRestore) { }

	private void SpawnRuntimePrefabs(Scene scene, Dictionary<String, Object> savedData, Dictionary<String, PDSceneObject> allSceneObjects) { }

}

