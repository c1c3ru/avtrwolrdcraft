namespace Game.Level;

public class LevelSpawnOnBurgerFlag : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private PDPrefab _spawn; //Field offset: 0x20
	[SerializeField]
	private Transform _SpawnPoint; //Field offset: 0x28
	[SerializeField]
	private UnityEvent _onCrownSpawnEvent; //Field offset: 0x30
	private bool _isSpawned; //Field offset: 0x38

	public LevelSpawnOnBurgerFlag() { }

	private void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void InitCrown() { }

	private void OnDestroy() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

