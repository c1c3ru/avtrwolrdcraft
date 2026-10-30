namespace Game.Level.ContextualAnimation;

public class LevelCAScissorsCraftingItemHandler : LevelCAItemCraftingHandlerBase
{
	[SerializeField]
	protected SkeletonAnimation _skeletonAnimation; //Field offset: 0xD8
	[SerializeField]
	[SpineAnimation(null, null, True, False, False, dataField = "_skeletonAnimation")]
	protected string _craftingAnimationName; //Field offset: 0xE0

	public LevelCAScissorsCraftingItemHandler() { }

	protected virtual void Awake() { }

	protected virtual string GetAnimationNameForAllConfigItems() { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	protected virtual void OnDestroy() { }

	private void OnSpineAnimationEvent(TrackEntry trackEntry, Event spineEvent) { }

}

