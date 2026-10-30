namespace PWC.Level.Maker;

public class LevelMakerSplitLevelView : MonoBehaviour
{
	[CompilerGenerated]
	private static LevelMakerSplitLevelView <Instance>k__BackingField; //Field offset: 0x0
	[SerializeField]
	private GameCamera _mainCamera; //Field offset: 0x20
	[SerializeField]
	private CShapeRaycaster _cShapeRaycaster; //Field offset: 0x28
	[SerializeField]
	private Camera _aboveSplitLevelCamera; //Field offset: 0x30
	private readonly HashSet<GameObject> _itemsVisibleByAboveSplitCamera; //Field offset: 0x38
	private Bounds _otherLevelViewBounds; //Field offset: 0x40
	private TransformChangedHandler _transformChangedHandler; //Field offset: 0x58

	public private static LevelMakerSplitLevelView Instance
	{
		[CompilerGenerated]
		 get { } //Length: 72
		[CompilerGenerated]
		private set { } //Length: 88
	}

	public LevelMakerSplitLevelView() { }

	public void AddToItemsVisibleByAboveSplitCamera(GameObject gameObject) { }

	private void Awake() { }

	[CompilerGenerated]
	public static LevelMakerSplitLevelView get_Instance() { }

	public float GetMainLevelScreenFactor() { }

	private Bounds GetOtherLevelViewBounds() { }

	public Vector2 GetPositionFromMainViewToOtherView(Vector2 worldPosition) { }

	public Vector2 GetPositionFromOtherViewToMainView(Vector2 worldPosition) { }

	public float GetSplitXPosition() { }

	public bool IsBoundsInsideOtherLevel(Bounds bounds) { }

	public bool IsPointInsideOtherLevel(Vector2 point) { }

	public bool IsPointInsideOtherLevelView(Vector2 point) { }

	public bool IsVisible() { }

	private void OnBeforeRaycast() { }

	private void OnDestroy() { }

	private void OnItemBeginDrag(DragDropItemBase dragDropItem) { }

	private void OnLevelItemBeginDrag(LevelItem levelItem) { }

	private void OnLevelMakerItemBeginDrag(LevelMakerItem levelMakerItem) { }

	private void OnLevelPostInit() { }

	private void OnPositionChanged() { }

	private void OnSplitLevelMainCameraFactorChanged() { }

	public void RemoveFromItemsVisibleByAboveSplitCamera(GameObject gameObject) { }

	[CompilerGenerated]
	private static void set_Instance(LevelMakerSplitLevelView value) { }

	public void SetMainLevelScreenFactor(float fullMainLevelViewFactor) { }

	public void SyncCamerasScrollBounds() { }

	public void SyncOtherLevelViewBounds() { }

	public void SyncSplitLevelCameraPosition() { }

	private bool TryOverridePointPosition(PointerEventData eventData, out Vector2 position) { }

}

