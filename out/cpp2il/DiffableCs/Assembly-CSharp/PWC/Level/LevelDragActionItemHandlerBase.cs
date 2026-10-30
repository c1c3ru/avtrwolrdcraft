namespace PWC.Level;

public abstract class LevelDragActionItemHandlerBase : LevelDragActionHandler, ILevelDragActionItemHandler
{
	internal sealed class FilterTargetDelegate : MulticastDelegate
	{

		public FilterTargetDelegate(object object, IntPtr method) { }

		public override IAsyncResult BeginInvoke(ILevelConsumer consumer, ref bool canConsume, AsyncCallback callback, object object) { }

		public override void EndInvoke(ref bool canConsume, IAsyncResult result) { }

		public override void Invoke(ILevelConsumer consumer, ref bool canConsume) { }

	}

	private Func<ILevelConsumer, Boolean> _performDragCondition; //Field offset: 0x88
	private Predicate<ILevelConsumer> _filterTarget; //Field offset: 0x90
	[CompilerGenerated]
	private FilterTargetDelegate FilterTargetAction; //Field offset: 0x98

	public event FilterTargetDelegate FilterTargetAction
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public override LevelDragActionHandler DragActionHandler
	{
		 get { } //Length: 4
	}

	protected LevelDragActionItemHandlerBase() { }

	[CompilerGenerated]
	public void add_FilterTargetAction(FilterTargetDelegate value) { }

	protected virtual void Awake() { }

	protected override bool FilterTarget(ILevelConsumer target) { }

	public override LevelDragActionHandler get_DragActionHandler() { }

	public override bool IsConsumerGoodTarget(ILevelConsumer consumer) { }

	protected override bool IsStrictInteractionTest() { }

	protected override bool IsValidTarget(ILevelConsumer target) { }

	protected override void OnBeginDrag(DragDropItemBase item, PointerEventData eventData) { }

	protected virtual void OnDestroy() { }

	protected override void OnDisable() { }

	protected override void OnEnable() { }

	protected override void OnEndDrag(DragDropItemBase item, PointerEventData eventData) { }

	protected void OnSyncPosition(DragDropItemBase item, Vector2 pointerPosition) { }

	protected abstract void OnTargetEnter(ILevelConsumer target) { }

	protected virtual void OnTargetEnterInternal(ILevelConsumer consumer) { }

	protected abstract void OnTargetExit(ILevelConsumer target, ExitReasonType exitReasonType) { }

	protected virtual void OnTargetExitInternal(ILevelConsumer consumer, ExitReasonType exitReasonType) { }

	protected override bool PerformDragCondition(ILevelConsumer consumer) { }

	private void PrepareConsumers() { }

	[CompilerGenerated]
	public void remove_FilterTargetAction(FilterTargetDelegate value) { }

	public void TryActionOnce() { }

}

