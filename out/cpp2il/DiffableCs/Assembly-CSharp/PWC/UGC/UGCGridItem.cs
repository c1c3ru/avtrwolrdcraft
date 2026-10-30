namespace PWC.UGC;

public class UGCGridItem : UGCItemBase, ILevelMakerSnappableFloorLineObject, IUGCGridItemOwner, IUGCEntity
{
	[SerializeField]
	private float _zHeight; //Field offset: 0x120
	[SerializeField]
	private CShape _bottomCShape; //Field offset: 0x128
	[SerializeField]
	private bool _canHoldGridItems; //Field offset: 0x130
	[SerializeField]
	private Transform _flatItemsParent; //Field offset: 0x138
	[SerializeField]
	private Transform _gridItemsParent; //Field offset: 0x140
	[SerializeField]
	private SortingGroup _sortingGroup; //Field offset: 0x148
	[SerializeField]
	private bool _canHoldFlatWallItemsInFront; //Field offset: 0x150
	[SerializeField]
	private bool _canHoldFlatWallItemsInSide; //Field offset: 0x151
	[SerializeField]
	private bool _canHoldFlatFloorItems; //Field offset: 0x152
	[SerializeField]
	private GameObject _gridRenderer; //Field offset: 0x158
	private CShape _topCShape; //Field offset: 0x160
	private CShape _sideCShape; //Field offset: 0x168
	private CShape _frontCShape; //Field offset: 0x170
	[SerializeField]
	private GameShape _bottomGameShape; //Field offset: 0x178
	private readonly List<ILevelMakerSnappableFloorLineObject> _listAsSnappableFloorLineObjectForDrag; //Field offset: 0x180
	private float _zBottom; //Field offset: 0x188
	private IUGCGridItemOwner _owner; //Field offset: 0x190
	private float _scaleFactor; //Field offset: 0x198
	[TupleElementNames(new IL2CPP_TYPE_STRING[] {"min", "max"})]
	private Func<ILevelMakerSnappableFloorLineObject, ValueTuple`2<Vector3, Vector3>> _getMinMaxForSortingTestAction; //Field offset: 0x1A0

	public UGCGridItem() { }

	private static bool AreObjectsIntesectingInXY(UGCGridItem ugcObject1, UGCGridItem ugcObject2) { }

	private void AssignOwnerFromParent() { }

	protected virtual void Awake() { }

	public override bool CanHoldFlatFloorItems() { }

	public bool CanHoldFlatWallItems() { }

	public bool CanHoldFlatWallItemsInFront() { }

	public bool CanHoldFlatWallItemsInSide() { }

	private void ClearListsForDragging() { }

	private static void GetBottomCShapeBounds1DForXAndY(UGCGridItem ugcObject, out Bounds1D xBounds1D, out Bounds1D yBounds1D) { }

	private static ValueTuple<Vector2, Vector2> GetBottomCShapeMinMaxInProjected2D(UGCGridItem ugcObject) { }

	private Vector2[] GetBottomCShapeWorldPoints() { }

	private static void GetBounds1DForXAndY(Vector2[] worldPoints, float zBottom, out Bounds1D xBounds1D, out Bounds1D yBounds1D) { }

	private Vector2 GetCShapeCenter(CShape cShape) { }

	public Vector2 GetFrontCenter() { }

	public CShape GetFrontCShape() { }

	private static ValueTuple<Vector3, Vector3> GetMinMaxForSortingTest(ILevelMakerSnappableFloorLineObject obj) { }

	private void GetObjectsIntesectingInXY(List<UGCGridItem> fromList, List<UGCGridItem> touchingObjects) { }

	public IUGCGridItemOwner GetOwner() { }

	private float GetScaledUnitDepth() { }

	private float GetScaledUnitHeight() { }

	private float GetScaledUnitWidth() { }

	public Vector2 GetSideCenter() { }

	public CShape GetSideCShape() { }

	public override int GetSortingOrder() { }

	public override CShape GetTopCShape() { }

	public int GetUGCChildrenCount() { }

	public virtual Vector2 GetZoomInPosition() { }

	private float GetZTop() { }

	private void InitFacesShapes() { }

	public void InitWithOwner(IUGCGridItemOwner owner, bool isPostSpawnFromUIMenu) { }

	private static bool IsApproxEqual(float a, float b) { }

	private void KeepBoxInsideGridFloor(UGCGridFloor gridFloor, ref Vector2 boxMin, ref Vector2 boxMax) { }

	private void MoveToProjected2DIn3D(Vector2 boxMin) { }

	protected virtual void OnBeginDragInternal(PointerEventData eventData) { }

	public virtual void OnDeselected() { }

	private void OnDragImplement() { }

	protected virtual void OnEndDragInternal(PointerEventData eventData) { }

	protected virtual void OnPreDestroyUGCEntity() { }

	public virtual void OnSelected() { }

	protected virtual void OnSyncPosition(Vector2 pointerPosition) { }

	protected virtual void OnUGCPrePostInit() { }

	public void PerformRemoteDragUpdate() { }

	private override Bounds PWC.Level.Maker.ILevelMakerSnappableFloorLineObject.GetBounds() { }

	private override CShape PWC.Level.Maker.ILevelMakerSnappableFloorLineObject.GetWallCShape() { }

	private override GameShape PWC.Level.Maker.ILevelMakerSnappableFloorLineObject.GetWallGameShape() { }

	private override void PWC.Level.Maker.ILevelMakerSnappableFloorLineObject.SetContentSortingOrder(int sortingOrder) { }

	private override bool PWC.UGC.IUGCGridItemOwner.CanHoldGridItems() { }

	private override Transform PWC.UGC.IUGCGridItemOwner.GetParentForFlatItems() { }

	private override Transform PWC.UGC.IUGCGridItemOwner.GetParentForGridItems() { }

	private override ValueTuple<Vector2, Vector2> PWC.UGC.IUGCGridItemOwner.GetProjected2DMinMax() { }

	private override float PWC.UGC.IUGCGridItemOwner.GetZBottom() { }

	private override float PWC.UGC.IUGCGridItemOwner.GetZTop() { }

	private void SetZBottom(float zBottom) { }

	private void SyncListsForDragging() { }

	private void SyncRenderSorting() { }

	public bool TryPlaceOnProperPositionFromCurrentPosition() { }

	private bool TrySnapToProperPlaceOnOwner(Nullable<Vector2> targetProjected2DPosition = null) { }

	private void UpdatePositionForSnapping() { }

}

