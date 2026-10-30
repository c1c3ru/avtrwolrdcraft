namespace PWC.Level.Maker;

[RequireComponent(typeof(LevelMakerItem))]
public abstract class LevelMakerRotatingItemHandlerBase : MonoBehaviour, IHasPersistentData, IRequirePDSceneObject, ILevelSpawnDuringGameplay
{
	[SerializeField]
	protected PDPrefabReference _prefabReference; //Field offset: 0x20
	private LevelMakerItem _item; //Field offset: 0x28
	[CompilerGenerated]
	private Action<LevelMakerRotatingItemHandlerBase> OnItemRotatedAction; //Field offset: 0x30

	public event Action<LevelMakerRotatingItemHandlerBase> OnItemRotatedAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public private LevelMakerItem Item
	{
		 get { } //Length: 8
		private set { } //Length: 8
	}

	protected LevelMakerRotatingItemHandlerBase() { }

	[CompilerGenerated]
	public void add_OnItemRotatedAction(Action<LevelMakerRotatingItemHandlerBase> value) { }

	protected override void Awake() { }

	private void DestroySelf() { }

	public LevelMakerItem get_Item() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	protected int GetSortingOrder() { }

	protected override void OnDestroy() { }

	protected override void OnItemRotated(LevelMakerRotatingItemHandlerBase nextItem) { }

	protected override void OnLevelPostInit() { }

	public override void OnSpawnDuringGameplay() { }

	[CompilerGenerated]
	public void remove_OnItemRotatedAction(Action<LevelMakerRotatingItemHandlerBase> value) { }

	protected void RotateItem() { }

	private void set_Item(LevelMakerItem value) { }

	private void SetColorsOnNextRotationObject(LevelMakerRotatingItemHandlerBase nextRotationItem) { }

	private void SetDoorsStatenNextRotationObject(LevelMakerRotatingItemHandlerBase nextRotationItem) { }

	private void SetLightsStatenNextRotationObject(LevelMakerRotatingItemHandlerBase nextRotationItem) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SetToggleableAudiosStatenNextRotationObject(LevelMakerRotatingItemHandlerBase nextRotationItem) { }

	private void SetToggleableGameObjectsStatenNextRotationObject(LevelMakerRotatingItemHandlerBase nextRotationItem) { }

	protected override void SyncFlippedState() { }

	protected bool TrySpawnImplement(out PDPrefab pdPrefabInstance) { }

	private bool TrySpawnNextRotationItem(out PDPrefab instance) { }

}

