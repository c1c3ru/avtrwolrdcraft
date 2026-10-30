namespace Game.Level.Baking;

[DisallowMultipleComponent]
public class LevelBakeryDoughInteractionItemHandler : LevelSimpleItemHandlerConsumerBase, IInteractableItem, IMultiplayer_NetworkIdentityBase
{
	[SerializeField]
	private LevelCookableItemHandler _cookableHandler; //Field offset: 0x28
	[CompilerGenerated]
	private int <Multiplayer_ComponentIndex>k__BackingField; //Field offset: 0x30

	public override int Multiplayer_ComponentIndex
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public LevelBakeryDoughInteractionItemHandler() { }

	protected virtual void Awake() { }

	[CompilerGenerated]
	public override int get_Multiplayer_ComponentIndex() { }

	private void OnDestroy() { }

	private override void PWC.Multiplayer.MPDataHelper_ItemDropInteraction.IInteractableItem.Multiplayer_DropInteract(ILevelConsumer consumer, MPEventIdentifierData idData) { }

	[CompilerGenerated]
	public override void set_Multiplayer_ComponentIndex(int value) { }

	public void TryDropInteraction(ILevelConsumer consumer, ref bool didInteract, ref MPEventIdentifierData mpData) { }

	private bool TryDropInteraction_Internal(LevelBakeryMoldInteractionItemHandler mold) { }

}

