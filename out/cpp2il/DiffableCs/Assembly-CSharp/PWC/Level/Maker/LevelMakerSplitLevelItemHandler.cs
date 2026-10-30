namespace PWC.Level.Maker;

public class LevelMakerSplitLevelItemHandler : MonoBehaviour
{
	private enum DragMode
	{
		None = 0,
		Default = 1,
		AboveSplitLevel = 2,
		OtherLevel = 3,
	}

	private DragDropItemBase _item; //Field offset: 0x20
	private LevelMakerSplitLevelView _view; //Field offset: 0x28
	private Nullable<Boolean> _isLayerAboveSplit; //Field offset: 0x30
	private bool _didMarkAsRuntimeSpawn; //Field offset: 0x32
	private bool _shouldListenToOnSyncPosition; //Field offset: 0x33
	private readonly Dictionary<Transform, Int32> _layersToSave; //Field offset: 0x38

	public LevelMakerSplitLevelItemHandler() { }

	private void Awake() { }

	private Bounds GetBounds() { }

	public void Init(LevelMakerSplitLevelView view) { }

	private bool IsInsideOtherLevel() { }

	private void OnDestroy() { }

	private void OnItemBeginDrag(DragDropItemBase dragDropItem, PointerEventData eventData) { }

	private void OnItemPreEndDrag(DragDropItemBase item, PointerEventData eventData) { }

	private void OnItemSyncPosition(DragDropItemBase item, Vector2 pointerPoisition) { }

	private void SetAboveSplitLevel(bool isAboveSplitLevel) { }

	private void SetDragMode(DragMode dragMode) { }

	private void SetScene(SplitLevelSceneType sceneType) { }

	private bool TryOverrideGetPointerPositionForDrag(DragDropItemBase item, out Vector2 position) { }

}

