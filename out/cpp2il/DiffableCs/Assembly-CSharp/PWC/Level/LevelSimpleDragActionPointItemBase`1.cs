namespace PWC.Level;

public abstract class LevelSimpleDragActionPointItemBase : LevelItem, IInteractableItem, IMultiplayer_NetworkIdentityBase
{
	[SerializeField]
	private LevelDragActionPointHandler _dragActionHandler; //Field offset: 0x0
	private bool _multiplayer_canSendEvent; //Field offset: 0x0

	protected LevelSimpleDragActionPointItemBase`1() { }

	protected virtual void Awake() { }

	private bool Multiplayer_ShouldSendEvent() { }

	protected virtual void OnBeginDragInternal(PointerEventData eventData) { }

	protected virtual void OnDestroy() { }

	protected virtual void OnEndDragInternal(PointerEventData eventData) { }

	protected virtual void OnSyncPosition(Vector2 pointerPosition) { }

	protected abstract void OnTargetEnter(T target) { }

	private void OnTargetEnterInternal(ILevelConsumer consumer) { }

	protected abstract void OnTargetExit(T target) { }

	private void OnTargetExitInternal(ILevelConsumer consumer) { }

	private override void PWC.Multiplayer.MPDataHelper_ItemDragInteraction.IInteractableItem.Multiplayer_DragInteract(ILevelConsumer consumer, Multiplayer_EventType eventType, MPEventIdentifierData idData) { }

	public virtual bool TryDragInteraction(ILevelConsumer consumer) { }

}

