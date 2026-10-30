namespace PWC.ScavengerHunt.Level;

[RequireComponent(typeof(PDSceneObject))]
public class ScavengerHuntItemSpawner : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private ScavengerHuntType _scavengerHuntType; //Field offset: 0x20
	[SerializeField]
	private int _spawnerID; //Field offset: 0x24
	[SerializeField]
	private Transform _parentToSpawnUnder; //Field offset: 0x28
	[SerializeField]
	private Transform _positionTransform; //Field offset: 0x30
	private ScavengerHuntTypeHandler _handler; //Field offset: 0x38
	private string _gameGuid; //Field offset: 0x40
	private string _prefabGuid; //Field offset: 0x48

	public ScavengerHuntItemSpawner() { }

	private void Awake() { }

	private void EnsureGameNumber() { }

	private void EnsurePrefabGuid() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnBeforeDestroyGameItem(string prefabGuid) { }

	private void OnDestroy() { }

	private void OnGameStart() { }

	private void OnLevelPrePostInit() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SpawnItemIfNeeded() { }

}

