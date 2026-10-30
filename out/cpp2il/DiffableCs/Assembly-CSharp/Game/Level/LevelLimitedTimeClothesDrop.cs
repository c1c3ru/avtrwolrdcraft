namespace Game.Level;

public class LevelLimitedTimeClothesDrop : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[SerializeField]
	private LevelClothesDropConsumerHandler[] _parents; //Field offset: 0x20
	[SerializeField]
	private PDPrefabReference _shoppingBagPrefabReference; //Field offset: 0x28
	[SerializeField]
	private Transform _bagSpawnPoint; //Field offset: 0x30
	[SerializeField]
	private LevelType _levelType; //Field offset: 0x38
	private PDTextBulkData _prevClothesFile; //Field offset: 0x40
	private PDTextBulkData _nextClothesFile; //Field offset: 0x48
	private ClothesDropDataMap _map; //Field offset: 0x50
	private bool _isDropInitiated; //Field offset: 0x58
	private string _lastDropName; //Field offset: 0x60
	private bool _isNewDrop; //Field offset: 0x68
	private long _currentTime; //Field offset: 0x70
	private long _currentDropEndTime; //Field offset: 0x78

	public LevelLimitedTimeClothesDrop() { }

	private void Awake() { }

	private void EnsureNothingInAllPlaces() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private bool IsInConfigs(SpineType spineType, string skinName) { }

	private void OnDestroy() { }

	private void OnLevelPrePostInit() { }

	private void ReplaceClothesWithNextClothes() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private LevelItem SpawnBag() { }

}

