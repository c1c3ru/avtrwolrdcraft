namespace PWC.Level;

public class LevelHangableClothingSingleStateItem : LevelClothingItem, IInteractableItem, IMultiplayer_NetworkIdentityBase
{
	[SerializeField]
	protected bool _adjustHangPoint; //Field offset: 0x389
	[SerializeField]
	protected LevelHangHandler _hangHandler; //Field offset: 0x390

	public LevelHangableClothingSingleStateItem() { }

	public virtual void InitIfNeeded() { }

	private string Multiplayer_GetKey() { }

	protected virtual void OnBeginDragInternal(PointerEventData eventData) { }

	private override void PWC.Multiplayer.MPDataHelper_ItemDropInteraction.IInteractableItem.Multiplayer_DropInteract(ILevelConsumer consumer, MPEventIdentifierData idData) { }

	public virtual bool TryDropInteraction(ILevelConsumer consumer, out MPEventIdentifierData mpData) { }

}

