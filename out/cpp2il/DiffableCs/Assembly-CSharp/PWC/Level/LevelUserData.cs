namespace PWC.Level;

public static class LevelUserData
{
	internal class UserSceneData
	{
		public string sceneId; //Field offset: 0x10
		public string filePath; //Field offset: 0x18
		public PDScene pdScene; //Field offset: 0x20
		[CompilerGenerated]
		private bool <IsDirty>k__BackingField; //Field offset: 0x28

		public bool IsDirty
		{
			[CompilerGenerated]
			 get { } //Length: 8
			[CompilerGenerated]
			 set { } //Length: 12
		}

		public UserSceneData() { }

		[CompilerGenerated]
		public bool get_IsDirty() { }

		[CompilerGenerated]
		public void set_IsDirty(bool value) { }

	}

	private static readonly Dictionary<String, UserSceneData> _data; //Field offset: 0x0

	private static LevelUserData() { }

	public static void ClearLevelDataFromUserData(string sceneId, PDPrefab prefab) { }

	public static void ClearStaticVariables() { }

	public static bool CreateUserDataFromDataAndSetAsCurrent(string sceneName, PDScene pdScene, out UserSceneData levelUserData) { }

	public static void DeletePrefabGuidFromAllLevels(string prefabGuid) { }

	public static void DeleteSceneData(string sceneName) { }

	public static void DeleteSceneGuidFromAllLevels(string sceneGuid, HashSet<String> excludeLevels = null) { }

	public static IReadOnlyDictionary<String, UserSceneData> GetData() { }

	public static int GetPrefabGuidCountInAnyLevel(string prefabGuid, string excludeSceneId = null) { }

	public static void Init() { }

	public static bool IsItemPartOfScene(string sceneId, string sceneObjectGuid) { }

	public static bool IsPrefabGuidExistInAnyLevel(string prefabGuid) { }

	public static void SaveDirtyData() { }

	private static void SaveToDisk(UserSceneData userSceneData) { }

	public static void SetLevelData(string sceneId, string filePath, PDScene pdScene) { }

	public static bool TryGetData(string sceneId, out UserSceneData userSceneData) { }

	public static bool TryGetSceneForSceneGuid(string sceneGuid, out string sceneName) { }

	private static bool TryLoadLevelDataFromFileAndSetAsCurrent(string sceneName) { }

}

