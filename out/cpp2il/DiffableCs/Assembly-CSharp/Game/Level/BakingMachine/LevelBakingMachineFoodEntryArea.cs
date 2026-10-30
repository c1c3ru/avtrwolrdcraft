namespace Game.Level.BakingMachine;

public class LevelBakingMachineFoodEntryArea : LevelConsumerAreaBase, IInteractableItem, IMultiplayer_NetworkIdentityBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public LevelBakingMachineFoodEntryArea <>4__this; //Field offset: 0x10
		public LevelItem levelItem; //Field offset: 0x18

		public <>c__DisplayClass9_0() { }

		internal void <StartProcessItem>b__0() { }

	}

	private LevelBakingMachine _machine; //Field offset: 0x58
	private bool _isConsumingItemInProgress; //Field offset: 0x60
	[CompilerGenerated]
	private int <Multiplayer_ComponentIndex>k__BackingField; //Field offset: 0x64

	public override int Multiplayer_ComponentIndex
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public LevelBakingMachineFoodEntryArea() { }

	protected virtual void Awake() { }

	public virtual bool CanConsumeItem(LevelItem levelItem) { }

	[CompilerGenerated]
	public override int get_Multiplayer_ComponentIndex() { }

	public void Init(LevelBakingMachine machine) { }

	private override void PWC.Multiplayer.MPDataHelper_ConsumerDropInteraction.IInteractableItem.Multiplayer_ConsumerDropInteract(LevelItem levelItem, MPEventIdentifierData idData) { }

	[CompilerGenerated]
	public override void set_Multiplayer_ComponentIndex(int value) { }

	private void StartProcessItem(LevelItem levelItem) { }

	public virtual bool TryLevelItemDropInteraction(LevelItem levelItem, out MPEventIdentifierData mpData) { }

}

