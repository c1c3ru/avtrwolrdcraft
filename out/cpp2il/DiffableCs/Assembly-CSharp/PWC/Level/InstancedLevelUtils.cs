namespace PWC.Level;

public static class InstancedLevelUtils
{
	private class OwnedLevels
	{
		public List<String> instancedSceneIds; //Field offset: 0x10

		public OwnedLevels() { }

	}

	private class ReturnPoint
	{
		public string sceneName; //Field offset: 0x10
		public string suffix; //Field offset: 0x18

		public ReturnPoint() { }

	}

	private const string RETURN_POINT_KEY_PREFIX = "InstancedLevelReturn_"; //Field offset: 0x0
	private const string OWNED_LEVELS_KEY_PREFIX = "InstancedLevelsOf_"; //Field offset: 0x0
	private static string _pendingArrivalInstanceSuffix; //Field offset: 0x0
	private static string _pendingArrivalSceneId; //Field offset: 0x8
	private static readonly Dictionary<String, String> _returnSceneIdsOfDeletedLevels; //Field offset: 0x10

	public static bool HasPendingArrival
	{
		 get { } //Length: 96
	}

	private static InstancedLevelUtils() { }

	public static void DeleteInstancedLevelsOf(string ownerSceneGuid) { }

	public static bool get_HasPendingArrival() { }

	private static string GetOwnedLevelsKey(string ownerSceneGuid) { }

	private static string GetReturnPointKey(string instancedSceneId) { }

	private static OwnedLevels LoadOwnedLevels(string ownerSceneGuid) { }

	public static void RecordEntry(string ownerSceneGuid, string instancedSceneId, string returnSceneName, string returnSuffix) { }

	public static string RedirectIfDeleted(string sceneId) { }

	public static void SeedDefaultDataIfNeeded(string sceneName, string instancedSceneId) { }

	public static void SetPendingArrival(string instanceSuffix, string sceneId) { }

	public static bool TryConsumePendingArrival(string instanceSuffix) { }

	public static bool TryGetReturnPoint(string instancedSceneId, out string sceneName, out string suffix) { }

}

