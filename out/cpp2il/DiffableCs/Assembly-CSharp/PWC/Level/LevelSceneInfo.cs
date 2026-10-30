namespace PWC.Level;

[CreateAssetMenu(menuName = "PazuWorld/Level/Level Scene Info")]
public class LevelSceneInfo : ScriptableObject
{
	internal class PrefabData
	{
		public string MainSceneGuid; //Field offset: 0x10
		public string PrefabGuid; //Field offset: 0x18

		public PrefabData() { }

	}

	private static Dictionary<String, LevelSceneInfo> _infos; //Field offset: 0x0
	public const string ASSETS_ROOT_PATH = "Level/SceneInfo/"; //Field offset: 0x0
	public LevelSceneFlags flags; //Field offset: 0x18
	public PDTextBulkData[] bulkDataAssets; //Field offset: 0x20
	public List<PrefabData> levelDefaultPerfabsData; //Field offset: 0x28

	public LevelSceneInfo() { }

	public static IReadOnlyDictionary<String, LevelSceneInfo> GetAllInfos() { }

	public static void LoadDataIfNeeded() { }

	public static bool TryGetInfo(string sceneName, out LevelSceneInfo info) { }

}

