namespace PWC.Level;

[DisallowMultipleComponent]
public class LevelRecipeItemHandler : LevelSimpleItemHandlerConsumerBase, IInteractableItem, IMultiplayer_NetworkIdentityBase
{
	[CompilerGenerated]
	private static Action<LevelItem, LevelItem> OnApplyRecipeAction; //Field offset: 0x0
	[SerializeField]
	private bool _keepItem; //Field offset: 0x28
	[SerializeField]
	private bool _useEffectColorHandler; //Field offset: 0x29
	[ConditionalField("_useEffectColorHandler", False, True, (array) null)]
	[SerializeField]
	private Color _particleSystemColor; //Field offset: 0x2C
	[SerializeField]
	private ParticleSystem _overrideEffectPrefab; //Field offset: 0x40
	[SerializeField]
	private string _mergeSound; //Field offset: 0x48
	private PDPrefab _myPDPrefab; //Field offset: 0x50
	public Func<LevelItem, Boolean> OverrideOnCreateAction; //Field offset: 0x58
	[CompilerGenerated]
	private int <Multiplayer_ComponentIndex>k__BackingField; //Field offset: 0x60

	public static event Action<LevelItem, LevelItem> OnApplyRecipeAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public override int Multiplayer_ComponentIndex
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public LevelRecipeItemHandler() { }

	[CompilerGenerated]
	public static void add_OnApplyRecipeAction(Action<LevelItem, LevelItem> value) { }

	private void ApplyRecipe(LevelRecipeItemHandler consumerRecipeHandler, string outcomePDPrefabGuid) { }

	protected virtual void Awake() { }

	[CompilerGenerated]
	public override int get_Multiplayer_ComponentIndex() { }

	private void OnDestroy() { }

	private override void PWC.Multiplayer.MPDataHelper_ItemDropInteraction.IInteractableItem.Multiplayer_DropInteract(ILevelConsumer consumer, MPEventIdentifierData idData) { }

	[CompilerGenerated]
	public static void remove_OnApplyRecipeAction(Action<LevelItem, LevelItem> value) { }

	[CompilerGenerated]
	public override void set_Multiplayer_ComponentIndex(int value) { }

	public void TryDropInteraction(ILevelConsumer consumer, ref bool didInteract, ref MPEventIdentifierData mpData) { }

}

