namespace Game.Level;

public class LevelConeHolder : MonoBehaviour
{
	[SerializeField]
	private LevelDropArea _dropArea; //Field offset: 0x20
	[SerializeField]
	private Transform _spawnPoint; //Field offset: 0x28
	[SerializeField]
	private PDPrefabReference _prefabToSpawn; //Field offset: 0x30
	[SerializeField]
	private LevelSpawner _spawner; //Field offset: 0x38
	[SerializeField]
	private string _soundName; //Field offset: 0x40
	[Range(1, 20)]
	[SerializeField]
	private int _maxInstances; //Field offset: 0x48
	[SerializeField]
	private int numberOfSpawns; //Field offset: 0x4C

	public LevelConeHolder() { }

	private void Awake() { }

	private LevelSpawn GetPrefabToSpawn() { }

	private void OnDestroy() { }

	private void OnItemPickUp(LevelItem levelItem) { }

	private void SpawnSinglePrefab() { }

}

