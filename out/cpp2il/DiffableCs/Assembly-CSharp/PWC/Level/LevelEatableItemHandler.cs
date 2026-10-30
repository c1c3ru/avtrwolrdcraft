namespace PWC.Level;

[RequireComponent(typeof(LevelItem))]
public class LevelEatableItemHandler : MonoBehaviour, IInteractableItem, IMultiplayer_NetworkIdentityBase, IInteractableItem
{
	[SerializeField]
	private bool _useEffectColorHandler; //Field offset: 0x20
	[ConditionalField("_useEffectColorHandler", False, True, (array) null)]
	[SerializeField]
	protected Color _particleSystemColor; //Field offset: 0x24
	[SerializeField]
	protected ParticleSystem _overrideEffectPrefab; //Field offset: 0x38
	[SerializeField]
	private EaterType _eaterType; //Field offset: 0x40
	[SerializeField]
	private bool _checkSpesificSpineTypeForEventTrigger; //Field offset: 0x44
	[ConditionalField("_checkSpesificSpineTypeForEventTrigger", True, True, (array) null)]
	[SerializeField]
	private SpineType _spineType; //Field offset: 0x48
	[SerializeField]
	public UnityEvent OnItemEaten; //Field offset: 0x50
	private LevelItem _levelItem; //Field offset: 0x58
	private LevelEffectColorHandler _effectColorHandler; //Field offset: 0x60
	[CompilerGenerated]
	private int <Multiplayer_ComponentIndex>k__BackingField; //Field offset: 0x68

	public EaterType EaterType
	{
		 get { } //Length: 8
	}

	public override int Multiplayer_ComponentIndex
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public LevelItem MyLevelItem
	{
		 get { } //Length: 8
	}

	public LevelEatableItemHandler() { }

	private void Awake() { }

	public EaterType get_EaterType() { }

	[CompilerGenerated]
	public override int get_Multiplayer_ComponentIndex() { }

	public LevelItem get_MyLevelItem() { }

	private Color GetParticleSystemColor() { }

	private string Multiplayer_GetKey() { }

	public void OnBeginEating(LevelItem eater) { }

	private void OnDestroy() { }

	private void PlayEatingParticleSystem(LevelItem eater) { }

	private override void PWC.Multiplayer.MPDataHelper_ItemDropCharacterInteraction.IInteractableItem.Multiplayer_DropInteractWithCharacter(LevelCharacter character, MPEventIdentifierData idData) { }

	private override void PWC.Multiplayer.MPDataHelper_ItemDropInteraction.IInteractableItem.Multiplayer_DropInteract(ILevelConsumer consumer, MPEventIdentifierData idData) { }

	private void ReleaseNotEatableItemFromSelf() { }

	[CompilerGenerated]
	public override void set_Multiplayer_ComponentIndex(int value) { }

	protected override void TryDropInteraction(ILevelConsumer consumer, ref bool didInteract, ref MPEventIdentifierData mpData) { }

	protected override void TryDropInteractionWithCharacter(LevelCharacter character, ref bool didInteract, ref MPEventIdentifierData mpData) { }

}

