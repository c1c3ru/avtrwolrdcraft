namespace Game.Level.ContextualAnimation;

public abstract class LevelCABabyOnCharacterHandlerBase : LevelCAItemOnBoneHandlerBase
{

	protected LevelCABabyOnCharacterHandlerBase() { }

	protected virtual void Awake() { }

	public virtual SpineType GetSpineType() { }

	private bool HasCarrierSibling() { }

	public virtual bool IsValidForTarget(ICATarget target) { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	protected override void OnBeforePlacedOnCharacter(ILevelAvatar avatar, ItemOnAvatarType itemOnAvatarType) { }

	protected virtual void OnDestroy() { }

	protected virtual void OnReadyPostLoad() { }

	protected override void OnRemovedFromCharacter(ILevelAvatar avatar) { }

	protected override void PlayBabyIdle() { }

	protected void PlayReactionAnimation(string animationName, bool isLoop) { }

	protected void RefreshSkeletonAnimation(ILevelAvatar avatar) { }

	protected void RemoveSkin(Skin mainSkin, Skin skinToRemove) { }

	protected override bool ShouldDeferToCarrierSibling() { }

	protected bool TryOverridePreBeginDrag(DragDropItemBase dragDropItem, PointerEventData eventData) { }

}

