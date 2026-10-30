namespace PWC.Level.ContextualAnimation;

public abstract class LevelCAItemWithSkinHandlerBase : LevelCAItemHandlerBase
{
	private Skin _skin; //Field offset: 0x88
	private bool _isSkinOn; //Field offset: 0x90
	private BoneFollower _currentBoneFollower; //Field offset: 0x98
	private Renderer[] _renderers; //Field offset: 0xA0
	protected ILevelAvatar _currentHolder; //Field offset: 0xA8

	protected LevelCAItemWithSkinHandlerBase() { }

	public void AddSkinAndHideItem(AvatarSpineSkinsManagerBase skinManager) { }

	protected virtual void Awake() { }

	protected override string GetBoneName() { }

	public Renderer[] GetRenderers() { }

	private Skin GetSkin() { }

	protected abstract string GetSkinName() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual void OnRemovedFromTarget(ICATarget target) { }

	protected override void OnSkinAdded() { }

	protected override void OnSkinRemoved() { }

	public void RemoveSkinAndShowItem() { }

}

