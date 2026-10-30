namespace PWC.Level;

public class LevelHangableItemHandler : MonoBehaviour, IInteractableItem, IMultiplayer_NetworkIdentityBase
{
	[SerializeField]
	protected LevelHangHandler _hangHandler; //Field offset: 0x20
	[SerializeField]
	private bool _canHoldItemsWhileHang; //Field offset: 0x28
	private LevelItem _levelItem; //Field offset: 0x30
	[CompilerGenerated]
	private int <Multiplayer_ComponentIndex>k__BackingField; //Field offset: 0x38

	public override int Multiplayer_ComponentIndex
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public LevelHangableItemHandler() { }

	private void Awake() { }

	[CompilerGenerated]
	public override int get_Multiplayer_ComponentIndex() { }

	private string Multiplayer_GetKey() { }

	private void OnDestroy() { }

	private void OnItemBeginDragAction(DragDropItemBase item, PointerEventData eventData) { }

	private void OnItemEndDragAction(DragDropItemBase item, PointerEventData eventData) { }

	private override void PWC.Multiplayer.MPDataHelper_ItemDropInteraction.IInteractableItem.Multiplayer_DropInteract(ILevelConsumer consumer, MPEventIdentifierData idData) { }

	[CompilerGenerated]
	public override void set_Multiplayer_ComponentIndex(int value) { }

	private void TryItemDropInteractionAction(ILevelConsumer consumer, ref bool didInteract, ref MPEventIdentifierData mpData) { }

}

