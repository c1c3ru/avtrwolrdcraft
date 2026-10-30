namespace PWC.Level;

public class LevelFruitTree : LevelConsumerAreaBase, ILevelPlantWateringTarget, ILevelConsumer, ILevelPlant, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private PDPrefabReference _fruitPrefab; //Field offset: 0x58
	[SerializeField]
	private Transform[] _spawnPoints; //Field offset: 0x60
	private LevelPlantPot _plantPot; //Field offset: 0x68

	public LevelFruitTree() { }

	protected virtual void Awake() { }

	public override bool DidGrowComplete() { }

	protected override PDPrefabReference GetFruitPrefab(int pointIndex) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	public override ILevelPlant GetPlant() { }

	public override bool IsAlive() { }

	protected virtual void OnDestroy() { }

	public override float PlayIncrementSound() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public override void SetPlantPot(LevelPlantPot plantPot) { }

	public override bool TryIncrementPlant() { }

}

