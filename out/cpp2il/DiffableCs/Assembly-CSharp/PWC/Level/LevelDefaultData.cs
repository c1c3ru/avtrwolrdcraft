namespace PWC.Level;

public static class LevelDefaultData
{
	private static readonly Dictionary<String, PDScene> _data; //Field offset: 0x0
	private static readonly Dictionary<String, String> _scenesForSceneGuids; //Field offset: 0x8

	private static LevelDefaultData() { }

	public static void Init() { }

	public static bool IsItemPartOfScene(string sceneName, string sceneObjectGuid) { }

	public static bool TryGetData(string sceneName, out PDScene pdScene) { }

	public static bool TryGetSceneOwnerForItem(string sceneObjectGuid, out string sceneName) { }

}

