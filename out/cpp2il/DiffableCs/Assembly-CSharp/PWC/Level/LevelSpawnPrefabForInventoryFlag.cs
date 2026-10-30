namespace PWC.Level;

public class LevelSpawnPrefabForInventoryFlag : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private InventoryFlagType _requiredFlagType; //Field offset: 0x20
	[SerializeField]
	private PDPrefabReference _prefabReference; //Field offset: 0x28
	private BoolPD _didSpawnPDData; //Field offset: 0x30

	public LevelSpawnPrefabForInventoryFlag() { }

	private void Awake() { }

	protected override bool CanSpawn() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void LevelUpgradeTracker_FillDisposableOnLevelResetPrefabGuidsAction(HashSet<String> sceneGuids) { }

	private void OnDestroy() { }

	private void OnPreLevelPostInit() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

