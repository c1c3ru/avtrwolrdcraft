namespace PWC.Level;

[AddComponentMenu(null)]
public class LevelSimpleHangableItem : LevelItem, IInteractableItem, IMultiplayer_NetworkIdentityBase, IMultiplayer_PrepareForDrop
{
	[SerializeField]
	protected LevelHangHandler _hangHandler; //Field offset: 0x348

	public LevelSimpleHangableItem() { }

	private string Multiplayer_GetKey() { }

	public override void Multiplayer_PrepareForDrop(MPDataType tiggerFromDataType) { }

	protected virtual void OnBeginDragInternal(PointerEventData eventData) { }

	protected virtual void OnEndDragInternal(PointerEventData eventData) { }

	private override void PWC.Multiplayer.MPDataHelper_ItemDropInteraction.IInteractableItem.Multiplayer_DropInteract(ILevelConsumer consumer, MPEventIdentifierData idData) { }

	public virtual bool TryDropInteraction(ILevelConsumer consumer, out MPEventIdentifierData mpData) { }

}

