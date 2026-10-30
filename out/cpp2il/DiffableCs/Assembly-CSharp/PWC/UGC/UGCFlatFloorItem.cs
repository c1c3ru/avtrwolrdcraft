namespace PWC.UGC;

public class UGCFlatFloorItem : UGCItemBase, ILevelMakerUIMenuItem
{
	private IUGCGridItemOwner _owner; //Field offset: 0x120
	private SortingGroup _sortingGroup; //Field offset: 0x128

	public UGCFlatFloorItem() { }

	protected virtual void Awake() { }

	public IUGCGridItemOwner GetOwner() { }

	public void InitWithOwner(IUGCGridItemOwner owner, bool isPostSpawnFromUIMenu) { }

	protected virtual void OnBeginDragInternal(PointerEventData eventData) { }

	public virtual void OnDeselected() { }

	protected virtual void OnEndDragInternal(PointerEventData eventData) { }

	public virtual void OnSelected() { }

	protected virtual void OnSyncPosition(Vector2 pointerPosition) { }

	protected virtual void OnUGCPostInit() { }

	private override void PWC.Level.Maker.ILevelMakerUIMenuItem.OnCreatedInsideUIItem() { }

	private void SetSortingOrder(int sortingOrder) { }

	private void SyncOnDrag() { }

	private void SyncToCurrentOwner(bool isPostSpawnFromUIMenu) { }

}

