namespace PWC.Level.Maker;

public class LevelMakerSnappableItemHandler : MonoBehaviour, ILevelSpawnDuringGameplay, ILevelMakerSnappableFloorLineObject
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass32_0
	{
		public LevelAreaBase area; //Field offset: 0x10

		public <>c__DisplayClass32_0() { }

		internal bool <SetSortAsRootWhenSnappedIfNeeded>b__0(LevelAvatarRestAreaBase restArea) { }

	}

	internal enum SnapType
	{
		None = 0,
		Wall = 1,
		Floor = 2,
		WallFloor = 3,
	}

	internal struct TouchingItemData
	{
		public Vector2 boxPosition; //Field offset: 0x0
		public Bounds1D xBounds; //Field offset: 0x8
		public Bounds1D yBounds; //Field offset: 0x10

	}

	private const string ROOT_FOR_SORTING_WHEN_SNAPPED = "RootForSortingWhenSnapped"; //Field offset: 0x0
	[SerializeField]
	private SortingGroup _soritngGroup; //Field offset: 0x20
	[SerializeField]
	private SortingGroup _bodySoritngGroup; //Field offset: 0x28
	[SerializeField]
	private CShape _cShape; //Field offset: 0x30
	[SerializeField]
	private SortingGroup[] _stickingOutSortingGroups; //Field offset: 0x38
	[SerializeField]
	private SortingGroup[] _sortAsRootWhenSnappedSortingGroups; //Field offset: 0x40
	[SerializeField]
	private bool _autoSetSortAsRootWhenSnapped; //Field offset: 0x48
	private DragDropItemBase _dragDropItem; //Field offset: 0x50
	[CompilerGenerated]
	private bool <IsInGoodSnappingPosition>k__BackingField; //Field offset: 0x58
	private LevelMakerSnappableFloorLine _currentFloorLine; //Field offset: 0x60
	private GameShape _gameShape; //Field offset: 0x68
	private Int32[] _stickingOutSortingGroupsDefaultSortingOrders; //Field offset: 0x70
	private SnapType _snapType; //Field offset: 0x78
	private WallAngleType _wallAngleType; //Field offset: 0x7C
	public LevelMakerSnappableWallFloorItemBase _snappableWallItemHandler; //Field offset: 0x80
	private List<LevelMakerSnappableFloorLine> _myFloorLinesList; //Field offset: 0x88
	private bool _clampToCameraYBounds; //Field offset: 0x90
	[CompilerGenerated]
	private bool <CanSnapOnSyncPosition>k__BackingField; //Field offset: 0x91

	public bool CanSnapOnSyncPosition
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 12
	}

	public LevelMakerSnappableFloorLine CurrentFloorLine
	{
		 get { } //Length: 8
	}

	public private bool IsInGoodSnappingPosition
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public WallAngleType WallAngleType
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public LevelMakerSnappableItemHandler() { }

	[CompilerGenerated]
	internal static void <UpdatePositionForSnapping>g__HandleAxis|56_0(ref float finalRange, float range, float boxPosition, float otherBoxPosition) { }

	private void Awake() { }

	private void ClampTopYPosition(Vector2 boxBottomCenter) { }

	[CompilerGenerated]
	public bool get_CanSnapOnSyncPosition() { }

	public LevelMakerSnappableFloorLine get_CurrentFloorLine() { }

	[CompilerGenerated]
	public bool get_IsInGoodSnappingPosition() { }

	public WallAngleType get_WallAngleType() { }

	private void GetBounds1DForXAndY(CShapeModel cShapeModel, bool isFlipped, out Bounds1D xBounds1D, out Bounds1D yBounds1D) { }

	private void GetBoxInfo(out Vector2 boxBottomCenter, out Vector2 vectorFromTransformPosition) { }

	private List<ILevelMakerSnappableFloorLineObject> GetCurrentFloorLineObjectsList() { }

	public DragDropItemBase GetDragDropItem() { }

	public GameShape GetGameShape() { }

	public List<LevelMakerSnappableFloorLine> GetSelfFloorLines() { }

	private float GetTopYPosition() { }

	private void GetTouchingObjects(List<ILevelMakerSnappableFloorLineObject> fromList, List<ILevelMakerSnappableFloorLineObject> touchingObjects) { }

	private void GetTuchingItemsData(List<ILevelMakerSnappableFloorLineObject> touchingObjects, List<TouchingItemData> touchingItemsData, Bounds1D xBounds1D, Bounds1D yBounds1D, bool isFlipped, out float overlappingArea) { }

	public override CShape GetWallCShape() { }

	private bool IsBoxIntersectingWithOtherBoxes(List<ILevelMakerSnappableFloorLineObject> list) { }

	public bool IsFlipped() { }

	public void Multiplayer_OnGoodPositionDrop() { }

	public void Multiplayer_OnSyncPosition() { }

	private void OnDestroy() { }

	private void OnDragDropItemSyncPosition(DragDropItemBase dragDropItem, Vector2 _) { }

	private void OnLevelPostInit() { }

	private void OnReadyPostLoad() { }

	private override void PWC.Level.ILevelSpawnDuringGameplay.OnSpawnDuringGameplay() { }

	private override Bounds PWC.Level.Maker.ILevelMakerSnappableFloorLineObject.GetBounds() { }

	private override GameShape PWC.Level.Maker.ILevelMakerSnappableFloorLineObject.GetWallGameShape() { }

	private void ReleaseCollidingLevelItems() { }

	[CompilerGenerated]
	public void set_CanSnapOnSyncPosition(bool value) { }

	[CompilerGenerated]
	private void set_IsInGoodSnappingPosition(bool value) { }

	public void set_WallAngleType(WallAngleType value) { }

	public override void SetContentSortingOrder(int sortingOrder) { }

	public void SetCurrentFloorLine(LevelMakerSnappableFloorLine floorLine) { }

	public void SetRootSortingGroupEnabled(bool isEnabled) { }

	public void SetRootSortingOrder(int sortingOrder) { }

	public void SetSnapType(SnapType snapType) { }

	private void SetSortAsRootWhenSnappedIfNeeded() { }

	public void SyncForCurrentPosition(bool releaseCollingLevelItems) { }

	private bool TryFindAndSyncWithProperLine(Vector2 boxBottomCenter, out LevelMakerSnappableFloorLine floorLine, bool ignoreDynamic = false) { }

	private bool TrySnapItem() { }

	private bool TryToSnapToClosestLine(out LevelMakerSnappableFloorLine floorLine) { }

	private void UpdatePositionForSnapping(List<TouchingItemData> touchingItemsData, CShapeModel cShapeModel, Vector2 boxPosition, float floorYPosition, bool isFlipped) { }

}

