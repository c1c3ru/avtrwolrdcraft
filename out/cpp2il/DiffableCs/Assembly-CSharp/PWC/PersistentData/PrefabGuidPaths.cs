namespace PWC.PersistentData;

[CreateAssetMenu]
public class PrefabGuidPaths : ScriptableObject
{
	internal class PrefabGuidPath
	{
		public string guid; //Field offset: 0x10
		public string path; //Field offset: 0x18
		public ulong flags; //Field offset: 0x20
		public Vector2 dimentions; //Field offset: 0x28

		public PrefabGuidPath() { }

	}

	private static Dictionary<String, PrefabGuidPath> _prefabGuidPaths; //Field offset: 0x0
	private const string PREFAB_GUIDS_PATH = "PersistantData/PrefabGuidPaths"; //Field offset: 0x0
	private static Dictionary<String, String> _prefabNameToGuid; //Field offset: 0x8
	public List<PrefabGuidPath> paths; //Field offset: 0x18

	public PrefabGuidPaths() { }

	private static void EnsureData() { }

	public static PrefabGuidPaths Get() { }

	public static List<String> GetAllPrefabGuidsWithFlags(ulong flags) { }

	private static PrefabGuidPath GetPrefabData(string prefabGuid, bool logIfError = true) { }

	public static Vector2 GetPrefabDimensions(string prefabGuid, bool logIfError = true) { }

	public static ulong GetPrefabFlags(string prefabGuid, bool logIfError = true) { }

	public static string GetPrefabGuidFromName(string name, bool logIfError = true) { }

	public static string GetPrefabNameFromGuid(string prefabGuid, bool logIfError = true) { }

	public static string GetPrefabPath(string prefabGuid, bool logIfError = true) { }

}

