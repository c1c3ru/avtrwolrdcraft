namespace Game.Level.ContextualAnimation;

public abstract class LevelCAPetOnToddlerHandlerBase : LevelCAItemOnBoneHandlerBase
{
	[CompilerGenerated]
	private static Action<LevelCAPetOnToddlerHandlerBase, ICATarget> OnPetGivenToToddlerStatic; //Field offset: 0x0

	public static event Action<LevelCAPetOnToddlerHandlerBase, ICATarget> OnPetGivenToToddlerStatic
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	protected LevelCAPetOnToddlerHandlerBase() { }

	[CompilerGenerated]
	public static void add_OnPetGivenToToddlerStatic(Action<LevelCAPetOnToddlerHandlerBase, ICATarget> value) { }

	protected virtual void Awake() { }

	private void CanBeDroppedOnToddlerHand(LevelDropArea dropArea, ref bool canDrop) { }

	private void DropIfCurrentlyHeldBy(LevelToddler toddler) { }

	protected void EnsurePetFacesToddler(LevelAnimal pet) { }

	protected override string GetIdleAnimationName() { }

	public virtual SpineType GetSpineType() { }

	private static bool IsCurrentlyHeldByCharacter(LevelToddler toddler) { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	protected override void OnBeforePlacedOnToddler(ILevelAvatar avatar, ItemOnAvatarType type) { }

	protected virtual void OnDestroy() { }

	private void OnPostInit() { }

	protected override void OnRemovedFromToddler(ILevelAvatar avatar) { }

	private void OnToddlerIsHeldByCharacterChanged(LevelToddler toddler, bool isHeldByCharacter) { }

	private void OnToddlerPostureTypeChanged(LevelToddler toddler, PostureType postureType) { }

	[CompilerGenerated]
	public static void remove_OnPetGivenToToddlerStatic(Action<LevelCAPetOnToddlerHandlerBase, ICATarget> value) { }

	protected bool TryOverridePreBeginDrag(DragDropItemBase dragDropItem, PointerEventData eventData) { }

}

