namespace Game.Level;

public class LevelSpawnOnLevelPostInit : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	internal class Config
	{
		public String[] items; //Field offset: 0x10

		public Config() { }

	}

	[SerializeField]
	protected SpineType _spineType; //Field offset: 0x20
	[SerializeField]
	protected PDPrefabReference[] _prefabReferences; //Field offset: 0x28
	[SerializeField]
	protected Transform[] _points; //Field offset: 0x30
	[SerializeField]
	private bool _isNewEveryLoad; //Field offset: 0x38
	[SerializeField]
	protected TextAsset _textAsset; //Field offset: 0x40
	protected int _pointIndex; //Field offset: 0x48
	protected String[] _clothingItems; //Field offset: 0x50
	private List<Int32> _prefabsIndexes; //Field offset: 0x58
	private List<Int32> _clothesIndexes; //Field offset: 0x60

	public LevelSpawnOnLevelPostInit() { }

	protected override void Awake() { }

	private void ClearClothesIndexListIfNeeded() { }

	private void ClearPrefabsIndexListIfNeeded() { }

	protected void DestroyCurrentItems() { }

	private void FillDisposableOnLevelResetSceneGuids(HashSet<String> sceneGuids) { }

	protected override string GetClothingItem() { }

	private bool GetIsClothes() { }

	protected override PDPrefabReference GetItemPrefab() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	protected override void OnDestroy() { }

	private void ResetClothesIndexes() { }

	private void ResetPrefabsIndexes() { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	public override void SpawnOnInit() { }

	protected override bool UseNormalSpawnAndDestroyBehavior() { }

}

