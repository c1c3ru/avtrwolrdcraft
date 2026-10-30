namespace PWC.Level;

public class LevelDrinkableItemHandler : LevelDragActionItemHandlerBase, ILevelConsumer, IInteractableItem, IMultiplayer_NetworkIdentityBase, IInteractableItem
{
	[SerializeField]
	private UnityEvent _onDrinkEvent; //Field offset: 0xA0
	private ILevelFillable _fillable; //Field offset: 0xA8

	public LevelItem MyLevelItem
	{
		 get { } //Length: 8
	}

	public LevelDrinkableItemHandler() { }

	protected virtual void Awake() { }

	public override bool CanBeDrinked() { }

	protected virtual bool FilterTarget(ILevelConsumer target) { }

	public LevelItem get_MyLevelItem() { }

	public override ILevelEntity GetEntity() { }

	public override GameShape GetGameShape() { }

	public override SortingElement GetSortingElement() { }

	public override int GetSortPriority() { }

	public override Transform GetTransform() { }

	protected virtual bool IsValidTarget(ILevelConsumer consumer) { }

	private string Multiplayer_GetKey() { }

	protected virtual void OnDestroy() { }

	protected virtual void OnDisable() { }

	protected virtual void OnEnable() { }

	protected override void OnItemLand(LevelDropArea dropArea) { }

	protected virtual void OnTargetEnter(ILevelConsumer consumer) { }

	protected virtual void OnTargetExit(ILevelConsumer consumer, ExitReasonType exitReasonType) { }

	private override void PWC.Multiplayer.MPDataHelper_ItemDropCharacterInteraction.IInteractableItem.Multiplayer_DropInteractWithCharacter(LevelCharacter character, MPEventIdentifierData idData) { }

	private override void PWC.Multiplayer.MPDataHelper_ItemDropInteraction.IInteractableItem.Multiplayer_DropInteract(ILevelConsumer consumer, MPEventIdentifierData idData) { }

	protected override void TryDropInteraction(ILevelConsumer consumer, ref bool didInteract, ref MPEventIdentifierData mpData) { }

	protected override void TryDropInteractionWithCharacter(LevelCharacter character, ref bool didInteract, ref MPEventIdentifierData mpData) { }

}

