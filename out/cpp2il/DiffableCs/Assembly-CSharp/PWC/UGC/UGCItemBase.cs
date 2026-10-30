namespace PWC.UGC;

public class UGCItemBase : DragDropItemBase, IUGCEntity, IUGCSpawnableFromUI, ILevelMakerDeletableByUIItem
{
	internal sealed class CanBeDeletedDelegate : MulticastDelegate
	{

		public CanBeDeletedDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(ref bool canBeDeleted, AsyncCallback callback, object object) { }

		public override void EndInvoke(ref bool canBeDeleted, IAsyncResult result) { }

		public override void Invoke(ref bool canBeDeleted) { }

	}

	[CompilerGenerated]
	private static Action<UGCItemBase> OnItemBeginDragAction; //Field offset: 0x0
	[CompilerGenerated]
	private static Action<UGCItemBase> OnItemClickAction; //Field offset: 0x8
	[CompilerGenerated]
	private static Action<UGCItemBase> OnItemPreDestroyUGCEntityAction; //Field offset: 0x10
	[CompilerGenerated]
	private Action<UGCItemBase> OnPreDestroyUGCEntityAction; //Field offset: 0x110
	[CompilerGenerated]
	private CanBeDeletedDelegate CanBeDeletedAction; //Field offset: 0x118

	public event CanBeDeletedDelegate CanBeDeletedAction
	{
		[CompilerGenerated]
		 add { } //Length: 160
		[CompilerGenerated]
		 remove { } //Length: 160
	}

	public static event Action<UGCItemBase> OnItemBeginDragAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public static event Action<UGCItemBase> OnItemClickAction
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	public static event Action<UGCItemBase> OnItemPreDestroyUGCEntityAction
	{
		[CompilerGenerated]
		 add { } //Length: 208
		[CompilerGenerated]
		 remove { } //Length: 208
	}

	public event Action<UGCItemBase> OnPreDestroyUGCEntityAction
	{
		[CompilerGenerated]
		 add { } //Length: 180
		[CompilerGenerated]
		 remove { } //Length: 180
	}

	public UGCItemBase() { }

	[CompilerGenerated]
	public void add_CanBeDeletedAction(CanBeDeletedDelegate value) { }

	[CompilerGenerated]
	public static void add_OnItemBeginDragAction(Action<UGCItemBase> value) { }

	[CompilerGenerated]
	public static void add_OnItemClickAction(Action<UGCItemBase> value) { }

	[CompilerGenerated]
	public static void add_OnItemPreDestroyUGCEntityAction(Action<UGCItemBase> value) { }

	[CompilerGenerated]
	public void add_OnPreDestroyUGCEntityAction(Action<UGCItemBase> value) { }

	protected virtual void Awake() { }

	private bool CanBeDeleted() { }

	public void DestroyUGCEntity() { }

	public override Vector2 GetZoomInPosition() { }

	protected virtual void OnBeginDragInternal(PointerEventData eventData) { }

	public override void OnDeselected() { }

	protected virtual void OnDestroy() { }

	private void OnEditModeChange(bool isEditMode) { }

	protected virtual void OnPointerClickInternal(PointerEventData eventData) { }

	protected override void OnPreDestroyUGCEntity() { }

	public override void OnSelected() { }

	protected override void OnUGCPostInit() { }

	protected override void OnUGCPrePostInit() { }

	private override bool PWC.Level.Maker.ILevelMakerDeletableByUIItem.CanBeDestroyedByUIButton() { }

	private override void PWC.Level.Maker.ILevelMakerDeletableByUIItem.DestoryByUIBUtton() { }

	private override MonoBehaviour PWC.UGC.IUGCEntity.GetMonoBehaviour() { }

	[CompilerGenerated]
	public void remove_CanBeDeletedAction(CanBeDeletedDelegate value) { }

	[CompilerGenerated]
	public static void remove_OnItemBeginDragAction(Action<UGCItemBase> value) { }

	[CompilerGenerated]
	public static void remove_OnItemClickAction(Action<UGCItemBase> value) { }

	[CompilerGenerated]
	public static void remove_OnItemPreDestroyUGCEntityAction(Action<UGCItemBase> value) { }

	[CompilerGenerated]
	public void remove_OnPreDestroyUGCEntityAction(Action<UGCItemBase> value) { }

}

