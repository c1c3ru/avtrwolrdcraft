namespace PWC.Level;

[DisallowMultipleComponent]
public class LevelBakeryMoldInteractionItemHandler : LevelSimpleItemHandlerConsumerBase, IInteractableItem, IMultiplayer_NetworkIdentityBase
{
	[SerializeField]
	private LevelBakingMoldItemHandler _itemHandler; //Field offset: 0x28
	[CompilerGenerated]
	private int <Multiplayer_ComponentIndex>k__BackingField; //Field offset: 0x30

	public override int Multiplayer_ComponentIndex
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public LevelBakeryMoldInteractionItemHandler() { }

	protected virtual void Awake() { }

	[CompilerGenerated]
	public override int get_Multiplayer_ComponentIndex() { }

	private void OnDestroy() { }

	private override void PWC.Multiplayer.MPDataHelper_ItemDropInteraction.IInteractableItem.Multiplayer_DropInteract(ILevelConsumer consumer, MPEventIdentifierData idData) { }

	[CompilerGenerated]
	public override void set_Multiplayer_ComponentIndex(int value) { }

	public void TryDropInteraction(ILevelConsumer consumer, ref bool didInteract, ref MPEventIdentifierData mpData) { }

	private bool TryDropInteraction_Internal(LevelBakeryDoughInteractionItemHandler dough) { }

}

