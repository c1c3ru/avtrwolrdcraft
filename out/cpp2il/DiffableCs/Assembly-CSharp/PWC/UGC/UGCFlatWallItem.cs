namespace PWC.UGC;

public class UGCFlatWallItem : UGCItemBase, ILevelMakerUIMenuItem, IHasPersistentData, IRequirePDSceneObject
{
	internal enum StateType
	{
		None = 0,
		Front = 1,
		Side = 2,
	}

	[SerializeField]
	private GameObject _frontState; //Field offset: 0x120
	[SerializeField]
	private GameObject _sideState; //Field offset: 0x128
	[SerializeField]
	private int _sortingOrderOffset; //Field offset: 0x130
	private UGCGridItem _owner; //Field offset: 0x138
	private StateType _currentState; //Field offset: 0x140
	private SortingGroup _sortingGroup; //Field offset: 0x148

	public UGCFlatWallItem() { }

	[CompilerGenerated]
	private Vector2 <TryFindGoodPositionOnOwner>g__GetPosition|16_0(bool fromFrontCShape) { }

	protected virtual void Awake() { }

	public virtual Vector2 GetZoomInPosition() { }

	public void InitWithOwner(UGCGridItem owner, bool isPostSpawnFromUIMenu) { }

	protected virtual void OnBeginDragInternal(PointerEventData eventData) { }

	public virtual void OnDeselected() { }

	protected virtual void OnEndDragInternal(PointerEventData eventData) { }

	public virtual void OnSelected() { }

	protected virtual void OnSyncPosition(Vector2 pointerPosition) { }

	protected virtual void OnUGCPostInit() { }

	private override void PWC.Level.Maker.ILevelMakerUIMenuItem.OnCreatedInsideUIItem() { }

	private override Dictionary<String, Object> PWC.PersistentData.IHasPersistentData.GetPersistentData() { }

	private override void PWC.PersistentData.IHasPersistentData.SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SetSortingOrder(int sortingOrder) { }

	private void SetState(StateType stateType) { }

	private void SyncOnDrag() { }

	private void SyncToCurrentOwner(bool isPostSpawnFromUIMenu) { }

	private void TryFindGoodPositionOnOwner() { }

}

