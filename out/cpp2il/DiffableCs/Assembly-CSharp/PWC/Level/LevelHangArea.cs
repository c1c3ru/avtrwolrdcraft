namespace PWC.Level;

public class LevelHangArea : LevelConsumerAreaBase, IRequirePDSceneObject, ILevelItemDetachFromParentListener, IItemsHolderArea
{
	public LevelHangHandler currentItem; //Field offset: 0x58
	[CompilerGenerated]
	private Action<LevelItem> OnItemHangAction; //Field offset: 0x60
	[CompilerGenerated]
	private Action<LevelItem> OnItemPickUpAction; //Field offset: 0x68

	public event Action<LevelItem> OnItemHangAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<LevelItem> OnItemPickUpAction
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	private override event Action<LevelItem> PWC.Level.IItemsHolderArea.OnItemsHolderItemEndDropAction
	{
		private add { } //Length: 4
		private remove { } //Length: 4
	}

	public LevelHangArea() { }

	[CompilerGenerated]
	public void add_OnItemHangAction(Action<LevelItem> value) { }

	[CompilerGenerated]
	public void add_OnItemPickUpAction(Action<LevelItem> value) { }

	protected virtual void Awake() { }

	public Vector2 GetHangPosition() { }

	protected virtual void OnDestroy() { }

	public void OnItemHang(LevelItem levelItem) { }

	private void OnLevelPostInit() { }

	private override void PWC.Level.IItemsHolderArea.add_OnItemsHolderItemEndDropAction(Action<LevelItem> value) { }

	private override bool PWC.Level.IItemsHolderArea.HasItemsOnSelf() { }

	private override void PWC.Level.IItemsHolderArea.ReleaseItems() { }

	private override void PWC.Level.IItemsHolderArea.remove_OnItemsHolderItemEndDropAction(Action<LevelItem> value) { }

	private override void PWC.Level.ILevelItemDetachFromParentListener.OnChildItemDetachUnderSelfHierarchy(LevelItem levelItem) { }

	public override void ReleaseHangableItemIfNeeded() { }

	[CompilerGenerated]
	public void remove_OnItemHangAction(Action<LevelItem> value) { }

	[CompilerGenerated]
	public void remove_OnItemPickUpAction(Action<LevelItem> value) { }

}

