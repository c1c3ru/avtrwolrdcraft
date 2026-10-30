namespace PWC.Level;

public class LevelPlantPot : MonoBehaviour, ILevelSpawnDuringGameplay
{
	internal struct IndexEvent
	{
		public int Index; //Field offset: 0x0
		public UnityEvent onIndex; //Field offset: 0x8

	}

	[SerializeField]
	private LevelSpawner _spawner; //Field offset: 0x20
	[SerializeField]
	private Transform _plantPoint; //Field offset: 0x28
	public List<IndexEvent> OnPlantIndexSet; //Field offset: 0x30
	public UnityEvent OnFruitSpawned; //Field offset: 0x38
	public UnityEvent OnPlantPickup; //Field offset: 0x40
	private ILevelPlant _currentPlantItem; //Field offset: 0x48

	public ILevelPlant CurrentPlantItem
	{
		 get { } //Length: 8
	}

	public Transform PlantPoint
	{
		 get { } //Length: 8
	}

	public LevelPlantPot() { }

	private void Awake() { }

	public bool CanAcceptSeed() { }

	public ILevelPlant get_CurrentPlantItem() { }

	public Transform get_PlantPoint() { }

	private void OnDestroy() { }

	public void OnItemPlantPickup(DragDropItemBase levelItemPlant, PointerEventData _) { }

	private void OnLevelPostInit() { }

	public void OnPlantDestroyed(ILevelPlant plant) { }

	private override void PWC.Level.ILevelSpawnDuringGameplay.OnSpawnDuringGameplay() { }

	private void SetCurrentPlantItemIfExists() { }

	public LevelSpawn SpawnFromPot(LevelSpawn levelSpawnPrefab) { }

	private void SpawnPlantItem(LevelPlantBase plantPrefab) { }

	public void TryPutSeed(LevelPlantBase plantPrefab) { }

}

