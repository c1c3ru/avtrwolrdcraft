namespace PWC.PersistentData;

public static class PDUtils
{

	public static void AddData(Dictionary<String, Object> allData, T data, string overrideKey = null) { }

	public static void AssertPDPrefabReferenceValid(PDPrefabReference reference, object context, Type type = null) { }

	public static List<PDPrefab> GetAllMappedPDPrefabs() { }

	public static PDPrefab GetPrefab(string prefabGuid, bool logIfError = true) { }

	public static PDPrefab GetPrefabFromName(string prefabName, bool logIfError = true) { }

	public static PDPrefab Spawn(PDPrefab prefab, Vector2 position = null, Transform parent = null, Scene scene = null, bool multiplayer_ensureGuids = true) { }

	public static PDPrefab Spawn(string prefabGuid, Vector2 position = null, Transform parent = null, Scene scene = null, bool multiplayer_ensureGuids = true) { }

	public static bool TryGetData(Dictionary<String, Object> allData, out T data, bool logErrorIfNotFound = true, string overrideKey = null) { }

	private static bool TryGetDataInternal(string key, Dictionary<String, Object> data, out T tData, bool logErrorIfNotFound = true) { }

	public static bool TryLoadDataFromDefaultData(string sceneName, PDSceneObject sceneObject) { }

}

