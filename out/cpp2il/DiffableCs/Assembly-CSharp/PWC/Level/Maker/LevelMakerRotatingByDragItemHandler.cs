namespace PWC.Level.Maker;

[RequireComponent(typeof(LevelMakerItem))]
public class LevelMakerRotatingByDragItemHandler : LevelMakerRotatingItemHandlerBase, IBeginDragHandler, IEventSystemHandler, IDragHandler
{
	private WallAngleType _angleType; //Field offset: 0x38
	private CShape _rotatedItemCShape; //Field offset: 0x40
	protected LevelMakerItemWithArea _itemWithAreaHandler; //Field offset: 0x48
	private LevelMakerItemWithArea _rotatedItem; //Field offset: 0x50
	private LevelMakerRotatingByDragItemHandler _rotatedItemRotationHandler; //Field offset: 0x58
	public bool IsOriginalPrefab; //Field offset: 0x60
	private PointerEventData data; //Field offset: 0x68
	private bool _isFirstFramePassed; //Field offset: 0x70

	public LevelMakerRotatingByDragItemHandler() { }

	protected virtual void Awake() { }

	private bool CheckIsOnCorrectWallType() { }

	private CShape GetWallAreaCShape() { }

	public void InitRotatedItemForColissionTests() { }

	public override void OnBeginDrag(PointerEventData eventData) { }

	protected virtual void OnDestroy() { }

	public override void OnDrag(PointerEventData eventData) { }

	protected virtual void OnItemRotated(LevelMakerRotatingItemHandlerBase nextItem) { }

	protected virtual void OnLevelPostInit() { }

	public virtual void OnSpawnDuringGameplay() { }

	private void OnSyncPosition(DragDropItemBase _, Vector2 position) { }

}

