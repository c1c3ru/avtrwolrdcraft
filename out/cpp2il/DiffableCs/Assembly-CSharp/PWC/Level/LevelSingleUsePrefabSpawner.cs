namespace PWC.Level;

public class LevelSingleUsePrefabSpawner : LevelSimpleSpawnerBase, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private PDPrefabReference _prefabReference; //Field offset: 0x90
	[SerializeField]
	private int _requiredClicksToSpawn; //Field offset: 0x98
	[SerializeField]
	private UnityEvent _onSpawnAction; //Field offset: 0xA0
	private int _numOfClicks; //Field offset: 0xA8

	public LevelSingleUsePrefabSpawner() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public virtual LevelSpawn GetPrefabToSpawn() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public virtual void SpawnOnClick() { }

}

