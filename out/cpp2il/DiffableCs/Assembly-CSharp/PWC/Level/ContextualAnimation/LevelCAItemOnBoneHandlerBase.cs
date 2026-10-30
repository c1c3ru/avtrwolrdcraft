namespace PWC.Level.ContextualAnimation;

public abstract class LevelCAItemOnBoneHandlerBase : LevelCAItemHandlerBase
{
	private BoneFollower _currentBoneFollower; //Field offset: 0x88
	protected ILevelAvatar _currentHolder; //Field offset: 0x90

	protected LevelCAItemOnBoneHandlerBase() { }

	private void AddItemToBone() { }

	protected abstract string GetBoneName() { }

	protected override ItemOnAvatarType GetItemOnAvatarType() { }

	protected override Nullable<Vector2> GetPivotOnBone() { }

	protected override bool IsFollowScale() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	private void RemoveItemFromBone() { }

	protected virtual bool SnapItemToAvatar(ILevelAvatar avatar, ItemOnAvatarType itemOnAvatarType, LevelItem levelItem) { }

}

