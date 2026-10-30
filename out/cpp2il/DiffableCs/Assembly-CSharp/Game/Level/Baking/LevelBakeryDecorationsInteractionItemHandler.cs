namespace Game.Level.Baking;

[DisallowMultipleComponent]
public class LevelBakeryDecorationsInteractionItemHandler : MonoBehaviour, IInteractableItem, IMultiplayer_NetworkIdentityBase
{
	private enum DecorationType
	{
		Melting = 0,
		Regular = 1,
		CakeOnly = 2,
	}

	private enum RegularDecorations
	{
		Almonds = 0,
		Pearl = 1,
		Chestnuts = 2,
		ChocolateBall = 3,
		VanillaBean = 4,
		Pistachio = 5,
	}

	private const string TOPPING_DIRECTORY_PATH = "Food_BakeryToppings/"; //Field offset: 0x0
	[SerializeField]
	private LevelItem _levelItem; //Field offset: 0x20
	[SerializeField]
	private DecorationType _decorationType; //Field offset: 0x28
	[ConditionalField("_decorationType", null, True, (array) null, CompareValues = new IL2CPP_TYPE_OBJECT[] {"Regular", "CakeOnly"})]
	[SerializeField]
	private RegularDecorations _RegularDecorationName; //Field offset: 0x2C
	[ConditionalField("_decorationType", "Melting", True, (array) null)]
	[SerializeField]
	private LevelEffectColorHandler colorHandler; //Field offset: 0x30
	[CompilerGenerated]
	private int <Multiplayer_ComponentIndex>k__BackingField; //Field offset: 0x38

	public override int Multiplayer_ComponentIndex
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public LevelBakeryDecorationsInteractionItemHandler() { }

	protected void Awake() { }

	[CompilerGenerated]
	public override int get_Multiplayer_ComponentIndex() { }

	private void GetMeltingDecorationPathes(LevelBakeryPastryInteractionItemHandler pastry, out string unbaked, out string baked) { }

	private void GetRegularDecorationPath(LevelBakeryPastryInteractionItemHandler pastry, out string pastryDecorationPath, out string sliceDecorationPath) { }

	private void OnDestroy() { }

	private override void PWC.Multiplayer.MPDataHelper_ItemDropInteraction.IInteractableItem.Multiplayer_DropInteract(ILevelConsumer consumer, MPEventIdentifierData idData) { }

	[CompilerGenerated]
	public override void set_Multiplayer_ComponentIndex(int value) { }

	public void TryDropInteraction(ILevelConsumer consumer, ref bool didInteract, ref MPEventIdentifierData mpData) { }

	private bool TryDropInternaction_Internal(LevelBakeryPastryInteractionItemHandler pastry) { }

}

