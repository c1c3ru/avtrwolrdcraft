namespace Game.Level;

public class LevelCafeteriaFoodDisplayKeySecret : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private int _numberOfClickToSpawnKey; //Field offset: 0x20
	[SerializeField]
	private LevelSimpleSpawnerBase[] _foodSpawners; //Field offset: 0x28
	[SerializeField]
	private PDPrefabReference _key; //Field offset: 0x30
	[SerializeField]
	private UnityEvent _onKeySpawnAction; //Field offset: 0x38
	private bool _isSpawned; //Field offset: 0x40

	public LevelCafeteriaFoodDisplayKeySecret() { }

	private void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnSpawnedItem(LevelSimpleSpawnerBase spawner, LevelSpawn spawn) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

