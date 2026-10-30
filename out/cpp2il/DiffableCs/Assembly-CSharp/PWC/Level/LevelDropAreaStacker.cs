namespace PWC.Level;

public class LevelDropAreaStacker : LevelDropAreaLinker, ILevelSpawnDuringGameplay
{
	[SerializeField]
	private int _maxItemsInStack; //Field offset: 0x64
	private int _itemsInStack; //Field offset: 0x68
	private LevelDropArea _currentDropArea; //Field offset: 0x70
	private bool _isDropBegan; //Field offset: 0x78
	private LevelItem _currentFallingItem; //Field offset: 0x80

	private void _dropArea_OnAllHierarchyChildrenDropAreaItemInterruptDropAction(LevelDropArea arg1, LevelItem arg2) { }

	private void _dropArea_OnAllHierarchyChildrenDropAreaItemPickUpAction(LevelDropArea arg1, LevelItem arg2) { }

	private void _dropArea_OnItemBeginDropAction(LevelDropArea levelDropArea, LevelItem obj) { }

	public LevelDropAreaStacker() { }

	protected virtual void Awake() { }

	public virtual bool CanConsumeItem(LevelItem levelItem) { }

	private void CountAddedItems(LevelItem firstItemAdded) { }

	private void CountAllItems() { }

	private void EnsureOnReadyPostLoad() { }

	public virtual LevelDropArea GetDropArea() { }

	private void OnAllHierarchyChildrenDropAreaItemEndDrop(LevelDropArea arg1, LevelItem arg2) { }

	protected virtual void OnDestroy() { }

	private void OnLevelPostInit() { }

	public override void OnSpawnDuringGameplay() { }

	private void ReleaseItemAndEnsureEnabledDropArea(LevelItem item) { }

	private void UpdateCurrentDropArea(LevelItem obj) { }

}

