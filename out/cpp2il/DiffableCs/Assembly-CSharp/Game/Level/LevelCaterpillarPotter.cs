namespace Game.Level;

public class LevelCaterpillarPotter : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass12_0
	{
		public LevelItem levelItem; //Field offset: 0x10

		public <>c__DisplayClass12_0() { }

		internal void <SpawnCar>b__0() { }

	}

	private const string FLOWER_LABEL = "Flower"; //Field offset: 0x0
	[SerializeField]
	private LevelSpawner[] _plantSpawners; //Field offset: 0x20
	[SerializeField]
	private Level1DDropArea[] _potDropAreas; //Field offset: 0x28
	[SerializeField]
	private PDPrefabReference _carToSpawn; //Field offset: 0x30
	[SerializeField]
	private Transform _bounceArea; //Field offset: 0x38
	[SerializeField]
	private UnityEvent _onSecretSolved; //Field offset: 0x40
	private bool _gotCar; //Field offset: 0x48

	public LevelCaterpillarPotter() { }

	private void Awake() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnDropAreaStateChanged(LevelItem levelItem) { }

	private void OnSpawnFlower(LevelSpawner levelSpawner, LevelSpawn levelSpawn) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SpawnCar() { }

	private void UpdateFlowersStateIfNeeded() { }

}

