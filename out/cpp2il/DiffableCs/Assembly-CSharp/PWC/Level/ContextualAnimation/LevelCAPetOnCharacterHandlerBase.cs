namespace PWC.Level.ContextualAnimation;

public abstract class LevelCAPetOnCharacterHandlerBase : LevelCAItemOnBoneHandlerBase
{
	[CompilerGenerated]
	private static Action<LevelCAPetOnCharacterHandlerBase, ICATarget> OnPetGivenToAvatarStatic; //Field offset: 0x0
	private bool _allowPairWithDropActionArea; //Field offset: 0x98

	public static event Action<LevelCAPetOnCharacterHandlerBase, ICATarget> OnPetGivenToAvatarStatic
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	protected LevelCAPetOnCharacterHandlerBase() { }

	[CompilerGenerated]
	public static void add_OnPetGivenToAvatarStatic(Action<LevelCAPetOnCharacterHandlerBase, ICATarget> value) { }

	protected virtual void Awake() { }

	public override bool CanPairWithDropActionArea() { }

	protected override string GetIdleAnimationName() { }

	public virtual SpineType GetSpineType() { }

	private bool HasCarrierSibling() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	protected override void OnBeforePlacedOnCharacter(ILevelAvatar avatar, ItemOnAvatarType type) { }

	protected virtual void OnDestroy() { }

	protected virtual void OnReadyPostLoad() { }

	protected override void OnRemovedFromCharacter(ILevelAvatar avatar) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	protected override void PlayPetIdle() { }

	protected void PlayReactionAnimation(string animationName, bool isLoop) { }

	protected void RefreshSkeletonAnimation(ILevelAvatar avatar) { }

	[CompilerGenerated]
	public static void remove_OnPetGivenToAvatarStatic(Action<LevelCAPetOnCharacterHandlerBase, ICATarget> value) { }

	protected void RemoveSkin(Skin mainSkin, Skin skinToRemove) { }

	protected override bool ShouldDeferToCarrierSibling() { }

	protected bool TryOverridePreBeginDrag(DragDropItemBase dragDropItem, PointerEventData eventData) { }

}

