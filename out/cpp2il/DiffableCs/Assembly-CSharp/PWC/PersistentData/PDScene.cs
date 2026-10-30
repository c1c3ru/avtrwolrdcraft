namespace PWC.PersistentData;

public class PDScene
{
	internal class PrefabData
	{
		public string prefabGuid; //Field offset: 0x10
		public SceneData sceneData; //Field offset: 0x18
		public int dataIndex; //Field offset: 0x20

		public PrefabData() { }

		public string GetFirstSceneGuid() { }

	}

	private readonly Dictionary<String, Object> _allData; //Field offset: 0x10
	private readonly Dictionary<String, Object> _prefabs; //Field offset: 0x18
	private readonly Dictionary<String, Object> _sceneObjects; //Field offset: 0x20
	private Dictionary<String, PrefabData> _sceneGuidToPrefabData; //Field offset: 0x28

	public IReadOnlyDictionary<String, Object> AllData
	{
		 get { } //Length: 8
	}

	public IReadOnlyDictionary<String, Object> Prefabs
	{
		 get { } //Length: 8
	}

	public IReadOnlyDictionary<String, Object> SceneObjects
	{
		 get { } //Length: 8
	}

	public PDScene(Dictionary<String, Object> data) { }

	public void AddSceneObject(string sceneGuid, Dictionary<String, Object> persistentDataList) { }

	public void AddSceneObject(string sceneGuid, List<String> persistentDataList) { }

	public bool ContainsPrefabGuid(string prefabGuid) { }

	public bool ContainsSceneGuid(string sceneGuid) { }

	private void EnsurePrefabData() { }

	public IReadOnlyDictionary<String, Object> get_AllData() { }

	public IReadOnlyDictionary<String, Object> get_Prefabs() { }

	public IReadOnlyDictionary<String, Object> get_SceneObjects() { }

	public int GetPrefabCountInScene(string prefabGuid) { }

	public IReadOnlyDictionary<String, PrefabData> GetPrefabsData() { }

	public bool IsPrefabExistInScene(string prefabGuid) { }

	public bool TryAddPrefabData(string prefabGuid, SceneData sceneData) { }

	public bool TryGetPrefabDataForSceneGuid(string sceneGuid, out PrefabData prefabData) { }

	public void TryRemovePrefab(string prefabGuid) { }

	public bool TryRemovePrefabData(PrefabData prefabData) { }

	public bool TryRemoveSceneGuid(string sceneGuid) { }

}

