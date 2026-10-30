namespace PWC.Level;

public class LevelSpawnerInRandomLocations : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<LocationState> <>9__12_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <OnLevelPrePostInit>b__12_0(LocationState x) { }

	}

	[SerializeField]
	private int _numberOfItemsToSpawn; //Field offset: 0x20
	[SerializeField]
	private GameObject _prefab; //Field offset: 0x28
	[SerializeField]
	private Transform[] _locations; //Field offset: 0x30
	private bool _isHasPersistentData; //Field offset: 0x38
	[CompilerGenerated]
	private Action<ILevelSpawnInRandomLocationTarget> OnSpawnAction; //Field offset: 0x40
	private List<LocationState> _locationsStates; //Field offset: 0x48
	private List<Int32> _indexs; //Field offset: 0x50
	private readonly List<ILevelSpawnInRandomLocationTarget> _targets; //Field offset: 0x58

	public event Action<ILevelSpawnInRandomLocationTarget> OnSpawnAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public LevelSpawnerInRandomLocations() { }

	[CompilerGenerated]
	public void add_OnSpawnAction(Action<ILevelSpawnInRandomLocationTarget> value) { }

	private void Awake() { }

	private void GetLocationsIndexesOrderIfNeeded() { }

	private void GetLocationsStatesIfNeeded() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private void OnDestroy() { }

	private void OnLevelPrePostInit() { }

	[CompilerGenerated]
	public void remove_OnSpawnAction(Action<ILevelSpawnInRandomLocationTarget> value) { }

	public void SetLocationInteracted(int index) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

}

