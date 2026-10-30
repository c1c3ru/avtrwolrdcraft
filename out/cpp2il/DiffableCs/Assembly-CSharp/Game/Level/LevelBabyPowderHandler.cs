namespace Game.Level;

public class LevelBabyPowderHandler : LevelConsumerAreaBase, IInteractableItem, IMultiplayer_NetworkIdentityBase
{
	[SerializeField]
	private SpriteRenderer _offMouthSpriteRenderer; //Field offset: 0x58
	[SerializeField]
	private SpriteRenderer _onMouthSpriteRenderer; //Field offset: 0x60
	[SerializeField]
	private Sprite _offMouthSprite; //Field offset: 0x68
	[SerializeField]
	private Sprite _onMouthSprite; //Field offset: 0x70
	[CompilerGenerated]
	private int <Multiplayer_ComponentIndex>k__BackingField; //Field offset: 0x78

	public override int Multiplayer_ComponentIndex
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public LevelBabyPowderHandler() { }

	protected virtual void Awake() { }

	[CompilerGenerated]
	public override int get_Multiplayer_ComponentIndex() { }

	private void LevelItemDropInteraction_Implement(LevelItem levelItem) { }

	private override void PWC.Multiplayer.MPDataHelper_ConsumerDropInteraction.IInteractableItem.Multiplayer_ConsumerDropInteract(LevelItem levelItem, MPEventIdentifierData idData) { }

	[CompilerGenerated]
	public override void set_Multiplayer_ComponentIndex(int value) { }

	public virtual bool TryLevelItemDropInteraction(LevelItem levelItem, out MPEventIdentifierData mpData) { }

}

