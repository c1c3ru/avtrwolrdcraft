namespace Game.Level;

public class LevelDigHolesManager : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	private struct ProbabilityPerPrefab
	{
		public PDPrefabReference reference; //Field offset: 0x0
		public float probability; //Field offset: 0x8
		public int maxInstantiations; //Field offset: 0xC
		public UnityEvent onDugEvent; //Field offset: 0x10

	}

	[SerializeField]
	private ProbabilityPerPrefab[] references; //Field offset: 0x20
	[SerializeField]
	private LevelSpawnerInRandomLocations _spawner; //Field offset: 0x28
	public List<Int32> _totalInstantiations; //Field offset: 0x30

	public LevelDigHolesManager() { }

	protected void Awake() { }

	private bool CanInstantiate(int i) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public PDPrefab GetRandomPrefab(out UnityEvent onDugEvent) { }

	private void InitTotalInitializationsListIfNeeded() { }

	private void OnDestroy() { }

	private void OnDigHoleSpawn(ILevelSpawnInRandomLocationTarget spawn) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

