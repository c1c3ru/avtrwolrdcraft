namespace PWC.Level.Maker;

public class LevelMakerSmartPlatformItem : LevelMakerFloorFlatItem
{
	private const int DEFAULT_MIN_SORTING = 1; //Field offset: 0x0
	private const int DEFAULT_PARENT_SORTING = -4; //Field offset: 0x0
	private const int DEFAULT_BLOCKED_SORTING_LAYER = -90; //Field offset: 0x0
	public static readonly List<LevelMakerSmartPlatformItem> PlatformList; //Field offset: 0x0

	private static LevelMakerSmartPlatformItem() { }

	public LevelMakerSmartPlatformItem() { }

	private int FindMaxSorting() { }

	private void FindPlatformParent() { }

	protected virtual int GetDefaultSortingOrder() { }

	private LevelMakerSnappableFloorLine GetMostIntersectLine(GameObject obj, Bounds1D platformBounds) { }

	protected virtual List<Vector2> GetPositionsForGoodPlaceToDropTest() { }

	private bool IsAreaFullyInsideFloor_Platform(LevelObjectAreaBase area) { }

	protected virtual bool IsCurrentPositionGoodForDrop(out LevelAreaBase area) { }

	private bool IsTouchingUndroppableSmartArea() { }

	protected virtual void OnBeginDragInternal(PointerEventData eventData) { }

	protected virtual void OnDisable() { }

	protected virtual void OnEnable() { }

	protected virtual void OnEndDragInternal(PointerEventData eventData) { }

	protected virtual void OnReadyPostLoad() { }

	public virtual void StartFloating() { }

}

