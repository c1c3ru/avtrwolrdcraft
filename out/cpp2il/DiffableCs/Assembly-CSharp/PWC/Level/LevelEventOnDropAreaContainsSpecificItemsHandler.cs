namespace PWC.Level;

public class LevelEventOnDropAreaContainsSpecificItemsHandler : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass14_0
	{
		public PDPrefabReference prefabRefrence; //Field offset: 0x10

		public <>c__DisplayClass14_0() { }

		internal bool <UpdateUnlockIndicator>b__0(string x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass15_0
	{
		public string guid; //Field offset: 0x10

		public <>c__DisplayClass15_0() { }

		internal bool <OnItemConsumed>b__0(PDPrefabReference x) { }

	}

	[SerializeField]
	private bool _onceUnlockedKeepUnlocked; //Field offset: 0x20
	[SerializeField]
	private List<PDPrefabReference> _requiredItemsInDropArea; //Field offset: 0x28
	[SerializeField]
	private List<Int32> _amountPerItem; //Field offset: 0x30
	[SerializeField]
	public UnityEvent OnUnlockedAction; //Field offset: 0x38
	[SerializeField]
	public UnityEvent OnRelockedAction; //Field offset: 0x40
	[SerializeField]
	private bool _isUnlocked; //Field offset: 0x48
	[SerializeField]
	private bool _unlockedActionOnLoad; //Field offset: 0x49
	[SerializeField]
	private List<LevelDropArea> _dropAreasToCombine; //Field offset: 0x50
	[SerializeField]
	private string _soundName; //Field offset: 0x58
	private LevelDropArea _dropArea; //Field offset: 0x60
	private List<String> _currentGuidsOfItemsConsumed; //Field offset: 0x68

	public LevelEventOnDropAreaContainsSpecificItemsHandler() { }

	private void Awake() { }

	private List<String> GetHierarchyPrefabGuids(LevelItem rootItem) { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnItemConsumed(LevelDropArea dropArea, LevelItem levelItem) { }

	private void OnItemPickUp(LevelDropArea dropArea, LevelItem levelItem) { }

	private void OnLevelPostInit() { }

	private void RemoveItemFromList(LevelItem item) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void UpdateUnlockIndicator() { }

}

