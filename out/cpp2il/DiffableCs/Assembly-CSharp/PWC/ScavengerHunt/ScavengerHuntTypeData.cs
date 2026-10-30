namespace PWC.ScavengerHunt;

[CreateAssetMenu(menuName = "PazuWorld/ScavengerHunt/TypeData")]
public class ScavengerHuntTypeData : ScriptableObject
{
	internal class SceneData
	{
		public string scene; //Field offset: 0x10
		public List<Int32> spawnerIds; //Field offset: 0x18

		public SceneData() { }

	}

	public ScavengerHuntType type; //Field offset: 0x18
	public int gameNumber; //Field offset: 0x1C
	public int timeLimit; //Field offset: 0x20
	public PDPrefabReference outcomeItemPrefab; //Field offset: 0x28
	public PDPrefabReference[] itemsPrefabs; //Field offset: 0x30
	public int spawnersCount; //Field offset: 0x38
	public List<SceneData> sceneDataList; //Field offset: 0x40
	private HashSet<String> _hashedPrefabGuids; //Field offset: 0x48
	private Dictionary<String, SceneData> _hashedSceneData; //Field offset: 0x50

	public ScavengerHuntTypeData() { }

	private void EnsurePrefabGuids() { }

	public bool IsPartOfItemsCollection(string prefabGuid) { }

	public bool IsPartOfItemsToFind(PDPrefab pdPrefab) { }

	public bool IsPassingRequirement(PDPrefab[] pdPrefabs, out HashSet<String>& countedItems) { }

	public bool TryGetSceneData(string sceneName, out SceneData sceneData) { }

}

