namespace PWC.Level;

public abstract class LevelSimpleDragActionItemBase : LevelItem, ILevelDragActionItemHandler
{
	[SerializeField]
	protected LevelDragActionHandler _dragActionHandler; //Field offset: 0x348
	private Predicate<ILevelConsumer> _filterTarget; //Field offset: 0x350

	public override LevelDragActionHandler DragActionHandler
	{
		 get { } //Length: 8
	}

	protected LevelSimpleDragActionItemBase() { }

	protected virtual void Awake() { }

	protected abstract bool FilterTarget(ILevelConsumer target) { }

	public override LevelDragActionHandler get_DragActionHandler() { }

	public override bool IsConsumerGoodTarget(ILevelConsumer consumer) { }

	protected override bool IsStrictInteractionTest() { }

	protected override bool IsValidTarget(ILevelConsumer target) { }

	protected virtual void OnBeginDragInternal(PointerEventData eventData) { }

	protected virtual void OnDestroy() { }

	protected virtual void OnEndDragInternal(PointerEventData eventData) { }

	protected virtual void OnSyncPosition(Vector2 pointerPosition) { }

	protected abstract void OnTargetEnter(ILevelConsumer target) { }

	private void OnTargetEnterInternal(ILevelConsumer consumer) { }

	protected abstract void OnTargetExit(ILevelConsumer target) { }

	private void OnTargetExitInternal(ILevelConsumer consumer, ExitReasonType exitReasonType) { }

	private void PrepareConsumers() { }

	public void TryActionOnce() { }

	public virtual bool TryDragInteraction(ILevelConsumer consumer) { }

}

