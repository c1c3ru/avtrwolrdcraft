namespace PWC.Level;

public class LevelSimpleMultiPrefabSpawner : LevelSimpleSpawnerBase, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private bool _isRandom; //Field offset: 0x8C
	[SerializeField]
	private bool _disableClicks; //Field offset: 0x8D
	[SerializeField]
	private PDPrefabReference[] _prefabReferences; //Field offset: 0x90
	[SerializeField]
	private bool _keepTrackOnIndex; //Field offset: 0x98
	private int _nextIndex; //Field offset: 0x9C

	public LevelSimpleMultiPrefabSpawner() { }

	public List<String> GetAllNamesOfPrefabsToSpawn() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public virtual LevelSpawn GetPrefabToSpawn() { }

	public void IndexDecrease() { }

	public void IndexIncrease() { }

	public virtual void OnPointerClick(PointerEventData eventData) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public void SpawnByIndex(int index) { }

	public void SpawnCurrentIndex() { }

}

