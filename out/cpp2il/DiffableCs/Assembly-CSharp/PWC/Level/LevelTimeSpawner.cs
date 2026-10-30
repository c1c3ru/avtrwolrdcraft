namespace PWC.Level;

public class LevelTimeSpawner : MonoBehaviour
{
	private const string LAST_SAVED_TIME_PLAYER_PREFS_PREFIX = "TimeSpawnerLastSavedTime_"; //Field offset: 0x0
	[SerializeField]
	private LevelSpawner _spawner; //Field offset: 0x20
	[SerializeField]
	private PDPrefabReference _prefabReference; //Field offset: 0x28
	[SerializeField]
	private PDSceneObject _pdSceneObject; //Field offset: 0x30
	[SerializeField]
	private float _minutes; //Field offset: 0x38
	[SerializeField]
	private Transform _spawnPosition; //Field offset: 0x40
	[SerializeField]
	private Transform _spawnParent; //Field offset: 0x48
	[SerializeField]
	private int _maxInstances; //Field offset: 0x50
	[SerializeField]
	private bool _useFifo; //Field offset: 0x54

	public LevelTimeSpawner() { }

	[CompilerGenerated]
	private void <OnLevelPostInit>g__SaveCurrentTime|10_0() { }

	[CompilerGenerated]
	private void <OnLevelPostInit>g__SpawnPrefab|10_1() { }

	private void Awake() { }

	private string GetPlayerPrefsKey() { }

	private void OnDestroy() { }

	private void OnLevelPostInit() { }

	private void OnValidate() { }

}

